using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections.ObjectModel;
using System.Collections;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class SerialNumber
	{
		private readonly Maticsoft.DAL.SerialNumber dal=new Maticsoft.DAL.SerialNumber();
		public SerialNumber()
		{}
		#region  BasicMethod
		

        E_InspectMethod _InspectMethod;
        /// <summary>
        /// 设置检测类型
        /// </summary>
        public E_InspectMethod InspectMethod
        {
            set { _InspectMethod = value; }
        }
        
        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="_orderid">工单单号</param>
        /// <param name="_type">条码类型</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string _orderid, Maticsoft.Model.E_SerialNumber_Type _type)
        {
            return dal.Get_SN_List(_orderid, _type);
        }
      
        /// <summary>
        /// 获取最小SN编码
        /// </summary>
        /// <param name="_OrderID">工单单号</param>
        /// <param name="_Type">条码类型</param>
        /// <returns>最小SN</returns>
        public string Get_MinSN(string _OrderID, Model.E_SerialNumber_Type _Type)
        {
            return dal.Get_MinSN(_OrderID, _Type);
        }

        /// <summary>
        /// 获取最小Client编码  8芯配组
        /// </summary>
        /// <param name="_BatchNo">批号</param>
        /// <param name="_Type">条码类型</param>
        /// <param name="FourCore">8芯配组</param>
        /// <returns></returns>
        public string Get_MinSN(string _BatchNo, Model.E_SerialNumber_Type _Type,string FourCore)
        {
            return dal.Get_MinSN(_BatchNo, _Type,FourCore);
        }

        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="_orderid">工单单号</param>
        /// <param name="_type">条码类型</param>
        /// <param name="_Barcode_State">条码状态</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string _orderid, Maticsoft.Model.E_SerialNumber_Type _type, Maticsoft.Model.E_Barcode_State _Barcode_State)
        {
            return dal.Get_SN_List(_orderid, _type, _Barcode_State);
        }

        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="_orderid">工单单号</param>
        /// <param name="_type">条码类型</param>
        /// <param name="_Barcode_State">条码状态</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(Maticsoft.Model.PackBatch _PackBatch, Maticsoft.Model.E_SerialNumber_Type _type, Maticsoft.Model.E_Barcode_State _Barcode_State)
        {
            return dal.Get_SN_List(_PackBatch, _type, _Barcode_State);
        }
         /// <summary>
        /// 返回条码列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string strWhere)
        {
            return dal.Get_SN_List(strWhere);
        }
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="strSql">查询条件</param>
        /// <returns></returns>
        public int Get_PackCount_Batch(string strsql)
        {
            return dal.Get_PackCount_Batch(strsql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_where(string where_sql)
        {
            return dal.Exists_Where(where_sql);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SerialNumber model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 批量增加条码
        /// </summary>
        /// <param name="model">抽象类 serialnumber</param>
        /// <param name="StartSN">开始编码</param>
        /// <param name="OrderCount">工单总量</param>
        /// <returns></returns>
        public string Add(Maticsoft.Model.SerialNumber model, long StartSN, int OrderCount)
        {
            return dal.serialNumber_Value(_InspectMethod, model,  StartSN ,OrderCount);  
        }
           
       
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.SerialNumber model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SN)
		{
			
			return dal.Delete(SN);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sqlWhere )
		{
			return dal.DeleteList(sqlWhere );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.SerialNumber GetModel(string SN)
		{
			
			return dal.GetModel(SN);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.SerialNumber GetModelByCache(string SN)
		{
			
			string CacheKey = "SerialNumberModel-" + SN;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SN);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.SerialNumber)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获取数据并转换为List类型  
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="Type">条码类型 ，无用 只是便于区分重载</param>
        /// <returns></returns>
        public List<string> GetList(string strWhere, Maticsoft.Model.E_SerialNumber_Type Type)
        {
            DataSet ds = dal.GetList(strWhere);
            List<string> temList = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                temList.Add(dr["SN"].ToString());
            }
            return temList;

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
		public List<Maticsoft.Model.SerialNumber> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.SerialNumber> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.SerialNumber> modelList = new List<Maticsoft.Model.SerialNumber>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.SerialNumber model;
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
       
        

        

        public string Sack_SerialNumber(string ordrID, string sackQty)
        {       
                return dal.Sack_SerialNumber(ordrID, sackQty);
        }

      
		#endregion  ExtensionMethod
	}
}

