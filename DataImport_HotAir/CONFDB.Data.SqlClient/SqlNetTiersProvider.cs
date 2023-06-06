
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using CONFDB.Entities;
using CONFDB.Data;
using CONFDB.Data.Bases;

#endregion

namespace CONFDB.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : CONFDB.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "AccessTypeProvider"
			
		private SqlAccessTypeProvider innerSqlAccessTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AccessType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccessTypeProviderBase AccessTypeProvider
		{
			get
			{
				if (innerSqlAccessTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccessTypeProvider == null)
						{
							this.innerSqlAccessTypeProvider = new SqlAccessTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccessTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccessTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccessTypeProvider SqlAccessTypeProvider
		{
			get {return AccessTypeProvider as SqlAccessTypeProvider;}
		}
		
		#endregion
		
		
		#region "RecordingProvider"
			
		private SqlRecordingProvider innerSqlRecordingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Recording"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RecordingProviderBase RecordingProvider
		{
			get
			{
				if (innerSqlRecordingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRecordingProvider == null)
						{
							this.innerSqlRecordingProvider = new SqlRecordingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRecordingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRecordingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRecordingProvider SqlRecordingProvider
		{
			get {return RecordingProvider as SqlRecordingProvider;}
		}
		
		#endregion
		
		
		#region "RecordingParticipantUsageProvider"
			
		private SqlRecordingParticipantUsageProvider innerSqlRecordingParticipantUsageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RecordingParticipantUsage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RecordingParticipantUsageProviderBase RecordingParticipantUsageProvider
		{
			get
			{
				if (innerSqlRecordingParticipantUsageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRecordingParticipantUsageProvider == null)
						{
							this.innerSqlRecordingParticipantUsageProvider = new SqlRecordingParticipantUsageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRecordingParticipantUsageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRecordingParticipantUsageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRecordingParticipantUsageProvider SqlRecordingParticipantUsageProvider
		{
			get {return RecordingParticipantUsageProvider as SqlRecordingParticipantUsageProvider;}
		}
		
		#endregion
		
		
		#region "RatingTypeProvider"
			
		private SqlRatingTypeProvider innerSqlRatingTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RatingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RatingTypeProviderBase RatingTypeProvider
		{
			get
			{
				if (innerSqlRatingTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRatingTypeProvider == null)
						{
							this.innerSqlRatingTypeProvider = new SqlRatingTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRatingTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRatingTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRatingTypeProvider SqlRatingTypeProvider
		{
			get {return RatingTypeProvider as SqlRatingTypeProvider;}
		}
		
		#endregion
		
		
		#region "PromptSetProvider"
			
		private SqlPromptSetProvider innerSqlPromptSetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PromptSet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PromptSetProviderBase PromptSetProvider
		{
			get
			{
				if (innerSqlPromptSetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPromptSetProvider == null)
						{
							this.innerSqlPromptSetProvider = new SqlPromptSetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPromptSetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPromptSetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPromptSetProvider SqlPromptSetProvider
		{
			get {return PromptSetProvider as SqlPromptSetProvider;}
		}
		
		#endregion
		
		
		#region "RoleProvider"
			
		private SqlRoleProvider innerSqlRoleProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Role"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RoleProviderBase RoleProvider
		{
			get
			{
				if (innerSqlRoleProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRoleProvider == null)
						{
							this.innerSqlRoleProvider = new SqlRoleProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRoleProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRoleProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRoleProvider SqlRoleProvider
		{
			get {return RoleProvider as SqlRoleProvider;}
		}
		
		#endregion
		
		
		#region "SeeVoghMeetingTrackerProvider"
			
		private SqlSeeVoghMeetingTrackerProvider innerSqlSeeVoghMeetingTrackerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SeeVoghMeetingTracker"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SeeVoghMeetingTrackerProviderBase SeeVoghMeetingTrackerProvider
		{
			get
			{
				if (innerSqlSeeVoghMeetingTrackerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSeeVoghMeetingTrackerProvider == null)
						{
							this.innerSqlSeeVoghMeetingTrackerProvider = new SqlSeeVoghMeetingTrackerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSeeVoghMeetingTrackerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSeeVoghMeetingTrackerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSeeVoghMeetingTrackerProvider SqlSeeVoghMeetingTrackerProvider
		{
			get {return SeeVoghMeetingTrackerProvider as SqlSeeVoghMeetingTrackerProvider;}
		}
		
		#endregion
		
		
		#region "CountryProvider"
			
		private SqlCountryProvider innerSqlCountryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Country"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryProviderBase CountryProvider
		{
			get
			{
				if (innerSqlCountryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountryProvider == null)
						{
							this.innerSqlCountryProvider = new SqlCountryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCountryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountryProvider SqlCountryProvider
		{
			get {return CountryProvider as SqlCountryProvider;}
		}
		
		#endregion
		
		
		#region "CurrencyProvider"
			
		private SqlCurrencyProvider innerSqlCurrencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Currency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrencyProviderBase CurrencyProvider
		{
			get
			{
				if (innerSqlCurrencyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurrencyProvider == null)
						{
							this.innerSqlCurrencyProvider = new SqlCurrencyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurrencyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCurrencyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurrencyProvider SqlCurrencyProvider
		{
			get {return CurrencyProvider as SqlCurrencyProvider;}
		}
		
		#endregion
		
		
		#region "SystemExtensionProvider"
			
		private SqlSystemExtensionProvider innerSqlSystemExtensionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SystemExtension"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SystemExtensionProviderBase SystemExtensionProvider
		{
			get
			{
				if (innerSqlSystemExtensionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSystemExtensionProvider == null)
						{
							this.innerSqlSystemExtensionProvider = new SqlSystemExtensionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSystemExtensionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSystemExtensionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSystemExtensionProvider SqlSystemExtensionProvider
		{
			get {return SystemExtensionProvider as SqlSystemExtensionProvider;}
		}
		
		#endregion
		
		
		#region "StateProvider"
			
		private SqlStateProvider innerSqlStateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="State"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StateProviderBase StateProvider
		{
			get
			{
				if (innerSqlStateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStateProvider == null)
						{
							this.innerSqlStateProvider = new SqlStateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlStateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStateProvider SqlStateProvider
		{
			get {return StateProvider as SqlStateProvider;}
		}
		
		#endregion
		
		
		#region "ProductTypeProvider"
			
		private SqlProductTypeProvider innerSqlProductTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductTypeProviderBase ProductTypeProvider
		{
			get
			{
				if (innerSqlProductTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductTypeProvider == null)
						{
							this.innerSqlProductTypeProvider = new SqlProductTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductTypeProvider SqlProductTypeProvider
		{
			get {return ProductTypeProvider as SqlProductTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProductRateTypeProvider"
			
		private SqlProductRateTypeProvider innerSqlProductRateTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductRateType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductRateTypeProviderBase ProductRateTypeProvider
		{
			get
			{
				if (innerSqlProductRateTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductRateTypeProvider == null)
						{
							this.innerSqlProductRateTypeProvider = new SqlProductRateTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductRateTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductRateTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductRateTypeProvider SqlProductRateTypeProvider
		{
			get {return ProductRateTypeProvider as SqlProductRateTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProductRateIntervalProvider"
			
		private SqlProductRateIntervalProvider innerSqlProductRateIntervalProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductRateInterval"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductRateIntervalProviderBase ProductRateIntervalProvider
		{
			get
			{
				if (innerSqlProductRateIntervalProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductRateIntervalProvider == null)
						{
							this.innerSqlProductRateIntervalProvider = new SqlProductRateIntervalProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductRateIntervalProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductRateIntervalProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductRateIntervalProvider SqlProductRateIntervalProvider
		{
			get {return ProductRateIntervalProvider as SqlProductRateIntervalProvider;}
		}
		
		#endregion
		
		
		#region "ModeratorXtimeUserProvider"
			
		private SqlModeratorXtimeUserProvider innerSqlModeratorXtimeUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ModeratorXtimeUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ModeratorXtimeUserProviderBase ModeratorXtimeUserProvider
		{
			get
			{
				if (innerSqlModeratorXtimeUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlModeratorXtimeUserProvider == null)
						{
							this.innerSqlModeratorXtimeUserProvider = new SqlModeratorXtimeUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlModeratorXtimeUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlModeratorXtimeUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlModeratorXtimeUserProvider SqlModeratorXtimeUserProvider
		{
			get {return ModeratorXtimeUserProvider as SqlModeratorXtimeUserProvider;}
		}
		
		#endregion
		
		
		#region "LeadStageProvider"
			
		private SqlLeadStageProvider innerSqlLeadStageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadStage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadStageProviderBase LeadStageProvider
		{
			get
			{
				if (innerSqlLeadStageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadStageProvider == null)
						{
							this.innerSqlLeadStageProvider = new SqlLeadStageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadStageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadStageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadStageProvider SqlLeadStageProvider
		{
			get {return LeadStageProvider as SqlLeadStageProvider;}
		}
		
		#endregion
		
		
		#region "LeadSourceProvider"
			
		private SqlLeadSourceProvider innerSqlLeadSourceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadSource"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadSourceProviderBase LeadSourceProvider
		{
			get
			{
				if (innerSqlLeadSourceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadSourceProvider == null)
						{
							this.innerSqlLeadSourceProvider = new SqlLeadSourceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadSourceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadSourceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadSourceProvider SqlLeadSourceProvider
		{
			get {return LeadSourceProvider as SqlLeadSourceProvider;}
		}
		
		#endregion
		
		
		#region "LeadProductProvider"
			
		private SqlLeadProductProvider innerSqlLeadProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadProductProviderBase LeadProductProvider
		{
			get
			{
				if (innerSqlLeadProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadProductProvider == null)
						{
							this.innerSqlLeadProductProvider = new SqlLeadProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadProductProvider SqlLeadProductProvider
		{
			get {return LeadProductProvider as SqlLeadProductProvider;}
		}
		
		#endregion
		
		
		#region "OmnoviaHostedArchiveProvider"
			
		private SqlOmnoviaHostedArchiveProvider innerSqlOmnoviaHostedArchiveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OmnoviaHostedArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OmnoviaHostedArchiveProviderBase OmnoviaHostedArchiveProvider
		{
			get
			{
				if (innerSqlOmnoviaHostedArchiveProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOmnoviaHostedArchiveProvider == null)
						{
							this.innerSqlOmnoviaHostedArchiveProvider = new SqlOmnoviaHostedArchiveProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOmnoviaHostedArchiveProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOmnoviaHostedArchiveProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOmnoviaHostedArchiveProvider SqlOmnoviaHostedArchiveProvider
		{
			get {return OmnoviaHostedArchiveProvider as SqlOmnoviaHostedArchiveProvider;}
		}
		
		#endregion
		
		
		#region "OmnoviaHostedArchiveParticipantProvider"
			
		private SqlOmnoviaHostedArchiveParticipantProvider innerSqlOmnoviaHostedArchiveParticipantProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OmnoviaHostedArchiveParticipant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OmnoviaHostedArchiveParticipantProviderBase OmnoviaHostedArchiveParticipantProvider
		{
			get
			{
				if (innerSqlOmnoviaHostedArchiveParticipantProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOmnoviaHostedArchiveParticipantProvider == null)
						{
							this.innerSqlOmnoviaHostedArchiveParticipantProvider = new SqlOmnoviaHostedArchiveParticipantProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOmnoviaHostedArchiveParticipantProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOmnoviaHostedArchiveParticipantProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOmnoviaHostedArchiveParticipantProvider SqlOmnoviaHostedArchiveParticipantProvider
		{
			get {return OmnoviaHostedArchiveParticipantProvider as SqlOmnoviaHostedArchiveParticipantProvider;}
		}
		
		#endregion
		
		
		#region "ProductProvider"
			
		private SqlProductProvider innerSqlProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProviderBase ProductProvider
		{
			get
			{
				if (innerSqlProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductProvider == null)
						{
							this.innerSqlProductProvider = new SqlProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductProvider SqlProductProvider
		{
			get {return ProductProvider as SqlProductProvider;}
		}
		
		#endregion
		
		
		#region "ProductRateProvider"
			
		private SqlProductRateProvider innerSqlProductRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductRateProviderBase ProductRateProvider
		{
			get
			{
				if (innerSqlProductRateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductRateProvider == null)
						{
							this.innerSqlProductRateProvider = new SqlProductRateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductRateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductRateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductRateProvider SqlProductRateProvider
		{
			get {return ProductRateProvider as SqlProductRateProvider;}
		}
		
		#endregion
		
		
		#region "PrevInvoicesProvider"
			
		private SqlPrevInvoicesProvider innerSqlPrevInvoicesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PrevInvoices"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PrevInvoicesProviderBase PrevInvoicesProvider
		{
			get
			{
				if (innerSqlPrevInvoicesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPrevInvoicesProvider == null)
						{
							this.innerSqlPrevInvoicesProvider = new SqlPrevInvoicesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPrevInvoicesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPrevInvoicesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPrevInvoicesProvider SqlPrevInvoicesProvider
		{
			get {return PrevInvoicesProvider as SqlPrevInvoicesProvider;}
		}
		
		#endregion
		
		
		#region "OmnoviaMp4RequestProvider"
			
		private SqlOmnoviaMp4RequestProvider innerSqlOmnoviaMp4RequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OmnoviaMp4Request"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OmnoviaMp4RequestProviderBase OmnoviaMp4RequestProvider
		{
			get
			{
				if (innerSqlOmnoviaMp4RequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOmnoviaMp4RequestProvider == null)
						{
							this.innerSqlOmnoviaMp4RequestProvider = new SqlOmnoviaMp4RequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOmnoviaMp4RequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOmnoviaMp4RequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOmnoviaMp4RequestProvider SqlOmnoviaMp4RequestProvider
		{
			get {return OmnoviaMp4RequestProvider as SqlOmnoviaMp4RequestProvider;}
		}
		
		#endregion
		
		
		#region "SystemExtensionLabelProvider"
			
		private SqlSystemExtensionLabelProvider innerSqlSystemExtensionLabelProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SystemExtensionLabel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SystemExtensionLabelProviderBase SystemExtensionLabelProvider
		{
			get
			{
				if (innerSqlSystemExtensionLabelProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSystemExtensionLabelProvider == null)
						{
							this.innerSqlSystemExtensionLabelProvider = new SqlSystemExtensionLabelProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSystemExtensionLabelProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSystemExtensionLabelProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSystemExtensionLabelProvider SqlSystemExtensionLabelProvider
		{
			get {return SystemExtensionLabelProvider as SqlSystemExtensionLabelProvider;}
		}
		
		#endregion
		
		
		#region "VerticalProvider"
			
		private SqlVerticalProvider innerSqlVerticalProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vertical"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VerticalProviderBase VerticalProvider
		{
			get
			{
				if (innerSqlVerticalProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVerticalProvider == null)
						{
							this.innerSqlVerticalProvider = new SqlVerticalProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVerticalProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVerticalProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVerticalProvider SqlVerticalProvider
		{
			get {return VerticalProvider as SqlVerticalProvider;}
		}
		
		#endregion
		
		
		#region "SystemSettingsProvider"
			
		private SqlSystemSettingsProvider innerSqlSystemSettingsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SystemSettings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SystemSettingsProviderBase SystemSettingsProvider
		{
			get
			{
				if (innerSqlSystemSettingsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSystemSettingsProvider == null)
						{
							this.innerSqlSystemSettingsProvider = new SqlSystemSettingsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSystemSettingsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSystemSettingsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSystemSettingsProvider SqlSystemSettingsProvider
		{
			get {return SystemSettingsProvider as SqlSystemSettingsProvider;}
		}
		
		#endregion
		
		
		#region "TicketProductProvider"
			
		private SqlTicketProductProvider innerSqlTicketProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketProductProviderBase TicketProductProvider
		{
			get
			{
				if (innerSqlTicketProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketProductProvider == null)
						{
							this.innerSqlTicketProductProvider = new SqlTicketProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketProductProvider SqlTicketProductProvider
		{
			get {return TicketProductProvider as SqlTicketProductProvider;}
		}
		
		#endregion
		
		
		#region "TicketStatusProvider"
			
		private SqlTicketStatusProvider innerSqlTicketStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketStatusProviderBase TicketStatusProvider
		{
			get
			{
				if (innerSqlTicketStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketStatusProvider == null)
						{
							this.innerSqlTicketStatusProvider = new SqlTicketStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketStatusProvider SqlTicketStatusProvider
		{
			get {return TicketStatusProvider as SqlTicketStatusProvider;}
		}
		
		#endregion
		
		
		#region "TicketPriorityProvider"
			
		private SqlTicketPriorityProvider innerSqlTicketPriorityProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketPriority"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketPriorityProviderBase TicketPriorityProvider
		{
			get
			{
				if (innerSqlTicketPriorityProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketPriorityProvider == null)
						{
							this.innerSqlTicketPriorityProvider = new SqlTicketPriorityProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketPriorityProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketPriorityProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketPriorityProvider SqlTicketPriorityProvider
		{
			get {return TicketPriorityProvider as SqlTicketPriorityProvider;}
		}
		
		#endregion
		
		
		#region "UserProvider"
			
		private SqlUserProvider innerSqlUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerSqlUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserProvider == null)
						{
							this.innerSqlUserProvider = new SqlUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserProvider SqlUserProvider
		{
			get {return UserProvider as SqlUserProvider;}
		}
		
		#endregion
		
		
		#region "ValidTicketStateChangesProvider"
			
		private SqlValidTicketStateChangesProvider innerSqlValidTicketStateChangesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ValidTicketStateChanges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ValidTicketStateChangesProviderBase ValidTicketStateChangesProvider
		{
			get
			{
				if (innerSqlValidTicketStateChangesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlValidTicketStateChangesProvider == null)
						{
							this.innerSqlValidTicketStateChangesProvider = new SqlValidTicketStateChangesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlValidTicketStateChangesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlValidTicketStateChangesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlValidTicketStateChangesProvider SqlValidTicketStateChangesProvider
		{
			get {return ValidTicketStateChangesProvider as SqlValidTicketStateChangesProvider;}
		}
		
		#endregion
		
		
		#region "User_MarketingServiceProvider"
			
		private SqlUser_MarketingServiceProvider innerSqlUser_MarketingServiceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User_MarketingService"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override User_MarketingServiceProviderBase User_MarketingServiceProvider
		{
			get
			{
				if (innerSqlUser_MarketingServiceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUser_MarketingServiceProvider == null)
						{
							this.innerSqlUser_MarketingServiceProvider = new SqlUser_MarketingServiceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUser_MarketingServiceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUser_MarketingServiceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUser_MarketingServiceProvider SqlUser_MarketingServiceProvider
		{
			get {return User_MarketingServiceProvider as SqlUser_MarketingServiceProvider;}
		}
		
		#endregion
		
		
		#region "Moderator_FeatureProvider"
			
		private SqlModerator_FeatureProvider innerSqlModerator_FeatureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Moderator_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Moderator_FeatureProviderBase Moderator_FeatureProvider
		{
			get
			{
				if (innerSqlModerator_FeatureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlModerator_FeatureProvider == null)
						{
							this.innerSqlModerator_FeatureProvider = new SqlModerator_FeatureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlModerator_FeatureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlModerator_FeatureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlModerator_FeatureProvider SqlModerator_FeatureProvider
		{
			get {return Moderator_FeatureProvider as SqlModerator_FeatureProvider;}
		}
		
		#endregion
		
		
		#region "UtilProvider"
			
		private SqlUtilProvider innerSqlUtilProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Util"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UtilProviderBase UtilProvider
		{
			get
			{
				if (innerSqlUtilProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUtilProvider == null)
						{
							this.innerSqlUtilProvider = new SqlUtilProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUtilProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUtilProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUtilProvider SqlUtilProvider
		{
			get {return UtilProvider as SqlUtilProvider;}
		}
		
		#endregion
		
		
		#region "TicketCategoryProvider"
			
		private SqlTicketCategoryProvider innerSqlTicketCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketCategoryProviderBase TicketCategoryProvider
		{
			get
			{
				if (innerSqlTicketCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketCategoryProvider == null)
						{
							this.innerSqlTicketCategoryProvider = new SqlTicketCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketCategoryProvider SqlTicketCategoryProvider
		{
			get {return TicketCategoryProvider as SqlTicketCategoryProvider;}
		}
		
		#endregion
		
		
		#region "TaxableProvider"
			
		private SqlTaxableProvider innerSqlTaxableProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Taxable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TaxableProviderBase TaxableProvider
		{
			get
			{
				if (innerSqlTaxableProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTaxableProvider == null)
						{
							this.innerSqlTaxableProvider = new SqlTaxableProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTaxableProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTaxableProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTaxableProvider SqlTaxableProvider
		{
			get {return TaxableProvider as SqlTaxableProvider;}
		}
		
		#endregion
		
		
		#region "WholesalerProvider"
			
		private SqlWholesalerProvider innerSqlWholesalerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Wholesaler"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WholesalerProviderBase WholesalerProvider
		{
			get
			{
				if (innerSqlWholesalerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWholesalerProvider == null)
						{
							this.innerSqlWholesalerProvider = new SqlWholesalerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWholesalerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWholesalerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWholesalerProvider SqlWholesalerProvider
		{
			get {return WholesalerProvider as SqlWholesalerProvider;}
		}
		
		#endregion
		
		
		#region "TicketProvider"
			
		private SqlTicketProvider innerSqlTicketProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Ticket"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketProviderBase TicketProvider
		{
			get
			{
				if (innerSqlTicketProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketProvider == null)
						{
							this.innerSqlTicketProvider = new SqlTicketProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketProvider SqlTicketProvider
		{
			get {return TicketProvider as SqlTicketProvider;}
		}
		
		#endregion
		
		
		#region "WelcomeKitRequestProvider"
			
		private SqlWelcomeKitRequestProvider innerSqlWelcomeKitRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WelcomeKitRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WelcomeKitRequestProviderBase WelcomeKitRequestProvider
		{
			get
			{
				if (innerSqlWelcomeKitRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWelcomeKitRequestProvider == null)
						{
							this.innerSqlWelcomeKitRequestProvider = new SqlWelcomeKitRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWelcomeKitRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWelcomeKitRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWelcomeKitRequestProvider SqlWelcomeKitRequestProvider
		{
			get {return WelcomeKitRequestProvider as SqlWelcomeKitRequestProvider;}
		}
		
		#endregion
		
		
		#region "Wholesaler_ProductProvider"
			
		private SqlWholesaler_ProductProvider innerSqlWholesaler_ProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Wholesaler_Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Wholesaler_ProductProviderBase Wholesaler_ProductProvider
		{
			get
			{
				if (innerSqlWholesaler_ProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWholesaler_ProductProvider == null)
						{
							this.innerSqlWholesaler_ProductProvider = new SqlWholesaler_ProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWholesaler_ProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWholesaler_ProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWholesaler_ProductProvider SqlWholesaler_ProductProvider
		{
			get {return Wholesaler_ProductProvider as SqlWholesaler_ProductProvider;}
		}
		
		#endregion
		
		
		#region "SalesPersonProvider"
			
		private SqlSalesPersonProvider innerSqlSalesPersonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesPersonProviderBase SalesPersonProvider
		{
			get
			{
				if (innerSqlSalesPersonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesPersonProvider == null)
						{
							this.innerSqlSalesPersonProvider = new SqlSalesPersonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesPersonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSalesPersonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesPersonProvider SqlSalesPersonProvider
		{
			get {return SalesPersonProvider as SqlSalesPersonProvider;}
		}
		
		#endregion
		
		
		#region "MarketingServiceProvider"
			
		private SqlMarketingServiceProvider innerSqlMarketingServiceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MarketingService"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MarketingServiceProviderBase MarketingServiceProvider
		{
			get
			{
				if (innerSqlMarketingServiceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMarketingServiceProvider == null)
						{
							this.innerSqlMarketingServiceProvider = new SqlMarketingServiceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMarketingServiceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMarketingServiceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMarketingServiceProvider SqlMarketingServiceProvider
		{
			get {return MarketingServiceProvider as SqlMarketingServiceProvider;}
		}
		
		#endregion
		
		
		#region "ModeratorProvider"
			
		private SqlModeratorProvider innerSqlModeratorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Moderator"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ModeratorProviderBase ModeratorProvider
		{
			get
			{
				if (innerSqlModeratorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlModeratorProvider == null)
						{
							this.innerSqlModeratorProvider = new SqlModeratorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlModeratorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlModeratorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlModeratorProvider SqlModeratorProvider
		{
			get {return ModeratorProvider as SqlModeratorProvider;}
		}
		
		#endregion
		
		
		#region "ParticipantProvider"
			
		private SqlParticipantProvider innerSqlParticipantProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Participant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ParticipantProviderBase ParticipantProvider
		{
			get
			{
				if (innerSqlParticipantProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlParticipantProvider == null)
						{
							this.innerSqlParticipantProvider = new SqlParticipantProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlParticipantProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlParticipantProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlParticipantProvider SqlParticipantProvider
		{
			get {return ParticipantProvider as SqlParticipantProvider;}
		}
		
		#endregion
		
		
		#region "Moderator_DnisProvider"
			
		private SqlModerator_DnisProvider innerSqlModerator_DnisProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Moderator_Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Moderator_DnisProviderBase Moderator_DnisProvider
		{
			get
			{
				if (innerSqlModerator_DnisProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlModerator_DnisProvider == null)
						{
							this.innerSqlModerator_DnisProvider = new SqlModerator_DnisProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlModerator_DnisProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlModerator_DnisProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlModerator_DnisProvider SqlModerator_DnisProvider
		{
			get {return Moderator_DnisProvider as SqlModerator_DnisProvider;}
		}
		
		#endregion
		
		
		#region "ParticipantListProvider"
			
		private SqlParticipantListProvider innerSqlParticipantListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ParticipantList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ParticipantListProviderBase ParticipantListProvider
		{
			get
			{
				if (innerSqlParticipantListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlParticipantListProvider == null)
						{
							this.innerSqlParticipantListProvider = new SqlParticipantListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlParticipantListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlParticipantListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlParticipantListProvider SqlParticipantListProvider
		{
			get {return ParticipantListProvider as SqlParticipantListProvider;}
		}
		
		#endregion
		
		
		#region "TempReplayIdsProvider"
			
		private SqlTempReplayIdsProvider innerSqlTempReplayIdsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempReplayIds"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempReplayIdsProviderBase TempReplayIdsProvider
		{
			get
			{
				if (innerSqlTempReplayIdsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempReplayIdsProvider == null)
						{
							this.innerSqlTempReplayIdsProvider = new SqlTempReplayIdsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempReplayIdsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempReplayIdsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempReplayIdsProvider SqlTempReplayIdsProvider
		{
			get {return TempReplayIdsProvider as SqlTempReplayIdsProvider;}
		}
		
		#endregion
		
		
		#region "TempExistingCodesProvider"
			
		private SqlTempExistingCodesProvider innerSqlTempExistingCodesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempExistingCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempExistingCodesProviderBase TempExistingCodesProvider
		{
			get
			{
				if (innerSqlTempExistingCodesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempExistingCodesProvider == null)
						{
							this.innerSqlTempExistingCodesProvider = new SqlTempExistingCodesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempExistingCodesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempExistingCodesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempExistingCodesProvider SqlTempExistingCodesProvider
		{
			get {return TempExistingCodesProvider as SqlTempExistingCodesProvider;}
		}
		
		#endregion
		
		
		#region "TempCodesProvider"
			
		private SqlTempCodesProvider innerSqlTempCodesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempCodesProviderBase TempCodesProvider
		{
			get
			{
				if (innerSqlTempCodesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempCodesProvider == null)
						{
							this.innerSqlTempCodesProvider = new SqlTempCodesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempCodesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempCodesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempCodesProvider SqlTempCodesProvider
		{
			get {return TempCodesProvider as SqlTempCodesProvider;}
		}
		
		#endregion
		
		
		#region "TempCodeChangesProvider"
			
		private SqlTempCodeChangesProvider innerSqlTempCodeChangesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempCodeChanges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempCodeChangesProviderBase TempCodeChangesProvider
		{
			get
			{
				if (innerSqlTempCodeChangesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempCodeChangesProvider == null)
						{
							this.innerSqlTempCodeChangesProvider = new SqlTempCodeChangesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempCodeChangesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempCodeChangesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempCodeChangesProvider SqlTempCodeChangesProvider
		{
			get {return TempCodeChangesProvider as SqlTempCodeChangesProvider;}
		}
		
		#endregion
		
		
		#region "TempSampleRatesPerProductProvider"
			
		private SqlTempSampleRatesPerProductProvider innerSqlTempSampleRatesPerProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempSampleRatesPerProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempSampleRatesPerProductProviderBase TempSampleRatesPerProductProvider
		{
			get
			{
				if (innerSqlTempSampleRatesPerProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempSampleRatesPerProductProvider == null)
						{
							this.innerSqlTempSampleRatesPerProductProvider = new SqlTempSampleRatesPerProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempSampleRatesPerProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempSampleRatesPerProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempSampleRatesPerProductProvider SqlTempSampleRatesPerProductProvider
		{
			get {return TempSampleRatesPerProductProvider as SqlTempSampleRatesPerProductProvider;}
		}
		
		#endregion
		
		
		#region "TempTotalDollarsSpentProvider"
			
		private SqlTempTotalDollarsSpentProvider innerSqlTempTotalDollarsSpentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TempTotalDollarsSpent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TempTotalDollarsSpentProviderBase TempTotalDollarsSpentProvider
		{
			get
			{
				if (innerSqlTempTotalDollarsSpentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTempTotalDollarsSpentProvider == null)
						{
							this.innerSqlTempTotalDollarsSpentProvider = new SqlTempTotalDollarsSpentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTempTotalDollarsSpentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTempTotalDollarsSpentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTempTotalDollarsSpentProvider SqlTempTotalDollarsSpentProvider
		{
			get {return TempTotalDollarsSpentProvider as SqlTempTotalDollarsSpentProvider;}
		}
		
		#endregion
		
		
		#region "RatedCdrProvider"
			
		private SqlRatedCdrProvider innerSqlRatedCdrProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RatedCdr"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RatedCdrProviderBase RatedCdrProvider
		{
			get
			{
				if (innerSqlRatedCdrProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRatedCdrProvider == null)
						{
							this.innerSqlRatedCdrProvider = new SqlRatedCdrProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRatedCdrProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRatedCdrProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRatedCdrProvider SqlRatedCdrProvider
		{
			get {return RatedCdrProvider as SqlRatedCdrProvider;}
		}
		
		#endregion
		
		
		#region "TrendProvider"
			
		private SqlTrendProvider innerSqlTrendProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Trend"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TrendProviderBase TrendProvider
		{
			get
			{
				if (innerSqlTrendProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTrendProvider == null)
						{
							this.innerSqlTrendProvider = new SqlTrendProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTrendProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTrendProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTrendProvider SqlTrendProvider
		{
			get {return TrendProvider as SqlTrendProvider;}
		}
		
		#endregion
		
		
		#region "TicketUserAssociationsProvider"
			
		private SqlTicketUserAssociationsProvider innerSqlTicketUserAssociationsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketUserAssociations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketUserAssociationsProviderBase TicketUserAssociationsProvider
		{
			get
			{
				if (innerSqlTicketUserAssociationsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketUserAssociationsProvider == null)
						{
							this.innerSqlTicketUserAssociationsProvider = new SqlTicketUserAssociationsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketUserAssociationsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketUserAssociationsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketUserAssociationsProvider SqlTicketUserAssociationsProvider
		{
			get {return TicketUserAssociationsProvider as SqlTicketUserAssociationsProvider;}
		}
		
		#endregion
		
		
		#region "TicketStatusHistoryProvider"
			
		private SqlTicketStatusHistoryProvider innerSqlTicketStatusHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TicketStatusHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TicketStatusHistoryProviderBase TicketStatusHistoryProvider
		{
			get
			{
				if (innerSqlTicketStatusHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTicketStatusHistoryProvider == null)
						{
							this.innerSqlTicketStatusHistoryProvider = new SqlTicketStatusHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTicketStatusHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTicketStatusHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTicketStatusHistoryProvider SqlTicketStatusHistoryProvider
		{
			get {return TicketStatusHistoryProvider as SqlTicketStatusHistoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductRateValueProvider"
			
		private SqlProductRateValueProvider innerSqlProductRateValueProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductRateValue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductRateValueProviderBase ProductRateValueProvider
		{
			get
			{
				if (innerSqlProductRateValueProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductRateValueProvider == null)
						{
							this.innerSqlProductRateValueProvider = new SqlProductRateValueProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductRateValueProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductRateValueProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductRateValueProvider SqlProductRateValueProvider
		{
			get {return ProductRateValueProvider as SqlProductRateValueProvider;}
		}
		
		#endregion
		
		
		#region "LeadPeriodProvider"
			
		private SqlLeadPeriodProvider innerSqlLeadPeriodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadPeriodProviderBase LeadPeriodProvider
		{
			get
			{
				if (innerSqlLeadPeriodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadPeriodProvider == null)
						{
							this.innerSqlLeadPeriodProvider = new SqlLeadPeriodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadPeriodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadPeriodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadPeriodProvider SqlLeadPeriodProvider
		{
			get {return LeadPeriodProvider as SqlLeadPeriodProvider;}
		}
		
		#endregion
		
		
		#region "DnisProvider"
			
		private SqlDnisProvider innerSqlDnisProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DnisProviderBase DnisProvider
		{
			get
			{
				if (innerSqlDnisProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDnisProvider == null)
						{
							this.innerSqlDnisProvider = new SqlDnisProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDnisProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDnisProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDnisProvider SqlDnisProvider
		{
			get {return DnisProvider as SqlDnisProvider;}
		}
		
		#endregion
		
		
		#region "LeadChurnReasonProvider"
			
		private SqlLeadChurnReasonProvider innerSqlLeadChurnReasonProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadChurnReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadChurnReasonProviderBase LeadChurnReasonProvider
		{
			get
			{
				if (innerSqlLeadChurnReasonProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadChurnReasonProvider == null)
						{
							this.innerSqlLeadChurnReasonProvider = new SqlLeadChurnReasonProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadChurnReasonProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadChurnReasonProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadChurnReasonProvider SqlLeadChurnReasonProvider
		{
			get {return LeadChurnReasonProvider as SqlLeadChurnReasonProvider;}
		}
		
		#endregion
		
		
		#region "DnisTypeProvider"
			
		private SqlDnisTypeProvider innerSqlDnisTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DnisType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DnisTypeProviderBase DnisTypeProvider
		{
			get
			{
				if (innerSqlDnisTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDnisTypeProvider == null)
						{
							this.innerSqlDnisTypeProvider = new SqlDnisTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDnisTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDnisTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDnisTypeProvider SqlDnisTypeProvider
		{
			get {return DnisTypeProvider as SqlDnisTypeProvider;}
		}
		
		#endregion
		
		
		#region "CompanyProvider"
			
		private SqlCompanyProvider innerSqlCompanyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Company"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CompanyProviderBase CompanyProvider
		{
			get
			{
				if (innerSqlCompanyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCompanyProvider == null)
						{
							this.innerSqlCompanyProvider = new SqlCompanyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCompanyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCompanyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCompanyProvider SqlCompanyProvider
		{
			get {return CompanyProvider as SqlCompanyProvider;}
		}
		
		#endregion
		
		
		#region "ClientNotesProvider"
			
		private SqlClientNotesProvider innerSqlClientNotesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClientNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClientNotesProviderBase ClientNotesProvider
		{
			get
			{
				if (innerSqlClientNotesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClientNotesProvider == null)
						{
							this.innerSqlClientNotesProvider = new SqlClientNotesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClientNotesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlClientNotesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClientNotesProvider SqlClientNotesProvider
		{
			get {return ClientNotesProvider as SqlClientNotesProvider;}
		}
		
		#endregion
		
		
		#region "CharityProvider"
			
		private SqlCharityProvider innerSqlCharityProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Charity"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CharityProviderBase CharityProvider
		{
			get
			{
				if (innerSqlCharityProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCharityProvider == null)
						{
							this.innerSqlCharityProvider = new SqlCharityProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCharityProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCharityProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCharityProvider SqlCharityProvider
		{
			get {return CharityProvider as SqlCharityProvider;}
		}
		
		#endregion
		
		
		#region "CallFlowProvider"
			
		private SqlCallFlowProvider innerSqlCallFlowProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CallFlow"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CallFlowProviderBase CallFlowProvider
		{
			get
			{
				if (innerSqlCallFlowProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCallFlowProvider == null)
						{
							this.innerSqlCallFlowProvider = new SqlCallFlowProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCallFlowProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCallFlowProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCallFlowProvider SqlCallFlowProvider
		{
			get {return CallFlowProvider as SqlCallFlowProvider;}
		}
		
		#endregion
		
		
		#region "CommissionProvider"
			
		private SqlCommissionProvider innerSqlCommissionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Commission"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CommissionProviderBase CommissionProvider
		{
			get
			{
				if (innerSqlCommissionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCommissionProvider == null)
						{
							this.innerSqlCommissionProvider = new SqlCommissionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCommissionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCommissionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCommissionProvider SqlCommissionProvider
		{
			get {return CommissionProvider as SqlCommissionProvider;}
		}
		
		#endregion
		
		
		#region "CommissionCustomerProvider"
			
		private SqlCommissionCustomerProvider innerSqlCommissionCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CommissionCustomer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CommissionCustomerProviderBase CommissionCustomerProvider
		{
			get
			{
				if (innerSqlCommissionCustomerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCommissionCustomerProvider == null)
						{
							this.innerSqlCommissionCustomerProvider = new SqlCommissionCustomerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCommissionCustomerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCommissionCustomerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCommissionCustomerProvider SqlCommissionCustomerProvider
		{
			get {return CommissionCustomerProvider as SqlCommissionCustomerProvider;}
		}
		
		#endregion
		
		
		#region "CompanyInfoProvider"
			
		private SqlCompanyInfoProvider innerSqlCompanyInfoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CompanyInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CompanyInfoProviderBase CompanyInfoProvider
		{
			get
			{
				if (innerSqlCompanyInfoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCompanyInfoProvider == null)
						{
							this.innerSqlCompanyInfoProvider = new SqlCompanyInfoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCompanyInfoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCompanyInfoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCompanyInfoProvider SqlCompanyInfoProvider
		{
			get {return CompanyInfoProvider as SqlCompanyInfoProvider;}
		}
		
		#endregion
		
		
		#region "CurveProvider"
			
		private SqlCurveProvider innerSqlCurveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Curve"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurveProviderBase CurveProvider
		{
			get
			{
				if (innerSqlCurveProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurveProvider == null)
						{
							this.innerSqlCurveProvider = new SqlCurveProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurveProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCurveProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurveProvider SqlCurveProvider
		{
			get {return CurveProvider as SqlCurveProvider;}
		}
		
		#endregion
		
		
		#region "CompanyLeadTrackingProvider"
			
		private SqlCompanyLeadTrackingProvider innerSqlCompanyLeadTrackingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CompanyLeadTracking"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CompanyLeadTrackingProviderBase CompanyLeadTrackingProvider
		{
			get
			{
				if (innerSqlCompanyLeadTrackingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCompanyLeadTrackingProvider == null)
						{
							this.innerSqlCompanyLeadTrackingProvider = new SqlCompanyLeadTrackingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCompanyLeadTrackingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCompanyLeadTrackingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCompanyLeadTrackingProvider SqlCompanyLeadTrackingProvider
		{
			get {return CompanyLeadTrackingProvider as SqlCompanyLeadTrackingProvider;}
		}
		
		#endregion
		
		
		#region "ConferencingSummaryProvider"
			
		private SqlConferencingSummaryProvider innerSqlConferencingSummaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ConferencingSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ConferencingSummaryProviderBase ConferencingSummaryProvider
		{
			get
			{
				if (innerSqlConferencingSummaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlConferencingSummaryProvider == null)
						{
							this.innerSqlConferencingSummaryProvider = new SqlConferencingSummaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlConferencingSummaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlConferencingSummaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlConferencingSummaryProvider SqlConferencingSummaryProvider
		{
			get {return ConferencingSummaryProvider as SqlConferencingSummaryProvider;}
		}
		
		#endregion
		
		
		#region "BridgeTypeProvider"
			
		private SqlBridgeTypeProvider innerSqlBridgeTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BridgeType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BridgeTypeProviderBase BridgeTypeProvider
		{
			get
			{
				if (innerSqlBridgeTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBridgeTypeProvider == null)
						{
							this.innerSqlBridgeTypeProvider = new SqlBridgeTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBridgeTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBridgeTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBridgeTypeProvider SqlBridgeTypeProvider
		{
			get {return BridgeTypeProvider as SqlBridgeTypeProvider;}
		}
		
		#endregion
		
		
		#region "CompanyLeadTrackingNotesProvider"
			
		private SqlCompanyLeadTrackingNotesProvider innerSqlCompanyLeadTrackingNotesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CompanyLeadTrackingNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CompanyLeadTrackingNotesProviderBase CompanyLeadTrackingNotesProvider
		{
			get
			{
				if (innerSqlCompanyLeadTrackingNotesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCompanyLeadTrackingNotesProvider == null)
						{
							this.innerSqlCompanyLeadTrackingNotesProvider = new SqlCompanyLeadTrackingNotesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCompanyLeadTrackingNotesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCompanyLeadTrackingNotesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCompanyLeadTrackingNotesProvider SqlCompanyLeadTrackingNotesProvider
		{
			get {return CompanyLeadTrackingNotesProvider as SqlCompanyLeadTrackingNotesProvider;}
		}
		
		#endregion
		
		
		#region "BridgeRequestTypeProvider"
			
		private SqlBridgeRequestTypeProvider innerSqlBridgeRequestTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BridgeRequestType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BridgeRequestTypeProviderBase BridgeRequestTypeProvider
		{
			get
			{
				if (innerSqlBridgeRequestTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBridgeRequestTypeProvider == null)
						{
							this.innerSqlBridgeRequestTypeProvider = new SqlBridgeRequestTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBridgeRequestTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBridgeRequestTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBridgeRequestTypeProvider SqlBridgeRequestTypeProvider
		{
			get {return BridgeRequestTypeProvider as SqlBridgeRequestTypeProvider;}
		}
		
		#endregion
		
		
		#region "AdminSiteNotesProvider"
			
		private SqlAdminSiteNotesProvider innerSqlAdminSiteNotesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminSiteNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminSiteNotesProviderBase AdminSiteNotesProvider
		{
			get
			{
				if (innerSqlAdminSiteNotesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminSiteNotesProvider == null)
						{
							this.innerSqlAdminSiteNotesProvider = new SqlAdminSiteNotesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminSiteNotesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminSiteNotesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminSiteNotesProvider SqlAdminSiteNotesProvider
		{
			get {return AdminSiteNotesProvider as SqlAdminSiteNotesProvider;}
		}
		
		#endregion
		
		
		#region "ActionTypeProvider"
			
		private SqlActionTypeProvider innerSqlActionTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ActionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ActionTypeProviderBase ActionTypeProvider
		{
			get
			{
				if (innerSqlActionTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlActionTypeProvider == null)
						{
							this.innerSqlActionTypeProvider = new SqlActionTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlActionTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlActionTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlActionTypeProvider SqlActionTypeProvider
		{
			get {return ActionTypeProvider as SqlActionTypeProvider;}
		}
		
		#endregion
		
		
		#region "ActionProvider"
			
		private SqlActionProvider innerSqlActionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Action"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ActionProviderBase ActionProvider
		{
			get
			{
				if (innerSqlActionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlActionProvider == null)
						{
							this.innerSqlActionProvider = new SqlActionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlActionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlActionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlActionProvider SqlActionProvider
		{
			get {return ActionProvider as SqlActionProvider;}
		}
		
		#endregion
		
		
		#region "AccountManagerProvider"
			
		private SqlAccountManagerProvider innerSqlAccountManagerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AccountManager"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccountManagerProviderBase AccountManagerProvider
		{
			get
			{
				if (innerSqlAccountManagerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccountManagerProvider == null)
						{
							this.innerSqlAccountManagerProvider = new SqlAccountManagerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccountManagerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccountManagerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccountManagerProvider SqlAccountManagerProvider
		{
			get {return AccountManagerProvider as SqlAccountManagerProvider;}
		}
		
		#endregion
		
		
		#region "AccessType_ProductRateProvider"
			
		private SqlAccessType_ProductRateProvider innerSqlAccessType_ProductRateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AccessType_ProductRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccessType_ProductRateProviderBase AccessType_ProductRateProvider
		{
			get
			{
				if (innerSqlAccessType_ProductRateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccessType_ProductRateProvider == null)
						{
							this.innerSqlAccessType_ProductRateProvider = new SqlAccessType_ProductRateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccessType_ProductRateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccessType_ProductRateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccessType_ProductRateProvider SqlAccessType_ProductRateProvider
		{
			get {return AccessType_ProductRateProvider as SqlAccessType_ProductRateProvider;}
		}
		
		#endregion
		
		
		#region "AdminSiteNotesHistoryProvider"
			
		private SqlAdminSiteNotesHistoryProvider innerSqlAdminSiteNotesHistoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminSiteNotesHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminSiteNotesHistoryProviderBase AdminSiteNotesHistoryProvider
		{
			get
			{
				if (innerSqlAdminSiteNotesHistoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminSiteNotesHistoryProvider == null)
						{
							this.innerSqlAdminSiteNotesHistoryProvider = new SqlAdminSiteNotesHistoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminSiteNotesHistoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminSiteNotesHistoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminSiteNotesHistoryProvider SqlAdminSiteNotesHistoryProvider
		{
			get {return AdminSiteNotesHistoryProvider as SqlAdminSiteNotesHistoryProvider;}
		}
		
		#endregion
		
		
		#region "AreaCodeNxxProvider"
			
		private SqlAreaCodeNxxProvider innerSqlAreaCodeNxxProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AreaCodeNxx"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AreaCodeNxxProviderBase AreaCodeNxxProvider
		{
			get
			{
				if (innerSqlAreaCodeNxxProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAreaCodeNxxProvider == null)
						{
							this.innerSqlAreaCodeNxxProvider = new SqlAreaCodeNxxProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAreaCodeNxxProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAreaCodeNxxProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAreaCodeNxxProvider SqlAreaCodeNxxProvider
		{
			get {return AreaCodeNxxProvider as SqlAreaCodeNxxProvider;}
		}
		
		#endregion
		
		
		#region "AuditLogProvider"
			
		private SqlAuditLogProvider innerSqlAuditLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AuditLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AuditLogProviderBase AuditLogProvider
		{
			get
			{
				if (innerSqlAuditLogProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAuditLogProvider == null)
						{
							this.innerSqlAuditLogProvider = new SqlAuditLogProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAuditLogProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAuditLogProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAuditLogProvider SqlAuditLogProvider
		{
			get {return AuditLogProvider as SqlAuditLogProvider;}
		}
		
		#endregion
		
		
		#region "BridgeRequestProvider"
			
		private SqlBridgeRequestProvider innerSqlBridgeRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BridgeRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BridgeRequestProviderBase BridgeRequestProvider
		{
			get
			{
				if (innerSqlBridgeRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBridgeRequestProvider == null)
						{
							this.innerSqlBridgeRequestProvider = new SqlBridgeRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBridgeRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBridgeRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBridgeRequestProvider SqlBridgeRequestProvider
		{
			get {return BridgeRequestProvider as SqlBridgeRequestProvider;}
		}
		
		#endregion
		
		
		#region "BridgeProvider"
			
		private SqlBridgeProvider innerSqlBridgeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Bridge"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BridgeProviderBase BridgeProvider
		{
			get
			{
				if (innerSqlBridgeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBridgeProvider == null)
						{
							this.innerSqlBridgeProvider = new SqlBridgeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBridgeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBridgeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBridgeProvider SqlBridgeProvider
		{
			get {return BridgeProvider as SqlBridgeProvider;}
		}
		
		#endregion
		
		
		#region "BillableLegsProvider"
			
		private SqlBillableLegsProvider innerSqlBillableLegsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BillableLegs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BillableLegsProviderBase BillableLegsProvider
		{
			get
			{
				if (innerSqlBillableLegsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBillableLegsProvider == null)
						{
							this.innerSqlBillableLegsProvider = new SqlBillableLegsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBillableLegsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBillableLegsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBillableLegsProvider SqlBillableLegsProvider
		{
			get {return BillableLegsProvider as SqlBillableLegsProvider;}
		}
		
		#endregion
		
		
		#region "CustomerProvider"
			
		private SqlCustomerProvider innerSqlCustomerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerProviderBase CustomerProvider
		{
			get
			{
				if (innerSqlCustomerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerProvider == null)
						{
							this.innerSqlCustomerProvider = new SqlCustomerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerProvider SqlCustomerProvider
		{
			get {return CustomerProvider as SqlCustomerProvider;}
		}
		
		#endregion
		
		
		#region "AverageRatesProvider"
			
		private SqlAverageRatesProvider innerSqlAverageRatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AverageRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AverageRatesProviderBase AverageRatesProvider
		{
			get
			{
				if (innerSqlAverageRatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAverageRatesProvider == null)
						{
							this.innerSqlAverageRatesProvider = new SqlAverageRatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAverageRatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAverageRatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAverageRatesProvider SqlAverageRatesProvider
		{
			get {return AverageRatesProvider as SqlAverageRatesProvider;}
		}
		
		#endregion
		
		
		#region "BridgeQueueProvider"
			
		private SqlBridgeQueueProvider innerSqlBridgeQueueProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BridgeQueue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BridgeQueueProviderBase BridgeQueueProvider
		{
			get
			{
				if (innerSqlBridgeQueueProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBridgeQueueProvider == null)
						{
							this.innerSqlBridgeQueueProvider = new SqlBridgeQueueProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBridgeQueueProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlBridgeQueueProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBridgeQueueProvider SqlBridgeQueueProvider
		{
			get {return BridgeQueueProvider as SqlBridgeQueueProvider;}
		}
		
		#endregion
		
		
		#region "ForExProvider"
			
		private SqlForExProvider innerSqlForExProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ForEx"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ForExProviderBase ForExProvider
		{
			get
			{
				if (innerSqlForExProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlForExProvider == null)
						{
							this.innerSqlForExProvider = new SqlForExProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlForExProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlForExProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlForExProvider SqlForExProvider
		{
			get {return ForExProvider as SqlForExProvider;}
		}
		
		#endregion
		
		
		#region "Customer_DnisProvider"
			
		private SqlCustomer_DnisProvider innerSqlCustomer_DnisProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customer_Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Customer_DnisProviderBase Customer_DnisProvider
		{
			get
			{
				if (innerSqlCustomer_DnisProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomer_DnisProvider == null)
						{
							this.innerSqlCustomer_DnisProvider = new SqlCustomer_DnisProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomer_DnisProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomer_DnisProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomer_DnisProvider SqlCustomer_DnisProvider
		{
			get {return Customer_DnisProvider as SqlCustomer_DnisProvider;}
		}
		
		#endregion
		
		
		#region "FeatureOptionTypeProvider"
			
		private SqlFeatureOptionTypeProvider innerSqlFeatureOptionTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="FeatureOptionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FeatureOptionTypeProviderBase FeatureOptionTypeProvider
		{
			get
			{
				if (innerSqlFeatureOptionTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFeatureOptionTypeProvider == null)
						{
							this.innerSqlFeatureOptionTypeProvider = new SqlFeatureOptionTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFeatureOptionTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFeatureOptionTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFeatureOptionTypeProvider SqlFeatureOptionTypeProvider
		{
			get {return FeatureOptionTypeProvider as SqlFeatureOptionTypeProvider;}
		}
		
		#endregion
		
		
		#region "FeatureProvider"
			
		private SqlFeatureProvider innerSqlFeatureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FeatureProviderBase FeatureProvider
		{
			get
			{
				if (innerSqlFeatureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFeatureProvider == null)
						{
							this.innerSqlFeatureProvider = new SqlFeatureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFeatureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFeatureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFeatureProvider SqlFeatureProvider
		{
			get {return FeatureProvider as SqlFeatureProvider;}
		}
		
		#endregion
		
		
		#region "GlPostingTypeProvider"
			
		private SqlGlPostingTypeProvider innerSqlGlPostingTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="GlPostingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GlPostingTypeProviderBase GlPostingTypeProvider
		{
			get
			{
				if (innerSqlGlPostingTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGlPostingTypeProvider == null)
						{
							this.innerSqlGlPostingTypeProvider = new SqlGlPostingTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGlPostingTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGlPostingTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGlPostingTypeProvider SqlGlPostingTypeProvider
		{
			get {return GlPostingTypeProvider as SqlGlPostingTypeProvider;}
		}
		
		#endregion
		
		
		#region "FeatureOptionProvider"
			
		private SqlFeatureOptionProvider innerSqlFeatureOptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="FeatureOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FeatureOptionProviderBase FeatureOptionProvider
		{
			get
			{
				if (innerSqlFeatureOptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFeatureOptionProvider == null)
						{
							this.innerSqlFeatureOptionProvider = new SqlFeatureOptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFeatureOptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFeatureOptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFeatureOptionProvider SqlFeatureOptionProvider
		{
			get {return FeatureOptionProvider as SqlFeatureOptionProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceChargesProvider"
			
		private SqlInvoiceChargesProvider innerSqlInvoiceChargesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="InvoiceCharges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceChargesProviderBase InvoiceChargesProvider
		{
			get
			{
				if (innerSqlInvoiceChargesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceChargesProvider == null)
						{
							this.innerSqlInvoiceChargesProvider = new SqlInvoiceChargesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceChargesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceChargesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceChargesProvider SqlInvoiceChargesProvider
		{
			get {return InvoiceChargesProvider as SqlInvoiceChargesProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceNotesProvider"
			
		private SqlInvoiceNotesProvider innerSqlInvoiceNotesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="InvoiceNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceNotesProviderBase InvoiceNotesProvider
		{
			get
			{
				if (innerSqlInvoiceNotesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceNotesProvider == null)
						{
							this.innerSqlInvoiceNotesProvider = new SqlInvoiceNotesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceNotesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceNotesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceNotesProvider SqlInvoiceNotesProvider
		{
			get {return InvoiceNotesProvider as SqlInvoiceNotesProvider;}
		}
		
		#endregion
		
		
		#region "LeadProvider"
			
		private SqlLeadProvider innerSqlLeadProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Lead"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadProviderBase LeadProvider
		{
			get
			{
				if (innerSqlLeadProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadProvider == null)
						{
							this.innerSqlLeadProvider = new SqlLeadProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLeadProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadProvider SqlLeadProvider
		{
			get {return LeadProvider as SqlLeadProvider;}
		}
		
		#endregion
		
		
		#region "LanguageProvider"
			
		private SqlLanguageProvider innerSqlLanguageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Language"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LanguageProviderBase LanguageProvider
		{
			get
			{
				if (innerSqlLanguageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLanguageProvider == null)
						{
							this.innerSqlLanguageProvider = new SqlLanguageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLanguageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLanguageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLanguageProvider SqlLanguageProvider
		{
			get {return LanguageProvider as SqlLanguageProvider;}
		}
		
		#endregion
		
		
		#region "IrWholesalerProvider"
			
		private SqlIrWholesalerProvider innerSqlIrWholesalerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="IrWholesaler"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IrWholesalerProviderBase IrWholesalerProvider
		{
			get
			{
				if (innerSqlIrWholesalerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIrWholesalerProvider == null)
						{
							this.innerSqlIrWholesalerProvider = new SqlIrWholesalerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIrWholesalerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlIrWholesalerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIrWholesalerProvider SqlIrWholesalerProvider
		{
			get {return IrWholesalerProvider as SqlIrWholesalerProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceSummaryProvider"
			
		private SqlInvoiceSummaryProvider innerSqlInvoiceSummaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="InvoiceSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceSummaryProviderBase InvoiceSummaryProvider
		{
			get
			{
				if (innerSqlInvoiceSummaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceSummaryProvider == null)
						{
							this.innerSqlInvoiceSummaryProvider = new SqlInvoiceSummaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceSummaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceSummaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceSummaryProvider SqlInvoiceSummaryProvider
		{
			get {return InvoiceSummaryProvider as SqlInvoiceSummaryProvider;}
		}
		
		#endregion
		
		
		#region "ExtensionTypeCategoryProvider"
			
		private SqlExtensionTypeCategoryProvider innerSqlExtensionTypeCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ExtensionTypeCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ExtensionTypeCategoryProviderBase ExtensionTypeCategoryProvider
		{
			get
			{
				if (innerSqlExtensionTypeCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlExtensionTypeCategoryProvider == null)
						{
							this.innerSqlExtensionTypeCategoryProvider = new SqlExtensionTypeCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlExtensionTypeCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlExtensionTypeCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlExtensionTypeCategoryProvider SqlExtensionTypeCategoryProvider
		{
			get {return ExtensionTypeCategoryProvider as SqlExtensionTypeCategoryProvider;}
		}
		
		#endregion
		
		
		#region "ExtensionTypeProvider"
			
		private SqlExtensionTypeProvider innerSqlExtensionTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ExtensionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ExtensionTypeProviderBase ExtensionTypeProvider
		{
			get
			{
				if (innerSqlExtensionTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlExtensionTypeProvider == null)
						{
							this.innerSqlExtensionTypeProvider = new SqlExtensionTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlExtensionTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlExtensionTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlExtensionTypeProvider SqlExtensionTypeProvider
		{
			get {return ExtensionTypeProvider as SqlExtensionTypeProvider;}
		}
		
		#endregion
		
		
		#region "EventManagerProvider"
			
		private SqlEventManagerProvider innerSqlEventManagerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EventManager"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EventManagerProviderBase EventManagerProvider
		{
			get
			{
				if (innerSqlEventManagerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEventManagerProvider == null)
						{
							this.innerSqlEventManagerProvider = new SqlEventManagerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEventManagerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEventManagerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEventManagerProvider SqlEventManagerProvider
		{
			get {return EventManagerProvider as SqlEventManagerProvider;}
		}
		
		#endregion
		
		
		#region "CustomerTransactionImportProvider"
			
		private SqlCustomerTransactionImportProvider innerSqlCustomerTransactionImportProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerTransactionImport"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerTransactionImportProviderBase CustomerTransactionImportProvider
		{
			get
			{
				if (innerSqlCustomerTransactionImportProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerTransactionImportProvider == null)
						{
							this.innerSqlCustomerTransactionImportProvider = new SqlCustomerTransactionImportProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerTransactionImportProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerTransactionImportProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerTransactionImportProvider SqlCustomerTransactionImportProvider
		{
			get {return CustomerTransactionImportProvider as SqlCustomerTransactionImportProvider;}
		}
		
		#endregion
		
		
		#region "CustomerReviewProvider"
			
		private SqlCustomerReviewProvider innerSqlCustomerReviewProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerReview"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerReviewProviderBase CustomerReviewProvider
		{
			get
			{
				if (innerSqlCustomerReviewProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerReviewProvider == null)
						{
							this.innerSqlCustomerReviewProvider = new SqlCustomerReviewProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerReviewProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerReviewProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerReviewProvider SqlCustomerReviewProvider
		{
			get {return CustomerReviewProvider as SqlCustomerReviewProvider;}
		}
		
		#endregion
		
		
		#region "CustomerDocumentProvider"
			
		private SqlCustomerDocumentProvider innerSqlCustomerDocumentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerDocument"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerDocumentProviderBase CustomerDocumentProvider
		{
			get
			{
				if (innerSqlCustomerDocumentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerDocumentProvider == null)
						{
							this.innerSqlCustomerDocumentProvider = new SqlCustomerDocumentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerDocumentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerDocumentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerDocumentProvider SqlCustomerDocumentProvider
		{
			get {return CustomerDocumentProvider as SqlCustomerDocumentProvider;}
		}
		
		#endregion
		
		
		#region "Customer_FeatureProvider"
			
		private SqlCustomer_FeatureProvider innerSqlCustomer_FeatureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customer_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Customer_FeatureProviderBase Customer_FeatureProvider
		{
			get
			{
				if (innerSqlCustomer_FeatureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomer_FeatureProvider == null)
						{
							this.innerSqlCustomer_FeatureProvider = new SqlCustomer_FeatureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomer_FeatureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomer_FeatureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomer_FeatureProvider SqlCustomer_FeatureProvider
		{
			get {return Customer_FeatureProvider as SqlCustomer_FeatureProvider;}
		}
		
		#endregion
		
		
		#region "CustomerTransactionTypeProvider"
			
		private SqlCustomerTransactionTypeProvider innerSqlCustomerTransactionTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerTransactionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerTransactionTypeProviderBase CustomerTransactionTypeProvider
		{
			get
			{
				if (innerSqlCustomerTransactionTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerTransactionTypeProvider == null)
						{
							this.innerSqlCustomerTransactionTypeProvider = new SqlCustomerTransactionTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerTransactionTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerTransactionTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerTransactionTypeProvider SqlCustomerTransactionTypeProvider
		{
			get {return CustomerTransactionTypeProvider as SqlCustomerTransactionTypeProvider;}
		}
		
		#endregion
		
		
		#region "DepartmentProvider"
			
		private SqlDepartmentProvider innerSqlDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentProviderBase DepartmentProvider
		{
			get
			{
				if (innerSqlDepartmentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDepartmentProvider == null)
						{
							this.innerSqlDepartmentProvider = new SqlDepartmentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDepartmentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDepartmentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDepartmentProvider SqlDepartmentProvider
		{
			get {return DepartmentProvider as SqlDepartmentProvider;}
		}
		
		#endregion
		
		
		#region "ErrorCodesProvider"
			
		private SqlErrorCodesProvider innerSqlErrorCodesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ErrorCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ErrorCodesProviderBase ErrorCodesProvider
		{
			get
			{
				if (innerSqlErrorCodesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlErrorCodesProvider == null)
						{
							this.innerSqlErrorCodesProvider = new SqlErrorCodesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlErrorCodesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlErrorCodesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlErrorCodesProvider SqlErrorCodesProvider
		{
			get {return ErrorCodesProvider as SqlErrorCodesProvider;}
		}
		
		#endregion
		
		
		#region "EmailTemplateProvider"
			
		private SqlEmailTemplateProvider innerSqlEmailTemplateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmailTemplate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmailTemplateProviderBase EmailTemplateProvider
		{
			get
			{
				if (innerSqlEmailTemplateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmailTemplateProvider == null)
						{
							this.innerSqlEmailTemplateProvider = new SqlEmailTemplateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmailTemplateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEmailTemplateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmailTemplateProvider SqlEmailTemplateProvider
		{
			get {return EmailTemplateProvider as SqlEmailTemplateProvider;}
		}
		
		#endregion
		
		
		#region "EmailNotificationProvider"
			
		private SqlEmailNotificationProvider innerSqlEmailNotificationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmailNotification"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmailNotificationProviderBase EmailNotificationProvider
		{
			get
			{
				if (innerSqlEmailNotificationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmailNotificationProvider == null)
						{
							this.innerSqlEmailNotificationProvider = new SqlEmailNotificationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmailNotificationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEmailNotificationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmailNotificationProvider SqlEmailNotificationProvider
		{
			get {return EmailNotificationProvider as SqlEmailNotificationProvider;}
		}
		
		#endregion
		
		
		#region "CustomerTransactionProvider"
			
		private SqlCustomerTransactionProvider innerSqlCustomerTransactionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerTransaction"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerTransactionProviderBase CustomerTransactionProvider
		{
			get
			{
				if (innerSqlCustomerTransactionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerTransactionProvider == null)
						{
							this.innerSqlCustomerTransactionProvider = new SqlCustomerTransactionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerTransactionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomerTransactionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerTransactionProvider SqlCustomerTransactionProvider
		{
			get {return CustomerTransactionProvider as SqlCustomerTransactionProvider;}
		}
		
		#endregion
		
		
		#region "DocumentTypeProvider"
			
		private SqlDocumentTypeProvider innerSqlDocumentTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DocumentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DocumentTypeProviderBase DocumentTypeProvider
		{
			get
			{
				if (innerSqlDocumentTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDocumentTypeProvider == null)
						{
							this.innerSqlDocumentTypeProvider = new SqlDocumentTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDocumentTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDocumentTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDocumentTypeProvider SqlDocumentTypeProvider
		{
			get {return DocumentTypeProvider as SqlDocumentTypeProvider;}
		}
		
		#endregion
		
		
		#region "Wholesaler_Product_FeatureProvider"
			
		private SqlWholesaler_Product_FeatureProvider innerSqlWholesaler_Product_FeatureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Wholesaler_Product_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Wholesaler_Product_FeatureProviderBase Wholesaler_Product_FeatureProvider
		{
			get
			{
				if (innerSqlWholesaler_Product_FeatureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWholesaler_Product_FeatureProvider == null)
						{
							this.innerSqlWholesaler_Product_FeatureProvider = new SqlWholesaler_Product_FeatureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWholesaler_Product_FeatureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWholesaler_Product_FeatureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWholesaler_Product_FeatureProvider SqlWholesaler_Product_FeatureProvider
		{
			get {return Wholesaler_Product_FeatureProvider as SqlWholesaler_Product_FeatureProvider;}
		}
		
		#endregion
		
		
		
		#region "Vw_AccessType_ProductRatesProvider"
		
		private SqlVw_AccessType_ProductRatesProvider innerSqlVw_AccessType_ProductRatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_AccessType_ProductRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_AccessType_ProductRatesProviderBase Vw_AccessType_ProductRatesProvider
		{
			get
			{
				if (innerSqlVw_AccessType_ProductRatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_AccessType_ProductRatesProvider == null)
						{
							this.innerSqlVw_AccessType_ProductRatesProvider = new SqlVw_AccessType_ProductRatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_AccessType_ProductRatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_AccessType_ProductRatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_AccessType_ProductRatesProvider SqlVw_AccessType_ProductRatesProvider
		{
			get {return Vw_AccessType_ProductRatesProvider as SqlVw_AccessType_ProductRatesProvider;}
		}
		
		#endregion
		
		
		#region "Vw_ConferenceCallList_UniqueProvider"
		
		private SqlVw_ConferenceCallList_UniqueProvider innerSqlVw_ConferenceCallList_UniqueProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_ConferenceCallList_Unique"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_ConferenceCallList_UniqueProviderBase Vw_ConferenceCallList_UniqueProvider
		{
			get
			{
				if (innerSqlVw_ConferenceCallList_UniqueProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_ConferenceCallList_UniqueProvider == null)
						{
							this.innerSqlVw_ConferenceCallList_UniqueProvider = new SqlVw_ConferenceCallList_UniqueProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_ConferenceCallList_UniqueProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_ConferenceCallList_UniqueProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_ConferenceCallList_UniqueProvider SqlVw_ConferenceCallList_UniqueProvider
		{
			get {return Vw_ConferenceCallList_UniqueProvider as SqlVw_ConferenceCallList_UniqueProvider;}
		}
		
		#endregion
		
		
		#region "Vw_ConferenceListProvider"
		
		private SqlVw_ConferenceListProvider innerSqlVw_ConferenceListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_ConferenceList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_ConferenceListProviderBase Vw_ConferenceListProvider
		{
			get
			{
				if (innerSqlVw_ConferenceListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_ConferenceListProvider == null)
						{
							this.innerSqlVw_ConferenceListProvider = new SqlVw_ConferenceListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_ConferenceListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_ConferenceListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_ConferenceListProvider SqlVw_ConferenceListProvider
		{
			get {return Vw_ConferenceListProvider as SqlVw_ConferenceListProvider;}
		}
		
		#endregion
		
		
		#region "Vw_CustomerListProvider"
		
		private SqlVw_CustomerListProvider innerSqlVw_CustomerListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_CustomerList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_CustomerListProviderBase Vw_CustomerListProvider
		{
			get
			{
				if (innerSqlVw_CustomerListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_CustomerListProvider == null)
						{
							this.innerSqlVw_CustomerListProvider = new SqlVw_CustomerListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_CustomerListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_CustomerListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_CustomerListProvider SqlVw_CustomerListProvider
		{
			get {return Vw_CustomerListProvider as SqlVw_CustomerListProvider;}
		}
		
		#endregion
		
		
		#region "Vw_CustomerTransactionListProvider"
		
		private SqlVw_CustomerTransactionListProvider innerSqlVw_CustomerTransactionListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_CustomerTransactionList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_CustomerTransactionListProviderBase Vw_CustomerTransactionListProvider
		{
			get
			{
				if (innerSqlVw_CustomerTransactionListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_CustomerTransactionListProvider == null)
						{
							this.innerSqlVw_CustomerTransactionListProvider = new SqlVw_CustomerTransactionListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_CustomerTransactionListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_CustomerTransactionListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_CustomerTransactionListProvider SqlVw_CustomerTransactionListProvider
		{
			get {return Vw_CustomerTransactionListProvider as SqlVw_CustomerTransactionListProvider;}
		}
		
		#endregion
		
		
		#region "Vw_DefaultProductRatesProvider"
		
		private SqlVw_DefaultProductRatesProvider innerSqlVw_DefaultProductRatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_DefaultProductRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_DefaultProductRatesProviderBase Vw_DefaultProductRatesProvider
		{
			get
			{
				if (innerSqlVw_DefaultProductRatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_DefaultProductRatesProvider == null)
						{
							this.innerSqlVw_DefaultProductRatesProvider = new SqlVw_DefaultProductRatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_DefaultProductRatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_DefaultProductRatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_DefaultProductRatesProvider SqlVw_DefaultProductRatesProvider
		{
			get {return Vw_DefaultProductRatesProvider as SqlVw_DefaultProductRatesProvider;}
		}
		
		#endregion
		
		
		#region "Vw_FeatureOptionsForCustomersProvider"
		
		private SqlVw_FeatureOptionsForCustomersProvider innerSqlVw_FeatureOptionsForCustomersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_FeatureOptionsForCustomers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_FeatureOptionsForCustomersProviderBase Vw_FeatureOptionsForCustomersProvider
		{
			get
			{
				if (innerSqlVw_FeatureOptionsForCustomersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_FeatureOptionsForCustomersProvider == null)
						{
							this.innerSqlVw_FeatureOptionsForCustomersProvider = new SqlVw_FeatureOptionsForCustomersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_FeatureOptionsForCustomersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_FeatureOptionsForCustomersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_FeatureOptionsForCustomersProvider SqlVw_FeatureOptionsForCustomersProvider
		{
			get {return Vw_FeatureOptionsForCustomersProvider as SqlVw_FeatureOptionsForCustomersProvider;}
		}
		
		#endregion
		
		
		#region "Vw_FeatureOptionsForModeratorsProvider"
		
		private SqlVw_FeatureOptionsForModeratorsProvider innerSqlVw_FeatureOptionsForModeratorsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_FeatureOptionsForModerators"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_FeatureOptionsForModeratorsProviderBase Vw_FeatureOptionsForModeratorsProvider
		{
			get
			{
				if (innerSqlVw_FeatureOptionsForModeratorsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_FeatureOptionsForModeratorsProvider == null)
						{
							this.innerSqlVw_FeatureOptionsForModeratorsProvider = new SqlVw_FeatureOptionsForModeratorsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_FeatureOptionsForModeratorsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_FeatureOptionsForModeratorsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_FeatureOptionsForModeratorsProvider SqlVw_FeatureOptionsForModeratorsProvider
		{
			get {return Vw_FeatureOptionsForModeratorsProvider as SqlVw_FeatureOptionsForModeratorsProvider;}
		}
		
		#endregion
		
		
		#region "Vw_ModeratorListProvider"
		
		private SqlVw_ModeratorListProvider innerSqlVw_ModeratorListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_ModeratorList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_ModeratorListProviderBase Vw_ModeratorListProvider
		{
			get
			{
				if (innerSqlVw_ModeratorListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_ModeratorListProvider == null)
						{
							this.innerSqlVw_ModeratorListProvider = new SqlVw_ModeratorListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_ModeratorListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_ModeratorListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_ModeratorListProvider SqlVw_ModeratorListProvider
		{
			get {return Vw_ModeratorListProvider as SqlVw_ModeratorListProvider;}
		}
		
		#endregion
		
		
		#region "Vw_ModeratorList_AdminSiteProvider"
		
		private SqlVw_ModeratorList_AdminSiteProvider innerSqlVw_ModeratorList_AdminSiteProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_ModeratorList_AdminSite"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_ModeratorList_AdminSiteProviderBase Vw_ModeratorList_AdminSiteProvider
		{
			get
			{
				if (innerSqlVw_ModeratorList_AdminSiteProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_ModeratorList_AdminSiteProvider == null)
						{
							this.innerSqlVw_ModeratorList_AdminSiteProvider = new SqlVw_ModeratorList_AdminSiteProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_ModeratorList_AdminSiteProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_ModeratorList_AdminSiteProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_ModeratorList_AdminSiteProvider SqlVw_ModeratorList_AdminSiteProvider
		{
			get {return Vw_ModeratorList_AdminSiteProvider as SqlVw_ModeratorList_AdminSiteProvider;}
		}
		
		#endregion
		
		
		#region "Vw_RecordingListProvider"
		
		private SqlVw_RecordingListProvider innerSqlVw_RecordingListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_RecordingList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_RecordingListProviderBase Vw_RecordingListProvider
		{
			get
			{
				if (innerSqlVw_RecordingListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_RecordingListProvider == null)
						{
							this.innerSqlVw_RecordingListProvider = new SqlVw_RecordingListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_RecordingListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_RecordingListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_RecordingListProvider SqlVw_RecordingListProvider
		{
			get {return Vw_RecordingListProvider as SqlVw_RecordingListProvider;}
		}
		
		#endregion
		
		
		#region "Vw_SystemExtension_AllProvider"
		
		private SqlVw_SystemExtension_AllProvider innerSqlVw_SystemExtension_AllProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_SystemExtension_All"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_SystemExtension_AllProviderBase Vw_SystemExtension_AllProvider
		{
			get
			{
				if (innerSqlVw_SystemExtension_AllProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_SystemExtension_AllProvider == null)
						{
							this.innerSqlVw_SystemExtension_AllProvider = new SqlVw_SystemExtension_AllProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_SystemExtension_AllProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_SystemExtension_AllProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_SystemExtension_AllProvider SqlVw_SystemExtension_AllProvider
		{
			get {return Vw_SystemExtension_AllProvider as SqlVw_SystemExtension_AllProvider;}
		}
		
		#endregion
		
		
		#region "Vw_SystemExtension_CustomerLabelProvider"
		
		private SqlVw_SystemExtension_CustomerLabelProvider innerSqlVw_SystemExtension_CustomerLabelProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_SystemExtension_CustomerLabel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_SystemExtension_CustomerLabelProviderBase Vw_SystemExtension_CustomerLabelProvider
		{
			get
			{
				if (innerSqlVw_SystemExtension_CustomerLabelProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_SystemExtension_CustomerLabelProvider == null)
						{
							this.innerSqlVw_SystemExtension_CustomerLabelProvider = new SqlVw_SystemExtension_CustomerLabelProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_SystemExtension_CustomerLabelProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_SystemExtension_CustomerLabelProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_SystemExtension_CustomerLabelProvider SqlVw_SystemExtension_CustomerLabelProvider
		{
			get {return Vw_SystemExtension_CustomerLabelProvider as SqlVw_SystemExtension_CustomerLabelProvider;}
		}
		
		#endregion
		
		
		#region "Vw_SystemExtension_ValueProvider"
		
		private SqlVw_SystemExtension_ValueProvider innerSqlVw_SystemExtension_ValueProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_SystemExtension_Value"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_SystemExtension_ValueProviderBase Vw_SystemExtension_ValueProvider
		{
			get
			{
				if (innerSqlVw_SystemExtension_ValueProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_SystemExtension_ValueProvider == null)
						{
							this.innerSqlVw_SystemExtension_ValueProvider = new SqlVw_SystemExtension_ValueProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_SystemExtension_ValueProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_SystemExtension_ValueProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_SystemExtension_ValueProvider SqlVw_SystemExtension_ValueProvider
		{
			get {return Vw_SystemExtension_ValueProvider as SqlVw_SystemExtension_ValueProvider;}
		}
		
		#endregion
		
		
		#region "Vw_UserListProvider"
		
		private SqlVw_UserListProvider innerSqlVw_UserListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Vw_UserList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Vw_UserListProviderBase Vw_UserListProvider
		{
			get
			{
				if (innerSqlVw_UserListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVw_UserListProvider == null)
						{
							this.innerSqlVw_UserListProvider = new SqlVw_UserListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVw_UserListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlVw_UserListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVw_UserListProvider SqlVw_UserListProvider
		{
			get {return Vw_UserListProvider as SqlVw_UserListProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
