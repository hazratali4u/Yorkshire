using System;
using System.Data;
using SAMSDataAccessLayer.Classes;
using SAMSCommonLayer.Classes;


namespace SAMSDatabaseLayer.Classes
{
	public class spUpdateSKUS3
	{
		#region Private Members
		private string sp_Name = "spUpdateSKUS3" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private short m_UNITS_IN_CASE;
		private int m_COMPANY_ID;
		private int m_SKU_ID;
		private int m_CATEGORY_ID;
		private int m_COLOR_ID;
		
		private int m_USER_ID;
		private bool m_ISACTIVE;
		private string m_SKU_NAME;
        private string m_SKU_CODE;
        private string m_size;
		private string m_color;
		private string m_thickness;
		private string m_core;
		private string m_hotpress;
		private string m_glue;
		private string m_face;
        private string m_sanding;
        private string m_grade;
        private string m_tolerance;
		#endregion
		#region Public Properties
		public short UNITS_IN_CASE
		{
			set
			{
				m_UNITS_IN_CASE = value ;
			}
			get
			{
				return m_UNITS_IN_CASE;
			}
		}
		public int COMPANY_ID
		{
			set
			{
				m_COMPANY_ID = value ;
			}
			get
			{
				return m_COMPANY_ID;
			}
		}
		public int SKU_ID
		{
			set
			{
				m_SKU_ID = value ;
			}
			get
			{
				return m_SKU_ID;
			}
		}
		public int CATEGORY_ID
		{
			set
			{
				m_CATEGORY_ID = value ;
			}
			get
			{
				return m_CATEGORY_ID;
			}
		}
		public int COLOR_ID
		{
			set
			{
				m_COLOR_ID = value ;
			}
			get
			{
				return m_COLOR_ID;
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
		public bool ISACTIVE
		{
			set
			{
				m_ISACTIVE = value ;
			}
			get
			{
				return m_ISACTIVE;
			}
		}
		public  string SKU_NAME
		{
			set
			{
				m_SKU_NAME = value ;
			}
			get
			{
				return m_SKU_NAME;
			}
		}
        public string SKU_CODE
        {
            set { m_SKU_CODE = value; }
            get { return m_SKU_CODE; }
        }
        public  string size
		{
			set
			{
				m_size = value ;
			}
			get
			{
				return m_size;
			}
		}
		public  string color
		{
			set
			{
				m_color = value ;
			}
			get
			{
				return m_color;
			}
		}
		public  string thickness
		{
			set
			{
				m_thickness = value ;
			}
			get
			{
				return m_thickness;
			}
		}
		public  string core
		{
			set
			{
				m_core = value ;
			}
			get
			{
				return m_core;
			}
		}
		public  string hotpress
		{
			set
			{
				m_hotpress = value ;
			}
			get
			{
				return m_hotpress;
			}
		}
		public  string glue
		{
			set
			{
				m_glue = value ;
			}
			get
			{
				return m_glue;
			}
		}
		public  string face
		{
			set
			{
				m_face = value ;
			}
			get
			{
				return m_face;
			}
		}
        
        public string sanding
        {
            set
            {
                m_sanding = value;
            }
            get
            {
                return m_sanding;
            }
        }
        public string grade
        {
            set
            {
                m_grade = value;
            }
            get
            {
                return m_grade;
            }
        }
        public string tolerance
        {
            set
            {
                m_tolerance = value;
            }
            get
            {
                return m_tolerance;
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
		public spUpdateSKUS3()
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
				m_UNITS_IN_CASE= Convert.ToInt16(dr["UNITS_IN_CASE"]);
				m_COMPANY_ID= Convert.ToInt32(dr["COMPANY_ID"]);
				m_SKU_ID= Convert.ToInt32(dr["SKU_ID"]);
				m_CATEGORY_ID= Convert.ToInt32(dr["CATEGORY_ID"]);
				m_COLOR_ID= Convert.ToInt32(dr["COLOR_ID"]);
				
				m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
				m_ISACTIVE=Convert.ToBoolean(dr["ISACTIVE"]);
				m_SKU_NAME= Convert.ToString(dr["SKU_NAME"]);
				m_size= Convert.ToString(dr["size"]);
				m_color= Convert.ToString(dr["color"]);
				m_thickness= Convert.ToString(dr["thickness"]);
				m_core= Convert.ToString(dr["core"]);
				m_hotpress= Convert.ToString(dr["hotpress"]);
				m_glue= Convert.ToString(dr["glue"]);
				m_face= Convert.ToString(dr["face"]);

                m_sanding = Convert.ToString(dr["sanding"]);
                m_grade = Convert.ToString(dr["grade"]);
                m_tolerance = Convert.ToString(dr["tolerance"]);
			}
		}
		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@UNITS_IN_CASE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.SmallInt);
			if(m_UNITS_IN_CASE==Constants.ShortNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_UNITS_IN_CASE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@COMPANY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_COMPANY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_COMPANY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKU_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SKU_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKU_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CATEGORY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CATEGORY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CATEGORY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@COLOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_COLOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_COLOR_ID;
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
			parameter.ParameterName = "@ISACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKU_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SKU_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKU_NAME;
			}
			pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@SKU_CODE";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_SKU_CODE == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_SKU_CODE;
            }
            pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@size" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_size== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_size;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@color" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_color== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_color;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@thickness" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_thickness== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_thickness;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@core" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_core== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_core;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@hotpress" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_hotpress== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_hotpress;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@glue" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_glue== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_glue;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@face" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_face== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_face;
			}
			pparams.Add(parameter);


            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@sanding";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_sanding == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_sanding;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@grade";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_grade == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_grade;
            }
            pparams.Add(parameter);

            parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
            parameter.ParameterName = "@tolerance";
            parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
            if (m_tolerance == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = m_tolerance;
            }
            pparams.Add(parameter);
		}
		#endregion
	}
}
