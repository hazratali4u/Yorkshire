using System;
using System.Data;
using SAMSCommonLayer.Classes;
using SAMSDataAccessLayer.Classes;
namespace SAMSDatabaseLayer.Classes
{
	public class spInsertCUSTOMER
	{
        #region Private Members
        private string sp_Name = "spInsertCUSTOMER";
        private IDbConnection m_connection;
        private IDbTransaction m_transaction;


        private int m_DISTRIBUTOR_ID;

        private int m_designationId;
       
        private DateTime m_REGDATE;
        private DateTime m_TIME_STAMP;
        private DateTime m_LASTUPDATE_DATE;
        private bool m_IS_GST_REGISTERED;
        private bool m_IS_ACTIVE;
        private long m_CUSTOMER_ID;
        private string m_CUSTOMER_CODE;
        private string m_CUSTOMER_NAME;
        private string m_ADDRESS;
        private string m_CONTACT_PERSON;
        private string m_CONTACT_NUMBER;
        private string m_EMAIL_ADDRESS;
        private decimal m_TAX_RATE;
        private string m_GST_NUMBER;
        private string m_NTN;
       
        private string m_FAX_NO;
        private string m_mobileno;
        private string m_url;

        #endregion

        #region Public Properties

        public int DISTRIBUTOR_ID
        {
            set
            {
                m_DISTRIBUTOR_ID = value;
            }
            get
            {
                return m_DISTRIBUTOR_ID;
            }
        }
       
        public int designationId
        {
            set
            {
                m_designationId = value;
            }
            get
            {
                return m_designationId;
            }
        }
       
        public DateTime REGDATE
        {
            set
            {
                m_REGDATE = value;
            }
            get
            {
                return m_REGDATE;
            }
        }

        public DateTime TIME_STAMP
        {
            set
            {
                m_TIME_STAMP = value;
            }
            get
            {
                return m_TIME_STAMP;
            }
        }

        public DateTime LASTUPDATE_DATE
        {
            set
            {
                m_LASTUPDATE_DATE = value;
            }
            get
            {
                return m_LASTUPDATE_DATE;
            }
        }

        public bool IS_GST_REGISTERED
        {
            set
            {
                m_IS_GST_REGISTERED = value;
            }
            get
            {
                return m_IS_GST_REGISTERED;
            }
        }

        public bool IS_ACTIVE
        {
            set
            {
                m_IS_ACTIVE = value;
            }
            get
            {
                return m_IS_ACTIVE;
            }
        }

        public long CUSTOMER_ID
        {
            set
            {
                m_CUSTOMER_ID = value;
            }
            get
            {
                return m_CUSTOMER_ID;
            }
        }

        public string CUSTOMER_CODE
        {
            set
            {
                m_CUSTOMER_CODE = value;
            }
            get
            {
                return m_CUSTOMER_CODE;
            }
        }

        public string CUSTOMER_NAME
        {
            set
            {
                m_CUSTOMER_NAME = value;
            }
            get
            {
                return m_CUSTOMER_NAME;
            }
        }

        public string ADDRESS
        {
            set
            {
                m_ADDRESS = value;
            }
            get
            {
                return m_ADDRESS;
            }
        }

        public string CONTACT_PERSON
        {
            set
            {
                m_CONTACT_PERSON = value;
            }
            get
            {
                return m_CONTACT_PERSON;
            }
        }

        public string CONTACT_NUMBER
        {
            set
            {
                m_CONTACT_NUMBER = value;
            }
            get
            {
                return m_CONTACT_NUMBER;
            }
        }

        public string EMAIL_ADDRESS
        {
            set
            {
                m_EMAIL_ADDRESS = value;
            }
            get
            {
                return m_EMAIL_ADDRESS;
            }
        }

        public decimal TAX_RATE
        {
            set
            {
                m_TAX_RATE = value;
            }
            get
            {
                return m_TAX_RATE;
            }
        }

        public string GST_NUMBER
        {
            set
            {
                m_GST_NUMBER = value;
            }
            get
            {
                return m_GST_NUMBER;
            }
        }

        public string NTN
        {
            set
            {
                m_NTN = value;
            }
            get
            {
                return m_NTN;
            }
        }

        public string FAX_NO
        {
            set
            {
                m_FAX_NO = value;
            }
            get
            {
                return m_FAX_NO;
            }
        }

        public string mobileno
        {
            set
            {
                m_mobileno = value;
            }
            get
            {
                return m_mobileno;
            }
        }

        public string url
        {
            set
            {
                m_url = value;
            }
            get
            {
                return m_url;
            }
        }
        public IDbConnection Connection
        {
            set
            {
                m_connection = value;
            }
            get
            {
                return m_connection;
            }
        }
        public IDbTransaction Transaction
        {
            set
            {
                m_transaction = value;
            }
            get
            {
                return m_transaction;
            }
        }
        #endregion

        #region Constructor
        public spInsertCUSTOMER()
        {


        }
        #endregion

        #region public Methods
        public bool ExecuteQuery()
        {
            try
            {
                IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertCUSTOMER";
                cmd.Connection = m_connection;
                if (m_transaction != null)
                {
                    cmd.Transaction = m_transaction;
                }
                GetParameterCollection(ref cmd);
               
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {


            }
        }


        public IDataReader ExecuteReader()
        {
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spInsertCUSTOMER";
                command.Connection = m_connection;
                if (m_transaction != null)
                {
                    command.Transaction = m_transaction;
                }
                GetParameterCollection(ref command);
                IDataReader dr = command.ExecuteReader();
                return dr;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
            }
        }

        public DataTable ExecuteTable()
        {
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spInsertCUSTOMER";
                command.Connection = m_connection;
                if (m_transaction != null)
                {
                    command.Transaction = m_transaction;
                }
                GetParameterCollection(ref command);
                IDbDataAdapter da = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
                da.SelectCommand = command;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {


            }
        }

        public string ExecuteScalar()
        {
            try
            {
                IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spInsertCUSTOMER";
                command.Connection = m_connection;
                if (m_transaction != null)
                {
                    command.Transaction = m_transaction;
                }
                GetParameterCollection(ref command);
                object o;
                o = command.ExecuteScalar();


                return o.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
            }
        }

        public void FirstReader(IDataReader dr)
        {
            if (dr.Read())
            {

                m_DISTRIBUTOR_ID = Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
                m_designationId = Convert.ToInt32(dr["designationId"]);
              

                m_REGDATE = Convert.ToDateTime(dr["REGDATE"]);
                m_TIME_STAMP = Convert.ToDateTime(dr["TIME_STAMP"]);
                m_LASTUPDATE_DATE = Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
                m_IS_GST_REGISTERED = Convert.ToBoolean(dr["IS_GST_REGISTERED"]);
                m_IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]);
                m_CUSTOMER_ID = Convert.ToInt64(dr["CUSTOMER_ID"]);
                m_CUSTOMER_CODE = Convert.ToString(dr["CUSTOMER_CODE"]);
                m_CUSTOMER_NAME = Convert.ToString(dr["CUSTOMER_NAME"]);
                m_ADDRESS = Convert.ToString(dr["ADDRESS"]);
                m_CONTACT_PERSON = Convert.ToString(dr["CONTACT_PERSON"]);
                m_CONTACT_NUMBER = Convert.ToString(dr["CONTACT_NUMBER"]);
                m_EMAIL_ADDRESS = Convert.ToString(dr["EMAIL_ADDRESS"]);
                m_TAX_RATE = Convert.ToDecimal(dr["TAX_RATE"]);
                m_GST_NUMBER = Convert.ToString(dr["GST_NUMBER"]);
                m_NTN = Convert.ToString(dr["NTN"]);
           
                m_FAX_NO = Convert.ToString(dr["FAX_NO"]);
                m_mobileno = Convert.ToString(dr["mobileno"]);
                m_url = Convert.ToString(dr["url"]);
            }
        }

        public void GetParameterCollection(ref IDbCommand cmd)
        {
            IDataParameterCollection pparams = cmd.Parameters;
            IDataParameter parameter;


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@DISTRIBUTOR_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_DISTRIBUTOR_ID == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_DISTRIBUTOR_ID;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@designationId";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
            if (m_designationId == Constants.IntNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_designationId;
            }
            pparams.Add(parameter);




            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@REGDATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_REGDATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_REGDATE;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TIME_STAMP";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_TIME_STAMP == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_TIME_STAMP;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@LASTUPDATE_DATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
            if (m_LASTUPDATE_DATE == Constants.DateNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_LASTUPDATE_DATE;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_GST_REGISTERED";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = m_IS_GST_REGISTERED;
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@IS_ACTIVE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
            parameter.Value = m_IS_ACTIVE;
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_ID";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
            if (m_CUSTOMER_ID == Constants.LongNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CUSTOMER_ID;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_CUSTOMER_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CUSTOMER_CODE;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CUSTOMER_NAME";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_CUSTOMER_NAME == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CUSTOMER_NAME;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_ADDRESS;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CONTACT_PERSON";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_CONTACT_PERSON == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CONTACT_PERSON;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@CONTACT_NUMBER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_CONTACT_NUMBER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_CONTACT_NUMBER;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@EMAIL_ADDRESS";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_EMAIL_ADDRESS == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_EMAIL_ADDRESS;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@TAX_RATE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
            if (m_TAX_RATE == Constants.DecimalNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_TAX_RATE;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@GST_NUMBER";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_GST_NUMBER == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_GST_NUMBER;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@NTN";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_NTN == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_NTN;
            }
            pparams.Add(parameter);

            

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@FAX_NO";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_FAX_NO == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_FAX_NO;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@mobileno";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_mobileno == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_mobileno;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@url";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_url == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_url;
            }
            pparams.Add(parameter);

        }

        #endregion
	}
}
