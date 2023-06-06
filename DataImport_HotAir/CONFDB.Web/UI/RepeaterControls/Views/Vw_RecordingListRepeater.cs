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
    /// A designer class for a strongly typed repeater <c>Vw_RecordingListRepeater</c>
    /// </summary>
	public class Vw_RecordingListRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_RecordingListRepeaterDesigner"/> class.
        /// </summary>
		public Vw_RecordingListRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is Vw_RecordingListRepeater))
			{ 
				throw new ArgumentException("Component is not a Vw_RecordingListRepeater."); 
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
			Vw_RecordingListRepeater z = (Vw_RecordingListRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="Vw_RecordingListRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(Vw_RecordingListRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:Vw_RecordingListRepeater runat=\"server\"></{0}:Vw_RecordingListRepeater>")]
	public class Vw_RecordingListRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_RecordingListRepeater"/> class.
        /// </summary>
		public Vw_RecordingListRepeater()
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
		[TemplateContainer(typeof(Vw_RecordingListItem))]
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
		[TemplateContainer(typeof(Vw_RecordingListItem))]
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
		[TemplateContainer(typeof(Vw_RecordingListItem))]
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
		[TemplateContainer(typeof(Vw_RecordingListItem))]
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
					CONFDB.Entities.Vw_RecordingList entity = o as CONFDB.Entities.Vw_RecordingList;
					Vw_RecordingListItem container = new Vw_RecordingListItem(entity);

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
	public class Vw_RecordingListItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private CONFDB.Entities.Vw_RecordingList _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_RecordingListItem"/> class.
        /// </summary>
		public Vw_RecordingListItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Vw_RecordingListItem"/> class.
        /// </summary>
		public Vw_RecordingListItem(CONFDB.Entities.Vw_RecordingList entity)
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
        /// Gets the BridgeId
        /// </summary>
        /// <value>The BridgeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? BridgeId
		{
			get { return _entity.BridgeId; }
		}
        /// <summary>
        /// Gets the RecordingStartTime
        /// </summary>
        /// <value>The RecordingStartTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? RecordingStartTime
		{
			get { return _entity.RecordingStartTime; }
		}
        /// <summary>
        /// Gets the RecordingEndTime
        /// </summary>
        /// <value>The RecordingEndTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? RecordingEndTime
		{
			get { return _entity.RecordingEndTime; }
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
        /// Gets the ReplayCode
        /// </summary>
        /// <value>The ReplayCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReplayCode
		{
			get { return _entity.ReplayCode; }
		}
        /// <summary>
        /// Gets the CreatedDate
        /// </summary>
        /// <value>The CreatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedDate
		{
			get { return _entity.CreatedDate; }
		}
        /// <summary>
        /// Gets the ProcessFlag
        /// </summary>
        /// <value>The ProcessFlag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProcessFlag
		{
			get { return _entity.ProcessFlag; }
		}
        /// <summary>
        /// Gets the EmailSent
        /// </summary>
        /// <value>The EmailSent.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? EmailSent
		{
			get { return _entity.EmailSent; }
		}
        /// <summary>
        /// Gets the RpFileNumber
        /// </summary>
        /// <value>The RpFileNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RpFileNumber
		{
			get { return _entity.RpFileNumber; }
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
        /// Gets the Notes
        /// </summary>
        /// <value>The Notes.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Notes
		{
			get { return _entity.Notes; }
		}
        /// <summary>
        /// Gets the Mp3Flag
        /// </summary>
        /// <value>The Mp3Flag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Mp3Flag
		{
			get { return _entity.Mp3Flag; }
		}
        /// <summary>
        /// Gets the Mp3SizeInKb
        /// </summary>
        /// <value>The Mp3SizeInKb.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Mp3SizeInKb
		{
			get { return _entity.Mp3SizeInKb; }
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
        /// Gets the StorageDuration
        /// </summary>
        /// <value>The StorageDuration.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? StorageDuration
		{
			get { return _entity.StorageDuration; }
		}
        /// <summary>
        /// Gets the BillingDuration
        /// </summary>
        /// <value>The BillingDuration.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16? BillingDuration
		{
			get { return _entity.BillingDuration; }
		}
        /// <summary>
        /// Gets the BillingId
        /// </summary>
        /// <value>The BillingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BillingId
		{
			get { return _entity.BillingId; }
		}
        /// <summary>
        /// Gets the DurationSec
        /// </summary>
        /// <value>The DurationSec.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DurationSec
		{
			get { return _entity.DurationSec; }
		}
        /// <summary>
        /// Gets the AuxiliaryConferenceId
        /// </summary>
        /// <value>The AuxiliaryConferenceId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AuxiliaryConferenceId
		{
			get { return _entity.AuxiliaryConferenceId; }
		}
        /// <summary>
        /// Gets the MediaType
        /// </summary>
        /// <value>The MediaType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MediaType
		{
			get { return _entity.MediaType; }
		}
        /// <summary>
        /// Gets the HostedLinkExpiryDate
        /// </summary>
        /// <value>The HostedLinkExpiryDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? HostedLinkExpiryDate
		{
			get { return _entity.HostedLinkExpiryDate; }
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
        /// <summary>
        /// Gets the Username
        /// </summary>
        /// <value>The Username.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Username
		{
			get { return _entity.Username; }
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
        /// Gets the ExtendRecordingDate
        /// </summary>
        /// <value>The ExtendRecordingDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ExtendRecordingDate
		{
			get { return _entity.ExtendRecordingDate; }
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
        /// Gets the HostedLinkType
        /// </summary>
        /// <value>The HostedLinkType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HostedLinkType
		{
			get { return _entity.HostedLinkType; }
		}
        /// <summary>
        /// Gets the HostedLinkUrl
        /// </summary>
        /// <value>The HostedLinkUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HostedLinkUrl
		{
			get { return _entity.HostedLinkUrl; }
		}
        /// <summary>
        /// Gets the RecordingGuid
        /// </summary>
        /// <value>The RecordingGuid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RecordingGuid
		{
			get { return _entity.RecordingGuid; }
		}

	}
}
