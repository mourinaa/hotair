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
	/// Represents the DataRepository.AverageRatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AverageRatesDataSourceDesigner))]
	public class AverageRatesDataSource : ProviderDataSource<AverageRates, AverageRatesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesDataSource class.
		/// </summary>
		public AverageRatesDataSource() : base(new AverageRatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AverageRatesDataSourceView used by the AverageRatesDataSource.
		/// </summary>
		protected AverageRatesDataSourceView AverageRatesView
		{
			get { return ( View as AverageRatesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AverageRatesDataSource control invokes to retrieve data.
		/// </summary>
		public AverageRatesSelectMethod SelectMethod
		{
			get
			{
				AverageRatesSelectMethod selectMethod = AverageRatesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AverageRatesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AverageRatesDataSourceView class that is to be
		/// used by the AverageRatesDataSource.
		/// </summary>
		/// <returns>An instance of the AverageRatesDataSourceView class.</returns>
		protected override BaseDataSourceView<AverageRates, AverageRatesKey> GetNewDataSourceView()
		{
			return new AverageRatesDataSourceView(this, DefaultViewName);
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
	/// Supports the AverageRatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AverageRatesDataSourceView : ProviderDataSourceView<AverageRates, AverageRatesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AverageRatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AverageRatesDataSourceView(AverageRatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AverageRatesDataSource AverageRatesOwner
		{
			get { return Owner as AverageRatesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AverageRatesSelectMethod SelectMethod
		{
			get { return AverageRatesOwner.SelectMethod; }
			set { AverageRatesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AverageRatesService AverageRatesProvider
		{
			get { return Provider as AverageRatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AverageRates> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AverageRates> results = null;
			AverageRates item;
			count = 0;
			
			System.DateTime _usageMonth;
			System.Int32 _productRateId;
			System.String _wholesalerId;

			switch ( SelectMethod )
			{
				case AverageRatesSelectMethod.Get:
					AverageRatesKey entityKey  = new AverageRatesKey();
					entityKey.Load(values);
					item = AverageRatesProvider.Get(entityKey);
					results = new TList<AverageRates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AverageRatesSelectMethod.GetAll:
                    results = AverageRatesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AverageRatesSelectMethod.GetPaged:
					results = AverageRatesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AverageRatesSelectMethod.Find:
					if ( FilterParameters != null )
						results = AverageRatesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AverageRatesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AverageRatesSelectMethod.GetByUsageMonthProductRateIdWholesalerId:
					_usageMonth = ( values["UsageMonth"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["UsageMonth"], typeof(System.DateTime)) : DateTime.MinValue;
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					item = AverageRatesProvider.GetByUsageMonthProductRateIdWholesalerId(_usageMonth, _productRateId, _wholesalerId);
					results = new TList<AverageRates>();
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
			if ( SelectMethod == AverageRatesSelectMethod.Get || SelectMethod == AverageRatesSelectMethod.GetByUsageMonthProductRateIdWholesalerId )
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
				AverageRates entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AverageRatesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AverageRates> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AverageRatesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AverageRatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AverageRatesDataSource class.
	/// </summary>
	public class AverageRatesDataSourceDesigner : ProviderDataSourceDesigner<AverageRates, AverageRatesKey>
	{
		/// <summary>
		/// Initializes a new instance of the AverageRatesDataSourceDesigner class.
		/// </summary>
		public AverageRatesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AverageRatesSelectMethod SelectMethod
		{
			get { return ((AverageRatesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AverageRatesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AverageRatesDataSourceActionList

	/// <summary>
	/// Supports the AverageRatesDataSourceDesigner class.
	/// </summary>
	internal class AverageRatesDataSourceActionList : DesignerActionList
	{
		private AverageRatesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AverageRatesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AverageRatesDataSourceActionList(AverageRatesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AverageRatesSelectMethod SelectMethod
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

	#endregion AverageRatesDataSourceActionList
	
	#endregion AverageRatesDataSourceDesigner
	
	#region AverageRatesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AverageRatesDataSource.SelectMethod property.
	/// </summary>
	public enum AverageRatesSelectMethod
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
		/// Represents the GetByUsageMonthProductRateIdWholesalerId method.
		/// </summary>
		GetByUsageMonthProductRateIdWholesalerId
	}
	
	#endregion AverageRatesSelectMethod

	#region AverageRatesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesFilter : SqlFilter<AverageRatesColumn>
	{
	}
	
	#endregion AverageRatesFilter

	#region AverageRatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesExpressionBuilder : SqlExpressionBuilder<AverageRatesColumn>
	{
	}
	
	#endregion AverageRatesExpressionBuilder	

	#region AverageRatesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AverageRatesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesProperty : ChildEntityProperty<AverageRatesChildEntityTypes>
	{
	}
	
	#endregion AverageRatesProperty
}

