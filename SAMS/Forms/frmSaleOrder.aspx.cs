using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using System.Data;
using SAMSCommonLayer.Classes;
using SAMSBusinessLayer.Reports;

public partial class Forms_frmSaleOrder : System.Web.UI.Page
{
    readonly DataControl _dc = new DataControl();
    readonly CustomerDataController _customerCtrl = new CustomerDataController();
    readonly OrderEntryController oeCtrl = new OrderEntryController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CreateTable();
            LoadDistributors();
            LoadPendingOrder();
            LoadCustomers();
            
            CustomerLedger();
            LoadSKUDetail();
           
        }
    }

    private void LoadDistributors()
    {
        DistributorController distCtrl = new DistributorController();
        DataTable dt = distCtrl.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                clsWebFormUtil.FillDropDownList(ddlDistributor, dt, 0, 2);
            }
        }
    }
    protected void ddlDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomers();
        CustomerLedger();
        LoadSKUDetail();
        ddlCustomer.Focus();
    }

    private void LoadCustomers()
    {
        if (ddlDistributor.Items.Count > 0)
        {
            DataTable dtCustomer = _customerCtrl.SelectPrincipalCustomer(int.Parse(ddlDistributor.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
            if (dtCustomer.Rows.Count > 0)
            {
                lblCustomerAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                if (lblCustomerAddress.Text == "")
                {
                    lblCustomerAddress.Text = "N/A";
                }
                clsWebFormUtil.FillDropDownList(ddlCustomer, dtCustomer, "CUSTOMER_ID", "CustomerTown");
                Session.Add("dtCustomer", dtCustomer);
            }
        }
    }
    private void CustomerLedger()
    {
        if (ddlCustomer.Items.Count > 0)
        {
            decimal Opening = 0;

            DataTable dt = _customerCtrl.SelectCustomerCreditBalance(long.Parse(ddlCustomer.SelectedValue), Constants.IntNullValue, Convert.ToInt32(ddlDistributor.SelectedValue), Constants.Advance_PaymentOrder_id);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Opening = Opening + decimal.Parse(_dc.chkNull_0(dt.Rows[0][0].ToString()));

                    lblLedgerBalance.Text = string.Format("{0:0,0.00}", Opening);
                }
                else
                {
                    lblLedgerBalance.Text = Convert.ToString(Opening);
                }
            }
            else
            {
                lblLedgerBalance.Text = Convert.ToString(Opening);
            }
                
        }
    }
    
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        CustomerLedger();
        CustomerAddress();
       // LoadSKUDetail();
      
    }
    private void CustomerAddress()
    {
        DataTable dt = (DataTable)Session["dtCustomer"];
        DataRow[] foundRows = dt.Select("CUSTOMER_ID  = '" + ddlCustomer.SelectedValue + "'");

        if (foundRows.Length > 0)
        {
            lblCustomerAddress.Text = foundRows[0]["Address"].ToString();
            if (lblCustomerAddress.Text == "")
            {
                lblCustomerAddress.Text = "N/A";
            }
        }
    }

    #region Detail Panel

    DataTable orderSku = new DataTable();
    private static int RowNo;

    //private void LoadSKUDetail()
    //{
    //    if (ddlCustomer.Items.Count > 0)
    //    {
    //        if (ddlCustomer.SelectedItem.Text.Contains("|"))
    //        {
    //            string[] Customer = ddlCustomer.SelectedItem.Text.Split('|');
    //            if (Customer[1].ToString().Trim() == "Default")
    //            {
    //                SKUPriceDetailController PController = new SKUPriceDetailController();
    //                DataTable Dtsku_Price = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(ddlDistributor.SelectedValue), int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
    //                clsWebFormUtil.FillDropDownList(ddlSKus, Dtsku_Price, "SKU_ID", "SkuDetail2", true);
    //                Session.Add("Dtsku_Price", Dtsku_Price);
    //            }
    //            else
    //            {
    //                SKUPriceDetailController PController = new SKUPriceDetailController();
    //                DataTable Dtsku_Price = PController.GetCustomerSKU(int.Parse(ddlDistributor.SelectedValue), Convert.ToInt32(ddlCustomer.SelectedValue));
    //                clsWebFormUtil.FillDropDownList(ddlSKus, Dtsku_Price, "SKU_ID", "SkuDetail2", true);
    //                Session.Add("Dtsku_Price", Dtsku_Price);
    //            }
    //        }
    //    }
    //}
    private void LoadSKUDetail()
    {
        SkuController SKUCtl = new SkuController();
        DataTable Dtsku_Price = SKUCtl.SelectSkuData(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
        if (Dtsku_Price != null)
        {
            clsWebFormUtil.FillDropDownList(ddlSKus, Dtsku_Price, 0, 3, true);
            Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }
    private void CreateTable()
    {
        orderSku = new DataTable();
        orderSku.Columns.Add("orderDetailId", typeof(long));
        orderSku.Columns.Add("skuId", typeof(int));
        orderSku.Columns.Add("skuName", typeof(string));
        orderSku.Columns.Add("price", typeof(decimal));
        orderSku.Columns.Add("qty", typeof(decimal));
        orderSku.Columns.Add("extraDiscount", typeof(decimal));
        orderSku.Columns.Add("amount", typeof(decimal));
        orderSku.Columns.Add("netAmount", typeof(decimal));
        
        Session.Add("orderSku", orderSku);

    }

    private bool CheckDublicateSKU()
    {

        orderSku = (DataTable)Session["orderSku"];
        DataRow[] foundRows = orderSku.Select("skuId  = '" + ddlSKus.SelectedValue + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }

        return false;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable Dtsku_Price = (DataTable)Session["Dtsku_Price"];
           

            DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + ddlSKus.SelectedValue + "'");

            if (foundRows.Length > 0)
            {
                orderSku = (DataTable)Session["orderSku"];
                if (btnSave.Text == "Add")
                {
                    if (CheckDublicateSKU())
                    {
                        DataRow dr = orderSku.NewRow();
                        dr["skuId"] = foundRows[0]["SKU_ID"];
                        dr["skuName"] = ddlSKus.SelectedItem.Text;
                        dr["qty"] = decimal.Parse(_dc.chkNull_0(txtQuantity.Text));
                        dr["price"] = decimal.Parse(_dc.chkNull_0(txtRate.Text));
                        //dr["extraDiscount"] = decimal.Parse(_dc.chkNull_0(txtDiscount.Text));
                        dr["amount"] = decimal.Parse(_dc.chkNull_0(txtRate.Text)) * decimal.Parse(_dc.chkNull_0(txtQuantity.Text));
                        dr["netAmount"] = decimal.Parse(_dc.chkNull_0(txtAmount.Text));
                        orderSku.Rows.Add(dr);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('  " + ddlSKus.SelectedItem.Text + " Already Exists ');", true);

                        return;
                    }
                }
                else if (btnSave.Text == "Update")
                {

                    DataRow dr = orderSku.Rows[RowNo];
                    dr["skuId"] = foundRows[0]["SKU_ID"];
                    dr["skuName"] = ddlSKus.SelectedItem.Text;
                    dr["qty"] = decimal.Parse(_dc.chkNull_0(txtQuantity.Text));
                    dr["price"] = decimal.Parse(_dc.chkNull_0(txtRate.Text));
                    //dr["extraDiscount"] = decimal.Parse(_dc.chkNull_0(txtDiscount.Text));
                    dr["amount"] = decimal.Parse(_dc.chkNull_0(txtRate.Text)) * decimal.Parse(_dc.chkNull_0(txtQuantity.Text));
                    dr["netAmount"] = decimal.Parse(_dc.chkNull_0(txtAmount.Text));

                }
                Session.Add("orderSku", orderSku);
                ClearDetail();
                LoadGird();

                ScriptManager.GetCurrent(Page).SetFocus(ddlSKus);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Wrong Product Select');", true);

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' Some error occurred');", true);
        }
    }

    protected void grdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;

        ddlSKus.SelectedValue = grdOrder.Rows[RowNo].Cells[0].Text;
        txtQuantity.Text = grdOrder.Rows[RowNo].Cells[2].Text;
        txtRate.Text = grdOrder.Rows[RowNo].Cells[3].Text;
       // txtDiscount.Text = grdOrder.Rows[RowNo].Cells[4].Text;
        txtAmount.Text = grdOrder.Rows[RowNo].Cells[4].Text;
       
        ddlSKus.Enabled = false;
        txtQuantity.Focus();
        btnSave.Text = "Update";

    }
    protected void grdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        orderSku = (DataTable)Session["orderSku"];
        if (orderSku.Rows.Count > 0)
        {
            orderSku.Rows.RemoveAt(e.RowIndex);
            Session.Add("orderSku", orderSku);
            LoadGird();
        }
    }

    private void LoadGird()
    {
        decimal TotalValue = 0;
        decimal TotalAmount = 0;
        orderSku = (DataTable)Session["orderSku"];
        grdOrder.DataSource = orderSku;
        grdOrder.DataBind();
        foreach (DataRow dr in orderSku.Rows)
        {
           TotalValue += decimal.Parse(dr["qty"].ToString());
           TotalAmount += decimal.Parse(dr["netAmount"].ToString());
        }
       txtTotalQty.Text = TotalValue.ToString();
       txtGrossAmount.Text = string.Format("{0:0.00}",  TotalAmount);
       txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount - decimal.Parse(_dc.chkNull_0(txtExtraDiscount.Text)));
       hfTotalAmount.Value = string.Format("{0:0.00}", TotalAmount - decimal.Parse(_dc.chkNull_0(txtExtraDiscount.Text)));
       
    }
    private void ClearDetail()
    {

        txtQuantity.Text = "";
        txtRate.Text = "";
        
        txtAmount.Text = "0";

        ddlSKus.Enabled = true;
        btnSave.Text = "Add";

    }
    #endregion

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        try
        {
            orderSku = (DataTable)Session["orderSku"];
            if (orderSku.Rows.Count > 0)
            {
                if (drpDocumentNo.SelectedValue == Constants.LongNullValue.ToString())
                {
                    long sId = oeCtrl.AddOrder(int.Parse(ddlDistributor.SelectedValue), null,0, long.Parse(ddlCustomer.SelectedValue)
                    , 214,decimal.Parse(_dc.chkNull_0(hfTotalAmount.Value)),0,decimal.Parse(_dc.chkNull_0(txtExtraDiscount.Text)),decimal.Parse(_dc.chkNull_0(txtTotalQty.Text)), Constants.Order_Pending_Id, orderSku, int.Parse(Session["UserId"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString()), txtRemarks.Text);
                    if (sId > 0)
                    {
                        LoadPendingOrder();
                        ClearMasterALL();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' some error occurred');", true);
                    }
                }
                else
                {
                    bool flag = oeCtrl.UpdateOrder(long.Parse(drpDocumentNo.SelectedValue), DateTime.Parse(Session["CurrentWorkDate"].ToString()),
                        0, int.Parse(ddlDistributor.SelectedValue), 214, null,
                        long.Parse(ddlCustomer.SelectedValue), decimal.Parse(_dc.chkNull_0(hfTotalAmount.Value)), 0
                        , decimal.Parse(_dc.chkNull_0(txtExtraDiscount.Text)), decimal.Parse(_dc.chkNull_0(txtTotalQty.Text)), orderSku, int.Parse(Session["UserId"].ToString()), txtRemarks.Text);

                    if (flag)
                    {
                        LoadPendingOrder();
                        ClearMasterALL();
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' some error occurred');", true);
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' At least one Item must enter');", true);

            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' some error occurred');", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
        CreateTable();
        LoadGird();
        ClearDetail();
        txtTotalQty.Text = "";
        txtTotalAmount.Text = "";
        txtExtraDiscount.Text = "";
        
    }
    private void GetOrder(long sId)
    {
        try
        {
            DocumentPrintController DPrint = new DocumentPrintController();
            

            DataTable dt = DPrint.SelectReportTitle(int.Parse(ddlDistributor.SelectedValue));


            DataSet ds = null;

            ds = oeCtrl.SelectOrderforView(sId, 0);

          
            //if (ds.Rows.Count <= 0) return;

            CrpOrderPrinting crpOrder = new CrpOrderPrinting();
            crpOrder.SetDataSource(ds);
            crpOrder.Refresh();

            crpOrder.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString().ToUpper());
            crpOrder.SetParameterValue("CompanyAddress", dt.Rows[0]["ADDRESS1"].ToString());
            crpOrder.SetParameterValue("ContactNo", dt.Rows[0]["CONTACT_NUMBER"].ToString());
            //---------------------------------------------------------------------------------\\

            //---------------------------------------------------------------------------------\\


            //Session.Add("CrpReport", crpOrder);
           // Session.Add("ReportType", 0);

           // const string url = "'Default.aspx'";
           // Response.Write("<script>window.open(" + url + ",'_blank');</script>");
            Session.Add("CrpReport", crpOrder);
            Session.Add("ReportType", 0);
            const string url = "'Default.aspx'";
            const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);  


        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    #region Update Panel

    private void LoadPendingOrder()
    {
        drpDocumentNo.Items.Clear();
        DataTable dtOrder = oeCtrl.SelectPendingOrder2(Convert.ToInt32(ddlDistributor.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.Order_Pending_Id, 0, int.Parse(Session["UserID"].ToString()), Convert.ToDateTime(Session["CurrentWorkDate"]));
        drpDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(drpDocumentNo, dtOrder, 0, 1);
        Session.Add("dtOrder", dtOrder);
    }
    private void ExistenOrderDetail(long OrderId)
    {
        orderSku = oeCtrl.SelectOrderDetail(Convert.ToInt32(ddlDistributor.SelectedValue), OrderId, Constants.DateNullValue, 0);
        Session.Add("orderSku", orderSku);
        LoadGird();
      
    }
    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (long.Parse(drpDocumentNo.SelectedValue.ToString()) != Constants.LongNullValue)
        {
            DataTable dt = (DataTable)Session["dtOrder"];
            DataRow[] foundRows = dt.Select("SALE_ORDER_ID  = '" + drpDocumentNo.SelectedValue + "'");
            if (foundRows.Length > 0)
            {
                ddlCustomer.SelectedValue = foundRows[0]["CUSTOMER_ID"].ToString();

                lblCustomerAddress.Text = foundRows[0]["Address"].ToString();
                txtExtraDiscount.Text = string.Format("{0:0.00}", decimal.Parse(foundRows[0]["discount"].ToString()));

                CustomerLedger();
               // LoadSKUDetail();

                ExistenOrderDetail(long.Parse(drpDocumentNo.SelectedValue.ToString()));
                txtRemarks.Text = foundRows[0]["remarks"].ToString();

                EnableDisableController(false);
            }
            
        }
        else
        {
            CreateTable();
            LoadGird();
            ClearMasterALL();
        }
    }
    private void EnableDisableController(bool CValue)
    {
        if (CValue == true)
        {
            ddlCustomer.Enabled = true;
            ddlDistributor.Enabled = true;
        }
        else
        {
            ddlCustomer.Enabled = false;
            ddlDistributor.Enabled = false;
        }
    }
    private void ClearMasterALL()
    {
        EnableDisableController(true);
        Session.Remove("orderSku");
        CreateTable();

        LoadGird();

        txtRemarks.Text = "";
        txtTotalAmount.Text = "";
        txtExtraDiscount.Text = "";

        RowNo = 0;
        drpDocumentNo.SelectedIndex = 0;
        ScriptManager.GetCurrent(Page).SetFocus(ddlCustomer);
    }

    #endregion
}