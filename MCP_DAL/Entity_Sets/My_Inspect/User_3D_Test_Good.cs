/*
* User_3D_Test_Good.cs
*
* 功 能： 3D数据查询更新
* 类 名： User_3D_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-31 11:06:00   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人                    　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using System.Collections;//Please add references

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:User_3D_Test_Good
	/// </summary>
	public partial class User_3D_Test_Good
	{
		public User_3D_Test_Good()
		{}
        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.ToLine);

         /// <summary>
         /// 获取 SPC数据
         /// </summary>
         /// <param name="_Date">日期</param>
        public DataSet Get_SPC(string _Date,string Type)
        {
            string Sql = "  SELECT TOP (125) (CASE LEFT(Type, 3) WHEN 'APC' THEN 'APC' ELSE 'PC' END) AS Type,   ";
            Sql += " Result, Curvature, Spherical, Apex_Offset, Tilt_Angle, CONVERT(varchar(100),  ";
            Sql += " Test_Date, 23) AS Test_Date, Test_Time, NEWID() AS Random  ";
            Sql += " FROM User_3D_Test_Good   ";
            Sql += " WHERE (Test_Date = '"+_Date+"') AND ((CASE LEFT(Type, 3)  ";
            Sql += " WHEN 'APC' THEN 'APC' ELSE 'PC' END) = '"+Type+"')  ";
            Sql += " ORDER BY Random    ";
            return dbs.Query(Sql);
        }




        #region Getdata_Method
        //--------------------------------------------------------------------------------------------
        //   名称：获取数据
        //   功能：获取测试数据
        //   日期：2014-02-25 13:37
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// 多芯查询 有IN条件
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_Multicore(My_GetTestData.GetDataEventArgs e)
        {
            string sql = "SELECT * ";
            sql += " FROM (SELECT TOP (100) PERCENT LEFT(SN, 13) AS SN, SUBSTRING(SN, 15, 2) AS Name, Type,";
            sql += " Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Planar,";
            sql += " Planar_Result, Apex_Offset, Apex_Offset_Result, Bearing, Bearing_Result,";
            sql += " Apex_Angle, Apex_Angle_Result, Tilt_Offset, Tilt_Offset_Result, Tilt_Angle,";
            sql += " Tilt_Angle_Result, KeyError, KeyError_Result, FiberRq, FiberRq_Result,";
            sql += " FiberRa, FiberRa_Result, FerruleRq, FerruleRq_Result, FerruleRa,";
            sql += " FerruleRa_Result, Diameter, Diameter_Result, Test_Date, Test_Time, D, E, F,A,SUBSTRING(SN, 12, 2) AS PigtailNum";
            sql += " FROM User_3D_Test_Good";
            sql += " WHERE " + e.sqlWhere + " AND (Result LIKE N'%PASS%') ";
            sql += " ORDER BY Name) AS User3dGood";
            e.TestData = dbs.Query(sql);
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                e.PigtailList = GetPigtailList(e.TestData);
            }           
        }
        /// <summary>
        /// 双并查询 有IN条件
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_TwainCore(My_GetTestData.GetDataEventArgs e)
        {
            string sql = " SELECT TOP (100) PERCENT LEFT(SN, 13) AS SN, SUBSTRING(SN, 12, 2) AS Name, Type, ";
            sql += " Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Planar, ";
            sql += " Planar_Result, Apex_Offset, Apex_Offset_Result, Bearing, Bearing_Result, ";
            sql += " Apex_Angle, Apex_Angle_Result, Tilt_Offset, Tilt_Offset_Result, Tilt_Angle, ";
            sql += "  Tilt_Angle_Result, KeyError, KeyError_Result, FiberRq, FiberRq_Result, FiberRa, ";
            sql += " FiberRa_Result, FerruleRq, FerruleRq_Result, FerruleRa, FerruleRa_Result, ";
            sql += " Diameter, Diameter_Result, Test_Date, Test_Time, D, E, F, A ";
            sql += " FROM User_3D_Test_Good ";
            sql += " WHERE " + e.sqlWhere + " AND (Result LIKE N'%PASS%') ";
            e.TestData = dbs.Query(sql);
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                e.PigtailList = GetPigtailList(e.TestData);
            } 
        }
        /// <summary>
        /// TFK十二芯检测x2
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_twentyFour(My_GetTestData.GetDataEventArgs e)
        {
            string sql = " SELECT TOP (100) PERCENT LEFT(SN, 13) AS SN, SUBSTRING(SN, 12, 5) AS Name, Type, ";
            sql += " Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Planar, ";
            sql += " Planar_Result, Apex_Offset, Apex_Offset_Result, Bearing, Bearing_Result, ";
            sql += " Apex_Angle, Apex_Angle_Result, Tilt_Offset, Tilt_Offset_Result, Tilt_Angle, ";
            sql += "  Tilt_Angle_Result, KeyError, KeyError_Result, FiberRq, FiberRq_Result, FiberRa, ";
            sql += " FiberRa_Result, FerruleRq, FerruleRq_Result, FerruleRa, FerruleRa_Result, ";
            sql += " Diameter, Diameter_Result, Test_Date, Test_Time, D, E, F, A ";
            sql += " FROM User_3D_Test_Good ";
            sql += " WHERE " + e.sqlWhere + " AND (Result LIKE N'%PASS%') ";
            e.TestData = dbs.Query(sql);
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                e.PigtailList = GetPigtailList(e.TestData);
            }      
        }
        /// <summary>
        /// 单芯查询 无 IN条件
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_OneCore(My_GetTestData.GetDataEventArgs e)
        {
            string sql = " SELECT TOP (100) PERCENT LEFT(SN, 10) AS SN, SUBSTRING(SN, 12, 2) AS Name, Type, ";
            sql += " Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Planar, ";
            sql += " Planar_Result, Apex_Offset, Apex_Offset_Result, Bearing, Bearing_Result, ";
            sql += " Apex_Angle, Apex_Angle_Result, Tilt_Offset, Tilt_Offset_Result, Tilt_Angle, ";
            sql += "  Tilt_Angle_Result, KeyError, KeyError_Result, FiberRq, FiberRq_Result, FiberRa, ";
            sql += " FiberRa_Result, FerruleRq, FerruleRq_Result, FerruleRa, FerruleRa_Result, ";
            sql += " Diameter, Diameter_Result, Test_Date, Test_Time, D, E, F, A ,SUBSTRING(SN, 1, 1) AS PigtailNum";
            sql += " FROM User_3D_Test_Good ";
            sql += " WHERE " + e.sqlWhere + " AND (Result LIKE N'%PASS%') ";
            e.TestData = dbs.Query(sql);
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                ArrayList temAl = new ArrayList();
                temAl.Add("1");
                e.PigtailList = temAl;
            }
        }

        /// <summary>
        /// 两码两标签 查询方法
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_TwoSnToLab(My_GetTestData.GetDataEventArgs e)
        {
            string sql = " SELECT TOP (100) PERCENT LEFT(SN, 10) AS SN, LEFT(SN, 10)  AS Name, Type, ";
            sql += " Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Planar, ";
            sql += " Planar_Result, Apex_Offset, Apex_Offset_Result, Bearing, Bearing_Result, ";
            sql += " Apex_Angle, Apex_Angle_Result, Tilt_Offset, Tilt_Offset_Result, Tilt_Angle, ";
            sql += "  Tilt_Angle_Result, KeyError, KeyError_Result, FiberRq, FiberRq_Result, FiberRa, ";
            sql += " FiberRa_Result, FerruleRq, FerruleRq_Result, FerruleRa, FerruleRa_Result, ";
            sql += " Diameter, Diameter_Result, Test_Date, Test_Time, D, E, F, A ,SUBSTRING(SN, 1, 1) AS PigtailNum";
            sql += " FROM User_3D_Test_Good ";
            sql += " WHERE " + e.sqlWhere + " AND (Result LIKE N'%PASS%') ";
            e.TestData = dbs.Query(sql);
            if (e.TestData.Tables[0].Rows.Count > 0)
            {               
                e.PigtailList = GetPigtailList(e.TestData);
            }
        }


     
        /// <summary>
        /// 获取用户测试数据数组
        /// </summary>
        /// <param name="user_ds_SN">DataSet 用户SN编码</param>
        /// <param name="_statsub">提取字符 串的起始位置</param>
        /// <returns></returns>
        private ArrayList GetPigtailList(DataSet user_ds_SN, int _statsub)
        {
            ArrayList tem = new ArrayList();
            foreach (DataRow dr in user_ds_SN.Tables[0].Rows)
            {
                string temT = dr["SN"].ToString();
                if (temT.Length > _statsub)
                {
                    tem.Add(temT.Substring(_statsub, 2));
                }
            }
            return tem;
        }
        /// <summary>
        /// 获取用户测试数据数组  _Name
        /// </summary>
        /// <param name="user_ds_SN">DataSet 用户SN编码</param>
        /// <returns></returns>
        private ArrayList GetPigtailList(DataSet user_ds_SN)
        {
            ArrayList tem = new ArrayList();
            foreach (DataRow dr in user_ds_SN.Tables[0].Rows)
            {               
                    tem.Add(dr["Name"].ToString());
            }
            return tem;
        }

        #endregion




        //--------------------------------------------------------------------------------------------
        //   名称：获取数据
        //   功能：获取测试数据
        //   日期：2014-02-25 13:37
        //--------------------------------------------------------------------------------------------

        #region  BasicMethod
        /// <summary>
        /// 获取SN编码类型
        /// </summary>
        /// <param name="_SqlIn"></param>
        /// <returns></returns>
        public Maticsoft.Model.E_PigtailType Get_PigtailType(string _SqlIn)
        {           
            Maticsoft.Model.E_PigtailType _Type;
            DataSet temds = GetList("SN IN "+_SqlIn);
            if (temds.Tables[0].Rows.Count != 0)
            {
                string _temType = temds.Tables[0].Rows[0]["Type"].ToString();
                if (_temType != "")
                {
                    string te ="";
                    if (_temType.Length >= 3)
                    {
                        te = _temType.Substring(0, 3);
                    }                   
                    if (te == "APC")
                    {
                        _Type = Model.E_PigtailType.APC;
                    }
                    else
                    {
                        _Type = Model.E_PigtailType.PC;
                    }
                }
                else { _Type = Model.E_PigtailType._Null; }
                return _Type;
            }
            else
            {
                return Model.E_PigtailType._Null;
            }
            
        }

        /// <summary>
        /// 获取线号
        /// </summary>
        /// <param name="_sn">SN编码</param>
        /// <returns></returns>
        public string Get_PigtailNum(string _sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT SUBSTRING(SN, 12, 2) AS PigtailNum FROM User_3D_Test_Good");
            strSql.Append(" WHERE (SN LIKE '" + _sn+ "%')");
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0]["PigtailNum"].ToString();
            }
            else { return ""; }
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.User_3D_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_3D_Test_Good(");
			strSql.Append("SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Name,@Type,@Result,@Curvature,@Curvature_Result,@Spherical,@Spherical_Result,@Planar,@Planar_Result,@Apex_Offset,@Apex_Offset_Result,@Bearing,@Bearing_Result,@Apex_Angle,@Apex_Angle_Result,@Tilt_Offset,@Tilt_Offset_Result,@Tilt_Angle,@Tilt_Angle_Result,@KeyError,@KeyError_Result,@FiberRq,@FiberRq_Result,@FiberRa,@FiberRa_Result,@FerruleRq,@FerruleRq_Result,@FerruleRa,@FerruleRa_Result,@Diameter,@Diameter_Result,@Test_Date,@Test_Time,@D,@E,@F,@A)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,15),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Planar", SqlDbType.VarChar,15),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Curvature;
			parameters[5].Value = model.Curvature_Result;
			parameters[6].Value = model.Spherical;
			parameters[7].Value = model.Spherical_Result;
			parameters[8].Value = model.Planar;
			parameters[9].Value = model.Planar_Result;
			parameters[10].Value = model.Apex_Offset;
			parameters[11].Value = model.Apex_Offset_Result;
			parameters[12].Value = model.Bearing;
			parameters[13].Value = model.Bearing_Result;
			parameters[14].Value = model.Apex_Angle;
			parameters[15].Value = model.Apex_Angle_Result;
			parameters[16].Value = model.Tilt_Offset;
			parameters[17].Value = model.Tilt_Offset_Result;
			parameters[18].Value = model.Tilt_Angle;
			parameters[19].Value = model.Tilt_Angle_Result;
			parameters[20].Value = model.KeyError;
			parameters[21].Value = model.KeyError_Result;
			parameters[22].Value = model.FiberRq;
			parameters[23].Value = model.FiberRq_Result;
			parameters[24].Value = model.FiberRa;
			parameters[25].Value = model.FiberRa_Result;
			parameters[26].Value = model.FerruleRq;
			parameters[27].Value = model.FerruleRq_Result;
			parameters[28].Value = model.FerruleRa;
			parameters[29].Value = model.FerruleRa_Result;
			parameters[30].Value = model.Diameter;
			parameters[31].Value = model.Diameter_Result;
			parameters[32].Value = model.Test_Date;
			parameters[33].Value = model.Test_Time;
			parameters[34].Value = model.D;
			parameters[35].Value = model.E;
			parameters[36].Value = model.F;
			parameters[37].Value = model.A;

            object obj = dbs.GetSingle(strSql.ToString(), parameters);
           
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
		public bool Update(Maticsoft.Model.User_3D_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_3D_Test_Good set ");
			strSql.Append("SN=@SN,");
			strSql.Append("Name=@Name,");
			strSql.Append("Type=@Type,");
			strSql.Append("Result=@Result,");
			strSql.Append("Curvature=@Curvature,");
			strSql.Append("Curvature_Result=@Curvature_Result,");
			strSql.Append("Spherical=@Spherical,");
			strSql.Append("Spherical_Result=@Spherical_Result,");
			strSql.Append("Planar=@Planar,");
			strSql.Append("Planar_Result=@Planar_Result,");
			strSql.Append("Apex_Offset=@Apex_Offset,");
			strSql.Append("Apex_Offset_Result=@Apex_Offset_Result,");
			strSql.Append("Bearing=@Bearing,");
			strSql.Append("Bearing_Result=@Bearing_Result,");
			strSql.Append("Apex_Angle=@Apex_Angle,");
			strSql.Append("Apex_Angle_Result=@Apex_Angle_Result,");
			strSql.Append("Tilt_Offset=@Tilt_Offset,");
			strSql.Append("Tilt_Offset_Result=@Tilt_Offset_Result,");
			strSql.Append("Tilt_Angle=@Tilt_Angle,");
			strSql.Append("Tilt_Angle_Result=@Tilt_Angle_Result,");
			strSql.Append("KeyError=@KeyError,");
			strSql.Append("KeyError_Result=@KeyError_Result,");
			strSql.Append("FiberRq=@FiberRq,");
			strSql.Append("FiberRq_Result=@FiberRq_Result,");
			strSql.Append("FiberRa=@FiberRa,");
			strSql.Append("FiberRa_Result=@FiberRa_Result,");
			strSql.Append("FerruleRq=@FerruleRq,");
			strSql.Append("FerruleRq_Result=@FerruleRq_Result,");
			strSql.Append("FerruleRa=@FerruleRa,");
			strSql.Append("FerruleRa_Result=@FerruleRa_Result,");
			strSql.Append("Diameter=@Diameter,");
			strSql.Append("Diameter_Result=@Diameter_Result,");
			strSql.Append("Test_Date=@Test_Date,");
			strSql.Append("Test_Time=@Test_Time,");
			strSql.Append("D=@D,");
			strSql.Append("E=@E,");
			strSql.Append("F=@F,");
			strSql.Append("A=@A");
            strSql.Append(" where SN=@SN");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,15),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Planar", SqlDbType.VarChar,15),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15),
					};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Curvature;
			parameters[5].Value = model.Curvature_Result;
			parameters[6].Value = model.Spherical;
			parameters[7].Value = model.Spherical_Result;
			parameters[8].Value = model.Planar;
			parameters[9].Value = model.Planar_Result;
			parameters[10].Value = model.Apex_Offset;
			parameters[11].Value = model.Apex_Offset_Result;
			parameters[12].Value = model.Bearing;
			parameters[13].Value = model.Bearing_Result;
			parameters[14].Value = model.Apex_Angle;
			parameters[15].Value = model.Apex_Angle_Result;
			parameters[16].Value = model.Tilt_Offset;
			parameters[17].Value = model.Tilt_Offset_Result;
			parameters[18].Value = model.Tilt_Angle;
			parameters[19].Value = model.Tilt_Angle_Result;
			parameters[20].Value = model.KeyError;
			parameters[21].Value = model.KeyError_Result;
			parameters[22].Value = model.FiberRq;
			parameters[23].Value = model.FiberRq_Result;
			parameters[24].Value = model.FiberRa;
			parameters[25].Value = model.FiberRa_Result;
			parameters[26].Value = model.FerruleRq;
			parameters[27].Value = model.FerruleRq_Result;
			parameters[28].Value = model.FerruleRa;
			parameters[29].Value = model.FerruleRa_Result;
			parameters[30].Value = model.Diameter;
			parameters[31].Value = model.Diameter_Result;
			parameters[32].Value = model.Test_Date;
			parameters[33].Value = model.Test_Time;
			parameters[34].Value = model.D;
			parameters[35].Value = model.E;
			parameters[36].Value = model.F;
			parameters[37].Value = model.A;
			

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_3D_Test_Good ");
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
        /// <param name="Option">精确查询=1；  模糊查询=2</param>
        /// <returns></returns>
        public bool Delete(string SN ,int Option)
        {
            int rows=0;
            if (Option == 1)   //精确查询
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from User_3D_Test_Good ");
                strSql.Append(" where SN=@SN");
                SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25)};			
                parameters[0].Value = SN;
                rows = dbs.ExecuteSql(strSql.ToString(), parameters);
            }
            else//模糊查询
            {
                string strSql = "delete from User_3D_Test_Good  where SN Like '"+SN+"%'";             
                rows = dbs.ExecuteSql(strSql);
            }         
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
			strSql.Append("delete from User_3D_Test_Good ");
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
		public Maticsoft.Model.User_3D_Test_Good GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key from User_3D_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.User_3D_Test_Good model=new Maticsoft.Model.User_3D_Test_Good();
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
		public Maticsoft.Model.User_3D_Test_Good DataRowToModel(DataRow row)
		{
			Maticsoft.Model.User_3D_Test_Good model=new Maticsoft.Model.User_3D_Test_Good();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Curvature"]!=null)
				{
					model.Curvature=row["Curvature"].ToString();
				}
				if(row["Curvature_Result"]!=null)
				{
					model.Curvature_Result=row["Curvature_Result"].ToString();
				}
				if(row["Spherical"]!=null)
				{
					model.Spherical=row["Spherical"].ToString();
				}
				if(row["Spherical_Result"]!=null)
				{
					model.Spherical_Result=row["Spherical_Result"].ToString();
				}
				if(row["Planar"]!=null)
				{
					model.Planar=row["Planar"].ToString();
				}
				if(row["Planar_Result"]!=null)
				{
					model.Planar_Result=row["Planar_Result"].ToString();
				}
				if(row["Apex_Offset"]!=null)
				{
					model.Apex_Offset=row["Apex_Offset"].ToString();
				}
				if(row["Apex_Offset_Result"]!=null)
				{
					model.Apex_Offset_Result=row["Apex_Offset_Result"].ToString();
				}
				if(row["Bearing"]!=null)
				{
					model.Bearing=row["Bearing"].ToString();
				}
				if(row["Bearing_Result"]!=null)
				{
					model.Bearing_Result=row["Bearing_Result"].ToString();
				}
				if(row["Apex_Angle"]!=null)
				{
					model.Apex_Angle=row["Apex_Angle"].ToString();
				}
				if(row["Apex_Angle_Result"]!=null)
				{
					model.Apex_Angle_Result=row["Apex_Angle_Result"].ToString();
				}
				if(row["Tilt_Offset"]!=null)
				{
					model.Tilt_Offset=row["Tilt_Offset"].ToString();
				}
				if(row["Tilt_Offset_Result"]!=null)
				{
					model.Tilt_Offset_Result=row["Tilt_Offset_Result"].ToString();
				}
				if(row["Tilt_Angle"]!=null)
				{
					model.Tilt_Angle=row["Tilt_Angle"].ToString();
				}
				if(row["Tilt_Angle_Result"]!=null)
				{
					model.Tilt_Angle_Result=row["Tilt_Angle_Result"].ToString();
				}
				if(row["KeyError"]!=null)
				{
					model.KeyError=row["KeyError"].ToString();
				}
				if(row["KeyError_Result"]!=null)
				{
					model.KeyError_Result=row["KeyError_Result"].ToString();
				}
				if(row["FiberRq"]!=null)
				{
					model.FiberRq=row["FiberRq"].ToString();
				}
				if(row["FiberRq_Result"]!=null)
				{
					model.FiberRq_Result=row["FiberRq_Result"].ToString();
				}
				if(row["FiberRa"]!=null)
				{
					model.FiberRa=row["FiberRa"].ToString();
				}
				if(row["FiberRa_Result"]!=null)
				{
					model.FiberRa_Result=row["FiberRa_Result"].ToString();
				}
				if(row["FerruleRq"]!=null)
				{
					model.FerruleRq=row["FerruleRq"].ToString();
				}
				if(row["FerruleRq_Result"]!=null)
				{
					model.FerruleRq_Result=row["FerruleRq_Result"].ToString();
				}
				if(row["FerruleRa"]!=null)
				{
					model.FerruleRa=row["FerruleRa"].ToString();
				}
				if(row["FerruleRa_Result"]!=null)
				{
					model.FerruleRa_Result=row["FerruleRa_Result"].ToString();
				}
				if(row["Diameter"]!=null)
				{
					model.Diameter=row["Diameter"].ToString();
				}
				if(row["Diameter_Result"]!=null)
				{
					model.Diameter_Result=row["Diameter_Result"].ToString();
				}
				if(row["Test_Date"]!=null)
				{
					model.Test_Date=row["Test_Date"].ToString();
				}
				if(row["Test_Time"]!=null)
				{
					model.Test_Time=row["Test_Time"].ToString();
				}
				if(row["D"]!=null)
				{
					model.D=row["D"].ToString();
				}
				if(row["E"]!=null)
				{
					model.E=row["E"].ToString();
				}
				if(row["F"]!=null)
				{
					model.F=row["F"].ToString();
				}
				if(row["A"]!=null)
				{
					model.A=row["A"].ToString();
				}
                if (row["ID_Key"] != null)
                {
                    model.ID_Key = (decimal)row["ID_Key"];
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
			strSql.Append("select SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key ");
			strSql.Append(" FROM User_3D_Test_Good ");
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
			strSql.Append(" SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key ");
			strSql.Append(" FROM User_3D_Test_Good ");
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
			strSql.Append("select count(1) FROM User_3D_Test_Good ");
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
			strSql.Append(")AS Row, T.*  from User_3D_Test_Good T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return dbs.Query(strSql.ToString());
		}

		

		#endregion  BasicMethod
	}
}

