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
	/// Represents the DataRepository.FeatureOptionTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FeatureOptionTypeDataSourceDesigner))]
	public class FeatureOptionTypeDataSource : ProviderDataSource<FeatureOptionType, FeatureOptionTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeDataSource class.
		/// </summary>
		public FeatureOptionTypeDataSource() : base(new FeatureOptionTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FeatureOptionTypeDataSourceView used by the FeatureOptionTypeDataSource.
		/// </summary>
		protected FeatureOptionTypeDataSourceView FeatureOptionTypeView
		{
			get { return ( View as FeatureOptionTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FeatureOptionTypeDataSource control invokes to retrieve data.
		/// </summary>
		public FeatureOptionTypeSelectMethod SelectMethod
		{
			get
			{
				FeatureOptionTypeSelectMethod selectMethod = FeatureOptionTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FeatureOptionTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FeatureOptionTypeDataSourceView class that is to be
		/// used by the FeatureOptionTypeDataSource.
		/// </summary>
		/// <returns>An instance of the FeatureOptionTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<FeatureOptionType, FeatureOptionTypeKey> GetNewDataSourceView()
		{
			return new FeatureOptionTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the FeatureOptionTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FeatureOptionTypeDataSourceView : ProviderDataSourceView<FeatureOptionType, FeatureOptionTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FeatureOptionTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FeatureOptionTypeDataSourceView(FeatureOptionTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FeatureOptionTypeDataSource FeatureOptionTypeOwner
		{
			get { return Owner as FeatureOptionTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FeatureOptionTypeSelectMethod SelectMethod
		{
			get { return FeatureOptionTypeOwner.SelectMethod; }
			set { FeatureOptionTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FeatureOptionTypeService FeatureOptionTypeProvider
		{
			get { return Provider as FeatureOptionTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<FeatureOptionType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<FeatureOptionType> results = null;
			FeatureOptionType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case FeatureOptionTypeSelectMethod.Get:
					FeatureOptionTypeKey entityKey  = new FeatureOptionTypeKey();
					entityKey.Load(values);
					item = FeatureOptionTypeProvider.Get(entityKey);
					results = new TList<FeatureOptionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FeatureOptionTypeSelectMethod.GetAll:
                    results = FeatureOptionTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FeatureOptionTypeSelectMethod.GetPaged:
					results = FeatureOptionTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FeatureOptionTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = FeatureOptionTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FeatureOptionTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FeatureOptionTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = FeatureOptionTypeProvider.GetById(_id);
					results = new TList<FeatureOptionType>();
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
			if ( SelectMethod == FeatureOptionTypeSelectMethod.Get || SelectMethod == FeatureOptionTypeSelectMethod.GetById )
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
				FeatureOptionType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FeatureOptionTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<FeatureOptionType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FeatureOptionTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FeatureOptionTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FeatureOptionTypeDataSource class.
	/// </summary>
	public class FeatureOptionTypeDataSourceDesigner : ProviderDataSourceDesigner<FeatureOptionType, FeatureOptionTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeDataSourceDesigner class.
		/// </summary>
		public FeatureOptionTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureOptionTypeSelectMethod SelectMethod
		{
			get { return ((FeatureOptionTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FeatureOptionTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FeatureOptionTypeDataSourceActionList

	/// <summary>
	/// Supports the FeatureOptionTypeDataSourceDesigner class.
	/// </summary>
	internal class FeatureOptionTypeDataSourceActionList : DesignerActionList
	{
		private FeatureOptionTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FeatureOptionTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FeatureOptionTypeDataSourceActionList(FeatureOptionTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureOptionTypeSelectMethod SelectMethod
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

	#endregion FeatureOptionTypeDataSourceActionList
	
	#endregion FeatureOptionTypeDataSourceDesigner
	
	#region FeatureOptionTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FeatureOptionTypeDataSource.SelectMethod property.
	/// </summary>
	public enum FeatureOptionTypeSelectMethod
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
	
	#endregion FeatureOptionTypeSelectMethod

	#region FeatureOptionTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOptionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionTypeFilter : SqlFilter<FeatureOptionTypeColumn>
	{
	}
	
	#endregion FeatureOptionTypeFilter

	#region FeatureOptionTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOptionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionTypeExpressionBuilder : SqlExpressionBuilder<FeatureOptionTypeColumn>
	{
	}
	
	#endregion FeatureOptionTypeExpressionBuilder	

	#region FeatureOptionTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FeatureOptionTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOptionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionTypeProperty : ChildEntityProperty<FeatureOptionTypeChildEntityTypes>
	{
	}
	
	#endregion FeatureOptionTypeProperty
}

