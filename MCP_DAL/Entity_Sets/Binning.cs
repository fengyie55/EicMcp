using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Binning
	/// </summary>
	public partial class Binning
	{
		public Binning()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SackID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Binning");
			strSql.Append(" where SackID=@SackID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SackID", SqlDbType.NChar,10)			};
			parameters[0].Value = SackID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Binning model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Binning(");
			strSql.Append("SackID,BoxID,BatchNO,OrderID,ID_Key)");
			strSql.Append(" values (");
			strSql.Append("@SackID,@BoxID,@BatchNO,@OrderID,@ID_Key)");
			SqlParameter[] parameters = {
					new SqlParameter("@SackID", SqlDbType.NChar,10),
					new SqlParameter("@BoxID", SqlDbType.NChar,10),
					new SqlParameter("@BatchNO", SqlDbType.NChar,10),
					new SqlParameter("@OrderID", SqlDbType.NChar,10),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SackID;
			parameters[1].Value = model.BoxID;
			parameters[2].Value = model.BatchNO;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.ID_Key;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Binning model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Binning set ");
			strSql.Append("BoxID=@BoxID,");
			strSql.Append("BatchNO=@BatchNO,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where SackID=@SackID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BoxID", SqlDbType.NChar,10),
					new SqlParameter("@BatchNO", SqlDbType.NChar,10),
					new SqlParameter("@OrderID", SqlDbType.NChar,10),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@SackID", SqlDbType.NChar,10)};
			parameters[0].Value = model.BoxID;
			parameters[1].Value = model.BatchNO;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.ID_Key;
			parameters[4].Value = model.SackID;

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
		public bool Delete(string SackID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Binning ");
			strSql.Append(" where SackID=@SackID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SackID", SqlDbType.NChar,10)			};
			parameters[0].Value = SackID;

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
		public bool DeleteList(string SackIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Binning ");
			strSql.Append(" where SackID in ("+SackIDlist + ")  ");
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
		public Maticsoft.Model.Binning GetModel(string SackID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SackID,BoxID,BatchNO,OrderID,ID_Key from tb_Binning ");
			strSql.Append(" where SackID=@SackID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SackID", SqlDbType.NChar,10)			};
			parameters[0].Value = SackID;

			Maticsoft.Model.Binning model=new Maticsoft.Model.Binning();
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
		public Maticsoft.Model.Binning DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Binning model=new Maticsoft.Model.Binning();
			if (row != null)
			{
				if(row["SackID"]!=null)
				{
					model.SackID=row["SackID"].ToString();
				}
				if(row["BoxID"]!=null)
				{
					model.BoxID=row["BoxID"].ToString();
				}
				if(row["BatchNO"]!=null)
				{
					model.BatchNO=row["BatchNO"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
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
			strSql.Append("select SackID,BoxID,BatchNO,OrderID,ID_Key ");
			strSql.Append(" FROM tb_Binning ");
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
			strSql.Append(" SackID,BoxID,BatchNO,OrderID,ID_Key ");
			strSql.Append(" FROM tb_Binning ");
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
			strSql.Append("select count(1) FROM tb_Binning ");
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
				strSql.Append("order by T.SackID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Binning T ");
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
			parameters[0].Value = "tb_Binning";
			parameters[1].Value = "SackID";
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

