<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUData.aspx.cs" Inherits="Forms_frmSKUData" Title="SAMS :: SKU Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
    <div style="z-index: 101; left: 530px; width: 100px; position: absolute; top: 2px;
                        height: 100px">
        <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Width="26px" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif">
                </asp:ImageButton>&nbsp; Loading....
            </ProgressTemplate>
        </asp:UpdateProgress>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <table width="100%">
                            <tr>
                                <td>
                                
                                <asp:Literal ID="ltrlNew" runat="server" Text="aa"></asp:Literal>
                                </td>
                            </tr>
                              </table>
                                <table class="tblhead" width="100%" >
                                    <tr>
                                        <td style="color: White; font-weight: bold;">
                                            <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label>
                                        </td>
                                        <td style="width: 170px; height: 22px" align="left">
                                            <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                                <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                                <asp:ListItem Value="CATEGORY">Category</asp:ListItem>
                                                <asp:ListItem Value="SKU_NAME">Name</asp:ListItem>
                                                <asp:ListItem Value="Color">Color</asp:ListItem>
                                                <asp:ListItem Value="size">Size</asp:ListItem>
                                                <asp:ListItem Value="thickness">Thickness</asp:ListItem>
                                                <asp:ListItem Value="core">Core</asp:ListItem>
                                                <asp:ListItem Value="glue">Glue</asp:ListItem>
                                                <asp:ListItem Value="face">Face</asp:ListItem>
                                                <asp:ListItem Value="grade">Grade</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 224px; height: 22px" align="left">
                                            <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="width: 250px; height: 22px" align="left">
                                            <asp:Button ID="btnFilter" runat="server" Width="85px" Font-Size="8pt" Text="Filter"
                                                OnClick="btnFilter_Click" style="cursor:pointer;"></asp:Button>
                                        </td>
                                        <td style="width: 250px; height: 22px">
                                        </td>
                                    </tr>
                                </table>
                                <fieldset>
                                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="390px" ScrollBars="Auto">
                                    <asp:GridView ID="grdSKUData" runat="server" Width="100%" ForeColor="SteelBlue" HorizontalAlign="Center"
                                        BorderColor="SteelBlue" BackColor="White" AutoGenerateColumns="False" OnRowEditing="grdSKUData_RowEditing"
                                        OnRowDeleting="grdSKUData_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="CATEGORY_ID">
                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                <ItemStyle CssClass="HidePanel"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CATEGORY" HeaderText="Category Name">
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle CssClass="grdDetail" Width="12%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SKU_NAME" HeaderText="Item Name">
                                                <ItemStyle CssClass="grdDetail" Width="18%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="color" HeaderText="Color">
                                                <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="size" HeaderText="Size">
                                                <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="thickness" HeaderText="Thickness">
                                                <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="core" HeaderText="Core">
                                                <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="hotpress" HeaderText="HotPress">
                                                <ItemStyle CssClass="HidePanel" />
                                                <HeaderStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="glue" HeaderText="Glue">
                                                <ItemStyle CssClass="HidePanel" />
                                                <HeaderStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="face" HeaderText="Face">
                                                 <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="grade" HeaderText="Grade">
                                                 <ItemStyle CssClass="grdDetail" Width="10%"></ItemStyle>
                                                <HeaderStyle CssClass="grdHead" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UNITS_IN_CASE" HeaderText="UIC">
                                                <ItemStyle CssClass="HidePanel" />
                                                <HeaderStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="Edit">
                                                        <img id="imgEdit" alt="" src="~/images/edit.gif" runat="server" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="grdDetail" Width="3%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="grdHead" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                        Text="Inactive"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                                </ItemStyle>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                </asp:Panel>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
