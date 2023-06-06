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
	/// Represents the DataRepository.TempSampleRatesPerProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TempSampleRatesPerProductDataSourceDesigner))]
	public class TempSampleRatesPerProductDataSource : ProviderDataSource<TempSampleRatesPerProduct, TempSampleRatesPerProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductDataSource class.
		/// </summary>
		public TempSampleRatesPerProductDataSource() : base(new TempSampleRatesPerProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TempSampleRatesPerProductDataSourceView used by the TempSampleRatesPerProductDataSource.
		/// </summary>
		protected TempSampleRatesPerProductDataSourceView TempSampleRatesPerProductView
		{
			get { return ( View as TempSampleRatesPerProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TempSampleRatesPerProductDataSource control invokes to retrieve data.
		/// </summary>
		public TempSampleRatesPerProductSelectMethod SelectMethod
		{
			get
			{
				TempSampleRatesPerProductSelectMethod selectMethod = TempSampleRatesPerProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TempSampleRatesPerProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TempSampleRatesPerProductDataSourceView class that is to be
		/// used by the TempSampleRatesPerProductDataSource.
		/// </summary>
		/// <returns>An instance of the TempSampleRatesPerProductDataSourceView class.</returns>
		protected override BaseDataSourceView<TempSampleRatesPerProduct, TempSampleRatesPerProductKey> GetNewDataSourceView()
		{
			return new TempSampleRatesPerProductDataSourceView(this, DefaultViewName);
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
	/// Supports the TempSampleRatesPerProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TempSampleRatesPerProductDataSourceView : ProviderDataSourceView<TempSampleRatesPerProduct, TempSampleRatesPerProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TempSampleRatesPerProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TempSampleRatesPerProductDataSourceView(TempSampleRatesPerProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TempSampleRatesPerProductDataSource TempSampleRatesPerProductOwner
		{
			get { return Owner as TempSampleRatesPerProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TempSampleRatesPerProductSelectMethod SelectMethod
		{
			get { return TempSampleRatesPerProductOwner.SelectMethod; }
			set { TempSampleRatesPerProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TempSampleRatesPerProductService TempSampleRatesPerProductProvider
		{
			get { return Provider as TempSampleRatesPerProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TempSampleRatesPerProduct> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TempSampleRatesPerProduct> results = null;
			TempSampleRatesPerProduct item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TempSampleRatesPerProductSelectMethod.Get:
					TempSampleRatesPerProductKey entityKey  = new TempSampleRatesPerProductKey();
					entityKey.Load(values);
					item = TempSampleRatesPerProductProvider.Get(entityKey);
					results = new TList<TempSampleRatesPerProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TempSampleRatesPerProductSelectMethod.GetAll:
                    results = TempSampleRatesPerProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TempSampleRatesPerProductSelectMethod.GetPaged:
					results = TempSampleRatesPerProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TempSampleRatesPerProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = TempSampleRatesPerProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TempSampleRatesPerProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TempSampleRatesPerProductSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TempSampleRatesPerProductProvider.GetById(_id);
					results = new TList<TempSampleRatesPerProduct>();
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
			if ( SelectMethod == TempSampleRatesPerProductSelectMethod.Get || SelectMethod == TempSampleRatesPerProductSelectMethod.GetById )
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
				TempSampleRatesPerProduct entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TempSampleRatesPerProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TempSampleRatesPerProduct> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TempSampleRatesPerProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TempSampleRatesPerProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TempSampleRatesPerProductDataSource class.
	/// </summary>
	public class TempSampleRatesPerProductDataSourceDesigner : ProviderDataSourceDesigner<TempSampleRatesPerProduct, TempSampleRatesPerProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductDataSourceDesigner class.
		/// </summary>
		public TempSampleRatesPerProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempSampleRatesPerProductSelectMethod SelectMethod
		{
			get { return ((TempSampleRatesPerProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TempSampleRatesPerProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TempSampleRatesPerProductDataSourceActionList

	/// <summary>
	/// Supports the TempSampleRatesPerProductDataSourceDesigner class.
	/// </summary>
	internal class TempSampleRatesPerProductDataSourceActionList : DesignerActionList
	{
		private TempSampleRatesPerProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TempSampleRatesPerProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TempSampleRatesPerProductDataSourceActionList(TempSampleRatesPerProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempSampleRatesPerProductSelectMethod SelectMethod
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

	#endregion TempSampleRatesPerProductDataSourceActionList
	
	#endregion TempSampleRatesPerProductDataSourceDesigner
	
	#region TempSampleRatesPerProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TempSampleRatesPerProductDataSource.SelectMethod property.
	/// </summary>
	public enum TempSampleRatesPerProductSelectMethod
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
	
	#endregion TempSampleRatesPerProductSelectMethod

	#region TempSampleRatesPerProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempSampleRatesPerProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempSampleRatesPerProductFilter : SqlFilter<TempSampleRatesPerProductColumn>
	{
	}
	
	#endregion TempSampleRatesPerProductFilter

	#region TempSampleRatesPerProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempSampleRatesPerProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempSampleRatesPerProductExpressionBuilder : SqlExpressionBuilder<TempSampleRatesPerProductColumn>
	{
	}
	
	#endregion TempSampleRatesPerProductExpressionBuilder	

	#region TempSampleRatesPerProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TempSampleRatesPerProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TempSampleRatesPerProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempSampleRatesPerProductProperty : ChildEntityProperty<TempSampleRatesPerProductChildEntityTypes>
	{
	}
	
	#endregion TempSampleRatesPerProductProperty
}

