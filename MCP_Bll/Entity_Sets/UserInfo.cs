using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// UserInfo
	/// </summary>
	public partial class UserInfo
	{
		private readonly Maticsoft.DAL.UserInfo dal=new Maticsoft.DAL.UserInfo();
		public UserInfo()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal USI_ID)
		{
			return dal.Exists(USI_ID);
		}


        /// <summary>
        /// 获取字段不重复记录
        /// </summary>
        /// <param name="_Value">字段名</param>
        /// <returns></returns>
        public DataSet Get_Distinct_List(string _Value)
        {
            return dal.Get_Distinct_List(_Value);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.UserInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.UserInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal USI_ID)
		{
			
			return dal.Delete(USI_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string USI_IDlist )
		{
			return dal.DeleteList(USI_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.UserInfo GetModel(decimal USI_ID)
		{
			
			return dal.GetModel(USI_ID);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserInfo GetModel(string JobNum)
        {

            return dal.GetModel(JobNum);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.UserInfo GetModelByCache(decimal USI_ID)
		{
			
			string CacheKey = "UserInfoModel-" + USI_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(USI_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.UserInfo)objModel;
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
		public List<Maticsoft.Model.UserInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.UserInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.UserInfo> modelList = new List<Maticsoft.Model.UserInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.UserInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.UserInfo();
					if(dt.Rows[n]["USI_ID"]!=null && dt.Rows[n]["USI_ID"].ToString()!="")
					{
						model.USI_ID=decimal.Parse(dt.Rows[n]["USI_ID"].ToString());
					}
					if(dt.Rows[n]["Workstation"]!=null && dt.Rows[n]["Workstation"].ToString()!="")
					{
					model.Workstation=dt.Rows[n]["Workstation"].ToString();
					}
					if(dt.Rows[n]["Job_Title"]!=null && dt.Rows[n]["Job_Title"].ToString()!="")
					{
					model.Job_Title=dt.Rows[n]["Job_Title"].ToString();
					}
					if(dt.Rows[n]["Is_Job"]!=null && dt.Rows[n]["Is_Job"].ToString()!="")
					{
					model.Is_Job=dt.Rows[n]["Is_Job"].ToString();
					}
					if(dt.Rows[n]["Job_Num"]!=null && dt.Rows[n]["Job_Num"].ToString()!="")
					{
					model.Job_Num=dt.Rows[n]["Job_Num"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Age"]!=null && dt.Rows[n]["Age"].ToString()!="")
					{
					model.Age=dt.Rows[n]["Age"].ToString();
					}
					if(dt.Rows[n]["Sex"]!=null && dt.Rows[n]["Sex"].ToString()!="")
					{
					model.Sex=dt.Rows[n]["Sex"].ToString();
					}
					if(dt.Rows[n]["IsWedding"]!=null && dt.Rows[n]["IsWedding"].ToString()!="")
					{
					model.IsWedding=dt.Rows[n]["IsWedding"].ToString();
					}
					if(dt.Rows[n]["Politics"]!=null && dt.Rows[n]["Politics"].ToString()!="")
					{
					model.Politics=dt.Rows[n]["Politics"].ToString();
					}
					if(dt.Rows[n]["ID_Card"]!=null && dt.Rows[n]["ID_Card"].ToString()!="")
					{
					model.ID_Card=dt.Rows[n]["ID_Card"].ToString();
					}
					if(dt.Rows[n]["Nation"]!=null && dt.Rows[n]["Nation"].ToString()!="")
					{
					model.Nation=dt.Rows[n]["Nation"].ToString();
					}
					if(dt.Rows[n]["Native_Place"]!=null && dt.Rows[n]["Native_Place"].ToString()!="")
					{
					model.Native_Place=dt.Rows[n]["Native_Place"].ToString();
					}
					if(dt.Rows[n]["Degree"]!=null && dt.Rows[n]["Degree"].ToString()!="")
					{
					model.Degree=dt.Rows[n]["Degree"].ToString();
					}
					if(dt.Rows[n]["Major"]!=null && dt.Rows[n]["Major"].ToString()!="")
					{
					model.Major=dt.Rows[n]["Major"].ToString();
					}
					if(dt.Rows[n]["School"]!=null && dt.Rows[n]["School"].ToString()!="")
					{
					model.School=dt.Rows[n]["School"].ToString();
					}
					if(dt.Rows[n]["Date_Of_Birth"]!=null && dt.Rows[n]["Date_Of_Birth"].ToString()!="")
					{
						model.Date_Of_Birth=DateTime.Parse(dt.Rows[n]["Date_Of_Birth"].ToString());
					}
					if(dt.Rows[n]["Entry_Date"]!=null && dt.Rows[n]["Entry_Date"].ToString()!="")
					{
						model.Entry_Date=DateTime.Parse(dt.Rows[n]["Entry_Date"].ToString());
					}
					if(dt.Rows[n]["Termination_Date"]!=null && dt.Rows[n]["Termination_Date"].ToString()!="")
					{
						model.Termination_Date=DateTime.Parse(dt.Rows[n]["Termination_Date"].ToString());
					}
					if(dt.Rows[n]["QQ"]!=null && dt.Rows[n]["QQ"].ToString()!="")
					{
					model.QQ=dt.Rows[n]["QQ"].ToString();
					}
					if(dt.Rows[n]["Email_Address"]!=null && dt.Rows[n]["Email_Address"].ToString()!="")
					{
					model.Email_Address=dt.Rows[n]["Email_Address"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Present_Assress"]!=null && dt.Rows[n]["Present_Assress"].ToString()!="")
					{
					model.Present_Assress=dt.Rows[n]["Present_Assress"].ToString();
					}
					if(dt.Rows[n]["Emergency_Contact"]!=null && dt.Rows[n]["Emergency_Contact"].ToString()!="")
					{
					model.Emergency_Contact=dt.Rows[n]["Emergency_Contact"].ToString();
					}
					if(dt.Rows[n]["Resume"]!=null && dt.Rows[n]["Resume"].ToString()!="")
					{
					model.Resume=dt.Rows[n]["Resume"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

