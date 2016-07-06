<%@ Page Title="tb_Equipment_Maintain" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.Equipment_Maintain.List" %>
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
                    BorderWidth="1px" DataKeyNames="Mat_ID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="FormNum" HeaderText="FormNum" SortExpression="FormNum" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Ass_Num" HeaderText="Ass_Num" SortExpression="Ass_Num" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Ass_Name" HeaderText="Ass_Name" SortExpression="Ass_Name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Ass_MakeNum" HeaderText="Ass_MakeNum" SortExpression="Ass_MakeNum" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Ass_Type" HeaderText="Ass_Type" SortExpression="Ass_Type" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Apply_Date" HeaderText="Apply_Date" SortExpression="Apply_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Apply_Describe" HeaderText="Apply_Describe" SortExpression="Apply_Describe" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Apply_User" HeaderText="Apply_User" SortExpression="Apply_User" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Maintain_Cause" HeaderText="Maintain_Cause" SortExpression="Maintain_Cause" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Maintain_Describe" HeaderText="Maintain_Describe" SortExpression="Maintain_Describe" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="maintain_User" HeaderText="maintain_User" SortExpression="maintain_User" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Maintain_Date" HeaderText="Maintain_Date" SortExpression="Maintain_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Check_Deseribe" HeaderText="Check_Deseribe" SortExpression="Check_Deseribe" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Check_Result" HeaderText="Check_Result" SortExpression="Check_Result" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Check_Date" HeaderText="Check_Date" SortExpression="Check_Date" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Check_User" HeaderText="Check_User" SortExpression="Check_User" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Mat_ID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Mat_ID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
