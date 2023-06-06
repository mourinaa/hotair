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
	/// Represents the DataRepository.LeadChurnReasonProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadChurnReasonDataSourceDesigner))]
	public class LeadChurnReasonDataSource : ProviderDataSource<LeadChurnReason, LeadChurnReasonKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonDataSource class.
		/// </summary>
		public LeadChurnReasonDataSource() : base(new LeadChurnReasonService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadChurnReasonDataSourceView used by the LeadChurnReasonDataSource.
		/// </summary>
		protected LeadChurnReasonDataSourceView LeadChurnReasonView
		{
			get { return ( View as LeadChurnReasonDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadChurnReasonDataSource control invokes to retrieve data.
		/// </summary>
		public LeadChurnReasonSelectMethod SelectMethod
		{
			get
			{
				LeadChurnReasonSelectMethod selectMethod = LeadChurnReasonSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadChurnReasonSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadChurnReasonDataSourceView class that is to be
		/// used by the LeadChurnReasonDataSource.
		/// </summary>
		/// <returns>An instance of the LeadChurnReasonDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadChurnReason, LeadChurnReasonKey> GetNewDataSourceView()
		{
			return new LeadChurnReasonDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadChurnReasonDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadChurnReasonDataSourceView : ProviderDataSourceView<LeadChurnReason, LeadChurnReasonKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadChurnReasonDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadChurnReasonDataSourceView(LeadChurnReasonDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadChurnReasonDataSource LeadChurnReasonOwner
		{
			get { return Owner as LeadChurnReasonDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadChurnReasonSelectMethod SelectMethod
		{
			get { return LeadChurnReasonOwner.SelectMethod; }
			set { LeadChurnReasonOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadChurnReasonService LeadChurnReasonProvider
		{
			get { return Provider as LeadChurnReasonService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadChurnReason> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadChurnReason> results = null;
			LeadChurnReason item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LeadChurnReasonSelectMethod.Get:
					LeadChurnReasonKey entityKey  = new LeadChurnReasonKey();
					entityKey.Load(values);
					item = LeadChurnReasonProvider.Get(entityKey);
					results = new TList<LeadChurnReason>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadChurnReasonSelectMethod.GetAll:
                    results = LeadChurnReasonProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadChurnReasonSelectMethod.GetPaged:
					results = LeadChurnReasonProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadChurnReasonSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadChurnReasonProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadChurnReasonProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadChurnReasonSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadChurnReasonProvider.GetById(_id);
					results = new TList<LeadChurnReason>();
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
			if ( SelectMethod == LeadChurnReasonSelectMethod.Get || SelectMethod == LeadChurnReasonSelectMethod.GetById )
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
				LeadChurnReason entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadChurnReasonProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadChurnReason> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadChurnReasonProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadChurnReasonDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadChurnReasonDataSource class.
	/// </summary>
	public class LeadChurnReasonDataSourceDesigner : ProviderDataSourceDesigner<LeadChurnReason, LeadChurnReasonKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonDataSourceDesigner class.
		/// </summary>
		public LeadChurnReasonDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadChurnReasonSelectMethod SelectMethod
		{
			get { return ((LeadChurnReasonDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadChurnReasonDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadChurnReasonDataSourceActionList

	/// <summary>
	/// Supports the LeadChurnReasonDataSourceDesigner class.
	/// </summary>
	internal class LeadChurnReasonDataSourceActionList : DesignerActionList
	{
		private LeadChurnReasonDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadChurnReasonDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadChurnReasonDataSourceActionList(LeadChurnReasonDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadChurnReasonSelectMethod SelectMethod
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

	#endregion LeadChurnReasonDataSourceActionList
	
	#endregion LeadChurnReasonDataSourceDesigner
	
	#region LeadChurnReasonSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadChurnReasonDataSource.SelectMethod property.
	/// </summary>
	public enum LeadChurnReasonSelectMethod
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
	
	#endregion LeadChurnReasonSelectMethod

	#region LeadChurnReasonFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadChurnReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadChurnReasonFilter : SqlFilter<LeadChurnReasonColumn>
	{
	}
	
	#endregion LeadChurnReasonFilter

	#region LeadChurnReasonExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadChurnReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadChurnReasonExpressionBuilder : SqlExpressionBuilder<LeadChurnReasonColumn>
	{
	}
	
	#endregion LeadChurnReasonExpressionBuilder	

	#region LeadChurnReasonProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadChurnReasonChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadChurnReason"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadChurnReasonProperty : ChildEntityProperty<LeadChurnReasonChildEntityTypes>
	{
	}
	
	#endregion LeadChurnReasonProperty
}

