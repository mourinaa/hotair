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
    /// A designer class for a strongly typed repeater <c>AverageRatesRepeater</c>
    /// </summary>
	public class AverageRatesRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AverageRatesRepeaterDesigner"/> class.
        /// </summary>
		public AverageRatesRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AverageRatesRepeater))
			{ 
				throw new ArgumentException("Component is not a AverageRatesRepeater."); 
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
			AverageRatesRepeater z = (AverageRatesRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="AverageRatesRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(AverageRatesRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AverageRatesRepeater runat=\"server\"></{0}:AverageRatesRepeater>")]
	public class AverageRatesRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AverageRatesRepeater"/> class.
        /// </summary>
		public AverageRatesRepeater()
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
		[TemplateContainer(typeof(AverageRatesItem))]
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
		[TemplateContainer(typeof(AverageRatesItem))]
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
		[TemplateContainer(typeof(AverageRatesItem))]
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
		[TemplateContainer(typeof(AverageRatesItem))]
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
					CONFDB.Entities.AverageRates entity = o as CONFDB.Entities.AverageRates;
					AverageRatesItem container = new AverageRatesItem(entity);

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
	public class AverageRatesItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.AverageRates _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AverageRatesItem"/> class.
        /// </summary>
		public AverageRatesItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AverageRatesItem"/> class.
        /// </summary>
		public AverageRatesItem(CONFDB.Entities.AverageRates entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the UsageMonth
        /// </summary>
        /// <value>The UsageMonth.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime UsageMonth
		{
			get { return _entity.UsageMonth; }
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
        /// Gets the WholesalerId
        /// </summary>
        /// <value>The WholesalerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WholesalerId
		{
			get { return _entity.WholesalerId; }
		}
        /// <summary>
        /// Gets the MedianRetailRate
        /// </summary>
        /// <value>The MedianRetailRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? MedianRetailRate
		{
			get { return _entity.MedianRetailRate; }
		}
        /// <summary>
        /// Gets the AverageRetailRate
        /// </summary>
        /// <value>The AverageRetailRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? AverageRetailRate
		{
			get { return _entity.AverageRetailRate; }
		}
        /// <summary>
        /// Gets the WeightedAverageRetailRate
        /// </summary>
        /// <value>The WeightedAverageRetailRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WeightedAverageRetailRate
		{
			get { return _entity.WeightedAverageRetailRate; }
		}
        /// <summary>
        /// Gets the MedianWsRate
        /// </summary>
        /// <value>The MedianWsRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? MedianWsRate
		{
			get { return _entity.MedianWsRate; }
		}
        /// <summary>
        /// Gets the AverageWsRate
        /// </summary>
        /// <value>The AverageWsRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? AverageWsRate
		{
			get { return _entity.AverageWsRate; }
		}
        /// <summary>
        /// Gets the WeightedAverageWsRate
        /// </summary>
        /// <value>The WeightedAverageWsRate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? WeightedAverageWsRate
		{
			get { return _entity.WeightedAverageWsRate; }
		}
        /// <summary>
        /// Gets the UsageSeconds
        /// </summary>
        /// <value>The UsageSeconds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UsageSeconds
		{
			get { return _entity.UsageSeconds; }
		}
        /// <summary>
        /// Gets the UsageQuantity
        /// </summary>
        /// <value>The UsageQuantity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UsageQuantity
		{
			get { return _entity.UsageQuantity; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.AverageRates"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.AverageRates Entity
        {
            get { return _entity; }
        }
	}
}
