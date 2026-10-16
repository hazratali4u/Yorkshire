<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmProformaInvoiceView.aspx.cs" Inherits="Forms_frmProformaInvoiceView"
    Title="SAMS :: Proforma Invoice Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script type="text/javascript" src="../AjaxLibrary/jquery.searchabledropdown-1.0.8.min.js"></script>
    <script language="JavaScript" type="text/javascript">
        function pageLoad() {
            $("select").searchable();
        } 
    </script>
    <div id="right_data">
        <table width="95%">
            <tr>               
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
                            <asp:Panel ID="pnEnquiryList" runat="server" Width="95%">
                            <table width="100%">
                                <tbody>
                                     <tr>
                                        <td>
                                            <asp:Literal ID="ltrlNewPI" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="2" > 
                                                <tr>
                                                        <td class="tblhead" style="width:10%;">PI No</td>
                                                         
                                                        <td class="tblhead" style="width:10%;">PI Date</td>
                                                        <td class="tblhead" style="width:45%;">Supplier</td>
                                                        <td class="tblhead" style="width:15%;">Location</td>
                                                        <td class="tblhead" style="width:10%;">Document Date</td>
                                                         <td class="tblhead" colspan="2" style="width:10%;"></td>
                                                </tr>
                                            </table>
                                            <div style="border: thin solid #006699">
                                            <asp:Repeater ID="rptPI" runat="server" 
                                                OnItemCommand="rptPI_ItemCommand">
                                                <ItemTemplate>
                                                    <div style="background:#EFF3FB">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                                    <tr>
                                                                        <td style="width:10%;"><%# Eval("PI_NO")%> </td>                                                                        
                                                                        <td style="width:10%;"><%# ((DateTime)Eval("PI_DATE")).ToString("dd-MMM-yyyy")%></td>
                                                                        <td style="width:45%;"><%# Eval("SKU_HIE_NAME")%> </td>
                                                                        <td style="width:15%;"><%# Eval("DISTRIBUTOR_NAME")%></td>
                                                                        <td style="width:10%;"><%# ((DateTime)Eval("DOCUMENT_DATE")).ToString("dd-MMM-yyyy")%> </td>
                                                                         <td style="width:5%;">
                                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("PROFORMA_INVOICE_ID") %>' ToolTip="Delete PI" OnClientClick="return confirm('Are you sure? you are going to delete this PI.');">
                                                                                <img src="../images/delete.gif" width="16" height="16">
                                                                            </asp:LinkButton>
                                                                        </td>                                                                        
                                                                        <td style="width:5%;">
                                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("PROFORMA_INVOICE_ID") %>' ToolTip="Delete PI">
                                                                                <img src="../images/edit.gif" width="16" height="16">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                            
                                                    </div>
                                                </ItemTemplate> 
                                                <AlternatingItemTemplate>
                                                    <div style="background:#ffffff">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                                    <tr>
                                                                        <td style="width:10%;"><%# Eval("PI_NO")%> </td>                                                                        
                                                                        <td style="width:10%;"><%# ((DateTime)Eval("PI_DATE")).ToString("dd-MMM-yyyy")%></td>
                                                                        <td style="width:45%;"><%# Eval("SKU_HIE_NAME")%> </td>
                                                                        <td style="width:15%;"><%# Eval("DISTRIBUTOR_NAME")%></td>
                                                                        <td style="width:10%;"><%# ((DateTime)Eval("DOCUMENT_DATE")).ToString("dd-MMM-yyyy")%> </td>
                                                                         <td style="width:5%;">
                                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("PROFORMA_INVOICE_ID") %>' ToolTip="Delete PI" OnClientClick="return confirm('Are you sure? you are going to delete this PI.');">
                                                                                <img src="../images/delete.gif" width="16" height="16">
                                                                            </asp:LinkButton>
                                                                        </td>                                                                        
                                                                        <td style="width:5%;">
                                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("PROFORMA_INVOICE_ID") %>' ToolTip="Delete PI">
                                                                                <img src="../images/edit.gif" width="16" height="16">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                           
                                                    </div>
                                                </AlternatingItemTemplate>                                                                                                
                                            </asp:Repeater>
                                            </div>
                                            <table width="100%">
                                            <tr>
                                                <td align="right" width="56%">
                                                        <asp:LinkButton ID="linkbtnprev" runat="server" 
                                                   onclick="linkbtnprev_Click" CausesValidation="false" Visible="false" style="color: #6C5A10;">Previous</asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="linkbtnnext" runat="server" 
                                                  onclick="linkbtnnext_Click" CausesValidation="false" Visible="false" style="color: #6C5A10;">Next</asp:LinkButton>
                                                </td>
                                                <td align="right" width="44%">
                                                <asp:Label ID="lblCurrentPageNo" runat="server" Text="" Visible="false" style="color: #6C5A10;"></asp:Label>
                                                    <asp:Label ID="lblOf" runat="server" Text="Of" Visible="false" style="color: #6C5A10;"></asp:Label>
                                                    <asp:Label ID="lblTotalNoOfPages" runat="server" Text="" Visible="false" style="color: #6C5A10;"></asp:Label>
                                                    <asp:Label ID="lblDummy" runat="server" Text="| Total Records:" Visible="false" style="color: #6C5A10;"></asp:Label>
                                                    <asp:Label ID="lblTotalNoOfRecords" runat="server" Text="" Visible="false" style="color: #6C5A10;"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>                        
                        </contenttemplate>
                    </asp:UpdatePanel>                    
                    <div style="z-index: 101; left: 640px; width: 100px; position: absolute; top: 10px;
                        height: 50px">
                        &nbsp;<asp:Panel ID="Panel21" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update</ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </td>               
            </tr>
        </table>
           </div>
</asp:Content>
