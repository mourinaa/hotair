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
	/// Represents the DataRepository.CountryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CountryDataSourceDesigner))]
	public class CountryDataSource : ProviderDataSource<Country, CountryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryDataSource class.
		/// </summary>
		public CountryDataSource() : base(new CountryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CountryDataSourceView used by the CountryDataSource.
		/// </summary>
		protected CountryDataSourceView CountryView
		{
			get { return ( View as CountryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CountryDataSource control invokes to retrieve data.
		/// </summary>
		public CountrySelectMethod SelectMethod
		{
			get
			{
				CountrySelectMethod selectMethod = CountrySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CountrySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CountryDataSourceView class that is to be
		/// used by the CountryDataSource.
		/// </summary>
		/// <returns>An instance of the CountryDataSourceView class.</returns>
		protected override BaseDataSourceView<Country, CountryKey> GetNewDataSourceView()
		{
			return new CountryDataSourceView(this, DefaultViewName);
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
	/// Supports the CountryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CountryDataSourceView : ProviderDataSourceView<Country, CountryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CountryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CountryDataSourceView(CountryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CountryDataSource CountryOwner
		{
			get { return Owner as CountryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CountrySelectMethod SelectMethod
		{
			get { return CountryOwner.SelectMethod; }
			set { CountryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CountryService CountryProvider
		{
			get { return Provider as CountryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Country> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Country> results = null;
			Country item;
			count = 0;
			
			System.String _id;
			System.String _countryAreaCode_nullable;

			switch ( SelectMethod )
			{
				case CountrySelectMethod.Get:
					CountryKey entityKey  = new CountryKey();
					entityKey.Load(values);
					item = CountryProvider.Get(entityKey);
					results = new TList<Country>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CountrySelectMethod.GetAll:
                    results = CountryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CountrySelectMethod.GetPaged:
					results = CountryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CountrySelectMethod.Find:
					if ( FilterParameters != null )
						results = CountryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CountryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CountrySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = CountryProvider.GetById(_id);
					results = new TList<Country>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CountrySelectMethod.GetByCountryAreaCode:
					_countryAreaCode_nullable = (System.String) EntityUtil.ChangeType(values["CountryAreaCode"], typeof(System.String));
					results = CountryProvider.GetByCountryAreaCode(_countryAreaCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == CountrySelectMethod.Get || SelectMethod == CountrySelectMethod.GetById )
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
				Country entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CountryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Country> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CountryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CountryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CountryDataSource class.
	/// </summary>
	public class CountryDataSourceDesigner : ProviderDataSourceDesigner<Country, CountryKey>
	{
		/// <summary>
		/// Initializes a new instance of the CountryDataSourceDesigner class.
		/// </summary>
		public CountryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountrySelectMethod SelectMethod
		{
			get { return ((CountryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CountryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CountryDataSourceActionList

	/// <summary>
	/// Supports the CountryDataSourceDesigner class.
	/// </summary>
	internal class CountryDataSourceActionList : DesignerActionList
	{
		private CountryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CountryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CountryDataSourceActionList(CountryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountrySelectMethod SelectMethod
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

	#endregion CountryDataSourceActionList
	
	#endregion CountryDataSourceDesigner
	
	#region CountrySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CountryDataSource.SelectMethod property.
	/// </summary>
	public enum CountrySelectMethod
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
		/// Represents the GetByCountryAreaCode method.
		/// </summary>
		GetByCountryAreaCode
	}
	
	#endregion CountrySelectMethod

	#region CountryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryFilter : SqlFilter<CountryColumn>
	{
	}
	
	#endregion CountryFilter

	#region CountryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryExpressionBuilder : SqlExpressionBuilder<CountryColumn>
	{
	}
	
	#endregion CountryExpressionBuilder	

	#region CountryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CountryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryProperty : ChildEntityProperty<CountryChildEntityTypes>
	{
	}
	
	#endregion CountryProperty
}

