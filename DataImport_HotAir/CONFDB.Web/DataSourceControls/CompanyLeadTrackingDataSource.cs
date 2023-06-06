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
	/// Represents the DataRepository.CompanyLeadTrackingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CompanyLeadTrackingDataSourceDesigner))]
	public class CompanyLeadTrackingDataSource : ProviderDataSource<CompanyLeadTracking, CompanyLeadTrackingKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingDataSource class.
		/// </summary>
		public CompanyLeadTrackingDataSource() : base(new CompanyLeadTrackingService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CompanyLeadTrackingDataSourceView used by the CompanyLeadTrackingDataSource.
		/// </summary>
		protected CompanyLeadTrackingDataSourceView CompanyLeadTrackingView
		{
			get { return ( View as CompanyLeadTrackingDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CompanyLeadTrackingDataSource control invokes to retrieve data.
		/// </summary>
		public CompanyLeadTrackingSelectMethod SelectMethod
		{
			get
			{
				CompanyLeadTrackingSelectMethod selectMethod = CompanyLeadTrackingSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CompanyLeadTrackingSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CompanyLeadTrackingDataSourceView class that is to be
		/// used by the CompanyLeadTrackingDataSource.
		/// </summary>
		/// <returns>An instance of the CompanyLeadTrackingDataSourceView class.</returns>
		protected override BaseDataSourceView<CompanyLeadTracking, CompanyLeadTrackingKey> GetNewDataSourceView()
		{
			return new CompanyLeadTrackingDataSourceView(this, DefaultViewName);
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
	/// Supports the CompanyLeadTrackingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CompanyLeadTrackingDataSourceView : ProviderDataSourceView<CompanyLeadTracking, CompanyLeadTrackingKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CompanyLeadTrackingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CompanyLeadTrackingDataSourceView(CompanyLeadTrackingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CompanyLeadTrackingDataSource CompanyLeadTrackingOwner
		{
			get { return Owner as CompanyLeadTrackingDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CompanyLeadTrackingSelectMethod SelectMethod
		{
			get { return CompanyLeadTrackingOwner.SelectMethod; }
			set { CompanyLeadTrackingOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CompanyLeadTrackingService CompanyLeadTrackingProvider
		{
			get { return Provider as CompanyLeadTrackingService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CompanyLeadTracking> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CompanyLeadTracking> results = null;
			CompanyLeadTracking item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _leadPeriodId;
			System.Int32 _companyInfoId;
			System.Int32 _leadSourceId;
			System.Int32 _leadChurnReasonId;
			System.Int32 _leadProductId;
			System.Int32 _leadStageId;

			switch ( SelectMethod )
			{
				case CompanyLeadTrackingSelectMethod.Get:
					CompanyLeadTrackingKey entityKey  = new CompanyLeadTrackingKey();
					entityKey.Load(values);
					item = CompanyLeadTrackingProvider.Get(entityKey);
					results = new TList<CompanyLeadTracking>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CompanyLeadTrackingSelectMethod.GetAll:
                    results = CompanyLeadTrackingProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CompanyLeadTrackingSelectMethod.GetPaged:
					results = CompanyLeadTrackingProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.Find:
					if ( FilterParameters != null )
						results = CompanyLeadTrackingProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CompanyLeadTrackingProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CompanyLeadTrackingSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CompanyLeadTrackingProvider.GetById(_id);
					results = new TList<CompanyLeadTracking>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CompanyLeadTrackingSelectMethod.GetByLeadPeriodId:
					_leadPeriodId = ( values["LeadPeriodId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LeadPeriodId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByLeadPeriodId(_leadPeriodId, this.StartIndex, this.PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.GetByCompanyInfoId:
					_companyInfoId = ( values["CompanyInfoId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CompanyInfoId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByCompanyInfoId(_companyInfoId, this.StartIndex, this.PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.GetByLeadSourceId:
					_leadSourceId = ( values["LeadSourceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LeadSourceId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByLeadSourceId(_leadSourceId, this.StartIndex, this.PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.GetByLeadChurnReasonId:
					_leadChurnReasonId = ( values["LeadChurnReasonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LeadChurnReasonId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByLeadChurnReasonId(_leadChurnReasonId, this.StartIndex, this.PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.GetByLeadProductId:
					_leadProductId = ( values["LeadProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LeadProductId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByLeadProductId(_leadProductId, this.StartIndex, this.PageSize, out count);
					break;
				case CompanyLeadTrackingSelectMethod.GetByLeadStageId:
					_leadStageId = ( values["LeadStageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LeadStageId"], typeof(System.Int32)) : (int)0;
					results = CompanyLeadTrackingProvider.GetByLeadStageId(_leadStageId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CompanyLeadTrackingSelectMethod.Get || SelectMethod == CompanyLeadTrackingSelectMethod.GetById )
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
				CompanyLeadTracking entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CompanyLeadTrackingProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CompanyLeadTracking> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CompanyLeadTrackingProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CompanyLeadTrackingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CompanyLeadTrackingDataSource class.
	/// </summary>
	public class CompanyLeadTrackingDataSourceDesigner : ProviderDataSourceDesigner<CompanyLeadTracking, CompanyLeadTrackingKey>
	{
		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingDataSourceDesigner class.
		/// </summary>
		public CompanyLeadTrackingDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyLeadTrackingSelectMethod SelectMethod
		{
			get { return ((CompanyLeadTrackingDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CompanyLeadTrackingDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CompanyLeadTrackingDataSourceActionList

	/// <summary>
	/// Supports the CompanyLeadTrackingDataSourceDesigner class.
	/// </summary>
	internal class CompanyLeadTrackingDataSourceActionList : DesignerActionList
	{
		private CompanyLeadTrackingDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CompanyLeadTrackingDataSourceActionList(CompanyLeadTrackingDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyLeadTrackingSelectMethod SelectMethod
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

	#endregion CompanyLeadTrackingDataSourceActionList
	
	#endregion CompanyLeadTrackingDataSourceDesigner
	
	#region CompanyLeadTrackingSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CompanyLeadTrackingDataSource.SelectMethod property.
	/// </summary>
	public enum CompanyLeadTrackingSelectMethod
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
		/// Represents the GetByLeadPeriodId method.
		/// </summary>
		GetByLeadPeriodId,
		/// <summary>
		/// Represents the GetByCompanyInfoId method.
		/// </summary>
		GetByCompanyInfoId,
		/// <summary>
		/// Represents the GetByLeadSourceId method.
		/// </summary>
		GetByLeadSourceId,
		/// <summary>
		/// Represents the GetByLeadChurnReasonId method.
		/// </summary>
		GetByLeadChurnReasonId,
		/// <summary>
		/// Represents the GetByLeadProductId method.
		/// </summary>
		GetByLeadProductId,
		/// <summary>
		/// Represents the GetByLeadStageId method.
		/// </summary>
		GetByLeadStageId
	}
	
	#endregion CompanyLeadTrackingSelectMethod

	#region CompanyLeadTrackingFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingFilter : SqlFilter<CompanyLeadTrackingColumn>
	{
	}
	
	#endregion CompanyLeadTrackingFilter

	#region CompanyLeadTrackingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingExpressionBuilder : SqlExpressionBuilder<CompanyLeadTrackingColumn>
	{
	}
	
	#endregion CompanyLeadTrackingExpressionBuilder	

	#region CompanyLeadTrackingProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CompanyLeadTrackingChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingProperty : ChildEntityProperty<CompanyLeadTrackingChildEntityTypes>
	{
	}
	
	#endregion CompanyLeadTrackingProperty
}

