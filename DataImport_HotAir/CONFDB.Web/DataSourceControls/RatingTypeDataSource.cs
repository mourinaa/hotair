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
	/// Represents the DataRepository.RatingTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RatingTypeDataSourceDesigner))]
	public class RatingTypeDataSource : ProviderDataSource<RatingType, RatingTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatingTypeDataSource class.
		/// </summary>
		public RatingTypeDataSource() : base(new RatingTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RatingTypeDataSourceView used by the RatingTypeDataSource.
		/// </summary>
		protected RatingTypeDataSourceView RatingTypeView
		{
			get { return ( View as RatingTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RatingTypeDataSource control invokes to retrieve data.
		/// </summary>
		public RatingTypeSelectMethod SelectMethod
		{
			get
			{
				RatingTypeSelectMethod selectMethod = RatingTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RatingTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RatingTypeDataSourceView class that is to be
		/// used by the RatingTypeDataSource.
		/// </summary>
		/// <returns>An instance of the RatingTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<RatingType, RatingTypeKey> GetNewDataSourceView()
		{
			return new RatingTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the RatingTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RatingTypeDataSourceView : ProviderDataSourceView<RatingType, RatingTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatingTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RatingTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RatingTypeDataSourceView(RatingTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RatingTypeDataSource RatingTypeOwner
		{
			get { return Owner as RatingTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RatingTypeSelectMethod SelectMethod
		{
			get { return RatingTypeOwner.SelectMethod; }
			set { RatingTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RatingTypeService RatingTypeProvider
		{
			get { return Provider as RatingTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RatingType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RatingType> results = null;
			RatingType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case RatingTypeSelectMethod.Get:
					RatingTypeKey entityKey  = new RatingTypeKey();
					entityKey.Load(values);
					item = RatingTypeProvider.Get(entityKey);
					results = new TList<RatingType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RatingTypeSelectMethod.GetAll:
                    results = RatingTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RatingTypeSelectMethod.GetPaged:
					results = RatingTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RatingTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = RatingTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RatingTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RatingTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = RatingTypeProvider.GetById(_id);
					results = new TList<RatingType>();
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
			if ( SelectMethod == RatingTypeSelectMethod.Get || SelectMethod == RatingTypeSelectMethod.GetById )
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
				RatingType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RatingTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RatingType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RatingTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RatingTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RatingTypeDataSource class.
	/// </summary>
	public class RatingTypeDataSourceDesigner : ProviderDataSourceDesigner<RatingType, RatingTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the RatingTypeDataSourceDesigner class.
		/// </summary>
		public RatingTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RatingTypeSelectMethod SelectMethod
		{
			get { return ((RatingTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RatingTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RatingTypeDataSourceActionList

	/// <summary>
	/// Supports the RatingTypeDataSourceDesigner class.
	/// </summary>
	internal class RatingTypeDataSourceActionList : DesignerActionList
	{
		private RatingTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RatingTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RatingTypeDataSourceActionList(RatingTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RatingTypeSelectMethod SelectMethod
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

	#endregion RatingTypeDataSourceActionList
	
	#endregion RatingTypeDataSourceDesigner
	
	#region RatingTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RatingTypeDataSource.SelectMethod property.
	/// </summary>
	public enum RatingTypeSelectMethod
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
	
	#endregion RatingTypeSelectMethod

	#region RatingTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatingTypeFilter : SqlFilter<RatingTypeColumn>
	{
	}
	
	#endregion RatingTypeFilter

	#region RatingTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatingTypeExpressionBuilder : SqlExpressionBuilder<RatingTypeColumn>
	{
	}
	
	#endregion RatingTypeExpressionBuilder	

	#region RatingTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RatingTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RatingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatingTypeProperty : ChildEntityProperty<RatingTypeChildEntityTypes>
	{
	}
	
	#endregion RatingTypeProperty
}

