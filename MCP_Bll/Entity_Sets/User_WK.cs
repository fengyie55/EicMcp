using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// User_WK
	/// </summary>
	public partial class User_WK
	{
		private readonly Maticsoft.DAL.User_WK dal=new Maticsoft.DAL.User_WK();
		public User_WK()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal WU_ID)
		{
			return dal.Exists(WU_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.User_WK model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.User_WK model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal WU_ID)
		{
			
			return dal.Delete(WU_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string WU_IDlist )
		{
			return dal.DeleteList(WU_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.User_WK GetModel(decimal WU_ID)
		{
			
			return dal.GetModel(WU_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.User_WK GetModelByCache(decimal WU_ID)
		{
			
			string CacheKey = "User_WKModel-" + WU_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(WU_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.User_WK)objModel;
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
		public List<Maticsoft.Model.User_WK> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.User_WK> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.User_WK> modelList = new List<Maticsoft.Model.User_WK>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.User_WK model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.User_WK();
					if(dt.Rows[n]["WU_ID"]!=null && dt.Rows[n]["WU_ID"].ToString()!="")
					{
						model.WU_ID=decimal.Parse(dt.Rows[n]["WU_ID"].ToString());
					}
					if(dt.Rows[n]["WK"]!=null && dt.Rows[n]["WK"].ToString()!="")
					{
					model.WK=dt.Rows[n]["WK"].ToString();
					}
					if(dt.Rows[n]["ClassType"]!=null && dt.Rows[n]["ClassType"].ToString()!="")
					{
					model.ClassType=dt.Rows[n]["ClassType"].ToString();
					}
					if(dt.Rows[n]["JobNum"]!=null && dt.Rows[n]["JobNum"].ToString()!="")
					{
					model.JobNum=dt.Rows[n]["JobNum"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Remarks"]!=null && dt.Rows[n]["Remarks"].ToString()!="")
					{
					model.Remarks=dt.Rows[n]["Remarks"].ToString();
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

