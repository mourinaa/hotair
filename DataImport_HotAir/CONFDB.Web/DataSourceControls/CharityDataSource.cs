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
	/// Represents the DataRepository.CharityProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CharityDataSourceDesigner))]
	public class CharityDataSource : ProviderDataSource<Charity, CharityKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CharityDataSource class.
		/// </summary>
		public CharityDataSource() : base(new CharityService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CharityDataSourceView used by the CharityDataSource.
		/// </summary>
		protected CharityDataSourceView CharityView
		{
			get { return ( View as CharityDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CharityDataSource control invokes to retrieve data.
		/// </summary>
		public CharitySelectMethod SelectMethod
		{
			get
			{
				CharitySelectMethod selectMethod = CharitySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CharitySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CharityDataSourceView class that is to be
		/// used by the CharityDataSource.
		/// </summary>
		/// <returns>An instance of the CharityDataSourceView class.</returns>
		protected override BaseDataSourceView<Charity, CharityKey> GetNewDataSourceView()
		{
			return new CharityDataSourceView(this, DefaultViewName);
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
	/// Supports the CharityDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CharityDataSourceView : ProviderDataSourceView<Charity, CharityKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CharityDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CharityDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CharityDataSourceView(CharityDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CharityDataSource CharityOwner
		{
			get { return Owner as CharityDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CharitySelectMethod SelectMethod
		{
			get { return CharityOwner.SelectMethod; }
			set { CharityOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CharityService CharityProvider
		{
			get { return Provider as CharityService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Charity> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Charity> results = null;
			Charity item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case CharitySelectMethod.Get:
					CharityKey entityKey  = new CharityKey();
					entityKey.Load(values);
					item = CharityProvider.Get(entityKey);
					results = new TList<Charity>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CharitySelectMethod.GetAll:
                    results = CharityProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CharitySelectMethod.GetPaged:
					results = CharityProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CharitySelectMethod.Find:
					if ( FilterParameters != null )
						results = CharityProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CharityProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CharitySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CharityProvider.GetById(_id);
					results = new TList<Charity>();
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
			if ( SelectMethod == CharitySelectMethod.Get || SelectMethod == CharitySelectMethod.GetById )
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
				Charity entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CharityProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Charity> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CharityProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CharityDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CharityDataSource class.
	/// </summary>
	public class CharityDataSourceDesigner : ProviderDataSourceDesigner<Charity, CharityKey>
	{
		/// <summary>
		/// Initializes a new instance of the CharityDataSourceDesigner class.
		/// </summary>
		public CharityDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CharitySelectMethod SelectMethod
		{
			get { return ((CharityDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CharityDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CharityDataSourceActionList

	/// <summary>
	/// Supports the CharityDataSourceDesigner class.
	/// </summary>
	internal class CharityDataSourceActionList : DesignerActionList
	{
		private CharityDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CharityDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CharityDataSourceActionList(CharityDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CharitySelectMethod SelectMethod
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

	#endregion CharityDataSourceActionList
	
	#endregion CharityDataSourceDesigner
	
	#region CharitySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CharityDataSource.SelectMethod property.
	/// </summary>
	public enum CharitySelectMethod
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
	
	#endregion CharitySelectMethod

	#region CharityFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Charity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CharityFilter : SqlFilter<CharityColumn>
	{
	}
	
	#endregion CharityFilter

	#region CharityExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Charity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CharityExpressionBuilder : SqlExpressionBuilder<CharityColumn>
	{
	}
	
	#endregion CharityExpressionBuilder	

	#region CharityProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CharityChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Charity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CharityProperty : ChildEntityProperty<CharityChildEntityTypes>
	{
	}
	
	#endregion CharityProperty
}

