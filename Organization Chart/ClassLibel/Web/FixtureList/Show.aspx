<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.FixtureList.Show" Title="显示页" %>
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
		BarCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBarCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Fixture_Name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFixture_Name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InstallLocation
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInstallLocation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		F_State
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblF_State" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LogDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLogDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LogUser
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLogUser" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CareUser
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCareUser" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UseDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUseDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScrapDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScrapDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FAY_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFAY_ID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Remark
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRemark" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




