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
    /// A designer class for a strongly typed repeater <c>RecordingParticipantUsageRepeater</c>
    /// </summary>
	public class RecordingParticipantUsageRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:RecordingParticipantUsageRepeaterDesigner"/> class.
        /// </summary>
		public RecordingParticipantUsageRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is RecordingParticipantUsageRepeater))
			{ 
				throw new ArgumentException("Component is not a RecordingParticipantUsageRepeater."); 
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
			RecordingParticipantUsageRepeater z = (RecordingParticipantUsageRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="RecordingParticipantUsageRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(RecordingParticipantUsageRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:RecordingParticipantUsageRepeater runat=\"server\"></{0}:RecordingParticipantUsageRepeater>")]
	public class RecordingParticipantUsageRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:RecordingParticipantUsageRepeater"/> class.
        /// </summary>
		public RecordingParticipantUsageRepeater()
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
		[TemplateContainer(typeof(RecordingParticipantUsageItem))]
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
		[TemplateContainer(typeof(RecordingParticipantUsageItem))]
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
		[TemplateContainer(typeof(RecordingParticipantUsageItem))]
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
		[TemplateContainer(typeof(RecordingParticipantUsageItem))]
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
					CONFDB.Entities.RecordingParticipantUsage entity = o as CONFDB.Entities.RecordingParticipantUsage;
					RecordingParticipantUsageItem container = new RecordingParticipantUsageItem(entity);

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
	public class RecordingParticipantUsageItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.RecordingParticipantUsage _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RecordingParticipantUsageItem"/> class.
        /// </summary>
		public RecordingParticipantUsageItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RecordingParticipantUsageItem"/> class.
        /// </summary>
		public RecordingParticipantUsageItem(CONFDB.Entities.RecordingParticipantUsage entity)
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
        /// Gets the RecordingId
        /// </summary>
        /// <value>The RecordingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 RecordingId
		{
			get { return _entity.RecordingId; }
		}
        /// <summary>
        /// Gets the ParticipantName
        /// </summary>
        /// <value>The ParticipantName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ParticipantName
		{
			get { return _entity.ParticipantName; }
		}
        /// <summary>
        /// Gets the ParticipantCompanyName
        /// </summary>
        /// <value>The ParticipantCompanyName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ParticipantCompanyName
		{
			get { return _entity.ParticipantCompanyName; }
		}
        /// <summary>
        /// Gets the ParticipantEmail
        /// </summary>
        /// <value>The ParticipantEmail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ParticipantEmail
		{
			get { return _entity.ParticipantEmail; }
		}
        /// <summary>
        /// Gets the DownloadDate
        /// </summary>
        /// <value>The DownloadDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime DownloadDate
		{
			get { return _entity.DownloadDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.RecordingParticipantUsage"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.RecordingParticipantUsage Entity
        {
            get { return _entity; }
        }
	}
}
