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
	/// Represents the DataRepository.CompanyInfoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CompanyInfoDataSourceDesigner))]
	public class CompanyInfoDataSource : ProviderDataSource<CompanyInfo, CompanyInfoKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoDataSource class.
		/// </summary>
		public CompanyInfoDataSource() : base(new CompanyInfoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CompanyInfoDataSourceView used by the CompanyInfoDataSource.
		/// </summary>
		protected CompanyInfoDataSourceView CompanyInfoView
		{
			get { return ( View as CompanyInfoDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CompanyInfoDataSource control invokes to retrieve data.
		/// </summary>
		public CompanyInfoSelectMethod SelectMethod
		{
			get
			{
				CompanyInfoSelectMethod selectMethod = CompanyInfoSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CompanyInfoSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CompanyInfoDataSourceView class that is to be
		/// used by the CompanyInfoDataSource.
		/// </summary>
		/// <returns>An instance of the CompanyInfoDataSourceView class.</returns>
		protected override BaseDataSourceView<CompanyInfo, CompanyInfoKey> GetNewDataSourceView()
		{
			return new CompanyInfoDataSourceView(this, DefaultViewName);
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
	/// Supports the CompanyInfoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CompanyInfoDataSourceView : ProviderDataSourceView<CompanyInfo, CompanyInfoKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CompanyInfoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CompanyInfoDataSourceView(CompanyInfoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CompanyInfoDataSource CompanyInfoOwner
		{
			get { return Owner as CompanyInfoDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CompanyInfoSelectMethod SelectMethod
		{
			get { return CompanyInfoOwner.SelectMethod; }
			set { CompanyInfoOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CompanyInfoService CompanyInfoProvider
		{
			get { return Provider as CompanyInfoService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CompanyInfo> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CompanyInfo> results = null;
			CompanyInfo item;
			count = 0;
			
			System.Int32 _id;
			System.String _countryId;

			switch ( SelectMethod )
			{
				case CompanyInfoSelectMethod.Get:
					CompanyInfoKey entityKey  = new CompanyInfoKey();
					entityKey.Load(values);
					item = CompanyInfoProvider.Get(entityKey);
					results = new TList<CompanyInfo>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CompanyInfoSelectMethod.GetAll:
                    results = CompanyInfoProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CompanyInfoSelectMethod.GetPaged:
					results = CompanyInfoProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CompanyInfoSelectMethod.Find:
					if ( FilterParameters != null )
						results = CompanyInfoProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CompanyInfoProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CompanyInfoSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CompanyInfoProvider.GetById(_id);
					results = new TList<CompanyInfo>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CompanyInfoSelectMethod.GetByCountryId:
					_countryId = ( values["CountryId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CountryId"], typeof(System.String)) : string.Empty;
					results = CompanyInfoProvider.GetByCountryId(_countryId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CompanyInfoSelectMethod.Get || SelectMethod == CompanyInfoSelectMethod.GetById )
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
				CompanyInfo entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CompanyInfoProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CompanyInfo> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CompanyInfoProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CompanyInfoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CompanyInfoDataSource class.
	/// </summary>
	public class CompanyInfoDataSourceDesigner : ProviderDataSourceDesigner<CompanyInfo, CompanyInfoKey>
	{
		/// <summary>
		/// Initializes a new instance of the CompanyInfoDataSourceDesigner class.
		/// </summary>
		public CompanyInfoDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyInfoSelectMethod SelectMethod
		{
			get { return ((CompanyInfoDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CompanyInfoDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CompanyInfoDataSourceActionList

	/// <summary>
	/// Supports the CompanyInfoDataSourceDesigner class.
	/// </summary>
	internal class CompanyInfoDataSourceActionList : DesignerActionList
	{
		private CompanyInfoDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CompanyInfoDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CompanyInfoDataSourceActionList(CompanyInfoDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyInfoSelectMethod SelectMethod
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

	#endregion CompanyInfoDataSourceActionList
	
	#endregion CompanyInfoDataSourceDesigner
	
	#region CompanyInfoSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CompanyInfoDataSource.SelectMethod property.
	/// </summary>
	public enum CompanyInfoSelectMethod
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
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId
	}
	
	#endregion CompanyInfoSelectMethod

	#region CompanyInfoFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoFilter : SqlFilter<CompanyInfoColumn>
	{
	}
	
	#endregion CompanyInfoFilter

	#region CompanyInfoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoExpressionBuilder : SqlExpressionBuilder<CompanyInfoColumn>
	{
	}
	
	#endregion CompanyInfoExpressionBuilder	

	#region CompanyInfoProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CompanyInfoChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoProperty : ChildEntityProperty<CompanyInfoChildEntityTypes>
	{
	}
	
	#endregion CompanyInfoProperty
}

