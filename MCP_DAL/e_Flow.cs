/** 
* e_Flow.cs
*
* 功 能： N/A
* 类 名： e_Flow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：　　　　　　　　　　　　　　│
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
	/// 数据访问类:e_Flow
	/// </summary>
	public partial class e_Flow
	{
		public e_Flow()
		{}

        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.e_Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_e_Flow(");
			strSql.Append("DrawNum,ProcessOrder,ProcessNum,ProcessName,IsImportant,IsAffirm,Content,Remaks,R1,R2,R3)");
			strSql.Append(" values (");
			strSql.Append("@DrawNum,@ProcessOrder,@ProcessNum,@ProcessName,@IsImportant,@IsAffirm,@Content,@Remaks,@R1,@R2,@R3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessOrder", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,50),
					new SqlParameter("@IsImportant", SqlDbType.VarChar,50),
					new SqlParameter("@IsAffirm", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,50),
					new SqlParameter("@Remaks", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50),
					new SqlParameter("@R2", SqlDbType.VarChar,50),
					new SqlParameter("@R3", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DrawNum;
			parameters[1].Value = model.ProcessOrder;
			parameters[2].Value = model.ProcessNum;
			parameters[3].Value = model.ProcessName;
			parameters[4].Value = model.IsImportant;
			parameters[5].Value = model.IsAffirm;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.Remaks;
			parameters[8].Value = model.R1;
			parameters[9].Value = model.R2;
			parameters[10].Value = model.R3;

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
		public bool Update(Maticsoft.Model.e_Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_e_Flow set ");
			strSql.Append("DrawNum=@DrawNum,");
			strSql.Append("ProcessOrder=@ProcessOrder,");
			strSql.Append("ProcessNum=@ProcessNum,");
			strSql.Append("ProcessName=@ProcessName,");
			strSql.Append("IsImportant=@IsImportant,");
			strSql.Append("IsAffirm=@IsAffirm,");
			strSql.Append("Content=@Content,");
			strSql.Append("Remaks=@Remaks,");
			strSql.Append("R1=@R1,");
			strSql.Append("R2=@R2,");
			strSql.Append("R3=@R3");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessOrder", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,50),
					new SqlParameter("@IsImportant", SqlDbType.VarChar,50),
					new SqlParameter("@IsAffirm", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,50),
					new SqlParameter("@Remaks", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50),
					new SqlParameter("@R2", SqlDbType.VarChar,50),
					new SqlParameter("@R3", SqlDbType.VarChar,50),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.DrawNum;
			parameters[1].Value = model.ProcessOrder;
			parameters[2].Value = model.ProcessNum;
			parameters[3].Value = model.ProcessName;
			parameters[4].Value = model.IsImportant;
			parameters[5].Value = model.IsAffirm;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.Remaks;
			parameters[8].Value = model.R1;
			parameters[9].Value = model.R2;
			parameters[10].Value = model.R3;
			parameters[11].Value = model.ID_Key;

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
			strSql.Append("delete from tb_e_Flow ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string DrawNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_e_Flow ");
            strSql.Append(" where DrawNum=@DrawNum");
            SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50),
			};
            parameters[0].Value = DrawNum;

            int rows = dbs.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from tb_e_Flow ");
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
		public Maticsoft.Model.e_Flow GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DrawNum,ProcessOrder,ProcessNum,ProcessName,IsImportant,IsAffirm,Content,Remaks,R1,R2,R3,ID_Key from tb_e_Flow ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.e_Flow model=new Maticsoft.Model.e_Flow();
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
		public Maticsoft.Model.e_Flow DataRowToModel(DataRow row)
		{
			Maticsoft.Model.e_Flow model=new Maticsoft.Model.e_Flow();
			if (row != null)
			{
				if(row["DrawNum"]!=null)
				{
					model.DrawNum=row["DrawNum"].ToString();
				}
				if(row["ProcessOrder"]!=null)
				{
					model.ProcessOrder=row["ProcessOrder"].ToString();
				}
				if(row["ProcessNum"]!=null)
				{
					model.ProcessNum=row["ProcessNum"].ToString();
				}
				if(row["ProcessName"]!=null)
				{
					model.ProcessName=row["ProcessName"].ToString();
				}
				if(row["IsImportant"]!=null)
				{
					model.IsImportant=row["IsImportant"].ToString();
				}
				if(row["IsAffirm"]!=null)
				{
					model.IsAffirm=row["IsAffirm"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Remaks"]!=null)
				{
					model.Remaks=row["Remaks"].ToString();
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
			strSql.Append("select DrawNum,ProcessOrder,ProcessNum,ProcessName,IsImportant,IsAffirm,Content,Remaks,R1,R2,R3,ID_Key ");
			strSql.Append(" FROM tb_e_Flow ");
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
			strSql.Append(" DrawNum,ProcessOrder,ProcessNum,ProcessName,IsImportant,IsAffirm,Content,Remaks,R1,R2,R3,ID_Key ");
			strSql.Append(" FROM tb_e_Flow ");
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
			strSql.Append("select count(1) FROM tb_e_Flow ");
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
			strSql.Append(")AS Row, T.*  from tb_e_Flow T ");
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
			parameters[0].Value = "tb_e_Flow";
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

