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
	/// Represents the DataRepository.TempTotalDollarsSpentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TempTotalDollarsSpentDataSourceDesigner))]
	public class TempTotalDollarsSpentDataSource : ProviderDataSource<TempTotalDollarsSpent, TempTotalDollarsSpentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentDataSource class.
		/// </summary>
		public TempTotalDollarsSpentDataSource() : base(new TempTotalDollarsSpentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TempTotalDollarsSpentDataSourceView used by the TempTotalDollarsSpentDataSource.
		/// </summary>
		protected TempTotalDollarsSpentDataSourceView TempTotalDollarsSpentView
		{
			get { return ( View as TempTotalDollarsSpentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TempTotalDollarsSpentDataSource control invokes to retrieve data.
		/// </summary>
		public TempTotalDollarsSpentSelectMethod SelectMethod
		{
			get
			{
				TempTotalDollarsSpentSelectMethod selectMethod = TempTotalDollarsSpentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TempTotalDollarsSpentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TempTotalDollarsSpentDataSourceView class that is to be
		/// used by the TempTotalDollarsSpentDataSource.
		/// </summary>
		/// <returns>An instance of the TempTotalDollarsSpentDataSourceView class.</returns>
		protected override BaseDataSourceView<TempTotalDollarsSpent, TempTotalDollarsSpentKey> GetNewDataSourceView()
		{
			return new TempTotalDollarsSpentDataSourceView(this, DefaultViewName);
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
	/// Supports the TempTotalDollarsSpentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TempTotalDollarsSpentDataSourceView : ProviderDataSourceView<TempTotalDollarsSpent, TempTotalDollarsSpentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TempTotalDollarsSpentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TempTotalDollarsSpentDataSourceView(TempTotalDollarsSpentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TempTotalDollarsSpentDataSource TempTotalDollarsSpentOwner
		{
			get { return Owner as TempTotalDollarsSpentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TempTotalDollarsSpentSelectMethod SelectMethod
		{
			get { return TempTotalDollarsSpentOwner.SelectMethod; }
			set { TempTotalDollarsSpentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TempTotalDollarsSpentService TempTotalDollarsSpentProvider
		{
			get { return Provider as TempTotalDollarsSpentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TempTotalDollarsSpent> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TempTotalDollarsSpent> results = null;
			TempTotalDollarsSpent item;
			count = 0;
			
			System.Int32 _id123;
			System.String _priCustomerNumber_nullable;

			switch ( SelectMethod )
			{
				case TempTotalDollarsSpentSelectMethod.Get:
					TempTotalDollarsSpentKey entityKey  = new TempTotalDollarsSpentKey();
					entityKey.Load(values);
					item = TempTotalDollarsSpentProvider.Get(entityKey);
					results = new TList<TempTotalDollarsSpent>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TempTotalDollarsSpentSelectMethod.GetAll:
                    results = TempTotalDollarsSpentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TempTotalDollarsSpentSelectMethod.GetPaged:
					results = TempTotalDollarsSpentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TempTotalDollarsSpentSelectMethod.Find:
					if ( FilterParameters != null )
						results = TempTotalDollarsSpentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TempTotalDollarsSpentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TempTotalDollarsSpentSelectMethod.GetById123:
					_id123 = ( values["Id123"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id123"], typeof(System.Int32)) : (int)0;
					item = TempTotalDollarsSpentProvider.GetById123(_id123);
					results = new TList<TempTotalDollarsSpent>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case TempTotalDollarsSpentSelectMethod.GetByPriCustomerNumber:
					_priCustomerNumber_nullable = (System.String) EntityUtil.ChangeType(values["PriCustomerNumber"], typeof(System.String));
					results = TempTotalDollarsSpentProvider.GetByPriCustomerNumber(_priCustomerNumber_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TempTotalDollarsSpentSelectMethod.Get || SelectMethod == TempTotalDollarsSpentSelectMethod.GetById123 )
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
				TempTotalDollarsSpent entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TempTotalDollarsSpentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TempTotalDollarsSpent> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TempTotalDollarsSpentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TempTotalDollarsSpentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TempTotalDollarsSpentDataSource class.
	/// </summary>
	public class TempTotalDollarsSpentDataSourceDesigner : ProviderDataSourceDesigner<TempTotalDollarsSpent, TempTotalDollarsSpentKey>
	{
		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentDataSourceDesigner class.
		/// </summary>
		public TempTotalDollarsSpentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempTotalDollarsSpentSelectMethod SelectMethod
		{
			get { return ((TempTotalDollarsSpentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TempTotalDollarsSpentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TempTotalDollarsSpentDataSourceActionList

	/// <summary>
	/// Supports the TempTotalDollarsSpentDataSourceDesigner class.
	/// </summary>
	internal class TempTotalDollarsSpentDataSourceActionList : DesignerActionList
	{
		private TempTotalDollarsSpentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TempTotalDollarsSpentDataSourceActionList(TempTotalDollarsSpentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TempTotalDollarsSpentSelectMethod SelectMethod
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

	#endregion TempTotalDollarsSpentDataSourceActionList
	
	#endregion TempTotalDollarsSpentDataSourceDesigner
	
	#region TempTotalDollarsSpentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TempTotalDollarsSpentDataSource.SelectMethod property.
	/// </summary>
	public enum TempTotalDollarsSpentSelectMethod
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
		/// Represents the GetById123 method.
		/// </summary>
		GetById123,
		/// <summary>
		/// Represents the GetByPriCustomerNumber method.
		/// </summary>
		GetByPriCustomerNumber
	}
	
	#endregion TempTotalDollarsSpentSelectMethod

	#region TempTotalDollarsSpentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentFilter : SqlFilter<TempTotalDollarsSpentColumn>
	{
	}
	
	#endregion TempTotalDollarsSpentFilter

	#region TempTotalDollarsSpentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentExpressionBuilder : SqlExpressionBuilder<TempTotalDollarsSpentColumn>
	{
	}
	
	#endregion TempTotalDollarsSpentExpressionBuilder	

	#region TempTotalDollarsSpentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TempTotalDollarsSpentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentProperty : ChildEntityProperty<TempTotalDollarsSpentChildEntityTypes>
	{
	}
	
	#endregion TempTotalDollarsSpentProperty
}

