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
	/// Represents the DataRepository.ProductRateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductRateDataSourceDesigner))]
	public class ProductRateDataSource : ProviderDataSource<ProductRate, ProductRateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateDataSource class.
		/// </summary>
		public ProductRateDataSource() : base(new ProductRateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductRateDataSourceView used by the ProductRateDataSource.
		/// </summary>
		protected ProductRateDataSourceView ProductRateView
		{
			get { return ( View as ProductRateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductRateDataSource control invokes to retrieve data.
		/// </summary>
		public ProductRateSelectMethod SelectMethod
		{
			get
			{
				ProductRateSelectMethod selectMethod = ProductRateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductRateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductRateDataSourceView class that is to be
		/// used by the ProductRateDataSource.
		/// </summary>
		/// <returns>An instance of the ProductRateDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductRate, ProductRateKey> GetNewDataSourceView()
		{
			return new ProductRateDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductRateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductRateDataSourceView : ProviderDataSourceView<ProductRate, ProductRateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductRateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductRateDataSourceView(ProductRateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductRateDataSource ProductRateOwner
		{
			get { return Owner as ProductRateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductRateSelectMethod SelectMethod
		{
			get { return ProductRateOwner.SelectMethod; }
			set { ProductRateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductRateService ProductRateProvider
		{
			get { return Provider as ProductRateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductRate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductRate> results = null;
			ProductRate item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _productId;
			System.Int32 _productRateTypeId;
			System.String _name_nullable;
			System.String _countryId_nullable;
			System.Int32 _ratingTypeId;
			System.Int32 _productRateIntervalId;
			System.Int32 _taxableId;

			switch ( SelectMethod )
			{
				case ProductRateSelectMethod.Get:
					ProductRateKey entityKey  = new ProductRateKey();
					entityKey.Load(values);
					item = ProductRateProvider.Get(entityKey);
					results = new TList<ProductRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductRateSelectMethod.GetAll:
                    results = ProductRateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductRateSelectMethod.GetPaged:
					results = ProductRateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductRateSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductRateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductRateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductRateSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProductRateProvider.GetById(_id);
					results = new TList<ProductRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductRateSelectMethod.GetByProductIdProductRateTypeId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_productRateTypeId = ( values["ProductRateTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateTypeId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByProductIdProductRateTypeId(_productId, _productRateTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByNameProductId:
					_name_nullable = (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String));
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					item = ProductRateProvider.GetByNameProductId(_name_nullable, _productId);
					results = new TList<ProductRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case ProductRateSelectMethod.GetByCountryId:
					_countryId_nullable = (System.String) EntityUtil.ChangeType(values["CountryId"], typeof(System.String));
					results = ProductRateProvider.GetByCountryId(_countryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByRatingTypeId:
					_ratingTypeId = ( values["RatingTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RatingTypeId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByRatingTypeId(_ratingTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByProductRateIntervalId:
					_productRateIntervalId = ( values["ProductRateIntervalId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateIntervalId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByProductRateIntervalId(_productRateIntervalId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByProductRateTypeId:
					_productRateTypeId = ( values["ProductRateTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateTypeId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByProductRateTypeId(_productRateTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case ProductRateSelectMethod.GetByTaxableId:
					_taxableId = ( values["TaxableId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TaxableId"], typeof(System.Int32)) : (int)0;
					results = ProductRateProvider.GetByTaxableId(_taxableId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProductRateSelectMethod.Get || SelectMethod == ProductRateSelectMethod.GetById )
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
				ProductRate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductRateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductRate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductRateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductRateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductRateDataSource class.
	/// </summary>
	public class ProductRateDataSourceDesigner : ProviderDataSourceDesigner<ProductRate, ProductRateKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductRateDataSourceDesigner class.
		/// </summary>
		public ProductRateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateSelectMethod SelectMethod
		{
			get { return ((ProductRateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductRateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductRateDataSourceActionList

	/// <summary>
	/// Supports the ProductRateDataSourceDesigner class.
	/// </summary>
	internal class ProductRateDataSourceActionList : DesignerActionList
	{
		private ProductRateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductRateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductRateDataSourceActionList(ProductRateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateSelectMethod SelectMethod
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

	#endregion ProductRateDataSourceActionList
	
	#endregion ProductRateDataSourceDesigner
	
	#region ProductRateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductRateDataSource.SelectMethod property.
	/// </summary>
	public enum ProductRateSelectMethod
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
		/// Represents the GetByProductIdProductRateTypeId method.
		/// </summary>
		GetByProductIdProductRateTypeId,
		/// <summary>
		/// Represents the GetByNameProductId method.
		/// </summary>
		GetByNameProductId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId,
		/// <summary>
		/// Represents the GetByRatingTypeId method.
		/// </summary>
		GetByRatingTypeId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByProductRateIntervalId method.
		/// </summary>
		GetByProductRateIntervalId,
		/// <summary>
		/// Represents the GetByProductRateTypeId method.
		/// </summary>
		GetByProductRateTypeId,
		/// <summary>
		/// Represents the GetByTaxableId method.
		/// </summary>
		GetByTaxableId
	}
	
	#endregion ProductRateSelectMethod

	#region ProductRateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateFilter : SqlFilter<ProductRateColumn>
	{
	}
	
	#endregion ProductRateFilter

	#region ProductRateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateExpressionBuilder : SqlExpressionBuilder<ProductRateColumn>
	{
	}
	
	#endregion ProductRateExpressionBuilder	

	#region ProductRateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductRateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateProperty : ChildEntityProperty<ProductRateChildEntityTypes>
	{
	}
	
	#endregion ProductRateProperty
}

