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
public partial class Forms_frmPurchaseOrderEntry : System.Web.UI.Page
{
    readonly SKUPriceDetailController PController = new SKUPriceDetailController();
    readonly PurchaseController mPurchase = new PurchaseController();
    DataControl dc = new DataControl();
    private static int RowNo;
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
            LoadSKUDetail();
            CreatTable();
            CreateAttatchment();
            GetDocumentNo();
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
            SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime = (DateTime)Session["CurrentWorkDate"];

            txtNetAmount.Attributes.Add("readonly", "readonly");
            txtGstValue.Attributes.Add("readonly", "readonly");
            txtAmountFC.Attributes.Add("readonly", "readonly");
            txtTotalQuantity.Attributes.Add("readonly", "readonly");

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

    #region Check_Duplication



    private bool CheckDublicateSKU()
    {

        PurchaseSKU = (DataTable)Session["PurchaseSKU"];
        DataRow[] foundRows = PurchaseSKU.Select("SKU_ID  = '" + ddlSKuCde.SelectedValue + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }

        return false;

    }
    #endregion

    #region Load
    private void GetDocumentNo()
    {
        drpDocumentNo.Items.Clear();

        DataTable dt = mPurchase.SelectPurchaseOrderDocumentNo2(Constants.LongNullValue, int.Parse(drpDistributor.SelectedValue), 0, Convert.ToDateTime(Session["CURRENTWORKDATE"]), 0);
        drpDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(drpDocumentNo, dt, "PURCHASE_ORDER_ID", "VENDOR_NAME");
    }


    private void LoadPrincipal()
    {
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue,Convert.ToInt32(rdbSupplierType.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
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
        //txtAmountRs.Text = string.Format("{0:0.00}", TotalAmountFc * Convert.ToDecimal(dc.chkNull_0(txtExchangeRate.Text)));
        txtNetAmount.Text = NetAmount.ToString();
    }

    private void LoadSKUDetail()
    {
        SkuController SKUCtl = new SkuController();
        ddlSKuCde.Items.Clear();

        if (drpPrincipal.Items.Count > 0)
        {
            DataTable Dtsku_Price = SKUCtl.SelectSkuData(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(drpPrincipal.SelectedValue));
            if (Dtsku_Price != null)
            {
                clsWebFormUtil.FillDropDownList(ddlSKuCde, Dtsku_Price, 0, 3, true);

                Session.Add("Dtsku_Price", Dtsku_Price);
            }
        }
    }

    #endregion

    #region Grid Operations

    /// <summary>
    /// Sets Dcoment Detail Data For Edit. This Function Runs When An Existing Document Detail Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable Dtsku_Price = (DataTable)Session["Dtsku_Price"];

        RowNo = e.NewEditIndex;
        ddlSKuCde.SelectedValue = GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text;

        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtRate.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtAmount.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;


        txtQuantity.Focus();
        btnSave.Text = "Update";

    }

    /// <summary>
    /// Deletes A Document Detail
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseSKU = (DataTable)Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
            PurchaseSKU.Rows.RemoveAt(e.RowIndex);
            Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
        }
    }

    #endregion

    #region Click OPerations

    //Grid Operation
    protected void btnSave_Click(object sender, EventArgs e)
    {

        DataTable Dtsku_Price = (DataTable)Session["Dtsku_Price"];

        DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + ddlSKuCde.SelectedValue + "'");

        int mPackSize = int.Parse(dc.chkNull_0(foundRows[0]["UNITS_IN_CASE"].ToString()));


        if (foundRows.Length > 0)
        {
            PurchaseSKU = (DataTable)Session["PurchaseSKU"];

            if (btnSave.Text == "Add")
            {
                if (CheckDublicateSKU())
                {

                    DataRow dr = PurchaseSKU.NewRow();
                    dr["SKU_ID"] = foundRows[0]["SKU_ID"];

                    dr["SKU_Name"] = ddlSKuCde.SelectedItem.Text;

                    dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtRate.Text));

                    dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                    dr["QUANTITY_CTN"] = 0;

                    dr["AMOUNT"] = decimal.Parse(txtRate.Text) * Convert.ToInt32(dr["Quantity"]);

                    PurchaseSKU.Rows.Add(dr);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('  " + ddlSKuCde.SelectedItem.Text + " Already Exists ');", true);
                    return;
                }
            }
            else if (btnSave.Text == "Update")
            {
                DataRow dr = PurchaseSKU.Rows[RowNo];
                dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                // dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                dr["SKU_Name"] = ddlSKuCde.SelectedItem.Text;


                dr["PRICE"] = decimal.Parse(dc.chkNull_0(txtRate.Text));

                dr["Quantity"] = decimal.Parse(dc.chkNull_0(txtQuantity.Text));

                dr["AMOUNT"] = decimal.Parse(txtRate.Text) * Convert.ToInt32(dr["Quantity"]);

            }
            Session.Add("PurchaseSKU", PurchaseSKU);
            ClearAll();
            LoadGird();
            DisAbaleOption(true);
            ScriptManager.GetCurrent(Page).SetFocus(ddlSKuCde);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Wrong Product Select');", true);

        }

    }
    protected void btnSaveDocument_Click(object sender, EventArgs e)
    {
        SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime = (DateTime)Session["CurrentWorkDate"];

        PurchaseSKU = (DataTable)Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
            DistributorController mDayClose = new DistributorController();
            if (CalculatePurchase(DateTime.Parse(Session["CurrentWorkDate"].ToString())))
            {
                PurchaseSKU = (DataTable)Session["PurchaseSKU"];
                _dtAttach = (DataTable)Session["dtAttach"];
                
                PurchaseSKU.Rows.Clear();
                _dtAttach.Rows.Clear();


                Session.Add("PurchaseSKU", PurchaseSKU);
                Session.Add("dtAttach", _dtAttach);

                LoadGird();
                GetDocumentNo();

                ClearAll();

                ClearMaster();
                DisAbaleOption(false);

                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Record save successfully');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' At least one SKU must enter');", true);

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DisAbaleOption(false);
        CreatTable();
        LoadGird();
        ClearAll();
        txtRemarks.Text = "";
        txtExchangeRate.Text = "";
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
            ClearAll();
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
            drpDistributor.Enabled = false;

            LoadDocumentDetail();
            LoadSKUDetail();
            CreateAttatchment();
            LoadAttachment();
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAll();
        GetDocumentNo();
    }

    /// <summary>
    /// Loads Document Detail To Document Detail Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    /// 
    protected void rdbSupplierType_SelectedIndexChanged(object sender, EventArgs e)
    {

        ClearAll();
        LoadPrincipal();
        LoadSKUDetail();
    }
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAll();
        LoadSKUDetail();
    }
   

    #endregion


    private bool CalculatePurchase(DateTime CWorkDate)
    {
        bool flag = false;

        decimal mTotalAmount = 0;

        PurchaseController mController = new PurchaseController();
        DataTable dtPurchaseDetail = (DataTable)Session["PurchaseSKU"];
        foreach (DataRow dr in dtPurchaseDetail.Rows)
        {
            mTotalAmount += decimal.Parse(dr["AMOUNT"].ToString());

        }
        if (!chkDestiantion.Checked)
        {
            txtDestinationPort.Text = "";
        }
        if (!chkDeliveryTime.Checked)
        {
            txtDeliveryTime.Text = "";
        }

        if (!chkPacking.Checked)
        {
            txtPacking.Text = "";
        }
        if (!chkShipMark.Checked)
        {
            txtShippingMark.Text = "";
        }
        if (!chkShipTerms.Checked)
        {
            txtShippingTerms.Text = "";
        }
        if (!chkShipMode.Checked)
        {
            txtShipmentMode.Text = "";
        }
        if (!chkPayTerm.Checked)
        {
            txtPaymentTerm.Text = "";
        }
        if (!chkFtaCertif.Checked)
        {
            txtFtaCertif.Text = "";
        }
        if (!chkOriginCertif.Checked)
        {
            txtOriginCertif.Text = "";
        }
        if (!chkPhyCertificate.Checked)
        {
            txtPhyCertificate.Text = "";
        }
        if (!chkPackList.Checked)
        {
            txtPackingList.Text = "";
        }
        if (!chkCommInvoice.Checked)
        {
            txtCommercialInvoice.Text = "";
        }
        if (!chkConatiner.Checked)
        {
            txtContainerSize.Text = "";
        }
        if (!chkRemarks1.Checked)
        {
            txtRemarks1.Text = "";
        }
        if (!chkRemarks2.Checked)
        {
            txtRemarks2.Text = "";
        }
        if (!chkRemarks3.Checked)
        {
            txtRemarks3.Text = "";
        }
        if (!chkRemarks4.Checked)
        {
            txtRemarks4.Text = "";
        }
        if (!chkRemarks5.Checked)
        {
            txtRemarks5.Text = "";
        }
        if (!chkRemarks6.Checked)
        {
            txtRemarks6.Text = "";
        }
        if (!chkRemarks7.Checked)
        {
            txtRemarks7.Text = "";
        }
        if (!chkRemarks8.Checked)
        {
            txtRemarks8.Text = "";
        }
        if (!chkRemarks9.Checked)
        {
            txtRemarks9.Text = "";
        }
        if (!chkRemarks10.Checked)
        {
            txtRemarks10.Text = "";
        }
        _dtAttach = (DataTable)Session["dtAttach"];
        if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
        {


            flag = mController.InsertPurchaseOrder(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), txtRemarks.Text, 0
            , Convert.ToInt32(ddlCurrency.SelectedValue), Convert.ToDecimal(dc.chkNull_0(txtExchangeRate.Text)), CWorkDate, mTotalAmount, int.Parse(Session["UserId"].ToString()), dtPurchaseDetail
            , txtCreditTerm.Text, decimal.Parse(dc.chkNull_0(txtNetAmount.Text)), decimal.Parse(dc.chkNull_0(txtgst.Text)), decimal.Parse(dc.chkNull_0(txtGstValue.Text))
            , txtDestinationPort.Text, txtDeliveryTime.Text, txtPacking.Text, txtShippingMark.Text, txtShippingTerms.Text, txtShipmentMode.Text
            , txtPaymentTerm.Text, null, txtFtaCertif.Text, txtOriginCertif.Text, txtPhyCertificate.Text, txtPackingList.Text, txtCommercialInvoice.Text
            , txtContainerSize.Text, txtRemarks1.Text, txtRemarks2.Text, txtRemarks3.Text, txtRemarks4.Text
            , txtRemarks5.Text, txtRemarks6.Text, txtRemarks7.Text, txtRemarks8.Text, txtRemarks9.Text, txtRemarks10.Text, _dtAttach);

        }

        else
        {
            flag = mController.UpdatePurchaseOrderDetail(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtRemarks.Text, Convert.ToInt32(ddlCurrency.SelectedValue)
            , mTotalAmount, Convert.ToDecimal(dc.chkNull_0(txtExchangeRate.Text)), int.Parse(Session["UserId"].ToString()), dtPurchaseDetail
            , txtCreditTerm.Text, decimal.Parse(dc.chkNull_0(txtNetAmount.Text)), decimal.Parse(dc.chkNull_0(txtgst.Text)), decimal.Parse(dc.chkNull_0(txtGstValue.Text))
            , txtDestinationPort.Text, txtDeliveryTime.Text, txtPacking.Text, txtShippingMark.Text, txtShippingTerms.Text, txtShipmentMode.Text
            , txtPaymentTerm.Text, null, txtFtaCertif.Text, txtOriginCertif.Text, txtPhyCertificate.Text, txtPackingList.Text, txtCommercialInvoice.Text
            , txtContainerSize.Text, txtRemarks1.Text, txtRemarks2.Text, txtRemarks3.Text, txtRemarks4.Text
            , txtRemarks5.Text, txtRemarks6.Text, txtRemarks7.Text, txtRemarks8.Text, txtRemarks9.Text, txtRemarks10.Text, _dtAttach);

        }
        return flag;
    }

    private void DisAbaleOption(bool IsDisable)
    {
        if (IsDisable == true)
        {
            drpPrincipal.Enabled = false;
            drpDistributor.Enabled = false;
            drpDocumentNo.Enabled = false;
            txtRemarks.Enabled = false;
            ddlCurrency.Enabled = false;
            txtExchangeRate.Enabled = false;
        }
        else
        {
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;
            drpDocumentNo.Enabled = true;
            drpDocumentNo.SelectedIndex = 0;
            txtRemarks.Enabled = true;
            ddlCurrency.Enabled = true;
            txtExchangeRate.Enabled = true;
        }
    }

    private void ClearAll()
    {

        txtQuantity.Text = "";
        txtRate.Text = "";
        txtAmount.Text = "0.00";

        btnSave.Text = "Add";
    }

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
    protected void grdAttach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Button lnkViewDoc = e.Row.FindControl("lnkViewDoc") as Button;
            Button lnkViewDoc2 = e.Row.FindControl("btn_delete") as Button;

            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkViewDoc);
        }
    }
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
                string FName = dtDoc.Rows[RowIndex]["FILE_NAME"].ToString();
                DownLoadFile(Server.MapPath("~/Docs/" + FName));
            }
            else
            {

            }
        }
        else
        {
            _dtAttach = (DataTable)Session["dtAttach"];


            _dtAttach.Rows[RowIndex].Delete();

            grdAttach.DataSource = _dtAttach;
            grdAttach.DataBind();
            _dtAttach.AcceptChanges();

            Session.Add("dtAttach", _dtAttach);
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
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;

        _dtAttach = (DataTable)Session["dtAttach"];
        HttpFileCollection uploadedFiles = Request.Files;
        if (FupVendor.HasFile)
        {
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                DataRow dr = _dtAttach.NewRow();
                HttpPostedFile userPostedFile = uploadedFiles[i];
                if (userPostedFile.ContentLength > 0)
                {
                    Stream fs = FupVendor.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    string fileName = Path.GetFileName(userPostedFile.FileName);
                    var file = Path.Combine(Server.MapPath("~/POImages/"), fileName);
                    userPostedFile.SaveAs(file);
                    dr["NAME"] = fileName;
                    dr["PATH"] = Server.MapPath("~/POImages/" + fileName);
                    dr["DATA"] = bytes;

                    _dtAttach.Rows.Add(dr);
                }

            }
            //ltrlDoc.Text = Utility.ShowAlert(true, "Document has been uploaded successfully.");
            grdAttach.DataSource = _dtAttach;
            grdAttach.DataBind();
            Session.Add("dtAttach", _dtAttach);
        }
        else
        {
            //ltrlDoc.Text = Utility.ShowAlert(false, "Please browse some document.");
        }

    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        _dtAttach = (DataTable)Session["dtAttach"];
        //Get the button that raised the event
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int r = gvr.RowIndex;
        //Get rowindex

        //Delete row
        _dtAttach.Rows[r].Delete();

        grdAttach.DataSource = _dtAttach;
        grdAttach.DataBind();

        _dtAttach.AcceptChanges();
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