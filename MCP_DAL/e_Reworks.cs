/**  版本信息模板在安装目录下，可自行修改。
* e_Reworks.cs
*
* 功 能： N/A
* 类 名： e_Reworks
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:36   N/A    初版
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
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:e_Reworks
	/// </summary>
	public partial class e_Reworks
	{
		public e_Reworks()
		{}
        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_e_Reworks");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Decimal)
			};
			parameters[0].Value = Id;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.e_Reworks model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_e_Reworks(");
			strSql.Append("Barcord,ReworkCount,RejectsNum,R_Describe,S_Describe,Result,Date,Operator,Verify,R1,R2,R3,R4,R5)");
			strSql.Append(" values (");
			strSql.Append("@Barcord,@ReworkCount,@RejectsNum,@R_Describe,@S_Describe,@Result,@Date,@Operator,@Verify,@R1,@R2,@R3,@R4,@R5)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Barcord", SqlDbType.VarBinary,50),
					new SqlParameter("@ReworkCount", SqlDbType.VarBinary,50),
					new SqlParameter("@RejectsNum", SqlDbType.VarBinary,50),
					new SqlParameter("@R_Describe", SqlDbType.Text),
					new SqlParameter("@S_Describe", SqlDbType.Text),
					new SqlParameter("@Result", SqlDbType.NVarChar,50),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Operator", SqlDbType.VarBinary,50),
					new SqlParameter("@Verify", SqlDbType.VarBinary,50),
					new SqlParameter("@R1", SqlDbType.Text),
					new SqlParameter("@R2", SqlDbType.Text),
					new SqlParameter("@R3", SqlDbType.Text),
					new SqlParameter("@R4", SqlDbType.Text),
					new SqlParameter("@R5", SqlDbType.Text)};
			parameters[0].Value = model.Barcord;
			parameters[1].Value = model.ReworkCount;
			parameters[2].Value = model.RejectsNum;
			parameters[3].Value = model.R_Describe;
			parameters[4].Value = model.S_Describe;
			parameters[5].Value = model.Result;
			parameters[6].Value = model.Date;
			parameters[7].Value = model.Operator;
			parameters[8].Value = model.Verify;
			parameters[9].Value = model.R1;
			parameters[10].Value = model.R2;
			parameters[11].Value = model.R3;
			parameters[12].Value = model.R4;
			parameters[13].Value = model.R5;

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
		public bool Update(Maticsoft.Model.e_Reworks model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_e_Reworks set ");
			strSql.Append("Barcord=@Barcord,");
			strSql.Append("ReworkCount=@ReworkCount,");
			strSql.Append("RejectsNum=@RejectsNum,");
			strSql.Append("R_Describe=@R_Describe,");
			strSql.Append("S_Describe=@S_Describe,");
			strSql.Append("Result=@Result,");
			strSql.Append("Date=@Date,");
			strSql.Append("Operator=@Operator,");
			strSql.Append("Verify=@Verify,");
			strSql.Append("R1=@R1,");
			strSql.Append("R2=@R2,");
			strSql.Append("R3=@R3,");
			strSql.Append("R4=@R4,");
			strSql.Append("R5=@R5");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Barcord", SqlDbType.VarBinary,50),
					new SqlParameter("@ReworkCount", SqlDbType.VarBinary,50),
					new SqlParameter("@RejectsNum", SqlDbType.VarBinary,50),
					new SqlParameter("@R_Describe", SqlDbType.Text),
					new SqlParameter("@S_Describe", SqlDbType.Text),
					new SqlParameter("@Result", SqlDbType.NVarChar,50),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Operator", SqlDbType.VarBinary,50),
					new SqlParameter("@Verify", SqlDbType.VarBinary,50),
					new SqlParameter("@R1", SqlDbType.Text),
					new SqlParameter("@R2", SqlDbType.Text),
					new SqlParameter("@R3", SqlDbType.Text),
					new SqlParameter("@R4", SqlDbType.Text),
					new SqlParameter("@R5", SqlDbType.Text),
					new SqlParameter("@Id", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Barcord;
			parameters[1].Value = model.ReworkCount;
			parameters[2].Value = model.RejectsNum;
			parameters[3].Value = model.R_Describe;
			parameters[4].Value = model.S_Describe;
			parameters[5].Value = model.Result;
			parameters[6].Value = model.Date;
			parameters[7].Value = model.Operator;
			parameters[8].Value = model.Verify;
			parameters[9].Value = model.R1;
			parameters[10].Value = model.R2;
			parameters[11].Value = model.R3;
			parameters[12].Value = model.R4;
			parameters[13].Value = model.R5;
			parameters[14].Value = model.Id;

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
		public bool Delete(decimal Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_e_Reworks ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Decimal)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_e_Reworks ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public Maticsoft.Model.e_Reworks GetModel(decimal Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Barcord,ReworkCount,RejectsNum,R_Describe,S_Describe,Result,Date,Operator,Verify,R1,R2,R3,R4,R5 from tb_e_Reworks ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Decimal)
			};
			parameters[0].Value = Id;

			Maticsoft.Model.e_Reworks model=new Maticsoft.Model.e_Reworks();
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
		public Maticsoft.Model.e_Reworks DataRowToModel(DataRow row)
		{
			Maticsoft.Model.e_Reworks model=new Maticsoft.Model.e_Reworks();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=decimal.Parse(row["Id"].ToString());
				}
				if(row["Barcord"]!=null && row["Barcord"].ToString()!="")
				{
					model.Barcord=(byte[])row["Barcord"];
				}
				if(row["ReworkCount"]!=null && row["ReworkCount"].ToString()!="")
				{
					model.ReworkCount=(byte[])row["ReworkCount"];
				}
				if(row["RejectsNum"]!=null && row["RejectsNum"].ToString()!="")
				{
					model.RejectsNum=(byte[])row["RejectsNum"];
				}
				if(row["R_Describe"]!=null)
				{
					model.R_Describe=row["R_Describe"].ToString();
				}
				if(row["S_Describe"]!=null)
				{
					model.S_Describe=row["S_Describe"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
				}
				if(row["Operator"]!=null && row["Operator"].ToString()!="")
				{
					model.Operator=(byte[])row["Operator"];
				}
				if(row["Verify"]!=null && row["Verify"].ToString()!="")
				{
					model.Verify=(byte[])row["Verify"];
				}
				if(row["R1"]!=null)
				{
					model.R1=row["R1"].ToString();
				}
				if(row["R2"]!=null)
				{
					model.R2=row["R2"].ToString();
				}
				if(row["R3"]!=null)
				{
					model.R3=row["R3"].ToString();
				}
				if(row["R4"]!=null)
				{
					model.R4=row["R4"].ToString();
				}
				if(row["R5"]!=null)
				{
					model.R5=row["R5"].ToString();
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
			strSql.Append("select Id,Barcord,ReworkCount,RejectsNum,R_Describe,S_Describe,Result,Date,Operator,Verify,R1,R2,R3,R4,R5 ");
			strSql.Append(" FROM tb_e_Reworks ");
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
			strSql.Append(" Id,Barcord,ReworkCount,RejectsNum,R_Describe,S_Describe,Result,Date,Operator,Verify,R1,R2,R3,R4,R5 ");
			strSql.Append(" FROM tb_e_Reworks ");
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
			strSql.Append("select count(1) FROM tb_e_Reworks ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_e_Reworks T ");
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
			parameters[0].Value = "tb_e_Reworks";
			parameters[1].Value = "Id";
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

