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
	/// Represents the DataRepository.CustomerTransactionImportProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerTransactionImportDataSourceDesigner))]
	public class CustomerTransactionImportDataSource : ProviderDataSource<CustomerTransactionImport, CustomerTransactionImportKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportDataSource class.
		/// </summary>
		public CustomerTransactionImportDataSource() : base(new CustomerTransactionImportService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerTransactionImportDataSourceView used by the CustomerTransactionImportDataSource.
		/// </summary>
		protected CustomerTransactionImportDataSourceView CustomerTransactionImportView
		{
			get { return ( View as CustomerTransactionImportDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerTransactionImportDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerTransactionImportSelectMethod SelectMethod
		{
			get
			{
				CustomerTransactionImportSelectMethod selectMethod = CustomerTransactionImportSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerTransactionImportSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerTransactionImportDataSourceView class that is to be
		/// used by the CustomerTransactionImportDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerTransactionImportDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerTransactionImport, CustomerTransactionImportKey> GetNewDataSourceView()
		{
			return new CustomerTransactionImportDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerTransactionImportDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerTransactionImportDataSourceView : ProviderDataSourceView<CustomerTransactionImport, CustomerTransactionImportKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerTransactionImportDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerTransactionImportDataSourceView(CustomerTransactionImportDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerTransactionImportDataSource CustomerTransactionImportOwner
		{
			get { return Owner as CustomerTransactionImportDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerTransactionImportSelectMethod SelectMethod
		{
			get { return CustomerTransactionImportOwner.SelectMethod; }
			set { CustomerTransactionImportOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerTransactionImportService CustomerTransactionImportProvider
		{
			get { return Provider as CustomerTransactionImportService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerTransactionImport> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerTransactionImport> results = null;
			CustomerTransactionImport item;
			count = 0;
			
			System.Int64 _id;

			switch ( SelectMethod )
			{
				case CustomerTransactionImportSelectMethod.Get:
					CustomerTransactionImportKey entityKey  = new CustomerTransactionImportKey();
					entityKey.Load(values);
					item = CustomerTransactionImportProvider.Get(entityKey);
					results = new TList<CustomerTransactionImport>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerTransactionImportSelectMethod.GetAll:
                    results = CustomerTransactionImportProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerTransactionImportSelectMethod.GetPaged:
					results = CustomerTransactionImportProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerTransactionImportSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerTransactionImportProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerTransactionImportProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerTransactionImportSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = CustomerTransactionImportProvider.GetById(_id);
					results = new TList<CustomerTransactionImport>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
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
			if ( SelectMethod == CustomerTransactionImportSelectMethod.Get || SelectMethod == CustomerTransactionImportSelectMethod.GetById )
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
				CustomerTransactionImport entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerTransactionImportProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerTransactionImport> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerTransactionImportProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerTransactionImportDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerTransactionImportDataSource class.
	/// </summary>
	public class CustomerTransactionImportDataSourceDesigner : ProviderDataSourceDesigner<CustomerTransactionImport, CustomerTransactionImportKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportDataSourceDesigner class.
		/// </summary>
		public CustomerTransactionImportDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerTransactionImportSelectMethod SelectMethod
		{
			get { return ((CustomerTransactionImportDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerTransactionImportDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerTransactionImportDataSourceActionList

	/// <summary>
	/// Supports the CustomerTransactionImportDataSourceDesigner class.
	/// </summary>
	internal class CustomerTransactionImportDataSourceActionList : DesignerActionList
	{
		private CustomerTransactionImportDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerTransactionImportDataSourceActionList(CustomerTransactionImportDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerTransactionImportSelectMethod SelectMethod
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

	#endregion CustomerTransactionImportDataSourceActionList
	
	#endregion CustomerTransactionImportDataSourceDesigner
	
	#region CustomerTransactionImportSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerTransactionImportDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerTransactionImportSelectMethod
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
		GetById
	}
	
	#endregion CustomerTransactionImportSelectMethod

	#region CustomerTransactionImportFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportFilter : SqlFilter<CustomerTransactionImportColumn>
	{
	}
	
	#endregion CustomerTransactionImportFilter

	#region CustomerTransactionImportExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportExpressionBuilder : SqlExpressionBuilder<CustomerTransactionImportColumn>
	{
	}
	
	#endregion CustomerTransactionImportExpressionBuilder	

	#region CustomerTransactionImportProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerTransactionImportChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportProperty : ChildEntityProperty<CustomerTransactionImportChildEntityTypes>
	{
	}
	
	#endregion CustomerTransactionImportProperty
}

