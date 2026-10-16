using System;
using System.Data;
using System.Web.UI;
using SAMSBusinessLayer.Classes;
using System.Web.UI.WebControls;
using SAMSCommonLayer.Classes;

public partial class Forms_frmVendorPayment : System.Web.UI.Page
{
    readonly LedgerController ledgerCtl = new LedgerController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtChequeDate.Attributes.Add("readonly", "readonly");
            LoadDistributor();
            LoadPrincipal();
            LoadBalanceGrid();
            LoadBank();
            LoadVendorPayment();
            txtChequeDate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
            hfVId.Value = "";
            hfLId.Value = "";
        }
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBank();
        LoadVendorPayment();
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(ddlLocation, dt, 0, 2, true);
    }

    protected void ddlPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadVendorPayment();
        this.LoadBalanceGrid();
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(ddlPrincipal, m_dt, 0, 1, true);
    }

    private void LoadBalanceGrid()
    {
        LedgerController CDC = new LedgerController();
        gvBalance.DataSource = null;
        gvBalance.DataBind();
        if (ddlPrincipal.Items.Count > 0)
        {
            DataTable dtCredit = CDC.GetSupplierBalance(Convert.ToInt32(ddlPrincipal.SelectedValue));
            gvBalance.DataSource = dtCredit;
            gvBalance.DataBind();
        }
    }

    protected void LoadBank()
    {
        ddlBank.Items.Clear();
        Configuration.GetAccountHead();
        AccountHeadController mAccountController = new AccountHeadController();
        if (ddlPaymentMode.SelectedValue == "19" || ddlPaymentMode.SelectedValue == "21")
        {
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, int.Parse(SAMSCommonLayer.Classes.Configuration.CashDefaultType), 0);
            clsWebFormUtil.FillDropDownList(ddlBank, dt, 0, 4, true);
        }
        else
        {
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(ddlBank, dt, 0, 4);
        }
    }

    protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCheque.Enabled = true;
        txtSlip.Enabled = true;
        ibnEndDate.Enabled = true;
        drpChequeStatus.Enabled = true;
        gvBalance.Enabled = true;
        if (ddlPaymentMode.SelectedValue == "18" || ddlPaymentMode.SelectedValue == "20")
        {
            txtCheque.Enabled = true;
            txtSlip.Enabled = true;
            txtCheque.Text = "";
            txtSlip.Text = "";
            txtNarration.Text = "";
            ibnEndDate.Enabled = true;
            drpChequeStatus.Enabled = true;
        }
        else if (ddlPaymentMode.SelectedValue == "17" || ddlPaymentMode.SelectedValue == "20")
        {
            txtSlip.Enabled = true;
            txtCheque.Enabled = false;
            ibnEndDate.Enabled = false;
            txtCheque.Text = "";
            txtSlip.Text = "";
            txtNarration.Text = "";
            drpChequeStatus.Enabled = false;
        }
        else
        {
            txtCheque.Enabled = false;
            txtSlip.Enabled = false;
            ibnEndDate.Enabled = false;
            txtCheque.Text = "";
            txtSlip.Text = "";
            txtNarration.Text = "";
            drpChequeStatus.Enabled = false;
        }

        if(ddlPaymentMode.SelectedValue == "20" || ddlPaymentMode.SelectedValue == "21" || ddlPaymentMode.SelectedValue == "22")
        {
            gvBalance.Enabled = false;
        }
        LoadBank();
        LoadVendorPayment();
    }

    protected void drpChequeStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (hfVId.Value == "")
        {
            LoadVendorPayment();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController LedgCtl = new CustomerDataController();
        DataControl dc = new DataControl();
        long AccontHeadID = 1184;//Payable to Suppliers(0307010001)
        decimal Amount = Convert.ToDecimal(dc.chkNull_0(txtAmount.Text));
        decimal OfferAmount = decimal.Parse(txtAmount.Text);
        int InvoiceCount = 0;
        if (Amount < 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter amount.');", true);
            return;
        }
        foreach (GridViewRow grv in gvBalance.Rows)
        {
            CheckBox cbBalance = (CheckBox)grv.FindControl("cbBalance");
            if (cbBalance.Checked)
            {
                InvoiceCount++;
                break;
            }
        }

        if ((ddlPaymentMode.SelectedValue == "15" || ddlPaymentMode.SelectedValue == "16" || ddlPaymentMode.SelectedValue == "17"
            || ddlPaymentMode.SelectedValue == "18" || ddlPaymentMode.SelectedValue == "19") && InvoiceCount == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No invoice select.');", true);
            return;
        }

        if (ddlPaymentMode.SelectedValue == "15" || ddlPaymentMode.SelectedValue == "16" || ddlPaymentMode.SelectedValue == "17"
            || ddlPaymentMode.SelectedValue == "18" || ddlPaymentMode.SelectedValue == "19")
        {
            if (ddlBank.Items.Count > 0 && ddlLocation.Items.Count > 0 && ddlPrincipal.Items.Count > 0)
            {
                if (gvBalance.Rows.Count > 0)
                {
                    foreach (GridViewRow grv in gvBalance.Rows)
                    {
                        CheckBox cbBalance = (CheckBox)grv.FindControl("cbBalance");
                        if (cbBalance.Checked)
                        {
                            if (decimal.Parse(grv.Cells[3].Text) >= OfferAmount)
                            {
                                ledgerCtl.InsertVendorLedger(AccontHeadID, Convert.ToInt32(ddlLocation.SelectedValue),
                                OfferAmount, 0, Convert.ToDateTime(Session["CurrentWorkDate"]),
                                txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                                Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Constants.Document_Purchase, Convert.ToInt32(Session["UserID"]),
                                Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)), Convert.ToDateTime(txtChequeDate.Text),
                                txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

                                ledgerCtl.InsertVendorLedger(Convert.ToInt32(ddlBank.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue),
                                0, OfferAmount, Convert.ToDateTime(Session["CurrentWorkDate"]),
                                txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                                Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Constants.Document_Purchase,
                                Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)),
                                Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

                                ledgerCtl.UpdateSupplierBalance(Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Convert.ToInt32(ddlLocation.SelectedValue), OfferAmount, 1);
                                OfferAmount = decimal.Parse(grv.Cells[3].Text) - OfferAmount;
                                break;
                            }
                            else
                            {
                                ledgerCtl.InsertVendorLedger(AccontHeadID, Convert.ToInt32(ddlLocation.SelectedValue),
                                decimal.Parse(grv.Cells[3].Text), 0, Convert.ToDateTime(Session["CurrentWorkDate"]),
                                txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                                Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Constants.Document_Purchase, Convert.ToInt32(Session["UserID"]),
                                Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)), Convert.ToDateTime(txtChequeDate.Text),
                                txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

                                ledgerCtl.InsertVendorLedger(Convert.ToInt32(ddlBank.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue),
                                0, decimal.Parse(grv.Cells[3].Text), Convert.ToDateTime(Session["CurrentWorkDate"]),
                                txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                                Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Constants.Document_Purchase,
                                Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)),
                                Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

                                ledgerCtl.UpdateSupplierBalance(Convert.ToInt64(gvBalance.DataKeys[grv.RowIndex].Values["PROFORMA_INVOICE_ID"]), Convert.ToInt32(ddlLocation.SelectedValue), decimal.Parse(grv.Cells[3].Text), 1);
                                OfferAmount = OfferAmount - decimal.Parse(grv.Cells[3].Text);
                            }
                        }
                    }
                }
                else
                {
                    ledgerCtl.InsertVendorLedger(AccontHeadID, Convert.ToInt32(ddlLocation.SelectedValue),
                                OfferAmount, 0, Convert.ToDateTime(Session["CurrentWorkDate"]),
                                txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                                -1, Constants.IntNullValue, Convert.ToInt32(Session["UserID"]),
                                Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)), Convert.ToDateTime(txtChequeDate.Text),
                                txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

                    ledgerCtl.InsertVendorLedger(Convert.ToInt32(ddlBank.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue),
                    0, OfferAmount, Convert.ToDateTime(Session["CurrentWorkDate"]),
                    txtNarration.Text, Convert.ToInt32(ddlPrincipal.SelectedValue),
                    -1, Constants.IntNullValue, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)),
                    Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('InValid Inputs !');", true);
                return;
            }

            ddlPrincipal_SelectedIndexChanged(null, null);
            ClearForm();
            LoadVendorPayment();
        }
        else
        {
            ledgerCtl.InsertVendorLedger(AccontHeadID, Convert.ToInt32(ddlLocation.SelectedValue), OfferAmount, 0, Convert.ToDateTime(Session["CurrentWorkDate"]),
                                    txtNarration.Text + "(" + ddlPaymentMode.SelectedItem.Text + ")", Convert.ToInt32(ddlPrincipal.SelectedValue), -1, Constants.IntNullValue, Convert.ToInt32(Session["UserID"]),
                                    Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)), Convert.ToDateTime(txtChequeDate.Text),
                                    txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));
            ledgerCtl.InsertVendorLedger(Convert.ToInt32(ddlBank.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), 0, OfferAmount, Convert.ToDateTime(Session["CurrentWorkDate"])
            , txtNarration.Text + "(" + ddlPaymentMode.SelectedItem.Text + ")", Convert.ToInt32(ddlPrincipal.SelectedValue), -1, Constants.IntNullValue, Convert.ToInt32(Session["UserID"])
            , Convert.ToInt32(ddlPaymentMode.SelectedValue), Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtConversionRate.Text)),
            Convert.ToDateTime(txtChequeDate.Text), txtCheque.Text, txtSlip.Text, short.Parse(drpChequeStatus.SelectedValue));

            ddlPrincipal_SelectedIndexChanged(null, null);
            ClearForm();
            LoadVendorPayment();
        }
    }

    private void ClearForm()
    {
        txtCheque.Text = "";
        txtSlip.Text = "";
        txtAmount.Text = "";
        txtDiscount.Text = "";
        txtIncomeTax.Text = "";
        txtNarration.Text = "";
        btnSave.Text = "Save";
        ddlPaymentMode.Enabled = true;
        ddlLocation.Enabled = true;
        ddlPrincipal.Enabled = true;
        hfVId.Value = "";
        hfLId.Value = "";
    }

    /// <summary>
    /// Loads Opening Credits Detail To Grid
    /// </summary>
    private void LoadVendorPayment()
    {
        DataTable dt;
        if (ddlPaymentMode.SelectedValue == "18")
        {
            dt = ledgerCtl.GetVendorPayment(int.Parse(ddlLocation.SelectedValue.ToString()), Convert.ToInt32(ddlPrincipal.SelectedValue), DateTime.Parse(Session["CurrentWorkDate"].ToString()), Convert.ToInt32(ddlPaymentMode.SelectedValue), short.Parse(drpChequeStatus.SelectedValue));

        }
        else
        {
            dt = ledgerCtl.GetVendorPayment(int.Parse(ddlLocation.SelectedValue.ToString()), Convert.ToInt32(ddlPrincipal.SelectedValue), DateTime.Parse(Session["CurrentWorkDate"].ToString()), Convert.ToInt32(ddlPaymentMode.SelectedValue), Constants.ShortNullValue);

        }
        GrdOrder.DataSource = dt;
        GrdOrder.DataBind();
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ledgerCtl.DeleteVendorPayment(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlPrincipal.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt32(ddlPaymentMode.SelectedValue), GrdOrder.Rows[e.RowIndex].Cells[0].Text.Replace("&nbsp;", ""), GrdOrder.Rows[e.RowIndex].Cells[1].Text.Replace("&nbsp;", ""), Convert.ToDateTime(GrdOrder.Rows[e.RowIndex].Cells[2].Text.Replace("&nbsp;", ""))))
        {
            ClearForm();
            ddlPrincipal_SelectedIndexChanged(null, null);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occured. Payment not deleted.');", true);
        }
    }
}