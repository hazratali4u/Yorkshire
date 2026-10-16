<%@ Page Title="SAMS :: Sale Order" Language="C#" MasterPageFile="~/Forms/PageMaster.master"
    AutoEventWireup="true" CodeFile="frmSaleOrder.aspx.cs" Inherits="Forms_frmSaleOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">

        function pageLoad() {
            $("#<%=ddlCustomer.ClientID%>").searchable();
            $("#<%=ddlSKus.ClientID%>").searchable();
        }
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
        function Calculate() {

            var Qty = $("#<%=txtQuantity.ClientID%>").val();
            var Rate = $("#<%=txtRate.ClientID%>").val();
          <%-- 
          // var Discount = $("#<%=txtDiscount.ClientID%>").val();
          //if (Discount == "") {
//                Discount = 0;
//            }
          --%> 

            if (Rate == "") {
                Rate = 0;
            }
       

           // $("#<%=txtAmount.ClientID%>").val(((Qty * Rate) - Discount).toFixed(2));
            $("#<%=txtAmount.ClientID%>").val((Qty * Rate).toFixed(2));
        
        }
        function CalculateTotal() {
            var totalAmount = document.getElementById('<%= hfTotalAmount.ClientID%>').value;
            var extraDiscount = $("#<%=txtExtraDiscount.ClientID%>").val();

            $("#<%=txtTotalAmount.ClientID%>").val((totalAmount - extraDiscount).toFixed(2));
        }
    </script>
    <div id="right_data">
        <div style="z-index: 101; left: 50%; width: 100px; position: absolute; top: 10%;
            height: 100px">
            &nbsp;<asp:Panel ID="Panel21" runat="server">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                            Width="31px" />
                        Wait Update
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </asp:Panel>
        </div>
        <asp:UpdatePanel ID="pnlMaster" runat="server">
            <ContentTemplate>
                <table cellpadding="2px">
                    <tr>
                        <td style="width: 100px;">
                            <strong>
                                <label>
                                    Location</label>
                            </strong>
                        </td>
                        <td style="width: 265px;">
                            <asp:DropDownList ID="ddlDistributor" runat="server" Width="220px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlDistributor_SelectedIndexChanged" TabIndex="1">
                            </asp:DropDownList>
                        </td>
                        <td rowspan="4" style="width: 37%">
                        </td>
                        <td rowspan="4">
                            <fieldset>
                                <table>
                                    <tr>
                                        <td style="width: 140px; font-size: 16px; text-align: center">
                                            <strong>Ledger Balance</strong>
                                        </td>
                                        <tr>
                                        </tr>
                                        <td style="font-size: 16px; text-align: right">
                                            <asp:Label ID="lblLedgerBalance" runat="server"></asp:Label>
                                            <asp:Label ID="lblOpeningType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            <strong>
                                <label>
                                    Document No</label>
                            </strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpDocumentNo" runat="server" Width="220px" AutoPostBack="True"
                                OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged" TabIndex="2">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <label>
                                    Customer</label>
                            </strong>
                        </td>
                        <td>
                            <strong>
                                <asp:DropDownList ID="ddlCustomer" runat="server" Width="220px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" TabIndex="3">
                                </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 103px">
                            <strong>
                                <asp:Label ID="lblAdress" runat="server" Text="Address"></asp:Label></strong>
                        </td>
                        <td style="border: 1px solid rgb(225, 225, 225);">
                            <strong>
                                <asp:Label ID="lblCustomerAddress" runat="server"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Remarks </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" TabIndex="4" Width="495px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="pnlDetail" runat="server">
            <ContentTemplate>
                <table>
                    <tbody>
                        <tr>
                            <td style="height: 16px">
                                <asp:Label ID="lblskuname" runat="server" Width="316px" Text="Product Name" CssClass="lblDetail"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblquantity" runat="server" Width="88px" Text="Quantity" CssClass="lblDetail"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Width="78px" Text="Price" CssClass="lblDetail"></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label ID="Label3" runat="server" Width="78px" Text="Amount" CssClass="lblDetail"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlSKus" runat="server" Width="320px" TabIndex="5">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantity" runat="server" Width="88px" TabIndex="6" onkeyup="Calculate();"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Custom" ValidChars="0123456789." TargetControlID="txtQuantity">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" runat="server" Width="80px" TabIndex="7" onkeypress="return onlyDotsAndNumbers(this,event);"
                                    onkeyup="Calculate();"></asp:TextBox>
                            </td>
                          <%--  <td>
                                <asp:TextBox ID="txtDiscount" runat="server" Width="80px" TabIndex="8" onkeypress="return onlyDotsAndNumbers(this,event);"
                                    onkeyup="Calculate();"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtAmount" runat="server" Width="80px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button AccessKey="A" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="75px"
                                    Font-Size="8pt" Text="Add" CssClass="Button" TabIndex="9" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="6">
                                <asp:Panel ID="Panel2" runat="server" Width="680px" Height="200px" ScrollBars="Vertical"
                                    BorderWidth="1px" BorderStyle="Groove" BorderColor="Silver">
                                    <asp:GridView ID="grdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="White" ForeColor="SteelBlue" HorizontalAlign="Center" OnRowDeleting="grdOrder_RowDeleting"
                                        OnRowEditing="grdOrder_RowEditing" ShowHeader="False" Width="100%">
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="skuId">
                                                <HeaderStyle CssClass="HidePanel" />
                                                <ItemStyle CssClass="HidePanel" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="skuName">
                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Left" Width="310px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="qty">
                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="price" DataFormatString="{0:F2}">
                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="extraDiscount" DataFormatString="{0:F2}">
                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="netAmount" DataFormatString="{0:F2}">
                                                <ItemStyle CssClass="grdDetail" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                <ItemStyle CssClass="grdDetail" Width="35px" HorizontalAlign="Center" />
                                            </asp:CommandField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                        Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="grdDetail" Width="40px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                            VerticalAlign="Middle" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                            <td>
                            <fieldset style="position:relative; top:-17px;">
                                <table >
                                    <tr>
                                        <td style="text-align: center; width:100px;">
                                            <strong style="font-size: medium;">Total Qty </strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalQty" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                </fieldset>
                                <fieldset style="position:relative; top:16px;">
                                    <legend style="width: 95px; font-size:14px;">Calculation</legend>
                                    <table style="vertical-align: bottom;">
                                        <tr style="height:25px;">
                                            <td style="text-align: left;">
                                                <strong>Gross Amount</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGrossAmount" runat="server" Width="100px" ReadOnly="true" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <%--<tr style="height:25px;">
                                            <td style="text-align: left;">
                                                <strong>Product Discount</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStandardDiscount" runat="server" Width="100px" ReadOnly="true" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>--%>
                                        <tr style="height:25px;">
                                            <td style="text-align: left;">
                                                <strong>Discount</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExtraDiscount" runat="server" TabIndex="10" Width="100px" onkeypress="return onlyDotsAndNumbers(this,event);"
                                                    onkeyup="CalculateTotal();"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr style="height:25px;">
                                            <td style="text-align: left;">
                                                <strong>Net Amount</strong>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hfTotalAmount" runat="server"></asp:HiddenField>
                                                <asp:TextBox ID="txtTotalAmount" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Button AccessKey="S" ID="btnSaveOrder" runat="server" Width="110px" Font-Size="8pt"
                        TabIndex="11" Text="Save Order" UseSubmitBehavior="False" OnClick="btnSaveOrder_Click"
                        CssClass="Button" />
                    <asp:Button AccessKey="C" ID="btnCancel" runat="server" Width="110px" Font-Size="8pt"
                        TabIndex="12" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click"
                        CssClass="Button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
