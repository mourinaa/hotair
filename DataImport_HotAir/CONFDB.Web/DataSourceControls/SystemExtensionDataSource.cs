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
	/// Represents the DataRepository.SystemExtensionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SystemExtensionDataSourceDesigner))]
	public class SystemExtensionDataSource : ProviderDataSource<SystemExtension, SystemExtensionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionDataSource class.
		/// </summary>
		public SystemExtensionDataSource() : base(new SystemExtensionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SystemExtensionDataSourceView used by the SystemExtensionDataSource.
		/// </summary>
		protected SystemExtensionDataSourceView SystemExtensionView
		{
			get { return ( View as SystemExtensionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SystemExtensionDataSource control invokes to retrieve data.
		/// </summary>
		public SystemExtensionSelectMethod SelectMethod
		{
			get
			{
				SystemExtensionSelectMethod selectMethod = SystemExtensionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SystemExtensionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SystemExtensionDataSourceView class that is to be
		/// used by the SystemExtensionDataSource.
		/// </summary>
		/// <returns>An instance of the SystemExtensionDataSourceView class.</returns>
		protected override BaseDataSourceView<SystemExtension, SystemExtensionKey> GetNewDataSourceView()
		{
			return new SystemExtensionDataSourceView(this, DefaultViewName);
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
	/// Supports the SystemExtensionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SystemExtensionDataSourceView : ProviderDataSourceView<SystemExtension, SystemExtensionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SystemExtensionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SystemExtensionDataSourceView(SystemExtensionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SystemExtensionDataSource SystemExtensionOwner
		{
			get { return Owner as SystemExtensionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SystemExtensionSelectMethod SelectMethod
		{
			get { return SystemExtensionOwner.SelectMethod; }
			set { SystemExtensionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SystemExtensionService SystemExtensionProvider
		{
			get { return Provider as SystemExtensionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SystemExtension> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SystemExtension> results = null;
			SystemExtension item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _systemExtensionLabelId;
			System.Int32 _tableId;

			switch ( SelectMethod )
			{
				case SystemExtensionSelectMethod.Get:
					SystemExtensionKey entityKey  = new SystemExtensionKey();
					entityKey.Load(values);
					item = SystemExtensionProvider.Get(entityKey);
					results = new TList<SystemExtension>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SystemExtensionSelectMethod.GetAll:
                    results = SystemExtensionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SystemExtensionSelectMethod.GetPaged:
					results = SystemExtensionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SystemExtensionSelectMethod.Find:
					if ( FilterParameters != null )
						results = SystemExtensionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SystemExtensionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SystemExtensionSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = SystemExtensionProvider.GetById(_id);
					results = new TList<SystemExtension>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SystemExtensionSelectMethod.GetBySystemExtensionLabelIdTableId:
					_systemExtensionLabelId = ( values["SystemExtensionLabelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SystemExtensionLabelId"], typeof(System.Int32)) : (int)0;
					_tableId = ( values["TableId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TableId"], typeof(System.Int32)) : (int)0;
					item = SystemExtensionProvider.GetBySystemExtensionLabelIdTableId(_systemExtensionLabelId, _tableId);
					results = new TList<SystemExtension>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SystemExtensionSelectMethod.GetBySystemExtensionLabelId:
					_systemExtensionLabelId = ( values["SystemExtensionLabelId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SystemExtensionLabelId"], typeof(System.Int32)) : (int)0;
					results = SystemExtensionProvider.GetBySystemExtensionLabelId(_systemExtensionLabelId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SystemExtensionSelectMethod.Get || SelectMethod == SystemExtensionSelectMethod.GetById )
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
				SystemExtension entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SystemExtensionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SystemExtension> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SystemExtensionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SystemExtensionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SystemExtensionDataSource class.
	/// </summary>
	public class SystemExtensionDataSourceDesigner : ProviderDataSourceDesigner<SystemExtension, SystemExtensionKey>
	{
		/// <summary>
		/// Initializes a new instance of the SystemExtensionDataSourceDesigner class.
		/// </summary>
		public SystemExtensionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemExtensionSelectMethod SelectMethod
		{
			get { return ((SystemExtensionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SystemExtensionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SystemExtensionDataSourceActionList

	/// <summary>
	/// Supports the SystemExtensionDataSourceDesigner class.
	/// </summary>
	internal class SystemExtensionDataSourceActionList : DesignerActionList
	{
		private SystemExtensionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SystemExtensionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SystemExtensionDataSourceActionList(SystemExtensionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemExtensionSelectMethod SelectMethod
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

	#endregion SystemExtensionDataSourceActionList
	
	#endregion SystemExtensionDataSourceDesigner
	
	#region SystemExtensionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SystemExtensionDataSource.SelectMethod property.
	/// </summary>
	public enum SystemExtensionSelectMethod
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
		/// Represents the GetBySystemExtensionLabelIdTableId method.
		/// </summary>
		GetBySystemExtensionLabelIdTableId,
		/// <summary>
		/// Represents the GetBySystemExtensionLabelId method.
		/// </summary>
		GetBySystemExtensionLabelId
	}
	
	#endregion SystemExtensionSelectMethod

	#region SystemExtensionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionFilter : SqlFilter<SystemExtensionColumn>
	{
	}
	
	#endregion SystemExtensionFilter

	#region SystemExtensionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionExpressionBuilder : SqlExpressionBuilder<SystemExtensionColumn>
	{
	}
	
	#endregion SystemExtensionExpressionBuilder	

	#region SystemExtensionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SystemExtensionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionProperty : ChildEntityProperty<SystemExtensionChildEntityTypes>
	{
	}
	
	#endregion SystemExtensionProperty
}

