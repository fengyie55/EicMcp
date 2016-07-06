<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Material_Receive.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Re_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRe_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReceiveID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblReceiveID" runat="server"></asp:Label>
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
		ClientNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblClientNum" runat="server"></asp:Label>
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
		WorkStationID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWorkStationID" runat="server"></asp:Label>
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




