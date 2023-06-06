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
	/// Represents the DataRepository.ProductRateIntervalProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductRateIntervalDataSourceDesigner))]
	public class ProductRateIntervalDataSource : ProviderDataSource<ProductRateInterval, ProductRateIntervalKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalDataSource class.
		/// </summary>
		public ProductRateIntervalDataSource() : base(new ProductRateIntervalService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductRateIntervalDataSourceView used by the ProductRateIntervalDataSource.
		/// </summary>
		protected ProductRateIntervalDataSourceView ProductRateIntervalView
		{
			get { return ( View as ProductRateIntervalDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductRateIntervalDataSource control invokes to retrieve data.
		/// </summary>
		public ProductRateIntervalSelectMethod SelectMethod
		{
			get
			{
				ProductRateIntervalSelectMethod selectMethod = ProductRateIntervalSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductRateIntervalSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductRateIntervalDataSourceView class that is to be
		/// used by the ProductRateIntervalDataSource.
		/// </summary>
		/// <returns>An instance of the ProductRateIntervalDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductRateInterval, ProductRateIntervalKey> GetNewDataSourceView()
		{
			return new ProductRateIntervalDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductRateIntervalDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductRateIntervalDataSourceView : ProviderDataSourceView<ProductRateInterval, ProductRateIntervalKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductRateIntervalDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductRateIntervalDataSourceView(ProductRateIntervalDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductRateIntervalDataSource ProductRateIntervalOwner
		{
			get { return Owner as ProductRateIntervalDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductRateIntervalSelectMethod SelectMethod
		{
			get { return ProductRateIntervalOwner.SelectMethod; }
			set { ProductRateIntervalOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductRateIntervalService ProductRateIntervalProvider
		{
			get { return Provider as ProductRateIntervalService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductRateInterval> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductRateInterval> results = null;
			ProductRateInterval item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProductRateIntervalSelectMethod.Get:
					ProductRateIntervalKey entityKey  = new ProductRateIntervalKey();
					entityKey.Load(values);
					item = ProductRateIntervalProvider.Get(entityKey);
					results = new TList<ProductRateInterval>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductRateIntervalSelectMethod.GetAll:
                    results = ProductRateIntervalProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductRateIntervalSelectMethod.GetPaged:
					results = ProductRateIntervalProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductRateIntervalSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductRateIntervalProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductRateIntervalProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductRateIntervalSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProductRateIntervalProvider.GetById(_id);
					results = new TList<ProductRateInterval>();
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
			if ( SelectMethod == ProductRateIntervalSelectMethod.Get || SelectMethod == ProductRateIntervalSelectMethod.GetById )
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
				ProductRateInterval entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductRateIntervalProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductRateInterval> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductRateIntervalProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductRateIntervalDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductRateIntervalDataSource class.
	/// </summary>
	public class ProductRateIntervalDataSourceDesigner : ProviderDataSourceDesigner<ProductRateInterval, ProductRateIntervalKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalDataSourceDesigner class.
		/// </summary>
		public ProductRateIntervalDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateIntervalSelectMethod SelectMethod
		{
			get { return ((ProductRateIntervalDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductRateIntervalDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductRateIntervalDataSourceActionList

	/// <summary>
	/// Supports the ProductRateIntervalDataSourceDesigner class.
	/// </summary>
	internal class ProductRateIntervalDataSourceActionList : DesignerActionList
	{
		private ProductRateIntervalDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductRateIntervalDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductRateIntervalDataSourceActionList(ProductRateIntervalDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateIntervalSelectMethod SelectMethod
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

	#endregion ProductRateIntervalDataSourceActionList
	
	#endregion ProductRateIntervalDataSourceDesigner
	
	#region ProductRateIntervalSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductRateIntervalDataSource.SelectMethod property.
	/// </summary>
	public enum ProductRateIntervalSelectMethod
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
	
	#endregion ProductRateIntervalSelectMethod

	#region ProductRateIntervalFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateInterval"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateIntervalFilter : SqlFilter<ProductRateIntervalColumn>
	{
	}
	
	#endregion ProductRateIntervalFilter

	#region ProductRateIntervalExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateInterval"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateIntervalExpressionBuilder : SqlExpressionBuilder<ProductRateIntervalColumn>
	{
	}
	
	#endregion ProductRateIntervalExpressionBuilder	

	#region ProductRateIntervalProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductRateIntervalChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateInterval"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateIntervalProperty : ChildEntityProperty<ProductRateIntervalChildEntityTypes>
	{
	}
	
	#endregion ProductRateIntervalProperty
}

