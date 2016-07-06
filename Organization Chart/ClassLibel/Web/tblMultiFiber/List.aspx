<%@ Page Title="tblMultiFiber" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.tblMultiFiber.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Scan_ID" HeaderText="Scan_ID" SortExpression="Scan_ID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ScanTime" HeaderText="ScanTime" SortExpression="ScanTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="User_ID" HeaderText="User_ID" SortExpression="User_ID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ConnectorID" HeaderText="ConnectorID" SortExpression="ConnectorID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LightMode" HeaderText="LightMode" SortExpression="LightMode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DataSource" HeaderText="DataSource" SortExpression="DataSource" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Microscope" HeaderText="Microscope" SortExpression="Microscope" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DataFilePath" HeaderText="DataFilePath" SortExpression="DataFilePath" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberCount" HeaderText="FiberCount" SortExpression="FiberCount" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberPitch" HeaderText="FiberPitch" SortExpression="FiberPitch" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibersPerRow" HeaderText="FibersPerRow" SortExpression="FibersPerRow" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberRowPitch" HeaderText="FiberRowPitch" SortExpression="FiberRowPitch" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RowsVerticalOffset" HeaderText="RowsVerticalOffset" SortExpression="RowsVerticalOffset" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberCaptureShape" HeaderText="FiberCaptureShape" SortExpression="FiberCaptureShape" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Shape" HeaderText="Shape" SortExpression="Shape" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberDiameter" HeaderText="FiberDiameter" SortExpression="FiberDiameter" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FerruleType" HeaderText="FerruleType" SortExpression="FerruleType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FerruleCount" HeaderText="FerruleCount" SortExpression="FerruleCount" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="GuideStructureType" HeaderText="GuideStructureType" SortExpression="GuideStructureType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="GuideStructurePitch" HeaderText="GuideStructurePitch" SortExpression="GuideStructurePitch" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NominalYAngle" HeaderText="NominalYAngle" SortExpression="NominalYAngle" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ConnectorType" HeaderText="ConnectorType" SortExpression="ConnectorType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ScanSegmentsNmb" HeaderText="ScanSegmentsNmb" SortExpression="ScanSegmentsNmb" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROI_width" HeaderText="ROI_width" SortExpression="ROI_width" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROI_height" HeaderText="ROI_height" SortExpression="ROI_height" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="AvgDiameter" HeaderText="AvgDiameter" SortExpression="AvgDiameter" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ExtractingDiameter" HeaderText="ExtractingDiameter" SortExpression="ExtractingDiameter" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MinModulation" HeaderText="MinModulation" SortExpression="MinModulation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TopPixRemove" HeaderText="TopPixRemove" SortExpression="TopPixRemove" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TopPixLeft" HeaderText="TopPixLeft" SortExpression="TopPixLeft" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SampleType" HeaderText="SampleType" SortExpression="SampleType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Multimode" HeaderText="Multimode" SortExpression="Multimode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MeasurementConfig" HeaderText="MeasurementConfig" SortExpression="MeasurementConfig" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PassFail" HeaderText="PassFail" SortExpression="PassFail" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffH" HeaderText="MaxFibDiffH" SortExpression="MaxFibDiffH" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffH_min" HeaderText="MaxFibDiffH_min" SortExpression="MaxFibDiffH_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffH_max" HeaderText="MaxFibDiffH_max" SortExpression="MaxFibDiffH_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffH_Pass" HeaderText="MaxFibDiffH_Pass" SortExpression="MaxFibDiffH_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffAdjH" HeaderText="MaxFibDiffAdjH" SortExpression="MaxFibDiffAdjH" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffAdjH_min" HeaderText="MaxFibDiffAdjH_min" SortExpression="MaxFibDiffAdjH_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffAdjH_max" HeaderText="MaxFibDiffAdjH_max" SortExpression="MaxFibDiffAdjH_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxFibDiffAdjH_Pass" HeaderText="MaxFibDiffAdjH_Pass" SortExpression="MaxFibDiffAdjH_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxCoreDip" HeaderText="MaxCoreDip" SortExpression="MaxCoreDip" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxCoreDip_min" HeaderText="MaxCoreDip_min" SortExpression="MaxCoreDip_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxCoreDip_max" HeaderText="MaxCoreDip_max" SortExpression="MaxCoreDip_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MaxCoreDip_Pass" HeaderText="MaxCoreDip_Pass" SortExpression="MaxCoreDip_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_X" HeaderText="ROC_X" SortExpression="ROC_X" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_X_min" HeaderText="ROC_X_min" SortExpression="ROC_X_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_X_max" HeaderText="ROC_X_max" SortExpression="ROC_X_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_X_Pass" HeaderText="ROC_X_Pass" SortExpression="ROC_X_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_Y" HeaderText="ROC_Y" SortExpression="ROC_Y" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_Y_min" HeaderText="ROC_Y_min" SortExpression="ROC_Y_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_Y_max" HeaderText="ROC_Y_max" SortExpression="ROC_Y_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ROC_Y_Pass" HeaderText="ROC_Y_Pass" SortExpression="ROC_Y_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="XEndFaceAngle" HeaderText="XEndFaceAngle" SortExpression="XEndFaceAngle" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="XEndFaceAngle_min" HeaderText="XEndFaceAngle_min" SortExpression="XEndFaceAngle_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="XEndFaceAngle_max" HeaderText="XEndFaceAngle_max" SortExpression="XEndFaceAngle_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="XEndFaceAngle_Pass" HeaderText="XEndFaceAngle_Pass" SortExpression="XEndFaceAngle_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="YEndFaceAngle" HeaderText="YEndFaceAngle" SortExpression="YEndFaceAngle" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="YEndFaceAngle_min" HeaderText="YEndFaceAngle_min" SortExpression="YEndFaceAngle_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="YEndFaceAngle_max" HeaderText="YEndFaceAngle_max" SortExpression="YEndFaceAngle_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="YEndFaceAngle_Pass" HeaderText="YEndFaceAngle_Pass" SortExpression="YEndFaceAngle_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FlatnessDeviation" HeaderText="FlatnessDeviation" SortExpression="FlatnessDeviation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FlatnessDeviation_min" HeaderText="FlatnessDeviation_min" SortExpression="FlatnessDeviation_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FlatnessDeviation_max" HeaderText="FlatnessDeviation_max" SortExpression="FlatnessDeviation_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FlatnessDeviation_Pass" HeaderText="FlatnessDeviation_Pass" SortExpression="FlatnessDeviation_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberProtrusion_min" HeaderText="FiberProtrusion_min" SortExpression="FiberProtrusion_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberProtrusion_max" HeaderText="FiberProtrusion_max" SortExpression="FiberProtrusion_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberProtrusion_Pass" HeaderText="FiberProtrusion_Pass" SortExpression="FiberProtrusion_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberROC_min" HeaderText="FiberROC_min" SortExpression="FiberROC_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberROC_max" HeaderText="FiberROC_max" SortExpression="FiberROC_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberROC_Pass" HeaderText="FiberROC_Pass" SortExpression="FiberROC_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberHeight" HeaderText="FiberHeight" SortExpression="FiberHeight" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberCoreDip" HeaderText="FiberCoreDip" SortExpression="FiberCoreDip" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FiberROC" HeaderText="FiberROC" SortExpression="FiberROC" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TestPassed" HeaderText="TestPassed" SortExpression="TestPassed" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayXAng" HeaderText="FibArrayXAng" SortExpression="FibArrayXAng" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayXAng_min" HeaderText="FibArrayXAng_min" SortExpression="FibArrayXAng_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayXAng_max" HeaderText="FibArrayXAng_max" SortExpression="FibArrayXAng_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayXAng_Pass" HeaderText="FibArrayXAng_Pass" SortExpression="FibArrayXAng_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayYAng" HeaderText="FibArrayYAng" SortExpression="FibArrayYAng" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayYAng_min" HeaderText="FibArrayYAng_min" SortExpression="FibArrayYAng_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayYAng_max" HeaderText="FibArrayYAng_max" SortExpression="FibArrayYAng_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FibArrayYAng_Pass" HeaderText="FibArrayYAng_Pass" SortExpression="FibArrayYAng_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Coplanarity" HeaderText="Coplanarity" SortExpression="Coplanarity" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Coplanarity_min" HeaderText="Coplanarity_min" SortExpression="Coplanarity_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Coplanarity_max" HeaderText="Coplanarity_max" SortExpression="Coplanarity_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Coplanarity_Pass" HeaderText="Coplanarity_Pass" SortExpression="Coplanarity_Pass" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MinusCoplanarity" HeaderText="MinusCoplanarity" SortExpression="MinusCoplanarity" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MinusCoplanarity_min" HeaderText="MinusCoplanarity_min" SortExpression="MinusCoplanarity_min" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MinusCoplanarity_max" HeaderText="MinusCoplanarity_max" SortExpression="MinusCoplanarity_max" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MinusCoplanarity_Pass" HeaderText="MinusCoplanarity_Pass" SortExpression="MinusCoplanarity_Pass" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Show.aspx?"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Modify.aspx?"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
