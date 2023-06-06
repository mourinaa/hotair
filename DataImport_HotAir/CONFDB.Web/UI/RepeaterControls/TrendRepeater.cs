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
    /// A designer class for a strongly typed repeater <c>TrendRepeater</c>
    /// </summary>
	public class TrendRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TrendRepeaterDesigner"/> class.
        /// </summary>
		public TrendRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TrendRepeater))
			{ 
				throw new ArgumentException("Component is not a TrendRepeater."); 
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
			TrendRepeater z = (TrendRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="TrendRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TrendRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TrendRepeater runat=\"server\"></{0}:TrendRepeater>")]
	public class TrendRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TrendRepeater"/> class.
        /// </summary>
		public TrendRepeater()
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
		[TemplateContainer(typeof(TrendItem))]
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
		[TemplateContainer(typeof(TrendItem))]
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
		[TemplateContainer(typeof(TrendItem))]
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
		[TemplateContainer(typeof(TrendItem))]
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
					CONFDB.Entities.Trend entity = o as CONFDB.Entities.Trend;
					TrendItem container = new TrendItem(entity);

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
	public class TrendItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Trend _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrendItem"/> class.
        /// </summary>
		public TrendItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrendItem"/> class.
        /// </summary>
		public TrendItem(CONFDB.Entities.Trend entity)
			: base()
		{
			_entity = entity;
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
		public System.Int32 CustomerId
		{
			get { return _entity.CustomerId; }
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
        /// Gets the RetailCurrency
        /// </summary>
        /// <value>The RetailCurrency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RetailCurrency
		{
			get { return _entity.RetailCurrency; }
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
        /// Gets the TotalRevenueMonth01
        /// </summary>
        /// <value>The TotalRevenueMonth01.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth01
		{
			get { return _entity.TotalRevenueMonth01; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth02
        /// </summary>
        /// <value>The TotalRevenueMonth02.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth02
		{
			get { return _entity.TotalRevenueMonth02; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth03
        /// </summary>
        /// <value>The TotalRevenueMonth03.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth03
		{
			get { return _entity.TotalRevenueMonth03; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth04
        /// </summary>
        /// <value>The TotalRevenueMonth04.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth04
		{
			get { return _entity.TotalRevenueMonth04; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth05
        /// </summary>
        /// <value>The TotalRevenueMonth05.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth05
		{
			get { return _entity.TotalRevenueMonth05; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth06
        /// </summary>
        /// <value>The TotalRevenueMonth06.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth06
		{
			get { return _entity.TotalRevenueMonth06; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth07
        /// </summary>
        /// <value>The TotalRevenueMonth07.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth07
		{
			get { return _entity.TotalRevenueMonth07; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth08
        /// </summary>
        /// <value>The TotalRevenueMonth08.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth08
		{
			get { return _entity.TotalRevenueMonth08; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth09
        /// </summary>
        /// <value>The TotalRevenueMonth09.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth09
		{
			get { return _entity.TotalRevenueMonth09; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth10
        /// </summary>
        /// <value>The TotalRevenueMonth10.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth10
		{
			get { return _entity.TotalRevenueMonth10; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth11
        /// </summary>
        /// <value>The TotalRevenueMonth11.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth11
		{
			get { return _entity.TotalRevenueMonth11; }
		}
        /// <summary>
        /// Gets the TotalRevenueMonth12
        /// </summary>
        /// <value>The TotalRevenueMonth12.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? TotalRevenueMonth12
		{
			get { return _entity.TotalRevenueMonth12; }
		}
        /// <summary>
        /// Gets the YearCategory
        /// </summary>
        /// <value>The YearCategory.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? YearCategory
		{
			get { return _entity.YearCategory; }
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
        /// Gets the EndDate
        /// </summary>
        /// <value>The EndDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? EndDate
		{
			get { return _entity.EndDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.Trend"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.Trend Entity
        {
            get { return _entity; }
        }
	}
}
