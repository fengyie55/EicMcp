using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections.ObjectModel;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class PackBatch
	{
		private readonly Maticsoft.DAL.PackBatch dal=new Maticsoft.DAL.PackBatch();
		public PackBatch()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BatchNo)
		{
			return dal.Exists(BatchNo);
		}
       
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.PackBatch model)
		{
            //先删除再更新 防止重复
            dal.Delete(model.BatchNo);
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.PackBatch model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string BatchNo)
		{
			
			return dal.Delete(BatchNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BatchNolist )
		{
			return dal.DeleteList(BatchNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.PackBatch GetModel(string BatchNo)
		{
			
			return dal.GetModel(BatchNo);
		}

        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public int Get_BatchCount(string sqlWhere)
        {
            return dal.Get_BatchCount(sqlWhere);
        }
     



        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="dt">DataRow</param>
        /// <returns></returns>
        public Maticsoft.Model.PackBatch GetDataTableToModel(DataRow dt)
        {

            return dal.DataRowToModel(dt);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.PackBatch GetModelByCache(string BatchNo)
		{
			
			string CacheKey = "PackBatchModel-" + BatchNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BatchNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.PackBatch)objModel;
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
        public ObservableCollection<Maticsoft.Model.PackBatch> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public ObservableCollection<Maticsoft.Model.PackBatch> DataTableToList(DataTable dt)
		{
            ObservableCollection<Maticsoft.Model.PackBatch> modelList = new ObservableCollection<Maticsoft.Model.PackBatch>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.PackBatch model;
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

