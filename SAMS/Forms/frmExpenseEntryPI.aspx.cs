using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;

/// <summary>
/// Form To Add, Edit Branch Expense And Salary
/// </summary>
public partial class frmExpenseEntryPI : System.Web.UI.Page
{
    PIController PI = new PIController();
    DataControl dc = new DataControl();

    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CreateTable();
            this.LoadDistributor();            
            this.LoadAccountHead();
            if (Session["PIExpID"] != null)
            {
                if (Session["PIExpID"].ToString() != "")
                {
                    this.LoadPINo(2);
                    LoadPIDetail();
                    btnSave.Text = "Update";
                }
            }
            else
            {
                this.LoadPINo(5);
            }
            this.GetPISKU();
        }
    }

    private void CreateTable()
    {
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("ACCOUNT_HEAD_ID", typeof(int));
        dtDetail.Columns.Add("SKU_ID", typeof(int));
        dtDetail.Columns.Add("SKU_NAME", typeof(string));
        dtDetail.Columns.Add("ACCOUNT_NAME", typeof(string));
        dtDetail.Columns.Add("AMOUNT", typeof(decimal));
        Session.Add("dtDetail", dtDetail);
    }

    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(ddlLocation, dt, 0, 2, true);
    }

    private void LoadPINo(int intType)
    {
        ddlPINo.Items.Clear();
        PurchaseController mPurchase = new PurchaseController();
        DataTable dt = mPurchase.GetProformaInvoice(Constants.LongNullValue, Convert.ToInt32(ddlLocation.SelectedValue), intType);
        ddlPINo.Items.Add(new ListItem("--------Select--------", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(ddlPINo, dt, "PROFORMA_INVOICE_ID", "VENDOR_NAME", false);
    }

    private void GetPISKU()
    {
        ddlSKU.Items.Clear();
        PurchaseController mPurchase = new PurchaseController();
        DataTable dt = mPurchase.GetProformaInvoice(Convert.ToInt64(ddlPINo.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), 4);
        ddlSKU.Items.Add(new ListItem("--------Select--------", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(ddlSKU, dt, "SKU_ID", "SKU_NAME", false);
    }

    private void LoadAccountHead()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dt = mAccountController.GetAssignAccountHead(Constants.IntNullValue, Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(ddlAccountHead, dt, 0, 4);
    }
    
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPINo(5);
    }

    protected void ddlPINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetPISKU();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlSKU.SelectedValue != Constants.IntNullValue.ToString())
        {
            if (Convert.ToDecimal(dc.chkNull_0(txtAmount.Text)) > 0)
            {
                DataTable dtDetail = (DataTable)Session["dtDetail"];
                if (CheckDublicateAccountHead(dtDetail))
                {
                    DataRow dr = dtDetail.NewRow();
                    dr["ACCOUNT_NAME"] = ddlAccountHead.SelectedItem.Text;
                    dr["SKU_NAME"] = ddlSKU.SelectedItem.Text;
                    dr["SKU_ID"] = Convert.ToInt32(ddlSKU.SelectedValue);
                    dr["ACCOUNT_HEAD_ID"] = Convert.ToInt32(ddlAccountHead.SelectedValue);
                    dr["AMOUNT"] = Convert.ToDecimal(dc.chkNull_0(txtAmount.Text));
                    dtDetail.Rows.Add(dr);
                    Session.Add("dtDetail", dtDetail);
                    gvExpense.DataSource = dtDetail;
                    gvExpense.DataBind();

                    txtAmount.Text = string.Empty;

                    ScriptManager.GetCurrent(Page).SetFocus(ddlAccountHead);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('This Expense Head already exist.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Amount must be greater than 0');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No SKU selected.');", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool flag = false;
        if (ddlPINo.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select PI#');", true);
            return;
        }
        else
        {
            DataTable dtDetail = (DataTable)Session["dtDetail"];
            decimal TotalAmount = 0;
            foreach (DataRow dr in dtDetail.Rows)
            {
                TotalAmount += Convert.ToDecimal(dr["AMOUNT"]);
            }
            if (btnSave.Text == "Save")
            {
                flag = PI.InsertPIExpense(Convert.ToInt64(ddlPINo.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), TotalAmount, txtRemarks.Text, Convert.ToInt32(Session["UserID"]), dtDetail);
            }
            else
            {
                flag = PI.UpdatePIExpense(Convert.ToInt64(Session["PIExpID"]),Convert.ToInt64(ddlPINo.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), TotalAmount, txtRemarks.Text, Convert.ToInt32(Session["UserID"]), dtDetail);
            }
            
            if (flag)
            {
                Response.Redirect("frmExpenseEntryPIView.aspx?LevelType=" + Request.QueryString["LevelType"].ToString() + "&LevelID=" + Request.QueryString["LevelID"].ToString() + "&TopID=" + Request.QueryString["TopID"].ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
    }

    private bool CheckDublicateAccountHead(DataTable dtDetail)
    {

        DataRow[] foundRows = dtDetail.Select("ACCOUNT_HEAD_ID = '" + ddlAccountHead.SelectedValue + "' AND SKU_ID = '" + ddlSKU.SelectedValue + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        return false;
    }

    protected void gvExpense_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtDetail = (DataTable)Session["dtDetail"];
        if (dtDetail.Rows.Count > 0)
        {
            dtDetail.Rows.RemoveAt(e.RowIndex);
            Session.Add("dtDetail", dtDetail);
            gvExpense.DataSource = dtDetail;
            gvExpense.DataBind();
        }
    }

    private void LoadPIDetail()
    {
        DataTable dt = PI.GetPIExpense(Convert.ToInt64(Session["PIExpID"]), Constants.IntNullValue, 1);
        if (dt.Rows.Count > 0)
        {
            ddlLocation.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            ddlPINo.SelectedValue = dt.Rows[0]["PI_ID"].ToString();
            txtRemarks.Text = dt.Rows[0]["REMARKS"].ToString();
            DataTable dtDetail = PI.GetPIExpense(Convert.ToInt64(Session["PIExpID"]), Constants.IntNullValue, 2);
            Session.Add("dtDetail", dtDetail);
            gvExpense.DataSource = dtDetail;
            gvExpense.DataBind();
        }
    }
}