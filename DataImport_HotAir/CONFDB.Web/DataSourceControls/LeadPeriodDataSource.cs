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
	/// Represents the DataRepository.LeadPeriodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadPeriodDataSourceDesigner))]
	public class LeadPeriodDataSource : ProviderDataSource<LeadPeriod, LeadPeriodKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadPeriodDataSource class.
		/// </summary>
		public LeadPeriodDataSource() : base(new LeadPeriodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadPeriodDataSourceView used by the LeadPeriodDataSource.
		/// </summary>
		protected LeadPeriodDataSourceView LeadPeriodView
		{
			get { return ( View as LeadPeriodDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadPeriodDataSource control invokes to retrieve data.
		/// </summary>
		public LeadPeriodSelectMethod SelectMethod
		{
			get
			{
				LeadPeriodSelectMethod selectMethod = LeadPeriodSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadPeriodSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadPeriodDataSourceView class that is to be
		/// used by the LeadPeriodDataSource.
		/// </summary>
		/// <returns>An instance of the LeadPeriodDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadPeriod, LeadPeriodKey> GetNewDataSourceView()
		{
			return new LeadPeriodDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadPeriodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadPeriodDataSourceView : ProviderDataSourceView<LeadPeriod, LeadPeriodKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadPeriodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadPeriodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadPeriodDataSourceView(LeadPeriodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadPeriodDataSource LeadPeriodOwner
		{
			get { return Owner as LeadPeriodDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadPeriodSelectMethod SelectMethod
		{
			get { return LeadPeriodOwner.SelectMethod; }
			set { LeadPeriodOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadPeriodService LeadPeriodProvider
		{
			get { return Provider as LeadPeriodService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadPeriod> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadPeriod> results = null;
			LeadPeriod item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LeadPeriodSelectMethod.Get:
					LeadPeriodKey entityKey  = new LeadPeriodKey();
					entityKey.Load(values);
					item = LeadPeriodProvider.Get(entityKey);
					results = new TList<LeadPeriod>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadPeriodSelectMethod.GetAll:
                    results = LeadPeriodProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadPeriodSelectMethod.GetPaged:
					results = LeadPeriodProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadPeriodSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadPeriodProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadPeriodProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadPeriodSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadPeriodProvider.GetById(_id);
					results = new TList<LeadPeriod>();
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
			if ( SelectMethod == LeadPeriodSelectMethod.Get || SelectMethod == LeadPeriodSelectMethod.GetById )
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
				LeadPeriod entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadPeriodProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadPeriod> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadPeriodProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadPeriodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadPeriodDataSource class.
	/// </summary>
	public class LeadPeriodDataSourceDesigner : ProviderDataSourceDesigner<LeadPeriod, LeadPeriodKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadPeriodDataSourceDesigner class.
		/// </summary>
		public LeadPeriodDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadPeriodSelectMethod SelectMethod
		{
			get { return ((LeadPeriodDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadPeriodDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadPeriodDataSourceActionList

	/// <summary>
	/// Supports the LeadPeriodDataSourceDesigner class.
	/// </summary>
	internal class LeadPeriodDataSourceActionList : DesignerActionList
	{
		private LeadPeriodDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadPeriodDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadPeriodDataSourceActionList(LeadPeriodDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadPeriodSelectMethod SelectMethod
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

	#endregion LeadPeriodDataSourceActionList
	
	#endregion LeadPeriodDataSourceDesigner
	
	#region LeadPeriodSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadPeriodDataSource.SelectMethod property.
	/// </summary>
	public enum LeadPeriodSelectMethod
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
	
	#endregion LeadPeriodSelectMethod

	#region LeadPeriodFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadPeriodFilter : SqlFilter<LeadPeriodColumn>
	{
	}
	
	#endregion LeadPeriodFilter

	#region LeadPeriodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadPeriodExpressionBuilder : SqlExpressionBuilder<LeadPeriodColumn>
	{
	}
	
	#endregion LeadPeriodExpressionBuilder	

	#region LeadPeriodProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadPeriodChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadPeriodProperty : ChildEntityProperty<LeadPeriodChildEntityTypes>
	{
	}
	
	#endregion LeadPeriodProperty
}

