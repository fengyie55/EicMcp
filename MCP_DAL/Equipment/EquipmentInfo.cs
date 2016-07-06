using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:EquipmentInfo
	/// </summary>
	public partial class EquipmentInfo
	{
		public EquipmentInfo()
		{}
		#region  Method
        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.EquipmentMS);
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Eqp_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_EquipmentInfo");
			strSql.Append(" where Eqp_ID=@Eqp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Eqp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Eqp_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获取字段不重复记录
        /// </summary>
        /// <param name="_Value">字段名</param>
        /// <returns></returns>
        public DataSet Get_Distinct_List(string _Value)
        {
            DataSet ds = new DataSet();
            try
            {
                if (_Value.Trim() != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" SELECT DISTINCT ");
                    strSql.Append(_Value);
                    strSql.Append(" FROM tb_EquipmentInfo ");
                    ds = dbs.Query(strSql.ToString());
                }
            }
            catch { ds = null; };
            return ds;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.EquipmentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_EquipmentInfo(");
			strSql.Append("AssetType,Department,InstallationSite,AddMode,VerifyDate,VerifyInterval,MaintenanceDate,MaintenanceInterval,LoginDate,UsefulLife,DeliveryUser,CheckUser,CareUser,AssetNum,AssetName,AliasName,MakeNum,EquipentModel,Specification,FunctionDescription,Supplier,ManufacturingDate,OfficialWedsite,SupplierTel,AferSaleTel,State,Count,Unit,Efficiency,EquipentOEE,PhotoPatch,SafetySpecification,OI,ChechSheet)");
			strSql.Append(" values (");
			strSql.Append("@AssetType,@Department,@InstallationSite,@AddMode,@VerifyDate,@VerifyInterval,@MaintenanceDate,@MaintenanceInterval,@LoginDate,@UsefulLife,@DeliveryUser,@CheckUser,@CareUser,@AssetNum,@AssetName,@AliasName,@MakeNum,@EquipentModel,@Specification,@FunctionDescription,@Supplier,@ManufacturingDate,@OfficialWedsite,@SupplierTel,@AferSaleTel,@State,@Count,@Unit,@Efficiency,@EquipentOEE,@PhotoPatch,@SafetySpecification,@OI,@ChechSheet)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AssetType", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@InstallationSite", SqlDbType.VarChar,50),
					new SqlParameter("@AddMode", SqlDbType.VarChar,50),
					new SqlParameter("@VerifyDate", SqlDbType.DateTime),
					new SqlParameter("@VerifyInterval", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenanceDate", SqlDbType.DateTime),
					new SqlParameter("@MaintenanceInterval", SqlDbType.VarChar,50),
					new SqlParameter("@LoginDate", SqlDbType.DateTime),
					new SqlParameter("@UsefulLife", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryUser", SqlDbType.VarChar,50),
					new SqlParameter("@CheckUser", SqlDbType.VarChar,50),
					new SqlParameter("@CareUser", SqlDbType.VarChar,50),
					new SqlParameter("@AssetNum", SqlDbType.VarChar,50),
					new SqlParameter("@AssetName", SqlDbType.VarChar,50),
					new SqlParameter("@AliasName", SqlDbType.VarChar,50),
					new SqlParameter("@MakeNum", SqlDbType.VarChar,50),
					new SqlParameter("@EquipentModel", SqlDbType.VarChar,255),
					new SqlParameter("@Specification", SqlDbType.VarChar,255),
					new SqlParameter("@FunctionDescription", SqlDbType.VarChar,255),
					new SqlParameter("@Supplier", SqlDbType.VarChar,50),
					new SqlParameter("@ManufacturingDate", SqlDbType.DateTime),
					new SqlParameter("@OfficialWedsite", SqlDbType.VarChar,100),
					new SqlParameter("@SupplierTel", SqlDbType.VarChar,100),
					new SqlParameter("@AferSaleTel", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@Efficiency", SqlDbType.VarChar,50),
					new SqlParameter("@EquipentOEE", SqlDbType.VarChar,50),
					new SqlParameter("@PhotoPatch", SqlDbType.VarChar,100),
					new SqlParameter("@SafetySpecification", SqlDbType.VarChar,100),
					new SqlParameter("@OI", SqlDbType.VarChar,100),
					new SqlParameter("@ChechSheet", SqlDbType.VarChar,100)};
			parameters[0].Value = model.AssetType;
			parameters[1].Value = model.Department;
			parameters[2].Value = model.InstallationSite;
			parameters[3].Value = model.AddMode;
			parameters[4].Value = model.VerifyDate;
			parameters[5].Value = model.VerifyInterval;
			parameters[6].Value = model.MaintenanceDate;
			parameters[7].Value = model.MaintenanceInterval;
			parameters[8].Value = model.LoginDate;
			parameters[9].Value = model.UsefulLife;
			parameters[10].Value = model.DeliveryUser;
			parameters[11].Value = model.CheckUser;
			parameters[12].Value = model.CareUser;
			parameters[13].Value = model.AssetNum;
			parameters[14].Value = model.AssetName;
			parameters[15].Value = model.AliasName;
			parameters[16].Value = model.MakeNum;
			parameters[17].Value = model.EquipentModel;
			parameters[18].Value = model.Specification;
			parameters[19].Value = model.FunctionDescription;
			parameters[20].Value = model.Supplier;
			parameters[21].Value = model.ManufacturingDate;
			parameters[22].Value = model.OfficialWedsite;
			parameters[23].Value = model.SupplierTel;
			parameters[24].Value = model.AferSaleTel;
			parameters[25].Value = model.State;
			parameters[26].Value = model.Count;
			parameters[27].Value = model.Unit;
			parameters[28].Value = model.Efficiency;
			parameters[29].Value = model.EquipentOEE;
			parameters[30].Value = model.PhotoPatch;
			parameters[31].Value = model.SafetySpecification;
			parameters[32].Value = model.OI;
			parameters[33].Value = model.ChechSheet;

			object obj = dbs.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.EquipmentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_EquipmentInfo set ");
			strSql.Append("AssetType=@AssetType,");
			strSql.Append("Department=@Department,");
			strSql.Append("InstallationSite=@InstallationSite,");
			strSql.Append("AddMode=@AddMode,");
			strSql.Append("VerifyDate=@VerifyDate,");
			strSql.Append("VerifyInterval=@VerifyInterval,");
			strSql.Append("MaintenanceDate=@MaintenanceDate,");
			strSql.Append("MaintenanceInterval=@MaintenanceInterval,");
			strSql.Append("LoginDate=@LoginDate,");
			strSql.Append("UsefulLife=@UsefulLife,");
			strSql.Append("DeliveryUser=@DeliveryUser,");
			strSql.Append("CheckUser=@CheckUser,");
			strSql.Append("CareUser=@CareUser,");
			strSql.Append("AssetNum=@AssetNum,");
			strSql.Append("AssetName=@AssetName,");
			strSql.Append("AliasName=@AliasName,");
			strSql.Append("MakeNum=@MakeNum,");
			strSql.Append("EquipentModel=@EquipentModel,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("FunctionDescription=@FunctionDescription,");
			strSql.Append("Supplier=@Supplier,");
			strSql.Append("ManufacturingDate=@ManufacturingDate,");
			strSql.Append("OfficialWedsite=@OfficialWedsite,");
			strSql.Append("SupplierTel=@SupplierTel,");
			strSql.Append("AferSaleTel=@AferSaleTel,");
			strSql.Append("State=@State,");
			strSql.Append("Count=@Count,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Efficiency=@Efficiency,");
			strSql.Append("EquipentOEE=@EquipentOEE,");
			strSql.Append("PhotoPatch=@PhotoPatch,");
			strSql.Append("SafetySpecification=@SafetySpecification,");
			strSql.Append("OI=@OI,");
			strSql.Append("ChechSheet=@ChechSheet");
			strSql.Append(" where Eqp_ID=@Eqp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@AssetType", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@InstallationSite", SqlDbType.VarChar,50),
					new SqlParameter("@AddMode", SqlDbType.VarChar,50),
					new SqlParameter("@VerifyDate", SqlDbType.DateTime),
					new SqlParameter("@VerifyInterval", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenanceDate", SqlDbType.DateTime),
					new SqlParameter("@MaintenanceInterval", SqlDbType.VarChar,50),
					new SqlParameter("@LoginDate", SqlDbType.DateTime),
					new SqlParameter("@UsefulLife", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryUser", SqlDbType.VarChar,50),
					new SqlParameter("@CheckUser", SqlDbType.VarChar,50),
					new SqlParameter("@CareUser", SqlDbType.VarChar,50),
					new SqlParameter("@AssetNum", SqlDbType.VarChar,50),
					new SqlParameter("@AssetName", SqlDbType.VarChar,50),
					new SqlParameter("@AliasName", SqlDbType.VarChar,50),
					new SqlParameter("@MakeNum", SqlDbType.VarChar,50),
					new SqlParameter("@EquipentModel", SqlDbType.VarChar,255),
					new SqlParameter("@Specification", SqlDbType.VarChar,255),
					new SqlParameter("@FunctionDescription", SqlDbType.VarChar,255),
					new SqlParameter("@Supplier", SqlDbType.VarChar,50),
					new SqlParameter("@ManufacturingDate", SqlDbType.DateTime),
					new SqlParameter("@OfficialWedsite", SqlDbType.VarChar,100),
					new SqlParameter("@SupplierTel", SqlDbType.VarChar,100),
					new SqlParameter("@AferSaleTel", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@Efficiency", SqlDbType.VarChar,50),
					new SqlParameter("@EquipentOEE", SqlDbType.VarChar,50),
					new SqlParameter("@PhotoPatch", SqlDbType.VarChar,100),
					new SqlParameter("@SafetySpecification", SqlDbType.VarChar,100),
					new SqlParameter("@OI", SqlDbType.VarChar,100),
					new SqlParameter("@ChechSheet", SqlDbType.VarChar,100),
					new SqlParameter("@Eqp_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.AssetType;
			parameters[1].Value = model.Department;
			parameters[2].Value = model.InstallationSite;
			parameters[3].Value = model.AddMode;
			parameters[4].Value = model.VerifyDate;
			parameters[5].Value = model.VerifyInterval;
			parameters[6].Value = model.MaintenanceDate;
			parameters[7].Value = model.MaintenanceInterval;
			parameters[8].Value = model.LoginDate;
			parameters[9].Value = model.UsefulLife;
			parameters[10].Value = model.DeliveryUser;
			parameters[11].Value = model.CheckUser;
			parameters[12].Value = model.CareUser;
			parameters[13].Value = model.AssetNum;
			parameters[14].Value = model.AssetName;
			parameters[15].Value = model.AliasName;
			parameters[16].Value = model.MakeNum;
			parameters[17].Value = model.EquipentModel;
			parameters[18].Value = model.Specification;
			parameters[19].Value = model.FunctionDescription;
			parameters[20].Value = model.Supplier;
			parameters[21].Value = model.ManufacturingDate;
			parameters[22].Value = model.OfficialWedsite;
			parameters[23].Value = model.SupplierTel;
			parameters[24].Value = model.AferSaleTel;
			parameters[25].Value = model.State;
			parameters[26].Value = model.Count;
			parameters[27].Value = model.Unit;
			parameters[28].Value = model.Efficiency;
			parameters[29].Value = model.EquipentOEE;
			parameters[30].Value = model.PhotoPatch;
			parameters[31].Value = model.SafetySpecification;
			parameters[32].Value = model.OI;
			parameters[33].Value = model.ChechSheet;
			parameters[34].Value = model.Eqp_ID;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal Eqp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_EquipmentInfo ");
			strSql.Append(" where Eqp_ID=@Eqp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Eqp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Eqp_ID;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Eqp_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_EquipmentInfo ");
			strSql.Append(" where Eqp_ID in ("+Eqp_IDlist + ")  ");
			int rows=dbs.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.EquipmentInfo GetModel(string AssetNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Eqp_ID,AssetType,Department,InstallationSite,AddMode,VerifyDate,VerifyInterval,MaintenanceDate,MaintenanceInterval,LoginDate,UsefulLife,DeliveryUser,CheckUser,CareUser,AssetNum,AssetName,AliasName,MakeNum,EquipentModel,Specification,FunctionDescription,Supplier,ManufacturingDate,OfficialWedsite,SupplierTel,AferSaleTel,State,Count,Unit,Efficiency,EquipentOEE,PhotoPatch,SafetySpecification,OI,ChechSheet from tb_EquipmentInfo ");
            strSql.Append(" where AssetNum = '"+AssetNum+"'");
            

            Maticsoft.Model.EquipmentInfo model = new Maticsoft.Model.EquipmentInfo();
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Eqp_ID"] != null && ds.Tables[0].Rows[0]["Eqp_ID"].ToString() != "")
                {
                    model.Eqp_ID = decimal.Parse(ds.Tables[0].Rows[0]["Eqp_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssetType"] != null && ds.Tables[0].Rows[0]["AssetType"].ToString() != "")
                {
                    model.AssetType = ds.Tables[0].Rows[0]["AssetType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null && ds.Tables[0].Rows[0]["Department"].ToString() != "")
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InstallationSite"] != null && ds.Tables[0].Rows[0]["InstallationSite"].ToString() != "")
                {
                    model.InstallationSite = ds.Tables[0].Rows[0]["InstallationSite"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddMode"] != null && ds.Tables[0].Rows[0]["AddMode"].ToString() != "")
                {
                    model.AddMode = ds.Tables[0].Rows[0]["AddMode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VerifyDate"] != null && ds.Tables[0].Rows[0]["VerifyDate"].ToString() != "")
                {
                    model.VerifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["VerifyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VerifyInterval"] != null && ds.Tables[0].Rows[0]["VerifyInterval"].ToString() != "")
                {
                    model.VerifyInterval = ds.Tables[0].Rows[0]["VerifyInterval"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MaintenanceDate"] != null && ds.Tables[0].Rows[0]["MaintenanceDate"].ToString() != "")
                {
                    model.MaintenanceDate = DateTime.Parse(ds.Tables[0].Rows[0]["MaintenanceDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaintenanceInterval"] != null && ds.Tables[0].Rows[0]["MaintenanceInterval"].ToString() != "")
                {
                    model.MaintenanceInterval = ds.Tables[0].Rows[0]["MaintenanceInterval"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginDate"] != null && ds.Tables[0].Rows[0]["LoginDate"].ToString() != "")
                {
                    model.LoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["LoginDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UsefulLife"] != null && ds.Tables[0].Rows[0]["UsefulLife"].ToString() != "")
                {
                    model.UsefulLife = ds.Tables[0].Rows[0]["UsefulLife"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DeliveryUser"] != null && ds.Tables[0].Rows[0]["DeliveryUser"].ToString() != "")
                {
                    model.DeliveryUser = ds.Tables[0].Rows[0]["DeliveryUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CheckUser"] != null && ds.Tables[0].Rows[0]["CheckUser"].ToString() != "")
                {
                    model.CheckUser = ds.Tables[0].Rows[0]["CheckUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CareUser"] != null && ds.Tables[0].Rows[0]["CareUser"].ToString() != "")
                {
                    model.CareUser = ds.Tables[0].Rows[0]["CareUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AssetNum"] != null && ds.Tables[0].Rows[0]["AssetNum"].ToString() != "")
                {
                    model.AssetNum = ds.Tables[0].Rows[0]["AssetNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AssetName"] != null && ds.Tables[0].Rows[0]["AssetName"].ToString() != "")
                {
                    model.AssetName = ds.Tables[0].Rows[0]["AssetName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AliasName"] != null && ds.Tables[0].Rows[0]["AliasName"].ToString() != "")
                {
                    model.AliasName = ds.Tables[0].Rows[0]["AliasName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MakeNum"] != null && ds.Tables[0].Rows[0]["MakeNum"].ToString() != "")
                {
                    model.MakeNum = ds.Tables[0].Rows[0]["MakeNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EquipentModel"] != null && ds.Tables[0].Rows[0]["EquipentModel"].ToString() != "")
                {
                    model.EquipentModel = ds.Tables[0].Rows[0]["EquipentModel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Specification"] != null && ds.Tables[0].Rows[0]["Specification"].ToString() != "")
                {
                    model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FunctionDescription"] != null && ds.Tables[0].Rows[0]["FunctionDescription"].ToString() != "")
                {
                    model.FunctionDescription = ds.Tables[0].Rows[0]["FunctionDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Supplier"] != null && ds.Tables[0].Rows[0]["Supplier"].ToString() != "")
                {
                    model.Supplier = ds.Tables[0].Rows[0]["Supplier"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManufacturingDate"] != null && ds.Tables[0].Rows[0]["ManufacturingDate"].ToString() != "")
                {
                    model.ManufacturingDate = DateTime.Parse(ds.Tables[0].Rows[0]["ManufacturingDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OfficialWedsite"] != null && ds.Tables[0].Rows[0]["OfficialWedsite"].ToString() != "")
                {
                    model.OfficialWedsite = ds.Tables[0].Rows[0]["OfficialWedsite"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SupplierTel"] != null && ds.Tables[0].Rows[0]["SupplierTel"].ToString() != "")
                {
                    model.SupplierTel = ds.Tables[0].Rows[0]["SupplierTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AferSaleTel"] != null && ds.Tables[0].Rows[0]["AferSaleTel"].ToString() != "")
                {
                    model.AferSaleTel = ds.Tables[0].Rows[0]["AferSaleTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Count"] != null && ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = ds.Tables[0].Rows[0]["Count"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Unit"] != null && ds.Tables[0].Rows[0]["Unit"].ToString() != "")
                {
                    model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Efficiency"] != null && ds.Tables[0].Rows[0]["Efficiency"].ToString() != "")
                {
                    model.Efficiency = ds.Tables[0].Rows[0]["Efficiency"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EquipentOEE"] != null && ds.Tables[0].Rows[0]["EquipentOEE"].ToString() != "")
                {
                    model.EquipentOEE = ds.Tables[0].Rows[0]["EquipentOEE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhotoPatch"] != null && ds.Tables[0].Rows[0]["PhotoPatch"].ToString() != "")
                {
                    model.PhotoPatch = ds.Tables[0].Rows[0]["PhotoPatch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafetySpecification"] != null && ds.Tables[0].Rows[0]["SafetySpecification"].ToString() != "")
                {
                    model.SafetySpecification = ds.Tables[0].Rows[0]["SafetySpecification"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OI"] != null && ds.Tables[0].Rows[0]["OI"].ToString() != "")
                {
                    model.OI = ds.Tables[0].Rows[0]["OI"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ChechSheet"] != null && ds.Tables[0].Rows[0]["ChechSheet"].ToString() != "")
                {
                    model.ChechSheet = ds.Tables[0].Rows[0]["ChechSheet"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.EquipmentInfo GetModel(decimal Eqp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Eqp_ID,AssetType,Department,InstallationSite,AddMode,VerifyDate,VerifyInterval,MaintenanceDate,MaintenanceInterval,LoginDate,UsefulLife,DeliveryUser,CheckUser,CareUser,AssetNum,AssetName,AliasName,MakeNum,EquipentModel,Specification,FunctionDescription,Supplier,ManufacturingDate,OfficialWedsite,SupplierTel,AferSaleTel,State,Count,Unit,Efficiency,EquipentOEE,PhotoPatch,SafetySpecification,OI,ChechSheet from tb_EquipmentInfo ");
			strSql.Append(" where Eqp_ID=@Eqp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Eqp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Eqp_ID;

			Maticsoft.Model.EquipmentInfo model=new Maticsoft.Model.EquipmentInfo();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Eqp_ID"]!=null && ds.Tables[0].Rows[0]["Eqp_ID"].ToString()!="")
				{
					model.Eqp_ID=decimal.Parse(ds.Tables[0].Rows[0]["Eqp_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AssetType"]!=null && ds.Tables[0].Rows[0]["AssetType"].ToString()!="")
				{
					model.AssetType=ds.Tables[0].Rows[0]["AssetType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Department"]!=null && ds.Tables[0].Rows[0]["Department"].ToString()!="")
				{
					model.Department=ds.Tables[0].Rows[0]["Department"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InstallationSite"]!=null && ds.Tables[0].Rows[0]["InstallationSite"].ToString()!="")
				{
					model.InstallationSite=ds.Tables[0].Rows[0]["InstallationSite"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddMode"]!=null && ds.Tables[0].Rows[0]["AddMode"].ToString()!="")
				{
					model.AddMode=ds.Tables[0].Rows[0]["AddMode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VerifyDate"]!=null && ds.Tables[0].Rows[0]["VerifyDate"].ToString()!="")
				{
					model.VerifyDate=DateTime.Parse(ds.Tables[0].Rows[0]["VerifyDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VerifyInterval"]!=null && ds.Tables[0].Rows[0]["VerifyInterval"].ToString()!="")
				{
					model.VerifyInterval=ds.Tables[0].Rows[0]["VerifyInterval"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MaintenanceDate"]!=null && ds.Tables[0].Rows[0]["MaintenanceDate"].ToString()!="")
				{
					model.MaintenanceDate=DateTime.Parse(ds.Tables[0].Rows[0]["MaintenanceDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaintenanceInterval"]!=null && ds.Tables[0].Rows[0]["MaintenanceInterval"].ToString()!="")
				{
					model.MaintenanceInterval=ds.Tables[0].Rows[0]["MaintenanceInterval"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoginDate"]!=null && ds.Tables[0].Rows[0]["LoginDate"].ToString()!="")
				{
					model.LoginDate=DateTime.Parse(ds.Tables[0].Rows[0]["LoginDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UsefulLife"]!=null && ds.Tables[0].Rows[0]["UsefulLife"].ToString()!="")
				{
					model.UsefulLife=ds.Tables[0].Rows[0]["UsefulLife"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DeliveryUser"]!=null && ds.Tables[0].Rows[0]["DeliveryUser"].ToString()!="")
				{
					model.DeliveryUser=ds.Tables[0].Rows[0]["DeliveryUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CheckUser"]!=null && ds.Tables[0].Rows[0]["CheckUser"].ToString()!="")
				{
					model.CheckUser=ds.Tables[0].Rows[0]["CheckUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CareUser"]!=null && ds.Tables[0].Rows[0]["CareUser"].ToString()!="")
				{
					model.CareUser=ds.Tables[0].Rows[0]["CareUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AssetNum"]!=null && ds.Tables[0].Rows[0]["AssetNum"].ToString()!="")
				{
					model.AssetNum=ds.Tables[0].Rows[0]["AssetNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AssetName"]!=null && ds.Tables[0].Rows[0]["AssetName"].ToString()!="")
				{
					model.AssetName=ds.Tables[0].Rows[0]["AssetName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AliasName"]!=null && ds.Tables[0].Rows[0]["AliasName"].ToString()!="")
				{
					model.AliasName=ds.Tables[0].Rows[0]["AliasName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MakeNum"]!=null && ds.Tables[0].Rows[0]["MakeNum"].ToString()!="")
				{
					model.MakeNum=ds.Tables[0].Rows[0]["MakeNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EquipentModel"]!=null && ds.Tables[0].Rows[0]["EquipentModel"].ToString()!="")
				{
					model.EquipentModel=ds.Tables[0].Rows[0]["EquipentModel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Specification"]!=null && ds.Tables[0].Rows[0]["Specification"].ToString()!="")
				{
					model.Specification=ds.Tables[0].Rows[0]["Specification"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FunctionDescription"]!=null && ds.Tables[0].Rows[0]["FunctionDescription"].ToString()!="")
				{
					model.FunctionDescription=ds.Tables[0].Rows[0]["FunctionDescription"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Supplier"]!=null && ds.Tables[0].Rows[0]["Supplier"].ToString()!="")
				{
					model.Supplier=ds.Tables[0].Rows[0]["Supplier"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ManufacturingDate"]!=null && ds.Tables[0].Rows[0]["ManufacturingDate"].ToString()!="")
				{
					model.ManufacturingDate=DateTime.Parse(ds.Tables[0].Rows[0]["ManufacturingDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OfficialWedsite"]!=null && ds.Tables[0].Rows[0]["OfficialWedsite"].ToString()!="")
				{
					model.OfficialWedsite=ds.Tables[0].Rows[0]["OfficialWedsite"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SupplierTel"]!=null && ds.Tables[0].Rows[0]["SupplierTel"].ToString()!="")
				{
					model.SupplierTel=ds.Tables[0].Rows[0]["SupplierTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AferSaleTel"]!=null && ds.Tables[0].Rows[0]["AferSaleTel"].ToString()!="")
				{
					model.AferSaleTel=ds.Tables[0].Rows[0]["AferSaleTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["State"]!=null && ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=ds.Tables[0].Rows[0]["State"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Count"]!=null && ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=ds.Tables[0].Rows[0]["Count"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Unit"]!=null && ds.Tables[0].Rows[0]["Unit"].ToString()!="")
				{
					model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Efficiency"]!=null && ds.Tables[0].Rows[0]["Efficiency"].ToString()!="")
				{
					model.Efficiency=ds.Tables[0].Rows[0]["Efficiency"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EquipentOEE"]!=null && ds.Tables[0].Rows[0]["EquipentOEE"].ToString()!="")
				{
					model.EquipentOEE=ds.Tables[0].Rows[0]["EquipentOEE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PhotoPatch"]!=null && ds.Tables[0].Rows[0]["PhotoPatch"].ToString()!="")
				{
					model.PhotoPatch=ds.Tables[0].Rows[0]["PhotoPatch"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SafetySpecification"]!=null && ds.Tables[0].Rows[0]["SafetySpecification"].ToString()!="")
				{
					model.SafetySpecification=ds.Tables[0].Rows[0]["SafetySpecification"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OI"]!=null && ds.Tables[0].Rows[0]["OI"].ToString()!="")
				{
					model.OI=ds.Tables[0].Rows[0]["OI"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ChechSheet"]!=null && ds.Tables[0].Rows[0]["ChechSheet"].ToString()!="")
				{
					model.ChechSheet=ds.Tables[0].Rows[0]["ChechSheet"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  AssetType, Department, InstallationSite, State, AssetNum, AssetName, AliasName,MakeNum, EquipentModel, Specification, FunctionDescription, AddMode, VerifyDate,VerifyInterval, MaintenanceDate, MaintenanceInterval, LoginDate, UsefulLife,DeliveryUser, CheckUser, CareUser, Supplier, ManufacturingDate, OfficialWedsite,SupplierTel, AferSaleTel, Count, Unit, Efficiency, EquipentOEE, PhotoPatch,SafetySpecification, OI, ChechSheet, Eqp_ID");
			strSql.Append(" FROM tb_EquipmentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Eqp_ID,AssetType,Department,InstallationSite,AddMode,VerifyDate,VerifyInterval,MaintenanceDate,MaintenanceInterval,LoginDate,UsefulLife,DeliveryUser,CheckUser,CareUser,AssetNum,AssetName,AliasName,MakeNum,EquipentModel,Specification,FunctionDescription,Supplier,ManufacturingDate,OfficialWedsite,SupplierTel,AferSaleTel,State,Count,Unit,Efficiency,EquipentOEE,PhotoPatch,SafetySpecification,OI,ChechSheet ");
			strSql.Append(" FROM tb_EquipmentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_EquipmentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = dbs.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Eqp_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_EquipmentInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return dbs.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_EquipmentInfo";
			parameters[1].Value = "Eqp_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

