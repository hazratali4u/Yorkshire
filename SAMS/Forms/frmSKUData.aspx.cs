using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using System.IO;

/// <summary>
/// From To Add, Edit, Delete SKU
/// </summary>
public partial class Forms_frmSKUData : System.Web.UI.Page
{

    SkuController mController = new SkuController();
    DataControl dc = new DataControl(); 
    SkuHierarchyController mHer_Controller = new SkuHierarchyController();
    
    private  DataTable m_SKUDt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove("skuId");
            ltrlNew.Text = "<a href='frmSKUDataAdd.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2'>Add Product</a>";
         
            LoadData();
            LoadGrid();
        }
    }
        
    private void LoadData()
    {
        SkuController mSKUController = new SkuController();
        m_SKUDt = mSKUController.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["CompanyId"].ToString()));
        Session.Add("m_SKUDt", m_SKUDt);
    }

    private void LoadGrid()
    {
        m_SKUDt = (DataTable)Session["m_SKUDt"];
        if (m_SKUDt != null)
        {
            if (!string.IsNullOrEmpty(txtSeach.Text))
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
                    case 4:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    case 5:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    case 6:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    case 7:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    case 8:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    case 9:
                        m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                        break;
                    default:
                        m_SKUDt.DefaultView.RowFilter = "SKU_NAME" + " like '%" + "" + "%'";
                        break;
                }
                }
            grdSKUData.DataSource = m_SKUDt.DefaultView;
            grdSKUData.DataBind();
        }
    }

    protected void grdSKUData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        Session.Add("skuId" , int.Parse(grdSKUData.Rows[e.NewEditIndex].Cells[1].Text));
        Response.Redirect("frmSKUDataAdd.aspx?LevelID=19&LevelType=3&TopID=2");
    }

    protected void grdSKUData_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
       int m_sku_id = int.Parse(grdSKUData.Rows[e.RowIndex].Cells[1].Text);
       bool result = mController.UpdateSKUS(m_sku_id, int.Parse(Session["CompanyId"].ToString()), null,Constants.IntNullValue,null,null,
          null, null, null, null, null, Constants.IntNullValue,null,null,null, Constants.ShortNullValue, false, Convert.ToInt32(Session["UserID"]),null);
       if (result)
       {
           LoadData();
           LoadGrid();
       }
       else
       {

           ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred!');", true);
       }
   }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }

}