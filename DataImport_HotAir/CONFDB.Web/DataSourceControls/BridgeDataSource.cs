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
	/// Represents the DataRepository.BridgeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BridgeDataSourceDesigner))]
	public class BridgeDataSource : ProviderDataSource<Bridge, BridgeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeDataSource class.
		/// </summary>
		public BridgeDataSource() : base(new BridgeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BridgeDataSourceView used by the BridgeDataSource.
		/// </summary>
		protected BridgeDataSourceView BridgeView
		{
			get { return ( View as BridgeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BridgeDataSource control invokes to retrieve data.
		/// </summary>
		public BridgeSelectMethod SelectMethod
		{
			get
			{
				BridgeSelectMethod selectMethod = BridgeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BridgeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BridgeDataSourceView class that is to be
		/// used by the BridgeDataSource.
		/// </summary>
		/// <returns>An instance of the BridgeDataSourceView class.</returns>
		protected override BaseDataSourceView<Bridge, BridgeKey> GetNewDataSourceView()
		{
			return new BridgeDataSourceView(this, DefaultViewName);
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
	/// Supports the BridgeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BridgeDataSourceView : ProviderDataSourceView<Bridge, BridgeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BridgeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BridgeDataSourceView(BridgeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BridgeDataSource BridgeOwner
		{
			get { return Owner as BridgeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BridgeSelectMethod SelectMethod
		{
			get { return BridgeOwner.SelectMethod; }
			set { BridgeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BridgeService BridgeProvider
		{
			get { return Provider as BridgeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Bridge> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Bridge> results = null;
			Bridge item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _bridgeTypeId;

			switch ( SelectMethod )
			{
				case BridgeSelectMethod.Get:
					BridgeKey entityKey  = new BridgeKey();
					entityKey.Load(values);
					item = BridgeProvider.Get(entityKey);
					results = new TList<Bridge>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BridgeSelectMethod.GetAll:
                    results = BridgeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BridgeSelectMethod.GetPaged:
					results = BridgeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BridgeSelectMethod.Find:
					if ( FilterParameters != null )
						results = BridgeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BridgeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BridgeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = BridgeProvider.GetById(_id);
					results = new TList<Bridge>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case BridgeSelectMethod.GetByBridgeTypeId:
					_bridgeTypeId = ( values["BridgeTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BridgeTypeId"], typeof(System.Int32)) : (int)0;
					results = BridgeProvider.GetByBridgeTypeId(_bridgeTypeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BridgeSelectMethod.Get || SelectMethod == BridgeSelectMethod.GetById )
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
				Bridge entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BridgeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Bridge> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BridgeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BridgeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BridgeDataSource class.
	/// </summary>
	public class BridgeDataSourceDesigner : ProviderDataSourceDesigner<Bridge, BridgeKey>
	{
		/// <summary>
		/// Initializes a new instance of the BridgeDataSourceDesigner class.
		/// </summary>
		public BridgeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeSelectMethod SelectMethod
		{
			get { return ((BridgeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BridgeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BridgeDataSourceActionList

	/// <summary>
	/// Supports the BridgeDataSourceDesigner class.
	/// </summary>
	internal class BridgeDataSourceActionList : DesignerActionList
	{
		private BridgeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BridgeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BridgeDataSourceActionList(BridgeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeSelectMethod SelectMethod
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

	#endregion BridgeDataSourceActionList
	
	#endregion BridgeDataSourceDesigner
	
	#region BridgeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BridgeDataSource.SelectMethod property.
	/// </summary>
	public enum BridgeSelectMethod
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
		/// Represents the GetByBridgeTypeId method.
		/// </summary>
		GetByBridgeTypeId
	}
	
	#endregion BridgeSelectMethod

	#region BridgeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeFilter : SqlFilter<BridgeColumn>
	{
	}
	
	#endregion BridgeFilter

	#region BridgeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeExpressionBuilder : SqlExpressionBuilder<BridgeColumn>
	{
	}
	
	#endregion BridgeExpressionBuilder	

	#region BridgeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BridgeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeProperty : ChildEntityProperty<BridgeChildEntityTypes>
	{
	}
	
	#endregion BridgeProperty
}

