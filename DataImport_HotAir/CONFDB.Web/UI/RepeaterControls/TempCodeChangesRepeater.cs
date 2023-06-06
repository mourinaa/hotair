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
    /// A designer class for a strongly typed repeater <c>TempCodeChangesRepeater</c>
    /// </summary>
	public class TempCodeChangesRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TempCodeChangesRepeaterDesigner"/> class.
        /// </summary>
		public TempCodeChangesRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TempCodeChangesRepeater))
			{ 
				throw new ArgumentException("Component is not a TempCodeChangesRepeater."); 
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
			TempCodeChangesRepeater z = (TempCodeChangesRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="TempCodeChangesRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TempCodeChangesRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TempCodeChangesRepeater runat=\"server\"></{0}:TempCodeChangesRepeater>")]
	public class TempCodeChangesRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TempCodeChangesRepeater"/> class.
        /// </summary>
		public TempCodeChangesRepeater()
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
		[TemplateContainer(typeof(TempCodeChangesItem))]
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
		[TemplateContainer(typeof(TempCodeChangesItem))]
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
		[TemplateContainer(typeof(TempCodeChangesItem))]
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
		[TemplateContainer(typeof(TempCodeChangesItem))]
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
					CONFDB.Entities.TempCodeChanges entity = o as CONFDB.Entities.TempCodeChanges;
					TempCodeChangesItem container = new TempCodeChangesItem(entity);

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
	public class TempCodeChangesItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.TempCodeChanges _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TempCodeChangesItem"/> class.
        /// </summary>
		public TempCodeChangesItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TempCodeChangesItem"/> class.
        /// </summary>
		public TempCodeChangesItem(CONFDB.Entities.TempCodeChanges entity)
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
        /// Gets the OrigModCode
        /// </summary>
        /// <value>The OrigModCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String OrigModCode
		{
			get { return _entity.OrigModCode; }
		}
        /// <summary>
        /// Gets the OrigPassCode
        /// </summary>
        /// <value>The OrigPassCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String OrigPassCode
		{
			get { return _entity.OrigPassCode; }
		}
        /// <summary>
        /// Gets the ExpectedOrigModCode
        /// </summary>
        /// <value>The ExpectedOrigModCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExpectedOrigModCode
		{
			get { return _entity.ExpectedOrigModCode; }
		}
        /// <summary>
        /// Gets the ExpectedOrigPassCode
        /// </summary>
        /// <value>The ExpectedOrigPassCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExpectedOrigPassCode
		{
			get { return _entity.ExpectedOrigPassCode; }
		}
        /// <summary>
        /// Gets the NewModCode
        /// </summary>
        /// <value>The NewModCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String NewModCode
		{
			get { return _entity.NewModCode; }
		}
        /// <summary>
        /// Gets the NewPassCode
        /// </summary>
        /// <value>The NewPassCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String NewPassCode
		{
			get { return _entity.NewPassCode; }
		}
        /// <summary>
        /// Gets the AppliedDate
        /// </summary>
        /// <value>The AppliedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime AppliedDate
		{
			get { return _entity.AppliedDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:CONFDB.Entities.TempCodeChanges"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public CONFDB.Entities.TempCodeChanges Entity
        {
            get { return _entity; }
        }
	}
}
