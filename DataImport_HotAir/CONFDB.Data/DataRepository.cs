#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using CONFDB.Entities;
using CONFDB.Data;
using CONFDB.Data.Bases;

#endregion

namespace CONFDB.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("CONFDB.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.8.0");
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region AccessTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AccessType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AccessTypeProviderBase AccessTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccessTypeProvider;
			}
		}
		
		#endregion
		
		#region RecordingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Recording"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RecordingProviderBase RecordingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RecordingProvider;
			}
		}
		
		#endregion
		
		#region RecordingParticipantUsageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RecordingParticipantUsage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RecordingParticipantUsageProviderBase RecordingParticipantUsageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RecordingParticipantUsageProvider;
			}
		}
		
		#endregion
		
		#region RatingTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RatingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RatingTypeProviderBase RatingTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RatingTypeProvider;
			}
		}
		
		#endregion
		
		#region PromptSetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PromptSet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PromptSetProviderBase PromptSetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PromptSetProvider;
			}
		}
		
		#endregion
		
		#region RoleProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Role"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RoleProviderBase RoleProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RoleProvider;
			}
		}
		
		#endregion
		
		#region SeeVoghMeetingTrackerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SeeVoghMeetingTracker"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SeeVoghMeetingTrackerProviderBase SeeVoghMeetingTrackerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SeeVoghMeetingTrackerProvider;
			}
		}
		
		#endregion
		
		#region CountryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Country"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountryProviderBase CountryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountryProvider;
			}
		}
		
		#endregion
		
		#region CurrencyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Currency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurrencyProviderBase CurrencyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurrencyProvider;
			}
		}
		
		#endregion
		
		#region SystemExtensionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SystemExtension"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SystemExtensionProviderBase SystemExtensionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SystemExtensionProvider;
			}
		}
		
		#endregion
		
		#region StateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="State"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StateProviderBase StateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StateProvider;
			}
		}
		
		#endregion
		
		#region ProductTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductTypeProviderBase ProductTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductTypeProvider;
			}
		}
		
		#endregion
		
		#region ProductRateTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductRateType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductRateTypeProviderBase ProductRateTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductRateTypeProvider;
			}
		}
		
		#endregion
		
		#region ProductRateIntervalProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductRateInterval"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductRateIntervalProviderBase ProductRateIntervalProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductRateIntervalProvider;
			}
		}
		
		#endregion
		
		#region ModeratorXtimeUserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ModeratorXtimeUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ModeratorXtimeUserProviderBase ModeratorXtimeUserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ModeratorXtimeUserProvider;
			}
		}
		
		#endregion
		
		#region LeadStageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadStage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadStageProviderBase LeadStageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadStageProvider;
			}
		}
		
		#endregion
		
		#region LeadSourceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadSource"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadSourceProviderBase LeadSourceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadSourceProvider;
			}
		}
		
		#endregion
		
		#region LeadProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadProductProviderBase LeadProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadProductProvider;
			}
		}
		
		#endregion
		
		#region OmnoviaHostedArchiveProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OmnoviaHostedArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OmnoviaHostedArchiveProviderBase OmnoviaHostedArchiveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OmnoviaHostedArchiveProvider;
			}
		}
		
		#endregion
		
		#region OmnoviaHostedArchiveParticipantProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OmnoviaHostedArchiveParticipant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OmnoviaHostedArchiveParticipantProviderBase OmnoviaHostedArchiveParticipantProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OmnoviaHostedArchiveParticipantProvider;
			}
		}
		
		#endregion
		
		#region ProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductProviderBase ProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductProvider;
			}
		}
		
		#endregion
		
		#region ProductRateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductRateProviderBase ProductRateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductRateProvider;
			}
		}
		
		#endregion
		
		#region PrevInvoicesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PrevInvoices"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PrevInvoicesProviderBase PrevInvoicesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PrevInvoicesProvider;
			}
		}
		
		#endregion
		
		#region OmnoviaMp4RequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OmnoviaMp4Request"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OmnoviaMp4RequestProviderBase OmnoviaMp4RequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OmnoviaMp4RequestProvider;
			}
		}
		
		#endregion
		
		#region SystemExtensionLabelProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SystemExtensionLabel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SystemExtensionLabelProviderBase SystemExtensionLabelProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SystemExtensionLabelProvider;
			}
		}
		
		#endregion
		
		#region VerticalProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vertical"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VerticalProviderBase VerticalProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VerticalProvider;
			}
		}
		
		#endregion
		
		#region SystemSettingsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SystemSettings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SystemSettingsProviderBase SystemSettingsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SystemSettingsProvider;
			}
		}
		
		#endregion
		
		#region TicketProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketProductProviderBase TicketProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketProductProvider;
			}
		}
		
		#endregion
		
		#region TicketStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketStatusProviderBase TicketStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketStatusProvider;
			}
		}
		
		#endregion
		
		#region TicketPriorityProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketPriority"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketPriorityProviderBase TicketPriorityProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketPriorityProvider;
			}
		}
		
		#endregion
		
		#region UserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserProviderBase UserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserProvider;
			}
		}
		
		#endregion
		
		#region ValidTicketStateChangesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ValidTicketStateChanges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ValidTicketStateChangesProviderBase ValidTicketStateChangesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ValidTicketStateChangesProvider;
			}
		}
		
		#endregion
		
		#region User_MarketingServiceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User_MarketingService"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static User_MarketingServiceProviderBase User_MarketingServiceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.User_MarketingServiceProvider;
			}
		}
		
		#endregion
		
		#region Moderator_FeatureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Moderator_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Moderator_FeatureProviderBase Moderator_FeatureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Moderator_FeatureProvider;
			}
		}
		
		#endregion
		
		#region UtilProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Util"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UtilProviderBase UtilProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UtilProvider;
			}
		}
		
		#endregion
		
		#region TicketCategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketCategoryProviderBase TicketCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketCategoryProvider;
			}
		}
		
		#endregion
		
		#region TaxableProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Taxable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TaxableProviderBase TaxableProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TaxableProvider;
			}
		}
		
		#endregion
		
		#region WholesalerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Wholesaler"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WholesalerProviderBase WholesalerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WholesalerProvider;
			}
		}
		
		#endregion
		
		#region TicketProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Ticket"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketProviderBase TicketProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketProvider;
			}
		}
		
		#endregion
		
		#region WelcomeKitRequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WelcomeKitRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WelcomeKitRequestProviderBase WelcomeKitRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WelcomeKitRequestProvider;
			}
		}
		
		#endregion
		
		#region Wholesaler_ProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Wholesaler_Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Wholesaler_ProductProviderBase Wholesaler_ProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Wholesaler_ProductProvider;
			}
		}
		
		#endregion
		
		#region SalesPersonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesPerson"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesPersonProviderBase SalesPersonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesPersonProvider;
			}
		}
		
		#endregion
		
		#region MarketingServiceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MarketingService"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MarketingServiceProviderBase MarketingServiceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MarketingServiceProvider;
			}
		}
		
		#endregion
		
		#region ModeratorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Moderator"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ModeratorProviderBase ModeratorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ModeratorProvider;
			}
		}
		
		#endregion
		
		#region ParticipantProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Participant"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ParticipantProviderBase ParticipantProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ParticipantProvider;
			}
		}
		
		#endregion
		
		#region Moderator_DnisProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Moderator_Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Moderator_DnisProviderBase Moderator_DnisProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Moderator_DnisProvider;
			}
		}
		
		#endregion
		
		#region ParticipantListProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ParticipantList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ParticipantListProviderBase ParticipantListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ParticipantListProvider;
			}
		}
		
		#endregion
		
		#region TempReplayIdsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempReplayIds"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempReplayIdsProviderBase TempReplayIdsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempReplayIdsProvider;
			}
		}
		
		#endregion
		
		#region TempExistingCodesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempExistingCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempExistingCodesProviderBase TempExistingCodesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempExistingCodesProvider;
			}
		}
		
		#endregion
		
		#region TempCodesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempCodesProviderBase TempCodesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempCodesProvider;
			}
		}
		
		#endregion
		
		#region TempCodeChangesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempCodeChanges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempCodeChangesProviderBase TempCodeChangesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempCodeChangesProvider;
			}
		}
		
		#endregion
		
		#region TempSampleRatesPerProductProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempSampleRatesPerProduct"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempSampleRatesPerProductProviderBase TempSampleRatesPerProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempSampleRatesPerProductProvider;
			}
		}
		
		#endregion
		
		#region TempTotalDollarsSpentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TempTotalDollarsSpent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TempTotalDollarsSpentProviderBase TempTotalDollarsSpentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TempTotalDollarsSpentProvider;
			}
		}
		
		#endregion
		
		#region RatedCdrProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RatedCdr"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RatedCdrProviderBase RatedCdrProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RatedCdrProvider;
			}
		}
		
		#endregion
		
		#region TrendProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Trend"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TrendProviderBase TrendProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TrendProvider;
			}
		}
		
		#endregion
		
		#region TicketUserAssociationsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketUserAssociations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketUserAssociationsProviderBase TicketUserAssociationsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketUserAssociationsProvider;
			}
		}
		
		#endregion
		
		#region TicketStatusHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TicketStatusHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TicketStatusHistoryProviderBase TicketStatusHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TicketStatusHistoryProvider;
			}
		}
		
		#endregion
		
		#region ProductRateValueProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductRateValue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductRateValueProviderBase ProductRateValueProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductRateValueProvider;
			}
		}
		
		#endregion
		
		#region LeadPeriodProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadPeriodProviderBase LeadPeriodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadPeriodProvider;
			}
		}
		
		#endregion
		
		#region DnisProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DnisProviderBase DnisProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DnisProvider;
			}
		}
		
		#endregion
		
		#region LeadChurnReasonProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadChurnReason"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadChurnReasonProviderBase LeadChurnReasonProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadChurnReasonProvider;
			}
		}
		
		#endregion
		
		#region DnisTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DnisType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DnisTypeProviderBase DnisTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DnisTypeProvider;
			}
		}
		
		#endregion
		
		#region CompanyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Company"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CompanyProviderBase CompanyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CompanyProvider;
			}
		}
		
		#endregion
		
		#region ClientNotesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClientNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClientNotesProviderBase ClientNotesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClientNotesProvider;
			}
		}
		
		#endregion
		
		#region CharityProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Charity"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CharityProviderBase CharityProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CharityProvider;
			}
		}
		
		#endregion
		
		#region CallFlowProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CallFlow"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CallFlowProviderBase CallFlowProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CallFlowProvider;
			}
		}
		
		#endregion
		
		#region CommissionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Commission"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CommissionProviderBase CommissionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CommissionProvider;
			}
		}
		
		#endregion
		
		#region CommissionCustomerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CommissionCustomer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CommissionCustomerProviderBase CommissionCustomerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CommissionCustomerProvider;
			}
		}
		
		#endregion
		
		#region CompanyInfoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CompanyInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CompanyInfoProviderBase CompanyInfoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CompanyInfoProvider;
			}
		}
		
		#endregion
		
		#region CurveProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Curve"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurveProviderBase CurveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurveProvider;
			}
		}
		
		#endregion
		
		#region CompanyLeadTrackingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CompanyLeadTracking"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CompanyLeadTrackingProviderBase CompanyLeadTrackingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CompanyLeadTrackingProvider;
			}
		}
		
		#endregion
		
		#region ConferencingSummaryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ConferencingSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ConferencingSummaryProviderBase ConferencingSummaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ConferencingSummaryProvider;
			}
		}
		
		#endregion
		
		#region BridgeTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BridgeType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BridgeTypeProviderBase BridgeTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BridgeTypeProvider;
			}
		}
		
		#endregion
		
		#region CompanyLeadTrackingNotesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CompanyLeadTrackingNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CompanyLeadTrackingNotesProviderBase CompanyLeadTrackingNotesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CompanyLeadTrackingNotesProvider;
			}
		}
		
		#endregion
		
		#region BridgeRequestTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BridgeRequestType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BridgeRequestTypeProviderBase BridgeRequestTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BridgeRequestTypeProvider;
			}
		}
		
		#endregion
		
		#region AdminSiteNotesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminSiteNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminSiteNotesProviderBase AdminSiteNotesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminSiteNotesProvider;
			}
		}
		
		#endregion
		
		#region ActionTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ActionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ActionTypeProviderBase ActionTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ActionTypeProvider;
			}
		}
		
		#endregion
		
		#region ActionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Action"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ActionProviderBase ActionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ActionProvider;
			}
		}
		
		#endregion
		
		#region AccountManagerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AccountManager"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AccountManagerProviderBase AccountManagerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccountManagerProvider;
			}
		}
		
		#endregion
		
		#region AccessType_ProductRateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AccessType_ProductRate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AccessType_ProductRateProviderBase AccessType_ProductRateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccessType_ProductRateProvider;
			}
		}
		
		#endregion
		
		#region AdminSiteNotesHistoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminSiteNotesHistory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminSiteNotesHistoryProviderBase AdminSiteNotesHistoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminSiteNotesHistoryProvider;
			}
		}
		
		#endregion
		
		#region AreaCodeNxxProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AreaCodeNxx"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AreaCodeNxxProviderBase AreaCodeNxxProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AreaCodeNxxProvider;
			}
		}
		
		#endregion
		
		#region AuditLogProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AuditLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AuditLogProviderBase AuditLogProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AuditLogProvider;
			}
		}
		
		#endregion
		
		#region BridgeRequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BridgeRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BridgeRequestProviderBase BridgeRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BridgeRequestProvider;
			}
		}
		
		#endregion
		
		#region BridgeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Bridge"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BridgeProviderBase BridgeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BridgeProvider;
			}
		}
		
		#endregion
		
		#region BillableLegsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BillableLegs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BillableLegsProviderBase BillableLegsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BillableLegsProvider;
			}
		}
		
		#endregion
		
		#region CustomerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerProviderBase CustomerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerProvider;
			}
		}
		
		#endregion
		
		#region AverageRatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AverageRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AverageRatesProviderBase AverageRatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AverageRatesProvider;
			}
		}
		
		#endregion
		
		#region BridgeQueueProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BridgeQueue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BridgeQueueProviderBase BridgeQueueProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BridgeQueueProvider;
			}
		}
		
		#endregion
		
		#region ForExProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ForEx"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ForExProviderBase ForExProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ForExProvider;
			}
		}
		
		#endregion
		
		#region Customer_DnisProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customer_Dnis"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Customer_DnisProviderBase Customer_DnisProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Customer_DnisProvider;
			}
		}
		
		#endregion
		
		#region FeatureOptionTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="FeatureOptionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FeatureOptionTypeProviderBase FeatureOptionTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FeatureOptionTypeProvider;
			}
		}
		
		#endregion
		
		#region FeatureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FeatureProviderBase FeatureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FeatureProvider;
			}
		}
		
		#endregion
		
		#region GlPostingTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="GlPostingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GlPostingTypeProviderBase GlPostingTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GlPostingTypeProvider;
			}
		}
		
		#endregion
		
		#region FeatureOptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="FeatureOption"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FeatureOptionProviderBase FeatureOptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FeatureOptionProvider;
			}
		}
		
		#endregion
		
		#region InvoiceChargesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="InvoiceCharges"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceChargesProviderBase InvoiceChargesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceChargesProvider;
			}
		}
		
		#endregion
		
		#region InvoiceNotesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="InvoiceNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceNotesProviderBase InvoiceNotesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceNotesProvider;
			}
		}
		
		#endregion
		
		#region LeadProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Lead"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadProviderBase LeadProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadProvider;
			}
		}
		
		#endregion
		
		#region LanguageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Language"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LanguageProviderBase LanguageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LanguageProvider;
			}
		}
		
		#endregion
		
		#region IrWholesalerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="IrWholesaler"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IrWholesalerProviderBase IrWholesalerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IrWholesalerProvider;
			}
		}
		
		#endregion
		
		#region InvoiceSummaryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="InvoiceSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceSummaryProviderBase InvoiceSummaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceSummaryProvider;
			}
		}
		
		#endregion
		
		#region ExtensionTypeCategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ExtensionTypeCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ExtensionTypeCategoryProviderBase ExtensionTypeCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ExtensionTypeCategoryProvider;
			}
		}
		
		#endregion
		
		#region ExtensionTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ExtensionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ExtensionTypeProviderBase ExtensionTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ExtensionTypeProvider;
			}
		}
		
		#endregion
		
		#region EventManagerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EventManager"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EventManagerProviderBase EventManagerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EventManagerProvider;
			}
		}
		
		#endregion
		
		#region CustomerTransactionImportProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerTransactionImport"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerTransactionImportProviderBase CustomerTransactionImportProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerTransactionImportProvider;
			}
		}
		
		#endregion
		
		#region CustomerReviewProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerReview"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerReviewProviderBase CustomerReviewProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerReviewProvider;
			}
		}
		
		#endregion
		
		#region CustomerDocumentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerDocument"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerDocumentProviderBase CustomerDocumentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerDocumentProvider;
			}
		}
		
		#endregion
		
		#region Customer_FeatureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customer_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Customer_FeatureProviderBase Customer_FeatureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Customer_FeatureProvider;
			}
		}
		
		#endregion
		
		#region CustomerTransactionTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerTransactionType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerTransactionTypeProviderBase CustomerTransactionTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerTransactionTypeProvider;
			}
		}
		
		#endregion
		
		#region DepartmentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DepartmentProviderBase DepartmentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DepartmentProvider;
			}
		}
		
		#endregion
		
		#region ErrorCodesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ErrorCodes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ErrorCodesProviderBase ErrorCodesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ErrorCodesProvider;
			}
		}
		
		#endregion
		
		#region EmailTemplateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmailTemplate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmailTemplateProviderBase EmailTemplateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmailTemplateProvider;
			}
		}
		
		#endregion
		
		#region EmailNotificationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmailNotification"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmailNotificationProviderBase EmailNotificationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmailNotificationProvider;
			}
		}
		
		#endregion
		
		#region CustomerTransactionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerTransaction"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerTransactionProviderBase CustomerTransactionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerTransactionProvider;
			}
		}
		
		#endregion
		
		#region DocumentTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DocumentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DocumentTypeProviderBase DocumentTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DocumentTypeProvider;
			}
		}
		
		#endregion
		
		#region Wholesaler_Product_FeatureProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Wholesaler_Product_Feature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Wholesaler_Product_FeatureProviderBase Wholesaler_Product_FeatureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Wholesaler_Product_FeatureProvider;
			}
		}
		
		#endregion
		
		
		#region Vw_AccessType_ProductRatesProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_AccessType_ProductRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_AccessType_ProductRatesProviderBase Vw_AccessType_ProductRatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_AccessType_ProductRatesProvider;
			}
		}
		
		#endregion
		
		#region Vw_ConferenceCallList_UniqueProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_ConferenceCallList_Unique"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_ConferenceCallList_UniqueProviderBase Vw_ConferenceCallList_UniqueProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_ConferenceCallList_UniqueProvider;
			}
		}
		
		#endregion
		
		#region Vw_ConferenceListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_ConferenceList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_ConferenceListProviderBase Vw_ConferenceListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_ConferenceListProvider;
			}
		}
		
		#endregion
		
		#region Vw_CustomerListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_CustomerList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_CustomerListProviderBase Vw_CustomerListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_CustomerListProvider;
			}
		}
		
		#endregion
		
		#region Vw_CustomerTransactionListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_CustomerTransactionList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_CustomerTransactionListProviderBase Vw_CustomerTransactionListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_CustomerTransactionListProvider;
			}
		}
		
		#endregion
		
		#region Vw_DefaultProductRatesProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_DefaultProductRates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_DefaultProductRatesProviderBase Vw_DefaultProductRatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_DefaultProductRatesProvider;
			}
		}
		
		#endregion
		
		#region Vw_FeatureOptionsForCustomersProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_FeatureOptionsForCustomers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_FeatureOptionsForCustomersProviderBase Vw_FeatureOptionsForCustomersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_FeatureOptionsForCustomersProvider;
			}
		}
		
		#endregion
		
		#region Vw_FeatureOptionsForModeratorsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_FeatureOptionsForModerators"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_FeatureOptionsForModeratorsProviderBase Vw_FeatureOptionsForModeratorsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_FeatureOptionsForModeratorsProvider;
			}
		}
		
		#endregion
		
		#region Vw_ModeratorListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_ModeratorList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_ModeratorListProviderBase Vw_ModeratorListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_ModeratorListProvider;
			}
		}
		
		#endregion
		
		#region Vw_ModeratorList_AdminSiteProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_ModeratorList_AdminSite"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_ModeratorList_AdminSiteProviderBase Vw_ModeratorList_AdminSiteProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_ModeratorList_AdminSiteProvider;
			}
		}
		
		#endregion
		
		#region Vw_RecordingListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_RecordingList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_RecordingListProviderBase Vw_RecordingListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_RecordingListProvider;
			}
		}
		
		#endregion
		
		#region Vw_SystemExtension_AllProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_SystemExtension_All"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_SystemExtension_AllProviderBase Vw_SystemExtension_AllProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_SystemExtension_AllProvider;
			}
		}
		
		#endregion
		
		#region Vw_SystemExtension_CustomerLabelProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_SystemExtension_CustomerLabel"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_SystemExtension_CustomerLabelProviderBase Vw_SystemExtension_CustomerLabelProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_SystemExtension_CustomerLabelProvider;
			}
		}
		
		#endregion
		
		#region Vw_SystemExtension_ValueProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_SystemExtension_Value"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_SystemExtension_ValueProviderBase Vw_SystemExtension_ValueProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_SystemExtension_ValueProvider;
			}
		}
		
		#endregion
		
		#region Vw_UserListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Vw_UserList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Vw_UserListProviderBase Vw_UserListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Vw_UserListProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region AccessTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeFilters : AccessTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilters class.
		/// </summary>
		public AccessTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessTypeFilters
	
	#region AccessTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AccessTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeQuery : AccessTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeQuery class.
		/// </summary>
		public AccessTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessTypeQuery
		
	#region RecordingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingFilters : RecordingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingFilters class.
		/// </summary>
		public RecordingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingFilters
	
	#region RecordingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RecordingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingQuery : RecordingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingQuery class.
		/// </summary>
		public RecordingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingQuery
		
	#region RecordingParticipantUsageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageFilters : RecordingParticipantUsageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilters class.
		/// </summary>
		public RecordingParticipantUsageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingParticipantUsageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingParticipantUsageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingParticipantUsageFilters
	
	#region RecordingParticipantUsageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RecordingParticipantUsageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageQuery : RecordingParticipantUsageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageQuery class.
		/// </summary>
		public RecordingParticipantUsageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingParticipantUsageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingParticipantUsageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingParticipantUsageQuery
		
	#region RatingTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatingTypeFilters : RatingTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatingTypeFilters class.
		/// </summary>
		public RatingTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatingTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatingTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatingTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatingTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatingTypeFilters
	
	#region RatingTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RatingTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RatingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatingTypeQuery : RatingTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatingTypeQuery class.
		/// </summary>
		public RatingTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatingTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatingTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatingTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatingTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatingTypeQuery
		
	#region PromptSetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PromptSet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PromptSetFilters : PromptSetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PromptSetFilters class.
		/// </summary>
		public PromptSetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PromptSetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PromptSetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PromptSetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PromptSetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PromptSetFilters
	
	#region PromptSetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PromptSetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PromptSet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PromptSetQuery : PromptSetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PromptSetQuery class.
		/// </summary>
		public PromptSetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PromptSetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PromptSetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PromptSetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PromptSetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PromptSetQuery
		
	#region RoleFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Role"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleFilters : RoleFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleFilters class.
		/// </summary>
		public RoleFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RoleFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RoleFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RoleFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RoleFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RoleFilters
	
	#region RoleQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RoleParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Role"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleQuery : RoleParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleQuery class.
		/// </summary>
		public RoleQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RoleQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RoleQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RoleQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RoleQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RoleQuery
		
	#region SeeVoghMeetingTrackerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeeVoghMeetingTracker"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeeVoghMeetingTrackerFilters : SeeVoghMeetingTrackerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilters class.
		/// </summary>
		public SeeVoghMeetingTrackerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeeVoghMeetingTrackerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeeVoghMeetingTrackerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeeVoghMeetingTrackerFilters
	
	#region SeeVoghMeetingTrackerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SeeVoghMeetingTrackerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SeeVoghMeetingTracker"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeeVoghMeetingTrackerQuery : SeeVoghMeetingTrackerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerQuery class.
		/// </summary>
		public SeeVoghMeetingTrackerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeeVoghMeetingTrackerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeeVoghMeetingTrackerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeeVoghMeetingTrackerQuery
		
	#region CountryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryFilters : CountryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryFilters class.
		/// </summary>
		public CountryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryFilters
	
	#region CountryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryQuery : CountryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryQuery class.
		/// </summary>
		public CountryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryQuery
		
	#region CurrencyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyFilters : CurrencyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		public CurrencyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyFilters
	
	#region CurrencyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurrencyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyQuery : CurrencyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		public CurrencyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyQuery
		
	#region SystemExtensionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionFilters : SystemExtensionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilters class.
		/// </summary>
		public SystemExtensionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionFilters
	
	#region SystemExtensionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SystemExtensionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionQuery : SystemExtensionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionQuery class.
		/// </summary>
		public SystemExtensionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionQuery
		
	#region StateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateFilters : StateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateFilters class.
		/// </summary>
		public StateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateFilters
	
	#region StateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateQuery : StateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateQuery class.
		/// </summary>
		public StateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateQuery
		
	#region ProductTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeFilters : ProductTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilters class.
		/// </summary>
		public ProductTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeFilters
	
	#region ProductTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeQuery : ProductTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeQuery class.
		/// </summary>
		public ProductTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeQuery
		
	#region ProductRateTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateTypeFilters : ProductRateTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeFilters class.
		/// </summary>
		public ProductRateTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateTypeFilters
	
	#region ProductRateTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductRateTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductRateType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateTypeQuery : ProductRateTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeQuery class.
		/// </summary>
		public ProductRateTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateTypeQuery
		
	#region ProductRateIntervalFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateInterval"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateIntervalFilters : ProductRateIntervalFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalFilters class.
		/// </summary>
		public ProductRateIntervalFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateIntervalFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateIntervalFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateIntervalFilters
	
	#region ProductRateIntervalQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductRateIntervalParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductRateInterval"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateIntervalQuery : ProductRateIntervalParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalQuery class.
		/// </summary>
		public ProductRateIntervalQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateIntervalQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateIntervalQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateIntervalQuery
		
	#region ModeratorXtimeUserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserFilters : ModeratorXtimeUserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilters class.
		/// </summary>
		public ModeratorXtimeUserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorXtimeUserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorXtimeUserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorXtimeUserFilters
	
	#region ModeratorXtimeUserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ModeratorXtimeUserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserQuery : ModeratorXtimeUserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserQuery class.
		/// </summary>
		public ModeratorXtimeUserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorXtimeUserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorXtimeUserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorXtimeUserQuery
		
	#region LeadStageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadStage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadStageFilters : LeadStageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadStageFilters class.
		/// </summary>
		public LeadStageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadStageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadStageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadStageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadStageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadStageFilters
	
	#region LeadStageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadStageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadStage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadStageQuery : LeadStageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadStageQuery class.
		/// </summary>
		public LeadStageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadStageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadStageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadStageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadStageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadStageQuery
		
	#region LeadSourceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceFilters : LeadSourceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilters class.
		/// </summary>
		public LeadSourceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadSourceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadSourceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadSourceFilters
	
	#region LeadSourceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadSourceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceQuery : LeadSourceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceQuery class.
		/// </summary>
		public LeadSourceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadSourceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadSourceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadSourceQuery
		
	#region LeadProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProductFilters : LeadProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadProductFilters class.
		/// </summary>
		public LeadProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadProductFilters
	
	#region LeadProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProductQuery : LeadProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadProductQuery class.
		/// </summary>
		public LeadProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadProductQuery
		
	#region OmnoviaHostedArchiveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveFilters : OmnoviaHostedArchiveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilters class.
		/// </summary>
		public OmnoviaHostedArchiveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveFilters
	
	#region OmnoviaHostedArchiveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OmnoviaHostedArchiveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveQuery : OmnoviaHostedArchiveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveQuery class.
		/// </summary>
		public OmnoviaHostedArchiveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveQuery
		
	#region OmnoviaHostedArchiveParticipantFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantFilters : OmnoviaHostedArchiveParticipantFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilters class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveParticipantFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveParticipantFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveParticipantFilters
	
	#region OmnoviaHostedArchiveParticipantQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OmnoviaHostedArchiveParticipantParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantQuery : OmnoviaHostedArchiveParticipantParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantQuery class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveParticipantQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveParticipantQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveParticipantQuery
		
	#region ProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilters : ProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		public ProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilters
	
	#region ProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductQuery : ProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		public ProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductQuery
		
	#region ProductRateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateFilters : ProductRateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateFilters class.
		/// </summary>
		public ProductRateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateFilters
	
	#region ProductRateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductRateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateQuery : ProductRateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateQuery class.
		/// </summary>
		public ProductRateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateQuery
		
	#region PrevInvoicesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PrevInvoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PrevInvoicesFilters : PrevInvoicesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesFilters class.
		/// </summary>
		public PrevInvoicesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PrevInvoicesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PrevInvoicesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PrevInvoicesFilters
	
	#region PrevInvoicesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PrevInvoicesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PrevInvoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PrevInvoicesQuery : PrevInvoicesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesQuery class.
		/// </summary>
		public PrevInvoicesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PrevInvoicesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PrevInvoicesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PrevInvoicesQuery
		
	#region OmnoviaMp4RequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestFilters : OmnoviaMp4RequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilters class.
		/// </summary>
		public OmnoviaMp4RequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaMp4RequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaMp4RequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaMp4RequestFilters
	
	#region OmnoviaMp4RequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OmnoviaMp4RequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestQuery : OmnoviaMp4RequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestQuery class.
		/// </summary>
		public OmnoviaMp4RequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaMp4RequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaMp4RequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaMp4RequestQuery
		
	#region SystemExtensionLabelFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelFilters : SystemExtensionLabelFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilters class.
		/// </summary>
		public SystemExtensionLabelFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionLabelFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionLabelFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionLabelFilters
	
	#region SystemExtensionLabelQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SystemExtensionLabelParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelQuery : SystemExtensionLabelParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelQuery class.
		/// </summary>
		public SystemExtensionLabelQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionLabelQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionLabelQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionLabelQuery
		
	#region VerticalFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vertical"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VerticalFilters : VerticalFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VerticalFilters class.
		/// </summary>
		public VerticalFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VerticalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VerticalFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VerticalFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VerticalFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VerticalFilters
	
	#region VerticalQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VerticalParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vertical"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VerticalQuery : VerticalParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VerticalQuery class.
		/// </summary>
		public VerticalQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VerticalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VerticalQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VerticalQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VerticalQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VerticalQuery
		
	#region SystemSettingsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemSettingsFilters : SystemSettingsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemSettingsFilters class.
		/// </summary>
		public SystemSettingsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemSettingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemSettingsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemSettingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemSettingsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemSettingsFilters
	
	#region SystemSettingsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SystemSettingsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SystemSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemSettingsQuery : SystemSettingsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemSettingsQuery class.
		/// </summary>
		public SystemSettingsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemSettingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemSettingsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemSettingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemSettingsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemSettingsQuery
		
	#region TicketProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProductFilters : TicketProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketProductFilters class.
		/// </summary>
		public TicketProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketProductFilters
	
	#region TicketProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProductQuery : TicketProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketProductQuery class.
		/// </summary>
		public TicketProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketProductQuery
		
	#region TicketStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusFilters : TicketStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilters class.
		/// </summary>
		public TicketStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusFilters
	
	#region TicketStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusQuery : TicketStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusQuery class.
		/// </summary>
		public TicketStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusQuery
		
	#region TicketPriorityFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketPriority"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketPriorityFilters : TicketPriorityFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketPriorityFilters class.
		/// </summary>
		public TicketPriorityFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketPriorityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketPriorityFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketPriorityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketPriorityFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketPriorityFilters
	
	#region TicketPriorityQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketPriorityParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketPriority"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketPriorityQuery : TicketPriorityParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketPriorityQuery class.
		/// </summary>
		public TicketPriorityQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketPriorityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketPriorityQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketPriorityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketPriorityQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketPriorityQuery
		
	#region UserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilters : UserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		public UserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilters
	
	#region UserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserQuery : UserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		public UserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserQuery
		
	#region ValidTicketStateChangesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesFilters : ValidTicketStateChangesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilters class.
		/// </summary>
		public ValidTicketStateChangesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ValidTicketStateChangesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ValidTicketStateChangesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ValidTicketStateChangesFilters
	
	#region ValidTicketStateChangesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ValidTicketStateChangesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesQuery : ValidTicketStateChangesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesQuery class.
		/// </summary>
		public ValidTicketStateChangesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ValidTicketStateChangesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ValidTicketStateChangesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ValidTicketStateChangesQuery
		
	#region User_MarketingServiceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceFilters : User_MarketingServiceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilters class.
		/// </summary>
		public User_MarketingServiceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public User_MarketingServiceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public User_MarketingServiceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion User_MarketingServiceFilters
	
	#region User_MarketingServiceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="User_MarketingServiceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceQuery : User_MarketingServiceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceQuery class.
		/// </summary>
		public User_MarketingServiceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public User_MarketingServiceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public User_MarketingServiceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion User_MarketingServiceQuery
		
	#region Moderator_FeatureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_FeatureFilters : Moderator_FeatureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureFilters class.
		/// </summary>
		public Moderator_FeatureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_FeatureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_FeatureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_FeatureFilters
	
	#region Moderator_FeatureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Moderator_FeatureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Moderator_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_FeatureQuery : Moderator_FeatureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureQuery class.
		/// </summary>
		public Moderator_FeatureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_FeatureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_FeatureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_FeatureQuery
		
	#region UtilFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Util"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UtilFilters : UtilFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UtilFilters class.
		/// </summary>
		public UtilFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UtilFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UtilFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UtilFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UtilFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UtilFilters
	
	#region UtilQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UtilParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Util"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UtilQuery : UtilParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UtilQuery class.
		/// </summary>
		public UtilQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UtilQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UtilQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UtilQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UtilQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UtilQuery
		
	#region TicketCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketCategoryFilters : TicketCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketCategoryFilters class.
		/// </summary>
		public TicketCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketCategoryFilters
	
	#region TicketCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketCategoryQuery : TicketCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketCategoryQuery class.
		/// </summary>
		public TicketCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketCategoryQuery
		
	#region TaxableFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Taxable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxableFilters : TaxableFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxableFilters class.
		/// </summary>
		public TaxableFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaxableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaxableFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaxableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaxableFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaxableFilters
	
	#region TaxableQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TaxableParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Taxable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxableQuery : TaxableParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxableQuery class.
		/// </summary>
		public TaxableQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaxableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaxableQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaxableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaxableQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaxableQuery
		
	#region WholesalerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerFilters : WholesalerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerFilters class.
		/// </summary>
		public WholesalerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WholesalerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WholesalerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WholesalerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WholesalerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WholesalerFilters
	
	#region WholesalerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WholesalerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerQuery : WholesalerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerQuery class.
		/// </summary>
		public WholesalerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WholesalerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WholesalerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WholesalerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WholesalerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WholesalerQuery
		
	#region TicketFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketFilters : TicketFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketFilters class.
		/// </summary>
		public TicketFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketFilters
	
	#region TicketQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketQuery : TicketParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketQuery class.
		/// </summary>
		public TicketQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketQuery
		
	#region WelcomeKitRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WelcomeKitRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WelcomeKitRequestFilters : WelcomeKitRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestFilters class.
		/// </summary>
		public WelcomeKitRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WelcomeKitRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WelcomeKitRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WelcomeKitRequestFilters
	
	#region WelcomeKitRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WelcomeKitRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WelcomeKitRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WelcomeKitRequestQuery : WelcomeKitRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestQuery class.
		/// </summary>
		public WelcomeKitRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WelcomeKitRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WelcomeKitRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WelcomeKitRequestQuery
		
	#region Wholesaler_ProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductFilters : Wholesaler_ProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilters class.
		/// </summary>
		public Wholesaler_ProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_ProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_ProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_ProductFilters
	
	#region Wholesaler_ProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Wholesaler_ProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductQuery : Wholesaler_ProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductQuery class.
		/// </summary>
		public Wholesaler_ProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_ProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_ProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_ProductQuery
		
	#region SalesPersonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonFilters : SalesPersonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		public SalesPersonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonFilters
	
	#region SalesPersonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesPersonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonQuery : SalesPersonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		public SalesPersonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonQuery
		
	#region MarketingServiceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceFilters : MarketingServiceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilters class.
		/// </summary>
		public MarketingServiceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MarketingServiceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MarketingServiceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MarketingServiceFilters
	
	#region MarketingServiceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MarketingServiceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceQuery : MarketingServiceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceQuery class.
		/// </summary>
		public MarketingServiceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MarketingServiceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MarketingServiceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MarketingServiceQuery
		
	#region ModeratorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorFilters : ModeratorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorFilters class.
		/// </summary>
		public ModeratorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorFilters
	
	#region ModeratorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ModeratorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorQuery : ModeratorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorQuery class.
		/// </summary>
		public ModeratorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorQuery
		
	#region ParticipantFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantFilters : ParticipantFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantFilters class.
		/// </summary>
		public ParticipantFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantFilters
	
	#region ParticipantQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParticipantParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantQuery : ParticipantParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantQuery class.
		/// </summary>
		public ParticipantQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantQuery
		
	#region Moderator_DnisFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisFilters : Moderator_DnisFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilters class.
		/// </summary>
		public Moderator_DnisFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_DnisFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_DnisFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_DnisFilters
	
	#region Moderator_DnisQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Moderator_DnisParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisQuery : Moderator_DnisParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisQuery class.
		/// </summary>
		public Moderator_DnisQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_DnisQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_DnisQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_DnisQuery
		
	#region ParticipantListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ParticipantList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantListFilters : ParticipantListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantListFilters class.
		/// </summary>
		public ParticipantListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantListFilters
	
	#region ParticipantListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParticipantListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ParticipantList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantListQuery : ParticipantListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantListQuery class.
		/// </summary>
		public ParticipantListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantListQuery
		
	#region TempReplayIdsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsFilters : TempReplayIdsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilters class.
		/// </summary>
		public TempReplayIdsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempReplayIdsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempReplayIdsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempReplayIdsFilters
	
	#region TempReplayIdsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempReplayIdsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsQuery : TempReplayIdsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsQuery class.
		/// </summary>
		public TempReplayIdsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempReplayIdsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempReplayIdsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempReplayIdsQuery
		
	#region TempExistingCodesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempExistingCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempExistingCodesFilters : TempExistingCodesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilters class.
		/// </summary>
		public TempExistingCodesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempExistingCodesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempExistingCodesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempExistingCodesFilters
	
	#region TempExistingCodesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempExistingCodesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempExistingCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempExistingCodesQuery : TempExistingCodesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesQuery class.
		/// </summary>
		public TempExistingCodesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempExistingCodesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempExistingCodesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempExistingCodesQuery
		
	#region TempCodesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodesFilters : TempCodesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodesFilters class.
		/// </summary>
		public TempCodesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodesFilters
	
	#region TempCodesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempCodesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodesQuery : TempCodesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodesQuery class.
		/// </summary>
		public TempCodesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodesQuery
		
	#region TempCodeChangesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesFilters : TempCodeChangesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilters class.
		/// </summary>
		public TempCodeChangesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodeChangesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodeChangesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodeChangesFilters
	
	#region TempCodeChangesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempCodeChangesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesQuery : TempCodeChangesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesQuery class.
		/// </summary>
		public TempCodeChangesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodeChangesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodeChangesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodeChangesQuery
		
	#region TempSampleRatesPerProductFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempSampleRatesPerProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempSampleRatesPerProductFilters : TempSampleRatesPerProductFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductFilters class.
		/// </summary>
		public TempSampleRatesPerProductFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempSampleRatesPerProductFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempSampleRatesPerProductFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempSampleRatesPerProductFilters
	
	#region TempSampleRatesPerProductQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempSampleRatesPerProductParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempSampleRatesPerProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempSampleRatesPerProductQuery : TempSampleRatesPerProductParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductQuery class.
		/// </summary>
		public TempSampleRatesPerProductQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempSampleRatesPerProductQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempSampleRatesPerProductQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempSampleRatesPerProductQuery
		
	#region TempTotalDollarsSpentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentFilters : TempTotalDollarsSpentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilters class.
		/// </summary>
		public TempTotalDollarsSpentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempTotalDollarsSpentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempTotalDollarsSpentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempTotalDollarsSpentFilters
	
	#region TempTotalDollarsSpentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TempTotalDollarsSpentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentQuery : TempTotalDollarsSpentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentQuery class.
		/// </summary>
		public TempTotalDollarsSpentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempTotalDollarsSpentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempTotalDollarsSpentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempTotalDollarsSpentQuery
		
	#region RatedCdrFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrFilters : RatedCdrFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilters class.
		/// </summary>
		public RatedCdrFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatedCdrFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatedCdrFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatedCdrFilters
	
	#region RatedCdrQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RatedCdrParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrQuery : RatedCdrParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrQuery class.
		/// </summary>
		public RatedCdrQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatedCdrQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatedCdrQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatedCdrQuery
		
	#region TrendFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendFilters : TrendFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendFilters class.
		/// </summary>
		public TrendFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrendFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrendFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrendFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrendFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrendFilters
	
	#region TrendQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TrendParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendQuery : TrendParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendQuery class.
		/// </summary>
		public TrendQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrendQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrendQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrendQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrendQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrendQuery
		
	#region TicketUserAssociationsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsFilters : TicketUserAssociationsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilters class.
		/// </summary>
		public TicketUserAssociationsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketUserAssociationsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketUserAssociationsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketUserAssociationsFilters
	
	#region TicketUserAssociationsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketUserAssociationsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsQuery : TicketUserAssociationsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsQuery class.
		/// </summary>
		public TicketUserAssociationsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketUserAssociationsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketUserAssociationsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketUserAssociationsQuery
		
	#region TicketStatusHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryFilters : TicketStatusHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilters class.
		/// </summary>
		public TicketStatusHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusHistoryFilters
	
	#region TicketStatusHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TicketStatusHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryQuery : TicketStatusHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryQuery class.
		/// </summary>
		public TicketStatusHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusHistoryQuery
		
	#region ProductRateValueFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueFilters : ProductRateValueFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilters class.
		/// </summary>
		public ProductRateValueFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateValueFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateValueFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateValueFilters
	
	#region ProductRateValueQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductRateValueParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueQuery : ProductRateValueParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueQuery class.
		/// </summary>
		public ProductRateValueQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateValueQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateValueQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateValueQuery
		
	#region LeadPeriodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadPeriodFilters : LeadPeriodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadPeriodFilters class.
		/// </summary>
		public LeadPeriodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadPeriodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadPeriodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadPeriodFilters
	
	#region LeadPeriodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadPeriodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadPeriodQuery : LeadPeriodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadPeriodQuery class.
		/// </summary>
		public LeadPeriodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadPeriodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadPeriodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadPeriodQuery
		
	#region DnisFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisFilters : DnisFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisFilters class.
		/// </summary>
		public DnisFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisFilters
	
	#region DnisQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DnisParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisQuery : DnisParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisQuery class.
		/// </summary>
		public DnisQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisQuery
		
	#region LeadChurnReasonFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadChurnReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadChurnReasonFilters : LeadChurnReasonFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonFilters class.
		/// </summary>
		public LeadChurnReasonFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadChurnReasonFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadChurnReasonFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadChurnReasonFilters
	
	#region LeadChurnReasonQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadChurnReasonParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadChurnReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadChurnReasonQuery : LeadChurnReasonParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonQuery class.
		/// </summary>
		public LeadChurnReasonQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadChurnReasonQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadChurnReasonQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadChurnReasonQuery
		
	#region DnisTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DnisType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisTypeFilters : DnisTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisTypeFilters class.
		/// </summary>
		public DnisTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisTypeFilters
	
	#region DnisTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DnisTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DnisType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisTypeQuery : DnisTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisTypeQuery class.
		/// </summary>
		public DnisTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisTypeQuery
		
	#region CompanyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Company"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyFilters : CompanyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyFilters class.
		/// </summary>
		public CompanyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyFilters
	
	#region CompanyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CompanyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Company"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyQuery : CompanyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyQuery class.
		/// </summary>
		public CompanyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyQuery
		
	#region ClientNotesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientNotesFilters : ClientNotesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientNotesFilters class.
		/// </summary>
		public ClientNotesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientNotesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientNotesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientNotesFilters
	
	#region ClientNotesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClientNotesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClientNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientNotesQuery : ClientNotesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientNotesQuery class.
		/// </summary>
		public ClientNotesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClientNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClientNotesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClientNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClientNotesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClientNotesQuery
		
	#region CharityFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Charity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CharityFilters : CharityFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CharityFilters class.
		/// </summary>
		public CharityFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CharityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CharityFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CharityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CharityFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CharityFilters
	
	#region CharityQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CharityParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Charity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CharityQuery : CharityParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CharityQuery class.
		/// </summary>
		public CharityQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CharityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CharityQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CharityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CharityQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CharityQuery
		
	#region CallFlowFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CallFlow"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CallFlowFilters : CallFlowFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CallFlowFilters class.
		/// </summary>
		public CallFlowFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CallFlowFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CallFlowFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CallFlowFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CallFlowFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CallFlowFilters
	
	#region CallFlowQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CallFlowParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CallFlow"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CallFlowQuery : CallFlowParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CallFlowQuery class.
		/// </summary>
		public CallFlowQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CallFlowQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CallFlowQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CallFlowQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CallFlowQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CallFlowQuery
		
	#region CommissionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionFilters : CommissionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionFilters class.
		/// </summary>
		public CommissionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionFilters
	
	#region CommissionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CommissionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionQuery : CommissionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionQuery class.
		/// </summary>
		public CommissionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionQuery
		
	#region CommissionCustomerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionCustomerFilters : CommissionCustomerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerFilters class.
		/// </summary>
		public CommissionCustomerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionCustomerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionCustomerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionCustomerFilters
	
	#region CommissionCustomerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CommissionCustomerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CommissionCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionCustomerQuery : CommissionCustomerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerQuery class.
		/// </summary>
		public CommissionCustomerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionCustomerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionCustomerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionCustomerQuery
		
	#region CompanyInfoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoFilters : CompanyInfoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilters class.
		/// </summary>
		public CompanyInfoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyInfoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyInfoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyInfoFilters
	
	#region CompanyInfoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CompanyInfoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoQuery : CompanyInfoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoQuery class.
		/// </summary>
		public CompanyInfoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyInfoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyInfoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyInfoQuery
		
	#region CurveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Curve"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurveFilters : CurveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurveFilters class.
		/// </summary>
		public CurveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurveFilters
	
	#region CurveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Curve"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurveQuery : CurveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurveQuery class.
		/// </summary>
		public CurveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurveQuery
		
	#region CompanyLeadTrackingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingFilters : CompanyLeadTrackingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilters class.
		/// </summary>
		public CompanyLeadTrackingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingFilters
	
	#region CompanyLeadTrackingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CompanyLeadTrackingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingQuery : CompanyLeadTrackingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingQuery class.
		/// </summary>
		public CompanyLeadTrackingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingQuery
		
	#region ConferencingSummaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryFilters : ConferencingSummaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilters class.
		/// </summary>
		public ConferencingSummaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConferencingSummaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConferencingSummaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConferencingSummaryFilters
	
	#region ConferencingSummaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ConferencingSummaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryQuery : ConferencingSummaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryQuery class.
		/// </summary>
		public ConferencingSummaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConferencingSummaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConferencingSummaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConferencingSummaryQuery
		
	#region BridgeTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeTypeFilters : BridgeTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeTypeFilters class.
		/// </summary>
		public BridgeTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeTypeFilters
	
	#region BridgeTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BridgeTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BridgeType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeTypeQuery : BridgeTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeTypeQuery class.
		/// </summary>
		public BridgeTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeTypeQuery
		
	#region CompanyLeadTrackingNotesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesFilters : CompanyLeadTrackingNotesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilters class.
		/// </summary>
		public CompanyLeadTrackingNotesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingNotesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingNotesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingNotesFilters
	
	#region CompanyLeadTrackingNotesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CompanyLeadTrackingNotesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesQuery : CompanyLeadTrackingNotesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesQuery class.
		/// </summary>
		public CompanyLeadTrackingNotesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingNotesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingNotesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingNotesQuery
		
	#region BridgeRequestTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequestType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestTypeFilters : BridgeRequestTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeFilters class.
		/// </summary>
		public BridgeRequestTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestTypeFilters
	
	#region BridgeRequestTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BridgeRequestTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BridgeRequestType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestTypeQuery : BridgeRequestTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeQuery class.
		/// </summary>
		public BridgeRequestTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestTypeQuery
		
	#region AdminSiteNotesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesFilters : AdminSiteNotesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesFilters class.
		/// </summary>
		public AdminSiteNotesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesFilters
	
	#region AdminSiteNotesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminSiteNotesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesQuery : AdminSiteNotesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesQuery class.
		/// </summary>
		public AdminSiteNotesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesQuery
		
	#region ActionTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeFilters : ActionTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		public ActionTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeFilters
	
	#region ActionTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ActionTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeQuery : ActionTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		public ActionTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeQuery
		
	#region ActionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionFilters : ActionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionFilters class.
		/// </summary>
		public ActionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionFilters
	
	#region ActionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ActionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionQuery : ActionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionQuery class.
		/// </summary>
		public ActionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionQuery
		
	#region AccountManagerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccountManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountManagerFilters : AccountManagerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountManagerFilters class.
		/// </summary>
		public AccountManagerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountManagerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountManagerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountManagerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountManagerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountManagerFilters
	
	#region AccountManagerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AccountManagerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AccountManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountManagerQuery : AccountManagerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountManagerQuery class.
		/// </summary>
		public AccountManagerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountManagerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountManagerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountManagerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountManagerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountManagerQuery
		
	#region AccessType_ProductRateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateFilters : AccessType_ProductRateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilters class.
		/// </summary>
		public AccessType_ProductRateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessType_ProductRateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessType_ProductRateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessType_ProductRateFilters
	
	#region AccessType_ProductRateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AccessType_ProductRateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateQuery : AccessType_ProductRateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateQuery class.
		/// </summary>
		public AccessType_ProductRateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessType_ProductRateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessType_ProductRateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessType_ProductRateQuery
		
	#region AdminSiteNotesHistoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryFilters : AdminSiteNotesHistoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilters class.
		/// </summary>
		public AdminSiteNotesHistoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesHistoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesHistoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesHistoryFilters
	
	#region AdminSiteNotesHistoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminSiteNotesHistoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryQuery : AdminSiteNotesHistoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryQuery class.
		/// </summary>
		public AdminSiteNotesHistoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesHistoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesHistoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesHistoryQuery
		
	#region AreaCodeNxxFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxFilters : AreaCodeNxxFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilters class.
		/// </summary>
		public AreaCodeNxxFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaCodeNxxFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaCodeNxxFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaCodeNxxFilters
	
	#region AreaCodeNxxQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AreaCodeNxxParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxQuery : AreaCodeNxxParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxQuery class.
		/// </summary>
		public AreaCodeNxxQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaCodeNxxQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaCodeNxxQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaCodeNxxQuery
		
	#region AuditLogFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AuditLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditLogFilters : AuditLogFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditLogFilters class.
		/// </summary>
		public AuditLogFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditLogFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditLogFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditLogFilters
	
	#region AuditLogQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AuditLogParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AuditLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditLogQuery : AuditLogParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditLogQuery class.
		/// </summary>
		public AuditLogQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditLogQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditLogQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditLogQuery
		
	#region BridgeRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestFilters : BridgeRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilters class.
		/// </summary>
		public BridgeRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestFilters
	
	#region BridgeRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BridgeRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestQuery : BridgeRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestQuery class.
		/// </summary>
		public BridgeRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestQuery
		
	#region BridgeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeFilters : BridgeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeFilters class.
		/// </summary>
		public BridgeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeFilters
	
	#region BridgeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BridgeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQuery : BridgeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQuery class.
		/// </summary>
		public BridgeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeQuery
		
	#region BillableLegsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsFilters : BillableLegsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilters class.
		/// </summary>
		public BillableLegsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillableLegsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillableLegsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillableLegsFilters
	
	#region BillableLegsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BillableLegsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsQuery : BillableLegsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsQuery class.
		/// </summary>
		public BillableLegsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillableLegsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillableLegsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillableLegsQuery
		
	#region CustomerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerFilters : CustomerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		public CustomerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerFilters
	
	#region CustomerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerQuery : CustomerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		public CustomerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerQuery
		
	#region AverageRatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesFilters : AverageRatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilters class.
		/// </summary>
		public AverageRatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AverageRatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AverageRatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AverageRatesFilters
	
	#region AverageRatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AverageRatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesQuery : AverageRatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesQuery class.
		/// </summary>
		public AverageRatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AverageRatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AverageRatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AverageRatesQuery
		
	#region BridgeQueueFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueFilters : BridgeQueueFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilters class.
		/// </summary>
		public BridgeQueueFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeQueueFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeQueueFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeQueueFilters
	
	#region BridgeQueueQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BridgeQueueParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueQuery : BridgeQueueParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueQuery class.
		/// </summary>
		public BridgeQueueQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeQueueQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeQueueQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeQueueQuery
		
	#region ForExFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExFilters : ForExFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExFilters class.
		/// </summary>
		public ForExFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ForExFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ForExFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ForExFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ForExFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ForExFilters
	
	#region ForExQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ForExParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExQuery : ForExParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExQuery class.
		/// </summary>
		public ForExQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ForExQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ForExQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ForExQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ForExQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ForExQuery
		
	#region Customer_DnisFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisFilters : Customer_DnisFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilters class.
		/// </summary>
		public Customer_DnisFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_DnisFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_DnisFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_DnisFilters
	
	#region Customer_DnisQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Customer_DnisParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisQuery : Customer_DnisParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisQuery class.
		/// </summary>
		public Customer_DnisQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_DnisQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_DnisQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_DnisQuery
		
	#region FeatureOptionTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOptionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionTypeFilters : FeatureOptionTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeFilters class.
		/// </summary>
		public FeatureOptionTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionTypeFilters
	
	#region FeatureOptionTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FeatureOptionTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="FeatureOptionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionTypeQuery : FeatureOptionTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeQuery class.
		/// </summary>
		public FeatureOptionTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionTypeQuery
		
	#region FeatureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureFilters : FeatureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureFilters class.
		/// </summary>
		public FeatureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureFilters
	
	#region FeatureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FeatureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureQuery : FeatureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureQuery class.
		/// </summary>
		public FeatureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureQuery
		
	#region GlPostingTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlPostingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlPostingTypeFilters : GlPostingTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilters class.
		/// </summary>
		public GlPostingTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlPostingTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlPostingTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlPostingTypeFilters
	
	#region GlPostingTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GlPostingTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="GlPostingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlPostingTypeQuery : GlPostingTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeQuery class.
		/// </summary>
		public GlPostingTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlPostingTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlPostingTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlPostingTypeQuery
		
	#region FeatureOptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionFilters : FeatureOptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilters class.
		/// </summary>
		public FeatureOptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionFilters
	
	#region FeatureOptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FeatureOptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionQuery : FeatureOptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionQuery class.
		/// </summary>
		public FeatureOptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionQuery
		
	#region InvoiceChargesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceCharges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceChargesFilters : InvoiceChargesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesFilters class.
		/// </summary>
		public InvoiceChargesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceChargesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceChargesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceChargesFilters
	
	#region InvoiceChargesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceChargesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="InvoiceCharges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceChargesQuery : InvoiceChargesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesQuery class.
		/// </summary>
		public InvoiceChargesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceChargesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceChargesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceChargesQuery
		
	#region InvoiceNotesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesFilters : InvoiceNotesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilters class.
		/// </summary>
		public InvoiceNotesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceNotesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceNotesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceNotesFilters
	
	#region InvoiceNotesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceNotesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesQuery : InvoiceNotesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesQuery class.
		/// </summary>
		public InvoiceNotesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceNotesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceNotesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceNotesQuery
		
	#region LeadFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadFilters : LeadFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadFilters class.
		/// </summary>
		public LeadFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadFilters
	
	#region LeadQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadQuery : LeadParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadQuery class.
		/// </summary>
		public LeadQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadQuery
		
	#region LanguageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageFilters : LanguageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		public LanguageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageFilters
	
	#region LanguageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LanguageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageQuery : LanguageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		public LanguageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageQuery
		
	#region IrWholesalerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerFilters : IrWholesalerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilters class.
		/// </summary>
		public IrWholesalerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IrWholesalerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IrWholesalerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IrWholesalerFilters
	
	#region IrWholesalerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IrWholesalerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerQuery : IrWholesalerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerQuery class.
		/// </summary>
		public IrWholesalerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IrWholesalerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IrWholesalerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IrWholesalerQuery
		
	#region InvoiceSummaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryFilters : InvoiceSummaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilters class.
		/// </summary>
		public InvoiceSummaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceSummaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceSummaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceSummaryFilters
	
	#region InvoiceSummaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceSummaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryQuery : InvoiceSummaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryQuery class.
		/// </summary>
		public InvoiceSummaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceSummaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceSummaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceSummaryQuery
		
	#region ExtensionTypeCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionTypeCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeCategoryFilters : ExtensionTypeCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryFilters class.
		/// </summary>
		public ExtensionTypeCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeCategoryFilters
	
	#region ExtensionTypeCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ExtensionTypeCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ExtensionTypeCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeCategoryQuery : ExtensionTypeCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryQuery class.
		/// </summary>
		public ExtensionTypeCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeCategoryQuery
		
	#region ExtensionTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeFilters : ExtensionTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilters class.
		/// </summary>
		public ExtensionTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeFilters
	
	#region ExtensionTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ExtensionTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeQuery : ExtensionTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeQuery class.
		/// </summary>
		public ExtensionTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeQuery
		
	#region EventManagerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EventManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EventManagerFilters : EventManagerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EventManagerFilters class.
		/// </summary>
		public EventManagerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EventManagerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EventManagerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EventManagerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EventManagerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EventManagerFilters
	
	#region EventManagerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EventManagerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EventManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EventManagerQuery : EventManagerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EventManagerQuery class.
		/// </summary>
		public EventManagerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EventManagerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EventManagerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EventManagerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EventManagerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EventManagerQuery
		
	#region CustomerTransactionImportFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportFilters : CustomerTransactionImportFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilters class.
		/// </summary>
		public CustomerTransactionImportFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionImportFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionImportFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionImportFilters
	
	#region CustomerTransactionImportQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerTransactionImportParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportQuery : CustomerTransactionImportParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportQuery class.
		/// </summary>
		public CustomerTransactionImportQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionImportQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionImportQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionImportQuery
		
	#region CustomerReviewFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerReviewFilters : CustomerReviewFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilters class.
		/// </summary>
		public CustomerReviewFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerReviewFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerReviewFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerReviewFilters
	
	#region CustomerReviewQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerReviewParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerReviewQuery : CustomerReviewParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerReviewQuery class.
		/// </summary>
		public CustomerReviewQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerReviewQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerReviewQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerReviewQuery
		
	#region CustomerDocumentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentFilters : CustomerDocumentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilters class.
		/// </summary>
		public CustomerDocumentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDocumentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDocumentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDocumentFilters
	
	#region CustomerDocumentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerDocumentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentQuery : CustomerDocumentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentQuery class.
		/// </summary>
		public CustomerDocumentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDocumentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDocumentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDocumentQuery
		
	#region Customer_FeatureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_FeatureFilters : Customer_FeatureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureFilters class.
		/// </summary>
		public Customer_FeatureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_FeatureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_FeatureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_FeatureFilters
	
	#region Customer_FeatureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Customer_FeatureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customer_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_FeatureQuery : Customer_FeatureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureQuery class.
		/// </summary>
		public Customer_FeatureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_FeatureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_FeatureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_FeatureQuery
		
	#region CustomerTransactionTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeFilters : CustomerTransactionTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilters class.
		/// </summary>
		public CustomerTransactionTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionTypeFilters
	
	#region CustomerTransactionTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerTransactionTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeQuery : CustomerTransactionTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeQuery class.
		/// </summary>
		public CustomerTransactionTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionTypeQuery
		
	#region DepartmentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentFilters : DepartmentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		public DepartmentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentFilters
	
	#region DepartmentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DepartmentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentQuery : DepartmentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		public DepartmentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentQuery
		
	#region ErrorCodesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorCodesFilters : ErrorCodesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorCodesFilters class.
		/// </summary>
		public ErrorCodesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorCodesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorCodesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorCodesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorCodesFilters
	
	#region ErrorCodesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ErrorCodesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ErrorCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorCodesQuery : ErrorCodesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorCodesQuery class.
		/// </summary>
		public ErrorCodesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ErrorCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ErrorCodesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ErrorCodesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ErrorCodesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ErrorCodesQuery
		
	#region EmailTemplateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateFilters : EmailTemplateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilters class.
		/// </summary>
		public EmailTemplateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplateFilters
	
	#region EmailTemplateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmailTemplateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateQuery : EmailTemplateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateQuery class.
		/// </summary>
		public EmailTemplateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplateQuery
		
	#region EmailNotificationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationFilters : EmailNotificationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilters class.
		/// </summary>
		public EmailNotificationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailNotificationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailNotificationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailNotificationFilters
	
	#region EmailNotificationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmailNotificationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationQuery : EmailNotificationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationQuery class.
		/// </summary>
		public EmailNotificationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailNotificationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailNotificationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailNotificationQuery
		
	#region CustomerTransactionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransaction"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionFilters : CustomerTransactionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilters class.
		/// </summary>
		public CustomerTransactionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionFilters
	
	#region CustomerTransactionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerTransactionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerTransaction"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionQuery : CustomerTransactionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionQuery class.
		/// </summary>
		public CustomerTransactionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionQuery
		
	#region DocumentTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DocumentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentTypeFilters : DocumentTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentTypeFilters class.
		/// </summary>
		public DocumentTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentTypeFilters
	
	#region DocumentTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DocumentTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DocumentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DocumentTypeQuery : DocumentTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DocumentTypeQuery class.
		/// </summary>
		public DocumentTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DocumentTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DocumentTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DocumentTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DocumentTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DocumentTypeQuery
		
	#region Wholesaler_Product_FeatureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_Product_FeatureFilters : Wholesaler_Product_FeatureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureFilters class.
		/// </summary>
		public Wholesaler_Product_FeatureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_Product_FeatureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_Product_FeatureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_Product_FeatureFilters
	
	#region Wholesaler_Product_FeatureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Wholesaler_Product_FeatureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_Product_FeatureQuery : Wholesaler_Product_FeatureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureQuery class.
		/// </summary>
		public Wholesaler_Product_FeatureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_Product_FeatureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_Product_FeatureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_Product_FeatureQuery
		
	#region Vw_AccessType_ProductRatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesFilters : Vw_AccessType_ProductRatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilters class.
		/// </summary>
		public Vw_AccessType_ProductRatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_AccessType_ProductRatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_AccessType_ProductRatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_AccessType_ProductRatesFilters
	
	#region Vw_AccessType_ProductRatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_AccessType_ProductRatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesQuery : Vw_AccessType_ProductRatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesQuery class.
		/// </summary>
		public Vw_AccessType_ProductRatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_AccessType_ProductRatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_AccessType_ProductRatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_AccessType_ProductRatesQuery
		
	#region Vw_ConferenceCallList_UniqueFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueFilters : Vw_ConferenceCallList_UniqueFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilters class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceCallList_UniqueFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceCallList_UniqueFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceCallList_UniqueFilters
	
	#region Vw_ConferenceCallList_UniqueQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_ConferenceCallList_UniqueParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueQuery : Vw_ConferenceCallList_UniqueParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueQuery class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceCallList_UniqueQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceCallList_UniqueQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceCallList_UniqueQuery
		
	#region Vw_ConferenceListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListFilters : Vw_ConferenceListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilters class.
		/// </summary>
		public Vw_ConferenceListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceListFilters
	
	#region Vw_ConferenceListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_ConferenceListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListQuery : Vw_ConferenceListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListQuery class.
		/// </summary>
		public Vw_ConferenceListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceListQuery
		
	#region Vw_CustomerListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListFilters : Vw_CustomerListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilters class.
		/// </summary>
		public Vw_CustomerListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerListFilters
	
	#region Vw_CustomerListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_CustomerListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListQuery : Vw_CustomerListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListQuery class.
		/// </summary>
		public Vw_CustomerListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerListQuery
		
	#region Vw_CustomerTransactionListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListFilters : Vw_CustomerTransactionListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilters class.
		/// </summary>
		public Vw_CustomerTransactionListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerTransactionListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerTransactionListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerTransactionListFilters
	
	#region Vw_CustomerTransactionListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_CustomerTransactionListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListQuery : Vw_CustomerTransactionListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListQuery class.
		/// </summary>
		public Vw_CustomerTransactionListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerTransactionListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerTransactionListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerTransactionListQuery
		
	#region Vw_DefaultProductRatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesFilters : Vw_DefaultProductRatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilters class.
		/// </summary>
		public Vw_DefaultProductRatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_DefaultProductRatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_DefaultProductRatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_DefaultProductRatesFilters
	
	#region Vw_DefaultProductRatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_DefaultProductRatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesQuery : Vw_DefaultProductRatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesQuery class.
		/// </summary>
		public Vw_DefaultProductRatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_DefaultProductRatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_DefaultProductRatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_DefaultProductRatesQuery
		
	#region Vw_FeatureOptionsForCustomersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForCustomers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForCustomersFilters : Vw_FeatureOptionsForCustomersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersFilters class.
		/// </summary>
		public Vw_FeatureOptionsForCustomersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForCustomersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForCustomersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForCustomersFilters
	
	#region Vw_FeatureOptionsForCustomersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_FeatureOptionsForCustomersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForCustomers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForCustomersQuery : Vw_FeatureOptionsForCustomersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersQuery class.
		/// </summary>
		public Vw_FeatureOptionsForCustomersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForCustomersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForCustomersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForCustomersQuery
		
	#region Vw_FeatureOptionsForModeratorsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsFilters : Vw_FeatureOptionsForModeratorsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilters class.
		/// </summary>
		public Vw_FeatureOptionsForModeratorsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForModeratorsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForModeratorsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForModeratorsFilters
	
	#region Vw_FeatureOptionsForModeratorsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_FeatureOptionsForModeratorsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsQuery : Vw_FeatureOptionsForModeratorsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsQuery class.
		/// </summary>
		public Vw_FeatureOptionsForModeratorsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForModeratorsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForModeratorsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForModeratorsQuery
		
	#region Vw_ModeratorListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListFilters : Vw_ModeratorListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilters class.
		/// </summary>
		public Vw_ModeratorListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorListFilters
	
	#region Vw_ModeratorListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_ModeratorListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListQuery : Vw_ModeratorListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListQuery class.
		/// </summary>
		public Vw_ModeratorListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorListQuery
		
	#region Vw_ModeratorList_AdminSiteFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteFilters : Vw_ModeratorList_AdminSiteFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilters class.
		/// </summary>
		public Vw_ModeratorList_AdminSiteFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorList_AdminSiteFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorList_AdminSiteFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorList_AdminSiteFilters
	
	#region Vw_ModeratorList_AdminSiteQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_ModeratorList_AdminSiteParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteQuery : Vw_ModeratorList_AdminSiteParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteQuery class.
		/// </summary>
		public Vw_ModeratorList_AdminSiteQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorList_AdminSiteQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorList_AdminSiteQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorList_AdminSiteQuery
		
	#region Vw_RecordingListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListFilters : Vw_RecordingListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilters class.
		/// </summary>
		public Vw_RecordingListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_RecordingListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_RecordingListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_RecordingListFilters
	
	#region Vw_RecordingListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_RecordingListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListQuery : Vw_RecordingListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListQuery class.
		/// </summary>
		public Vw_RecordingListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_RecordingListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_RecordingListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_RecordingListQuery
		
	#region Vw_SystemExtension_AllFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllFilters : Vw_SystemExtension_AllFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilters class.
		/// </summary>
		public Vw_SystemExtension_AllFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_AllFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_AllFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_AllFilters
	
	#region Vw_SystemExtension_AllQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_SystemExtension_AllParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllQuery : Vw_SystemExtension_AllParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllQuery class.
		/// </summary>
		public Vw_SystemExtension_AllQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_AllQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_AllQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_AllQuery
		
	#region Vw_SystemExtension_CustomerLabelFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelFilters : Vw_SystemExtension_CustomerLabelFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilters class.
		/// </summary>
		public Vw_SystemExtension_CustomerLabelFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_CustomerLabelFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_CustomerLabelFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_CustomerLabelFilters
	
	#region Vw_SystemExtension_CustomerLabelQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_SystemExtension_CustomerLabelParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelQuery : Vw_SystemExtension_CustomerLabelParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelQuery class.
		/// </summary>
		public Vw_SystemExtension_CustomerLabelQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_CustomerLabelQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_CustomerLabelQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_CustomerLabelQuery
		
	#region Vw_SystemExtension_ValueFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueFilters : Vw_SystemExtension_ValueFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilters class.
		/// </summary>
		public Vw_SystemExtension_ValueFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_ValueFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_ValueFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_ValueFilters
	
	#region Vw_SystemExtension_ValueQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_SystemExtension_ValueParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueQuery : Vw_SystemExtension_ValueParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueQuery class.
		/// </summary>
		public Vw_SystemExtension_ValueQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_ValueQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_ValueQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_ValueQuery
		
	#region Vw_UserListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListFilters : Vw_UserListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilters class.
		/// </summary>
		public Vw_UserListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_UserListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_UserListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_UserListFilters
	
	#region Vw_UserListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Vw_UserListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListQuery : Vw_UserListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListQuery class.
		/// </summary>
		public Vw_UserListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_UserListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_UserListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_UserListQuery
	#endregion

	
}
