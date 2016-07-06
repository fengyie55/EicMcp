using AvalonDock;
using System.Windows.Media;
using System.Windows.Input;
using Maticsoft.BLL;
using System.Data;
using System.Threading;
using System;

namespace UI
{
    /// <summary>
    /// UserControl_Inspect_Packaging.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_Pigtail_Inspect : DocumentContent
    {
        public UserControl_Pigtail_Inspect()
        {
            InitializeComponent();
        }


        #region 变量

        Color _Mycolor = Color.FromRgb(58, 157, 82);                  //默认透明度为255；Red=58, Green=157, Blue=82
        Color _Mycolor2 = Color.FromArgb(255, 58, 157, 82);           //透明度=255 ，Red=58, Green=157, Blue=82
        //
        WorkOrder _M_WorkOrder = new WorkOrder();
        PackBatch _M_PackBatch = new PackBatch();                               //包装批号
        SerialNumber _M_SerialNumber = new SerialNumber();
        //
        Maticsoft.Model.WorkOrder _WorkOrder = new Maticsoft.Model.WorkOrder();
        Maticsoft.Model.PackBatch _PackBatch = new Maticsoft.Model.PackBatch();
        //
        My_Inspect _WTT_Inspect = new My_Inspect();
        //
        DataSet _WTT_Exfo_Data = new DataSet();
        DataSet _WTT_3D_Data = new DataSet();

       // int _WTT_FillCount_3D = 0;
       // int _WTT_FillCount_Exfo = 0;

      //  string _WTT_SN_One = "";
        #endregion


        #region 控件

        //
        //工单单号输入
        //
        private void txb_Orderid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_Orderid.IsFocused)
            {
                if (txb_Orderid.Text != "")
                {
                    txb_ClientSN.Text = "";
                    txb_Orderid.IsEnabled = false;
                    cmb_BatchNo.IsEnabled = true;
                    _WorkOrder = _M_WorkOrder.GetModel(txb_Orderid.Text.Trim());
                    if (_WorkOrder != null)
                    {
                        showOption(_WorkOrder.InspectMethod);
                        shouOrderInfo(_WorkOrder);
                        cmb_BatchNo.DataContext = _M_PackBatch.GetList(" OrderID ='" + txb_Orderid.Text + "'").Tables[0];
                        cmb_BatchNo.DisplayMemberPath = "BatchNo";
                        //检测设置工单
                        My_Inspect _TemInspect = new My_Inspect();
                        _TemInspect.WorkOrder = _WorkOrder;
                        _WTT_Inspect = _TemInspect;
                        lab_Title.Content = "订单中心——" + _WorkOrder.InspectMethod;
                    }
                    else { My_MessageBox.My_MessageBox_Message("未找到工单信息！"); }        
                }
                else { My_MessageBox.My_MessageBox_Message("工单单号不能为空"); }           
            }
        }

        //
        //包装批号
        //
        private void cmb_BatchNo_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cmb_BatchNo.Text != "")
            {
                _PackBatch = _M_PackBatch.GetModel(cmb_BatchNo.Text.Trim());
                cmb_BatchNo.IsEnabled = false;
                Info_Batch_Count.Text = _PackBatch.Count.ToString();
                Info_YetPack_Count.Text = _M_SerialNumber.Get_PackCount_Batch("BatchNo ='" + cmb_BatchNo.Text.Trim() + "' AND (Type = 'ClientSN') AND State ='Yet_Pack'").ToString();
                //
                _WTT_Inspect.PackBatch = _PackBatch;
                _WTT_Inspect.IsUpdate = false;
                _WTT_Inspect.IsPrint = false;

                if (
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯
                    )
                {
                    txb_ClientSN.Text = _M_SerialNumber.Get_MinSN(_WorkOrder.OrderID, Maticsoft.Model.E_SerialNumber_Type.ClientSN);
                    //待包装线号
                    txb_ClientNum.Text = _WTT_Inspect.Get_Client_NotPack_PigtailNum(txb_ClientSN.Text.Trim());
                }

                //获取8芯配组ClientSN
                else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL ||
                     _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯_SAMHALL
                    || _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯_SAMHALL ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯_SAMHALL)
                {
                    txb_ClientSN.Text = _M_SerialNumber.Get_MinSN(txb_Orderid.Text.Trim(), Maticsoft.Model.E_SerialNumber_Type.ClientSN, "");
                    //待包装线号
                    txb_ClientNum.Text = _WTT_Inspect.Get_Client_NotPack_PigtailNum(txb_ClientSN.Text.Trim());
                }


                //验证此批号是否包装完成
                if (Info_Batch_Count.Text.Trim() == Info_YetPack_Count.Text.Trim())
                {
                    txb_Pigtailsn.IsEnabled = false;
                    My_MessageBox.My_MessageBox_Message("批号：" + _PackBatch.BatchNo + "  数量：" + _PackBatch.Count + "已包装：" + Info_YetPack_Count + "\r\n包装完成！");
                }
                else
                {
                    txb_Pigtailsn.IsEnabled = true;
                }
                cmb_LabName.Text = _WTT_Inspect.My_Print.LabName;

            }
        }


        //
        //条码输入框
        //       
        private void txb_Pigtailsn_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && txb_Pigtailsn.IsFocused)
                {
                    if (txb_Pigtailsn.Text != "")   //条码不能为空
                    {
                        InspectSN(txb_ClientSN.Text.Trim(), txb_Pigtailsn.Text.Trim());
                    }
                    else { My_MessageBox.My_MessageBox_Message("条码不能为空"); }
                }
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message + "\r\n此条码数据异常！\r\n请至→工单管理→删除此条码的测试数据后重新存档！！！"); }
        }

        private void InspectSN(string ClientSN, string PigtailSN)
        {
            lab_ErrList.Content = "";  // string PigtailSN;
            //如果检测类型是12芯x2 则将条码设置为 10位
            if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2 && PigtailSN.Length > 10)
            {
                PigtailSN = PigtailSN.Substring(0, 10);
            }
            //初始化参数
            My_Inspect.InspectEventArgs _SN = new My_Inspect.InspectEventArgs(ClientSN, PigtailSN);           
            //进行检测
            if (_WTT_Inspect.InspectStart(_SN))
            {
                SolidColorBrush myBrush = new SolidColorBrush(_Mycolor); //定义纯色绘制 变量
                lab_Result.Content = "PASS"; lab_Result.Foreground = myBrush;
                txb_Pigtailsn.Text = "";
            }
            else
            {
                if (_SN.InspectResult.ErrorList == "")
                {
                    //在单独线程播放异常提示音
                    Thread t = new Thread(MyPlay);
                    t.IsBackground = true;
                    t.Start();

                    lab_Result.Content = "FAIL"; lab_Result.Foreground = Brushes.Red;
                    txb_Pigtailsn.SelectAll(); //选择文本框中的内容          
                    // My_MessageBox.My_MessageBox_Message("注意！此条码为不良品！请查看结果窗口");
                    lab_ErrList.Content = "此条码为不良品!";
                }
                else
                {
                    //在单独线程播放异常提示音
                    Thread t = new Thread(MyPlay);
                    t.IsBackground = true;
                    t.Start();

                    lab_Result.Content = "";
                    txb_Pigtailsn.SelectAll(); //选择文本框中的内容
                    My_MessageBox.My_MessageBox_Message(_SN.InspectResult.ErrorList);
                    // lab_ErrList.Content = _SN.InspectResult.ErrorList;
                }
            }
            Show_InspectResult(_SN);  //显示与统计
            Set_CombinationInfo(_SN);  //配组完成
        }

        /// <summary>
        /// 显示检测结果
        /// </summary>
        /// <param name="_SN"></param>
        private void Show_InspectResult(My_Inspect.InspectEventArgs _SN)
        {
            txb_Result_Fill_3D.Text = _SN.InspectResult.Fill_3D;            //3D不良接头
           
            txb_Result_Fill_Exfo.Text = _SN.InspectResult.Fill_Exfo;        //Exfo不良接头
           
            if (_SN.InspectResult.Data_3D != null)
            {
                dgv_Data_3D.ItemsSource = _SN.InspectResult.Data_3D.Tables[0].DefaultView;
            }
            if (_SN.InspectResult.Data_Exfo != null)
            {
                dgv_Data_Exfo.ItemsSource = _SN.InspectResult.Data_Exfo.Tables[0].DefaultView;
            }
        }

        /// <summary>
        /// 配组完成
        /// </summary>
        /// <param name="_SN"></param>
        private void Set_CombinationInfo(My_Inspect.InspectEventArgs _SN)
        {
            if (_SN.InspectResult.Combination)
            {
                if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯 ||
                     _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯 ||
                      _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯)
                {
                    txb_ClientSN.Text = _M_SerialNumber.Get_MinSN(_WorkOrder.OrderID, Maticsoft.Model.E_SerialNumber_Type.ClientSN);
                    //待包装线号
                    txb_ClientNum.Text = _WTT_Inspect.Get_Client_NotPack_PigtailNum(txb_ClientSN.Text.Trim());
                }
                //获取8芯配组ClientSN
                else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL ||
                     _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯_SAMHALL
                     || _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯_SAMHALL ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯_SAMHALL)
                {
                    txb_ClientSN.Text = _M_SerialNumber.Get_MinSN(txb_Orderid.Text.Trim(), Maticsoft.Model.E_SerialNumber_Type.ClientSN, "");
                    //待包装线号
                    txb_ClientNum.Text = _WTT_Inspect.Get_Client_NotPack_PigtailNum(txb_ClientSN.Text.Trim());
                }
                My_MessageBox.My_MessageBox_Message("客户编码：" + txb_ClientSN.Text + "\r\n配组完成!");
            }
            //更新已包装数
            Info_YetPack_Count.Text = _M_SerialNumber.Get_PackCount_Batch("BatchNo ='" + cmb_BatchNo.Text.Trim() + "' AND (Type = 'ClientSN') AND State ='Yet_Pack'").ToString();

            //待包装线号
            txb_ClientNum.Text = _WTT_Inspect.Get_Client_NotPack_PigtailNum(txb_ClientSN.Text.Trim());

            //验证此批号是否包装完成
            if (Info_Batch_Count.Text.Trim() == Info_YetPack_Count.Text.Trim())
            {
                txb_Pigtailsn.IsEnabled = false;
                My_MessageBox.My_MessageBox_Message("批号：" + _PackBatch.BatchNo + "  数量：" + _PackBatch.Count + "已包装：" + Info_YetPack_Count + "\r\n包装完成！");
            }
        }
       
        //
        //验证框 工单单号
        //
        private void ckb_OrderID_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ckb_OrderID.IsChecked == true) { txb_Orderid.IsEnabled = true; }
        }
        //
        //验证框 包装批号
        //
        private void ckb_BatchNo_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ckb_BatchNo.IsChecked == true) { cmb_BatchNo.IsEnabled = true; }
        }
        
        #endregion


        #region Method

        /************************** Method **************************/      
        //根据工单类型决定显示和隐藏相应的控件
        private void showOption(Maticsoft.Model.E_InspectMethod _Imethod)
        {
            txb_ClientSN.Visibility = System.Windows.Visibility.Visible;
            if (_Imethod == Maticsoft.Model.E_InspectMethod.一码一签)
            {
                lab_Note_ClientSN.Visibility = System.Windows.Visibility.Hidden;
                lab_Note_NotPigtailNum.Visibility = System.Windows.Visibility.Hidden;                           
                txb_ClientNum.Visibility = System.Windows.Visibility.Hidden;
                txb_ClientSN.Visibility = System.Windows.Visibility.Hidden;              
            }
            else if (_Imethod == Maticsoft.Model.E_InspectMethod.双并检测 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.四芯检测 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.八芯检测 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.十二芯检测 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.FFOS_四芯 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.FFOS_八芯 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.FFOS_十六芯 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.FFOS_二十四芯 ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.FFOS_三十二芯  ||
                     _Imethod == Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2||
                     _Imethod == Maticsoft.Model.E_InspectMethod.两码两签||
                     _Imethod == Maticsoft.Model.E_InspectMethod.MPO检测)
            {
                lab_Note_ClientSN.Visibility = System.Windows.Visibility.Hidden;
                txb_ClientSN.Visibility = System.Windows.Visibility.Hidden;
                txb_ClientNum.Visibility = System.Windows.Visibility.Hidden;
                lab_Note_NotPigtailNum.Visibility = System.Windows.Visibility.Hidden;
            }
            txb_ClientSN.IsEnabled = false; //客户编码输入栏 不可编辑

            //根据工单检测类型决定是否隐藏 结果显示控件
            txb_Result_Fill_3D.Visibility = System.Windows.Visibility.Hidden;
            txb_Result_Fill_Exfo.Visibility = System.Windows.Visibility.Hidden;
            
            if (_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D)
            {
                txb_Result_Fill_3D.Visibility = System.Windows.Visibility.Visible;
            }
            else if (_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
            {
                txb_Result_Fill_Exfo.Visibility = System.Windows.Visibility.Visible;
            }
            else if (_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
            {
                txb_Result_Fill_Exfo.Visibility = System.Windows.Visibility.Visible;
                txb_Result_Fill_3D.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //显示工单信息
        private void shouOrderInfo(Maticsoft.Model.WorkOrder _workOrderInfo)
        {
            Info_OrderID_Count.Text = _workOrderInfo.Count;
            Info_PeoductName.Text = _workOrderInfo.ProductName;            
            Info_Model.Text = _workOrderInfo.Model;           
            Info_DeliveryDate.Text = _workOrderInfo.DeliveryDate;                    
        }       
        //播放异常提示音
        private void MyPlay()
        {            
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            string temPath = System.AppDomain.CurrentDomain.BaseDirectory;
            player.SoundLocation = temPath + "Alert.wav";
            player.Load();
            player.Play();
        }

       
        #endregion

        //
        //设置标签
        //
        private void cmb_LabName_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        //
        //标签打印
        //
        private void btn_Print_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _WTT_Inspect.LabPrint(); 
        }

        //
        //批量刷条码 
        //
        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ZhuifengLib.EXCEL.ExcelControl _excelcontrol = new ZhuifengLib.EXCEL.ExcelControl();
            DataSet Temds = new DataSet();
            Temds = _excelcontrol.ExcelReader("D:\\模板\\DeleteListTemplate.xlsx");
            int t = 0;
            foreach (DataRow dr in Temds.Tables[0].Rows)
            {
                string _pigtailsn = dr["SN"].ToString();
                InspectSN("", _pigtailsn);
                t++;
                lab_Count_Show.Content = t + "/" + Temds.Tables[0].Rows.Count;
            }
            My_MessageBox.My_MessageBox_Message("终于结束了！");
        }

       
        /*************************** The End */         
    }
}
