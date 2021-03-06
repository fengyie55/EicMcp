﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:LabVerify
	/// </summary>
	public partial class LabVerify
	{
		public LabVerify()
		{}
		#region  Method
        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal LBV_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_LabVerify");
			strSql.Append(" where LBV_ID=@LBV_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LBV_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = LBV_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.LabVerify model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_LabVerify(");
			strSql.Append("Orm_ID,Pb_ID,IsVerify,UserID,LabPic_ID)");
			strSql.Append(" values (");
			strSql.Append("@Orm_ID,@Pb_ID,@IsVerify,@UserID,@LabPic_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Pb_ID", SqlDbType.VarChar,50),
					new SqlParameter("@IsVerify", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@LabPic_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Pb_ID;
			parameters[2].Value = model.IsVerify;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.LabPic_ID;

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
		public bool Update(Maticsoft.Model.LabVerify model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_LabVerify set ");
			strSql.Append("Orm_ID=@Orm_ID,");
			strSql.Append("Pb_ID=@Pb_ID,");
			strSql.Append("IsVerify=@IsVerify,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("LabPic_ID=@LabPic_ID");
			strSql.Append(" where LBV_ID=@LBV_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Pb_ID", SqlDbType.VarChar,50),
					new SqlParameter("@IsVerify", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@LabPic_ID", SqlDbType.VarChar,50),
					new SqlParameter("@LBV_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Pb_ID;
			parameters[2].Value = model.IsVerify;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.LabPic_ID;
			parameters[5].Value = model.LBV_ID;

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
		public bool Delete(decimal LBV_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_LabVerify ");
			strSql.Append(" where LBV_ID=@LBV_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LBV_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = LBV_ID;

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
		public bool DeleteList(string LBV_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_LabVerify ");
			strSql.Append(" where LBV_ID in ("+LBV_IDlist + ")  ");
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
		public Maticsoft.Model.LabVerify GetModel(decimal LBV_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LBV_ID,Orm_ID,Pb_ID,IsVerify,UserID,LabPic_ID from tb_LabVerify ");
			strSql.Append(" where LBV_ID=@LBV_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LBV_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = LBV_ID;

			Maticsoft.Model.LabVerify model=new Maticsoft.Model.LabVerify();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LBV_ID"]!=null && ds.Tables[0].Rows[0]["LBV_ID"].ToString()!="")
				{
					model.LBV_ID=decimal.Parse(ds.Tables[0].Rows[0]["LBV_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Orm_ID"]!=null && ds.Tables[0].Rows[0]["Orm_ID"].ToString()!="")
				{
					model.Orm_ID=ds.Tables[0].Rows[0]["Orm_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pb_ID"]!=null && ds.Tables[0].Rows[0]["Pb_ID"].ToString()!="")
				{
					model.Pb_ID=ds.Tables[0].Rows[0]["Pb_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsVerify"]!=null && ds.Tables[0].Rows[0]["IsVerify"].ToString()!="")
				{
					model.IsVerify=ds.Tables[0].Rows[0]["IsVerify"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LabPic_ID"]!=null && ds.Tables[0].Rows[0]["LabPic_ID"].ToString()!="")
				{
					model.LabPic_ID=ds.Tables[0].Rows[0]["LabPic_ID"].ToString();
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
        public Maticsoft.Model.LabVerify GetModel(string sqlWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LBV_ID,Orm_ID,Pb_ID,IsVerify,UserID,LabPic_ID from tb_LabVerify ");          
            if (sqlWhere != "")
            {
                strSql.Append(" where " + sqlWhere);
            }

            Maticsoft.Model.LabVerify model = new Maticsoft.Model.LabVerify();
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LBV_ID"] != null && ds.Tables[0].Rows[0]["LBV_ID"].ToString() != "")
                {
                    model.LBV_ID = decimal.Parse(ds.Tables[0].Rows[0]["LBV_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Orm_ID"] != null && ds.Tables[0].Rows[0]["Orm_ID"].ToString() != "")
                {
                    model.Orm_ID = ds.Tables[0].Rows[0]["Orm_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pb_ID"] != null && ds.Tables[0].Rows[0]["Pb_ID"].ToString() != "")
                {
                    model.Pb_ID = ds.Tables[0].Rows[0]["Pb_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsVerify"] != null && ds.Tables[0].Rows[0]["IsVerify"].ToString() != "")
                {
                    model.IsVerify = ds.Tables[0].Rows[0]["IsVerify"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LabPic_ID"] != null && ds.Tables[0].Rows[0]["LabPic_ID"].ToString() != "")
                {
                    model.LabPic_ID = ds.Tables[0].Rows[0]["LabPic_ID"].ToString();
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
			strSql.Append("select LBV_ID,Orm_ID,Pb_ID,IsVerify,UserID,LabPic_ID ");
			strSql.Append(" FROM tb_LabVerify ");
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
			strSql.Append(" LBV_ID,Orm_ID,Pb_ID,IsVerify,UserID,LabPic_ID ");
			strSql.Append(" FROM tb_LabVerify ");
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
			strSql.Append("select count(1) FROM tb_LabVerify ");
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
				strSql.Append("order by T.LBV_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_LabVerify T ");
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
			parameters[0].Value = "tb_LabVerify";
			parameters[1].Value = "LBV_ID";
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

