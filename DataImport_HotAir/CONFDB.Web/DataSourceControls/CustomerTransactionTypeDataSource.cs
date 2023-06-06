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
	/// Represents the DataRepository.CustomerTransactionTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerTransactionTypeDataSourceDesigner))]
	public class CustomerTransactionTypeDataSource : ProviderDataSource<CustomerTransactionType, CustomerTransactionTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeDataSource class.
		/// </summary>
		public CustomerTransactionTypeDataSource() : base(new CustomerTransactionTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerTransactionTypeDataSourceView used by the CustomerTransactionTypeDataSource.
		/// </summary>
		protected CustomerTransactionTypeDataSourceView CustomerTransactionTypeView
		{
			get { return ( View as CustomerTransactionTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerTransactionTypeDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerTransactionTypeSelectMethod SelectMethod
		{
			get
			{
				CustomerTransactionTypeSelectMethod selectMethod = CustomerTransactionTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerTransactionTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerTransactionTypeDataSourceView class that is to be
		/// used by the CustomerTransactionTypeDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerTransactionTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerTransactionType, CustomerTransactionTypeKey> GetNewDataSourceView()
		{
			return new CustomerTransactionTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerTransactionTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerTransactionTypeDataSourceView : ProviderDataSourceView<CustomerTransactionType, CustomerTransactionTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerTransactionTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerTransactionTypeDataSourceView(CustomerTransactionTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerTransactionTypeDataSource CustomerTransactionTypeOwner
		{
			get { return Owner as CustomerTransactionTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerTransactionTypeSelectMethod SelectMethod
		{
			get { return CustomerTransactionTypeOwner.SelectMethod; }
			set { CustomerTransactionTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerTransactionTypeService CustomerTransactionTypeProvider
		{
			get { return Provider as CustomerTransactionTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerTransactionType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerTransactionType> results = null;
			CustomerTransactionType item;
			count = 0;
			
			System.Int32 _id;
			System.String _name_nullable;
			System.Int32? _actionValue_nullable;
			System.Int32? _glPostingTypeId_nullable;

			switch ( SelectMethod )
			{
				case CustomerTransactionTypeSelectMethod.Get:
					CustomerTransactionTypeKey entityKey  = new CustomerTransactionTypeKey();
					entityKey.Load(values);
					item = CustomerTransactionTypeProvider.Get(entityKey);
					results = new TList<CustomerTransactionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerTransactionTypeSelectMethod.GetAll:
                    results = CustomerTransactionTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerTransactionTypeSelectMethod.GetPaged:
					results = CustomerTransactionTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerTransactionTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerTransactionTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerTransactionTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerTransactionTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CustomerTransactionTypeProvider.GetById(_id);
					results = new TList<CustomerTransactionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CustomerTransactionTypeSelectMethod.GetByName:
					_name_nullable = (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String));
					results = CustomerTransactionTypeProvider.GetByName(_name_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerTransactionTypeSelectMethod.GetByActionValue:
					_actionValue_nullable = (System.Int32?) EntityUtil.ChangeType(values["ActionValue"], typeof(System.Int32?));
					results = CustomerTransactionTypeProvider.GetByActionValue(_actionValue_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case CustomerTransactionTypeSelectMethod.GetByGlPostingTypeId:
					_glPostingTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["GlPostingTypeId"], typeof(System.Int32?));
					results = CustomerTransactionTypeProvider.GetByGlPostingTypeId(_glPostingTypeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerTransactionTypeSelectMethod.Get || SelectMethod == CustomerTransactionTypeSelectMethod.GetById )
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
				CustomerTransactionType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerTransactionTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerTransactionType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerTransactionTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerTransactionTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerTransactionTypeDataSource class.
	/// </summary>
	public class CustomerTransactionTypeDataSourceDesigner : ProviderDataSourceDesigner<CustomerTransactionType, CustomerTransactionTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeDataSourceDesigner class.
		/// </summary>
		public CustomerTransactionTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerTransactionTypeSelectMethod SelectMethod
		{
			get { return ((CustomerTransactionTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerTransactionTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerTransactionTypeDataSourceActionList

	/// <summary>
	/// Supports the CustomerTransactionTypeDataSourceDesigner class.
	/// </summary>
	internal class CustomerTransactionTypeDataSourceActionList : DesignerActionList
	{
		private CustomerTransactionTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerTransactionTypeDataSourceActionList(CustomerTransactionTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerTransactionTypeSelectMethod SelectMethod
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

	#endregion CustomerTransactionTypeDataSourceActionList
	
	#endregion CustomerTransactionTypeDataSourceDesigner
	
	#region CustomerTransactionTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerTransactionTypeDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerTransactionTypeSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByActionValue method.
		/// </summary>
		GetByActionValue,
		/// <summary>
		/// Represents the GetByGlPostingTypeId method.
		/// </summary>
		GetByGlPostingTypeId
	}
	
	#endregion CustomerTransactionTypeSelectMethod

	#region CustomerTransactionTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeFilter : SqlFilter<CustomerTransactionTypeColumn>
	{
	}
	
	#endregion CustomerTransactionTypeFilter

	#region CustomerTransactionTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeExpressionBuilder : SqlExpressionBuilder<CustomerTransactionTypeColumn>
	{
	}
	
	#endregion CustomerTransactionTypeExpressionBuilder	

	#region CustomerTransactionTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerTransactionTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeProperty : ChildEntityProperty<CustomerTransactionTypeChildEntityTypes>
	{
	}
	
	#endregion CustomerTransactionTypeProperty
}

