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
	/// Represents the DataRepository.LeadStageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadStageDataSourceDesigner))]
	public class LeadStageDataSource : ProviderDataSource<LeadStage, LeadStageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadStageDataSource class.
		/// </summary>
		public LeadStageDataSource() : base(new LeadStageService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadStageDataSourceView used by the LeadStageDataSource.
		/// </summary>
		protected LeadStageDataSourceView LeadStageView
		{
			get { return ( View as LeadStageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadStageDataSource control invokes to retrieve data.
		/// </summary>
		public LeadStageSelectMethod SelectMethod
		{
			get
			{
				LeadStageSelectMethod selectMethod = LeadStageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadStageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadStageDataSourceView class that is to be
		/// used by the LeadStageDataSource.
		/// </summary>
		/// <returns>An instance of the LeadStageDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadStage, LeadStageKey> GetNewDataSourceView()
		{
			return new LeadStageDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadStageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadStageDataSourceView : ProviderDataSourceView<LeadStage, LeadStageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadStageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadStageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadStageDataSourceView(LeadStageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadStageDataSource LeadStageOwner
		{
			get { return Owner as LeadStageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadStageSelectMethod SelectMethod
		{
			get { return LeadStageOwner.SelectMethod; }
			set { LeadStageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadStageService LeadStageProvider
		{
			get { return Provider as LeadStageService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadStage> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadStage> results = null;
			LeadStage item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LeadStageSelectMethod.Get:
					LeadStageKey entityKey  = new LeadStageKey();
					entityKey.Load(values);
					item = LeadStageProvider.Get(entityKey);
					results = new TList<LeadStage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadStageSelectMethod.GetAll:
                    results = LeadStageProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadStageSelectMethod.GetPaged:
					results = LeadStageProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadStageSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadStageProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadStageProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadStageSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadStageProvider.GetById(_id);
					results = new TList<LeadStage>();
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
			if ( SelectMethod == LeadStageSelectMethod.Get || SelectMethod == LeadStageSelectMethod.GetById )
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
				LeadStage entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadStageProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadStage> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadStageProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadStageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadStageDataSource class.
	/// </summary>
	public class LeadStageDataSourceDesigner : ProviderDataSourceDesigner<LeadStage, LeadStageKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadStageDataSourceDesigner class.
		/// </summary>
		public LeadStageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadStageSelectMethod SelectMethod
		{
			get { return ((LeadStageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadStageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadStageDataSourceActionList

	/// <summary>
	/// Supports the LeadStageDataSourceDesigner class.
	/// </summary>
	internal class LeadStageDataSourceActionList : DesignerActionList
	{
		private LeadStageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadStageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadStageDataSourceActionList(LeadStageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadStageSelectMethod SelectMethod
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

	#endregion LeadStageDataSourceActionList
	
	#endregion LeadStageDataSourceDesigner
	
	#region LeadStageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadStageDataSource.SelectMethod property.
	/// </summary>
	public enum LeadStageSelectMethod
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
	
	#endregion LeadStageSelectMethod

	#region LeadStageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadStage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadStageFilter : SqlFilter<LeadStageColumn>
	{
	}
	
	#endregion LeadStageFilter

	#region LeadStageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadStage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadStageExpressionBuilder : SqlExpressionBuilder<LeadStageColumn>
	{
	}
	
	#endregion LeadStageExpressionBuilder	

	#region LeadStageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadStageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadStage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadStageProperty : ChildEntityProperty<LeadStageChildEntityTypes>
	{
	}
	
	#endregion LeadStageProperty
}

