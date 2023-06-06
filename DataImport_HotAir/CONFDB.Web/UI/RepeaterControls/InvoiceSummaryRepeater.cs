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
    /// A designer class for a strongly typed repeater <c>InvoiceSummaryRepeater</c>
    /// </summary>
	public class InvoiceSummaryRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:InvoiceSummaryRepeaterDesigner"/> class.
        /// </summary>
		public InvoiceSummaryRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is InvoiceSummaryRepeater))
			{ 
				throw new ArgumentException("Component is not a InvoiceSummaryRepeater."); 
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
			InvoiceSummaryRepeater z = (InvoiceSummaryRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="InvoiceSummaryRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(InvoiceSummaryRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:InvoiceSummaryRepeater runat=\"server\"></{0}:InvoiceSummaryRepeater>")]
	public class InvoiceSummaryRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:InvoiceSummaryRepeater"/> class.
        /// </summary>
		public InvoiceSummaryRepeater()
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
		[TemplateContainer(typeof(InvoiceSummaryItem))]
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
		[TemplateContainer(typeof(InvoiceSummaryItem))]
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
		[TemplateContainer(typeof(InvoiceSummaryItem))]
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
		[TemplateContainer(typeof(InvoiceSummaryItem))]
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
					CONFDB.Entities.InvoiceSummary entity = o as CONFDB.Entities.InvoiceSummary;
					InvoiceSummaryItem container = new InvoiceSummaryItem(entity);

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
	public class InvoiceSummaryItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.InvoiceSummary _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InvoiceSummaryItem"/> class.
        /// </summary>
		public InvoiceSummaryItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InvoiceSummaryItem"/> class.
        /// </summary>
		public InvoiceSummaryItem(CONFDB.Entities.InvoiceSummary entity)
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
        /// Gets the StartDate
        /// </summary>
        /// <value>The StartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime StartDate
		{
			get { return _entity.StartDate; }
		}
        /// <summary>
        /// Gets the EndDate
        /// </summary>
        /// <value>The EndDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime EndDate
		{
			get { return _entity.EndDate; }
		}
        /// <summary>
        /// Gets the CustomerId
        /// </summary>
        /// <value>The CustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CustomerId
		{
			get { return _entity.CustomerId; }
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
        /// Gets the InvoiceNumber
        /// </summary>
        /// <value>The InvoiceNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String InvoiceNumber
		{
			get { return _entity.InvoiceNumber; }
		}
        /// <summary>
        /// Gets the AmountOfLastBill
        /// </summary>
        /// <value>The AmountOfLastBill.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? AmountOfLastBill
		{
			get { return _entity.AmountOfLastBill; }
		}
        /// <summary>
        /// Gets the Payment1
        /// </summary>
        /// <value>The Payment1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? Payment1
		{
			get { return _entity.Payment1; }
		}
        /// <summary>
        /// Gets the TotalCredits
        /// </summary>
        /// <value>The TotalCredits.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalCredits
		{
			get { return _entity.TotalCredits; }
		}
        /// <summary>
        /// Gets the TotalLatePaymentCharges
        /// </summary>
        /// <value>The TotalLatePaymentCharges.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalLatePaymentCharges
		{
			get { return _entity.TotalLatePaymentCharges; }
		}
        /// <summary>
        /// Gets the BalForward
        /// </summary>
        /// <value>The BalForward.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? BalForward
		{
			get { return _entity.BalForward; }
		}
        /// <summary>
        /// Gets the ProductCharges
        /// </summary>
        /// <value>The ProductCharges.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? ProductCharges
		{
			get { return _entity.ProductCharges; }
		}
        /// <summary>
        /// Gets the MiscCharges
        /// </summary>
        /// <value>The MiscCharges.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? MiscCharges
		{
			get { return _entity.MiscCharges; }
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
        /// Gets the TotalCurrent
        /// </summary>
        /// <value>The TotalCurrent.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalCurrent
		{
			get { return _entity.TotalCurrent; }
		}
        /// <summary>
        /// Gets the BalanceForward
        /// </summary>
        /// <value>The BalanceForward.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? BalanceForward
		{
			get { return _entity.BalanceForward; }
		}
        /// <summary>
        /// Gets the InvoiceDate
        /// </summary>
        /// <value>The InvoiceDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime InvoiceDate
		{
			get { return _entity.InvoiceDate; }
		}
        /// <summary>
        /// Gets the DueDate
        /// </summary>
        /// <value>The DueDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime DueDate
		{
			get { return _entity.DueDate; }
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
        /// Gets the WholesalerId
        /// </summary>
        /// <value>The WholesalerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WholesalerId
		{
			get { return _entity.WholesalerId; }
		}
        /// <summary>
        /// Gets the TotalFreeCredits
        /// </summary>
        /// <value>The TotalFreeCredits.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalFreeCredits
		{
			get { return _entity.TotalFreeCredits; }
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
        /// Gets the BpayCustomerRefNumber
        /// </summary>
        /// <value>The BpayCustomerRefNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BpayCustomerRefNumber
		{
			get { return _entity.BpayCustomerRefNumber; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.InvoiceSummary"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.InvoiceSummary Entity
        {
            get { return _entity; }
        }
	}
}
