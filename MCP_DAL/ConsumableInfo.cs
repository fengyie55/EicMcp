using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ConsumableInfo
	/// </summary>
	public partial class ConsumableInfo
	{
		public ConsumableInfo()
		{}
		#region  Method
        DbHelperSQL dbs = new DbHelperSQL();

        


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Csm_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_ConsumableInfo");
			strSql.Append(" where Csm_ID=@Csm_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Csm_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Csm_ID;

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
                    strSql.Append(" FROM tb_ConsumableInfo ");
                    ds = dbs.Query(strSql.ToString());
                }
            }
            catch { ds = null; };
            return ds;
        }

        /// <summary>
        /// 获取用于新增加耗材的编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            DataSet ds = new DataSet();
            string _sql = "SELECT TOP (1) SUBSTRING(C_Barcode, 4, 9) + 1 AS MaxNum FROM tb_ConsumableInfo ORDER BY Csm_ID DESC";
            ds = dbs.Query(_sql);
            return "ECH" + ds.Tables[0].Rows[0]["MaxNum"].ToString();
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ConsumableInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ConsumableInfo(");
			strSql.Append("C_Type,C_Barcode,C_Name,C_AliasName,C_Model,C_Address,C_Function,C_Lifetime,C_LifeUnit,C_SafeStock,C_Unit,C_Picture,C_Manufacturer,C_Official_Website,C_Tel,C_After_Sale,C_PurchasCycle,C_Remarks)");
			strSql.Append(" values (");
			strSql.Append("@C_Type,@C_Barcode,@C_Name,@C_AliasName,@C_Model,@C_Address,@C_Function,@C_Lifetime,@C_LifeUnit,@C_SafeStock,@C_Unit,@C_Picture,@C_Manufacturer,@C_Official_Website,@C_Tel,@C_After_Sale,@C_PurchasCycle,@C_Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Type", SqlDbType.VarChar,50),
					new SqlParameter("@C_Barcode", SqlDbType.VarChar,50),
					new SqlParameter("@C_Name", SqlDbType.VarChar,50),
					new SqlParameter("@C_AliasName", SqlDbType.VarChar,50),
					new SqlParameter("@C_Model", SqlDbType.VarChar,50),
					new SqlParameter("@C_Address", SqlDbType.VarChar,50),
					new SqlParameter("@C_Function", SqlDbType.VarChar,50),
					new SqlParameter("@C_Lifetime", SqlDbType.VarChar,50),
					new SqlParameter("@C_LifeUnit", SqlDbType.VarChar,50),
					new SqlParameter("@C_SafeStock", SqlDbType.VarChar,50),
					new SqlParameter("@C_Unit", SqlDbType.VarChar,50),
					new SqlParameter("@C_Picture", SqlDbType.VarChar,50),
					new SqlParameter("@C_Manufacturer", SqlDbType.VarChar,50),
					new SqlParameter("@C_Official_Website", SqlDbType.VarChar,50),
					new SqlParameter("@C_Tel", SqlDbType.VarChar,50),
					new SqlParameter("@C_After_Sale", SqlDbType.VarChar,50),
					new SqlParameter("@C_PurchasCycle", SqlDbType.VarChar,50),
					new SqlParameter("@C_Remarks", SqlDbType.Text)};
			parameters[0].Value = model.C_Type;
			parameters[1].Value = model.C_Barcode;
			parameters[2].Value = model.C_Name;
			parameters[3].Value = model.C_AliasName;
			parameters[4].Value = model.C_Model;
			parameters[5].Value = model.C_Address;
			parameters[6].Value = model.C_Function;
			parameters[7].Value = model.C_Lifetime;
			parameters[8].Value = model.C_LifeUnit;
			parameters[9].Value = model.C_SafeStock;
			parameters[10].Value = model.C_Unit;
			parameters[11].Value = model.C_Picture;
			parameters[12].Value = model.C_Manufacturer;
			parameters[13].Value = model.C_Official_Website;
			parameters[14].Value = model.C_Tel;
			parameters[15].Value = model.C_After_Sale;
			parameters[16].Value = model.C_PurchasCycle;
			parameters[17].Value = model.C_Remarks;

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
		public bool Update(Maticsoft.Model.ConsumableInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ConsumableInfo set ");
			strSql.Append("C_Type=@C_Type,");
			strSql.Append("C_Barcode=@C_Barcode,");
			strSql.Append("C_Name=@C_Name,");
			strSql.Append("C_AliasName=@C_AliasName,");
			strSql.Append("C_Model=@C_Model,");
			strSql.Append("C_Address=@C_Address,");
			strSql.Append("C_Function=@C_Function,");
			strSql.Append("C_Lifetime=@C_Lifetime,");
			strSql.Append("C_LifeUnit=@C_LifeUnit,");
			strSql.Append("C_SafeStock=@C_SafeStock,");
			strSql.Append("C_Unit=@C_Unit,");
			strSql.Append("C_Picture=@C_Picture,");
			strSql.Append("C_Manufacturer=@C_Manufacturer,");
			strSql.Append("C_Official_Website=@C_Official_Website,");
			strSql.Append("C_Tel=@C_Tel,");
			strSql.Append("C_After_Sale=@C_After_Sale,");
			strSql.Append("C_PurchasCycle=@C_PurchasCycle,");
			strSql.Append("C_Remarks=@C_Remarks");
			strSql.Append(" where Csm_ID=@Csm_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Type", SqlDbType.VarChar,50),
					new SqlParameter("@C_Barcode", SqlDbType.VarChar,50),
					new SqlParameter("@C_Name", SqlDbType.VarChar,50),
					new SqlParameter("@C_AliasName", SqlDbType.VarChar,50),
					new SqlParameter("@C_Model", SqlDbType.VarChar,50),
					new SqlParameter("@C_Address", SqlDbType.VarChar,50),
					new SqlParameter("@C_Function", SqlDbType.VarChar,50),
					new SqlParameter("@C_Lifetime", SqlDbType.VarChar,50),
					new SqlParameter("@C_LifeUnit", SqlDbType.VarChar,50),
					new SqlParameter("@C_SafeStock", SqlDbType.VarChar,50),
					new SqlParameter("@C_Unit", SqlDbType.VarChar,50),
					new SqlParameter("@C_Picture", SqlDbType.VarChar,50),
					new SqlParameter("@C_Manufacturer", SqlDbType.VarChar,50),
					new SqlParameter("@C_Official_Website", SqlDbType.VarChar,50),
					new SqlParameter("@C_Tel", SqlDbType.VarChar,50),
					new SqlParameter("@C_After_Sale", SqlDbType.VarChar,50),
					new SqlParameter("@C_PurchasCycle", SqlDbType.VarChar,50),
					new SqlParameter("@C_Remarks", SqlDbType.Text),
					new SqlParameter("@Csm_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.C_Type;
			parameters[1].Value = model.C_Barcode;
			parameters[2].Value = model.C_Name;
			parameters[3].Value = model.C_AliasName;
			parameters[4].Value = model.C_Model;
			parameters[5].Value = model.C_Address;
			parameters[6].Value = model.C_Function;
			parameters[7].Value = model.C_Lifetime;
			parameters[8].Value = model.C_LifeUnit;
			parameters[9].Value = model.C_SafeStock;
			parameters[10].Value = model.C_Unit;
			parameters[11].Value = model.C_Picture;
			parameters[12].Value = model.C_Manufacturer;
			parameters[13].Value = model.C_Official_Website;
			parameters[14].Value = model.C_Tel;
			parameters[15].Value = model.C_After_Sale;
			parameters[16].Value = model.C_PurchasCycle;
			parameters[17].Value = model.C_Remarks;
			parameters[18].Value = model.Csm_ID;

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
		public bool Delete(decimal Csm_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ConsumableInfo ");
			strSql.Append(" where Csm_ID=@Csm_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Csm_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Csm_ID;

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
		public bool DeleteList(string Csm_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ConsumableInfo ");
			strSql.Append(" where Csm_ID in ("+Csm_IDlist + ")  ");
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
		public Maticsoft.Model.ConsumableInfo GetModel(decimal Csm_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Csm_ID,C_Type,C_Barcode,C_Name,C_AliasName,C_Model,C_Address,C_Function,C_Lifetime,C_LifeUnit,C_SafeStock,C_Unit,C_Picture,C_Manufacturer,C_Official_Website,C_Tel,C_After_Sale,C_PurchasCycle,C_Remarks from tb_ConsumableInfo ");
			strSql.Append(" where Csm_ID=@Csm_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Csm_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Csm_ID;

			Maticsoft.Model.ConsumableInfo model=new Maticsoft.Model.ConsumableInfo();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Csm_ID"]!=null && ds.Tables[0].Rows[0]["Csm_ID"].ToString()!="")
				{
					model.Csm_ID=decimal.Parse(ds.Tables[0].Rows[0]["Csm_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["C_Type"]!=null && ds.Tables[0].Rows[0]["C_Type"].ToString()!="")
				{
					model.C_Type=ds.Tables[0].Rows[0]["C_Type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Barcode"]!=null && ds.Tables[0].Rows[0]["C_Barcode"].ToString()!="")
				{
					model.C_Barcode=ds.Tables[0].Rows[0]["C_Barcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Name"]!=null && ds.Tables[0].Rows[0]["C_Name"].ToString()!="")
				{
					model.C_Name=ds.Tables[0].Rows[0]["C_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_AliasName"]!=null && ds.Tables[0].Rows[0]["C_AliasName"].ToString()!="")
				{
					model.C_AliasName=ds.Tables[0].Rows[0]["C_AliasName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Model"]!=null && ds.Tables[0].Rows[0]["C_Model"].ToString()!="")
				{
					model.C_Model=ds.Tables[0].Rows[0]["C_Model"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Address"]!=null && ds.Tables[0].Rows[0]["C_Address"].ToString()!="")
				{
					model.C_Address=ds.Tables[0].Rows[0]["C_Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Function"]!=null && ds.Tables[0].Rows[0]["C_Function"].ToString()!="")
				{
					model.C_Function=ds.Tables[0].Rows[0]["C_Function"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Lifetime"]!=null && ds.Tables[0].Rows[0]["C_Lifetime"].ToString()!="")
				{
					model.C_Lifetime=ds.Tables[0].Rows[0]["C_Lifetime"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_LifeUnit"]!=null && ds.Tables[0].Rows[0]["C_LifeUnit"].ToString()!="")
				{
					model.C_LifeUnit=ds.Tables[0].Rows[0]["C_LifeUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_SafeStock"]!=null && ds.Tables[0].Rows[0]["C_SafeStock"].ToString()!="")
				{
					model.C_SafeStock=ds.Tables[0].Rows[0]["C_SafeStock"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Unit"]!=null && ds.Tables[0].Rows[0]["C_Unit"].ToString()!="")
				{
					model.C_Unit=ds.Tables[0].Rows[0]["C_Unit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Picture"]!=null && ds.Tables[0].Rows[0]["C_Picture"].ToString()!="")
				{
					model.C_Picture=ds.Tables[0].Rows[0]["C_Picture"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Manufacturer"]!=null && ds.Tables[0].Rows[0]["C_Manufacturer"].ToString()!="")
				{
					model.C_Manufacturer=ds.Tables[0].Rows[0]["C_Manufacturer"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Official_Website"]!=null && ds.Tables[0].Rows[0]["C_Official_Website"].ToString()!="")
				{
					model.C_Official_Website=ds.Tables[0].Rows[0]["C_Official_Website"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Tel"]!=null && ds.Tables[0].Rows[0]["C_Tel"].ToString()!="")
				{
					model.C_Tel=ds.Tables[0].Rows[0]["C_Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_After_Sale"]!=null && ds.Tables[0].Rows[0]["C_After_Sale"].ToString()!="")
				{
					model.C_After_Sale=ds.Tables[0].Rows[0]["C_After_Sale"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_PurchasCycle"]!=null && ds.Tables[0].Rows[0]["C_PurchasCycle"].ToString()!="")
				{
					model.C_PurchasCycle=ds.Tables[0].Rows[0]["C_PurchasCycle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["C_Remarks"]!=null && ds.Tables[0].Rows[0]["C_Remarks"].ToString()!="")
				{
					model.C_Remarks=ds.Tables[0].Rows[0]["C_Remarks"].ToString();
				}
                //通过计算得出当前库存
                ConsumableReceive _M_Re = new ConsumableReceive();
                ConsumableStorage _M_St = new ConsumableStorage();
                double _storageCount = _M_St.Get_Stock(model.C_Barcode);
                double _receiveCount = _M_Re.Get_Stock(model.C_Barcode);
                model.Stock = (_storageCount - _receiveCount).ToString();

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
        public Maticsoft.Model.ConsumableInfo GetModel(string Csm_BarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Csm_ID,C_Type,C_Barcode,C_Name,C_AliasName,C_Model,C_Address,C_Function,C_Lifetime,C_LifeUnit,C_SafeStock,C_Unit,C_Picture,C_Manufacturer,C_Official_Website,C_Tel,C_After_Sale,C_PurchasCycle,C_Remarks from tb_ConsumableInfo ");
            strSql.Append(" where C_Barcode=@C_Barcode");
            SqlParameter[] parameters = {
					new SqlParameter("@C_Barcode", SqlDbType.VarChar)
			};
            parameters[0].Value = Csm_BarCode;

            Maticsoft.Model.ConsumableInfo model = new Maticsoft.Model.ConsumableInfo();
            DataSet ds = dbs.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Csm_ID"] != null && ds.Tables[0].Rows[0]["Csm_ID"].ToString() != "")
                {
                    model.Csm_ID = decimal.Parse(ds.Tables[0].Rows[0]["Csm_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_Type"] != null && ds.Tables[0].Rows[0]["C_Type"].ToString() != "")
                {
                    model.C_Type = ds.Tables[0].Rows[0]["C_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Barcode"] != null && ds.Tables[0].Rows[0]["C_Barcode"].ToString() != "")
                {
                    model.C_Barcode = ds.Tables[0].Rows[0]["C_Barcode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Name"] != null && ds.Tables[0].Rows[0]["C_Name"].ToString() != "")
                {
                    model.C_Name = ds.Tables[0].Rows[0]["C_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_AliasName"] != null && ds.Tables[0].Rows[0]["C_AliasName"].ToString() != "")
                {
                    model.C_AliasName = ds.Tables[0].Rows[0]["C_AliasName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Model"] != null && ds.Tables[0].Rows[0]["C_Model"].ToString() != "")
                {
                    model.C_Model = ds.Tables[0].Rows[0]["C_Model"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Address"] != null && ds.Tables[0].Rows[0]["C_Address"].ToString() != "")
                {
                    model.C_Address = ds.Tables[0].Rows[0]["C_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Function"] != null && ds.Tables[0].Rows[0]["C_Function"].ToString() != "")
                {
                    model.C_Function = ds.Tables[0].Rows[0]["C_Function"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Lifetime"] != null && ds.Tables[0].Rows[0]["C_Lifetime"].ToString() != "")
                {
                    model.C_Lifetime = ds.Tables[0].Rows[0]["C_Lifetime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_LifeUnit"] != null && ds.Tables[0].Rows[0]["C_LifeUnit"].ToString() != "")
                {
                    model.C_LifeUnit = ds.Tables[0].Rows[0]["C_LifeUnit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_SafeStock"] != null && ds.Tables[0].Rows[0]["C_SafeStock"].ToString() != "")
                {
                    model.C_SafeStock = ds.Tables[0].Rows[0]["C_SafeStock"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Unit"] != null && ds.Tables[0].Rows[0]["C_Unit"].ToString() != "")
                {
                    model.C_Unit = ds.Tables[0].Rows[0]["C_Unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Picture"] != null && ds.Tables[0].Rows[0]["C_Picture"].ToString() != "")
                {
                    model.C_Picture = ds.Tables[0].Rows[0]["C_Picture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Manufacturer"] != null && ds.Tables[0].Rows[0]["C_Manufacturer"].ToString() != "")
                {
                    model.C_Manufacturer = ds.Tables[0].Rows[0]["C_Manufacturer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Official_Website"] != null && ds.Tables[0].Rows[0]["C_Official_Website"].ToString() != "")
                {
                    model.C_Official_Website = ds.Tables[0].Rows[0]["C_Official_Website"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Tel"] != null && ds.Tables[0].Rows[0]["C_Tel"].ToString() != "")
                {
                    model.C_Tel = ds.Tables[0].Rows[0]["C_Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_After_Sale"] != null && ds.Tables[0].Rows[0]["C_After_Sale"].ToString() != "")
                {
                    model.C_After_Sale = ds.Tables[0].Rows[0]["C_After_Sale"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_PurchasCycle"] != null && ds.Tables[0].Rows[0]["C_PurchasCycle"].ToString() != "")
                {
                    model.C_PurchasCycle = ds.Tables[0].Rows[0]["C_PurchasCycle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_Remarks"] != null && ds.Tables[0].Rows[0]["C_Remarks"].ToString() != "")
                {
                    model.C_Remarks = ds.Tables[0].Rows[0]["C_Remarks"].ToString();
                }

                //通过计算得出当前库存
                ConsumableReceive _M_Re = new ConsumableReceive();
                ConsumableStorage _M_St = new ConsumableStorage();
                double _storageCount = _M_St.Get_Stock(model.C_Barcode);
                double _receiveCount = _M_Re.Get_Stock(model.C_Barcode);
                model.Stock = (_storageCount - _receiveCount).ToString();
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
			strSql.Append("select Csm_ID,C_Type,C_Barcode,C_Name,C_AliasName,C_Model,C_Address,C_Function,C_Lifetime,C_LifeUnit,C_SafeStock,C_Unit,C_Picture,C_Manufacturer,C_Official_Website,C_Tel,C_After_Sale,C_PurchasCycle,C_Remarks ");
			strSql.Append(" FROM tb_ConsumableInfo ");
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
			strSql.Append(" Csm_ID,C_Type,C_Barcode,C_Name,C_AliasName,C_Model,C_Address,C_Function,C_Lifetime,C_LifeUnit,C_SafeStock,C_Unit,C_Picture,C_Manufacturer,C_Official_Website,C_Tel,C_After_Sale,C_PurchasCycle,C_Remarks ");
			strSql.Append(" FROM tb_ConsumableInfo ");
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
			strSql.Append("select count(1) FROM tb_ConsumableInfo ");
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
				strSql.Append("order by T.Csm_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_ConsumableInfo T ");
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
			parameters[0].Value = "tb_ConsumableInfo";
			parameters[1].Value = "Csm_ID";
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

