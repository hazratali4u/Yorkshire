using System;
using System.Data;
using SAMSCommonLayer.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For SKU Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert SKU
    /// </item>
    /// <term>
    /// Update SKU
    /// </term>
    /// <item>
    /// Get SKU
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class SkuController
	{	
		#region Constructors

        /// <summary>
        /// Constructor For SkuController
        /// </summary>
		public SkuController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
        #endregion
				
		#region public Methods

        #region Select

        /// <summary>
        /// Gets SKUS Data
        /// </summary>
        /// <remarks>
        /// Returns SKUS Data as Datatable
        /// </remarks>
        /// <param name="p_company_id">Principal</param>
        /// <param name="p_division_id">Dicision</param>
        /// <param name="p_category_id">Category</param>
        /// <param name="p_brand_id">Brand</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKUS Data as Datatable</returns>
        public DataTable SelectSkuInfo(int p_company_id, int p_division_id, int p_category_id, int p_brand_id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSkuInfo mspSelectSkuInfo = new uspSelectSkuInfo();
                mspSelectSkuInfo.brand_id = p_brand_id;
                mspSelectSkuInfo.category_id = p_category_id;
                mspSelectSkuInfo.Principal_id = p_company_id;
                mspSelectSkuInfo.Connection = mConnection;
                mspSelectSkuInfo.division_id = p_division_id;
                mspSelectSkuInfo.Company_id = Companyid;

                DataTable dt = mspSelectSkuInfo.ExecuteTable();

                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Getting Information for Edit from(frmSKuData.aspx)
        /// </summary>
        /// <param name="pSkuId"></param>
        /// <param name="p_category_id"></param>
        /// <param name="Companyid"></param>
        /// <returns></returns>
        public DataTable SelectSkuInfo(int pSkuId, int p_category_id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSkuInfo mspSelectSkuInfo = new uspSelectSkuInfo();
                mspSelectSkuInfo.Connection = mConnection;

                mspSelectSkuInfo.category_id = p_category_id;
                mspSelectSkuInfo.Principal_id = pSkuId;
                mspSelectSkuInfo.Company_id = Companyid;

                DataTable dt = mspSelectSkuInfo.ExecuteTable();

                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
 
        public DataTable SelectSkuInfo2(int p_company_id, int p_division_id, int p_category_id, int p_brand_id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSkuInfo2 mspSelectSkuInfo = new uspSelectSkuInfo2();
                mspSelectSkuInfo.Connection = mConnection;

                mspSelectSkuInfo.brand_id = p_brand_id;
                mspSelectSkuInfo.category_id = p_category_id;
                mspSelectSkuInfo.Principal_id = p_company_id;
                mspSelectSkuInfo.division_id = p_division_id;
                mspSelectSkuInfo.Company_id = Companyid;

                DataTable dt = mspSelectSkuInfo.ExecuteTable();

                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        /// <summary>
        /// Gets SKU Data
        /// </summary>
        /// <remarks>
        /// Returns SKUS Data as Datatable
        /// </remarks>
        /// <param name="p_SKU_Id">SKU</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKUS Data as Datatable</returns>
        public DataTable SelectSkuData(int p_SKU_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKUS mSkuInfo = new spSelectSKUS();
                mSkuInfo.Connection = mConnection;
                mSkuInfo.SKU_ID = p_SKU_Id;
                mSkuInfo.COMPANY_ID = Companyid;
                DataTable dt = mSkuInfo.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        /// <summary>
        /// Gets SKU Data
        /// </summary>
        /// <remarks>
        /// Returns SKUS Data as Datatable
        /// </remarks>
        /// <param name="p_SKU_Id">SKU</param>
        /// <param name="Companyid">Company</param>
        /// <returns>SKUS Data as Datatable</returns>
        public DataTable SelectSkuData(int p_SKU_Id, int Companyid,int p_Principal_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKUS mSkuInfo = new spSelectSKUS();
                mSkuInfo.Connection = mConnection;
                mSkuInfo.SKU_ID = p_SKU_Id;
                mSkuInfo.COMPANY_ID = Companyid;
                mSkuInfo.PRINCIPAL_ID = p_Principal_ID;
                DataTable dt = mSkuInfo.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        
        /// <summary>
        /// Gets SKU UOM
        /// </summary>
        /// <param name="p_UOM_Id">UOM</param>
        /// <param name="p_UOM_Desc">Description</param>
        /// <returns>SKU UOM</returns>
        public DataTable SelectUOMs(int p_UOM_Id, string p_UOM_Desc)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectUOMS mUOMs = new spSelectUOMS();
                mUOMs.Connection = mConnection;

                mUOMs.UOM_ID = p_UOM_Id;
                mUOMs.UOM_DESC = p_UOM_Desc;
                mUOMs.TIME_STAMP = Constants.DateNullValue;
                mUOMs.STATUS = Constants.IntNullValue;

                DataTable dt = mUOMs.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        #endregion

        #region Insert, Update
        
        public bool InsertSKUS(int p_COMPANY_ID, string p_SKU_NAME, int pCATEGORY_ID
            ,string pSize,string pColor,string pThickness,string pCore,string pHotPress,string pGlue,string pFace 
            ,int p_COLOR_ID, string pSanding, string pGrade, string pTolerance, short p_UNITS_IN_CASE, int p_USER_ID,string p_SKU_CODE)
        {
            IDbConnection mConnection = null;
            
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertSKUS2 mSkus = new spInsertSKUS2();
                mSkus.Connection = mConnection;

                mSkus.COMPANY_ID = p_COMPANY_ID;
                mSkus.SKU_NAME = p_SKU_NAME;
               
                mSkus.CATEGORY_ID = pCATEGORY_ID;
                mSkus.size=pSize;
                mSkus.color=pColor;
                mSkus.thickness=pThickness;
                mSkus.core=pCore;
                mSkus.hotpress=pHotPress;
                mSkus.glue=pGlue;
                mSkus.face = pFace;
                mSkus.COLOR_ID = p_COLOR_ID;

                mSkus.sanding = pSanding;
                mSkus.grade = pGrade;
                mSkus.tolerance = pTolerance;
                mSkus.UNITS_IN_CASE = p_UNITS_IN_CASE;
               
                mSkus.USER_ID = p_USER_ID;
                mSkus.SKU_CODE = p_SKU_CODE;
                return mSkus.ExecuteQuery();

              

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
              
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }


        public bool UpdateSKUS(int p_SKU_ID, int p_COMPANY_ID, string p_SKU_NAME, int pCATEGORY_ID
            , string pSize, string pColor, string pThickness, string pCore, string pHotPress, string pGlue, string pFace, int p_COLOR_ID
            , string pSanding, string pGrade, string pTolerance, short p_UNITS_IN_CASE
            , bool p_ISACTIVE, int p_USER_ID,string p_SKU_CODE)
        {
            IDbConnection mConnection = null;
            
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
               
                spUpdateSKUS3 mSkus = new spUpdateSKUS3();
                
                mSkus.Connection = mConnection;
                
                mSkus.SKU_ID = p_SKU_ID;
                mSkus.COMPANY_ID = p_COMPANY_ID;
                mSkus.SKU_NAME = p_SKU_NAME;
                mSkus.CATEGORY_ID = pCATEGORY_ID;
                mSkus.size = pSize;
                mSkus.color = pColor;
                mSkus.thickness = pThickness;
                mSkus.core = pCore;
                mSkus.hotpress = pHotPress;
                mSkus.glue = pGlue;
                mSkus.face = pFace;
                mSkus.COLOR_ID = p_COLOR_ID;
                mSkus.sanding = pSanding;
                mSkus.grade = pGrade;
                mSkus.tolerance = pTolerance;
                mSkus.UNITS_IN_CASE = p_UNITS_IN_CASE;
                mSkus.ISACTIVE = p_ISACTIVE;
                mSkus.USER_ID = p_USER_ID;
                mSkus.SKU_CODE = p_SKU_CODE;
                return mSkus.ExecuteQuery();


            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        #endregion

        #endregion
    }
}
