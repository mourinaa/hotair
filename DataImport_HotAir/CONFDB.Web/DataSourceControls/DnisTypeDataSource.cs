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
	/// Represents the DataRepository.DnisTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DnisTypeDataSourceDesigner))]
	public class DnisTypeDataSource : ProviderDataSource<DnisType, DnisTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisTypeDataSource class.
		/// </summary>
		public DnisTypeDataSource() : base(new DnisTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DnisTypeDataSourceView used by the DnisTypeDataSource.
		/// </summary>
		protected DnisTypeDataSourceView DnisTypeView
		{
			get { return ( View as DnisTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DnisTypeDataSource control invokes to retrieve data.
		/// </summary>
		public DnisTypeSelectMethod SelectMethod
		{
			get
			{
				DnisTypeSelectMethod selectMethod = DnisTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DnisTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DnisTypeDataSourceView class that is to be
		/// used by the DnisTypeDataSource.
		/// </summary>
		/// <returns>An instance of the DnisTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<DnisType, DnisTypeKey> GetNewDataSourceView()
		{
			return new DnisTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the DnisTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DnisTypeDataSourceView : ProviderDataSourceView<DnisType, DnisTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DnisTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DnisTypeDataSourceView(DnisTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DnisTypeDataSource DnisTypeOwner
		{
			get { return Owner as DnisTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DnisTypeSelectMethod SelectMethod
		{
			get { return DnisTypeOwner.SelectMethod; }
			set { DnisTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DnisTypeService DnisTypeProvider
		{
			get { return Provider as DnisTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DnisType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DnisType> results = null;
			DnisType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case DnisTypeSelectMethod.Get:
					DnisTypeKey entityKey  = new DnisTypeKey();
					entityKey.Load(values);
					item = DnisTypeProvider.Get(entityKey);
					results = new TList<DnisType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DnisTypeSelectMethod.GetAll:
                    results = DnisTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DnisTypeSelectMethod.GetPaged:
					results = DnisTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DnisTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = DnisTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DnisTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DnisTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DnisTypeProvider.GetById(_id);
					results = new TList<DnisType>();
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
			if ( SelectMethod == DnisTypeSelectMethod.Get || SelectMethod == DnisTypeSelectMethod.GetById )
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
				DnisType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DnisTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DnisType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DnisTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DnisTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DnisTypeDataSource class.
	/// </summary>
	public class DnisTypeDataSourceDesigner : ProviderDataSourceDesigner<DnisType, DnisTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the DnisTypeDataSourceDesigner class.
		/// </summary>
		public DnisTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DnisTypeSelectMethod SelectMethod
		{
			get { return ((DnisTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DnisTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DnisTypeDataSourceActionList

	/// <summary>
	/// Supports the DnisTypeDataSourceDesigner class.
	/// </summary>
	internal class DnisTypeDataSourceActionList : DesignerActionList
	{
		private DnisTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DnisTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DnisTypeDataSourceActionList(DnisTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DnisTypeSelectMethod SelectMethod
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

	#endregion DnisTypeDataSourceActionList
	
	#endregion DnisTypeDataSourceDesigner
	
	#region DnisTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DnisTypeDataSource.SelectMethod property.
	/// </summary>
	public enum DnisTypeSelectMethod
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
	
	#endregion DnisTypeSelectMethod

	#region DnisTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DnisType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisTypeFilter : SqlFilter<DnisTypeColumn>
	{
	}
	
	#endregion DnisTypeFilter

	#region DnisTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DnisType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisTypeExpressionBuilder : SqlExpressionBuilder<DnisTypeColumn>
	{
	}
	
	#endregion DnisTypeExpressionBuilder	

	#region DnisTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DnisTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DnisType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisTypeProperty : ChildEntityProperty<DnisTypeChildEntityTypes>
	{
	}
	
	#endregion DnisTypeProperty
}

