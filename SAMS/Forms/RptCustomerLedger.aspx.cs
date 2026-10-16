using System;
using System.Data;
using System.Web.UI;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// Form For Customer Ledger Report
/// </summary>
public partial class Forms_RptCustomerLedger : System.Web.UI.Page
{
    CustomerDataController CustCtl = new CustomerDataController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDistributor();
           
            LoadData();
            
            SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime = (DateTime)Session["CurrentWorkDate"];
            txtStartDate.Text = SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dt, 0, 2, true);
    }

    /// <summary>
    /// Loads Customers To Customer Combo
    /// </summary>
    private void LoadData()
    {
        if (drpDistributor.Items.Count > 0 )
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectAllCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            clsWebFormUtil.FillDropDownList(DrpCustomer, dt, "CUSTOMER_ID", "customerDetail");           
        }
    }

    /// <summary>
    /// Gets Customer Opening Balance
    /// </summary>
    private decimal  LoadCustomerOpBalance()
    {
        if (drpDistributor.Items.Count > 0 && DrpCustomer.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectPrincipalCustomerOpBalance(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), Constants.IntNullValue);
            return decimal.Parse(dt.Rows[0][0].ToString());
        }
        return 0;
    }

    /// <summary>
    /// Loads Routes And Customers
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        LoadData();
    }

   
    
    /// <summary>
    /// Shows Customer Ledger Either in PDF or in Excel
    /// </summary>
    /// <param name="p_Report_Type">ReportType</param>
    private void ShowReport(int p_Report_Type)
    {
        DataControl dc = new DataControl();
        SAMSBusinessLayer.Classes.DocumentPrintController DPrint = new SAMSBusinessLayer.Classes.DocumentPrintController();
        RptCustomerController RptCustomerCtl = new RptCustomerController();
        DataSet ds;
        ds = RptCustomerCtl.CustomerLedger_View2(Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpCustomer.SelectedValue.ToString()),
                  DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

        SAMSBusinessLayer.Reports.CrpCustomerLedger2 CrpReport = new SAMSBusinessLayer.Reports.CrpCustomerLedger2();

        ReportDocument subReport = CrpReport.OpenSubreport("SubReport");

        CrpReport.SetDataSource(ds);
        subReport.SetDataSource(ds);

        
        CrpReport.Refresh();

        CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
        CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
        CrpReport.SetParameterValue("Location", drpDistributor.SelectedItem.Text);
        
        CrpReport.SetParameterValue("Customer", DrpCustomer.SelectedItem.Text);
        CrpReport.SetParameterValue("Op_Balance", LoadCustomerOpBalance());
        CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
        CrpReport.SetParameterValue("businessDeal", hfBusinessDeal.Value);
        Session.Add("CrpReport", CrpReport);
        Session.Add("ReportType", p_Report_Type);
        
        const string url = "'Default.aspx'";
        const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }

    /// <summary>
    /// Shows Customer Ledger Report in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Customer Ledger Report in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }
}
