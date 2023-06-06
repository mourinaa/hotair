using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace CONFDB.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>WholesalerRepeater</c>
    /// </summary>
	public class WholesalerRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WholesalerRepeaterDesigner"/> class.
        /// </summary>
		public WholesalerRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is WholesalerRepeater))
			{ 
				throw new ArgumentException("Component is not a WholesalerRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			WholesalerRepeater z = (WholesalerRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="WholesalerRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(WholesalerRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:WholesalerRepeater runat=\"server\"></{0}:WholesalerRepeater>")]
	public class WholesalerRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WholesalerRepeater"/> class.
        /// </summary>
		public WholesalerRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WholesalerItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WholesalerItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}
			

		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WholesalerItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WholesalerItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

      /// <summary>
      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      /// </summary>
		protected override void CreateChildControls()
      {
         if (ChildControlsCreated)
         {
            return;
         }

         Controls.Clear();

         //Instantiate the Header template (if exists)
         if (m_headerTemplate != null)
         {
            Control headerItem = new Control();
            m_headerTemplate.InstantiateIn(headerItem);
            Controls.Add(headerItem);
         }

         //Instantiate the Footer template (if exists)
         if (m_footerTemplate != null)
         {
            Control footerItem = new Control();
            m_footerTemplate.InstantiateIn(footerItem);
            Controls.Add(footerItem);
         }

         ChildControlsCreated = true;
      }
		
		/// <summary>
      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      /// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      {
         int pos = 0;

         if (dataBinding)
         {
            foreach (object o in dataSource)
            {
					CONFDB.Entities.Wholesaler entity = o as CONFDB.Entities.Wholesaler;
					WholesalerItem container = new WholesalerItem(entity);

					if (m_itemTemplate != null && (pos % 2) == 0)
					{
						m_itemTemplate.InstantiateIn(container);
					}
					else
					{
						if (m_altenateItemTemplate != null)
						{
							m_altenateItemTemplate.InstantiateIn(container);
						}
						else if (m_itemTemplate != null)
						{
							m_itemTemplate.InstantiateIn(container);
						}
						else
						{
							// no template !!!
						}
					}
					Controls.Add(container);
					
					container.DataBind();
					
					pos++;
				}
			}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class WholesalerItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Wholesaler _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WholesalerItem"/> class.
        /// </summary>
		public WholesalerItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WholesalerItem"/> class.
        /// </summary>
		public WholesalerItem(CONFDB.Entities.Wholesaler entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Id
		{
			get { return _entity.Id; }
		}
        /// <summary>
        /// Gets the CompanyName
        /// </summary>
        /// <value>The CompanyName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyName
		{
			get { return _entity.CompanyName; }
		}
        /// <summary>
        /// Gets the CompanyShortName
        /// </summary>
        /// <value>The CompanyShortName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyShortName
		{
			get { return _entity.CompanyShortName; }
		}
        /// <summary>
        /// Gets the RetailPriCustomerNumber
        /// </summary>
        /// <value>The RetailPriCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RetailPriCustomerNumber
		{
			get { return _entity.RetailPriCustomerNumber; }
		}
        /// <summary>
        /// Gets the RetailPriCustomerNumberLikeExp
        /// </summary>
        /// <value>The RetailPriCustomerNumberLikeExp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RetailPriCustomerNumberLikeExp
		{
			get { return _entity.RetailPriCustomerNumberLikeExp; }
		}
        /// <summary>
        /// Gets the DefaultModCodeLength
        /// </summary>
        /// <value>The DefaultModCodeLength.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte? DefaultModCodeLength
		{
			get { return _entity.DefaultModCodeLength; }
		}
        /// <summary>
        /// Gets the DefaultPassCodeLength
        /// </summary>
        /// <value>The DefaultPassCodeLength.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte? DefaultPassCodeLength
		{
			get { return _entity.DefaultPassCodeLength; }
		}
        /// <summary>
        /// Gets the DefaultPasswordLength
        /// </summary>
        /// <value>The DefaultPasswordLength.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte? DefaultPasswordLength
		{
			get { return _entity.DefaultPasswordLength; }
		}
        /// <summary>
        /// Gets the DefaultCapsOk
        /// </summary>
        /// <value>The DefaultCapsOk.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? DefaultCapsOk
		{
			get { return _entity.DefaultCapsOk; }
		}
        /// <summary>
        /// Gets the ModeratorTxt
        /// </summary>
        /// <value>The ModeratorTxt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModeratorTxt
		{
			get { return _entity.ModeratorTxt; }
		}
        /// <summary>
        /// Gets the ParticipantTxt
        /// </summary>
        /// <value>The ParticipantTxt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ParticipantTxt
		{
			get { return _entity.ParticipantTxt; }
		}
        /// <summary>
        /// Gets the Enabled
        /// </summary>
        /// <value>The Enabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Enabled
		{
			get { return _entity.Enabled; }
		}
        /// <summary>
        /// Gets the CustomerNumberExceptionList
        /// </summary>
        /// <value>The CustomerNumberExceptionList.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CustomerNumberExceptionList
		{
			get { return _entity.CustomerNumberExceptionList; }
		}
        /// <summary>
        /// Gets the WebProductProviderName
        /// </summary>
        /// <value>The WebProductProviderName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebProductProviderName
		{
			get { return _entity.WebProductProviderName; }
		}
        /// <summary>
        /// Gets the WebProductProviderBranding
        /// </summary>
        /// <value>The WebProductProviderBranding.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebProductProviderBranding
		{
			get { return _entity.WebProductProviderBranding; }
		}
        /// <summary>
        /// Gets the WebSecProductProvider
        /// </summary>
        /// <value>The WebSecProductProvider.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebSecProductProvider
		{
			get { return _entity.WebSecProductProvider; }
		}
        /// <summary>
        /// Gets the CurrencyId
        /// </summary>
        /// <value>The CurrencyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CurrencyId
		{
			get { return _entity.CurrencyId; }
		}
        /// <summary>
        /// Gets the BillingWholesalerId
        /// </summary>
        /// <value>The BillingWholesalerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingWholesalerId
		{
			get { return _entity.BillingWholesalerId; }
		}
        /// <summary>
        /// Gets the BillingCustomerNumber
        /// </summary>
        /// <value>The BillingCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingCustomerNumber
		{
			get { return _entity.BillingCustomerNumber; }
		}
        /// <summary>
        /// Gets the TaxableId
        /// </summary>
        /// <value>The TaxableId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 TaxableId
		{
			get { return _entity.TaxableId; }
		}
        /// <summary>
        /// Gets the WebSiteUrl
        /// </summary>
        /// <value>The WebSiteUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebSiteUrl
		{
			get { return _entity.WebSiteUrl; }
		}
        /// <summary>
        /// Gets the AdminSiteUrl
        /// </summary>
        /// <value>The AdminSiteUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AdminSiteUrl
		{
			get { return _entity.AdminSiteUrl; }
		}
        /// <summary>
        /// Gets the AdminSiteIp
        /// </summary>
        /// <value>The AdminSiteIp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AdminSiteIp
		{
			get { return _entity.AdminSiteIp; }
		}
        /// <summary>
        /// Gets the SelfServeUrl
        /// </summary>
        /// <value>The SelfServeUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SelfServeUrl
		{
			get { return _entity.SelfServeUrl; }
		}
        /// <summary>
        /// Gets the SelfServeIp
        /// </summary>
        /// <value>The SelfServeIp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SelfServeIp
		{
			get { return _entity.SelfServeIp; }
		}
        /// <summary>
        /// Gets the WebConferencingUrl
        /// </summary>
        /// <value>The WebConferencingUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebConferencingUrl
		{
			get { return _entity.WebConferencingUrl; }
		}
        /// <summary>
        /// Gets the WebConferencingIp
        /// </summary>
        /// <value>The WebConferencingIp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebConferencingIp
		{
			get { return _entity.WebConferencingIp; }
		}
        /// <summary>
        /// Gets the SupportEmail
        /// </summary>
        /// <value>The SupportEmail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SupportEmail
		{
			get { return _entity.SupportEmail; }
		}
        /// <summary>
        /// Gets the SupportPhoneNumber
        /// </summary>
        /// <value>The SupportPhoneNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SupportPhoneNumber
		{
			get { return _entity.SupportPhoneNumber; }
		}
        /// <summary>
        /// Gets the DoRetailBilling
        /// </summary>
        /// <value>The DoRetailBilling.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean DoRetailBilling
		{
			get { return _entity.DoRetailBilling; }
		}
        /// <summary>
        /// Gets the CommissionLockDate
        /// </summary>
        /// <value>The CommissionLockDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CommissionLockDate
		{
			get { return _entity.CommissionLockDate; }
		}
        /// <summary>
        /// Gets the PortalId
        /// </summary>
        /// <value>The PortalId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? PortalId
		{
			get { return _entity.PortalId; }
		}
        /// <summary>
        /// Gets the BillingAddress1
        /// </summary>
        /// <value>The BillingAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingAddress1
		{
			get { return _entity.BillingAddress1; }
		}
        /// <summary>
        /// Gets the BillingAddress2
        /// </summary>
        /// <value>The BillingAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingAddress2
		{
			get { return _entity.BillingAddress2; }
		}
        /// <summary>
        /// Gets the BillingCity
        /// </summary>
        /// <value>The BillingCity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingCity
		{
			get { return _entity.BillingCity; }
		}
        /// <summary>
        /// Gets the BillingCountry
        /// </summary>
        /// <value>The BillingCountry.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingCountry
		{
			get { return _entity.BillingCountry; }
		}
        /// <summary>
        /// Gets the BillingRegion
        /// </summary>
        /// <value>The BillingRegion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingRegion
		{
			get { return _entity.BillingRegion; }
		}
        /// <summary>
        /// Gets the BillingPostalCode
        /// </summary>
        /// <value>The BillingPostalCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingPostalCode
		{
			get { return _entity.BillingPostalCode; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.Wholesaler"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.Wholesaler Entity
        {
            get { return _entity; }
        }
	}
}
