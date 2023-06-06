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
	/// Represents the DataRepository.WelcomeKitRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WelcomeKitRequestDataSourceDesigner))]
	public class WelcomeKitRequestDataSource : ProviderDataSource<WelcomeKitRequest, WelcomeKitRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestDataSource class.
		/// </summary>
		public WelcomeKitRequestDataSource() : base(new WelcomeKitRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WelcomeKitRequestDataSourceView used by the WelcomeKitRequestDataSource.
		/// </summary>
		protected WelcomeKitRequestDataSourceView WelcomeKitRequestView
		{
			get { return ( View as WelcomeKitRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WelcomeKitRequestDataSource control invokes to retrieve data.
		/// </summary>
		public WelcomeKitRequestSelectMethod SelectMethod
		{
			get
			{
				WelcomeKitRequestSelectMethod selectMethod = WelcomeKitRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WelcomeKitRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WelcomeKitRequestDataSourceView class that is to be
		/// used by the WelcomeKitRequestDataSource.
		/// </summary>
		/// <returns>An instance of the WelcomeKitRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<WelcomeKitRequest, WelcomeKitRequestKey> GetNewDataSourceView()
		{
			return new WelcomeKitRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the WelcomeKitRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WelcomeKitRequestDataSourceView : ProviderDataSourceView<WelcomeKitRequest, WelcomeKitRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WelcomeKitRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WelcomeKitRequestDataSourceView(WelcomeKitRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WelcomeKitRequestDataSource WelcomeKitRequestOwner
		{
			get { return Owner as WelcomeKitRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WelcomeKitRequestSelectMethod SelectMethod
		{
			get { return WelcomeKitRequestOwner.SelectMethod; }
			set { WelcomeKitRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WelcomeKitRequestService WelcomeKitRequestProvider
		{
			get { return Provider as WelcomeKitRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WelcomeKitRequest> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WelcomeKitRequest> results = null;
			WelcomeKitRequest item;
			count = 0;
			
			System.Int32 _id;
			System.DateTime _createdDate;
			System.Int32 _moderatorId;

			switch ( SelectMethod )
			{
				case WelcomeKitRequestSelectMethod.Get:
					WelcomeKitRequestKey entityKey  = new WelcomeKitRequestKey();
					entityKey.Load(values);
					item = WelcomeKitRequestProvider.Get(entityKey);
					results = new TList<WelcomeKitRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WelcomeKitRequestSelectMethod.GetAll:
                    results = WelcomeKitRequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WelcomeKitRequestSelectMethod.GetPaged:
					results = WelcomeKitRequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WelcomeKitRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = WelcomeKitRequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WelcomeKitRequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WelcomeKitRequestSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = WelcomeKitRequestProvider.GetById(_id);
					results = new TList<WelcomeKitRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case WelcomeKitRequestSelectMethod.GetByCreatedDate:
					_createdDate = ( values["CreatedDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["CreatedDate"], typeof(System.DateTime)) : DateTime.Now;
					results = WelcomeKitRequestProvider.GetByCreatedDate(_createdDate, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case WelcomeKitRequestSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = WelcomeKitRequestProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WelcomeKitRequestSelectMethod.Get || SelectMethod == WelcomeKitRequestSelectMethod.GetById )
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
				WelcomeKitRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WelcomeKitRequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WelcomeKitRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WelcomeKitRequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WelcomeKitRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WelcomeKitRequestDataSource class.
	/// </summary>
	public class WelcomeKitRequestDataSourceDesigner : ProviderDataSourceDesigner<WelcomeKitRequest, WelcomeKitRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestDataSourceDesigner class.
		/// </summary>
		public WelcomeKitRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WelcomeKitRequestSelectMethod SelectMethod
		{
			get { return ((WelcomeKitRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WelcomeKitRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WelcomeKitRequestDataSourceActionList

	/// <summary>
	/// Supports the WelcomeKitRequestDataSourceDesigner class.
	/// </summary>
	internal class WelcomeKitRequestDataSourceActionList : DesignerActionList
	{
		private WelcomeKitRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WelcomeKitRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WelcomeKitRequestDataSourceActionList(WelcomeKitRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WelcomeKitRequestSelectMethod SelectMethod
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

	#endregion WelcomeKitRequestDataSourceActionList
	
	#endregion WelcomeKitRequestDataSourceDesigner
	
	#region WelcomeKitRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WelcomeKitRequestDataSource.SelectMethod property.
	/// </summary>
	public enum WelcomeKitRequestSelectMethod
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
		/// Represents the GetByCreatedDate method.
		/// </summary>
		GetByCreatedDate,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId
	}
	
	#endregion WelcomeKitRequestSelectMethod

	#region WelcomeKitRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WelcomeKitRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WelcomeKitRequestFilter : SqlFilter<WelcomeKitRequestColumn>
	{
	}
	
	#endregion WelcomeKitRequestFilter

	#region WelcomeKitRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WelcomeKitRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WelcomeKitRequestExpressionBuilder : SqlExpressionBuilder<WelcomeKitRequestColumn>
	{
	}
	
	#endregion WelcomeKitRequestExpressionBuilder	

	#region WelcomeKitRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WelcomeKitRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WelcomeKitRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WelcomeKitRequestProperty : ChildEntityProperty<WelcomeKitRequestChildEntityTypes>
	{
	}
	
	#endregion WelcomeKitRequestProperty
}

