using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// Operation_log
	/// </summary>
	public partial class Operation_log
	{
		private readonly Maticsoft.DAL.Operation_log dal=new Maticsoft.DAL.Operation_log();
		public Operation_log()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal R_ID)
		{
			return dal.Exists(R_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Operation_log model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Operation_log model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal R_ID)
		{
			
			return dal.Delete(R_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string R_IDlist )
		{
			return dal.DeleteList(R_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Operation_log GetModel(decimal R_ID)
		{
			
			return dal.GetModel(R_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Operation_log GetModelByCache(decimal R_ID)
		{
			
			string CacheKey = "Operation_logModel-" + R_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(R_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.Operation_log)objModel;
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
		public List<Maticsoft.Model.Operation_log> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Operation_log> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Operation_log> modelList = new List<Maticsoft.Model.Operation_log>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Operation_log model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.Operation_log();
					if(dt.Rows[n]["R_ID"]!=null && dt.Rows[n]["R_ID"].ToString()!="")
					{
						model.R_ID=decimal.Parse(dt.Rows[n]["R_ID"].ToString());
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["Operation"]!=null && dt.Rows[n]["Operation"].ToString()!="")
					{
					model.Operation=dt.Rows[n]["Operation"].ToString();
					}
					if(dt.Rows[n]["Remarks"]!=null && dt.Rows[n]["Remarks"].ToString()!="")
					{
					model.Remarks=dt.Rows[n]["Remarks"].ToString();
					}
					if(dt.Rows[n]["DateTime"]!=null && dt.Rows[n]["DateTime"].ToString()!="")
					{
						model.DateTime=DateTime.Parse(dt.Rows[n]["DateTime"].ToString());
					}
					modelList.Add(model);
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

		#endregion  Method
	}
}

