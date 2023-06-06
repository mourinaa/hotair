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
	/// Represents the DataRepository.CompanyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CompanyDataSourceDesigner))]
	public class CompanyDataSource : ProviderDataSource<Company, CompanyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDataSource class.
		/// </summary>
		public CompanyDataSource() : base(new CompanyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CompanyDataSourceView used by the CompanyDataSource.
		/// </summary>
		protected CompanyDataSourceView CompanyView
		{
			get { return ( View as CompanyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CompanyDataSource control invokes to retrieve data.
		/// </summary>
		public CompanySelectMethod SelectMethod
		{
			get
			{
				CompanySelectMethod selectMethod = CompanySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CompanySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CompanyDataSourceView class that is to be
		/// used by the CompanyDataSource.
		/// </summary>
		/// <returns>An instance of the CompanyDataSourceView class.</returns>
		protected override BaseDataSourceView<Company, CompanyKey> GetNewDataSourceView()
		{
			return new CompanyDataSourceView(this, DefaultViewName);
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
	/// Supports the CompanyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CompanyDataSourceView : ProviderDataSourceView<Company, CompanyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CompanyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CompanyDataSourceView(CompanyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CompanyDataSource CompanyOwner
		{
			get { return Owner as CompanyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CompanySelectMethod SelectMethod
		{
			get { return CompanyOwner.SelectMethod; }
			set { CompanyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CompanyService CompanyProvider
		{
			get { return Provider as CompanyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Company> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Company> results = null;
			Company item;
			count = 0;
			
			System.Int32 _id;
			System.String _wholesalerId;
			System.String _description_nullable;

			switch ( SelectMethod )
			{
				case CompanySelectMethod.Get:
					CompanyKey entityKey  = new CompanyKey();
					entityKey.Load(values);
					item = CompanyProvider.Get(entityKey);
					results = new TList<Company>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CompanySelectMethod.GetAll:
                    results = CompanyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CompanySelectMethod.GetPaged:
					results = CompanyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CompanySelectMethod.Find:
					if ( FilterParameters != null )
						results = CompanyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CompanyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CompanySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CompanyProvider.GetById(_id);
					results = new TList<Company>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CompanySelectMethod.GetByWholesalerIdDescription:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_description_nullable = (System.String) EntityUtil.ChangeType(values["Description"], typeof(System.String));
					item = CompanyProvider.GetByWholesalerIdDescription(_wholesalerId, _description_nullable);
					results = new TList<Company>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case CompanySelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = CompanyProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CompanySelectMethod.Get || SelectMethod == CompanySelectMethod.GetById )
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
				Company entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CompanyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Company> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CompanyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CompanyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CompanyDataSource class.
	/// </summary>
	public class CompanyDataSourceDesigner : ProviderDataSourceDesigner<Company, CompanyKey>
	{
		/// <summary>
		/// Initializes a new instance of the CompanyDataSourceDesigner class.
		/// </summary>
		public CompanyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanySelectMethod SelectMethod
		{
			get { return ((CompanyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CompanyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CompanyDataSourceActionList

	/// <summary>
	/// Supports the CompanyDataSourceDesigner class.
	/// </summary>
	internal class CompanyDataSourceActionList : DesignerActionList
	{
		private CompanyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CompanyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CompanyDataSourceActionList(CompanyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanySelectMethod SelectMethod
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

	#endregion CompanyDataSourceActionList
	
	#endregion CompanyDataSourceDesigner
	
	#region CompanySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CompanyDataSource.SelectMethod property.
	/// </summary>
	public enum CompanySelectMethod
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
		/// Represents the GetByWholesalerIdDescription method.
		/// </summary>
		GetByWholesalerIdDescription,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion CompanySelectMethod

	#region CompanyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Company"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyFilter : SqlFilter<CompanyColumn>
	{
	}
	
	#endregion CompanyFilter

	#region CompanyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Company"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyExpressionBuilder : SqlExpressionBuilder<CompanyColumn>
	{
	}
	
	#endregion CompanyExpressionBuilder	

	#region CompanyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CompanyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Company"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyProperty : ChildEntityProperty<CompanyChildEntityTypes>
	{
	}
	
	#endregion CompanyProperty
}

