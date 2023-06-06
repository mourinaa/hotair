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
    /// A designer class for a strongly typed repeater <c>CustomerRepeater</c>
    /// </summary>
	public class CustomerRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerRepeaterDesigner"/> class.
        /// </summary>
		public CustomerRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is CustomerRepeater))
			{ 
				throw new ArgumentException("Component is not a CustomerRepeater."); 
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
			CustomerRepeater z = (CustomerRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="CustomerRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(CustomerRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:CustomerRepeater runat=\"server\"></{0}:CustomerRepeater>")]
	public class CustomerRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerRepeater"/> class.
        /// </summary>
		public CustomerRepeater()
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
		[TemplateContainer(typeof(CustomerItem))]
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
		[TemplateContainer(typeof(CustomerItem))]
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
		[TemplateContainer(typeof(CustomerItem))]
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
		[TemplateContainer(typeof(CustomerItem))]
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
					CONFDB.Entities.Customer entity = o as CONFDB.Entities.Customer;
					CustomerItem container = new CustomerItem(entity);

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
	public class CustomerItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Customer _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerItem"/> class.
        /// </summary>
		public CustomerItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerItem"/> class.
        /// </summary>
		public CustomerItem(CONFDB.Entities.Customer entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Id
		{
			get { return _entity.Id; }
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
        /// Gets the PriCustomerNumber
        /// </summary>
        /// <value>The PriCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PriCustomerNumber
		{
			get { return _entity.PriCustomerNumber; }
		}
        /// <summary>
        /// Gets the Description
        /// </summary>
        /// <value>The Description.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Description
		{
			get { return _entity.Description; }
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
        /// Gets the PrimaryContactName
        /// </summary>
        /// <value>The PrimaryContactName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactName
		{
			get { return _entity.PrimaryContactName; }
		}
        /// <summary>
        /// Gets the PrimaryContactPhoneNumber
        /// </summary>
        /// <value>The PrimaryContactPhoneNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactPhoneNumber
		{
			get { return _entity.PrimaryContactPhoneNumber; }
		}
        /// <summary>
        /// Gets the PrimaryContactEmailAddress
        /// </summary>
        /// <value>The PrimaryContactEmailAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactEmailAddress
		{
			get { return _entity.PrimaryContactEmailAddress; }
		}
        /// <summary>
        /// Gets the PrimaryContactAddress1
        /// </summary>
        /// <value>The PrimaryContactAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactAddress1
		{
			get { return _entity.PrimaryContactAddress1; }
		}
        /// <summary>
        /// Gets the PrimaryContactAddress2
        /// </summary>
        /// <value>The PrimaryContactAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactAddress2
		{
			get { return _entity.PrimaryContactAddress2; }
		}
        /// <summary>
        /// Gets the PrimaryContactCity
        /// </summary>
        /// <value>The PrimaryContactCity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactCity
		{
			get { return _entity.PrimaryContactCity; }
		}
        /// <summary>
        /// Gets the PrimaryContactCountry
        /// </summary>
        /// <value>The PrimaryContactCountry.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactCountry
		{
			get { return _entity.PrimaryContactCountry; }
		}
        /// <summary>
        /// Gets the PrimaryContactRegion
        /// </summary>
        /// <value>The PrimaryContactRegion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactRegion
		{
			get { return _entity.PrimaryContactRegion; }
		}
        /// <summary>
        /// Gets the PrimaryContactPostalCode
        /// </summary>
        /// <value>The PrimaryContactPostalCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactPostalCode
		{
			get { return _entity.PrimaryContactPostalCode; }
		}
        /// <summary>
        /// Gets the PrimaryContactFaxNumber
        /// </summary>
        /// <value>The PrimaryContactFaxNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrimaryContactFaxNumber
		{
			get { return _entity.PrimaryContactFaxNumber; }
		}
        /// <summary>
        /// Gets the BillingContactName
        /// </summary>
        /// <value>The BillingContactName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactName
		{
			get { return _entity.BillingContactName; }
		}
        /// <summary>
        /// Gets the BillingContactPhoneNumber
        /// </summary>
        /// <value>The BillingContactPhoneNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactPhoneNumber
		{
			get { return _entity.BillingContactPhoneNumber; }
		}
        /// <summary>
        /// Gets the BillingContactEmailAddress
        /// </summary>
        /// <value>The BillingContactEmailAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactEmailAddress
		{
			get { return _entity.BillingContactEmailAddress; }
		}
        /// <summary>
        /// Gets the BillingContactAddress1
        /// </summary>
        /// <value>The BillingContactAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactAddress1
		{
			get { return _entity.BillingContactAddress1; }
		}
        /// <summary>
        /// Gets the BillingContactAddress2
        /// </summary>
        /// <value>The BillingContactAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactAddress2
		{
			get { return _entity.BillingContactAddress2; }
		}
        /// <summary>
        /// Gets the BillingContactCity
        /// </summary>
        /// <value>The BillingContactCity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactCity
		{
			get { return _entity.BillingContactCity; }
		}
        /// <summary>
        /// Gets the BillingContactCountry
        /// </summary>
        /// <value>The BillingContactCountry.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactCountry
		{
			get { return _entity.BillingContactCountry; }
		}
        /// <summary>
        /// Gets the BillingContactRegion
        /// </summary>
        /// <value>The BillingContactRegion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactRegion
		{
			get { return _entity.BillingContactRegion; }
		}
        /// <summary>
        /// Gets the BillingContactPostalCode
        /// </summary>
        /// <value>The BillingContactPostalCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactPostalCode
		{
			get { return _entity.BillingContactPostalCode; }
		}
        /// <summary>
        /// Gets the BillingContactFaxNumber
        /// </summary>
        /// <value>The BillingContactFaxNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingContactFaxNumber
		{
			get { return _entity.BillingContactFaxNumber; }
		}
        /// <summary>
        /// Gets the WebsiteUrl
        /// </summary>
        /// <value>The WebsiteUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebsiteUrl
		{
			get { return _entity.WebsiteUrl; }
		}
        /// <summary>
        /// Gets the SalesPersonId
        /// </summary>
        /// <value>The SalesPersonId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SalesPersonId
		{
			get { return _entity.SalesPersonId; }
		}
        /// <summary>
        /// Gets the VerticalId
        /// </summary>
        /// <value>The VerticalId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 VerticalId
		{
			get { return _entity.VerticalId; }
		}
        /// <summary>
        /// Gets the CompanyId
        /// </summary>
        /// <value>The CompanyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CompanyId
		{
			get { return _entity.CompanyId; }
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
        /// Gets the BillingPeriodCutoff
        /// </summary>
        /// <value>The BillingPeriodCutoff.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 BillingPeriodCutoff
		{
			get { return _entity.BillingPeriodCutoff; }
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
        /// Gets the CreditCardNameOnCard
        /// </summary>
        /// <value>The CreditCardNameOnCard.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardNameOnCard
		{
			get { return _entity.CreditCardNameOnCard; }
		}
        /// <summary>
        /// Gets the CreditCardNumber
        /// </summary>
        /// <value>The CreditCardNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardNumber
		{
			get { return _entity.CreditCardNumber; }
		}
        /// <summary>
        /// Gets the CreditCardExp
        /// </summary>
        /// <value>The CreditCardExp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardExp
		{
			get { return _entity.CreditCardExp; }
		}
        /// <summary>
        /// Gets the CreditCardVerCode
        /// </summary>
        /// <value>The CreditCardVerCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardVerCode
		{
			get { return _entity.CreditCardVerCode; }
		}
        /// <summary>
        /// Gets the CreditCardTypeName
        /// </summary>
        /// <value>The CreditCardTypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreditCardTypeName
		{
			get { return _entity.CreditCardTypeName; }
		}
        /// <summary>
        /// Gets the CreatedDate
        /// </summary>
        /// <value>The CreatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime CreatedDate
		{
			get { return _entity.CreatedDate; }
		}
        /// <summary>
        /// Gets the LastModified
        /// </summary>
        /// <value>The LastModified.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastModified
		{
			get { return _entity.LastModified; }
		}
        /// <summary>
        /// Gets the UniqueCustomerId
        /// </summary>
        /// <value>The UniqueCustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid UniqueCustomerId
		{
			get { return _entity.UniqueCustomerId; }
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
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UserId
		{
			get { return _entity.UserId; }
		}
        /// <summary>
        /// Gets the WebGroupId
        /// </summary>
        /// <value>The WebGroupId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebGroupId
		{
			get { return _entity.WebGroupId; }
		}
        /// <summary>
        /// Gets the AccountManagerId
        /// </summary>
        /// <value>The AccountManagerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AccountManagerId
		{
			get { return _entity.AccountManagerId; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.Customer"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.Customer Entity
        {
            get { return _entity; }
        }
	}
}
