using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;

/// <summary>
/// Form To Add, Edit Customer Claim
/// </summary>
public partial class Forms_frmDemangedClaim : System.Web.UI.Page
{
    DataTable ClaimedSKU;
    private static int RowId;
    private static long URowId;

    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDistributor();
            LoadClaimType();
            LoadAccountHead();            
            CreatTableValue();           
            LoadRoute();
            LoadCustomer();
            LoadGrid();
            btnAddNew.Attributes.Add("onclick", "return ValidateValueForm();");
            ScriptManager.GetCurrent(Page).SetFocus(drpDistributor);
            lblRowId.Text = "-1";
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        var dController = new DistributorController();
        var dt = dController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dt, 0, 2, true);
    }
    
    /// <summary>
    /// Loads Claim Types To RadioButtonList
    /// </summary>
    private void LoadClaimType()
    {
        RbdClaimType.Items.Add(new ListItem("Credit Claim", Constants.CreditClaim.ToString()));
        RbdClaimType.Items.Add(new ListItem("Debit Claim", Constants.DebitClaim.ToString()));        
        RbdClaimType.SelectedIndex = 0;         
    }
    
    /// <summary>
    /// Loads Account Heads To AccountHead Combo
    /// Modified by: Hazrat Ali
    /// 2012-Feb-16 10:40 AM
    /// Hard coded Account Heads as per Saddruddin Sb Instructions
    /// This is valid only for FDMPL and invalid for BDN and FDM
    /// Commited old code
    /// </summary>
    private void LoadAccountHead()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId,Constants.LongNullValue);
        clsWebFormUtil.FillDropDownList(DrpAccountHead, dt, 0, 4, true);
        #region Commited Code
        /*
        DrpAccountHead.Items.Clear();
        if (RbdClaimType.SelectedValue == Constants.DebitClaim.ToString())
        {
            DrpAccountHead.Items.Add(new ListItem("SECURITY DEPOSIT BOTTLE", "424"));
        }
        else if (RbdClaimType.SelectedValue == Constants.CreditClaim.ToString())
        {
            DrpAccountHead.Items.Add(new ListItem("Adv. against Empty Bottle", "511"));
            DrpAccountHead.Items.Add(new ListItem("Sales Return", "245"));
            DrpAccountHead.Items.Add(new ListItem("Sale Discount - Claimable", "493"));
        }
         */
       
        /*
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectClaimHead(int.Parse(RbdClaimType.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpAccountHead, dt, 0, 2, true);
         */
      
        #endregion
    }
        
    /// <summary>
    /// Creates Datatable For Customer Claim Data
    /// </summary>
    private void CreatTableValue()
    {
        DataTable dtVoucher = new DataTable();
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
        Session.Add("dtVoucher", dtVoucher);
        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();  

    }
    
    /// <summary>
    /// Loads Routes To Route Combo
    /// </summary>
    private void LoadRoute()
    {
        //DistributorAreaController mController = new DistributorAreaController();
        //DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
        //clsWebFormUtil.FillDropDownList(ddlRoute, dt, 0, 6, true);

        ddlRoute.Items.Clear();
        GeoHierarchyController gController = new GeoHierarchyController();
    
        DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue), Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(Session["CompanyId"].ToString()));

        clsWebFormUtil.FillDropDownList(ddlRoute, dt, "GEO_ID", "GEO_NAME");


        ddlRoute.Enabled = true;     
    }
    
    /// <summary>
    /// Loads Customers To Customer Combo
    /// </summary>
    private void LoadCustomer()
    {
        if (drpDistributor.Items.Count > 0 && ddlRoute.Items.Count > 0)
        {
            var mController = new CustomerDataController();
          

            var dt = mController.SelectAllCustomer(int.Parse(drpDistributor.SelectedValue), Constants.IntNullValue, Convert.ToInt32(ddlRoute.SelectedValue),2);
            clsWebFormUtil.FillDropDownList(DrpCustomer, dt, 0, 3, true);
            Session.Add("dt", dt);
        }
        else
        {
            DrpCustomer.Items.Clear();   
        }
    }
    
    /// <summary>
    /// Loads Customer Claims To Grid
    /// </summary>
    private void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0)
        {
            var lController = new LedgerController();
            var dt = lController.SelectClaimDetail(int.Parse(drpDistributor.SelectedValue),int.Parse(RbdClaimType.SelectedValue),
                DateTime.Parse(Session["CurrentWorkDate"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString()));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
    }
    
    private void ClearGrd_Order()
    {
        txtRemarks.Text = "";
        txtAmount.Text = "";
        btnAddNew.Text = "Save";
        
    }
    /// <summary>
    /// Deletes Customer Claim
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController LController = new LedgerController();
        DataControl dc = new DataControl();

        LController.DeleteWareHouseLedger(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[4].Text)),
        int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[8].Text)),Constants.LongNullValue  , decimal.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[9].Text)),2);

        ClearGrd_Order();
        LoadGrid();
        
    }
    private void EnableDisable(bool flag)
    {
        if (flag == true)
        {
            drpDistributor.Enabled = false;
            ddlRoute.Enabled = false;
            DrpCustomer.Enabled = false;
        }
        else
        {
            drpDistributor.Enabled = true;
            ddlRoute.Enabled = true;
            DrpCustomer.Enabled = true;
        }
    }
    
    /// <summary>
    /// Saves Customer Claim
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        LedgerController LController = new LedgerController();

        if (btnAddNew.Text == "Save")
        {
            string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
            Session.Add("VoucherNo", MaxDocumentId);
            if (RbdClaimType.SelectedValue == Constants.DebitClaim.ToString())
            {
                LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountHead.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
                   DateTime.Parse(Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), 0,
                    null, int.Parse(Session["UserId"].ToString()), Constants.LongNullValue, null, Constants.IntNullValue, null, Constants.DateNullValue, Constants.DebitClaim, "");

                LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(txtAmount.Text),
                   DateTime.Parse(Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), 0,
                    null, int.Parse(Session["UserId"].ToString()), Constants.LongNullValue, null, Constants.IntNullValue, null, Constants.DateNullValue, Constants.DebitClaim, "");
            }
            else
            {
                LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountHead.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(txtAmount.Text),
                    DateTime.Parse(Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), 0,
                     null, int.Parse(Session["UserId"].ToString()), Constants.LongNullValue, null, Constants.IntNullValue, null, Constants.DateNullValue, Constants.CreditClaim, "");

                LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), Convert.ToInt64(Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
                    DateTime.Parse(Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), 0,
                     null, int.Parse(Session["UserId"].ToString()), Constants.LongNullValue, null, Constants.IntNullValue, null, Constants.DateNullValue, Constants.CreditClaim, "");
            }

            InsertGL();            
        }
        Session.Remove("VoucherNo");
        ClearGrd_Order();
        LoadGrid();
    }

    #region Index/Change

    /// <summary>
    /// Loads Account Heads And Claim Data
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void RbdClaimType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrid();      
        if (ddlClaimMode.SelectedIndex == 1)
        {
            LoadDocumentNo();
        }
    }

    protected void ddlClaimMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlClaimMode.SelectedIndex == 0)
        //{
        //    lblDocumentNo.Visible = false;
        //    ddlDocumentNo.Visible = false;
           

        //    txtAmount.Visible = true;
        //    lblAmount.Visible = true;
        //    btnAddNew.Visible = true;
        //    pnlValue.Visible = true;
        //}
        //else
        //{
        //    txtAmount.Visible = false;
        //    lblAmount.Visible = false;
        //    btnAddNew.Visible = false;
        //    pnlValue.Visible = false;

        //    pnlProduct.Visible = true;
        //    lblDocumentNo.Visible = true;
        //    ddlDocumentNo.Visible = true;
        //    LoadDocumentNo();
        //    CreatTable();
        //    LoadPurchaseGrid();
        //}
    }

    protected void ddlDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (long.Parse(ddlDocumentNo.SelectedValue.ToString()) != Constants.LongNullValue)
        {
            DataTable dt = (DataTable)Session["dtDocumentNo"];
            DataRow[] foundRows = dt.Select("CLAIM_MASTER_ID  = '" + ddlDocumentNo.SelectedItem.Text + "'");
            if (foundRows.Length > 0)
            {
                DrpAccountHead.SelectedValue = foundRows[0]["ACCOUNT_HEAD_ID"].ToString();
                txtRemarks.Text = foundRows[0]["REMARKS"].ToString();
               // txtTotalAmount.Text = foundRows[0]["AMOUNT"].ToString();
                LoadClaimDetail();
                ClearAll();
           //     ScriptManager.GetCurrent(Page).SetFocus(txtskuCode);                
            }
        }
        else
        {
            ClearAll();
           
        }
    }

    /// <summary>
    /// Loads Routes And Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRoute();
        LoadCustomer();
        if (ddlClaimMode.SelectedIndex == 1)
        {
            LoadDocumentNo();
        }
    }

    /// <summary>
    /// Loads Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomer();

        if (ddlClaimMode.SelectedIndex == 1)
        {
            LoadDocumentNo();
        }
       
    }

    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClaimMode.SelectedIndex == 1)
        {
            LoadDocumentNo();
        }
       
    }
    #endregion

    #region Load

    /// <summary>
    /// Loads Document Nos
    /// </summary>
    private void LoadDocumentNo()
    {
        if (DrpCustomer.Items.Count > 0)
        {
            LedgerController LedgrCtl = new LedgerController();
            ddlDocumentNo.Items.Clear();
            DataTable dtDocumentNo = LedgrCtl.GetCustomerClaimMaster(Constants.IntNullValue, Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpCustomer.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), RbdClaimType.SelectedIndex);
            ddlDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(ddlDocumentNo, dtDocumentNo, "LEDGER_ID", "CLAIM_MASTER_ID");
            Session.Add("dtDocumentNo", dtDocumentNo);
        }
    }

    private void LoadClaimDetail()
    {
        LedgerController LegrCtl = new LedgerController();
        ClaimedSKU = LegrCtl.GetCustomerClaimDetail(Convert.ToInt32(ddlDocumentNo.SelectedItem.Text));
        Session.Add("ClaimedSKU", ClaimedSKU);
       // LoadPurchaseGrid();
    }

    /// <summary>
    /// Loads SKU Data To SKU ListBox
    /// </summary>
   
    #endregion
   

    /// <summary>
    /// Clears Some Of Controls
    /// </summary>
    private void ClearAll()
    {
      
        txtRemarks.Text = "";
        txtAmount.Text = "";
    }

    private void InsertGL()
    {
        LedgerController LController = new LedgerController();
        DataTable dtVoucher = new DataTable();
        dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
        dtVoucher.Columns.Add("ACCOUNT_HEAD_ID", typeof(long));
        dtVoucher.Columns.Add("DEBIT", typeof(decimal));
        dtVoucher.Columns.Add("CREDIT", typeof(decimal));
        dtVoucher.Columns.Add("REMARKS", typeof(string));
        dtVoucher.Columns.Add("Principal_Id", typeof(string));
        if (RbdClaimType.SelectedValue == Constants.DebitClaim.ToString())
        {
            DataRow dr = dtVoucher.NewRow();
            dr["LEDGER_ID"] = Constants.LongNullValue.ToString();
            dr["ACCOUNT_HEAD_ID"] = Convert.ToInt64(DrpAccountHead.SelectedValue);
            dr["REMARKS"] = txtRemarks.Text;
            dr["DEBIT"] = decimal.Parse(txtAmount.Text);
            dr["CREDIT"] = 0;
            dr["Principal_Id"] = 0;
            dtVoucher.Rows.Add(dr);
            ///Credit Side Entry
            DataRow dr1 = dtVoucher.NewRow();
            dr1["LEDGER_ID"] = Constants.LongNullValue.ToString();
            dr1["ACCOUNT_HEAD_ID"] = 791;//Account Receivable(0402030001)
            dr1["DEBIT"] = 0;
            dr1["CREDIT"] = decimal.Parse(txtAmount.Text);
            dr1["Principal_Id"] = 0;
            dr1["REMARKS"] = txtRemarks.Text;
            dtVoucher.Rows.Add(dr1);
        }
        else
        {
            DataRow dr = dtVoucher.NewRow();
            dr["LEDGER_ID"] = Constants.LongNullValue.ToString();
            dr["ACCOUNT_HEAD_ID"] = Convert.ToInt64(DrpAccountHead.SelectedValue);
            dr["REMARKS"] = txtRemarks.Text;
            dr["DEBIT"] = 0;
            dr["CREDIT"] = decimal.Parse(txtAmount.Text);
            dr["Principal_Id"] = 0;
            dtVoucher.Rows.Add(dr);
            ///Credit Side Entry
            DataRow dr1 = dtVoucher.NewRow();
            dr1["LEDGER_ID"] = Constants.LongNullValue.ToString();
            dr1["ACCOUNT_HEAD_ID"] = 791;//Account Receivable(0402030001)
            dr1["DEBIT"] = decimal.Parse(txtAmount.Text);
            dr1["CREDIT"] = 0;
            dr1["Principal_Id"] = 0;
            dr1["REMARKS"] = txtRemarks.Text;
            dtVoucher.Rows.Add(dr1);
        }

        string MaxDocumentId = "";
        MaxDocumentId = LController.SelectMaxVoucherId(Constants.Journal_Voucher, Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]));
        LController.Add_Voucher(Convert.ToInt32(drpDistributor.SelectedValue), 0, MaxDocumentId, Constants.Journal_Voucher, Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt32(RbdClaimType.SelectedValue), Session["VoucherNo"].ToString(), "Defualt Customer Claim Voucher", Constants.DateNullValue, null, dtVoucher, Convert.ToInt32(Session["UserID"]), null, Constants.DateNullValue);
    }
}