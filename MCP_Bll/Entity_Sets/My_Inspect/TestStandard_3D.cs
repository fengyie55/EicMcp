using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class TestStandard_3D
	{
		private readonly Maticsoft.DAL.TestStandard_3D dal=new Maticsoft.DAL.TestStandard_3D();
		public TestStandard_3D()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.TestStandard_3D model)
		{
			return dal.Add(model);
		}
       
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.TestStandard_3D model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string orderID,string type)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(orderID,type);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string _orderID)
        {
            return dal.Delete(_orderID);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.TestStandard_3D GetModel(string strSql)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(strSql);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.TestStandard_3D GetModelByCache(string _steWher)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "TestStandard_3DModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(_steWher);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.TestStandard_3D)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public ArrayList GetArrayList(string _strWhere)
        {
            return dal.GetArrayList(_strWhere);
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
		public List<Maticsoft.Model.TestStandard_3D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.TestStandard_3D> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.TestStandard_3D> modelList = new List<Maticsoft.Model.TestStandard_3D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.TestStandard_3D model;
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

