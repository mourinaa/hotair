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
	/// Represents the DataRepository.BridgeRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BridgeRequestDataSourceDesigner))]
	public class BridgeRequestDataSource : ProviderDataSource<BridgeRequest, BridgeRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestDataSource class.
		/// </summary>
		public BridgeRequestDataSource() : base(new BridgeRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BridgeRequestDataSourceView used by the BridgeRequestDataSource.
		/// </summary>
		protected BridgeRequestDataSourceView BridgeRequestView
		{
			get { return ( View as BridgeRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BridgeRequestDataSource control invokes to retrieve data.
		/// </summary>
		public BridgeRequestSelectMethod SelectMethod
		{
			get
			{
				BridgeRequestSelectMethod selectMethod = BridgeRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BridgeRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BridgeRequestDataSourceView class that is to be
		/// used by the BridgeRequestDataSource.
		/// </summary>
		/// <returns>An instance of the BridgeRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<BridgeRequest, BridgeRequestKey> GetNewDataSourceView()
		{
			return new BridgeRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the BridgeRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BridgeRequestDataSourceView : ProviderDataSourceView<BridgeRequest, BridgeRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BridgeRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BridgeRequestDataSourceView(BridgeRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BridgeRequestDataSource BridgeRequestOwner
		{
			get { return Owner as BridgeRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BridgeRequestSelectMethod SelectMethod
		{
			get { return BridgeRequestOwner.SelectMethod; }
			set { BridgeRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BridgeRequestService BridgeRequestProvider
		{
			get { return Provider as BridgeRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BridgeRequest> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BridgeRequest> results = null;
			BridgeRequest item;
			count = 0;
			
			System.Guid _id;
			System.Int32 _moderatorId;
			System.String _processFlag;
			System.Int32? _bridgeRequestTypeId_nullable;

			switch ( SelectMethod )
			{
				case BridgeRequestSelectMethod.Get:
					BridgeRequestKey entityKey  = new BridgeRequestKey();
					entityKey.Load(values);
					item = BridgeRequestProvider.Get(entityKey);
					results = new TList<BridgeRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BridgeRequestSelectMethod.GetAll:
                    results = BridgeRequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BridgeRequestSelectMethod.GetPaged:
					results = BridgeRequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BridgeRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = BridgeRequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BridgeRequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BridgeRequestSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.NewGuid();
					item = BridgeRequestProvider.GetById(_id);
					results = new TList<BridgeRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case BridgeRequestSelectMethod.GetByModeratorIdProcessFlag:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					_processFlag = ( values["ProcessFlag"] != null ) ? (System.String) EntityUtil.ChangeType(values["ProcessFlag"], typeof(System.String)) : string.Empty;
					results = BridgeRequestProvider.GetByModeratorIdProcessFlag(_moderatorId, _processFlag, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case BridgeRequestSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = BridgeRequestProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case BridgeRequestSelectMethod.GetByBridgeRequestTypeId:
					_bridgeRequestTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["BridgeRequestTypeId"], typeof(System.Int32?));
					results = BridgeRequestProvider.GetByBridgeRequestTypeId(_bridgeRequestTypeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BridgeRequestSelectMethod.Get || SelectMethod == BridgeRequestSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(BridgeRequest entity)
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
				BridgeRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BridgeRequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BridgeRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BridgeRequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BridgeRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BridgeRequestDataSource class.
	/// </summary>
	public class BridgeRequestDataSourceDesigner : ProviderDataSourceDesigner<BridgeRequest, BridgeRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the BridgeRequestDataSourceDesigner class.
		/// </summary>
		public BridgeRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeRequestSelectMethod SelectMethod
		{
			get { return ((BridgeRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BridgeRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BridgeRequestDataSourceActionList

	/// <summary>
	/// Supports the BridgeRequestDataSourceDesigner class.
	/// </summary>
	internal class BridgeRequestDataSourceActionList : DesignerActionList
	{
		private BridgeRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BridgeRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BridgeRequestDataSourceActionList(BridgeRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeRequestSelectMethod SelectMethod
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

	#endregion BridgeRequestDataSourceActionList
	
	#endregion BridgeRequestDataSourceDesigner
	
	#region BridgeRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BridgeRequestDataSource.SelectMethod property.
	/// </summary>
	public enum BridgeRequestSelectMethod
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
		/// Represents the GetByModeratorIdProcessFlag method.
		/// </summary>
		GetByModeratorIdProcessFlag,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByBridgeRequestTypeId method.
		/// </summary>
		GetByBridgeRequestTypeId
	}
	
	#endregion BridgeRequestSelectMethod

	#region BridgeRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestFilter : SqlFilter<BridgeRequestColumn>
	{
	}
	
	#endregion BridgeRequestFilter

	#region BridgeRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestExpressionBuilder : SqlExpressionBuilder<BridgeRequestColumn>
	{
	}
	
	#endregion BridgeRequestExpressionBuilder	

	#region BridgeRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BridgeRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestProperty : ChildEntityProperty<BridgeRequestChildEntityTypes>
	{
	}
	
	#endregion BridgeRequestProperty
}

