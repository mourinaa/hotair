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
	/// Represents the DataRepository.EmailTemplateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmailTemplateDataSourceDesigner))]
	public class EmailTemplateDataSource : ProviderDataSource<EmailTemplate, EmailTemplateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateDataSource class.
		/// </summary>
		public EmailTemplateDataSource() : base(new EmailTemplateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmailTemplateDataSourceView used by the EmailTemplateDataSource.
		/// </summary>
		protected EmailTemplateDataSourceView EmailTemplateView
		{
			get { return ( View as EmailTemplateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmailTemplateDataSource control invokes to retrieve data.
		/// </summary>
		public EmailTemplateSelectMethod SelectMethod
		{
			get
			{
				EmailTemplateSelectMethod selectMethod = EmailTemplateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmailTemplateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmailTemplateDataSourceView class that is to be
		/// used by the EmailTemplateDataSource.
		/// </summary>
		/// <returns>An instance of the EmailTemplateDataSourceView class.</returns>
		protected override BaseDataSourceView<EmailTemplate, EmailTemplateKey> GetNewDataSourceView()
		{
			return new EmailTemplateDataSourceView(this, DefaultViewName);
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
	/// Supports the EmailTemplateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmailTemplateDataSourceView : ProviderDataSourceView<EmailTemplate, EmailTemplateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmailTemplateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmailTemplateDataSourceView(EmailTemplateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmailTemplateDataSource EmailTemplateOwner
		{
			get { return Owner as EmailTemplateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmailTemplateSelectMethod SelectMethod
		{
			get { return EmailTemplateOwner.SelectMethod; }
			set { EmailTemplateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmailTemplateService EmailTemplateProvider
		{
			get { return Provider as EmailTemplateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmailTemplate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmailTemplate> results = null;
			EmailTemplate item;
			count = 0;
			
			System.Int32 _id;
			System.String _wholesalerId;
			System.String _templateName;
			System.String _priCustomerNumber_nullable;
			System.Int32? _callFlowId_nullable;
			System.String _languageId;

			switch ( SelectMethod )
			{
				case EmailTemplateSelectMethod.Get:
					EmailTemplateKey entityKey  = new EmailTemplateKey();
					entityKey.Load(values);
					item = EmailTemplateProvider.Get(entityKey);
					results = new TList<EmailTemplate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmailTemplateSelectMethod.GetAll:
                    results = EmailTemplateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmailTemplateSelectMethod.GetPaged:
					results = EmailTemplateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmailTemplateSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmailTemplateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmailTemplateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmailTemplateSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = EmailTemplateProvider.GetById(_id);
					results = new TList<EmailTemplate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmailTemplateSelectMethod.GetByWholesalerIdTemplateNamePriCustomerNumber:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_templateName = ( values["TemplateName"] != null ) ? (System.String) EntityUtil.ChangeType(values["TemplateName"], typeof(System.String)) : string.Empty;
					_priCustomerNumber_nullable = (System.String) EntityUtil.ChangeType(values["PriCustomerNumber"], typeof(System.String));
					item = EmailTemplateProvider.GetByWholesalerIdTemplateNamePriCustomerNumber(_wholesalerId, _templateName, _priCustomerNumber_nullable);
					results = new TList<EmailTemplate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmailTemplateSelectMethod.GetByWholesalerIdTemplateName:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_templateName = ( values["TemplateName"] != null ) ? (System.String) EntityUtil.ChangeType(values["TemplateName"], typeof(System.String)) : string.Empty;
					results = EmailTemplateProvider.GetByWholesalerIdTemplateName(_wholesalerId, _templateName, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case EmailTemplateSelectMethod.GetByCallFlowId:
					_callFlowId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CallFlowId"], typeof(System.Int32?));
					results = EmailTemplateProvider.GetByCallFlowId(_callFlowId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmailTemplateSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = EmailTemplateProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case EmailTemplateSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["LanguageId"], typeof(System.String)) : string.Empty;
					results = EmailTemplateProvider.GetByLanguageId(_languageId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == EmailTemplateSelectMethod.Get || SelectMethod == EmailTemplateSelectMethod.GetById )
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
				EmailTemplate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmailTemplateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmailTemplate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmailTemplateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmailTemplateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmailTemplateDataSource class.
	/// </summary>
	public class EmailTemplateDataSourceDesigner : ProviderDataSourceDesigner<EmailTemplate, EmailTemplateKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmailTemplateDataSourceDesigner class.
		/// </summary>
		public EmailTemplateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailTemplateSelectMethod SelectMethod
		{
			get { return ((EmailTemplateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmailTemplateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmailTemplateDataSourceActionList

	/// <summary>
	/// Supports the EmailTemplateDataSourceDesigner class.
	/// </summary>
	internal class EmailTemplateDataSourceActionList : DesignerActionList
	{
		private EmailTemplateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmailTemplateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmailTemplateDataSourceActionList(EmailTemplateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailTemplateSelectMethod SelectMethod
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

	#endregion EmailTemplateDataSourceActionList
	
	#endregion EmailTemplateDataSourceDesigner
	
	#region EmailTemplateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmailTemplateDataSource.SelectMethod property.
	/// </summary>
	public enum EmailTemplateSelectMethod
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
		/// Represents the GetByWholesalerIdTemplateNamePriCustomerNumber method.
		/// </summary>
		GetByWholesalerIdTemplateNamePriCustomerNumber,
		/// <summary>
		/// Represents the GetByWholesalerIdTemplateName method.
		/// </summary>
		GetByWholesalerIdTemplateName,
		/// <summary>
		/// Represents the GetByCallFlowId method.
		/// </summary>
		GetByCallFlowId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId
	}
	
	#endregion EmailTemplateSelectMethod

	#region EmailTemplateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateFilter : SqlFilter<EmailTemplateColumn>
	{
	}
	
	#endregion EmailTemplateFilter

	#region EmailTemplateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateExpressionBuilder : SqlExpressionBuilder<EmailTemplateColumn>
	{
	}
	
	#endregion EmailTemplateExpressionBuilder	

	#region EmailTemplateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmailTemplateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateProperty : ChildEntityProperty<EmailTemplateChildEntityTypes>
	{
	}
	
	#endregion EmailTemplateProperty
}

