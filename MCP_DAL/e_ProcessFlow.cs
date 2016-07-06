/**  版本信息模板在安装目录下，可自行修改。
* e_ProcessFlow.cs
*
* 功 能： N/A
* 类 名： e_ProcessFlow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/1/28 13:33:41   N/A    初版
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
	/// 数据访问类:e_ProcessFlow
	/// </summary>
	public partial class e_ProcessFlow
	{
		public e_ProcessFlow()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID_Key)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_e_ProcessFlow");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.e_ProcessFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_e_ProcessFlow(");
			strSql.Append("BarCode,ProNum,ProcessName,ProcessContent,Value,JobNum,UserName,DateTime,State,Remarks,R1,R2,R3,R4,R5)");
			strSql.Append(" values (");
			strSql.Append("@BarCode,@ProNum,@ProcessName,@ProcessContent,@Value,@JobNum,@UserName,@DateTime,@State,@Remarks,@R1,@R2,@R3,@R4,@R5)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,150),
					new SqlParameter("@ProcessContent", SqlDbType.VarChar,150),
					new SqlParameter("@Value", SqlDbType.VarChar,150),
					new SqlParameter("@JobNum", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.VarChar,150),
					new SqlParameter("@Remarks", SqlDbType.VarChar,1),
					new SqlParameter("@R1", SqlDbType.VarChar,150),
					new SqlParameter("@R2", SqlDbType.VarChar,150),
					new SqlParameter("@R3", SqlDbType.VarChar,150),
					new SqlParameter("@R4", SqlDbType.VarChar,150),
					new SqlParameter("@R5", SqlDbType.VarChar,150)};
			parameters[0].Value = model.BarCode;
			parameters[1].Value = model.ProNum;
			parameters[2].Value = model.ProcessName;
			parameters[3].Value = model.ProcessContent;
			parameters[4].Value = model.Value;
			parameters[5].Value = model.JobNum;
			parameters[6].Value = model.UserName;
			parameters[7].Value = model.DateTime;
			parameters[8].Value = model.State;
			parameters[9].Value = model.Remarks;
			parameters[10].Value = model.R1;
			parameters[11].Value = model.R2;
			parameters[12].Value = model.R3;
			parameters[13].Value = model.R4;
			parameters[14].Value = model.R5;

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
		public bool Update(Maticsoft.Model.e_ProcessFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_e_ProcessFlow set ");
			strSql.Append("BarCode=@BarCode,");
			strSql.Append("ProNum=@ProNum,");
			strSql.Append("ProcessName=@ProcessName,");
			strSql.Append("ProcessContent=@ProcessContent,");
			strSql.Append("Value=@Value,");
			strSql.Append("JobNum=@JobNum,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("DateTime=@DateTime,");
			strSql.Append("State=@State,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("R1=@R1,");
			strSql.Append("R2=@R2,");
			strSql.Append("R3=@R3,");
			strSql.Append("R4=@R4,");
			strSql.Append("R5=@R5");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,150),
					new SqlParameter("@ProcessContent", SqlDbType.VarChar,150),
					new SqlParameter("@Value", SqlDbType.VarChar,150),
					new SqlParameter("@JobNum", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.VarChar,150),
					new SqlParameter("@Remarks", SqlDbType.VarChar,1),
					new SqlParameter("@R1", SqlDbType.VarChar,150),
					new SqlParameter("@R2", SqlDbType.VarChar,150),
					new SqlParameter("@R3", SqlDbType.VarChar,150),
					new SqlParameter("@R4", SqlDbType.VarChar,150),
					new SqlParameter("@R5", SqlDbType.VarChar,150),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.BarCode;
			parameters[1].Value = model.ProNum;
			parameters[2].Value = model.ProcessName;
			parameters[3].Value = model.ProcessContent;
			parameters[4].Value = model.Value;
			parameters[5].Value = model.JobNum;
			parameters[6].Value = model.UserName;
			parameters[7].Value = model.DateTime;
			parameters[8].Value = model.State;
			parameters[9].Value = model.Remarks;
			parameters[10].Value = model.R1;
			parameters[11].Value = model.R2;
			parameters[12].Value = model.R3;
			parameters[13].Value = model.R4;
			parameters[14].Value = model.R5;
			parameters[15].Value = model.ID_Key;

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
			strSql.Append("delete from tb_e_ProcessFlow ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
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
			strSql.Append("delete from tb_e_ProcessFlow ");
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
		public Maticsoft.Model.e_ProcessFlow GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID_Key,BarCode,ProNum,ProcessName,ProcessContent,Value,JobNum,UserName,DateTime,State,Remarks,R1,R2,R3,R4,R5 from tb_e_ProcessFlow ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.e_ProcessFlow model=new Maticsoft.Model.e_ProcessFlow();
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
		public Maticsoft.Model.e_ProcessFlow DataRowToModel(DataRow row)
		{
			Maticsoft.Model.e_ProcessFlow model=new Maticsoft.Model.e_ProcessFlow();
			if (row != null)
			{
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
				if(row["BarCode"]!=null)
				{
					model.BarCode=row["BarCode"].ToString();
				}
				if(row["ProNum"]!=null)
				{
					model.ProNum=row["ProNum"].ToString();
				}
				if(row["ProcessName"]!=null)
				{
					model.ProcessName=row["ProcessName"].ToString();
				}
				if(row["ProcessContent"]!=null)
				{
					model.ProcessContent=row["ProcessContent"].ToString();
				}
				if(row["Value"]!=null)
				{
					model.Value=row["Value"].ToString();
				}
				if(row["JobNum"]!=null)
				{
					model.JobNum=row["JobNum"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
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
			strSql.Append("select ID_Key,BarCode,ProNum,ProcessName,ProcessContent,Value,JobNum,UserName,DateTime,State,Remarks,R1,R2,R3,R4,R5 ");
			strSql.Append(" FROM tb_e_ProcessFlow ");
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
			strSql.Append(" ID_Key,BarCode,ProNum,ProcessName,ProcessContent,Value,JobNum,UserName,DateTime,State,Remarks,R1,R2,R3,R4,R5 ");
			strSql.Append(" FROM tb_e_ProcessFlow ");
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
			strSql.Append("select count(1) FROM tb_e_ProcessFlow ");
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
			strSql.Append(")AS Row, T.*  from tb_e_ProcessFlow T ");
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
			parameters[0].Value = "tb_e_ProcessFlow";
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

