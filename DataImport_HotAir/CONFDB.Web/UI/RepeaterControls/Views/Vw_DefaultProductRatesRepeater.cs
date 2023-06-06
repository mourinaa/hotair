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
    /// A designer class for a strongly typed repeater <c>Vw_DefaultProductRatesRepeater</c>
    /// </summary>
	public class Vw_DefaultProductRatesRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_DefaultProductRatesRepeaterDesigner"/> class.
        /// </summary>
		public Vw_DefaultProductRatesRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is Vw_DefaultProductRatesRepeater))
			{ 
				throw new ArgumentException("Component is not a Vw_DefaultProductRatesRepeater."); 
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
			Vw_DefaultProductRatesRepeater z = (Vw_DefaultProductRatesRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="Vw_DefaultProductRatesRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(Vw_DefaultProductRatesRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:Vw_DefaultProductRatesRepeater runat=\"server\"></{0}:Vw_DefaultProductRatesRepeater>")]
	public class Vw_DefaultProductRatesRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_DefaultProductRatesRepeater"/> class.
        /// </summary>
		public Vw_DefaultProductRatesRepeater()
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
		[TemplateContainer(typeof(Vw_DefaultProductRatesItem))]
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
		[TemplateContainer(typeof(Vw_DefaultProductRatesItem))]
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
		[TemplateContainer(typeof(Vw_DefaultProductRatesItem))]
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
		[TemplateContainer(typeof(Vw_DefaultProductRatesItem))]
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

			if (m_headerTemplate != null)
			{
				Control headerItem = new Control();
				m_headerTemplate.InstantiateIn(headerItem);
				Controls.Add(headerItem);
			}

			
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
					CONFDB.Entities.Vw_DefaultProductRates entity = o as CONFDB.Entities.Vw_DefaultProductRates;
					Vw_DefaultProductRatesItem container = new Vw_DefaultProductRatesItem(entity);

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
	public class Vw_DefaultProductRatesItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Vw_DefaultProductRates _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_DefaultProductRatesItem"/> class.
        /// </summary>
		public Vw_DefaultProductRatesItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_DefaultProductRatesItem"/> class.
        /// </summary>
		public Vw_DefaultProductRatesItem(CONFDB.Entities.Vw_DefaultProductRates entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the ProductRateValueId
        /// </summary>
        /// <value>The ProductRateValueId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductRateValueId
		{
			get { return _entity.ProductRateValueId; }
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
        /// Gets the StartDate
        /// </summary>
        /// <value>The StartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? StartDate
		{
			get { return _entity.StartDate; }
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
        /// Gets the ProductRateName
        /// </summary>
        /// <value>The ProductRateName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductRateName
		{
			get { return _entity.ProductRateName; }
		}
        /// <summary>
        /// Gets the ProductId
        /// </summary>
        /// <value>The ProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductId
		{
			get { return _entity.ProductId; }
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
        /// Gets the ProductDefaultOption
        /// </summary>
        /// <value>The ProductDefaultOption.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? ProductDefaultOption
		{
			get { return _entity.ProductDefaultOption; }
		}
        /// <summary>
        /// Gets the ProductTypeId
        /// </summary>
        /// <value>The ProductTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductTypeId
		{
			get { return _entity.ProductTypeId; }
		}
        /// <summary>
        /// Gets the ProductRateTypeId
        /// </summary>
        /// <value>The ProductRateTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ProductRateTypeId
		{
			get { return _entity.ProductRateTypeId; }
		}
        /// <summary>
        /// Gets the ProductTypeName
        /// </summary>
        /// <value>The ProductTypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductTypeName
		{
			get { return _entity.ProductTypeName; }
		}
        /// <summary>
        /// Gets the ProductRateTypeName
        /// </summary>
        /// <value>The ProductRateTypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductRateTypeName
		{
			get { return _entity.ProductRateTypeName; }
		}
        /// <summary>
        /// Gets the ProductDisplayOrder
        /// </summary>
        /// <value>The ProductDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductDisplayOrder
		{
			get { return _entity.ProductDisplayOrder; }
		}
        /// <summary>
        /// Gets the ProductRateDisplayName
        /// </summary>
        /// <value>The ProductRateDisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductRateDisplayName
		{
			get { return _entity.ProductRateDisplayName; }
		}
        /// <summary>
        /// Gets the ProductRateDisplayOrder
        /// </summary>
        /// <value>The ProductRateDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductRateDisplayOrder
		{
			get { return _entity.ProductRateDisplayOrder; }
		}
        /// <summary>
        /// Gets the ProductTypeDisplayName
        /// </summary>
        /// <value>The ProductTypeDisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductTypeDisplayName
		{
			get { return _entity.ProductTypeDisplayName; }
		}
        /// <summary>
        /// Gets the ProductTypeDisplayOrder
        /// </summary>
        /// <value>The ProductTypeDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductTypeDisplayOrder
		{
			get { return _entity.ProductTypeDisplayOrder; }
		}
        /// <summary>
        /// Gets the ProductRateTypeDisplayName
        /// </summary>
        /// <value>The ProductRateTypeDisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProductRateTypeDisplayName
		{
			get { return _entity.ProductRateTypeDisplayName; }
		}
        /// <summary>
        /// Gets the ProductRateTypeDisplayOrder
        /// </summary>
        /// <value>The ProductRateTypeDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProductRateTypeDisplayOrder
		{
			get { return _entity.ProductRateTypeDisplayOrder; }
		}
        /// <summary>
        /// Gets the DdlDescription
        /// </summary>
        /// <value>The DdlDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DdlDescription
		{
			get { return _entity.DdlDescription; }
		}
        /// <summary>
        /// Gets the RatingTypeId
        /// </summary>
        /// <value>The RatingTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 RatingTypeId
		{
			get { return _entity.RatingTypeId; }
		}
        /// <summary>
        /// Gets the DisplayName
        /// </summary>
        /// <value>The DisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DisplayName
		{
			get { return _entity.DisplayName; }
		}
        /// <summary>
        /// Gets the DdlDescription2
        /// </summary>
        /// <value>The DdlDescription2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DdlDescription2
		{
			get { return _entity.DdlDescription2; }
		}

	}
}
