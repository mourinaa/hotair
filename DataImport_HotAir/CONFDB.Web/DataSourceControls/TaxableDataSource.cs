﻿#region Using Directives
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
	/// Represents the DataRepository.TaxableProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TaxableDataSourceDesigner))]
	public class TaxableDataSource : ProviderDataSource<Taxable, TaxableKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxableDataSource class.
		/// </summary>
		public TaxableDataSource() : base(new TaxableService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TaxableDataSourceView used by the TaxableDataSource.
		/// </summary>
		protected TaxableDataSourceView TaxableView
		{
			get { return ( View as TaxableDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TaxableDataSource control invokes to retrieve data.
		/// </summary>
		public TaxableSelectMethod SelectMethod
		{
			get
			{
				TaxableSelectMethod selectMethod = TaxableSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TaxableSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TaxableDataSourceView class that is to be
		/// used by the TaxableDataSource.
		/// </summary>
		/// <returns>An instance of the TaxableDataSourceView class.</returns>
		protected override BaseDataSourceView<Taxable, TaxableKey> GetNewDataSourceView()
		{
			return new TaxableDataSourceView(this, DefaultViewName);
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
	/// Supports the TaxableDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TaxableDataSourceView : ProviderDataSourceView<Taxable, TaxableKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxableDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TaxableDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TaxableDataSourceView(TaxableDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TaxableDataSource TaxableOwner
		{
			get { return Owner as TaxableDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TaxableSelectMethod SelectMethod
		{
			get { return TaxableOwner.SelectMethod; }
			set { TaxableOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TaxableService TaxableProvider
		{
			get { return Provider as TaxableService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Taxable> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Taxable> results = null;
			Taxable item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TaxableSelectMethod.Get:
					TaxableKey entityKey  = new TaxableKey();
					entityKey.Load(values);
					item = TaxableProvider.Get(entityKey);
					results = new TList<Taxable>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TaxableSelectMethod.GetAll:
                    results = TaxableProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TaxableSelectMethod.GetPaged:
					results = TaxableProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TaxableSelectMethod.Find:
					if ( FilterParameters != null )
						results = TaxableProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TaxableProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TaxableSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TaxableProvider.GetById(_id);
					results = new TList<Taxable>();
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
			if ( SelectMethod == TaxableSelectMethod.Get || SelectMethod == TaxableSelectMethod.GetById )
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
				Taxable entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TaxableProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Taxable> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TaxableProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TaxableDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TaxableDataSource class.
	/// </summary>
	public class TaxableDataSourceDesigner : ProviderDataSourceDesigner<Taxable, TaxableKey>
	{
		/// <summary>
		/// Initializes a new instance of the TaxableDataSourceDesigner class.
		/// </summary>
		public TaxableDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaxableSelectMethod SelectMethod
		{
			get { return ((TaxableDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TaxableDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TaxableDataSourceActionList

	/// <summary>
	/// Supports the TaxableDataSourceDesigner class.
	/// </summary>
	internal class TaxableDataSourceActionList : DesignerActionList
	{
		private TaxableDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TaxableDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TaxableDataSourceActionList(TaxableDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaxableSelectMethod SelectMethod
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

	#endregion TaxableDataSourceActionList
	
	#endregion TaxableDataSourceDesigner
	
	#region TaxableSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TaxableDataSource.SelectMethod property.
	/// </summary>
	public enum TaxableSelectMethod
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
	
	#endregion TaxableSelectMethod

	#region TaxableFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Taxable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxableFilter : SqlFilter<TaxableColumn>
	{
	}
	
	#endregion TaxableFilter

	#region TaxableExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Taxable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxableExpressionBuilder : SqlExpressionBuilder<TaxableColumn>
	{
	}
	
	#endregion TaxableExpressionBuilder	

	#region TaxableProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TaxableChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Taxable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxableProperty : ChildEntityProperty<TaxableChildEntityTypes>
	{
	}
	
	#endregion TaxableProperty
}

