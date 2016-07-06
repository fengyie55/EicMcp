using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ConsumableInfo
	/// </summary>
	public partial class ConsumableInfo
	{
		private readonly Maticsoft.DAL.ConsumableInfo dal=new Maticsoft.DAL.ConsumableInfo();
		public ConsumableInfo()
		{}
		#region  Method


         /// <summary>
        /// 获取用于新增加耗材的编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }



		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Csm_ID)
		{
			return dal.Exists(Csm_ID);
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
		public decimal Add(Maticsoft.Model.ConsumableInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ConsumableInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal Csm_ID)
		{
			
			return dal.Delete(Csm_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Csm_IDlist )
		{
			return dal.DeleteList(Csm_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.ConsumableInfo GetModel(decimal Csm_ID)
		{
			
			return dal.GetModel(Csm_ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ConsumableInfo GetModel(string Csm_BarCode)
        {
            return dal.GetModel(Csm_BarCode);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ConsumableInfo GetModelByCache(decimal Csm_ID)
		{
			
			string CacheKey = "ConsumableInfoModel-" + Csm_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Csm_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.ConsumableInfo)objModel;
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
		public List<Maticsoft.Model.ConsumableInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ConsumableInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ConsumableInfo> modelList = new List<Maticsoft.Model.ConsumableInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ConsumableInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ConsumableInfo();
					if(dt.Rows[n]["Csm_ID"]!=null && dt.Rows[n]["Csm_ID"].ToString()!="")
					{
						model.Csm_ID=decimal.Parse(dt.Rows[n]["Csm_ID"].ToString());
					}
					if(dt.Rows[n]["C_Type"]!=null && dt.Rows[n]["C_Type"].ToString()!="")
					{
					model.C_Type=dt.Rows[n]["C_Type"].ToString();
					}
					if(dt.Rows[n]["C_Barcode"]!=null && dt.Rows[n]["C_Barcode"].ToString()!="")
					{
					model.C_Barcode=dt.Rows[n]["C_Barcode"].ToString();
					}
					if(dt.Rows[n]["C_Name"]!=null && dt.Rows[n]["C_Name"].ToString()!="")
					{
					model.C_Name=dt.Rows[n]["C_Name"].ToString();
					}
					if(dt.Rows[n]["C_AliasName"]!=null && dt.Rows[n]["C_AliasName"].ToString()!="")
					{
					model.C_AliasName=dt.Rows[n]["C_AliasName"].ToString();
					}
					if(dt.Rows[n]["C_Model"]!=null && dt.Rows[n]["C_Model"].ToString()!="")
					{
					model.C_Model=dt.Rows[n]["C_Model"].ToString();
					}
					if(dt.Rows[n]["C_Address"]!=null && dt.Rows[n]["C_Address"].ToString()!="")
					{
					model.C_Address=dt.Rows[n]["C_Address"].ToString();
					}
					if(dt.Rows[n]["C_Function"]!=null && dt.Rows[n]["C_Function"].ToString()!="")
					{
					model.C_Function=dt.Rows[n]["C_Function"].ToString();
					}
					if(dt.Rows[n]["C_Lifetime"]!=null && dt.Rows[n]["C_Lifetime"].ToString()!="")
					{
					model.C_Lifetime=dt.Rows[n]["C_Lifetime"].ToString();
					}
					if(dt.Rows[n]["C_LifeUnit"]!=null && dt.Rows[n]["C_LifeUnit"].ToString()!="")
					{
					model.C_LifeUnit=dt.Rows[n]["C_LifeUnit"].ToString();
					}
					if(dt.Rows[n]["C_SafeStock"]!=null && dt.Rows[n]["C_SafeStock"].ToString()!="")
					{
					model.C_SafeStock=dt.Rows[n]["C_SafeStock"].ToString();
					}
					if(dt.Rows[n]["C_Unit"]!=null && dt.Rows[n]["C_Unit"].ToString()!="")
					{
					model.C_Unit=dt.Rows[n]["C_Unit"].ToString();
					}
					if(dt.Rows[n]["C_Picture"]!=null && dt.Rows[n]["C_Picture"].ToString()!="")
					{
					model.C_Picture=dt.Rows[n]["C_Picture"].ToString();
					}
					if(dt.Rows[n]["C_Manufacturer"]!=null && dt.Rows[n]["C_Manufacturer"].ToString()!="")
					{
					model.C_Manufacturer=dt.Rows[n]["C_Manufacturer"].ToString();
					}
					if(dt.Rows[n]["C_Official_Website"]!=null && dt.Rows[n]["C_Official_Website"].ToString()!="")
					{
					model.C_Official_Website=dt.Rows[n]["C_Official_Website"].ToString();
					}
					if(dt.Rows[n]["C_Tel"]!=null && dt.Rows[n]["C_Tel"].ToString()!="")
					{
					model.C_Tel=dt.Rows[n]["C_Tel"].ToString();
					}
					if(dt.Rows[n]["C_After_Sale"]!=null && dt.Rows[n]["C_After_Sale"].ToString()!="")
					{
					model.C_After_Sale=dt.Rows[n]["C_After_Sale"].ToString();
					}
					if(dt.Rows[n]["C_PurchasCycle"]!=null && dt.Rows[n]["C_PurchasCycle"].ToString()!="")
					{
					model.C_PurchasCycle=dt.Rows[n]["C_PurchasCycle"].ToString();
					}
					if(dt.Rows[n]["C_Remarks"]!=null && dt.Rows[n]["C_Remarks"].ToString()!="")
					{
					model.C_Remarks=dt.Rows[n]["C_Remarks"].ToString();
					}

                    //通过计算得出当前库存
                   Maticsoft.DAL.ConsumableReceive _M_Re = new Maticsoft.DAL.ConsumableReceive();
                   Maticsoft.DAL.ConsumableStorage _M_St = new Maticsoft.DAL.ConsumableStorage();
                    double _storageCount = _M_St.Get_Stock(model.C_Barcode);
                    double _receiveCount = _M_Re.Get_Stock(model.C_Barcode);
                    model.Stock = (_storageCount - _receiveCount).ToString();

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

