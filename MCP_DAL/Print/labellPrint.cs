using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seagull.BarTender.Print;
using System.Collections;

namespace Maticsoft.DAL
{
    public class labellPrint
    {
        #region 参数
        ZebraPrint _print = new ZebraPrint();
        SerialNumber _Method_serialNumber = new SerialNumber();  //条码      
        Model.WorkOrder _WorkOrder = new Model.WorkOrder();      //工单信息    
        Model.PackBatch _PackBatch = new Model.PackBatch();      //批号信息
        int _packCount_Batch = 0;                                //已包装数量
        int _yetPrintCount = 0;                                  //已打印数
        int DirectionCount = 0;                                  //12芯*2打印单边打印数量
        string _ErrorList = "";                                  //异常列表
        string _SN = "";

        Model.PrintRecord _PrintRecord = new Model.PrintRecord();
        ArrayList _list_clientSN = new ArrayList();             //客户编码列表
        ArrayList _list_pigtailSN = new ArrayList();            //Pigtail编码列表   
        #endregion
        #region 属性
        /// <summary>
        /// 设置工单单号
        /// </summary>
        public string OrderID
        {
            set
            {
                _ErrorList = "";
                WorkOrder wk = new WorkOrder();
                _WorkOrder = wk.GetModel(value);         //获取工单信息
                if (_WorkOrder != null)
                {
                    Option(_WorkOrder);                  //选择打印方式
                    _list_clientSN = _Method_serialNumber.Get_SN_List(value, Model.E_SerialNumber_Type.ClientSN);  //客户编码列表
                    _list_pigtailSN = _Method_serialNumber.Get_SN_List(value, Model.E_SerialNumber_Type.PigtailSN);//Pigtail编码列表
                    _PrintRecord.OrderID = value;
                }
                else
                {
                    _ErrorList += "\r\n未找到工单：:" + value + "的信息，请确认是否存在此工单！";
                }
            }
        }
        /// <summary>
        /// 设置批号
        /// </summary>
        public string PackBatch
        {
            set
            {
                PackBatch pb = new PackBatch();
                _PackBatch = pb.GetModel(value);
                string str_FindPackCount = "(State = 'Yet_Pack') AND (Type = 'ClientSN') AND (BatchNo ='" + value + "') ";
                _packCount_Batch = _Method_serialNumber.Get_PackCount_Batch(str_FindPackCount);                     //已包装数 
                _PrintRecord.BatchNo = value;
                PrintCount(value);
            }
        }
        /// <summary>
        /// 设置SN
        /// </summary>
        public string SN
        {
            set
            {
                _SN = value;                                      //SN赋值          
                StartInspect(value);                              //开始检测
                _PrintRecord.SN = value;                          //打印记录 SN  
                _PrintRecord.DataTime = DateTime.Now.ToString();  //记录记录 时间            
            }
        }

        /// <summary>
        /// 设置打印机
        /// </summary>
        public string PrintName
        {
            set { _print.PrintName = value; }
        }
        /// <summary>
        /// 打印模板
        /// </summary>
        public string labMode
        {
            set
            {
                _print.labMode = value;
                if (value == "\\\\qqqqqq-ms2\\MCP\\24芯打印模板\\特恩驰测试右.btw")
                {
                    _PrintRecord.LabellMode = "右";
                }
                else { _PrintRecord.LabellMode = "左"; }

                Maticsoft.DAL.tb_PrintRecord _pr = new tb_PrintRecord();
                DirectionCount = _pr.GetRecordCount("(BatchNo = '" + _PackBatch.BatchNo + "') AND (LabellMode = '" + _PrintRecord.LabellMode + "')"); //获取指定方向打印的数量           
            }
        }
        /// <summary>
        ///  工单基本信息
        /// </summary>
        public Model.WorkOrder OrderInfo
        {
            get { return _WorkOrder; }
        }
        /// <summary>
        /// 开始打印
        /// </summary>

        public void StartPrint()
        {
            _print.StartPrint(); //开始打印
            Maticsoft.DAL.tb_PrintRecord _pr = new tb_PrintRecord();
            _pr.Add(_PrintRecord);                  
            DirectionCount = _pr.GetRecordCount("(BatchNo = '" + _PackBatch.BatchNo + "') AND (LabellMode = '" + _PrintRecord.LabellMode + "')"); //获取指定方向打印的数量           
            PrintCount(_PackBatch.BatchNo);
        }
        /// <summary>
        /// 已打印数量
        /// </summary>
        public int YetPrintCount
        {
            get { return _yetPrintCount; }
        }
        public int DirectionPrintCount
        {
            get { return DirectionCount; }
        }
        /// <summary>
        /// 异常列表
        /// </summary>
        public string Get_ErroyList
        {
            get { return _ErrorList; }
        }
        #endregion
        #region 方法

        private void Option(Model.WorkOrder _wk)
        {
            //如果是12芯x2 线材类型 执行直接调取模板
            if (_wk.InspectMethod == Model.E_InspectMethod.TFK十二芯检测x2)
            {
                _print.MyZeberPrint += MyPrint;
            }
        }

        //开始检测
        private void StartInspect(string _SN)
        {
            Maticsoft.DAL.tb_PrintRecord _pr = new tb_PrintRecord();
            SerialNumber sen = new SerialNumber();
            _ErrorList = "";

            if (_yetPrintCount != _PackBatch.Count)                                                                    //1.批量与已打印是否相等
            {
                if (sen.Exists_Where("(State = 'Yet_Pack') AND (Type = 'ClientSN') AND (SN Like '" + _SN + "%')"))     //2.条码是否已经包装
                {                  
                        if (!_pr.Exists(_SN)) //4.是否已打印                         
                        {
                            /***************** 配组  检测 PigtailSN  *********************************/
                            if (_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_八芯 ||
                            _WorkOrder.InspectMethod == Model.E_InspectMethod.配组_二十四芯 ||
                            _WorkOrder.InspectMethod == Model.E_InspectMethod.配组_四十八芯 ||
                            _WorkOrder.InspectMethod == Model.E_InspectMethod.配组_九十六芯)
                            {
                                if (_list_pigtailSN.Contains(_SN)) //3.条码是否属于此工单                                                           
                                { }
                                else { _ErrorList += "\r\n条码:" + _SN + "不属于此工单！"; }//3.
                            }
                            /***************** 非配组  检测 ClientSN  *********************************/
                            else
                            {
                                if (_list_clientSN.Contains(_SN))  //3.条码是否属于此工单                                                           
                                {
                                    DirectionCount = _pr.GetRecordCount("(BatchNo = '" + _PackBatch.BatchNo + "') AND (LabellMode = '" + _PrintRecord.LabellMode + "')"); //获取指定方向打印的数量
                                    if (DirectionCount != _PackBatch.Count / 2)    //4.（12芯*2线材 左右是否打印完成）                          
                                    { }
                                    else
                                    {
                                        _ErrorList += "\r\n批号:" + _PackBatch.BatchNo
                                            + "\r\n标签：" + _PrintRecord.LabellMode + "已打印完成！请更换方向后重试";
                                    }//4.
                                }
                                else { _ErrorList += "\r\n条码:" + _SN + "不属于此工单！"; }//3.
                            }
                        }
                        else { _ErrorList += "\r\n条码:" + _SN + "已打印！"; }//4.             
                }
                else { _ErrorList += "\r\n条码" + _SN + "未包装！"; }//2.
            }
            else //1.
            {
                _ErrorList += "\r\n工单:" + _PackBatch.OrderID
                    + "\r\n批号:" + _PackBatch.BatchNo
                    + "\r\n总批量:" + _PackBatch.Count
                    + "\r\n已包装:" + _packCount_Batch
                    + "\r\n本批已打印完成！";
            }
        }


        public int PrintCount(string BatchNo)
        {
            Maticsoft.DAL.tb_PrintRecord _pr = new tb_PrintRecord();
            _yetPrintCount = _pr.GetRecordCount(("BatchNo = '" + BatchNo + "'"));
            return _yetPrintCount;
        }

        private void MyPrint(LabelFormatDocument btFormat)
        {
            btFormat.SubStrings["SN"].Value = _SN;
        }
        #endregion
    }
}
