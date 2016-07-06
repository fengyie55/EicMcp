<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Rework.Show" Title="显示页" %>
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
		SN
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PigtailType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPigtailType" runat="server"></asp:Label>
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
		RejectID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRejectID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RejectDescribe
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRejectDescribe" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DisposeID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDisposeID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DisposeDescribe
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDisposeDescribe" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Length
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLength" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Result
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblResult" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReworkID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblReworkID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VerifyID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVerifyID" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




