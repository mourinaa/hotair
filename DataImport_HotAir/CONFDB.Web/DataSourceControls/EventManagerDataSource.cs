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
	/// Represents the DataRepository.EventManagerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EventManagerDataSourceDesigner))]
	public class EventManagerDataSource : ProviderDataSource<EventManager, EventManagerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EventManagerDataSource class.
		/// </summary>
		public EventManagerDataSource() : base(new EventManagerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EventManagerDataSourceView used by the EventManagerDataSource.
		/// </summary>
		protected EventManagerDataSourceView EventManagerView
		{
			get { return ( View as EventManagerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EventManagerDataSource control invokes to retrieve data.
		/// </summary>
		public EventManagerSelectMethod SelectMethod
		{
			get
			{
				EventManagerSelectMethod selectMethod = EventManagerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EventManagerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EventManagerDataSourceView class that is to be
		/// used by the EventManagerDataSource.
		/// </summary>
		/// <returns>An instance of the EventManagerDataSourceView class.</returns>
		protected override BaseDataSourceView<EventManager, EventManagerKey> GetNewDataSourceView()
		{
			return new EventManagerDataSourceView(this, DefaultViewName);
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
	/// Supports the EventManagerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EventManagerDataSourceView : ProviderDataSourceView<EventManager, EventManagerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EventManagerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EventManagerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EventManagerDataSourceView(EventManagerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EventManagerDataSource EventManagerOwner
		{
			get { return Owner as EventManagerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EventManagerSelectMethod SelectMethod
		{
			get { return EventManagerOwner.SelectMethod; }
			set { EventManagerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EventManagerService EventManagerProvider
		{
			get { return Provider as EventManagerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EventManager> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EventManager> results = null;
			EventManager item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _userId_nullable;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case EventManagerSelectMethod.Get:
					EventManagerKey entityKey  = new EventManagerKey();
					entityKey.Load(values);
					item = EventManagerProvider.Get(entityKey);
					results = new TList<EventManager>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EventManagerSelectMethod.GetAll:
                    results = EventManagerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EventManagerSelectMethod.GetPaged:
					results = EventManagerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EventManagerSelectMethod.Find:
					if ( FilterParameters != null )
						results = EventManagerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EventManagerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EventManagerSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = EventManagerProvider.GetById(_id);
					results = new TList<EventManager>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EventManagerSelectMethod.GetByUserId:
					_userId_nullable = (System.Int32?) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32?));
					results = EventManagerProvider.GetByUserId(_userId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EventManagerSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = EventManagerProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EventManagerSelectMethod.Get || SelectMethod == EventManagerSelectMethod.GetById )
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
				EventManager entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EventManagerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EventManager> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EventManagerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EventManagerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EventManagerDataSource class.
	/// </summary>
	public class EventManagerDataSourceDesigner : ProviderDataSourceDesigner<EventManager, EventManagerKey>
	{
		/// <summary>
		/// Initializes a new instance of the EventManagerDataSourceDesigner class.
		/// </summary>
		public EventManagerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EventManagerSelectMethod SelectMethod
		{
			get { return ((EventManagerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EventManagerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EventManagerDataSourceActionList

	/// <summary>
	/// Supports the EventManagerDataSourceDesigner class.
	/// </summary>
	internal class EventManagerDataSourceActionList : DesignerActionList
	{
		private EventManagerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EventManagerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EventManagerDataSourceActionList(EventManagerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EventManagerSelectMethod SelectMethod
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

	#endregion EventManagerDataSourceActionList
	
	#endregion EventManagerDataSourceDesigner
	
	#region EventManagerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EventManagerDataSource.SelectMethod property.
	/// </summary>
	public enum EventManagerSelectMethod
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
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion EventManagerSelectMethod

	#region EventManagerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EventManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EventManagerFilter : SqlFilter<EventManagerColumn>
	{
	}
	
	#endregion EventManagerFilter

	#region EventManagerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EventManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EventManagerExpressionBuilder : SqlExpressionBuilder<EventManagerColumn>
	{
	}
	
	#endregion EventManagerExpressionBuilder	

	#region EventManagerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EventManagerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EventManager"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EventManagerProperty : ChildEntityProperty<EventManagerChildEntityTypes>
	{
	}
	
	#endregion EventManagerProperty
}

