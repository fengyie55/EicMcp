<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.Equipment_Maintain.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		FormNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFormNum" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Num
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAss_Num" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Name
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAss_Name" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_MakeNum
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAss_MakeNum" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ass_Type
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAss_Type" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtApply_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_Describe
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtApply_Describe" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Apply_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtApply_User" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Cause
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaintain_Cause" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Describe
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaintain_Describe" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		maintain_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmaintain_User" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Maintain_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMaintain_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Deseribe
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCheck_Deseribe" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Result
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCheck_Result" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_Date
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCheck_Date" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Check_User
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCheck_User" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Remarks
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemarks" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

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
