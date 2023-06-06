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
    /// A designer class for a strongly typed repeater <c>BillableLegsRepeater</c>
    /// </summary>
	public class BillableLegsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:BillableLegsRepeaterDesigner"/> class.
        /// </summary>
		public BillableLegsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is BillableLegsRepeater))
			{ 
				throw new ArgumentException("Component is not a BillableLegsRepeater."); 
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
			BillableLegsRepeater z = (BillableLegsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="BillableLegsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(BillableLegsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:BillableLegsRepeater runat=\"server\"></{0}:BillableLegsRepeater>")]
	public class BillableLegsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:BillableLegsRepeater"/> class.
        /// </summary>
		public BillableLegsRepeater()
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
		[TemplateContainer(typeof(BillableLegsItem))]
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
		[TemplateContainer(typeof(BillableLegsItem))]
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
		[TemplateContainer(typeof(BillableLegsItem))]
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
		[TemplateContainer(typeof(BillableLegsItem))]
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
					CONFDB.Entities.BillableLegs entity = o as CONFDB.Entities.BillableLegs;
					BillableLegsItem container = new BillableLegsItem(entity);

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
	public class BillableLegsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.BillableLegs _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BillableLegsItem"/> class.
        /// </summary>
		public BillableLegsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BillableLegsItem"/> class.
        /// </summary>
		public BillableLegsItem(CONFDB.Entities.BillableLegs entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid Id
		{
			get { return _entity.Id; }
		}
        /// <summary>
        /// Gets the ConferenceId
        /// </summary>
        /// <value>The ConferenceId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ConferenceId
		{
			get { return _entity.ConferenceId; }
		}
        /// <summary>
        /// Gets the ModeratorId
        /// </summary>
        /// <value>The ModeratorId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ModeratorId
		{
			get { return _entity.ModeratorId; }
		}
        /// <summary>
        /// Gets the WholesalerId
        /// </summary>
        /// <value>The WholesalerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WholesalerId
		{
			get { return _entity.WholesalerId; }
		}
        /// <summary>
        /// Gets the ModeratorCode
        /// </summary>
        /// <value>The ModeratorCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModeratorCode
		{
			get { return _entity.ModeratorCode; }
		}
        /// <summary>
        /// Gets the PassCode
        /// </summary>
        /// <value>The PassCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PassCode
		{
			get { return _entity.PassCode; }
		}
        /// <summary>
        /// Gets the ModeratorName
        /// </summary>
        /// <value>The ModeratorName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModeratorName
		{
			get { return _entity.ModeratorName; }
		}
        /// <summary>
        /// Gets the Moderator
        /// </summary>
        /// <value>The Moderator.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Moderator
		{
			get { return _entity.Moderator; }
		}
        /// <summary>
        /// Gets the ExternalCustomerNumber
        /// </summary>
        /// <value>The ExternalCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExternalCustomerNumber
		{
			get { return _entity.ExternalCustomerNumber; }
		}
        /// <summary>
        /// Gets the ExternalModeratorNumber
        /// </summary>
        /// <value>The ExternalModeratorNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExternalModeratorNumber
		{
			get { return _entity.ExternalModeratorNumber; }
		}
        /// <summary>
        /// Gets the ReferenceNumber
        /// </summary>
        /// <value>The ReferenceNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReferenceNumber
		{
			get { return _entity.ReferenceNumber; }
		}
        /// <summary>
        /// Gets the StartTime
        /// </summary>
        /// <value>The StartTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime StartTime
		{
			get { return _entity.StartTime; }
		}
        /// <summary>
        /// Gets the EndTime
        /// </summary>
        /// <value>The EndTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime EndTime
		{
			get { return _entity.EndTime; }
		}
        /// <summary>
        /// Gets the ElapsedTime
        /// </summary>
        /// <value>The ElapsedTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ElapsedTime
		{
			get { return _entity.ElapsedTime; }
		}
        /// <summary>
        /// Gets the BridgeId
        /// </summary>
        /// <value>The BridgeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16 BridgeId
		{
			get { return _entity.BridgeId; }
		}
        /// <summary>
        /// Gets the UniqueConferenceId
        /// </summary>
        /// <value>The UniqueConferenceId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UniqueConferenceId
		{
			get { return _entity.UniqueConferenceId; }
		}
        /// <summary>
        /// Gets the AuxiliaryConferenceId
        /// </summary>
        /// <value>The AuxiliaryConferenceId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AuxiliaryConferenceId
		{
			get { return _entity.AuxiliaryConferenceId; }
		}
        /// <summary>
        /// Gets the Dnis
        /// </summary>
        /// <value>The Dnis.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Dnis
		{
			get { return _entity.Dnis; }
		}
        /// <summary>
        /// Gets the DialNumber
        /// </summary>
        /// <value>The DialNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DialNumber
		{
			get { return _entity.DialNumber; }
		}
        /// <summary>
        /// Gets the Ani
        /// </summary>
        /// <value>The Ani.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Ani
		{
			get { return _entity.Ani; }
		}
        /// <summary>
        /// Gets the ParticipantName
        /// </summary>
        /// <value>The ParticipantName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ParticipantName
		{
			get { return _entity.ParticipantName; }
		}
        /// <summary>
        /// Gets the Destination
        /// </summary>
        /// <value>The Destination.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Destination
		{
			get { return _entity.Destination; }
		}
        /// <summary>
        /// Gets the AccessTypeId
        /// </summary>
        /// <value>The AccessTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AccessTypeId
		{
			get { return _entity.AccessTypeId; }
		}
        /// <summary>
        /// Gets the ConnectProductRateId
        /// </summary>
        /// <value>The ConnectProductRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ConnectProductRateId
		{
			get { return _entity.ConnectProductRateId; }
		}
        /// <summary>
        /// Gets the BridgeProductRateId
        /// </summary>
        /// <value>The BridgeProductRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 BridgeProductRateId
		{
			get { return _entity.BridgeProductRateId; }
		}
        /// <summary>
        /// Gets the LdProductRateId
        /// </summary>
        /// <value>The LdProductRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 LdProductRateId
		{
			get { return _entity.LdProductRateId; }
		}
        /// <summary>
        /// Gets the ProductRateTaxableValue
        /// </summary>
        /// <value>The ProductRateTaxableValue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductRateTaxableValue
		{
			get { return _entity.ProductRateTaxableValue; }
		}
        /// <summary>
        /// Gets the CustomerTaxableValue
        /// </summary>
        /// <value>The CustomerTaxableValue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CustomerTaxableValue
		{
			get { return _entity.CustomerTaxableValue; }
		}
        /// <summary>
        /// Gets the WsTaxableValue
        /// </summary>
        /// <value>The WsTaxableValue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 WsTaxableValue
		{
			get { return _entity.WsTaxableValue; }
		}
        /// <summary>
        /// Gets the RetailConnectCharge
        /// </summary>
        /// <value>The RetailConnectCharge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailConnectCharge
		{
			get { return _entity.RetailConnectCharge; }
		}
        /// <summary>
        /// Gets the RetailBridgeRate
        /// </summary>
        /// <value>The RetailBridgeRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailBridgeRate
		{
			get { return _entity.RetailBridgeRate; }
		}
        /// <summary>
        /// Gets the RetailLdRate
        /// </summary>
        /// <value>The RetailLdRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailLdRate
		{
			get { return _entity.RetailLdRate; }
		}
        /// <summary>
        /// Gets the RetailCurrency
        /// </summary>
        /// <value>The RetailCurrency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RetailCurrency
		{
			get { return _entity.RetailCurrency; }
		}
        /// <summary>
        /// Gets the RetailBillingInterval
        /// </summary>
        /// <value>The RetailBillingInterval.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 RetailBillingInterval
		{
			get { return _entity.RetailBillingInterval; }
		}
        /// <summary>
        /// Gets the RetailTotalConnectCharge
        /// </summary>
        /// <value>The RetailTotalConnectCharge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailTotalConnectCharge
		{
			get { return _entity.RetailTotalConnectCharge; }
		}
        /// <summary>
        /// Gets the RetailTotalBridge
        /// </summary>
        /// <value>The RetailTotalBridge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailTotalBridge
		{
			get { return _entity.RetailTotalBridge; }
		}
        /// <summary>
        /// Gets the RetailTotalLd
        /// </summary>
        /// <value>The RetailTotalLd.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailTotalLd
		{
			get { return _entity.RetailTotalLd; }
		}
        /// <summary>
        /// Gets the RetailTotal
        /// </summary>
        /// <value>The RetailTotal.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailTotal
		{
			get { return _entity.RetailTotal; }
		}
        /// <summary>
        /// Gets the RetailLocalTaxRate
        /// </summary>
        /// <value>The RetailLocalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailLocalTaxRate
		{
			get { return _entity.RetailLocalTaxRate; }
		}
        /// <summary>
        /// Gets the RetailFederalTaxRate
        /// </summary>
        /// <value>The RetailFederalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailFederalTaxRate
		{
			get { return _entity.RetailFederalTaxRate; }
		}
        /// <summary>
        /// Gets the RetailLocalTax
        /// </summary>
        /// <value>The RetailLocalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailLocalTax
		{
			get { return _entity.RetailLocalTax; }
		}
        /// <summary>
        /// Gets the RetailFederalTax
        /// </summary>
        /// <value>The RetailFederalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailFederalTax
		{
			get { return _entity.RetailFederalTax; }
		}
        /// <summary>
        /// Gets the RetailTotalTax
        /// </summary>
        /// <value>The RetailTotalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? RetailTotalTax
		{
			get { return _entity.RetailTotalTax; }
		}
        /// <summary>
        /// Gets the WsConnectCharge
        /// </summary>
        /// <value>The WsConnectCharge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsConnectCharge
		{
			get { return _entity.WsConnectCharge; }
		}
        /// <summary>
        /// Gets the WsBridgeRate
        /// </summary>
        /// <value>The WsBridgeRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsBridgeRate
		{
			get { return _entity.WsBridgeRate; }
		}
        /// <summary>
        /// Gets the WsldRate
        /// </summary>
        /// <value>The WsldRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsldRate
		{
			get { return _entity.WsldRate; }
		}
        /// <summary>
        /// Gets the WsCurrency
        /// </summary>
        /// <value>The WsCurrency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WsCurrency
		{
			get { return _entity.WsCurrency; }
		}
        /// <summary>
        /// Gets the WsBillingInterval
        /// </summary>
        /// <value>The WsBillingInterval.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 WsBillingInterval
		{
			get { return _entity.WsBillingInterval; }
		}
        /// <summary>
        /// Gets the WsTotalConnectCharge
        /// </summary>
        /// <value>The WsTotalConnectCharge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTotalConnectCharge
		{
			get { return _entity.WsTotalConnectCharge; }
		}
        /// <summary>
        /// Gets the WsTotalBridge
        /// </summary>
        /// <value>The WsTotalBridge.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTotalBridge
		{
			get { return _entity.WsTotalBridge; }
		}
        /// <summary>
        /// Gets the WsTotalLd
        /// </summary>
        /// <value>The WsTotalLd.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTotalLd
		{
			get { return _entity.WsTotalLd; }
		}
        /// <summary>
        /// Gets the WsTotal
        /// </summary>
        /// <value>The WsTotal.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTotal
		{
			get { return _entity.WsTotal; }
		}
        /// <summary>
        /// Gets the WsLocalTaxRate
        /// </summary>
        /// <value>The WsLocalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsLocalTaxRate
		{
			get { return _entity.WsLocalTaxRate; }
		}
        /// <summary>
        /// Gets the WsFederalTaxRate
        /// </summary>
        /// <value>The WsFederalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsFederalTaxRate
		{
			get { return _entity.WsFederalTaxRate; }
		}
        /// <summary>
        /// Gets the WsLocalTax
        /// </summary>
        /// <value>The WsLocalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsLocalTax
		{
			get { return _entity.WsLocalTax; }
		}
        /// <summary>
        /// Gets the WsFederalTax
        /// </summary>
        /// <value>The WsFederalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsFederalTax
		{
			get { return _entity.WsFederalTax; }
		}
        /// <summary>
        /// Gets the WsTotalTax
        /// </summary>
        /// <value>The WsTotalTax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTotalTax
		{
			get { return _entity.WsTotalTax; }
		}
        /// <summary>
        /// Gets the BillingStatus
        /// </summary>
        /// <value>The BillingStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? BillingStatus
		{
			get { return _entity.BillingStatus; }
		}
        /// <summary>
        /// Gets the BilledDate
        /// </summary>
        /// <value>The BilledDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? BilledDate
		{
			get { return _entity.BilledDate; }
		}
        /// <summary>
        /// Gets the ProcessedDate
        /// </summary>
        /// <value>The ProcessedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ProcessedDate
		{
			get { return _entity.ProcessedDate; }
		}
        /// <summary>
        /// Gets the RatedToZero
        /// </summary>
        /// <value>The RatedToZero.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? RatedToZero
		{
			get { return _entity.RatedToZero; }
		}
        /// <summary>
        /// Gets the ProductName
        /// </summary>
        /// <value>The ProductName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductName
		{
			get { return _entity.ProductName; }
		}
        /// <summary>
        /// Gets the ProductNameAlt
        /// </summary>
        /// <value>The ProductNameAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductNameAlt
		{
			get { return _entity.ProductNameAlt; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.BillableLegs"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.BillableLegs Entity
        {
            get { return _entity; }
        }
	}
}
