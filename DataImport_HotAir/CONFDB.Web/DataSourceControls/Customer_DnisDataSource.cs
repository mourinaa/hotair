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
	/// Represents the DataRepository.Customer_DnisProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Customer_DnisDataSourceDesigner))]
	public class Customer_DnisDataSource : ProviderDataSource<Customer_Dnis, Customer_DnisKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisDataSource class.
		/// </summary>
		public Customer_DnisDataSource() : base(new Customer_DnisService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Customer_DnisDataSourceView used by the Customer_DnisDataSource.
		/// </summary>
		protected Customer_DnisDataSourceView Customer_DnisView
		{
			get { return ( View as Customer_DnisDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Customer_DnisDataSource control invokes to retrieve data.
		/// </summary>
		public Customer_DnisSelectMethod SelectMethod
		{
			get
			{
				Customer_DnisSelectMethod selectMethod = Customer_DnisSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Customer_DnisSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Customer_DnisDataSourceView class that is to be
		/// used by the Customer_DnisDataSource.
		/// </summary>
		/// <returns>An instance of the Customer_DnisDataSourceView class.</returns>
		protected override BaseDataSourceView<Customer_Dnis, Customer_DnisKey> GetNewDataSourceView()
		{
			return new Customer_DnisDataSourceView(this, DefaultViewName);
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
	/// Supports the Customer_DnisDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Customer_DnisDataSourceView : ProviderDataSourceView<Customer_Dnis, Customer_DnisKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Customer_DnisDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Customer_DnisDataSourceView(Customer_DnisDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Customer_DnisDataSource Customer_DnisOwner
		{
			get { return Owner as Customer_DnisDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Customer_DnisSelectMethod SelectMethod
		{
			get { return Customer_DnisOwner.SelectMethod; }
			set { Customer_DnisOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Customer_DnisService Customer_DnisProvider
		{
			get { return Provider as Customer_DnisService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Customer_Dnis> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Customer_Dnis> results = null;
			Customer_Dnis item;
			count = 0;
			
			System.Int32 _dnisid;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case Customer_DnisSelectMethod.Get:
					Customer_DnisKey entityKey  = new Customer_DnisKey();
					entityKey.Load(values);
					item = Customer_DnisProvider.Get(entityKey);
					results = new TList<Customer_Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Customer_DnisSelectMethod.GetAll:
                    results = Customer_DnisProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Customer_DnisSelectMethod.GetPaged:
					results = Customer_DnisProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Customer_DnisSelectMethod.Find:
					if ( FilterParameters != null )
						results = Customer_DnisProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Customer_DnisProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Customer_DnisSelectMethod.GetByDnisidCustomerId:
					_dnisid = ( values["Dnisid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Dnisid"], typeof(System.Int32)) : (int)0;
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = Customer_DnisProvider.GetByDnisidCustomerId(_dnisid, _customerId);
					results = new TList<Customer_Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case Customer_DnisSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = Customer_DnisProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case Customer_DnisSelectMethod.GetByDnisid:
					_dnisid = ( values["Dnisid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Dnisid"], typeof(System.Int32)) : (int)0;
					results = Customer_DnisProvider.GetByDnisid(_dnisid, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == Customer_DnisSelectMethod.Get || SelectMethod == Customer_DnisSelectMethod.GetByDnisidCustomerId )
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
				Customer_Dnis entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Customer_DnisProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Customer_Dnis> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Customer_DnisProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Customer_DnisDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Customer_DnisDataSource class.
	/// </summary>
	public class Customer_DnisDataSourceDesigner : ProviderDataSourceDesigner<Customer_Dnis, Customer_DnisKey>
	{
		/// <summary>
		/// Initializes a new instance of the Customer_DnisDataSourceDesigner class.
		/// </summary>
		public Customer_DnisDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Customer_DnisSelectMethod SelectMethod
		{
			get { return ((Customer_DnisDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Customer_DnisDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Customer_DnisDataSourceActionList

	/// <summary>
	/// Supports the Customer_DnisDataSourceDesigner class.
	/// </summary>
	internal class Customer_DnisDataSourceActionList : DesignerActionList
	{
		private Customer_DnisDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Customer_DnisDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Customer_DnisDataSourceActionList(Customer_DnisDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Customer_DnisSelectMethod SelectMethod
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

	#endregion Customer_DnisDataSourceActionList
	
	#endregion Customer_DnisDataSourceDesigner
	
	#region Customer_DnisSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Customer_DnisDataSource.SelectMethod property.
	/// </summary>
	public enum Customer_DnisSelectMethod
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
		/// Represents the GetByDnisidCustomerId method.
		/// </summary>
		GetByDnisidCustomerId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByDnisid method.
		/// </summary>
		GetByDnisid
	}
	
	#endregion Customer_DnisSelectMethod

	#region Customer_DnisFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisFilter : SqlFilter<Customer_DnisColumn>
	{
	}
	
	#endregion Customer_DnisFilter

	#region Customer_DnisExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisExpressionBuilder : SqlExpressionBuilder<Customer_DnisColumn>
	{
	}
	
	#endregion Customer_DnisExpressionBuilder	

	#region Customer_DnisProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Customer_DnisChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisProperty : ChildEntityProperty<Customer_DnisChildEntityTypes>
	{
	}
	
	#endregion Customer_DnisProperty
}

