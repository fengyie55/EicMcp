using System;
using System.Data;
using System.Collections.Generic;

namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class WorkOrder
	{
		private readonly Maticsoft.DAL.WorkOrder dal=new Maticsoft.DAL.WorkOrder();
		
		/// <summary>
		/// 获取工单须发料件
		/// </summary>
		/// <param name="OrderID">512-1311001</param>
		/// <returns></returns>
		public DataSet GetOrderMaterial(string OrderID)
		{
			return dal.GetOrderMaterial(OrderID);
		}

		/// <summary>
		/// 获取工单信息
		/// </summary>
		/// <param name="OrderID">512-1311001</param>
		/// <returns></returns>
		public DataSet GetOrderInfo(string OrderID)
		{
			return dal.GetOrderInfo(OrderID);
		}

		/// <summary>
		/// 获取产品品号
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public string GetProductId(string orderId)
		{
			return dal.GetProductId(orderId);
		}
		#region  BasicMethod

		/// <summary>
		/// 获取记录总数
		/// </summary>
		/// <param name="orderID">工单单号</param>
		/// <returns></returns>
		public int GetCount(string orderID)
		{
			return dal.GetRecordCount("OrderID='" + orderID + "'");
			
		}

		 /// <summary>
		/// 获取工单的总批量
		/// </summary>
		/// <param name="_OrderList"></param>
		/// <returns></returns>
		public double GetOrderListCount(string[] _OrderList)
		{
			return dal.GetOrderListCount(_OrderList);
		}

		/// <summary>
		/// 获取工单列表
		/// </summary>
		/// <param name="sqlWhere"></param>
		/// <returns></returns>
		public string[] GetOrdList(string sqlWhere) 
		{
			List<Model.WorkOrder> _TemOrderList = GetModelList(sqlWhere);
			string[] _OrderList = new string[_TemOrderList.Count];
			int t = 0;
			foreach(Model.WorkOrder _Order in _TemOrderList)
			{
				if(_Order != null)
				{
					_OrderList[t] = _Order.OrderID;
					t++;
				}
			}
			return _OrderList;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.WorkOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.WorkOrder model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string _orderID)
		{
			
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(_orderID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.WorkOrder GetModel(string _orderID)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(_orderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.WorkOrder GetModelByCache(string _orderID)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "WorkOrderModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(_orderID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.WorkOrder)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.WorkOrder> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.WorkOrder> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.WorkOrder> modelList = new List<Maticsoft.Model.WorkOrder>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.WorkOrder model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

