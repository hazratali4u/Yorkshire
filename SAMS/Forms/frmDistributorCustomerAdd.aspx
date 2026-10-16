<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorCustomerAdd.aspx.cs" Inherits="Forms_frmDistributorCustomerAdd"
    Title="SAMS :: Customer Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <style>
        #right #right_data fieldset legend
        {
            width: 120px;
        }
        
        .ajax__tab_xp .ajax__tab_body
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #525252;
        }
    </style>
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">

        function pageLoad() {



            $("#<%=DrpDesignation.ClientID %>").searchable();

        }


        function ValidateBasicInformation() {
            var str;
            str = document.getElementById('<%=txtCustomerName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Customer Name');
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
                            <strong>
                                <asp:Label Style="font-size: 14px;" runat="server" ID="lblCustomerInfo"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
                                <cc1:TabPanel ID="TabPanel1" runat="server">
                                    <HeaderTemplate>
                                        Basic Information
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                        <asp:Label ID="Label7" runat="server" Width="77px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                                </td>
                                                <td style="width: 175px">
                                                    <asp:DropDownList ID="DrpDistributor" runat="server" Width="205px" CssClass="DropList">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 20px">
                                                </td>
                                                <td style="width: 105px" align="left">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                       Name</strong>
                                                </td>
                                                <td style="width: 175px; height: 20px">
                                                    <asp:TextBox ID="txtCustomerName" runat="server" Width="205px" CssClass="txtBox"
                                                        MaxLength="100"></asp:TextBox>
                                                </td>
                                                <td style="width: 1px; height: 20px" valign="top">
                                                </td>
                                                <td>
                                                    <strong>
                                                        Address </strong>
                                                </td>
                                                <td style="width: 219px; height: 20px">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="205px" CssClass="txtBox " MaxLength="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                        Phone No</strong>
                                                </td>
                                                <td style="width: 175px; height: 20px">
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" Width="205px" CssClass="txtBox" MaxLength="15"></asp:TextBox>
                                                </td>
                                                <td style="width: 1px; height: 20px" valign="top">
                                                </td>
                                                <td>
                                                    <strong>Date Of Birth</strong>
                                                </td>
                                                <td style="width: 219px; height: 20px">
                                                    <asp:TextBox ID="txtRegdate" runat="server" Width="180px" CssClass="txtBox" Enabled="false"></asp:TextBox>
                                                    <asp:ImageButton ID="ibndob" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                    </asp:ImageButton>
                                                    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                                    <cc1:CalendarExtender ID="CEStartDate" runat="server" TargetControlID="txtRegdate"
                                                        PopupButtonID="ibndob" Format="dd-MMM-yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                        Mobile No</strong>
                                                </td>
                                                <td style="width: 175px; height: 20px">
                                                    <asp:TextBox ID="txtMobileNo" runat="server" Width="205px" CssClass="txtBox" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td style="width: 1px; height: 20px" valign="top">
                                                </td>
                                                <td>
                                                    <strong>
                                                        Url</strong>
                                                </td>
                                                <td style="width: 219px; height: 20px">
                                                    <asp:TextBox ID="txtUrl" runat="server" Width="205px" CssClass="txtBox" MaxLength="150"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                        Fax No</strong>
                                                </td>
                                                <td style="width: 175px; height: 20px">
                                                    <asp:TextBox ID="txtFAX" runat="server" Width="205px" CssClass="txtBox" MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td style="width: 1px; height: 20px" valign="top">
                                                </td>
                                                <td>
                                                    <strong>
                                                       NTN #</strong>
                                                </td>
                                                <td style="width: 219px; height: 20px">
                                                    <asp:TextBox ID="txtNTN" runat="server" Width="205px" CssClass="txtBox" MaxLength="11"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                    <strong>
                                                        <asp:Label ID="Label2" runat="server" Width="100px" Text="Email Address" CssClass="lblbox"></asp:Label></strong>
                                                </td>
                                                <td style="width: 175px; height: 20px">
                                                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="205px" CssClass="txtBox"
                                                        MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td style="width: 1px; height: 20px" valign="top">
                                                </td>
                                                <td>
                                                    <strong>
                                                        <asp:Label ID="Label6" runat="server" Width="106px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong>
                                                </td>
                                                <td style="width: 219px; height: 20px">
                                                    <asp:TextBox ID="txtContactPerson" runat="server" Width="205px" CssClass="txtBox"
                                                        MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td style="width: 82px; height: 20px">
                                                    <strong>Designation</strong>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DrpDesignation" runat="server" Width="180px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px">
                                                    <strong>S.TaxNo</strong>
                                                </td>
                                                <td style="width: 219px">
                                                    <asp:TextBox ID="txtGstNo" runat="server" Width="205px" CssClass="txtBox" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <strong>S.Tax % </strong>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTaxRate" runat="server" Width="90px" CssClass="txtBox "></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="ftbeTaxRate" ValidChars=".0123456789" runat="server"
                                                        TargetControlID="txtTaxRate">
                                                    </cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                 <td style="height: 20px">
                                                   
                                                </td>
                                                <td style="width: 219px">
                                                <asp:CheckBox ID="chkIsActive" runat="server" Checked="True" Font-Bold="true" Text="IsActive"
                                                        Width="93px" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 105px">
                                                </td>
                                                <td style="width: 175px">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="Button" Font-Size="8pt" OnClick="btnSave_Click"
                                                        Text="Save" ValidationGroup="vg" Width="80px" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="Button" Font-Size="8pt" OnClick="btnCancel_Click"
                                                        Text="Cancel" Width="80px" />
                                                </td>
                                                <td style="width: 1px">
                                                </td>
                                                <td>
                                                    
                                                </td>
                                                <td style="width: 219px">
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel3" Visible="false">
                                    <HeaderTemplate>
                                        Opening Balance
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel4" runat="server" GroupingText="Opening Balance" Width="100%">
                                                    <br />
                                                    <table width="80%">
                                                        <tr>
                                                            <td style="width: 55%" valign="top">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 30%">
                                                                            <strong>Type</strong>
                                                                        </td>
                                                                        <td style="width: 5%">
                                                                        </td>
                                                                        <td style="width: 65%">
                                                                            <asp:RadioButtonList ID="rblOpening" runat="server" Width="100%" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="0" Text="Credit" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Debit"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 30%">
                                                                            <strong>Date</strong>
                                                                        </td>
                                                                        <td style="width: 5%">
                                                                        </td>
                                                                        <td style="width: 65%">
                                                                            <asp:TextBox ID="txtOpeningDate" runat="server" Width="90%"></asp:TextBox>
                                                                            <asp:ImageButton ID="ibOpeningDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                                            </asp:ImageButton>
                                                                            <cc1:CalendarExtender ID="ceOpeningDate" runat="server" TargetControlID="txtOpeningDate"
                                                                                PopupButtonID="ibOpeningDate" Format="dd-MMM-yyyy">
                                                                            </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 30%">
                                                                            <strong>Opening Balance</strong>
                                                                        </td>
                                                                        <td style="width: 5%">
                                                                        </td>
                                                                        <td style="width: 65%">
                                                                            <asp:TextBox ID="txtOpeningBalance" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 30%">
                                                                            <strong>Remarks</strong>
                                                                        </td>
                                                                        <td style="width: 5%">
                                                                        </td>
                                                                        <td style="width: 65%">
                                                                            <asp:TextBox ID="txtOpeningBalanceRemarks" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center">
                                                                            <br />
                                                                            <asp:Button ID="btnSaveOpeningBalance" runat="server" Font-Size="8pt" OnClick="btnOpeningBalance_Click"
                                                                                CssClass="Button" Text="Save" Width="85px" />
                                                                            <asp:Button ID="btnCancelOpeningBalance" runat="server" Font-Size="8pt" OnClick="btnCancel_Click"
                                                                                CssClass="Button" Text="Cancel" Width="85px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 45%" valign="middle">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
