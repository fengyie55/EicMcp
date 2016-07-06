using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using System.Collections;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Pack_3D
	/// </summary>
	public partial class Pack_3D
	{
		public Pack_3D()
		{}
		#region  BasicMethod
        DbHelperSQL dbs = new DbHelperSQL();

        /// <summary>
        /// 查询已包装的数据 ——主要用于导出
        /// </summary>
        /// <param name="BatchNo">包装批号 当为多芯查询时  为ClientSN编码</param>
        /// <returns>已包装数据</returns>
        public DataSet Get_PackData(string BatchNo,Maticsoft.Model.E_InspectMethod _InspectMethod)
        {
            if (_InspectMethod == Model.E_InspectMethod.TFK十二芯检测x2)
            {
                /*
                string strSql = " SELECT tb_Pack_3D.ClientSN + '-' + LEFT(tb_Pack_3D.Name, 2) AS SN,  ";
                strSql += "  SUBSTRING(tb_Pack_3D.Name, 4, 2) AS Name, tb_Pack_3D.Type, tb_Pack_3D.Result,  ";
                strSql += "  tb_Pack_3D.Curvature, tb_Pack_3D.Curvature_Result, tb_Pack_3D.Spherical,    ";
                strSql += "  tb_Pack_3D.Spherical_Result, tb_Pack_3D.Apex_Offset,           ";
                strSql += "  tb_Pack_3D.Apex_Offset_Result, tb_Pack_3D.Tilt_Angle,       ";
                strSql += "  tb_Pack_3D.Tilt_Angle_Result, tb_Pack_3D.Test_Date, tb_Pack_3D.Test_Time, ";
                strSql += "  tb_PrintRecord.LabellMode       ";
                strSql += "  FROM tb_Pack_3D LEFT OUTER JOIN      ";
                strSql += "  tb_PrintRecord ON tb_Pack_3D.ClientSN = tb_PrintRecord.SN    ";
                strSql += "  Where tb_PrintRecord.BatchNo='" + BatchNo + "'";
                strSql += "  ORDER BY SN, CONVERT(int, SUBSTRING(tb_Pack_3D.Name, 4, 2))    ";
                */

                string strSql = " SELECT ClientSN + '-' + LEFT(Name, 2) AS SN1, SUBSTRING(Name, 4, 2) AS Name, Type, ";
                strSql += "  Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Apex_Offset, ";
                strSql += "  Apex_Offset_Result, Tilt_Angle, Tilt_Angle_Result, Test_Date, Test_Time ";
                strSql += " FROM tb_Pack_3D ";
                strSql += " Where BatchNo='" + BatchNo + "'";
                strSql += " ORDER BY SN1, CONVERT(int, SUBSTRING(Name, 4, 2)) ";


                return dbs.Query(strSql);
            }
            else if (_InspectMethod == Model.E_InspectMethod.配组_四十八芯 ||
             _InspectMethod == Model.E_InspectMethod.配组_九十六芯 ||
            _InspectMethod == Model.E_InspectMethod.配组_二十四芯 
                )
            {
                string strSql = "SELECT ClientSN, CONVERT(int, Name) AS Name,  Type, Result, Curvature, Curvature_Result,";
                strSql += " Spherical, Spherical_Result, Apex_Offset, Apex_Offset_Result, Tilt_Angle,Tilt_Angle_Result, Test_Date, Test_Time  ";
                strSql += " FROM tb_Pack_3D WHERE (ClientSN = '" + BatchNo + "')  ORDER BY ClientSN, Name";
                return dbs.Query(strSql);
            }
            else if (_InspectMethod == Model.E_InspectMethod.配组_八芯_SAMHALL 
                || _InspectMethod == Model.E_InspectMethod.配组_九十六芯_SAMHALL 
                || _InspectMethod == Model.E_InspectMethod.配组_二十四芯_SAMHALL
                || _InspectMethod == Model.E_InspectMethod.配组_四十八芯_SAMHALL)
            {
                string strSql = " SELECT ClientSN, SN, Type, Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Apex_Offset, ";
                strSql += " Apex_Offset_Result , Tilt_Angle, Tilt_Angle_Result, Test_Date, Test_Time FROM tb_Pack_3D";
                strSql += " Where BatchNo='" + BatchNo + "'";
                return dbs.Query(strSql);
            }

            else //if (_InspectMethod == Model.E_InspectMethod.配组_八芯)
            {
                string strSql = " SELECT ClientSN, Name, tb_Pack_3D.Type, Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Apex_Offset, ";
                strSql += " Apex_Offset_Result , Tilt_Angle, Tilt_Angle_Result, Test_Date, Test_Time FROM tb_Pack_3D LEFT OUTER JOIN      ";
                strSql += "  tb_SerialNumber ON tb_Pack_3D.SN = tb_SerialNumber.SN         ";
                strSql += "   WHERE (tb_SerialNumber.BatchNO = '" + BatchNo + "') AND   (tb_SerialNumber.State = 'Yet_Pack')";
                DataSet temds = dbs.Query(strSql);

                if (temds.Tables[0].Rows.Count > 0)
                {
                    return temds;
                }
                else
                {
                    string strSql2 = " SELECT ClientSN, Name, tb_Pack_3D.Type, Result, Curvature, Curvature_Result, Spherical, Spherical_Result, Apex_Offset, ";
                    strSql2 += " Apex_Offset_Result , Tilt_Angle, Tilt_Angle_Result, Test_Date, Test_Time FROM tb_Pack_3D LEFT OUTER JOIN      ";
                    strSql2 += "  tb_SerialNumber ON tb_Pack_3D.ClientSN = tb_SerialNumber.SN         ";
                    strSql2 += "   WHERE (tb_SerialNumber.BatchNO = '" + BatchNo + "') AND   (tb_SerialNumber.State = 'Yet_Pack')";
                    return dbs.Query(strSql2);
                }
            }

        }
      
        

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            string dt = DateTime.Now.ToString();
            int _temRecord = 0;
            foreach (DataRow dr in e.TestData.Tables[0].Rows)
            {
                Maticsoft.Model.Pack_3D PK_3D = DataRowToModel(dr);
                PK_3D.OrderID = e.WorkOrder.OrderID;
                PK_3D.BatchNo = e.BatchNo;
                PK_3D.ClientSN = e.ClientSN;
                
                PK_3D.PackDate = dt;
                dbs.Exists("delete from tb_Pack_3D WHERE SN ='"+ PK_3D.SN + "' AND Name ='"+PK_3D.Name+"'");
                  
                if (Add(PK_3D) == 0) //返回更新结果
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
        /// 增加数据-多芯
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack2(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            string dt = DateTime.Now.ToString();
            int _temRecord = 0;
            int tem;
            foreach (DataRow dr in e.TestData.Tables[0].Rows)
            {              
                Maticsoft.Model.Pack_3D PK_3D = DataRowToModel(dr);
                tem = (int.Parse(PK_3D.SN.Substring(11, 2).ToString()) - 1) * 8 + int.Parse(PK_3D.Name);
                PK_3D.OrderID = e.WorkOrder.OrderID;
                PK_3D.BatchNo = e.BatchNo;
                PK_3D.ClientSN = e.ClientSN;
                PK_3D.Name = tem.ToString();
                PK_3D.PackDate = dt;
                dbs.Exists("delete from tb_Pack_3D WHERE SN ='" + PK_3D.SN + "' AND Name ='" + PK_3D.Name + "'");

                if (Add(PK_3D) == 0) //返回更新结果
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
        /// 增加数据-8芯
        /// </summary>
        /// <param name="e"></param>
        public void Add_Pack3(Maticsoft.DAL.My_GetTestData.UpDataEventArgs e)
        {
            string dt = DateTime.Now.ToString();
            int _temRecord = 0;
           // int tem;
            foreach (DataRow dr in e.TestData.Tables[0].Rows)
            {

                Maticsoft.Model.Pack_3D PK_3D = DataRowToModel(dr);
               // tem = (int.Parse(PK_3D.SN.Substring(11, 2).ToString()) - 1) * 8 + int.Parse(PK_3D.Name);
                PK_3D.OrderID = e.WorkOrder.OrderID;
                PK_3D.BatchNo = e.BatchNo;
                PK_3D.ClientSN = e.ClientSN;

                dbs.Exists("delete from tb_Pack_3D WHERE SN ='" + PK_3D.SN + "'");

                int temName = Get_ClientPigtailNumber(e.ClientSN, "8芯").Count+1;
                PK_3D.Name = temName.ToString(); ;

               // PK_3D.Name = tem.ToString();
                PK_3D.PackDate = dt;
               

                if (Add(PK_3D) == 0) //返回更新结果
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
        /// 返回已经包装的线号（主要用于配组线材类型）
        /// </summary>
        /// <param name="_clientSN">客户编码</param>
        /// <returns></returns>
        public ArrayList Get_ClientPigtailNumber(string _clientSN)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT SUBSTRING(SN, 12, 2) AS PigtailNum FROM tb_Pack_3D");
            strSql.Append(" WHERE (ClientSN = '"+_clientSN+"')");
            DataSet ds = dbs.Query(strSql.ToString());
            ArrayList tem = new ArrayList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tem.Add(ds.Tables[0].Rows[i]["PigtailNum"].ToString());
            }
            return tem;
        }
       
        /// <summary>
        /// 返回已经包装的线号 _八芯配组
        /// </summary>
        /// <param name="_clientSN">客户编码</param>
        /// <returns></returns>
        public ArrayList Get_ClientPigtailNumber(string _clientSN,string _EightCore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(SN) AS Count FROM tb_Pack_3D ");
            strSql.Append(" WHERE (ClientSN = '" + _clientSN + "')");
            DataSet ds = dbs.Query(strSql.ToString());
            ArrayList tem = new ArrayList();
            int temCount = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
            for (int i = 1; i <= temCount; i++)
            {
                tem.Add(i.ToString());
            }            
            return tem;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Maticsoft.Model.Pack_3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Pack_3D(");
			strSql.Append("SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,PackLot,PackDate,CustomerName,ClientSN,BatchNo,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Name,@Type,@Result,@Curvature,@Curvature_Result,@Spherical,@Spherical_Result,@Planar,@Planar_Result,@Apex_Offset,@Apex_Offset_Result,@Bearing,@Bearing_Result,@Apex_Angle,@Apex_Angle_Result,@Tilt_Offset,@Tilt_Offset_Result,@Tilt_Angle,@Tilt_Angle_Result,@KeyError,@KeyError_Result,@FiberRq,@FiberRq_Result,@FiberRa,@FiberRa_Result,@FerruleRq,@FerruleRq_Result,@FerruleRa,@FerruleRa_Result,@Diameter,@Diameter_Result,@Test_Date,@Test_Time,@D,@E,@F,@A,@PackLot,@PackDate,@CustomerName,@ClientSN,@BatchNo,@OrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,6),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Planar", SqlDbType.VarChar,6),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15),
					new SqlParameter("@PackLot", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.VarChar,35),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,35),
					new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,25)};
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
			parameters[38].Value = model.PackLot;
			parameters[39].Value = model.PackDate;
			parameters[40].Value = model.CustomerName;
			parameters[41].Value = model.ClientSN;
			parameters[42].Value = model.BatchNo;
			parameters[43].Value = model.OrderID;

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
		public bool Update(Maticsoft.Model.Pack_3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Pack_3D set ");
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
			strSql.Append("A=@A,");
			strSql.Append("PackLot=@PackLot,");
			strSql.Append("PackDate=@PackDate,");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("ClientSN=@ClientSN,");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("OrderID=@OrderID");
			
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,6),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Planar", SqlDbType.VarChar,6),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,15),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15),
					new SqlParameter("@PackLot", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.VarChar,35),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,35),
					new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,25),
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
			parameters[38].Value = model.PackLot;
			parameters[39].Value = model.PackDate;
			parameters[40].Value = model.CustomerName;
			parameters[41].Value = model.ClientSN;
			parameters[42].Value = model.BatchNo;
			parameters[43].Value = model.OrderID;


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
			strSql.Append("delete from tb_Pack_3D ");
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
        public int Delete(string sqlWhere)
        {
            string strSql = "delete from tb_Pack_3D where " + sqlWhere + "";
            int rows = dbs.ExecuteSql(strSql.ToString());
            return rows;
        }

		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Pack_3D ");
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
		public Maticsoft.Model.Pack_3D GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,PackLot,PackDate,CustomerName,ClientSN,BatchNo,OrderID,ID_Key from tb_Pack_3D ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.Pack_3D model=new Maticsoft.Model.Pack_3D();
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
		public Maticsoft.Model.Pack_3D DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Pack_3D model=new Maticsoft.Model.Pack_3D();
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
			/*	if(row["PackLot"]!=null)
				{
					model.PackLot=row["PackLot"].ToString();
				}
                
				if(row["PackDate"]!=null)
				{
					model.PackDate=row["PackDate"].ToString();
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["ClientSN"]!=null)
				{
					model.ClientSN=row["ClientSN"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
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
			strSql.Append("select SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,PackLot,PackDate,CustomerName,ClientSN,BatchNo,OrderID,ID_Key ");
			strSql.Append(" FROM tb_Pack_3D ");
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
			strSql.Append(" SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,PackLot,PackDate,CustomerName,ClientSN,BatchNo,OrderID,ID_Key ");
			strSql.Append(" FROM tb_Pack_3D ");
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
			strSql.Append("select count(1) FROM tb_Pack_3D ");
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
			strSql.Append(")AS Row, T.*  from tb_Pack_3D T ");
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
			parameters[0].Value = "tb_Pack_3D";
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

