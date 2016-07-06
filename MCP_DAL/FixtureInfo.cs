using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:FixtureInfo
	/// </summary>
	public partial class FixtureInfo
	{
		public FixtureInfo()
		{}

        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.EquipmentMS);
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal FAY_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_FixtureInfo");
			strSql.Append(" where FAY_ID=@FAY_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FAY_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = FAY_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.FixtureInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_FixtureInfo(");
			strSql.Append("Assembly_BarCode,Assembly_Name,BarCode,Name,Alias,Makedev,Model,FunctionRemarks,SafeCount,Unit,Versions,Up_ID,DrawingPatch,Pic_ID,Correlation_ID,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@Assembly_BarCode,@Assembly_Name,@BarCode,@Name,@Alias,@Makedev,@Model,@FunctionRemarks,@SafeCount,@Unit,@Versions,@Up_ID,@DrawingPatch,@Pic_ID,@Correlation_ID,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Assembly_BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Assembly_Name", SqlDbType.VarChar,50),
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Alias", SqlDbType.VarChar,50),
					new SqlParameter("@Makedev", SqlDbType.VarChar,50),
					new SqlParameter("@Model", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionRemarks", SqlDbType.VarChar,255),
					new SqlParameter("@SafeCount", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@Versions", SqlDbType.VarChar,50),
					new SqlParameter("@Up_ID", SqlDbType.VarChar,50),
					new SqlParameter("@DrawingPatch", SqlDbType.VarChar,255),
					new SqlParameter("@Pic_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Correlation_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255)};
			parameters[0].Value = model.Assembly_BarCode;
			parameters[1].Value = model.Assembly_Name;
			parameters[2].Value = model.BarCode;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Alias;
			parameters[5].Value = model.Makedev;
			parameters[6].Value = model.Model;
			parameters[7].Value = model.FunctionRemarks;
			parameters[8].Value = model.SafeCount;
			parameters[9].Value = model.Unit;
			parameters[10].Value = model.Versions;
			parameters[11].Value = model.Up_ID;
			parameters[12].Value = model.DrawingPatch;
			parameters[13].Value = model.Pic_ID;
			parameters[14].Value = model.Correlation_ID;
			parameters[15].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.FixtureInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_FixtureInfo set ");
			strSql.Append("Assembly_BarCode=@Assembly_BarCode,");
			strSql.Append("Assembly_Name=@Assembly_Name,");
			strSql.Append("BarCode=@BarCode,");
			strSql.Append("Name=@Name,");
			strSql.Append("Alias=@Alias,");
			strSql.Append("Makedev=@Makedev,");
			strSql.Append("Model=@Model,");
			strSql.Append("FunctionRemarks=@FunctionRemarks,");
			strSql.Append("SafeCount=@SafeCount,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Versions=@Versions,");
			strSql.Append("Up_ID=@Up_ID,");
			strSql.Append("DrawingPatch=@DrawingPatch,");
			strSql.Append("Pic_ID=@Pic_ID,");
			strSql.Append("Correlation_ID=@Correlation_ID,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where FAY_ID=@FAY_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Assembly_BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Assembly_Name", SqlDbType.VarChar,50),
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Alias", SqlDbType.VarChar,50),
					new SqlParameter("@Makedev", SqlDbType.VarChar,50),
					new SqlParameter("@Model", SqlDbType.VarChar,50),
					new SqlParameter("@FunctionRemarks", SqlDbType.VarChar,255),
					new SqlParameter("@SafeCount", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@Versions", SqlDbType.VarChar,50),
					new SqlParameter("@Up_ID", SqlDbType.VarChar,50),
					new SqlParameter("@DrawingPatch", SqlDbType.VarChar,255),
					new SqlParameter("@Pic_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Correlation_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255),
					new SqlParameter("@FAY_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Assembly_BarCode;
			parameters[1].Value = model.Assembly_Name;
			parameters[2].Value = model.BarCode;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Alias;
			parameters[5].Value = model.Makedev;
			parameters[6].Value = model.Model;
			parameters[7].Value = model.FunctionRemarks;
			parameters[8].Value = model.SafeCount;
			parameters[9].Value = model.Unit;
			parameters[10].Value = model.Versions;
			parameters[11].Value = model.Up_ID;
			parameters[12].Value = model.DrawingPatch;
			parameters[13].Value = model.Pic_ID;
			parameters[14].Value = model.Correlation_ID;
			parameters[15].Value = model.Remarks;
			parameters[16].Value = model.FAY_ID;

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
		public bool Delete(decimal FAY_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_FixtureInfo ");
			strSql.Append(" where FAY_ID=@FAY_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FAY_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = FAY_ID;

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
		public bool DeleteList(string FAY_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_FixtureInfo ");
			strSql.Append(" where FAY_ID in ("+FAY_IDlist + ")  ");
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
		public Maticsoft.Model.FixtureInfo GetModel(decimal FAY_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FAY_ID,Assembly_BarCode,Assembly_Name,BarCode,Name,Alias,Makedev,Model,FunctionRemarks,SafeCount,Unit,Versions,Up_ID,DrawingPatch,Pic_ID,Correlation_ID,Remarks from tb_FixtureInfo ");
			strSql.Append(" where FAY_ID=@FAY_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FAY_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = FAY_ID;

			Maticsoft.Model.FixtureInfo model=new Maticsoft.Model.FixtureInfo();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FAY_ID"]!=null && ds.Tables[0].Rows[0]["FAY_ID"].ToString()!="")
				{
					model.FAY_ID=decimal.Parse(ds.Tables[0].Rows[0]["FAY_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Assembly_BarCode"]!=null && ds.Tables[0].Rows[0]["Assembly_BarCode"].ToString()!="")
				{
					model.Assembly_BarCode=ds.Tables[0].Rows[0]["Assembly_BarCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Assembly_Name"]!=null && ds.Tables[0].Rows[0]["Assembly_Name"].ToString()!="")
				{
					model.Assembly_Name=ds.Tables[0].Rows[0]["Assembly_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BarCode"]!=null && ds.Tables[0].Rows[0]["BarCode"].ToString()!="")
				{
					model.BarCode=ds.Tables[0].Rows[0]["BarCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Alias"]!=null && ds.Tables[0].Rows[0]["Alias"].ToString()!="")
				{
					model.Alias=ds.Tables[0].Rows[0]["Alias"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Makedev"]!=null && ds.Tables[0].Rows[0]["Makedev"].ToString()!="")
				{
					model.Makedev=ds.Tables[0].Rows[0]["Makedev"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Model"]!=null && ds.Tables[0].Rows[0]["Model"].ToString()!="")
				{
					model.Model=ds.Tables[0].Rows[0]["Model"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FunctionRemarks"]!=null && ds.Tables[0].Rows[0]["FunctionRemarks"].ToString()!="")
				{
					model.FunctionRemarks=ds.Tables[0].Rows[0]["FunctionRemarks"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SafeCount"]!=null && ds.Tables[0].Rows[0]["SafeCount"].ToString()!="")
				{
					model.SafeCount=ds.Tables[0].Rows[0]["SafeCount"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Unit"]!=null && ds.Tables[0].Rows[0]["Unit"].ToString()!="")
				{
					model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Versions"]!=null && ds.Tables[0].Rows[0]["Versions"].ToString()!="")
				{
					model.Versions=ds.Tables[0].Rows[0]["Versions"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Up_ID"]!=null && ds.Tables[0].Rows[0]["Up_ID"].ToString()!="")
				{
					model.Up_ID=ds.Tables[0].Rows[0]["Up_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DrawingPatch"]!=null && ds.Tables[0].Rows[0]["DrawingPatch"].ToString()!="")
				{
					model.DrawingPatch=ds.Tables[0].Rows[0]["DrawingPatch"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pic_ID"]!=null && ds.Tables[0].Rows[0]["Pic_ID"].ToString()!="")
				{
					model.Pic_ID=ds.Tables[0].Rows[0]["Pic_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Correlation_ID"]!=null && ds.Tables[0].Rows[0]["Correlation_ID"].ToString()!="")
				{
					model.Correlation_ID=ds.Tables[0].Rows[0]["Correlation_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remarks"]!=null && ds.Tables[0].Rows[0]["Remarks"].ToString()!="")
				{
					model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
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
        public Maticsoft.Model.FixtureInfo GetModel(string _AssetNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FAY_ID,Assembly_BarCode,Assembly_Name,BarCode,Name,Alias,Makedev,Model,FunctionRemarks,SafeCount,Unit,Versions,Up_ID,DrawingPatch,Pic_ID,Correlation_ID,Remarks from tb_FixtureInfo ");
            strSql.Append(" where Assembly_BarCode=@Assembly_BarCode");
            SqlParameter[] parameters = {
					new SqlParameter("@Assembly_BarCode", SqlDbType.VarChar, 50)
			};
            parameters[0].Value = _AssetNumber;

            Maticsoft.Model.FixtureInfo model = new Maticsoft.Model.FixtureInfo();
            DataSet ds = dbs.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FAY_ID"] != null && ds.Tables[0].Rows[0]["FAY_ID"].ToString() != "")
                {
                    model.FAY_ID = decimal.Parse(ds.Tables[0].Rows[0]["FAY_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Assembly_BarCode"] != null && ds.Tables[0].Rows[0]["Assembly_BarCode"].ToString() != "")
                {
                    model.Assembly_BarCode = ds.Tables[0].Rows[0]["Assembly_BarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Assembly_Name"] != null && ds.Tables[0].Rows[0]["Assembly_Name"].ToString() != "")
                {
                    model.Assembly_Name = ds.Tables[0].Rows[0]["Assembly_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BarCode"] != null && ds.Tables[0].Rows[0]["BarCode"].ToString() != "")
                {
                    model.BarCode = ds.Tables[0].Rows[0]["BarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Alias"] != null && ds.Tables[0].Rows[0]["Alias"].ToString() != "")
                {
                    model.Alias = ds.Tables[0].Rows[0]["Alias"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Makedev"] != null && ds.Tables[0].Rows[0]["Makedev"].ToString() != "")
                {
                    model.Makedev = ds.Tables[0].Rows[0]["Makedev"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Model"] != null && ds.Tables[0].Rows[0]["Model"].ToString() != "")
                {
                    model.Model = ds.Tables[0].Rows[0]["Model"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FunctionRemarks"] != null && ds.Tables[0].Rows[0]["FunctionRemarks"].ToString() != "")
                {
                    model.FunctionRemarks = ds.Tables[0].Rows[0]["FunctionRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SafeCount"] != null && ds.Tables[0].Rows[0]["SafeCount"].ToString() != "")
                {
                    model.SafeCount = ds.Tables[0].Rows[0]["SafeCount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Unit"] != null && ds.Tables[0].Rows[0]["Unit"].ToString() != "")
                {
                    model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Versions"] != null && ds.Tables[0].Rows[0]["Versions"].ToString() != "")
                {
                    model.Versions = ds.Tables[0].Rows[0]["Versions"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Up_ID"] != null && ds.Tables[0].Rows[0]["Up_ID"].ToString() != "")
                {
                    model.Up_ID = ds.Tables[0].Rows[0]["Up_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DrawingPatch"] != null && ds.Tables[0].Rows[0]["DrawingPatch"].ToString() != "")
                {
                    model.DrawingPatch = ds.Tables[0].Rows[0]["DrawingPatch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic_ID"] != null && ds.Tables[0].Rows[0]["Pic_ID"].ToString() != "")
                {
                    model.Pic_ID = ds.Tables[0].Rows[0]["Pic_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Correlation_ID"] != null && ds.Tables[0].Rows[0]["Correlation_ID"].ToString() != "")
                {
                    model.Correlation_ID = ds.Tables[0].Rows[0]["Correlation_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
			strSql.Append("select FAY_ID,Assembly_BarCode,Assembly_Name,BarCode,Name,Alias,Makedev,Model,FunctionRemarks,SafeCount,Unit,Versions,Up_ID,DrawingPatch,Pic_ID,Correlation_ID,Remarks ");
			strSql.Append(" FROM tb_FixtureInfo ");
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
			strSql.Append(" FAY_ID,Assembly_BarCode,Assembly_Name,BarCode,Name,Alias,Makedev,Model,FunctionRemarks,SafeCount,Unit,Versions,Up_ID,DrawingPatch,Pic_ID,Correlation_ID,Remarks ");
			strSql.Append(" FROM tb_FixtureInfo ");
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
			strSql.Append("select count(1) FROM tb_FixtureInfo ");
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
				strSql.Append("order by T.FAY_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_FixtureInfo T ");
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
			parameters[0].Value = "tb_FixtureInfo";
			parameters[1].Value = "FAY_ID";
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

