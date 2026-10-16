using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using System.Data;
using SAMSCommonLayer.Classes;

public partial class Forms_frmFreightEntry : System.Web.UI.Page
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
            ddlDistributor.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            ddlCustomer.SelectedValue = dt.Rows[0]["CUSTOMER_ID"].ToString();
            lblCustomer.Text = ddlCustomer.SelectedItem.Text;
            //------------------------------------------------------------------------\\
            txtTransporter.Text = Convert.ToString(dt.Rows[0]["driverName"].ToString());
            txtTruckNo.Text = Convert.ToString(dt.Rows[0]["truckNo"].ToString());
            txtBuilty.Text = Convert.ToString(dt.Rows[0]["builtyNo"].ToString());
            txtBuiltyDate.Text = string.Format("{0:dd-MMM-yyyy}", dt.Rows[0]["builtyDate"]);
            txtRemarks.Text = Convert.ToString(dt.Rows[0]["freightRemarks"].ToString());
            txtFreightAmount.Text = string.Format("{0,0:0.00}", dt.Rows[0]["freightAmount"]);
            txtDriverName.Text = dt.Rows[0]["FREIGHT_DRIVER_NAME"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["invoiceId"] != null)
            {
                LoadDistributors();
                LoadCustomers();
                loadInvoice();
            }     
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
               
            }
        }
    }
 
    #endregion
    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        
        var id = Session["invoiceId"].ToString().Split('-');

        if (oeCtrl.Update_Invoice(Convert.ToInt64(id[1]),txtTransporter.Text, txtTruckNo.Text, txtBuilty.Text,DateTime.Parse(Session["CurrentWorkDate"].ToString())
        ,  DateTime.Parse(txtBuiltyDate.Text.ToString())
        , Convert.ToDecimal(_dc.chkNull_0(txtFreightAmount.Text)), int.Parse(this.Session["UserId"].ToString())
        ,txtRemarks.Text,2, txtDriverName.Text))
        {

            //Session.Add("reportId", id[1]);

            Response.Redirect("frmFreightView.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26");
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('some error occurred');", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        Session.Remove("invoiceId");

        Response.Redirect("frmFreightView.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26");
    }   
}