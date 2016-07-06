<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.tblMultiFiber.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Scan_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScan_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScanTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScanTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUser_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ConnectorID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblConnectorID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LightMode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLightMode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DataSource
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDataSource" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Microscope
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMicroscope" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DataFilePath
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDataFilePath" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberPitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberPitch" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibersPerRow
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibersPerRow" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberRowPitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberRowPitch" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RowsVerticalOffset
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRowsVerticalOffset" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCaptureShape
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberCaptureShape" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Shape
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblShape" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberDiameter" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FerruleType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFerruleType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FerruleCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFerruleCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GuideStructureType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGuideStructureType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GuideStructurePitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGuideStructurePitch" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NominalYAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNominalYAngle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ConnectorType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblConnectorType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScanSegmentsNmb
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScanSegmentsNmb" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROI_width
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROI_width" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROI_height
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROI_height" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AvgDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAvgDiameter" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ExtractingDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblExtractingDiameter" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinModulation
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMinModulation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TopPixRemove
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTopPixRemove" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TopPixLeft
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTopPixLeft" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SampleType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSampleType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Multimode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMultimode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MeasurementConfig
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMeasurementConfig" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PassFail
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPassFail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffH" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffH_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffH_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffH_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffAdjH" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffAdjH_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffAdjH_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxFibDiffAdjH_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxCoreDip" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxCoreDip_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxCoreDip_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaxCoreDip_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_X" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_X_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_X_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_X_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_Y" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_Y_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_Y_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblROC_Y_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblXEndFaceAngle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblXEndFaceAngle_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblXEndFaceAngle_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblXEndFaceAngle_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblYEndFaceAngle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblYEndFaceAngle_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblYEndFaceAngle_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblYEndFaceAngle_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFlatnessDeviation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFlatnessDeviation_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFlatnessDeviation_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFlatnessDeviation_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberProtrusion_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberProtrusion_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberProtrusion_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberROC_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberROC_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberROC_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberHeight
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberHeight" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCoreDip
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberCoreDip" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFiberROC" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TestPassed
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTestPassed" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayXAng" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayXAng_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayXAng_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayXAng_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayYAng" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayYAng_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayYAng_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFibArrayYAng_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCoplanarity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCoplanarity_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCoplanarity_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCoplanarity_Pass" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMinusCoplanarity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMinusCoplanarity_min" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMinusCoplanarity_max" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMinusCoplanarity_Pass" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




