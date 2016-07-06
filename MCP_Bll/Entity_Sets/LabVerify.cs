using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// LabVerify
	/// </summary>
	public partial class LabVerify
	{
		private readonly Maticsoft.DAL.LabVerify dal=new Maticsoft.DAL.LabVerify();
		public LabVerify()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal LBV_ID)
		{
			return dal.Exists(LBV_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.LabVerify model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.LabVerify model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal LBV_ID)
		{
			
			return dal.Delete(LBV_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LBV_IDlist )
		{
			return dal.DeleteList(LBV_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.LabVerify GetModel(decimal LBV_ID)
		{
			
			return dal.GetModel(LBV_ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.LabVerify GetModel(string sqlWhere)
        {
            return dal.GetModel(sqlWhere);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.LabVerify GetModelByCache(decimal LBV_ID)
		{
			
			string CacheKey = "LabVerifyModel-" + LBV_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LBV_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.LabVerify)objModel;
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
		public List<Maticsoft.Model.LabVerify> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.LabVerify> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.LabVerify> modelList = new List<Maticsoft.Model.LabVerify>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.LabVerify model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.LabVerify();
					if(dt.Rows[n]["LBV_ID"]!=null && dt.Rows[n]["LBV_ID"].ToString()!="")
					{
						model.LBV_ID=decimal.Parse(dt.Rows[n]["LBV_ID"].ToString());
					}
					if(dt.Rows[n]["Orm_ID"]!=null && dt.Rows[n]["Orm_ID"].ToString()!="")
					{
					model.Orm_ID=dt.Rows[n]["Orm_ID"].ToString();
					}
					if(dt.Rows[n]["Pb_ID"]!=null && dt.Rows[n]["Pb_ID"].ToString()!="")
					{
					model.Pb_ID=dt.Rows[n]["Pb_ID"].ToString();
					}
					if(dt.Rows[n]["IsVerify"]!=null && dt.Rows[n]["IsVerify"].ToString()!="")
					{
					model.IsVerify=dt.Rows[n]["IsVerify"].ToString();
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
					model.UserID=dt.Rows[n]["UserID"].ToString();
					}
					if(dt.Rows[n]["LabPic_ID"]!=null && dt.Rows[n]["LabPic_ID"].ToString()!="")
					{
					model.LabPic_ID=dt.Rows[n]["LabPic_ID"].ToString();
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

