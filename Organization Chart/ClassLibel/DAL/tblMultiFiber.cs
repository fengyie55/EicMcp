/**  版本信息模板在安装目录下，可自行修改。
* tblMultiFiber.cs
*
* 功 能： N/A
* 类 名： tblMultiFiber
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-14 11:09:06   N/A    初版
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
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tblMultiFiber
	/// </summary>
	public partial class tblMultiFiber
	{
		public tblMultiFiber()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tblMultiFiber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tblMultiFiber(");
			strSql.Append("ID,Scan_ID,ScanTime,User_ID,ProductID,ConnectorID,LightMode,DataSource,Microscope,DataFilePath,FiberCount,FiberPitch,FibersPerRow,FiberRowPitch,RowsVerticalOffset,FiberCaptureShape,Shape,FiberDiameter,FerruleType,FerruleCount,GuideStructureType,GuideStructurePitch,NominalYAngle,ConnectorType,ScanSegmentsNmb,ROI_width,ROI_height,AvgDiameter,ExtractingDiameter,MinModulation,TopPixRemove,TopPixLeft,SampleType,Multimode,MeasurementConfig,PassFail,MaxFibDiffH,MaxFibDiffH_min,MaxFibDiffH_max,MaxFibDiffH_Pass,MaxFibDiffAdjH,MaxFibDiffAdjH_min,MaxFibDiffAdjH_max,MaxFibDiffAdjH_Pass,MaxCoreDip,MaxCoreDip_min,MaxCoreDip_max,MaxCoreDip_Pass,ROC_X,ROC_X_min,ROC_X_max,ROC_X_Pass,ROC_Y,ROC_Y_min,ROC_Y_max,ROC_Y_Pass,XEndFaceAngle,XEndFaceAngle_min,XEndFaceAngle_max,XEndFaceAngle_Pass,YEndFaceAngle,YEndFaceAngle_min,YEndFaceAngle_max,YEndFaceAngle_Pass,FlatnessDeviation,FlatnessDeviation_min,FlatnessDeviation_max,FlatnessDeviation_Pass,FiberProtrusion_min,FiberProtrusion_max,FiberProtrusion_Pass,FiberROC_min,FiberROC_max,FiberROC_Pass,FiberHeight,FiberCoreDip,FiberROC,TestPassed,FibArrayXAng,FibArrayXAng_min,FibArrayXAng_max,FibArrayXAng_Pass,FibArrayYAng,FibArrayYAng_min,FibArrayYAng_max,FibArrayYAng_Pass,Coplanarity,Coplanarity_min,Coplanarity_max,Coplanarity_Pass,MinusCoplanarity,MinusCoplanarity_min,MinusCoplanarity_max,MinusCoplanarity_Pass)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Scan_ID,@ScanTime,@User_ID,@ProductID,@ConnectorID,@LightMode,@DataSource,@Microscope,@DataFilePath,@FiberCount,@FiberPitch,@FibersPerRow,@FiberRowPitch,@RowsVerticalOffset,@FiberCaptureShape,@Shape,@FiberDiameter,@FerruleType,@FerruleCount,@GuideStructureType,@GuideStructurePitch,@NominalYAngle,@ConnectorType,@ScanSegmentsNmb,@ROI_width,@ROI_height,@AvgDiameter,@ExtractingDiameter,@MinModulation,@TopPixRemove,@TopPixLeft,@SampleType,@Multimode,@MeasurementConfig,@PassFail,@MaxFibDiffH,@MaxFibDiffH_min,@MaxFibDiffH_max,@MaxFibDiffH_Pass,@MaxFibDiffAdjH,@MaxFibDiffAdjH_min,@MaxFibDiffAdjH_max,@MaxFibDiffAdjH_Pass,@MaxCoreDip,@MaxCoreDip_min,@MaxCoreDip_max,@MaxCoreDip_Pass,@ROC_X,@ROC_X_min,@ROC_X_max,@ROC_X_Pass,@ROC_Y,@ROC_Y_min,@ROC_Y_max,@ROC_Y_Pass,@XEndFaceAngle,@XEndFaceAngle_min,@XEndFaceAngle_max,@XEndFaceAngle_Pass,@YEndFaceAngle,@YEndFaceAngle_min,@YEndFaceAngle_max,@YEndFaceAngle_Pass,@FlatnessDeviation,@FlatnessDeviation_min,@FlatnessDeviation_max,@FlatnessDeviation_Pass,@FiberProtrusion_min,@FiberProtrusion_max,@FiberProtrusion_Pass,@FiberROC_min,@FiberROC_max,@FiberROC_Pass,@FiberHeight,@FiberCoreDip,@FiberROC,@TestPassed,@FibArrayXAng,@FibArrayXAng_min,@FibArrayXAng_max,@FibArrayXAng_Pass,@FibArrayYAng,@FibArrayYAng_min,@FibArrayYAng_max,@FibArrayYAng_Pass,@Coplanarity,@Coplanarity_min,@Coplanarity_max,@Coplanarity_Pass,@MinusCoplanarity,@MinusCoplanarity_min,@MinusCoplanarity_max,@MinusCoplanarity_Pass)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Scan_ID", SqlDbType.Int,4),
					new SqlParameter("@ScanTime", SqlDbType.DateTime),
					new SqlParameter("@User_ID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.NVarChar,255),
					new SqlParameter("@ConnectorID", SqlDbType.NVarChar,255),
					new SqlParameter("@LightMode", SqlDbType.NVarChar,50),
					new SqlParameter("@DataSource", SqlDbType.NVarChar,50),
					new SqlParameter("@Microscope", SqlDbType.NVarChar,50),
					new SqlParameter("@DataFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@FiberCount", SqlDbType.Int,4),
					new SqlParameter("@FiberPitch", SqlDbType.Float,8),
					new SqlParameter("@FibersPerRow", SqlDbType.Int,4),
					new SqlParameter("@FiberRowPitch", SqlDbType.Float,8),
					new SqlParameter("@RowsVerticalOffset", SqlDbType.Float,8),
					new SqlParameter("@FiberCaptureShape", SqlDbType.NVarChar,250),
					new SqlParameter("@Shape", SqlDbType.NVarChar,250),
					new SqlParameter("@FiberDiameter", SqlDbType.Float,8),
					new SqlParameter("@FerruleType", SqlDbType.NVarChar,250),
					new SqlParameter("@FerruleCount", SqlDbType.Int,4),
					new SqlParameter("@GuideStructureType", SqlDbType.NVarChar,250),
					new SqlParameter("@GuideStructurePitch", SqlDbType.Float,8),
					new SqlParameter("@NominalYAngle", SqlDbType.Float,8),
					new SqlParameter("@ConnectorType", SqlDbType.NVarChar,250),
					new SqlParameter("@ScanSegmentsNmb", SqlDbType.Int,4),
					new SqlParameter("@ROI_width", SqlDbType.Float,8),
					new SqlParameter("@ROI_height", SqlDbType.Float,8),
					new SqlParameter("@AvgDiameter", SqlDbType.Float,8),
					new SqlParameter("@ExtractingDiameter", SqlDbType.Float,8),
					new SqlParameter("@MinModulation", SqlDbType.Int,4),
					new SqlParameter("@TopPixRemove", SqlDbType.Int,4),
					new SqlParameter("@TopPixLeft", SqlDbType.Int,4),
					new SqlParameter("@SampleType", SqlDbType.NVarChar,250),
					new SqlParameter("@Multimode", SqlDbType.Int,4),
					new SqlParameter("@MeasurementConfig", SqlDbType.NVarChar,250),
					new SqlParameter("@PassFail", SqlDbType.Int,4),
					new SqlParameter("@MaxFibDiffH", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_min", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_max", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxFibDiffAdjH", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_min", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_max", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxCoreDip", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_min", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_max", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@ROC_X", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_min", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_max", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@ROC_Y", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_min", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_max", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@XEndFaceAngle", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_min", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_max", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@YEndFaceAngle", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_min", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_max", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FlatnessDeviation", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_min", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_max", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberProtrusion_min", SqlDbType.Float,8),
					new SqlParameter("@FiberProtrusion_max", SqlDbType.Float,8),
					new SqlParameter("@FiberProtrusion_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberROC_min", SqlDbType.Float,8),
					new SqlParameter("@FiberROC_max", SqlDbType.Float,8),
					new SqlParameter("@FiberROC_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberHeight", SqlDbType.Image),
					new SqlParameter("@FiberCoreDip", SqlDbType.Image),
					new SqlParameter("@FiberROC", SqlDbType.Image),
					new SqlParameter("@TestPassed", SqlDbType.NVarChar,50),
					new SqlParameter("@FibArrayXAng", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_min", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_max", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FibArrayYAng", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_min", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_max", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@Coplanarity", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_min", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_max", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MinusCoplanarity", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_min", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_max", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_Pass", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Scan_ID;
			parameters[2].Value = model.ScanTime;
			parameters[3].Value = model.User_ID;
			parameters[4].Value = model.ProductID;
			parameters[5].Value = model.ConnectorID;
			parameters[6].Value = model.LightMode;
			parameters[7].Value = model.DataSource;
			parameters[8].Value = model.Microscope;
			parameters[9].Value = model.DataFilePath;
			parameters[10].Value = model.FiberCount;
			parameters[11].Value = model.FiberPitch;
			parameters[12].Value = model.FibersPerRow;
			parameters[13].Value = model.FiberRowPitch;
			parameters[14].Value = model.RowsVerticalOffset;
			parameters[15].Value = model.FiberCaptureShape;
			parameters[16].Value = model.Shape;
			parameters[17].Value = model.FiberDiameter;
			parameters[18].Value = model.FerruleType;
			parameters[19].Value = model.FerruleCount;
			parameters[20].Value = model.GuideStructureType;
			parameters[21].Value = model.GuideStructurePitch;
			parameters[22].Value = model.NominalYAngle;
			parameters[23].Value = model.ConnectorType;
			parameters[24].Value = model.ScanSegmentsNmb;
			parameters[25].Value = model.ROI_width;
			parameters[26].Value = model.ROI_height;
			parameters[27].Value = model.AvgDiameter;
			parameters[28].Value = model.ExtractingDiameter;
			parameters[29].Value = model.MinModulation;
			parameters[30].Value = model.TopPixRemove;
			parameters[31].Value = model.TopPixLeft;
			parameters[32].Value = model.SampleType;
			parameters[33].Value = model.Multimode;
			parameters[34].Value = model.MeasurementConfig;
			parameters[35].Value = model.PassFail;
			parameters[36].Value = model.MaxFibDiffH;
			parameters[37].Value = model.MaxFibDiffH_min;
			parameters[38].Value = model.MaxFibDiffH_max;
			parameters[39].Value = model.MaxFibDiffH_Pass;
			parameters[40].Value = model.MaxFibDiffAdjH;
			parameters[41].Value = model.MaxFibDiffAdjH_min;
			parameters[42].Value = model.MaxFibDiffAdjH_max;
			parameters[43].Value = model.MaxFibDiffAdjH_Pass;
			parameters[44].Value = model.MaxCoreDip;
			parameters[45].Value = model.MaxCoreDip_min;
			parameters[46].Value = model.MaxCoreDip_max;
			parameters[47].Value = model.MaxCoreDip_Pass;
			parameters[48].Value = model.ROC_X;
			parameters[49].Value = model.ROC_X_min;
			parameters[50].Value = model.ROC_X_max;
			parameters[51].Value = model.ROC_X_Pass;
			parameters[52].Value = model.ROC_Y;
			parameters[53].Value = model.ROC_Y_min;
			parameters[54].Value = model.ROC_Y_max;
			parameters[55].Value = model.ROC_Y_Pass;
			parameters[56].Value = model.XEndFaceAngle;
			parameters[57].Value = model.XEndFaceAngle_min;
			parameters[58].Value = model.XEndFaceAngle_max;
			parameters[59].Value = model.XEndFaceAngle_Pass;
			parameters[60].Value = model.YEndFaceAngle;
			parameters[61].Value = model.YEndFaceAngle_min;
			parameters[62].Value = model.YEndFaceAngle_max;
			parameters[63].Value = model.YEndFaceAngle_Pass;
			parameters[64].Value = model.FlatnessDeviation;
			parameters[65].Value = model.FlatnessDeviation_min;
			parameters[66].Value = model.FlatnessDeviation_max;
			parameters[67].Value = model.FlatnessDeviation_Pass;
			parameters[68].Value = model.FiberProtrusion_min;
			parameters[69].Value = model.FiberProtrusion_max;
			parameters[70].Value = model.FiberProtrusion_Pass;
			parameters[71].Value = model.FiberROC_min;
			parameters[72].Value = model.FiberROC_max;
			parameters[73].Value = model.FiberROC_Pass;
			parameters[74].Value = model.FiberHeight;
			parameters[75].Value = model.FiberCoreDip;
			parameters[76].Value = model.FiberROC;
			parameters[77].Value = model.TestPassed;
			parameters[78].Value = model.FibArrayXAng;
			parameters[79].Value = model.FibArrayXAng_min;
			parameters[80].Value = model.FibArrayXAng_max;
			parameters[81].Value = model.FibArrayXAng_Pass;
			parameters[82].Value = model.FibArrayYAng;
			parameters[83].Value = model.FibArrayYAng_min;
			parameters[84].Value = model.FibArrayYAng_max;
			parameters[85].Value = model.FibArrayYAng_Pass;
			parameters[86].Value = model.Coplanarity;
			parameters[87].Value = model.Coplanarity_min;
			parameters[88].Value = model.Coplanarity_max;
			parameters[89].Value = model.Coplanarity_Pass;
			parameters[90].Value = model.MinusCoplanarity;
			parameters[91].Value = model.MinusCoplanarity_min;
			parameters[92].Value = model.MinusCoplanarity_max;
			parameters[93].Value = model.MinusCoplanarity_Pass;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.tblMultiFiber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tblMultiFiber set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Scan_ID=@Scan_ID,");
			strSql.Append("ScanTime=@ScanTime,");
			strSql.Append("User_ID=@User_ID,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("ConnectorID=@ConnectorID,");
			strSql.Append("LightMode=@LightMode,");
			strSql.Append("DataSource=@DataSource,");
			strSql.Append("Microscope=@Microscope,");
			strSql.Append("DataFilePath=@DataFilePath,");
			strSql.Append("FiberCount=@FiberCount,");
			strSql.Append("FiberPitch=@FiberPitch,");
			strSql.Append("FibersPerRow=@FibersPerRow,");
			strSql.Append("FiberRowPitch=@FiberRowPitch,");
			strSql.Append("RowsVerticalOffset=@RowsVerticalOffset,");
			strSql.Append("FiberCaptureShape=@FiberCaptureShape,");
			strSql.Append("Shape=@Shape,");
			strSql.Append("FiberDiameter=@FiberDiameter,");
			strSql.Append("FerruleType=@FerruleType,");
			strSql.Append("FerruleCount=@FerruleCount,");
			strSql.Append("GuideStructureType=@GuideStructureType,");
			strSql.Append("GuideStructurePitch=@GuideStructurePitch,");
			strSql.Append("NominalYAngle=@NominalYAngle,");
			strSql.Append("ConnectorType=@ConnectorType,");
			strSql.Append("ScanSegmentsNmb=@ScanSegmentsNmb,");
			strSql.Append("ROI_width=@ROI_width,");
			strSql.Append("ROI_height=@ROI_height,");
			strSql.Append("AvgDiameter=@AvgDiameter,");
			strSql.Append("ExtractingDiameter=@ExtractingDiameter,");
			strSql.Append("MinModulation=@MinModulation,");
			strSql.Append("TopPixRemove=@TopPixRemove,");
			strSql.Append("TopPixLeft=@TopPixLeft,");
			strSql.Append("SampleType=@SampleType,");
			strSql.Append("Multimode=@Multimode,");
			strSql.Append("MeasurementConfig=@MeasurementConfig,");
			strSql.Append("PassFail=@PassFail,");
			strSql.Append("MaxFibDiffH=@MaxFibDiffH,");
			strSql.Append("MaxFibDiffH_min=@MaxFibDiffH_min,");
			strSql.Append("MaxFibDiffH_max=@MaxFibDiffH_max,");
			strSql.Append("MaxFibDiffH_Pass=@MaxFibDiffH_Pass,");
			strSql.Append("MaxFibDiffAdjH=@MaxFibDiffAdjH,");
			strSql.Append("MaxFibDiffAdjH_min=@MaxFibDiffAdjH_min,");
			strSql.Append("MaxFibDiffAdjH_max=@MaxFibDiffAdjH_max,");
			strSql.Append("MaxFibDiffAdjH_Pass=@MaxFibDiffAdjH_Pass,");
			strSql.Append("MaxCoreDip=@MaxCoreDip,");
			strSql.Append("MaxCoreDip_min=@MaxCoreDip_min,");
			strSql.Append("MaxCoreDip_max=@MaxCoreDip_max,");
			strSql.Append("MaxCoreDip_Pass=@MaxCoreDip_Pass,");
			strSql.Append("ROC_X=@ROC_X,");
			strSql.Append("ROC_X_min=@ROC_X_min,");
			strSql.Append("ROC_X_max=@ROC_X_max,");
			strSql.Append("ROC_X_Pass=@ROC_X_Pass,");
			strSql.Append("ROC_Y=@ROC_Y,");
			strSql.Append("ROC_Y_min=@ROC_Y_min,");
			strSql.Append("ROC_Y_max=@ROC_Y_max,");
			strSql.Append("ROC_Y_Pass=@ROC_Y_Pass,");
			strSql.Append("XEndFaceAngle=@XEndFaceAngle,");
			strSql.Append("XEndFaceAngle_min=@XEndFaceAngle_min,");
			strSql.Append("XEndFaceAngle_max=@XEndFaceAngle_max,");
			strSql.Append("XEndFaceAngle_Pass=@XEndFaceAngle_Pass,");
			strSql.Append("YEndFaceAngle=@YEndFaceAngle,");
			strSql.Append("YEndFaceAngle_min=@YEndFaceAngle_min,");
			strSql.Append("YEndFaceAngle_max=@YEndFaceAngle_max,");
			strSql.Append("YEndFaceAngle_Pass=@YEndFaceAngle_Pass,");
			strSql.Append("FlatnessDeviation=@FlatnessDeviation,");
			strSql.Append("FlatnessDeviation_min=@FlatnessDeviation_min,");
			strSql.Append("FlatnessDeviation_max=@FlatnessDeviation_max,");
			strSql.Append("FlatnessDeviation_Pass=@FlatnessDeviation_Pass,");
			strSql.Append("FiberProtrusion_min=@FiberProtrusion_min,");
			strSql.Append("FiberProtrusion_max=@FiberProtrusion_max,");
			strSql.Append("FiberProtrusion_Pass=@FiberProtrusion_Pass,");
			strSql.Append("FiberROC_min=@FiberROC_min,");
			strSql.Append("FiberROC_max=@FiberROC_max,");
			strSql.Append("FiberROC_Pass=@FiberROC_Pass,");
			strSql.Append("FiberHeight=@FiberHeight,");
			strSql.Append("FiberCoreDip=@FiberCoreDip,");
			strSql.Append("FiberROC=@FiberROC,");
			strSql.Append("TestPassed=@TestPassed,");
			strSql.Append("FibArrayXAng=@FibArrayXAng,");
			strSql.Append("FibArrayXAng_min=@FibArrayXAng_min,");
			strSql.Append("FibArrayXAng_max=@FibArrayXAng_max,");
			strSql.Append("FibArrayXAng_Pass=@FibArrayXAng_Pass,");
			strSql.Append("FibArrayYAng=@FibArrayYAng,");
			strSql.Append("FibArrayYAng_min=@FibArrayYAng_min,");
			strSql.Append("FibArrayYAng_max=@FibArrayYAng_max,");
			strSql.Append("FibArrayYAng_Pass=@FibArrayYAng_Pass,");
			strSql.Append("Coplanarity=@Coplanarity,");
			strSql.Append("Coplanarity_min=@Coplanarity_min,");
			strSql.Append("Coplanarity_max=@Coplanarity_max,");
			strSql.Append("Coplanarity_Pass=@Coplanarity_Pass,");
			strSql.Append("MinusCoplanarity=@MinusCoplanarity,");
			strSql.Append("MinusCoplanarity_min=@MinusCoplanarity_min,");
			strSql.Append("MinusCoplanarity_max=@MinusCoplanarity_max,");
			strSql.Append("MinusCoplanarity_Pass=@MinusCoplanarity_Pass");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Scan_ID", SqlDbType.Int,4),
					new SqlParameter("@ScanTime", SqlDbType.DateTime),
					new SqlParameter("@User_ID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.NVarChar,255),
					new SqlParameter("@ConnectorID", SqlDbType.NVarChar,255),
					new SqlParameter("@LightMode", SqlDbType.NVarChar,50),
					new SqlParameter("@DataSource", SqlDbType.NVarChar,50),
					new SqlParameter("@Microscope", SqlDbType.NVarChar,50),
					new SqlParameter("@DataFilePath", SqlDbType.NVarChar,250),
					new SqlParameter("@FiberCount", SqlDbType.Int,4),
					new SqlParameter("@FiberPitch", SqlDbType.Float,8),
					new SqlParameter("@FibersPerRow", SqlDbType.Int,4),
					new SqlParameter("@FiberRowPitch", SqlDbType.Float,8),
					new SqlParameter("@RowsVerticalOffset", SqlDbType.Float,8),
					new SqlParameter("@FiberCaptureShape", SqlDbType.NVarChar,250),
					new SqlParameter("@Shape", SqlDbType.NVarChar,250),
					new SqlParameter("@FiberDiameter", SqlDbType.Float,8),
					new SqlParameter("@FerruleType", SqlDbType.NVarChar,250),
					new SqlParameter("@FerruleCount", SqlDbType.Int,4),
					new SqlParameter("@GuideStructureType", SqlDbType.NVarChar,250),
					new SqlParameter("@GuideStructurePitch", SqlDbType.Float,8),
					new SqlParameter("@NominalYAngle", SqlDbType.Float,8),
					new SqlParameter("@ConnectorType", SqlDbType.NVarChar,250),
					new SqlParameter("@ScanSegmentsNmb", SqlDbType.Int,4),
					new SqlParameter("@ROI_width", SqlDbType.Float,8),
					new SqlParameter("@ROI_height", SqlDbType.Float,8),
					new SqlParameter("@AvgDiameter", SqlDbType.Float,8),
					new SqlParameter("@ExtractingDiameter", SqlDbType.Float,8),
					new SqlParameter("@MinModulation", SqlDbType.Int,4),
					new SqlParameter("@TopPixRemove", SqlDbType.Int,4),
					new SqlParameter("@TopPixLeft", SqlDbType.Int,4),
					new SqlParameter("@SampleType", SqlDbType.NVarChar,250),
					new SqlParameter("@Multimode", SqlDbType.Int,4),
					new SqlParameter("@MeasurementConfig", SqlDbType.NVarChar,250),
					new SqlParameter("@PassFail", SqlDbType.Int,4),
					new SqlParameter("@MaxFibDiffH", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_min", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_max", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffH_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxFibDiffAdjH", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_min", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_max", SqlDbType.Float,8),
					new SqlParameter("@MaxFibDiffAdjH_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MaxCoreDip", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_min", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_max", SqlDbType.Float,8),
					new SqlParameter("@MaxCoreDip_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@ROC_X", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_min", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_max", SqlDbType.Float,8),
					new SqlParameter("@ROC_X_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@ROC_Y", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_min", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_max", SqlDbType.Float,8),
					new SqlParameter("@ROC_Y_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@XEndFaceAngle", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_min", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_max", SqlDbType.Float,8),
					new SqlParameter("@XEndFaceAngle_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@YEndFaceAngle", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_min", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_max", SqlDbType.Float,8),
					new SqlParameter("@YEndFaceAngle_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FlatnessDeviation", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_min", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_max", SqlDbType.Float,8),
					new SqlParameter("@FlatnessDeviation_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberProtrusion_min", SqlDbType.Float,8),
					new SqlParameter("@FiberProtrusion_max", SqlDbType.Float,8),
					new SqlParameter("@FiberProtrusion_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberROC_min", SqlDbType.Float,8),
					new SqlParameter("@FiberROC_max", SqlDbType.Float,8),
					new SqlParameter("@FiberROC_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FiberHeight", SqlDbType.Image),
					new SqlParameter("@FiberCoreDip", SqlDbType.Image),
					new SqlParameter("@FiberROC", SqlDbType.Image),
					new SqlParameter("@TestPassed", SqlDbType.NVarChar,50),
					new SqlParameter("@FibArrayXAng", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_min", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_max", SqlDbType.Float,8),
					new SqlParameter("@FibArrayXAng_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@FibArrayYAng", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_min", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_max", SqlDbType.Float,8),
					new SqlParameter("@FibArrayYAng_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@Coplanarity", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_min", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_max", SqlDbType.Float,8),
					new SqlParameter("@Coplanarity_Pass", SqlDbType.NVarChar,50),
					new SqlParameter("@MinusCoplanarity", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_min", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_max", SqlDbType.Float,8),
					new SqlParameter("@MinusCoplanarity_Pass", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Scan_ID;
			parameters[2].Value = model.ScanTime;
			parameters[3].Value = model.User_ID;
			parameters[4].Value = model.ProductID;
			parameters[5].Value = model.ConnectorID;
			parameters[6].Value = model.LightMode;
			parameters[7].Value = model.DataSource;
			parameters[8].Value = model.Microscope;
			parameters[9].Value = model.DataFilePath;
			parameters[10].Value = model.FiberCount;
			parameters[11].Value = model.FiberPitch;
			parameters[12].Value = model.FibersPerRow;
			parameters[13].Value = model.FiberRowPitch;
			parameters[14].Value = model.RowsVerticalOffset;
			parameters[15].Value = model.FiberCaptureShape;
			parameters[16].Value = model.Shape;
			parameters[17].Value = model.FiberDiameter;
			parameters[18].Value = model.FerruleType;
			parameters[19].Value = model.FerruleCount;
			parameters[20].Value = model.GuideStructureType;
			parameters[21].Value = model.GuideStructurePitch;
			parameters[22].Value = model.NominalYAngle;
			parameters[23].Value = model.ConnectorType;
			parameters[24].Value = model.ScanSegmentsNmb;
			parameters[25].Value = model.ROI_width;
			parameters[26].Value = model.ROI_height;
			parameters[27].Value = model.AvgDiameter;
			parameters[28].Value = model.ExtractingDiameter;
			parameters[29].Value = model.MinModulation;
			parameters[30].Value = model.TopPixRemove;
			parameters[31].Value = model.TopPixLeft;
			parameters[32].Value = model.SampleType;
			parameters[33].Value = model.Multimode;
			parameters[34].Value = model.MeasurementConfig;
			parameters[35].Value = model.PassFail;
			parameters[36].Value = model.MaxFibDiffH;
			parameters[37].Value = model.MaxFibDiffH_min;
			parameters[38].Value = model.MaxFibDiffH_max;
			parameters[39].Value = model.MaxFibDiffH_Pass;
			parameters[40].Value = model.MaxFibDiffAdjH;
			parameters[41].Value = model.MaxFibDiffAdjH_min;
			parameters[42].Value = model.MaxFibDiffAdjH_max;
			parameters[43].Value = model.MaxFibDiffAdjH_Pass;
			parameters[44].Value = model.MaxCoreDip;
			parameters[45].Value = model.MaxCoreDip_min;
			parameters[46].Value = model.MaxCoreDip_max;
			parameters[47].Value = model.MaxCoreDip_Pass;
			parameters[48].Value = model.ROC_X;
			parameters[49].Value = model.ROC_X_min;
			parameters[50].Value = model.ROC_X_max;
			parameters[51].Value = model.ROC_X_Pass;
			parameters[52].Value = model.ROC_Y;
			parameters[53].Value = model.ROC_Y_min;
			parameters[54].Value = model.ROC_Y_max;
			parameters[55].Value = model.ROC_Y_Pass;
			parameters[56].Value = model.XEndFaceAngle;
			parameters[57].Value = model.XEndFaceAngle_min;
			parameters[58].Value = model.XEndFaceAngle_max;
			parameters[59].Value = model.XEndFaceAngle_Pass;
			parameters[60].Value = model.YEndFaceAngle;
			parameters[61].Value = model.YEndFaceAngle_min;
			parameters[62].Value = model.YEndFaceAngle_max;
			parameters[63].Value = model.YEndFaceAngle_Pass;
			parameters[64].Value = model.FlatnessDeviation;
			parameters[65].Value = model.FlatnessDeviation_min;
			parameters[66].Value = model.FlatnessDeviation_max;
			parameters[67].Value = model.FlatnessDeviation_Pass;
			parameters[68].Value = model.FiberProtrusion_min;
			parameters[69].Value = model.FiberProtrusion_max;
			parameters[70].Value = model.FiberProtrusion_Pass;
			parameters[71].Value = model.FiberROC_min;
			parameters[72].Value = model.FiberROC_max;
			parameters[73].Value = model.FiberROC_Pass;
			parameters[74].Value = model.FiberHeight;
			parameters[75].Value = model.FiberCoreDip;
			parameters[76].Value = model.FiberROC;
			parameters[77].Value = model.TestPassed;
			parameters[78].Value = model.FibArrayXAng;
			parameters[79].Value = model.FibArrayXAng_min;
			parameters[80].Value = model.FibArrayXAng_max;
			parameters[81].Value = model.FibArrayXAng_Pass;
			parameters[82].Value = model.FibArrayYAng;
			parameters[83].Value = model.FibArrayYAng_min;
			parameters[84].Value = model.FibArrayYAng_max;
			parameters[85].Value = model.FibArrayYAng_Pass;
			parameters[86].Value = model.Coplanarity;
			parameters[87].Value = model.Coplanarity_min;
			parameters[88].Value = model.Coplanarity_max;
			parameters[89].Value = model.Coplanarity_Pass;
			parameters[90].Value = model.MinusCoplanarity;
			parameters[91].Value = model.MinusCoplanarity_min;
			parameters[92].Value = model.MinusCoplanarity_max;
			parameters[93].Value = model.MinusCoplanarity_Pass;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tblMultiFiber ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public Maticsoft.Model.tblMultiFiber GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Scan_ID,ScanTime,User_ID,ProductID,ConnectorID,LightMode,DataSource,Microscope,DataFilePath,FiberCount,FiberPitch,FibersPerRow,FiberRowPitch,RowsVerticalOffset,FiberCaptureShape,Shape,FiberDiameter,FerruleType,FerruleCount,GuideStructureType,GuideStructurePitch,NominalYAngle,ConnectorType,ScanSegmentsNmb,ROI_width,ROI_height,AvgDiameter,ExtractingDiameter,MinModulation,TopPixRemove,TopPixLeft,SampleType,Multimode,MeasurementConfig,PassFail,MaxFibDiffH,MaxFibDiffH_min,MaxFibDiffH_max,MaxFibDiffH_Pass,MaxFibDiffAdjH,MaxFibDiffAdjH_min,MaxFibDiffAdjH_max,MaxFibDiffAdjH_Pass,MaxCoreDip,MaxCoreDip_min,MaxCoreDip_max,MaxCoreDip_Pass,ROC_X,ROC_X_min,ROC_X_max,ROC_X_Pass,ROC_Y,ROC_Y_min,ROC_Y_max,ROC_Y_Pass,XEndFaceAngle,XEndFaceAngle_min,XEndFaceAngle_max,XEndFaceAngle_Pass,YEndFaceAngle,YEndFaceAngle_min,YEndFaceAngle_max,YEndFaceAngle_Pass,FlatnessDeviation,FlatnessDeviation_min,FlatnessDeviation_max,FlatnessDeviation_Pass,FiberProtrusion_min,FiberProtrusion_max,FiberProtrusion_Pass,FiberROC_min,FiberROC_max,FiberROC_Pass,FiberHeight,FiberCoreDip,FiberROC,TestPassed,FibArrayXAng,FibArrayXAng_min,FibArrayXAng_max,FibArrayXAng_Pass,FibArrayYAng,FibArrayYAng_min,FibArrayYAng_max,FibArrayYAng_Pass,Coplanarity,Coplanarity_min,Coplanarity_max,Coplanarity_Pass,MinusCoplanarity,MinusCoplanarity_min,MinusCoplanarity_max,MinusCoplanarity_Pass from tblMultiFiber ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.tblMultiFiber model=new Maticsoft.Model.tblMultiFiber();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.tblMultiFiber DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tblMultiFiber model=new Maticsoft.Model.tblMultiFiber();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Scan_ID"]!=null && row["Scan_ID"].ToString()!="")
				{
					model.Scan_ID=int.Parse(row["Scan_ID"].ToString());
				}
				if(row["ScanTime"]!=null && row["ScanTime"].ToString()!="")
				{
					model.ScanTime=DateTime.Parse(row["ScanTime"].ToString());
				}
				if(row["User_ID"]!=null && row["User_ID"].ToString()!="")
				{
					model.User_ID=int.Parse(row["User_ID"].ToString());
				}
				if(row["ProductID"]!=null)
				{
					model.ProductID=row["ProductID"].ToString();
				}
				if(row["ConnectorID"]!=null)
				{
					model.ConnectorID=row["ConnectorID"].ToString();
				}
				if(row["LightMode"]!=null)
				{
					model.LightMode=row["LightMode"].ToString();
				}
				if(row["DataSource"]!=null)
				{
					model.DataSource=row["DataSource"].ToString();
				}
				if(row["Microscope"]!=null)
				{
					model.Microscope=row["Microscope"].ToString();
				}
				if(row["DataFilePath"]!=null)
				{
					model.DataFilePath=row["DataFilePath"].ToString();
				}
				if(row["FiberCount"]!=null && row["FiberCount"].ToString()!="")
				{
					model.FiberCount=int.Parse(row["FiberCount"].ToString());
				}
				if(row["FiberPitch"]!=null && row["FiberPitch"].ToString()!="")
				{
					model.FiberPitch=decimal.Parse(row["FiberPitch"].ToString());
				}
				if(row["FibersPerRow"]!=null && row["FibersPerRow"].ToString()!="")
				{
					model.FibersPerRow=int.Parse(row["FibersPerRow"].ToString());
				}
				if(row["FiberRowPitch"]!=null && row["FiberRowPitch"].ToString()!="")
				{
					model.FiberRowPitch=decimal.Parse(row["FiberRowPitch"].ToString());
				}
				if(row["RowsVerticalOffset"]!=null && row["RowsVerticalOffset"].ToString()!="")
				{
					model.RowsVerticalOffset=decimal.Parse(row["RowsVerticalOffset"].ToString());
				}
				if(row["FiberCaptureShape"]!=null)
				{
					model.FiberCaptureShape=row["FiberCaptureShape"].ToString();
				}
				if(row["Shape"]!=null)
				{
					model.Shape=row["Shape"].ToString();
				}
				if(row["FiberDiameter"]!=null && row["FiberDiameter"].ToString()!="")
				{
					model.FiberDiameter=decimal.Parse(row["FiberDiameter"].ToString());
				}
				if(row["FerruleType"]!=null)
				{
					model.FerruleType=row["FerruleType"].ToString();
				}
				if(row["FerruleCount"]!=null && row["FerruleCount"].ToString()!="")
				{
					model.FerruleCount=int.Parse(row["FerruleCount"].ToString());
				}
				if(row["GuideStructureType"]!=null)
				{
					model.GuideStructureType=row["GuideStructureType"].ToString();
				}
				if(row["GuideStructurePitch"]!=null && row["GuideStructurePitch"].ToString()!="")
				{
					model.GuideStructurePitch=decimal.Parse(row["GuideStructurePitch"].ToString());
				}
				if(row["NominalYAngle"]!=null && row["NominalYAngle"].ToString()!="")
				{
					model.NominalYAngle=decimal.Parse(row["NominalYAngle"].ToString());
				}
				if(row["ConnectorType"]!=null)
				{
					model.ConnectorType=row["ConnectorType"].ToString();
				}
				if(row["ScanSegmentsNmb"]!=null && row["ScanSegmentsNmb"].ToString()!="")
				{
					model.ScanSegmentsNmb=int.Parse(row["ScanSegmentsNmb"].ToString());
				}
				if(row["ROI_width"]!=null && row["ROI_width"].ToString()!="")
				{
					model.ROI_width=decimal.Parse(row["ROI_width"].ToString());
				}
				if(row["ROI_height"]!=null && row["ROI_height"].ToString()!="")
				{
					model.ROI_height=decimal.Parse(row["ROI_height"].ToString());
				}
				if(row["AvgDiameter"]!=null && row["AvgDiameter"].ToString()!="")
				{
					model.AvgDiameter=decimal.Parse(row["AvgDiameter"].ToString());
				}
				if(row["ExtractingDiameter"]!=null && row["ExtractingDiameter"].ToString()!="")
				{
					model.ExtractingDiameter=decimal.Parse(row["ExtractingDiameter"].ToString());
				}
				if(row["MinModulation"]!=null && row["MinModulation"].ToString()!="")
				{
					model.MinModulation=int.Parse(row["MinModulation"].ToString());
				}
				if(row["TopPixRemove"]!=null && row["TopPixRemove"].ToString()!="")
				{
					model.TopPixRemove=int.Parse(row["TopPixRemove"].ToString());
				}
				if(row["TopPixLeft"]!=null && row["TopPixLeft"].ToString()!="")
				{
					model.TopPixLeft=int.Parse(row["TopPixLeft"].ToString());
				}
				if(row["SampleType"]!=null)
				{
					model.SampleType=row["SampleType"].ToString();
				}
				if(row["Multimode"]!=null && row["Multimode"].ToString()!="")
				{
					model.Multimode=int.Parse(row["Multimode"].ToString());
				}
				if(row["MeasurementConfig"]!=null)
				{
					model.MeasurementConfig=row["MeasurementConfig"].ToString();
				}
				if(row["PassFail"]!=null && row["PassFail"].ToString()!="")
				{
					model.PassFail=int.Parse(row["PassFail"].ToString());
				}
				if(row["MaxFibDiffH"]!=null && row["MaxFibDiffH"].ToString()!="")
				{
					model.MaxFibDiffH=decimal.Parse(row["MaxFibDiffH"].ToString());
				}
				if(row["MaxFibDiffH_min"]!=null && row["MaxFibDiffH_min"].ToString()!="")
				{
					model.MaxFibDiffH_min=decimal.Parse(row["MaxFibDiffH_min"].ToString());
				}
				if(row["MaxFibDiffH_max"]!=null && row["MaxFibDiffH_max"].ToString()!="")
				{
					model.MaxFibDiffH_max=decimal.Parse(row["MaxFibDiffH_max"].ToString());
				}
				if(row["MaxFibDiffH_Pass"]!=null)
				{
					model.MaxFibDiffH_Pass=row["MaxFibDiffH_Pass"].ToString();
				}
				if(row["MaxFibDiffAdjH"]!=null && row["MaxFibDiffAdjH"].ToString()!="")
				{
					model.MaxFibDiffAdjH=decimal.Parse(row["MaxFibDiffAdjH"].ToString());
				}
				if(row["MaxFibDiffAdjH_min"]!=null && row["MaxFibDiffAdjH_min"].ToString()!="")
				{
					model.MaxFibDiffAdjH_min=decimal.Parse(row["MaxFibDiffAdjH_min"].ToString());
				}
				if(row["MaxFibDiffAdjH_max"]!=null && row["MaxFibDiffAdjH_max"].ToString()!="")
				{
					model.MaxFibDiffAdjH_max=decimal.Parse(row["MaxFibDiffAdjH_max"].ToString());
				}
				if(row["MaxFibDiffAdjH_Pass"]!=null)
				{
					model.MaxFibDiffAdjH_Pass=row["MaxFibDiffAdjH_Pass"].ToString();
				}
				if(row["MaxCoreDip"]!=null && row["MaxCoreDip"].ToString()!="")
				{
					model.MaxCoreDip=decimal.Parse(row["MaxCoreDip"].ToString());
				}
				if(row["MaxCoreDip_min"]!=null && row["MaxCoreDip_min"].ToString()!="")
				{
					model.MaxCoreDip_min=decimal.Parse(row["MaxCoreDip_min"].ToString());
				}
				if(row["MaxCoreDip_max"]!=null && row["MaxCoreDip_max"].ToString()!="")
				{
					model.MaxCoreDip_max=decimal.Parse(row["MaxCoreDip_max"].ToString());
				}
				if(row["MaxCoreDip_Pass"]!=null)
				{
					model.MaxCoreDip_Pass=row["MaxCoreDip_Pass"].ToString();
				}
				if(row["ROC_X"]!=null && row["ROC_X"].ToString()!="")
				{
					model.ROC_X=decimal.Parse(row["ROC_X"].ToString());
				}
				if(row["ROC_X_min"]!=null && row["ROC_X_min"].ToString()!="")
				{
					model.ROC_X_min=decimal.Parse(row["ROC_X_min"].ToString());
				}
				if(row["ROC_X_max"]!=null && row["ROC_X_max"].ToString()!="")
				{
					model.ROC_X_max=decimal.Parse(row["ROC_X_max"].ToString());
				}
				if(row["ROC_X_Pass"]!=null)
				{
					model.ROC_X_Pass=row["ROC_X_Pass"].ToString();
				}
				if(row["ROC_Y"]!=null && row["ROC_Y"].ToString()!="")
				{
					model.ROC_Y=decimal.Parse(row["ROC_Y"].ToString());
				}
				if(row["ROC_Y_min"]!=null && row["ROC_Y_min"].ToString()!="")
				{
					model.ROC_Y_min=decimal.Parse(row["ROC_Y_min"].ToString());
				}
				if(row["ROC_Y_max"]!=null && row["ROC_Y_max"].ToString()!="")
				{
					model.ROC_Y_max=decimal.Parse(row["ROC_Y_max"].ToString());
				}
				if(row["ROC_Y_Pass"]!=null)
				{
					model.ROC_Y_Pass=row["ROC_Y_Pass"].ToString();
				}
				if(row["XEndFaceAngle"]!=null && row["XEndFaceAngle"].ToString()!="")
				{
					model.XEndFaceAngle=decimal.Parse(row["XEndFaceAngle"].ToString());
				}
				if(row["XEndFaceAngle_min"]!=null && row["XEndFaceAngle_min"].ToString()!="")
				{
					model.XEndFaceAngle_min=decimal.Parse(row["XEndFaceAngle_min"].ToString());
				}
				if(row["XEndFaceAngle_max"]!=null && row["XEndFaceAngle_max"].ToString()!="")
				{
					model.XEndFaceAngle_max=decimal.Parse(row["XEndFaceAngle_max"].ToString());
				}
				if(row["XEndFaceAngle_Pass"]!=null)
				{
					model.XEndFaceAngle_Pass=row["XEndFaceAngle_Pass"].ToString();
				}
				if(row["YEndFaceAngle"]!=null && row["YEndFaceAngle"].ToString()!="")
				{
					model.YEndFaceAngle=decimal.Parse(row["YEndFaceAngle"].ToString());
				}
				if(row["YEndFaceAngle_min"]!=null && row["YEndFaceAngle_min"].ToString()!="")
				{
					model.YEndFaceAngle_min=decimal.Parse(row["YEndFaceAngle_min"].ToString());
				}
				if(row["YEndFaceAngle_max"]!=null && row["YEndFaceAngle_max"].ToString()!="")
				{
					model.YEndFaceAngle_max=decimal.Parse(row["YEndFaceAngle_max"].ToString());
				}
				if(row["YEndFaceAngle_Pass"]!=null)
				{
					model.YEndFaceAngle_Pass=row["YEndFaceAngle_Pass"].ToString();
				}
				if(row["FlatnessDeviation"]!=null && row["FlatnessDeviation"].ToString()!="")
				{
					model.FlatnessDeviation=decimal.Parse(row["FlatnessDeviation"].ToString());
				}
				if(row["FlatnessDeviation_min"]!=null && row["FlatnessDeviation_min"].ToString()!="")
				{
					model.FlatnessDeviation_min=decimal.Parse(row["FlatnessDeviation_min"].ToString());
				}
				if(row["FlatnessDeviation_max"]!=null && row["FlatnessDeviation_max"].ToString()!="")
				{
					model.FlatnessDeviation_max=decimal.Parse(row["FlatnessDeviation_max"].ToString());
				}
				if(row["FlatnessDeviation_Pass"]!=null)
				{
					model.FlatnessDeviation_Pass=row["FlatnessDeviation_Pass"].ToString();
				}
				if(row["FiberProtrusion_min"]!=null && row["FiberProtrusion_min"].ToString()!="")
				{
					model.FiberProtrusion_min=decimal.Parse(row["FiberProtrusion_min"].ToString());
				}
				if(row["FiberProtrusion_max"]!=null && row["FiberProtrusion_max"].ToString()!="")
				{
					model.FiberProtrusion_max=decimal.Parse(row["FiberProtrusion_max"].ToString());
				}
				if(row["FiberProtrusion_Pass"]!=null)
				{
					model.FiberProtrusion_Pass=row["FiberProtrusion_Pass"].ToString();
				}
				if(row["FiberROC_min"]!=null && row["FiberROC_min"].ToString()!="")
				{
					model.FiberROC_min=decimal.Parse(row["FiberROC_min"].ToString());
				}
				if(row["FiberROC_max"]!=null && row["FiberROC_max"].ToString()!="")
				{
					model.FiberROC_max=decimal.Parse(row["FiberROC_max"].ToString());
				}
				if(row["FiberROC_Pass"]!=null)
				{
					model.FiberROC_Pass=row["FiberROC_Pass"].ToString();
				}
				if(row["FiberHeight"]!=null && row["FiberHeight"].ToString()!="")
				{
					model.FiberHeight=(byte[])row["FiberHeight"];
				}
				if(row["FiberCoreDip"]!=null && row["FiberCoreDip"].ToString()!="")
				{
					model.FiberCoreDip=(byte[])row["FiberCoreDip"];
				}
				if(row["FiberROC"]!=null && row["FiberROC"].ToString()!="")
				{
					model.FiberROC=(byte[])row["FiberROC"];
				}
				if(row["TestPassed"]!=null)
				{
					model.TestPassed=row["TestPassed"].ToString();
				}
				if(row["FibArrayXAng"]!=null && row["FibArrayXAng"].ToString()!="")
				{
					model.FibArrayXAng=decimal.Parse(row["FibArrayXAng"].ToString());
				}
				if(row["FibArrayXAng_min"]!=null && row["FibArrayXAng_min"].ToString()!="")
				{
					model.FibArrayXAng_min=decimal.Parse(row["FibArrayXAng_min"].ToString());
				}
				if(row["FibArrayXAng_max"]!=null && row["FibArrayXAng_max"].ToString()!="")
				{
					model.FibArrayXAng_max=decimal.Parse(row["FibArrayXAng_max"].ToString());
				}
				if(row["FibArrayXAng_Pass"]!=null)
				{
					model.FibArrayXAng_Pass=row["FibArrayXAng_Pass"].ToString();
				}
				if(row["FibArrayYAng"]!=null && row["FibArrayYAng"].ToString()!="")
				{
					model.FibArrayYAng=decimal.Parse(row["FibArrayYAng"].ToString());
				}
				if(row["FibArrayYAng_min"]!=null && row["FibArrayYAng_min"].ToString()!="")
				{
					model.FibArrayYAng_min=decimal.Parse(row["FibArrayYAng_min"].ToString());
				}
				if(row["FibArrayYAng_max"]!=null && row["FibArrayYAng_max"].ToString()!="")
				{
					model.FibArrayYAng_max=decimal.Parse(row["FibArrayYAng_max"].ToString());
				}
				if(row["FibArrayYAng_Pass"]!=null)
				{
					model.FibArrayYAng_Pass=row["FibArrayYAng_Pass"].ToString();
				}
				if(row["Coplanarity"]!=null && row["Coplanarity"].ToString()!="")
				{
					model.Coplanarity=decimal.Parse(row["Coplanarity"].ToString());
				}
				if(row["Coplanarity_min"]!=null && row["Coplanarity_min"].ToString()!="")
				{
					model.Coplanarity_min=decimal.Parse(row["Coplanarity_min"].ToString());
				}
				if(row["Coplanarity_max"]!=null && row["Coplanarity_max"].ToString()!="")
				{
					model.Coplanarity_max=decimal.Parse(row["Coplanarity_max"].ToString());
				}
				if(row["Coplanarity_Pass"]!=null)
				{
					model.Coplanarity_Pass=row["Coplanarity_Pass"].ToString();
				}
				if(row["MinusCoplanarity"]!=null && row["MinusCoplanarity"].ToString()!="")
				{
					model.MinusCoplanarity=decimal.Parse(row["MinusCoplanarity"].ToString());
				}
				if(row["MinusCoplanarity_min"]!=null && row["MinusCoplanarity_min"].ToString()!="")
				{
					model.MinusCoplanarity_min=decimal.Parse(row["MinusCoplanarity_min"].ToString());
				}
				if(row["MinusCoplanarity_max"]!=null && row["MinusCoplanarity_max"].ToString()!="")
				{
					model.MinusCoplanarity_max=decimal.Parse(row["MinusCoplanarity_max"].ToString());
				}
				if(row["MinusCoplanarity_Pass"]!=null)
				{
					model.MinusCoplanarity_Pass=row["MinusCoplanarity_Pass"].ToString();
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
			strSql.Append("select ID,Scan_ID,ScanTime,User_ID,ProductID,ConnectorID,LightMode,DataSource,Microscope,DataFilePath,FiberCount,FiberPitch,FibersPerRow,FiberRowPitch,RowsVerticalOffset,FiberCaptureShape,Shape,FiberDiameter,FerruleType,FerruleCount,GuideStructureType,GuideStructurePitch,NominalYAngle,ConnectorType,ScanSegmentsNmb,ROI_width,ROI_height,AvgDiameter,ExtractingDiameter,MinModulation,TopPixRemove,TopPixLeft,SampleType,Multimode,MeasurementConfig,PassFail,MaxFibDiffH,MaxFibDiffH_min,MaxFibDiffH_max,MaxFibDiffH_Pass,MaxFibDiffAdjH,MaxFibDiffAdjH_min,MaxFibDiffAdjH_max,MaxFibDiffAdjH_Pass,MaxCoreDip,MaxCoreDip_min,MaxCoreDip_max,MaxCoreDip_Pass,ROC_X,ROC_X_min,ROC_X_max,ROC_X_Pass,ROC_Y,ROC_Y_min,ROC_Y_max,ROC_Y_Pass,XEndFaceAngle,XEndFaceAngle_min,XEndFaceAngle_max,XEndFaceAngle_Pass,YEndFaceAngle,YEndFaceAngle_min,YEndFaceAngle_max,YEndFaceAngle_Pass,FlatnessDeviation,FlatnessDeviation_min,FlatnessDeviation_max,FlatnessDeviation_Pass,FiberProtrusion_min,FiberProtrusion_max,FiberProtrusion_Pass,FiberROC_min,FiberROC_max,FiberROC_Pass,FiberHeight,FiberCoreDip,FiberROC,TestPassed,FibArrayXAng,FibArrayXAng_min,FibArrayXAng_max,FibArrayXAng_Pass,FibArrayYAng,FibArrayYAng_min,FibArrayYAng_max,FibArrayYAng_Pass,Coplanarity,Coplanarity_min,Coplanarity_max,Coplanarity_Pass,MinusCoplanarity,MinusCoplanarity_min,MinusCoplanarity_max,MinusCoplanarity_Pass ");
			strSql.Append(" FROM tblMultiFiber ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" ID,Scan_ID,ScanTime,User_ID,ProductID,ConnectorID,LightMode,DataSource,Microscope,DataFilePath,FiberCount,FiberPitch,FibersPerRow,FiberRowPitch,RowsVerticalOffset,FiberCaptureShape,Shape,FiberDiameter,FerruleType,FerruleCount,GuideStructureType,GuideStructurePitch,NominalYAngle,ConnectorType,ScanSegmentsNmb,ROI_width,ROI_height,AvgDiameter,ExtractingDiameter,MinModulation,TopPixRemove,TopPixLeft,SampleType,Multimode,MeasurementConfig,PassFail,MaxFibDiffH,MaxFibDiffH_min,MaxFibDiffH_max,MaxFibDiffH_Pass,MaxFibDiffAdjH,MaxFibDiffAdjH_min,MaxFibDiffAdjH_max,MaxFibDiffAdjH_Pass,MaxCoreDip,MaxCoreDip_min,MaxCoreDip_max,MaxCoreDip_Pass,ROC_X,ROC_X_min,ROC_X_max,ROC_X_Pass,ROC_Y,ROC_Y_min,ROC_Y_max,ROC_Y_Pass,XEndFaceAngle,XEndFaceAngle_min,XEndFaceAngle_max,XEndFaceAngle_Pass,YEndFaceAngle,YEndFaceAngle_min,YEndFaceAngle_max,YEndFaceAngle_Pass,FlatnessDeviation,FlatnessDeviation_min,FlatnessDeviation_max,FlatnessDeviation_Pass,FiberProtrusion_min,FiberProtrusion_max,FiberProtrusion_Pass,FiberROC_min,FiberROC_max,FiberROC_Pass,FiberHeight,FiberCoreDip,FiberROC,TestPassed,FibArrayXAng,FibArrayXAng_min,FibArrayXAng_max,FibArrayXAng_Pass,FibArrayYAng,FibArrayYAng_min,FibArrayYAng_max,FibArrayYAng_Pass,Coplanarity,Coplanarity_min,Coplanarity_max,Coplanarity_Pass,MinusCoplanarity,MinusCoplanarity_min,MinusCoplanarity_max,MinusCoplanarity_Pass ");
			strSql.Append(" FROM tblMultiFiber ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tblMultiFiber ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from tblMultiFiber T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "tblMultiFiber";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

