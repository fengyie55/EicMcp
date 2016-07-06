using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Threading;

namespace Maticsoft.BLL
{
    partial class My_Inspect
    {

        //--------------------------------------------------------------------------------------------
        //   名称：进行检测
        //   功能：进行检测
        //   日期：2014-02-26 10:49
        //--------------------------------------------------------------------------------------------

        #region 全局变量

        /// <summary>
        /// 事件类
        /// </summary>
        Maticsoft.DAL.My_GetTestData _GLL_TestData = new Maticsoft.DAL.My_GetTestData();
        /// <summary>
        /// 工单
        /// </summary>
        Maticsoft.Model.WorkOrder _GLL_WorkOrder = new Maticsoft.Model.WorkOrder();
        /// <summary>
        /// 批号
        /// </summary>
        Maticsoft.Model.PackBatch _GLL_PackBatch = new Maticsoft.Model.PackBatch();
        /// <summary>
        /// 标准数组 Pigtail
        /// </summary>
        ArrayList _GLL_Standard_PigtailList = new ArrayList();
        /// <summary>
        /// 标准数组 Client
        /// </summary>
        ArrayList _GLL_Standard_ClientList = new ArrayList();

        #endregion


        #region 属性
        /// <summary>
        /// 设置工单
        /// </summary>
        public  Maticsoft.Model.WorkOrder WorkOrder 
        { 
            set 
            {              
                this._GLL_WorkOrder =value;                                //工单赋值
                EventSet(_GLL_WorkOrder.InspectMethod, _GLL_WorkOrder.InspectType);  //设置事件 在分体类 MyInspect_EventSet中设置
                //获取标准数组
                Maticsoft.DAL.My_StandardList _M_StandardList = new Maticsoft.DAL.My_StandardList();
                _GLL_Standard_PigtailList = _M_StandardList.Pigtail_Standard_pigtailNum(_GLL_WorkOrder.InspectMethod);
                _GLL_Standard_ClientList = _M_StandardList.Client_Standard_ClientNum(_GLL_WorkOrder.InspectMethod);              
            } 
        }
        /// <summary>
        /// 批次
        /// </summary>
        public  Maticsoft.Model.PackBatch PackBatch
        {
            set 
            { 
                this._GLL_PackBatch = value;
             //调用批号中的标签
                if (_GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.TFK十二芯检测x2)
                {
                    My_Print = new My_Print(_GLL_WorkOrder.OrderID, _GLL_PackBatch.BatchNo);
                }
            //调用工单中的标签
                else   
                {
                    My_Print = new My_Print(_GLL_PackBatch);
                }
            }
        }

        /// <summary>
        /// 打印类
        /// </summary>
        public My_Print My_Print { get; set; }

        /// <summary>
        /// 是否进行更新操作
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// 是否启用标签打印
        /// </summary>
        public bool IsPrint { get { return My_Print.IsPrint; } set { My_Print.IsPrint = value; } }



        #endregion


        #region 调用类
        //--------------------------------------------------------------------------------------------
        //   名称：检测设置
        //   功能：设置检测方法 返回检测结果
        //   日期：2014-02-26 10:49
        //--------------------------------------------------------------------------------------------
        public delegate void InspectEventHandler(InspectEventArgs e);        //委托定义
        public event InspectEventHandler Event_Inspect;                      //事件定义 获取3D数据
       
        /// <summary>
        /// 检测参数传递类
        /// </summary>
        public class InspectEventArgs : EventArgs                            //参数传递类定义 
        {
            /// <summary>
            /// 条码
            /// </summary>
            public readonly string SN;
            /// <summary>
            /// 客户编码
            /// </summary>
            public readonly string ClientSN;
            /// <summary>
            /// 重载 不配组类型
            /// </summary>
            /// <param name="_SN"></param>
            public InspectEventArgs(string _SN)
            {
                this.SN = _SN;               
            }
            public InspectEventArgs() { }
            /// <summary>
            /// 重载 配组类型
            /// </summary>
            /// <param name="_ClientSN"></param>
            /// <param name="_SN"></param>
            public InspectEventArgs(string _ClientSN, string _SN)
            {
                this.ClientSN = _ClientSN;
                this.SN = _SN;
            }
            /// <summary>
            /// 检测结果
            /// </summary>
            public ResultEventArgs InspectResult { get; set; }
        }
        
        /// <summary>
        /// 检测结果传递类
        /// </summary>
        public class ResultEventArgs : EventArgs
        {
            /// <summary>
            /// 检测结果 -3D
            /// </summary>
            public  bool Result_3D { get; set; }
            /// <summary>
            /// 检测结果 -Exfo
            /// </summary>
            public bool Result_Exfo { get; set; }
            /// <summary>
            /// 配组是否完成
            /// </summary>
            public bool Combination { get; set; }
            /// <summary>
            /// 3D数据
            /// </summary>
            public DataSet Data_3D { get; set; }
            /// <summary>
            /// EXFO数据
            /// </summary>
            public DataSet Data_Exfo { get; set; }
            /// <summary>
            /// 异常列表
            /// </summary>
            public string ErrorList { get; set; }
            /// <summary>
            /// 不良接头-3D
            /// </summary>
            public string Fill_3D { get; set; }
            /// <summary>
            /// 不良接头-EXFO
            /// </summary>
            public string Fill_Exfo { get; set; }
            /// <summary>
            /// 待包装线号列表
            /// </summary>
            public string Not_ClientSN_Name { get; set; }
            
           
        }

        #endregion


        #region 执行事件
        /// <summary>
        /// 进行检测
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onInspect()
        {
            if (Event_Inspect != null) { Event_Inspect(_WTT_e); }
        }

        InspectEventArgs _WTT_e = new InspectEventArgs();
       
        /// <summary>
        /// 开始检测 并返回检测结果
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool InspectStart(InspectEventArgs e)
        {
            My_Print.SN = e.SN;
            _WTT_e = e;
            Thread Mythread_ExReport = new Thread(new ThreadStart(onInspect));
            Mythread_ExReport.IsBackground = true;
            Mythread_ExReport.DisableComObjectEagerCleanup();
            Mythread_ExReport.Start();
                       
            //等待线程执行结束
            Mythread_ExReport.Join();

            if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
            {
                if (e.InspectResult.Result_3D && e.InspectResult.Result_Exfo)
                {
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //更新条码状态
                        _GLL_SerialNumber.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _GLL_SerialNumber.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_GLL_SerialNumber);
                    }
                    return true;
                }
                else { return false; }              
            }
            else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
            {
                if (e.InspectResult.Result_Exfo == true)
                {
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //更新条码状态
                        _GLL_SerialNumber.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _GLL_SerialNumber.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_GLL_SerialNumber);
                    }
                }
                return e.InspectResult.Result_Exfo;
            }
            else  //只检测3D
            {
                if (e.InspectResult.Result_3D == true)
                {
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //更新条码状态
                        _GLL_SerialNumber.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _GLL_SerialNumber.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_GLL_SerialNumber);
                    }
                }
                return e.InspectResult.Result_3D;
            }
            
        }     
       
        /// <summary>
        /// 标签打印
        /// </summary>
        public void LabPrint()
        {          
            if (My_Print.IsPrint)
            {
                My_Print.Print();
            }
            else { My_MessageBox.My_MessageBox_Message("此工单未设置标签！"); }
        }    

        #endregion
    }
}
