using System;
using System.Data;
using SAMSCommonLayer.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Purchase, TranferOut, Purchase Return, TranferIn And Damage Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </item>
    /// <term>
    /// Update Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </term>
    /// <item>
    /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class PurchaseController
    {
        #region Constructor

        /// <summary>
        /// Constructor for PurchaseController
        /// </summary>
        public PurchaseController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Private Variables
        
        IDbTransaction mTransaction;
        IDbConnection mConnection;

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="PConnection">Connection</param>
        /// <param name="PTransaction">Transaction</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPrivousePurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, IDbConnection PConnection, IDbTransaction PTransaction)
        {
            try
            {
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = PConnection;
                mPurchaseDetail.Transaction = PTransaction;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
        }

        /// <summary>
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Posting">Posting</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage  Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = p_User_Id;
                mPurchaseMaster.POSTING = p_Posting;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="P_DocumentDate">Date</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, DateTime P_DocumentDate)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.DOCUMENT_DATE = P_DocumentDate;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting, int p_SOLD_TO)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = Constants.IntNullValue;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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


        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, DateTime pDocumentDate)
        
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = p_User_Id;
                mPurchaseMaster.DOCUMENT_DATE = pDocumentDate;
               
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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

        public DataTable SelectSKUClosingStock(int p_DISTRIBUTOR_ID, int p_SKU_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                mStockUpdate.Connection = mConnection;
                mStockUpdate.TYPE_ID = 12;
                mStockUpdate.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mStockUpdate.SKU_ID = p_SKU_ID;
                
                DataTable dt = mStockUpdate.ExecuteTable();
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

        public DataSet DailySupplierPurchased(int pDistributorId, int pSupplierId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.dsSalesPurchaseRegister ds = new SAMSBusinessLayer.Reports.dsSalesPurchaseRegister();

                spDailyPurchased mLedger = new spDailyPurchased();

                mLedger.Connection = mConnection;

                mLedger.distributorId = pDistributorId;
                mLedger.supplierId = pSupplierId;
                mLedger.fromDate = p_From_Date;
                mLedger.toDate = p_ToDate;

                DataTable dt = mLedger.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["spDailyPurchased"].ImportRow(dr);
                }



                return ds;
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

        public DataTable GetProformaInvoiceView(int p_DISTRIBUTOR_ID, int p_PageSize, int p_PageNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetProformaInvoiceView mStockUpdate = new uspGetProformaInvoiceView();
                mStockUpdate.Connection = mConnection;
                mStockUpdate.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mStockUpdate.PageSize = p_PageSize;
                mStockUpdate.PageNo = p_PageNo;
                DataTable dt = mStockUpdate.ExecuteTable();
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

        /// <summary>
        /// Inserts Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_ORDER_NUMBER">DocumentNo</param>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <param name="p_SOLD_FROM">SoldFrom</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_IS_DELETE">IsDeleted</param>
        /// <param name="dtPurchaseDetail">PurchaseDetailDatatable</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_BuiltyNo">Builty</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool InsertPurchaseDocument(int p_DISTRIBUTOR_ID,string p_ORDER_NUMBER,int p_TYPE_ID,DateTime p_DOCUMENT_DATE,int p_SOLD_TO,int p_SOLD_FROM
            ,decimal p_TOTAL_AMOUNT,bool p_IS_DELETE,DataTable dtPurchaseDetail,int p_Posting,string p_BuiltyNo,int p_UserId,int p_PrincipalId) 
		{
			try
			{                 
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;  
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;   
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId; 
                
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;
                
                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = decimal.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;// Convert.ToDateTime(dr["TIME_STAMP"]);  
                    mPurchaseDetail.ExecuteQuery();
                    
                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId; 
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;   
                    mStockUpdate.ExecuteQuery();


                    uspProcessSKUStock mSKUStock = new uspProcessSKUStock();
                    mSKUStock.Connection = mConnection;
                    mSKUStock.Transaction = mTransaction;
                    mSKUStock.SKU_ID = mPurchaseDetail.SKU_ID;
                    mSKUStock.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mSKUStock.BATCH_NO = mPurchaseDetail.BATCH_NO;
                    mSKUStock.UNITS_IN_STOCK = mPurchaseDetail.QUANTITY;
                    mSKUStock.EXPIRY_DATE = mPurchaseDetail.TIME_STAMP;
                    mSKUStock.TYPE_ID = p_TYPE_ID;
                    mSKUStock.REF_NO = "";
                    mSKUStock.ExecuteQuery();   
                }
                mTransaction.Commit();
                return true; 
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}

        /// <summary>
        /// Inserts Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_ORDER_NUMBER">DocumentNo</param>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <param name="p_SOLD_FROM">SoldFrom</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_IS_DELETE">IsDeleted</param>
        /// <param name="dtPurchaseDetail">PurchaseDetailDatatable</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_BuiltyNo">Builty</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool InsertPurchaseDocument(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM
            , decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail,int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId, long p_PO_ID
            , string p_REF_NO)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.PO_ID = p_PO_ID;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();

                    uspProcessSKUStock mSKUStock = new uspProcessSKUStock();                    
                    mSKUStock.Connection = mConnection;
                    mSKUStock.Transaction = mTransaction;
                    mSKUStock.SKU_ID = mPurchaseDetail.SKU_ID;
                    mSKUStock.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mSKUStock.BATCH_NO = mPurchaseDetail.BATCH_NO;
                    mSKUStock.UNITS_IN_STOCK = mPurchaseDetail.QUANTITY;
                    mSKUStock.EXPIRY_DATE = mPurchaseDetail.TIME_STAMP;
                    mSKUStock.TYPE_ID = p_TYPE_ID;
                    mSKUStock.REF_NO = p_REF_NO;
                    mSKUStock.ExecuteQuery();

                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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
        
        /// <summary>
        /// Updates Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_ORDER_NUMBER">DocumentNo</param>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <param name="p_SOLD_FROM">SoldFrom</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_IS_DELETE">IsDeleted</param>
        /// <param name="dtPurchaseDetail">PurchaseDetailDatatable</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_BuiltyNo">Builty</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Principal">Principal</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool UpdatePurchaseDocument(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId,int p_Principal)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER(); 
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;  
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;   
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;  
                mPurchaseMaster.ExecuteQuery();
               
                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID,mConnection,mTransaction);
                
                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID; 
                   // mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }
                                
                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    
                   //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = decimal.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                 //   if (dr["TIME_STAMP"] != null)
                 //   {
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;// Convert.ToDateTime(dr["TIME_STAMP"]);
                  //  }
                  //  else
                  //  {
                   //     mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                  //  }
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal; 
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();


                    uspProcessSKUStock mSKUStock = new uspProcessSKUStock();
                    mSKUStock.Connection = mConnection;
                    mSKUStock.Transaction = mTransaction;
                    mSKUStock.SKU_ID = mPurchaseDetail.SKU_ID;
                    mSKUStock.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mSKUStock.BATCH_NO = mPurchaseDetail.BATCH_NO;
                    mSKUStock.UNITS_IN_STOCK = mPurchaseDetail.QUANTITY;
                    mSKUStock.EXPIRY_DATE = mPurchaseDetail.TIME_STAMP;
                    mSKUStock.TYPE_ID = p_TYPE_ID;
                    mSKUStock.REF_NO = "";
                    mSKUStock.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        public bool UpdatePurchaseDocument(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal,string p_REF_NO)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                  //  mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    if (dr["TIME_STAMP"] != null)
                    {
                        mPurchaseDetail.TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                    }
                    else
                    {
                        mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    }
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();


                    uspProcessSKUStock mSKUStock = new uspProcessSKUStock();
                    mSKUStock.Connection = mConnection;
                    mSKUStock.Transaction = mTransaction;
                    mSKUStock.SKU_ID = mPurchaseDetail.SKU_ID;
                    mSKUStock.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mSKUStock.BATCH_NO = mPurchaseDetail.BATCH_NO;
                    mSKUStock.UNITS_IN_STOCK = mPurchaseDetail.FREE_SKU;
                    mSKUStock.EXPIRY_DATE = mPurchaseDetail.TIME_STAMP;
                    mSKUStock.TYPE_ID = p_TYPE_ID;
                     mSKUStock.REF_NO = p_REF_NO;
                    mSKUStock.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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


        // GRN

        public bool InsertGRN(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO
            , int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo
            , int p_UserId, int p_PrincipalId, long p_PO_ID, string p_REF_NO, string pDcNo, DateTime pDcDate, string pDriverName
            , string pVehicleNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;                
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.dcNo = pDcNo;
                mPurchaseMaster.dcDate = pDcDate;
                mPurchaseMaster.driverName = pDriverName;
                mPurchaseMaster.VehicleNo = pVehicleNo;
                mPurchaseMaster.PO_ID = p_PO_ID;
                
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = decimal.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = mPurchaseMaster.DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                    

                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        public bool UpdateGRN(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE
            , int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting
            , string p_BuiltyNo, int p_UserId, int p_Principal, string p_REF_NO, string pDcNo, DateTime pDcDate, string pDriverName
            , string pVehicleNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);


                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.document_date = p_DOCUMENT_DATE;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.qty = decimal.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }


                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.dcNo = pDcNo;
                mPurchaseMaster.dcDate = pDcDate;
                mPurchaseMaster.driverName = pDriverName;
                mPurchaseMaster.VehicleNo = pVehicleNo;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = decimal.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                  
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = 0;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();

                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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


        public bool PostPendingDocument(long p_PURCHASE_MASTER_ID,int p_Type_Id,int p_Distributor_Id,int p_Posting)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                mPurchaseMaster.TYPE_ID = p_Type_Id;  
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.ExecuteQuery();
                return true;
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

        #region Purchase Order

        public DataTable GetPOAttachment(long pPO_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER_ATTACHMENT mData = new spSelectPURCHASE_ORDER_ATTACHMENT();
                mData.Connection = mConnection;
                mData.PURCHASE_ORDER_ID = pPO_ID;
                DataTable dt = mData.ExecuteTable();
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

        public bool InsertPurchaseOrder(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, string p_REF_NO, int p_TYPE_ID, int p_CURRENCY_ID, decimal p_EXCHANGE_RATE, DateTime p_DOCUMENT_DATE, decimal p_TOTAL_AMOUNT, int p_USER_ID,
            DataTable dtPurchaseDetail, string pCreditTerm, decimal pNetAMount, decimal pGst, decimal pGstValue
            , string p_destinationPort, string p_delivertyTime, string p_Packing, string p_shippingMark
        , string p_shippingTerms, string p_shipmentMode, string p_paymentTerm, string p_documentReq
        , string p_ftaCertificate, string p_originCertificate, string p_phyCertificate, string p_packingList, string p_CommInvoice, string p_containerSize
        , string p_remarks1, string p_remarks2, string p_remarks3, string p_remarks4
        , string p_remarks5, string p_remarks6, string p_remarks7, string p_remarks8, string p_remarks9, string p_remarks10
        , DataTable dtAttachment)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_ORDER mPurchaseMaster = new spInsertPURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mPurchaseMaster.REF_NO = p_REF_NO;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.CURRENCY_ID = p_CURRENCY_ID;
                mPurchaseMaster.EXCHANGE_RATE = p_EXCHANGE_RATE;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_USER_ID;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.creditTerm = pCreditTerm;
                mPurchaseMaster.gst = pGst;
                mPurchaseMaster.gstValue = pGstValue;
                mPurchaseMaster.netAmount = pNetAMount;

                mPurchaseMaster.destinationPort = p_destinationPort;
                mPurchaseMaster.delivertyTime = p_delivertyTime;
                mPurchaseMaster.Packing = p_Packing;
                mPurchaseMaster.shippingMark = p_shippingMark;
                mPurchaseMaster.shippingTerms = p_shippingTerms;
                mPurchaseMaster.shipmentMode = p_shipmentMode;
                mPurchaseMaster.paymentTerm = p_paymentTerm;
                mPurchaseMaster.documentReq = p_documentReq;
                mPurchaseMaster.ftaCertificate = p_ftaCertificate;
                mPurchaseMaster.originCertificate = p_originCertificate;
                mPurchaseMaster.phyCertificate = p_phyCertificate;
                mPurchaseMaster.packingList = p_packingList;
                mPurchaseMaster.CommInvoice = p_CommInvoice;
                mPurchaseMaster.containerSize = p_containerSize;
                mPurchaseMaster.remarks1 = p_remarks1;
                mPurchaseMaster.remarks2 = p_remarks2;
                mPurchaseMaster.remarks3 = p_remarks3;
                mPurchaseMaster.remarks4 = p_remarks4;
                mPurchaseMaster.remarks5 = p_remarks5;
                mPurchaseMaster.remarks6 = p_remarks6;
                mPurchaseMaster.remarks7 = p_remarks7;
                mPurchaseMaster.remarks8 = p_remarks8;
                mPurchaseMaster.remarks9 = p_remarks9;
                mPurchaseMaster.remarks10 = p_remarks10;

                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_ORDER_DETAIL mPurchaseDetail = new spInsertPURCHASE_ORDER_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_ORDER_ID = mPurchaseMaster.PURCHASE_ORDER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TIME_STAMP = DateTime.Now;
                    mPurchaseDetail.ExecuteQuery();                    
                }

                spInsertPURCHASE_ORDER_ATTACHMENT mOrderDetailAtt = new spInsertPURCHASE_ORDER_ATTACHMENT();
                mOrderDetailAtt.Connection = mConnection;
                mOrderDetailAtt.Transaction = mTransaction;

                foreach (DataRow dr in dtAttachment.Rows)
                {
                    mOrderDetailAtt.PURCHASE_ORDER_ID = mPurchaseMaster.PURCHASE_ORDER_ID;
                    mOrderDetailAtt.PATH = dr["PATH"].ToString();
                    mOrderDetailAtt.NAME = dr["NAME"].ToString();
                    mOrderDetailAtt.DATA =(byte[]) dr["DATA"];
                    mOrderDetailAtt.ExecuteQuery();
                }


                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        public bool UpdatePurchaseOrderDetail(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, string p_REF_NO, int p_CURRENCY_ID, decimal p_TOTAL_AMOUNT
            , decimal p_EXCHANGE_RATE, int p_USER_ID, DataTable dtPurchaseDetail, string pCreditTerm, decimal pNetAMount, decimal pGst, decimal pGstValue
            , string p_destinationPort, string p_delivertyTime, string p_Packing, string p_shippingMark
        , string p_shippingTerms, string p_shipmentMode, string p_paymentTerm, string p_documentReq
        , string p_ftaCertificate, string p_originCertificate, string p_phyCertificate, string p_packingList, string p_CommInvoice, string p_containerSize
        , string p_remarks1, string p_remarks2, string p_remarks3, string p_remarks4
            , string p_remarks5, string p_remarks6, string p_remarks7, string p_remarks8, string p_remarks9, string p_remarks10
            , DataTable dtAttachment)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spDeletePURCHASE_ORDER_DETAIL mDelete = new spDeletePURCHASE_ORDER_DETAIL();
                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;

                mDelete.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mDelete.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mDelete.ExecuteQuery();
                
                
                spUpdatePURCHASE_ORDER mPurchaseMaster = new spUpdatePURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.CURRENCY_ID = p_CURRENCY_ID;
                mPurchaseMaster.REF_NO = p_REF_NO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.EXCHANGE_RATE = p_EXCHANGE_RATE;
                mPurchaseMaster.USER_ID = p_USER_ID;
                mPurchaseMaster.creditTerm = pCreditTerm;
                mPurchaseMaster.gst = pGst;
                mPurchaseMaster.gstValue= pGstValue;
                mPurchaseMaster.netAmount = pNetAMount;
                mPurchaseMaster.LAST_UPDATE = System.DateTime.Now;
                mPurchaseMaster.destinationPort = p_destinationPort;
                mPurchaseMaster.delivertyTime = p_delivertyTime;
                mPurchaseMaster.Packing = p_Packing;
                mPurchaseMaster.shippingMark = p_shippingMark;
                mPurchaseMaster.shippingTerms = p_shippingTerms;
                mPurchaseMaster.shipmentMode = p_shipmentMode;
                mPurchaseMaster.paymentTerm = p_paymentTerm;
                mPurchaseMaster.documentReq = p_documentReq;
                mPurchaseMaster.ftaCertificate = p_ftaCertificate;
                mPurchaseMaster.originCertificate = p_originCertificate;
                mPurchaseMaster.phyCertificate = p_phyCertificate;
                mPurchaseMaster.packingList = p_packingList;
                mPurchaseMaster.CommInvoice = p_CommInvoice;
                mPurchaseMaster.containerSize = p_containerSize;
                mPurchaseMaster.remarks1 = p_remarks1;
                mPurchaseMaster.remarks2 = p_remarks2;
                mPurchaseMaster.remarks3 = p_remarks3;
                mPurchaseMaster.remarks4 = p_remarks4;
                mPurchaseMaster.remarks1 = p_remarks1;
                mPurchaseMaster.remarks2 = p_remarks2;
                mPurchaseMaster.remarks3 = p_remarks3;
                mPurchaseMaster.remarks4 = p_remarks4;
                mPurchaseMaster.remarks5 = p_remarks5;
                mPurchaseMaster.remarks6 = p_remarks6;
                mPurchaseMaster.remarks7 = p_remarks7;
                mPurchaseMaster.remarks8 = p_remarks8;
                mPurchaseMaster.remarks9 = p_remarks9;
                mPurchaseMaster.remarks10 = p_remarks10;

                mPurchaseMaster.ExecuteQuery();
                                              
                spInsertPURCHASE_ORDER_DETAIL mPurchaseDetail = new spInsertPURCHASE_ORDER_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    mPurchaseDetail.PURCHASE_ORDER_ID = mPurchaseMaster.PURCHASE_ORDER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TIME_STAMP = DateTime.Now;
                    mPurchaseDetail.ExecuteQuery();    
                }

                spInsertPURCHASE_ORDER_ATTACHMENT mOrderDetailAtt = new spInsertPURCHASE_ORDER_ATTACHMENT();
                mOrderDetailAtt.Connection = mConnection;
                mOrderDetailAtt.Transaction = mTransaction;

                foreach (DataRow dr in dtAttachment.Rows)
                {
                    mOrderDetailAtt.PURCHASE_ORDER_ID = mPurchaseMaster.PURCHASE_ORDER_ID;
                    mOrderDetailAtt.PATH = dr["PATH"].ToString();
                    mOrderDetailAtt.NAME = dr["NAME"].ToString();
                    mOrderDetailAtt.DATA = (byte[])dr["DATA"];
                    mOrderDetailAtt.ExecuteQuery();
                }


                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
               // ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        /// <summary>
        /// Gets Purchase Order Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase Order Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Posting">Posting</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage  Document No as Datatable</returns>
        public DataTable SelectPurchaseOrderDocumentNo(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID,DateTime p_DOCUMENT_DATE)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER mPurchaseMaster = new spSelectPURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataSet SelectPurchaseOrderNo(long pPurchaseOrderId, int pTypeId, DateTime pDocumentDate)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER mPurchaseMaster = new spSelectPURCHASE_ORDER();
                
                   mPurchaseMaster.Connection = mConnection;
                   mPurchaseMaster.PURCHASE_ORDER_ID = pPurchaseOrderId;
                    
                    mPurchaseMaster.TYPE_ID = pTypeId;
                    mPurchaseMaster.DOCUMENT_DATE = pDocumentDate;

                return mPurchaseMaster.ExecuteDataSet();

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
      
        public DataTable SelectPurchaseOrderDocumentNo2(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID,DateTime p_DOCUMENT_DATE, byte pStatus)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER mPurchaseMaster = new spSelectPURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPurchaseOrderDetail(long p_PURCHASE_ORDER_ID,int p_DISTRIBUTOR_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER_DETAIL mPurchaseDetail = new spSelectPURCHASE_ORDER_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;                
                DataTable dt = mPurchaseDetail.ExecuteTable();
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
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPurchaseOrderDetail2(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER_DETAIL2 mPurchaseDetail = new spSelectPURCHASE_ORDER_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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

        #region Proforma Invoice

        public bool InsertProformaInvoice(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, string p_PI_NO, DateTime p_PI_DATE, DateTime p_DOCUMENT_DATE, decimal p_TOTAL_AMOUNT, int p_USER_ID, DataTable dtPIDetail)
        {
            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspInsertProformaInvoice mPurchaseMaster = new uspInsertProformaInvoice();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mPurchaseMaster.PI_NO = p_PI_NO;
                mPurchaseMaster.PI_DATE = p_PI_DATE;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_USER_ID;
                mPurchaseMaster.ExecuteQuery();

                uspInsertProformaInvoiceDetail mPurchaseDetail = new uspInsertProformaInvoiceDetail();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;
                
                foreach (DataRow dr in dtPIDetail.Rows)
                {
                    mPurchaseDetail.PROFORMA_INVOICE_ID = mPurchaseMaster.PROFORMA_INVOICE_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());                                        
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());                    
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();
                }
                mTransaction.Commit();
                return true; 
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}                
        }

        public bool UpdateProformaInvoice(long p_PROFORMA_INVOICE_ID, long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, string p_PI_NO, DateTime p_PI_DATE, decimal p_TOTAL_AMOUNT, DateTime p_DOCUMENT_DATE, int p_USER_ID, DataTable dtPIDetail)
        {
            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspUpdateProformaInvoice mPurchaseMaster = new uspUpdateProformaInvoice();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PROFORMA_INVOICE_ID = p_PROFORMA_INVOICE_ID;
                mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mPurchaseMaster.PI_NO = p_PI_NO;
                mPurchaseMaster.PI_DATE = p_PI_DATE;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_USER_ID;
                mPurchaseMaster.IS_DELETED = false;
                mPurchaseMaster.ExecuteQuery();

                uspInsertProformaInvoiceDetail mPurchaseDetail = new uspInsertProformaInvoiceDetail();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPIDetail.Rows)
                {
                    mPurchaseDetail.PROFORMA_INVOICE_ID = mPurchaseMaster.PROFORMA_INVOICE_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        public bool UpdateProformaInvoice(long p_PROFORMA_INVOICE_ID, int p_USER_ID, bool p_IS_DELETED)
        {
            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspUpdateProformaInvoice2 mPurchaseMaster = new uspUpdateProformaInvoice2();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PROFORMA_INVOICE_ID = p_PROFORMA_INVOICE_ID;
                mPurchaseMaster.USER_ID = p_USER_ID;
                mPurchaseMaster.IS_DELETED = p_IS_DELETED;
                mPurchaseMaster.ExecuteQuery();

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        public DataTable GetProformaInvoice(long p_PROFORMA_INVOICE_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetProformaInvoice mPurchaseMaster = new uspGetProformaInvoice();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PROFORMA_INVOICE_ID = p_PROFORMA_INVOICE_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataTable GetProformaInvoiceDetail(long p_PROFORMA_INVOICE_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetProformaInvoiceDetail mPurchaseMaster = new uspGetProformaInvoiceDetail();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PROFORMA_INVOICE_ID = p_PROFORMA_INVOICE_ID;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        #region GRN Q.A


        public bool UpdateGRN_QA(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE
           , int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting
           , string p_BuiltyNo, int p_UserId, int p_Principal, string p_REF_NO, string pDcNo, DateTime pDcDate, string pDriverName, string pVehicleNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);


                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.document_date = p_DOCUMENT_DATE;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.qty = int.Parse(dr["FREE_SKU"].ToString()) - int.Parse(dr["ngQty"].ToString());
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.dcNo = pDcNo;
                mPurchaseMaster.dcDate = pDcDate;
                mPurchaseMaster.driverName = pDriverName;
                mPurchaseMaster.VehicleNo = pVehicleNo;
                mPurchaseMaster.ORDER_NUMBER =Convert.ToString(p_PURCHASE_MASTER_ID);
               
                mPurchaseMaster.ExecuteQuery();

               
                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    decimal qty = 0;
                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.ngQty = int.Parse(dr["ngQty"].ToString());
                    mPurchaseDetail.remarks = dr["remarks"].ToString();
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();
                    
                    qty = mPurchaseDetail.FREE_SKU - mPurchaseDetail.ngQty;

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = qty;
                    mStockUpdate.FREE_QTY = 0;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();


                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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

        #endregion
    }
}