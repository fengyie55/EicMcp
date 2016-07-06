/**  版本信息模板在安装目录下，可自行修改。
* ConsumableStorage.cs
*
* 功 能： N/A
* 类 名： ConsumableStorage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-09-26 10:32:35   N/A    初版
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
	/// ConsumableStorage
	/// </summary>
	public partial class ConsumableStorage
	{
		private readonly Maticsoft.DAL.ConsumableStorage dal=new Maticsoft.DAL.ConsumableStorage();
		public ConsumableStorage()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取入库数量
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
		public bool Exists(decimal C_StoID)
		{
			return dal.Exists(C_StoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ConsumableStorage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ConsumableStorage model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal C_StoID)
		{
			
			return dal.Delete(C_StoID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_StoIDlist )
		{
			return dal.DeleteList(C_StoIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ConsumableStorage GetModel(decimal C_StoID)
		{
			
			return dal.GetModel(C_StoID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ConsumableStorage GetModelByCache(decimal C_StoID)
		{
			
			string CacheKey = "ConsumableStorageModel-" + C_StoID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(C_StoID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ConsumableStorage)objModel;
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
		public List<Maticsoft.Model.ConsumableStorage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ConsumableStorage> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ConsumableStorage> modelList = new List<Maticsoft.Model.ConsumableStorage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ConsumableStorage model;
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

