using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Maticsoft.BLL
{
    public partial class Cls_OrderInfo
    {
        /// <summary>
        /// 析构函数
        /// </summary>
        public Cls_OrderInfo()
        {

        }

        #region 枚举

        /// <summary>
        /// 获取物料信息的选项
        /// </summary>
        public enum WorkShopList
        {
            N_WorkShop,
            B_WorkShop,
            X_WorkShop
        }
        #endregion


        #region 属性
        /// <summary>
        /// 工单
        /// </summary>
        public Maticsoft.Model.WorkOrder Order { get; set; }

        /// <summary>
        /// 各站物料状况
        /// </summary>
        public List<string> WK_MaterialInfo { get; set; } 

        /// <summary>
        /// 图表显示的信息
        /// </summary>
        public ArrayList ChartInfo { get; set; }

        /// <summary>
        /// 工单中的物料
        /// </summary>
        public DataSet OrderMaterialList { get; set; }


        /// <summary>
        /// 获取工单领料和发料的明细
        /// </summary>
        public DataSet GetOrderMaterialInfo { get; set; }

        /// <summary>
        /// 待计算的工单列表
        /// </summary>
        public string[] OrderList { get; set; }
        #endregion



        #region Method
        /// <summary>
        /// 获取指定车间的物料信息
        /// </summary>
        public void GetOrderInfo(WorkShopList _Option)
        {

        }

        /*********************************************************
         * 显示 第一二三站的领料信息
         */

        /// <summary>
        /// 获取工单信息
        /// </summary>
        /// <param name="_Order">工单</param>
        public ObservableCollection<Customer> GetOrderInfo(string[] _OrderList)
        {
            OrderList = _OrderList;
            customers.Clear();   //清空列表！
            Maticsoft.BLL.MoveStore_ProductControl _M_MoveStore = new Maticsoft.BLL.MoveStore_ProductControl();
            Maticsoft.BLL.WorkOrder _wo = new WorkOrder();
            //总批量
            customers.Add(new Customer() { Type = "总批量", Count = _wo.GetOrderListCount(OrderList).ToString() });
            customers.Add(new Customer() { Type = "-------------", Count = "-------------" });
         
            //第一站             
            customers.Add(new Customer() { Type = "一站在制品", Count = "" });
           
            //FerInfo
            Maticsoft.BLL.Material_Inject _M_Material_Inject = new Maticsoft.BLL.Material_Inject();
            DataSet _FerReceive = _M_Material_Inject.GetInjectView(_OrderList);          
            foreach (DataRow dr in _FerReceive.Tables[0].Rows)
            {              
                double FerReceiveCount = 0, FerInjectCount=0;
                double.TryParse(dr["已领数量"].ToString(), out FerReceiveCount); // 已领取数量
                double.TryParse(dr["投入"].ToString(), out FerInjectCount);      //已投入数量
                customers.Add(new Customer() { Type = dr["别名"].ToString()+ "领取数量", Count = FerReceiveCount.ToString() });
                customers.Add(new Customer() { Type = dr["别名"].ToString() + "投入数量", Count = FerInjectCount.ToString() });
                customers.Add(new Customer() { Type = "剩余", Count = (FerReceiveCount - FerInjectCount).ToString() });
            }

           // double Not_YanMuo = _M_MoveStore.GetViewStateCount(Order.OrderID, "State='待研磨'");  //已研磨
           // double Not_Test  = _M_MoveStore.GetViewStateCount(Order.OrderID, "State='待测试'"); //已研磨   
           // double Yet_InStorage = _M_MoveStore.GetViewStateCount(Order.OrderID, "State='成品'"); //已研磨    


            //第二站                    
            double Two_Send = _M_MoveStore.GetWKCount_Send(OrderList, "第二站");
            double Two_Recieve = _M_MoveStore.GetWKCount_Receive(OrderList, "第二站");

            customers.Add(new Customer() { Type = "-------------", Count = "-------------" });
            customers.Add(new Customer() { Type = "二站在制品", Count = (Two_Recieve - Two_Send).ToString() });
            customers.Add(new Customer() { Type = "接收", Count =  Two_Recieve.ToString() });
            customers.Add(new Customer() { Type = "发出", Count =  Two_Send.ToString() });

            //第三站                    
            double Three_Send = _M_MoveStore.GetWKCount_Send(OrderList, "第三站");
            double Three_Recieve = _M_MoveStore.GetWKCount_Receive(OrderList, "第三站");
            double Three_Storege = _M_MoveStore.GetWKCount_Receive(OrderList, "仓库");

            customers.Add(new Customer() { Type = "-------------", Count = "-------------" });
            customers.Add(new Customer() { Type = "三站在制品", Count = (Three_Recieve - Three_Send).ToString() });
            customers.Add(new Customer() { Type = "接收", Count = Three_Recieve.ToString() });
            customers.Add(new Customer() { Type = "发出", Count = (Three_Send-Three_Storege).ToString() });
            // customers.Add(new Customer() { Type = "入库", Count = Three_Storege.ToString() });

            //仓库                            
            customers.Add(new Customer() { Type = "-------------", Count = "-------------" });
            customers.Add(new Customer() { Type = "入库数量", Count = Three_Storege.ToString() });

            //获取工单料件流动明细
            GetOrderMaterialInfo = _M_MoveStore.GetOrderMaterialInfo(OrderList);
            return customers;
        }

        /// <summary>
        /// 获取生产中的工单列表
        /// </summary>
        /// <returns></returns>
        public List<Maticsoft.Model.WorkOrder> get_On_Stream_Order()
        {
            Maticsoft.BLL.WorkOrder _M_WorkOrder = new Maticsoft.BLL.WorkOrder();
            return _M_WorkOrder.GetModelList("State = '待生产'");          
        }



        /// <summary>
        /// 获取指定车间的生产中的工单列表
        /// </summary>
        /// <param name="_Option"></param>
        /// <returns></returns>
        public List<Maticsoft.Model.WorkOrder> get_On_Stream_Order(WorkShopList _Option)
        {
            string _Workshop = "";
            if (_Option == WorkShopList.N_WorkShop) _Workshop = "南车间";
            else if (_Option == WorkShopList.B_WorkShop) _Workshop = "北车间";
            else if (_Option == WorkShopList.X_WorkShop) _Workshop = "小车间";
            Maticsoft.BLL.WorkOrder _M_WorkOrder = new Maticsoft.BLL.WorkOrder();
            return _M_WorkOrder.GetModelList("(Workshop = '" + _Workshop + "') AND (State = '待生产')");
        }


        /// <summary>
        /// 获取工单物料列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderMaterial_List()
        {
            Maticsoft.BLL.Material_Inject _M_MaterialInject = new Maticsoft.BLL.Material_Inject();
            return _M_MaterialInject.GetInjectView(OrderList);
        }







        //******************************** 临时类 ********************
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        CollectionViewSource view = new CollectionViewSource();
        public  class Customer
        {
            public string Type { get; set; }
            public string Count { get; set; }
        }
        //***********************************************************


        #endregion

    }
}
