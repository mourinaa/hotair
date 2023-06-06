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
	/// Represents the DataRepository.ExtensionTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ExtensionTypeDataSourceDesigner))]
	public class ExtensionTypeDataSource : ProviderDataSource<ExtensionType, ExtensionTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeDataSource class.
		/// </summary>
		public ExtensionTypeDataSource() : base(new ExtensionTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ExtensionTypeDataSourceView used by the ExtensionTypeDataSource.
		/// </summary>
		protected ExtensionTypeDataSourceView ExtensionTypeView
		{
			get { return ( View as ExtensionTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ExtensionTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ExtensionTypeSelectMethod SelectMethod
		{
			get
			{
				ExtensionTypeSelectMethod selectMethod = ExtensionTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ExtensionTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ExtensionTypeDataSourceView class that is to be
		/// used by the ExtensionTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ExtensionTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ExtensionType, ExtensionTypeKey> GetNewDataSourceView()
		{
			return new ExtensionTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ExtensionTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ExtensionTypeDataSourceView : ProviderDataSourceView<ExtensionType, ExtensionTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ExtensionTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ExtensionTypeDataSourceView(ExtensionTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ExtensionTypeDataSource ExtensionTypeOwner
		{
			get { return Owner as ExtensionTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ExtensionTypeSelectMethod SelectMethod
		{
			get { return ExtensionTypeOwner.SelectMethod; }
			set { ExtensionTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ExtensionTypeService ExtensionTypeProvider
		{
			get { return Provider as ExtensionTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ExtensionType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ExtensionType> results = null;
			ExtensionType item;
			count = 0;
			
			System.Int32 _id;
			System.String _name;
			System.Int32 _extensionTypeCategoryId;

			switch ( SelectMethod )
			{
				case ExtensionTypeSelectMethod.Get:
					ExtensionTypeKey entityKey  = new ExtensionTypeKey();
					entityKey.Load(values);
					item = ExtensionTypeProvider.Get(entityKey);
					results = new TList<ExtensionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ExtensionTypeSelectMethod.GetAll:
                    results = ExtensionTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ExtensionTypeSelectMethod.GetPaged:
					results = ExtensionTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ExtensionTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ExtensionTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ExtensionTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ExtensionTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ExtensionTypeProvider.GetById(_id);
					results = new TList<ExtensionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ExtensionTypeSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = ExtensionTypeProvider.GetByName(_name);
					results = new TList<ExtensionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ExtensionTypeSelectMethod.GetByExtensionTypeCategoryId:
					_extensionTypeCategoryId = ( values["ExtensionTypeCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ExtensionTypeCategoryId"], typeof(System.Int32)) : (int)0;
					results = ExtensionTypeProvider.GetByExtensionTypeCategoryId(_extensionTypeCategoryId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == ExtensionTypeSelectMethod.Get || SelectMethod == ExtensionTypeSelectMethod.GetById )
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
				ExtensionType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ExtensionTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ExtensionType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ExtensionTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ExtensionTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ExtensionTypeDataSource class.
	/// </summary>
	public class ExtensionTypeDataSourceDesigner : ProviderDataSourceDesigner<ExtensionType, ExtensionTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ExtensionTypeDataSourceDesigner class.
		/// </summary>
		public ExtensionTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExtensionTypeSelectMethod SelectMethod
		{
			get { return ((ExtensionTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ExtensionTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ExtensionTypeDataSourceActionList

	/// <summary>
	/// Supports the ExtensionTypeDataSourceDesigner class.
	/// </summary>
	internal class ExtensionTypeDataSourceActionList : DesignerActionList
	{
		private ExtensionTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ExtensionTypeDataSourceActionList(ExtensionTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExtensionTypeSelectMethod SelectMethod
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

	#endregion ExtensionTypeDataSourceActionList
	
	#endregion ExtensionTypeDataSourceDesigner
	
	#region ExtensionTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ExtensionTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ExtensionTypeSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName,
		/// <summary>
		/// Represents the GetByExtensionTypeCategoryId method.
		/// </summary>
		GetByExtensionTypeCategoryId
	}
	
	#endregion ExtensionTypeSelectMethod

	#region ExtensionTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeFilter : SqlFilter<ExtensionTypeColumn>
	{
	}
	
	#endregion ExtensionTypeFilter

	#region ExtensionTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeExpressionBuilder : SqlExpressionBuilder<ExtensionTypeColumn>
	{
	}
	
	#endregion ExtensionTypeExpressionBuilder	

	#region ExtensionTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ExtensionTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeProperty : ChildEntityProperty<ExtensionTypeChildEntityTypes>
	{
	}
	
	#endregion ExtensionTypeProperty
}

