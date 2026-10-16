using System;
using System.Data;
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
    private  DataTable m_dt,m_SKUDt;
    private static int m_sku_id;

    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Populate_drpSKUCompany();
            Populate_drpSKUDivisions();
            Populate_drpSKUCategory();
            Populate_drpSKUBrand();
            LoadData();
            LoadGrid();
        }
    }

    /// <summary>
    /// Loads Principal To Principal Combo
    /// </summary>
    private void Populate_drpSKUCompany()
    {
        m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUPrincipal, Constants.IntNullValue, Constants.IntNullValue, null, null, true, int.Parse(this.Session["CompanyId"].ToString()),2);
        clsWebFormUtil.FillDropDownList(this.ddlModel, m_dt, 0, 3, true);
    }

    /// <summary>
    /// Loads Divisions To Division Combo
    /// </summary>
    private void Populate_drpSKUDivisions()
    {
        if (ddlModel.Items.Count > 0)
        {
            if (ddlModel.Items.Count > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(ddlModel.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()), 2);
                clsWebFormUtil.FillDropDownList(this.ddlType, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddlType.Items.Clear();   
        }
    }
        
    /// <summary>
    /// Loads Categories To Category Combo
    /// </summary>
    private void Populate_drpSKUCategory()
    {
        if (ddlType.Items.Count > 0)
        {
            if (ddlType.Items.Count   > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(ddlType.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()), 2);
                clsWebFormUtil.FillDropDownList(this.ddlTechnology, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddlTechnology.Items.Clear();   
        }
    }
        
    /// <summary>
    /// Loads Brands To Brand Combo
    /// </summary>
    private void Populate_drpSKUBrand()
    {
        if (ddlTechnology.Items.Count > 0)
        {
            string strSKUCategoryID = this.ddlTechnology.SelectedItem.Value;

            if (ddlTechnology.Items.Count   > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, int.Parse(ddlTechnology.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()), 2);
                clsWebFormUtil.FillDropDownList(this.ddlNature, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddlNature.Items.Clear();   
        }
    }

    /// <summary>
    /// Loads SKU Data To Session
    /// </summary>
    private void LoadData()
    {
        if (ddlModel.Items.Count > 0)
        {
            SkuController mSKUController = new SkuController();
            m_SKUDt = mSKUController.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.Session.Add("m_SKUDt", m_SKUDt);
        }
    }

    /// <summary>
    /// Loads Data From Session To Grid
    /// </summary>
    private void LoadGrid()
    {
        m_SKUDt = (DataTable)this.Session["m_SKUDt"];
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
                case 4:
                    m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                default:
                    m_SKUDt.DefaultView.RowFilter = "SKU_NAME" + " like '%" + "" + "%'";
                    break;
            }
            grdSKUData.DataSource = m_SKUDt.DefaultView;
            grdSKUData.DataBind();
        }
       }

   /// <summary>
   /// Sets SKU Data For Edit. This Function Runs When An Existing SKU Needs To Be Edited
   /// </summary>
   /// <param name="sender">object</param>
   /// <param name="e">GridViewEditEventArgs</param>
    protected void grdSKUData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Session.Add("Pic", grdSKUData.Rows[e.NewEditIndex].Cells[16].Text);
        ddlModel.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[0].Text;
        ddlType.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[1].Text;
        ddlTechnology.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[2].Text;
        ddlNature.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[3].Text;
        m_sku_id = int.Parse(grdSKUData.Rows[e.NewEditIndex].Cells[4].Text);
        ddlSourece.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[5].Text;
        ddlColor.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[6].Text;
        ddlUnit.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[7].Text;
        txtskuname.Text = grdSKUData.Rows[e.NewEditIndex].Cells[8].Text;
        txtskuname2.Text = grdSKUData.Rows[e.NewEditIndex].Cells[9].Text;
        txtskucode.Text = grdSKUData.Rows[e.NewEditIndex].Cells[10].Text;
        txtMaximumStock.Text = grdSKUData.Rows[e.NewEditIndex].Cells[11].Text;
        txtMinimumStock.Text = grdSKUData.Rows[e.NewEditIndex].Cells[12].Text;
        txtunitincase.Text = grdSKUData.Rows[e.NewEditIndex].Cells[13].Text;
        txtSkuweight.Text = grdSKUData.Rows[e.NewEditIndex].Cells[14].Text;
        txtLocation.Text = grdSKUData.Rows[e.NewEditIndex].Cells[15].Text;
        iItem.ImageUrl = "~/Pics/" +  grdSKUData.Rows[e.NewEditIndex].Cells[16].Text;
        ddlUOM.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[17].Text;
        btnSave.Text = "Update";
    }

   /// <summary>
   /// Deletes A SKU
   /// </summary>
   /// <param name="sender">object</param>
   /// <param name="e">GridViewEditEventArgs</param>
    protected void grdSKUData_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
       int m_sku_id = int.Parse(grdSKUData.Rows[e.RowIndex].Cells[4].Text);
       //string result = mController.UpdateSKUS3(m_sku_id, int.Parse(this.Session["CompanyId"].ToString()), null, null, null, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue
       //        , Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.ShortNullValue, Constants.DecimalNullValue, null, null, false, Convert.ToInt32(Session["UserID"]), Constants.IntNullValue
       //        , Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue);
       //this.LoadData();
       this.LoadGrid();
   }

   /// <summary>
   /// Sets PageIndex Of SKU Grid
   /// </summary>
   /// <param name="sender">object</param>
   /// <param name="e">GridViewPageEventArgs</param>
    protected void grdSKUData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdSKUData.PageIndex = e.NewPageIndex;
        this.LoadGrid();

    }

   /// <summary>
   /// Save Or Updates an SKU
   /// </summary>
   /// <param name="sender">object</param>
   /// <param name="e">EventArgs</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {       
       if (txtskuname.Text.Length <= 0)
       {
           lblErrorMsg.Text = "Must Enter Item Name";
           return;
       }

       string fileName = null;
       if (fuImage.HasFile)
       {
           string path = Server.MapPath("~/Pics");
           string fExtension = "";
           FileInfo oFileInfo = new FileInfo(fuImage.PostedFile.FileName);
           fExtension = Path.GetExtension(fuImage.FileName);
           fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "pic" + fExtension;
           string fullFileName = path + "\\" + fileName;

           if (!Directory.Exists(path))
           {
               Directory.CreateDirectory(path);
           }
           fuImage.PostedFile.SaveAs(fullFileName);
       }

       //if(btnSave.Text == "Save") 
       //{
       //    mController.InsertSKUS3(int.Parse(this.Session["CompanyId"].ToString()), txtskuname.Text, txtskuname2.Text, txtskucode.Text, Convert.ToInt32(ddlModel.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlTechnology.SelectedValue)
       //        , Convert.ToInt32(ddlNature.SelectedValue), Convert.ToInt32(ddlSourece.SelectedValue), Convert.ToInt32(ddlColor.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(dc.chkNull_0(txtMaximumStock.Text))
       //        , Convert.ToInt32(dc.chkNull_0(txtMinimumStock.Text)), Convert.ToInt16(dc.chkNull_0(txtunitincase.Text)), Convert.ToDecimal(dc.chkNull_0(txtSkuweight.Text)), txtLocation.Text, fileName, Convert.ToInt32(Session["UserID"]),Convert.ToInt32(ddlUOM.SelectedValue)
       //        ,Constants.LongNullValue, Constants.LongNullValue,  Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue);
       //    this.CLearAll();  
       //}
       //else if (btnSave.Text == "Update")
       //{
       //    mController.UpdateSKUS3(m_sku_id, int.Parse(this.Session["CompanyId"].ToString()), txtskuname.Text, txtskuname2.Text, txtskucode.Text, Convert.ToInt32(ddlModel.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlTechnology.SelectedValue)
       //        , Convert.ToInt32(ddlNature.SelectedValue), Convert.ToInt32(ddlSourece.SelectedValue), Convert.ToInt32(ddlColor.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(dc.chkNull_0(txtMaximumStock.Text))
       //        , Convert.ToInt32(dc.chkNull_0(txtMinimumStock.Text)), Convert.ToInt16(dc.chkNull_0(txtunitincase.Text)), Convert.ToDecimal(dc.chkNull_0(txtSkuweight.Text)), txtLocation.Text, fileName,true, Convert.ToInt32(Session["UserID"]),Convert.ToInt32(ddlUOM.SelectedValue)
       //        , Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue, Constants.LongNullValue);
       //    this.CLearAll();
       //}
       Session.Remove("Pic");
       iItem.ImageUrl = "~/images/noimage.jpg";
       this.LoadData();         
    }
  
    /// <summary>
    /// Filters SKU From SKU Grid
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    /// <summary>
    /// Clears Form Controls
    /// </summary>
    private void CLearAll()
    {
        txtMaximumStock.Text = "";
        txtskucode.Text = "";
        txtunitincase.Text = "";
        txtskuname.Text = "";
        txtskuname2.Text = "";
        txtMinimumStock.Text = "";
        txtLocation.Text = "";
        btnSave.Text = "Save";
        txtBarCode.Text = "";
        txtSkuweight.Text = "";
        this.LoadData();
        this.LoadGrid();
    }
}