<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Maticsoft.Web.FixtureList.Modify" Title="修改页" %>
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
		<asp:label id="lblID" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BarCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBarCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Fixture_Name
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFixture_Name" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InstallLocation
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInstallLocation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		F_State
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtF_State" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LogDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtLogDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LogUser
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLogUser" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CareUser
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCareUser" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UseDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtUseDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ScrapDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtScrapDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FAY_ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFAY_ID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Remark
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemark" runat="server" Width="200px"></asp:TextBox>
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

