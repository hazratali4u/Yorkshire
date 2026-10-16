using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using System.Web;
using System.IO;

/// <summary>
/// From For Purchase, TranferOut, Purchase Return, TranferIn And Damage
/// </summary>
public partial class Forms_frmProformaInvoiceEntry : System.Web.UI.Page
{
    readonly SKUPriceDetailController PController = new SKUPriceDetailController();
    readonly PurchaseController mPurchase = new PurchaseController();
    DataControl dc = new DataControl();
    DataTable PurchaseSKU;
    DataTable _dtAttach;

    private void LoadAttachment()
    {
        grdAttach.DataSource = null;
        grdAttach.DataBind();
        
        DataTable dtPurchaseAtt = mPurchase.GetPOAttachment(Convert.ToInt64(drpDocumentNo.SelectedValue));

        _dtAttach = (DataTable)Session["dtAttach"];

        if (dtPurchaseAtt.Rows.Count > 0)
        {

            foreach (DataRow drf in dtPurchaseAtt.Rows)
            {
                if (drf["NAME"] != DBNull.Value)
                {

                    DataRow dr2 = _dtAttach.NewRow();

                    dr2["NAME"] = drf["NAME"].ToString();
                    dr2["PATH"] = drf["PATH"].ToString();
                    Byte[] bytes = (byte[])drf["DATA"];// br.ReadBytes((Int32)fs.Length);


                    dr2["DATA"] = bytes;
                    dr2["PURCHASE_ORDER_ID"] = drf["PURCHASE_ORDER_ID"].ToString();
                    _dtAttach.Rows.Add(dr2);
                }
               
            }
           
        }
        grdAttach.DataSource = _dtAttach;
        grdAttach.DataBind();

        Session.Add("dtAttach", _dtAttach);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadDistributor();
            CreatTable();
            CreateAttatchment();
            GetDocumentNo();            

            txtNetAmount.Attributes.Add("readonly", "readonly");
            txtGstValue.Attributes.Add("readonly", "readonly");
            txtAmountFC.Attributes.Add("readonly", "readonly");
            txtTotalQuantity.Attributes.Add("readonly", "readonly");
            txtPIDate.Attributes.Add("readonly", "readonly");
            txtPIDate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
            txtDestinationPort.Text = "KICT Karachi Port";
            txtDeliveryTime.Text = "with in 15 days";
            txtPacking.Text = "Pallet Packing / Loose Packing / Rapped in Polythene sheets";
            txtShippingMark.Text = "STARPEED LIMITED";
            txtShippingTerms.Text = "14 days free detention must be written on Original BL for destination port.";
            txtShipmentMode.Text = "By Sea";
            txtPaymentTerm.Text = "10% TT at the time of orderconfirmation 20% TT before loading balance 70% TT after copy of B/L.";
            // txtCreditTerm.Text = dt.Rows[0]["documentReq"].ToString();
            txtFtaCertif.Text = "FTA CERTIFICATE";
            txtOriginCertif.Text = "Certificate of Origin";
            txtPhyCertificate.Text = "Phytosanitary Certificate";
            txtPackingList.Text = "Packing List";
            txtCommercialInvoice.Text = "Commercial Invoice";
            txtContainerSize.Text = "40feet/ 40HQ";
            txtRemarks1.Text = "No Partial shipment will be allowed";
            txtRemarks2.Text = "Trans-shipment is not allowed";
            txtRemarks3.Text = "Non-negotiate set must be sent by shipper to consignee.";
            txtRemarks4.Text = "Below Appended Stickers should be placed on every sheet";

            chkDestiantion.Checked = true;
            chkDeliveryTime.Checked = true;
            chkPacking.Checked = true;
            chkShipMark.Checked = true;
            chkShipTerms.Checked = true;
            chkShipMode.Checked = true;
            chkPayTerm.Checked = true;
            chkFtaCertif.Checked = true;
            chkOriginCertif.Checked = true;
            chkPhyCertificate.Checked = true;
            chkPackList.Checked = true;
            chkCommInvoice.Checked = true;
            chkConatiner.Checked = true;

            if (Session["ProformaID"] != null)
            {
                if (Session["ProformaID"].ToString() != "")
                {
                    LoadPIDetail();
                    btnSaveDocument.Text = "Update Document";
                }
            }
        }
    }

    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("PURCHASE_ORDER_DETAIL_ID", typeof(long));
        PurchaseSKU.Columns.Add("SKU_ID", typeof(int));

        PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        PurchaseSKU.Columns.Add("Quantity", typeof(decimal));
        PurchaseSKU.Columns.Add("QUANTITY_CTN", typeof(int));
        PurchaseSKU.Columns.Add("PRICE", typeof(decimal));
        PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        Session.Add("PurchaseSKU", PurchaseSKU);

    }
    
    #region Load

    private void GetDocumentNo()
    {
        drpDocumentNo.Items.Clear();

        DataTable dt = mPurchase.SelectPurchaseOrderDocumentNo2(Constants.LongNullValue, int.Parse(drpDistributor.SelectedValue), 0, Convert.ToDateTime(Session["CURRENTWORKDATE"]), 0);
        clsWebFormUtil.FillDropDownList(drpDocumentNo, dt, "PURCHASE_ORDER_ID", "VENDOR_NAME");
        if (Session["ProformaID"] == null)
        {
            drpDocumentNo_SelectedIndexChanged(null, null);
        }
        
    }

    private void LoadPrincipal()
    {
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue,Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(drpPrincipal, m_dt, 0, 1, true);
    }

    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dt, 0, 2, true);
    }

    private void LoadDocumentDetail()
    {

        DataTable dt = mPurchase.SelectPurchaseOrderDocumentNo(Convert.ToInt64(drpDocumentNo.SelectedValue), Convert.ToInt32(drpDistributor.SelectedValue), Constants.IntNullValue, Convert.ToDateTime(Session["CurrentWorkDate"]));
        if (dt.Rows.Count > 0)
        {
            txtRemarks.Text = dt.Rows[0]["REF_NO"].ToString().Replace("&nbsp;", "");
            txtgst.Text = dt.Rows[0]["gst"].ToString();
            txtGstValue.Text = dt.Rows[0]["gstValue"].ToString();
            txtNetAmount.Text = string.Format("{0:0.00}", dt.Rows[0]["netAmount"]);
            txtCreditTerm.Text = dt.Rows[0]["creditTerm"].ToString();
            ddlCurrency.SelectedValue = dt.Rows[0]["CURRENCY_ID"].ToString();
            txtExchangeRate.Text = string.Format("{0:0.00}", dt.Rows[0]["EXCHANGE_RATE"]);
            drpPrincipal.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();


            txtDestinationPort.Text = dt.Rows[0]["destinationPort"].ToString();
            chkDestiantion.Checked = false;
            if (dt.Rows[0]["destinationPort"].ToString() != "")
            {
                chkDestiantion.Checked = true;
            }

            txtDeliveryTime.Text = dt.Rows[0]["delivertyTime"].ToString();
            chkDeliveryTime.Checked = false;
            if (dt.Rows[0]["delivertyTime"].ToString() != "")
            {
                chkDeliveryTime.Checked = true;
            }
            txtPacking.Text = dt.Rows[0]["Packing"].ToString();
            chkPacking.Checked = false;
            if (dt.Rows[0]["Packing"].ToString() != "")
            {
                chkPacking.Checked = true;
            }
            txtShippingMark.Text = dt.Rows[0]["shippingMark"].ToString();
            chkShipMark.Checked = false;
            if (dt.Rows[0]["shippingMark"].ToString() != "")
            {
                chkShipMark.Checked = true;
            }
            txtShippingTerms.Text = dt.Rows[0]["shippingTerms"].ToString();
            chkShipTerms.Checked = false;
            if (dt.Rows[0]["shippingTerms"].ToString() != "")
            {
                chkShipTerms.Checked = true;
            }
            txtShipmentMode.Text = dt.Rows[0]["shipmentMode"].ToString();
            chkShipMode.Checked = false;
            if (dt.Rows[0]["shipmentMode"].ToString() != "")
            {
                chkShipMode.Checked = true;
            }
            txtPaymentTerm.Text = dt.Rows[0]["paymentTerm"].ToString();
            chkPayTerm.Checked = false;
            if (dt.Rows[0]["paymentTerm"].ToString() != "")
            {
                chkPayTerm.Checked = true;
            }

            // txtCreditTerm.Text = dt.Rows[0]["documentReq"].ToString();
            //chkDo.Checked = false;
            if (dt.Rows[0]["documentReq"].ToString() != "")
            {
                //  chkDestiantion.Checked = true;
            }
            txtFtaCertif.Text = dt.Rows[0]["ftaCertificate"].ToString();
            chkFtaCertif.Checked = false;
            if (dt.Rows[0]["ftaCertificate"].ToString() != "")
            {
                chkFtaCertif.Checked = true;
            }

            txtOriginCertif.Text = dt.Rows[0]["originCertificate"].ToString();
            chkOriginCertif.Checked = false;
            if (dt.Rows[0]["originCertificate"].ToString() != "")
            {
                chkOriginCertif.Checked = true;
            }

            txtPhyCertificate.Text = dt.Rows[0]["phyCertificate"].ToString();
            chkPhyCertificate.Checked = false;
            if (dt.Rows[0]["phyCertificate"].ToString() != "")
            {
                chkPhyCertificate.Checked = true;
            }
            txtPackingList.Text = dt.Rows[0]["packingList"].ToString();
            chkPackList.Checked = false;
            if (dt.Rows[0]["packingList"].ToString() != "")
            {
                chkPackList.Checked = true;
            }

            txtCommercialInvoice.Text = dt.Rows[0]["CommInvoice"].ToString();
            chkCommInvoice.Checked = false;
            if (dt.Rows[0]["CommInvoice"].ToString() != "")
            {
                chkCommInvoice.Checked = true;
            }
            txtContainerSize.Text = dt.Rows[0]["containerSize"].ToString();
            chkConatiner.Checked = false;
            if (dt.Rows[0]["containerSize"].ToString() != "")
            {
                chkConatiner.Checked = true;
            }
            txtRemarks1.Text = dt.Rows[0]["remarks1"].ToString();
            chkRemarks1.Checked = false;
            if (dt.Rows[0]["remarks1"].ToString() != "")
            {
                chkRemarks1.Checked = true;
            }
            txtRemarks2.Text = dt.Rows[0]["remarks2"].ToString();
            chkRemarks2.Checked = false;
            if (dt.Rows[0]["remarks2"].ToString() != "")
            {
                chkRemarks2.Checked = true;
            }
            txtRemarks3.Text = dt.Rows[0]["remarks3"].ToString();
            chkRemarks3.Checked = false;
            if (dt.Rows[0]["remarks3"].ToString() != "")
            {
                chkRemarks3.Checked = true;
            }
            txtRemarks4.Text = dt.Rows[0]["remarks4"].ToString();
            chkRemarks4.Checked = false;
            if (dt.Rows[0]["remarks4"].ToString() != "")
            {
                chkRemarks4.Checked = true;
            }
            txtRemarks5.Text = dt.Rows[0]["remarks5"].ToString();
            chkRemarks5.Checked = false;
            if (dt.Rows[0]["remarks5"].ToString() != "")
            {
                chkRemarks5.Checked = true;
            }
            txtRemarks6.Text = dt.Rows[0]["remarks6"].ToString();
            chkRemarks6.Checked = false;
            if (dt.Rows[0]["remarks6"].ToString() != "")
            {
                chkRemarks6.Checked = true;
            }
            txtRemarks7.Text = dt.Rows[0]["remarks7"].ToString();
            chkRemarks7.Checked = false;
            if (dt.Rows[0]["remarks7"].ToString() != "")
            {
                chkRemarks7.Checked = true;
            }
            txtRemarks8.Text = dt.Rows[0]["remarks8"].ToString();
            chkRemarks8.Checked = false;
            if (dt.Rows[0]["remarks8"].ToString() != "")
            {
                chkRemarks8.Checked = true;
            }
            txtRemarks9.Text = dt.Rows[0]["remarks9"].ToString();
            chkRemarks9.Checked = false;
            if (dt.Rows[0]["remarks9"].ToString() != "")
            {
                chkRemarks9.Checked = true;
            }
            txtRemarks10.Text = dt.Rows[0]["remarks10"].ToString();
            chkRemarks10.Checked = false;
            if (dt.Rows[0]["remarks10"].ToString() != "")
            {
                chkRemarks10.Checked = true;
            }

            PurchaseSKU = mPurchase.SelectPurchaseOrderDetail(long.Parse(dt.Rows[0][0].ToString()), Convert.ToInt32(drpDistributor.SelectedValue));
            Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
        }
    }

    private void LoadGird()
    {
        decimal TotalValue = 0;
        decimal TotalAmountFc = 0;
        decimal NetAmount = 0;
        PurchaseSKU = (DataTable)Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
        foreach (DataRow dr in PurchaseSKU.Rows)
        {
            TotalValue += decimal.Parse(dr["Quantity"].ToString());
            TotalAmountFc += Convert.ToDecimal(dr["AMOUNT"]);
            NetAmount += Convert.ToDecimal(dr["AMOUNT"]);
        }

        txtTotalQuantity.Text = TotalValue.ToString();
        txtAmountFC.Text = Math.Round(TotalAmountFc, 2).ToString();
        txtNetAmount.Text = NetAmount.ToString();
    }

    private void LoadPIDetail()
    {
        DataTable dt = mPurchase.GetProformaInvoice(Convert.ToInt64(Session["ProformaID"]),Constants.IntNullValue,1);
        if (dt.Rows.Count > 0)
        {
            txtPINo.Text = dt.Rows[0]["PI_NO"].ToString().Replace("&nbsp;", "");
            if (dt.Rows[0]["PI_DATE"].ToString() != "")
            {
                txtPIDate.Text = Convert.ToDateTime(dt.Rows[0]["PI_DATE"]).ToString("dd-MMM-yyyy");
            }
            txtRemarks.Text = dt.Rows[0]["REF_NO"].ToString().Replace("&nbsp;", "");
            txtgst.Text = dt.Rows[0]["gst"].ToString();
            txtGstValue.Text = dt.Rows[0]["gstValue"].ToString();
            txtNetAmount.Text = string.Format("{0:0.00}", dt.Rows[0]["netAmount"]);
            txtCreditTerm.Text = dt.Rows[0]["creditTerm"].ToString();
            ddlCurrency.SelectedValue = dt.Rows[0]["CURRENCY_ID"].ToString();
            txtExchangeRate.Text = string.Format("{0:0.00}", dt.Rows[0]["EXCHANGE_RATE"]);
            drpPrincipal.SelectedValue = dt.Rows[0]["PRINCIPAL_ID"].ToString();
            txtDestinationPort.Text = dt.Rows[0]["destinationPort"].ToString();
            chkDestiantion.Checked = false;
            if (dt.Rows[0]["destinationPort"].ToString() != "")
            {
                chkDestiantion.Checked = true;
            }
            txtDeliveryTime.Text = dt.Rows[0]["delivertyTime"].ToString();
            chkDeliveryTime.Checked = false;
            if (dt.Rows[0]["delivertyTime"].ToString() != "")
            {
                chkDeliveryTime.Checked = true;
            }
            txtPacking.Text = dt.Rows[0]["Packing"].ToString();
            chkPacking.Checked = false;
            if (dt.Rows[0]["Packing"].ToString() != "")
            {
                chkPacking.Checked = true;
            }
            txtShippingMark.Text = dt.Rows[0]["shippingMark"].ToString();
            chkShipMark.Checked = false;
            if (dt.Rows[0]["shippingMark"].ToString() != "")
            {
                chkShipMark.Checked = true;
            }
            txtShippingTerms.Text = dt.Rows[0]["shippingTerms"].ToString();
            chkShipTerms.Checked = false;
            if (dt.Rows[0]["shippingTerms"].ToString() != "")
            {
                chkShipTerms.Checked = true;
            }
            txtShipmentMode.Text = dt.Rows[0]["shipmentMode"].ToString();
            chkShipMode.Checked = false;
            if (dt.Rows[0]["shipmentMode"].ToString() != "")
            {
                chkShipMode.Checked = true;
            }
            txtPaymentTerm.Text = dt.Rows[0]["paymentTerm"].ToString();
            chkPayTerm.Checked = false;
            if (dt.Rows[0]["paymentTerm"].ToString() != "")
            {
                chkPayTerm.Checked = true;
            }

            if (dt.Rows[0]["documentReq"].ToString() != "")
            {
            
            }
            txtFtaCertif.Text = dt.Rows[0]["ftaCertificate"].ToString();
            chkFtaCertif.Checked = false;
            if (dt.Rows[0]["ftaCertificate"].ToString() != "")
            {
                chkFtaCertif.Checked = true;
            }

            txtOriginCertif.Text = dt.Rows[0]["originCertificate"].ToString();
            chkOriginCertif.Checked = false;
            if (dt.Rows[0]["originCertificate"].ToString() != "")
            {
                chkOriginCertif.Checked = true;
            }

            txtPhyCertificate.Text = dt.Rows[0]["phyCertificate"].ToString();
            chkPhyCertificate.Checked = false;
            if (dt.Rows[0]["phyCertificate"].ToString() != "")
            {
                chkPhyCertificate.Checked = true;
            }
            txtPackingList.Text = dt.Rows[0]["packingList"].ToString();
            chkPackList.Checked = false;
            if (dt.Rows[0]["packingList"].ToString() != "")
            {
                chkPackList.Checked = true;
            }

            txtCommercialInvoice.Text = dt.Rows[0]["CommInvoice"].ToString();
            chkCommInvoice.Checked = false;
            if (dt.Rows[0]["CommInvoice"].ToString() != "")
            {
                chkCommInvoice.Checked = true;
            }
            txtContainerSize.Text = dt.Rows[0]["containerSize"].ToString();
            chkConatiner.Checked = false;
            if (dt.Rows[0]["containerSize"].ToString() != "")
            {
                chkConatiner.Checked = true;
            }
            txtRemarks1.Text = dt.Rows[0]["remarks1"].ToString();
            chkRemarks1.Checked = false;
            if (dt.Rows[0]["remarks1"].ToString() != "")
            {
                chkRemarks1.Checked = true;
            }
            txtRemarks2.Text = dt.Rows[0]["remarks2"].ToString();
            chkRemarks2.Checked = false;
            if (dt.Rows[0]["remarks2"].ToString() != "")
            {
                chkRemarks2.Checked = true;
            }
            txtRemarks3.Text = dt.Rows[0]["remarks3"].ToString();
            chkRemarks3.Checked = false;
            if (dt.Rows[0]["remarks3"].ToString() != "")
            {
                chkRemarks3.Checked = true;
            }
            txtRemarks4.Text = dt.Rows[0]["remarks4"].ToString();
            chkRemarks4.Checked = false;
            if (dt.Rows[0]["remarks4"].ToString() != "")
            {
                chkRemarks4.Checked = true;
            }
            txtRemarks5.Text = dt.Rows[0]["remarks5"].ToString();
            chkRemarks5.Checked = false;
            if (dt.Rows[0]["remarks5"].ToString() != "")
            {
                chkRemarks5.Checked = true;
            }
            txtRemarks6.Text = dt.Rows[0]["remarks6"].ToString();
            chkRemarks6.Checked = false;
            if (dt.Rows[0]["remarks6"].ToString() != "")
            {
                chkRemarks6.Checked = true;
            }
            txtRemarks7.Text = dt.Rows[0]["remarks7"].ToString();
            chkRemarks7.Checked = false;
            if (dt.Rows[0]["remarks7"].ToString() != "")
            {
                chkRemarks7.Checked = true;
            }
            txtRemarks8.Text = dt.Rows[0]["remarks8"].ToString();
            chkRemarks8.Checked = false;
            if (dt.Rows[0]["remarks8"].ToString() != "")
            {
                chkRemarks8.Checked = true;
            }
            txtRemarks9.Text = dt.Rows[0]["remarks9"].ToString();
            chkRemarks9.Checked = false;
            if (dt.Rows[0]["remarks9"].ToString() != "")
            {
                chkRemarks9.Checked = true;
            }
            txtRemarks10.Text = dt.Rows[0]["remarks10"].ToString();
            chkRemarks10.Checked = false;
            if (dt.Rows[0]["remarks10"].ToString() != "")
            {
                chkRemarks10.Checked = true;
            }

            DataTable dtDetail = mPurchase.GetProformaInvoiceDetail(Convert.ToInt64(Session["ProformaID"]));
            GrdPurchase.DataSource = dtDetail;
            GrdPurchase.DataBind();
        }
    }

    #endregion
        
    #region Click OPerations

    protected void btnSaveDocument_Click(object sender, EventArgs e)
    {
        bool flag = false;
        PurchaseController mController = new PurchaseController();
        if (GrdPurchase.Rows.Count > 0)
        {
            if (txtPINo.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Please enter P.I No.');", true);
                return;
            }

            DataTable dtPIDetail = new DataTable();
            dtPIDetail.Columns.Add("SKU_ID", typeof(int));
            dtPIDetail.Columns.Add("QUANTITY", typeof(decimal));
            dtPIDetail.Columns.Add("PRICE", typeof(decimal));
            dtPIDetail.Columns.Add("AMOUNT", typeof(decimal));
            decimal TotalAmount = 0;
            foreach (GridViewRow gvr in GrdPurchase.Rows)
            {
                TextBox txtPIQty = (TextBox)gvr.FindControl("txtPIQty");

                DataRow dr = dtPIDetail.NewRow();
                dr["SKU_ID"] = gvr.Cells[0].Text;
                dr["QUANTITY"] = txtPIQty.Text;
                dr["PRICE"] = gvr.Cells[4].Text;
                dr["AMOUNT"] = gvr.Cells[5].Text;
                TotalAmount += Convert.ToDecimal(dc.chkNull_0(gvr.Cells[5].Text));
                dtPIDetail.Rows.Add(dr);
            }
            if (btnSaveDocument.Text == "Save Document")
            {
                flag = mController.InsertProformaInvoice(Convert.ToInt64(drpDocumentNo.SelectedValue), Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(drpPrincipal.SelectedValue), txtPINo.Text, Convert.ToDateTime(txtPIDate.Text), Convert.ToDateTime(Session["CurrentWorkDate"]), TotalAmount, Convert.ToInt32(Session["UserID"]), dtPIDetail);
            }
            else
            {
                flag = mController.UpdateProformaInvoice(Convert.ToInt64(Session["ProformaID"]), Convert.ToInt64(drpDocumentNo.SelectedValue), Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(drpPrincipal.SelectedValue), txtPINo.Text, Convert.ToDateTime(txtPIDate.Text), TotalAmount, Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt32(Session["UserID"]), dtPIDetail);
            }

            if (flag)
            {
                Response.Redirect("frmProformaInvoiceView.aspx?LevelType=" + Request.QueryString["LevelType"].ToString() + "&LevelID=" + Request.QueryString["LevelID"].ToString() + "&TopID=" + Request.QueryString["TopID"].ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No product selected.');", true);
        }
        
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmProformaInvoiceView.aspx?LevelType=" + Request.QueryString["LevelType"].ToString() + "&LevelID=" + Request.QueryString["LevelID"].ToString() + "&TopID=" + Request.QueryString["TopID"].ToString());
    }

    #endregion

    #region Index/Change

    /// <summary>
    /// Loads Document Detail Data To Document Detail Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
        {
            CreatTable();
            Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
            ClearMaster();
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;

            txtDestinationPort.Text = "KICT Karachi Port";

            txtDeliveryTime.Text = "with in 15 days";
            txtPacking.Text = "Pallet Packing / Loose Packing / Rapped in Polythene sheets";
            txtShippingMark.Text = "STARPEED LIMITED";
            txtShippingTerms.Text = "14 days free detention must be written on Original BL for destination port.";
            txtShipmentMode.Text = "By Sea";
            txtPaymentTerm.Text = "10% TT at the time of orderconfirmation 20% TT before loading balance 70% TT after copy of B/L.";
            // txtCreditTerm.Text = dt.Rows[0]["documentReq"].ToString();
            txtFtaCertif.Text = "FTA CERTIFICATE";
            txtOriginCertif.Text = "Certificate of Origin";
            txtPhyCertificate.Text = "Phytosanitary Certificate";
            txtPackingList.Text = "Packing List";
            txtCommercialInvoice.Text = "Commercial Invoice";
            txtContainerSize.Text = "40feet/ 40HQ";

            txtRemarks1.Text = "No Partial shipment will be allowed";
            txtRemarks2.Text = "Trans-shipment is not allowed";
            txtRemarks3.Text = "Non-negotiate set must be sent by shipper to consignee.";
            txtRemarks4.Text = "Below Appended Stickers should be placed on every sheet";

            chkDestiantion.Checked = true;
            chkDeliveryTime.Checked = true;
            chkPacking.Checked = true;
            chkShipMark.Checked = true;
            chkShipTerms.Checked = true;
            chkShipMode.Checked = true;
            chkPayTerm.Checked = true;
            chkFtaCertif.Checked = true;
            chkOriginCertif.Checked = true;
            chkPhyCertificate.Checked = true;
            chkPackList.Checked = true;
            chkCommInvoice.Checked = true;
            chkConatiner.Checked = true;
            chkRemarks1.Checked = true;
            chkRemarks2.Checked = true;
            chkRemarks3.Checked = true;
            chkRemarks4.Checked = true;
        }
        else
        {
            if (Session["dtAttach"] != null)
            {
                Session.Remove("dtAttach");
            }
            
            drpPrincipal.Enabled = false;            
            LoadDocumentDetail();
            CreateAttatchment();
            LoadAttachment();
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDocumentNo();
    }
    
    protected void GrdPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Text.StringBuilder atrTotal = new System.Text.StringBuilder();
            TextBox txtPOQty = (TextBox)e.Row.FindControl("txtPOQty");
            TextBox txtPIQty = (TextBox)e.Row.FindControl("txtPIQty");

            atrTotal.Append("calcAmount(");
            atrTotal.Append(txtPIQty.ClientID);                        
            atrTotal.Append(",");
            atrTotal.Append(e.Row.Cells[4].Text);
            atrTotal.Append(",");
            atrTotal.Append(e.Row.Cells[5].ClientID + ");");
            txtPOQty.Attributes.Add("onChange", atrTotal.ToString());
            txtPIQty.Attributes.Add("onChange", atrTotal.ToString());            
        }
    }

    #endregion
    
    private void ClearMaster()
    {
        txtExchangeRate.Text = "";
        txtRemarks.Text = "";
        txtNetAmount.Text = "";
        txtCreditTerm.Text = "";
        txtgst.Text = "";
        txtGstValue.Text = "0";

        grdAttach.DataSource = null;
        grdAttach.DataBind();
    }

    #region Attachment
    protected void grdAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        int RowIndex = gvr.RowIndex;
        if (e.CommandName.ToLower() == "download")
        {
            long id = long.Parse(e.CommandArgument.ToString());
            DataTable dtDoc = mPurchase.GetPOAttachment(Convert.ToInt64(drpDocumentNo.SelectedValue));
            if (dtDoc.Rows.Count > 0)
            {
                string FName = dtDoc.Rows[RowIndex]["NAME"].ToString();
                DownLoadFile(Server.MapPath("~/PIIMages/" + FName));
            }         
        }
    }
    private void CreateAttatchment()
    {       
        _dtAttach = new DataTable();
        _dtAttach.Columns.Add("NAME", typeof(string));
        _dtAttach.Columns.Add("PATH", typeof(string));
        _dtAttach.Columns.Add("DATA", typeof(byte[]));
        _dtAttach.Columns.Add("PURCHASE_ORDER_ID", typeof(int));
        Session.Add("dtAttach", _dtAttach);
    }    
    private void DownLoadFile(string path)
    {
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = MimeType(Path.GetExtension(path));
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(path)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(path);
            Response.End();
        }
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    }
    #endregion
}