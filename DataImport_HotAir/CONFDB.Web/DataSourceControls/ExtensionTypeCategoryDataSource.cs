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
	/// Represents the DataRepository.ExtensionTypeCategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ExtensionTypeCategoryDataSourceDesigner))]
	public class ExtensionTypeCategoryDataSource : ProviderDataSource<ExtensionTypeCategory, ExtensionTypeCategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryDataSource class.
		/// </summary>
		public ExtensionTypeCategoryDataSource() : base(new ExtensionTypeCategoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ExtensionTypeCategoryDataSourceView used by the ExtensionTypeCategoryDataSource.
		/// </summary>
		protected ExtensionTypeCategoryDataSourceView ExtensionTypeCategoryView
		{
			get { return ( View as ExtensionTypeCategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ExtensionTypeCategoryDataSource control invokes to retrieve data.
		/// </summary>
		public ExtensionTypeCategorySelectMethod SelectMethod
		{
			get
			{
				ExtensionTypeCategorySelectMethod selectMethod = ExtensionTypeCategorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ExtensionTypeCategorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ExtensionTypeCategoryDataSourceView class that is to be
		/// used by the ExtensionTypeCategoryDataSource.
		/// </summary>
		/// <returns>An instance of the ExtensionTypeCategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ExtensionTypeCategory, ExtensionTypeCategoryKey> GetNewDataSourceView()
		{
			return new ExtensionTypeCategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ExtensionTypeCategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ExtensionTypeCategoryDataSourceView : ProviderDataSourceView<ExtensionTypeCategory, ExtensionTypeCategoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ExtensionTypeCategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ExtensionTypeCategoryDataSourceView(ExtensionTypeCategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ExtensionTypeCategoryDataSource ExtensionTypeCategoryOwner
		{
			get { return Owner as ExtensionTypeCategoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ExtensionTypeCategorySelectMethod SelectMethod
		{
			get { return ExtensionTypeCategoryOwner.SelectMethod; }
			set { ExtensionTypeCategoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ExtensionTypeCategoryService ExtensionTypeCategoryProvider
		{
			get { return Provider as ExtensionTypeCategoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ExtensionTypeCategory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ExtensionTypeCategory> results = null;
			ExtensionTypeCategory item;
			count = 0;
			
			System.Int32 _id;
			System.String _categoryName;

			switch ( SelectMethod )
			{
				case ExtensionTypeCategorySelectMethod.Get:
					ExtensionTypeCategoryKey entityKey  = new ExtensionTypeCategoryKey();
					entityKey.Load(values);
					item = ExtensionTypeCategoryProvider.Get(entityKey);
					results = new TList<ExtensionTypeCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ExtensionTypeCategorySelectMethod.GetAll:
                    results = ExtensionTypeCategoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ExtensionTypeCategorySelectMethod.GetPaged:
					results = ExtensionTypeCategoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ExtensionTypeCategorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ExtensionTypeCategoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ExtensionTypeCategoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ExtensionTypeCategorySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ExtensionTypeCategoryProvider.GetById(_id);
					results = new TList<ExtensionTypeCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ExtensionTypeCategorySelectMethod.GetByCategoryName:
					_categoryName = ( values["CategoryName"] != null ) ? (System.String) EntityUtil.ChangeType(values["CategoryName"], typeof(System.String)) : string.Empty;
					item = ExtensionTypeCategoryProvider.GetByCategoryName(_categoryName);
					results = new TList<ExtensionTypeCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
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
			if ( SelectMethod == ExtensionTypeCategorySelectMethod.Get || SelectMethod == ExtensionTypeCategorySelectMethod.GetById )
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
				ExtensionTypeCategory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ExtensionTypeCategoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ExtensionTypeCategory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ExtensionTypeCategoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ExtensionTypeCategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ExtensionTypeCategoryDataSource class.
	/// </summary>
	public class ExtensionTypeCategoryDataSourceDesigner : ProviderDataSourceDesigner<ExtensionTypeCategory, ExtensionTypeCategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryDataSourceDesigner class.
		/// </summary>
		public ExtensionTypeCategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExtensionTypeCategorySelectMethod SelectMethod
		{
			get { return ((ExtensionTypeCategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ExtensionTypeCategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ExtensionTypeCategoryDataSourceActionList

	/// <summary>
	/// Supports the ExtensionTypeCategoryDataSourceDesigner class.
	/// </summary>
	internal class ExtensionTypeCategoryDataSourceActionList : DesignerActionList
	{
		private ExtensionTypeCategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeCategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ExtensionTypeCategoryDataSourceActionList(ExtensionTypeCategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExtensionTypeCategorySelectMethod SelectMethod
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

	#endregion ExtensionTypeCategoryDataSourceActionList
	
	#endregion ExtensionTypeCategoryDataSourceDesigner
	
	#region ExtensionTypeCategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ExtensionTypeCategoryDataSource.SelectMethod property.
	/// </summary>
	public enum ExtensionTypeCategorySelectMethod
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
		/// Represents the GetByCategoryName method.
		/// </summary>
		GetByCategoryName
	}
	
	#endregion ExtensionTypeCategorySelectMethod

	#region ExtensionTypeCategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionTypeCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeCategoryFilter : SqlFilter<ExtensionTypeCategoryColumn>
	{
	}
	
	#endregion ExtensionTypeCategoryFilter

	#region ExtensionTypeCategoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionTypeCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeCategoryExpressionBuilder : SqlExpressionBuilder<ExtensionTypeCategoryColumn>
	{
	}
	
	#endregion ExtensionTypeCategoryExpressionBuilder	

	#region ExtensionTypeCategoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ExtensionTypeCategoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionTypeCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeCategoryProperty : ChildEntityProperty<ExtensionTypeCategoryChildEntityTypes>
	{
	}
	
	#endregion ExtensionTypeCategoryProperty
}

