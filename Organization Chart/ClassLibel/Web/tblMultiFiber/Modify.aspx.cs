using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.tblMultiFiber
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
			
	private void ShowInfo()
	{
		Maticsoft.BLL.tblMultiFiber bll=new Maticsoft.BLL.tblMultiFiber();
		Maticsoft.Model.tblMultiFiber model=bll.GetModel();
		this.txtID.Text=model.ID.ToString();
		this.txtScan_ID.Text=model.Scan_ID.ToString();
		this.txtScanTime.Text=model.ScanTime.ToString();
		this.txtUser_ID.Text=model.User_ID.ToString();
		this.txtProductID.Text=model.ProductID;
		this.txtConnectorID.Text=model.ConnectorID;
		this.txtLightMode.Text=model.LightMode;
		this.txtDataSource.Text=model.DataSource;
		this.txtMicroscope.Text=model.Microscope;
		this.txtDataFilePath.Text=model.DataFilePath;
		this.txtFiberCount.Text=model.FiberCount.ToString();
		this.txtFiberPitch.Text=model.FiberPitch.ToString();
		this.txtFibersPerRow.Text=model.FibersPerRow.ToString();
		this.txtFiberRowPitch.Text=model.FiberRowPitch.ToString();
		this.txtRowsVerticalOffset.Text=model.RowsVerticalOffset.ToString();
		this.txtFiberCaptureShape.Text=model.FiberCaptureShape;
		this.txtShape.Text=model.Shape;
		this.txtFiberDiameter.Text=model.FiberDiameter.ToString();
		this.txtFerruleType.Text=model.FerruleType;
		this.txtFerruleCount.Text=model.FerruleCount.ToString();
		this.txtGuideStructureType.Text=model.GuideStructureType;
		this.txtGuideStructurePitch.Text=model.GuideStructurePitch.ToString();
		this.txtNominalYAngle.Text=model.NominalYAngle.ToString();
		this.txtConnectorType.Text=model.ConnectorType;
		this.txtScanSegmentsNmb.Text=model.ScanSegmentsNmb.ToString();
		this.txtROI_width.Text=model.ROI_width.ToString();
		this.txtROI_height.Text=model.ROI_height.ToString();
		this.txtAvgDiameter.Text=model.AvgDiameter.ToString();
		this.txtExtractingDiameter.Text=model.ExtractingDiameter.ToString();
		this.txtMinModulation.Text=model.MinModulation.ToString();
		this.txtTopPixRemove.Text=model.TopPixRemove.ToString();
		this.txtTopPixLeft.Text=model.TopPixLeft.ToString();
		this.txtSampleType.Text=model.SampleType;
		this.txtMultimode.Text=model.Multimode.ToString();
		this.txtMeasurementConfig.Text=model.MeasurementConfig;
		this.txtPassFail.Text=model.PassFail.ToString();
		this.txtMaxFibDiffH.Text=model.MaxFibDiffH.ToString();
		this.txtMaxFibDiffH_min.Text=model.MaxFibDiffH_min.ToString();
		this.txtMaxFibDiffH_max.Text=model.MaxFibDiffH_max.ToString();
		this.txtMaxFibDiffH_Pass.Text=model.MaxFibDiffH_Pass;
		this.txtMaxFibDiffAdjH.Text=model.MaxFibDiffAdjH.ToString();
		this.txtMaxFibDiffAdjH_min.Text=model.MaxFibDiffAdjH_min.ToString();
		this.txtMaxFibDiffAdjH_max.Text=model.MaxFibDiffAdjH_max.ToString();
		this.txtMaxFibDiffAdjH_Pass.Text=model.MaxFibDiffAdjH_Pass;
		this.txtMaxCoreDip.Text=model.MaxCoreDip.ToString();
		this.txtMaxCoreDip_min.Text=model.MaxCoreDip_min.ToString();
		this.txtMaxCoreDip_max.Text=model.MaxCoreDip_max.ToString();
		this.txtMaxCoreDip_Pass.Text=model.MaxCoreDip_Pass;
		this.txtROC_X.Text=model.ROC_X.ToString();
		this.txtROC_X_min.Text=model.ROC_X_min.ToString();
		this.txtROC_X_max.Text=model.ROC_X_max.ToString();
		this.txtROC_X_Pass.Text=model.ROC_X_Pass;
		this.txtROC_Y.Text=model.ROC_Y.ToString();
		this.txtROC_Y_min.Text=model.ROC_Y_min.ToString();
		this.txtROC_Y_max.Text=model.ROC_Y_max.ToString();
		this.txtROC_Y_Pass.Text=model.ROC_Y_Pass;
		this.txtXEndFaceAngle.Text=model.XEndFaceAngle.ToString();
		this.txtXEndFaceAngle_min.Text=model.XEndFaceAngle_min.ToString();
		this.txtXEndFaceAngle_max.Text=model.XEndFaceAngle_max.ToString();
		this.txtXEndFaceAngle_Pass.Text=model.XEndFaceAngle_Pass;
		this.txtYEndFaceAngle.Text=model.YEndFaceAngle.ToString();
		this.txtYEndFaceAngle_min.Text=model.YEndFaceAngle_min.ToString();
		this.txtYEndFaceAngle_max.Text=model.YEndFaceAngle_max.ToString();
		this.txtYEndFaceAngle_Pass.Text=model.YEndFaceAngle_Pass;
		this.txtFlatnessDeviation.Text=model.FlatnessDeviation.ToString();
		this.txtFlatnessDeviation_min.Text=model.FlatnessDeviation_min.ToString();
		this.txtFlatnessDeviation_max.Text=model.FlatnessDeviation_max.ToString();
		this.txtFlatnessDeviation_Pass.Text=model.FlatnessDeviation_Pass;
		this.txtFiberProtrusion_min.Text=model.FiberProtrusion_min.ToString();
		this.txtFiberProtrusion_max.Text=model.FiberProtrusion_max.ToString();
		this.txtFiberProtrusion_Pass.Text=model.FiberProtrusion_Pass;
		this.txtFiberROC_min.Text=model.FiberROC_min.ToString();
		this.txtFiberROC_max.Text=model.FiberROC_max.ToString();
		this.txtFiberROC_Pass.Text=model.FiberROC_Pass;
		this.txtFiberHeight.Text=model.FiberHeight.ToString();
		this.txtFiberCoreDip.Text=model.FiberCoreDip.ToString();
		this.txtFiberROC.Text=model.FiberROC.ToString();
		this.txtTestPassed.Text=model.TestPassed;
		this.txtFibArrayXAng.Text=model.FibArrayXAng.ToString();
		this.txtFibArrayXAng_min.Text=model.FibArrayXAng_min.ToString();
		this.txtFibArrayXAng_max.Text=model.FibArrayXAng_max.ToString();
		this.txtFibArrayXAng_Pass.Text=model.FibArrayXAng_Pass;
		this.txtFibArrayYAng.Text=model.FibArrayYAng.ToString();
		this.txtFibArrayYAng_min.Text=model.FibArrayYAng_min.ToString();
		this.txtFibArrayYAng_max.Text=model.FibArrayYAng_max.ToString();
		this.txtFibArrayYAng_Pass.Text=model.FibArrayYAng_Pass;
		this.txtCoplanarity.Text=model.Coplanarity.ToString();
		this.txtCoplanarity_min.Text=model.Coplanarity_min.ToString();
		this.txtCoplanarity_max.Text=model.Coplanarity_max.ToString();
		this.txtCoplanarity_Pass.Text=model.Coplanarity_Pass;
		this.txtMinusCoplanarity.Text=model.MinusCoplanarity.ToString();
		this.txtMinusCoplanarity_min.Text=model.MinusCoplanarity_min.ToString();
		this.txtMinusCoplanarity_max.Text=model.MinusCoplanarity_max.ToString();
		this.txtMinusCoplanarity_Pass.Text=model.MinusCoplanarity_Pass;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtID.Text))
			{
				strErr+="ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtScan_ID.Text))
			{
				strErr+="Scan_ID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtScanTime.Text))
			{
				strErr+="ScanTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUser_ID.Text))
			{
				strErr+="User_ID格式错误！\\n";	
			}
			if(this.txtProductID.Text.Trim().Length==0)
			{
				strErr+="ProductID不能为空！\\n";	
			}
			if(this.txtConnectorID.Text.Trim().Length==0)
			{
				strErr+="ConnectorID不能为空！\\n";	
			}
			if(this.txtLightMode.Text.Trim().Length==0)
			{
				strErr+="LightMode不能为空！\\n";	
			}
			if(this.txtDataSource.Text.Trim().Length==0)
			{
				strErr+="DataSource不能为空！\\n";	
			}
			if(this.txtMicroscope.Text.Trim().Length==0)
			{
				strErr+="Microscope不能为空！\\n";	
			}
			if(this.txtDataFilePath.Text.Trim().Length==0)
			{
				strErr+="DataFilePath不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtFiberCount.Text))
			{
				strErr+="FiberCount格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberPitch.Text))
			{
				strErr+="FiberPitch格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtFibersPerRow.Text))
			{
				strErr+="FibersPerRow格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberRowPitch.Text))
			{
				strErr+="FiberRowPitch格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtRowsVerticalOffset.Text))
			{
				strErr+="RowsVerticalOffset格式错误！\\n";	
			}
			if(this.txtFiberCaptureShape.Text.Trim().Length==0)
			{
				strErr+="FiberCaptureShape不能为空！\\n";	
			}
			if(this.txtShape.Text.Trim().Length==0)
			{
				strErr+="Shape不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberDiameter.Text))
			{
				strErr+="FiberDiameter格式错误！\\n";	
			}
			if(this.txtFerruleType.Text.Trim().Length==0)
			{
				strErr+="FerruleType不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtFerruleCount.Text))
			{
				strErr+="FerruleCount格式错误！\\n";	
			}
			if(this.txtGuideStructureType.Text.Trim().Length==0)
			{
				strErr+="GuideStructureType不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGuideStructurePitch.Text))
			{
				strErr+="GuideStructurePitch格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtNominalYAngle.Text))
			{
				strErr+="NominalYAngle格式错误！\\n";	
			}
			if(this.txtConnectorType.Text.Trim().Length==0)
			{
				strErr+="ConnectorType不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtScanSegmentsNmb.Text))
			{
				strErr+="ScanSegmentsNmb格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROI_width.Text))
			{
				strErr+="ROI_width格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROI_height.Text))
			{
				strErr+="ROI_height格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtAvgDiameter.Text))
			{
				strErr+="AvgDiameter格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtExtractingDiameter.Text))
			{
				strErr+="ExtractingDiameter格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMinModulation.Text))
			{
				strErr+="MinModulation格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTopPixRemove.Text))
			{
				strErr+="TopPixRemove格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTopPixLeft.Text))
			{
				strErr+="TopPixLeft格式错误！\\n";	
			}
			if(this.txtSampleType.Text.Trim().Length==0)
			{
				strErr+="SampleType不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtMultimode.Text))
			{
				strErr+="Multimode格式错误！\\n";	
			}
			if(this.txtMeasurementConfig.Text.Trim().Length==0)
			{
				strErr+="MeasurementConfig不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPassFail.Text))
			{
				strErr+="PassFail格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffH.Text))
			{
				strErr+="MaxFibDiffH格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffH_min.Text))
			{
				strErr+="MaxFibDiffH_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffH_max.Text))
			{
				strErr+="MaxFibDiffH_max格式错误！\\n";	
			}
			if(this.txtMaxFibDiffH_Pass.Text.Trim().Length==0)
			{
				strErr+="MaxFibDiffH_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffAdjH.Text))
			{
				strErr+="MaxFibDiffAdjH格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffAdjH_min.Text))
			{
				strErr+="MaxFibDiffAdjH_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxFibDiffAdjH_max.Text))
			{
				strErr+="MaxFibDiffAdjH_max格式错误！\\n";	
			}
			if(this.txtMaxFibDiffAdjH_Pass.Text.Trim().Length==0)
			{
				strErr+="MaxFibDiffAdjH_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxCoreDip.Text))
			{
				strErr+="MaxCoreDip格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxCoreDip_min.Text))
			{
				strErr+="MaxCoreDip_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMaxCoreDip_max.Text))
			{
				strErr+="MaxCoreDip_max格式错误！\\n";	
			}
			if(this.txtMaxCoreDip_Pass.Text.Trim().Length==0)
			{
				strErr+="MaxCoreDip_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_X.Text))
			{
				strErr+="ROC_X格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_X_min.Text))
			{
				strErr+="ROC_X_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_X_max.Text))
			{
				strErr+="ROC_X_max格式错误！\\n";	
			}
			if(this.txtROC_X_Pass.Text.Trim().Length==0)
			{
				strErr+="ROC_X_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_Y.Text))
			{
				strErr+="ROC_Y格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_Y_min.Text))
			{
				strErr+="ROC_Y_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtROC_Y_max.Text))
			{
				strErr+="ROC_Y_max格式错误！\\n";	
			}
			if(this.txtROC_Y_Pass.Text.Trim().Length==0)
			{
				strErr+="ROC_Y_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtXEndFaceAngle.Text))
			{
				strErr+="XEndFaceAngle格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtXEndFaceAngle_min.Text))
			{
				strErr+="XEndFaceAngle_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtXEndFaceAngle_max.Text))
			{
				strErr+="XEndFaceAngle_max格式错误！\\n";	
			}
			if(this.txtXEndFaceAngle_Pass.Text.Trim().Length==0)
			{
				strErr+="XEndFaceAngle_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtYEndFaceAngle.Text))
			{
				strErr+="YEndFaceAngle格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtYEndFaceAngle_min.Text))
			{
				strErr+="YEndFaceAngle_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtYEndFaceAngle_max.Text))
			{
				strErr+="YEndFaceAngle_max格式错误！\\n";	
			}
			if(this.txtYEndFaceAngle_Pass.Text.Trim().Length==0)
			{
				strErr+="YEndFaceAngle_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFlatnessDeviation.Text))
			{
				strErr+="FlatnessDeviation格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFlatnessDeviation_min.Text))
			{
				strErr+="FlatnessDeviation_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFlatnessDeviation_max.Text))
			{
				strErr+="FlatnessDeviation_max格式错误！\\n";	
			}
			if(this.txtFlatnessDeviation_Pass.Text.Trim().Length==0)
			{
				strErr+="FlatnessDeviation_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberProtrusion_min.Text))
			{
				strErr+="FiberProtrusion_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberProtrusion_max.Text))
			{
				strErr+="FiberProtrusion_max格式错误！\\n";	
			}
			if(this.txtFiberProtrusion_Pass.Text.Trim().Length==0)
			{
				strErr+="FiberProtrusion_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberROC_min.Text))
			{
				strErr+="FiberROC_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFiberROC_max.Text))
			{
				strErr+="FiberROC_max格式错误！\\n";	
			}
			if(this.txtFiberROC_Pass.Text.Trim().Length==0)
			{
				strErr+="FiberROC_Pass不能为空！\\n";	
			}
			if(this.txtTestPassed.Text.Trim().Length==0)
			{
				strErr+="TestPassed不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayXAng.Text))
			{
				strErr+="FibArrayXAng格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayXAng_min.Text))
			{
				strErr+="FibArrayXAng_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayXAng_max.Text))
			{
				strErr+="FibArrayXAng_max格式错误！\\n";	
			}
			if(this.txtFibArrayXAng_Pass.Text.Trim().Length==0)
			{
				strErr+="FibArrayXAng_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayYAng.Text))
			{
				strErr+="FibArrayYAng格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayYAng_min.Text))
			{
				strErr+="FibArrayYAng_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtFibArrayYAng_max.Text))
			{
				strErr+="FibArrayYAng_max格式错误！\\n";	
			}
			if(this.txtFibArrayYAng_Pass.Text.Trim().Length==0)
			{
				strErr+="FibArrayYAng_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCoplanarity.Text))
			{
				strErr+="Coplanarity格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCoplanarity_min.Text))
			{
				strErr+="Coplanarity_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCoplanarity_max.Text))
			{
				strErr+="Coplanarity_max格式错误！\\n";	
			}
			if(this.txtCoplanarity_Pass.Text.Trim().Length==0)
			{
				strErr+="Coplanarity_Pass不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMinusCoplanarity.Text))
			{
				strErr+="MinusCoplanarity格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMinusCoplanarity_min.Text))
			{
				strErr+="MinusCoplanarity_min格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMinusCoplanarity_max.Text))
			{
				strErr+="MinusCoplanarity_max格式错误！\\n";	
			}
			if(this.txtMinusCoplanarity_Pass.Text.Trim().Length==0)
			{
				strErr+="MinusCoplanarity_Pass不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.txtID.Text);
			int Scan_ID=int.Parse(this.txtScan_ID.Text);
			DateTime ScanTime=DateTime.Parse(this.txtScanTime.Text);
			int User_ID=int.Parse(this.txtUser_ID.Text);
			string ProductID=this.txtProductID.Text;
			string ConnectorID=this.txtConnectorID.Text;
			string LightMode=this.txtLightMode.Text;
			string DataSource=this.txtDataSource.Text;
			string Microscope=this.txtMicroscope.Text;
			string DataFilePath=this.txtDataFilePath.Text;
			int FiberCount=int.Parse(this.txtFiberCount.Text);
			decimal FiberPitch=decimal.Parse(this.txtFiberPitch.Text);
			int FibersPerRow=int.Parse(this.txtFibersPerRow.Text);
			decimal FiberRowPitch=decimal.Parse(this.txtFiberRowPitch.Text);
			decimal RowsVerticalOffset=decimal.Parse(this.txtRowsVerticalOffset.Text);
			string FiberCaptureShape=this.txtFiberCaptureShape.Text;
			string Shape=this.txtShape.Text;
			decimal FiberDiameter=decimal.Parse(this.txtFiberDiameter.Text);
			string FerruleType=this.txtFerruleType.Text;
			int FerruleCount=int.Parse(this.txtFerruleCount.Text);
			string GuideStructureType=this.txtGuideStructureType.Text;
			decimal GuideStructurePitch=decimal.Parse(this.txtGuideStructurePitch.Text);
			decimal NominalYAngle=decimal.Parse(this.txtNominalYAngle.Text);
			string ConnectorType=this.txtConnectorType.Text;
			int ScanSegmentsNmb=int.Parse(this.txtScanSegmentsNmb.Text);
			decimal ROI_width=decimal.Parse(this.txtROI_width.Text);
			decimal ROI_height=decimal.Parse(this.txtROI_height.Text);
			decimal AvgDiameter=decimal.Parse(this.txtAvgDiameter.Text);
			decimal ExtractingDiameter=decimal.Parse(this.txtExtractingDiameter.Text);
			int MinModulation=int.Parse(this.txtMinModulation.Text);
			int TopPixRemove=int.Parse(this.txtTopPixRemove.Text);
			int TopPixLeft=int.Parse(this.txtTopPixLeft.Text);
			string SampleType=this.txtSampleType.Text;
			int Multimode=int.Parse(this.txtMultimode.Text);
			string MeasurementConfig=this.txtMeasurementConfig.Text;
			int PassFail=int.Parse(this.txtPassFail.Text);
			decimal MaxFibDiffH=decimal.Parse(this.txtMaxFibDiffH.Text);
			decimal MaxFibDiffH_min=decimal.Parse(this.txtMaxFibDiffH_min.Text);
			decimal MaxFibDiffH_max=decimal.Parse(this.txtMaxFibDiffH_max.Text);
			string MaxFibDiffH_Pass=this.txtMaxFibDiffH_Pass.Text;
			decimal MaxFibDiffAdjH=decimal.Parse(this.txtMaxFibDiffAdjH.Text);
			decimal MaxFibDiffAdjH_min=decimal.Parse(this.txtMaxFibDiffAdjH_min.Text);
			decimal MaxFibDiffAdjH_max=decimal.Parse(this.txtMaxFibDiffAdjH_max.Text);
			string MaxFibDiffAdjH_Pass=this.txtMaxFibDiffAdjH_Pass.Text;
			decimal MaxCoreDip=decimal.Parse(this.txtMaxCoreDip.Text);
			decimal MaxCoreDip_min=decimal.Parse(this.txtMaxCoreDip_min.Text);
			decimal MaxCoreDip_max=decimal.Parse(this.txtMaxCoreDip_max.Text);
			string MaxCoreDip_Pass=this.txtMaxCoreDip_Pass.Text;
			decimal ROC_X=decimal.Parse(this.txtROC_X.Text);
			decimal ROC_X_min=decimal.Parse(this.txtROC_X_min.Text);
			decimal ROC_X_max=decimal.Parse(this.txtROC_X_max.Text);
			string ROC_X_Pass=this.txtROC_X_Pass.Text;
			decimal ROC_Y=decimal.Parse(this.txtROC_Y.Text);
			decimal ROC_Y_min=decimal.Parse(this.txtROC_Y_min.Text);
			decimal ROC_Y_max=decimal.Parse(this.txtROC_Y_max.Text);
			string ROC_Y_Pass=this.txtROC_Y_Pass.Text;
			decimal XEndFaceAngle=decimal.Parse(this.txtXEndFaceAngle.Text);
			decimal XEndFaceAngle_min=decimal.Parse(this.txtXEndFaceAngle_min.Text);
			decimal XEndFaceAngle_max=decimal.Parse(this.txtXEndFaceAngle_max.Text);
			string XEndFaceAngle_Pass=this.txtXEndFaceAngle_Pass.Text;
			decimal YEndFaceAngle=decimal.Parse(this.txtYEndFaceAngle.Text);
			decimal YEndFaceAngle_min=decimal.Parse(this.txtYEndFaceAngle_min.Text);
			decimal YEndFaceAngle_max=decimal.Parse(this.txtYEndFaceAngle_max.Text);
			string YEndFaceAngle_Pass=this.txtYEndFaceAngle_Pass.Text;
			decimal FlatnessDeviation=decimal.Parse(this.txtFlatnessDeviation.Text);
			decimal FlatnessDeviation_min=decimal.Parse(this.txtFlatnessDeviation_min.Text);
			decimal FlatnessDeviation_max=decimal.Parse(this.txtFlatnessDeviation_max.Text);
			string FlatnessDeviation_Pass=this.txtFlatnessDeviation_Pass.Text;
			decimal FiberProtrusion_min=decimal.Parse(this.txtFiberProtrusion_min.Text);
			decimal FiberProtrusion_max=decimal.Parse(this.txtFiberProtrusion_max.Text);
			string FiberProtrusion_Pass=this.txtFiberProtrusion_Pass.Text;
			decimal FiberROC_min=decimal.Parse(this.txtFiberROC_min.Text);
			decimal FiberROC_max=decimal.Parse(this.txtFiberROC_max.Text);
			string FiberROC_Pass=this.txtFiberROC_Pass.Text;
			byte[] FiberHeight= new UnicodeEncoding().GetBytes(this.txtFiberHeight.Text);
			byte[] FiberCoreDip= new UnicodeEncoding().GetBytes(this.txtFiberCoreDip.Text);
			byte[] FiberROC= new UnicodeEncoding().GetBytes(this.txtFiberROC.Text);
			string TestPassed=this.txtTestPassed.Text;
			decimal FibArrayXAng=decimal.Parse(this.txtFibArrayXAng.Text);
			decimal FibArrayXAng_min=decimal.Parse(this.txtFibArrayXAng_min.Text);
			decimal FibArrayXAng_max=decimal.Parse(this.txtFibArrayXAng_max.Text);
			string FibArrayXAng_Pass=this.txtFibArrayXAng_Pass.Text;
			decimal FibArrayYAng=decimal.Parse(this.txtFibArrayYAng.Text);
			decimal FibArrayYAng_min=decimal.Parse(this.txtFibArrayYAng_min.Text);
			decimal FibArrayYAng_max=decimal.Parse(this.txtFibArrayYAng_max.Text);
			string FibArrayYAng_Pass=this.txtFibArrayYAng_Pass.Text;
			decimal Coplanarity=decimal.Parse(this.txtCoplanarity.Text);
			decimal Coplanarity_min=decimal.Parse(this.txtCoplanarity_min.Text);
			decimal Coplanarity_max=decimal.Parse(this.txtCoplanarity_max.Text);
			string Coplanarity_Pass=this.txtCoplanarity_Pass.Text;
			decimal MinusCoplanarity=decimal.Parse(this.txtMinusCoplanarity.Text);
			decimal MinusCoplanarity_min=decimal.Parse(this.txtMinusCoplanarity_min.Text);
			decimal MinusCoplanarity_max=decimal.Parse(this.txtMinusCoplanarity_max.Text);
			string MinusCoplanarity_Pass=this.txtMinusCoplanarity_Pass.Text;


			Maticsoft.Model.tblMultiFiber model=new Maticsoft.Model.tblMultiFiber();
			model.ID=ID;
			model.Scan_ID=Scan_ID;
			model.ScanTime=ScanTime;
			model.User_ID=User_ID;
			model.ProductID=ProductID;
			model.ConnectorID=ConnectorID;
			model.LightMode=LightMode;
			model.DataSource=DataSource;
			model.Microscope=Microscope;
			model.DataFilePath=DataFilePath;
			model.FiberCount=FiberCount;
			model.FiberPitch=FiberPitch;
			model.FibersPerRow=FibersPerRow;
			model.FiberRowPitch=FiberRowPitch;
			model.RowsVerticalOffset=RowsVerticalOffset;
			model.FiberCaptureShape=FiberCaptureShape;
			model.Shape=Shape;
			model.FiberDiameter=FiberDiameter;
			model.FerruleType=FerruleType;
			model.FerruleCount=FerruleCount;
			model.GuideStructureType=GuideStructureType;
			model.GuideStructurePitch=GuideStructurePitch;
			model.NominalYAngle=NominalYAngle;
			model.ConnectorType=ConnectorType;
			model.ScanSegmentsNmb=ScanSegmentsNmb;
			model.ROI_width=ROI_width;
			model.ROI_height=ROI_height;
			model.AvgDiameter=AvgDiameter;
			model.ExtractingDiameter=ExtractingDiameter;
			model.MinModulation=MinModulation;
			model.TopPixRemove=TopPixRemove;
			model.TopPixLeft=TopPixLeft;
			model.SampleType=SampleType;
			model.Multimode=Multimode;
			model.MeasurementConfig=MeasurementConfig;
			model.PassFail=PassFail;
			model.MaxFibDiffH=MaxFibDiffH;
			model.MaxFibDiffH_min=MaxFibDiffH_min;
			model.MaxFibDiffH_max=MaxFibDiffH_max;
			model.MaxFibDiffH_Pass=MaxFibDiffH_Pass;
			model.MaxFibDiffAdjH=MaxFibDiffAdjH;
			model.MaxFibDiffAdjH_min=MaxFibDiffAdjH_min;
			model.MaxFibDiffAdjH_max=MaxFibDiffAdjH_max;
			model.MaxFibDiffAdjH_Pass=MaxFibDiffAdjH_Pass;
			model.MaxCoreDip=MaxCoreDip;
			model.MaxCoreDip_min=MaxCoreDip_min;
			model.MaxCoreDip_max=MaxCoreDip_max;
			model.MaxCoreDip_Pass=MaxCoreDip_Pass;
			model.ROC_X=ROC_X;
			model.ROC_X_min=ROC_X_min;
			model.ROC_X_max=ROC_X_max;
			model.ROC_X_Pass=ROC_X_Pass;
			model.ROC_Y=ROC_Y;
			model.ROC_Y_min=ROC_Y_min;
			model.ROC_Y_max=ROC_Y_max;
			model.ROC_Y_Pass=ROC_Y_Pass;
			model.XEndFaceAngle=XEndFaceAngle;
			model.XEndFaceAngle_min=XEndFaceAngle_min;
			model.XEndFaceAngle_max=XEndFaceAngle_max;
			model.XEndFaceAngle_Pass=XEndFaceAngle_Pass;
			model.YEndFaceAngle=YEndFaceAngle;
			model.YEndFaceAngle_min=YEndFaceAngle_min;
			model.YEndFaceAngle_max=YEndFaceAngle_max;
			model.YEndFaceAngle_Pass=YEndFaceAngle_Pass;
			model.FlatnessDeviation=FlatnessDeviation;
			model.FlatnessDeviation_min=FlatnessDeviation_min;
			model.FlatnessDeviation_max=FlatnessDeviation_max;
			model.FlatnessDeviation_Pass=FlatnessDeviation_Pass;
			model.FiberProtrusion_min=FiberProtrusion_min;
			model.FiberProtrusion_max=FiberProtrusion_max;
			model.FiberProtrusion_Pass=FiberProtrusion_Pass;
			model.FiberROC_min=FiberROC_min;
			model.FiberROC_max=FiberROC_max;
			model.FiberROC_Pass=FiberROC_Pass;
			model.FiberHeight=FiberHeight;
			model.FiberCoreDip=FiberCoreDip;
			model.FiberROC=FiberROC;
			model.TestPassed=TestPassed;
			model.FibArrayXAng=FibArrayXAng;
			model.FibArrayXAng_min=FibArrayXAng_min;
			model.FibArrayXAng_max=FibArrayXAng_max;
			model.FibArrayXAng_Pass=FibArrayXAng_Pass;
			model.FibArrayYAng=FibArrayYAng;
			model.FibArrayYAng_min=FibArrayYAng_min;
			model.FibArrayYAng_max=FibArrayYAng_max;
			model.FibArrayYAng_Pass=FibArrayYAng_Pass;
			model.Coplanarity=Coplanarity;
			model.Coplanarity_min=Coplanarity_min;
			model.Coplanarity_max=Coplanarity_max;
			model.Coplanarity_Pass=Coplanarity_Pass;
			model.MinusCoplanarity=MinusCoplanarity;
			model.MinusCoplanarity_min=MinusCoplanarity_min;
			model.MinusCoplanarity_max=MinusCoplanarity_max;
			model.MinusCoplanarity_Pass=MinusCoplanarity_Pass;

			Maticsoft.BLL.tblMultiFiber bll=new Maticsoft.BLL.tblMultiFiber();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
