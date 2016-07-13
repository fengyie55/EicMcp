using System;
using System.Collections.Generic;
using System.Data;
using Seagull.BarTender.Print;
using System.Drawing.Printing;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace Maticsoft.DAL
{
    public class My_Print
    {

        #region 全局变量
        private int _LabCount = 0;
        private bool _IsBtPrint = false;
        private string LabPatch = "D:\\模板\\PrintTemplates\\HP_Templates\\";
        private DataSet _WTT_LabSetInfo = null;
        private List<DataSet> _WTT_NotPrintList = new List<DataSet>();  //待打印数据列表
        private Engine btEngine = new Engine();    //后台线程

        Maticsoft.Model.PrintRecord _PrintRecord = new Model.PrintRecord();
        Maticsoft.DAL.tb_PrintRecord _M_PrintRecord = new tb_PrintRecord();
        #endregion


        #region 构造函数
        public My_Print()
        {
            try
            {
                btEngine.Start();      //开启后台线程   
            }
            catch { My_MessageBox.My_MessageBox_Message("打印服务未能启动，将导致无法打印！/r/n导致此错误的原因可能是您的计算机未安装BT打印软件或其它必要的服务程序！如有疑问请联系系统管理员"); }
        }
        /// <summary>
        /// 针对12芯*2设计
        /// </summary>
        public My_Print(string OrderID, string BatchNo)
        {
            try
            {
                //1.获取工单中标签的设置信息 2.开启BT打印程序后台线程
                OrderLabSet _M_LabSetInfo = new OrderLabSet();
                _WTT_LabSetInfo = _M_LabSetInfo.GetLabInfo("(tb_OrderLabSet.BachNo  = '" + BatchNo + "' )");
                if (_WTT_LabSetInfo.Tables[0].Rows.Count > 0)
                {
                    LabName = _WTT_LabSetInfo.Tables[0].Rows[0]["LabName"].ToString();
                    _PrintRecord.BatchNo = BatchNo;
                    _PrintRecord.OrderID = OrderID;
                    _PrintRecord.LabellMode = LabName;
                    btEngine.Start();      //开启后台线程    
                    IsPrint = true;        //启用标签打印

                    //检查标签是否核对
                    LabVerify labv = new LabVerify();
                    Maticsoft.Model.LabVerify _temLabv = labv.GetModel(" Pb_ID = '" + BatchNo + "'");
                    if (_temLabv != null && _temLabv.IsVerify != "0") { }
                    else
                    {
                        IsPrint = false;
                        My_MessageBox.My_MessageBox_Erry("此工单标签未经过核对！！！\r\n请通知助理或工程师进行标签核对后重试！");
                    }
                }
                else
                {
                    IsPrint = false;
                    My_MessageBox.My_MessageBox_Message("未找到此批号的任何标签，将不进行标签打印！！！\r\n请确认是否需要进行标签打印");
                }
            }
            catch { My_MessageBox.My_MessageBox_Message("打印服务未能启动，将导致无法打印！/r/n导致此错误的原因可能是您的计算机未安装BT打印软件或其它必要的服务程序！如有疑问请联系系统管理员"); }
        }


        //针对跳线设计
        public My_Print(Maticsoft.Model.PackBatch _packBatch)
        {
            try
            {
                //1.获取工单中标签的设置信息 2.开启BT打印程序后台线程
                OrderLabSet _M_LabSetInfo = new OrderLabSet();
                _WTT_LabSetInfo = _M_LabSetInfo.GetLabInfo("(tb_OrderLabSet.OrderID  = '" + _packBatch.OrderID + "' )");
                if (_WTT_LabSetInfo.Tables[0].Rows.Count > 0)
                {
                    LabName = _WTT_LabSetInfo.Tables[0].Rows[0]["LabName"].ToString();
                    _PrintRecord.BatchNo = _packBatch.BatchNo;
                    _PrintRecord.OrderID = _packBatch.OrderID;
                    _PrintRecord.LabellMode = LabName;
                    btEngine.Start();      //开启后台线程    
                    IsPrint = true;        //启用标签打印

                    //检查标签是否核对
                    LabVerify labv = new LabVerify();
                    Maticsoft.Model.LabVerify _temLabv = labv.GetModel(" Orm_ID = '" + _packBatch.OrderID + "'");
                    if (_temLabv != null && _temLabv.IsVerify != "0") { }
                    else
                    {
                        IsPrint = false;
                        My_MessageBox.My_MessageBox_Erry("此工单标签未经过核对！！！\r\n请通知助理或工程师进行标签核对后重试！");
                    }
                }
                else
                {
                    IsPrint = false;
                    My_MessageBox.My_MessageBox_Message("未找到此批号的任何标签，将不进行标签打印！！！\r\n请确认是否需要进行标签打印");
                }
            }
            catch { My_MessageBox.My_MessageBox_Message("打印服务未能启动，将导致无法打印！/r/n导致此错误的原因可能是您的计算机未安装BT打印软件或其它必要的服务程序！如有疑问请联系系统管理员"); }
        }

        #endregion


        #region 属性
        /// <summary>
        /// 是否启用Bt打印机进行打印 这样的打印为扫描一次打印一个
        /// </summary>
        public bool IsBtPrint
        {
            set
            {
                _IsBtPrint = value;
                if (_IsBtPrint)
                {
                    LabPatch = "D:\\模板\\PrintTemplates\\BT_Templates\\";
                }
            }
        }

        /// <summary>
        /// 获取或设置是否启用标签打印
        /// </summary>
        public bool IsPrint { get; set; }
        /// <summary>
        /// 设置或获取标签
        /// </summary>
        public string LabName { get; set; }

        /// <summary>
        /// 获取标签数量
        /// </summary>
        public int LabCount { get { return _LabCount; } }

        /// <summary>
        /// 标签ＳＮ编码 为Bt打印时 启用
        /// </summary>
        public string SN { get; set; }
        #endregion


        #region 实现方法

        /// <summary>
        /// 重置标签 
        /// 本方法主要功能为 重置标签名称以及标签信息 主要为同一个批号存在两种标签的工单设计 如 12芯*2
        /// </summary>
        /// <param name="_labName"></param>
        public bool SetLab(string _labName)
        {
            OrderLabSet _M_LabSetInfo = new OrderLabSet();
            _WTT_LabSetInfo = _M_LabSetInfo.GetLabInfo("(tb_OrderLabSet.BachNo  = '" + _PrintRecord.BatchNo
                + "') AND (tb_OrderLabSet.LabName = '" + _labName + "')");

            if (_WTT_LabSetInfo.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        ///  添加待打印数据
        /// </summary>
        /// <param name="PackInfo"></param>
        /// <returns></returns>
        public void Add_PrintData(DataSet _notprintdata)
        {
            _WTT_NotPrintList.Add(_notprintdata);
            _LabCount++;
            if (_IsBtPrint) //if printType is Bt   
            {
                BtPrint();
            }
            else //PrintType is HP
            {
                if (_LabCount == 12)
                {
                    Print();
                    My_MessageBox.My_MessageBox_Message("标签数量为：" + _LabCount + " PCS \r\n系统正在打印...");
                }
            }
        }

        /// <summary>
        /// 开始打印
        /// </summary>
        public void Print()
        {
            if (LabCount >= 1)
            {
                /*  改动日期2015-01-06 目的;实现可以连续输入排队打印
                Thread Mythread_ExReport = new Thread(new ThreadStart(onPrint));
                Mythread_ExReport.IsBackground = true;
                Mythread_ExReport.DisableComObjectEagerCleanup();
                Mythread_ExReport.Start();
                 */
                onPrint();
            }
        }

        /// <summary>
        /// 开始打印 BT打印
        /// </summary>
        public void BtPrint()
        {
            if (SN != "")
            {
                /* 改动日期2015-01-06 目的;实现可以连续输入排队打印
                Thread Mythread_ExReport = new Thread(new ThreadStart(onBtPrint));
                Mythread_ExReport.IsBackground = true;
                Mythread_ExReport.DisableComObjectEagerCleanup();
                Mythread_ExReport.Start();
                 */
                onBtPrint();
            }
        }


        /// <summary>
        /// 标签打印
        /// </summary>
        protected virtual void onPrint()
        {
            try
            {
                string ExcelName = _WTT_LabSetInfo.Tables[0].Rows[0]["LabName"].ToString();
                string ExcelPath = "D:\\模板\\PrintTemplates\\Data_Source\\" + ExcelName.Substring(0, ExcelName.Length - 4) + ".xlsx";

                //1.获取默认打印机 填充数据 2.开始打印  3.计数清零 4.Exfo待打印数据列表清零        
                //获取默认打印机
                PrintDocument fPrintDocument = new PrintDocument();
                Delete_ExcelData(ExcelPath,24);
                //填充打印数据源
                foreach (DataSet _Temds in _WTT_NotPrintList)
                    Install_data_ToExcel(_Temds);

                Messages messages = null;
                //设置打印模板
                LabelFormatDocument btFormat = btEngine.Documents.Open(LabPatch + LabName);
                //设置打印机
                btFormat.PrintSetup.PrinterName = fPrintDocument.PrinterSettings.PrinterName;
                btFormat.Activate();
                Result result = btFormat.Print("PrintJob1", out messages);
                btFormat.Close(SaveOptions.SaveChanges);
                _LabCount = 0;
                _WTT_NotPrintList.Clear();
                Delete_ExcelData(ExcelPath,24);
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }


        /// <summary>
        /// 通过Bt打印机进行打印
        /// </summary>
        protected virtual void onBtPrint()
        {
            try
            {
                //1.获取默认打印机 填充数据 2.开始打印  3.计数清零 4.Exfo待打印数据列表清零        
                //获取默认打印机
                PrintDocument fPrintDocument = new PrintDocument();

                Messages messages = null;
                //设置打印模板
                LabelFormatDocument btFormat = btEngine.Documents.Open(LabPatch + LabName);

                //设置打印机
                btFormat.PrintSetup.PrinterName = fPrintDocument.PrinterSettings.PrinterName;
                btFormat.Activate();

                if (_WTT_LabSetInfo != null)
                {
                    //填充打印数据源
                    foreach (DataRow dr in _WTT_LabSetInfo.Tables[0].Rows)
                    {
                        string drName = dr["Name"].ToString();
                        btFormat.SubStrings[drName].Value = dr["Value"].ToString();
                    }


                    //BT打印临时添加代码变更时间 2015-5-26 变更原因 海信标签需要进行1315打印 而其它的则都不需要1315
                    if (LabName == "海信_RD-A-ELA32983.btw")
                    {
                        Pack_Exfo _M_Pack_Exfo = new Pack_Exfo();
                        //添加打印数据
                        DataSet temds = _M_Pack_Exfo.GetList("ClientSN='" + SN + "'");
                        if (temds.Tables[0].Rows.Count < 4)
                        {
                            My_MessageBox.My_MessageBox_Message("打印数据不足（1310或1550数据不够）请检测标签和数据！请重新上传测试数据");
                        }
                        //填充打印数据源
                        foreach (DataRow dr in temds.Tables[0].Rows)
                        {
                            if (dr["PartNumber"].ToString() == "1" && dr["Wave"].ToString() == "1310nm")
                            {
                                btFormat.SubStrings["IL_One_13"].Value = dr["IL_A"].ToString();
                                btFormat.SubStrings["RL_One_13"].Value = dr["Refl_A"].ToString();
                            }
                            if (dr["PartNumber"].ToString() == "1" && dr["Wave"].ToString() == "1550nm")
                            {
                                btFormat.SubStrings["IL_One_15"].Value = dr["IL_A"].ToString();
                                btFormat.SubStrings["RL_One_15"].Value = dr["Refl_A"].ToString();
                            }
                            if (dr["PartNumber"].ToString() == "2" && dr["Wave"].ToString() == "1310nm")
                            {
                                btFormat.SubStrings["IL_Two_13"].Value = dr["IL_A"].ToString();
                                btFormat.SubStrings["RL_Two_13"].Value = dr["Refl_A"].ToString();
                            }
                            if (dr["PartNumber"].ToString() == "2" && dr["Wave"].ToString() == "1550nm")
                            {
                                btFormat.SubStrings["IL_Two_15"].Value = dr["IL_A"].ToString();
                                btFormat.SubStrings["RL_Two_15"].Value = dr["Refl_A"].ToString();
                            }
                        }
                    }

                }

                btFormat.SubStrings["SN"].Value = SN;

                // Result result = btFormat.Print("PrintJob1", out messages);
                btFormat.Print();
                btFormat.Close(SaveOptions.SaveChanges);
                _LabCount = 0;
                _WTT_NotPrintList.Clear();
                SN = "";
            }
            catch (System.Exception ex)
            { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        #endregion


        #region Method
        ///// <summary>
        /////  install Data TO Excel
        /////  Export 
        ///// </summary>
        //private bool Install_data_ToExcel(DataSet _ds)
        //{
        //    //填充标签设置信息
        //    string _LineName = "(", _LineValue = "(";
        //    string _Tem_Name = "", _Tem_Value = "";
        //    foreach (DataRow labdr in _WTT_LabSetInfo.Tables[0].Rows)
        //    {
        //        //获取标签各项的名字与值
        //        _Tem_Name = labdr["Name"].ToString();
        //        _Tem_Value = labdr["Value"].ToString();


        //        //SET SN
        //        if (_Tem_Name == "SN")
        //        {
        //            _Tem_Value = _ds.Tables[0].Rows[0]["SN"].ToString().Substring(0, 10);

        //            //添加标签打印记录
        //            _PrintRecord.SN = _Tem_Value;
        //            _PrintRecord.DataTime = DateTime.Now.ToString();
        //            _M_PrintRecord.Add(_PrintRecord);
        //        }
        //        //SET RL
        //        else if (_Tem_Name.Substring(0, 2) == "RL")
        //        {


        //            string _tem_r = _Tem_Name.Substring(3, _Tem_Name.Length - 3);
        //            foreach (DataRow _E_dr in _ds.Tables[0].Rows)
        //            {
        //                string _tem_v_r = _E_dr["PartNumber"].ToString();
        //                if (_tem_v_r == _tem_r)
        //                {
        //                    _Tem_Value = _E_dr["Refl_A"].ToString();
        //                    if (_Tem_Value != "")
        //                    {
        //                        double tem_R_v = double.Parse(_Tem_Value);
        //                        tem_R_v = Math.Abs(tem_R_v);
        //                        _Tem_Value = tem_R_v.ToString("0");
        //                        if (_Tem_Value == "0") { _Tem_Value = ""; } //如果值为0则为空
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    _Tem_Value = "";
        //                }
        //            }
        //        }
        //        //SET IL
        //        else if (_Tem_Name.Substring(0, 2) == "IL")
        //        {
        //            string _tem_i = _Tem_Name.Substring(3, _Tem_Name.Length - 3);
        //            foreach (DataRow _E_dr in _ds.Tables[0].Rows)
        //            {
        //                string _tem_v_i = _E_dr["PartNumber"].ToString();
        //                if (_tem_v_i == _tem_i)
        //                {
        //                    _Tem_Value = _E_dr["IL_A"].ToString();
        //                    if (_Tem_Value != "")
        //                    {
        //                        double tem_I_v = double.Parse(_Tem_Value);
        //                        tem_I_v = Math.Abs(tem_I_v);
        //                        _Tem_Value = tem_I_v.ToString("0.00");
        //                    }
        //                    break;
        //                }
        //                else
        //                {
        //                    _Tem_Value = "";
        //                }
        //            }
        //        }

        //        //拼接Command 
        //        _LineName += _Tem_Name + ",";
        //        _LineValue += "'" + _Tem_Value + "',";
        //    }
        //    //对语句进行修剪 去除最后一个字符 “ ，”
        //    _LineName = _LineName.Substring(0, _LineName.Length - 1) + ")";
        //    _LineValue = _LineValue.Substring(0, _LineValue.Length - 1) + ")";

        //    //插入数据
        //    if (SaveFP2toExcel(_LineName, _LineValue)) return true; else return false;

        //}


        /// <summary>
        ///  install Data TO Excel
        ///  Export 
        /// </summary>
        private bool Install_data_ToExcel(DataSet _ds)
        {
            string ExcelName = _WTT_LabSetInfo.Tables[0].Rows[0]["LabName"].ToString();
            string Path = "D:\\模板\\PrintTemplates\\Data_Source\\" + ExcelName.Substring(0, ExcelName.Length - 4) + ".xlsx";
            ZhuifengLib.ExcelHelper excelHelper = new ZhuifengLib.ExcelHelper(Path);
            var ParList = new List<ZhuifengLib.InsertExcelParameter>();

            string _Tem_Name = "", _Tem_Value = "";
            foreach (DataRow labdr in _WTT_LabSetInfo.Tables[0].Rows)
            {
                //获取标签各项的名字与值
                _Tem_Name = labdr["Name"].ToString();
                _Tem_Value = labdr["Value"].ToString();
                //SET SN
                if (_Tem_Name == "SN")
                {
                    _Tem_Value = _ds.Tables[0].Rows[0]["SN"].ToString().Substring(0, 10);

                    //添加标签打印记录
                    _PrintRecord.SN = _Tem_Value;
                    _PrintRecord.DataTime = DateTime.Now.ToString();
                    _M_PrintRecord.Add(_PrintRecord);
                }
                //SET RL
                else if (_Tem_Name.Substring(0, 2) == "RL")
                {
                    string _tem_r = _Tem_Name.Substring(3, _Tem_Name.Length - 3);
                    foreach (DataRow _E_dr in _ds.Tables[0].Rows)
                    {
                        string _tem_v_r = _E_dr["PartNumber"].ToString();
                        if (_tem_v_r == _tem_r)
                        {
                            _Tem_Value = _E_dr["Refl_A"].ToString();
                            if (_Tem_Value != "")
                            {
                                double tem_R_v = double.Parse(_Tem_Value);
                                tem_R_v = Math.Abs(tem_R_v);
                                _Tem_Value = tem_R_v.ToString("0");
                                if (_Tem_Value == "0") { _Tem_Value = ""; } //如果值为0则为空
                            }
                            break;
                        }
                        else
                        {
                            _Tem_Value = "";
                        }
                    }
                }
                //SET IL
                else if (_Tem_Name.Substring(0, 2) == "IL")
                {
                    string _tem_i = _Tem_Name.Substring(3, _Tem_Name.Length - 3);
                    foreach (DataRow _E_dr in _ds.Tables[0].Rows)
                    {
                        string _tem_v_i = _E_dr["PartNumber"].ToString();
                        if (_tem_v_i == _tem_i)
                        {
                            _Tem_Value = _E_dr["IL_A"].ToString();
                            if (_Tem_Value != "")
                            {
                                double tem_I_v = double.Parse(_Tem_Value);
                                tem_I_v = Math.Abs(tem_I_v);
                                _Tem_Value = tem_I_v.ToString("0.00");
                            }
                            break;
                        }
                        else
                        {
                            _Tem_Value = "";
                        }
                    }
                }
                ParList.Add(new ZhuifengLib.InsertExcelParameter() { Type = _Tem_Name, Paramenter = _Tem_Value });
            }
            excelHelper.InsertRow(ParList);
            return true;
        }



        



        /// <summary>  
        /// 写入Excel文档  
        /// </summary>  
        /// <param name="Path">文件名称</param>  
        private bool SaveFP2toExcel(string _lineName, string _lineValue)
        {
            //try
            //{
            string ExcelName = _WTT_LabSetInfo.Tables[0].Rows[0]["LabName"].ToString();
            string Path = "D:\\模板\\PrintTemplates\\Data_Source\\" + ExcelName.Substring(0, ExcelName.Length - 4) + ".xlsx";

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            //插入数据的命令
            cmd.CommandText = "INSERT INTO [sheet1$] " + _lineName + " VALUES " + _lineValue + "";
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;

            //}
            //    catch (System.Data.OleDb.OleDbException ex)
            //    {
            //        My_MessageBox.My_MessageBox_Message("写入Excel发生错误：" + ex.Message);
            //        return false;
            //    };
        }

        /// <summary>
        /// 清除指定Excel中的数据
        /// </summary>
        /// <param name="_Patch"></param>
        /// <returns></returns>
        public static bool Delete_ExcelData(string _Patch,int deleteRows)
        {
            try
            {
                // kill_Process("excel");
                //将数据填充到模板
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null) { return false; }
                xlApp.Workbooks._Open(_Patch);
                Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
                //删除指定区域
                for (int t = 0; t < deleteRows; t++)
                {
                    Excel.Range m_objRange = (Excel.Range)oSheet.Rows[2, System.Reflection.Missing.Value];
                    m_objRange.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }

                //填充完成后的操作          
                xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
                xlApp.AlertBeforeOverwriting = false;
                xlApp.SaveWorkspace(); //保存工作簿  
                xlApp.Quit();          //确保Excel进程关闭  
                xlApp = null;
                GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出 
                return true;
            }
            catch (SyntaxErrorException ex)
            {
                My_MessageBox.My_MessageBox_Message(ex.Message);
                return false;
            }
        }

        private bool kill_Process(string _ProcessName)
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
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



        private bool add_PrintRecord()
        {

            return true;
        }
        #endregion

        #region ##
        public delegate void LabelPrintReportEventHandler(LabelPrintEventArgs e);        //委托定义
        public event LabelPrintReportEventHandler LabelPrint;                            //事件定义

        public class LabelPrintEventArgs : EventArgs                                     //参数类定义
        {
            //参数定义
            public readonly Maticsoft.Model.WorkOrder WorkOrder;
            public readonly string TemplatePath;
            public readonly DataSet LabelSet;
            public readonly DataSet ExfoTestData;

            /// <summary>
            /// 默认构造函数
            /// </summary>
            /// <param name="_TemplatePath">模板路径</param>
            /// <param name="_LabelSet">标签设置信息</param>
            /// <param name="_ExfoTestData">待打印Exfo测试数据</param>
            public LabelPrintEventArgs(Maticsoft.Model.WorkOrder _WorkOrder, string _TemplatePath, DataSet _LabelSet, DataSet _ExfoTestData)
            {
                this.WorkOrder = _WorkOrder;
                this.TemplatePath = _TemplatePath;
                this.LabelSet = _LabelSet;
                this.ExfoTestData = _ExfoTestData;
            }
        }

        /// <summary>
        /// 验证事件是否为空
        /// </summary>
        protected virtual void onLabelPrint(LabelPrintEventArgs e)
        {
            if (LabelPrint != null)
            {
                LabelPrint(e);
            }
        }

        /// <summary>
        /// 开始打印
        /// </summary>
        public void Print(LabelPrintEventArgs e)
        {
            onLabelPrint(e);
        }
        #endregion

    }
}
