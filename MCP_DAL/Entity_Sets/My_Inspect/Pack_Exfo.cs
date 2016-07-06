using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using System.Collections;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Pack_Exfo
	/// </summary>
	public partial class Pack_Exfo
	{
		public Pack_Exfo()
		{}
		#region  BasicMethod
        DbHelperSQL dbs = new DbHelperSQL();


        /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string BatchNo, Maticsoft.Model.E_InspectMethod _InspectMethod)
        {

            if (_InspectMethod == Model.E_InspectMethod.TFK十二芯检测x2)
            {
                string strSql = " SELECT   tb_Pack_3D.ClientSN, tb_Pack_3D.SN, tb_Pack_3D.Name, tb_Pack_3D.Type, tb_Pack_3D.Result, ";
                strSql += " tb_Pack_3D.Curvature, tb_Pack_3D.Curvature_Result, tb_Pack_3D.Spherical, tb_Pack_3D.Spherical_Result, ";
                strSql += "tb_Pack_3D.Apex_Offset, tb_Pack_3D.Apex_Offset_Result, tb_Pack_3D.Tilt_Angle, tb_Pack_3D.Tilt_Angle_Result,";
                strSql += " tb_Pack_3D.Test_Date, tb_Pack_3D.Test_Time, tb_Pack_3D.PackDate ,tb_PrintRecord.LabellMode ";
                strSql += " FROM tb_Pack_3D LEFT OUTER JOIN  tb_PrintRecord ON tb_Pack_3D.ClientSN = tb_PrintRecord.SN ";
                strSql += " Where tb_PrintRecord.BatchNo='" + BatchNo + "'";
                return dbs.Query(strSql);
            }
            else if (_InspectMethod == Model.E_InspectMethod.配组_四十八芯 ||
             _InspectMethod == Model.E_InspectMethod.配组_九十六芯 ||
            _InspectMethod == Model.E_InspectMethod.配组_二十四芯)
            {
                string strSql = "SELECT ClientSN, CONVERT(int, Name) AS Name,  Type, Result, Curvature, Curvature_Result,";
                strSql += " Spherical, Spherical_Result, Apex_Offset, Apex_Offset_Result, Tilt_Angle,Tilt_Angle_Result, Test_Date, Test_Time  ";
                strSql += " FROM tb_Pack_3D WHERE (ClientSN = '" + BatchNo + "')  ORDER BY ClientSN, Name";
                return dbs.Query(strSql);
            }          
            else //if (_InspectMethod == Model.E_InspectMethod.配组_八芯)
            {
                string strSql = " SELECT tb_Pack_Exfo.SN, IL_A, Refl_A FROM tb_Pack_Exfo LEFT OUTER JOIN   ";
                strSql += " tb_SerialNumber ON tb_Pack_Exfo.SN = tb_SerialNumber.SN  ";
                strSql += " WHERE (tb_SerialNumber.BatchNO = '"+BatchNo+"') AND (tb_SerialNumber.State = 'Yet_Pack') "; 
                    
               // strSql += " Where BatchNo='" + BatchNo + "'";
                return dbs.Query(strSql);
            }

        }

        
         /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string ClientSN)
        {
            string strSql = " SELECT ClientSN AS SN, PartNumber AS Name, IL_A, Refl_A FROM tb_Pack_Exfo WHERE (ClientSN = '"+ClientSN+"') ";
            // strSql += " Where BatchNo='" + BatchNo + "'";
            return dbs.Query(strSql);
        }


        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack(My_GetTestData.UpDataEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int _temRecord = 0;
            foreach (DataRow dr in e.TestData.Tables[0].Rows)
            {
                Maticsoft.Model.Pack_Exfo PK_Exfo = DataRowToModel_NotPack(dr);
                PK_Exfo.OrderID = e.WorkOrder.OrderID;
                PK_Exfo.BatchNo = e.BatchNo;
                PK_Exfo.ClientSN = e.ClientSN;
                PK_Exfo.PackDate = dt;
                dbs.Exists("delete from tb_Pack_Exfo WHERE SN ='" + PK_Exfo.SN + "' AND PartNumber= '" + PK_Exfo.PartNumber + "' AND Wave = '" + PK_Exfo.Wave + "'");
                if (!Add(PK_Exfo)) //返回更新结果
                {
                    ++_temRecord;
                }
            }
            /*
            if (_temRecord != 0)
            {
                e.Result = false;
            }
            else { e.Result = true; }
             */
        }

        /// <summary>
        /// 两码两标签 数据添加
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack_TwoSnTwoLab(My_GetTestData.UpDataEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int _temRecord = 0;
            foreach (DataRow dr in e.TestData.Tables[0].Rows)
            {
                Maticsoft.Model.Pack_Exfo PK_Exfo = DataRowToModel_NotPack(dr);
                PK_Exfo.OrderID = e.WorkOrder.OrderID;
                PK_Exfo.BatchNo = e.BatchNo;
                PK_Exfo.ClientSN = dr["SN"].ToString();
                PK_Exfo.PackDate = dt;
                dbs.Exists("delete from tb_Pack_Exfo WHERE SN ='" + PK_Exfo.SN + "' AND Wave = '" + PK_Exfo.Wave + "'");
                if (!Add(PK_Exfo)) //返回更新结果
                {
                    ++_temRecord;
                }
            }
        }


        /// <summary>
        /// 返回已经包装的线号（主要用于配组线材类型）
        /// </summary>
        /// <param name="_clientSN">客户编码</param>
        /// <returns></returns>
        public ArrayList Get_ClientPigtailNumber(string _clientSN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT SUBSTRING(SN, 12, 2) AS PigtailNum FROM tb_Pack_Exfo");
            strSql.Append(" WHERE (ClientSN = '" + _clientSN + "')");
            DataSet ds = dbs.Query(strSql.ToString());
            ArrayList tem = new ArrayList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tem.Add(ds.Tables[0].Rows[i]["PigtailNum"].ToString());
            }
            return tem;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Pack_Exfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Pack_Exfo(");
			strSql.Append("TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName)");
			strSql.Append(" values (");
			strSql.Append("@TestDate,@PartNumber,@SN,@Result,@Wave,@IL_A,@Refl_A,@IL_B,@Refl_B,@ClientSN,@OrderID,@BatchNo,@PackDate,@CustomerName)");
            SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10),
                    new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,35),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.DateTime),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,25)};

			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;
            parameters[9].Value = model.ClientSN;
			parameters[10].Value = model.OrderID;
			parameters[11].Value = model.BatchNo;
			parameters[12].Value = model.PackDate;
			parameters[13].Value = model.CustomerName;
			

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
		public bool Update(Maticsoft.Model.Pack_Exfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Pack_Exfo set ");
			strSql.Append("TestDate=@TestDate,");
			strSql.Append("PartNumber=@PartNumber,");
			strSql.Append("SN=@SN,");
			strSql.Append("Result=@Result,");
			strSql.Append("Wave=@Wave,");
			strSql.Append("IL_A=@IL_A,");
			strSql.Append("Refl_A=@Refl_A,");
			strSql.Append("IL_B=@IL_B,");
			strSql.Append("Refl_B=@Refl_B,");
            strSql.Append("ClientSN=@ClientSN,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("PackDate=@PackDate,");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10),
                    new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,35),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.DateTime),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,25),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;
            parameters[9].Value = model.ClientSN;
			parameters[10].Value = model.OrderID;
			parameters[11].Value = model.BatchNo;
			parameters[12].Value = model.PackDate;
			parameters[13].Value = model.CustomerName;
			parameters[14].Value = model.ID_Key;

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
		public bool Delete(string sqlWhere)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Pack_Exfo ");
			strSql.Append(" where "+sqlWhere+"");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Pack_Exfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key from tb_Pack_Exfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.Pack_Exfo model=new Maticsoft.Model.Pack_Exfo();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel_NotPack(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体 从未包装数据中 主要用于更新数据 
		/// </summary>
		public Maticsoft.Model.Pack_Exfo DataRowToModel_NotPack(DataRow row)
		{
			Maticsoft.Model.Pack_Exfo model=new Maticsoft.Model.Pack_Exfo();
			if (row != null)
			{
				if(row["TestDate"]!=null)
				{
					model.TestDate=row["TestDate"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.PartNumber=row["Name"].ToString();
				}
				if(row["SN"]!=null && row["SN"].ToString()!="")
				{
					model.SN= row["SN"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Wave"]!=null)
				{
					model.Wave=row["Wave"].ToString();
				}
				if(row["IL_A"]!=null)
				{
					model.IL_A=row["IL_A"].ToString();
				}
				if(row["Refl_A"]!=null)
				{
					model.Refl_A=row["Refl_A"].ToString();
				}
				if(row["IL_B"]!=null)
				{
					model.IL_B=row["IL_B"].ToString();
				}
				if(row["Refl_B"]!=null)
				{
					model.Refl_B=row["Refl_B"].ToString();
				}
                /*
                if (row["ClientSN"] != null)
                {
                    model.Refl_B = row["ClientSN"].ToString();
                }
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["PackDate"]!=null && row["PackDate"].ToString()!="")
				{
					model.PackDate=DateTime.Parse(row["PackDate"].ToString());
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
                 */
			}
			return model;
		}

        /// <summary>
        /// 得到一个对象实体 从已包装数据中
        /// </summary>
        public Maticsoft.Model.Pack_Exfo DataRowToModel_YetPack(DataRow row)
        {
            Maticsoft.Model.Pack_Exfo model = new Maticsoft.Model.Pack_Exfo();
            if (row != null)
            {
                if (row["TestDate"] != null)
                {
                    model.TestDate = row["TestDate"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.PartNumber = row["Name"].ToString();
                }
                if (row["SN"] != null && row["SN"].ToString() != "")
                {
                    model.SN = row["SN"].ToString();
                }
                if (row["Result"] != null)
                {
                    model.Result = row["Result"].ToString();
                }
                if (row["Wave"] != null)
                {
                    model.Wave = row["Wave"].ToString();
                }
                if (row["IL_A"] != null)
                {
                    model.IL_A = row["IL_A"].ToString();
                }
                if (row["Refl_A"] != null)
                {
                    model.Refl_A = row["Refl_A"].ToString();
                }
                if (row["IL_B"] != null)
                {
                    model.IL_B = row["IL_B"].ToString();
                }
                if (row["Refl_B"] != null)
                {
                    model.Refl_B = row["Refl_B"].ToString();
                }
                /*
                if (row["ClientSN"] != null)
                {
                    model.Refl_B = row["ClientSN"].ToString();
                }
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["PackDate"]!=null && row["PackDate"].ToString()!="")
				{
					model.PackDate=DateTime.Parse(row["PackDate"].ToString());
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
                 */
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName ");
			strSql.Append(" FROM tb_Pack_Exfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据集 MPO
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataSet GetMPOList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ClientSN, SN, PartNumber, Result, Wave, ABS(IL_A) AS IL_A, ABS(Refl_A) AS Refl_A  FROM tb_Pack_Exfo ");            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY ClientSN, SN, CONVERT(int, PartNumber) ");
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
			strSql.Append(" TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key ");
			strSql.Append(" FROM tb_Pack_Exfo ");
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
			strSql.Append("select count(1) FROM tb_Pack_Exfo ");
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
			strSql.Append(")AS Row, T.*  from tb_Pack_Exfo T ");
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
			parameters[0].Value = "tb_Pack_Exfo";
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

