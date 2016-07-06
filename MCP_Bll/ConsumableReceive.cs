/**  版本信息模板在安装目录下，可自行修改。
* ConsumableReceive.cs
*
* 功 能： N/A
* 类 名： ConsumableReceive
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-09-26 10:32:33   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
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
	/// ConsumableReceive
	/// </summary>
	public partial class ConsumableReceive
	{
		private readonly Maticsoft.DAL.ConsumableReceive dal=new Maticsoft.DAL.ConsumableReceive();
		public ConsumableReceive()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取领料数量
        /// </summary>
        /// <param name="Barcode"></param>
        /// <returns></returns>
        public double GetStoge(string Barcode)
        {
            return dal.Get_Stock(Barcode);
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal C_RecID)
		{
			return dal.Exists(C_RecID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ConsumableReceive model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ConsumableReceive model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal C_RecID)
		{
			
			return dal.Delete(C_RecID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_RecIDlist )
		{
			return dal.DeleteList(C_RecIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ConsumableReceive GetModel(decimal C_RecID)
		{
			
			return dal.GetModel(C_RecID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ConsumableReceive GetModelByCache(decimal C_RecID)
		{
			
			string CacheKey = "ConsumableReceiveModel-" + C_RecID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_RecID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ConsumableReceive)objModel;
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
		public List<Maticsoft.Model.ConsumableReceive> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ConsumableReceive> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ConsumableReceive> modelList = new List<Maticsoft.Model.ConsumableReceive>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ConsumableReceive model;
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

