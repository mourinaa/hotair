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
	/// Represents the DataRepository.TicketProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketDataSourceDesigner))]
	public class TicketDataSource : ProviderDataSource<Ticket, TicketKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketDataSource class.
		/// </summary>
		public TicketDataSource() : base(new TicketService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketDataSourceView used by the TicketDataSource.
		/// </summary>
		protected TicketDataSourceView TicketView
		{
			get { return ( View as TicketDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketDataSource control invokes to retrieve data.
		/// </summary>
		public TicketSelectMethod SelectMethod
		{
			get
			{
				TicketSelectMethod selectMethod = TicketSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketDataSourceView class that is to be
		/// used by the TicketDataSource.
		/// </summary>
		/// <returns>An instance of the TicketDataSourceView class.</returns>
		protected override BaseDataSourceView<Ticket, TicketKey> GetNewDataSourceView()
		{
			return new TicketDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketDataSourceView : ProviderDataSourceView<Ticket, TicketKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketDataSourceView(TicketDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketDataSource TicketOwner
		{
			get { return Owner as TicketDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketSelectMethod SelectMethod
		{
			get { return TicketOwner.SelectMethod; }
			set { TicketOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketService TicketProvider
		{
			get { return Provider as TicketService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Ticket> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Ticket> results = null;
			Ticket item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;
			System.String _wholesalerId_nullable;
			System.Int32 _ticketProductId;
			System.Int32 _statusId;
			System.Int32 _ticketPriorityId;
			System.Int32 _ticketCategoryId;
			System.Int32 _moderatorId;

			switch ( SelectMethod )
			{
				case TicketSelectMethod.Get:
					TicketKey entityKey  = new TicketKey();
					entityKey.Load(values);
					item = TicketProvider.Get(entityKey);
					results = new TList<Ticket>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketSelectMethod.GetAll:
                    results = TicketProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketSelectMethod.GetPaged:
					results = TicketProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketSelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TicketProvider.GetById(_id);
					results = new TList<Ticket>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case TicketSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByWholesalerId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = TicketProvider.GetByWholesalerId(_wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByTicketProductId:
					_ticketProductId = ( values["TicketProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TicketProductId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByTicketProductId(_ticketProductId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByStatusId:
					_statusId = ( values["StatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StatusId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByStatusId(_statusId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByTicketPriorityId:
					_ticketPriorityId = ( values["TicketPriorityId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TicketPriorityId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByTicketPriorityId(_ticketPriorityId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByTicketCategoryId:
					_ticketCategoryId = ( values["TicketCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TicketCategoryId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByTicketCategoryId(_ticketCategoryId, this.StartIndex, this.PageSize, out count);
					break;
				case TicketSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = TicketProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TicketSelectMethod.Get || SelectMethod == TicketSelectMethod.GetById )
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
				Ticket entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Ticket> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketDataSource class.
	/// </summary>
	public class TicketDataSourceDesigner : ProviderDataSourceDesigner<Ticket, TicketKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketDataSourceDesigner class.
		/// </summary>
		public TicketDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketSelectMethod SelectMethod
		{
			get { return ((TicketDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketDataSourceActionList

	/// <summary>
	/// Supports the TicketDataSourceDesigner class.
	/// </summary>
	internal class TicketDataSourceActionList : DesignerActionList
	{
		private TicketDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketDataSourceActionList(TicketDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketSelectMethod SelectMethod
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

	#endregion TicketDataSourceActionList
	
	#endregion TicketDataSourceDesigner
	
	#region TicketSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketDataSource.SelectMethod property.
	/// </summary>
	public enum TicketSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByTicketProductId method.
		/// </summary>
		GetByTicketProductId,
		/// <summary>
		/// Represents the GetByStatusId method.
		/// </summary>
		GetByStatusId,
		/// <summary>
		/// Represents the GetByTicketPriorityId method.
		/// </summary>
		GetByTicketPriorityId,
		/// <summary>
		/// Represents the GetByTicketCategoryId method.
		/// </summary>
		GetByTicketCategoryId,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId
	}
	
	#endregion TicketSelectMethod

	#region TicketFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketFilter : SqlFilter<TicketColumn>
	{
	}
	
	#endregion TicketFilter

	#region TicketExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketExpressionBuilder : SqlExpressionBuilder<TicketColumn>
	{
	}
	
	#endregion TicketExpressionBuilder	

	#region TicketProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProperty : ChildEntityProperty<TicketChildEntityTypes>
	{
	}
	
	#endregion TicketProperty
}

