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
	/// Represents the DataRepository.WholesalerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WholesalerDataSourceDesigner))]
	public class WholesalerDataSource : ProviderDataSource<Wholesaler, WholesalerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerDataSource class.
		/// </summary>
		public WholesalerDataSource() : base(new WholesalerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WholesalerDataSourceView used by the WholesalerDataSource.
		/// </summary>
		protected WholesalerDataSourceView WholesalerView
		{
			get { return ( View as WholesalerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WholesalerDataSource control invokes to retrieve data.
		/// </summary>
		public WholesalerSelectMethod SelectMethod
		{
			get
			{
				WholesalerSelectMethod selectMethod = WholesalerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WholesalerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WholesalerDataSourceView class that is to be
		/// used by the WholesalerDataSource.
		/// </summary>
		/// <returns>An instance of the WholesalerDataSourceView class.</returns>
		protected override BaseDataSourceView<Wholesaler, WholesalerKey> GetNewDataSourceView()
		{
			return new WholesalerDataSourceView(this, DefaultViewName);
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
	/// Supports the WholesalerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WholesalerDataSourceView : ProviderDataSourceView<Wholesaler, WholesalerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WholesalerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WholesalerDataSourceView(WholesalerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WholesalerDataSource WholesalerOwner
		{
			get { return Owner as WholesalerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WholesalerSelectMethod SelectMethod
		{
			get { return WholesalerOwner.SelectMethod; }
			set { WholesalerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WholesalerService WholesalerProvider
		{
			get { return Provider as WholesalerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Wholesaler> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Wholesaler> results = null;
			Wholesaler item;
			count = 0;
			
			System.String _id;
			System.String _currencyId_nullable;
			System.String _billingCountry_nullable;
			System.String _billingRegion_nullable;
			System.Int32 _taxableId;
			System.String _languageId;

			switch ( SelectMethod )
			{
				case WholesalerSelectMethod.Get:
					WholesalerKey entityKey  = new WholesalerKey();
					entityKey.Load(values);
					item = WholesalerProvider.Get(entityKey);
					results = new TList<Wholesaler>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WholesalerSelectMethod.GetAll:
                    results = WholesalerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WholesalerSelectMethod.GetPaged:
					results = WholesalerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WholesalerSelectMethod.Find:
					if ( FilterParameters != null )
						results = WholesalerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WholesalerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WholesalerSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
					item = WholesalerProvider.GetById(_id);
					results = new TList<Wholesaler>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case WholesalerSelectMethod.GetByCurrencyId:
					_currencyId_nullable = (System.String) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.String));
					results = WholesalerProvider.GetByCurrencyId(_currencyId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WholesalerSelectMethod.GetByBillingCountry:
					_billingCountry_nullable = (System.String) EntityUtil.ChangeType(values["BillingCountry"], typeof(System.String));
					results = WholesalerProvider.GetByBillingCountry(_billingCountry_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WholesalerSelectMethod.GetByBillingRegion:
					_billingRegion_nullable = (System.String) EntityUtil.ChangeType(values["BillingRegion"], typeof(System.String));
					results = WholesalerProvider.GetByBillingRegion(_billingRegion_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WholesalerSelectMethod.GetByTaxableId:
					_taxableId = ( values["TaxableId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TaxableId"], typeof(System.Int32)) : (int)0;
					results = WholesalerProvider.GetByTaxableId(_taxableId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case WholesalerSelectMethod.GetByLanguageIdFromIrWholesaler:
					_languageId = ( values["LanguageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["LanguageId"], typeof(System.String)) : string.Empty;
					results = WholesalerProvider.GetByLanguageIdFromIrWholesaler(_languageId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == WholesalerSelectMethod.Get || SelectMethod == WholesalerSelectMethod.GetById )
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
				Wholesaler entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WholesalerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Wholesaler> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WholesalerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WholesalerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WholesalerDataSource class.
	/// </summary>
	public class WholesalerDataSourceDesigner : ProviderDataSourceDesigner<Wholesaler, WholesalerKey>
	{
		/// <summary>
		/// Initializes a new instance of the WholesalerDataSourceDesigner class.
		/// </summary>
		public WholesalerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WholesalerSelectMethod SelectMethod
		{
			get { return ((WholesalerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WholesalerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WholesalerDataSourceActionList

	/// <summary>
	/// Supports the WholesalerDataSourceDesigner class.
	/// </summary>
	internal class WholesalerDataSourceActionList : DesignerActionList
	{
		private WholesalerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WholesalerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WholesalerDataSourceActionList(WholesalerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WholesalerSelectMethod SelectMethod
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

	#endregion WholesalerDataSourceActionList
	
	#endregion WholesalerDataSourceDesigner
	
	#region WholesalerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WholesalerDataSource.SelectMethod property.
	/// </summary>
	public enum WholesalerSelectMethod
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
		/// Represents the GetByCurrencyId method.
		/// </summary>
		GetByCurrencyId,
		/// <summary>
		/// Represents the GetByBillingCountry method.
		/// </summary>
		GetByBillingCountry,
		/// <summary>
		/// Represents the GetByBillingRegion method.
		/// </summary>
		GetByBillingRegion,
		/// <summary>
		/// Represents the GetByTaxableId method.
		/// </summary>
		GetByTaxableId,
		/// <summary>
		/// Represents the GetByLanguageIdFromIrWholesaler method.
		/// </summary>
		GetByLanguageIdFromIrWholesaler
	}
	
	#endregion WholesalerSelectMethod

	#region WholesalerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerFilter : SqlFilter<WholesalerColumn>
	{
	}
	
	#endregion WholesalerFilter

	#region WholesalerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerExpressionBuilder : SqlExpressionBuilder<WholesalerColumn>
	{
	}
	
	#endregion WholesalerExpressionBuilder	

	#region WholesalerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WholesalerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerProperty : ChildEntityProperty<WholesalerChildEntityTypes>
	{
	}
	
	#endregion WholesalerProperty
}

