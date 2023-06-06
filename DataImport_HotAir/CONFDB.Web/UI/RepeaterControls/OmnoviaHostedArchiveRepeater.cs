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
    /// A designer class for a strongly typed repeater <c>OmnoviaHostedArchiveRepeater</c>
    /// </summary>
	public class OmnoviaHostedArchiveRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:OmnoviaHostedArchiveRepeaterDesigner"/> class.
        /// </summary>
		public OmnoviaHostedArchiveRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is OmnoviaHostedArchiveRepeater))
			{ 
				throw new ArgumentException("Component is not a OmnoviaHostedArchiveRepeater."); 
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
			OmnoviaHostedArchiveRepeater z = (OmnoviaHostedArchiveRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="OmnoviaHostedArchiveRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(OmnoviaHostedArchiveRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:OmnoviaHostedArchiveRepeater runat=\"server\"></{0}:OmnoviaHostedArchiveRepeater>")]
	public class OmnoviaHostedArchiveRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:OmnoviaHostedArchiveRepeater"/> class.
        /// </summary>
		public OmnoviaHostedArchiveRepeater()
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
		[TemplateContainer(typeof(OmnoviaHostedArchiveItem))]
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
		[TemplateContainer(typeof(OmnoviaHostedArchiveItem))]
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
		[TemplateContainer(typeof(OmnoviaHostedArchiveItem))]
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
		[TemplateContainer(typeof(OmnoviaHostedArchiveItem))]
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
					CONFDB.Entities.OmnoviaHostedArchive entity = o as CONFDB.Entities.OmnoviaHostedArchive;
					OmnoviaHostedArchiveItem container = new OmnoviaHostedArchiveItem(entity);

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
	public class OmnoviaHostedArchiveItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.OmnoviaHostedArchive _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OmnoviaHostedArchiveItem"/> class.
        /// </summary>
		public OmnoviaHostedArchiveItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OmnoviaHostedArchiveItem"/> class.
        /// </summary>
		public OmnoviaHostedArchiveItem(CONFDB.Entities.OmnoviaHostedArchive entity)
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
        /// Gets the OmnoviaCustomerId
        /// </summary>
        /// <value>The OmnoviaCustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? OmnoviaCustomerId
		{
			get { return _entity.OmnoviaCustomerId; }
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
        /// Gets the MovieId
        /// </summary>
        /// <value>The MovieId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 MovieId
		{
			get { return _entity.MovieId; }
		}
        /// <summary>
        /// Gets the RoomName
        /// </summary>
        /// <value>The RoomName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RoomName
		{
			get { return _entity.RoomName; }
		}
        /// <summary>
        /// Gets the MovieTitle
        /// </summary>
        /// <value>The MovieTitle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MovieTitle
		{
			get { return _entity.MovieTitle; }
		}
        /// <summary>
        /// Gets the MovieDateAdded
        /// </summary>
        /// <value>The MovieDateAdded.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? MovieDateAdded
		{
			get { return _entity.MovieDateAdded; }
		}
        /// <summary>
        /// Gets the MovieLength
        /// </summary>
        /// <value>The MovieLength.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? MovieLength
		{
			get { return _entity.MovieLength; }
		}
        /// <summary>
        /// Gets the MovieRoomId
        /// </summary>
        /// <value>The MovieRoomId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? MovieRoomId
		{
			get { return _entity.MovieRoomId; }
		}
        /// <summary>
        /// Gets the MovieDate
        /// </summary>
        /// <value>The MovieDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? MovieDate
		{
			get { return _entity.MovieDate; }
		}
        /// <summary>
        /// Gets the CompanyShortLink
        /// </summary>
        /// <value>The CompanyShortLink.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyShortLink
		{
			get { return _entity.CompanyShortLink; }
		}
        /// <summary>
        /// Gets the Created
        /// </summary>
        /// <value>The Created.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? Created
		{
			get { return _entity.Created; }
		}
        /// <summary>
        /// Gets the HostedLinkExpiryDate
        /// </summary>
        /// <value>The HostedLinkExpiryDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime HostedLinkExpiryDate
		{
			get { return _entity.HostedLinkExpiryDate; }
		}
        /// <summary>
        /// Gets the HostedLinkShortened
        /// </summary>
        /// <value>The HostedLinkShortened.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HostedLinkShortened
		{
			get { return _entity.HostedLinkShortened; }
		}
        /// <summary>
        /// Gets the HostedLinkAlias
        /// </summary>
        /// <value>The HostedLinkAlias.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HostedLinkAlias
		{
			get { return _entity.HostedLinkAlias; }
		}
        /// <summary>
        /// Gets the RecordingDirectory
        /// </summary>
        /// <value>The RecordingDirectory.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RecordingDirectory
		{
			get { return _entity.RecordingDirectory; }
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
        /// Gets the HostingPeriod
        /// </summary>
        /// <value>The HostingPeriod.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? HostingPeriod
		{
			get { return _entity.HostingPeriod; }
		}
        /// <summary>
        /// Gets the HostingAutoRenew
        /// </summary>
        /// <value>The HostingAutoRenew.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? HostingAutoRenew
		{
			get { return _entity.HostingAutoRenew; }
		}
        /// <summary>
        /// Gets the Event_Id
        /// </summary>
        /// <value>The Event_Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Event_Id
		{
			get { return _entity.Event_Id; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.OmnoviaHostedArchive"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.OmnoviaHostedArchive Entity
        {
            get { return _entity; }
        }
	}
}
