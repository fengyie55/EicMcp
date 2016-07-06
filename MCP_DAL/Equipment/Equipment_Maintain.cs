/**  版本信息模板在安装目录下，可自行修改。
* Equipment_Maintain.cs
*
* 功 能： N/A
* 类 名： Equipment_Maintain
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-08 9:14:36   N/A    初版
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
	/// 数据访问类:Equipment_Maintain
	/// </summary>
	public partial class Equipment_Maintain
	{
		public Equipment_Maintain()
		{}

        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.EquipmentMS);

        /// <summary>
        /// 获取用于新增加耗材的编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            DataSet ds = new DataSet();
            string _sql = "SELECT TOP (1) SUBSTRING(FormNum, 3, 10) + 1 AS MaxNum FROM tb_Equipment_Maintain ORDER BY Mat_ID DESC";
            ds = dbs.Query(_sql);
            return "MS" + ds.Tables[0].Rows[0]["MaxNum"].ToString();
        }
        
        #region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Mat_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Equipment_Maintain");
			strSql.Append(" where Mat_ID=@Mat_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mat_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mat_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Equipment_Maintain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Equipment_Maintain(");
			strSql.Append("FormNum,Ass_Num,Ass_Name,Ass_MakeNum,Ass_Type,Apply_Date,Apply_Describe,Apply_User,Maintain_Cause,Maintain_Describe,maintain_User,Maintain_Date,Check_Deseribe,Check_Result,Check_Date,Check_User,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@FormNum,@Ass_Num,@Ass_Name,@Ass_MakeNum,@Ass_Type,@Apply_Date,@Apply_Describe,@Apply_User,@Maintain_Cause,@Maintain_Describe,@maintain_User,@Maintain_Date,@Check_Deseribe,@Check_Result,@Check_Date,@Check_User,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FormNum", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Num", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_MakeNum", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Type", SqlDbType.VarChar,50),
					new SqlParameter("@Apply_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Apply_Describe", SqlDbType.Text),
					new SqlParameter("@Apply_User", SqlDbType.VarChar,50),
					new SqlParameter("@Maintain_Cause", SqlDbType.Text),
					new SqlParameter("@Maintain_Describe", SqlDbType.Text),
					new SqlParameter("@maintain_User", SqlDbType.VarChar,50),
					new SqlParameter("@Maintain_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Check_Deseribe", SqlDbType.Text),
					new SqlParameter("@Check_Result", SqlDbType.VarChar,50),
					new SqlParameter("@Check_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Check_User", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FormNum;
			parameters[1].Value = model.Ass_Num;
			parameters[2].Value = model.Ass_Name;
			parameters[3].Value = model.Ass_MakeNum;
			parameters[4].Value = model.Ass_Type;
			parameters[5].Value = model.Apply_Date;
			parameters[6].Value = model.Apply_Describe;
			parameters[7].Value = model.Apply_User;
			parameters[8].Value = model.Maintain_Cause;
			parameters[9].Value = model.Maintain_Describe;
			parameters[10].Value = model.maintain_User;
			parameters[11].Value = model.Maintain_Date;
			parameters[12].Value = model.Check_Deseribe;
			parameters[13].Value = model.Check_Result;
			parameters[14].Value = model.Check_Date;
			parameters[15].Value = model.Check_User;
			parameters[16].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.Equipment_Maintain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Equipment_Maintain set ");
			strSql.Append("FormNum=@FormNum,");
			strSql.Append("Ass_Num=@Ass_Num,");
			strSql.Append("Ass_Name=@Ass_Name,");
			strSql.Append("Ass_MakeNum=@Ass_MakeNum,");
			strSql.Append("Ass_Type=@Ass_Type,");
			strSql.Append("Apply_Date=@Apply_Date,");
			strSql.Append("Apply_Describe=@Apply_Describe,");
			strSql.Append("Apply_User=@Apply_User,");
			strSql.Append("Maintain_Cause=@Maintain_Cause,");
			strSql.Append("Maintain_Describe=@Maintain_Describe,");
			strSql.Append("maintain_User=@maintain_User,");
			strSql.Append("Maintain_Date=@Maintain_Date,");
			strSql.Append("Check_Deseribe=@Check_Deseribe,");
			strSql.Append("Check_Result=@Check_Result,");
			strSql.Append("Check_Date=@Check_Date,");
			strSql.Append("Check_User=@Check_User,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where Mat_ID=@Mat_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FormNum", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Num", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_MakeNum", SqlDbType.VarChar,50),
					new SqlParameter("@Ass_Type", SqlDbType.VarChar,50),
					new SqlParameter("@Apply_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Apply_Describe", SqlDbType.Text),
					new SqlParameter("@Apply_User", SqlDbType.VarChar,50),
					new SqlParameter("@Maintain_Cause", SqlDbType.Text),
					new SqlParameter("@Maintain_Describe", SqlDbType.Text),
					new SqlParameter("@maintain_User", SqlDbType.VarChar,50),
					new SqlParameter("@Maintain_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Check_Deseribe", SqlDbType.Text),
					new SqlParameter("@Check_Result", SqlDbType.VarChar,50),
					new SqlParameter("@Check_Date", SqlDbType.VarChar,50),
					new SqlParameter("@Check_User", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@Mat_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.FormNum;
			parameters[1].Value = model.Ass_Num;
			parameters[2].Value = model.Ass_Name;
			parameters[3].Value = model.Ass_MakeNum;
			parameters[4].Value = model.Ass_Type;
			parameters[5].Value = model.Apply_Date;
			parameters[6].Value = model.Apply_Describe;
			parameters[7].Value = model.Apply_User;
			parameters[8].Value = model.Maintain_Cause;
			parameters[9].Value = model.Maintain_Describe;
			parameters[10].Value = model.maintain_User;
			parameters[11].Value = model.Maintain_Date;
			parameters[12].Value = model.Check_Deseribe;
			parameters[13].Value = model.Check_Result;
			parameters[14].Value = model.Check_Date;
			parameters[15].Value = model.Check_User;
			parameters[16].Value = model.Remarks;
			parameters[17].Value = model.Mat_ID;

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
		public bool Delete(decimal Mat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Equipment_Maintain ");
			strSql.Append(" where Mat_ID=@Mat_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mat_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mat_ID;

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
		public bool DeleteList(string Mat_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Equipment_Maintain ");
			strSql.Append(" where Mat_ID in ("+Mat_IDlist + ")  ");
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
		public Maticsoft.Model.Equipment_Maintain GetModel(decimal Mat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Mat_ID,FormNum,Ass_Num,Ass_Name,Ass_MakeNum,Ass_Type,Apply_Date,Apply_Describe,Apply_User,Maintain_Cause,Maintain_Describe,maintain_User,Maintain_Date,Check_Deseribe,Check_Result,Check_Date,Check_User,Remarks from tb_Equipment_Maintain ");
			strSql.Append(" where Mat_ID=@Mat_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mat_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mat_ID;

			Maticsoft.Model.Equipment_Maintain model=new Maticsoft.Model.Equipment_Maintain();
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
		public Maticsoft.Model.Equipment_Maintain DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Equipment_Maintain model=new Maticsoft.Model.Equipment_Maintain();
			if (row != null)
			{
				if(row["Mat_ID"]!=null && row["Mat_ID"].ToString()!="")
				{
					model.Mat_ID=decimal.Parse(row["Mat_ID"].ToString());
				}
				if(row["FormNum"]!=null)
				{
					model.FormNum=row["FormNum"].ToString();
				}
				if(row["Ass_Num"]!=null)
				{
					model.Ass_Num=row["Ass_Num"].ToString();
				}
				if(row["Ass_Name"]!=null)
				{
					model.Ass_Name=row["Ass_Name"].ToString();
				}
				if(row["Ass_MakeNum"]!=null)
				{
					model.Ass_MakeNum=row["Ass_MakeNum"].ToString();
				}
				if(row["Ass_Type"]!=null)
				{
					model.Ass_Type=row["Ass_Type"].ToString();
				}
				if(row["Apply_Date"]!=null)
				{
					model.Apply_Date=row["Apply_Date"].ToString();
				}
				if(row["Apply_Describe"]!=null)
				{
					model.Apply_Describe=row["Apply_Describe"].ToString();
				}
				if(row["Apply_User"]!=null)
				{
					model.Apply_User=row["Apply_User"].ToString();
				}
				if(row["Maintain_Cause"]!=null)
				{
					model.Maintain_Cause=row["Maintain_Cause"].ToString();
				}
				if(row["Maintain_Describe"]!=null)
				{
					model.Maintain_Describe=row["Maintain_Describe"].ToString();
				}
				if(row["maintain_User"]!=null)
				{
					model.maintain_User=row["maintain_User"].ToString();
				}
				if(row["Maintain_Date"]!=null)
				{
					model.Maintain_Date=row["Maintain_Date"].ToString();
				}
				if(row["Check_Deseribe"]!=null)
				{
					model.Check_Deseribe=row["Check_Deseribe"].ToString();
				}
				if(row["Check_Result"]!=null)
				{
					model.Check_Result=row["Check_Result"].ToString();
				}
				if(row["Check_Date"]!=null)
				{
					model.Check_Date=row["Check_Date"].ToString();
				}
				if(row["Check_User"]!=null)
				{
					model.Check_User=row["Check_User"].ToString();
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
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
			strSql.Append("select Mat_ID,FormNum,Ass_Num,Ass_Name,Ass_MakeNum,Ass_Type,Apply_Date,Apply_Describe,Apply_User,Maintain_Cause,Maintain_Describe,maintain_User,Maintain_Date,Check_Deseribe,Check_Result,Check_Date,Check_User,Remarks ");
			strSql.Append(" FROM tb_Equipment_Maintain ");
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
			strSql.Append(" Mat_ID,FormNum,Ass_Num,Ass_Name,Ass_MakeNum,Ass_Type,Apply_Date,Apply_Describe,Apply_User,Maintain_Cause,Maintain_Describe,maintain_User,Maintain_Date,Check_Deseribe,Check_Result,Check_Date,Check_User,Remarks ");
			strSql.Append(" FROM tb_Equipment_Maintain ");
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
			strSql.Append("select count(1) FROM tb_Equipment_Maintain ");
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
				strSql.Append("order by T.Mat_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Equipment_Maintain T ");
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
			parameters[0].Value = "tb_Equipment_Maintain";
			parameters[1].Value = "Mat_ID";
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

