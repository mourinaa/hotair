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
	/// Represents the DataRepository.BridgeTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BridgeTypeDataSourceDesigner))]
	public class BridgeTypeDataSource : ProviderDataSource<BridgeType, BridgeTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeTypeDataSource class.
		/// </summary>
		public BridgeTypeDataSource() : base(new BridgeTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BridgeTypeDataSourceView used by the BridgeTypeDataSource.
		/// </summary>
		protected BridgeTypeDataSourceView BridgeTypeView
		{
			get { return ( View as BridgeTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BridgeTypeDataSource control invokes to retrieve data.
		/// </summary>
		public BridgeTypeSelectMethod SelectMethod
		{
			get
			{
				BridgeTypeSelectMethod selectMethod = BridgeTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BridgeTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BridgeTypeDataSourceView class that is to be
		/// used by the BridgeTypeDataSource.
		/// </summary>
		/// <returns>An instance of the BridgeTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<BridgeType, BridgeTypeKey> GetNewDataSourceView()
		{
			return new BridgeTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the BridgeTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BridgeTypeDataSourceView : ProviderDataSourceView<BridgeType, BridgeTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BridgeTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BridgeTypeDataSourceView(BridgeTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BridgeTypeDataSource BridgeTypeOwner
		{
			get { return Owner as BridgeTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BridgeTypeSelectMethod SelectMethod
		{
			get { return BridgeTypeOwner.SelectMethod; }
			set { BridgeTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BridgeTypeService BridgeTypeProvider
		{
			get { return Provider as BridgeTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BridgeType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BridgeType> results = null;
			BridgeType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case BridgeTypeSelectMethod.Get:
					BridgeTypeKey entityKey  = new BridgeTypeKey();
					entityKey.Load(values);
					item = BridgeTypeProvider.Get(entityKey);
					results = new TList<BridgeType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BridgeTypeSelectMethod.GetAll:
                    results = BridgeTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BridgeTypeSelectMethod.GetPaged:
					results = BridgeTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BridgeTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = BridgeTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BridgeTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BridgeTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = BridgeTypeProvider.GetById(_id);
					results = new TList<BridgeType>();
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
			if ( SelectMethod == BridgeTypeSelectMethod.Get || SelectMethod == BridgeTypeSelectMethod.GetById )
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
				BridgeType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BridgeTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BridgeType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BridgeTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BridgeTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BridgeTypeDataSource class.
	/// </summary>
	public class BridgeTypeDataSourceDesigner : ProviderDataSourceDesigner<BridgeType, BridgeTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the BridgeTypeDataSourceDesigner class.
		/// </summary>
		public BridgeTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeTypeSelectMethod SelectMethod
		{
			get { return ((BridgeTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BridgeTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BridgeTypeDataSourceActionList

	/// <summary>
	/// Supports the BridgeTypeDataSourceDesigner class.
	/// </summary>
	internal class BridgeTypeDataSourceActionList : DesignerActionList
	{
		private BridgeTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BridgeTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BridgeTypeDataSourceActionList(BridgeTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BridgeTypeSelectMethod SelectMethod
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

	#endregion BridgeTypeDataSourceActionList
	
	#endregion BridgeTypeDataSourceDesigner
	
	#region BridgeTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BridgeTypeDataSource.SelectMethod property.
	/// </summary>
	public enum BridgeTypeSelectMethod
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
	
	#endregion BridgeTypeSelectMethod

	#region BridgeTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeTypeFilter : SqlFilter<BridgeTypeColumn>
	{
	}
	
	#endregion BridgeTypeFilter

	#region BridgeTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeTypeExpressionBuilder : SqlExpressionBuilder<BridgeTypeColumn>
	{
	}
	
	#endregion BridgeTypeExpressionBuilder	

	#region BridgeTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BridgeTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeTypeProperty : ChildEntityProperty<BridgeTypeChildEntityTypes>
	{
	}
	
	#endregion BridgeTypeProperty
}

