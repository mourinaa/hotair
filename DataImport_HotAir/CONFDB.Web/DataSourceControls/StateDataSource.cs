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
	/// Represents the DataRepository.StateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StateDataSourceDesigner))]
	public class StateDataSource : ProviderDataSource<State, StateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateDataSource class.
		/// </summary>
		public StateDataSource() : base(new StateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StateDataSourceView used by the StateDataSource.
		/// </summary>
		protected StateDataSourceView StateView
		{
			get { return ( View as StateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StateDataSource control invokes to retrieve data.
		/// </summary>
		public StateSelectMethod SelectMethod
		{
			get
			{
				StateSelectMethod selectMethod = StateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StateDataSourceView class that is to be
		/// used by the StateDataSource.
		/// </summary>
		/// <returns>An instance of the StateDataSourceView class.</returns>
		protected override BaseDataSourceView<State, StateKey> GetNewDataSourceView()
		{
			return new StateDataSourceView(this, DefaultViewName);
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
	/// Supports the StateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StateDataSourceView : ProviderDataSourceView<State, StateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StateDataSourceView(StateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StateDataSource StateOwner
		{
			get { return Owner as StateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StateSelectMethod SelectMethod
		{
			get { return StateOwner.SelectMethod; }
			set { StateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StateService StateProvider
		{
			get { return Provider as StateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<State> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<State> results = null;
			State item;
			count = 0;
			
			System.String _id;
			System.String _countryId;

			switch ( SelectMethod )
			{
				case StateSelectMethod.Get:
					StateKey entityKey  = new StateKey();
					entityKey.Load(values);
					item = StateProvider.Get(entityKey);
					results = new TList<State>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StateSelectMethod.GetAll:
                    results = StateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case StateSelectMethod.GetPaged:
					results = StateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StateSelectMethod.Find:
					if ( FilterParameters != null )
						results = StateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StateSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = StateProvider.GetById(_id);
					results = new TList<State>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case StateSelectMethod.GetByIdCountryId:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					_countryId = ( values["CountryId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryId"], typeof(System.String)) : string.Empty;
					item = StateProvider.GetByIdCountryId(_id, _countryId);
					results = new TList<State>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case StateSelectMethod.GetByCountryId:
					_countryId = ( values["CountryId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryId"], typeof(System.String)) : string.Empty;
					results = StateProvider.GetByCountryId(_countryId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == StateSelectMethod.Get || SelectMethod == StateSelectMethod.GetById )
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
				State entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					StateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<State> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			StateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StateDataSource class.
	/// </summary>
	public class StateDataSourceDesigner : ProviderDataSourceDesigner<State, StateKey>
	{
		/// <summary>
		/// Initializes a new instance of the StateDataSourceDesigner class.
		/// </summary>
		public StateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StateSelectMethod SelectMethod
		{
			get { return ((StateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StateDataSourceActionList

	/// <summary>
	/// Supports the StateDataSourceDesigner class.
	/// </summary>
	internal class StateDataSourceActionList : DesignerActionList
	{
		private StateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StateDataSourceActionList(StateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StateSelectMethod SelectMethod
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

	#endregion StateDataSourceActionList
	
	#endregion StateDataSourceDesigner
	
	#region StateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StateDataSource.SelectMethod property.
	/// </summary>
	public enum StateSelectMethod
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
		/// Represents the GetByIdCountryId method.
		/// </summary>
		GetByIdCountryId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId
	}
	
	#endregion StateSelectMethod

	#region StateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateFilter : SqlFilter<StateColumn>
	{
	}
	
	#endregion StateFilter

	#region StateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateExpressionBuilder : SqlExpressionBuilder<StateColumn>
	{
	}
	
	#endregion StateExpressionBuilder	

	#region StateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateProperty : ChildEntityProperty<StateChildEntityTypes>
	{
	}
	
	#endregion StateProperty
}

