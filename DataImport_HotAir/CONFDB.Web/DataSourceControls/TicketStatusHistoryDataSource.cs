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
	/// Represents the DataRepository.TicketStatusHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketStatusHistoryDataSourceDesigner))]
	public class TicketStatusHistoryDataSource : ProviderDataSource<TicketStatusHistory, TicketStatusHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryDataSource class.
		/// </summary>
		public TicketStatusHistoryDataSource() : base(new TicketStatusHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketStatusHistoryDataSourceView used by the TicketStatusHistoryDataSource.
		/// </summary>
		protected TicketStatusHistoryDataSourceView TicketStatusHistoryView
		{
			get { return ( View as TicketStatusHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketStatusHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public TicketStatusHistorySelectMethod SelectMethod
		{
			get
			{
				TicketStatusHistorySelectMethod selectMethod = TicketStatusHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketStatusHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketStatusHistoryDataSourceView class that is to be
		/// used by the TicketStatusHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the TicketStatusHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<TicketStatusHistory, TicketStatusHistoryKey> GetNewDataSourceView()
		{
			return new TicketStatusHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketStatusHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketStatusHistoryDataSourceView : ProviderDataSourceView<TicketStatusHistory, TicketStatusHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketStatusHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketStatusHistoryDataSourceView(TicketStatusHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketStatusHistoryDataSource TicketStatusHistoryOwner
		{
			get { return Owner as TicketStatusHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketStatusHistorySelectMethod SelectMethod
		{
			get { return TicketStatusHistoryOwner.SelectMethod; }
			set { TicketStatusHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketStatusHistoryService TicketStatusHistoryProvider
		{
			get { return Provider as TicketStatusHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TicketStatusHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TicketStatusHistory> results = null;
			TicketStatusHistory item;
			count = 0;
			
			System.Int32 _ticketId;
			System.Int32 _statusId;

			switch ( SelectMethod )
			{
				case TicketStatusHistorySelectMethod.Get:
					TicketStatusHistoryKey entityKey  = new TicketStatusHistoryKey();
					entityKey.Load(values);
					item = TicketStatusHistoryProvider.Get(entityKey);
					results = new TList<TicketStatusHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketStatusHistorySelectMethod.GetAll:
                    results = TicketStatusHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketStatusHistorySelectMethod.GetPaged:
					results = TicketStatusHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketStatusHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketStatusHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketStatusHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketStatusHistorySelectMethod.GetByTicketId:
					_ticketId = ( values["TicketId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TicketId"], typeof(System.Int32)) : (int)0;
					item = TicketStatusHistoryProvider.GetByTicketId(_ticketId);
					results = new TList<TicketStatusHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case TicketStatusHistorySelectMethod.GetByStatusId:
					_statusId = ( values["StatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StatusId"], typeof(System.Int32)) : (int)0;
					results = TicketStatusHistoryProvider.GetByStatusId(_statusId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TicketStatusHistorySelectMethod.Get || SelectMethod == TicketStatusHistorySelectMethod.GetByTicketId )
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
				TicketStatusHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketStatusHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TicketStatusHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketStatusHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketStatusHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketStatusHistoryDataSource class.
	/// </summary>
	public class TicketStatusHistoryDataSourceDesigner : ProviderDataSourceDesigner<TicketStatusHistory, TicketStatusHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryDataSourceDesigner class.
		/// </summary>
		public TicketStatusHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketStatusHistorySelectMethod SelectMethod
		{
			get { return ((TicketStatusHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketStatusHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketStatusHistoryDataSourceActionList

	/// <summary>
	/// Supports the TicketStatusHistoryDataSourceDesigner class.
	/// </summary>
	internal class TicketStatusHistoryDataSourceActionList : DesignerActionList
	{
		private TicketStatusHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketStatusHistoryDataSourceActionList(TicketStatusHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketStatusHistorySelectMethod SelectMethod
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

	#endregion TicketStatusHistoryDataSourceActionList
	
	#endregion TicketStatusHistoryDataSourceDesigner
	
	#region TicketStatusHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketStatusHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum TicketStatusHistorySelectMethod
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
		/// Represents the GetByTicketId method.
		/// </summary>
		GetByTicketId,
		/// <summary>
		/// Represents the GetByStatusId method.
		/// </summary>
		GetByStatusId
	}
	
	#endregion TicketStatusHistorySelectMethod

	#region TicketStatusHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryFilter : SqlFilter<TicketStatusHistoryColumn>
	{
	}
	
	#endregion TicketStatusHistoryFilter

	#region TicketStatusHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryExpressionBuilder : SqlExpressionBuilder<TicketStatusHistoryColumn>
	{
	}
	
	#endregion TicketStatusHistoryExpressionBuilder	

	#region TicketStatusHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketStatusHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryProperty : ChildEntityProperty<TicketStatusHistoryChildEntityTypes>
	{
	}
	
	#endregion TicketStatusHistoryProperty
}

