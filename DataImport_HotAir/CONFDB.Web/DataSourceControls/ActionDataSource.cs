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
	/// Represents the DataRepository.ActionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ActionDataSourceDesigner))]
	public class ActionDataSource : ProviderDataSource<Action, ActionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionDataSource class.
		/// </summary>
		public ActionDataSource() : base(new ActionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ActionDataSourceView used by the ActionDataSource.
		/// </summary>
		protected ActionDataSourceView ActionView
		{
			get { return ( View as ActionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ActionDataSource control invokes to retrieve data.
		/// </summary>
		public ActionSelectMethod SelectMethod
		{
			get
			{
				ActionSelectMethod selectMethod = ActionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ActionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ActionDataSourceView class that is to be
		/// used by the ActionDataSource.
		/// </summary>
		/// <returns>An instance of the ActionDataSourceView class.</returns>
		protected override BaseDataSourceView<Action, ActionKey> GetNewDataSourceView()
		{
			return new ActionDataSourceView(this, DefaultViewName);
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
	/// Supports the ActionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ActionDataSourceView : ProviderDataSourceView<Action, ActionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ActionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ActionDataSourceView(ActionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ActionDataSource ActionOwner
		{
			get { return Owner as ActionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ActionSelectMethod SelectMethod
		{
			get { return ActionOwner.SelectMethod; }
			set { ActionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ActionService ActionProvider
		{
			get { return Provider as ActionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Action> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Action> results = null;
			Action item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _actionTypeId;

			switch ( SelectMethod )
			{
				case ActionSelectMethod.Get:
					ActionKey entityKey  = new ActionKey();
					entityKey.Load(values);
					item = ActionProvider.Get(entityKey);
					results = new TList<Action>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ActionSelectMethod.GetAll:
                    results = ActionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ActionSelectMethod.GetPaged:
					results = ActionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ActionSelectMethod.Find:
					if ( FilterParameters != null )
						results = ActionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ActionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ActionSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ActionProvider.GetById(_id);
					results = new TList<Action>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ActionSelectMethod.GetByActionTypeId:
					_actionTypeId = ( values["ActionTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ActionTypeId"], typeof(System.Int32)) : (int)0;
					results = ActionProvider.GetByActionTypeId(_actionTypeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ActionSelectMethod.Get || SelectMethod == ActionSelectMethod.GetById )
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
				Action entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ActionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Action> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ActionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ActionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ActionDataSource class.
	/// </summary>
	public class ActionDataSourceDesigner : ProviderDataSourceDesigner<Action, ActionKey>
	{
		/// <summary>
		/// Initializes a new instance of the ActionDataSourceDesigner class.
		/// </summary>
		public ActionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ActionSelectMethod SelectMethod
		{
			get { return ((ActionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ActionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ActionDataSourceActionList

	/// <summary>
	/// Supports the ActionDataSourceDesigner class.
	/// </summary>
	internal class ActionDataSourceActionList : DesignerActionList
	{
		private ActionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ActionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ActionDataSourceActionList(ActionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ActionSelectMethod SelectMethod
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

	#endregion ActionDataSourceActionList
	
	#endregion ActionDataSourceDesigner
	
	#region ActionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ActionDataSource.SelectMethod property.
	/// </summary>
	public enum ActionSelectMethod
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
		/// Represents the GetByActionTypeId method.
		/// </summary>
		GetByActionTypeId
	}
	
	#endregion ActionSelectMethod

	#region ActionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionFilter : SqlFilter<ActionColumn>
	{
	}
	
	#endregion ActionFilter

	#region ActionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionExpressionBuilder : SqlExpressionBuilder<ActionColumn>
	{
	}
	
	#endregion ActionExpressionBuilder	

	#region ActionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ActionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionProperty : ChildEntityProperty<ActionChildEntityTypes>
	{
	}
	
	#endregion ActionProperty
}

