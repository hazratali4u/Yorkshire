<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmExpenseEntryPI.aspx.cs" Inherits="frmExpenseEntryPI" Title="SAMS :: PI Expense Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $("select").searchable();
        }       
 
    </script>
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <div style="z-index: 101; left: 537px; width: 100px; position: absolute; top: 50px;
                            height: 83px">
                            &nbsp;<asp:Panel ID="Panel21" runat="server">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                    <ProgressTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                            Width="23px" />
                                        Wait Update
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </asp:Panel>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>                                
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <tr>
                                        <td style="width:10%"><strong>Location</strong></td>
                                        <td style="width:90%">
                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="200" 
                                                AutoPostBack="True" onselectedindexchanged="ddlLocation_SelectedIndexChanged" TabIndex="0"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:10%"><strong>PI#</strong></td>
                                        <td style="width:90%">
                                            <asp:DropDownList ID="ddlPINo" runat="server" Width="200" TabIndex="1"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlPINo_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:10%"><strong>Remarks</strong></td>
                                        <td style="width:90%">
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="340px" Height="30px" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table width="70%">
                                        <tr>     
                                            <td style="width:35%">
                                                <asp:Label ID="lblSKU" runat="server" Width="100%"
                                                     Text="Product Name" CssClass="lblDetail" ></asp:Label>
                                            </td>                                     
                                            <td style="width:35%">
                                                <asp:Label ID="lblExpenseHead" runat="server" Width="100%"
                                                     Text="Expense Head" CssClass="lblDetail" ></asp:Label>
                                            </td>
                                            <td style="width:20%">
                                                <asp:Label ID="lblAmount" runat="server" Width="100%" 
                                                     Text="Amount" CssClass="lblDetail"></asp:Label>
                                            <td style="width:10%">
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td style="width:35%">
                                                <asp:DropDownList ID="ddlSKU" runat="server" Width="100%" TabIndex="3"></asp:DropDownList>
                                            </td>
                                            <td style="width:35%">
                                                <asp:DropDownList ID="ddlAccountHead" runat="server" Width="100%" TabIndex="4">
                                                </asp:DropDownList>
                                            </td>                                           
                                            <td style="width:20%">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="100%" TabIndex="5"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="Custom" ValidChars="0123456789" TargetControlID="txtAmount">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td style="width:10%">
                                                <asp:Button AccessKey="A" ID="btnAdd" runat="server" Width="100%"
                                                    Font-Size="8pt" Text="Add" ValidationGroup="vg" CssClass="Button" 
                                                    onclick="btnAdd_Click" TabIndex="6"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Panel ID="pnlGrid" runat="server" Width="750px" Height="200px" ScrollBars="Vertical"
                                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                    <asp:GridView ID="gvExpense" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="White" ForeColor="SteelBlue" HorizontalAlign="Center" ShowHeader="False" Width="100%" 
                                                        OnRowDeleting="gvExpense_RowDeleting">
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="Product Name">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Left"
                                                                    Width="35%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ACCOUNT_NAME" HeaderText="Expense Head">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Left"
                                                                    Width="35%" />
                                                            </asp:BoundField>                                                            
                                                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right"
                                                                    Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="10%" HorizontalAlign="Center"/>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White" />
                                                        <PagerStyle BackColor="Transparent" />
                                                        <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                            VerticalAlign="Middle" />
                                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Button AccessKey="A" ID="btnSave" runat="server" Width="60px" Height="30px"
                                                    Font-Size="8pt" Text="Save" ValidationGroup="vg" CssClass="Button" 
                                                    onclick="btnSave_Click" TabIndex="7"/>
                                            </td>
                                        </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>        
    </div>
</asp:Content>