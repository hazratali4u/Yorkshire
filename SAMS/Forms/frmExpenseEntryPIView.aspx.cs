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
public partial class Forms_frmExpenseEntryPIView : System.Web.UI.Page
{
    PurchaseController PurCtl = new PurchaseController();
    PIController PI = new PIController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("PIExpID");
            ltrlNewPI.Text = "<a href='frmExpenseEntryPI.aspx?LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=" + Request.QueryString["TopID"].ToString() + "&LevelID=" + Request.QueryString["LevelID"].ToString() + "'>Add New PI Expense</a> ";
            FillRepeater();
        }
    }

    private void FillRepeater()
    {
        rptPIExpense.DataSource = null;
        rptPIExpense.DataBind();
        lblTotalNoOfRecords.Text = "";
        lblCurrentPageNo.Text = "";
        lblTotalNoOfPages.Text = "";
        PagedDataSource PagedResults = new PagedDataSource();
        PagedResults.AllowPaging = true;
        PagedResults.PageSize = 20;

        DataTable dt = new DataTable();
        dt = PI.GetPIExpenseView(Constants.IntNullValue, 20, CurrentPage);

        if (dt.Rows.Count > 0)
        {
            PagedResults.CurrentPageIndex = CurrentPage;

            rptPIExpense.DataSource = dt;
            rptPIExpense.DataBind();

            linkbtnnext.Visible = true;
            linkbtnprev.Visible = true;
            lblTotalNoOfPages.Visible = true;
            lblCurrentPageNo.Visible = true;
            lblTotalNoOfRecords.Visible = true;
            lblDummy.Visible = true;
            lblOf.Visible = true;
            lblTotalNoOfRecords.Text = dt.Rows[0]["TotalRows"].ToString();
            lblCurrentPageNo.Text = (CurrentPage + 1).ToString();
            lblTotalNoOfPages.Text = Convert.ToString(Math.Ceiling(Convert.ToDecimal(dt.Rows[0]["TotalRows"]) / Convert.ToDecimal(50)));

            if (lblCurrentPageNo.Text == lblTotalNoOfPages.Text)
            {
                linkbtnnext.Enabled = false;
            }
            else
            {
                linkbtnnext.Enabled = true;
            }
            if (lblCurrentPageNo.Text == "1")
            {
                linkbtnprev.Enabled = false;
            }
            else
            {
                linkbtnprev.Enabled = true;
            }

        }
        else if (dt.Rows.Count == 0)
        {
            linkbtnnext.Visible = false;
            linkbtnprev.Visible = false;
            lblTotalNoOfPages.Visible = false;
            lblCurrentPageNo.Visible = false;
            lblTotalNoOfRecords.Visible = false;
            lblOf.Visible = false;
            lblDummy.Visible = false;
            lblTotalNoOfRecords.Text = "";
        }
    }

    public int CurrentPage
    {
        get
        {
            object objview = this.ViewState["_CurrentPage"];
            if (objview == null)
                return 0;
            else
                return (int)objview;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }

    protected void linkbtnprev_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        FillRepeater();
    }

    protected void linkbtnnext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        FillRepeater();
    }

    protected void rptPIExpense_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            this.Session.Add("PIExpID", Convert.ToInt64(e.CommandArgument));
            Response.Redirect("frmExpenseEntryPI.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopId=" + Request.QueryString["TopID"].ToString());
        }
        else if (e.CommandName == "del")
        {            
            if (PI.UpdatePIExpense2(Convert.ToInt64(e.CommandArgument), Convert.ToInt32(Session["UserID"]), true))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('PI deleted successfully.');", true);
                FillRepeater();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
    }
}