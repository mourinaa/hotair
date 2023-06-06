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
	/// Represents the DataRepository.CommissionAdjustmentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommissionAdjustmentDataSourceDesigner))]
	public class CommissionAdjustmentDataSource : ProviderDataSource<CommissionAdjustment, CommissionAdjustmentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionAdjustmentDataSource class.
		/// </summary>
		public CommissionAdjustmentDataSource() : base(new CommissionAdjustmentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommissionAdjustmentDataSourceView used by the CommissionAdjustmentDataSource.
		/// </summary>
		protected CommissionAdjustmentDataSourceView CommissionAdjustmentView
		{
			get { return ( View as CommissionAdjustmentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommissionAdjustmentDataSource control invokes to retrieve data.
		/// </summary>
		public CommissionAdjustmentSelectMethod SelectMethod
		{
			get
			{
				CommissionAdjustmentSelectMethod selectMethod = CommissionAdjustmentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommissionAdjustmentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommissionAdjustmentDataSourceView class that is to be
		/// used by the CommissionAdjustmentDataSource.
		/// </summary>
		/// <returns>An instance of the CommissionAdjustmentDataSourceView class.</returns>
		protected override BaseDataSourceView<CommissionAdjustment, CommissionAdjustmentKey> GetNewDataSourceView()
		{
			return new CommissionAdjustmentDataSourceView(this, DefaultViewName);
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
	/// Supports the CommissionAdjustmentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommissionAdjustmentDataSourceView : ProviderDataSourceView<CommissionAdjustment, CommissionAdjustmentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionAdjustmentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommissionAdjustmentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommissionAdjustmentDataSourceView(CommissionAdjustmentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommissionAdjustmentDataSource CommissionAdjustmentOwner
		{
			get { return Owner as CommissionAdjustmentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommissionAdjustmentSelectMethod SelectMethod
		{
			get { return CommissionAdjustmentOwner.SelectMethod; }
			set { CommissionAdjustmentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommissionAdjustmentService CommissionAdjustmentProvider
		{
			get { return Provider as CommissionAdjustmentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CommissionAdjustment> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CommissionAdjustment> results = null;
			CommissionAdjustment item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _salesPersonId;
			System.String _currencyId_nullable;
			System.String _wholesalerId;

			switch ( SelectMethod )
			{
				case CommissionAdjustmentSelectMethod.Get:
					CommissionAdjustmentKey entityKey  = new CommissionAdjustmentKey();
					entityKey.Load(values);
					item = CommissionAdjustmentProvider.Get(entityKey);
					results = new TList<CommissionAdjustment>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommissionAdjustmentSelectMethod.GetAll:
                    results = CommissionAdjustmentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommissionAdjustmentSelectMethod.GetPaged:
					results = CommissionAdjustmentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommissionAdjustmentSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommissionAdjustmentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommissionAdjustmentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommissionAdjustmentSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CommissionAdjustmentProvider.GetById(_id);
					results = new TList<CommissionAdjustment>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CommissionAdjustmentSelectMethod.GetBySalesPersonId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					results = CommissionAdjustmentProvider.GetBySalesPersonId(_salesPersonId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionAdjustmentSelectMethod.GetByCurrencyId:
					_currencyId_nullable = (System.String) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.String));
					results = CommissionAdjustmentProvider.GetByCurrencyId(_currencyId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionAdjustmentSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = CommissionAdjustmentProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CommissionAdjustmentSelectMethod.Get || SelectMethod == CommissionAdjustmentSelectMethod.GetById )
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
				CommissionAdjustment entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommissionAdjustmentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CommissionAdjustment> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommissionAdjustmentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommissionAdjustmentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommissionAdjustmentDataSource class.
	/// </summary>
	public class CommissionAdjustmentDataSourceDesigner : ProviderDataSourceDesigner<CommissionAdjustment, CommissionAdjustmentKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommissionAdjustmentDataSourceDesigner class.
		/// </summary>
		public CommissionAdjustmentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionAdjustmentSelectMethod SelectMethod
		{
			get { return ((CommissionAdjustmentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommissionAdjustmentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommissionAdjustmentDataSourceActionList

	/// <summary>
	/// Supports the CommissionAdjustmentDataSourceDesigner class.
	/// </summary>
	internal class CommissionAdjustmentDataSourceActionList : DesignerActionList
	{
		private CommissionAdjustmentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommissionAdjustmentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommissionAdjustmentDataSourceActionList(CommissionAdjustmentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionAdjustmentSelectMethod SelectMethod
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

	#endregion CommissionAdjustmentDataSourceActionList
	
	#endregion CommissionAdjustmentDataSourceDesigner
	
	#region CommissionAdjustmentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommissionAdjustmentDataSource.SelectMethod property.
	/// </summary>
	public enum CommissionAdjustmentSelectMethod
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
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetByCurrencyId method.
		/// </summary>
		GetByCurrencyId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion CommissionAdjustmentSelectMethod

	#region CommissionAdjustmentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionAdjustment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionAdjustmentFilter : SqlFilter<CommissionAdjustmentColumn>
	{
	}
	
	#endregion CommissionAdjustmentFilter

	#region CommissionAdjustmentExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionAdjustment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionAdjustmentExpressionBuilder : SqlExpressionBuilder<CommissionAdjustmentColumn>
	{
	}
	
	#endregion CommissionAdjustmentExpressionBuilder	

	#region CommissionAdjustmentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommissionAdjustmentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionAdjustment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionAdjustmentProperty : ChildEntityProperty<CommissionAdjustmentChildEntityTypes>
	{
	}
	
	#endregion CommissionAdjustmentProperty
}

