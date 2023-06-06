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
	/// Represents the DataRepository.CompanyLeadTrackingNotesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CompanyLeadTrackingNotesDataSourceDesigner))]
	public class CompanyLeadTrackingNotesDataSource : ProviderDataSource<CompanyLeadTrackingNotes, CompanyLeadTrackingNotesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesDataSource class.
		/// </summary>
		public CompanyLeadTrackingNotesDataSource() : base(new CompanyLeadTrackingNotesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CompanyLeadTrackingNotesDataSourceView used by the CompanyLeadTrackingNotesDataSource.
		/// </summary>
		protected CompanyLeadTrackingNotesDataSourceView CompanyLeadTrackingNotesView
		{
			get { return ( View as CompanyLeadTrackingNotesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CompanyLeadTrackingNotesDataSource control invokes to retrieve data.
		/// </summary>
		public CompanyLeadTrackingNotesSelectMethod SelectMethod
		{
			get
			{
				CompanyLeadTrackingNotesSelectMethod selectMethod = CompanyLeadTrackingNotesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CompanyLeadTrackingNotesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CompanyLeadTrackingNotesDataSourceView class that is to be
		/// used by the CompanyLeadTrackingNotesDataSource.
		/// </summary>
		/// <returns>An instance of the CompanyLeadTrackingNotesDataSourceView class.</returns>
		protected override BaseDataSourceView<CompanyLeadTrackingNotes, CompanyLeadTrackingNotesKey> GetNewDataSourceView()
		{
			return new CompanyLeadTrackingNotesDataSourceView(this, DefaultViewName);
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
	/// Supports the CompanyLeadTrackingNotesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CompanyLeadTrackingNotesDataSourceView : ProviderDataSourceView<CompanyLeadTrackingNotes, CompanyLeadTrackingNotesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CompanyLeadTrackingNotesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CompanyLeadTrackingNotesDataSourceView(CompanyLeadTrackingNotesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CompanyLeadTrackingNotesDataSource CompanyLeadTrackingNotesOwner
		{
			get { return Owner as CompanyLeadTrackingNotesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CompanyLeadTrackingNotesSelectMethod SelectMethod
		{
			get { return CompanyLeadTrackingNotesOwner.SelectMethod; }
			set { CompanyLeadTrackingNotesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CompanyLeadTrackingNotesService CompanyLeadTrackingNotesProvider
		{
			get { return Provider as CompanyLeadTrackingNotesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CompanyLeadTrackingNotes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CompanyLeadTrackingNotes> results = null;
			CompanyLeadTrackingNotes item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _companyLeadTrackingId;

			switch ( SelectMethod )
			{
				case CompanyLeadTrackingNotesSelectMethod.Get:
					CompanyLeadTrackingNotesKey entityKey  = new CompanyLeadTrackingNotesKey();
					entityKey.Load(values);
					item = CompanyLeadTrackingNotesProvider.Get(entityKey);
					results = new TList<CompanyLeadTrackingNotes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CompanyLeadTrackingNotesSelectMethod.GetAll:
                    results = CompanyLeadTrackingNotesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CompanyLeadTrackingNotesSelectMethod.GetPaged:
					results = CompanyLeadTrackingNotesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CompanyLeadTrackingNotesSelectMethod.Find:
					if ( FilterParameters != null )
						results = CompanyLeadTrackingNotesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CompanyLeadTrackingNotesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CompanyLeadTrackingNotesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CompanyLeadTrackingNotesProvider.GetById(_id);
					results = new TList<CompanyLeadTrackingNotes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CompanyLeadTrackingNotesSelectMethod.GetByCompanyLeadTrackingId:
					_companyLeadTrackingId = ( values["CompanyLeadTrackingId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CompanyLeadTrackingId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingNotesProvider.GetByCompanyLeadTrackingId(_companyLeadTrackingId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CompanyLeadTrackingNotesSelectMethod.Get || SelectMethod == CompanyLeadTrackingNotesSelectMethod.GetById )
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
				CompanyLeadTrackingNotes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CompanyLeadTrackingNotesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CompanyLeadTrackingNotes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CompanyLeadTrackingNotesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CompanyLeadTrackingNotesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CompanyLeadTrackingNotesDataSource class.
	/// </summary>
	public class CompanyLeadTrackingNotesDataSourceDesigner : ProviderDataSourceDesigner<CompanyLeadTrackingNotes, CompanyLeadTrackingNotesKey>
	{
		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesDataSourceDesigner class.
		/// </summary>
		public CompanyLeadTrackingNotesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyLeadTrackingNotesSelectMethod SelectMethod
		{
			get { return ((CompanyLeadTrackingNotesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CompanyLeadTrackingNotesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CompanyLeadTrackingNotesDataSourceActionList

	/// <summary>
	/// Supports the CompanyLeadTrackingNotesDataSourceDesigner class.
	/// </summary>
	internal class CompanyLeadTrackingNotesDataSourceActionList : DesignerActionList
	{
		private CompanyLeadTrackingNotesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CompanyLeadTrackingNotesDataSourceActionList(CompanyLeadTrackingNotesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyLeadTrackingNotesSelectMethod SelectMethod
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

	#endregion CompanyLeadTrackingNotesDataSourceActionList
	
	#endregion CompanyLeadTrackingNotesDataSourceDesigner
	
	#region CompanyLeadTrackingNotesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CompanyLeadTrackingNotesDataSource.SelectMethod property.
	/// </summary>
	public enum CompanyLeadTrackingNotesSelectMethod
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
		/// Represents the GetByCompanyLeadTrackingId method.
		/// </summary>
		GetByCompanyLeadTrackingId
	}
	
	#endregion CompanyLeadTrackingNotesSelectMethod

	#region CompanyLeadTrackingNotesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesFilter : SqlFilter<CompanyLeadTrackingNotesColumn>
	{
	}
	
	#endregion CompanyLeadTrackingNotesFilter

	#region CompanyLeadTrackingNotesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesExpressionBuilder : SqlExpressionBuilder<CompanyLeadTrackingNotesColumn>
	{
	}
	
	#endregion CompanyLeadTrackingNotesExpressionBuilder	

	#region CompanyLeadTrackingNotesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CompanyLeadTrackingNotesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesProperty : ChildEntityProperty<CompanyLeadTrackingNotesChildEntityTypes>
	{
	}
	
	#endregion CompanyLeadTrackingNotesProperty
}

