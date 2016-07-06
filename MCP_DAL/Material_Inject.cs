/* Material_Inject.cs
*
* 功 能： N/A
* 类 名： Material_Inject
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-9 16:48:33   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　                   │
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Material_Inject
	/// </summary>
	public partial class Material_Inject
	{
		public Material_Inject()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal In_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Material_Inject");
			strSql.Append(" where In_ID=@In_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@In_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = In_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 获取已投入数量
        /// </summary>
        public int GetInjectCount(string Orm_ID)
        {
            string sql = "SELECT SUM(CONVERT(float, Count)) AS Count FROM tb_Material_Inject WHERE (Orm_ID = '"+Orm_ID+"')";
            return dbs.GetSUM_Count(sql);
        }


        /// <summary>
        /// 获取管制料件 需领 已领 投入 视图
        /// </summary>
        public DataSet GetInjectView(string OrderID)
        {
            DataSet ds = new DataSet();
            string strSql = "SELECT derivedtbl_1.工单, derivedtbl_1.别名, derivedtbl_1.料号, derivedtbl_1.需领数量, ";
            strSql += "      derivedtbl_1.已领数量, SUM(CONVERT(float, dbo.tb_Material_Inject.Count)) AS 投入 ";
            strSql += "  , derivedtbl_1.已领数量 - SUM(CONVERT(float, tb_Material_Inject.Count))     AS 剩余数量";
            strSql += "  FROM (SELECT dbo.tb_OrderMaterial.OrderID AS 工单, ";
            strSql += "              dbo.tb_MaterialInfo.AliasName AS 别名, ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID AS 料号, ";
            strSql += "              dbo.tb_MaterialInfo.ProductName AS 品名, ";
            strSql += "              dbo.tb_MaterialInfo.Model AS 规格, dbo.tb_MaterialInfo.Unit AS 单位, ";
            strSql += "              dbo.tb_OrderMaterial.SendCount AS 需领数量, SUM(CONVERT(float, ";
            strSql += "              dbo.tb_Material_Receive.Count)) AS 已领数量, ";
            strSql += "              dbo.tb_OrderMaterial.Orm_ID";
            strSql += "        FROM dbo.tb_OrderMaterial INNER JOIN";
            strSql += "              dbo.tb_MaterialInfo ON ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID = dbo.tb_MaterialInfo.MaterialID LEFT OUTER JOIN";
            strSql += "              dbo.tb_Material_Receive ON ";
            strSql += "              dbo.tb_OrderMaterial.Orm_ID = dbo.tb_Material_Receive.Orm_ID";
            strSql += "        GROUP BY dbo.tb_OrderMaterial.OrderID, dbo.tb_MaterialInfo.AliasName, ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID, dbo.tb_MaterialInfo.ProductName, ";
            strSql += "              dbo.tb_MaterialInfo.Model, dbo.tb_MaterialInfo.Unit, ";
            strSql += "              dbo.tb_OrderMaterial.SendCount, dbo.tb_OrderMaterial.Orm_ID";
            strSql += "        HAVING (dbo.tb_OrderMaterial.OrderID = '" + OrderID + "') AND ";
            strSql += "              (dbo.tb_MaterialInfo.AliasName = 'APC' OR  dbo.tb_MaterialInfo.AliasName = 'MT' OR ";
            strSql += "              dbo.tb_MaterialInfo.AliasName = 'PC' OR dbo.tb_MaterialInfo.AliasName = 'LC 头套组' OR ";
            strSql += "              dbo.tb_MaterialInfo.AliasName = 'SUS')) AS derivedtbl_1 LEFT OUTER JOIN";
            strSql += "      dbo.tb_Material_Inject ON ";
            strSql += "      derivedtbl_1.Orm_ID = dbo.tb_Material_Inject.Orm_ID";
            strSql += "  GROUP BY derivedtbl_1.工单, derivedtbl_1.别名, derivedtbl_1.料号, derivedtbl_1.需领数量, ";
            strSql += "      derivedtbl_1.已领数量";
            ds = dbs.Query(strSql);
            return ds;

        }

        /// <summary>
        /// 获取管制料件 需领 已领 投入 视图
        /// </summary>
        public DataSet GetInjectView(string[] OrderList)
        {
            string _OrderIDList = ""; int t = 0;
            foreach (string _TemOrd in OrderList)
            {
                if (t == 0) { _OrderIDList += "'" + _TemOrd + "'"; }
                else { _OrderIDList += ",'" + _TemOrd + "'"; }
                t++;
            }
            DataSet ds = new DataSet();
            string strSql = "SELECT derivedtbl_1.工单, derivedtbl_1.别名, derivedtbl_1.料号, derivedtbl_1.需领数量, ";
            strSql += "      derivedtbl_1.已领数量, SUM(CONVERT(float, dbo.tb_Material_Inject.Count)) AS 投入 ";
            strSql += "  , derivedtbl_1.已领数量 - SUM(CONVERT(float, tb_Material_Inject.Count))     AS 剩余数量";
            strSql += "  FROM (SELECT dbo.tb_OrderMaterial.OrderID AS 工单, ";
            strSql += "              dbo.tb_MaterialInfo.AliasName AS 别名, ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID AS 料号, ";
            strSql += "              dbo.tb_MaterialInfo.ProductName AS 品名, ";
            strSql += "              dbo.tb_MaterialInfo.Model AS 规格, dbo.tb_MaterialInfo.Unit AS 单位, ";
            strSql += "              dbo.tb_OrderMaterial.SendCount AS 需领数量, SUM(CONVERT(float, ";
            strSql += "              dbo.tb_Material_Receive.Count)) AS 已领数量, ";
            strSql += "              dbo.tb_OrderMaterial.Orm_ID";
            strSql += "        FROM dbo.tb_OrderMaterial INNER JOIN";
            strSql += "              dbo.tb_MaterialInfo ON ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID = dbo.tb_MaterialInfo.MaterialID LEFT OUTER JOIN";
            strSql += "              dbo.tb_Material_Receive ON ";
            strSql += "              dbo.tb_OrderMaterial.Orm_ID = dbo.tb_Material_Receive.Orm_ID";
            strSql += "        GROUP BY dbo.tb_OrderMaterial.OrderID, dbo.tb_MaterialInfo.AliasName, ";
            strSql += "              dbo.tb_OrderMaterial.MaterialID, dbo.tb_MaterialInfo.ProductName, ";
            strSql += "              dbo.tb_MaterialInfo.Model, dbo.tb_MaterialInfo.Unit, ";
            strSql += "              dbo.tb_OrderMaterial.SendCount, dbo.tb_OrderMaterial.Orm_ID";
            strSql += "        HAVING (dbo.tb_OrderMaterial.OrderID IN (" + _OrderIDList + ")) AND ";
            strSql += "              (dbo.tb_MaterialInfo.AliasName = 'APC' OR  dbo.tb_MaterialInfo.AliasName = 'MT' OR ";
            strSql += "              dbo.tb_MaterialInfo.AliasName = 'PC' OR dbo.tb_MaterialInfo.AliasName = 'LC 头套组' OR ";
            strSql += "              dbo.tb_MaterialInfo.AliasName = 'SUS')) AS derivedtbl_1 LEFT OUTER JOIN";
            strSql += "      dbo.tb_Material_Inject ON ";
            strSql += "      derivedtbl_1.Orm_ID = dbo.tb_Material_Inject.Orm_ID";
            strSql += "  GROUP BY derivedtbl_1.工单, derivedtbl_1.别名, derivedtbl_1.料号, derivedtbl_1.需领数量, ";
            strSql += "      derivedtbl_1.已领数量";
            ds = dbs.Query(strSql);
            return ds;


        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Material_Inject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Material_Inject(");
			strSql.Append("Orm_ID,Count,UserID,WK_ID,DateTime)");
			strSql.Append(" values (");
			strSql.Append("@Orm_ID,@Count,@UserID,@WK_ID,@DateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,15),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@WK_ID", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Count;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.WK_ID;
			parameters[4].Value = model.DateTime;

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
		public bool Update(Maticsoft.Model.Material_Inject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Material_Inject set ");
			strSql.Append("Orm_ID=@Orm_ID,");
			strSql.Append("Count=@Count,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("WK_ID=@WK_ID,");
			strSql.Append("DateTime=@DateTime");
			strSql.Append(" where In_ID=@In_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,15),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@WK_ID", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@In_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Count;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.WK_ID;
			parameters[4].Value = model.DateTime;
			parameters[5].Value = model.In_ID;

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
		public bool Delete(decimal In_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_Inject ");
			strSql.Append(" where In_ID=@In_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@In_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = In_ID;

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
		public bool DeleteList(string In_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_Inject ");
			strSql.Append(" where In_ID in ("+In_IDlist + ")  ");
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
		public Maticsoft.Model.Material_Inject GetModel(decimal In_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 In_ID,Orm_ID,Count,UserID,WK_ID,DateTime from tb_Material_Inject ");
			strSql.Append(" where In_ID=@In_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@In_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = In_ID;

			Maticsoft.Model.Material_Inject model=new Maticsoft.Model.Material_Inject();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Material_Inject DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Material_Inject model=new Maticsoft.Model.Material_Inject();
			if (row != null)
			{
				if(row["In_ID"]!=null && row["In_ID"].ToString()!="")
				{
					model.In_ID=decimal.Parse(row["In_ID"].ToString());
				}
				if(row["Orm_ID"]!=null)
				{
					model.Orm_ID=row["Orm_ID"].ToString();
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["WK_ID"]!=null)
				{
					model.WK_ID=row["WK_ID"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
			}
			return model;
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select In_ID,Orm_ID,Count,UserID,WK_ID,DateTime ");
			strSql.Append(" FROM tb_Material_Inject ");
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
			strSql.Append(" In_ID,Orm_ID,Count,UserID,WK_ID,DateTime ");
			strSql.Append(" FROM tb_Material_Inject ");
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
			strSql.Append("select count(1) FROM tb_Material_Inject ");
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
				strSql.Append("order by T.In_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Material_Inject T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return dbs.Query(strSql.ToString());
		}
		
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

