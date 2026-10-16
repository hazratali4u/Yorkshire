<%@ Page Title="Freight Entry" Language="C#" MasterPageFile="~/Forms/PageMaster.master"
    AutoEventWireup="true" CodeFile="frmFreightEntry.aspx.cs" Inherits="Forms_frmFreightEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btnSaveOrder.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;

        

       
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
                    <td>
                        &nbsp;
                    </td>
                </tr>
                    <tr>
                        <td style="width: 110px;">
                            <strong>
                                <label>
                                    Location</label>
                            </strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistributor" runat="server" Width="250px" Enabled="false">
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
                                <asp:DropDownList ID="ddlCustomer" runat="server" Width="250px">
                                </asp:DropDownList>
                        </td>
                       
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="pnlDetail" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="width:110px;">
                            <strong>Builty No </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBuilty" Width="25%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Builty Date</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBuiltyDate" Width="25%" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                            </asp:ImageButton>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgToDate" TargetControlID="txtBuiltyDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Transporter Name </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTransporter" Width="25%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Truck No </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTruckNo" Width="25%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Driver Name </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDriverName" Width="25%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Freight Amount </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFreightAmount" Width="25%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Remarks </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Columns="35" Rows="3"></asp:TextBox>
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
        <table>
            <tr>
            <td>
            </td>
                <td >
                    <asp:Button AccessKey="S" ID="btnSaveOrder" runat="server" Width="90px" Font-Size="8pt"
                        Text="Save" UseSubmitBehavior="False" OnClick="btnSaveOrder_Click" CssClass="Button" />&nbsp;
                    <asp:Button AccessKey="C" ID="btnCancel" runat="server" Width="90px" Font-Size="8pt"
                        Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" CssClass="Button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
