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
    /// A designer class for a strongly typed repeater <c>WelcomeKitRequestRepeater</c>
    /// </summary>
	public class WelcomeKitRequestRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WelcomeKitRequestRepeaterDesigner"/> class.
        /// </summary>
		public WelcomeKitRequestRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is WelcomeKitRequestRepeater))
			{ 
				throw new ArgumentException("Component is not a WelcomeKitRequestRepeater."); 
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
			WelcomeKitRequestRepeater z = (WelcomeKitRequestRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="WelcomeKitRequestRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(WelcomeKitRequestRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:WelcomeKitRequestRepeater runat=\"server\"></{0}:WelcomeKitRequestRepeater>")]
	public class WelcomeKitRequestRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WelcomeKitRequestRepeater"/> class.
        /// </summary>
		public WelcomeKitRequestRepeater()
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
		[TemplateContainer(typeof(WelcomeKitRequestItem))]
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
		[TemplateContainer(typeof(WelcomeKitRequestItem))]
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
		[TemplateContainer(typeof(WelcomeKitRequestItem))]
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
		[TemplateContainer(typeof(WelcomeKitRequestItem))]
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
					CONFDB.Entities.WelcomeKitRequest entity = o as CONFDB.Entities.WelcomeKitRequest;
					WelcomeKitRequestItem container = new WelcomeKitRequestItem(entity);

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
	public class WelcomeKitRequestItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.WelcomeKitRequest _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WelcomeKitRequestItem"/> class.
        /// </summary>
		public WelcomeKitRequestItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WelcomeKitRequestItem"/> class.
        /// </summary>
		public WelcomeKitRequestItem(CONFDB.Entities.WelcomeKitRequest entity)
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
        /// Gets the ModeratorId
        /// </summary>
        /// <value>The ModeratorId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ModeratorId
		{
			get { return _entity.ModeratorId; }
		}
        /// <summary>
        /// Gets the Notes
        /// </summary>
        /// <value>The Notes.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Notes
		{
			get { return _entity.Notes; }
		}
        /// <summary>
        /// Gets the RequestedBy
        /// </summary>
        /// <value>The RequestedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RequestedBy
		{
			get { return _entity.RequestedBy; }
		}
        /// <summary>
        /// Gets the LastModifiedBy
        /// </summary>
        /// <value>The LastModifiedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastModifiedBy
		{
			get { return _entity.LastModifiedBy; }
		}
        /// <summary>
        /// Gets the LastModified
        /// </summary>
        /// <value>The LastModified.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastModified
		{
			get { return _entity.LastModified; }
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
        /// Gets the RequestProcessed
        /// </summary>
        /// <value>The RequestProcessed.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean RequestProcessed
		{
			get { return _entity.RequestProcessed; }
		}
        /// <summary>
        /// Gets the RequestCompletedDate
        /// </summary>
        /// <value>The RequestCompletedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? RequestCompletedDate
		{
			get { return _entity.RequestCompletedDate; }
		}
        /// <summary>
        /// Gets the RequestCompletedBy
        /// </summary>
        /// <value>The RequestCompletedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RequestCompletedBy
		{
			get { return _entity.RequestCompletedBy; }
		}
        /// <summary>
        /// Gets the BilledDate
        /// </summary>
        /// <value>The BilledDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? BilledDate
		{
			get { return _entity.BilledDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.WelcomeKitRequest"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.WelcomeKitRequest Entity
        {
            get { return _entity; }
        }
	}
}
