/* AdapterTestData.cs
*
* 功 能： N/A
* 类 名： AdapterTestData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-3-26 13:54:41   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　│
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
	/// 数据访问类:AdapterTestData
	/// </summary>
	public partial class AdapterTestData
	{
		public AdapterTestData()
		{}
		#region  BasicMethod
        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.ToLine);


        /// <summary>
        /// 获取SPC数据
        /// </summary>
        public DataSet Get_SPC(string _Date)
        {
            string Sql = "  SELECT (TestRL1 + TestRL2 + TestRL3 + TestRL4 + TestRL5) / 5 AS IL , Testfour0, Testfour90, Testfour180, Testfour270,";
            Sql += " CONVERT(varchar(100), TestTime, 23) AS Test_Date, NEWID() AS Random  ";
            Sql += " FROM AdapterTestData  ";
            Sql += " WHERE (CONVERT(varchar(100), TestTime, 23) = '"+_Date+"')  ";
            Sql += " ORDER BY Random  ";
            return dbs.Query(Sql);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID_key)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdapterTestData");
			strSql.Append(" where ID_key=@ID_key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_key;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.AdapterTestData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AdapterTestData(");
			strSql.Append("OrderID,ProductName,TestRL1,TestRL2,TestRL3,TestRL4,TestRL5,ModelRl,Testfour0,Testfour90,Testfour180,Testfour270,ModelFour,TestTime,SCLine,P_Value,BR_Value,RecordTestOp,MachineID,MachineName,TestResult)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@ProductName,@TestRL1,@TestRL2,@TestRL3,@TestRL4,@TestRL5,@ModelRl,@Testfour0,@Testfour90,@Testfour180,@Testfour270,@ModelFour,@TestTime,@SCLine,@P_Value,@BR_Value,@RecordTestOp,@MachineID,@MachineName,@TestResult)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@ProductName", SqlDbType.VarChar,50),
					new SqlParameter("@TestRL1", SqlDbType.Float,8),
					new SqlParameter("@TestRL2", SqlDbType.Float,8),
					new SqlParameter("@TestRL3", SqlDbType.Float,8),
					new SqlParameter("@TestRL4", SqlDbType.Float,8),
					new SqlParameter("@TestRL5", SqlDbType.Float,8),
					new SqlParameter("@ModelRl", SqlDbType.Float,8),
					new SqlParameter("@Testfour0", SqlDbType.Float,8),
					new SqlParameter("@Testfour90", SqlDbType.Float,8),
					new SqlParameter("@Testfour180", SqlDbType.Float,8),
					new SqlParameter("@Testfour270", SqlDbType.Float,8),
					new SqlParameter("@ModelFour", SqlDbType.Float,8),
					new SqlParameter("@TestTime", SqlDbType.SmallDateTime),
					new SqlParameter("@SCLine", SqlDbType.VarChar,30),
					new SqlParameter("@P_Value", SqlDbType.VarChar,20),
					new SqlParameter("@BR_Value", SqlDbType.VarChar,20),
					new SqlParameter("@RecordTestOp", SqlDbType.VarChar,30),
					new SqlParameter("@MachineID", SqlDbType.VarChar,30),
					new SqlParameter("@MachineName", SqlDbType.VarChar,20),
					new SqlParameter("@TestResult", SqlDbType.VarChar,10)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.TestRL1;
			parameters[3].Value = model.TestRL2;
			parameters[4].Value = model.TestRL3;
			parameters[5].Value = model.TestRL4;
			parameters[6].Value = model.TestRL5;
			parameters[7].Value = model.ModelRl;
			parameters[8].Value = model.Testfour0;
			parameters[9].Value = model.Testfour90;
			parameters[10].Value = model.Testfour180;
			parameters[11].Value = model.Testfour270;
			parameters[12].Value = model.ModelFour;
			parameters[13].Value = model.TestTime;
			parameters[14].Value = model.SCLine;
			parameters[15].Value = model.P_Value;
			parameters[16].Value = model.BR_Value;
			parameters[17].Value = model.RecordTestOp;
			parameters[18].Value = model.MachineID;
			parameters[19].Value = model.MachineName;
			parameters[20].Value = model.TestResult;

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
		public bool Update(Maticsoft.Model.AdapterTestData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AdapterTestData set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("TestRL1=@TestRL1,");
			strSql.Append("TestRL2=@TestRL2,");
			strSql.Append("TestRL3=@TestRL3,");
			strSql.Append("TestRL4=@TestRL4,");
			strSql.Append("TestRL5=@TestRL5,");
			strSql.Append("ModelRl=@ModelRl,");
			strSql.Append("Testfour0=@Testfour0,");
			strSql.Append("Testfour90=@Testfour90,");
			strSql.Append("Testfour180=@Testfour180,");
			strSql.Append("Testfour270=@Testfour270,");
			strSql.Append("ModelFour=@ModelFour,");
			strSql.Append("TestTime=@TestTime,");
			strSql.Append("SCLine=@SCLine,");
			strSql.Append("P_Value=@P_Value,");
			strSql.Append("BR_Value=@BR_Value,");
			strSql.Append("RecordTestOp=@RecordTestOp,");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("MachineName=@MachineName,");
			strSql.Append("TestResult=@TestResult");
			strSql.Append(" where ID_key=@ID_key");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@ProductName", SqlDbType.VarChar,50),
					new SqlParameter("@TestRL1", SqlDbType.Float,8),
					new SqlParameter("@TestRL2", SqlDbType.Float,8),
					new SqlParameter("@TestRL3", SqlDbType.Float,8),
					new SqlParameter("@TestRL4", SqlDbType.Float,8),
					new SqlParameter("@TestRL5", SqlDbType.Float,8),
					new SqlParameter("@ModelRl", SqlDbType.Float,8),
					new SqlParameter("@Testfour0", SqlDbType.Float,8),
					new SqlParameter("@Testfour90", SqlDbType.Float,8),
					new SqlParameter("@Testfour180", SqlDbType.Float,8),
					new SqlParameter("@Testfour270", SqlDbType.Float,8),
					new SqlParameter("@ModelFour", SqlDbType.Float,8),
					new SqlParameter("@TestTime", SqlDbType.SmallDateTime),
					new SqlParameter("@SCLine", SqlDbType.VarChar,30),
					new SqlParameter("@P_Value", SqlDbType.VarChar,20),
					new SqlParameter("@BR_Value", SqlDbType.VarChar,20),
					new SqlParameter("@RecordTestOp", SqlDbType.VarChar,30),
					new SqlParameter("@MachineID", SqlDbType.VarChar,30),
					new SqlParameter("@MachineName", SqlDbType.VarChar,20),
					new SqlParameter("@TestResult", SqlDbType.VarChar,10),
					new SqlParameter("@ID_key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.TestRL1;
			parameters[3].Value = model.TestRL2;
			parameters[4].Value = model.TestRL3;
			parameters[5].Value = model.TestRL4;
			parameters[6].Value = model.TestRL5;
			parameters[7].Value = model.ModelRl;
			parameters[8].Value = model.Testfour0;
			parameters[9].Value = model.Testfour90;
			parameters[10].Value = model.Testfour180;
			parameters[11].Value = model.Testfour270;
			parameters[12].Value = model.ModelFour;
			parameters[13].Value = model.TestTime;
			parameters[14].Value = model.SCLine;
			parameters[15].Value = model.P_Value;
			parameters[16].Value = model.BR_Value;
			parameters[17].Value = model.RecordTestOp;
			parameters[18].Value = model.MachineID;
			parameters[19].Value = model.MachineName;
			parameters[20].Value = model.TestResult;
			parameters[21].Value = model.ID_key;

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
		public bool Delete(decimal ID_key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdapterTestData ");
			strSql.Append(" where ID_key=@ID_key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_key;

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
		public bool DeleteList(string ID_keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AdapterTestData ");
			strSql.Append(" where ID_key in ("+ID_keylist + ")  ");
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
		public Maticsoft.Model.AdapterTestData GetModel(decimal ID_key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,ProductName,TestRL1,TestRL2,TestRL3,TestRL4,TestRL5,ModelRl,Testfour0,Testfour90,Testfour180,Testfour270,ModelFour,TestTime,SCLine,P_Value,BR_Value,RecordTestOp,MachineID,MachineName,TestResult,ID_key from AdapterTestData ");
			strSql.Append(" where ID_key=@ID_key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_key;

			Maticsoft.Model.AdapterTestData model=new Maticsoft.Model.AdapterTestData();
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
		public Maticsoft.Model.AdapterTestData DataRowToModel(DataRow row)
		{
			Maticsoft.Model.AdapterTestData model=new Maticsoft.Model.AdapterTestData();
			if (row != null)
			{
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["TestRL1"]!=null && row["TestRL1"].ToString()!="")
				{
					model.TestRL1=decimal.Parse(row["TestRL1"].ToString());
				}
				if(row["TestRL2"]!=null && row["TestRL2"].ToString()!="")
				{
					model.TestRL2=decimal.Parse(row["TestRL2"].ToString());
				}
				if(row["TestRL3"]!=null && row["TestRL3"].ToString()!="")
				{
					model.TestRL3=decimal.Parse(row["TestRL3"].ToString());
				}
				if(row["TestRL4"]!=null && row["TestRL4"].ToString()!="")
				{
					model.TestRL4=decimal.Parse(row["TestRL4"].ToString());
				}
				if(row["TestRL5"]!=null && row["TestRL5"].ToString()!="")
				{
					model.TestRL5=decimal.Parse(row["TestRL5"].ToString());
				}
				if(row["ModelRl"]!=null && row["ModelRl"].ToString()!="")
				{
					model.ModelRl=decimal.Parse(row["ModelRl"].ToString());
				}
				if(row["Testfour0"]!=null && row["Testfour0"].ToString()!="")
				{
					model.Testfour0=decimal.Parse(row["Testfour0"].ToString());
				}
				if(row["Testfour90"]!=null && row["Testfour90"].ToString()!="")
				{
					model.Testfour90=decimal.Parse(row["Testfour90"].ToString());
				}
				if(row["Testfour180"]!=null && row["Testfour180"].ToString()!="")
				{
					model.Testfour180=decimal.Parse(row["Testfour180"].ToString());
				}
				if(row["Testfour270"]!=null && row["Testfour270"].ToString()!="")
				{
					model.Testfour270=decimal.Parse(row["Testfour270"].ToString());
				}
				if(row["ModelFour"]!=null && row["ModelFour"].ToString()!="")
				{
					model.ModelFour=decimal.Parse(row["ModelFour"].ToString());
				}
				if(row["TestTime"]!=null && row["TestTime"].ToString()!="")
				{
					model.TestTime=DateTime.Parse(row["TestTime"].ToString());
				}
				if(row["SCLine"]!=null)
				{
					model.SCLine=row["SCLine"].ToString();
				}
				if(row["P_Value"]!=null)
				{
					model.P_Value=row["P_Value"].ToString();
				}
				if(row["BR_Value"]!=null)
				{
					model.BR_Value=row["BR_Value"].ToString();
				}
				if(row["RecordTestOp"]!=null)
				{
					model.RecordTestOp=row["RecordTestOp"].ToString();
				}
				if(row["MachineID"]!=null)
				{
					model.MachineID=row["MachineID"].ToString();
				}
				if(row["MachineName"]!=null)
				{
					model.MachineName=row["MachineName"].ToString();
				}
				if(row["TestResult"]!=null)
				{
					model.TestResult=row["TestResult"].ToString();
				}
				if(row["ID_key"]!=null && row["ID_key"].ToString()!="")
				{
					model.ID_key=decimal.Parse(row["ID_key"].ToString());
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
			strSql.Append("select OrderID,ProductName,TestRL1,TestRL2,TestRL3,TestRL4,TestRL5,ModelRl,Testfour0,Testfour90,Testfour180,Testfour270,ModelFour,TestTime,SCLine,P_Value,BR_Value,RecordTestOp,MachineID,MachineName,TestResult,ID_key ");
			strSql.Append(" FROM AdapterTestData ");
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
			strSql.Append(" OrderID,ProductName,TestRL1,TestRL2,TestRL3,TestRL4,TestRL5,ModelRl,Testfour0,Testfour90,Testfour180,Testfour270,ModelFour,TestTime,SCLine,P_Value,BR_Value,RecordTestOp,MachineID,MachineName,TestResult,ID_key ");
			strSql.Append(" FROM AdapterTestData ");
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
			strSql.Append("select count(1) FROM AdapterTestData ");
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
				strSql.Append("order by T.ID_key desc");
			}
			strSql.Append(")AS Row, T.*  from AdapterTestData T ");
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
			parameters[0].Value = "AdapterTestData";
			parameters[1].Value = "ID_key";
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

