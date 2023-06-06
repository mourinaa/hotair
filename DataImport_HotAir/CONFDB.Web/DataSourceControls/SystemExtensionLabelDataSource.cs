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
	/// Represents the DataRepository.SystemExtensionLabelProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SystemExtensionLabelDataSourceDesigner))]
	public class SystemExtensionLabelDataSource : ProviderDataSource<SystemExtensionLabel, SystemExtensionLabelKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelDataSource class.
		/// </summary>
		public SystemExtensionLabelDataSource() : base(new SystemExtensionLabelService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SystemExtensionLabelDataSourceView used by the SystemExtensionLabelDataSource.
		/// </summary>
		protected SystemExtensionLabelDataSourceView SystemExtensionLabelView
		{
			get { return ( View as SystemExtensionLabelDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SystemExtensionLabelDataSource control invokes to retrieve data.
		/// </summary>
		public SystemExtensionLabelSelectMethod SelectMethod
		{
			get
			{
				SystemExtensionLabelSelectMethod selectMethod = SystemExtensionLabelSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SystemExtensionLabelSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SystemExtensionLabelDataSourceView class that is to be
		/// used by the SystemExtensionLabelDataSource.
		/// </summary>
		/// <returns>An instance of the SystemExtensionLabelDataSourceView class.</returns>
		protected override BaseDataSourceView<SystemExtensionLabel, SystemExtensionLabelKey> GetNewDataSourceView()
		{
			return new SystemExtensionLabelDataSourceView(this, DefaultViewName);
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
	/// Supports the SystemExtensionLabelDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SystemExtensionLabelDataSourceView : ProviderDataSourceView<SystemExtensionLabel, SystemExtensionLabelKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SystemExtensionLabelDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SystemExtensionLabelDataSourceView(SystemExtensionLabelDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SystemExtensionLabelDataSource SystemExtensionLabelOwner
		{
			get { return Owner as SystemExtensionLabelDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SystemExtensionLabelSelectMethod SelectMethod
		{
			get { return SystemExtensionLabelOwner.SelectMethod; }
			set { SystemExtensionLabelOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SystemExtensionLabelService SystemExtensionLabelProvider
		{
			get { return Provider as SystemExtensionLabelService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SystemExtensionLabel> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SystemExtensionLabel> results = null;
			SystemExtensionLabel item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;
			System.Boolean _customerCanView;
			System.Boolean _moderatorCanView;
			System.Int32 _extensionTypeId;

			switch ( SelectMethod )
			{
				case SystemExtensionLabelSelectMethod.Get:
					SystemExtensionLabelKey entityKey  = new SystemExtensionLabelKey();
					entityKey.Load(values);
					item = SystemExtensionLabelProvider.Get(entityKey);
					results = new TList<SystemExtensionLabel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SystemExtensionLabelSelectMethod.GetAll:
                    results = SystemExtensionLabelProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SystemExtensionLabelSelectMethod.GetPaged:
					results = SystemExtensionLabelProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SystemExtensionLabelSelectMethod.Find:
					if ( FilterParameters != null )
						results = SystemExtensionLabelProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SystemExtensionLabelProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SystemExtensionLabelSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = SystemExtensionLabelProvider.GetById(_id);
					results = new TList<SystemExtensionLabel>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SystemExtensionLabelSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = SystemExtensionLabelProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case SystemExtensionLabelSelectMethod.GetByCustomerIdCustomerCanView:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_customerCanView = ( values["CustomerCanView"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["CustomerCanView"], typeof(System.Boolean)) : false;
					results = SystemExtensionLabelProvider.GetByCustomerIdCustomerCanView(_customerId, _customerCanView, this.StartIndex, this.PageSize, out count);
					break;
				case SystemExtensionLabelSelectMethod.GetByCustomerIdModeratorCanView:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_moderatorCanView = ( values["ModeratorCanView"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["ModeratorCanView"], typeof(System.Boolean)) : false;
					results = SystemExtensionLabelProvider.GetByCustomerIdModeratorCanView(_customerId, _moderatorCanView, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case SystemExtensionLabelSelectMethod.GetByExtensionTypeId:
					_extensionTypeId = ( values["ExtensionTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ExtensionTypeId"], typeof(System.Int32)) : (int)0;
					results = SystemExtensionLabelProvider.GetByExtensionTypeId(_extensionTypeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SystemExtensionLabelSelectMethod.Get || SelectMethod == SystemExtensionLabelSelectMethod.GetById )
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
				SystemExtensionLabel entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SystemExtensionLabelProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SystemExtensionLabel> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SystemExtensionLabelProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SystemExtensionLabelDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SystemExtensionLabelDataSource class.
	/// </summary>
	public class SystemExtensionLabelDataSourceDesigner : ProviderDataSourceDesigner<SystemExtensionLabel, SystemExtensionLabelKey>
	{
		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelDataSourceDesigner class.
		/// </summary>
		public SystemExtensionLabelDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemExtensionLabelSelectMethod SelectMethod
		{
			get { return ((SystemExtensionLabelDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SystemExtensionLabelDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SystemExtensionLabelDataSourceActionList

	/// <summary>
	/// Supports the SystemExtensionLabelDataSourceDesigner class.
	/// </summary>
	internal class SystemExtensionLabelDataSourceActionList : DesignerActionList
	{
		private SystemExtensionLabelDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SystemExtensionLabelDataSourceActionList(SystemExtensionLabelDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemExtensionLabelSelectMethod SelectMethod
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

	#endregion SystemExtensionLabelDataSourceActionList
	
	#endregion SystemExtensionLabelDataSourceDesigner
	
	#region SystemExtensionLabelSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SystemExtensionLabelDataSource.SelectMethod property.
	/// </summary>
	public enum SystemExtensionLabelSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByCustomerIdCustomerCanView method.
		/// </summary>
		GetByCustomerIdCustomerCanView,
		/// <summary>
		/// Represents the GetByCustomerIdModeratorCanView method.
		/// </summary>
		GetByCustomerIdModeratorCanView,
		/// <summary>
		/// Represents the GetByExtensionTypeId method.
		/// </summary>
		GetByExtensionTypeId
	}
	
	#endregion SystemExtensionLabelSelectMethod

	#region SystemExtensionLabelFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelFilter : SqlFilter<SystemExtensionLabelColumn>
	{
	}
	
	#endregion SystemExtensionLabelFilter

	#region SystemExtensionLabelExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelExpressionBuilder : SqlExpressionBuilder<SystemExtensionLabelColumn>
	{
	}
	
	#endregion SystemExtensionLabelExpressionBuilder	

	#region SystemExtensionLabelProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SystemExtensionLabelChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelProperty : ChildEntityProperty<SystemExtensionLabelChildEntityTypes>
	{
	}
	
	#endregion SystemExtensionLabelProperty
}

