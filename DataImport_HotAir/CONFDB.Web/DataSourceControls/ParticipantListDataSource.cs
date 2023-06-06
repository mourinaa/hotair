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
	/// Represents the DataRepository.ParticipantListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ParticipantListDataSourceDesigner))]
	public class ParticipantListDataSource : ProviderDataSource<ParticipantList, ParticipantListKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantListDataSource class.
		/// </summary>
		public ParticipantListDataSource() : base(new ParticipantListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ParticipantListDataSourceView used by the ParticipantListDataSource.
		/// </summary>
		protected ParticipantListDataSourceView ParticipantListView
		{
			get { return ( View as ParticipantListDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ParticipantListDataSource control invokes to retrieve data.
		/// </summary>
		public ParticipantListSelectMethod SelectMethod
		{
			get
			{
				ParticipantListSelectMethod selectMethod = ParticipantListSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ParticipantListSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ParticipantListDataSourceView class that is to be
		/// used by the ParticipantListDataSource.
		/// </summary>
		/// <returns>An instance of the ParticipantListDataSourceView class.</returns>
		protected override BaseDataSourceView<ParticipantList, ParticipantListKey> GetNewDataSourceView()
		{
			return new ParticipantListDataSourceView(this, DefaultViewName);
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
	/// Supports the ParticipantListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ParticipantListDataSourceView : ProviderDataSourceView<ParticipantList, ParticipantListKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ParticipantListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ParticipantListDataSourceView(ParticipantListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ParticipantListDataSource ParticipantListOwner
		{
			get { return Owner as ParticipantListDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ParticipantListSelectMethod SelectMethod
		{
			get { return ParticipantListOwner.SelectMethod; }
			set { ParticipantListOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ParticipantListService ParticipantListProvider
		{
			get { return Provider as ParticipantListService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ParticipantList> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ParticipantList> results = null;
			ParticipantList item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case ParticipantListSelectMethod.Get:
					ParticipantListKey entityKey  = new ParticipantListKey();
					entityKey.Load(values);
					item = ParticipantListProvider.Get(entityKey);
					results = new TList<ParticipantList>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ParticipantListSelectMethod.GetAll:
                    results = ParticipantListProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ParticipantListSelectMethod.GetPaged:
					results = ParticipantListProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ParticipantListSelectMethod.Find:
					if ( FilterParameters != null )
						results = ParticipantListProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ParticipantListProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ParticipantListSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ParticipantListProvider.GetById(_id);
					results = new TList<ParticipantList>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ParticipantListSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = ParticipantListProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == ParticipantListSelectMethod.Get || SelectMethod == ParticipantListSelectMethod.GetById )
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
				ParticipantList entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ParticipantListProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ParticipantList> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ParticipantListProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ParticipantListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ParticipantListDataSource class.
	/// </summary>
	public class ParticipantListDataSourceDesigner : ProviderDataSourceDesigner<ParticipantList, ParticipantListKey>
	{
		/// <summary>
		/// Initializes a new instance of the ParticipantListDataSourceDesigner class.
		/// </summary>
		public ParticipantListDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ParticipantListSelectMethod SelectMethod
		{
			get { return ((ParticipantListDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ParticipantListDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ParticipantListDataSourceActionList

	/// <summary>
	/// Supports the ParticipantListDataSourceDesigner class.
	/// </summary>
	internal class ParticipantListDataSourceActionList : DesignerActionList
	{
		private ParticipantListDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ParticipantListDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ParticipantListDataSourceActionList(ParticipantListDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ParticipantListSelectMethod SelectMethod
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

	#endregion ParticipantListDataSourceActionList
	
	#endregion ParticipantListDataSourceDesigner
	
	#region ParticipantListSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ParticipantListDataSource.SelectMethod property.
	/// </summary>
	public enum ParticipantListSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion ParticipantListSelectMethod

	#region ParticipantListFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ParticipantList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantListFilter : SqlFilter<ParticipantListColumn>
	{
	}
	
	#endregion ParticipantListFilter

	#region ParticipantListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ParticipantList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantListExpressionBuilder : SqlExpressionBuilder<ParticipantListColumn>
	{
	}
	
	#endregion ParticipantListExpressionBuilder	

	#region ParticipantListProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ParticipantListChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ParticipantList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantListProperty : ChildEntityProperty<ParticipantListChildEntityTypes>
	{
	}
	
	#endregion ParticipantListProperty
}

