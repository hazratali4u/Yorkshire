<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUDataOld.aspx.cs" Inherits="Forms_frmSKUData" Title="SAMS :: SKU Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
     <script language="JavaScript" type="text/javascript">
         function pageLoad() {
             var val = '<%=Session["Pic"] %>';
             if (val == '') {
             } else {
                 var logo = '<%= Session["Pic"]%>';
                 $('#ctl00_ctl00_mainCopy_cphPage_iItem').attr('src', '../Pics/' + logo).width(175).height(168);
             }
         }

         function readURL(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#ctl00_ctl00_mainCopy_cphPage_iItem').attr('src', e.target.result).width(175).height(168);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }  
  </script>
  <style></style>
    <div id="right_data">  
        <div>        
        <asp:FileUpload ID="fuImage" onchange = "readURL(this);" style="display:none;" runat="server"></asp:FileUpload>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>                                    
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td style="width:40" valign="top">
                                            <table width="100%">                                                
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label7" runat="server" Text="Item Name"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtskuname" runat="server" Width="192px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label13" runat="server" Text="Market Calling Name" Width="130px"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtskuname2" runat="server" Width="192px" CssClass="txtBox "></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label6" runat="server" Text="Catalog No."></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtskucode" runat="server" Width="192px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label8" runat="server" Text="Max. Stock Level"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtMaximumStock" runat="server" Width="192px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender id="fteMaximumStock" runat="server" TargetControlID="txtMaximumStock" FilterType="Custom" ValidChars="0123456789"> 
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label19" runat="server" Text="Min. Stock Level"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtMinimumStock" runat="server" Width="192px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender id="fteMinimumStock" runat="server" TargetControlID="txtMinimumStock" FilterType="Custom" ValidChars="0123456789"> 
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label16" runat="server" Text="Unit In Case"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtunitincase" runat="server" Width="192px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="unitincase" runat="server" TargetControlID="txtunitincase"
                                                            FilterType="Numbers">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label12" runat="server" Text="Weight"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtSkuweight" runat="server" Width="100px"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlUOM" runat="server" Width="90px">
                                                            <asp:ListItem Value="0" Text="Kg"></asp:ListItem>                                                            
                                                            <asp:ListItem Value="1" Text="Grm"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Ltr"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <cc1:FilteredTextBoxExtender id="fteSkuweight" runat="server" TargetControlID="txtSkuweight" FilterType="Custom" ValidChars=".0123456789"> 
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label11" runat="server" Text="Store Location"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:TextBox ID="txtLocation" runat="server" Width="192px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <br />
                                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="86px" Font-Size="8pt"
                                                        Text="Save" CssClass="Button" />                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:40" valign="top">
                                            <table width="100%">                                                
                                            <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label2" runat="server" Width="100px" Text="Type"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlType" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label3" runat="server" Width="100px" Text="Technology"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlTechnology" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label4" runat="server" Width="100px" Text="Nature"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlNature" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label1" runat="server" Width="100px" Text="Model"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlModel" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>                                                
                                                
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label9" runat="server" Text="Item Source"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlSourece" runat="server" Width="200px">
                                                            <asp:ListItem Value="0">Local Vendors</asp:ListItem>
                                                            <asp:ListItem Value="1">Inhouse Production</asp:ListItem>
                                                            <asp:ListItem Value="2">Imported Vendors</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label14" runat="server" Text="Color"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlColor" runat="server" Width="200px">
                                                            <asp:ListItem Value="0">Red</asp:ListItem>
                                                            <asp:ListItem Value="1">Black</asp:ListItem>
                                                            <asp:ListItem Value="2">Silver</asp:ListItem>
                                                            <asp:ListItem Value="3">Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:25%">
                                                        <strong>
                                                            <asp:Label ID="Label15" runat="server" Text="Units"></asp:Label>
                                                        </strong>                                                        
                                                    </td>
                                                    <td style="width:1%"></td>
                                                    <td style="width:74%">
                                                        <asp:DropDownList ID="ddlUnit" runat="server" Width="200px">
                                                            <asp:ListItem Value="0">Nos</asp:ListItem>
                                                            <asp:ListItem Value="1">Sets</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>                                                
                                            </table>
                                        </td>
                                        <td style="width:20" align="center" valign="top">
                                            <label for="ctl00_ctl00_mainCopy_cphPage_fuImage" id="lbl" runat="server" style="cursor: pointer;">
                                                <asp:Image runat="server" ID="iItem" Width="175" Height="168" ImageUrl="~/images/noimage.jpg" />
                                            </label>
                                        </td>
                                    </tr>
                                </table>                                

                                <table class="tblhead" width="100%">
                        <tbody>
                            <tr>
                                <td style="color: White; font-weight: bold;">
                                    <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label>
                                </td>
                                <td style="width: 170px; height: 22px" align="left">
                                    <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                        <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                        <asp:ListItem Value="Principal">Model</asp:ListItem>
                                        <asp:ListItem Value="Division">Type</asp:ListItem>
                                        <asp:ListItem Value="Category">Technology</asp:ListItem>
                                        <asp:ListItem Value="Brand">Nature</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 224px; height: 22px" align="left">
                                    <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                </td>
                                <td style="width: 250px; height: 22px" align="left">
                                    <asp:Button ID="btnFilter" runat="server" Width="85px" Font-Size="8pt" Text="Filter"
                                        OnClick="btnFilter_Click"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Auto" BorderColor="Silver" BorderStyle="Solid">
                        <asp:GridView ID="grdSKUData" runat="server" Width="99%" ForeColor="SteelBlue" CssClass="gridRow2"
                            OnPageIndexChanging="grdSKUData_PageIndexChanging" HorizontalAlign="Center" BorderColor="White"
                            BackColor="White" AutoGenerateColumns="False" OnRowEditing="grdSKUData_RowEditing"
                             OnRowDeleting="grdSKUData_RowDeleting">
                            
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous"></PagerSettings>
                            <Columns>
                                <asp:BoundField DataField="MODEL_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TYPE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TECHNOLOGY_ID" HeaderText="Category_Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NATURE_ID" HeaderText="Brand_Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SOURCE_ID" HeaderText="SOURCE_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="COLOR_ID" HeaderText="COLOR_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UNIT_ID" HeaderText="UNIT_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_NAME" HeaderText="Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_NAME2" HeaderText="Market Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CATALOG_NO" HeaderText="Catalog No">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MAX_STOCK" HeaderText="Max. Stock">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MIN_STOCK" HeaderText="Min. Stock">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UNITS_IN_CASE" HeaderText="UIC">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel">                                    
                                    </ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="HidePanel" />
                                </asp:BoundField>                                
                                 <asp:BoundField DataField="SKU_WEIGHT" HeaderText="WEIGHT">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="STORE_LOCATION" HeaderText="STORE_LOCATION">
                                    <ItemStyle CssClass="HidePanel">
                                    </ItemStyle>
                                    <HeaderStyle CssClass="HidePanel" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PIC" HeaderText="PIC">
                                    <ItemStyle CssClass="HidePanel">
                                    </ItemStyle>
                                    <HeaderStyle CssClass="HidePanel" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UOM" HeaderText="UOM">
                                    <ItemStyle CssClass="HidePanel">
                                    </ItemStyle>
                                    <HeaderStyle CssClass="HidePanel" />
                                </asp:BoundField>
                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:CommandField> 
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                            Text="Inactive"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" HorizontalAlign="Left">
                                    </ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>                           
                            </Columns>
                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                        </asp:GridView>
                    </asp:Panel>
                     <asp:Label ID="Label5" runat="server" Text="Bar Code" Visible="false"></asp:Label>
                       <asp:TextBox ID="txtBarCode" runat="server" Width="192px" CssClass="txtBox " Visible="false"></asp:TextBox>
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
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
