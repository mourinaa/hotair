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
	/// Represents the DataRepository.LeadSourceProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadSourceDataSourceDesigner))]
	public class LeadSourceDataSource : ProviderDataSource<LeadSource, LeadSourceKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceDataSource class.
		/// </summary>
		public LeadSourceDataSource() : base(new LeadSourceService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadSourceDataSourceView used by the LeadSourceDataSource.
		/// </summary>
		protected LeadSourceDataSourceView LeadSourceView
		{
			get { return ( View as LeadSourceDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadSourceDataSource control invokes to retrieve data.
		/// </summary>
		public LeadSourceSelectMethod SelectMethod
		{
			get
			{
				LeadSourceSelectMethod selectMethod = LeadSourceSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadSourceSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadSourceDataSourceView class that is to be
		/// used by the LeadSourceDataSource.
		/// </summary>
		/// <returns>An instance of the LeadSourceDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadSource, LeadSourceKey> GetNewDataSourceView()
		{
			return new LeadSourceDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadSourceDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadSourceDataSourceView : ProviderDataSourceView<LeadSource, LeadSourceKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadSourceDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadSourceDataSourceView(LeadSourceDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadSourceDataSource LeadSourceOwner
		{
			get { return Owner as LeadSourceDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadSourceSelectMethod SelectMethod
		{
			get { return LeadSourceOwner.SelectMethod; }
			set { LeadSourceOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadSourceService LeadSourceProvider
		{
			get { return Provider as LeadSourceService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadSource> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadSource> results = null;
			LeadSource item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case LeadSourceSelectMethod.Get:
					LeadSourceKey entityKey  = new LeadSourceKey();
					entityKey.Load(values);
					item = LeadSourceProvider.Get(entityKey);
					results = new TList<LeadSource>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadSourceSelectMethod.GetAll:
                    results = LeadSourceProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadSourceSelectMethod.GetPaged:
					results = LeadSourceProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadSourceSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadSourceProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadSourceProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadSourceSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadSourceProvider.GetById(_id);
					results = new TList<LeadSource>();
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
			if ( SelectMethod == LeadSourceSelectMethod.Get || SelectMethod == LeadSourceSelectMethod.GetById )
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
				LeadSource entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadSourceProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadSource> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadSourceProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadSourceDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadSourceDataSource class.
	/// </summary>
	public class LeadSourceDataSourceDesigner : ProviderDataSourceDesigner<LeadSource, LeadSourceKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadSourceDataSourceDesigner class.
		/// </summary>
		public LeadSourceDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadSourceSelectMethod SelectMethod
		{
			get { return ((LeadSourceDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadSourceDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadSourceDataSourceActionList

	/// <summary>
	/// Supports the LeadSourceDataSourceDesigner class.
	/// </summary>
	internal class LeadSourceDataSourceActionList : DesignerActionList
	{
		private LeadSourceDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadSourceDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadSourceDataSourceActionList(LeadSourceDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadSourceSelectMethod SelectMethod
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

	#endregion LeadSourceDataSourceActionList
	
	#endregion LeadSourceDataSourceDesigner
	
	#region LeadSourceSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadSourceDataSource.SelectMethod property.
	/// </summary>
	public enum LeadSourceSelectMethod
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
	
	#endregion LeadSourceSelectMethod

	#region LeadSourceFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceFilter : SqlFilter<LeadSourceColumn>
	{
	}
	
	#endregion LeadSourceFilter

	#region LeadSourceExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceExpressionBuilder : SqlExpressionBuilder<LeadSourceColumn>
	{
	}
	
	#endregion LeadSourceExpressionBuilder	

	#region LeadSourceProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadSourceChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceProperty : ChildEntityProperty<LeadSourceChildEntityTypes>
	{
	}
	
	#endregion LeadSourceProperty
}

