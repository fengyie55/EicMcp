/* BoxInfo.cs
*
* 功 能： N/A
* 类 名： BoxInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-19 8:21:37   N/A    初版  
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
	/// BoxInfo
	/// </summary>
	public partial class BoxInfo
	{
		private readonly Maticsoft.DAL.BoxInfo dal=new Maticsoft.DAL.BoxInfo();
		public BoxInfo()
		{}
		#region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_where(string where_sql)
        {
            return dal.Exists_Where(where_sql);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.BoxInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.BoxInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="_SqlWhere">Where查询条件  批号 或箱号</param>
        /// <returns></returns>
        public int GetYetEncasementCount(string _SqlWhere)
        {
            return dal.GetYetEncasementCount(_SqlWhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BoxInfo GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.BoxInfo GetModel(string sqlWhere)
        {
            return dal.GetModel(sqlWhere);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.BoxInfo GetModelByCache(decimal ID)
		{
			
			string CacheKey = "BoxInfoModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.BoxInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList_BatchNo_Or_BoxSN(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_BatchNo_Or_BoxSN(string strWhere)
        {
            return dal.GetList_BatchNo_Or_BoxSN(strWhere);
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
		public List<Maticsoft.Model.BoxInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList_BatchNo_Or_BoxSN(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表 用于查找
        /// </summary>
        public List<Maticsoft.Model.BoxInfo> GetModelList(string strWhere ,string _Find)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.BoxInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.BoxInfo> modelList = new List<Maticsoft.Model.BoxInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.BoxInfo model;
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

