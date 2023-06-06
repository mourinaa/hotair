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
	/// Represents the DataRepository.ConferencingSummaryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ConferencingSummaryDataSourceDesigner))]
	public class ConferencingSummaryDataSource : ProviderDataSource<ConferencingSummary, ConferencingSummaryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryDataSource class.
		/// </summary>
		public ConferencingSummaryDataSource() : base(new ConferencingSummaryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ConferencingSummaryDataSourceView used by the ConferencingSummaryDataSource.
		/// </summary>
		protected ConferencingSummaryDataSourceView ConferencingSummaryView
		{
			get { return ( View as ConferencingSummaryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ConferencingSummaryDataSource control invokes to retrieve data.
		/// </summary>
		public ConferencingSummarySelectMethod SelectMethod
		{
			get
			{
				ConferencingSummarySelectMethod selectMethod = ConferencingSummarySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ConferencingSummarySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ConferencingSummaryDataSourceView class that is to be
		/// used by the ConferencingSummaryDataSource.
		/// </summary>
		/// <returns>An instance of the ConferencingSummaryDataSourceView class.</returns>
		protected override BaseDataSourceView<ConferencingSummary, ConferencingSummaryKey> GetNewDataSourceView()
		{
			return new ConferencingSummaryDataSourceView(this, DefaultViewName);
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
	/// Supports the ConferencingSummaryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ConferencingSummaryDataSourceView : ProviderDataSourceView<ConferencingSummary, ConferencingSummaryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ConferencingSummaryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ConferencingSummaryDataSourceView(ConferencingSummaryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ConferencingSummaryDataSource ConferencingSummaryOwner
		{
			get { return Owner as ConferencingSummaryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ConferencingSummarySelectMethod SelectMethod
		{
			get { return ConferencingSummaryOwner.SelectMethod; }
			set { ConferencingSummaryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ConferencingSummaryService ConferencingSummaryProvider
		{
			get { return Provider as ConferencingSummaryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ConferencingSummary> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ConferencingSummary> results = null;
			ConferencingSummary item;
			count = 0;
			
			System.DateTime _billedDate;
			System.Int32 _productId;
			System.String _currency;

			switch ( SelectMethod )
			{
				case ConferencingSummarySelectMethod.Get:
					ConferencingSummaryKey entityKey  = new ConferencingSummaryKey();
					entityKey.Load(values);
					item = ConferencingSummaryProvider.Get(entityKey);
					results = new TList<ConferencingSummary>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ConferencingSummarySelectMethod.GetAll:
                    results = ConferencingSummaryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ConferencingSummarySelectMethod.GetPaged:
					results = ConferencingSummaryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ConferencingSummarySelectMethod.Find:
					if ( FilterParameters != null )
						results = ConferencingSummaryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ConferencingSummaryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ConferencingSummarySelectMethod.GetByBilledDateProductIdCurrency:
					_billedDate = ( values["BilledDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["BilledDate"], typeof(System.DateTime)) : DateTime.MinValue;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					_currency = ( values["Currency"] != null ) ? (System.String) EntityUtil.ChangeType(values["Currency"], typeof(System.String)) : string.Empty;
					item = ConferencingSummaryProvider.GetByBilledDateProductIdCurrency(_billedDate, _productId, _currency);
					results = new TList<ConferencingSummary>();
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
			if ( SelectMethod == ConferencingSummarySelectMethod.Get || SelectMethod == ConferencingSummarySelectMethod.GetByBilledDateProductIdCurrency )
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
				ConferencingSummary entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ConferencingSummaryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ConferencingSummary> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ConferencingSummaryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ConferencingSummaryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ConferencingSummaryDataSource class.
	/// </summary>
	public class ConferencingSummaryDataSourceDesigner : ProviderDataSourceDesigner<ConferencingSummary, ConferencingSummaryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryDataSourceDesigner class.
		/// </summary>
		public ConferencingSummaryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ConferencingSummarySelectMethod SelectMethod
		{
			get { return ((ConferencingSummaryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ConferencingSummaryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ConferencingSummaryDataSourceActionList

	/// <summary>
	/// Supports the ConferencingSummaryDataSourceDesigner class.
	/// </summary>
	internal class ConferencingSummaryDataSourceActionList : DesignerActionList
	{
		private ConferencingSummaryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ConferencingSummaryDataSourceActionList(ConferencingSummaryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ConferencingSummarySelectMethod SelectMethod
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

	#endregion ConferencingSummaryDataSourceActionList
	
	#endregion ConferencingSummaryDataSourceDesigner
	
	#region ConferencingSummarySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ConferencingSummaryDataSource.SelectMethod property.
	/// </summary>
	public enum ConferencingSummarySelectMethod
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
		/// Represents the GetByBilledDateProductIdCurrency method.
		/// </summary>
		GetByBilledDateProductIdCurrency
	}
	
	#endregion ConferencingSummarySelectMethod

	#region ConferencingSummaryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryFilter : SqlFilter<ConferencingSummaryColumn>
	{
	}
	
	#endregion ConferencingSummaryFilter

	#region ConferencingSummaryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryExpressionBuilder : SqlExpressionBuilder<ConferencingSummaryColumn>
	{
	}
	
	#endregion ConferencingSummaryExpressionBuilder	

	#region ConferencingSummaryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ConferencingSummaryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryProperty : ChildEntityProperty<ConferencingSummaryChildEntityTypes>
	{
	}
	
	#endregion ConferencingSummaryProperty
}

