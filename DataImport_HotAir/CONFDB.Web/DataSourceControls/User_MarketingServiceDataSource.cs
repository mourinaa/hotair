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
	/// Represents the DataRepository.User_MarketingServiceProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(User_MarketingServiceDataSourceDesigner))]
	public class User_MarketingServiceDataSource : ProviderDataSource<User_MarketingService, User_MarketingServiceKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceDataSource class.
		/// </summary>
		public User_MarketingServiceDataSource() : base(new User_MarketingServiceService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the User_MarketingServiceDataSourceView used by the User_MarketingServiceDataSource.
		/// </summary>
		protected User_MarketingServiceDataSourceView User_MarketingServiceView
		{
			get { return ( View as User_MarketingServiceDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the User_MarketingServiceDataSource control invokes to retrieve data.
		/// </summary>
		public User_MarketingServiceSelectMethod SelectMethod
		{
			get
			{
				User_MarketingServiceSelectMethod selectMethod = User_MarketingServiceSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (User_MarketingServiceSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the User_MarketingServiceDataSourceView class that is to be
		/// used by the User_MarketingServiceDataSource.
		/// </summary>
		/// <returns>An instance of the User_MarketingServiceDataSourceView class.</returns>
		protected override BaseDataSourceView<User_MarketingService, User_MarketingServiceKey> GetNewDataSourceView()
		{
			return new User_MarketingServiceDataSourceView(this, DefaultViewName);
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
	/// Supports the User_MarketingServiceDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class User_MarketingServiceDataSourceView : ProviderDataSourceView<User_MarketingService, User_MarketingServiceKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the User_MarketingServiceDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public User_MarketingServiceDataSourceView(User_MarketingServiceDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal User_MarketingServiceDataSource User_MarketingServiceOwner
		{
			get { return Owner as User_MarketingServiceDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal User_MarketingServiceSelectMethod SelectMethod
		{
			get { return User_MarketingServiceOwner.SelectMethod; }
			set { User_MarketingServiceOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal User_MarketingServiceService User_MarketingServiceProvider
		{
			get { return Provider as User_MarketingServiceService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<User_MarketingService> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<User_MarketingService> results = null;
			User_MarketingService item;
			count = 0;
			
			System.Int32 _marketingServiceId;
			System.Int32 _userId;

			switch ( SelectMethod )
			{
				case User_MarketingServiceSelectMethod.Get:
					User_MarketingServiceKey entityKey  = new User_MarketingServiceKey();
					entityKey.Load(values);
					item = User_MarketingServiceProvider.Get(entityKey);
					results = new TList<User_MarketingService>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case User_MarketingServiceSelectMethod.GetAll:
                    results = User_MarketingServiceProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case User_MarketingServiceSelectMethod.GetPaged:
					results = User_MarketingServiceProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case User_MarketingServiceSelectMethod.Find:
					if ( FilterParameters != null )
						results = User_MarketingServiceProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = User_MarketingServiceProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case User_MarketingServiceSelectMethod.GetByMarketingServiceIdUserId:
					_marketingServiceId = ( values["MarketingServiceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MarketingServiceId"], typeof(System.Int32)) : (int)0;
					_userId = ( values["UserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32)) : (int)0;
					item = User_MarketingServiceProvider.GetByMarketingServiceIdUserId(_marketingServiceId, _userId);
					results = new TList<User_MarketingService>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case User_MarketingServiceSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32)) : (int)0;
					results = User_MarketingServiceProvider.GetByUserId(_userId, this.StartIndex, this.PageSize, out count);
					break;
				case User_MarketingServiceSelectMethod.GetByMarketingServiceId:
					_marketingServiceId = ( values["MarketingServiceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MarketingServiceId"], typeof(System.Int32)) : (int)0;
					results = User_MarketingServiceProvider.GetByMarketingServiceId(_marketingServiceId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == User_MarketingServiceSelectMethod.Get || SelectMethod == User_MarketingServiceSelectMethod.GetByMarketingServiceIdUserId )
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
				User_MarketingService entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					User_MarketingServiceProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<User_MarketingService> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			User_MarketingServiceProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region User_MarketingServiceDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the User_MarketingServiceDataSource class.
	/// </summary>
	public class User_MarketingServiceDataSourceDesigner : ProviderDataSourceDesigner<User_MarketingService, User_MarketingServiceKey>
	{
		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceDataSourceDesigner class.
		/// </summary>
		public User_MarketingServiceDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public User_MarketingServiceSelectMethod SelectMethod
		{
			get { return ((User_MarketingServiceDataSource) DataSource).SelectMethod; }
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
				actions.Add(new User_MarketingServiceDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region User_MarketingServiceDataSourceActionList

	/// <summary>
	/// Supports the User_MarketingServiceDataSourceDesigner class.
	/// </summary>
	internal class User_MarketingServiceDataSourceActionList : DesignerActionList
	{
		private User_MarketingServiceDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public User_MarketingServiceDataSourceActionList(User_MarketingServiceDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public User_MarketingServiceSelectMethod SelectMethod
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

	#endregion User_MarketingServiceDataSourceActionList
	
	#endregion User_MarketingServiceDataSourceDesigner
	
	#region User_MarketingServiceSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the User_MarketingServiceDataSource.SelectMethod property.
	/// </summary>
	public enum User_MarketingServiceSelectMethod
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
		/// Represents the GetByMarketingServiceIdUserId method.
		/// </summary>
		GetByMarketingServiceIdUserId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByMarketingServiceId method.
		/// </summary>
		GetByMarketingServiceId
	}
	
	#endregion User_MarketingServiceSelectMethod

	#region User_MarketingServiceFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceFilter : SqlFilter<User_MarketingServiceColumn>
	{
	}
	
	#endregion User_MarketingServiceFilter

	#region User_MarketingServiceExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceExpressionBuilder : SqlExpressionBuilder<User_MarketingServiceColumn>
	{
	}
	
	#endregion User_MarketingServiceExpressionBuilder	

	#region User_MarketingServiceProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;User_MarketingServiceChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceProperty : ChildEntityProperty<User_MarketingServiceChildEntityTypes>
	{
	}
	
	#endregion User_MarketingServiceProperty
}

