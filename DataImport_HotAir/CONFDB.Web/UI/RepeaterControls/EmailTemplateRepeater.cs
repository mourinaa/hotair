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
    /// A designer class for a strongly typed repeater <c>EmailTemplateRepeater</c>
    /// </summary>
	public class EmailTemplateRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplateRepeaterDesigner"/> class.
        /// </summary>
		public EmailTemplateRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is EmailTemplateRepeater))
			{ 
				throw new ArgumentException("Component is not a EmailTemplateRepeater."); 
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
			EmailTemplateRepeater z = (EmailTemplateRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="EmailTemplateRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(EmailTemplateRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:EmailTemplateRepeater runat=\"server\"></{0}:EmailTemplateRepeater>")]
	public class EmailTemplateRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplateRepeater"/> class.
        /// </summary>
		public EmailTemplateRepeater()
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
		[TemplateContainer(typeof(EmailTemplateItem))]
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
		[TemplateContainer(typeof(EmailTemplateItem))]
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
		[TemplateContainer(typeof(EmailTemplateItem))]
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
		[TemplateContainer(typeof(EmailTemplateItem))]
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
					CONFDB.Entities.EmailTemplate entity = o as CONFDB.Entities.EmailTemplate;
					EmailTemplateItem container = new EmailTemplateItem(entity);

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
	public class EmailTemplateItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.EmailTemplate _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplateItem"/> class.
        /// </summary>
		public EmailTemplateItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplateItem"/> class.
        /// </summary>
		public EmailTemplateItem(CONFDB.Entities.EmailTemplate entity)
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
        /// Gets the SmtpServer
        /// </summary>
        /// <value>The SmtpServer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SmtpServer
		{
			get { return _entity.SmtpServer; }
		}
        /// <summary>
        /// Gets the SmtpUserName
        /// </summary>
        /// <value>The SmtpUserName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SmtpUserName
		{
			get { return _entity.SmtpUserName; }
		}
        /// <summary>
        /// Gets the SmtpPassword
        /// </summary>
        /// <value>The SmtpPassword.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SmtpPassword
		{
			get { return _entity.SmtpPassword; }
		}
        /// <summary>
        /// Gets the BaseFileDirectory
        /// </summary>
        /// <value>The BaseFileDirectory.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BaseFileDirectory
		{
			get { return _entity.BaseFileDirectory; }
		}
        /// <summary>
        /// Gets the TemplateName
        /// </summary>
        /// <value>The TemplateName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TemplateName
		{
			get { return _entity.TemplateName; }
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
        /// Gets the FileName
        /// </summary>
        /// <value>The FileName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FileName
		{
			get { return _entity.FileName; }
		}
        /// <summary>
        /// Gets the Subject
        /// </summary>
        /// <value>The Subject.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Subject
		{
			get { return _entity.Subject; }
		}
        /// <summary>
        /// Gets the Sender
        /// </summary>
        /// <value>The Sender.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Sender
		{
			get { return _entity.Sender; }
		}
        /// <summary>
        /// Gets the BccList
        /// </summary>
        /// <value>The BccList.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BccList
		{
			get { return _entity.BccList; }
		}
        /// <summary>
        /// Gets the CcList
        /// </summary>
        /// <value>The CcList.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CcList
		{
			get { return _entity.CcList; }
		}
        /// <summary>
        /// Gets the SendToContact
        /// </summary>
        /// <value>The SendToContact.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean SendToContact
		{
			get { return _entity.SendToContact; }
		}
        /// <summary>
        /// Gets the SendToModerator
        /// </summary>
        /// <value>The SendToModerator.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean SendToModerator
		{
			get { return _entity.SendToModerator; }
		}
        /// <summary>
        /// Gets the IncludeAttachment
        /// </summary>
        /// <value>The IncludeAttachment.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean IncludeAttachment
		{
			get { return _entity.IncludeAttachment; }
		}
        /// <summary>
        /// Gets the AttachmentFileName
        /// </summary>
        /// <value>The AttachmentFileName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AttachmentFileName
		{
			get { return _entity.AttachmentFileName; }
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
        /// Gets the EmailTemplateContentTypeId
        /// </summary>
        /// <value>The EmailTemplateContentTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailTemplateContentTypeId
		{
			get { return _entity.EmailTemplateContentTypeId; }
		}
        /// <summary>
        /// Gets the EmailTemplateGroupId
        /// </summary>
        /// <value>The EmailTemplateGroupId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailTemplateGroupId
		{
			get { return _entity.EmailTemplateGroupId; }
		}
        /// <summary>
        /// Gets the CallFlowId
        /// </summary>
        /// <value>The CallFlowId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CallFlowId
		{
			get { return _entity.CallFlowId; }
		}
        /// <summary>
        /// Gets the LanguageId
        /// </summary>
        /// <value>The LanguageId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LanguageId
		{
			get { return _entity.LanguageId; }
		}
        /// <summary>
        /// Gets the Enabled
        /// </summary>
        /// <value>The Enabled.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Enabled
		{
			get { return _entity.Enabled; }
		}
        /// <summary>
        /// Gets the DisplayOrder
        /// </summary>
        /// <value>The DisplayOrder.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DisplayOrder
		{
			get { return _entity.DisplayOrder; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.EmailTemplate"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.EmailTemplate Entity
        {
            get { return _entity; }
        }
	}
}
