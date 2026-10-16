using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSCommonLayer.Classes;
using SAMSBusinessLayer.Classes;

/// <summary>
/// From To Add, Edit, Delete SKU Hierarchy
/// </summary>
public partial class frmSKUHierarchyData : System.Web.UI.Page
{
    SkuHierarchyController mController = new SkuHierarchyController();
  
    static int CategoryId;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadCategory();
       
            TabContainer1.ActiveTabIndex = 0;
        }
    }

    #region Category Tab

    /// <summary>
    /// Loads Categorys To Category Grid On Category Tab And To All Category Combos On Form
    /// </summary>
    private void LoadCategory()
    {
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUCategory,Constants.IntNullValue,Constants.IntNullValue,null,null,true, int.Parse(this.Session["CompanyId"].ToString()),2);
        GrdCategory.DataSource = dt;
        GrdCategory.DataBind();
    }

    /// <summary>
    /// Sets Category Data For Edit. This Function Runs When An Existing Category Needs To Be Edited
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CategoryId = int.Parse(GrdCategory.Rows[e.NewEditIndex].Cells[0].Text);
        txtCategoryCode.Text = GrdCategory.Rows[e.NewEditIndex].Cells[1].Text;
        txtCategoryName.Text = GrdCategory.Rows[e.NewEditIndex].Cells[2].Text;
        txtCategoryName.Enabled = true;
        btnSaveCategory.Text = "Update";
    }

    /// <summary>
    /// Deletes A Category
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">GridViewEditEventArgs</param>
    protected void GrdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CategoryId = int.Parse(GrdCategory.Rows[e.RowIndex].Cells[0].Text);
        mController.UpdateHierarchy(Constants.SKUCategory, CategoryId, Constants.IntNullValue, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
        this.LoadCategory();
    }
    protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdCategory.PageIndex = e.NewPageIndex;
        this.LoadCategory();
    }

    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        if (btnSaveCategory.Text == "New")
        {
            txtCategoryCode.Text = this.GetAutoCode("CA", 0);
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();
            btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtCategoryName);
        }
        else if (btnSaveCategory.Text == "Save")
        {
            mController.InsertHierarchy(Constants.SKUCategory, Constants.IntNullValue, txtCategoryCode.Text, txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            this.SetAutoCode("CA", long.Parse(txtCategoryCode.Text.Substring(2)));
            btnSaveCategory.Text = "New";
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            this.LoadCategory();

        }
        else if (btnSaveCategory.Text == "Update")
        {
            mController.UpdateHierarchy(Constants.SKUCategory, CategoryId, Constants.IntNullValue, txtCategoryCode.Text, txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            btnSaveCategory.Text = "New";
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            this.LoadCategory();
        }

    }

    #endregion

    private string GetAutoCode(string PreeFix,int CodeType)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        return AutoCode.GetAutoCode(PreeFix, CodeType, Constants.LongNullValue);
    }
    
    private void SetAutoCode(string PreeFix, long CValue)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        string result = AutoCode.GetAutoCode(PreeFix, 1, CValue);
    }
}