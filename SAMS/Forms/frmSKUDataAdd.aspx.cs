using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using System.IO;

/// <summary>
/// From To Add, Edit, Delete SKU
/// </summary>
public partial class Forms_frmSKUDataAdd : System.Web.UI.Page
{

    SkuController mController = new SkuController();
    DataControl dc = new DataControl();
    SkuHierarchyController mHer_Controller = new SkuHierarchyController();
    readonly AccountHeadController mah_Controller = new AccountHeadController();

    private DataTable m_dt, m_SKUDt;


    /// <summary>
    /// Page_Load Function Populates All Combos And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                LoadCategory();

                if (Session["skuId"] != null)
                {
                    m_SKUDt = mController.SelectSkuInfo(int.Parse(Session["skuId"].ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
                    if (m_SKUDt != null)
                    {
                        if (m_SKUDt.Rows.Count > 0)
                        {
                            txtskuname.Text = m_SKUDt.Rows[0]["SKU_NAME"].ToString();
                            ddlCategory.SelectedValue = m_SKUDt.Rows[0]["CATEGORY_ID"].ToString();
                            txtSize.Text = m_SKUDt.Rows[0]["size"].ToString();
                            txtColor.Text = m_SKUDt.Rows[0]["color"].ToString();
                            txtThickness.Text = m_SKUDt.Rows[0]["thickness"].ToString();
                            txtCore.Text = m_SKUDt.Rows[0]["core"].ToString();
                            txtHotPress.Text = m_SKUDt.Rows[0]["hotpress"].ToString();
                            txtGlue.Text = m_SKUDt.Rows[0]["glue"].ToString();
                            txtFace.Text = m_SKUDt.Rows[0]["face"].ToString();
                            txtSanding.Text = m_SKUDt.Rows[0]["sanding"].ToString();
                            txtGrade.Text = m_SKUDt.Rows[0]["grade"].ToString();
                            txtTolerance.Text = m_SKUDt.Rows[0]["tolerance"].ToString();
                            txtunitincase.Text = m_SKUDt.Rows[0]["UNITS_IN_CASE"].ToString();
                            txtSKUCode.Text = m_SKUDt.Rows[0]["SKU_CODE"].ToString();

                            btnSave.Text = "Update";
                            chkIsActive.Checked = Convert.ToBoolean(m_SKUDt.Rows[0]["ISACTIVE"]);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    private void LoadCategory()
    {
        m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, Constants.IntNullValue, null, null, true, int.Parse(Session["CompanyId"].ToString()), 2);
        clsWebFormUtil.FillDropDownList(ddlCategory, m_dt, 0, 3, true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = true;
            if (txtskuname.Text.Length <= 0)
            {
                lblErrorMsg.Text = "Must Enter Product Name";
                return;
            }

            if (txtSKUCode.Text.Length <= 0)
            {
                lblErrorMsg.Text = "Must Enter Product Code";
                return;
            }

            if (btnSave.Text == "Save")
            {
                flag = mController.InsertSKUS(int.Parse(Session["CompanyId"].ToString()), txtskuname.Text, Convert.ToInt32(ddlCategory.SelectedValue)
                    , txtSize.Text, txtColor.Text, txtThickness.Text, txtCore.Text, txtHotPress.Text, txtGlue.Text, txtFace.Text
                    , Constants.IntNullValue,txtSanding.Text, txtGrade.Text, txtTolerance.Text, Convert.ToInt16(dc.chkNull_0(txtunitincase.Text)), Convert.ToInt32(Session["UserID"]),txtSKUCode.Text);


            }
            else if (btnSave.Text == "Update")
            {
                flag = mController.UpdateSKUS(int.Parse(Session["skuId"].ToString()), int.Parse(Session["CompanyId"].ToString()), txtskuname.Text, Convert.ToInt32(ddlCategory.SelectedValue)
                    , txtSize.Text, txtColor.Text, txtThickness.Text, txtCore.Text, txtHotPress.Text, txtGlue.Text, txtFace.Text
                    , Constants.IntNullValue, txtSanding.Text, txtGrade.Text, txtTolerance.Text ,Convert.ToInt16(dc.chkNull_0(txtunitincase.Text)), chkIsActive.Checked, Convert.ToInt32(Session["UserID"]),txtSKUCode.Text);


            }
            if (flag)
            {
                CLearAll();
                Session.Remove("skuId");
                Response.Redirect("frmSKUData.aspx?LevelID=" + Request["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2");
            }
            lblErrorMsg.Text = " Some Error Occurred!";
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
        }
    }


    /// <summary>
    /// Clears Form Controls
    /// </summary>
    private void CLearAll()
    {
        txtThickness.Text = "";
        txtColor.Text = "";
        txtunitincase.Text = "";
        txtskuname.Text = "";
        txtSize.Text = "";
        txtCore.Text = "";
        txtFace.Text = "";
        txtHotPress.Text = "";
        txtThickness.Text = "";
        txtGlue.Text = "";
        btnSave.Text = "Save";

    }
}