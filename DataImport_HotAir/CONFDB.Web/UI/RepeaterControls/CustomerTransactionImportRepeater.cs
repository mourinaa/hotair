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
    /// A designer class for a strongly typed repeater <c>CustomerTransactionImportRepeater</c>
    /// </summary>
	public class CustomerTransactionImportRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerTransactionImportRepeaterDesigner"/> class.
        /// </summary>
		public CustomerTransactionImportRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is CustomerTransactionImportRepeater))
			{ 
				throw new ArgumentException("Component is not a CustomerTransactionImportRepeater."); 
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
			CustomerTransactionImportRepeater z = (CustomerTransactionImportRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="CustomerTransactionImportRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(CustomerTransactionImportRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:CustomerTransactionImportRepeater runat=\"server\"></{0}:CustomerTransactionImportRepeater>")]
	public class CustomerTransactionImportRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerTransactionImportRepeater"/> class.
        /// </summary>
		public CustomerTransactionImportRepeater()
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
		[TemplateContainer(typeof(CustomerTransactionImportItem))]
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
		[TemplateContainer(typeof(CustomerTransactionImportItem))]
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
		[TemplateContainer(typeof(CustomerTransactionImportItem))]
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
		[TemplateContainer(typeof(CustomerTransactionImportItem))]
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
					CONFDB.Entities.CustomerTransactionImport entity = o as CONFDB.Entities.CustomerTransactionImport;
					CustomerTransactionImportItem container = new CustomerTransactionImportItem(entity);

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
	public class CustomerTransactionImportItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.CustomerTransactionImport _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerTransactionImportItem"/> class.
        /// </summary>
		public CustomerTransactionImportItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomerTransactionImportItem"/> class.
        /// </summary>
		public CustomerTransactionImportItem(CONFDB.Entities.CustomerTransactionImport entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 Id
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
        /// Gets the CustomerId
        /// </summary>
        /// <value>The CustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CustomerId
		{
			get { return _entity.CustomerId; }
		}
        /// <summary>
        /// Gets the ModeratorId
        /// </summary>
        /// <value>The ModeratorId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ModeratorId
		{
			get { return _entity.ModeratorId; }
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
        /// Gets the SecCustomerNumber
        /// </summary>
        /// <value>The SecCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SecCustomerNumber
		{
			get { return _entity.SecCustomerNumber; }
		}
        /// <summary>
        /// Gets the TransactionDate
        /// </summary>
        /// <value>The TransactionDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime TransactionDate
		{
			get { return _entity.TransactionDate; }
		}
        /// <summary>
        /// Gets the TransactionAmount
        /// </summary>
        /// <value>The TransactionAmount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal TransactionAmount
		{
			get { return _entity.TransactionAmount; }
		}
        /// <summary>
        /// Gets the TransactionDescription
        /// </summary>
        /// <value>The TransactionDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TransactionDescription
		{
			get { return _entity.TransactionDescription; }
		}
        /// <summary>
        /// Gets the CustomerTransactionTypeId
        /// </summary>
        /// <value>The CustomerTransactionTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CustomerTransactionTypeId
		{
			get { return _entity.CustomerTransactionTypeId; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductId
        /// </summary>
        /// <value>The Wholesaler_ProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Wholesaler_ProductId
		{
			get { return _entity.Wholesaler_ProductId; }
		}
        /// <summary>
        /// Gets the ProductRateId
        /// </summary>
        /// <value>The ProductRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductRateId
		{
			get { return _entity.ProductRateId; }
		}
        /// <summary>
        /// Gets the Quantity
        /// </summary>
        /// <value>The Quantity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Quantity
		{
			get { return _entity.Quantity; }
		}
        /// <summary>
        /// Gets the SellRate
        /// </summary>
        /// <value>The SellRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? SellRate
		{
			get { return _entity.SellRate; }
		}
        /// <summary>
        /// Gets the BuyRate
        /// </summary>
        /// <value>The BuyRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? BuyRate
		{
			get { return _entity.BuyRate; }
		}
        /// <summary>
        /// Gets the WsTransactionAmount
        /// </summary>
        /// <value>The WsTransactionAmount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WsTransactionAmount
		{
			get { return _entity.WsTransactionAmount; }
		}
        /// <summary>
        /// Gets the ModifiedBy
        /// </summary>
        /// <value>The ModifiedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModifiedBy
		{
			get { return _entity.ModifiedBy; }
		}
        /// <summary>
        /// Gets the CreatedDate
        /// </summary>
        /// <value>The CreatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedDate
		{
			get { return _entity.CreatedDate; }
		}
        /// <summary>
        /// Gets the PostedToCustTrans
        /// </summary>
        /// <value>The PostedToCustTrans.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PostedToCustTrans
		{
			get { return _entity.PostedToCustTrans; }
		}
        /// <summary>
        /// Gets the PostedToCustTransDate
        /// </summary>
        /// <value>The PostedToCustTransDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? PostedToCustTransDate
		{
			get { return _entity.PostedToCustTransDate; }
		}
        /// <summary>
        /// Gets the ImportType
        /// </summary>
        /// <value>The ImportType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ImportType
		{
			get { return _entity.ImportType; }
		}
        /// <summary>
        /// Gets the ErrorCodesId
        /// </summary>
        /// <value>The ErrorCodesId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ErrorCodesId
		{
			get { return _entity.ErrorCodesId; }
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
        /// Gets the UniqueConferenceId
        /// </summary>
        /// <value>The UniqueConferenceId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UniqueConferenceId
		{
			get { return _entity.UniqueConferenceId; }
		}
        /// <summary>
        /// Gets the LocalTaxRate
        /// </summary>
        /// <value>The LocalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? LocalTaxRate
		{
			get { return _entity.LocalTaxRate; }
		}
        /// <summary>
        /// Gets the FederalTaxRate
        /// </summary>
        /// <value>The FederalTaxRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? FederalTaxRate
		{
			get { return _entity.FederalTaxRate; }
		}
        /// <summary>
        /// Gets the LocalTaxAmount
        /// </summary>
        /// <value>The LocalTaxAmount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? LocalTaxAmount
		{
			get { return _entity.LocalTaxAmount; }
		}
        /// <summary>
        /// Gets the FederalTaxAmount
        /// </summary>
        /// <value>The FederalTaxAmount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? FederalTaxAmount
		{
			get { return _entity.FederalTaxAmount; }
		}
        /// <summary>
        /// Gets the ElapsedTimeSeconds
        /// </summary>
        /// <value>The ElapsedTimeSeconds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ElapsedTimeSeconds
		{
			get { return _entity.ElapsedTimeSeconds; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.CustomerTransactionImport"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.CustomerTransactionImport Entity
        {
            get { return _entity; }
        }
	}
}
