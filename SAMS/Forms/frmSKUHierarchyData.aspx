<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUHierarchyData.aspx.cs" Inherits="frmSKUHierarchyData" Title="SAMS :: SKU Hierarchy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            
        }
 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server" Height="400px" Width="550px"
                        ActiveTabIndex="0">
                        <cc1:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>
                                Category
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr style="display:none;">
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                                <td style="width: 49px; height: 28px">
                                                                    <strong>
                                                                        <asp:Label ID="Label1" runat="server" Width="90px" Text="Code"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                    <asp:TextBox ID="txtCategoryCode" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 28px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                                <td style="width: 49px; height: 29px">
                                                                    <strong>
                                                                        <asp:Label ID="Label2" runat="server" Width="96px" Text="Name"></asp:Label></strong>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                    <asp:TextBox ID="txtCategoryName" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 100px; height: 29px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                </td>
                                                                <td style="width: 49px" align="right">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 100px">
                                                                    <asp:Button ID="btnSaveCategory" OnClick="btnSaveCategory_Click" runat="server"
                                                                        Width="85px" Font-Size="8pt" Text="New" CssClass="Button" />
                                                                </td>
                                                                <td style="width: 100px">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                                <ProgressTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Width="33px" Height="31px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdCategory" runat="server" Width="99%" ForeColor="SteelBlue"
                                                            Font-Size="9pt" CssClass="gridRow2" BorderColor="SteelBlue"
                                                            BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdCategory_RowEditing"
                                                            OnRowDeleting="GrdCategory_RowDeleting">
                                                            
                                                            <Columns>
                                                                <asp:BoundField DataField="SKU_HIE_ID" >
                                                                    <ItemStyle CssClass="HidePanel" />
                                                                    <HeaderStyle CssClass="HidePanel" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_CODE" >
                                                                    <ItemStyle CssClass="HidePanel" />
                                                                    <HeaderStyle CssClass="HidePanel"/>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
                                                                    <ItemStyle CssClass="grdDetail" HorizontalAlign="Left" Width="80%"/>
                                                                    
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowEditButton="True">
                                                                    <ItemStyle CssClass="grdDetail" HorizontalAlign="Center" Width="10%"/>
                                                                </asp:CommandField>
                                                                <asp:TemplateField >
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                            Text="Delete"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="grdDetail" HorizontalAlign="Center" Width="10%"/>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
