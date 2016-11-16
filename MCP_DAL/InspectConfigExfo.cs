/**  版本信息模板在安装目录下，可自行修改。
* InspectConfigExfo.cs
*
* 功 能： N/A
* 类 名： InspectConfigExfo
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
	/// 数据访问类:InspectConfigExfo
	/// </summary>
	public partial class InspectConfigExfo
	{
		public InspectConfigExfo()
		{}
		#region  BasicMethod

		DbHelperSQL dbs = new DbHelperSQL();

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.InspectConfigExfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_InspectConfigExfo(");
			strSql.Append("ProductId,Wave,Type,IL_Min,IL_Max,RL_Min,RL_Max)");
			strSql.Append(" values (");
			strSql.Append("SQL2012ProductId,SQL2012Wave,SQL2012Type,SQL2012IL_Min,SQL2012IL_Max,SQL2012RL_Min,SQL2012RL_Max)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Wave", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012Type", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012IL_Min", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012IL_Max", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012RL_Min", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012RL_Max", SqlDbType.VarChar,15)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Wave;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.IL_Min;
			parameters[4].Value = model.IL_Max;
			parameters[5].Value = model.RL_Min;
			parameters[6].Value = model.RL_Max;

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
		public bool Update(Maticsoft.Model.InspectConfigExfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_InspectConfigExfo set ");
			strSql.Append("ProductId=SQL2012ProductId,");
			strSql.Append("Wave=SQL2012Wave,");
			strSql.Append("Type=SQL2012Type,");
			strSql.Append("IL_Min=SQL2012IL_Min,");
			strSql.Append("IL_Max=SQL2012IL_Max,");
			strSql.Append("RL_Min=SQL2012RL_Min,");
			strSql.Append("RL_Max=SQL2012RL_Max");
			strSql.Append(" where ID_Key=SQL2012ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Wave", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012Type", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012IL_Min", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012IL_Max", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012RL_Min", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012RL_Max", SqlDbType.VarChar,15),
					new SqlParameter("SQL2012ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Wave;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.IL_Min;
			parameters[4].Value = model.IL_Max;
			parameters[5].Value = model.RL_Min;
			parameters[6].Value = model.RL_Max;
			parameters[7].Value = model.ID_Key;

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
		public bool Delete(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfigExfo ");
			strSql.Append(" where ID_Key=SQL2012ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

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
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfigExfo ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
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
		public Maticsoft.Model.InspectConfigExfo GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductId,Wave,Type,IL_Min,IL_Max,RL_Min,RL_Max,ID_Key from tb_InspectConfigExfo ");
			strSql.Append(" where ID_Key=SQL2012ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.InspectConfigExfo model=new Maticsoft.Model.InspectConfigExfo();
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
		public Maticsoft.Model.InspectConfigExfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.InspectConfigExfo model=new Maticsoft.Model.InspectConfigExfo();
			if (row != null)
			{
				if(row["ProductId"]!=null)
				{
					model.ProductId=row["ProductId"].ToString();
				}
				if(row["Wave"]!=null)
				{
					model.Wave=row["Wave"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["IL_Min"]!=null)
				{
					model.IL_Min=row["IL_Min"].ToString();
				}
				if(row["IL_Max"]!=null)
				{
					model.IL_Max=row["IL_Max"].ToString();
				}
				if(row["RL_Min"]!=null)
				{
					model.RL_Min=row["RL_Min"].ToString();
				}
				if(row["RL_Max"]!=null)
				{
					model.RL_Max=row["RL_Max"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
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
			strSql.Append("select ProductId,Wave,Type,IL_Min,IL_Max,RL_Min,RL_Max,ID_Key ");
			strSql.Append(" FROM tb_InspectConfigExfo ");
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
			strSql.Append(" ProductId,Wave,Type,IL_Min,IL_Max,RL_Min,RL_Max,ID_Key ");
			strSql.Append(" FROM tb_InspectConfigExfo ");
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
			strSql.Append("select count(1) FROM tb_InspectConfigExfo ");
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
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_InspectConfigExfo T ");
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
			parameters[0].Value = "tb_InspectConfigExfo";
			parameters[1].Value = "ID_Key";
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

