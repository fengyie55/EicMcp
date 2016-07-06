using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AvalonDock;
using System.Data;
using Maticsoft.BLL;
using System;

namespace UI
{
    /// <summary>
    /// UserControl_Label_Print.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_Label_Print : DocumentContent
    {
        public UserControl_Label_Print()
        {
            InitializeComponent();
        }

        #region 变量

        WorkOrder _M_WorkOrder = new WorkOrder();
        PackBatch _M_PackBatchNo = new PackBatch();                                 //包装批号     
        tb_PrintRecord _M_PrintRecord = new tb_PrintRecord();
        My_Print _WTT_My_Print = new My_Print();
        Maticsoft.Model.WorkOrder _WTT_OrderInfo = new Maticsoft.Model.WorkOrder(); //工单信息
        Pack_Exfo _M_Pack_Exfo = new Pack_Exfo(); 
        #endregion

        //
        //工单单号
        //
        private void txb_OrderID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_Orderid.IsFocused)
            {
                if (txb_Orderid.Text != "")
                {
                    cmb_BatchNo.DisplayMemberPath = "BatchNo";
                    DataSet temds = new DataSet();
                    temds =  _M_PackBatchNo.GetList("OrderID ='" + txb_Orderid.Text + "'");
                    cmb_BatchNo.DataContext = temds.Tables[0];
                    _WTT_OrderInfo = _M_WorkOrder.GetModel(txb_Orderid.Text.Trim());                                
                    showOrderInfo(_WTT_OrderInfo);
                    txb_Orderid.IsEnabled = false;
                    cmb_BatchNo.IsEnabled = true;
                }
                else { My_MessageBox.My_MessageBox_Message("工单单号不能为空"); }
            }
        }

        //
        //包装批号
        //
        private void cmb_BatchNo_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_BatchNo.Text != "")
            {
                Maticsoft.Model.PackBatch _PackBatch = _M_PackBatchNo.GetModel(cmb_BatchNo.Text.Trim());
                cmb_BatchNo.IsEnabled = false;
                Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();
                //
                Info_YetPack_Count.Text = _M_SerialNumber.Get_PackCount_Batch("OrderID='" + txb_Orderid.Text.Trim()
                    + "' AND BatchNO='" + cmb_BatchNo.Text.Trim() + "' AND State='Yet_Pack' ").ToString();
                Info_Batch_Count.Text = _PackBatch.Count.ToString();
                Info_YetPrintCount.Text = _M_PrintRecord.Get_Count("BatchNo='" + cmb_BatchNo.Text.Trim() + "'").ToString();
                //
                _WTT_My_Print = new My_Print(txb_Orderid.Text.Trim(), cmb_BatchNo.Text.Trim());

                if (_WTT_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2)
                {
                    _WTT_My_Print.IsBtPrint = true;                   
                }
            }
            else { My_MessageBox.My_MessageBox_Message("批号不能为空！"); }
        }
           
        //
        //SN赋值
        //
        private void txb_BarCode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_BarCode.IsFocused) 
            {
                try
                {
                    if (txb_BarCode.Text != "")
                    {
                        DataSet SN_data = _M_Pack_Exfo.GetList(" (ClientSN = '"+txb_BarCode.Text.Trim()+"') AND (Wave = '1550nm')  ");
                        if (SN_data != null)
                        {
                            string PigtailSN = txb_BarCode.Text.Trim();
                            
                            //如果检测类型是12芯x2 则将条码设置为 10位
                            if (_WTT_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2 && PigtailSN.Length > 10)
                            {
                                _WTT_My_Print.SN = PigtailSN.Substring(0, 10);
                            }
                                                        
                            _WTT_My_Print.Add_PrintData(SN_data);
                            lst_BarCodeRecord.Items.Add(txb_BarCode.Text.Trim());
                        }
                        else
                        {
                            My_MessageBox.My_MessageBox_Message("未找到条码数据！");
                        }
                    }
                    else { My_MessageBox.My_MessageBox_Message("条码不能为空"); }
                }
                catch (Exception ex)
                {
                    My_MessageBox.My_MessageBox_Erry(ex.Message);
                }
            }
        }
    
        //
        //标签打印
        //
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            _WTT_My_Print.Print();
            txb_BarCode.SelectAll(); //选择文本框中的全部内容
        }
        //
        //核对框 工单单号
        //
        private void ckb_Order_Edit_Checked(object sender, RoutedEventArgs e)
        {
            if (ckb_Order_Edit.IsChecked == true) { txb_Orderid.IsEnabled = true; }
        }
        //
        //核对框 包装批号
        //
        private void ckb_BatchNo_Edit_Checked(object sender, RoutedEventArgs e)
        {
            if (ckb_BatchNo_Edit.IsChecked == true) { cmb_BatchNo.IsEnabled = true; }
        }
        //
        //窗体关闭
        //
        private void DocumentContent_Closed(object sender, EventArgs e)
        {
            kill_Process("bartend");  //结束BT进程
        }
        

        #region Method
        //显示工单信息
        private void showOrderInfo(Maticsoft.Model.WorkOrder _workOrderInfo)
        {
            Info_OrderID_Count.Text = _workOrderInfo.Count;
            Info_PeoductName.Text = _workOrderInfo.ProductName;           
            Info_Model.Text = _workOrderInfo.Model;        
            Info_DeliveryDate.Text = _workOrderInfo.DeliveryDate;
        }
           
        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="_ProcessName">进程名称</param>
        /// <returns></returns>
        private bool kill_Process(string _ProcessName)
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(_ProcessName);
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(_ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
            return true;
        }

        #endregion

    }


}
