using System;
using System.Data;
using SAMSDataAccessLayer.Classes;
using SAMSCommonLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spUpdateVENDOR
	{
		#region Private Members
		private string sp_Name = "spUpdateVENDOR" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private int m_VENDOR_ID;
        private short m_VENDOR_TYPE;
		private DateTime m_IncorporationDate;
		private DateTime m_LASTUPDATE_DATE;
		private DateTime m_TIME_STAMP;
		private bool m_IS_ACTIVE;
		private bool m_IS_DELETED;
		private string m_VENDOR_NAME;
		private string m_firmRegisterNo;
		private string m_registerComapnyName;
		private string m_f_Address;
		private string m_f_ContactNo;
		private string m_f_Fax;
		private string m_otherDetail;
		private string m_tradeExperience;
		private string m_certificateDetail;
		private string m_Asset;
		private string m_goodsManufactue;
		private string m_plantCapacity;
		private string m_othersAccountDetail;
		private string m_bI_Code;
		private string m_bI_Address;
		private string m_bI_ContactNo;
		private string m_bI_Fax;
		private string m_bI_Email;
		private string m_exportDetail;
		private string m_sa_ContactNo;
		private string m_sa_Email;
		private string m_sa_Skype;
		private string m_bI_Name;
		private string m_bI_Title;
		private string m_bI_No;
		private string m_f_Email;
		private string m_r_Name;
		private string m_r_ContactNo;
		private string m_r_Email;
		private string m_r_Skype;
		private string m_sa_Name;
		#endregion
		#region Public Properties
		public int VENDOR_ID
		{
			set
			{
				m_VENDOR_ID = value ;
			}
			get
			{
				return m_VENDOR_ID;
			}
		}
        public short VENDOR_TYPE
        {
            get
            {
                return m_VENDOR_TYPE;
            }
            set
            {
                m_VENDOR_TYPE = value;
            }
        }
		public DateTime IncorporationDate
		{
			set
			{
				m_IncorporationDate = value ;
			}
			get
			{
				return m_IncorporationDate;
			}
		}
		public DateTime LASTUPDATE_DATE
		{
			set
			{
				m_LASTUPDATE_DATE = value ;
			}
			get
			{
				return m_LASTUPDATE_DATE;
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
		public bool IS_ACTIVE
		{
			set
			{
				m_IS_ACTIVE = value ;
			}
			get
			{
				return m_IS_ACTIVE;
			}
		}
		public bool IS_DELETED
		{
			set
			{
				m_IS_DELETED = value ;
			}
			get
			{
				return m_IS_DELETED;
			}
		}
		public  string VENDOR_NAME
		{
			set
			{
				m_VENDOR_NAME = value ;
			}
			get
			{
				return m_VENDOR_NAME;
			}
		}
		public  string firmRegisterNo
		{
			set
			{
				m_firmRegisterNo = value ;
			}
			get
			{
				return m_firmRegisterNo;
			}
		}
		public  string registerComapnyName
		{
			set
			{
				m_registerComapnyName = value ;
			}
			get
			{
				return m_registerComapnyName;
			}
		}
		public  string f_Address
		{
			set
			{
				m_f_Address = value ;
			}
			get
			{
				return m_f_Address;
			}
		}
		public  string f_ContactNo
		{
			set
			{
				m_f_ContactNo = value ;
			}
			get
			{
				return m_f_ContactNo;
			}
		}
		public  string f_Fax
		{
			set
			{
				m_f_Fax = value ;
			}
			get
			{
				return m_f_Fax;
			}
		}
		public  string otherDetail
		{
			set
			{
				m_otherDetail = value ;
			}
			get
			{
				return m_otherDetail;
			}
		}
		public  string tradeExperience
		{
			set
			{
				m_tradeExperience = value ;
			}
			get
			{
				return m_tradeExperience;
			}
		}
		public  string certificateDetail
		{
			set
			{
				m_certificateDetail = value ;
			}
			get
			{
				return m_certificateDetail;
			}
		}
		public  string Asset
		{
			set
			{
				m_Asset = value ;
			}
			get
			{
				return m_Asset;
			}
		}
		public  string goodsManufactue
		{
			set
			{
				m_goodsManufactue = value ;
			}
			get
			{
				return m_goodsManufactue;
			}
		}
		public  string plantCapacity
		{
			set
			{
				m_plantCapacity = value ;
			}
			get
			{
				return m_plantCapacity;
			}
		}
		public  string othersAccountDetail
		{
			set
			{
				m_othersAccountDetail = value ;
			}
			get
			{
				return m_othersAccountDetail;
			}
		}
		public  string bI_Code
		{
			set
			{
				m_bI_Code = value ;
			}
			get
			{
				return m_bI_Code;
			}
		}
		public  string bI_Address
		{
			set
			{
				m_bI_Address = value ;
			}
			get
			{
				return m_bI_Address;
			}
		}
		public  string bI_ContactNo
		{
			set
			{
				m_bI_ContactNo = value ;
			}
			get
			{
				return m_bI_ContactNo;
			}
		}
		public  string bI_Fax
		{
			set
			{
				m_bI_Fax = value ;
			}
			get
			{
				return m_bI_Fax;
			}
		}
		public  string bI_Email
		{
			set
			{
				m_bI_Email = value ;
			}
			get
			{
				return m_bI_Email;
			}
		}
		public  string exportDetail
		{
			set
			{
				m_exportDetail = value ;
			}
			get
			{
				return m_exportDetail;
			}
		}
		public  string sa_ContactNo
		{
			set
			{
				m_sa_ContactNo = value ;
			}
			get
			{
				return m_sa_ContactNo;
			}
		}
		public  string sa_Email
		{
			set
			{
				m_sa_Email = value ;
			}
			get
			{
				return m_sa_Email;
			}
		}
		public  string sa_Skype
		{
			set
			{
				m_sa_Skype = value ;
			}
			get
			{
				return m_sa_Skype;
			}
		}
		public  string bI_Name
		{
			set
			{
				m_bI_Name = value ;
			}
			get
			{
				return m_bI_Name;
			}
		}
		public  string bI_Title
		{
			set
			{
				m_bI_Title = value ;
			}
			get
			{
				return m_bI_Title;
			}
		}
		public  string bI_No
		{
			set
			{
				m_bI_No = value ;
			}
			get
			{
				return m_bI_No;
			}
		}
		public  string f_Email
		{
			set
			{
				m_f_Email = value ;
			}
			get
			{
				return m_f_Email;
			}
		}
		public  string r_Name
		{
			set
			{
				m_r_Name = value ;
			}
			get
			{
				return m_r_Name;
			}
		}
		public  string r_ContactNo
		{
			set
			{
				m_r_ContactNo = value ;
			}
			get
			{
				return m_r_ContactNo;
			}
		}
		public  string r_Email
		{
			set
			{
				m_r_Email = value ;
			}
			get
			{
				return m_r_Email;
			}
		}
		public  string r_Skype
		{
			set
			{
				m_r_Skype = value ;
			}
			get
			{
				return m_r_Skype;
			}
		}
		public  string sa_Name
		{
			set
			{
				m_sa_Name = value ;
			}
			get
			{
				return m_sa_Name;
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
		public spUpdateVENDOR()
		{
            m_TIME_STAMP = Constants.DateNullValue;
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
				m_VENDOR_ID= Convert.ToInt32(dr["VENDOR_ID"]);
				m_IncorporationDate= Convert.ToDateTime(dr["IncorporationDate"]);
				m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
				m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
				m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
				m_IS_DELETED=Convert.ToBoolean(dr["IS_DELETED"]);
				m_VENDOR_NAME= Convert.ToString(dr["VENDOR_NAME"]);
				m_firmRegisterNo= Convert.ToString(dr["firmRegisterNo"]);
				m_registerComapnyName= Convert.ToString(dr["registerComapnyName"]);
				m_f_Address= Convert.ToString(dr["f_Address"]);
				m_f_ContactNo= Convert.ToString(dr["f_ContactNo"]);
				m_f_Fax= Convert.ToString(dr["f_Fax"]);
				m_otherDetail= Convert.ToString(dr["otherDetail"]);
				m_tradeExperience= Convert.ToString(dr["tradeExperience"]);
				m_certificateDetail= Convert.ToString(dr["certificateDetail"]);
				m_Asset= Convert.ToString(dr["Asset"]);
				m_goodsManufactue= Convert.ToString(dr["goodsManufactue"]);
				m_plantCapacity= Convert.ToString(dr["plantCapacity"]);
				m_othersAccountDetail= Convert.ToString(dr["othersAccountDetail"]);
				m_bI_Code= Convert.ToString(dr["bI_Code"]);
				m_bI_Address= Convert.ToString(dr["bI_Address"]);
				m_bI_ContactNo= Convert.ToString(dr["bI_ContactNo"]);
				m_bI_Fax= Convert.ToString(dr["bI_Fax"]);
				m_bI_Email= Convert.ToString(dr["bI_Email"]);
				m_exportDetail= Convert.ToString(dr["exportDetail"]);
				m_sa_ContactNo= Convert.ToString(dr["sa_ContactNo"]);
				m_sa_Email= Convert.ToString(dr["sa_Email"]);
				m_sa_Skype= Convert.ToString(dr["sa_Skype"]);
				m_bI_Name= Convert.ToString(dr["bI_Name"]);
				m_bI_Title= Convert.ToString(dr["bI_Title"]);
				m_bI_No= Convert.ToString(dr["bI_No"]);
				m_f_Email= Convert.ToString(dr["f_Email"]);
				m_r_Name= Convert.ToString(dr["r_Name"]);
				m_r_ContactNo= Convert.ToString(dr["r_ContactNo"]);
				m_r_Email= Convert.ToString(dr["r_Email"]);
				m_r_Skype= Convert.ToString(dr["r_Skype"]);
				m_sa_Name= Convert.ToString(dr["sa_Name"]);

                m_VENDOR_TYPE = Convert.ToInt16(dr["VENDOR_TYPE"]);
			}
		}
		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@VENDOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_VENDOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_VENDOR_ID;
			}
			pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@VENDOR_TYPE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.TinyInt);
            if (m_VENDOR_TYPE == Constants.ShortNullValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_VENDOR_TYPE;
            }
            pparams.Add(parameter);

			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IncorporationDate" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_IncorporationDate==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IncorporationDate;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LASTUPDATE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LASTUPDATE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LASTUPDATE_DATE;
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
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_DELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@VENDOR_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_VENDOR_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_VENDOR_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@firmRegisterNo" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_firmRegisterNo== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_firmRegisterNo;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@registerComapnyName" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_registerComapnyName== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_registerComapnyName;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@f_Address" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_f_Address== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_f_Address;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@f_ContactNo" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_f_ContactNo== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_f_ContactNo;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@f_Fax" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_f_Fax== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_f_Fax;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@otherDetail" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_otherDetail== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_otherDetail;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@tradeExperience" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_tradeExperience== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_tradeExperience;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@certificateDetail" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_certificateDetail== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_certificateDetail;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Asset" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_Asset== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Asset;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@goodsManufactue" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_goodsManufactue== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_goodsManufactue;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@plantCapacity" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_plantCapacity== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_plantCapacity;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@othersAccountDetail" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_othersAccountDetail== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_othersAccountDetail;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Code" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Code== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Code;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Address" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Address== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Address;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_ContactNo" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_ContactNo== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_ContactNo;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Fax" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Fax== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Fax;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Email" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Email== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Email;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@exportDetail" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_exportDetail== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_exportDetail;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@sa_ContactNo" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_sa_ContactNo== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_sa_ContactNo;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@sa_Email" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_sa_Email== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_sa_Email;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@sa_Skype" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_sa_Skype== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_sa_Skype;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Name" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Name== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Name;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_Title" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_Title== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_Title;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@bI_No" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_bI_No== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_bI_No;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@f_Email" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_f_Email== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_f_Email;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@r_Name" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_r_Name== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_r_Name;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@r_ContactNo" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_r_ContactNo== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_r_ContactNo;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@r_Email" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_r_Email== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_r_Email;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@r_Skype" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_r_Skype== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_r_Skype;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@sa_Name" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_sa_Name== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_sa_Name;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
