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
namespace Maticsoft.Web.tblMultiFiber
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblID.Text=model.ID.ToString();
		this.lblScan_ID.Text=model.Scan_ID.ToString();
		this.lblScanTime.Text=model.ScanTime.ToString();
		this.lblUser_ID.Text=model.User_ID.ToString();
		this.lblProductID.Text=model.ProductID;
		this.lblConnectorID.Text=model.ConnectorID;
		this.lblLightMode.Text=model.LightMode;
		this.lblDataSource.Text=model.DataSource;
		this.lblMicroscope.Text=model.Microscope;
		this.lblDataFilePath.Text=model.DataFilePath;
		this.lblFiberCount.Text=model.FiberCount.ToString();
		this.lblFiberPitch.Text=model.FiberPitch.ToString();
		this.lblFibersPerRow.Text=model.FibersPerRow.ToString();
		this.lblFiberRowPitch.Text=model.FiberRowPitch.ToString();
		this.lblRowsVerticalOffset.Text=model.RowsVerticalOffset.ToString();
		this.lblFiberCaptureShape.Text=model.FiberCaptureShape;
		this.lblShape.Text=model.Shape;
		this.lblFiberDiameter.Text=model.FiberDiameter.ToString();
		this.lblFerruleType.Text=model.FerruleType;
		this.lblFerruleCount.Text=model.FerruleCount.ToString();
		this.lblGuideStructureType.Text=model.GuideStructureType;
		this.lblGuideStructurePitch.Text=model.GuideStructurePitch.ToString();
		this.lblNominalYAngle.Text=model.NominalYAngle.ToString();
		this.lblConnectorType.Text=model.ConnectorType;
		this.lblScanSegmentsNmb.Text=model.ScanSegmentsNmb.ToString();
		this.lblROI_width.Text=model.ROI_width.ToString();
		this.lblROI_height.Text=model.ROI_height.ToString();
		this.lblAvgDiameter.Text=model.AvgDiameter.ToString();
		this.lblExtractingDiameter.Text=model.ExtractingDiameter.ToString();
		this.lblMinModulation.Text=model.MinModulation.ToString();
		this.lblTopPixRemove.Text=model.TopPixRemove.ToString();
		this.lblTopPixLeft.Text=model.TopPixLeft.ToString();
		this.lblSampleType.Text=model.SampleType;
		this.lblMultimode.Text=model.Multimode.ToString();
		this.lblMeasurementConfig.Text=model.MeasurementConfig;
		this.lblPassFail.Text=model.PassFail.ToString();
		this.lblMaxFibDiffH.Text=model.MaxFibDiffH.ToString();
		this.lblMaxFibDiffH_min.Text=model.MaxFibDiffH_min.ToString();
		this.lblMaxFibDiffH_max.Text=model.MaxFibDiffH_max.ToString();
		this.lblMaxFibDiffH_Pass.Text=model.MaxFibDiffH_Pass;
		this.lblMaxFibDiffAdjH.Text=model.MaxFibDiffAdjH.ToString();
		this.lblMaxFibDiffAdjH_min.Text=model.MaxFibDiffAdjH_min.ToString();
		this.lblMaxFibDiffAdjH_max.Text=model.MaxFibDiffAdjH_max.ToString();
		this.lblMaxFibDiffAdjH_Pass.Text=model.MaxFibDiffAdjH_Pass;
		this.lblMaxCoreDip.Text=model.MaxCoreDip.ToString();
		this.lblMaxCoreDip_min.Text=model.MaxCoreDip_min.ToString();
		this.lblMaxCoreDip_max.Text=model.MaxCoreDip_max.ToString();
		this.lblMaxCoreDip_Pass.Text=model.MaxCoreDip_Pass;
		this.lblROC_X.Text=model.ROC_X.ToString();
		this.lblROC_X_min.Text=model.ROC_X_min.ToString();
		this.lblROC_X_max.Text=model.ROC_X_max.ToString();
		this.lblROC_X_Pass.Text=model.ROC_X_Pass;
		this.lblROC_Y.Text=model.ROC_Y.ToString();
		this.lblROC_Y_min.Text=model.ROC_Y_min.ToString();
		this.lblROC_Y_max.Text=model.ROC_Y_max.ToString();
		this.lblROC_Y_Pass.Text=model.ROC_Y_Pass;
		this.lblXEndFaceAngle.Text=model.XEndFaceAngle.ToString();
		this.lblXEndFaceAngle_min.Text=model.XEndFaceAngle_min.ToString();
		this.lblXEndFaceAngle_max.Text=model.XEndFaceAngle_max.ToString();
		this.lblXEndFaceAngle_Pass.Text=model.XEndFaceAngle_Pass;
		this.lblYEndFaceAngle.Text=model.YEndFaceAngle.ToString();
		this.lblYEndFaceAngle_min.Text=model.YEndFaceAngle_min.ToString();
		this.lblYEndFaceAngle_max.Text=model.YEndFaceAngle_max.ToString();
		this.lblYEndFaceAngle_Pass.Text=model.YEndFaceAngle_Pass;
		this.lblFlatnessDeviation.Text=model.FlatnessDeviation.ToString();
		this.lblFlatnessDeviation_min.Text=model.FlatnessDeviation_min.ToString();
		this.lblFlatnessDeviation_max.Text=model.FlatnessDeviation_max.ToString();
		this.lblFlatnessDeviation_Pass.Text=model.FlatnessDeviation_Pass;
		this.lblFiberProtrusion_min.Text=model.FiberProtrusion_min.ToString();
		this.lblFiberProtrusion_max.Text=model.FiberProtrusion_max.ToString();
		this.lblFiberProtrusion_Pass.Text=model.FiberProtrusion_Pass;
		this.lblFiberROC_min.Text=model.FiberROC_min.ToString();
		this.lblFiberROC_max.Text=model.FiberROC_max.ToString();
		this.lblFiberROC_Pass.Text=model.FiberROC_Pass;
		this.lblFiberHeight.Text=model.FiberHeight.ToString();
		this.lblFiberCoreDip.Text=model.FiberCoreDip.ToString();
		this.lblFiberROC.Text=model.FiberROC.ToString();
		this.lblTestPassed.Text=model.TestPassed;
		this.lblFibArrayXAng.Text=model.FibArrayXAng.ToString();
		this.lblFibArrayXAng_min.Text=model.FibArrayXAng_min.ToString();
		this.lblFibArrayXAng_max.Text=model.FibArrayXAng_max.ToString();
		this.lblFibArrayXAng_Pass.Text=model.FibArrayXAng_Pass;
		this.lblFibArrayYAng.Text=model.FibArrayYAng.ToString();
		this.lblFibArrayYAng_min.Text=model.FibArrayYAng_min.ToString();
		this.lblFibArrayYAng_max.Text=model.FibArrayYAng_max.ToString();
		this.lblFibArrayYAng_Pass.Text=model.FibArrayYAng_Pass;
		this.lblCoplanarity.Text=model.Coplanarity.ToString();
		this.lblCoplanarity_min.Text=model.Coplanarity_min.ToString();
		this.lblCoplanarity_max.Text=model.Coplanarity_max.ToString();
		this.lblCoplanarity_Pass.Text=model.Coplanarity_Pass;
		this.lblMinusCoplanarity.Text=model.MinusCoplanarity.ToString();
		this.lblMinusCoplanarity_min.Text=model.MinusCoplanarity_min.ToString();
		this.lblMinusCoplanarity_max.Text=model.MinusCoplanarity_max.ToString();
		this.lblMinusCoplanarity_Pass.Text=model.MinusCoplanarity_Pass;

	}


    }
}
