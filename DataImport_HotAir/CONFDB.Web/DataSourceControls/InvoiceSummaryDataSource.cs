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
	/// Represents the DataRepository.InvoiceSummaryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(InvoiceSummaryDataSourceDesigner))]
	public class InvoiceSummaryDataSource : ProviderDataSource<InvoiceSummary, InvoiceSummaryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryDataSource class.
		/// </summary>
		public InvoiceSummaryDataSource() : base(new InvoiceSummaryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the InvoiceSummaryDataSourceView used by the InvoiceSummaryDataSource.
		/// </summary>
		protected InvoiceSummaryDataSourceView InvoiceSummaryView
		{
			get { return ( View as InvoiceSummaryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the InvoiceSummaryDataSource control invokes to retrieve data.
		/// </summary>
		public InvoiceSummarySelectMethod SelectMethod
		{
			get
			{
				InvoiceSummarySelectMethod selectMethod = InvoiceSummarySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (InvoiceSummarySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the InvoiceSummaryDataSourceView class that is to be
		/// used by the InvoiceSummaryDataSource.
		/// </summary>
		/// <returns>An instance of the InvoiceSummaryDataSourceView class.</returns>
		protected override BaseDataSourceView<InvoiceSummary, InvoiceSummaryKey> GetNewDataSourceView()
		{
			return new InvoiceSummaryDataSourceView(this, DefaultViewName);
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
	/// Supports the InvoiceSummaryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class InvoiceSummaryDataSourceView : ProviderDataSourceView<InvoiceSummary, InvoiceSummaryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the InvoiceSummaryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public InvoiceSummaryDataSourceView(InvoiceSummaryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal InvoiceSummaryDataSource InvoiceSummaryOwner
		{
			get { return Owner as InvoiceSummaryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal InvoiceSummarySelectMethod SelectMethod
		{
			get { return InvoiceSummaryOwner.SelectMethod; }
			set { InvoiceSummaryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal InvoiceSummaryService InvoiceSummaryProvider
		{
			get { return Provider as InvoiceSummaryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<InvoiceSummary> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<InvoiceSummary> results = null;
			InvoiceSummary item;
			count = 0;
			
			System.Int32 _id;
			System.DateTime _startDate;
			System.DateTime _endDate;
			System.String _priCustomerNumber;
			System.String _wholesalerId;
			System.String _invoiceNumber;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case InvoiceSummarySelectMethod.Get:
					InvoiceSummaryKey entityKey  = new InvoiceSummaryKey();
					entityKey.Load(values);
					item = InvoiceSummaryProvider.Get(entityKey);
					results = new TList<InvoiceSummary>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case InvoiceSummarySelectMethod.GetAll:
                    results = InvoiceSummaryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case InvoiceSummarySelectMethod.GetPaged:
					results = InvoiceSummaryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case InvoiceSummarySelectMethod.Find:
					if ( FilterParameters != null )
						results = InvoiceSummaryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = InvoiceSummaryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case InvoiceSummarySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = InvoiceSummaryProvider.GetById(_id);
					results = new TList<InvoiceSummary>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case InvoiceSummarySelectMethod.GetByStartDate:
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = InvoiceSummaryProvider.GetByStartDate(_startDate, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceSummarySelectMethod.GetByEndDate:
					_endDate = ( values["EndDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["EndDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = InvoiceSummaryProvider.GetByEndDate(_endDate, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceSummarySelectMethod.GetByPriCustomerNumberWholesalerId:
					_priCustomerNumber = ( values["PriCustomerNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["PriCustomerNumber"], typeof(System.String)) : string.Empty;
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = InvoiceSummaryProvider.GetByPriCustomerNumberWholesalerId(_priCustomerNumber, _wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceSummarySelectMethod.GetByInvoiceNumber:
					_invoiceNumber = ( values["InvoiceNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["InvoiceNumber"], typeof(System.String)) : string.Empty;
					results = InvoiceSummaryProvider.GetByInvoiceNumber(_invoiceNumber, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceSummarySelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = InvoiceSummaryProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case InvoiceSummarySelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = InvoiceSummaryProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == InvoiceSummarySelectMethod.Get || SelectMethod == InvoiceSummarySelectMethod.GetById )
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
				InvoiceSummary entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					InvoiceSummaryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<InvoiceSummary> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			InvoiceSummaryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region InvoiceSummaryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the InvoiceSummaryDataSource class.
	/// </summary>
	public class InvoiceSummaryDataSourceDesigner : ProviderDataSourceDesigner<InvoiceSummary, InvoiceSummaryKey>
	{
		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryDataSourceDesigner class.
		/// </summary>
		public InvoiceSummaryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceSummarySelectMethod SelectMethod
		{
			get { return ((InvoiceSummaryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new InvoiceSummaryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region InvoiceSummaryDataSourceActionList

	/// <summary>
	/// Supports the InvoiceSummaryDataSourceDesigner class.
	/// </summary>
	internal class InvoiceSummaryDataSourceActionList : DesignerActionList
	{
		private InvoiceSummaryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public InvoiceSummaryDataSourceActionList(InvoiceSummaryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceSummarySelectMethod SelectMethod
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

	#endregion InvoiceSummaryDataSourceActionList
	
	#endregion InvoiceSummaryDataSourceDesigner
	
	#region InvoiceSummarySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the InvoiceSummaryDataSource.SelectMethod property.
	/// </summary>
	public enum InvoiceSummarySelectMethod
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
		/// Represents the GetByStartDate method.
		/// </summary>
		GetByStartDate,
		/// <summary>
		/// Represents the GetByEndDate method.
		/// </summary>
		GetByEndDate,
		/// <summary>
		/// Represents the GetByPriCustomerNumberWholesalerId method.
		/// </summary>
		GetByPriCustomerNumberWholesalerId,
		/// <summary>
		/// Represents the GetByInvoiceNumber method.
		/// </summary>
		GetByInvoiceNumber,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion InvoiceSummarySelectMethod

	#region InvoiceSummaryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryFilter : SqlFilter<InvoiceSummaryColumn>
	{
	}
	
	#endregion InvoiceSummaryFilter

	#region InvoiceSummaryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryExpressionBuilder : SqlExpressionBuilder<InvoiceSummaryColumn>
	{
	}
	
	#endregion InvoiceSummaryExpressionBuilder	

	#region InvoiceSummaryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;InvoiceSummaryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryProperty : ChildEntityProperty<InvoiceSummaryChildEntityTypes>
	{
	}
	
	#endregion InvoiceSummaryProperty
}

