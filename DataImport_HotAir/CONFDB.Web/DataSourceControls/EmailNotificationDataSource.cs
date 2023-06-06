#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using CONFDB.Entities;
using CONFDB.Data;
using CONFDB.Data.Bases;
using CONFDB.Services;
#endregion

namespace CONFDB.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.EmailNotificationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmailNotificationDataSourceDesigner))]
	public class EmailNotificationDataSource : ProviderDataSource<EmailNotification, EmailNotificationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationDataSource class.
		/// </summary>
		public EmailNotificationDataSource() : base(new EmailNotificationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmailNotificationDataSourceView used by the EmailNotificationDataSource.
		/// </summary>
		protected EmailNotificationDataSourceView EmailNotificationView
		{
			get { return ( View as EmailNotificationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmailNotificationDataSource control invokes to retrieve data.
		/// </summary>
		public EmailNotificationSelectMethod SelectMethod
		{
			get
			{
				EmailNotificationSelectMethod selectMethod = EmailNotificationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmailNotificationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmailNotificationDataSourceView class that is to be
		/// used by the EmailNotificationDataSource.
		/// </summary>
		/// <returns>An instance of the EmailNotificationDataSourceView class.</returns>
		protected override BaseDataSourceView<EmailNotification, EmailNotificationKey> GetNewDataSourceView()
		{
			return new EmailNotificationDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the EmailNotificationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmailNotificationDataSourceView : ProviderDataSourceView<EmailNotification, EmailNotificationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmailNotificationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmailNotificationDataSourceView(EmailNotificationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmailNotificationDataSource EmailNotificationOwner
		{
			get { return Owner as EmailNotificationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmailNotificationSelectMethod SelectMethod
		{
			get { return EmailNotificationOwner.SelectMethod; }
			set { EmailNotificationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmailNotificationService EmailNotificationProvider
		{
			get { return Provider as EmailNotificationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmailNotification> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmailNotification> results = null;
			EmailNotification item;
			count = 0;
			
			System.Int32 _id;
			System.String _email_nullable;
			System.Boolean _emailSent;
			System.DateTime? _sentDate_nullable;
			System.String _templateName;
			System.DateTime _createdDate;

			switch ( SelectMethod )
			{
				case EmailNotificationSelectMethod.Get:
					EmailNotificationKey entityKey  = new EmailNotificationKey();
					entityKey.Load(values);
					item = EmailNotificationProvider.Get(entityKey);
					results = new TList<EmailNotification>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmailNotificationSelectMethod.GetAll:
                    results = EmailNotificationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmailNotificationSelectMethod.GetPaged:
					results = EmailNotificationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmailNotificationSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmailNotificationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmailNotificationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmailNotificationSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = EmailNotificationProvider.GetById(_id);
					results = new TList<EmailNotification>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmailNotificationSelectMethod.GetByEmail:
					_email_nullable = (System.String) EntityUtil.ChangeType(values["Email"], typeof(System.String));
					results = EmailNotificationProvider.GetByEmail(_email_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmailNotificationSelectMethod.GetByEmailSent:
					_emailSent = ( values["EmailSent"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["EmailSent"], typeof(System.Boolean)) : false;
					results = EmailNotificationProvider.GetByEmailSent(_emailSent, this.StartIndex, this.PageSize, out count);
					break;
				case EmailNotificationSelectMethod.GetBySentDate:
					_sentDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["SentDate"], typeof(System.DateTime?));
					results = EmailNotificationProvider.GetBySentDate(_sentDate_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmailNotificationSelectMethod.GetByTemplateNameCreatedDate:
					_templateName = ( values["TemplateName"] != null ) ? (System.String) EntityUtil.ChangeType(values["TemplateName"], typeof(System.String)) : string.Empty;
					_createdDate = ( values["CreatedDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["CreatedDate"], typeof(System.DateTime)) : DateTime.Now;
					results = EmailNotificationProvider.GetByTemplateNameCreatedDate(_templateName, _createdDate, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == EmailNotificationSelectMethod.Get || SelectMethod == EmailNotificationSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				EmailNotification entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmailNotificationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<EmailNotification> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmailNotificationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmailNotificationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmailNotificationDataSource class.
	/// </summary>
	public class EmailNotificationDataSourceDesigner : ProviderDataSourceDesigner<EmailNotification, EmailNotificationKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmailNotificationDataSourceDesigner class.
		/// </summary>
		public EmailNotificationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailNotificationSelectMethod SelectMethod
		{
			get { return ((EmailNotificationDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new EmailNotificationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmailNotificationDataSourceActionList

	/// <summary>
	/// Supports the EmailNotificationDataSourceDesigner class.
	/// </summary>
	internal class EmailNotificationDataSourceActionList : DesignerActionList
	{
		private EmailNotificationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmailNotificationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmailNotificationDataSourceActionList(EmailNotificationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailNotificationSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion EmailNotificationDataSourceActionList
	
	#endregion EmailNotificationDataSourceDesigner
	
	#region EmailNotificationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmailNotificationDataSource.SelectMethod property.
	/// </summary>
	public enum EmailNotificationSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByEmail method.
		/// </summary>
		GetByEmail,
		/// <summary>
		/// Represents the GetByEmailSent method.
		/// </summary>
		GetByEmailSent,
		/// <summary>
		/// Represents the GetBySentDate method.
		/// </summary>
		GetBySentDate,
		/// <summary>
		/// Represents the GetByTemplateNameCreatedDate method.
		/// </summary>
		GetByTemplateNameCreatedDate
	}
	
	#endregion EmailNotificationSelectMethod

	#region EmailNotificationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationFilter : SqlFilter<EmailNotificationColumn>
	{
	}
	
	#endregion EmailNotificationFilter

	#region EmailNotificationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationExpressionBuilder : SqlExpressionBuilder<EmailNotificationColumn>
	{
	}
	
	#endregion EmailNotificationExpressionBuilder	

	#region EmailNotificationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmailNotificationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationProperty : ChildEntityProperty<EmailNotificationChildEntityTypes>
	{
	}
	
	#endregion EmailNotificationProperty
}

