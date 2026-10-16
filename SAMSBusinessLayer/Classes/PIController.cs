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
    public class PIController
    {
        #region Constructor

        /// <summary>
        /// Constructor for PIController
        /// </summary>
        public PIController()
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

        public DataTable GetPIExpenseView(int p_DISTRIBUTOR_ID, int p_PageSize, int p_PageNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetPIExpenseView mStockUpdate = new uspGetPIExpenseView();
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

        public DataTable GetPIExpense(long p_PI_EXPENSE_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetPIExpense mPurchaseMaster = new uspGetPIExpense();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PI_EXPENSE_ID = p_PI_EXPENSE_ID;
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

        #endregion

        #region Insert, Update

        public bool InsertPIExpense(long p_PI_ID, int p_DISTRIBUTOR_ID, DateTime p_DOCUMENT_DATE, decimal p_TOTAL_AMOUNT, string p_REMARKS, int p_USER_ID, DataTable dtExpenseDetail) 
		{
			try
			{                 
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspInsertPIExpense mExpense = new uspInsertPIExpense();
                mExpense.Connection = mConnection;
                mExpense.Transaction = mTransaction;
                mExpense.PI_ID = p_PI_ID;
                mExpense.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mExpense.DOCUMENT_DATE = p_DOCUMENT_DATE;                
                mExpense.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mExpense.REMARKS = p_REMARKS;
                mExpense.USER_ID = p_USER_ID;
                mExpense.ExecuteQuery();

                uspInsertPIExpenseDetail mExpenseDetail = new uspInsertPIExpenseDetail();
                mExpenseDetail.Connection = mConnection;
                mExpenseDetail.Transaction = mTransaction;
                
                foreach (DataRow dr in dtExpenseDetail.Rows)
                {
                    mExpenseDetail.PI_EXPENSE_ID = mExpense.PI_EXPENSE_ID;
                    mExpenseDetail.ACCOUNT_HEAD_ID = int.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                    mExpenseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mExpenseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mExpenseDetail.ExecuteQuery();
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

        public bool UpdatePIExpense(long p_PI_EXPENSE_ID, long p_PI_ID, int p_DISTRIBUTOR_ID,decimal p_TOTAL_AMOUNT, string p_REMARKS, int p_USER_ID, DataTable dtExpenseDetail)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspUpdatePIExpense mExpense = new uspUpdatePIExpense();
                mExpense.Connection = mConnection;
                mExpense.Transaction = mTransaction;
                mExpense.PI_EXPENSE_ID = p_PI_EXPENSE_ID;
                mExpense.PI_ID = p_PI_ID;
                mExpense.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mExpense.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mExpense.REMARKS = p_REMARKS;
                mExpense.USER_ID = p_USER_ID;
                mExpense.ExecuteQuery();

                uspInsertPIExpenseDetail mExpenseDetail = new uspInsertPIExpenseDetail();
                mExpenseDetail.Connection = mConnection;
                mExpenseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtExpenseDetail.Rows)
                {
                    mExpenseDetail.PI_EXPENSE_ID = mExpense.PI_EXPENSE_ID;
                    mExpenseDetail.ACCOUNT_HEAD_ID = int.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                    mExpenseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mExpenseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mExpenseDetail.ExecuteQuery();
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

        public bool UpdatePIExpense2(long p_PI_EXPENSE_ID, int p_USER_ID, bool p_IS_DELETED)
        {
            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                uspUpdatePIExpense2 mPurchaseMaster = new uspUpdatePIExpense2();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PI_EXPENSE_ID = p_PI_EXPENSE_ID;
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

        #endregion

        #endregion
    }
}