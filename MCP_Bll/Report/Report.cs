using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Collections; 

namespace Maticsoft.BLL
{
    public class Report
    {
        /********************** 参数定义  **********************/            
       // private readonly Maticsoft.Model.PackBatch _PackBatch;
        public readonly DataSet _Import_Data;
        public string MessageList = "";       //消息列表

        /********************** 事件与委托  **********************/      
        public delegate void ExportTestReportEventHandler(ImportEventArgs e);        //委托定义
        public event ExportTestReportEventHandler Export_TextReport;                 //事件定义
       
           
        public class ImportEventArgs : EventArgs                                      //参数
        {
            public  DataSet ImportData;
            public  string  Template ,SavePath;

            #region 构造函数
            //构造函数
            public ImportEventArgs(DataSet _importdata, string _template ,string _savePath)
            {
                this.ImportData = _importdata;
                this.Template = _template;
                this.SavePath = _savePath;
            }
            //构造函数
            public ImportEventArgs(ArrayList _snDataList, string _template, string _savePath)
            {
                this.SN_DataList = _snDataList;
                this.Template = _template;
                this.SavePath = _savePath;
            }
            #endregion


            #region 属性
            /// <summary>
            /// SN DataList 数据列表 
            /// </summary>
            public ArrayList SN_DataList = new ArrayList();

            /// <summary>
            /// 工单信息
            /// </summary>
            public Maticsoft.Model.WorkOrder OrderInfo { get; set; }

            /// <summary>
            /// 标签信息
            /// </summary>
            public DataSet LabInfo { get; set; }

            /// <summary>
            /// 工单单号
            /// </summary>
            public Maticsoft.Model.PackBatch BatchNo { get; set; }

            /// <summary>
            /// 数据更新属性
            /// </summary>
            public ImportEventArgs() { }
            #endregion


            #region 事件
            //更新事件
            public delegate void UpValueEventHandler(int MinValue,int MaxValue,int Value);
            public event UpValueEventHandler UpProgressBar;

            #endregion


            #region Method
            /// <summary>
            /// 验证事件是否为空
            /// </summary>
            protected virtual void onUpProgressBar(int MinValue, int MaxValue, int Value)
            {
                if (UpProgressBar != null)
                {
                    UpProgressBar(MinValue,MaxValue,Value);
                }
            }
           
            /// <summary>
            /// 开始更新
            /// </summary>
            public void StatUpProgressBar(int MinValue, int MaxValue, int Value)
            {
                onUpProgressBar(MinValue,MaxValue,Value);
            }

            #endregion
        }

        /********************** 执行函数  **********************/      
       
        /// <summary>
        /// 导出报告默认构造器
        /// </summary>
        public Report() { }
       

        /// <summary>
        /// 验证事件是否为空
        /// </summary>
        protected virtual void onExport_TextReport(ImportEventArgs e)
        {
            if (Export_TextReport != null)
            {              
                Export_TextReport(e);
            }
        }
       
       

        /// <summary>
        /// 导出数据 重载
        /// </summary>
        /// <param name="e">委托类型的参数</param>
        /// <param name="packBatch">包装批号</param>
        /// <param name="reportType">报告类型 3D OR Exfo</param>
        /// <param name="ModelPatch">模板路径</param>
        /// <param name="SavePatch">保存路径</param>
        public void StatExport(ImportEventArgs e , Maticsoft.Model.PackBatch packBatch ,Maticsoft.Model.E_ReportType reportType 
            ,string ModelPatch,string SavePatch)
        {
            if (reportType == Model.E_ReportType.Exfo) //Exfo数据导出
            {

            }
            else if (reportType == Model.E_ReportType.PhysicalProperty)    //3D数据导出
            {

            }
        }

        /// <summary>
        /// 导出单个条码的数据 包括3D与Exfo
        /// </summary>
        /// <param name="SN"></param>
        /// <param name="SavePatch"></param>
        public void StatExport(Maticsoft.Model.SerialNumber SN, string SavePatch)
        {


        }

        ImportEventArgs _WTT_E = new ImportEventArgs();
        ArrayList _WTT_List = new ArrayList();

        /// <summary>
        /// 开始导出
        /// </summary>
        public void StatExport(ImportEventArgs e)
        {

            if (e.Template != "")
            {
                if (e.SavePath != "")
                {
                    _WTT_E = e;
                    Thread Mythread_ExReport = new Thread(new ThreadStart(ExReport));
                    Mythread_ExReport.IsBackground = true;
                    Mythread_ExReport.Start();
                }
                else { My_MessageBox.My_MessageBox_Message("保存路径不能为空！\r\n请选择保存路径后重试！"); }
            }
            else { My_MessageBox.My_MessageBox_Message("报告模板不能为空！\r\n前选择报告模板后重试！"); }

        }


        /// <summary>
        /// 开始导出
        /// </summary>
        public void StatExport(ImportEventArgs e, ArrayList _SN_List)
        {
            if (e.Template != "")
            {
                if (e.SavePath != "")
                {
                    _WTT_E = e;
                    _WTT_List = _SN_List;

                    Thread Mythread_ExReport = new Thread(new ThreadStart(Export_MultiCode));
                    Mythread_ExReport.IsBackground = true;
                    Mythread_ExReport.Start();
                }
                else { My_MessageBox.My_MessageBox_Message("保存路径不能为空！\r\n请选择保存路径后重试！"); }
            }
            else { My_MessageBox.My_MessageBox_Message("报告模板不能为空！\r\n前选择报告模板后重试！"); }
        }

        /// <summary>
        /// 导出多芯
        /// </summary>
        private void Export_MultiCode()
        {
            string tem = _WTT_E.SavePath;
            int temCount = 0;
            ImportEventArgs e = _WTT_E;
            foreach (string _sn in _WTT_List)
            {
                temCount++;
                Maticsoft.BLL.Pack_3D _M_Pack3d = new Pack_3D();
                e.SavePath = tem + _sn;
                e.ImportData = _M_Pack3d.Get_PackData(_sn, Model.E_InspectMethod.配组_四十八芯);
                _WTT_E = e;
                Thread Mythread_ExReport = new Thread(new ThreadStart(ExReport));
                Mythread_ExReport.IsBackground = true;
                Mythread_ExReport.Start();
                Mythread_ExReport.Join();
                _WTT_E.StatUpProgressBar(0, temCount, _WTT_List.Count);
            }
            My_MessageBox.My_MessageBox_Message("导出完成！");

        }   
   
        
        
        /// <summary>
        /// 执行导出
        /// </summary>
        private void ExReport()
        {
            onExport_TextReport(_WTT_E);
        }

       


    
        
        
        
        
        
        
        
        
        
         
        /********************** Method  **********************/      
        //获取测试数据 根据工单
        private DataSet Get_Data(Maticsoft.Model.WorkOrder _workOrder)
        {
            return null;
        }
        
    }
}
