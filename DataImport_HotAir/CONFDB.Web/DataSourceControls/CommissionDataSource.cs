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
	/// Represents the DataRepository.CommissionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommissionDataSourceDesigner))]
	public class CommissionDataSource : ProviderDataSource<Commission, CommissionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionDataSource class.
		/// </summary>
		public CommissionDataSource() : base(new CommissionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommissionDataSourceView used by the CommissionDataSource.
		/// </summary>
		protected CommissionDataSourceView CommissionView
		{
			get { return ( View as CommissionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommissionDataSource control invokes to retrieve data.
		/// </summary>
		public CommissionSelectMethod SelectMethod
		{
			get
			{
				CommissionSelectMethod selectMethod = CommissionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommissionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommissionDataSourceView class that is to be
		/// used by the CommissionDataSource.
		/// </summary>
		/// <returns>An instance of the CommissionDataSourceView class.</returns>
		protected override BaseDataSourceView<Commission, CommissionKey> GetNewDataSourceView()
		{
			return new CommissionDataSourceView(this, DefaultViewName);
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
	/// Supports the CommissionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommissionDataSourceView : ProviderDataSourceView<Commission, CommissionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommissionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommissionDataSourceView(CommissionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommissionDataSource CommissionOwner
		{
			get { return Owner as CommissionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommissionSelectMethod SelectMethod
		{
			get { return CommissionOwner.SelectMethod; }
			set { CommissionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommissionService CommissionProvider
		{
			get { return Provider as CommissionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Commission> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Commission> results = null;
			Commission item;
			count = 0;
			
			System.Int32 _id;
			System.String _currencyId;
			System.Int32 _salesPersonId;
			System.String _wholesalerId;
			System.Int32 _customerId;

			switch ( SelectMethod )
			{
				case CommissionSelectMethod.Get:
					CommissionKey entityKey  = new CommissionKey();
					entityKey.Load(values);
					item = CommissionProvider.Get(entityKey);
					results = new TList<Commission>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommissionSelectMethod.GetAll:
                    results = CommissionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommissionSelectMethod.GetPaged:
					results = CommissionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommissionSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommissionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommissionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommissionSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CommissionProvider.GetById(_id);
					results = new TList<Commission>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CommissionSelectMethod.GetByCurrencyId:
					_currencyId = ( values["CurrencyId"] != null ) ? (System.String) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.String)) : string.Empty;
					results = CommissionProvider.GetByCurrencyId(_currencyId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionSelectMethod.GetBySalesPersonId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					results = CommissionProvider.GetBySalesPersonId(_salesPersonId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = CommissionProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = CommissionProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CommissionSelectMethod.Get || SelectMethod == CommissionSelectMethod.GetById )
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
				Commission entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommissionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Commission> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommissionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommissionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommissionDataSource class.
	/// </summary>
	public class CommissionDataSourceDesigner : ProviderDataSourceDesigner<Commission, CommissionKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommissionDataSourceDesigner class.
		/// </summary>
		public CommissionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionSelectMethod SelectMethod
		{
			get { return ((CommissionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommissionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommissionDataSourceActionList

	/// <summary>
	/// Supports the CommissionDataSourceDesigner class.
	/// </summary>
	internal class CommissionDataSourceActionList : DesignerActionList
	{
		private CommissionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommissionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommissionDataSourceActionList(CommissionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionSelectMethod SelectMethod
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

	#endregion CommissionDataSourceActionList
	
	#endregion CommissionDataSourceDesigner
	
	#region CommissionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommissionDataSource.SelectMethod property.
	/// </summary>
	public enum CommissionSelectMethod
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
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion CommissionSelectMethod

	#region CommissionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionFilter : SqlFilter<CommissionColumn>
	{
	}
	
	#endregion CommissionFilter

	#region CommissionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionExpressionBuilder : SqlExpressionBuilder<CommissionColumn>
	{
	}
	
	#endregion CommissionExpressionBuilder	

	#region CommissionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommissionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionProperty : ChildEntityProperty<CommissionChildEntityTypes>
	{
	}
	
	#endregion CommissionProperty
}

