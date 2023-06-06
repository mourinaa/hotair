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
	/// Represents the DataRepository.CustomerDocumentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerDocumentDataSourceDesigner))]
	public class CustomerDocumentDataSource : ProviderDataSource<CustomerDocument, CustomerDocumentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentDataSource class.
		/// </summary>
		public CustomerDocumentDataSource() : base(new CustomerDocumentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerDocumentDataSourceView used by the CustomerDocumentDataSource.
		/// </summary>
		protected CustomerDocumentDataSourceView CustomerDocumentView
		{
			get { return ( View as CustomerDocumentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerDocumentDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerDocumentSelectMethod SelectMethod
		{
			get
			{
				CustomerDocumentSelectMethod selectMethod = CustomerDocumentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerDocumentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerDocumentDataSourceView class that is to be
		/// used by the CustomerDocumentDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerDocumentDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerDocument, CustomerDocumentKey> GetNewDataSourceView()
		{
			return new CustomerDocumentDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerDocumentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerDocumentDataSourceView : ProviderDataSourceView<CustomerDocument, CustomerDocumentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerDocumentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerDocumentDataSourceView(CustomerDocumentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerDocumentDataSource CustomerDocumentOwner
		{
			get { return Owner as CustomerDocumentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerDocumentSelectMethod SelectMethod
		{
			get { return CustomerDocumentOwner.SelectMethod; }
			set { CustomerDocumentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerDocumentService CustomerDocumentProvider
		{
			get { return Provider as CustomerDocumentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerDocument> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerDocument> results = null;
			CustomerDocument item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;
			System.String _wholesalerId_nullable;
			System.Int32 _documentTypeId;
			System.String _languageId_nullable;

			switch ( SelectMethod )
			{
				case CustomerDocumentSelectMethod.Get:
					CustomerDocumentKey entityKey  = new CustomerDocumentKey();
					entityKey.Load(values);
					item = CustomerDocumentProvider.Get(entityKey);
					results = new TList<CustomerDocument>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerDocumentSelectMethod.GetAll:
                    results = CustomerDocumentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerDocumentSelectMethod.GetPaged:
					results = CustomerDocumentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerDocumentSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerDocumentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerDocumentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerDocumentSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CustomerDocumentProvider.GetById(_id);
					results = new TList<CustomerDocument>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomerDocumentSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = CustomerDocumentProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerDocumentSelectMethod.GetByWholesalerId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = CustomerDocumentProvider.GetByWholesalerId(_wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerDocumentSelectMethod.GetByDocumentTypeId:
					_documentTypeId = ( values["DocumentTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DocumentTypeId"], typeof(System.Int32)) : (int)0;
					results = CustomerDocumentProvider.GetByDocumentTypeId(_documentTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerDocumentSelectMethod.GetByLanguageId:
					_languageId_nullable = (System.String) EntityUtil.ChangeType(values["LanguageId"], typeof(System.String));
					results = CustomerDocumentProvider.GetByLanguageId(_languageId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerDocumentSelectMethod.Get || SelectMethod == CustomerDocumentSelectMethod.GetById )
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
				CustomerDocument entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerDocumentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerDocument> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerDocumentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerDocumentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerDocumentDataSource class.
	/// </summary>
	public class CustomerDocumentDataSourceDesigner : ProviderDataSourceDesigner<CustomerDocument, CustomerDocumentKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerDocumentDataSourceDesigner class.
		/// </summary>
		public CustomerDocumentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerDocumentSelectMethod SelectMethod
		{
			get { return ((CustomerDocumentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerDocumentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerDocumentDataSourceActionList

	/// <summary>
	/// Supports the CustomerDocumentDataSourceDesigner class.
	/// </summary>
	internal class CustomerDocumentDataSourceActionList : DesignerActionList
	{
		private CustomerDocumentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerDocumentDataSourceActionList(CustomerDocumentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerDocumentSelectMethod SelectMethod
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

	#endregion CustomerDocumentDataSourceActionList
	
	#endregion CustomerDocumentDataSourceDesigner
	
	#region CustomerDocumentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerDocumentDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerDocumentSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByDocumentTypeId method.
		/// </summary>
		GetByDocumentTypeId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId
	}
	
	#endregion CustomerDocumentSelectMethod

	#region CustomerDocumentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentFilter : SqlFilter<CustomerDocumentColumn>
	{
	}
	
	#endregion CustomerDocumentFilter

	#region CustomerDocumentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentExpressionBuilder : SqlExpressionBuilder<CustomerDocumentColumn>
	{
	}
	
	#endregion CustomerDocumentExpressionBuilder	

	#region CustomerDocumentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerDocumentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentProperty : ChildEntityProperty<CustomerDocumentChildEntityTypes>
	{
	}
	
	#endregion CustomerDocumentProperty
}

