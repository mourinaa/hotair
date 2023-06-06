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
	/// Represents the DataRepository.BridgeRequestTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BridgeRequestTypeDataSourceDesigner))]
	public class BridgeRequestTypeDataSource : ProviderDataSource<BridgeRequestType, BridgeRequestTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeDataSource class.
		/// </summary>
		public BridgeRequestTypeDataSource() : base(new BridgeRequestTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BridgeRequestTypeDataSourceView used by the BridgeRequestTypeDataSource.
		/// </summary>
		protected BridgeRequestTypeDataSourceView BridgeRequestTypeView
		{
			get { return ( View as BridgeRequestTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BridgeRequestTypeDataSource control invokes to retrieve data.
		/// </summary>
		public BridgeRequestTypeSelectMethod SelectMethod
		{
			get
			{
				BridgeRequestTypeSelectMethod selectMethod = BridgeRequestTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BridgeRequestTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BridgeRequestTypeDataSourceView class that is to be
		/// used by the BridgeRequestTypeDataSource.
		/// </summary>
		/// <returns>An instance of the BridgeRequestTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<BridgeRequestType, BridgeRequestTypeKey> GetNewDataSourceView()
		{
			return new BridgeRequestTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the BridgeRequestTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BridgeRequestTypeDataSourceView : ProviderDataSourceView<BridgeRequestType, BridgeRequestTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BridgeRequestTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BridgeRequestTypeDataSourceView(BridgeRequestTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BridgeRequestTypeDataSource BridgeRequestTypeOwner
		{
			get { return Owner as BridgeRequestTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BridgeRequestTypeSelectMethod SelectMethod
		{
			get { return BridgeRequestTypeOwner.SelectMethod; }
			set { BridgeRequestTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BridgeRequestTypeService BridgeRequestTypeProvider
		{
			get { return Provider as BridgeRequestTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BridgeRequestType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BridgeRequestType> results = null;
			BridgeRequestType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case BridgeRequestTypeSelectMethod.Get:
					BridgeRequestTypeKey entityKey  = new BridgeRequestTypeKey();
					entityKey.Load(values);
					item = BridgeRequestTypeProvider.Get(entityKey);
					results = new TList<BridgeRequestType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BridgeRequestTypeSelectMethod.GetAll:
                    results = BridgeRequestTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BridgeRequestTypeSelectMethod.GetPaged:
					results = BridgeRequestTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BridgeRequestTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = BridgeRequestTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BridgeRequestTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BridgeRequestTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = BridgeRequestTypeProvider.GetById(_id);
					results = new TList<BridgeRequestType>();
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
			if ( SelectMethod == BridgeRequestTypeSelectMethod.Get || SelectMethod == BridgeRequestTypeSelectMethod.GetById )
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
				BridgeRequestType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BridgeRequestTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BridgeRequestType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BridgeRequestTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BridgeRequestTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BridgeRequestTypeDataSource class.
	/// </summary>
	public class BridgeRequestTypeDataSourceDesigner : ProviderDataSourceDesigner<BridgeRequestType, BridgeRequestTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeDataSourceDesigner class.
		/// </summary>
		public BridgeRequestTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeRequestTypeSelectMethod SelectMethod
		{
			get { return ((BridgeRequestTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BridgeRequestTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BridgeRequestTypeDataSourceActionList

	/// <summary>
	/// Supports the BridgeRequestTypeDataSourceDesigner class.
	/// </summary>
	internal class BridgeRequestTypeDataSourceActionList : DesignerActionList
	{
		private BridgeRequestTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BridgeRequestTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BridgeRequestTypeDataSourceActionList(BridgeRequestTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeRequestTypeSelectMethod SelectMethod
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

	#endregion BridgeRequestTypeDataSourceActionList
	
	#endregion BridgeRequestTypeDataSourceDesigner
	
	#region BridgeRequestTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BridgeRequestTypeDataSource.SelectMethod property.
	/// </summary>
	public enum BridgeRequestTypeSelectMethod
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
	
	#endregion BridgeRequestTypeSelectMethod

	#region BridgeRequestTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequestType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestTypeFilter : SqlFilter<BridgeRequestTypeColumn>
	{
	}
	
	#endregion BridgeRequestTypeFilter

	#region BridgeRequestTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequestType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestTypeExpressionBuilder : SqlExpressionBuilder<BridgeRequestTypeColumn>
	{
	}
	
	#endregion BridgeRequestTypeExpressionBuilder	

	#region BridgeRequestTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BridgeRequestTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequestType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestTypeProperty : ChildEntityProperty<BridgeRequestTypeChildEntityTypes>
	{
	}
	
	#endregion BridgeRequestTypeProperty
}

