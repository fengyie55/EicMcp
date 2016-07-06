using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using AvalonDock;
using Maticsoft.BLL;

namespace UI
{
    /// <summary>
    /// UserControl_Finished_Product.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_Finished_Product : DocumentContent
    {
        public UserControl_Finished_Product()
        {
            InitializeComponent();
        }

        /***************************  GTT变量  **************************************/
        Maticsoft.Model.BoxInfo _GTT_BoxInfo = new Maticsoft.Model.BoxInfo();
        Color _Mycolor = Color.FromRgb(58, 157, 82);                  //默认透明度为255；Red=58, Green=157, Blue=82
        Color _Mycolor2 = Color.FromArgb(255, 58, 157, 82);           //透明度=255 ，Red=58, Green=157, Blue=82

        int TemDeviceRecode = 0;

        /***************************  控件事件  **************************************/
        //
        //工单单号
        //
        private void txb_OrderID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_OrderID.IsFocused)
            {
                Maticsoft.BLL.WorkOrder _M_WorkOrder = new Maticsoft.BLL.WorkOrder();
                Maticsoft.Model.WorkOrder _WorkOrder = new Maticsoft.Model.WorkOrder();
                _WorkOrder = _M_WorkOrder.GetModel(txb_OrderID.Text.Trim());
                if (_WorkOrder != null)
                {
                    //控件赋值
                    txb_OrderCount.Text = _WorkOrder.Count;
                    Info_PeoductName.Text = _WorkOrder.ProductName;
                    Info_Model.Text = _WorkOrder.Model;
                    Info_DeliveryDate.Text = _WorkOrder.DeliveryDate;

                    //赋值包装批号
                    Maticsoft.BLL.PackBatch _temPackBatch = new PackBatch();
                    cmb_BatchNo.DataContext = _temPackBatch.GetList("OrderID='" + txb_OrderID.Text.Trim() + "'").Tables[0];
                    cmb_BatchNo.DisplayMemberPath = "BatchNo";
                }
                else
                {
                    My_MessageBox.My_MessageBox_Message("未找到工单信息！");
                }
            }
        }

        //批号下拉菜单
        private void cmb_BatchNo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                txb_BoxSN.IsEnabled = true;
                txb_BoxSN.Text = "";
                //获取批号信息
                PackBatch _M_PackBatch = new PackBatch();
                Maticsoft.Model.PackBatch _PackBatch = new Maticsoft.Model.PackBatch();
                _PackBatch = _M_PackBatch.GetModel(cmb_BatchNo.Text.Trim());
                txb_BatchCount.Text = _PackBatch.Count.ToString();

                //获取装箱信息
                EncasementSet _M_EncasementSet = new EncasementSet();
                Maticsoft.Model.EncasementSet _EncasementSet = new Maticsoft.Model.EncasementSet();
                _EncasementSet = _M_EncasementSet.GetModel(cmb_BatchNo.Text.Trim());
                if (_EncasementSet != null)
                {
                    Info_Device.Text = _EncasementSet.Device;
                    Info_DeviceQty.Text = _EncasementSet.DeviceQty;
                    Info_SackQty.Text = _EncasementSet.SackQty;
                    //****************************************************** 2015-6-25 增加 对标签检测进行设置
                    if (_EncasementSet.DeviceQty == "2") { labCheck.vm.IsEnSN2 = true; }
                    labCheck.vm.OrderID = _PackBatch.OrderID;

                   
                }

                //已包装数量
                Maticsoft.BLL.SerialNumber _M_SerialNumber = new Maticsoft.BLL.SerialNumber();
                Info_YetPack_Count.Text = _M_SerialNumber.Get_PackCount_Batch(" (BatchNO = '" + cmb_BatchNo.Text.Trim() + "')  AND (State = '" + Maticsoft.Model.E_Barcode_State.Yet_Pack + "')").ToString();

                //已装箱数量
                Maticsoft.BLL.BoxInfo _M_BoxInfo = new Maticsoft.BLL.BoxInfo();
                Info_YetEncasement_Count.Text = _M_BoxInfo.GetYetEncasementCount("tb_BoxInfo.BatchNo = '" + cmb_BatchNo.Text.Trim() + "'").ToString();

                //批号装箱完成
                if (int.Parse(Info_YetEncasement_Count.Text.Trim()) >= int.Parse(txb_BatchCount.Text.Trim()))
                {
                    My_MessageBox.My_MessageBox_Message("批号：" + cmb_BatchNo.Text.Trim() + "数量：" + txb_BatchCount.Text.Trim() + "\r\n装箱完毕！");
                    txb_Device.IsEnabled = false;
                    txb_SerialNumber.IsEnabled = false;
                }
            }
            catch { }
        }
        CollectionViewSource view = new CollectionViewSource();
        //
        //扫描条码
        //
        private void txb_SerialNumber_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter && txb_SerialNumber.IsFocused)
                {
                    if (txb_W_BoxSN.IsEnabled || txb_BoxSN.IsEnabled)
                    {
                        My_MessageBox.My_MessageBox_Message("请扫描外箱箱号与外箱ASN编码！");
                    }
                    else
                    {
                        Encasement _M_Encasement = new Encasement();
                        Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();

                        //条码是否属于此工单
                        if (!_M_SerialNumber.Exists_where("(OrderID = '" + txb_OrderID.Text.Trim() + "') AND (SN LIKE '" + txb_SerialNumber.Text.Trim() + "%')"))
                        {
                            My_MessageBox.My_MessageBox_Message("此条吗不属于此工单！");
                        }
                        else
                        {
                            //条码是否已经检测通过
                            if (!_M_SerialNumber.Exists_where("(State = 'Yet_Pack') AND (SN LIKE '" + txb_SerialNumber.Text.Trim() + "%')"))
                            {
                                My_MessageBox.My_MessageBox_Message("此条码未经过出货检测！");
                            }

                            else
                            {
                                //条码是否已经装箱
                                if (_M_Encasement.Exists_where("(SN = '" + txb_SerialNumber.Text.Trim() + "')"))
                                {
                                    My_MessageBox.My_MessageBox_Message("此条码已经装箱！");
                                }
                                else
                                {
                                    Maticsoft.BLL.LabelCheck labcheck = new LabelCheck();
                                    
                                    //条码是否已经检测标签
                                    if (!labcheck.Exists(txb_SerialNumber.Text.Trim()))
                                    {
                                        My_MessageBox.My_MessageBox_Message("此条码未核对标签！");
                                    }
                                    else
                                    {
                                        //赋值记录
                                        Maticsoft.Model.Encasement _Encasement = new Maticsoft.Model.Encasement();
                                        _Encasement.BoxID = _GTT_BoxInfo.ID.ToString();
                                        _Encasement.SN = txb_SerialNumber.Text.Trim();
                                        _Encasement.Qty = Info_SackQty.Text.Trim();
                                        //保存记录
                                        _M_Encasement.Add(_Encasement);

                                        //显示箱子已包装数量
                                        txb_SackCount.Text = _M_Encasement.GetBoxCount("(BoxID = '" + _GTT_BoxInfo.ID + "')").ToString();

                                        //在 ListBox 控件中显示
                                        view.Source = _M_Encasement.GetModelList("(BoxID = '" + _GTT_BoxInfo.ID + "')");
                                        lab_EncasementRecordCount.Text = lsv_SerialNumberList.Items.Count.ToString();

                                        if (txb_SackCount.Text.Trim() == txb_BoxCount.Text.Trim())
                                        {
                                            txb_SerialNumber.IsEnabled = false;
                                        }

                                        txb_SerialNumber.Text = "";

                                        //批号装箱完成
                                        Maticsoft.BLL.BoxInfo _M_BoxInfo = new Maticsoft.BLL.BoxInfo();
                                        if (_M_BoxInfo.GetYetEncasementCount("tb_BoxInfo.BatchNo = '" + cmb_BatchNo.Text.Trim() + "'") >= int.Parse(txb_BatchCount.Text.Trim()))
                                        {
                                            My_MessageBox.My_MessageBox_Message("批号：" + cmb_BatchNo.Text.Trim() + "数量：" + txb_BatchCount.Text.Trim() + "\r\n线材扫描完毕，请继续装箱！");
                                            txb_SerialNumber.IsEnabled = false;
                                        }
                                    }

                                }
                                   
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }
        //
        //内盒扫描
        //
        private void txb_Device_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Device.IsFocused)
            {
              //  try
              //  {
                    if (txb_SerialNumber.IsEnabled)
                    {
                        My_MessageBox.My_MessageBox_Message("此箱所装线材未扫描完毕！\r\n请扫描完毕后重试！");
                    }
                    else
                    {
                        //如果盒子编码与工单编码不符合
                        if (txb_Device.Text.Trim() != Info_Device.Text.Trim())
                        {
                            My_MessageBox.My_MessageBox_Message("此盒子Device编码与工单不符，请检查后重试！");
                        }
                        else
                        {
                            TemDeviceRecode++;
                            int tem = int.Parse(Info_DeviceQty.Text.Trim());
                            txb_DeviceCount.Text = (TemDeviceRecode * tem).ToString();
                            txb_Device.Text = "";

                            //如果此箱装箱完成
                            if (txb_DeviceCount.Text.Trim() == txb_BoxCount.Text.Trim())
                            {                               
                                Maticsoft.BLL.BoxInfo _M_BoxInfo = new Maticsoft.BLL.BoxInfo();
                                _GTT_BoxInfo.State = "YetEncasement";
                                _M_BoxInfo.Update(_GTT_BoxInfo);
                                                         
                                //已装箱数量更新                      
                                Info_YetEncasement_Count.Text = _M_BoxInfo.GetYetEncasementCount("tb_BoxInfo.BatchNo = '" + cmb_BatchNo.Text.Trim() + "'").ToString();
                                My_MessageBox.My_MessageBox_Message("箱号：" + txb_BoxSN.Text.Trim() + " 数量：" + txb_BoxCount.Text.Trim() + " 装箱完成！");

                                //清空控件中的数据
                                txb_BoxSN.Text = "";
                                txb_BoxSN.IsEnabled = true;
                                txb_W_BoxSN.Text = "";
                                txb_W_BoxSN.IsEnabled = true;
                                txb_SerialNumber.Text = "";
                                txb_SerialNumber.IsEnabled = true;
                                txb_Device.Text = "";
                                txb_BoxCount.Text = "";
                                txb_DeviceCount.Text = "";
                                TemDeviceRecode = 0;
                            
                            }
                            //已装箱数量更新 临时更新
                            if (txb_DeviceCount.Text != "")
                            {
                                Info_YetEncasement_Count.Text = (int.Parse(Info_YetEncasement_Count.Text.Trim()) + int.Parse(Info_DeviceQty.Text.Trim())).ToString();
                            }
                            //批号装箱完成
                            if (int.Parse(Info_YetEncasement_Count.Text.Trim()) >= int.Parse(txb_BatchCount.Text.Trim()))
                            {

                                My_MessageBox.My_MessageBox_Message("批号：" + cmb_BatchNo.Text.Trim() + "数量：" + txb_BatchCount.Text.Trim() + "\r\n装箱完毕！");
                                txb_Device.IsEnabled = false;
                                txb_SerialNumber.IsEnabled = false;
                                _GTT_BoxInfo.State = "YetEncasement";
                                Maticsoft.BLL.BoxInfo _M_BoxInfo = new Maticsoft.BLL.BoxInfo();
                                _M_BoxInfo.Update(_GTT_BoxInfo);                               
                            }
                        }
                    }
              //  }
              //  catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
            }

        }
        //
        //扫描箱号
        //
        private void txb_BoxSN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_BoxSN.IsFocused)
            {
                //获取箱号         
                Maticsoft.BLL.BoxInfo _M_BoxInfo = new Maticsoft.BLL.BoxInfo();
                _GTT_BoxInfo = _M_BoxInfo.GetModel("(BatchNo = '" + cmb_BatchNo.Text.Trim() + "') AND (State = 'NotEncasement') AND (BoxSN = '" + txb_BoxSN.Text.Trim() + "')");
                if (_GTT_BoxInfo.BoxSN != null)
                {
                    //验证通过
                    SolidColorBrush myBrush = new SolidColorBrush(_Mycolor); //定义纯色绘制 变量
                    lab_BoxResult.Text = "PASS"; lab_BoxResult.Foreground = myBrush;

                    //箱子总量
                    txb_BoxCount.Text = _GTT_BoxInfo.Qty;
                    txb_BoxSN.IsEnabled = false;

                    //显示箱子已包装数量
                    Encasement _M_Encasement = new Encasement();
                    txb_SackCount.Text = _M_Encasement.GetBoxCount("(BoxID = '" + _GTT_BoxInfo.ID + "')").ToString();

                    //在 ListBox 控件中显示
                    view.Source = _M_Encasement.GetModelList("(BoxID = '" + _GTT_BoxInfo.ID + "')");
                    lab_EncasementRecordCount.Text = lsv_SerialNumberList.Items.Count.ToString();

                    //判断是否箱子装满
                    if (txb_SackCount.Text.Trim() == txb_BoxCount.Text.Trim())
                    {
                        txb_SerialNumber.IsEnabled = false;
                    }
                }
                else
                {
                    lab_BoxResult.Text = "FAIL"; lab_BoxResult.Foreground = Brushes.Red;
                    My_MessageBox.My_MessageBox_Message("此箱号不属于此批号，或此箱号已装箱！\r\n请更换箱号后重试！");
                }
            }
        }
        //
        //外箱ASN编码
        //
        private void txb_W_BoxSN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_W_BoxSN.IsFocused)
            {
                if (txb_W_BoxSN.Text.Trim() == Info_Device.Text.Trim())
                {
                    SolidColorBrush myBrush = new SolidColorBrush(_Mycolor); //定义纯色绘制 变量
                    lab_W_Result.Text = "PASS"; lab_W_Result.Foreground = myBrush;
                    txb_W_BoxSN.IsEnabled = false;
                }
                else
                {
                    lab_W_Result.Text = "FAIL"; lab_W_Result.Foreground = Brushes.Red;
                    My_MessageBox.My_MessageBox_Message("此外箱ASN编码与工单不符！\r\n请重试或立即通知工程师！！");
                }
            }
        }

        Finished_Product_labelControls labCheck = new Finished_Product_labelControls();
      
        //
        //窗体载入模块
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lsv_SerialNumberList.DataContext = view;
                //*******************************************************2015-6-25增加 初始化标签检测
                ccl_Finished_Product_LabelControls.Content = labCheck;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message+"\r\n源："+ex.Source); }
           
         
        }

       

        
        //End
    }
}
