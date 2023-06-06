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
    /// A designer class for a strongly typed repeater <c>Vw_ConferenceListRepeater</c>
    /// </summary>
	public class Vw_ConferenceListRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_ConferenceListRepeaterDesigner"/> class.
        /// </summary>
		public Vw_ConferenceListRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is Vw_ConferenceListRepeater))
			{ 
				throw new ArgumentException("Component is not a Vw_ConferenceListRepeater."); 
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
			Vw_ConferenceListRepeater z = (Vw_ConferenceListRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="Vw_ConferenceListRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(Vw_ConferenceListRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:Vw_ConferenceListRepeater runat=\"server\"></{0}:Vw_ConferenceListRepeater>")]
	public class Vw_ConferenceListRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_ConferenceListRepeater"/> class.
        /// </summary>
		public Vw_ConferenceListRepeater()
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
		[TemplateContainer(typeof(Vw_ConferenceListItem))]
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
		[TemplateContainer(typeof(Vw_ConferenceListItem))]
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
		[TemplateContainer(typeof(Vw_ConferenceListItem))]
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
		[TemplateContainer(typeof(Vw_ConferenceListItem))]
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
					CONFDB.Entities.Vw_ConferenceList entity = o as CONFDB.Entities.Vw_ConferenceList;
					Vw_ConferenceListItem container = new Vw_ConferenceListItem(entity);

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
	public class Vw_ConferenceListItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Vw_ConferenceList _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_ConferenceListItem"/> class.
        /// </summary>
		public Vw_ConferenceListItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_ConferenceListItem"/> class.
        /// </summary>
		public Vw_ConferenceListItem(CONFDB.Entities.Vw_ConferenceList entity)
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
        /// Gets the CompanyName
        /// </summary>
        /// <value>The CompanyName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyName
		{
			get { return _entity.CompanyName; }
		}
        /// <summary>
        /// Gets the AdminName
        /// </summary>
        /// <value>The AdminName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AdminName
		{
			get { return _entity.AdminName; }
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
        /// Gets the SeeVoghMeetingId
        /// </summary>
        /// <value>The SeeVoghMeetingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SeeVoghMeetingId
		{
			get { return _entity.SeeVoghMeetingId; }
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
        /// Gets the LastWalletCardSentdate
        /// </summary>
        /// <value>The LastWalletCardSentdate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastWalletCardSentdate
		{
			get { return _entity.LastWalletCardSentdate; }
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
        /// Gets the CompanyId
        /// </summary>
        /// <value>The CompanyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CompanyId
		{
			get { return _entity.CompanyId; }
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
        /// Gets the SalesPerson
        /// </summary>
        /// <value>The SalesPerson.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SalesPerson
		{
			get { return _entity.SalesPerson; }
		}
        /// <summary>
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UserId
		{
			get { return _entity.UserId; }
		}
        /// <summary>
        /// Gets the ConferenceName
        /// </summary>
        /// <value>The ConferenceName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ConferenceName
		{
			get { return _entity.ConferenceName; }
		}

	}
}
