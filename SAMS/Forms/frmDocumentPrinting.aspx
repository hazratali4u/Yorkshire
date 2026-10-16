<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDocumentPrinting.aspx.cs" Inherits="Forms_frmDocumentPrinting" Title="SAMS :: Print Sale Document" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left" colspan="1">
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1">
                                            </td>
                                            <td align="left" colspan="1">
                                            </td>
                                            <td align="left" colspan="3">
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td style="height: 23px" align="right" colspan="5">
                                                <asp:RadioButtonList ID="rblCustomerType" runat="server" Width="300px" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="-1">All</asp:ListItem>
                                                    <asp:ListItem Value="1">Registered</asp:ListItem>
                                                    <asp:ListItem Value="0">UnRegistered</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width:95px;">
                                                <strong>
                                                   Document Type</strong>
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpLedgerType" runat="server" Width="200px">
                                                    <asp:ListItem Value="0">Sales Order </asp:ListItem>
                                                    <asp:ListItem Value="2">Outward Gate Pass</asp:ListItem>
                                                     <asp:ListItem Value="3">Invoice</asp:ListItem>                                                 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                   Location</strong>
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                    OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    Customer</strong>
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td style="height: 25px" align="left">
                                                <asp:DropDownList ID="DrpCustomer" runat="server" Width="200px" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                    From Date
                                                </strong>
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left" style="height: 25px">
                                                &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                                                    onkeyup="BlockStartDateKeyPress()" Width="150px"></asp:TextBox>
                                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                                    Width="16px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>
                                                   To Date
                                                </strong>
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left" style="height: 25px">
                                                &nbsp;<asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                                                    onkeyup="BlockEndDateKeyPress()" Width="150px"></asp:TextBox>
                                                <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                                    Width="16px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                                <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                                                    TargetControlID="txtStartDate">
                                                </cc1:CalendarExtender>
                                                <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                                                    TargetControlID="txtEndDate">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td align="left" colspan="5">
                                                <div id="divSort" class="container2">
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <strong>
                                                                       Sort By
                                                                    </strong>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:DropDownList ID="DrpSort" runat="server" CssClass="DropList" Width="240px">
                                                                        <asp:ListItem Value="0">Document No</asp:ListItem>
                                                                        <asp:ListItem Value="1">Customer Code</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <strong>
                                                                        Sort Order
                                                                    </strong>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbtSortOrder" runat="server" RepeatDirection="Horizontal"
                                                                        Width="192px">
                                                                        <asp:ListItem Selected="True" Text="Ascending"></asp:ListItem>
                                                                        <asp:ListItem Text="Descending"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp; &nbsp;
                        <asp:Button ID="btnViewPDF" runat="server" Width="90" Text="View PDF" OnClick="btnViewPDF_Click"
                            CssClass="Button" />
                        <asp:Button ID="btnViewExcel" runat="server" Width="90" Text="View Excel" OnClick="btnViewExcel_Click"
                            CssClass="Button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
