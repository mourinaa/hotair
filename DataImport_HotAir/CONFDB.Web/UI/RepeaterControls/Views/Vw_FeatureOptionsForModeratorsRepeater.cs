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
    /// A designer class for a strongly typed repeater <c>Vw_FeatureOptionsForModeratorsRepeater</c>
    /// </summary>
	public class Vw_FeatureOptionsForModeratorsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_FeatureOptionsForModeratorsRepeaterDesigner"/> class.
        /// </summary>
		public Vw_FeatureOptionsForModeratorsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is Vw_FeatureOptionsForModeratorsRepeater))
			{ 
				throw new ArgumentException("Component is not a Vw_FeatureOptionsForModeratorsRepeater."); 
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
			Vw_FeatureOptionsForModeratorsRepeater z = (Vw_FeatureOptionsForModeratorsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="Vw_FeatureOptionsForModeratorsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(Vw_FeatureOptionsForModeratorsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:Vw_FeatureOptionsForModeratorsRepeater runat=\"server\"></{0}:Vw_FeatureOptionsForModeratorsRepeater>")]
	public class Vw_FeatureOptionsForModeratorsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_FeatureOptionsForModeratorsRepeater"/> class.
        /// </summary>
		public Vw_FeatureOptionsForModeratorsRepeater()
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
		[TemplateContainer(typeof(Vw_FeatureOptionsForModeratorsItem))]
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
		[TemplateContainer(typeof(Vw_FeatureOptionsForModeratorsItem))]
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
		[TemplateContainer(typeof(Vw_FeatureOptionsForModeratorsItem))]
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
		[TemplateContainer(typeof(Vw_FeatureOptionsForModeratorsItem))]
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
					CONFDB.Entities.Vw_FeatureOptionsForModerators entity = o as CONFDB.Entities.Vw_FeatureOptionsForModerators;
					Vw_FeatureOptionsForModeratorsItem container = new Vw_FeatureOptionsForModeratorsItem(entity);

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
	public class Vw_FeatureOptionsForModeratorsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Vw_FeatureOptionsForModerators _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_FeatureOptionsForModeratorsItem"/> class.
        /// </summary>
		public Vw_FeatureOptionsForModeratorsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_FeatureOptionsForModeratorsItem"/> class.
        /// </summary>
		public Vw_FeatureOptionsForModeratorsItem(CONFDB.Entities.Vw_FeatureOptionsForModerators entity)
			: base()
		{
			_entity = entity;
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
        /// Gets the SecCustomerNumber
        /// </summary>
        /// <value>The SecCustomerNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SecCustomerNumber
		{
			get { return _entity.SecCustomerNumber; }
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
        /// Gets the Moderator_FeatureId
        /// </summary>
        /// <value>The Moderator_FeatureId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Moderator_FeatureId
		{
			get { return _entity.Moderator_FeatureId; }
		}
        /// <summary>
        /// Gets the Moderator_FeatureFeatureId
        /// </summary>
        /// <value>The Moderator_FeatureFeatureId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Moderator_FeatureFeatureId
		{
			get { return _entity.Moderator_FeatureFeatureId; }
		}
        /// <summary>
        /// Gets the Moderator_FeatureFeatureOptionId
        /// </summary>
        /// <value>The Moderator_FeatureFeatureOptionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Moderator_FeatureFeatureOptionId
		{
			get { return _entity.Moderator_FeatureFeatureOptionId; }
		}
        /// <summary>
        /// Gets the Moderator_FeatureEnabled
        /// </summary>
        /// <value>The Moderator_FeatureEnabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Moderator_FeatureEnabled
		{
			get { return _entity.Moderator_FeatureEnabled; }
		}
        /// <summary>
        /// Gets the Moderator_FeatureFeatureOptionValue
        /// </summary>
        /// <value>The Moderator_FeatureFeatureOptionValue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Moderator_FeatureFeatureOptionValue
		{
			get { return _entity.Moderator_FeatureFeatureOptionValue; }
		}
        /// <summary>
        /// Gets the FeatureId
        /// </summary>
        /// <value>The FeatureId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureId
		{
			get { return _entity.FeatureId; }
		}
        /// <summary>
        /// Gets the FeatureProductId
        /// </summary>
        /// <value>The FeatureProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureProductId
		{
			get { return _entity.FeatureProductId; }
		}
        /// <summary>
        /// Gets the FeatureName
        /// </summary>
        /// <value>The FeatureName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureName
		{
			get { return _entity.FeatureName; }
		}
        /// <summary>
        /// Gets the FeatureDisplayName
        /// </summary>
        /// <value>The FeatureDisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureDisplayName
		{
			get { return _entity.FeatureDisplayName; }
		}
        /// <summary>
        /// Gets the FeatureDescription
        /// </summary>
        /// <value>The FeatureDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureDescription
		{
			get { return _entity.FeatureDescription; }
		}
        /// <summary>
        /// Gets the FeatureDisplayNameAlt
        /// </summary>
        /// <value>The FeatureDisplayNameAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureDisplayNameAlt
		{
			get { return _entity.FeatureDisplayNameAlt; }
		}
        /// <summary>
        /// Gets the FeatureDescriptionAlt
        /// </summary>
        /// <value>The FeatureDescriptionAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureDescriptionAlt
		{
			get { return _entity.FeatureDescriptionAlt; }
		}
        /// <summary>
        /// Gets the FeatureDefaultOption
        /// </summary>
        /// <value>The FeatureDefaultOption.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureDefaultOption
		{
			get { return _entity.FeatureDefaultOption; }
		}
        /// <summary>
        /// Gets the FeatureEnabled
        /// </summary>
        /// <value>The FeatureEnabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureEnabled
		{
			get { return _entity.FeatureEnabled; }
		}
        /// <summary>
        /// Gets the FeatureDisplayOrder
        /// </summary>
        /// <value>The FeatureDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureDisplayOrder
		{
			get { return _entity.FeatureDisplayOrder; }
		}
        /// <summary>
        /// Gets the FeatureDisplayOnlyToCustomer
        /// </summary>
        /// <value>The FeatureDisplayOnlyToCustomer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureDisplayOnlyToCustomer
		{
			get { return _entity.FeatureDisplayOnlyToCustomer; }
		}
        /// <summary>
        /// Gets the FeatureDisplayInAmpSite
        /// </summary>
        /// <value>The FeatureDisplayInAmpSite.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureDisplayInAmpSite
		{
			get { return _entity.FeatureDisplayInAmpSite; }
		}
        /// <summary>
        /// Gets the FeatureDisplayToCustomer
        /// </summary>
        /// <value>The FeatureDisplayToCustomer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureDisplayToCustomer
		{
			get { return _entity.FeatureDisplayToCustomer; }
		}
        /// <summary>
        /// Gets the FeatureDisplayToModerator
        /// </summary>
        /// <value>The FeatureDisplayToModerator.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureDisplayToModerator
		{
			get { return _entity.FeatureDisplayToModerator; }
		}
        /// <summary>
        /// Gets the FeatureOptionId
        /// </summary>
        /// <value>The FeatureOptionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureOptionId
		{
			get { return _entity.FeatureOptionId; }
		}
        /// <summary>
        /// Gets the FeatureOptionFeatureId
        /// </summary>
        /// <value>The FeatureOptionFeatureId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureOptionFeatureId
		{
			get { return _entity.FeatureOptionFeatureId; }
		}
        /// <summary>
        /// Gets the FeatureOptionName
        /// </summary>
        /// <value>The FeatureOptionName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionName
		{
			get { return _entity.FeatureOptionName; }
		}
        /// <summary>
        /// Gets the FeatureOptionDisplayName
        /// </summary>
        /// <value>The FeatureOptionDisplayName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionDisplayName
		{
			get { return _entity.FeatureOptionDisplayName; }
		}
        /// <summary>
        /// Gets the FeatureOptionDescription
        /// </summary>
        /// <value>The FeatureOptionDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionDescription
		{
			get { return _entity.FeatureOptionDescription; }
		}
        /// <summary>
        /// Gets the FeatureOptionDisplayNameAlt
        /// </summary>
        /// <value>The FeatureOptionDisplayNameAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionDisplayNameAlt
		{
			get { return _entity.FeatureOptionDisplayNameAlt; }
		}
        /// <summary>
        /// Gets the FeatureOptionDescriptionAlt
        /// </summary>
        /// <value>The FeatureOptionDescriptionAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionDescriptionAlt
		{
			get { return _entity.FeatureOptionDescriptionAlt; }
		}
        /// <summary>
        /// Gets the FeatureOptionValue
        /// </summary>
        /// <value>The FeatureOptionValue.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionValue
		{
			get { return _entity.FeatureOptionValue; }
		}
        /// <summary>
        /// Gets the FeatureOptionDisplayOrder
        /// </summary>
        /// <value>The FeatureOptionDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FeatureOptionDisplayOrder
		{
			get { return _entity.FeatureOptionDisplayOrder; }
		}
        /// <summary>
        /// Gets the FeatureOptionDefaultOption
        /// </summary>
        /// <value>The FeatureOptionDefaultOption.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureOptionDefaultOption
		{
			get { return _entity.FeatureOptionDefaultOption; }
		}
        /// <summary>
        /// Gets the FeatureOptionEnabled
        /// </summary>
        /// <value>The FeatureOptionEnabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean FeatureOptionEnabled
		{
			get { return _entity.FeatureOptionEnabled; }
		}
        /// <summary>
        /// Gets the FeatureOptionFeatureOptionTypeId
        /// </summary>
        /// <value>The FeatureOptionFeatureOptionTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? FeatureOptionFeatureOptionTypeId
		{
			get { return _entity.FeatureOptionFeatureOptionTypeId; }
		}
        /// <summary>
        /// Gets the FeatureOptionRegularExpression
        /// </summary>
        /// <value>The FeatureOptionRegularExpression.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionRegularExpression
		{
			get { return _entity.FeatureOptionRegularExpression; }
		}
        /// <summary>
        /// Gets the FeatureOptionTypeId
        /// </summary>
        /// <value>The FeatureOptionTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? FeatureOptionTypeId
		{
			get { return _entity.FeatureOptionTypeId; }
		}
        /// <summary>
        /// Gets the FeatureOptionTypeName
        /// </summary>
        /// <value>The FeatureOptionTypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionTypeName
		{
			get { return _entity.FeatureOptionTypeName; }
		}
        /// <summary>
        /// Gets the FeatureOptionTypeDescription
        /// </summary>
        /// <value>The FeatureOptionTypeDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FeatureOptionTypeDescription
		{
			get { return _entity.FeatureOptionTypeDescription; }
		}
        /// <summary>
        /// Gets the FeatureOptionTypeDisplayOrder
        /// </summary>
        /// <value>The FeatureOptionTypeDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? FeatureOptionTypeDisplayOrder
		{
			get { return _entity.FeatureOptionTypeDisplayOrder; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductProductId
        /// </summary>
        /// <value>The Wholesaler_ProductProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Wholesaler_ProductProductId
		{
			get { return _entity.Wholesaler_ProductProductId; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductName
        /// </summary>
        /// <value>The Wholesaler_ProductName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Wholesaler_ProductName
		{
			get { return _entity.Wholesaler_ProductName; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductDescription
        /// </summary>
        /// <value>The Wholesaler_ProductDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Wholesaler_ProductDescription
		{
			get { return _entity.Wholesaler_ProductDescription; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductDisplayNameAlt
        /// </summary>
        /// <value>The Wholesaler_ProductDisplayNameAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Wholesaler_ProductDisplayNameAlt
		{
			get { return _entity.Wholesaler_ProductDisplayNameAlt; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductDescriptionAlt
        /// </summary>
        /// <value>The Wholesaler_ProductDescriptionAlt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Wholesaler_ProductDescriptionAlt
		{
			get { return _entity.Wholesaler_ProductDescriptionAlt; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductDisplayOrder
        /// </summary>
        /// <value>The Wholesaler_ProductDisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Wholesaler_ProductDisplayOrder
		{
			get { return _entity.Wholesaler_ProductDisplayOrder; }
		}
        /// <summary>
        /// Gets the Wholesaler_ProductEnabled
        /// </summary>
        /// <value>The Wholesaler_ProductEnabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Wholesaler_ProductEnabled
		{
			get { return _entity.Wholesaler_ProductEnabled; }
		}

	}
}
