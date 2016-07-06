using System;
using System.Windows;
using AvalonDock;
using System.Data;
using Maticsoft.BLL;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
using System.Collections;


namespace UI
{
    /// <summary>
    /// UserControl_Report.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_OrderControl : DocumentContent
    {
        public UserControl_OrderControl()
        {
            InitializeComponent();
        }
        DataSet ds_Record = new DataSet();                                       //数据记录
        Maticsoft.BLL.ZMing zm = new Maticsoft.BLL.ZMing();                      //公共类
        ZhuifengLib.JudgeOddOrEven _Judge_Odd = new ZhuifengLib.JudgeOddOrEven(); //判断奇偶
        int DeleteRecord = 0;                                                    //待删除记录

        #region 公共模块
        /*****************************   公共模块   *********************************/
        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            // 查询下拉菜单
            string[] ti = new string[12];
            ti[0] = "未包装";
            ti[1] = "已包装";
            ti[2] = "未装箱";
            ti[3] = "已装箱";
           // ti[4] = "未打印";
           // ti[5] = "已打印";
            ti[6] = "ClientSN";
            ti[7] = "PigtailSN";
            ti[8] = "SN查询";
            ti[9] = "原始数据3D";
            ti[10] = "原始数据JDS";
            ti[11] = "删除记录";
            cmb_Find_Option.ItemsSource = ti;
            //删除下拉菜单
            string[] tt = new string[4];
            tt[0] = "已包装";
           // tt[1] = "已打印";
            tt[2] = "已装箱";
            tt[3] = "删除条码";
            cmb_Delete_Option.ItemsSource = tt;         
        }
        
        //结构体定义  传递删除参数
        private struct DataDelivery
        {
            public string _BarCode;           //数据
            public int Option;               //选项数据
            public bool? IsDeleteSourceData; //是否删除原始数据
            public object[] SNlist;         //SN数据

        }
        /*  End  */

        #endregion



        #region 删除数据
        /*****************************   删除条码  *********************************/
        //
        //删除数据
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            User_Verify f = new User_Verify();
            f.ShowDialog();
            if (f.Result_InspectUser == true && f.SysUser.Privilege == "系统管理员" || f.SysUser.Privilege == "主管" || f.SysUser.Privilege == "工程师" || f.SysUser.Privilege == "助理")
            {
                My_MessageBox.My_MessageBox_Message("用户：" + f.SysUser.UserName);
                DataDelivery temData = new DataDelivery();
                
                object[] temList = new string[this.lst_DeleteList.Items.Count];
                lst_DeleteList.Items.CopyTo(temList, 0);

                temData.Option = cmb_Delete_Option.SelectedIndex;
                temData.SNlist = temList;

                temData.IsDeleteSourceData = ckb_DeleteSorceData.IsChecked; 
              

                if (temData.Option != -1)     //如果已经选择
                {
                    if (temData.Option == 3 ) //如果为删除源码
                    {
                        if (f.SysUser.Privilege == "助理" || f.SysUser.Privilege == "系统管理员")
                        {
                            DeleteSN_List(temData);
                        }
                        else
                        {
                            My_MessageBox.My_MessageBox_Message("对不起！您无权删除原始条码！请联系系统管理员或工程师！");
                        }
                    }
                    else
                    {
                        DeleteSN_List(temData);
                    }
                }           
                lst_DeleteList.Items.Clear();
                DeleteRecord = 0;
                lab_DeleteRecord.Text = DeleteRecord + "条";

                MCP_CS._Operation_log.UserName = f.SysUser.UserName;
                MCP_CS._Operation_log.Operation = "删除";
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未执行，操作被用户终止！或未通过验证 请确定您是否有权限删除数据！");
            }
        }
       
        //
        //从待删除列表中移除选中项
        //
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (lst_DeleteList.SelectedItem != null)
            {
                lst_DeleteList.Items.Remove(lst_DeleteList.SelectedItem);
                if (DeleteRecord > 0)
                {
                    DeleteRecord--;
                    lab_DeleteRecord.Text = DeleteRecord + "条";
                }
            }
        }
        
        //删除数据
        private void DeleteSN_List(DataDelivery e)
        {
            try
            {
                SerialNumber sn = new SerialNumber();
                tb_PrintRecord print = new tb_PrintRecord();
                int temRecordCount = 0;
                switch (e.Option)
                {
                    //删除已包装
                    case 0:
                        Update_SN_TO_Not_Pack(ref e, sn, ref temRecordCount);
                        break;
                    //删除已打印
                    case 1:
                        foreach (object _sn in e.SNlist)
                        {
                            string tem = "";
                            if (_sn.ToString().Length > 10) { tem = _sn.ToString().Substring(0, 10); } else { tem = _sn.ToString(); }
                            print.Delete(tem);
                            temRecordCount++;
                        }
                        My_MessageBox.My_MessageBox_Message("成功删除已打印:" + temRecordCount + "");
                        break;
                    //删除已装箱
                    case 2:
                        foreach (object _sn in e.SNlist)
                        {
                            Maticsoft.Model.SerialNumber _serialNumber = sn.GetModel(_sn.ToString());
                            _serialNumber.State = Maticsoft.Model.E_Barcode_State.Not_Encasement.ToString();
                            if (sn.Update(_serialNumber))
                            {
                                temRecordCount++;
                            }
                        }
                        My_MessageBox.My_MessageBox_Message("成功删除已装箱" + temRecordCount + "");
                        break;
                    case 3:
                        foreach (object _sn in e.SNlist)
                        {                           
                            if (sn.Delete(_sn.ToString()))
                            {
                                temRecordCount++;
                            }
                        }
                        My_MessageBox.My_MessageBox_Message("成功删除条码" + temRecordCount + "");
                        break;
                    default:
                        My_MessageBox.My_MessageBox_Message("不包含此项目");
                        break;
                }
            }
            catch (Exception ex)
            {
                My_MessageBox.My_MessageBox_Message(ex.Message);
            }
        }

        /// <summary>
        ///  条码更改为 未包装
        /// </summary>
        private static void Update_SN_TO_Not_Pack(ref DataDelivery e, SerialNumber sn, ref int temRecordCount)
        {
            //原始数据删除数量 计数
            int temCount = 0;
            int fillDelete_snCount = 0;
            string fillDelete_snList = "";
            Pack_3D pk_3d = new Pack_3D();
            Pack_Exfo pk_Exfo = new Pack_Exfo();
            Maticsoft.BLL.User_3D_Test_Good user3D = new User_3D_Test_Good();
            string temSN = "";
            foreach (object _sn in e.SNlist)
            {
                //如果长度大于13 temSN = 前13位条码
               if (_sn.ToString().Length > 13) { temSN = _sn.ToString().Substring(0, 10); } else { temSN = _sn.ToString(); }
                temSN = _sn.ToString(); 

                //删除原始数据
                if (e.IsDeleteSourceData == true)
                {
                    //删除3D数据
                    if (_sn.ToString().Length > 13)
                    {
                        if (user3D.Delete(_sn.ToString(), 1))
                        { temCount++; }
                    }
                    else
                    {
                        Maticsoft.BLL.MultiFiber _MPO_3D = new MultiFiber();
                        if (user3D.Delete(_sn.ToString(), 2) || _MPO_3D.Delete(_sn.ToString()))
                        { temCount++; }
                    }
                    //删除Exfo数据

                }
                //删除Pack中的数据                    
                pk_Exfo.Delete("SN Like '" + temSN + "%'");
                pk_3d.Delete("SN Like '" + temSN + "%'");

                //将已包装改写为未包装                                              
                Maticsoft.Model.SerialNumber _serialNumber = sn.GetModel(temSN);
                if (_serialNumber != null)
                {
                    _serialNumber.State = Maticsoft.Model.E_Barcode_State.Not_Pack.ToString();
                    //如果更新成功
                    if (sn.Update(_serialNumber)) { temRecordCount++; } else { fillDelete_snCount++; }
                }
                else { fillDelete_snCount++; }
                MCP_CS._Operation_log.Remarks += "," + _sn;

            }
            MCP_CS._Operation_log.DateTime = DateTime.Now;
            MCP_CS.Operation_Log.Add(MCP_CS._Operation_log);  //添加删除记录
            My_MessageBox.My_MessageBox_Message("成功删除已包装:" + temRecordCount + "条  原始数据:" + temCount + "条；\r\n失败" + fillDelete_snCount + "条  \r\n"+fillDelete_snList);
       
        }
        
        //添加到待删除列表      
        private void btn_Add_DeleteList_Click(object sender, RoutedEventArgs e)
        {           
            Add_DeleteSN_To_List(txb_Delete_BarCode.Text.Trim());
            txb_Delete_BarCode.Text = "";
        }

              
      
        //
        //待删除条码 添加框 Key_Up 事件
        //     
        private void txb_Delete_BarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txb_Delete_BarCode.IsFocused && e.Key == Key.Enter && ckb_Delete_Add_autot.IsChecked == true)
            {
                Add_DeleteSN_To_List(txb_Delete_BarCode.Text.Trim());
                txb_Delete_BarCode.Text = "";
            }        
        }

        //
        //打开模板——删除
        //
        private void btn_Edit_Delete_Click(object sender, RoutedEventArgs e)
        {
            ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();
            string err;
            _M_excel.OpenExcel("D:\\模板\\DeleteListTemplate.xlsx", out err);
        }

        //
        //导入模板——删除
        //
        private void btn_Inpu_Delete_SN_Click(object sender, RoutedEventArgs e)
        {
            ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();


            lst_DeleteList.Items.Clear();
            lab_DeleteRecord.Text = "0";

            DataSet temds = new DataSet();
            temds = _M_excel.ExcelReader("D:\\模板\\DeleteListTemplate.xlsx");
            if (temds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in temds.Tables[0].Rows)
                {                   
                    Add_DeleteSN_To_List(dr["SN"].ToString());
                }
            }
            lab_DeleteRecord.Text = lst_DeleteList.Items.Count.ToString();

            //让滚动条自动滚东到底部
            lst_DeleteList.UpdateLayout();//此句是关键  
            //如果不加上面那句的话，不会滚动到最底端，最后一个控件会看不见，加了上面这句刷新下ListBox的布局,就可以滚动到最底端了
            lst_DeleteList.ScrollIntoView(lst_DeleteList.Items[lst_DeleteList.Items.Count - 1]);
        }



        /// <summary>
        /// 添加SN 到 待删除列表
        /// </summary>
        private void Add_DeleteSN_To_List(string temSN)
        {
            try
            {
                Maticsoft.Model.SerialNumber _temSetial = new Maticsoft.Model.SerialNumber();
                Maticsoft.BLL.SerialNumber _M_serial = new SerialNumber();
                Maticsoft.Model.WorkOrder _order = new Maticsoft.Model.WorkOrder();
                Maticsoft.BLL.WorkOrder _M_order = new WorkOrder();
                if (temSN != "")
                {
                    if (temSN.Length > 13)
                    {
                        lst_DeleteList.Items.Add(temSN);
                        DeleteRecord++;
                    }
                    else
                    {

                        _temSetial = _M_serial.GetModel(temSN);
                        //
                        if (_temSetial != null)
                        {
                            _order = _M_order.GetModel(_temSetial.OrderID);
                            if (_order.InspectMethod == Maticsoft.Model.E_InspectMethod.两码两签)
                            {
                                ZhuifengLib.JudgeOddOrEven judge = new ZhuifengLib.JudgeOddOrEven();
                                System.Collections.Generic.List<long> temList = new System.Collections.Generic.List<long>();
                                temList = _Judge_Odd.Get_TwoList(temSN);
                                //
                                DeleteRecord++;
                                lst_DeleteList.Items.Add(temList[0].ToString());
                                DeleteRecord++;
                                lst_DeleteList.Items.Add(temList[1].ToString());
                            }
                            else
                            {
                                lst_DeleteList.Items.Add(temSN);
                                DeleteRecord++;
                            }

                        }
                        else { My_MessageBox.My_MessageBox_Message("未找到该条码！"); txb_Delete_BarCode.SelectAll(); }
                    }

                    //显示添加了多少条               
                    lab_DeleteRecord.Text = DeleteRecord + "条";
                    //让滚动条自动滚东到底部
                    lst_DeleteList.UpdateLayout();//此句是关键  
                    //如果不加上面那句的话，不会滚动到最底端，最后一个控件会看不见，加了上面这句刷新下ListBox的布局,就可以滚动到最底端了
                    lst_DeleteList.ScrollIntoView(lst_DeleteList.Items[lst_DeleteList.Items.Count - 1]);
                }
            }
            catch { }
        }
       
        /*  End  */

        #endregion



        #region 数据查询
        /*****************************   数据查询  *********************************/
        //
        //
        //查找数据
        private void btn_Find_Click(object sender, RoutedEventArgs e)
        {
            DataDelivery temdata = new DataDelivery();
            temdata.Option = cmb_Find_Option.SelectedIndex;
            temdata._BarCode = txb_Find_OrderID.Text;
            FindData(temdata);
        }
        //
        //导出到Excel
        //
        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
           zm.DataGridViewToExcel(ds_Record.Tables[0]);        
        }
        //数据查看
        private void FindData(DataDelivery e)
        {
            Maticsoft.BLL.SerialNumber sn = new Maticsoft.BLL.SerialNumber();    //条码操作类
            Type BarcodeState = typeof(Maticsoft.Model.E_Barcode_State);         //条码状态
            string s = BarcodeState.GetEnumName(e.Option);  //根据 索引获取 字符串  结果为 red 

            Maticsoft.BLL.Pack_3D _M_Pack3D = new Pack_3D();
            SerialNumber _M_SerialNumber = new SerialNumber();
            switch (e.Option)
            {
                case 0: //未包装                                                    
                    ds_Record = sn.GetList("(State = '" + s + "') AND (OrderID = '" + txb_Find_OrderID.Text + "')");
                    break;
                case 1: //已包装                                    
                    ds_Record = sn.GetList("(State = '" + s + "') AND (OrderID = '" + txb_Find_OrderID.Text + "')");
                    break;
                case 2: //未装箱                                     
                    ds_Record = sn.GetList("(State = '" + s + "') AND (OrderID = '" + txb_Find_OrderID.Text + "')");
                    break;
                case 3: //已装箱                                    
                    ds_Record = sn.GetList("(State = '" + s + "') AND (OrderID = '" + txb_Find_OrderID.Text + "')");
                    break;
                case 4: //未打印
                    break;
                case 5: //已打印
                    Maticsoft.BLL.tb_PrintRecord print_Record = new tb_PrintRecord();
                    ds_Record = print_Record.GetList("(OrderID = '" + txb_Find_OrderID.Text + "')");
                    break;
                case 6://客户编码                   
                    ds_Record = _M_Pack3D.GetList("ClientSN ='"+txb_Find_OrderID.Text.Trim()+"'");
                   // ds_Record = _M_Pack3D.Get_PackData(txb_Find_OrderID.Text.Trim(), Maticsoft.Model.E_InspectMethod.配组_四十八芯);
                    break;
                case 7://客户编码                  
                    ds_Record = _M_Pack3D.GetList("SN ='" + txb_Find_OrderID.Text.Trim() + "'");
                    break;
                case 8://SN查询
                    ds_Record = _M_SerialNumber.GetList("SN ='" + txb_Find_OrderID.Text.Trim() + "'");
                    break;
                case 9 : //原始数据3D查询 根据SN
                    ds_Record = MCP_CS._M_User_3D_Test_Good.GetList("SN LIKE '"+txb_Find_OrderID.Text.Trim()+"%'");
                    break;
                case 10: //原始数据JDS查询 根据SN
                    ds_Record = MCP_CS._M_User_JDS_Test_Good.GetList("SN LIKE '" + txb_Find_OrderID.Text.Trim() + "%'");
                    break;
                case 11 : //删除记录查询                   
                    ds_Record = MCP_CS.Operation_Log.GetList("Remarks LIKE '%" + txb_Find_OrderID.Text.Trim() + "%'");
                    break;

            }
            dgv_Info.ItemsSource = ds_Record.Tables[0].DefaultView;                       //显示控件中显示
            lab_Record.Text = ds_Record.Tables[0].Rows.Count.ToString() + "条";           //记录数量   
        }
        /*  End  */
        #endregion



        #region 添加条码
        //-------------------------------------------------------------------------------
        //                             添加条码
        //
        //-------------------------------------------------------------------------------
        
        //
        //工单单号
        //
        private void txb_Addser_OrderID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_Addser_OrderID.IsFocused)
            {
                Maticsoft.BLL.PackBatch _M_PackBatch = new PackBatch();             
                cmb_AddSer_BatchNo.ItemsSource = _M_PackBatch.GetList("OrderID ='" + txb_Addser_OrderID.Text.Trim() + "'").Tables[0].DefaultView;
                if (cmb_AddSer_BatchNo.Items.Count > 0)
                {
                    cmb_AddSer_BatchNo.SelectedIndex = 0;
                }
            }
        }

        //
        //从Excel中导入条码
        //
        private void btn_InPut_AddSN_Click(object sender, RoutedEventArgs e)
        {
            ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();

            lst_Add_SNList.Items.Clear();
            lab_Add_Count.Text = "0";

            DataSet temds = new DataSet();
            temds = _M_excel.ExcelReader("D:\\模板\\DeleteListTemplate.xlsx");
            if (temds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in temds.Tables[0].Rows)
                {
                    lst_Add_SNList.Items.Add(dr["SN"]);
                }
            }
            lab_Add_Count.Text = lst_Add_SNList.Items.Count.ToString();

            //让滚动条自动滚东到底部
            lst_Add_SNList.UpdateLayout();//此句是关键  
            //如果不加上面那句的话，不会滚动到最底端，最后一个控件会看不见，加了上面这句刷新下ListBox的布局,就可以滚动到最底端了
            lst_Add_SNList.ScrollIntoView(lst_Add_SNList.Items[lst_Add_SNList.Items.Count - 1]);
        }

        //
        //编辑Excel
        //
        private void btn_Edit_Add_Click(object sender, RoutedEventArgs e)
        {
            ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();
            string err;
            _M_excel.OpenExcel("D:\\模板\\DeleteListTemplate.xlsx", out err);
        }

        //
        //保存
        //
        private void btn_AddSer_Save_Click(object sender, RoutedEventArgs e)
        {

            Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();
            Maticsoft.Model.SerialNumber _SerialNumber = new Maticsoft.Model.SerialNumber();
            if (txb_Addser_OrderID.Text != "" && cmb_AddSer_BatchNo.Text != "" && cmb_AddSer_Type.Text != "")
            {
                //               
                Maticsoft.Model.SerialNumber Tem = new Maticsoft.Model.SerialNumber();
                Tem.OrderID = txb_Addser_OrderID.Text.Trim();
                Tem.BatchNO = cmb_AddSer_BatchNo.Text.Trim();
                Tem.State = "Not_Pack";
                Tem.Type = cmb_AddSer_Type.Text.Trim();
                int temcount = 0;
                string NG_SNlist = "";

                foreach (object _SN in lst_Add_SNList.Items)
                {
                    _SerialNumber = _M_SerialNumber.GetModel(_SN.ToString());
                    if (_SerialNumber == null)
                    {
                        Tem.SN = _SN.ToString();
                        _M_SerialNumber.Add(Tem);
                        temcount++;
                    }
                    else
                    {
                        NG_SNlist += "\r\n" + _SerialNumber.ToString();
                    }
                }

                My_MessageBox.My_MessageBox_Message("保存成功！\r\n增加：" + temcount.ToString()
                    + "条 失败：" + (lst_Add_SNList.Items.Count - temcount) + NG_SNlist);
                lab_Add_Count.Text = "0";
                lst_Add_SNList.Items.Clear();
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未保存，信息不完整！");
            }

        }

      
        #endregion

       


       
        /*****************************   END  *********************************/
    }
}
