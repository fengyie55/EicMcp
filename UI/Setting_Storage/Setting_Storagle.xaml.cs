using AvalonDock;
using Maticsoft.BLL;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System;
using System.Data;
using System.Windows.Data;



namespace UI
{
    /// <summary>
    /// Setting_Storagle.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_Storagle_Content : DocumentContent
    {
        public Setting_Storagle_Content()
        {
            InitializeComponent();
        }
    
        #region 全局变量

        /**************** 实体类   ************************/
        //工单信息
        ObservableCollection<Maticsoft.Model.WorkOrder> _workOrder
            = new ObservableCollection<Maticsoft.Model.WorkOrder>();
        //包装批号
        ObservableCollection<Maticsoft.Model.PackBatch> _packBatch
            = new ObservableCollection<Maticsoft.Model.PackBatch>();
       
        //检测标准
        ObservableCollection<Maticsoft.Model.InspectStandard> _ISD
            = new ObservableCollection<Maticsoft.Model.InspectStandard>();
        //工单物料
        DataSet _dt_OrderMaterial = new DataSet();

        /**************** 操作类   ************************/
        PackBatch _M_PackBatch = new PackBatch();                   //包装批号  
        WorkOrder _M_WorkOrder = new WorkOrder();                   //工单基本信息
        SerialNumber _M_SerialNumber = new SerialNumber();          //SN 编码
        InspectStandard _M_InspectStandard = new InspectStandard(); //检测标准
        /**************** 字段     ************************/
        string _TemMessage = "";                    //提示信息               
        #endregion

        #region 公共模块
        //
        //窗体载入事件处理程序
        //
        private void DocumentContent_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            cmb_InspectMethod.DataContext = System.Enum.GetNames(typeof(Maticsoft.Model.E_InspectMethod));
            dgv_Inspect_Standard_Info.ItemsSource = _ISD;   //检测标准 待保存列表
            dgv_PackBatch_Info.ItemsSource = _packBatch;    //包装批号 待保存列表                  
            lsv_BoxSN_List.DataContext = view;
            //条码列表
            lst_SN_List.ItemsSource = _GLL_Lst_SerialNumber;
        }
        //
        //工单信息查询
        //
        private void btn_Find_Order_Info_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Maticsoft.Model.WorkOrder wod = _M_WorkOrder.GetModel(txb_FindOrderID.Text.ToString());

            /******************** 工单基本信息 ********************************/
            if (wod != null)
            {
                txb_OrderID.Text = wod.OrderID;
                txb_ProductName.Text = wod.ProductName;
                txb_Model.Text = wod.Model;
                txb_Order_Count.Text = wod.Count;
                cmb_InspectMethod.Text = wod.InspectMethod.ToString();
                cmb_InspectType.Text = wod.InspectType.ToString();
                cmb_WorkShop.Text = wod.Workshop.ToString();
                date_DeliveryDate.Text = wod.DeliveryDate;
               // cmb_LabType.Text = wod.LabelType;             

                _ISD = _M_InspectStandard.GetModelList(txb_FindOrderID.Text);
                dgv_Inspect_Standard_Info.ItemsSource = _ISD;
                _packBatch = _M_PackBatch.GetModelList(" OrderID ='" + txb_FindOrderID.Text + "'");
                dgv_PackBatch_Info.ItemsSource = _packBatch;
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("工单：" + txb_FindOrderID.Text + "基本信息未找到！");
            }
        }
       

        #endregion

        #region 工单基本信息模块
        /****************************************** Controls ******************************************/
        //
        //保存工单基本信息
        //
        private void btn_Save_OrderInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //检查填写的信息是否完整
            if (txb_OrderID.Text == "" || txb_ProductName.Text == "" || txb_Model.Text == "" || txb_Order_Count.Text == "" ||
                cmb_InspectMethod.Text == "" || cmb_InspectType.Text == "" || date_DeliveryDate.Text == "" ||
                txb_Model.Text == ""   || cmb_WorkShop.Text == "")
            {
                My_MessageBox.My_MessageBox_Erry("请检查工单信息是否设置完整！\r\n请补充后重试！");
            }
            else
            {
                //如果数据库中已经有记录
                if (_M_WorkOrder.GetCount(txb_OrderID.Text.ToString()) > 0)
                {
                    if (MessageBox.Show("工单" + txb_OrderID.Text.ToString()
                        + "已经存在，继续将替换原有工单！\r\n是否继续添加", "系统提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                       // _M_WorkOrder.Delete(txb_OrderID.Text.ToString());    //删除原有数据     

                        Maticsoft.Model.WorkOrder _temWorkdOrder = new Maticsoft.Model.WorkOrder();
                        _temWorkdOrder = _M_WorkOrder.GetModel(txb_OrderID.Text.Trim());
                        Add_orderInfo(_temWorkdOrder);                                     //添加新数据数据
                    }
                }
                else { Add_orderInfo(); }                                   //添加数据
            }
        }
        /****************************************** Method ******************************************/
        /// <summary>
        /// 添加工单基本信息
        /// </summary>
        /// <returns></returns>
        private void Add_orderInfo()
        {
            Maticsoft.Model.WorkOrder _temWorkdOrder = new Maticsoft.Model.WorkOrder();
            _temWorkdOrder = _M_WorkOrder.GetModel(txb_OrderID.Text.Trim());
            Maticsoft.Model.WorkOrder _workOrder = new Maticsoft.Model.WorkOrder(){
                OrderID = txb_OrderID.Text.ToString(),    //工单单号
                Client = "Ezconn",
                ProductName = txb_ProductName.Text.ToString(),
                Model = txb_Model.Text.ToString(),
                Count = txb_Order_Count.Text.ToString(),
                //枚举类型的检测方法
                InspectMethod = (Maticsoft.Model.E_InspectMethod)Enum.Parse(typeof(Maticsoft.Model.E_InspectMethod),
                cmb_InspectMethod.SelectedItem.ToString(), false),
               
                //枚举类型检测选项
                InspectType =(Maticsoft.Model.E_InspectType)Enum.Parse(typeof(Maticsoft.Model.E_InspectType),
                cmb_InspectType.Text.ToString(),false),

                DeliveryDate = date_DeliveryDate.Text.ToString(),
              //  LabelType = cmb_LabType.Text.ToString(),
                ModelNo = txb_Model.Text.ToString(),           
                Workshop = cmb_WorkShop.Text.ToString(),
                State = "待生产" 
                 };
            

            //判断是否添加成功
            if (_M_WorkOrder.Add(_workOrder))
            {                
                _dt_OrderMaterial = _M_WorkOrder.GetOrderMaterial(txb_OrderID.Text);                                 //工单物料需领用量
               
                Add_orderMaterial(_dt_OrderMaterial);     //添加工单中的物料清单    
                Add_MaterialInfo(_dt_OrderMaterial);      //添加物料信息  暂时使用 用于收集物料信息                 
                //弹出提示信息               
                My_MessageBox.My_MessageBox_Message("工单" + txb_OrderID.Text.ToString() + "添加成功！");

                //保存条码
                if (txb_Stat_SN.Text != "")
                {
                    Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();
                    if (_M_SerialNumber.GetList("OrderID = '" + txb_OrderID.Text.Trim() + "'").Tables[0].Rows.Count < 1)
                    {
                        addSerialNumber(long.Parse(txb_Stat_SN.Text.ToString()), int.Parse(txb_Order_Count.Text));
                    }
                    else
                    {
                        if (MessageBox.Show("工单" + txb_OrderID.Text.ToString()
                            + "已经存在条码，继续将替换原有条码！\r\n是否继续添加", "系统提示",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            // _M_SerialNumber.DeleteList("OrderID = '" + txb_OrderID.Text.Trim() + "'");
                            addSerialNumber(long.Parse(txb_Stat_SN.Text.ToString()), int.Parse(txb_Order_Count.Text));
                        }
                    }
                }
                else { My_MessageBox.My_MessageBox_Message("开始条码 为空 将不进行条码添加！");  }
                #region 清空文本框
                txb_OrderID.Text = "";
                txb_ProductName.Text = "";
                txb_Model.Text = "";
                txb_Order_Count.Text = "";
                cmb_InspectMethod.Text = "";
                cmb_InspectType.Text = "";
                date_DeliveryDate.Text = "";               
                txb_Model.Text = "";               
                cmb_WorkShop.Text = "";              
                txb_Stat_SN.Text = "";
                _GLL_Lst_SerialNumber.Clear();
                #endregion
            }
            else
            {
                //弹出提示信息
                My_MessageBox.My_MessageBox_Erry("工单" + txb_OrderID.Text.ToString() + "添加失败！");
            }
        }

        /// <summary>
        /// 添加工单基本信息
        /// </summary>
        /// <returns></returns>
        private void Add_orderInfo(Maticsoft.Model.WorkOrder _workOrder)
        {
           
            
             _workOrder = new Maticsoft.Model.WorkOrder()
            {
                OrderID = txb_OrderID.Text.ToString(),    //工单单号
                Client = "Ezconn",
                ProductName = txb_ProductName.Text.ToString(),
                Model = txb_Model.Text.ToString(),
                Count = txb_Order_Count.Text.ToString(),
                //枚举类型的检测方法
                InspectMethod = (Maticsoft.Model.E_InspectMethod)Enum.Parse(typeof(Maticsoft.Model.E_InspectMethod),
                cmb_InspectMethod.SelectedItem.ToString(), false),

                //枚举类型检测选项
                InspectType = (Maticsoft.Model.E_InspectType)Enum.Parse(typeof(Maticsoft.Model.E_InspectType),
                cmb_InspectType.Text.ToString(), false),

                DeliveryDate = date_DeliveryDate.Text.ToString(),
                //  LabelType = cmb_LabType.Text.ToString(),
                ModelNo = txb_Model.Text.ToString(),
                Workshop = cmb_WorkShop.Text.ToString(),
                State = "待生产" , 
                ID_Key = _workOrder.ID_Key
            };


            //判断是否添加成功
            if (_M_WorkOrder.Update(_workOrder))
            {
                _dt_OrderMaterial = _M_WorkOrder.GetOrderMaterial(txb_OrderID.Text);                                 //工单物料需领用量

                Add_orderMaterial(_dt_OrderMaterial);     //添加工单中的物料清单    
                Add_MaterialInfo(_dt_OrderMaterial);      //添加物料信息  暂时使用 用于收集物料信息                 
                //弹出提示信息               
                My_MessageBox.My_MessageBox_Message("工单" + txb_OrderID.Text.ToString() + "添加成功！");

                //保存条码
                if (txb_Stat_SN.Text != "")
                {
                    Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();

                    if (_M_SerialNumber.GetList("OrderID = '" + txb_OrderID.Text.Trim() + "'").Tables[0].Rows.Count < 1)
                    {
                        addSerialNumber(long.Parse(txb_Stat_SN.Text.ToString()), int.Parse(txb_Order_Count.Text));
                    }
                    else
                    {
                        if (MessageBox.Show("工单" + txb_OrderID.Text.ToString()
                            + "已经存在条码，继续将替换原有条码！\r\n是否继续添加", "系统提示",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            // _M_SerialNumber.DeleteList("OrderID = '" + txb_OrderID.Text.Trim() + "'");
                            
                            addSerialNumber(long.Parse(txb_Stat_SN.Text.ToString()), int.Parse(txb_Order_Count.Text));
                        }
                    }
                }
                else { My_MessageBox.My_MessageBox_Message("开始条码 为空 将不进行条码添加！"); }
                #region 清空文本框
                txb_OrderID.Text = "";
                txb_ProductName.Text = "";
                txb_Model.Text = "";
                txb_Order_Count.Text = "";
                cmb_InspectMethod.Text = "";
                cmb_InspectType.Text = "";
                date_DeliveryDate.Text = "";
                txb_Model.Text = "";
                cmb_WorkShop.Text = "";
                txb_Stat_SN.Text = "";
                _GLL_Lst_SerialNumber.Clear();
                #endregion
            }
            else
            {
                //弹出提示信息
                My_MessageBox.My_MessageBox_Erry("工单" + txb_OrderID.Text.ToString() + "添加失败！");
            }
        }

        /// <summary>
        /// 保存条码
        /// </summary>
        /// <param name="_startSN"></param>
        /// <param name="_endSN"></param>
        private void addSerialNumber(long _startSN, int _orderCount)
        {
            string temInfo="";
            //条码
            Maticsoft.Model.SerialNumber _serialNumber = new Maticsoft.Model.SerialNumber() { OrderID = txb_OrderID.Text.ToString() };
            //检测方法
            Maticsoft.Model.E_InspectMethod temInspectMethod =(Maticsoft.Model.E_InspectMethod)Enum.Parse(typeof(Maticsoft.Model.E_InspectMethod),
                cmb_InspectMethod.SelectedItem.ToString(), false);
            _M_SerialNumber.InspectMethod = temInspectMethod;
            
            //显示结果
            if (temInspectMethod == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL
                || temInspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯_SAMHALL
                || temInspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯_SAMHALL
                || temInspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯_SAMHALL)
            {
                int temCount = 0;
                foreach (Maticsoft.Model.SerialNumber Tem in _GLL_Lst_SerialNumber)
                {
                    _M_SerialNumber.Add(Tem);
                    temCount++;
                }
                _GLL_Lst_SerialNumber.Clear();
                temInfo  = "操作完成！成功添加：" + temCount + "条\r\n失败:0条";
            }
            else
            {
                int temOrderCount = int.Parse(txb_Order_Count.Text.ToString());
                temInfo = _M_SerialNumber.Add(_serialNumber, _startSN,temOrderCount);
            }
            My_MessageBox.My_MessageBox_Message(temInfo);
        }

        //
        //载入工单基本信息
        //
        private void txb_OrderID_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                DataSet _OrderInfo = _M_WorkOrder.GetOrderInfo(txb_OrderID.Text);                                    //工单基本信息
                if (_OrderInfo != null)
                {
                    _dt_OrderMaterial = _M_WorkOrder.GetOrderMaterial(txb_OrderID.Text);                                 //工单物料需领用量            
                    //窗体控件显示
                    txb_ProductName.Text = _OrderInfo.Tables[0].Rows[0]["品名"].ToString();
                    txb_Model.Text = _OrderInfo.Tables[0].Rows[0]["规格"].ToString();

                    double d = double.Parse(_OrderInfo.Tables[0].Rows[0]["批量"].ToString());
                    txb_Order_Count.Text = d.ToString("0");

                    //增加根据品名选择检测类型 2016-07-06
                    if (txb_Model.Text.Contains("SM"))
                    {
                        cmb_InspectType.SelectedIndex = 0;
                    }
                    else if (txb_Model.Text.Contains("MM"))
                    {
                        cmb_InspectType.SelectedIndex = 2;
                    }
                }
                else
                {
                    My_MessageBox.My_MessageBox_Message("未找到工单信息！请手动输入或查询ERP是否存在该工单！！");
                }
            }
        }
        
        /// <summary>
        /// 添加工单物料
        /// </summary>
        private void Add_orderMaterial(DataSet _Order_Material_Data)
        {
            
            Maticsoft.BLL.OrderMaterial _OrM = new OrderMaterial();
            //如果已经添加则不进行添加
            if (!_OrM.Exists("OrderID='" + txb_OrderID.Text + "'"))
            {
                foreach (DataRow dr in _Order_Material_Data.Tables[0].Rows)
                {
                    _OrM.Add(dr, txb_OrderID.Text);
                }
            }
             
        }
        
        /// <summary>
        /// 添加物料信息
        /// </summary>
        private void Add_MaterialInfo(DataSet _Order_Material_Data)
        {
            
            Maticsoft.BLL.MaterialInfo _MaterialInfo = new MaterialInfo();

            foreach (DataRow dr in _Order_Material_Data.Tables[0].Rows)
            {
                if (!_MaterialInfo.Exists(dr["材料品号"].ToString().Trim()))
                {
                    _MaterialInfo.Add(dr);
                }
            }
             
        }
        
        //名称：结束条码控件
        //功能：输入数字后按回车键 算出结束编码
        private void txb_End_SN_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_End_SN.IsFocused)
            {
                if (txb_Stat_SN.Text != "" && txb_End_SN.Text != "")
                {
                    txb_End_SN.Text = (long.Parse(txb_Stat_SN.Text.Trim()) + (int.Parse(txb_End_SN.Text.Trim())-1)).ToString();
                }
            }
        }
        //生成条码
        ObservableCollection<Maticsoft.Model.SerialNumber> _GLL_Lst_SerialNumber = new ObservableCollection<Maticsoft.Model.SerialNumber>();

        //添加条码
        private void btn_Add_SerialNumber_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txb_Stat_SN.Text != "" && txb_End_SN.Text != "")
            {
                long _startSN = long.Parse(txb_Stat_SN.Text.ToString());
                long _endSN = long.Parse(txb_End_SN.Text.ToString());

                //添加条码到列表框           
                for (long i = _startSN; i <= _endSN; i++)
                {
                    Maticsoft.Model.SerialNumber _SerialNumber = new Maticsoft.Model.SerialNumber();
                    _SerialNumber.OrderID = txb_OrderID.Text.Trim();
                    _SerialNumber.State = Maticsoft.Model.E_Barcode_State.Not_Pack.ToString();
                    _SerialNumber.Type = cmb_SerialNumberType.Text.Trim();
                    

                    _SerialNumber.SN = i.ToString();
                    _GLL_Lst_SerialNumber.Add(_SerialNumber);
                }
                txb_Stat_SN.Text = "";
                txb_End_SN.Text = "";
            }
            else { My_MessageBox.My_MessageBox_Message("开始条码 和 结束条码 不能为空！"); }
        }

        #endregion

        #region 批号添加模块
        Maticsoft.Model.WorkOrder _GLL_BatchNo_TemWork = new Maticsoft.Model.WorkOrder(); 
        //
        //载入工单批号信息
        //
        private void txb_Batch_OrderID_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Batch_OrderID.IsFocused)
            {
                if (txb_Batch_OrderID.Text.Trim() != "")
                {
                    DataSet temDs = _M_PackBatch.GetList("OrderID = '" + txb_Batch_OrderID.Text.Trim() + "'");
                    dgv_PackBatch_Info.ItemsSource = temDs.Tables[0].DefaultView;
                                     
                    _GLL_BatchNo_TemWork =  _M_WorkOrder.GetModel(txb_Batch_OrderID.Text.Trim());
                    if (_GLL_BatchNo_TemWork != null)
                    {
                        txb_BatchNo_OrderID_Count.Text = _GLL_BatchNo_TemWork.Count;

                        if (_GLL_BatchNo_TemWork.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL)
                        {
                            txb_ClientSN_Stat_SN.IsEnabled = true;
                            txb_ClientSN_Count.IsEnabled = true;
                        }
                        else
                        {
                            txb_ClientSN_Stat_SN.IsEnabled = false;
                            txb_ClientSN_Count.IsEnabled = false;
                        }
                    }
                    else { My_MessageBox.My_MessageBox_Message("未找到工单信息！"); }                    
                }
            }
        }
        //
        //保存包装批号
        //
        private void btn_BatchNo_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txb_Batch_OrderID.Text != "" && txb_BatchNo.Text != "" && txb_BatchNo_Count.Text != "")
            {
                Maticsoft.Model.PackBatch _TemBatch = new Maticsoft.Model.PackBatch();
                _TemBatch.BatchNo = txb_BatchNo.Text.Trim();
                _TemBatch.Count = int.Parse(txb_BatchNo_Count.Text.Trim());
                _TemBatch.OrderID = txb_Batch_OrderID.Text.Trim();
                _TemBatch.State = "待包装";

                int temcount = 0;
                int.TryParse(txb_BatchNo_Count.Text.Trim(), out temcount);

                if (_GLL_BatchNo_TemWork.InspectMethod == Maticsoft.Model.E_InspectMethod.两码两签)
                {
                    ZhuifengLib.JudgeOddOrEven joe = new ZhuifengLib.JudgeOddOrEven();
                    //判断是否为奇数
                    if (!joe.IsOdd(txb_BatchNo_Count.Text.Trim()))
                    {
                        if (_M_PackBatch.Add(_TemBatch))
                        {
                            My_MessageBox.My_MessageBox_Message("添加成功！");
                        }
                        else { My_MessageBox.My_MessageBox_Message("添加失败！"); }
                    }
                    else { My_MessageBox.My_MessageBox_Message("添加失败！\r\n 数量不能为奇数"); }
                }
                else
                {
                    //添加
                    if (_M_PackBatch.Add(_TemBatch))
                    {
                        My_MessageBox.My_MessageBox_Message("添加成功！");
                    }
                    else { My_MessageBox.My_MessageBox_Message("添加失败！"); }
                }
                if (V_BatchCount(_TemBatch.OrderID, temcount))  //验证数量是否小于工单总量
                {
                }
                else { My_MessageBox.My_MessageBox_Message("已添加的批号与现有数量相加大于工单总量，\r\n"); }


                DataSet temDs = _M_PackBatch.GetList("OrderID = '" + txb_Batch_OrderID.Text.Trim() + "'");
                dgv_PackBatch_Info.ItemsSource = temDs.Tables[0].DefaultView;

                if (_GLL_BatchNo_TemWork.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL)
                {
                    if (txb_ClientSN_Stat_SN.Text != "" && txb_ClientSN_Count.Text != "")
                    {
                        SaveClient(long.Parse(txb_ClientSN_Stat_SN.Text.Trim()), int.Parse(txb_ClientSN_Count.Text.Trim()));
                    }
                    else
                    {
                        My_MessageBox.My_MessageBox_Message("起始客户编码 或数量不能为空！");
                    }
                }


                //清空
                txb_BatchNo_Count.Text = "";
                txb_BatchNo.Text = "";
            }
            else { My_MessageBox.My_MessageBox_Message("信息不完整，请补全后重试"); }
        }

        /// <summary>
        /// 验证此批号数量 是否会超出工单数量
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="_Count"></param>
        /// <returns></returns>
        private bool V_BatchCount(string OrderID, int _Count)
        {
            int orderIDCount = 0, batchCount = 0;
            Maticsoft.Model.WorkOrder _Order = MCP_CS._M_WorkOrder.GetModel(OrderID);
            int.TryParse(_Order.Count, out orderIDCount);
            batchCount =  MCP_CS._M_PackBatch.Get_BatchCount("OrderID= '"+OrderID+"'");

            if (orderIDCount < (batchCount + _Count))
            {
                return false;
            }
            else
            {
                return true;
            }

        }




        /// <summary>
        /// 保存客户编码
        /// </summary>
        private void SaveClient(long _StartSN, int _Count)
        {
            for (int i = 0; i < _Count; i++)
            {
                Maticsoft.Model.SerialNumber TemSerialNumber = new Maticsoft.Model.SerialNumber();
                TemSerialNumber.OrderID = txb_Batch_OrderID.Text.Trim();
                TemSerialNumber.BatchNO = txb_BatchNo.Text.Trim();
                TemSerialNumber.Type = Maticsoft.Model.E_SerialNumber_Type.ClientSN.ToString();
                TemSerialNumber.State = Maticsoft.Model.E_Barcode_State.Not_Pack.ToString();
                TemSerialNumber.SN = _StartSN.ToString();
                
                _M_SerialNumber.Add(TemSerialNumber);
                _StartSN++;
            }

        }

        //检测类型下拉菜单
        private void cmb_InspectMethod_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_InspectMethod.Text == Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL.ToString() || 
                cmb_InspectMethod.Text == Maticsoft.Model.E_InspectMethod.配组_二十四芯_SAMHALL.ToString() ||
                cmb_InspectMethod.Text == Maticsoft.Model.E_InspectMethod.配组_四十八芯_SAMHALL.ToString() ||
                cmb_InspectMethod.Text == Maticsoft.Model.E_InspectMethod.配组_九十六芯_SAMHALL.ToString())
            {
                txb_End_SN.IsEnabled = true;
                lst_SN_List.IsEnabled = true;
                btn_Add_SerialNumber.IsEnabled = true;
                cmb_InspectStandardType.IsEditable = true;
                lab_SerialNumberType.IsEnabled = true;
            }
            else
            {
                txb_End_SN.IsEnabled = false;
                lst_SN_List.IsEnabled = false;
                btn_Add_SerialNumber.IsEnabled = false;
                cmb_InspectStandardType.IsEditable = false;
                lab_SerialNumberType.IsEnabled = false;
            }
        }


        #endregion
       
        #region 装箱设置模块
        //******************************** 临时类 ********************
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        CollectionViewSource view = new CollectionViewSource();
        class Customer
        {
            public string BoxSN { get; set; }
            public string Qty  { get; set; }
            public string State { get; set; } 
        }
        //***********************************************************

        //
        //是否拼箱
        //
        private void cbx_pinxiang_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cbx_Pak_pinxiang.IsChecked == true)
            {                
                lab_PinXiang_SN.Visibility = System.Windows.Visibility.Visible;
                lab_PinXiangCount.Visibility = System.Windows.Visibility.Visible;
                txb_Pak_Pinxiang_SN.Visibility = System.Windows.Visibility.Visible;
                txb_Pak_PinXiangCount.Visibility = System.Windows.Visibility.Visible;
                btn_Pak_PinXiang_Add.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {                
                lab_PinXiang_SN.Visibility = System.Windows.Visibility.Hidden;
                lab_PinXiangCount.Visibility = System.Windows.Visibility.Hidden;
                txb_Pak_Pinxiang_SN.Visibility = System.Windows.Visibility.Hidden;
                txb_Pak_PinXiangCount.Visibility = System.Windows.Visibility.Hidden;
                btn_Pak_PinXiang_Add.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        //
        //生成箱号
        //
        private void btn_Pak_BoxSN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txb_Pak_BoxQty.Text != "")
            {
                lsv_BoxSN_List.DataContext = view;
               // customers.Clear();
                int temCount = AddBoxSN(txb_Pak_BoxQianZhui.Text.Trim(), txb_Pak_BoxQty.Text.Trim(),
                       int.Parse(txb_Pak_Start_BoxSN.Text.Trim()), int.Parse(txb_Pak_End_BoxSN.Text.Trim()));
                My_MessageBox.My_MessageBox_Message("成功生成箱号：" + temCount + "条");
                view.Source = customers;

                //清空
                txb_Pak_BoxQianZhui.Text = "";
                txb_Pak_BoxQty.Text = "";
                txb_Pak_Start_BoxSN.Text = "";
                txb_Pak_End_BoxSN.Text = "";
            }
            else { My_MessageBox.My_MessageBox_Message("每箱的数量不能为空"); }
        }
        //
        //添加拼箱
        //
        private void btn_Pak_PinXiang_Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            customers.Add(new Customer()
            {
                BoxSN = txb_Pak_Pinxiang_SN.Text.Trim(),
                Qty = txb_Pak_PinXiangCount.Text.Trim()
            });

            view.Source = customers;
            //清空
            txb_Pak_Pinxiang_SN.Text="";
            txb_Pak_PinXiangCount.Text = "";
        }
        //
        //装箱设置 OrderID控件
        //
        private void txb_Pak_OrderID_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Pak_OrderID.IsFocused)
            {
                if (txb_Pak_OrderID.Text != "")
                {
                    Maticsoft.BLL.PackBatch _temPackBatch = new PackBatch();
                    Maticsoft.BLL.WorkOrder _M_TemWorkOrder = new WorkOrder();
                    cmb_Pak_BatchNo.DataContext = _temPackBatch.GetList("OrderID='"+txb_Pak_OrderID.Text.Trim()+"'").Tables[0];
                    
                    cmb_Pak_BatchNo.DisplayMemberPath = "BatchNo";
                    Maticsoft.Model.WorkOrder _Orm = _M_TemWorkOrder.GetModel(txb_Pak_OrderID.Text.Trim());
                    if (_Orm.OrderID != null) { txb_Pak_OrderCount.Text = _Orm.Count; }//工单批量
                    else { My_MessageBox.My_MessageBox_Message("未找到工单信息！"); }
                }
                else
                {
                    My_MessageBox.My_MessageBox_Message("工单单号不能为空");
                }
            }
        }
        //
        //保存装箱信息 
        //
        private void btn_Save_PackSettinh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                //****保存装箱设置               
                EncasementSet _M_EncasementSet = new EncasementSet();
                Maticsoft.Model.EncasementSet _EncasementSet = _M_EncasementSet.GetModel(cmb_Pak_BatchNo.Text.Trim());
                         
                if (_EncasementSet.BatchNo == null)
                {
                    _EncasementSet.BatchNo = cmb_Pak_BatchNo.Text.Trim();
                    _EncasementSet.Device = txb_Pak_Device.Text.Trim();
                    _EncasementSet.DeviceQty = txb_Pak_DeviceCount.Text.Trim();
                    _EncasementSet.SackQty = txb_Pak_SackQty.Text.Trim();

                    _M_EncasementSet.Add(_EncasementSet); //添加
                }
                else 
                {
                    _EncasementSet.BatchNo = cmb_Pak_BatchNo.Text.Trim();
                    _EncasementSet.Device = txb_Pak_Device.Text.Trim();
                    _EncasementSet.DeviceQty = txb_Pak_DeviceCount.Text.Trim();
                    _EncasementSet.SackQty = txb_Pak_SackQty.Text.Trim();

                    _M_EncasementSet.Update(_EncasementSet); 
                }

                //保存箱号
                ObservableCollection<Maticsoft.Model.BoxInfo> _BoxInfo = new ObservableCollection<Maticsoft.Model.BoxInfo>();
                Maticsoft.Model.BoxInfo _TemBoxInfo = new Maticsoft.Model.BoxInfo();
                BoxInfo _M_BoxInfo = new BoxInfo();
                foreach (Customer Temcutomer in customers)
                {
                    _TemBoxInfo = _M_BoxInfo.GetModel("BoxSN = '"+Temcutomer.BoxSN+"'");
                                  
                    if (_TemBoxInfo.BoxSN == null)   //如果不存在则添加  否则 更新
                    {
                        _TemBoxInfo.BatchNo = cmb_Pak_BatchNo.Text.Trim();
                        _TemBoxInfo.Type = "BoxSN";
                        _TemBoxInfo.State = "NotEncasement";
                        _TemBoxInfo.BoxSN = Temcutomer.BoxSN;
                        _TemBoxInfo.Qty = Temcutomer.Qty;
                        _M_BoxInfo.Add(_TemBoxInfo);
                    }
                    else 
                    {
                        _TemBoxInfo.BatchNo = cmb_Pak_BatchNo.Text.Trim();
                        _TemBoxInfo.Type = "BoxSN";
                       // _TemBoxInfo.State = "NotEncasement";
                        _TemBoxInfo.BoxSN = Temcutomer.BoxSN;
                        _TemBoxInfo.Qty = Temcutomer.Qty;

                        _M_BoxInfo.Update(_TemBoxInfo);
                    }
                }

                My_MessageBox.My_MessageBox_Message("保存完成！");
                customers.Clear();
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }

        }
        //包装批号下拉菜单
        private void cmb_Pak_BatchNo_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Pak_BatchNo.Text != "")
            {
                Maticsoft.BLL.PackBatch _M_TemPackBatch = new PackBatch();
                txb_Pak_batchNoCount.Text = _M_TemPackBatch.GetModel(cmb_Pak_BatchNo.Text.Trim()).Count.ToString();

                //****装箱设置               
                EncasementSet _M_EncasementSet = new EncasementSet();
                Maticsoft.Model.EncasementSet _EncasementSet = _M_EncasementSet.GetModel(cmb_Pak_BatchNo.Text.Trim());
                txb_Pak_Device.Text = _EncasementSet.Device;
                txb_Pak_DeviceCount.Text = _EncasementSet.DeviceQty;
                txb_Pak_SackQty.Text = _EncasementSet.SackQty;

                //保存箱号
                BoxInfo _M_BoxInfo = new BoxInfo();
                lsv_BoxSN_List.DataContext = _M_BoxInfo.GetModelList("BatchNo ='" + cmb_Pak_BatchNo.Text.Trim() + "'","");
            }
        }




        /**************************** Method ***********************/
        private int AddBoxSN(string TemSN,string Count, int startSN, int EndSN)
        {
            string Tem = "";
            int TemCount = 0;
            for (int i = startSN; i <= EndSN; i++)
            {
                Tem = TemSN + i.ToString();
                customers.Add(new Customer() { Qty = Count, BoxSN = Tem });
                TemCount++;
            }
            return TemCount;
        }
              
        #endregion

        #region 检测标准
        /****************************************** Controls ******************************************/
        //
        //添加
        //
        private void btn_Add_Inspect_Standard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (InspectSatanard_InputTxb_Verification())
            {
                //验证此批号在已经添加的批号中是否存在
                bool _TemVerification = false;
                for (int t = 0; t < _ISD.Count; t++)
                {
                    if (_ISD.Count > 0 && txb_InspectStandard_OrderID.Text == _ISD[t].OrderID && 
                        cmb_InspectStandardType.Text == _ISD[t].Type)
                    {
                        _TemVerification = true; break;
                    }
                }
                if (_TemVerification || _M_InspectStandard.Exists(txb_InspectStandard_OrderID.Text, cmb_InspectStandardType.Text))
                {
                    //弹出提示！如果选择继续则删除数据库中对应的批号信息
                    if (MessageBox.Show("工单" + txb_InspectStandard_OrderID.Text + "类型：" + cmb_InspectStandardType.Text
                        + "已存在，\r\n继续将立即删除原有3D&Exfo检测标准！\r\n备注：如果是已添加到待保存列表中的请手动移除！\r\n是否继续添加", "系统提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        //从数据库中删除记录
                        _M_InspectStandard.Delete(txb_InspectStandard_OrderID.Text, cmb_InspectStandardType.Text);
                        InspectAdd(); //添加
                        InspectStandard_InputTxb_Clear();
                    }
                }
                else
                {
                    InspectAdd();   //添加
                    InspectStandard_InputTxb_Clear();
                }                  
            }
            else
            {
                My_MessageBox.My_MessageBox_Erry("检测标准信息不完整，请检测并补充完整后。重试！");              
            }
        }
        //
        //保存
        //
        private void btn_Save_Inspect_Standard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_ISD.Count > 0)
            {
                _M_InspectStandard.Delete(_ISD[0].OrderID);
            }          
            int TemAddCount = 0;                         //记录操作所影响的记录数
            for (int t = 0; t < _ISD.Count; t++)         //循环添加数据
            {
                if (_M_InspectStandard.Add(_ISD[t]))    //如果添加成功
                {
                    TemAddCount++;                       //记录添加次数 与 添加信息                         
                    _TemMessage += "工单单号：" + _ISD[t].OrderID
                                + "接头类型：" + _ISD[t].Type + "\r\n";
                }
            }
            if (TemAddCount >= 1)                         //判断是否添加成功
            {
                My_MessageBox.My_MessageBox_Message("数据添加成功！\r\n " + _TemMessage + "\r\n共添加记录 " + TemAddCount + "");
                 _ISD.Clear();  //清空检测标准列表
                _TemMessage = "";
            }
            else { My_MessageBox.My_MessageBox_Erry("数据添加失败！"); }
             
        }
        //
        //移除
        //
        private void txb_InspectStandard_Move_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                _ISD.Remove((Maticsoft.Model.InspectStandard)dgv_Inspect_Standard_Info.SelectedItem);
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Erry(ex.Message + "\r\n提示此消息是因为您选择的列为空列！\r\n请重试 或联系管理员"); }
        }
        //
        //选择列显示所选择的值
        //
        private void dgv_Inspect_Standard_Info_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {              
                Maticsoft.Model.InspectStandard _Tem = (Maticsoft.Model.InspectStandard)dgv_Inspect_Standard_Info.SelectedItem;
                txb_InspectStandard_OrderID.Text = _Tem.OrderID;
                cmb_InspectStandardType.Text = _Tem.Type;
                txb_IL_Max.Text = _Tem.IL_Max;             
                txb_IL_Min.Text = _Tem.IL_Min;
                txb_RL_Max.Text = _Tem.RL_Max;
                txb_RL_Min.Text = _Tem.RL_Min;
                txb_RCO_Max.Text = _Tem.RCO_Max;
                txb_RCO_Min.Text = _Tem.RCO_Min;
                txb_AE_Max.Text = _Tem.AE_Max;
                txb_AE_Min.Text = _Tem.AE_Min;
                txb_FH_Max.Text = _Tem.FH_Max;
                txb_FH_Min.Text = _Tem.FH_Min;
                txb_AO_Max.Text = _Tem.AO_Max;
                txb_AO_Min.Text = _Tem.AO_Min;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Erry(ex.Message + "\r\n弹出此错题的原因是您选择的列为空列！"); }
        }

        /****************************************** Controls ******************************************/
        /// <summary>
        /// 添加检测标准到 待保存列表
        /// </summary>
        private void InspectAdd()
        {
             _ISD.Add(new Maticsoft.Model.InspectStandard()
            {
                OrderID = txb_InspectStandard_OrderID.Text,
                Type = cmb_InspectStandardType.Text,
                Wave = "1550nm",
                IL_Max = txb_IL_Max.Text,
                IL_Min = txb_IL_Min.Text,
                RL_Max = txb_RL_Max.Text,
                RL_Min = txb_RL_Min.Text,
                RCO_Max = txb_RCO_Max.Text,
                RCO_Min = txb_RCO_Min.Text,
                AE_Max = txb_AE_Max.Text,
                AE_Min = txb_AE_Min.Text,
                FH_Max = txb_FH_Max.Text,
                FH_Min = txb_FH_Min.Text,
                AO_Max = txb_AO_Max.Text,
                AO_Min = txb_AO_Min.Text
            }
            );
             
        }

        /// <summary>
        /// 验证输入是否为空
        /// </summary>
        /// <returns>true 验证通过 可以继续下一步 </returns>
        private bool InspectSatanard_InputTxb_Verification()
        {
            if (txb_InspectStandard_OrderID.Text == "" || txb_IL_Max.Text == "" || cmb_InspectStandardType.Text == "" ||
                   txb_IL_Min.Text == "" || txb_RL_Max.Text == "" || txb_RL_Min.Text == "" || txb_RCO_Max.Text == "" ||
                   txb_RCO_Min.Text == "" || txb_AE_Max.Text == "" || txb_AE_Min.Text == "" || txb_FH_Max.Text == "" ||
                   txb_FH_Min.Text == "" || txb_AO_Max.Text == "" || txb_AO_Min.Text == "")
            {
                return false;
            }
            else { return true; }            
        }
        /// <summary>
        /// 清空输入文本框
        /// </summary>
        private void InspectStandard_InputTxb_Clear()
        {
            //清空文本输入框
            txb_InspectStandard_OrderID.Text = "";
            txb_IL_Max.Text = "";
            cmb_InspectStandardType.Text = "";
            txb_IL_Min.Text = "";
            txb_RL_Max.Text = "";
            txb_RL_Min.Text = "";
            txb_RCO_Max.Text = "";
            txb_RCO_Min.Text = "";
            txb_AE_Max.Text = "";
            txb_AE_Min.Text = "";
            txb_FH_Max.Text = "";
            txb_FH_Min.Text = "";
            txb_AO_Max.Text = "";
            txb_AO_Min.Text = "";
        }
        
        #endregion


        


        
       

        

        
        
        

        

        


      

       

     

       
        
       

                         
    }
}
