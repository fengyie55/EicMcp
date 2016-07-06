using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// EquipmentInfo
	/// </summary>
	public partial class EquipmentInfo
	{
		private readonly Maticsoft.DAL.EquipmentInfo dal=new Maticsoft.DAL.EquipmentInfo();
		public EquipmentInfo()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Eqp_ID)
		{
			return dal.Exists(Eqp_ID);
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
		public decimal Add(Maticsoft.Model.EquipmentInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.EquipmentInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal Eqp_ID)
		{
			
			return dal.Delete(Eqp_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Eqp_IDlist )
		{
			return dal.DeleteList(Eqp_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.EquipmentInfo GetModel(decimal Eqp_ID)
		{
			
			return dal.GetModel(Eqp_ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.EquipmentInfo GetModel(string AssetNum)
        {
            return dal.GetModel(AssetNum);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.EquipmentInfo GetModelByCache(decimal Eqp_ID)
		{
			
			string CacheKey = "EquipmentInfoModel-" + Eqp_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Eqp_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.EquipmentInfo)objModel;
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
		public List<Maticsoft.Model.EquipmentInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.EquipmentInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.EquipmentInfo> modelList = new List<Maticsoft.Model.EquipmentInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.EquipmentInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.EquipmentInfo();
					if(dt.Rows[n]["Eqp_ID"]!=null && dt.Rows[n]["Eqp_ID"].ToString()!="")
					{
						model.Eqp_ID=decimal.Parse(dt.Rows[n]["Eqp_ID"].ToString());
					}
					if(dt.Rows[n]["AssetType"]!=null && dt.Rows[n]["AssetType"].ToString()!="")
					{
					model.AssetType=dt.Rows[n]["AssetType"].ToString();
					}
					if(dt.Rows[n]["Department"]!=null && dt.Rows[n]["Department"].ToString()!="")
					{
					model.Department=dt.Rows[n]["Department"].ToString();
					}
					if(dt.Rows[n]["InstallationSite"]!=null && dt.Rows[n]["InstallationSite"].ToString()!="")
					{
					model.InstallationSite=dt.Rows[n]["InstallationSite"].ToString();
					}
					if(dt.Rows[n]["AddMode"]!=null && dt.Rows[n]["AddMode"].ToString()!="")
					{
					model.AddMode=dt.Rows[n]["AddMode"].ToString();
					}
					if(dt.Rows[n]["VerifyDate"]!=null && dt.Rows[n]["VerifyDate"].ToString()!="")
					{
						model.VerifyDate=DateTime.Parse(dt.Rows[n]["VerifyDate"].ToString());
					}
					if(dt.Rows[n]["VerifyInterval"]!=null && dt.Rows[n]["VerifyInterval"].ToString()!="")
					{
					model.VerifyInterval=dt.Rows[n]["VerifyInterval"].ToString();
					}
					if(dt.Rows[n]["MaintenanceDate"]!=null && dt.Rows[n]["MaintenanceDate"].ToString()!="")
					{
						model.MaintenanceDate=DateTime.Parse(dt.Rows[n]["MaintenanceDate"].ToString());
					}
					if(dt.Rows[n]["MaintenanceInterval"]!=null && dt.Rows[n]["MaintenanceInterval"].ToString()!="")
					{
					model.MaintenanceInterval=dt.Rows[n]["MaintenanceInterval"].ToString();
					}
					if(dt.Rows[n]["LoginDate"]!=null && dt.Rows[n]["LoginDate"].ToString()!="")
					{
						model.LoginDate=DateTime.Parse(dt.Rows[n]["LoginDate"].ToString());
					}
					if(dt.Rows[n]["UsefulLife"]!=null && dt.Rows[n]["UsefulLife"].ToString()!="")
					{
					model.UsefulLife=dt.Rows[n]["UsefulLife"].ToString();
					}
					if(dt.Rows[n]["DeliveryUser"]!=null && dt.Rows[n]["DeliveryUser"].ToString()!="")
					{
					model.DeliveryUser=dt.Rows[n]["DeliveryUser"].ToString();
					}
					if(dt.Rows[n]["CheckUser"]!=null && dt.Rows[n]["CheckUser"].ToString()!="")
					{
					model.CheckUser=dt.Rows[n]["CheckUser"].ToString();
					}
					if(dt.Rows[n]["CareUser"]!=null && dt.Rows[n]["CareUser"].ToString()!="")
					{
					model.CareUser=dt.Rows[n]["CareUser"].ToString();
					}
					if(dt.Rows[n]["AssetNum"]!=null && dt.Rows[n]["AssetNum"].ToString()!="")
					{
					model.AssetNum=dt.Rows[n]["AssetNum"].ToString();
					}
					if(dt.Rows[n]["AssetName"]!=null && dt.Rows[n]["AssetName"].ToString()!="")
					{
					model.AssetName=dt.Rows[n]["AssetName"].ToString();
					}
					if(dt.Rows[n]["AliasName"]!=null && dt.Rows[n]["AliasName"].ToString()!="")
					{
					model.AliasName=dt.Rows[n]["AliasName"].ToString();
					}
					if(dt.Rows[n]["MakeNum"]!=null && dt.Rows[n]["MakeNum"].ToString()!="")
					{
					model.MakeNum=dt.Rows[n]["MakeNum"].ToString();
					}
					if(dt.Rows[n]["EquipentModel"]!=null && dt.Rows[n]["EquipentModel"].ToString()!="")
					{
					model.EquipentModel=dt.Rows[n]["EquipentModel"].ToString();
					}
					if(dt.Rows[n]["Specification"]!=null && dt.Rows[n]["Specification"].ToString()!="")
					{
					model.Specification=dt.Rows[n]["Specification"].ToString();
					}
					if(dt.Rows[n]["FunctionDescription"]!=null && dt.Rows[n]["FunctionDescription"].ToString()!="")
					{
					model.FunctionDescription=dt.Rows[n]["FunctionDescription"].ToString();
					}
					if(dt.Rows[n]["Supplier"]!=null && dt.Rows[n]["Supplier"].ToString()!="")
					{
					model.Supplier=dt.Rows[n]["Supplier"].ToString();
					}
					if(dt.Rows[n]["ManufacturingDate"]!=null && dt.Rows[n]["ManufacturingDate"].ToString()!="")
					{
						model.ManufacturingDate=DateTime.Parse(dt.Rows[n]["ManufacturingDate"].ToString());
					}
					if(dt.Rows[n]["OfficialWedsite"]!=null && dt.Rows[n]["OfficialWedsite"].ToString()!="")
					{
					model.OfficialWedsite=dt.Rows[n]["OfficialWedsite"].ToString();
					}
					if(dt.Rows[n]["SupplierTel"]!=null && dt.Rows[n]["SupplierTel"].ToString()!="")
					{
					model.SupplierTel=dt.Rows[n]["SupplierTel"].ToString();
					}
					if(dt.Rows[n]["AferSaleTel"]!=null && dt.Rows[n]["AferSaleTel"].ToString()!="")
					{
					model.AferSaleTel=dt.Rows[n]["AferSaleTel"].ToString();
					}
					if(dt.Rows[n]["State"]!=null && dt.Rows[n]["State"].ToString()!="")
					{
					model.State=dt.Rows[n]["State"].ToString();
					}
					if(dt.Rows[n]["Count"]!=null && dt.Rows[n]["Count"].ToString()!="")
					{
					model.Count=dt.Rows[n]["Count"].ToString();
					}
					if(dt.Rows[n]["Unit"]!=null && dt.Rows[n]["Unit"].ToString()!="")
					{
					model.Unit=dt.Rows[n]["Unit"].ToString();
					}
					if(dt.Rows[n]["Efficiency"]!=null && dt.Rows[n]["Efficiency"].ToString()!="")
					{
					model.Efficiency=dt.Rows[n]["Efficiency"].ToString();
					}
					if(dt.Rows[n]["EquipentOEE"]!=null && dt.Rows[n]["EquipentOEE"].ToString()!="")
					{
					model.EquipentOEE=dt.Rows[n]["EquipentOEE"].ToString();
					}
					if(dt.Rows[n]["PhotoPatch"]!=null && dt.Rows[n]["PhotoPatch"].ToString()!="")
					{
					model.PhotoPatch=dt.Rows[n]["PhotoPatch"].ToString();
					}
					if(dt.Rows[n]["SafetySpecification"]!=null && dt.Rows[n]["SafetySpecification"].ToString()!="")
					{
					model.SafetySpecification=dt.Rows[n]["SafetySpecification"].ToString();
					}
					if(dt.Rows[n]["OI"]!=null && dt.Rows[n]["OI"].ToString()!="")
					{
					model.OI=dt.Rows[n]["OI"].ToString();
					}
					if(dt.Rows[n]["ChechSheet"]!=null && dt.Rows[n]["ChechSheet"].ToString()!="")
					{
					model.ChechSheet=dt.Rows[n]["ChechSheet"].ToString();
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

