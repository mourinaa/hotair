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
    /// A designer class for a strongly typed repeater <c>ModeratorRepeater</c>
    /// </summary>
	public class ModeratorRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ModeratorRepeaterDesigner"/> class.
        /// </summary>
		public ModeratorRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is ModeratorRepeater))
			{ 
				throw new ArgumentException("Component is not a ModeratorRepeater."); 
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
			ModeratorRepeater z = (ModeratorRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="ModeratorRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(ModeratorRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:ModeratorRepeater runat=\"server\"></{0}:ModeratorRepeater>")]
	public class ModeratorRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ModeratorRepeater"/> class.
        /// </summary>
		public ModeratorRepeater()
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
		[TemplateContainer(typeof(ModeratorItem))]
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
		[TemplateContainer(typeof(ModeratorItem))]
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
		[TemplateContainer(typeof(ModeratorItem))]
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
		[TemplateContainer(typeof(ModeratorItem))]
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
					CONFDB.Entities.Moderator entity = o as CONFDB.Entities.Moderator;
					ModeratorItem container = new ModeratorItem(entity);

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
	public class ModeratorItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Moderator _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModeratorItem"/> class.
        /// </summary>
		public ModeratorItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModeratorItem"/> class.
        /// </summary>
		public ModeratorItem(CONFDB.Entities.Moderator entity)
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
        /// Gets the Description
        /// </summary>
        /// <value>The Description.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Description
		{
			get { return _entity.Description; }
		}
        /// <summary>
        /// Gets the DepartmentId
        /// </summary>
        /// <value>The DepartmentId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DepartmentId
		{
			get { return _entity.DepartmentId; }
		}
        /// <summary>
        /// Gets the ModifiedBy
        /// </summary>
        /// <value>The ModifiedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ModifiedBy
		{
			get { return _entity.ModifiedBy; }
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
        /// Gets the LastModified
        /// </summary>
        /// <value>The LastModified.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastModified
		{
			get { return _entity.LastModified; }
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
        /// Gets the UniqueModeratorId
        /// </summary>
        /// <value>The UniqueModeratorId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid UniqueModeratorId
		{
			get { return _entity.UniqueModeratorId; }
		}
        /// <summary>
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UserId
		{
			get { return _entity.UserId; }
		}
        /// <summary>
        /// Gets the WebMeetingId
        /// </summary>
        /// <value>The WebMeetingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebMeetingId
		{
			get { return _entity.WebMeetingId; }
		}
        /// <summary>
        /// Gets the Omnovia_Room_Id
        /// </summary>
        /// <value>The Omnovia_Room_Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Omnovia_Room_Id
		{
			get { return _entity.Omnovia_Room_Id; }
		}
        /// <summary>
        /// Gets the Seevogh_Meeting_Url
        /// </summary>
        /// <value>The Seevogh_Meeting_Url.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Seevogh_Meeting_Url
		{
			get { return _entity.Seevogh_Meeting_Url; }
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
        /// Gets a <see cref="T:CONFDB.Entities.Moderator"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.Moderator Entity
        {
            get { return _entity; }
        }
	}
}
