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
	/// Represents the DataRepository.TempCodeChangesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TempCodeChangesDataSourceDesigner))]
	public class TempCodeChangesDataSource : ProviderDataSource<TempCodeChanges, TempCodeChangesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesDataSource class.
		/// </summary>
		public TempCodeChangesDataSource() : base(new TempCodeChangesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TempCodeChangesDataSourceView used by the TempCodeChangesDataSource.
		/// </summary>
		protected TempCodeChangesDataSourceView TempCodeChangesView
		{
			get { return ( View as TempCodeChangesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TempCodeChangesDataSource control invokes to retrieve data.
		/// </summary>
		public TempCodeChangesSelectMethod SelectMethod
		{
			get
			{
				TempCodeChangesSelectMethod selectMethod = TempCodeChangesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TempCodeChangesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TempCodeChangesDataSourceView class that is to be
		/// used by the TempCodeChangesDataSource.
		/// </summary>
		/// <returns>An instance of the TempCodeChangesDataSourceView class.</returns>
		protected override BaseDataSourceView<TempCodeChanges, TempCodeChangesKey> GetNewDataSourceView()
		{
			return new TempCodeChangesDataSourceView(this, DefaultViewName);
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
	/// Supports the TempCodeChangesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TempCodeChangesDataSourceView : ProviderDataSourceView<TempCodeChanges, TempCodeChangesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TempCodeChangesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TempCodeChangesDataSourceView(TempCodeChangesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TempCodeChangesDataSource TempCodeChangesOwner
		{
			get { return Owner as TempCodeChangesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TempCodeChangesSelectMethod SelectMethod
		{
			get { return TempCodeChangesOwner.SelectMethod; }
			set { TempCodeChangesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TempCodeChangesService TempCodeChangesProvider
		{
			get { return Provider as TempCodeChangesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TempCodeChanges> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TempCodeChanges> results = null;
			TempCodeChanges item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TempCodeChangesSelectMethod.Get:
					TempCodeChangesKey entityKey  = new TempCodeChangesKey();
					entityKey.Load(values);
					item = TempCodeChangesProvider.Get(entityKey);
					results = new TList<TempCodeChanges>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TempCodeChangesSelectMethod.GetAll:
                    results = TempCodeChangesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TempCodeChangesSelectMethod.GetPaged:
					results = TempCodeChangesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TempCodeChangesSelectMethod.Find:
					if ( FilterParameters != null )
						results = TempCodeChangesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TempCodeChangesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TempCodeChangesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TempCodeChangesProvider.GetById(_id);
					results = new TList<TempCodeChanges>();
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
			if ( SelectMethod == TempCodeChangesSelectMethod.Get || SelectMethod == TempCodeChangesSelectMethod.GetById )
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
				TempCodeChanges entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TempCodeChangesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TempCodeChanges> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TempCodeChangesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TempCodeChangesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TempCodeChangesDataSource class.
	/// </summary>
	public class TempCodeChangesDataSourceDesigner : ProviderDataSourceDesigner<TempCodeChanges, TempCodeChangesKey>
	{
		/// <summary>
		/// Initializes a new instance of the TempCodeChangesDataSourceDesigner class.
		/// </summary>
		public TempCodeChangesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempCodeChangesSelectMethod SelectMethod
		{
			get { return ((TempCodeChangesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TempCodeChangesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TempCodeChangesDataSourceActionList

	/// <summary>
	/// Supports the TempCodeChangesDataSourceDesigner class.
	/// </summary>
	internal class TempCodeChangesDataSourceActionList : DesignerActionList
	{
		private TempCodeChangesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TempCodeChangesDataSourceActionList(TempCodeChangesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempCodeChangesSelectMethod SelectMethod
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

	#endregion TempCodeChangesDataSourceActionList
	
	#endregion TempCodeChangesDataSourceDesigner
	
	#region TempCodeChangesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TempCodeChangesDataSource.SelectMethod property.
	/// </summary>
	public enum TempCodeChangesSelectMethod
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
	
	#endregion TempCodeChangesSelectMethod

	#region TempCodeChangesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesFilter : SqlFilter<TempCodeChangesColumn>
	{
	}
	
	#endregion TempCodeChangesFilter

	#region TempCodeChangesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesExpressionBuilder : SqlExpressionBuilder<TempCodeChangesColumn>
	{
	}
	
	#endregion TempCodeChangesExpressionBuilder	

	#region TempCodeChangesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TempCodeChangesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesProperty : ChildEntityProperty<TempCodeChangesChildEntityTypes>
	{
	}
	
	#endregion TempCodeChangesProperty
}

