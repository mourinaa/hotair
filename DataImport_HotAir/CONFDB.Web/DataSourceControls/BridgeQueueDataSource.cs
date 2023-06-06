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
	/// Represents the DataRepository.BridgeQueueProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BridgeQueueDataSourceDesigner))]
	public class BridgeQueueDataSource : ProviderDataSource<BridgeQueue, BridgeQueueKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueDataSource class.
		/// </summary>
		public BridgeQueueDataSource() : base(new BridgeQueueService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BridgeQueueDataSourceView used by the BridgeQueueDataSource.
		/// </summary>
		protected BridgeQueueDataSourceView BridgeQueueView
		{
			get { return ( View as BridgeQueueDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BridgeQueueDataSource control invokes to retrieve data.
		/// </summary>
		public BridgeQueueSelectMethod SelectMethod
		{
			get
			{
				BridgeQueueSelectMethod selectMethod = BridgeQueueSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BridgeQueueSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BridgeQueueDataSourceView class that is to be
		/// used by the BridgeQueueDataSource.
		/// </summary>
		/// <returns>An instance of the BridgeQueueDataSourceView class.</returns>
		protected override BaseDataSourceView<BridgeQueue, BridgeQueueKey> GetNewDataSourceView()
		{
			return new BridgeQueueDataSourceView(this, DefaultViewName);
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
	/// Supports the BridgeQueueDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BridgeQueueDataSourceView : ProviderDataSourceView<BridgeQueue, BridgeQueueKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BridgeQueueDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BridgeQueueDataSourceView(BridgeQueueDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BridgeQueueDataSource BridgeQueueOwner
		{
			get { return Owner as BridgeQueueDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BridgeQueueSelectMethod SelectMethod
		{
			get { return BridgeQueueOwner.SelectMethod; }
			set { BridgeQueueOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BridgeQueueService BridgeQueueProvider
		{
			get { return Provider as BridgeQueueService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BridgeQueue> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BridgeQueue> results = null;
			BridgeQueue item;
			count = 0;
			
			System.Guid _id;
			System.Int32 _bridgeId;
			System.Int32 _moderatorId;

			switch ( SelectMethod )
			{
				case BridgeQueueSelectMethod.Get:
					BridgeQueueKey entityKey  = new BridgeQueueKey();
					entityKey.Load(values);
					item = BridgeQueueProvider.Get(entityKey);
					results = new TList<BridgeQueue>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BridgeQueueSelectMethod.GetAll:
                    results = BridgeQueueProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BridgeQueueSelectMethod.GetPaged:
					results = BridgeQueueProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BridgeQueueSelectMethod.Find:
					if ( FilterParameters != null )
						results = BridgeQueueProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BridgeQueueProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BridgeQueueSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.NewGuid();
					item = BridgeQueueProvider.GetById(_id);
					results = new TList<BridgeQueue>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case BridgeQueueSelectMethod.GetByBridgeId:
					_bridgeId = ( values["BridgeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BridgeId"], typeof(System.Int32)) : (int)0;
					results = BridgeQueueProvider.GetByBridgeId(_bridgeId, this.StartIndex, this.PageSize, out count);
					break;
				case BridgeQueueSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = BridgeQueueProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BridgeQueueSelectMethod.Get || SelectMethod == BridgeQueueSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(BridgeQueue entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.Id == Guid.Empty )
				entity.Id = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				BridgeQueue entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BridgeQueueProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BridgeQueue> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BridgeQueueProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BridgeQueueDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BridgeQueueDataSource class.
	/// </summary>
	public class BridgeQueueDataSourceDesigner : ProviderDataSourceDesigner<BridgeQueue, BridgeQueueKey>
	{
		/// <summary>
		/// Initializes a new instance of the BridgeQueueDataSourceDesigner class.
		/// </summary>
		public BridgeQueueDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeQueueSelectMethod SelectMethod
		{
			get { return ((BridgeQueueDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BridgeQueueDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BridgeQueueDataSourceActionList

	/// <summary>
	/// Supports the BridgeQueueDataSourceDesigner class.
	/// </summary>
	internal class BridgeQueueDataSourceActionList : DesignerActionList
	{
		private BridgeQueueDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BridgeQueueDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BridgeQueueDataSourceActionList(BridgeQueueDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeQueueSelectMethod SelectMethod
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

	#endregion BridgeQueueDataSourceActionList
	
	#endregion BridgeQueueDataSourceDesigner
	
	#region BridgeQueueSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BridgeQueueDataSource.SelectMethod property.
	/// </summary>
	public enum BridgeQueueSelectMethod
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
		/// Represents the GetByBridgeId method.
		/// </summary>
		GetByBridgeId,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId
	}
	
	#endregion BridgeQueueSelectMethod

	#region BridgeQueueFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueFilter : SqlFilter<BridgeQueueColumn>
	{
	}
	
	#endregion BridgeQueueFilter

	#region BridgeQueueExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueExpressionBuilder : SqlExpressionBuilder<BridgeQueueColumn>
	{
	}
	
	#endregion BridgeQueueExpressionBuilder	

	#region BridgeQueueProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BridgeQueueChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueProperty : ChildEntityProperty<BridgeQueueChildEntityTypes>
	{
	}
	
	#endregion BridgeQueueProperty
}

