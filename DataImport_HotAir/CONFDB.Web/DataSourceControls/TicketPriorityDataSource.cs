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
	/// Represents the DataRepository.TicketPriorityProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketPriorityDataSourceDesigner))]
	public class TicketPriorityDataSource : ProviderDataSource<TicketPriority, TicketPriorityKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketPriorityDataSource class.
		/// </summary>
		public TicketPriorityDataSource() : base(new TicketPriorityService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketPriorityDataSourceView used by the TicketPriorityDataSource.
		/// </summary>
		protected TicketPriorityDataSourceView TicketPriorityView
		{
			get { return ( View as TicketPriorityDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketPriorityDataSource control invokes to retrieve data.
		/// </summary>
		public TicketPrioritySelectMethod SelectMethod
		{
			get
			{
				TicketPrioritySelectMethod selectMethod = TicketPrioritySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketPrioritySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketPriorityDataSourceView class that is to be
		/// used by the TicketPriorityDataSource.
		/// </summary>
		/// <returns>An instance of the TicketPriorityDataSourceView class.</returns>
		protected override BaseDataSourceView<TicketPriority, TicketPriorityKey> GetNewDataSourceView()
		{
			return new TicketPriorityDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketPriorityDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketPriorityDataSourceView : ProviderDataSourceView<TicketPriority, TicketPriorityKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketPriorityDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketPriorityDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketPriorityDataSourceView(TicketPriorityDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketPriorityDataSource TicketPriorityOwner
		{
			get { return Owner as TicketPriorityDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketPrioritySelectMethod SelectMethod
		{
			get { return TicketPriorityOwner.SelectMethod; }
			set { TicketPriorityOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketPriorityService TicketPriorityProvider
		{
			get { return Provider as TicketPriorityService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TicketPriority> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TicketPriority> results = null;
			TicketPriority item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TicketPrioritySelectMethod.Get:
					TicketPriorityKey entityKey  = new TicketPriorityKey();
					entityKey.Load(values);
					item = TicketPriorityProvider.Get(entityKey);
					results = new TList<TicketPriority>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketPrioritySelectMethod.GetAll:
                    results = TicketPriorityProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketPrioritySelectMethod.GetPaged:
					results = TicketPriorityProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketPrioritySelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketPriorityProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketPriorityProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketPrioritySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TicketPriorityProvider.GetById(_id);
					results = new TList<TicketPriority>();
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
			if ( SelectMethod == TicketPrioritySelectMethod.Get || SelectMethod == TicketPrioritySelectMethod.GetById )
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
				TicketPriority entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketPriorityProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TicketPriority> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketPriorityProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketPriorityDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketPriorityDataSource class.
	/// </summary>
	public class TicketPriorityDataSourceDesigner : ProviderDataSourceDesigner<TicketPriority, TicketPriorityKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketPriorityDataSourceDesigner class.
		/// </summary>
		public TicketPriorityDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketPrioritySelectMethod SelectMethod
		{
			get { return ((TicketPriorityDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketPriorityDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketPriorityDataSourceActionList

	/// <summary>
	/// Supports the TicketPriorityDataSourceDesigner class.
	/// </summary>
	internal class TicketPriorityDataSourceActionList : DesignerActionList
	{
		private TicketPriorityDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketPriorityDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketPriorityDataSourceActionList(TicketPriorityDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketPrioritySelectMethod SelectMethod
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

	#endregion TicketPriorityDataSourceActionList
	
	#endregion TicketPriorityDataSourceDesigner
	
	#region TicketPrioritySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketPriorityDataSource.SelectMethod property.
	/// </summary>
	public enum TicketPrioritySelectMethod
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
	
	#endregion TicketPrioritySelectMethod

	#region TicketPriorityFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketPriority"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketPriorityFilter : SqlFilter<TicketPriorityColumn>
	{
	}
	
	#endregion TicketPriorityFilter

	#region TicketPriorityExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketPriority"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketPriorityExpressionBuilder : SqlExpressionBuilder<TicketPriorityColumn>
	{
	}
	
	#endregion TicketPriorityExpressionBuilder	

	#region TicketPriorityProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketPriorityChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TicketPriority"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketPriorityProperty : ChildEntityProperty<TicketPriorityChildEntityTypes>
	{
	}
	
	#endregion TicketPriorityProperty
}

