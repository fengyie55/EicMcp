using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ImageList
	/// </summary>
	public partial class ImageList
	{
		public ImageList()
		{}
		#region  Method

        DbHelperSQL dbs = new DbHelperSQL();

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ImageList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ImageList(");
			strSql.Append("Name,Remarks,Im)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Remarks,@Im)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255),
					new SqlParameter("@Im", SqlDbType.Image)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Remarks;
			parameters[2].Value = model.Im;

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
		public bool Update(Maticsoft.Model.ImageList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ImageList set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("Im=@Im");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255),
					new SqlParameter("@Im", SqlDbType.Image),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Remarks;
			parameters[2].Value = model.Im;
			parameters[3].Value = model.ID;

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
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ImageList ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ImageList ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.ImageList GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Remarks,Im from tb_ImageList ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.ImageList model=new Maticsoft.Model.ImageList();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remarks"]!=null && ds.Tables[0].Rows[0]["Remarks"].ToString()!="")
				{
					model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Im"]!=null && ds.Tables[0].Rows[0]["Im"].ToString()!="")
				{
					model.Im=(byte[])ds.Tables[0].Rows[0]["Im"];
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
        public Maticsoft.Model.ImageList GetModel(string sqlWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Remarks,Im from tb_ImageList ");
            if (sqlWhere != "")
            {
                strSql.Append(" where " + sqlWhere);
            }

            Maticsoft.Model.ImageList model = new Maticsoft.Model.ImageList();
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = decimal.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Im"] != null && ds.Tables[0].Rows[0]["Im"].ToString() != "")
                {
                    model.Im = (byte[])ds.Tables[0].Rows[0]["Im"];
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
			strSql.Append("select ID,Name,Remarks,Im ");
			strSql.Append(" FROM tb_ImageList ");
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
			strSql.Append(" ID,Name,Remarks,Im ");
			strSql.Append(" FROM tb_ImageList ");
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
			strSql.Append("select count(1) FROM tb_ImageList ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_ImageList T ");
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
			parameters[0].Value = "tb_ImageList";
			parameters[1].Value = "ID";
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

