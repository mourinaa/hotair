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
	/// Represents the DataRepository.LeadProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadProductDataSourceDesigner))]
	public class LeadProductDataSource : ProviderDataSource<LeadProduct, LeadProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadProductDataSource class.
		/// </summary>
		public LeadProductDataSource() : base(new LeadProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadProductDataSourceView used by the LeadProductDataSource.
		/// </summary>
		protected LeadProductDataSourceView LeadProductView
		{
			get { return ( View as LeadProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadProductDataSource control invokes to retrieve data.
		/// </summary>
		public LeadProductSelectMethod SelectMethod
		{
			get
			{
				LeadProductSelectMethod selectMethod = LeadProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadProductDataSourceView class that is to be
		/// used by the LeadProductDataSource.
		/// </summary>
		/// <returns>An instance of the LeadProductDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadProduct, LeadProductKey> GetNewDataSourceView()
		{
			return new LeadProductDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadProductDataSourceView : ProviderDataSourceView<LeadProduct, LeadProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadProductDataSourceView(LeadProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadProductDataSource LeadProductOwner
		{
			get { return Owner as LeadProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadProductSelectMethod SelectMethod
		{
			get { return LeadProductOwner.SelectMethod; }
			set { LeadProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadProductService LeadProductProvider
		{
			get { return Provider as LeadProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadProduct> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadProduct> results = null;
			LeadProduct item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LeadProductSelectMethod.Get:
					LeadProductKey entityKey  = new LeadProductKey();
					entityKey.Load(values);
					item = LeadProductProvider.Get(entityKey);
					results = new TList<LeadProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadProductSelectMethod.GetAll:
                    results = LeadProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadProductSelectMethod.GetPaged:
					results = LeadProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadProductSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadProductProvider.GetById(_id);
					results = new TList<LeadProduct>();
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
			if ( SelectMethod == LeadProductSelectMethod.Get || SelectMethod == LeadProductSelectMethod.GetById )
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
				LeadProduct entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadProduct> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadProductDataSource class.
	/// </summary>
	public class LeadProductDataSourceDesigner : ProviderDataSourceDesigner<LeadProduct, LeadProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadProductDataSourceDesigner class.
		/// </summary>
		public LeadProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadProductSelectMethod SelectMethod
		{
			get { return ((LeadProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadProductDataSourceActionList

	/// <summary>
	/// Supports the LeadProductDataSourceDesigner class.
	/// </summary>
	internal class LeadProductDataSourceActionList : DesignerActionList
	{
		private LeadProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadProductDataSourceActionList(LeadProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadProductSelectMethod SelectMethod
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

	#endregion LeadProductDataSourceActionList
	
	#endregion LeadProductDataSourceDesigner
	
	#region LeadProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadProductDataSource.SelectMethod property.
	/// </summary>
	public enum LeadProductSelectMethod
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
	
	#endregion LeadProductSelectMethod

	#region LeadProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProductFilter : SqlFilter<LeadProductColumn>
	{
	}
	
	#endregion LeadProductFilter

	#region LeadProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProductExpressionBuilder : SqlExpressionBuilder<LeadProductColumn>
	{
	}
	
	#endregion LeadProductExpressionBuilder	

	#region LeadProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProductProperty : ChildEntityProperty<LeadProductChildEntityTypes>
	{
	}
	
	#endregion LeadProductProperty
}

