<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDelieveryOrderAdd.aspx.cs" Inherits="Forms_frmDelieveryOrderAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btnSaveOrder.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;

        function onlyDotsAndNumbers(txt, event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            if (charCode == 9 || charCode == 8) {
                return true;
            }
            if (charCode == 46) {
                if (txt.value.indexOf(".") < 0)
                    return true;
                return false;
            }
            if (charCode == 31 || charCode < 48 || charCode > 57)
                return false;
            return true;
        }

        function CalculateTotal() {
            var totalAmount = document.getElementById('<%= txtGross.ClientID%>').value;
            var extraDiscount = $("#<%=txtDiscount.ClientID%>").val();

            $("#<%=txtTotalAmount.ClientID%>").val((totalAmount - extraDiscount).toFixed(2));
        }
    </script>
    <div id="right_data">
        <div style="z-index: 101; left: 60%; width: 100px; position: absolute; top: 1%; height: 80px">
            &nbsp;<asp:Panel ID="Panel21" runat="server">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                            Width="31px" />
                        Wait....
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </asp:Panel>
        </div>
        <asp:UpdatePanel ID="pnlMaster" runat="server">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="hfOrderQty" />
                <asp:HiddenField runat="server" ID="hfGst" />
              
                <asp:HiddenField runat="server" ID="hfInvoiceDiscount" />
                <table cellpadding="2px">
                    <tr class="tblhead">
                        <td class="tblhead" style="width: 560px;">
                            <strong>
                                <asp:Label runat="server" ID="lblCustomer" Font-Size="Medium"></asp:Label></strong>
                                <strong>-
                                <asp:Label ID="lblCustomerAddress" runat="server" Font-Size="Medium"></asp:Label></strong>
                        </td>
                        <td class="tblhead" colspan="2" style="width: 230px;">
                            <strong>
                                <asp:Label runat="server" ID="lblDONo" Font-Size="Medium"></asp:Label></strong>
                        </td>
                        <td class="tblhead" colspan="2" style="width: 230px;">
                            <strong>
                                <asp:Label runat="server" ID="lblOrderNo" Font-Size="Medium"></asp:Label></strong>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 65px;">
                            <strong>
                                <label>
                                    Location</label>
                            </strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistributor" runat="server" Width="231px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <strong>
                                <label>
                                    Customer</label>
                            </strong>
                        </td>
                        <td>
                            <strong>
                                <asp:DropDownList ID="ddlCustomer" runat="server" Width="231px">
                                </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="pnlDetail" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr valign="top">
                        <td style="width: 70%">
                            <fieldset style="width: 200px;">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left" colspan="3">
                                                <asp:Panel ID="Panel2" runat="server" Width="675px" Height="280px" ScrollBars="Vertical"
                                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                    <asp:GridView ID="grdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="SteelBlue" ForeColor="SteelBlue" HorizontalAlign="Center" Width="100%"
                                                        OnRowDataBound="grdOrder_RowDataBound">
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="skuId" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="skuName" HeaderText="Product Name">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Left" Width="440px" />
                                                                <HeaderStyle CssClass="grdHead" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="qty" HeaderText="Order Qty">
                                                                <HeaderStyle CssClass="grdHead" />
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Prev Dispatch Qty">
                                                                <HeaderStyle CssClass="grdHead" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRecQty" runat="server" Width="75px" Text='<%# Eval("RcdQty")%>'
                                                                        Enabled="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Dispatch Qty">
                                                                <HeaderStyle CssClass="grdHead" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtCurrentRecQty" runat="server" Width="75px" Text='<%# Eval("CurrentRcdQty")%>'
                                                                        OnTextChanged="txtCurrentRecQty_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="fteCurrentRecQty" runat="server"
                                                                        FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCurrentRecQty">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:f2}">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                                                <HeaderStyle CssClass="grdHead" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:f2}">
                                                                <ItemStyle CssClass="HidePanel" />
                                                                <HeaderStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RcdQty">
                                                                <ItemStyle CssClass="HidePanel" />
                                                                <HeaderStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CurrentRcdQty">
                                                                <ItemStyle CssClass="HidePanel" />
                                                                <HeaderStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="netAmount" HeaderText="Amount" DataFormatString="{0:F2}">
                                                               <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                                                <HeaderStyle CssClass="grdHead" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                       
                                    </tbody>
                                </table>
                            </fieldset>
                        </td>
                        <td style="width: 30%">
                            <table width="100%">
                                <tr>
                                    <td colspan="2">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                    <td style="width: 135px; font-size: 16px;">
                                                        <strong>Ledger Balance:</strong>
                                                    </td>
                                                    <td style="font-size: 16px;">
                                                        <asp:Label ID="lblLedgerBalance" runat="server"></asp:Label>&nbsp;
                                                       
                                                    </td>
                                                </tr>
                                               
                                              
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                              
                               <tr>
                                <td>
                                    &nbsp;
                                </td>
                               </tr>
                               <tr>
                                <td>
                                 <strong>Total Qty </strong>
                                </td>
                                <td>
                                     <asp:TextBox ID="txtTotalQty" runat="server" Font-Size="14px" Width="100px" ReadOnly="true"></asp:TextBox>
                                </td>
                               </tr>
                               <tr>
                                    <td>
                                        <strong>Gross Amount</strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGross" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                               
                              
                                <tr>
                                    <td>
                                        <strong>Discount</strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscount" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"
                                                    onkeyup="CalculateTotal();"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td>
                                        <strong>Net Amount</strong>
                                    </td>
                                    <td>
                                     <asp:TextBox ID="txtTotalAmount" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Remarks </strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Columns="35" Rows="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td>
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:CheckBox ID="chkLimit" Text="Skip Limit" Font-Size="14px" runat="server" Checked="true"/></strong>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Button AccessKey="S" ID="btnSaveOrder" runat="server" Width="100px" Font-Size="8pt"
                        Text="Save" UseSubmitBehavior="False" OnClick="btnSaveOrder_Click" CssClass="Button" />
                    <asp:Button AccessKey="C" ID="btnCancel" runat="server" Width="100px" Font-Size="8pt"
                        Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" CssClass="Button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
