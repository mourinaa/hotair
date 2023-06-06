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
	/// Represents the DataRepository.Customer_FeatureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Customer_FeatureDataSourceDesigner))]
	public class Customer_FeatureDataSource : ProviderDataSource<Customer_Feature, Customer_FeatureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureDataSource class.
		/// </summary>
		public Customer_FeatureDataSource() : base(new Customer_FeatureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Customer_FeatureDataSourceView used by the Customer_FeatureDataSource.
		/// </summary>
		protected Customer_FeatureDataSourceView Customer_FeatureView
		{
			get { return ( View as Customer_FeatureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Customer_FeatureDataSource control invokes to retrieve data.
		/// </summary>
		public Customer_FeatureSelectMethod SelectMethod
		{
			get
			{
				Customer_FeatureSelectMethod selectMethod = Customer_FeatureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Customer_FeatureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Customer_FeatureDataSourceView class that is to be
		/// used by the Customer_FeatureDataSource.
		/// </summary>
		/// <returns>An instance of the Customer_FeatureDataSourceView class.</returns>
		protected override BaseDataSourceView<Customer_Feature, Customer_FeatureKey> GetNewDataSourceView()
		{
			return new Customer_FeatureDataSourceView(this, DefaultViewName);
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
	/// Supports the Customer_FeatureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Customer_FeatureDataSourceView : ProviderDataSourceView<Customer_Feature, Customer_FeatureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Customer_FeatureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Customer_FeatureDataSourceView(Customer_FeatureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Customer_FeatureDataSource Customer_FeatureOwner
		{
			get { return Owner as Customer_FeatureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Customer_FeatureSelectMethod SelectMethod
		{
			get { return Customer_FeatureOwner.SelectMethod; }
			set { Customer_FeatureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Customer_FeatureService Customer_FeatureProvider
		{
			get { return Provider as Customer_FeatureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Customer_Feature> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Customer_Feature> results = null;
			Customer_Feature item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _featureId;
			System.Int32 _customerId;
			System.Int32 _featureOptionId;

			switch ( SelectMethod )
			{
				case Customer_FeatureSelectMethod.Get:
					Customer_FeatureKey entityKey  = new Customer_FeatureKey();
					entityKey.Load(values);
					item = Customer_FeatureProvider.Get(entityKey);
					results = new TList<Customer_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Customer_FeatureSelectMethod.GetAll:
                    results = Customer_FeatureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Customer_FeatureSelectMethod.GetPaged:
					results = Customer_FeatureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Customer_FeatureSelectMethod.Find:
					if ( FilterParameters != null )
						results = Customer_FeatureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Customer_FeatureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Customer_FeatureSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = Customer_FeatureProvider.GetById(_id);
					results = new TList<Customer_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case Customer_FeatureSelectMethod.GetByFeatureIdCustomerIdFeatureOptionId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_featureOptionId = ( values["FeatureOptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureOptionId"], typeof(System.Int32)) : (int)0;
					results = Customer_FeatureProvider.GetByFeatureIdCustomerIdFeatureOptionId(_featureId, _customerId, _featureOptionId, this.StartIndex, this.PageSize, out count);
					break;
				case Customer_FeatureSelectMethod.GetByCustomerIdFeatureId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					results = Customer_FeatureProvider.GetByCustomerIdFeatureId(_customerId, _featureId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case Customer_FeatureSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = Customer_FeatureProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case Customer_FeatureSelectMethod.GetByFeatureId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					results = Customer_FeatureProvider.GetByFeatureId(_featureId, this.StartIndex, this.PageSize, out count);
					break;
				case Customer_FeatureSelectMethod.GetByFeatureOptionId:
					_featureOptionId = ( values["FeatureOptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureOptionId"], typeof(System.Int32)) : (int)0;
					results = Customer_FeatureProvider.GetByFeatureOptionId(_featureOptionId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == Customer_FeatureSelectMethod.Get || SelectMethod == Customer_FeatureSelectMethod.GetById )
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
				Customer_Feature entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Customer_FeatureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Customer_Feature> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Customer_FeatureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Customer_FeatureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Customer_FeatureDataSource class.
	/// </summary>
	public class Customer_FeatureDataSourceDesigner : ProviderDataSourceDesigner<Customer_Feature, Customer_FeatureKey>
	{
		/// <summary>
		/// Initializes a new instance of the Customer_FeatureDataSourceDesigner class.
		/// </summary>
		public Customer_FeatureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Customer_FeatureSelectMethod SelectMethod
		{
			get { return ((Customer_FeatureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Customer_FeatureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Customer_FeatureDataSourceActionList

	/// <summary>
	/// Supports the Customer_FeatureDataSourceDesigner class.
	/// </summary>
	internal class Customer_FeatureDataSourceActionList : DesignerActionList
	{
		private Customer_FeatureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Customer_FeatureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Customer_FeatureDataSourceActionList(Customer_FeatureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Customer_FeatureSelectMethod SelectMethod
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

	#endregion Customer_FeatureDataSourceActionList
	
	#endregion Customer_FeatureDataSourceDesigner
	
	#region Customer_FeatureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Customer_FeatureDataSource.SelectMethod property.
	/// </summary>
	public enum Customer_FeatureSelectMethod
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
		/// Represents the GetByFeatureIdCustomerIdFeatureOptionId method.
		/// </summary>
		GetByFeatureIdCustomerIdFeatureOptionId,
		/// <summary>
		/// Represents the GetByCustomerIdFeatureId method.
		/// </summary>
		GetByCustomerIdFeatureId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByFeatureId method.
		/// </summary>
		GetByFeatureId,
		/// <summary>
		/// Represents the GetByFeatureOptionId method.
		/// </summary>
		GetByFeatureOptionId
	}
	
	#endregion Customer_FeatureSelectMethod

	#region Customer_FeatureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_FeatureFilter : SqlFilter<Customer_FeatureColumn>
	{
	}
	
	#endregion Customer_FeatureFilter

	#region Customer_FeatureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_FeatureExpressionBuilder : SqlExpressionBuilder<Customer_FeatureColumn>
	{
	}
	
	#endregion Customer_FeatureExpressionBuilder	

	#region Customer_FeatureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Customer_FeatureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_FeatureProperty : ChildEntityProperty<Customer_FeatureChildEntityTypes>
	{
	}
	
	#endregion Customer_FeatureProperty
}

