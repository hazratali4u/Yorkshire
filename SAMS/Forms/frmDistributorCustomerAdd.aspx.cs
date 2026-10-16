using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using System.IO;

/// <summary>
/// From to Add, Edit, Delete Geo Heirarical Data
/// </summary>
public partial class Forms_frmDistributorCustomerAdd : System.Web.UI.Page
{    
    CustomerDataController CustCtl = new CustomerDataController();
    DataControl dc = new DataControl();

    /// <summary>
    /// Page_Load Function Populates All Combos and Grids On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDistributor();
            LoadDesignation();
            txtRegdate.Text = DateTime.Parse(Session["CurrentWorkDate"].ToString()).ToString("dd-MMM-yyyy");
            if (Request.QueryString["mode"] != null)
            {                
                LoadBasicInformation();
                LoadOpeningInformation();
                TabPanel8.Visible = true;
            }
            btnSave.Attributes.Add("onclick", "return ValidateBasicInformation()");
        }
    }

   
    #region Basic Information

    protected void LoadBasicInformation()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            DataTable dtCustomer = CustCtl.GetCustomerByID(Convert.ToInt32(Session["DistributorID"]), Convert.ToInt64(Session["CustomerId"]),1);
            if (dtCustomer.Rows.Count > 0)
            {
                txtCustomerName.Text = dtCustomer.Rows[0]["CUSTOMER_NAME"].ToString();
                txtGstNo.Text = dtCustomer.Rows[0]["GST_NUMBER"].ToString();
                txtNTN  .Text = dtCustomer.Rows[0]["NTN"].ToString();
                txtTaxRate.Text = dtCustomer.Rows[0]["TAX_RATE"].ToString();

                txtAddress.Text = dtCustomer.Rows[0]["ADDRESS"].ToString();
                txtEmailAddress.Text = dtCustomer.Rows[0]["EMAIL_ADDRESS"].ToString();
                txtFAX.Text = dtCustomer.Rows[0]["FAX_NO"].ToString();
                txtMobileNo.Text = dtCustomer.Rows[0]["mobileno"].ToString();
                txtUrl.Text = dtCustomer.Rows[0]["url"].ToString();

                txtPhoneNo.Text = dtCustomer.Rows[0]["CONTACT_NO"].ToString();
                txtContactPerson.Text = dtCustomer.Rows[0]["CONTACT_PERSON"].ToString();
                DrpDistributor.SelectedValue = dtCustomer.Rows[0]["DISTRIBUTOR_ID"].ToString();

                DrpDesignation.SelectedValue = dtCustomer.Rows[0]["designationId"].ToString();
                txtRegdate.Text = DateTime.Parse(dtCustomer.Rows[0]["REG_DATE"].ToString()).ToString("dd-MMM-yyyy");
              
                chkIsActive.Checked = Convert.ToBoolean(dtCustomer.Rows[0]["IS_ACTIVE"]);



               // lblCustomerInfo.Text = txtCustomerName.Text + " - " + ddlTown.SelectedItem.Text;

                btnSave.Text = "Update";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime dtime2 = Constants.DateNullValue;


        if (txtRegdate.Text != "")
        {
            dtime2 = Convert.ToDateTime(txtRegdate.Text);
        }

        CustomerDataController mController = new CustomerDataController();
        if (btnSave.Text == "Save")
        {

            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("CUSTOMER", "CUSTOMER_ID", int.Parse(DrpDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                long CustomerId = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                string StrCode = "";

                if (CustomerId.ToString().Length == 1)
                {
                    StrCode = "0000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 2)
                {
                    StrCode = "000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 3)
                {
                    StrCode = "00" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 4)
                {
                    StrCode = "0" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 5)
                {
                    StrCode = "" + CustomerId.ToString();
                }

                if(mController.InsertCustomer(CustomerId,false, chkIsActive.Checked, int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpDesignation.SelectedValue)
                    , txtGstNo.Text, txtContactPerson.Text, txtPhoneNo.Text, txtEmailAddress.Text, StrCode, txtCustomerName.Text, txtAddress.Text, dtime2
                       , decimal.Parse(dc.chkNull_0(txtTaxRate.Text)), txtFAX.Text, txtNTN.Text, txtMobileNo.Text, txtUrl.Text))
                {
                    Session.Add("CustomerId", CustomerId);
                    Session.Add("DistributorID", DrpDistributor.SelectedValue);
                    Response.Redirect("frmDistributorCustomer.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&mode=edit&TopID=2");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred.');", true);
                }
            }
        }
        else
            {
            if (mController.UpdateCustomer(Convert.ToInt64(Session["CustomerId"]), false, chkIsActive.Checked, int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpDesignation.SelectedValue)
                    , txtGstNo.Text, txtContactPerson.Text , txtPhoneNo.Text, txtEmailAddress.Text, decimal.Parse(dc.chkNull_0(txtTaxRate.Text)),null, txtCustomerName.Text, txtAddress.Text, dtime2
                    , txtFAX.Text, txtNTN.Text,txtMobileNo.Text, txtUrl.Text))
            {
                Response.Redirect("frmDistributorCustomer.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&mode=edit&TopID=2");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred.');", true);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["mode"] != null)
        {
            Response.Redirect("frmDistributorCustomerAdd.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&mode=edit&TopID=2");
        }
        else
        {
            Response.Redirect("frmDistributorCustomerAdd.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2");
        }
    }

    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);
    }
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Employee_Designation_Id, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpDesignation, dt, 0, 2, true);
    }

    #endregion
 
    #region Opening Balance

    private void LoadOpeningInformation()
    {
        DataTable dtOpening = CustCtl.GetCustomerOpening(Constants.LongNullValue, Convert.ToInt32(Session["DistributorID"]), Convert.ToInt64(Session["CustomerId"]), Constants.IntNullValue);
        if (dtOpening.Rows.Count > 0)
        {
            Session.Add("OpeningID", dtOpening.Rows[0]["CUSTOMER_OPENING_ID"]);
            if (dtOpening.Rows[0]["OPENING_DATE"].ToString() != "")
            {
                txtOpeningDate.Text = Convert.ToDateTime(dtOpening.Rows[0]["OPENING_DATE"]).ToString("dd-MMM-yyyy");
            }
            txtOpeningBalance.Text = dtOpening.Rows[0]["BALANCE"].ToString();
            txtOpeningBalanceRemarks.Text = dtOpening.Rows[0]["REMARKS"].ToString();
            rblOpening.SelectedValue = dtOpening.Rows[0]["TYPE_ID"].ToString();
            btnSaveOpeningBalance.Text = "Update";
        }
    }

    protected void btnOpeningBalance_Click(object sender, EventArgs e)
    {
        try
        {
            DataControl dc = new DataControl();
            DateTime dtOpening = Constants.DateNullValue;
            LedgerController LedgerCtl = new LedgerController();

            if (txtOpeningDate.Text.Length > 0)
            {
                dtOpening = Convert.ToDateTime(txtOpeningDate.Text);
            }
            if (btnSaveOpeningBalance.Text == "Save")
            {
                //if (rblOpening.SelectedValue == "1")
                //  {

                //  }
                if (rblOpening.SelectedValue == "1")
                {
                    LedgerCtl.OpeningCredit(Convert.ToInt32(Session["DistributorID"]), "opng", 0, 0,
                    DateTime.Parse(txtOpeningDate.Text), 0, Convert.ToInt64(Session["CustomerId"]), 0,
                    -1, 0, decimal.Parse(txtOpeningBalance.Text), int.Parse(this.Session["UserId"].ToString()), 25, txtOpeningBalanceRemarks.Text);

                }
                else
                {
                    LedgerCtl.OpeningCredit(Convert.ToInt32(Session["DistributorID"]), "opng", 0, 0,
                                     DateTime.Parse(txtOpeningDate.Text), 0, Convert.ToInt64(Session["CustomerId"]), 0,
                                     -1, 1, decimal.Parse(txtOpeningBalance.Text), int.Parse(this.Session["UserId"].ToString()), 25, txtOpeningBalanceRemarks.Text);

                }
                if (CustCtl.InsertCustomerOpening(Convert.ToInt64(Session["CustomerId"]), Convert.ToInt32(Session["DistributorID"]), Convert.ToInt32(rblOpening.SelectedValue), dtOpening, Convert.ToDecimal(dc.chkNull_0(txtOpeningBalance.Text)), txtOpeningBalanceRemarks.Text))
                {
                    btnSaveOpeningBalance.Text = "Update";
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Opening Added Successfully.');", true);

                }
            }
            else
            {

                // CustomerDataController cdc = new CustomerDataController();
                DataTable dt = CustCtl.SelectOpeningCredit(Convert.ToInt32(Session["DistributorID"]), Convert.ToInt64(Session["CustomerId"]), Constants.DateNullValue);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        LedgerCtl.DeleteOpeningCredit(Convert.ToInt32(Session["DistributorID"]), Constants.IntNullValue, 25, Constants.DateNullValue, Convert.ToInt64(Session["CustomerId"]), Convert.ToInt64(dt.Rows[0]["SALE_INVOICE_MASTER_ID"]), Convert.ToInt32(this.Session["UserId"]));
                    }
                }
                if (rblOpening.SelectedValue == "1")
                {
                    LedgerCtl.OpeningCredit(Convert.ToInt32(Session["DistributorID"]), "opng", 0, 0,
                    dtOpening, 0, Convert.ToInt64(Session["CustomerId"]), 0,
               -1, 0, decimal.Parse(txtOpeningBalance.Text), int.Parse(this.Session["UserId"].ToString()), 25, txtOpeningBalanceRemarks.Text);

                }
                else
                {
                    LedgerCtl.OpeningCredit(Convert.ToInt32(Session["DistributorID"]), "opng", 0, 0,
                                     DateTime.Parse(txtOpeningDate.Text), 0, Convert.ToInt64(Session["CustomerId"]), 0,
                                     -1, 1, decimal.Parse(txtOpeningBalance.Text), int.Parse(this.Session["UserId"].ToString()), 25, txtOpeningBalanceRemarks.Text);

                }
                if (CustCtl.UpdateCustomerOpening(Convert.ToInt64(Session["OpeningID"]), Convert.ToInt64(Session["CustomerId"]), Convert.ToInt32(Session["DistributorID"]), Convert.ToInt32(rblOpening.SelectedValue), dtOpening, Convert.ToDecimal(dc.chkNull_0(txtOpeningBalance.Text)), txtOpeningBalanceRemarks.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Opening Updated Successfully.');", true);
                }


            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert(' Some error occurred.');", true);
        }
    }    

    #endregion


}