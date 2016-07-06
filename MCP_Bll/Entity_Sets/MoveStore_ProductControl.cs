/* MoveStore_ProductControl.cs
*
* 功 能： N/A
* 类 名： MoveStore_ProductControl
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-11 11:20:22   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// MoveStore_ProductControl
	/// </summary>
	public partial class MoveStore_ProductControl
	{
		private readonly Maticsoft.DAL.MoveStore_ProductControl dal=new Maticsoft.DAL.MoveStore_ProductControl();
		public MoveStore_ProductControl()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MS_ID)
		{
			return dal.Exists(MS_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.MoveStore_ProductControl model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 获取个状态数量
        /// </summary>
        /// <param name="strWhere"> 可以查询各站 及 各状态 (tb_StateList.State = '待研磨') AND (tb_Workstation.Workstation = '南_第一站') </param>
        /// <returns></returns>
        public double GetViewStateCount(string _Ord_ID, string strWhere) 
        {
            return dal.GetView_StateCount(_Ord_ID, strWhere);
        }

        /// <summary>
        /// 获取工单指定站别发出的数量
        /// </summary>
        /// <param name="OrderList">工单列表</param>
        /// <param name="_WK">工作站别</param>
        /// <returns></returns>
        public double GetWKCount_Send(string[] OrderList, string _WK)
        {
            return dal.GetWK_Count_Send(OrderList, _WK);
        }

        /// <summary>
        /// 获取工单中物料在各站发送与接收的信息
        /// </summary>
        /// <param name="strWhere">工单单号：为IN 格式的查询语句 </param>
        /// <returns></returns>
        public DataSet GetOrderMaterialInfo(string[] OrderList)
        {
            return dal.GetOrderMaterialInfo(OrderList);
        }

        /// <summary>
        /// 获取工单指定站别接收的数量
        /// </summary>
        /// <param name="OrderList">工单列表</param>
        /// <param name="_WK">工作站别</param>
        /// <returns></returns>
        public double GetWKCount_Receive(string[] OrderList, string _WK)
        {
            return dal.GetWK_Count_Receive(OrderList, _WK);
        }

        /// <summary>
        /// 获取个状态数量
        /// </summary>
        /// <param name="strWhere"> 可以查询各站 及 各状态 (tb_StateList.State = '不良返回') AND (tb_Workstation.Workstation = '南_第三站') </param>
        /// <returns></returns>
        public double GetView_StateCount_Send(string _Ord_ID, string strWhere)
        {
            return dal.GetView_StateCount_Send(_Ord_ID, strWhere);
        }

        /// <summary>
        /// 获得总数量
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public int GetSUM_StateCount(string strWhere)
        {
            return dal.GetSUM_StateCount(strWhere);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.MoveStore_ProductControl model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal MS_ID)
		{
			
			return dal.Delete(MS_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MS_IDlist )
		{
			return dal.DeleteList(MS_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.MoveStore_ProductControl GetModel(decimal MS_ID)
		{
			
			return dal.GetModel(MS_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.MoveStore_ProductControl GetModelByCache(decimal MS_ID)
		{		
			string CacheKey = "MoveStore_ProductControlModel-" + MS_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MS_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.MoveStore_ProductControl)objModel;
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
		public List<Maticsoft.Model.MoveStore_ProductControl> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.MoveStore_ProductControl> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.MoveStore_ProductControl> modelList = new List<Maticsoft.Model.MoveStore_ProductControl>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.MoveStore_ProductControl model;
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

