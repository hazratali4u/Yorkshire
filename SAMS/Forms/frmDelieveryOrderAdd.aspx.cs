using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using System.Data;
using SAMSCommonLayer.Classes;

public partial class Forms_frmDelieveryOrderAdd : System.Web.UI.Page
{
    readonly DataControl _dc = new DataControl();
    readonly CustomerDataController _customerCtrl = new CustomerDataController();
    OrderEntryController oeCtrl = new OrderEntryController();
    private void loadInvoice()
    {
        var id = Session["invoiceId"].ToString().Split('-');
        lblDONo.Text = "DO No: " + id[1];
        lblOrderNo.Text = "Order No: " + id[0];
        DataTable dt = oeCtrl.SelectPendingOrder2(Convert.ToInt64(id[1]), 2);
        if (dt.Rows.Count > 0)
        {
            hfOrderQty.Value = dt.Rows[0]["orderQty"].ToString();
            ddlDistributor.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            ddlCustomer.SelectedValue = dt.Rows[0]["CUSTOMER_ID"].ToString();
            CustomerLedger();
            lblCustomer.Text = ddlCustomer.SelectedItem.Text;
            //------------------------------------------------------------------------\\



            txtDiscount.Text = string.Format("{0:0.00}", dt.Rows[0]["discount"]);
            // txtStandardDiscount.Text = string.Format("{0:0.00}", dt.Rows[0]["standardDiscount"]);
            txtRemarks.Text = Convert.ToString(_dc.chkNull_0(dt.Rows[0]["remarks"].ToString()));
            hfGst.Value = dt.Rows[0]["GstPage"].ToString();

            orderSku = oeCtrl.SelectOrderDetail(Convert.ToInt32(ddlDistributor.SelectedValue), long.Parse(id[1]), long.Parse(id[0]), DateTime.Parse(Session["CurrentWorkDate"].ToString()), 2);
        }
    }
    private void loadOrder()
    {
        lblOrderNo.Text = "Order No: " + Session["orderId"].ToString();

        DataTable dt = oeCtrl.SelectPendingOrder2(Convert.ToInt64(Session["orderId"]), 1);
        if (dt.Rows.Count > 0)
        {
            hfOrderQty.Value = dt.Rows[0]["orderQty"].ToString();
            ddlDistributor.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            ddlCustomer.SelectedValue = dt.Rows[0]["CUSTOMER_ID"].ToString();
            txtDiscount.Text = string.Format("{0:0.00}", dt.Rows[0]["discount"]);
            // txtStandardDiscount.Text = string.Format("{0:0.00}", dt.Rows[0]["standardDiscount"]);
            hfGst.Value = dt.Rows[0]["TAX_RATE"].ToString();


            CustomerLedger();

            //------------------------------------------------------------------\\
            txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
            lblCustomer.Text = ddlCustomer.SelectedItem.Text;
            orderSku = oeCtrl.SelectOrderDetail(Convert.ToInt32(ddlDistributor.SelectedValue), long.Parse(Session["orderId"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString()), 0);


        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            LoadDistributors();
            LoadCustomers();

            if (Session["invoiceId"] != null)
            {
                loadInvoice();
                Session.Add("orderSku", orderSku);
            }
            if (Session["orderId"] != null)
            {
                loadOrder();
                Session.Add("orderSku", orderSku);

            }
            // LoadChequeInformation();

            EnableDisableController(false);

            LoadGird();
        }
    }

    #region Load

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

    private bool CreditLimit()
    {
        //if (!chkLimit.Checked)
        //{
        //    decimal ledgerBal = decimal.Parse(_dc.chkNull_0(lblLedgerBalance.Text));
        //    decimal SaleLimit = decimal.Parse(_dc.chkNull_0(lblSaleLimit.Text));
        //    if (decimal.Parse(_dc.chkNull_0(txtTotalAmount.Text)) > ledgerBal + SaleLimit)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        return true;
    }
    /*
    private void LoadChequeInformation()
    {
        //Security Cheque Amount = Security Chq's + Rec Chq's + Deposit Chq's - LedgerBalance

        ChequeEntryController CController = new ChequeEntryController();
        decimal chqReceived = 0; decimal chqDeposit = 0;



        //Rec Chq's
        DataSet dsReceived = CController.SelectCheques(527, DateTime.Parse(Session["CurrentWorkDate"].ToString()), int.Parse(ddlDistributor.SelectedValue), int.Parse(ddlCustomer.SelectedValue), Constants.IntNullValue);
        DataTable dtReceived = dsReceived.Tables[2];
        if (dtReceived.Rows.Count > 0)
        {
            chqReceived = Convert.ToDecimal(dtReceived.Rows[0][0].ToString());
        }

        //Deposit Chq's
        DataSet dsDeposit = CController.SelectCheques(528, DateTime.Parse(Session["CurrentWorkDate"].ToString()), int.Parse(ddlDistributor.SelectedValue), int.Parse(ddlCustomer.SelectedValue), Constants.IntNullValue);
        DataTable dtDeposit = dsDeposit.Tables[2];
        if (dtDeposit.Rows.Count > 0)
        {
            chqDeposit = Convert.ToDecimal(dtDeposit.Rows[0][0].ToString());
        }


        string fmt2 = "#,##0.00;(#,##0.00)";
        decimal totalAmount = 0;

        if (decimal.Parse(_dc.chkNull_0(lblLedgerBalance.Text)) < 0)
        {
            totalAmount = (chqReceived + chqDeposit) + Convert.ToDecimal(_dc.chkNull_0(lblLedgerBalance.Text));
            lblChequeAmount.Text = totalAmount.ToString(fmt2);
        }
        else
        {
            totalAmount = (chqReceived + chqDeposit) - Convert.ToDecimal(_dc.chkNull_0(lblLedgerBalance.Text));
            lblChequeAmount.Text = totalAmount.ToString(fmt2);
        }

    }
  */
    #endregion

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

    #region Detail Panel

    DataTable orderSku = new DataTable();

    private void LoadGird()
    {
        decimal TotalValue = 0;
        decimal TotalAmount = 0;
        decimal TotalSale = 0;
        orderSku = (DataTable)Session["orderSku"];

        grdOrder.DataSource = orderSku;
        grdOrder.DataBind();

        if (Session["invoiceId"] == null)
        {
            foreach (DataRow dr in orderSku.Rows)
            {
                TotalValue += decimal.Parse(dr["qty"].ToString());
                TotalAmount += decimal.Parse(dr["netAmount"].ToString());
                TotalSale += decimal.Parse(dr["RcdQty"].ToString());
            }
            txtTotalQty.Text = TotalValue.ToString();
            txtGross.Text = string.Format("{0:0.00}", TotalAmount);
            txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount - decimal.Parse(txtDiscount.Text.ToString()));

            if (TotalSale == TotalValue)
            {
                //Session.Remove("orderId");
                btnSaveOrder.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Could not Dispatch against that Order.');", true);
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                //  "alert('Could not Dispatch against that Order.'); window.location='" +
                //    Request.ApplicationPath + "/Forms/frmSaleOrderView.aspx?LevelType=3&TopID=26&LevelID=97';", true);
                return;
            }
        }
        else
        {
            int i = 0;
            foreach (GridViewRow gvr in grdOrder.Rows)
            {
                TextBox txtCurrentRecQty = gvr.FindControl("txtCurrentRecQty") as TextBox;
                if (txtCurrentRecQty.Text.Length > 0)
                {
                    TotalSale += decimal.Parse(txtCurrentRecQty.Text);
                    TotalAmount += decimal.Parse(orderSku.Rows[i]["amount"].ToString());

                }
                i += 1;
            }
            txtTotalQty.Text = TotalSale.ToString();
            txtGross.Text = string.Format("{0:0.00}", TotalAmount);
            txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount - decimal.Parse(txtDiscount.Text.ToString()));
        }
    }

    protected void grdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // orderSku = (DataTable)Session["orderSku"];
        if (e.Row.RowIndex == 0)
        {
            //Set the focus to control on the edited row
            e.Row.FindControl("txtCurrentRecQty").Focus();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtCurrentRecQty = (TextBox)e.Row.FindControl("txtCurrentRecQty");

        }

    }
    private bool CheckStock(decimal Qty, int SkuId, string SkuName)
    {
        PurchaseController mController = new PurchaseController();
        DataTable dtstock = mController.SelectSKUClosingStock(int.Parse(ddlDistributor.SelectedValue), SkuId);
        if (dtstock.Rows.Count > 0)
        {
            if (ViewState["PrevRcdQty"] != null)
            {
                if (decimal.Parse(dtstock.Rows[0][0].ToString()) + decimal.Parse(ViewState["PrevRcdQty"].ToString()) < Qty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('" + SkuName + " Current Stock is " + dtstock.Rows[0][0].ToString() + "');", true);
                    return false;
                }
            }
            else
            {
                if (decimal.Parse(dtstock.Rows[0][0].ToString()) < Qty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('" + SkuName + " Current Stock is " + dtstock.Rows[0][0].ToString() + "');", true);
                    return false;
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('" + SkuName + " No Stock Found');", true);
            return false;
        }
        return true;
    }
    protected void txtCurrentRecQty_TextChanged(object sender, EventArgs e)
    {

        TextBox txtCurrentRecQty = sender as TextBox;

        if (txtCurrentRecQty == null) return;
        GridViewRow item = (GridViewRow)txtCurrentRecQty.NamingContainer;

        decimal recieveQty = 0;


        if (!string.IsNullOrEmpty(txtCurrentRecQty.Text))
        {                                   //prev rec qty
            recieveQty = decimal.Parse(item.Cells[7].Text) + decimal.Parse(_dc.chkNull_0(txtCurrentRecQty.Text));

        }

        DataTable order = (DataTable)Session["orderSku"];
        if (recieveQty > 0)
        {
            decimal orderQty = decimal.Parse(order.Rows[item.RowIndex]["qty"].ToString());
            if (Session["invoiceId"] != null)
            {
                ViewState["PrevRcdQty"] = Convert.ToDecimal(_dc.chkNull_0(order.Rows[item.RowIndex]["CurrentRcdQty"].ToString()));
            }
            if (CheckStock(decimal.Parse(_dc.chkNull_0(txtCurrentRecQty.Text)), int.Parse(order.Rows[item.RowIndex]["skuId"].ToString()), Convert.ToString(order.Rows[item.RowIndex]["skuName"])))
            {
                ViewState.Remove("PrevRcdQty");

                if (recieveQty > orderQty)
                {
                    txtCurrentRecQty.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Dispatch Qty should not be greater than Order Qty!');", true);

                }
                else
                {
                    order.Rows[item.RowIndex]["CurrentRcdQty"] = Convert.ToString(decimal.Parse(_dc.chkNull_0(txtCurrentRecQty.Text)));

                    int TotalQty = 0;
                    decimal TotalAmount = 0;
                    foreach (DataRow dr in order.Rows)
                    {
                        TotalQty += int.Parse(dr["CurrentRcdQty"].ToString());
                        TotalAmount += decimal.Parse(dr["CurrentRcdQty"].ToString()) * decimal.Parse(dr["price"].ToString());
                    }
                    txtTotalQty.Text = TotalQty.ToString();
                    txtGross.Text = string.Format("{0,0:0.00}", TotalAmount);
                    txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount - decimal.Parse(txtDiscount.Text.ToString()));

                    if (item.RowIndex + 1 < grdOrder.Rows.Count)
                    {
                        grdOrder.Rows[item.RowIndex + 1].Cells[4].Focus();
                    }
                    else if (item.RowIndex + 1 == grdOrder.Rows.Count)
                    {
                        grdOrder.Rows[item.RowIndex].Cells[4].Focus();
                    }
                    else
                    {
                        txtDiscount.Focus();
                    }
                }
                Session.Add("orderSku", order);
            }
            else
            {
                txtCurrentRecQty.Focus();
            }
        }

    }
    
    #endregion
    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        bool flag = true;
        DataTable orderSkus = new DataTable();
        orderSkus.Columns.Add("orderDetailId", typeof(long));
        orderSkus.Columns.Add("skuId", typeof(int));
        orderSkus.Columns.Add("skuName", typeof(string));
        orderSkus.Columns.Add("price", typeof(decimal));
        orderSkus.Columns.Add("qty", typeof(decimal));
        orderSkus.Columns.Add("Rcdqty", typeof(decimal));
        orderSkus.Columns.Add("amount", typeof(decimal));
        orderSkus.Columns.Add("netAmount", typeof(decimal));
        decimal orderQty = 0;
        decimal recieveQty = 0;
        int i = 0;
        foreach (GridViewRow gvr in grdOrder.Rows)
        {
            TextBox txtRecQty = gvr.FindControl("txtRecQty") as TextBox;
            TextBox txtCurrentRecQty = gvr.FindControl("txtCurrentRecQty") as TextBox;
            if (txtCurrentRecQty.Text.Length > 0)
            {
                orderSku = (DataTable)Session["orderSku"];
                orderQty = decimal.Parse(orderSku.Rows[i]["qty"].ToString());
                recieveQty = Convert.ToDecimal(txtRecQty.Text) + Convert.ToDecimal(_dc.chkNull_0(txtCurrentRecQty.Text));
                if (Session["invoiceId"] != null)
                {
                    ViewState["PrevRcdQty"] = Convert.ToDecimal(_dc.chkNull_0(orderSku.Rows[i]["CurrentRcdQty"].ToString()));
                }
                if (CheckStock(decimal.Parse(_dc.chkNull_0(txtCurrentRecQty.Text)), int.Parse(orderSku.Rows[i]["skuId"].ToString()), Convert.ToString(orderSku.Rows[i]["skuName"])))
                {
                    ViewState.Remove("PrevRcdQty");

                    if (recieveQty > orderQty)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Dispatch Qty should not be greater than Order Qty.');", true);
                        return;
                    }
                    i += 1;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
        }
        if (flag)//if All Item's stock is OKK
        {
            //orderSku = (DataTable)Session["orderSku"];
            foreach (GridViewRow gvr in grdOrder.Rows)
            {
                TextBox txtRecQty = gvr.FindControl("txtRecQty") as TextBox;
                TextBox txtCurrentRecQty = gvr.FindControl("txtCurrentRecQty") as TextBox;
                DataRow dr = orderSkus.NewRow();
                dr["skuId"] = Convert.ToInt32(_dc.chkNull_0(gvr.Cells[0].Text));
                dr["price"] = Convert.ToDecimal(_dc.chkNull_0(gvr.Cells[5].Text));
                dr["qty"] = Convert.ToDecimal(_dc.chkNull_0(gvr.Cells[2].Text));
                dr["Rcdqty"] = Convert.ToDecimal(_dc.chkNull_0(txtCurrentRecQty.Text));
                dr["amount"] = Convert.ToDecimal(_dc.chkNull_0(gvr.Cells[5].Text)) * Convert.ToDecimal(_dc.chkNull_0(txtCurrentRecQty.Text));
                dr["netAmount"] = Convert.ToDecimal(_dc.chkNull_0(gvr.Cells[9].Text));
                orderSkus.Rows.Add(dr);
            }
            if (orderSkus.Rows.Count > 0)
            {
                if (CreditLimit())
                {
                    long IsValidInsert = -1;

                    decimal mTotalAmount = decimal.Parse(txtTotalAmount.Text.ToString());
                    decimal mTotalQty = decimal.Parse(txtTotalQty.Text.ToString());
                    decimal ExtraDiscount = Convert.ToDecimal(_dc.chkNull_0(txtDiscount.Text));
                    decimal gstAmount = CalculateGst(mTotalAmount - ExtraDiscount, Convert.ToDecimal(_dc.chkNull_0(hfGst.Value)));

                    decimal creditAmount = 0;
                    if (ExtraDiscount < mTotalAmount)
                    {
                        creditAmount = mTotalAmount - ExtraDiscount + gstAmount;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Extra Discount should be less than Total Amount');", true);
                    }
                    if (Session["orderId"] != null)
                    {
                        IsValidInsert = oeCtrl.Add_Invoice(int.Parse(ddlDistributor.SelectedValue), decimal.Parse(hfOrderQty.Value), long.Parse(ddlCustomer.SelectedValue)
                            , long.Parse(Session["orderId"].ToString()), mTotalAmount,
                            0, Convert.ToDecimal(_dc.chkNull_0(txtDiscount.Text))
                            , gstAmount, creditAmount, orderSkus
                        , int.Parse(this.Session["UserId"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString())
                        , 0, txtRemarks.Text, decimal.Parse(_dc.chkNull_0(hfGst.Value)));
                        if (IsValidInsert > 0)
                        {
                            Response.Redirect("frmSaleOrderView.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
                        }
                    }
                    else
                    {
                        var id = Session["invoiceId"].ToString().Split('-');

                        if (oeCtrl.Update_Invoice(Convert.ToInt64(id[1]), DateTime.Parse(Session["CurrentWorkDate"].ToString())
                        , int.Parse(ddlDistributor.SelectedValue), "0", long.Parse(ddlCustomer.SelectedValue), 0,
                        mTotalAmount, 0, Convert.ToDecimal(_dc.chkNull_0(txtDiscount.Text)), gstAmount, creditAmount
                        , 0, 0, orderSkus, int.Parse(this.Session["UserId"].ToString())
                        , 0, 0, 0, 0, txtRemarks.Text, decimal.Parse(_dc.chkNull_0(hfGst.Value)), 1))
                        {
                            DataTable dt = oeCtrl.SelectDispatchQty(Convert.ToInt64(id[0]), 3);
                            if (dt.Rows.Count > 0)
                            {
                                decimal dispatchQty = Convert.ToDecimal(dt.Rows[0]["dispatchQty"].ToString());
                                if (decimal.Parse(hfOrderQty.Value) == dispatchQty)
                                {
                                    if (!oeCtrl.UpdateOrder(Convert.ToInt64(id[0]), int.Parse(ddlDistributor.SelectedValue), 1))
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
                                    }
                                }
                                else
                                {
                                    if (!oeCtrl.UpdateOrder(Convert.ToInt64(id[0]), int.Parse(ddlDistributor.SelectedValue), 0))
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
                                    }
                                }
                            }
                            Response.Redirect("frmSaleOrderView.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Check Customer Business Limit');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Select At least one Product');", true);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session.Remove("orderId");
        Session.Remove("invoiceId");

        Response.Redirect("frmSaleOrderView.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26");
    }
    private decimal CalculateGst(decimal mTotalAmount, decimal gst)
    {
        decimal gstAmount = mTotalAmount * (gst / 100);
        return gstAmount;
    }
}