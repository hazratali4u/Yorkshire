using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;

/// <summary>
/// From To Add, Edit Customer
/// </summary>
public partial class Forms_frmDistributorCustomer : System.Web.UI.Page
{
    readonly DataControl dc = new DataControl();
    readonly CustomerDataController mController = new CustomerDataController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("CustomerId");
            Session.Remove("DistributorID");
            ltrlNew.Text = "<a href='frmDistributorCustomerAdd.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2'>Add New Customer</a>";
            btnSearch.Attributes.Add("onclick", "return SearchRecord()");
           
            LoadDistributor();
            LoadCustomer2();
            countCustomer();
            countInActiveCustomer();
        }
    }

    private void countCustomer()
    {
        DataTable dt = mController.UspSelectCustomer(int.Parse(ddlLocation.SelectedValue), "CUSTOMER_NAME", txtSeach.Text, 1);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                lblCount.Text = dt.Rows.Count.ToString();
            }
        }
    }
    private void countInActiveCustomer()
    {
        if (ddlLocation.Items.Count > 0)
        {
            DataTable dt = mController.UspSelectCustomer(int.Parse(ddlLocation.SelectedValue), "CUSTOMER_NAME", txtSeach.Text, 3);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblCountInActive.Text = dt.Rows.Count.ToString();
                }
            }
        }
    }

    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(ddlLocation, dt, 0, 2, true);
    }


    private void LoadCustomer2()
    {
        if (ddlLocation.Items.Count > 0)
        {

            DataTable dt = mController.UspSelectCustomer(int.Parse(ddlLocation.SelectedValue), "CUSTOMER_NAME", txtSeach.Text, 0);
            DataTable sortedDT = null;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sortedDT = clsDataSetUtil.SortData(dt, "CUSTOMER_NAME", "ASC");

                }
            }
            gvCustomer.DataSource = sortedDT;
            gvCustomer.DataBind();
        }
    }
    

    /// <summary>
    /// Sets Customer Data For Edit. This Function Runs When An Existing Customer Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Session.Add("DistributorID", gvCustomer.Rows[e.NewEditIndex].Cells[1].Text);
        Session.Add("CustomerId", gvCustomer.Rows[e.NewEditIndex].Cells[0].Text);
        Response.Redirect("frmDistributorCustomerAdd.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&mode=edit&TopID=2");
    }

    protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CustomerDataController CustData = new CustomerDataController();

        long CustomerID = long.Parse(gvCustomer.Rows[e.RowIndex].Cells[0].Text);
        if (CustData.ActiveInActiveCustomer(CustomerID, Convert.ToInt32(ddlLocation.SelectedValue),false))
        {
            btnSearch_Click(null, null);
        }
        
    }
            
    /// <summary>
    /// Filters Customer From Customer Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CustomerDataController mController = new CustomerDataController();
        DataTable dt = mController.UspSelectCustomer(int.Parse(ddlLocation.SelectedValue), "CUSTOMER_NAME", "", 1);
        DataTable sortedDT=null;
        if (dt.Rows.Count > 0)
        {
            sortedDT = clsDataSetUtil.SortData(dt, "CUSTOMER_NAME", "ASC");

        }
        switch (ddSearchType.SelectedIndex)
        {
            case 1:
                sortedDT.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 2:
                sortedDT.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 3:
                sortedDT.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
           
            default:
                sortedDT.DefaultView.RowFilter = "CUSTOMER_NAME" + " like '%" + "" + "%'";
                break;
        }
        gvCustomer.DataSource = sortedDT.DefaultView;
        gvCustomer.DataBind();

        lblCount.Text = sortedDT.DefaultView.Count.ToString();

        SetTableSorter();
    }

    /// <summary>
    /// Set Customer Grid For JQuery Sorting
    /// </summary>
    private void SetTableSorter()
    {
        if (gvCustomer.Rows.Count > 1)
        {
            gvCustomer.UseAccessibleHeader = true;
            gvCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}