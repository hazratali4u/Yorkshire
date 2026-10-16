<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorCustomer.aspx.cs" Inherits="Forms_frmDistributorCustomer"
    Title="SAMS :: Customer Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
   
    <div id="right_data">
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td style="width: 20%">
                                <asp:Literal ID="ltrlNew" runat="server" Text="aa"></asp:Literal>
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="font-size: 14px; width: 20%">
                                <strong>Total Customers:
                                    <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label></strong>
                            </td>
                             <td style="font-size: 14px; width: 20%">
                                <strong>InActive Customers:
                                    <asp:Label ID="lblCountInActive" runat="server" Text="0"></asp:Label></strong>
                            </td>
                        </tr>
                    </table>
                    <table class="tblhead" width="100%">
                        <tbody>
                            <tr>
                                <td style="color: White; font-weight: bold; height: 21px; width: 15%" align="left">
                                    <asp:Label ID="Label10" runat="server" Text="Select Searching Type"></asp:Label>
                                </td>
                                <td style="height: 21px; width: 20%" align="left">
                                    <asp:DropDownList ID="ddlLocation" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 21px; width: 20%" align="left">
                                    <asp:DropDownList ID="ddSearchType" runat="server" Width="200px">
                                        <asp:ListItem Value="All">All Records</asp:ListItem>
                                        <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                        <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                        <asp:ListItem Value="CONTACT_NO">Contact No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 21px; width: 22%" align="left">
                                    <asp:TextBox ID="txtSeach" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td style="height: 21px; width: 12%" align="left">
                                    <asp:Button ID="btnSearch" runat="server" Width="100px" Font-Size="8pt" Text="Filter"
                                        OnClick="btnSearch_Click"></asp:Button>
                                </td>
                                <td style="height: 21px; width: 12%" align="left">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <fieldset>
                        <asp:Panel ID="Panel2" runat="server" Width="100%" Height="390px" ScrollBars="Auto">
                            <asp:GridView ID="gvCustomer" runat="server" Width="100%" ForeColor="SteelBlue" HorizontalAlign="Left"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="SteelBlue" OnRowEditing="gvCustomer_RowEditing"
                                OnRowDeleting="gvCustomer_RowDeleting">
                                <RowStyle ForeColor="Black"></RowStyle>
                                <Columns>
                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                        <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                        <ItemStyle CssClass="HidePanel"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID">
                                        <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                        <ItemStyle  CssClass="HidePanel">
                                        </ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer Name">
                                        <ItemStyle CssClass="grdDetail" Width="30%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"/>
                                    </asp:BoundField>
                                   
                                    <asp:BoundField DataField="ADDRESS" HeaderText="Address">
                                        <ItemStyle CssClass="grdDetail"  Width="20%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No">
                                        <ItemStyle CssClass="grdDetail"  Width="10%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"/>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                        <ItemStyle CssClass="grdDetail"  Width="6%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"/>
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="Edit">
                                                <img id="imgEdit" alt="" src="~/images/edit.gif" runat="server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="grdDetail" Width="3%" Height="14px" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="grdHead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                Text="Inactive"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="grdDetail" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" CssClass="grdHead"/>
                                    </asp:TemplateField>
                                </Columns>
                                            <HeaderStyle CssClass="grdHead"></HeaderStyle>
                                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                            </asp:GridView>
                        </asp:Panel>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
