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
	/// Represents the DataRepository.TicketStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketStatusDataSourceDesigner))]
	public class TicketStatusDataSource : ProviderDataSource<TicketStatus, TicketStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusDataSource class.
		/// </summary>
		public TicketStatusDataSource() : base(new TicketStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketStatusDataSourceView used by the TicketStatusDataSource.
		/// </summary>
		protected TicketStatusDataSourceView TicketStatusView
		{
			get { return ( View as TicketStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketStatusDataSource control invokes to retrieve data.
		/// </summary>
		public TicketStatusSelectMethod SelectMethod
		{
			get
			{
				TicketStatusSelectMethod selectMethod = TicketStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketStatusDataSourceView class that is to be
		/// used by the TicketStatusDataSource.
		/// </summary>
		/// <returns>An instance of the TicketStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<TicketStatus, TicketStatusKey> GetNewDataSourceView()
		{
			return new TicketStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketStatusDataSourceView : ProviderDataSourceView<TicketStatus, TicketStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketStatusDataSourceView(TicketStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketStatusDataSource TicketStatusOwner
		{
			get { return Owner as TicketStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketStatusSelectMethod SelectMethod
		{
			get { return TicketStatusOwner.SelectMethod; }
			set { TicketStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketStatusService TicketStatusProvider
		{
			get { return Provider as TicketStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TicketStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TicketStatus> results = null;
			TicketStatus item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _toStatusId;
			System.Int32 _fromStatusId;

			switch ( SelectMethod )
			{
				case TicketStatusSelectMethod.Get:
					TicketStatusKey entityKey  = new TicketStatusKey();
					entityKey.Load(values);
					item = TicketStatusProvider.Get(entityKey);
					results = new TList<TicketStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketStatusSelectMethod.GetAll:
                    results = TicketStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketStatusSelectMethod.GetPaged:
					results = TicketStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketStatusProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketStatusSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TicketStatusProvider.GetById(_id);
					results = new TList<TicketStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case TicketStatusSelectMethod.GetByToStatusIdFromValidTicketStateChanges:
					_toStatusId = ( values["ToStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ToStatusId"], typeof(System.Int32)) : (int)0;
					results = TicketStatusProvider.GetByToStatusIdFromValidTicketStateChanges(_toStatusId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketStatusSelectMethod.GetByFromStatusIdFromValidTicketStateChanges:
					_fromStatusId = ( values["FromStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FromStatusId"], typeof(System.Int32)) : (int)0;
					results = TicketStatusProvider.GetByFromStatusIdFromValidTicketStateChanges(_fromStatusId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == TicketStatusSelectMethod.Get || SelectMethod == TicketStatusSelectMethod.GetById )
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
				TicketStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TicketStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketStatusProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketStatusDataSource class.
	/// </summary>
	public class TicketStatusDataSourceDesigner : ProviderDataSourceDesigner<TicketStatus, TicketStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketStatusDataSourceDesigner class.
		/// </summary>
		public TicketStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketStatusSelectMethod SelectMethod
		{
			get { return ((TicketStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketStatusDataSourceActionList

	/// <summary>
	/// Supports the TicketStatusDataSourceDesigner class.
	/// </summary>
	internal class TicketStatusDataSourceActionList : DesignerActionList
	{
		private TicketStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketStatusDataSourceActionList(TicketStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketStatusSelectMethod SelectMethod
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

	#endregion TicketStatusDataSourceActionList
	
	#endregion TicketStatusDataSourceDesigner
	
	#region TicketStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketStatusDataSource.SelectMethod property.
	/// </summary>
	public enum TicketStatusSelectMethod
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
		/// Represents the GetByToStatusIdFromValidTicketStateChanges method.
		/// </summary>
		GetByToStatusIdFromValidTicketStateChanges,
		/// <summary>
		/// Represents the GetByFromStatusIdFromValidTicketStateChanges method.
		/// </summary>
		GetByFromStatusIdFromValidTicketStateChanges
	}
	
	#endregion TicketStatusSelectMethod

	#region TicketStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusFilter : SqlFilter<TicketStatusColumn>
	{
	}
	
	#endregion TicketStatusFilter

	#region TicketStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusExpressionBuilder : SqlExpressionBuilder<TicketStatusColumn>
	{
	}
	
	#endregion TicketStatusExpressionBuilder	

	#region TicketStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusProperty : ChildEntityProperty<TicketStatusChildEntityTypes>
	{
	}
	
	#endregion TicketStatusProperty
}

