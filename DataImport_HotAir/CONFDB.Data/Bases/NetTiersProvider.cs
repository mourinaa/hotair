
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using CONFDB.Entities;

#endregion

namespace CONFDB.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : System.Configuration.Provider.ProviderBase
	{
		private Type entityCreationalFactoryType = null;
        private static object syncObject = new object();
        private bool enableEntityTracking = true;
        private bool enableListTracking = false;
        private bool useEntityFactory = true;
		private bool enableMethodAuthorization = false;
        private int defaultCommandTimeout = 30;
		
		[ThreadStatic] // Allow the LoadPolicy to be controlled on a per thread basis
		private LoadPolicy loadPolicy = LoadPolicy.DiscardChanges;

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
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(CONFDB.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
				if (config["enableEntityTracking"] != null)
				{
                	bool.TryParse(config["enableEntityTracking"], out this.enableEntityTracking);
				}
				
				if (config["enableListTracking"] != null)
				{
                	bool.TryParse(config["enableListTracking"], out this.enableListTracking);
				}
				
				if (config["useEntityFactory"] != null)
				{
                	bool.TryParse(config["useEntityFactory"], out this.useEntityFactory);
				}
				
				if (config["enableMethodAuthorization"] != null)
				{
					bool.TryParse(config["enableMethodAuthorization"], out this.enableMethodAuthorization);				
				}
				
				if (config["defaultCommandTimeout"] != null)
				{
					int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
				}
				
				if (String.Compare(config["currentLoadPolicy"], LoadPolicy.DiscardChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.DiscardChanges;
                }
                
                if (String.Compare(config["currentLoadPolicy"], LoadPolicy.PreserveChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.PreserveChanges;
                }				
			}   
         }
	    
        /// <summary>
        /// Gets or sets the Creational Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual Type EntityCreationalFactoryType
        {
            get
            {
                return entityCreationalFactoryType;
            }
            set
            {
                entityCreationalFactoryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the ability to track entities.
        /// </summary>
        /// <value>true/false.</value>
        public virtual bool EnableEntityTracking
        {
            get
            {
                return enableEntityTracking;
            }
            set { enableEntityTracking = value; }
        }

        /// <summary>
        /// Gets or sets the Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual bool EnableListTracking
        {
            get
            {
                return enableListTracking;
            }
            set 
            {
                enableListTracking = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use entity factory property to enable the usage of the EntityFactory and it's type cache.
        /// </summary>
        /// <value>bool value</value>
        public virtual bool UseEntityFactory
        {
            get
            {
                return useEntityFactory;
            }
            set 
            {
                useEntityFactory = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use Enable Method Authorization to enable the usage of the Microsoft Patterns and Practices 
		/// IAuthorizationRuleProvider for code level authorization.
		/// </summary>
        /// <value>A bool value.</value>
        public virtual bool EnableMethodAuthorization
        {
            get
            {
                return enableMethodAuthorization;
            }
            set 
            {
                enableMethodAuthorization = value; 
            }
        }

        /// <summary>
        /// Gets or sets the default timeout for every command
        /// </summary>
        /// <value>integer value in seconds.</value>
        public virtual int DefaultCommandTimeout
        {
            get
            {
                return defaultCommandTimeout;
            }
            set
            {
                defaultCommandTimeout = value;
            }
        }
		
		/// <summary>
		/// Get or set the current LoadPolicy in effect
		/// </summary>
		/// <value>A <c cref="LoadPolicy"/> enumeration member.</value>
		public virtual LoadPolicy CurrentLoadPolicy
		{
			get
			{
				return loadPolicy;
			}
			set
			{
				loadPolicy = value;
			}
		}
		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation is supporting Transactions.
		///</summary>
		public abstract bool IsTransactionSupported{get;}
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public virtual TransactionManager CreateTransaction() {throw new NotSupportedException();}
		
		
		///<summary>
		/// Current AccessTypeProviderBase instance.
		///</summary>
		public virtual AccessTypeProviderBase AccessTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RecordingProviderBase instance.
		///</summary>
		public virtual RecordingProviderBase RecordingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RecordingParticipantUsageProviderBase instance.
		///</summary>
		public virtual RecordingParticipantUsageProviderBase RecordingParticipantUsageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RatingTypeProviderBase instance.
		///</summary>
		public virtual RatingTypeProviderBase RatingTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PromptSetProviderBase instance.
		///</summary>
		public virtual PromptSetProviderBase PromptSetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RoleProviderBase instance.
		///</summary>
		public virtual RoleProviderBase RoleProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SeeVoghMeetingTrackerProviderBase instance.
		///</summary>
		public virtual SeeVoghMeetingTrackerProviderBase SeeVoghMeetingTrackerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountryProviderBase instance.
		///</summary>
		public virtual CountryProviderBase CountryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurrencyProviderBase instance.
		///</summary>
		public virtual CurrencyProviderBase CurrencyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SystemExtensionProviderBase instance.
		///</summary>
		public virtual SystemExtensionProviderBase SystemExtensionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StateProviderBase instance.
		///</summary>
		public virtual StateProviderBase StateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductTypeProviderBase instance.
		///</summary>
		public virtual ProductTypeProviderBase ProductTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductRateTypeProviderBase instance.
		///</summary>
		public virtual ProductRateTypeProviderBase ProductRateTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductRateIntervalProviderBase instance.
		///</summary>
		public virtual ProductRateIntervalProviderBase ProductRateIntervalProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ModeratorXtimeUserProviderBase instance.
		///</summary>
		public virtual ModeratorXtimeUserProviderBase ModeratorXtimeUserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadStageProviderBase instance.
		///</summary>
		public virtual LeadStageProviderBase LeadStageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadSourceProviderBase instance.
		///</summary>
		public virtual LeadSourceProviderBase LeadSourceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadProductProviderBase instance.
		///</summary>
		public virtual LeadProductProviderBase LeadProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OmnoviaHostedArchiveProviderBase instance.
		///</summary>
		public virtual OmnoviaHostedArchiveProviderBase OmnoviaHostedArchiveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OmnoviaHostedArchiveParticipantProviderBase instance.
		///</summary>
		public virtual OmnoviaHostedArchiveParticipantProviderBase OmnoviaHostedArchiveParticipantProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProviderBase instance.
		///</summary>
		public virtual ProductProviderBase ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductRateProviderBase instance.
		///</summary>
		public virtual ProductRateProviderBase ProductRateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PrevInvoicesProviderBase instance.
		///</summary>
		public virtual PrevInvoicesProviderBase PrevInvoicesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OmnoviaMp4RequestProviderBase instance.
		///</summary>
		public virtual OmnoviaMp4RequestProviderBase OmnoviaMp4RequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SystemExtensionLabelProviderBase instance.
		///</summary>
		public virtual SystemExtensionLabelProviderBase SystemExtensionLabelProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VerticalProviderBase instance.
		///</summary>
		public virtual VerticalProviderBase VerticalProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SystemSettingsProviderBase instance.
		///</summary>
		public virtual SystemSettingsProviderBase SystemSettingsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketProductProviderBase instance.
		///</summary>
		public virtual TicketProductProviderBase TicketProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketStatusProviderBase instance.
		///</summary>
		public virtual TicketStatusProviderBase TicketStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketPriorityProviderBase instance.
		///</summary>
		public virtual TicketPriorityProviderBase TicketPriorityProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserProviderBase instance.
		///</summary>
		public virtual UserProviderBase UserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ValidTicketStateChangesProviderBase instance.
		///</summary>
		public virtual ValidTicketStateChangesProviderBase ValidTicketStateChangesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current User_MarketingServiceProviderBase instance.
		///</summary>
		public virtual User_MarketingServiceProviderBase User_MarketingServiceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Moderator_FeatureProviderBase instance.
		///</summary>
		public virtual Moderator_FeatureProviderBase Moderator_FeatureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UtilProviderBase instance.
		///</summary>
		public virtual UtilProviderBase UtilProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketCategoryProviderBase instance.
		///</summary>
		public virtual TicketCategoryProviderBase TicketCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TaxableProviderBase instance.
		///</summary>
		public virtual TaxableProviderBase TaxableProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WholesalerProviderBase instance.
		///</summary>
		public virtual WholesalerProviderBase WholesalerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketProviderBase instance.
		///</summary>
		public virtual TicketProviderBase TicketProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WelcomeKitRequestProviderBase instance.
		///</summary>
		public virtual WelcomeKitRequestProviderBase WelcomeKitRequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Wholesaler_ProductProviderBase instance.
		///</summary>
		public virtual Wholesaler_ProductProviderBase Wholesaler_ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesPersonProviderBase instance.
		///</summary>
		public virtual SalesPersonProviderBase SalesPersonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MarketingServiceProviderBase instance.
		///</summary>
		public virtual MarketingServiceProviderBase MarketingServiceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ModeratorProviderBase instance.
		///</summary>
		public virtual ModeratorProviderBase ModeratorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ParticipantProviderBase instance.
		///</summary>
		public virtual ParticipantProviderBase ParticipantProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Moderator_DnisProviderBase instance.
		///</summary>
		public virtual Moderator_DnisProviderBase Moderator_DnisProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ParticipantListProviderBase instance.
		///</summary>
		public virtual ParticipantListProviderBase ParticipantListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempReplayIdsProviderBase instance.
		///</summary>
		public virtual TempReplayIdsProviderBase TempReplayIdsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempExistingCodesProviderBase instance.
		///</summary>
		public virtual TempExistingCodesProviderBase TempExistingCodesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempCodesProviderBase instance.
		///</summary>
		public virtual TempCodesProviderBase TempCodesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempCodeChangesProviderBase instance.
		///</summary>
		public virtual TempCodeChangesProviderBase TempCodeChangesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempSampleRatesPerProductProviderBase instance.
		///</summary>
		public virtual TempSampleRatesPerProductProviderBase TempSampleRatesPerProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TempTotalDollarsSpentProviderBase instance.
		///</summary>
		public virtual TempTotalDollarsSpentProviderBase TempTotalDollarsSpentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RatedCdrProviderBase instance.
		///</summary>
		public virtual RatedCdrProviderBase RatedCdrProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TrendProviderBase instance.
		///</summary>
		public virtual TrendProviderBase TrendProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketUserAssociationsProviderBase instance.
		///</summary>
		public virtual TicketUserAssociationsProviderBase TicketUserAssociationsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TicketStatusHistoryProviderBase instance.
		///</summary>
		public virtual TicketStatusHistoryProviderBase TicketStatusHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductRateValueProviderBase instance.
		///</summary>
		public virtual ProductRateValueProviderBase ProductRateValueProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadPeriodProviderBase instance.
		///</summary>
		public virtual LeadPeriodProviderBase LeadPeriodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DnisProviderBase instance.
		///</summary>
		public virtual DnisProviderBase DnisProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadChurnReasonProviderBase instance.
		///</summary>
		public virtual LeadChurnReasonProviderBase LeadChurnReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DnisTypeProviderBase instance.
		///</summary>
		public virtual DnisTypeProviderBase DnisTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CompanyProviderBase instance.
		///</summary>
		public virtual CompanyProviderBase CompanyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClientNotesProviderBase instance.
		///</summary>
		public virtual ClientNotesProviderBase ClientNotesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CharityProviderBase instance.
		///</summary>
		public virtual CharityProviderBase CharityProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CallFlowProviderBase instance.
		///</summary>
		public virtual CallFlowProviderBase CallFlowProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CommissionProviderBase instance.
		///</summary>
		public virtual CommissionProviderBase CommissionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CommissionCustomerProviderBase instance.
		///</summary>
		public virtual CommissionCustomerProviderBase CommissionCustomerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CompanyInfoProviderBase instance.
		///</summary>
		public virtual CompanyInfoProviderBase CompanyInfoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurveProviderBase instance.
		///</summary>
		public virtual CurveProviderBase CurveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CompanyLeadTrackingProviderBase instance.
		///</summary>
		public virtual CompanyLeadTrackingProviderBase CompanyLeadTrackingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ConferencingSummaryProviderBase instance.
		///</summary>
		public virtual ConferencingSummaryProviderBase ConferencingSummaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BridgeTypeProviderBase instance.
		///</summary>
		public virtual BridgeTypeProviderBase BridgeTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CompanyLeadTrackingNotesProviderBase instance.
		///</summary>
		public virtual CompanyLeadTrackingNotesProviderBase CompanyLeadTrackingNotesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BridgeRequestTypeProviderBase instance.
		///</summary>
		public virtual BridgeRequestTypeProviderBase BridgeRequestTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdminSiteNotesProviderBase instance.
		///</summary>
		public virtual AdminSiteNotesProviderBase AdminSiteNotesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ActionTypeProviderBase instance.
		///</summary>
		public virtual ActionTypeProviderBase ActionTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ActionProviderBase instance.
		///</summary>
		public virtual ActionProviderBase ActionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AccountManagerProviderBase instance.
		///</summary>
		public virtual AccountManagerProviderBase AccountManagerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AccessType_ProductRateProviderBase instance.
		///</summary>
		public virtual AccessType_ProductRateProviderBase AccessType_ProductRateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdminSiteNotesHistoryProviderBase instance.
		///</summary>
		public virtual AdminSiteNotesHistoryProviderBase AdminSiteNotesHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AreaCodeNxxProviderBase instance.
		///</summary>
		public virtual AreaCodeNxxProviderBase AreaCodeNxxProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AuditLogProviderBase instance.
		///</summary>
		public virtual AuditLogProviderBase AuditLogProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BridgeRequestProviderBase instance.
		///</summary>
		public virtual BridgeRequestProviderBase BridgeRequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BridgeProviderBase instance.
		///</summary>
		public virtual BridgeProviderBase BridgeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BillableLegsProviderBase instance.
		///</summary>
		public virtual BillableLegsProviderBase BillableLegsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerProviderBase instance.
		///</summary>
		public virtual CustomerProviderBase CustomerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AverageRatesProviderBase instance.
		///</summary>
		public virtual AverageRatesProviderBase AverageRatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BridgeQueueProviderBase instance.
		///</summary>
		public virtual BridgeQueueProviderBase BridgeQueueProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ForExProviderBase instance.
		///</summary>
		public virtual ForExProviderBase ForExProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Customer_DnisProviderBase instance.
		///</summary>
		public virtual Customer_DnisProviderBase Customer_DnisProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FeatureOptionTypeProviderBase instance.
		///</summary>
		public virtual FeatureOptionTypeProviderBase FeatureOptionTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FeatureProviderBase instance.
		///</summary>
		public virtual FeatureProviderBase FeatureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GlPostingTypeProviderBase instance.
		///</summary>
		public virtual GlPostingTypeProviderBase GlPostingTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FeatureOptionProviderBase instance.
		///</summary>
		public virtual FeatureOptionProviderBase FeatureOptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceChargesProviderBase instance.
		///</summary>
		public virtual InvoiceChargesProviderBase InvoiceChargesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceNotesProviderBase instance.
		///</summary>
		public virtual InvoiceNotesProviderBase InvoiceNotesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadProviderBase instance.
		///</summary>
		public virtual LeadProviderBase LeadProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LanguageProviderBase instance.
		///</summary>
		public virtual LanguageProviderBase LanguageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IrWholesalerProviderBase instance.
		///</summary>
		public virtual IrWholesalerProviderBase IrWholesalerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceSummaryProviderBase instance.
		///</summary>
		public virtual InvoiceSummaryProviderBase InvoiceSummaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ExtensionTypeCategoryProviderBase instance.
		///</summary>
		public virtual ExtensionTypeCategoryProviderBase ExtensionTypeCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ExtensionTypeProviderBase instance.
		///</summary>
		public virtual ExtensionTypeProviderBase ExtensionTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EventManagerProviderBase instance.
		///</summary>
		public virtual EventManagerProviderBase EventManagerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerTransactionImportProviderBase instance.
		///</summary>
		public virtual CustomerTransactionImportProviderBase CustomerTransactionImportProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerReviewProviderBase instance.
		///</summary>
		public virtual CustomerReviewProviderBase CustomerReviewProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerDocumentProviderBase instance.
		///</summary>
		public virtual CustomerDocumentProviderBase CustomerDocumentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Customer_FeatureProviderBase instance.
		///</summary>
		public virtual Customer_FeatureProviderBase Customer_FeatureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerTransactionTypeProviderBase instance.
		///</summary>
		public virtual CustomerTransactionTypeProviderBase CustomerTransactionTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DepartmentProviderBase instance.
		///</summary>
		public virtual DepartmentProviderBase DepartmentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ErrorCodesProviderBase instance.
		///</summary>
		public virtual ErrorCodesProviderBase ErrorCodesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmailTemplateProviderBase instance.
		///</summary>
		public virtual EmailTemplateProviderBase EmailTemplateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmailNotificationProviderBase instance.
		///</summary>
		public virtual EmailNotificationProviderBase EmailNotificationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerTransactionProviderBase instance.
		///</summary>
		public virtual CustomerTransactionProviderBase CustomerTransactionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DocumentTypeProviderBase instance.
		///</summary>
		public virtual DocumentTypeProviderBase DocumentTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Wholesaler_Product_FeatureProviderBase instance.
		///</summary>
		public virtual Wholesaler_Product_FeatureProviderBase Wholesaler_Product_FeatureProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current Vw_AccessType_ProductRatesProviderBase instance.
		///</summary>
		public virtual Vw_AccessType_ProductRatesProviderBase Vw_AccessType_ProductRatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_ConferenceCallList_UniqueProviderBase instance.
		///</summary>
		public virtual Vw_ConferenceCallList_UniqueProviderBase Vw_ConferenceCallList_UniqueProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_ConferenceListProviderBase instance.
		///</summary>
		public virtual Vw_ConferenceListProviderBase Vw_ConferenceListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_CustomerListProviderBase instance.
		///</summary>
		public virtual Vw_CustomerListProviderBase Vw_CustomerListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_CustomerTransactionListProviderBase instance.
		///</summary>
		public virtual Vw_CustomerTransactionListProviderBase Vw_CustomerTransactionListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_DefaultProductRatesProviderBase instance.
		///</summary>
		public virtual Vw_DefaultProductRatesProviderBase Vw_DefaultProductRatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_FeatureOptionsForCustomersProviderBase instance.
		///</summary>
		public virtual Vw_FeatureOptionsForCustomersProviderBase Vw_FeatureOptionsForCustomersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_FeatureOptionsForModeratorsProviderBase instance.
		///</summary>
		public virtual Vw_FeatureOptionsForModeratorsProviderBase Vw_FeatureOptionsForModeratorsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_ModeratorListProviderBase instance.
		///</summary>
		public virtual Vw_ModeratorListProviderBase Vw_ModeratorListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_ModeratorList_AdminSiteProviderBase instance.
		///</summary>
		public virtual Vw_ModeratorList_AdminSiteProviderBase Vw_ModeratorList_AdminSiteProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_RecordingListProviderBase instance.
		///</summary>
		public virtual Vw_RecordingListProviderBase Vw_RecordingListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_SystemExtension_AllProviderBase instance.
		///</summary>
		public virtual Vw_SystemExtension_AllProviderBase Vw_SystemExtension_AllProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_SystemExtension_CustomerLabelProviderBase instance.
		///</summary>
		public virtual Vw_SystemExtension_CustomerLabelProviderBase Vw_SystemExtension_CustomerLabelProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_SystemExtension_ValueProviderBase instance.
		///</summary>
		public virtual Vw_SystemExtension_ValueProviderBase Vw_SystemExtension_ValueProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Vw_UserListProviderBase instance.
		///</summary>
		public virtual Vw_UserListProviderBase Vw_UserListProvider{get {throw new NotImplementedException();}}
		
					
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(DbCommand commandWrapper);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(DbCommand commandWrapper);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(DbCommand commandWrapper);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(DbCommand commandWrapper);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion
		
		#endregion
	}
	
	/// <summary>
	/// Possibel load policies that can be applied when a provider Load method is called. Determines 
	/// how entities with EntityState.Unchanged and EntityState.Changed are treated during a Load
	/// when entity tracking is enabled.
	/// </summary>
	public enum LoadPolicy
	{
		/// <summary>
		/// Refresh entities with EntityState.Unchanged if entity tracking is enabled. Entities with 
		/// EntityState.Changed will not be refreshed with information from the database.
		/// </summary>
		PreserveChanges,
		
		/// <summary>
		/// Refresh entities with EntityState.Changed as well as EntityState.Unchanged i.e. discard any
		/// unsaved changes.
		/// </summary>
		DiscardChanges
	}
}
