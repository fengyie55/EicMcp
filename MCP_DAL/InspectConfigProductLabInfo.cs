/**  版本信息模板在安装目录下，可自行修改。
* InspectConfigProductLabInfo.cs
*
* 功 能： N/A
* 类 名： InspectConfigProductLabInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  11/3/2016 11:32:51 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:InspectConfigProductLabInfo
	/// </summary>
	public partial class InspectConfigProductLabInfo
	{
		public InspectConfigProductLabInfo()
		{}

		DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Id_Key)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_InspectConfigProductLabInfo");
			strSql.Append(" where Id_Key=SQL2012Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = Id_Key;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.InspectConfigProductLabInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_InspectConfigProductLabInfo(");
			strSql.Append("ProductId,Name,Value)");
			strSql.Append(" values (");
			strSql.Append("SQL2012ProductId,SQL2012Name,SQL2012Value)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Name", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Value", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Value;

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
		public bool Update(Maticsoft.Model.InspectConfigProductLabInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_InspectConfigProductLabInfo set ");
			strSql.Append("ProductId=SQL2012ProductId,");
			strSql.Append("Name=SQL2012Name,");
			strSql.Append("Value=SQL2012Value");
			strSql.Append(" where Id_Key=SQL2012Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Name", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Value", SqlDbType.NVarChar,200),
					new SqlParameter("SQL2012Id_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Value;
			parameters[3].Value = model.Id_Key;

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
		public bool Delete(decimal Id_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfigProductLabInfo ");
			strSql.Append(" where Id_Key=SQL2012Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = Id_Key;

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
		public bool DeleteList(string Id_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfigProductLabInfo ");
			strSql.Append(" where Id_Key in ("+Id_Keylist + ")  ");
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
		public Maticsoft.Model.InspectConfigProductLabInfo GetModel(decimal Id_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductId,Name,Value,Id_Key from tb_InspectConfigProductLabInfo ");
			strSql.Append(" where Id_Key=SQL2012Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = Id_Key;

			Maticsoft.Model.InspectConfigProductLabInfo model=new Maticsoft.Model.InspectConfigProductLabInfo();
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
		public Maticsoft.Model.InspectConfigProductLabInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.InspectConfigProductLabInfo model=new Maticsoft.Model.InspectConfigProductLabInfo();
			if (row != null)
			{
				if(row["ProductId"]!=null)
				{
					model.ProductId=row["ProductId"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Value"]!=null)
				{
					model.Value=row["Value"].ToString();
				}
				if(row["Id_Key"]!=null && row["Id_Key"].ToString()!="")
				{
					model.Id_Key=decimal.Parse(row["Id_Key"].ToString());
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
			strSql.Append("select ProductId,Name,Value,Id_Key ");
			strSql.Append(" FROM tb_InspectConfigProductLabInfo ");
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
			strSql.Append(" ProductId,Name,Value,Id_Key ");
			strSql.Append(" FROM tb_InspectConfigProductLabInfo ");
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
			strSql.Append("select count(1) FROM tb_InspectConfigProductLabInfo ");
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
				strSql.Append("order by T.Id_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_InspectConfigProductLabInfo T ");
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
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_InspectConfigProductLabInfo";
			parameters[1].Value = "Id_Key";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

