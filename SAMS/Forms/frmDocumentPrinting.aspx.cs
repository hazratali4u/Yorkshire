using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using SAMSBusinessLayer.Reports;  
using CrystalDecisions.CrystalReports.Engine;

/// <summary>
/// Form For Print Sale Document Report
/// </summary>
public partial class Forms_frmDocumentPrinting : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadDistributor();
           
            LoadCustomer();
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
    private void LoadCustomer()
    {
        DrpCustomer.Items.Clear();
        DrpCustomer.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        if (drpDistributor.Items.Count > 0 )
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectAllCustomer(int.Parse(drpDistributor.SelectedValue.ToString()),  Constants.IntNullValue, Constants.IntNullValue);
            clsWebFormUtil.FillDropDownList(DrpCustomer, dt, 0, 3, false);

        }
    }

    /// <summary>
    /// Loads Sale Forces And Routes
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomer();
    }
    
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }
    
    /// <summary>
    /// Gets Print Sale Document And Shows Either in Excel or PDF
    /// </summary>
    /// <param name="p_ReportType">Type</param>
    private void ShowReport(int p_ReportType)
    {
       int customerType=Constants.IntNullValue;
       if (rblCustomerType.SelectedValue != "-1")
       {
           customerType =Convert.ToInt32(rblCustomerType.SelectedValue);
       }

        RptSaleController RptSaleCtl = new RptSaleController();
        DocumentPrintController DPrint = new DocumentPrintController();
        DataSet ds = null;

        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        DataControl dc = new DataControl();
        if (dt.Rows.Count > 0)
        {           
            //  { // mean sale order
            if (DrpLedgerType.SelectedValue == "0")
            {                
                ds = RptSaleCtl.SelectDocument(int.Parse(drpDistributor.SelectedValue.ToString())
                    , DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59")
                    , int.Parse(DrpLedgerType.SelectedValue), Constants.LongNullValue, customerType
                    , Constants.IntNullValue, Convert.ToInt32(DrpCustomer.SelectedValue));
                ReportDocument CrpReport = new ReportDocument();
                if (DrpSort.SelectedValue == "0")
                {
                    CrpReport = new SAMSBusinessLayer.Reports.CrpOrderPrinting();
                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();
                }
                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString().ToUpper());
                CrpReport.SetParameterValue("CompanyAddress", dt.Rows[0]["ADDRESS1"].ToString());
                CrpReport.SetParameterValue("ContactNo", dt.Rows[0]["CONTACT_NUMBER"].ToString());
                Session.Add("CrpReport", CrpReport);
                Session.Add("ReportType", p_ReportType);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
            else if (DrpLedgerType.SelectedValue == "2" || DrpLedgerType.SelectedValue == "3")
            {
                // mean NOn GST invoice
                ds = RptSaleCtl.SelectDocument(int.Parse(drpDistributor.SelectedValue.ToString())
                                   , DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59")
                                   , 2, Constants.LongNullValue, customerType
                                   , Constants.IntNullValue, Convert.ToInt32(DrpCustomer.SelectedValue));
                ReportDocument CrpReport = new ReportDocument();
                if (DrpLedgerType.SelectedValue == "3")
                {
                    CrpReport = new SAMSBusinessLayer.Reports.CrpQuotation();
                }
                else if (DrpLedgerType.SelectedValue == "2")
                {
                    CrpReport = new SAMSBusinessLayer.Reports.CrpOutwardGatePass();
                }

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                if (rbtSortOrder.SelectedIndex == 0)
                {
                    CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder;
                }
                else
                {
                    CrpReport.DataDefinition.SortFields[0].SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder;
                }
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString().ToUpper());
                CrpReport.SetParameterValue("CompanyAddress", dt.Rows[0]["ADDRESS1"].ToString());
                CrpReport.SetParameterValue("ContactNo", dt.Rows[0]["CONTACT_NUMBER"].ToString());

                Session.Add("CrpReport", CrpReport);
                Session.Add("ReportType", p_ReportType);
                const string url = "'Default.aspx'";
                const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
        }
    }

    /// <summary>
    /// Shows Print Sale Document in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }
}