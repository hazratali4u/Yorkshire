<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmVendorAdd.aspx.cs" Inherits="Forms_frmVendorAdd" Title="SAMS :: Vendor Information" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <style>
        #right #right_data fieldset legend
        {
            width: 140px;
        }
       
    </style>
    <script language="JavaScript" type="text/javascript">

        function ValidateBasicInformation() {
            var str;
            str = document.getElementById('<%=txtName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Please enter Company Name');
                return false;
            }
            return true;
        }
    </script>
    <div id="right_data">
        <asp:UpdatePanel ID="upCustomer" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 48%" valign="top">
                                        <fieldset>
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Registration No</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtRegisterNo" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Company Name</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Incorporation Date </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtIncDate" runat="server" Width="90%" Enabled="false"></asp:TextBox>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                        </asp:ImageButton>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIncDate"
                                                            PopupButtonID="ImageButton1" Format="dd-MMM-yyyy" PopupPosition="BottomRight">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <br />
                                        <br />
                                        <fieldset>
                                            <legend style="width: 192px;">Relationship / Export Manager</legend>
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Name </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtRName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Contact No </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtRContact" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Email </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtREmail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Skype </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtRSkype" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <br />
                                        <br />
                                        <asp:Panel ID="pnlStampAthrty" runat="server" GroupingText="Steal & Stamp Authority"
                                            Width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Name </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtSName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Contact No </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtSConactNo" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Email </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtSEmail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Skype </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtSSkype" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <br />
                                        <fieldset>
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Export Detail</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtExportDetail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Trade Experience</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtTradeExp" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Certificate Detail</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtCertificate" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Plant Land & Building </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtAsset" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Goods Manfacture</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtGoods" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Plant Capacity</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtPlantCapacity" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Any Account Detail</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtAccountDetail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Any Other Detail</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtOtherDetail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <br />
                                    </td>
                                    <td style="width: 4%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 48%" valign="top">
                                        <asp:Panel ID="pnlFirm" runat="server" GroupingText="Firm Official Detail" Width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Address </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtFirmAddress" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25%">
                                                        <strong>Telephone </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtFirmConatct" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Fax </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtFirmFax" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Email </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtFirmEmail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <br />
                                        <asp:Panel ID="pnlBank" runat="server" GroupingText="Bank Information" Width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Bank Name </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBankName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Account Title </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBankAccountTitle" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Account No </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBankAccountNo" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Swift Code </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtSwiftCode" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Branch Address </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBranchAddress" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Contact No </strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBContactNo" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Fax</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBFax" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 29%">
                                                        <strong>Email</strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:TextBox ID="txtBEmail" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <br />
                                        <fieldset>
                                            <table>
                                                <tr>
                                                    <td width="140px">
                                                        <strong>Attach File</strong>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FupVendor" Multiple="Multiple" runat="server" Width="250px" />
                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                                            CssClass="Button" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                     
                                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="2" Width="100%" GridLines="Horizontal"
                                                            EmptyDataText="<div style='padding:10px; margin:10px; background-color:#fbefef; border: Solid 1px #bb0000; color:#bb0000;'>There is no document to display.</div>"
                                                            OnRowCommand="grdAttach_RowCommand" OnRowDataBound="grdAttach_RowDataBound" AutoGenerateColumns="false" BorderColor="SteelBlue">
                                                            <Columns >
                                                                <asp:TemplateField >
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btn_delete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Remove this Document?');"
                                                                            CommandName="btn_delete_Click" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                                            Text="Remove" OnClick="btn_delete_Click" CssClass="Button" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle  CssClass="grdDetail" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FILENAME" HeaderText="File Name" >
                                                                <ItemStyle  CssClass="grdDetail" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="PATH" HeaderText="Path" >
                                                                <ItemStyle  CssClass="grdDetail" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle HorizontalAlign="Left"/>
                                                                    <ItemTemplate>
                                                                        <asp:Button  Text="Download" ID="lnkViewDoc" runat="server"
                                                                            CommandName="download" CommandArgument='<%# Eval("VENDOR_ID")%>' ToolTip="Download Document"
                                                                            CssClass="Button">
                                                                            
                                                                        </asp:Button>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left"   CssClass="grdDetail"/>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <HeaderStyle BackColor="#006699" ForeColor="White" />
                                                            <RowStyle BackColor="#EFF3FB" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                       
                                        <table style="margin-top:15px;">
                                         <tr>
                                                <td>
                                                  <strong>Supplier Type</strong>
                                                </td>
                                                <td>
                                                <asp:RadioButtonList ID="rdbSupplierType" runat="server" Font-Bold="true" RepeatDirection="Horizontal" Width="150px">
                                                <asp:ListItem Value="0" Selected="True">Imported</asp:ListItem>
                                                 <asp:ListItem Value="1" >Local</asp:ListItem>
                                                </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   
                                                </td>
                                                <td>
                                                 <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" Checked="true" Font-Bold="true"/>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSaveBasic" runat="server" Font-Size="8pt" OnClick="btnSaveBasic_Click"
                                                        CssClass="Button" Text="Save" Width="85px" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCancel" runat="server" Font-Size="8pt" OnClick="btnCancel_Click"
                                                        CssClass="Button" Text="Cancel" Width="85px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                <asp:PostBackTrigger ControlID="btnSaveBasic" />
                <asp:PostBackTrigger ControlID="btnCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
