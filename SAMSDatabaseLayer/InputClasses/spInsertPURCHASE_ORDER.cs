using System;
using System.Data;
using SAMSDataAccessLayer.Classes;
using SAMSCommonLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spInsertPURCHASE_ORDER
	{
		#region Private Members
		private string sp_Name = "spInsertPURCHASE_ORDER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private int m_DISTRIBUTOR_ID;
		private int m_PRINCIPAL_ID;
		private int m_TYPE_ID;
		private int m_CURRENCY_ID;
		private int m_USER_ID;
		private decimal m_EXCHANGE_RATE;
		private decimal m_TOTAL_AMOUNT;
		private DateTime m_DOCUMENT_DATE;
		private DateTime m_TIME_STAMP;
		private DateTime m_LAST_UPDATE;
		private decimal m_netAmount;
		private decimal m_gst;
		private decimal m_gstValue;
		private long m_PURCHASE_ORDER_ID;
		private string m_REF_NO;
		private string m_creditTerm;
		private string m_destinationPort;
		private string m_delivertyTime;
		private string m_Packing;
		private string m_shippingMark;
		private string m_remarks3;
		private string m_remarks4;
		private string m_phyCertificate;
		private string m_packingList;
		private string m_CommInvoice;
		private string m_containerSize;
		private string m_remarks1;
		private string m_remarks2;
		private string m_shippingTerms;
		private string m_shipmentMode;
		private string m_paymentTerm;
		private string m_documentReq;
		private string m_ftaCertificate;
		private string m_originCertificate;
        private string m_remarks5;
        private string m_remarks6;
        private string m_remarks7;
        private string m_remarks8;
        private string m_remarks9;
        private string m_remarks10;

		#endregion
		#region Public Properties
		public int DISTRIBUTOR_ID
		{
			set
			{
				m_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_DISTRIBUTOR_ID;
			}
		}
		public int PRINCIPAL_ID
		{
			set
			{
				m_PRINCIPAL_ID = value ;
			}
			get
			{
				return m_PRINCIPAL_ID;
			}
		}
		public int TYPE_ID
		{
			set
			{
				m_TYPE_ID = value ;
			}
			get
			{
				return m_TYPE_ID;
			}
		}
		public int CURRENCY_ID
		{
			set
			{
				m_CURRENCY_ID = value ;
			}
			get
			{
				return m_CURRENCY_ID;
			}
		}
		public int USER_ID
		{
			set
			{
				m_USER_ID = value ;
			}
			get
			{
				return m_USER_ID;
			}
		}
		public decimal  EXCHANGE_RATE
		{
			set
			{
				m_EXCHANGE_RATE = value ;
			}
			get
			{
				return m_EXCHANGE_RATE;
			}
		}
		public decimal  TOTAL_AMOUNT
		{
			set
			{
				m_TOTAL_AMOUNT = value ;
			}
			get
			{
				return m_TOTAL_AMOUNT;
			}
		}
		public DateTime DOCUMENT_DATE
		{
			set
			{
				m_DOCUMENT_DATE = value ;
			}
			get
			{
				return m_DOCUMENT_DATE;
			}
		}
		public DateTime TIME_STAMP
		{
			set
			{
				m_TIME_STAMP = value ;
			}
			get
			{
				return m_TIME_STAMP;
			}
		}
		public DateTime LAST_UPDATE
		{
			set
			{
				m_LAST_UPDATE = value ;
			}
			get
			{
				return m_LAST_UPDATE;
			}
		}
		public decimal netAmount
		{
			set
			{
				m_netAmount = value ;
			}
			get
			{
				return m_netAmount;
			}
		}
		public decimal gst
		{
			set
			{
				m_gst = value ;
			}
			get
			{
				return m_gst;
			}
		}
		public decimal gstValue
		{
			set
			{
				m_gstValue = value ;
			}
			get
			{
				return m_gstValue;
			}
		}
		public long PURCHASE_ORDER_ID
		{
			get
			{
				return m_PURCHASE_ORDER_ID;
			}
		}
		public  string REF_NO
		{
			set
			{
				m_REF_NO = value ;
			}
			get
			{
				return m_REF_NO;
			}
		}
		public  string creditTerm
		{
			set
			{
				m_creditTerm = value ;
			}
			get
			{
				return m_creditTerm;
			}
		}
		public  string destinationPort
		{
			set
			{
				m_destinationPort = value ;
			}
			get
			{
				return m_destinationPort;
			}
		}
		public  string delivertyTime
		{
			set
			{
				m_delivertyTime = value ;
			}
			get
			{
				return m_delivertyTime;
			}
		}
		public  string Packing
		{
			set
			{
				m_Packing = value ;
			}
			get
			{
				return m_Packing;
			}
		}
		public  string shippingMark
		{
			set
			{
				m_shippingMark = value ;
			}
			get
			{
				return m_shippingMark;
			}
		}
		public  string remarks3
		{
			set
			{
				m_remarks3 = value ;
			}
			get
			{
				return m_remarks3;
			}
		}
		public  string remarks4
		{
			set
			{
				m_remarks4 = value ;
			}
			get
			{
				return m_remarks4;
			}
		}
		public  string phyCertificate
		{
			set
			{
				m_phyCertificate = value ;
			}
			get
			{
				return m_phyCertificate;
			}
		}
		public  string packingList
		{
			set
			{
				m_packingList = value ;
			}
			get
			{
				return m_packingList;
			}
		}
		public  string CommInvoice
		{
			set
			{
				m_CommInvoice = value ;
			}
			get
			{
				return m_CommInvoice;
			}
		}
		public  string containerSize
		{
			set
			{
				m_containerSize = value ;
			}
			get
			{
				return m_containerSize;
			}
		}
		public  string remarks1
		{
			set
			{
				m_remarks1 = value ;
			}
			get
			{
				return m_remarks1;
			}
		}
		public  string remarks2
		{
			set
			{
				m_remarks2 = value ;
			}
			get
			{
				return m_remarks2;
			}
		}
		public  string shippingTerms
		{
			set
			{
				m_shippingTerms = value ;
			}
			get
			{
				return m_shippingTerms;
			}
		}
		public  string shipmentMode
		{
			set
			{
				m_shipmentMode = value ;
			}
			get
			{
				return m_shipmentMode;
			}
		}
		public  string paymentTerm
		{
			set
			{
				m_paymentTerm = value ;
			}
			get
			{
				return m_paymentTerm;
			}
		}
		public  string documentReq
		{
			set
			{
				m_documentReq = value ;
			}
			get
			{
				return m_documentReq;
			}
		}
		public  string ftaCertificate
		{
			set
			{
				m_ftaCertificate = value ;
			}
			get
			{
				return m_ftaCertificate;
			}
		}
		public  string originCertificate
		{
			set
			{
				m_originCertificate = value ;
			}
			get
			{
				return m_originCertificate;
			}
		}

        public string remarks5
        {
            set
            {
                m_remarks5 = value;
            }
            get
            {
                return m_remarks5;
            }
        }
        public string remarks6
        {
            set
            {
                m_remarks6 = value;
            }
            get
            {
                return m_remarks6;
            }
        }
        public string remarks7
        {
            set
            {
                m_remarks7 = value;
            }
            get
            {
                return m_remarks7;
            }
        }
        public string remarks8
        {
            set
            {
                m_remarks8 = value;
            }
            get
            {
                return m_remarks8;
            }
        }
        public string remarks9
        {
            set
            {
                m_remarks9 = value;
            }
            get
            {
                return m_remarks9;
            }
        }
        public string remarks10
        {
            set
            {
                m_remarks10 = value;
            }
            get
            {
                return m_remarks10;
            }
        }

		public IDbConnection  Connection
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
		public IDbTransaction  Transaction
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
		public spInsertPURCHASE_ORDER()
		{
		}
		#endregion
		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = sp_Name;
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_PURCHASE_ORDER_ID = (long)((IDataParameter)(cmd.Parameters["@PURCHASE_ORDER_ID"])).Value;
				return true;
			}
			catch(Exception e)
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
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
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
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
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
			catch(Exception exp)
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
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				object o;
				o = command.ExecuteScalar();


				return o.ToString();
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}
		public void FirstReader(IDataReader dr)
		{
			if(dr.Read())
			{
				m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
				m_PRINCIPAL_ID= Convert.ToInt32(dr["PRINCIPAL_ID"]);
				m_TYPE_ID= Convert.ToInt32(dr["TYPE_ID"]);
				m_CURRENCY_ID= Convert.ToInt32(dr["CURRENCY_ID"]);
				m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
				m_EXCHANGE_RATE= Convert.ToDecimal(dr["EXCHANGE_RATE"]);
				m_TOTAL_AMOUNT= Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
				m_DOCUMENT_DATE= Convert.ToDateTime(dr["DOCUMENT_DATE"]);
				m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
				m_LAST_UPDATE= Convert.ToDateTime(dr["LAST_UPDATE"]);
				m_netAmount= Convert.ToDecimal(dr["netAmount"]);
				m_gst= Convert.ToDecimal(dr["gst"]);
				m_gstValue= Convert.ToDecimal(dr["gstValue"]);
				m_PURCHASE_ORDER_ID=Convert.ToInt64(dr["PURCHASE_ORDER_ID"]);
				m_REF_NO= Convert.ToString(dr["REF_NO"]);
				m_creditTerm= Convert.ToString(dr["creditTerm"]);
				m_destinationPort= Convert.ToString(dr["destinationPort"]);
				m_delivertyTime= Convert.ToString(dr["delivertyTime"]);
				m_Packing= Convert.ToString(dr["Packing"]);
				m_shippingMark= Convert.ToString(dr["shippingMark"]);
				m_remarks3= Convert.ToString(dr["remarks3"]);
				m_remarks4= Convert.ToString(dr["remarks4"]);
				m_phyCertificate= Convert.ToString(dr["phyCertificate"]);
				m_packingList= Convert.ToString(dr["packingList"]);
				m_CommInvoice= Convert.ToString(dr["CommInvoice"]);
				m_containerSize= Convert.ToString(dr["containerSize"]);
				m_remarks1= Convert.ToString(dr["remarks1"]);
				m_remarks2= Convert.ToString(dr["remarks2"]);
				m_shippingTerms= Convert.ToString(dr["shippingTerms"]);
				m_shipmentMode= Convert.ToString(dr["shipmentMode"]);
				m_paymentTerm= Convert.ToString(dr["paymentTerm"]);
				m_documentReq= Convert.ToString(dr["documentReq"]);
				m_ftaCertificate= Convert.ToString(dr["ftaCertificate"]);
				m_originCertificate= Convert.ToString(dr["originCertificate"]);
			}
		}
		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PRINCIPAL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PRINCIPAL_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PRINCIPAL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CURRENCY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CURRENCY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CURRENCY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_USER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EXCHANGE_RATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_EXCHANGE_RATE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EXCHANGE_RATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TOTAL_AMOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TOTAL_AMOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TOTAL_AMOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DOCUMENT_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_DOCUMENT_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DOCUMENT_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIME_STAMP" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIME_STAMP==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIME_STAMP;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LAST_UPDATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LAST_UPDATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LAST_UPDATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@netAmount" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_netAmount==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_netAmount;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@gst" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_gst==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_gst;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@gstValue" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_gstValue==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_gstValue;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PURCHASE_ORDER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REF_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_REF_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REF_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@creditTerm" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_creditTerm== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_creditTerm;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@destinationPort" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_destinationPort== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_destinationPort;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@delivertyTime" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_delivertyTime== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_delivertyTime;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Packing" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_Packing== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Packing;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@shippingMark" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_shippingMark== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_shippingMark;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@remarks3" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_remarks3== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_remarks3;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@remarks4" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_remarks4== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_remarks4;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@phyCertificate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_phyCertificate== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_phyCertificate;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@packingList" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_packingList== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_packingList;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CommInvoice" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CommInvoice== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CommInvoice;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@containerSize" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_containerSize== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_containerSize;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@remarks1" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_remarks1== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_remarks1;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@remarks2" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_remarks2== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_remarks2;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@shippingTerms" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_shippingTerms== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_shippingTerms;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@shipmentMode" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_shipmentMode== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_shipmentMode;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@paymentTerm" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_paymentTerm== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_paymentTerm;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@documentReq" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_documentReq== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_documentReq;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ftaCertificate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ftaCertificate== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ftaCertificate;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@originCertificate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_originCertificate== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_originCertificate;
			}
			pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks5";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks5 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks5;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks6";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks6 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks6;
            }
            pparams.Add(parameter);
            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks7";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks7 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks7;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks8";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks8 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks8;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks9";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks9 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks9;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@remarks10";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_remarks10 == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_remarks10;
            }
            pparams.Add(parameter);

         
		}
		#endregion
	}
}
