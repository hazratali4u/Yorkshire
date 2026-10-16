using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSCommonLayer.Classes;
using SAMSBusinessLayer.Classes;
using System.Data;
using SAMSBusinessLayer.Reports;

public partial class Forms_frmSaleReturnView : System.Web.UI.Page
{

    readonly OrderEntryController oeCtrl = new OrderEntryController();

    private DataTable m_SKUDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ltrlNew.Text = "<a href='frmSaleReturn.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=26'>Add Sale Return</a>";
            Session.Remove("SaleReturnId");
            
            LoadData();
            LoadGrid();
        }
    }
    private void LoadData()
    {
        DataTable m_SKUDt = oeCtrl.SelectSaleReturn(Constants.LongNullValue,Convert.ToInt32(Session["Distributor_id"].ToString()), 1, int.Parse(Session["UserID"].ToString()), Convert.ToDateTime(Session["CurrentWorkDate"]));
        Session.Add("m_SKUDt", m_SKUDt);
    }
    private void LoadGrid()
    {
        m_SKUDt = (DataTable)Session["m_SKUDt"];
        if (m_SKUDt != null)
        {

            switch (ddSearchType.SelectedIndex)
            {

                case 1:
                    m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 2:
                    m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 3:
                    m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                default:
                    m_SKUDt.DefaultView.RowFilter = "CUSTOMER_NAME" + " like '%" + "" + "%'";
                    break;
            }

            grdSaleOrder.DataSource = m_SKUDt.DefaultView;
            grdSaleOrder.DataBind();
        }
    }
    protected void grdSaleOrder_RowCommand(object sender, GridViewCommandEventArgs e)

    {
        try
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int index = gvr.RowIndex;

            if (e.CommandName == "Edt")
            {

                Session.Add("SaleReturnId", grdSaleOrder.Rows[index].Cells[0].Text);

                Response.Redirect("frmSaleReturn.aspx?LevelID=103&LevelType=3&TopID=26");
            }
            else if (e.CommandName == "Del")
            {
                bool flag = oeCtrl.Update_SaleReturn(Convert.ToInt64(grdSaleOrder.Rows[index].Cells[0].Text), int.Parse(Session["Distributor_Id"].ToString()),
                    true, int.Parse(Session["UserId"].ToString()), 1);

                if (flag)
                {

                    LoadData();

                    LoadGrid();

                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Delete Successfully');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred');", true);
                }

            }
            else
            {
                bool flag = oeCtrl.Update_SaleReturn(Convert.ToInt64(grdSaleOrder.Rows[index].Cells[0].Text), int.Parse(Session["Distributor_Id"].ToString()),
                    false, int.Parse(Session["UserId"].ToString()), 2);

                if (flag)
                {
                    LoadData();
                    LoadGrid();
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Send to Q.A Successfully');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred');", true);
        }

    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        LoadGrid();

    }
}