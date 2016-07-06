using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// Equipment_TypeList
	/// </summary>
	public partial class Equipment_TypeList
	{
		private readonly Maticsoft.DAL.Equipment_TypeList dal=new Maticsoft.DAL.Equipment_TypeList();
		public Equipment_TypeList()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Equipment_TypeList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Equipment_TypeList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Equipment_TypeList GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Equipment_TypeList GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "Equipment_TypeListModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.Equipment_TypeList)objModel;
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
		public List<Maticsoft.Model.Equipment_TypeList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得String数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string[] GetStringList(string strWhere)
        {
            List<Maticsoft.Model.Equipment_TypeList> _tem = GetModelList(strWhere);
            string[] tem = new string[_tem.Count];
            int i = 0;
            foreach (Maticsoft.Model.Equipment_TypeList te in _tem)
            {
                tem[i] = te.Value.ToString();
                i++;
            }
            return tem;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Equipment_TypeList> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Equipment_TypeList> modelList = new List<Maticsoft.Model.Equipment_TypeList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Equipment_TypeList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.Equipment_TypeList();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=decimal.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Type"]!=null && dt.Rows[n]["Type"].ToString()!="")
					{
					model.Type=dt.Rows[n]["Type"].ToString();
					}
					if(dt.Rows[n]["Value"]!=null && dt.Rows[n]["Value"].ToString()!="")
					{
					model.Value=dt.Rows[n]["Value"].ToString();
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

