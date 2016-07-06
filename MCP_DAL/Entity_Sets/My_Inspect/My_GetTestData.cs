using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Maticsoft.DAL   
{
   public class My_GetTestData
    {
        //--------------------------------------------------------------------------------------------
        //   名称：获取数据
        //   功能：获取测试数据
        //   日期：2014-02-25 13:37
        //--------------------------------------------------------------------------------------------
        public delegate void GetDataEventHandler(GetDataEventArgs e);        //委托定义
        public event GetDataEventHandler GetData_3D;                         //事件定义 获取3D数据
        public event GetDataEventHandler GetData_Exfo;                       //事件定义 获取Exfo数据
        public class GetDataEventArgs : EventArgs                            //参数传递类定义 
        {
            /// <summary>
            /// WHERE 查询条件
            /// </summary>
            public readonly string sqlWhere;
            /// <summary>
            /// 条码
            /// </summary>
            public readonly string SN;
            public GetDataEventArgs(string _sqlWhere,string SN)
            {
                this.sqlWhere = _sqlWhere;
                this.SN = SN; 
            }
            /// <summary>
            /// 测试数据
            /// </summary>
            public DataSet TestData { get; set; }
            /// <summary>
            /// Pigtail数组
            /// </summary>
            public ArrayList PigtailList { get; set; }           
        }
        /// <summary>
        /// 获取 3D测试数据
        /// </summary>
        protected virtual void onGetData_3D(GetDataEventArgs e)
        {
            if (GetData_3D != null) { GetData_3D(e); }           
        }
        /// <summary>
        /// 获取Exfo测试数据
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onGetData_Exfo(GetDataEventArgs e)
        {
            if (GetData_Exfo != null) { GetData_Exfo(e); }
        }
        /// <summary>
        /// 获取3D 数据
        /// </summary>
        public DataSet Start_GetData_3D(GetDataEventArgs e)
        {
            onGetData_3D(e);
            return e.TestData;
        }
        public DataSet Start_GetData_Exfo(GetDataEventArgs e)
        {
            onGetData_Exfo(e);
            return e.TestData;
        }


        //--------------------------------------------------------------------------------------------
        //   名称：检测
        //   功能：获取测试数据
        //   日期：2014-02-25 13:37
        //--------------------------------------------------------------------------------------------

        //标准数组
        My_StandardList _StandatdList = new My_StandardList(); 


        /// <summary>
        /// 3D 数据是否测试通过
        /// </summary>
        /// <param name="_PigtailList">Pigtail数组</param>
        /// <returns></returns>
        public ArrayList Result_3D(Maticsoft.Model.WorkOrder _WorkOrder, ArrayList _PigtailList)
        {
            ArrayList temList = _StandatdList.Pigtail_Standard_pigtailNum(_WorkOrder.InspectMethod);
            return isEqual(temList, _PigtailList);
        }
        
        /// <summary>
        /// Exfo数是否测试通过
        /// </summary>
        /// <param name="_PigtailList">Pigtail数组</param>
        /// <returns></returns>
        public ArrayList Result_Exfo(Maticsoft.Model.WorkOrder _WorkOrder, ArrayList _PigtailList)
        {
            ArrayList temList = _StandatdList.Pigtail_Standard_pigtailNum(_WorkOrder.InspectMethod);
            return isEqual(temList, _PigtailList);
        }

        /// <summary>
        /// 判断两个数组是否相等
        /// </summary>
        /// <param name="_Standard">标准数组</param>
        /// <param name="_User_3D_Data">Pigtail接头数组</param>
        /// <returns>Arraylist 数组 空 则表示产品为良品 Pass； 不为空则返回的数组为不良品接头 Fill</returns>    
        private ArrayList isEqual(ArrayList _standradlist, ArrayList _objectlist)  //比较标准头数的集合 与 测试数据的集合是否相等 符合则为良品 否则为不良
        {
            ArrayList _list3 = new ArrayList(_standradlist); //使用New构造函数对标准数组进行重构
            for (int t = 0; t < _standradlist.Count; t++)    //用标准（集合1）中的元素与测试集合（集合2）中的每个元素进行比较
            {
                for (int i = 0; i < _objectlist.Count; i++) //循环用集合1中的元素与集合2进行逐个比较
                {
                    if (_standradlist[t].Equals(_objectlist[i].ToString()))  //如果相等
                    {
                        _list3.Remove(_standradlist[t]);    //移除重构标准数组中对应的元素
                        break; // 返回
                    }
                }
            }
            return _list3; //返回运算结果（数组为 0 标示产品为良品） （大于0 表示为不良品 其中的元素为不良品接头）
        }



        //--------------------------------------------------------------------------------------------
        //   名称：更新
        //   功能：更新测试数据
        //   日期：2014-02-25 13:37
        //--------------------------------------------------------------------------------------------
        public delegate void UpDataEventHandler(UpDataEventArgs e);        //委托定义
        public event UpDataEventHandler UpData_3D;                         //事件定义 更新3D数据
        public event UpDataEventHandler UpData_Exfo;                       //事件定义 更新Exfo数据
        public class UpDataEventArgs : EventArgs                           //参数传递类定义 
        {
            /// <summary>
            ///  测试数据
            /// </summary>
            public readonly DataSet TestData;
            /// <summary>
            ///  工单
            /// </summary>
            public readonly Maticsoft.Model.WorkOrder WorkOrder;
            /// <summary>
            ///  客户编码
            /// </summary>
            public readonly string ClientSN;
            /// <summary>
            /// 包装批号
            /// </summary>
            public readonly string BatchNo;
            public UpDataEventArgs(DataSet _TestData, Maticsoft.Model.WorkOrder _WorkOrder, string _BatchNo, string _ClientSN)
            {
                this.WorkOrder = _WorkOrder; 
                this.TestData = _TestData;
                this.ClientSN = _ClientSN;
                this.BatchNo = _BatchNo;
            }
        }
        /// <summary>
        /// 获取 3D测试数据
        /// </summary>
        protected virtual void onUpData_3D(UpDataEventArgs e)
        {
            if (UpData_3D != null) { UpData_3D(e); }
        }
        /// <summary>
        /// 获取Exfo测试数据
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onUpData_Exfo(UpDataEventArgs e)
        {
            if (UpData_Exfo != null) { UpData_Exfo(e); }
        }
        /// <summary>
        /// 开始更新3D数据
        /// </summary>
        public void Start_UpData_3D(UpDataEventArgs e)
        {
            onUpData_3D(e);
        }
        /// <summary>
        /// 开始更新Exfo数据
        /// </summary>
        public void Start_UpData_Exfo(UpDataEventArgs e)
        {
            onUpData_Exfo(e);
        }
    }
}
