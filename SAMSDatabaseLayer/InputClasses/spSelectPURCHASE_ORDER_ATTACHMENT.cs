using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAMSDataAccessLayer.Classes;
using SAMSCommonLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
    public class spSelectPURCHASE_ORDER_ATTACHMENT
    {
        #region Private Members
		private string sp_Name = "spSelectPURCHASE_ORDER_ATTACHMENT" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private long m_PURCHASE_ORDER_ID;
		private string m_PATH;
		private string m_FILE_NAME;
		#endregion
		#region Public Properties
        public long PURCHASE_ORDER_ID
		{
			set
			{
				m_PURCHASE_ORDER_ID = value ;
			}
			get
			{
				return m_PURCHASE_ORDER_ID;
			}
		}
		public  string PATH
		{
			set
			{
				m_PATH = value ;
			}
			get
			{
				return m_PATH;
			}
		}
		public  string FILE_NAME
		{
			set
			{
				m_FILE_NAME = value ;
			}
			get
			{
				return m_FILE_NAME;
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
        public spSelectPURCHASE_ORDER_ATTACHMENT()
		{
            m_PURCHASE_ORDER_ID = Constants.LongNullValue;
            m_FILE_NAME = null;
            m_PATH = null;
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
				m_PURCHASE_ORDER_ID= Convert.ToInt64(dr["PURCHASE_ORDER_ID"]);
				m_PATH= Convert.ToString(dr["PATH"]);
				m_FILE_NAME= Convert.ToString(dr["FILE_NAME"]);
			}
		}
		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PURCHASE_ORDER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_PURCHASE_ORDER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PURCHASE_ORDER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PATH" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_PATH== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PATH;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FILE_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FILE_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FILE_NAME;
			}
			pparams.Add(parameter);


		}
		#endregion
    }
}
