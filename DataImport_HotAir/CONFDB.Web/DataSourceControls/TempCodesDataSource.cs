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
	/// Represents the DataRepository.TempCodesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TempCodesDataSourceDesigner))]
	public class TempCodesDataSource : ProviderDataSource<TempCodes, TempCodesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodesDataSource class.
		/// </summary>
		public TempCodesDataSource() : base(new TempCodesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TempCodesDataSourceView used by the TempCodesDataSource.
		/// </summary>
		protected TempCodesDataSourceView TempCodesView
		{
			get { return ( View as TempCodesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TempCodesDataSource control invokes to retrieve data.
		/// </summary>
		public TempCodesSelectMethod SelectMethod
		{
			get
			{
				TempCodesSelectMethod selectMethod = TempCodesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TempCodesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TempCodesDataSourceView class that is to be
		/// used by the TempCodesDataSource.
		/// </summary>
		/// <returns>An instance of the TempCodesDataSourceView class.</returns>
		protected override BaseDataSourceView<TempCodes, TempCodesKey> GetNewDataSourceView()
		{
			return new TempCodesDataSourceView(this, DefaultViewName);
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
	/// Supports the TempCodesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TempCodesDataSourceView : ProviderDataSourceView<TempCodes, TempCodesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TempCodesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TempCodesDataSourceView(TempCodesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TempCodesDataSource TempCodesOwner
		{
			get { return Owner as TempCodesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TempCodesSelectMethod SelectMethod
		{
			get { return TempCodesOwner.SelectMethod; }
			set { TempCodesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TempCodesService TempCodesProvider
		{
			get { return Provider as TempCodesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TempCodes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TempCodes> results = null;
			TempCodes item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TempCodesSelectMethod.Get:
					TempCodesKey entityKey  = new TempCodesKey();
					entityKey.Load(values);
					item = TempCodesProvider.Get(entityKey);
					results = new TList<TempCodes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TempCodesSelectMethod.GetAll:
                    results = TempCodesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TempCodesSelectMethod.GetPaged:
					results = TempCodesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TempCodesSelectMethod.Find:
					if ( FilterParameters != null )
						results = TempCodesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TempCodesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TempCodesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TempCodesProvider.GetById(_id);
					results = new TList<TempCodes>();
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
			if ( SelectMethod == TempCodesSelectMethod.Get || SelectMethod == TempCodesSelectMethod.GetById )
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
				TempCodes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TempCodesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TempCodes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TempCodesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TempCodesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TempCodesDataSource class.
	/// </summary>
	public class TempCodesDataSourceDesigner : ProviderDataSourceDesigner<TempCodes, TempCodesKey>
	{
		/// <summary>
		/// Initializes a new instance of the TempCodesDataSourceDesigner class.
		/// </summary>
		public TempCodesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempCodesSelectMethod SelectMethod
		{
			get { return ((TempCodesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TempCodesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TempCodesDataSourceActionList

	/// <summary>
	/// Supports the TempCodesDataSourceDesigner class.
	/// </summary>
	internal class TempCodesDataSourceActionList : DesignerActionList
	{
		private TempCodesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TempCodesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TempCodesDataSourceActionList(TempCodesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempCodesSelectMethod SelectMethod
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

	#endregion TempCodesDataSourceActionList
	
	#endregion TempCodesDataSourceDesigner
	
	#region TempCodesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TempCodesDataSource.SelectMethod property.
	/// </summary>
	public enum TempCodesSelectMethod
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
	
	#endregion TempCodesSelectMethod

	#region TempCodesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodesFilter : SqlFilter<TempCodesColumn>
	{
	}
	
	#endregion TempCodesFilter

	#region TempCodesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodesExpressionBuilder : SqlExpressionBuilder<TempCodesColumn>
	{
	}
	
	#endregion TempCodesExpressionBuilder	

	#region TempCodesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TempCodesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodesProperty : ChildEntityProperty<TempCodesChildEntityTypes>
	{
	}
	
	#endregion TempCodesProperty
}

