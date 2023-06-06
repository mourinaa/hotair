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
	/// Represents the DataRepository.TempReplayIdsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TempReplayIdsDataSourceDesigner))]
	public class TempReplayIdsDataSource : ProviderDataSource<TempReplayIds, TempReplayIdsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsDataSource class.
		/// </summary>
		public TempReplayIdsDataSource() : base(new TempReplayIdsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TempReplayIdsDataSourceView used by the TempReplayIdsDataSource.
		/// </summary>
		protected TempReplayIdsDataSourceView TempReplayIdsView
		{
			get { return ( View as TempReplayIdsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TempReplayIdsDataSource control invokes to retrieve data.
		/// </summary>
		public TempReplayIdsSelectMethod SelectMethod
		{
			get
			{
				TempReplayIdsSelectMethod selectMethod = TempReplayIdsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TempReplayIdsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TempReplayIdsDataSourceView class that is to be
		/// used by the TempReplayIdsDataSource.
		/// </summary>
		/// <returns>An instance of the TempReplayIdsDataSourceView class.</returns>
		protected override BaseDataSourceView<TempReplayIds, TempReplayIdsKey> GetNewDataSourceView()
		{
			return new TempReplayIdsDataSourceView(this, DefaultViewName);
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
	/// Supports the TempReplayIdsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TempReplayIdsDataSourceView : ProviderDataSourceView<TempReplayIds, TempReplayIdsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TempReplayIdsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TempReplayIdsDataSourceView(TempReplayIdsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TempReplayIdsDataSource TempReplayIdsOwner
		{
			get { return Owner as TempReplayIdsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TempReplayIdsSelectMethod SelectMethod
		{
			get { return TempReplayIdsOwner.SelectMethod; }
			set { TempReplayIdsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TempReplayIdsService TempReplayIdsProvider
		{
			get { return Provider as TempReplayIdsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TempReplayIds> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TempReplayIds> results = null;
			TempReplayIds item;
			count = 0;
			
			System.Int32 _replayId;

			switch ( SelectMethod )
			{
				case TempReplayIdsSelectMethod.Get:
					TempReplayIdsKey entityKey  = new TempReplayIdsKey();
					entityKey.Load(values);
					item = TempReplayIdsProvider.Get(entityKey);
					results = new TList<TempReplayIds>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TempReplayIdsSelectMethod.GetAll:
                    results = TempReplayIdsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TempReplayIdsSelectMethod.GetPaged:
					results = TempReplayIdsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TempReplayIdsSelectMethod.Find:
					if ( FilterParameters != null )
						results = TempReplayIdsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TempReplayIdsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TempReplayIdsSelectMethod.GetByReplayId:
					_replayId = ( values["ReplayId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReplayId"], typeof(System.Int32)) : (int)0;
					item = TempReplayIdsProvider.GetByReplayId(_replayId);
					results = new TList<TempReplayIds>();
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
			if ( SelectMethod == TempReplayIdsSelectMethod.Get || SelectMethod == TempReplayIdsSelectMethod.GetByReplayId )
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
				TempReplayIds entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TempReplayIdsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TempReplayIds> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TempReplayIdsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TempReplayIdsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TempReplayIdsDataSource class.
	/// </summary>
	public class TempReplayIdsDataSourceDesigner : ProviderDataSourceDesigner<TempReplayIds, TempReplayIdsKey>
	{
		/// <summary>
		/// Initializes a new instance of the TempReplayIdsDataSourceDesigner class.
		/// </summary>
		public TempReplayIdsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempReplayIdsSelectMethod SelectMethod
		{
			get { return ((TempReplayIdsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TempReplayIdsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TempReplayIdsDataSourceActionList

	/// <summary>
	/// Supports the TempReplayIdsDataSourceDesigner class.
	/// </summary>
	internal class TempReplayIdsDataSourceActionList : DesignerActionList
	{
		private TempReplayIdsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TempReplayIdsDataSourceActionList(TempReplayIdsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempReplayIdsSelectMethod SelectMethod
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

	#endregion TempReplayIdsDataSourceActionList
	
	#endregion TempReplayIdsDataSourceDesigner
	
	#region TempReplayIdsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TempReplayIdsDataSource.SelectMethod property.
	/// </summary>
	public enum TempReplayIdsSelectMethod
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
		/// Represents the GetByReplayId method.
		/// </summary>
		GetByReplayId
	}
	
	#endregion TempReplayIdsSelectMethod

	#region TempReplayIdsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsFilter : SqlFilter<TempReplayIdsColumn>
	{
	}
	
	#endregion TempReplayIdsFilter

	#region TempReplayIdsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsExpressionBuilder : SqlExpressionBuilder<TempReplayIdsColumn>
	{
	}
	
	#endregion TempReplayIdsExpressionBuilder	

	#region TempReplayIdsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TempReplayIdsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsProperty : ChildEntityProperty<TempReplayIdsChildEntityTypes>
	{
	}
	
	#endregion TempReplayIdsProperty
}

