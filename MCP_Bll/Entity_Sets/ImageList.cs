using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ImageList
	/// </summary>
	public partial class ImageList
	{
		private readonly Maticsoft.DAL.ImageList dal=new Maticsoft.DAL.ImageList();
		public ImageList()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ImageList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ImageList model)
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ImageList GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}


         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ImageList GetModel(string sqlWhere)
        {
            return dal.GetModel(sqlWhere);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ImageList GetModelByCache(decimal ID)
		{
			
			string CacheKey = "ImageListModel-" + ID;
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
			return (Maticsoft.Model.ImageList)objModel;
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
		public List<Maticsoft.Model.ImageList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ImageList> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ImageList> modelList = new List<Maticsoft.Model.ImageList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ImageList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ImageList();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=decimal.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Remarks"]!=null && dt.Rows[n]["Remarks"].ToString()!="")
					{
					model.Remarks=dt.Rows[n]["Remarks"].ToString();
					}
					if(dt.Rows[n]["Im"]!=null && dt.Rows[n]["Im"].ToString()!="")
					{
						model.Im=(byte[])dt.Rows[n]["Im"];
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

