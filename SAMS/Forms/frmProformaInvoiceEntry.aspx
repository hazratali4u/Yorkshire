<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmProformaInvoiceEntry.aspx.cs" Inherits="Forms_frmProformaInvoiceEntry"
    Title="SAMS :: Proforma Invoice Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $("select").searchable();
        }

        function calcAmount(objPIQty, objPrice, objAmount) {
            
            if (objPIQty.value > 0) {
            }
            else {
                objPIQty.value = 0;
            }
            if (parseFloat(objPrice) > 0) {
                objAmount.firstChild.nodeValue = parseFloat(objPrice) * parseFloat(objPIQty.value);
            }
            else {
                objAmount.firstChild.nodeValue = '0';
            }
            var objRate = 0;
            var objValue = 0;            
            var gv = document.getElementById('<%=GrdPurchase.ClientID %>');
            var oRows = gv.rows;
            var cell;
            for (var i = 0; i < oRows.length; i++) {
                var oRow = oRows[i];
                objRate += parseFloat(gv.rows[i].cells[3].children[0].value);
                objValue += parseFloat(gv.rows[i].cells[5].textContent);                
            }

            document.getElementById("<%= txtTotalQuantity.ClientID%>").value = objRate;
            document.getElementById("<%= txtAmountFC.ClientID%>").value = objValue;
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
                                                    <asp:GridView ID="grdAttach" runat="server" CellPadding="2" Width="70%" GridLines="Horizontal"
                                                        EmptyDataText="<div style='padding:10px; margin:10px; background-color:#fbefef; border: Solid 1px #bb0000; color:#bb0000;'>There is no document to display.</div>"
                                                        OnRowCommand="grdAttach_RowCommand" AutoGenerateColumns="false"
                                                        BorderColor="SteelBlue">
                                                        <Columns>
                                                            <asp:BoundField DataField="NAME" HeaderText="File Name">
                                                                <ItemStyle CssClass="grdDetail" Width="20%" />
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
                                            <strong>PO No</strong>
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
                                            <strong>Supplier</strong>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td style="width: 11%">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="200px" Enabled="false">
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
                                            <asp:DropDownList ID="ddlCurrency" runat="server" Width="200px" Enabled="false">
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
                                            <asp:TextBox ID="txtExchangeRate" runat="server" Width="195px" Enabled="false"></asp:TextBox>
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
                                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="330px" Enabled="false"></asp:TextBox>
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
                                <table width="80%">
                                    <tbody>
                                        <tr>
                                            <td class="lblDetail" style="width:30%">
                                                <label style="color: White;">
                                                    SKU Description</label>
                                            </td>
                                            <td class="lblDetail"  style="width:20%">
                                                <label style="color: White;">
                                                    PO Quantity</label>
                                            </td>
                                            <td class="lblDetail"  style="width:20%">
                                                <label style="color: White;">
                                                    PI Quantity</label>
                                            </td>
                                            <td class="lblDetail"  style="width:15%">
                                                <label style="color: White;">
                                                    Rate</label>
                                            </td>
                                            <td class="lblDetail"  style="width:15%">
                                                <label style="color: White;">
                                                    Amount</label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="5">
                                                <asp:Panel ID="Panel2" runat="server" Width="700px" Height="180px" ScrollBars="Vertical"
                                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                                    <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"                                                        
                                                        ShowHeader="False" Width="100%" OnRowDataBound="GrdPurchase_RowDataBound">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous" />
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="HidePanel" />
                                                                <ItemStyle CssClass="HidePanel" Width="1%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                <ItemStyle CssClass="grdDetail" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="POQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPOQty" runat="server" Text='<%#Eval("POQty") %>' Width="90%" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="grdDetail" Width="20%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PIQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPIQty" runat="server" Text='<%#Eval("Quantity") %>' Width="90%"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                        FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPIQty">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="grdDetail" Width="20%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PRICE" HeaderText="Rate" DataFormatString="{0:F2}">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="14%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="15%"/>
                                                            </asp:BoundField>                                                            
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
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <strong>
                                                                    <asp:Label ID="Label7" runat="server" Width="100px" Height="16px" Text="Total Qty"></asp:Label></strong>
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
                                                <br />
                                                <fieldset>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <strong>
                                                                    <asp:Label ID="lblPINo" runat="server" Height="16px" Text="P.I. #"></asp:Label>
                                                                </strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPINo" runat="server" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>
                                                                    <asp:Label ID="lblPIDate" runat="server" Height="16px" Text="P.I. Date"></asp:Label>
                                                                </strong>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPIDate" runat="server" Width="100px"></asp:TextBox>
                                                                <asp:ImageButton ID="ibPIDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" Width="16px" />
                                                                <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                                                <cc1:CalendarExtender ID="cePIDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibPIDate"
                                                                    TargetControlID="txtPIDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Height="16px" Text="Sales Tax %"></asp:Label></strong>
                                                <asp:TextBox ID="txtgst" runat="server" Width="88px" onkeyup="CalculateNetAmount();" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Height="16px" Text="Sales Tax Value"></asp:Label></strong>
                                                <asp:TextBox ID="txtGstValue" runat="server" Width="120px"  ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Height="16px" Text="Net Amount"></asp:Label></strong>
                                                <asp:TextBox ID="txtNetAmount" runat="server" Width="120px"  ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                </table>
                                </fieldset> </td> </tr> </tbody> </table>
                                <asp:Panel runat="server" ID="pnlDetail" Enabled="false">
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
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnSaveDocument" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
