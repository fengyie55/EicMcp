using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.DAL;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class Pack_Exfo
	{
		private readonly Maticsoft.DAL.Pack_Exfo dal=new Maticsoft.DAL.Pack_Exfo();
		public Pack_Exfo()
		{}
		#region  BasicMethod

        /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string BatchNo, Maticsoft.Model.E_InspectMethod _inspectMethod)
        {
            return dal.Get_PackData(BatchNo, _inspectMethod);
        }

        /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string ClientSN)
        {
            return dal.Get_PackData(ClientSN);
        }

        /// <summary>
        /// 添加包装数据
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            dal.Add_Pack(e);
        }
        /// <summary>
        /// 添加包装数据 两码两标签
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack_TwoSnTwoLab(My_GetTestData.UpDataEventArgs e)
        {
            dal.Add_Pack_TwoSnTwoLab(e);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Pack_Exfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Pack_Exfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sqlWhere)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(sqlWhere);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Pack_Exfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Pack_Exfo GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "Pack_ExfoModel-" ;
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
			return (Maticsoft.Model.Pack_Exfo)objModel;
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
		public List<Maticsoft.Model.Pack_Exfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Pack_Exfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Pack_Exfo> modelList = new List<Maticsoft.Model.Pack_Exfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Pack_Exfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel_YetPack(dt.Rows[n]);
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

