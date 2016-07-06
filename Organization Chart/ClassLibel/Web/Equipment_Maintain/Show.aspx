<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Equipment_Maintain.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Mat_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMat_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FormNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFormNum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Num
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAss_Num" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAss_Name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_MakeNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAss_MakeNum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAss_Type" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblApply_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_Describe
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblApply_Describe" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblApply_User" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Cause
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaintain_Cause" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Describe
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaintain_Describe" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		maintain_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmaintain_User" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaintain_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Deseribe
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheck_Deseribe" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Result
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheck_Result" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheck_Date" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheck_User" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Remarks
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRemarks" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




