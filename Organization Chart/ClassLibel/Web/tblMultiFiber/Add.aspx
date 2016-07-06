<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.tblMultiFiber.Add" Title="增加页" %>

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
		<asp:TextBox id="txtID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Scan_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScan_ID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScanTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtScanTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		User_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUser_ID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtProductID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ConnectorID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtConnectorID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LightMode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLightMode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DataSource
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDataSource" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Microscope
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMicroscope" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DataFilePath
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDataFilePath" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberCount" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberPitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberPitch" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibersPerRow
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibersPerRow" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberRowPitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberRowPitch" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RowsVerticalOffset
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRowsVerticalOffset" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCaptureShape
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberCaptureShape" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Shape
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtShape" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberDiameter" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FerruleType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFerruleType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FerruleCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFerruleCount" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GuideStructureType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGuideStructureType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GuideStructurePitch
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGuideStructurePitch" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NominalYAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNominalYAngle" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ConnectorType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtConnectorType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScanSegmentsNmb
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScanSegmentsNmb" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROI_width
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROI_width" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROI_height
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROI_height" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AvgDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAvgDiameter" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ExtractingDiameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtExtractingDiameter" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinModulation
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMinModulation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TopPixRemove
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTopPixRemove" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TopPixLeft
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTopPixLeft" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SampleType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSampleType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Multimode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMultimode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MeasurementConfig
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMeasurementConfig" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PassFail
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPassFail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffH" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffH_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffH_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffH_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffH_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffAdjH" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffAdjH_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffAdjH_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxFibDiffAdjH_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxFibDiffAdjH_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxCoreDip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxCoreDip_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxCoreDip_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaxCoreDip_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaxCoreDip_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_X" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_X_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_X_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_X_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_X_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_Y" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_Y_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_Y_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ROC_Y_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtROC_Y_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtXEndFaceAngle" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtXEndFaceAngle_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtXEndFaceAngle_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		XEndFaceAngle_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtXEndFaceAngle_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtYEndFaceAngle" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtYEndFaceAngle_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtYEndFaceAngle_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		YEndFaceAngle_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtYEndFaceAngle_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFlatnessDeviation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFlatnessDeviation_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFlatnessDeviation_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FlatnessDeviation_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFlatnessDeviation_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberProtrusion_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberProtrusion_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberProtrusion_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberProtrusion_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberROC_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberROC_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberROC_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberHeight
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberHeight" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberCoreDip
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberCoreDip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FiberROC
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFiberROC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TestPassed
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTestPassed" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayXAng" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayXAng_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayXAng_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayXAng_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayXAng_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayYAng" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayYAng_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayYAng_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FibArrayYAng_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFibArrayYAng_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCoplanarity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCoplanarity_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCoplanarity_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Coplanarity_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCoplanarity_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMinusCoplanarity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_min
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMinusCoplanarity_min" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_max
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMinusCoplanarity_max" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MinusCoplanarity_Pass
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMinusCoplanarity_Pass" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
