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
    public partial class UserControl_Report : DocumentContent
    {
        public UserControl_Report()
        {
            InitializeComponent();
        }
        DataSet ds_Record = new DataSet();                                       //数据记录
        Maticsoft.BLL.ZMing zm = new Maticsoft.BLL.ZMing();                      //公共类
        ZhuifengLib.JudgeOddOrEven _Judge_Odd = new ZhuifengLib.JudgeOddOrEven(); //判断奇偶


        #region 公共模块
        /*****************************   公共模块   *********************************/
        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
           
            //获取报告导出模板
            string[] browsingFormats; // 存放文件名
            browsingFormats = System.IO.Directory.GetFiles(@"\\192.168.0.65\Templates\ReportTemplates\", "*.xls");   // FolderPath 文件夹路径  *.btw 文家后缀          
            int temIndex = 0;
            foreach (string tem in browsingFormats)
            {
                browsingFormats[temIndex] = tem.Substring(41);
                temIndex++;
            }
            cmb_TemplateList.ItemsSource = browsingFormats;
        }
        
     
        /*  End  */

        #endregion


        #region  报告导出
        /*****************************   导出报告  *********************************/
        //
        //工单单号
        //
        private void txb_Report_OrderID_3D_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_Report_OrderID_3D.IsFocused)
            {
                if (txb_Report_OrderID_3D.Text != "")
                {                    
                    Maticsoft.BLL.PackBatch PB = new PackBatch();
                    DataSet BatchNo_ds = new DataSet();
                    //赋值包装批号
                    BatchNo_ds = PB.GetList(" OrderID ='" + txb_Report_OrderID_3D.Text + "'");
                    cmb_Report_BatchNo_3D.DisplayMemberPath = "BatchNo";
                    cmb_Report_BatchNo_3D.DataContext = BatchNo_ds.Tables[0].DefaultView;                  
                    txb_Report_OrderID_3D.IsEnabled = false;
                    cmb_Report_BatchNo_3D.IsEnabled = true;
                }
                else { My_MessageBox.My_MessageBox_Message("工单单号不能为空"); }
            }
        }
        //
        //导出数据—3D
        //
        string temBatchNo, _TemPlate, temSavePatch;
       
        
        /// <summary>
        /// 导出3D数据报告
        /// </summary>
        private void btn_Report_3D_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btn_Report_3D.IsEnabled = false;
                temBatchNo = cmb_Report_BatchNo_3D.Text;
                _TemPlate = cmb_TemplateList.Text;
                temSavePatch = txb_SavePatch.Text;
                //
                Pack_3D _M_Pack3D = new Pack_3D();
                Pack_Exfo _M_PackExfo = new Pack_Exfo();
                //
                Report _Report_3D = new Report();
                Report _Report_Exfo = new Report();
                //
                Report_3D _report_3d = new Report_3D();
                Report_Exfo _report_exfo = new Report_Exfo();

                Maticsoft.BLL.WorkOrder _M_WorkOrder = new WorkOrder();
                Maticsoft.Model.WorkOrder _WorkOrder = new Maticsoft.Model.WorkOrder();

                _WorkOrder = _M_WorkOrder.GetModel(txb_Report_OrderID_3D.Text.Trim());

                //十二芯X2 导出
                if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2)
                {
                    //导出3D数据
                    _Report_3D.Export_TextReport += _report_3d.TFK十二芯检测x2;

                    Report.ImportEventArgs p = new Report.ImportEventArgs(_M_Pack3D.Get_PackData(cmb_Report_BatchNo_3D.Text.Trim(), _WorkOrder.InspectMethod), _TemPlate, temSavePatch + "\\" + temBatchNo);
                    p.OrderInfo = _WorkOrder;
                    OrderLabSet _M_OrderLabSet = new OrderLabSet();
                    p.LabInfo = _M_OrderLabSet.GetLabInfo("OrderID='" + txb_Report_OrderID_3D.Text + "'");
                    p.UpProgressBar += UpProgressBar;

                    _Report_3D.StatExport(p);

                    //导出Exfo数据
                }
                else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.四十八芯检测 ||
                    _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.二十四芯检测
                    )
                {
                    //导出3D数据
                    Maticsoft.BLL.SerialNumber _M_SerialNumber = new SerialNumber();

                    _Report_3D.Export_TextReport += _report_3d.Multicore;
                    DataSet temds = new DataSet();
                    Report.ImportEventArgs p = new Report.ImportEventArgs(temds, _TemPlate, temSavePatch + "\\");
                    p.OrderInfo = _WorkOrder;
                    OrderLabSet _M_OrderLabSet = new OrderLabSet();
                    p.LabInfo = _M_OrderLabSet.GetLabInfo("OrderID='" + txb_Report_OrderID_3D.Text + "'");
                    p.UpProgressBar += UpProgressBar;

                    ArrayList _SN_List = _M_SerialNumber.Get_SN_List(_WorkOrder.OrderID, Maticsoft.Model.E_SerialNumber_Type.ClientSN, Maticsoft.Model.E_Barcode_State.Yet_Pack);
                    _Report_3D.StatExport(p, _SN_List);
                }
                //配组8芯
                else
                {
                    //导出3D数据
                    _Report_3D.Export_TextReport += _report_3d.peizu;
                    Report.ImportEventArgs p = new Report.ImportEventArgs(_M_Pack3D.Get_PackData(cmb_Report_BatchNo_3D.Text.Trim(), _WorkOrder.InspectMethod), _TemPlate, temSavePatch + "\\" + temBatchNo);
                    p.OrderInfo = _WorkOrder;
                    p.UpProgressBar += UpProgressBar;
                    _Report_3D.StatExport(p);
                }
                btn_Report_3D.IsEnabled = true;
            }
            catch { }

        }


        /// <summary>
        /// 导出Exfo
        /// </summary>
        private void btn_Report_Exfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btn_Report_Exfo.IsEnabled = false;
                temBatchNo = cmb_Report_BatchNo_3D.Text;
                _TemPlate = cmb_TemplateList.Text;
                temSavePatch = txb_SavePatch.Text;
                //
                Pack_Exfo _M_PackExfo = new Pack_Exfo();
                //
                Report _Report_Exfo = new Report();
                //
                Report_Exfo _report_exfo = new Report_Exfo();

                Maticsoft.BLL.WorkOrder _M_WorkOrder = new WorkOrder();
                Maticsoft.Model.WorkOrder _WorkOrder = new Maticsoft.Model.WorkOrder();

                _WorkOrder = _M_WorkOrder.GetModel(txb_Report_OrderID_3D.Text.Trim());

                ExportMethod_Set(_M_PackExfo, _Report_Exfo, _report_exfo, _M_WorkOrder, _WorkOrder);

                btn_Report_Exfo.IsEnabled = true;
            }
            catch { }
          
        }

        /// <summary>
        /// 导出方法设置
        /// </summary>
        /// <param name="_M_PackExfo"></param>
        /// <param name="_Report_Exfo"></param>
        /// <param name="_report_exfo"></param>
        /// <param name="_M_WorkOrder"></param>
        /// <param name="_WorkOrder"></param>
        private void ExportMethod_Set(Pack_Exfo _M_PackExfo, Report _Report_Exfo, Report_Exfo _report_exfo, Maticsoft.BLL.WorkOrder _M_WorkOrder, Maticsoft.Model.WorkOrder _WorkOrder)
        {
            //双并导出
            if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.双并检测)
            {
                //获取每一个SN的已包装数据
                ArrayList temDatalist = new ArrayList();
                ArrayList temSnList = new ArrayList();
                Maticsoft.BLL.SerialNumber _M_seriarlnumber = new SerialNumber();
                
                temSnList = _M_seriarlnumber.Get_SN_List(MCP_CS._M_PackBatch.GetModel(cmb_Report_BatchNo_3D.Text.Trim()), Maticsoft.Model.E_SerialNumber_Type.ClientSN, Maticsoft.Model.E_Barcode_State.Yet_Pack);
                foreach (string _sn in temSnList)
                {
                    temDatalist.Add(_M_PackExfo.Get_PackData(_sn));
                }

                //导出Exfo数据         
                Report.ImportEventArgs ep = new Report.ImportEventArgs(temDatalist, _TemPlate, temSavePatch + "\\" + temBatchNo);
                _Report_Exfo.Export_TextReport += _report_exfo.Export_Twin;
                ep.OrderInfo = _WorkOrder;
                ep.UpProgressBar += UpProgressBar;
                _Report_Exfo.StatExport(ep);
            }
            else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.四芯检测 ||
                _WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.一码一签_跳线)
            {
                //获取每一个SN的已包装数据
                ArrayList temDatalist = new ArrayList();
                ArrayList temSnList = new ArrayList();
                Maticsoft.BLL.SerialNumber _M_seriarlnumber = new SerialNumber();
                Maticsoft.Model.PackBatch temPack = MCP_CS._M_PackBatch.GetModel(cmb_Report_BatchNo_3D.Text.Trim());

                temSnList = _M_seriarlnumber.Get_SN_List(temPack, Maticsoft.Model.E_SerialNumber_Type.ClientSN, Maticsoft.Model.E_Barcode_State.Yet_Pack);
                foreach (string _sn in temSnList)
                {
                    temDatalist.Add(_M_PackExfo.Get_PackData(_sn));
                }

                //导出Exfo数据         
                Report.ImportEventArgs ep = new Report.ImportEventArgs(temDatalist, _TemPlate, temSavePatch + "\\" + temBatchNo);
                _Report_Exfo.Export_TextReport += _report_exfo.Export_fourCore;
                ep.OrderInfo = _WorkOrder;
                ep.UpProgressBar += UpProgressBar;
                _Report_Exfo.StatExport(ep);
            }
            else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.MPO检测)
            {
                Maticsoft.BLL.PackBatch _M_BatchNo = new PackBatch();
                //导出Exfo数据     
                Maticsoft.Model.WorkOrder _temorder = _M_WorkOrder.GetModel(txb_Report_OrderID_3D.Text);
                
                Report.ImportEventArgs ep = new Report.ImportEventArgs(_M_PackExfo.Get_PackData(_temorder.OrderID, _temorder.InspectMethod), _TemPlate, temSavePatch + "\\" + temBatchNo);
              
                ep.BatchNo = _M_BatchNo.GetModel(cmb_Report_BatchNo_3D.Text.Trim());
                _Report_Exfo.Export_TextReport += _report_exfo.Export_Exfo_MPO;
                ep.OrderInfo = _WorkOrder;
                ep.UpProgressBar += UpProgressBar;
                _Report_Exfo.StatExport(ep);
            }
            else if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.八芯检测)
            {
                Maticsoft.BLL.PackBatch _M_BatchNo = new PackBatch();
                //导出Exfo数据     
                Maticsoft.Model.WorkOrder _temorder = _M_WorkOrder.GetModel(txb_Report_OrderID_3D.Text);

                Report.ImportEventArgs ep = new Report.ImportEventArgs(_M_PackExfo.Get_PackData(_temorder.OrderID, _temorder.InspectMethod), _TemPlate, temSavePatch + "\\" + temBatchNo);

                ep.BatchNo = _M_BatchNo.GetModel(cmb_Report_BatchNo_3D.Text.Trim());
                _Report_Exfo.Export_TextReport += _report_exfo.Export_EightCore;
                ep.OrderInfo = _WorkOrder;
                ep.UpProgressBar += UpProgressBar;
                _Report_Exfo.StatExport(ep);
            }
            else
            {
                //导出Exfo数据     
                Maticsoft.Model.WorkOrder _temorder = _M_WorkOrder.GetModel(txb_Report_OrderID_3D.Text);
                Report.ImportEventArgs ep = new Report.ImportEventArgs(_M_PackExfo.Get_PackData(cmb_Report_BatchNo_3D.Text.Trim(), _temorder.InspectMethod), _TemPlate, temSavePatch + "\\" + temBatchNo);
                _Report_Exfo.Export_TextReport += _report_exfo.Export_Exfo_One;
                ep.OrderInfo = _WorkOrder;
                ep.UpProgressBar += UpProgressBar;
                _Report_Exfo.StatExport(ep);
            }
        }



        /// <summary>
        /// 更新进度
        /// </summary>
        private void UpProgressBar(int _MinValue, int _MaxValue, int _Value)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                progressBar.Minimum = _MinValue;
                progressBar.Maximum = _MaxValue;
                progressBar.Value = _Value;
                txb_progressBar.Text = _Value + "/" + _MaxValue;
                //这里更新你的集合
            });           
        }

        /*  End  */
        #endregion



        #region 装箱报告
        /*****************************   导出装箱报告  *********************************/
        //
        //工单单号
        //
        private void txb_R_OrderID_Encasement_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_R_OrderID_Encasement.IsFocused)
            {
                Maticsoft.BLL.PackBatch _M_PackBatch = new PackBatch();
                DataSet temds = _M_PackBatch.GetList("OrderID='" + txb_R_OrderID_Encasement.Text.Trim() + "'");
                cmb_R_BatchNo_Encasement.DisplayMemberPath = "BatchNo";
                cmb_R_BatchNo_Encasement.DataContext = temds.Tables[0].DefaultView;
                cmb_R_BatchNo_Encasement.SelectedIndex = 0;
            }
        }
        //
        //导出装箱报告
        //
        private void btn_R_Export_Encasement_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.BLL.Report_3D _Report_Encasement = new Report_3D();
            Report _Report = new Report();  //初始化报告导出类
            _Report.Export_TextReport += _Report_Encasement.Encasement;  //赋值导出方式
            
            Maticsoft.BLL.BoxInfo _M_BoxInfo = new BoxInfo();
            //定义参数 DataSet数据 导出模板 保存路径
            DataSet _Temds = _M_BoxInfo.GetList_BatchNo_Or_BoxSN("BatchNo = '"+cmb_R_BatchNo_Encasement.Text.Trim()+"'");           
            Report.ImportEventArgs p = 
                new Report.ImportEventArgs(_Temds, cmb_TemplateList.Text.Trim(), txb_SavePatch.Text.Trim() + "\\" + cmb_R_BatchNo_Encasement.Text.Trim());
            p.UpProgressBar += UpProgressBar;
            _Report.StatExport(p);      
        }

        #endregion

      

        private void ckb_Report_orderID_Click(object sender, RoutedEventArgs e)
        {
            if (ckb_Report_orderID.IsChecked == true) { txb_Report_OrderID_3D.IsEnabled = true; } else { txb_Report_OrderID_3D.IsEnabled = false; }
        }
        /*****************************   END  *********************************/
    }
}
