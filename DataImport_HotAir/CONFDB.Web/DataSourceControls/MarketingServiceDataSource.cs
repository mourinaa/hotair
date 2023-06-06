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
	/// Represents the DataRepository.MarketingServiceProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MarketingServiceDataSourceDesigner))]
	public class MarketingServiceDataSource : ProviderDataSource<MarketingService, MarketingServiceKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceDataSource class.
		/// </summary>
		public MarketingServiceDataSource() : base(new MarketingServiceService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MarketingServiceDataSourceView used by the MarketingServiceDataSource.
		/// </summary>
		protected MarketingServiceDataSourceView MarketingServiceView
		{
			get { return ( View as MarketingServiceDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MarketingServiceDataSource control invokes to retrieve data.
		/// </summary>
		public MarketingServiceSelectMethod SelectMethod
		{
			get
			{
				MarketingServiceSelectMethod selectMethod = MarketingServiceSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MarketingServiceSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MarketingServiceDataSourceView class that is to be
		/// used by the MarketingServiceDataSource.
		/// </summary>
		/// <returns>An instance of the MarketingServiceDataSourceView class.</returns>
		protected override BaseDataSourceView<MarketingService, MarketingServiceKey> GetNewDataSourceView()
		{
			return new MarketingServiceDataSourceView(this, DefaultViewName);
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
	/// Supports the MarketingServiceDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MarketingServiceDataSourceView : ProviderDataSourceView<MarketingService, MarketingServiceKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MarketingServiceDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MarketingServiceDataSourceView(MarketingServiceDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MarketingServiceDataSource MarketingServiceOwner
		{
			get { return Owner as MarketingServiceDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MarketingServiceSelectMethod SelectMethod
		{
			get { return MarketingServiceOwner.SelectMethod; }
			set { MarketingServiceOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MarketingServiceService MarketingServiceProvider
		{
			get { return Provider as MarketingServiceService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MarketingService> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MarketingService> results = null;
			MarketingService item;
			count = 0;
			
			System.Int32 _id;
			System.String _wholesalerId;
			System.Int32 _userId;

			switch ( SelectMethod )
			{
				case MarketingServiceSelectMethod.Get:
					MarketingServiceKey entityKey  = new MarketingServiceKey();
					entityKey.Load(values);
					item = MarketingServiceProvider.Get(entityKey);
					results = new TList<MarketingService>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MarketingServiceSelectMethod.GetAll:
                    results = MarketingServiceProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MarketingServiceSelectMethod.GetPaged:
					results = MarketingServiceProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MarketingServiceSelectMethod.Find:
					if ( FilterParameters != null )
						results = MarketingServiceProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MarketingServiceProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MarketingServiceSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = MarketingServiceProvider.GetById(_id);
					results = new TList<MarketingService>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MarketingServiceSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = MarketingServiceProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case MarketingServiceSelectMethod.GetByUserIdFromUser_MarketingService:
					_userId = ( values["UserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32)) : (int)0;
					results = MarketingServiceProvider.GetByUserIdFromUser_MarketingService(_userId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MarketingServiceSelectMethod.Get || SelectMethod == MarketingServiceSelectMethod.GetById )
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
				MarketingService entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MarketingServiceProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MarketingService> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MarketingServiceProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MarketingServiceDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MarketingServiceDataSource class.
	/// </summary>
	public class MarketingServiceDataSourceDesigner : ProviderDataSourceDesigner<MarketingService, MarketingServiceKey>
	{
		/// <summary>
		/// Initializes a new instance of the MarketingServiceDataSourceDesigner class.
		/// </summary>
		public MarketingServiceDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MarketingServiceSelectMethod SelectMethod
		{
			get { return ((MarketingServiceDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MarketingServiceDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MarketingServiceDataSourceActionList

	/// <summary>
	/// Supports the MarketingServiceDataSourceDesigner class.
	/// </summary>
	internal class MarketingServiceDataSourceActionList : DesignerActionList
	{
		private MarketingServiceDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MarketingServiceDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MarketingServiceDataSourceActionList(MarketingServiceDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MarketingServiceSelectMethod SelectMethod
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

	#endregion MarketingServiceDataSourceActionList
	
	#endregion MarketingServiceDataSourceDesigner
	
	#region MarketingServiceSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MarketingServiceDataSource.SelectMethod property.
	/// </summary>
	public enum MarketingServiceSelectMethod
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
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByUserIdFromUser_MarketingService method.
		/// </summary>
		GetByUserIdFromUser_MarketingService
	}
	
	#endregion MarketingServiceSelectMethod

	#region MarketingServiceFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceFilter : SqlFilter<MarketingServiceColumn>
	{
	}
	
	#endregion MarketingServiceFilter

	#region MarketingServiceExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceExpressionBuilder : SqlExpressionBuilder<MarketingServiceColumn>
	{
	}
	
	#endregion MarketingServiceExpressionBuilder	

	#region MarketingServiceProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MarketingServiceChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceProperty : ChildEntityProperty<MarketingServiceChildEntityTypes>
	{
	}
	
	#endregion MarketingServiceProperty
}

