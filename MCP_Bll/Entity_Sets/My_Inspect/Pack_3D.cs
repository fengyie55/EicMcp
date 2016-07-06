using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections;
using Maticsoft.DAL;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class Pack_3D
	{
		private readonly Maticsoft.DAL.Pack_3D dal=new Maticsoft.DAL.Pack_3D();
		public Pack_3D()
		{}
		#region  BasicMethod

        /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string BatchNo,Maticsoft.Model.E_InspectMethod _inspectMethod)
        {
           return dal.Get_PackData(BatchNo,_inspectMethod);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            dal.Add_Pack(e);
        }


        /// <summary>
        /// 添加数据-多芯
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack2(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            dal.Add_Pack2(e);
        }

        /// <summary>
        /// 添加数据-8芯
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack3(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            dal.Add_Pack3(e);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Pack_3D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Pack_3D model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID_Key)
		{
			
			return dal.Delete(ID_Key);
		}

        /// <summary>
        /// 删除数据
        /// </summary>      
        /// <returns>受影响的行</returns>
        public int Delete(string strWhere)
        {
            return dal.Delete(strWhere);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ID_Keylist )
		{
			return dal.DeleteList(ID_Keylist );
		}

        /// <summary>
        /// 返回已经包装的线号（主要用于配组线材类型）
        /// </summary>
        /// <param name="_clientSN">客户编码</param>
        /// <returns></returns>
        public ArrayList Get_ClientSN_PigtailNum(string _clientSN)
        {
            return dal.Get_ClientPigtailNumber(_clientSN);
        }

        /// <summary>
        /// 返回已经包装的线号 -八芯配组
        /// </summary>
        /// <param name="_clientSN">客户编码</param>
        /// <returns></returns>
        public ArrayList Get_ClientSN_PigtailNum(string _clientSN,string _EightCore)
        {
            return dal.Get_ClientPigtailNumber(_clientSN,_EightCore);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Pack_3D GetModel(decimal ID_Key)
		{
			
			return dal.GetModel(ID_Key);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Pack_3D GetModelByCache(decimal ID_Key)
		{
			
			string CacheKey = "Pack_3DModel-" + ID_Key;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID_Key);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.Pack_3D)objModel;
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
		public List<Maticsoft.Model.Pack_3D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Pack_3D> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Pack_3D> modelList = new List<Maticsoft.Model.Pack_3D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Pack_3D model;
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

