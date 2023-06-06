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
	/// Represents the DataRepository.AdminSiteNotesTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminSiteNotesTypeDataSourceDesigner))]
	public class AdminSiteNotesTypeDataSource : ProviderDataSource<AdminSiteNotesType, AdminSiteNotesTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesTypeDataSource class.
		/// </summary>
		public AdminSiteNotesTypeDataSource() : base(new AdminSiteNotesTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminSiteNotesTypeDataSourceView used by the AdminSiteNotesTypeDataSource.
		/// </summary>
		protected AdminSiteNotesTypeDataSourceView AdminSiteNotesTypeView
		{
			get { return ( View as AdminSiteNotesTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminSiteNotesTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AdminSiteNotesTypeSelectMethod SelectMethod
		{
			get
			{
				AdminSiteNotesTypeSelectMethod selectMethod = AdminSiteNotesTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminSiteNotesTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminSiteNotesTypeDataSourceView class that is to be
		/// used by the AdminSiteNotesTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AdminSiteNotesTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminSiteNotesType, AdminSiteNotesTypeKey> GetNewDataSourceView()
		{
			return new AdminSiteNotesTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminSiteNotesTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminSiteNotesTypeDataSourceView : ProviderDataSourceView<AdminSiteNotesType, AdminSiteNotesTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminSiteNotesTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminSiteNotesTypeDataSourceView(AdminSiteNotesTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminSiteNotesTypeDataSource AdminSiteNotesTypeOwner
		{
			get { return Owner as AdminSiteNotesTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminSiteNotesTypeSelectMethod SelectMethod
		{
			get { return AdminSiteNotesTypeOwner.SelectMethod; }
			set { AdminSiteNotesTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminSiteNotesTypeService AdminSiteNotesTypeProvider
		{
			get { return Provider as AdminSiteNotesTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminSiteNotesType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminSiteNotesType> results = null;
			AdminSiteNotesType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case AdminSiteNotesTypeSelectMethod.Get:
					AdminSiteNotesTypeKey entityKey  = new AdminSiteNotesTypeKey();
					entityKey.Load(values);
					item = AdminSiteNotesTypeProvider.Get(entityKey);
					results = new TList<AdminSiteNotesType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminSiteNotesTypeSelectMethod.GetAll:
                    results = AdminSiteNotesTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdminSiteNotesTypeSelectMethod.GetPaged:
					results = AdminSiteNotesTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminSiteNotesTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminSiteNotesTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminSiteNotesTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminSiteNotesTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = AdminSiteNotesTypeProvider.GetById(_id);
					results = new TList<AdminSiteNotesType>();
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
			if ( SelectMethod == AdminSiteNotesTypeSelectMethod.Get || SelectMethod == AdminSiteNotesTypeSelectMethod.GetById )
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
				AdminSiteNotesType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdminSiteNotesTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminSiteNotesType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdminSiteNotesTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminSiteNotesTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminSiteNotesTypeDataSource class.
	/// </summary>
	public class AdminSiteNotesTypeDataSourceDesigner : ProviderDataSourceDesigner<AdminSiteNotesType, AdminSiteNotesTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesTypeDataSourceDesigner class.
		/// </summary>
		public AdminSiteNotesTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminSiteNotesTypeSelectMethod SelectMethod
		{
			get { return ((AdminSiteNotesTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminSiteNotesTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminSiteNotesTypeDataSourceActionList

	/// <summary>
	/// Supports the AdminSiteNotesTypeDataSourceDesigner class.
	/// </summary>
	internal class AdminSiteNotesTypeDataSourceActionList : DesignerActionList
	{
		private AdminSiteNotesTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminSiteNotesTypeDataSourceActionList(AdminSiteNotesTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminSiteNotesTypeSelectMethod SelectMethod
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

	#endregion AdminSiteNotesTypeDataSourceActionList
	
	#endregion AdminSiteNotesTypeDataSourceDesigner
	
	#region AdminSiteNotesTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminSiteNotesTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AdminSiteNotesTypeSelectMethod
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
	
	#endregion AdminSiteNotesTypeSelectMethod

	#region AdminSiteNotesTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesTypeFilter : SqlFilter<AdminSiteNotesTypeColumn>
	{
	}
	
	#endregion AdminSiteNotesTypeFilter

	#region AdminSiteNotesTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesTypeExpressionBuilder : SqlExpressionBuilder<AdminSiteNotesTypeColumn>
	{
	}
	
	#endregion AdminSiteNotesTypeExpressionBuilder	

	#region AdminSiteNotesTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminSiteNotesTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesTypeProperty : ChildEntityProperty<AdminSiteNotesTypeChildEntityTypes>
	{
	}
	
	#endregion AdminSiteNotesTypeProperty
}

