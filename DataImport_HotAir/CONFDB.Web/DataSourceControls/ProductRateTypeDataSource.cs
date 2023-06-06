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
	/// Represents the DataRepository.ProductRateTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductRateTypeDataSourceDesigner))]
	public class ProductRateTypeDataSource : ProviderDataSource<ProductRateType, ProductRateTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeDataSource class.
		/// </summary>
		public ProductRateTypeDataSource() : base(new ProductRateTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductRateTypeDataSourceView used by the ProductRateTypeDataSource.
		/// </summary>
		protected ProductRateTypeDataSourceView ProductRateTypeView
		{
			get { return ( View as ProductRateTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductRateTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ProductRateTypeSelectMethod SelectMethod
		{
			get
			{
				ProductRateTypeSelectMethod selectMethod = ProductRateTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductRateTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductRateTypeDataSourceView class that is to be
		/// used by the ProductRateTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ProductRateTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductRateType, ProductRateTypeKey> GetNewDataSourceView()
		{
			return new ProductRateTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductRateTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductRateTypeDataSourceView : ProviderDataSourceView<ProductRateType, ProductRateTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductRateTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductRateTypeDataSourceView(ProductRateTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductRateTypeDataSource ProductRateTypeOwner
		{
			get { return Owner as ProductRateTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductRateTypeSelectMethod SelectMethod
		{
			get { return ProductRateTypeOwner.SelectMethod; }
			set { ProductRateTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductRateTypeService ProductRateTypeProvider
		{
			get { return Provider as ProductRateTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductRateType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductRateType> results = null;
			ProductRateType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProductRateTypeSelectMethod.Get:
					ProductRateTypeKey entityKey  = new ProductRateTypeKey();
					entityKey.Load(values);
					item = ProductRateTypeProvider.Get(entityKey);
					results = new TList<ProductRateType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductRateTypeSelectMethod.GetAll:
                    results = ProductRateTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductRateTypeSelectMethod.GetPaged:
					results = ProductRateTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductRateTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductRateTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductRateTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductRateTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProductRateTypeProvider.GetById(_id);
					results = new TList<ProductRateType>();
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
			if ( SelectMethod == ProductRateTypeSelectMethod.Get || SelectMethod == ProductRateTypeSelectMethod.GetById )
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
				ProductRateType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductRateTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductRateType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductRateTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductRateTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductRateTypeDataSource class.
	/// </summary>
	public class ProductRateTypeDataSourceDesigner : ProviderDataSourceDesigner<ProductRateType, ProductRateTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductRateTypeDataSourceDesigner class.
		/// </summary>
		public ProductRateTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateTypeSelectMethod SelectMethod
		{
			get { return ((ProductRateTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductRateTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductRateTypeDataSourceActionList

	/// <summary>
	/// Supports the ProductRateTypeDataSourceDesigner class.
	/// </summary>
	internal class ProductRateTypeDataSourceActionList : DesignerActionList
	{
		private ProductRateTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductRateTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductRateTypeDataSourceActionList(ProductRateTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductRateTypeSelectMethod SelectMethod
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

	#endregion ProductRateTypeDataSourceActionList
	
	#endregion ProductRateTypeDataSourceDesigner
	
	#region ProductRateTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductRateTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ProductRateTypeSelectMethod
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
	
	#endregion ProductRateTypeSelectMethod

	#region ProductRateTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateTypeFilter : SqlFilter<ProductRateTypeColumn>
	{
	}
	
	#endregion ProductRateTypeFilter

	#region ProductRateTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateTypeExpressionBuilder : SqlExpressionBuilder<ProductRateTypeColumn>
	{
	}
	
	#endregion ProductRateTypeExpressionBuilder	

	#region ProductRateTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductRateTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateTypeProperty : ChildEntityProperty<ProductRateTypeChildEntityTypes>
	{
	}
	
	#endregion ProductRateTypeProperty
}

