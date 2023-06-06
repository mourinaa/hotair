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
	/// Represents the DataRepository.TrendProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TrendDataSourceDesigner))]
	public class TrendDataSource : ProviderDataSource<Trend, TrendKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendDataSource class.
		/// </summary>
		public TrendDataSource() : base(new TrendService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TrendDataSourceView used by the TrendDataSource.
		/// </summary>
		protected TrendDataSourceView TrendView
		{
			get { return ( View as TrendDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TrendDataSource control invokes to retrieve data.
		/// </summary>
		public TrendSelectMethod SelectMethod
		{
			get
			{
				TrendSelectMethod selectMethod = TrendSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TrendSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TrendDataSourceView class that is to be
		/// used by the TrendDataSource.
		/// </summary>
		/// <returns>An instance of the TrendDataSourceView class.</returns>
		protected override BaseDataSourceView<Trend, TrendKey> GetNewDataSourceView()
		{
			return new TrendDataSourceView(this, DefaultViewName);
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
	/// Supports the TrendDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TrendDataSourceView : ProviderDataSourceView<Trend, TrendKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TrendDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TrendDataSourceView(TrendDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TrendDataSource TrendOwner
		{
			get { return Owner as TrendDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TrendSelectMethod SelectMethod
		{
			get { return TrendOwner.SelectMethod; }
			set { TrendOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TrendService TrendProvider
		{
			get { return Provider as TrendService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Trend> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Trend> results = null;
			Trend item;
			count = 0;
			
			System.String _wholesalerId;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case TrendSelectMethod.Get:
					TrendKey entityKey  = new TrendKey();
					entityKey.Load(values);
					item = TrendProvider.Get(entityKey);
					results = new TList<Trend>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TrendSelectMethod.GetAll:
                    results = TrendProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TrendSelectMethod.GetPaged:
					results = TrendProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TrendSelectMethod.Find:
					if ( FilterParameters != null )
						results = TrendProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TrendProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TrendSelectMethod.GetByWholesalerIdCustomerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = TrendProvider.GetByWholesalerIdCustomerId(_wholesalerId, _customerId);
					results = new TList<Trend>();
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
			if ( SelectMethod == TrendSelectMethod.Get || SelectMethod == TrendSelectMethod.GetByWholesalerIdCustomerId )
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
				Trend entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TrendProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Trend> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TrendProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TrendDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TrendDataSource class.
	/// </summary>
	public class TrendDataSourceDesigner : ProviderDataSourceDesigner<Trend, TrendKey>
	{
		/// <summary>
		/// Initializes a new instance of the TrendDataSourceDesigner class.
		/// </summary>
		public TrendDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TrendSelectMethod SelectMethod
		{
			get { return ((TrendDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TrendDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TrendDataSourceActionList

	/// <summary>
	/// Supports the TrendDataSourceDesigner class.
	/// </summary>
	internal class TrendDataSourceActionList : DesignerActionList
	{
		private TrendDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TrendDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TrendDataSourceActionList(TrendDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TrendSelectMethod SelectMethod
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

	#endregion TrendDataSourceActionList
	
	#endregion TrendDataSourceDesigner
	
	#region TrendSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TrendDataSource.SelectMethod property.
	/// </summary>
	public enum TrendSelectMethod
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
		/// Represents the GetByWholesalerIdCustomerId method.
		/// </summary>
		GetByWholesalerIdCustomerId
	}
	
	#endregion TrendSelectMethod

	#region TrendFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendFilter : SqlFilter<TrendColumn>
	{
	}
	
	#endregion TrendFilter

	#region TrendExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendExpressionBuilder : SqlExpressionBuilder<TrendColumn>
	{
	}
	
	#endregion TrendExpressionBuilder	

	#region TrendProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TrendChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendProperty : ChildEntityProperty<TrendChildEntityTypes>
	{
	}
	
	#endregion TrendProperty
}

