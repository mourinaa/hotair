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
    /// A designer class for a strongly typed repeater <c>ProductRateValueRepeater</c>
    /// </summary>
	public class ProductRateValueRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ProductRateValueRepeaterDesigner"/> class.
        /// </summary>
		public ProductRateValueRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is ProductRateValueRepeater))
			{ 
				throw new ArgumentException("Component is not a ProductRateValueRepeater."); 
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
			ProductRateValueRepeater z = (ProductRateValueRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="ProductRateValueRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(ProductRateValueRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:ProductRateValueRepeater runat=\"server\"></{0}:ProductRateValueRepeater>")]
	public class ProductRateValueRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ProductRateValueRepeater"/> class.
        /// </summary>
		public ProductRateValueRepeater()
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
		[TemplateContainer(typeof(ProductRateValueItem))]
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
		[TemplateContainer(typeof(ProductRateValueItem))]
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
		[TemplateContainer(typeof(ProductRateValueItem))]
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
		[TemplateContainer(typeof(ProductRateValueItem))]
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
					CONFDB.Entities.ProductRateValue entity = o as CONFDB.Entities.ProductRateValue;
					ProductRateValueItem container = new ProductRateValueItem(entity);

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
	public class ProductRateValueItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.ProductRateValue _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ProductRateValueItem"/> class.
        /// </summary>
		public ProductRateValueItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ProductRateValueItem"/> class.
        /// </summary>
		public ProductRateValueItem(CONFDB.Entities.ProductRateValue entity)
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
        /// Gets the ProductRateId
        /// </summary>
        /// <value>The ProductRateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductRateId
		{
			get { return _entity.ProductRateId; }
		}
        /// <summary>
        /// Gets the SellRate
        /// </summary>
        /// <value>The SellRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal SellRate
		{
			get { return _entity.SellRate; }
		}
        /// <summary>
        /// Gets the SellRateCurrencyId
        /// </summary>
        /// <value>The SellRateCurrencyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SellRateCurrencyId
		{
			get { return _entity.SellRateCurrencyId; }
		}
        /// <summary>
        /// Gets the BuyRate
        /// </summary>
        /// <value>The BuyRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal BuyRate
		{
			get { return _entity.BuyRate; }
		}
        /// <summary>
        /// Gets the BuyRateCurrencyId
        /// </summary>
        /// <value>The BuyRateCurrencyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BuyRateCurrencyId
		{
			get { return _entity.BuyRateCurrencyId; }
		}
        /// <summary>
        /// Gets the DefaultOption
        /// </summary>
        /// <value>The DefaultOption.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte DefaultOption
		{
			get { return _entity.DefaultOption; }
		}
        /// <summary>
        /// Gets the StartDate
        /// </summary>
        /// <value>The StartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? StartDate
		{
			get { return _entity.StartDate; }
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
        /// Gets a <see cref="T:CONFDB.Entities.ProductRateValue"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.ProductRateValue Entity
        {
            get { return _entity; }
        }
	}
}
