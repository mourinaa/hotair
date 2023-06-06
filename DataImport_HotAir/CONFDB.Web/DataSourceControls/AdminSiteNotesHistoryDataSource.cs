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
	/// Represents the DataRepository.AdminSiteNotesHistoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminSiteNotesHistoryDataSourceDesigner))]
	public class AdminSiteNotesHistoryDataSource : ProviderDataSource<AdminSiteNotesHistory, AdminSiteNotesHistoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryDataSource class.
		/// </summary>
		public AdminSiteNotesHistoryDataSource() : base(new AdminSiteNotesHistoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminSiteNotesHistoryDataSourceView used by the AdminSiteNotesHistoryDataSource.
		/// </summary>
		protected AdminSiteNotesHistoryDataSourceView AdminSiteNotesHistoryView
		{
			get { return ( View as AdminSiteNotesHistoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminSiteNotesHistoryDataSource control invokes to retrieve data.
		/// </summary>
		public AdminSiteNotesHistorySelectMethod SelectMethod
		{
			get
			{
				AdminSiteNotesHistorySelectMethod selectMethod = AdminSiteNotesHistorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminSiteNotesHistorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminSiteNotesHistoryDataSourceView class that is to be
		/// used by the AdminSiteNotesHistoryDataSource.
		/// </summary>
		/// <returns>An instance of the AdminSiteNotesHistoryDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminSiteNotesHistory, AdminSiteNotesHistoryKey> GetNewDataSourceView()
		{
			return new AdminSiteNotesHistoryDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminSiteNotesHistoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminSiteNotesHistoryDataSourceView : ProviderDataSourceView<AdminSiteNotesHistory, AdminSiteNotesHistoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminSiteNotesHistoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminSiteNotesHistoryDataSourceView(AdminSiteNotesHistoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminSiteNotesHistoryDataSource AdminSiteNotesHistoryOwner
		{
			get { return Owner as AdminSiteNotesHistoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminSiteNotesHistorySelectMethod SelectMethod
		{
			get { return AdminSiteNotesHistoryOwner.SelectMethod; }
			set { AdminSiteNotesHistoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminSiteNotesHistoryService AdminSiteNotesHistoryProvider
		{
			get { return Provider as AdminSiteNotesHistoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminSiteNotesHistory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminSiteNotesHistory> results = null;
			AdminSiteNotesHistory item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _adminSiteNotesId_nullable;

			switch ( SelectMethod )
			{
				case AdminSiteNotesHistorySelectMethod.Get:
					AdminSiteNotesHistoryKey entityKey  = new AdminSiteNotesHistoryKey();
					entityKey.Load(values);
					item = AdminSiteNotesHistoryProvider.Get(entityKey);
					results = new TList<AdminSiteNotesHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminSiteNotesHistorySelectMethod.GetAll:
                    results = AdminSiteNotesHistoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdminSiteNotesHistorySelectMethod.GetPaged:
					results = AdminSiteNotesHistoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminSiteNotesHistorySelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminSiteNotesHistoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminSiteNotesHistoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminSiteNotesHistorySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = AdminSiteNotesHistoryProvider.GetById(_id);
					results = new TList<AdminSiteNotesHistory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AdminSiteNotesHistorySelectMethod.GetByAdminSiteNotesId:
					_adminSiteNotesId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdminSiteNotesId"], typeof(System.Int32?));
					results = AdminSiteNotesHistoryProvider.GetByAdminSiteNotesId(_adminSiteNotesId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdminSiteNotesHistorySelectMethod.Get || SelectMethod == AdminSiteNotesHistorySelectMethod.GetById )
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
				AdminSiteNotesHistory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdminSiteNotesHistoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminSiteNotesHistory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdminSiteNotesHistoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminSiteNotesHistoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminSiteNotesHistoryDataSource class.
	/// </summary>
	public class AdminSiteNotesHistoryDataSourceDesigner : ProviderDataSourceDesigner<AdminSiteNotesHistory, AdminSiteNotesHistoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryDataSourceDesigner class.
		/// </summary>
		public AdminSiteNotesHistoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminSiteNotesHistorySelectMethod SelectMethod
		{
			get { return ((AdminSiteNotesHistoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminSiteNotesHistoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminSiteNotesHistoryDataSourceActionList

	/// <summary>
	/// Supports the AdminSiteNotesHistoryDataSourceDesigner class.
	/// </summary>
	internal class AdminSiteNotesHistoryDataSourceActionList : DesignerActionList
	{
		private AdminSiteNotesHistoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminSiteNotesHistoryDataSourceActionList(AdminSiteNotesHistoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminSiteNotesHistorySelectMethod SelectMethod
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

	#endregion AdminSiteNotesHistoryDataSourceActionList
	
	#endregion AdminSiteNotesHistoryDataSourceDesigner
	
	#region AdminSiteNotesHistorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminSiteNotesHistoryDataSource.SelectMethod property.
	/// </summary>
	public enum AdminSiteNotesHistorySelectMethod
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
		/// Represents the GetByAdminSiteNotesId method.
		/// </summary>
		GetByAdminSiteNotesId
	}
	
	#endregion AdminSiteNotesHistorySelectMethod

	#region AdminSiteNotesHistoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryFilter : SqlFilter<AdminSiteNotesHistoryColumn>
	{
	}
	
	#endregion AdminSiteNotesHistoryFilter

	#region AdminSiteNotesHistoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryExpressionBuilder : SqlExpressionBuilder<AdminSiteNotesHistoryColumn>
	{
	}
	
	#endregion AdminSiteNotesHistoryExpressionBuilder	

	#region AdminSiteNotesHistoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminSiteNotesHistoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryProperty : ChildEntityProperty<AdminSiteNotesHistoryChildEntityTypes>
	{
	}
	
	#endregion AdminSiteNotesHistoryProperty
}

