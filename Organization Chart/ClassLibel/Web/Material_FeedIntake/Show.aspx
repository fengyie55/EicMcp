<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Material_FeedIntake.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Fe_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFe_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FeedIntakeID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFeedIntakeID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MaterialNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMaterialNum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Count
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WorkstationID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWorkstationID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DataTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDataTime" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




