using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// FixtureInfo
	/// </summary>
	public partial class FixtureInfo
	{
		private readonly Maticsoft.DAL.FixtureInfo dal=new Maticsoft.DAL.FixtureInfo();
		public FixtureInfo()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal FAY_ID)
		{
			return dal.Exists(FAY_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.FixtureInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.FixtureInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal FAY_ID)
		{
			
			return dal.Delete(FAY_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string FAY_IDlist )
		{
			return dal.DeleteList(FAY_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.FixtureInfo GetModel(decimal FAY_ID)
		{
			
			return dal.GetModel(FAY_ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.FixtureInfo GetModel(string AssetNum)
        {

            return dal.GetModel(AssetNum);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.FixtureInfo GetModelByCache(decimal FAY_ID)
		{
			
			string CacheKey = "FixtureInfoModel-" + FAY_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FAY_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.FixtureInfo)objModel;
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
		public List<Maticsoft.Model.FixtureInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.FixtureInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.FixtureInfo> modelList = new List<Maticsoft.Model.FixtureInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.FixtureInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.FixtureInfo();
					if(dt.Rows[n]["FAY_ID"]!=null && dt.Rows[n]["FAY_ID"].ToString()!="")
					{
						model.FAY_ID=decimal.Parse(dt.Rows[n]["FAY_ID"].ToString());
					}
					if(dt.Rows[n]["Assembly_BarCode"]!=null && dt.Rows[n]["Assembly_BarCode"].ToString()!="")
					{
					model.Assembly_BarCode=dt.Rows[n]["Assembly_BarCode"].ToString();
					}
					if(dt.Rows[n]["Assembly_Name"]!=null && dt.Rows[n]["Assembly_Name"].ToString()!="")
					{
					model.Assembly_Name=dt.Rows[n]["Assembly_Name"].ToString();
					}
					if(dt.Rows[n]["BarCode"]!=null && dt.Rows[n]["BarCode"].ToString()!="")
					{
					model.BarCode=dt.Rows[n]["BarCode"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Alias"]!=null && dt.Rows[n]["Alias"].ToString()!="")
					{
					model.Alias=dt.Rows[n]["Alias"].ToString();
					}
					if(dt.Rows[n]["Makedev"]!=null && dt.Rows[n]["Makedev"].ToString()!="")
					{
					model.Makedev=dt.Rows[n]["Makedev"].ToString();
					}
					if(dt.Rows[n]["Model"]!=null && dt.Rows[n]["Model"].ToString()!="")
					{
					model.Model=dt.Rows[n]["Model"].ToString();
					}
					if(dt.Rows[n]["FunctionRemarks"]!=null && dt.Rows[n]["FunctionRemarks"].ToString()!="")
					{
					model.FunctionRemarks=dt.Rows[n]["FunctionRemarks"].ToString();
					}
					if(dt.Rows[n]["SafeCount"]!=null && dt.Rows[n]["SafeCount"].ToString()!="")
					{
					model.SafeCount=dt.Rows[n]["SafeCount"].ToString();
					}
					if(dt.Rows[n]["Unit"]!=null && dt.Rows[n]["Unit"].ToString()!="")
					{
					model.Unit=dt.Rows[n]["Unit"].ToString();
					}
					if(dt.Rows[n]["Versions"]!=null && dt.Rows[n]["Versions"].ToString()!="")
					{
					model.Versions=dt.Rows[n]["Versions"].ToString();
					}
					if(dt.Rows[n]["Up_ID"]!=null && dt.Rows[n]["Up_ID"].ToString()!="")
					{
					model.Up_ID=dt.Rows[n]["Up_ID"].ToString();
					}
					if(dt.Rows[n]["DrawingPatch"]!=null && dt.Rows[n]["DrawingPatch"].ToString()!="")
					{
					model.DrawingPatch=dt.Rows[n]["DrawingPatch"].ToString();
					}
					if(dt.Rows[n]["Pic_ID"]!=null && dt.Rows[n]["Pic_ID"].ToString()!="")
					{
					model.Pic_ID=dt.Rows[n]["Pic_ID"].ToString();
					}
					if(dt.Rows[n]["Correlation_ID"]!=null && dt.Rows[n]["Correlation_ID"].ToString()!="")
					{
					model.Correlation_ID=dt.Rows[n]["Correlation_ID"].ToString();
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

