/**  版本信息模板在安装目录下，可自行修改。
* User_JDS_Test_Good.cs
*
* 功 能： N/A
* 类 名： User_JDS_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-31 11:06:01   追风猎人    初版
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
using MCP_DBUitility;
using System.Collections;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:User_JDS_Test_Good
	/// </summary>
	public partial class User_JDS_Test_Good
	{
		public User_JDS_Test_Good()
		{}

        DbHelperSQL dbs = new DbHelperSQL(Model.E_ConnectionList.ToLine);      
        DbHelperSQL dbs_Exfo = new DbHelperSQL(Model.E_ConnectionList.IQ12001B);

        #region Getdata_Method

        /// <summary>
        /// MPO_SPC
        /// </summary>
        public DataSet Get_MPO_SPC(string _Wave ,string _Date )
        {
            string Sql = "  SELECT * ";
            Sql += "  FROM (SELECT (CASE WHEN TWaveLength.Wvl_Id = 4 THEN '1310nm' WHEN TWaveLength.Wvl_Id ";
            Sql += "  = 3 THEN '850nm' END) AS Wave, TFiberMeasurement.Fim_ILEndA AS Il_A, ";
            Sql += "  TFiberMeasurement.Fim_ReflectanceEndA AS Refl_A, ";
            Sql += "  TFiberMeasurement.Fim_ILEndB AS Il_B, ";
            Sql += "  TFiberMeasurement.Fim_ReflectanceEndB AS Refl_B, CONVERT(varchar(100), ";
            Sql += "  TDUTMeasurement.Dum_MeasurementDate, 23) AS TestDate";
            Sql += "  FROM TTestTemplate INNER JOIN";
            Sql += "  TDUTMeasurement ON ";
            Sql += "  TTestTemplate.Tst_Id = TDUTMeasurement.Dum_Tst_Id LEFT OUTER JOIN";
            Sql += "  TFiber INNER JOIN";
            Sql += "  TFiberMeasurement ON TFiber.Fib_Id = TFiberMeasurement.Fim_Fib_Id ON ";
            Sql += "  TDUTMeasurement.Dum_Id = TFiberMeasurement.Fim_Dum_Id LEFT OUTER JOIN";
            Sql += "  TWaveLength ON ";
            Sql += "  TFiberMeasurement.Fim_Wvl_Id = TWaveLength.Wvl_Id";
            Sql += "  WHERE (TTestTemplate.Tst_Id = 975) OR (TTestTemplate.Tst_Id = 983) OR";
            Sql += "  (TTestTemplate.Tst_Id = 974)) AS derivedtbl_1";
            Sql += "  WHERE (CONVERT(varchar(100), TestDate, 23) = '"+_Date+"') AND (Wave = '"+_Wave+"')";
            return dbs_Exfo.Query(Sql);
        }

        /// <summary>
        /// SPC
        /// </summary>
        public DataSet Get_SPC(string _Wave, string _Date)   
        {
            string Sql = "   SELECT TOP (125) Wave, Il_A, Refl_A, Il_B, Refl_B, TestDate, TestTime, Random ";
            Sql += " FROM (SELECT (CASE WHEN TWaveLength.Wvl_Id = 1 THEN '1310nm' WHEN TWaveLength.Wvl_Id     ";
            Sql += "  = 2 THEN '1550nm' WHEN TWaveLength.Wvl_Id = 3 THEN '850nm' WHEN TWaveLength.Wvl_Id  ";
            Sql += "  = 4 THEN '1300nm' END) AS Wave, TFiberMeasurement.Fim_ILEndA AS Il_A,   ";
            Sql += "  TFiberMeasurement.Fim_ReflectanceEndA AS Refl_A,";
            Sql += "  TFiberMeasurement.Fim_ILEndB AS Il_B,     ";
            Sql += "  TFiberMeasurement.Fim_ReflectanceEndB AS Refl_B, CONVERT(varchar(100),";
            Sql += "  TDUTMeasurement.Dum_MeasurementDate, 23) AS TestDate,    ";
            Sql += "  CONVERT(varchar(100), TDUTMeasurement.Dum_MeasurementDate, 24)    ";
            Sql += "  AS TestTime, NEWID() AS Random  ";
            Sql += "  FROM TTestTemplate INNER JOIN  ";
            Sql += "  TDUTMeasurement ON    ";
            Sql += "  TTestTemplate.Tst_Id = TDUTMeasurement.Dum_Tst_Id LEFT OUTER JOIN  ";
            Sql += "  TFiber INNER JOIN        ";
            Sql += "  TFiberMeasurement ON TFiber.Fib_Id = TFiberMeasurement.Fim_Fib_Id ON    ";
            Sql += "  TDUTMeasurement.Dum_Id = TFiberMeasurement.Fim_Dum_Id LEFT OUTER JOIN  ";
            Sql += "  TWaveLength ON TWaveLength.Wvl_Id = TFiberMeasurement.Fim_Wvl_Id)    ";
            Sql += "  AS derivedtbl_1   ";
            Sql += "  WHERE (TestDate = '" + _Date + "')  AND (Wave = '" + _Wave + "') ";
            Sql += "  ORDER BY Random ";
            return dbs_Exfo.Query(Sql);
        }

        /// <summary>
        /// 获取 MPO JDS数据
        /// </summary>
        public void GetData_MPO(My_GetTestData.GetDataEventArgs e)
        {           
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 13) AS SN, SUBSTRING(SN, 15, 2) AS Name, Result, Wave, IL_A, ABS(Refl_A) AS Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);
            e.PigtailList = Get_PigtailList(e.TestData, 11);
            
            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                tem = false;
            }
            else { tem = true; }
            
            //如果JDS表中没有数据 从Exfo测试表中查找
            if (tem)
            {
                string asql = " SELECT * FROM (SELECT CAST(TDUTMeasurement.Dum_FixSerialNr AS nvarchar(20))  ";
                asql += "  + '-' + TDUTMeasurement.Dum_IncrSerialNr AS SN,  TFiber.Fib_SequenceNr AS Name, ";
                asql += " (CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END) AS Result, ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN ";
                asql += " dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550nm'   ";
                asql += " WHEN dbo.TWaveLength.Wvl_Value = 0.0000008500 THEN '850nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000013000 THEN '1300nm' END) ";
                asql += " AS Wave, TFiberMeasurement.Fim_ILEndA AS Il_A, ";
                asql += " TFiberMeasurement.Fim_ReflectanceEndA AS Refl_A, ";
                asql += " TFiberMeasurement.Fim_ILEndB AS Il_B, ";
                asql += " TFiberMeasurement.Fim_ReflectanceEndB AS Refl_B, ";
                asql += " TDUTMeasurement.Dum_MeasurementDate AS TestDate";
                asql += " FROM TFiber INNER JOIN";
                asql += " TFiberMeasurement ON ";
                asql += " TFiber.Fib_Id = TFiberMeasurement.Fim_Fib_Id RIGHT OUTER JOIN ";
                asql += " TDUTMeasurement ON ";
                asql += " TFiberMeasurement.Fim_Dum_Id = TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " TWaveLength ON ";
                asql += " TFiberMeasurement.Fim_Wvl_Id = TWaveLength.Wvl_Id";
                asql += " WHERE (TDUTMeasurement.Dum_FixSerialNr = '"+e.SN+"') AND ";
                asql += " (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS derivedtbl_1";
                //赋值返回的测试数据
                e.TestData = dbs_Exfo.Query(asql);
                e.PigtailList = Get_PigtailList(e.TestData, 11);
            }
        }


        /// <summary>
        /// 多芯查询 有IN条件
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_Multicore(My_GetTestData.GetDataEventArgs e)
        {
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 13) AS SN, SUBSTRING(SN, 15, 2) AS Name, Result, Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);                    //返回查询到的数据

            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0) { tem = false; }
            else { tem = true; }

            if (tem)
            {
                string asql = "SELECT * FROM( SELECT LEFT (dbo.TDUTMeasurement.Dum_FixSerialNr,13) AS [SN], ";
                asql += " SUBSTRING (dbo.TDUTMeasurement.Dum_FixSerialNr,15,2) AS [Name], ";
                asql += "(CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END ) AS [Result] , ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550nm' END ) AS Wave, ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndA AS [Il_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndA AS [Refl_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndB AS [Il_B], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndB AS [Refl_B], ";
                asql += "dbo.TDUTMeasurement.Dum_MeasurementDate AS [TestDate] ";
                asql += " FROM dbo.TDUTMeasurement LEFT OUTER JOIN";
                asql += " dbo.TTestTemplate ON ";
                asql += " dbo.TDUTMeasurement.Dum_Tst_Id = dbo.TTestTemplate.Tst_Id LEFT OUTER JOIN";
                asql += " dbo.TFiberMeasurement ON";
                asql += " dbo.TFiberMeasurement.Fim_Dum_Id = dbo.TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " dbo.TCustomer ON ";
                asql += " dbo.TTestTemplate.Tst_Cus_Id = dbo.TCustomer.Cus_Id LEFT OUTER JOIN";
                asql += " dbo.TDutModel ON ";
                asql += " dbo.TTestTemplate.Tst_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TCable ON dbo.TCable.Cab_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TFiber ON dbo.TFiber.Fib_Cab_Id = dbo.TCable.Cab_Id LEFT OUTER JOIN";
                asql += " dbo.TConnector AS StartingConnector ON ";
                asql += " dbo.TFiber.Fib_Starting_Con_Id = StartingConnector.Con_Id LEFT OUTER JOIN";
                asql += " dbo.TWaveLength ON";
                asql += " dbo.TFiberMeasurement.Fim_Wvl_Id = dbo.TWaveLength.Wvl_Id";
                asql += " WHERE (dbo.TDUTMeasurement.Dum_FixSerialNr LIKE '" + e.SN + "%') AND (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS TemTab";
                asql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed') )";
                e.TestData = dbs_Exfo.Query(asql);
            }
            e.PigtailList = Get_PigtailList_Name(e.TestData);
            // e.PiagtilNum = e.TestData.Tables[0].Rows[0][""].ToString();
        }

        /// <summary>
        /// 多芯查询 有IN条件
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_Multicore_TFK(My_GetTestData.GetDataEventArgs e) 
        {
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 13) AS SN, SUBSTRING(SN, 12, 5) AS Name, Result, Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);                    //返回查询到的数据

            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0) { tem = false; }
            else { tem = true; }

            if (tem)
            {
                string asql = "SELECT * FROM( SELECT LEFT (dbo.TDUTMeasurement.Dum_FixSerialNr,13) AS [SN], ";
                asql += " SUBSTRING (dbo.TDUTMeasurement.Dum_FixSerialNr,12,5) AS [Name], ";
                asql += "(CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END ) AS [Result] , ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550nm' END ) AS Wave, ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndA AS [Il_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndA AS [Refl_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndB AS [Il_B], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndB AS [Refl_B], ";
                asql += "dbo.TDUTMeasurement.Dum_MeasurementDate AS [TestDate] ";
                asql += " FROM dbo.TDUTMeasurement LEFT OUTER JOIN";
                asql += " dbo.TTestTemplate ON ";
                asql += " dbo.TDUTMeasurement.Dum_Tst_Id = dbo.TTestTemplate.Tst_Id LEFT OUTER JOIN";
                asql += " dbo.TFiberMeasurement ON";
                asql += " dbo.TFiberMeasurement.Fim_Dum_Id = dbo.TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " dbo.TCustomer ON ";
                asql += " dbo.TTestTemplate.Tst_Cus_Id = dbo.TCustomer.Cus_Id LEFT OUTER JOIN";
                asql += " dbo.TDutModel ON ";
                asql += " dbo.TTestTemplate.Tst_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TCable ON dbo.TCable.Cab_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TFiber ON dbo.TFiber.Fib_Cab_Id = dbo.TCable.Cab_Id LEFT OUTER JOIN";
                asql += " dbo.TConnector AS StartingConnector ON ";
                asql += " dbo.TFiber.Fib_Starting_Con_Id = StartingConnector.Con_Id LEFT OUTER JOIN";
                asql += " dbo.TWaveLength ON";
                asql += " dbo.TFiberMeasurement.Fim_Wvl_Id = dbo.TWaveLength.Wvl_Id";
                asql += " WHERE (dbo.TDUTMeasurement.Dum_FixSerialNr LIKE '" + e.SN + "%') AND (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS TemTab";
                asql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed') )";
                e.TestData = dbs_Exfo.Query(asql);
            }
            e.PigtailList = Get_PigtailList_Name(e.TestData);
            // e.PiagtilNum = e.TestData.Tables[0].Rows[0][""].ToString();
        }

        /// <summary>
        /// 双并查询 有IN条件
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_TwainCore(My_GetTestData.GetDataEventArgs e)
        {          
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 13) AS SN,SUBSTRING(SN, 12, 2) AS Name, Result, Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);                    //返回查询到的数据
            
            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0) { tem = false; }
            else { tem = true; }  
            
            if (tem)
            {
                string asql = "SELECT * FROM( SELECT LEFT (dbo.TDUTMeasurement.Dum_FixSerialNr,10) + '-' + TDUTMeasurement.Dum_IncrSerialNr AS [SN], ";
                asql += " TDUTMeasurement.Dum_IncrSerialNr AS [Name],  ";
                asql += "(CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END ) AS [Result] , ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550nm' END ) AS Wave, ";
                asql += "ABS(dbo.TFiberMeasurement.Fim_ILEndA) AS [Il_A], ";
                asql += "ABS(dbo.TFiberMeasurement.Fim_ReflectanceEndA) AS [Refl_A], ";
                asql += "ABS(dbo.TFiberMeasurement.Fim_ILEndB) AS [Il_B], ";
                asql += "ABS(dbo.TFiberMeasurement.Fim_ReflectanceEndB) AS [Refl_B], ";
                asql += "dbo.TDUTMeasurement.Dum_MeasurementDate AS [TestDate] ";
                asql += " FROM dbo.TDUTMeasurement LEFT OUTER JOIN";
                asql += " dbo.TTestTemplate ON ";
                asql += " dbo.TDUTMeasurement.Dum_Tst_Id = dbo.TTestTemplate.Tst_Id LEFT OUTER JOIN";
                asql += " dbo.TFiberMeasurement ON";
                asql += " dbo.TFiberMeasurement.Fim_Dum_Id = dbo.TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " dbo.TCustomer ON ";
                asql += " dbo.TTestTemplate.Tst_Cus_Id = dbo.TCustomer.Cus_Id LEFT OUTER JOIN";
                asql += " dbo.TDutModel ON ";
                asql += " dbo.TTestTemplate.Tst_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TCable ON dbo.TCable.Cab_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TFiber ON dbo.TFiber.Fib_Cab_Id = dbo.TCable.Cab_Id LEFT OUTER JOIN";
                asql += " dbo.TConnector AS StartingConnector ON ";
                asql += " dbo.TFiber.Fib_Starting_Con_Id = StartingConnector.Con_Id LEFT OUTER JOIN";
                asql += " dbo.TWaveLength ON";
                asql += " dbo.TFiberMeasurement.Fim_Wvl_Id = dbo.TWaveLength.Wvl_Id";
                asql += " WHERE (dbo.TDUTMeasurement.Dum_FixSerialNr LIKE '" + e.SN + "%') AND (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS TemTab";
                asql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%PASS')";
                e.TestData = dbs_Exfo.Query(asql);
            }
            e.PigtailList = Get_PigtailList(e.TestData, 11);
            // e.PiagtilNum = e.TestData.Tables[0].Rows[0][""].ToString();
        }

        /// <summary>
        /// 单芯查询 无 IN条件
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_OneCore(My_GetTestData.GetDataEventArgs e)
        {
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 10) AS SN,  '1' AS Name, Result, Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);                    //返回查询到的数据

            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0) { tem = false; }
            else { tem = true; }

            if (tem)
            {
                string asql = "SELECT * FROM( SELECT LEFT (dbo.TDUTMeasurement.Dum_FixSerialNr,10) AS [SN], ";
                asql += " '1' AS [Name], ";
                asql += "(CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END ) AS [Result] , ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550um' END ) AS Wave, ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndA AS [Il_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndA AS [Refl_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndB AS [Il_B], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndB AS [Refl_B], ";
                asql += "dbo.TDUTMeasurement.Dum_MeasurementDate AS [TestDate] ";
                asql += " FROM dbo.TDUTMeasurement LEFT OUTER JOIN";
                asql += " dbo.TTestTemplate ON ";
                asql += " dbo.TDUTMeasurement.Dum_Tst_Id = dbo.TTestTemplate.Tst_Id LEFT OUTER JOIN";
                asql += " dbo.TFiberMeasurement ON";
                asql += " dbo.TFiberMeasurement.Fim_Dum_Id = dbo.TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " dbo.TCustomer ON ";
                asql += " dbo.TTestTemplate.Tst_Cus_Id = dbo.TCustomer.Cus_Id LEFT OUTER JOIN";
                asql += " dbo.TDutModel ON ";
                asql += " dbo.TTestTemplate.Tst_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TCable ON dbo.TCable.Cab_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TFiber ON dbo.TFiber.Fib_Cab_Id = dbo.TCable.Cab_Id LEFT OUTER JOIN";
                asql += " dbo.TConnector AS StartingConnector ON ";
                asql += " dbo.TFiber.Fib_Starting_Con_Id = StartingConnector.Con_Id LEFT OUTER JOIN";
                asql += " dbo.TWaveLength ON";
                asql += " dbo.TFiberMeasurement.Fim_Wvl_Id = dbo.TWaveLength.Wvl_Id";
                asql += " WHERE (dbo.TDUTMeasurement.Dum_FixSerialNr LIKE '" + e.SN + "%') AND (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS TemTab";
                asql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
                e.TestData = dbs_Exfo.Query(asql);
            }
            if (e.TestData.Tables[0].Rows.Count > 0)
            {
                ArrayList temAl = new ArrayList();
                temAl.Add("1");
                e.PigtailList = temAl;
            }
            // e.PiagtilNum = e.TestData.Tables[0].Rows[0][""].ToString();
        }

        /// <summary>
        /// 两码两标签 查询
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_TwoSnToLab(My_GetTestData.GetDataEventArgs e)
        {
            //查询JDSU中的数据
            string sql = " SELECT LEFT(SN, 10) AS SN,  '1' AS Name, Result, Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate ";
            sql += " FROM User_JDS_Test_Good";
            sql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
            e.TestData = dbs.Query(sql);                    //返回查询到的数据

            //查询Exfo中的数据   
            bool tem = false;
            if (e.TestData.Tables[0].Rows.Count > 0) { tem = false; }
            else { tem = true; }

            if (tem)
            {
                string asql = "SELECT * FROM( SELECT LEFT (dbo.TDUTMeasurement.Dum_FixSerialNr,10) AS [SN], ";
                asql += " '1'  AS [Name], ";
                asql += "(CASE WHEN dbo.TDUTMeasurement.Dum_GlobalTestStatus = 1 THEN 'PASS' END ) AS [Result] , ";
                asql += " (CASE WHEN dbo.TWaveLength.Wvl_Value = 0.0000013100 THEN '1310nm' WHEN dbo.TWaveLength.Wvl_Value = 0.0000015500 THEN '1550nm' END ) AS Wave, ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndA AS [Il_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndA AS [Refl_A], ";
                asql += "dbo.TFiberMeasurement.Fim_ILEndB AS [Il_B], ";
                asql += "dbo.TFiberMeasurement.Fim_ReflectanceEndB AS [Refl_B], ";
                asql += "dbo.TDUTMeasurement.Dum_MeasurementDate AS [TestDate] ";
                asql += " FROM dbo.TDUTMeasurement LEFT OUTER JOIN";
                asql += " dbo.TTestTemplate ON ";
                asql += " dbo.TDUTMeasurement.Dum_Tst_Id = dbo.TTestTemplate.Tst_Id LEFT OUTER JOIN";
                asql += " dbo.TFiberMeasurement ON";
                asql += " dbo.TFiberMeasurement.Fim_Dum_Id = dbo.TDUTMeasurement.Dum_Id LEFT OUTER JOIN";
                asql += " dbo.TCustomer ON ";
                asql += " dbo.TTestTemplate.Tst_Cus_Id = dbo.TCustomer.Cus_Id LEFT OUTER JOIN";
                asql += " dbo.TDutModel ON ";
                asql += " dbo.TTestTemplate.Tst_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TCable ON dbo.TCable.Cab_Dtm_Id = dbo.TDutModel.Dtm_Id LEFT OUTER JOIN";
                asql += " dbo.TFiber ON dbo.TFiber.Fib_Cab_Id = dbo.TCable.Cab_Id LEFT OUTER JOIN";
                asql += " dbo.TConnector AS StartingConnector ON ";
                asql += " dbo.TFiber.Fib_Starting_Con_Id = StartingConnector.Con_Id LEFT OUTER JOIN";
                asql += " dbo.TWaveLength ON";
                asql += " dbo.TFiberMeasurement.Fim_Wvl_Id = dbo.TWaveLength.Wvl_Id";
                asql += " WHERE (dbo.TDUTMeasurement.Dum_FixSerialNr LIKE '" + e.SN + "%') AND (TDUTMeasurement.Dum_GlobalTestStatus = '1')) AS TemTab";
                asql += " WHERE " + e.sqlWhere + "  AND (Result LIKE '%Passed')";
                e.TestData = dbs_Exfo.Query(asql);
            }
            if (e.TestData.Tables[0].Rows.Count > 0)
            {              
                e.PigtailList = Get_PigtailList(e.TestData, "SN");
            }           
        }




        /// <summary>
        /// 获取用户测试数据数组
        /// </summary>
        /// <param name="user_ds_SN">DataSet 用户SN编码</param>
        /// <param name="_statsub">提取字符 串的起始位置</param>
        /// <returns></returns>
        private ArrayList Get_PigtailList(DataSet user_ds_SN, int _statsub)
        {
            ArrayList tem = new ArrayList();            
            foreach (DataRow dr in user_ds_SN.Tables[0].Rows)
            {
                string temstr = dr["SN"].ToString();
                tem.Add(temstr.Substring(_statsub, temstr.Length-_statsub));
            }
            return tem;
        }



        /// <summary>
        /// 获取用户测试数据数组
        /// </summary>
        /// <param name="user_ds_SN">DataSet 用户SN编码</param>
        /// <param name="_statsub">提取字符 串的起始位置</param>
        /// <returns></returns>
        private ArrayList Get_PigtailList_Name(DataSet user_ds_SN) 
        {
            ArrayList tem = new ArrayList();
            foreach (DataRow dr in user_ds_SN.Tables[0].Rows)
            {
                string temstr = dr["Name"].ToString();
                tem.Add(temstr);
            }
            return tem;
        }

        /// <summary>
        /// 获取用户测试数据数组
        /// </summary>
        /// <param name="user_ds_SN">测试数据</param>
        /// <param name="_lineName">列名称</param>
        /// <returns></returns>
        private ArrayList Get_PigtailList(DataSet user_ds_SN, string _lineName)
        {
            ArrayList tem = new ArrayList();            
            foreach (DataRow dr in user_ds_SN.Tables[0].Rows)
            {
                tem.Add(dr[_lineName].ToString());
            }
            return tem;
        }
        

        #endregion

        
        
        #region  BasicMethod

       
        /// <summary>
        /// 获取SN编码类型
        /// </summary>
        /// <param name="_sn"></param>
        /// <returns></returns>
        public Maticsoft.Model.E_PigtailType Get_PigtailType(string _sn)
        {
            Maticsoft.DAL.User_3D_Test_Good _M_User_3D = new User_3D_Test_Good();
            Maticsoft.Model.E_PigtailType _Type;
            DataSet temds =  _M_User_3D. GetList("SN IN " + _sn + "");
            if (temds.Tables[0].Rows.Count != 0)
            {
                string _temType = temds.Tables[0].Rows[0]["Type"].ToString();
                if (_temType != "")
                {
                    string te = "";
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
            strSql.Append("SELECT DISTINCT SUBSTRING(SN, 12, 2) AS PigtailNum User_JDS_Test_Good");
            strSql.Append(" WHERE (SN LIKE '" + _sn + "%')");
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
		public decimal Add(Maticsoft.Model.User_JDS_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_JDS_Test_Good(");
			strSql.Append("TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B)");
			strSql.Append(" values (");
			strSql.Append("@TestDate,@PartNumber,@SN,@Result,@Wave,@IL_A,@Refl_A,@IL_B,@Refl_B)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10)};
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;

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
		public bool Update(Maticsoft.Model.User_JDS_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_JDS_Test_Good set ");
			strSql.Append("TestDate=@TestDate,");
			strSql.Append("PartNumber=@PartNumber,");
			strSql.Append("SN=@SN,");
			strSql.Append("Result=@Result,");
			strSql.Append("Wave=@Wave,");
			strSql.Append("IL_A=@IL_A,");
			strSql.Append("Refl_A=@Refl_A,");
			strSql.Append("IL_B=@IL_B,");
			strSql.Append("Refl_B=@Refl_B");
            strSql.Append(" where SN=@SN");
            SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10)};
					
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;
			

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
			strSql.Append("delete from User_JDS_Test_Good ");
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
        public bool Delete(string SN) 
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User_JDS_Test_Good ");
            strSql.Append(" where SN=@SN");
            SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar, 35)
			};
            parameters[0].Value = SN;

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
			strSql.Append("delete from User_JDS_Test_Good ");
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
		public Maticsoft.Model.User_JDS_Test_Good GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key from User_JDS_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.User_JDS_Test_Good model=new Maticsoft.Model.User_JDS_Test_Good();
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
		public Maticsoft.Model.User_JDS_Test_Good DataRowToModel(DataRow row)
		{
			Maticsoft.Model.User_JDS_Test_Good model=new Maticsoft.Model.User_JDS_Test_Good();
			if (row != null)
			{
				if(row["TestDate"]!=null)
				{
					model.TestDate=row["TestDate"].ToString();
				}
				if(row["PartNumber"]!=null)
				{
					model.PartNumber=row["PartNumber"].ToString();
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
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
				
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key ");
			strSql.Append(" FROM User_JDS_Test_Good ");
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
			strSql.Append(" TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key ");
			strSql.Append(" FROM User_JDS_Test_Good ");
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
			strSql.Append("select count(1) FROM User_JDS_Test_Good ");
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
			strSql.Append(")AS Row, T.*  from User_JDS_Test_Good T ");
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
			parameters[0].Value = "User_JDS_Test_Good";
			parameters[1].Value = "ID_Key";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
	}
}

