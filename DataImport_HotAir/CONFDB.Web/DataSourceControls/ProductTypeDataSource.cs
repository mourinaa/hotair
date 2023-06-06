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
	/// Represents the DataRepository.ProductTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProductTypeDataSourceDesigner))]
	public class ProductTypeDataSource : ProviderDataSource<ProductType, ProductTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeDataSource class.
		/// </summary>
		public ProductTypeDataSource() : base(new ProductTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProductTypeDataSourceView used by the ProductTypeDataSource.
		/// </summary>
		protected ProductTypeDataSourceView ProductTypeView
		{
			get { return ( View as ProductTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProductTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ProductTypeSelectMethod SelectMethod
		{
			get
			{
				ProductTypeSelectMethod selectMethod = ProductTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProductTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProductTypeDataSourceView class that is to be
		/// used by the ProductTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ProductTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ProductType, ProductTypeKey> GetNewDataSourceView()
		{
			return new ProductTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ProductTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProductTypeDataSourceView : ProviderDataSourceView<ProductType, ProductTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProductTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProductTypeDataSourceView(ProductTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProductTypeDataSource ProductTypeOwner
		{
			get { return Owner as ProductTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProductTypeSelectMethod SelectMethod
		{
			get { return ProductTypeOwner.SelectMethod; }
			set { ProductTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProductTypeService ProductTypeProvider
		{
			get { return Provider as ProductTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProductType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProductType> results = null;
			ProductType item;
			count = 0;
			
			System.Int32 _id;
			System.String _name_nullable;

			switch ( SelectMethod )
			{
				case ProductTypeSelectMethod.Get:
					ProductTypeKey entityKey  = new ProductTypeKey();
					entityKey.Load(values);
					item = ProductTypeProvider.Get(entityKey);
					results = new TList<ProductType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProductTypeSelectMethod.GetAll:
                    results = ProductTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProductTypeSelectMethod.GetPaged:
					results = ProductTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProductTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProductTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProductTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProductTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProductTypeProvider.GetById(_id);
					results = new TList<ProductType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ProductTypeSelectMethod.GetByName:
					_name_nullable = (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String));
					item = ProductTypeProvider.GetByName(_name_nullable);
					results = new TList<ProductType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
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
			if ( SelectMethod == ProductTypeSelectMethod.Get || SelectMethod == ProductTypeSelectMethod.GetById )
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
				ProductType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProductTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProductType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProductTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProductTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProductTypeDataSource class.
	/// </summary>
	public class ProductTypeDataSourceDesigner : ProviderDataSourceDesigner<ProductType, ProductTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProductTypeDataSourceDesigner class.
		/// </summary>
		public ProductTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductTypeSelectMethod SelectMethod
		{
			get { return ((ProductTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProductTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProductTypeDataSourceActionList

	/// <summary>
	/// Supports the ProductTypeDataSourceDesigner class.
	/// </summary>
	internal class ProductTypeDataSourceActionList : DesignerActionList
	{
		private ProductTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProductTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProductTypeDataSourceActionList(ProductTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProductTypeSelectMethod SelectMethod
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

	#endregion ProductTypeDataSourceActionList
	
	#endregion ProductTypeDataSourceDesigner
	
	#region ProductTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProductTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ProductTypeSelectMethod
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
		GetByName
	}
	
	#endregion ProductTypeSelectMethod

	#region ProductTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeFilter : SqlFilter<ProductTypeColumn>
	{
	}
	
	#endregion ProductTypeFilter

	#region ProductTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeExpressionBuilder : SqlExpressionBuilder<ProductTypeColumn>
	{
	}
	
	#endregion ProductTypeExpressionBuilder	

	#region ProductTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProductTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeProperty : ChildEntityProperty<ProductTypeChildEntityTypes>
	{
	}
	
	#endregion ProductTypeProperty
}

