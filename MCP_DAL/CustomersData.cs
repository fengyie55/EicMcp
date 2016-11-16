/**  版本信息模板在安装目录下，可自行修改。
* CustomersData.cs
*
* 功 能： N/A
* 类 名： CustomersData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/21 9:50:08   N/A    初版
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
	/// 数据访问类:CustomersData
	/// </summary>
	public partial class CustomersData
	{
		public CustomersData()
		{}
		DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return dbs.GetMaxID("Id", "tb_CustomersData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_CustomersData");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CustomersData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_CustomersData(");
			strSql.Append("SN,IL_13nm,RL_13nm,IL_15nm,RL_15nm,R1,R2,R3,R4)");
			strSql.Append(" values (");
			strSql.Append("@SN,@IL_13nm,@RL_13nm,@IL_15nm,@RL_15nm,@R1,@R2,@R3,@R4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@IL_13nm", SqlDbType.VarChar,50),
					new SqlParameter("@RL_13nm", SqlDbType.VarChar,50),
					new SqlParameter("@IL_15nm", SqlDbType.VarChar,50),
					new SqlParameter("@RL_15nm", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50),
					new SqlParameter("@R2", SqlDbType.VarChar,50),
					new SqlParameter("@R3", SqlDbType.VarChar,50),
					new SqlParameter("@R4", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.IL_13nm;
			parameters[2].Value = model.RL_13nm;
			parameters[3].Value = model.IL_15nm;
			parameters[4].Value = model.RL_15nm;
			parameters[5].Value = model.R1;
			parameters[6].Value = model.R2;
			parameters[7].Value = model.R3;
			parameters[8].Value = model.R4;

			object obj = dbs.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CustomersData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_CustomersData set ");
			strSql.Append("SN=@SN,");
			strSql.Append("IL_13nm=@IL_13nm,");
			strSql.Append("RL_13nm=@RL_13nm,");
			strSql.Append("IL_15nm=@IL_15nm,");
			strSql.Append("RL_15nm=@RL_15nm,");
			strSql.Append("R1=@R1,");
			strSql.Append("R2=@R2,");
			strSql.Append("R3=@R3,");
			strSql.Append("R4=@R4");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@IL_13nm", SqlDbType.VarChar,50),
					new SqlParameter("@RL_13nm", SqlDbType.VarChar,50),
					new SqlParameter("@IL_15nm", SqlDbType.VarChar,50),
					new SqlParameter("@RL_15nm", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50),
					new SqlParameter("@R2", SqlDbType.VarChar,50),
					new SqlParameter("@R3", SqlDbType.VarChar,50),
					new SqlParameter("@R4", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.IL_13nm;
			parameters[2].Value = model.RL_13nm;
			parameters[3].Value = model.IL_15nm;
			parameters[4].Value = model.RL_15nm;
			parameters[5].Value = model.R1;
			parameters[6].Value = model.R2;
			parameters[7].Value = model.R3;
			parameters[8].Value = model.R4;
			parameters[9].Value = model.Id;

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
		public bool Delete(string _sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_CustomersData ");
			strSql.Append(" where SN=@SN");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)
			};
			parameters[0].Value = _sn;

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
			strSql.Append("delete from tb_CustomersData ");
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
		public Maticsoft.Model.CustomersData GetModel(string _sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,SN,IL_13nm,RL_13nm,IL_15nm,RL_15nm,R1,R2,R3,R4 from tb_CustomersData ");
			strSql.Append(" where SN=@SN");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)
			};
			parameters[0].Value = _sn;

			Maticsoft.Model.CustomersData model=new Maticsoft.Model.CustomersData();
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
		public Maticsoft.Model.CustomersData DataRowToModel(DataRow row)
		{
			Maticsoft.Model.CustomersData model=new Maticsoft.Model.CustomersData();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["IL_13nm"]!=null)
				{
					model.IL_13nm=row["IL_13nm"].ToString();
				}
				if(row["RL_13nm"]!=null)
				{
					model.RL_13nm=row["RL_13nm"].ToString();
				}
				if(row["IL_15nm"]!=null)
				{
					model.IL_15nm=row["IL_15nm"].ToString();
				}
				if(row["RL_15nm"]!=null)
				{
					model.RL_15nm=row["RL_15nm"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,SN,IL_13nm,RL_13nm,IL_15nm,RL_15nm,R1,R2,R3,R4 ");
			strSql.Append(" FROM tb_CustomersData ");
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
			strSql.Append(" Id,SN,IL_13nm,RL_13nm,IL_15nm,RL_15nm,R1,R2,R3,R4 ");
			strSql.Append(" FROM tb_CustomersData ");
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
			strSql.Append("select count(1) FROM tb_CustomersData ");
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
			strSql.Append(")AS Row, T.*  from tb_CustomersData T ");
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
			parameters[0].Value = "tb_CustomersData";
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

