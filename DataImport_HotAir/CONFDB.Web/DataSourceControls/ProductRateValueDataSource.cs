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
	/// Represents the DataRepository.ProductRateValueProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductRateValueDataSourceDesigner))]
	public class ProductRateValueDataSource : ProviderDataSource<ProductRateValue, ProductRateValueKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueDataSource class.
		/// </summary>
		public ProductRateValueDataSource() : base(new ProductRateValueService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductRateValueDataSourceView used by the ProductRateValueDataSource.
		/// </summary>
		protected ProductRateValueDataSourceView ProductRateValueView
		{
			get { return ( View as ProductRateValueDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductRateValueDataSource control invokes to retrieve data.
		/// </summary>
		public ProductRateValueSelectMethod SelectMethod
		{
			get
			{
				ProductRateValueSelectMethod selectMethod = ProductRateValueSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductRateValueSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductRateValueDataSourceView class that is to be
		/// used by the ProductRateValueDataSource.
		/// </summary>
		/// <returns>An instance of the ProductRateValueDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductRateValue, ProductRateValueKey> GetNewDataSourceView()
		{
			return new ProductRateValueDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductRateValueDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductRateValueDataSourceView : ProviderDataSourceView<ProductRateValue, ProductRateValueKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductRateValueDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductRateValueDataSourceView(ProductRateValueDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductRateValueDataSource ProductRateValueOwner
		{
			get { return Owner as ProductRateValueDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductRateValueSelectMethod SelectMethod
		{
			get { return ProductRateValueOwner.SelectMethod; }
			set { ProductRateValueOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductRateValueService ProductRateValueProvider
		{
			get { return Provider as ProductRateValueService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductRateValue> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductRateValue> results = null;
			ProductRateValue item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _customerId_nullable;
			System.Int32 _productRateId;
			System.Byte _defaultOption;
			System.String _wholesalerId_nullable;
			System.Decimal _sellRate;
			System.String _sellRateCurrencyId;
			System.String _buyRateCurrencyId;

			switch ( SelectMethod )
			{
				case ProductRateValueSelectMethod.Get:
					ProductRateValueKey entityKey  = new ProductRateValueKey();
					entityKey.Load(values);
					item = ProductRateValueProvider.Get(entityKey);
					results = new TList<ProductRateValue>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductRateValueSelectMethod.GetAll:
                    results = ProductRateValueProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductRateValueSelectMethod.GetPaged:
					results = ProductRateValueProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductRateValueSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductRateValueProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductRateValueProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductRateValueSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProductRateValueProvider.GetById(_id);
					results = new TList<ProductRateValue>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductRateValueSelectMethod.GetByCustomerIdProductRateId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					results = ProductRateValueProvider.GetByCustomerIdProductRateId(_customerId_nullable, _productRateId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByProductRateIdDefaultOption:
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					_defaultOption = ( values["DefaultOption"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["DefaultOption"], typeof(System.Byte)) : (byte)0;
					results = ProductRateValueProvider.GetByProductRateIdDefaultOption(_productRateId, _defaultOption, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByWholesalerId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = ProductRateValueProvider.GetByWholesalerId(_wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByIdProductRateIdSellRateSellRateCurrencyId:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					_sellRate = ( values["SellRate"] != null ) ? (System.Decimal) EntityUtil.ChangeType(values["SellRate"], typeof(System.Decimal)) : 0.0m;
					_sellRateCurrencyId = ( values["SellRateCurrencyId"] != null ) ? (System.String) EntityUtil.ChangeType(values["SellRateCurrencyId"], typeof(System.String)) : string.Empty;
					results = ProductRateValueProvider.GetByIdProductRateIdSellRateSellRateCurrencyId(_id, _productRateId, _sellRate, _sellRateCurrencyId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId:
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					_defaultOption = ( values["DefaultOption"] != null ) ? (System.Byte) EntityUtil.ChangeType(values["DefaultOption"], typeof(System.Byte)) : (byte)0;
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					_sellRateCurrencyId = ( values["SellRateCurrencyId"] != null ) ? (System.String) EntityUtil.ChangeType(values["SellRateCurrencyId"], typeof(System.String)) : string.Empty;
					item = ProductRateValueProvider.GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(_productRateId, _defaultOption, _wholesalerId_nullable, _customerId_nullable, _sellRateCurrencyId);
					results = new TList<ProductRateValue>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case ProductRateValueSelectMethod.GetByCustomerId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					results = ProductRateValueProvider.GetByCustomerId(_customerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByBuyRateCurrencyId:
					_buyRateCurrencyId = ( values["BuyRateCurrencyId"] != null ) ? (System.String) EntityUtil.ChangeType(values["BuyRateCurrencyId"], typeof(System.String)) : string.Empty;
					results = ProductRateValueProvider.GetByBuyRateCurrencyId(_buyRateCurrencyId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetBySellRateCurrencyId:
					_sellRateCurrencyId = ( values["SellRateCurrencyId"] != null ) ? (System.String) EntityUtil.ChangeType(values["SellRateCurrencyId"], typeof(System.String)) : string.Empty;
					results = ProductRateValueProvider.GetBySellRateCurrencyId(_sellRateCurrencyId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateValueSelectMethod.GetByProductRateId:
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					results = ProductRateValueProvider.GetByProductRateId(_productRateId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductRateValueSelectMethod.Get || SelectMethod == ProductRateValueSelectMethod.GetById )
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
				ProductRateValue entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductRateValueProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductRateValue> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductRateValueProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductRateValueDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductRateValueDataSource class.
	/// </summary>
	public class ProductRateValueDataSourceDesigner : ProviderDataSourceDesigner<ProductRateValue, ProductRateValueKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductRateValueDataSourceDesigner class.
		/// </summary>
		public ProductRateValueDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateValueSelectMethod SelectMethod
		{
			get { return ((ProductRateValueDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductRateValueDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductRateValueDataSourceActionList

	/// <summary>
	/// Supports the ProductRateValueDataSourceDesigner class.
	/// </summary>
	internal class ProductRateValueDataSourceActionList : DesignerActionList
	{
		private ProductRateValueDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductRateValueDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductRateValueDataSourceActionList(ProductRateValueDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateValueSelectMethod SelectMethod
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

	#endregion ProductRateValueDataSourceActionList
	
	#endregion ProductRateValueDataSourceDesigner
	
	#region ProductRateValueSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductRateValueDataSource.SelectMethod property.
	/// </summary>
	public enum ProductRateValueSelectMethod
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
		/// Represents the GetByCustomerIdProductRateId method.
		/// </summary>
		GetByCustomerIdProductRateId,
		/// <summary>
		/// Represents the GetByProductRateIdDefaultOption method.
		/// </summary>
		GetByProductRateIdDefaultOption,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByIdProductRateIdSellRateSellRateCurrencyId method.
		/// </summary>
		GetByIdProductRateIdSellRateSellRateCurrencyId,
		/// <summary>
		/// Represents the GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId method.
		/// </summary>
		GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByBuyRateCurrencyId method.
		/// </summary>
		GetByBuyRateCurrencyId,
		/// <summary>
		/// Represents the GetBySellRateCurrencyId method.
		/// </summary>
		GetBySellRateCurrencyId,
		/// <summary>
		/// Represents the GetByProductRateId method.
		/// </summary>
		GetByProductRateId
	}
	
	#endregion ProductRateValueSelectMethod

	#region ProductRateValueFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueFilter : SqlFilter<ProductRateValueColumn>
	{
	}
	
	#endregion ProductRateValueFilter

	#region ProductRateValueExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueExpressionBuilder : SqlExpressionBuilder<ProductRateValueColumn>
	{
	}
	
	#endregion ProductRateValueExpressionBuilder	

	#region ProductRateValueProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductRateValueChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueProperty : ChildEntityProperty<ProductRateValueChildEntityTypes>
	{
	}
	
	#endregion ProductRateValueProperty
}

