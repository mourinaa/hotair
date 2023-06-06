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
	/// Represents the DataRepository.AreaCodeNxxProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AreaCodeNxxDataSourceDesigner))]
	public class AreaCodeNxxDataSource : ProviderDataSource<AreaCodeNxx, AreaCodeNxxKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxDataSource class.
		/// </summary>
		public AreaCodeNxxDataSource() : base(new AreaCodeNxxService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AreaCodeNxxDataSourceView used by the AreaCodeNxxDataSource.
		/// </summary>
		protected AreaCodeNxxDataSourceView AreaCodeNxxView
		{
			get { return ( View as AreaCodeNxxDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AreaCodeNxxDataSource control invokes to retrieve data.
		/// </summary>
		public AreaCodeNxxSelectMethod SelectMethod
		{
			get
			{
				AreaCodeNxxSelectMethod selectMethod = AreaCodeNxxSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AreaCodeNxxSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AreaCodeNxxDataSourceView class that is to be
		/// used by the AreaCodeNxxDataSource.
		/// </summary>
		/// <returns>An instance of the AreaCodeNxxDataSourceView class.</returns>
		protected override BaseDataSourceView<AreaCodeNxx, AreaCodeNxxKey> GetNewDataSourceView()
		{
			return new AreaCodeNxxDataSourceView(this, DefaultViewName);
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
	/// Supports the AreaCodeNxxDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AreaCodeNxxDataSourceView : ProviderDataSourceView<AreaCodeNxx, AreaCodeNxxKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AreaCodeNxxDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AreaCodeNxxDataSourceView(AreaCodeNxxDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AreaCodeNxxDataSource AreaCodeNxxOwner
		{
			get { return Owner as AreaCodeNxxDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AreaCodeNxxSelectMethod SelectMethod
		{
			get { return AreaCodeNxxOwner.SelectMethod; }
			set { AreaCodeNxxOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AreaCodeNxxService AreaCodeNxxProvider
		{
			get { return Provider as AreaCodeNxxService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AreaCodeNxx> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AreaCodeNxx> results = null;
			AreaCodeNxx item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case AreaCodeNxxSelectMethod.Get:
					AreaCodeNxxKey entityKey  = new AreaCodeNxxKey();
					entityKey.Load(values);
					item = AreaCodeNxxProvider.Get(entityKey);
					results = new TList<AreaCodeNxx>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AreaCodeNxxSelectMethod.GetAll:
                    results = AreaCodeNxxProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AreaCodeNxxSelectMethod.GetPaged:
					results = AreaCodeNxxProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AreaCodeNxxSelectMethod.Find:
					if ( FilterParameters != null )
						results = AreaCodeNxxProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AreaCodeNxxProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AreaCodeNxxSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = AreaCodeNxxProvider.GetById(_id);
					results = new TList<AreaCodeNxx>();
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
			if ( SelectMethod == AreaCodeNxxSelectMethod.Get || SelectMethod == AreaCodeNxxSelectMethod.GetById )
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
				AreaCodeNxx entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AreaCodeNxxProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AreaCodeNxx> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AreaCodeNxxProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AreaCodeNxxDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AreaCodeNxxDataSource class.
	/// </summary>
	public class AreaCodeNxxDataSourceDesigner : ProviderDataSourceDesigner<AreaCodeNxx, AreaCodeNxxKey>
	{
		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxDataSourceDesigner class.
		/// </summary>
		public AreaCodeNxxDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AreaCodeNxxSelectMethod SelectMethod
		{
			get { return ((AreaCodeNxxDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AreaCodeNxxDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AreaCodeNxxDataSourceActionList

	/// <summary>
	/// Supports the AreaCodeNxxDataSourceDesigner class.
	/// </summary>
	internal class AreaCodeNxxDataSourceActionList : DesignerActionList
	{
		private AreaCodeNxxDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AreaCodeNxxDataSourceActionList(AreaCodeNxxDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AreaCodeNxxSelectMethod SelectMethod
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

	#endregion AreaCodeNxxDataSourceActionList
	
	#endregion AreaCodeNxxDataSourceDesigner
	
	#region AreaCodeNxxSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AreaCodeNxxDataSource.SelectMethod property.
	/// </summary>
	public enum AreaCodeNxxSelectMethod
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
	
	#endregion AreaCodeNxxSelectMethod

	#region AreaCodeNxxFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxFilter : SqlFilter<AreaCodeNxxColumn>
	{
	}
	
	#endregion AreaCodeNxxFilter

	#region AreaCodeNxxExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxExpressionBuilder : SqlExpressionBuilder<AreaCodeNxxColumn>
	{
	}
	
	#endregion AreaCodeNxxExpressionBuilder	

	#region AreaCodeNxxProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AreaCodeNxxChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxProperty : ChildEntityProperty<AreaCodeNxxChildEntityTypes>
	{
	}
	
	#endregion AreaCodeNxxProperty
}

