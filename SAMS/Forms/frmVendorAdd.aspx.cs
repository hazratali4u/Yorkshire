using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommonLayer.Classes;
using System.IO;
using System.Web;
using System.Collections.Generic;


/// <summary>
/// From to Add, Edit, Delete Geo Heirarical Data
/// </summary>
public partial class Forms_frmVendorAdd : System.Web.UI.Page
{    
    readonly VenderEntryController VendorCtl = new VenderEntryController();

    readonly AccountHeadController mah_Controller = new AccountHeadController();

    DataTable _dtAttach;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CreateAttatchment();
            txtIncDate.Text = DateTime.Parse(Session["CurrentWorkDate"].ToString()).ToString("dd-MMM-yyyy");
            if (Request.QueryString["mode"] != null)
            {
                LoadBasicInformation();
            }
            btnSaveBasic.Attributes.Add("onclick", "return ValidateBasicInformation()");
            
        }
    }

    #region Basic Information

    
    protected void LoadBasicInformation()
    {

        DataTable dtVendor = VendorCtl.GetVendor(Convert.ToInt32(Session["VendorID"]));
        if (dtVendor.Rows.Count > 0)
        {
            txtName.Text = dtVendor.Rows[0]["VENDOR_NAME"].ToString(); //registerComapnyName
            if (dtVendor.Rows[0]["IncorporationDate"].ToString() != "")
            {
                txtIncDate.Text = Convert.ToDateTime(dtVendor.Rows[0]["IncorporationDate"]).ToString("dd-MMM-yyyy");
            }
            txtRegisterNo.Text = dtVendor.Rows[0]["firmRegisterNo"].ToString();
            //------------------------------------------------------

            if (dtVendor.Rows[0]["VENDOR_TYPE"].ToString() != "")
            {
                rdbSupplierType.SelectedValue = dtVendor.Rows[0]["VENDOR_TYPE"].ToString();
            }
            txtFirmAddress.Text = dtVendor.Rows[0]["f_Address"].ToString();
            txtFirmConatct.Text = dtVendor.Rows[0]["f_ContactNo"].ToString();
            txtFirmFax.Text = dtVendor.Rows[0]["f_Fax"].ToString();
            txtFirmEmail.Text = dtVendor.Rows[0]["f_Email"].ToString();
            //------------------------------------------------------

            txtRName.Text = dtVendor.Rows[0]["r_Name"].ToString();
            txtRContact.Text = dtVendor.Rows[0]["r_ContactNo"].ToString();
            txtREmail.Text = dtVendor.Rows[0]["r_Email"].ToString();
            txtRSkype.Text = dtVendor.Rows[0]["r_Skype"].ToString();
            //-------------------------------------------------------
   
            txtSName.Text = dtVendor.Rows[0]["sa_Name"].ToString();
            txtSConactNo.Text = dtVendor.Rows[0]["sa_ContactNo"].ToString();
            txtSEmail.Text = dtVendor.Rows[0]["sa_Email"].ToString();
            txtSSkype.Text = dtVendor.Rows[0]["sa_Skype"].ToString();
            //-------------------------------------------------------

            txtBankName.Text = dtVendor.Rows[0]["bI_Name"].ToString();
            txtBankAccountTitle.Text = dtVendor.Rows[0]["bI_Title"].ToString();
            txtBankAccountNo.Text = dtVendor.Rows[0]["bI_No"].ToString();
            txtSwiftCode.Text = dtVendor.Rows[0]["bI_Code"].ToString();
            txtBranchAddress.Text = dtVendor.Rows[0]["bI_Address"].ToString();
            txtBContactNo.Text = dtVendor.Rows[0]["bI_ContactNo"].ToString();
            txtBFax.Text = dtVendor.Rows[0]["bI_Fax"].ToString();
            txtBEmail.Text = dtVendor.Rows[0]["bI_Email"].ToString();
            //-------------------------------------------------------

            txtExportDetail.Text = dtVendor.Rows[0]["exportDetail"].ToString();
            txtTradeExp.Text = dtVendor.Rows[0]["tradeExperience"].ToString();
            txtCertificate.Text = dtVendor.Rows[0]["certificateDetail"].ToString();
            txtAsset.Text = dtVendor.Rows[0]["Asset"].ToString();
            txtGoods.Text = dtVendor.Rows[0]["goodsManufactue"].ToString();
            txtPlantCapacity.Text = dtVendor.Rows[0]["plantCapacity"].ToString();
            txtAccountDetail.Text = dtVendor.Rows[0]["othersAccountDetail"].ToString();
            txtOtherDetail.Text = dtVendor.Rows[0]["otherDetail"].ToString();

            chkIsActive.Checked = Convert.ToBoolean(dtVendor.Rows[0]["IS_ACTIVE"]);

            DataTable dtVendorAtt = VendorCtl.GetVendorAttachment(Convert.ToInt32(Session["VendorID"]));
            if (dtVendorAtt.Rows.Count > 0)
            {

                foreach (DataRow drf in dtVendorAtt.Rows)
                {
                    if (drf["FILE_NAME"] != DBNull.Value)
                    {

                        DataRow dr2 = _dtAttach.NewRow();

                        dr2["FILENAME"] = drf["FILE_NAME"].ToString();
                        dr2["PATH"] = drf["PATH"].ToString();
                        dr2["VENDOR_ID"] = drf["VENDOR_ID"].ToString();
                        _dtAttach.Rows.Add(dr2);
                    }
                }


                grdAttach.DataSource = _dtAttach;
                grdAttach.DataBind();

                Session.Add("dtAttach", _dtAttach);
            }
            btnSaveBasic.Text = "Update";
        }
    }
    
    protected void btnSaveBasic_Click(object sender, EventArgs e)
    {
        try
        {
            _dtAttach = (DataTable)Session["dtAttach"];

            DateTime dtIncDate = Constants.DateNullValue;
            if (txtIncDate.Text.Length > 0)
            {
                dtIncDate = Convert.ToDateTime(txtIncDate.Text);
            }
            if (btnSaveBasic.Text == "Save")
            {
                int VendorID = VendorCtl.InsertVendor(txtName.Text, txtRegisterNo.Text, txtName.Text, dtIncDate
                    , txtFirmAddress.Text, txtFirmConatct.Text, txtFirmFax.Text, txtFirmEmail.Text
                    , txtRName.Text, txtRContact.Text, txtREmail.Text, txtRSkype.Text
                    , txtSName.Text, txtSConactNo.Text, txtSEmail.Text, txtSSkype.Text
                    , txtBankName.Text, txtBankAccountTitle.Text, txtBankAccountNo.Text, txtSwiftCode.Text, txtBranchAddress.Text, txtBContactNo.Text, txtBFax.Text, txtBEmail.Text
                    , txtExportDetail.Text, txtTradeExp.Text, txtCertificate.Text, txtAsset.Text, txtGoods.Text, txtPlantCapacity.Text, txtAccountDetail.Text, txtOtherDetail.Text, chkIsActive.Checked, _dtAttach,Convert.ToInt16(rdbSupplierType.SelectedValue));
                if (VendorID > 0)
                {
                    Session.Remove("dtAttach");
                    Response.Redirect("frmVendor.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred.');", true);
                }
            }
            else
            {
                if (VendorCtl.UpdateVendor(Convert.ToInt32(Session["VendorID"]), txtName.Text, txtRegisterNo.Text, txtName.Text, dtIncDate
                    , txtFirmAddress.Text, txtFirmConatct.Text, txtFirmFax.Text, txtFirmEmail.Text
                    , txtRName.Text, txtRContact.Text, txtREmail.Text, txtRSkype.Text
                    , txtSName.Text, txtSConactNo.Text, txtSEmail.Text, txtSSkype.Text
                    , txtBankName.Text, txtBankAccountTitle.Text, txtBankAccountNo.Text, txtSwiftCode.Text, txtBranchAddress.Text, txtBContactNo.Text, txtBFax.Text, txtBEmail.Text
                    , txtExportDetail.Text, txtTradeExp.Text, txtCertificate.Text, txtAsset.Text, txtGoods.Text, txtPlantCapacity.Text, txtAccountDetail.Text, txtOtherDetail.Text, chkIsActive.Checked, _dtAttach, Convert.ToInt16(rdbSupplierType.SelectedValue)))
                {
                    Session.Remove("dtAttach");
                    Response.Redirect("frmVendor.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred.');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Some error occurred.');", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["mode"] != null)
        {
            Response.Redirect("frmVendorAdd.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&mode=edit&TopID=2");
        }
        else
        {
            Response.Redirect("frmVendorAdd.aspx?LevelID=" + Request.QueryString["LevelID"].ToString() + "&LevelType=" + Request.QueryString["LevelType"].ToString() + "&TopID=2");
        }
    }
        
    #endregion
   
    #region Attachment
    protected void grdAttach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            Button lnkViewDoc = e.Row.FindControl("lnkViewDoc") as Button;
            Button lnkViewDoc2 = e.Row.FindControl("btn_delete") as Button;
            
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkViewDoc);
        }
    }
    protected void grdAttach_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

        int RowIndex = gvr.RowIndex;
        if (e.CommandName.ToLower() == "download")
        {
           

            long id = long.Parse(e.CommandArgument.ToString());
            DataTable dtDoc = VendorCtl.GetVendorAttachment(Convert.ToInt32(Session["VendorID"]));
            if (dtDoc.Rows.Count > 0)
            {
                string FName = dtDoc.Rows[RowIndex]["FILE_NAME"].ToString();
                DownLoadFile(Server.MapPath("~/Docs/" + FName));
            }
            else
            {

            }
        }
        else
        {
            _dtAttach = (DataTable)Session["dtAttach"];


            _dtAttach.Rows[RowIndex].Delete();

            grdAttach.DataSource = _dtAttach;
            grdAttach.DataBind();

            _dtAttach.AcceptChanges();
            Session.Add("dtAttach", _dtAttach);
        }
       
    }
    private void CreateAttatchment()
    {
        _dtAttach = new DataTable();
        _dtAttach.Columns.Add("FILENAME", typeof(string));
        _dtAttach.Columns.Add("PATH", typeof(string));
        _dtAttach.Columns.Add("VENDOR_ID", typeof(int));

        Session.Add("dtAttach", _dtAttach);
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
     
        Page.MaintainScrollPositionOnPostBack = true;

         _dtAttach = (DataTable)Session["dtAttach"];
        HttpFileCollection uploadedFiles = Request.Files;
        if (FupVendor.HasFile)
        {
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                DataRow dr = _dtAttach.NewRow();
                HttpPostedFile userPostedFile = uploadedFiles[i];
                if (userPostedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(userPostedFile.FileName);
                    var file = Path.Combine(Server.MapPath("~/POImages/"), fileName);
                    userPostedFile.SaveAs(file);
                    dr["FILENAME"] = fileName;
                    dr["PATH"] = Server.MapPath("~/POImages/" + fileName);
                    _dtAttach.Rows.Add(dr);
                }

            }
            //ltrlDoc.Text = Utility.ShowAlert(true, "Document has been uploaded successfully.");
            grdAttach.DataSource = _dtAttach;
            grdAttach.DataBind();
            Session.Add("dtAttach", _dtAttach);
        }
        else
        {
           //ltrlDoc.Text = Utility.ShowAlert(false, "Please browse some document.");
        }

    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        _dtAttach = (DataTable)Session["dtAttach"];
        //Get the button that raised the event
        Button btn = (Button)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int r = gvr.RowIndex;
        //Get rowindex

        //Delete row
        _dtAttach.Rows[r].Delete();

        grdAttach.DataSource = _dtAttach;
        grdAttach.DataBind();

        _dtAttach.AcceptChanges();
        Session.Add("dtAttach", _dtAttach);
    }

    private void DownLoadFile(string path)
    {
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = MimeType(Path.GetExtension(path));
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(path)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(path);
            Response.End();
        }
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    } 

    #endregion
}