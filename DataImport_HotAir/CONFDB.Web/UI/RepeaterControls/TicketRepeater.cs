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
    /// A designer class for a strongly typed repeater <c>TicketRepeater</c>
    /// </summary>
	public class TicketRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TicketRepeaterDesigner"/> class.
        /// </summary>
		public TicketRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TicketRepeater))
			{ 
				throw new ArgumentException("Component is not a TicketRepeater."); 
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
			TicketRepeater z = (TicketRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="TicketRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TicketRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TicketRepeater runat=\"server\"></{0}:TicketRepeater>")]
	public class TicketRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TicketRepeater"/> class.
        /// </summary>
		public TicketRepeater()
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
		[TemplateContainer(typeof(TicketItem))]
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
		[TemplateContainer(typeof(TicketItem))]
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
		[TemplateContainer(typeof(TicketItem))]
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
		[TemplateContainer(typeof(TicketItem))]
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
					CONFDB.Entities.Ticket entity = o as CONFDB.Entities.Ticket;
					TicketItem container = new TicketItem(entity);

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
	public class TicketItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Ticket _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TicketItem"/> class.
        /// </summary>
		public TicketItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TicketItem"/> class.
        /// </summary>
		public TicketItem(CONFDB.Entities.Ticket entity)
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
        /// Gets the Title
        /// </summary>
        /// <value>The Title.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Title
		{
			get { return _entity.Title; }
		}
        /// <summary>
        /// Gets the IssueDescription
        /// </summary>
        /// <value>The IssueDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String IssueDescription
		{
			get { return _entity.IssueDescription; }
		}
        /// <summary>
        /// Gets the ClientContactInfo
        /// </summary>
        /// <value>The ClientContactInfo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ClientContactInfo
		{
			get { return _entity.ClientContactInfo; }
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
        /// Gets the ModeratorId
        /// </summary>
        /// <value>The ModeratorId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ModeratorId
		{
			get { return _entity.ModeratorId; }
		}
        /// <summary>
        /// Gets the StatusId
        /// </summary>
        /// <value>The StatusId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 StatusId
		{
			get { return _entity.StatusId; }
		}
        /// <summary>
        /// Gets the ResolutionText
        /// </summary>
        /// <value>The ResolutionText.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ResolutionText
		{
			get { return _entity.ResolutionText; }
		}
        /// <summary>
        /// Gets the TicketPriorityId
        /// </summary>
        /// <value>The TicketPriorityId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 TicketPriorityId
		{
			get { return _entity.TicketPriorityId; }
		}
        /// <summary>
        /// Gets the CreatedByUserId
        /// </summary>
        /// <value>The CreatedByUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CreatedByUserId
		{
			get { return _entity.CreatedByUserId; }
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
        /// Gets the AssignedToUserId
        /// </summary>
        /// <value>The AssignedToUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AssignedToUserId
		{
			get { return _entity.AssignedToUserId; }
		}
        /// <summary>
        /// Gets the AssignedDate
        /// </summary>
        /// <value>The AssignedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime AssignedDate
		{
			get { return _entity.AssignedDate; }
		}
        /// <summary>
        /// Gets the FixedByUserId
        /// </summary>
        /// <value>The FixedByUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FixedByUserId
		{
			get { return _entity.FixedByUserId; }
		}
        /// <summary>
        /// Gets the FixedDate
        /// </summary>
        /// <value>The FixedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime FixedDate
		{
			get { return _entity.FixedDate; }
		}
        /// <summary>
        /// Gets the ClosedByUserId
        /// </summary>
        /// <value>The ClosedByUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ClosedByUserId
		{
			get { return _entity.ClosedByUserId; }
		}
        /// <summary>
        /// Gets the ClosedDate
        /// </summary>
        /// <value>The ClosedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime ClosedDate
		{
			get { return _entity.ClosedDate; }
		}
        /// <summary>
        /// Gets the TicketProductId
        /// </summary>
        /// <value>The TicketProductId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 TicketProductId
		{
			get { return _entity.TicketProductId; }
		}
        /// <summary>
        /// Gets the TicketCategoryId
        /// </summary>
        /// <value>The TicketCategoryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 TicketCategoryId
		{
			get { return _entity.TicketCategoryId; }
		}
        /// <summary>
        /// Gets the DuplicateTicketId
        /// </summary>
        /// <value>The DuplicateTicketId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DuplicateTicketId
		{
			get { return _entity.DuplicateTicketId; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.Ticket"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.Ticket Entity
        {
            get { return _entity; }
        }
	}
}
