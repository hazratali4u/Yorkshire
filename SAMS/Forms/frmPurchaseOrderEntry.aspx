<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmPurchaseOrderEntry.aspx.cs" Inherits="Forms_frmPurchaseOrderEntry"
    Title="SAMS :: Purchase Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $("select").searchable();
        }

        function CalcualeAmount() {
            var Qty = document.getElementById('<%=txtQuantity.ClientID%>').value;
            var Rate = document.getElementById('<%=txtRate.ClientID%>').value;

            document.getElementById("<%= txtAmount.ClientID %>").value = (Qty * Rate);
        }
        function CalculateNetAmount() {

            var grossAmount = document.getElementById('<%=txtAmountFC.ClientID%>').value;
            var gst = document.getElementById('<%=txtgst.ClientID%>').value;
            var netAmount = document.getElementById('<%=txtNetAmount.ClientID%>').value;

            if (gst == "") {
                gst = 0;
            }

            if (netAmount > 0) {

                var gstValue = parseFloat((gst / 100) * parseFloat(grossAmount)).toFixed(2);
                document.getElementById("<%= txtGstValue.ClientID %>").value = gstValue;
                document.getElementById("<%= txtNetAmount.ClientID %>").value = parseFloat(parseFloat(grossAmount) + parseFloat(gstValue)).toFixed(2);


            }
        }
        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtQuantity.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            str = document.getElementById('<%=drpPrincipal.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Plz Select Supplier');
                return false;

            }
            str = document.getElementById('<%=txtRate.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Rate');
                return false;
            }

            return true;
        }

        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }
 
    </script>
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 15%">
                                            <strong>Order For</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:DropDownList ID="drpDistributor" runat="server" AutoPostBack="True" Width="200px"
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 75%" rowspan="7">
                                            <asp:Panel ID="pnlUpload" Width="550px" Height="150px" runat="server" ScrollBars="Vertical"
                                                BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                <fieldset>
                                                    <table>
                                                        <tr>
                                                            <td width="100px">
                                                                <strong>Attach File</strong>
                                                            </td>
                                                            <td>
                                                                <asp:FileUpload ID="FupVendor" Multiple="Multiple" runat="server" Width="250px" />
                                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                                                    CssClass="Button" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="grdAttach" runat="server" CellPadding="2" Width="70%" GridLines="Horizontal"
                                                        EmptyDataText="<div style='padding:10px; margin:10px; background-color:#fbefef; border: Solid 1px #bb0000; color:#bb0000;'>There is no document to display.</div>"
                                                        OnRowCommand="grdAttach_RowCommand" OnRowDataBound="grdAttach_RowDataBound" AutoGenerateColumns="false"
                                                        BorderColor="SteelBlue">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btn_delete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Remove this Document?');"
                                                                        CommandName="btn_delete_Click" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                                        Text="Remove" OnClick="btn_delete_Click" CssClass="Button" />
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="grdDetail" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NAME" HeaderText="File Name">
                                                                <ItemStyle CssClass="grdDetail" Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PATH" HeaderText="Path">
                                                                <ItemStyle CssClass="grdDetail" Width="60%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Button Text="Download" ID="lnkViewDoc" runat="server" CommandName="download"
                                                                        CommandArgument='<%# Eval("PURCHASE_ORDER_ID")%>' ToolTip="Download Document"
                                                                        CssClass="Button"></asp:Button>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" CssClass="grdDetail" Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <HeaderStyle BackColor="#006699" ForeColor="White" />
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                </fieldset>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <strong>Transaction No</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:DropDownList ID="drpDocumentNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged"
                                                Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <strong>Supplier type</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                           <asp:RadioButtonList ID="rdbSupplierType" runat="server" Font-Bold="true" RepeatDirection="Horizontal" Width="150px"
                                           OnSelectedIndexChanged="rdbSupplierType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Selected="True">Imported</asp:ListItem>
                                                 <asp:ListItem Value="1" >Local</asp:ListItem>
                                                </asp:RadioButtonList>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <strong>Supplier</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged"
                                                Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>

                                    <tr>
                                        <td >
                                            <strong>Currency</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:DropDownList ID="ddlCurrency" runat="server" Width="200px">
                                                <asp:ListItem Value="0" Text="PKR"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="USD"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="RMB"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="AED"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Exch Rate</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:TextBox ID="txtExchangeRate" runat="server" Width="195px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                FilterType="Custom" ValidChars="0123456789." TargetControlID="txtExchangeRate">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%">
                                            <strong>Remarks</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="330px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td >
                                            <strong>CreditTerm</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:TextBox ID="txtCreditTerm" runat="server" Width="195px"></asp:TextBox>
                                        </td>
                                        <td style="width: 75%">
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td class="lblDetail">
                                                <label style="color: White;">
                                                    SKU Description</label>
                                            </td>
                                            <td class="lblDetail">
                                                <label style="color: White;">
                                                    Quantity</label>
                                            </td>
                                            <td class="lblDetail">
                                                <label style="color: White;">
                                                    Rate</label>
                                            </td>
                                            <td class="lblDetail">
                                                <label style="color: White;">
                                                    Amount</label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlSKuCde" runat="server" Width="295px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuantity" runat="server" Width="73px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQuantity">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRate" runat="server" Width="70px" onblur="CalcualeAmount();"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterType="Custom" ValidChars="0123456789." TargetControlID="txtRate">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAmount" runat="server" Width="76px" Enabled="false">0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button AccessKey="A" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="90px"
                                                    Font-Size="8pt" Text="Add" ValidationGroup="vg" CssClass="Button" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="5">
                                                <asp:Panel ID="Panel2" runat="server" Width="626px" Height="180px" ScrollBars="Vertical"
                                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                    <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                        OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                                        ShowHeader="False" Width="100%">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous" />
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                <ItemStyle CssClass="grdDetail" Width="286px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PRICE" HeaderText="Rate" DataFormatString="{0:F2}">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                                <ItemStyle CssClass="grdDetail" Width="36px" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="grdDetail" Width="40px" HorizontalAlign="Center" />
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
                                            <td style="vertical-align: top;">
                                                <fieldset>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <strong>
                                                                    <asp:Label ID="Label7" runat="server" Height="16px" Text="Total Qty"></asp:Label></strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTotalQuantity" runat="server" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>
                                                                    <asp:Label ID="Label1" runat="server" Height="16px" Text="Total Amount"></asp:Label></strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmountFC" runat="server" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                                <fieldse style="display: none;">
                                                    <legend style="width: 75px;">Calculation</legend>
                                                    <table>
                                                <td>
                                                    <strong>
                                                        <asp:Label ID="Label2" runat="server" Height="16px" Text="[Rs.]:" Visible="false"></asp:Label></strong>
                                                    <asp:TextBox ID="txtAmountRs" runat="server" Width="120px" Visible="false"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Height="16px" Text="Sales Tax %"></asp:Label></strong>
                                                <asp:TextBox ID="txtgst" runat="server" Width="88px" onkeyup="CalculateNetAmount();"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Height="16px" Text="Sales Tax Value"></asp:Label></strong>
                                                <asp:TextBox ID="txtGstValue" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Height="16px" Text="Net Amount"></asp:Label></strong>
                                                <asp:TextBox ID="txtNetAmount" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                        </tr>
                                </table>
                                </fieldset> </td> </tr> </tbody> </table>
                                <asp:Panel runat="server" ID="pnlDetail">
                                    <fieldset>
                                        <legend style="width: 130px;">Terms & Conditions</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkDestiantion" runat="server" />
                                                                <strong>Destination Port</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDestinationPort" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkDeliveryTime" runat="server" />
                                                                <strong>Delivery time</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDeliveryTime" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkPacking" runat="server" />
                                                                <strong>Packing</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPacking" runat="server" Width="350px" MaxLength="500"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkShipMark" runat="server" />
                                                                <strong>Shipping Mark</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtShippingMark" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkShipTerms" runat="server" />
                                                                <strong>Shipping terms</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtShippingTerms" runat="server" Width="350px" MaxLength="500"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkShipMode" runat="server" />
                                                                <strong>Mode of Shipment</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtShipmentMode" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkPayTerm" runat="server" />
                                                                <strong>Term of Payment</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPaymentTerm" runat="server" Width="350px" MaxLength="500"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks1" runat="server" />
                                                                <strong>Remarks 1</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks1" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks3" runat="server" />
                                                                <strong>Remarks 3</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks3" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks5" runat="server" />
                                                                <strong>Remarks 5</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks5" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks7" runat="server" />
                                                                <strong>Remarks 7</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks7" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks9" runat="server" />
                                                                <strong>Remarks 9</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks9" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 5%">
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td colspan="2">
                                                                <strong>Documents Required with Original B/L: </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkFtaCertif" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFtaCertif" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkOriginCertif" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOriginCertif" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkPhyCertificate" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPhyCertificate" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkPackList" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPackingList" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkCommInvoice" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCommercialInvoice" runat="server" Width="350px" MaxLength="150"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkConatiner" runat="server" />
                                                                <strong>Container Size</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtContainerSize" runat="server" Width="350px" MaxLength="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks2" runat="server" />
                                                                <strong>Remarks 2</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks2" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks4" runat="server" />
                                                                <strong>Remarks 4</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks4" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks6" runat="server" />
                                                                <strong>Remarks 6</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks6" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks8" runat="server" />
                                                                <strong>Remarks 8</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks8" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkRemarks10" runat="server" />
                                                                <strong>Remarks 10</strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks10" runat="server" Width="350px" MaxLength="250"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                                <br />
                                <asp:Button AccessKey="S" ID="btnSaveDocument" runat="server" Width="119px" Font-Size="8pt"
                                    Text="Save Document" UseSubmitBehavior="False" OnClick="btnSaveDocument_Click"
                                    CssClass="Button" />
                                <asp:Button AccessKey="C" ID="btnCancel" runat="server" Width="120px" Font-Size="8pt"
                                    Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" CssClass="Button" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
