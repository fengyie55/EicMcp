using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:PackBatch
	/// </summary>
	public partial class PackBatch
	{
		public PackBatch()
		{}
		#region  BasicMethod
        DbHelperSQL dbs = new DbHelperSQL();
        SerialNumber _temserialNumber = new SerialNumber();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BatchNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_PackBatch");
			strSql.Append(" where BatchNo=@BatchNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,15)			};
			parameters[0].Value = BatchNo;

			return dbs.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 已经包装数量
        /// </summary>
        /// <param name="_BatchNo">包装批号</param>
        /// <returns></returns>
        public int Yet_PackCount(string _BatchNo)
        {          
            return _temserialNumber.Get_PackCount_Batch("BatchNO= '" + _BatchNo + "'");
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.PackBatch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_PackBatch(");
			strSql.Append("BatchNo,Count,SackQty,BoxQty,OrderID,State)");
			strSql.Append(" values (");
			strSql.Append("@BatchNo,@Count,@SackQty,@BoxQty,@OrderID,@State)");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,15),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@SackQty", SqlDbType.VarChar,15),
					new SqlParameter("@BoxQty", SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15),
					new SqlParameter("@State", SqlDbType.VarChar,15),
					};
			parameters[0].Value = model.BatchNo;
			parameters[1].Value = model.Count;
			parameters[2].Value = model.SackQty;
			parameters[3].Value = model.BoxQty;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.State;
			;
          
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
		public bool Update(Maticsoft.Model.PackBatch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_PackBatch set ");
			strSql.Append("Count=@Count,");
			strSql.Append("SackQty=@SackQty,");
			strSql.Append("BoxQty=@BoxQty,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("State=@State,");
			
			strSql.Append(" where BatchNo=@BatchNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@SackQty", SqlDbType.VarChar,15),
					new SqlParameter("@BoxQty", SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15),
					new SqlParameter("@State", SqlDbType.VarChar,15),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,15)};
			parameters[0].Value = model.Count;
			parameters[1].Value = model.SackQty;
			parameters[2].Value = model.BoxQty;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.State;
			parameters[6].Value = model.BatchNo;

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
		public bool Delete(string BatchNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_PackBatch ");
			strSql.Append(" where BatchNo=@BatchNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,15)			};
			parameters[0].Value = BatchNo;

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
		public bool DeleteList(string BatchNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_PackBatch ");
			strSql.Append(" where BatchNo in ("+BatchNolist + ")  ");
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
        /// 获取总数量
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public int Get_BatchCount(string sqlWhere)
        {
            int tem = 0;
            string strSql = "SELECT SUM(Count) AS Count FROM tb_PackBatch ";
            if (sqlWhere != "") { strSql += " where   " + sqlWhere; }
            int.TryParse(dbs.Query(strSql).Tables[0].Rows[0]["Count"].ToString(), out tem);
            return tem;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.PackBatch GetModel(string BatchNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BatchNo,Count,SackQty,BoxQty,OrderID,State from tb_PackBatch ");
			strSql.Append(" where BatchNo=@BatchNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,15)			};
			parameters[0].Value = BatchNo;

			Maticsoft.Model.PackBatch model=new Maticsoft.Model.PackBatch();
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
		public Maticsoft.Model.PackBatch DataRowToModel(DataRow row)
		{
			Maticsoft.Model.PackBatch model=new Maticsoft.Model.PackBatch();
			if (row != null)
			{
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["Count"]!=null && row["Count"].ToString()!="")
				{
					model.Count=int.Parse(row["Count"].ToString());
				}
				if(row["SackQty"]!=null)
				{
					model.SackQty=row["SackQty"].ToString();
				}
				if(row["BoxQty"]!=null)
				{
					model.BoxQty=row["BoxQty"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
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
			strSql.Append("select BatchNo,Count,SackQty,BoxQty,OrderID,State,ID_Key ");
			strSql.Append(" FROM tb_PackBatch ");
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
			strSql.Append(" BatchNo,Count,SackQty,BoxQty,OrderID,State,ID_Key ");
			strSql.Append(" FROM tb_PackBatch ");
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
			strSql.Append("select count(1) FROM tb_PackBatch ");
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
				strSql.Append("order by T.BatchNo desc");
			}
			strSql.Append(")AS Row, T.*  from tb_PackBatch T ");
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
			parameters[0].Value = "tb_PackBatch";
			parameters[1].Value = "BatchNo";
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

