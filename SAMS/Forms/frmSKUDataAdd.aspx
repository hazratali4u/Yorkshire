<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUDataAdd.aspx.cs" Inherits="Forms_frmSKUDataAdd" Title="SAMS :: SKU Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
        
        function ddlFocus(obj) {
            obj.className = "ddlFocus";
        }
        function ddlBlur(obj) {
            obj.className = "";
        }
        function pageLoad() {

            $("select").searchable();

        }

       
    </script>
    <div id="right_data">
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="80%">
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 9%; height:20px;" >
                                <strong>Category </strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Product Code </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSKUCode" runat="server" Width="192px" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Product Name </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtskuname" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>                        
                        <tr>
                            <td style="height:20px;">
                                <strong>Size </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSize" runat="server" Width="192px" CssClass="txtBox "></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Color </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Thickness </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtThickness" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Core </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCore" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Hot Press </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHotPress" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Glue </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGlue" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Face </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFace" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Sanding </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSanding" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Grade </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrade" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Tolerance </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTolerance" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                <strong>Unit In Case </strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txtunitincase" runat="server" Width="192px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="unitincase" runat="server" TargetControlID="txtunitincase"
                                    FilterType="Numbers">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                            </td>
                            <td>
                                <strong>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" Checked="true" /></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                            </td>
                            <td>
                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="86px" Font-Size="8pt"
                                    Text="Save" CssClass="Button" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" Width="26px" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif">
                    </asp:ImageButton>&nbsp; Loading....
                </ProgressTemplate>
            </asp:UpdateProgress>
        
    </div>
</asp:Content>
