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
	/// Represents the DataRepository.CommissionCustomerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommissionCustomerDataSourceDesigner))]
	public class CommissionCustomerDataSource : ProviderDataSource<CommissionCustomer, CommissionCustomerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerDataSource class.
		/// </summary>
		public CommissionCustomerDataSource() : base(new CommissionCustomerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommissionCustomerDataSourceView used by the CommissionCustomerDataSource.
		/// </summary>
		protected CommissionCustomerDataSourceView CommissionCustomerView
		{
			get { return ( View as CommissionCustomerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommissionCustomerDataSource control invokes to retrieve data.
		/// </summary>
		public CommissionCustomerSelectMethod SelectMethod
		{
			get
			{
				CommissionCustomerSelectMethod selectMethod = CommissionCustomerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommissionCustomerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommissionCustomerDataSourceView class that is to be
		/// used by the CommissionCustomerDataSource.
		/// </summary>
		/// <returns>An instance of the CommissionCustomerDataSourceView class.</returns>
		protected override BaseDataSourceView<CommissionCustomer, CommissionCustomerKey> GetNewDataSourceView()
		{
			return new CommissionCustomerDataSourceView(this, DefaultViewName);
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
	/// Supports the CommissionCustomerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommissionCustomerDataSourceView : ProviderDataSourceView<CommissionCustomer, CommissionCustomerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommissionCustomerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommissionCustomerDataSourceView(CommissionCustomerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommissionCustomerDataSource CommissionCustomerOwner
		{
			get { return Owner as CommissionCustomerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommissionCustomerSelectMethod SelectMethod
		{
			get { return CommissionCustomerOwner.SelectMethod; }
			set { CommissionCustomerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommissionCustomerService CommissionCustomerProvider
		{
			get { return Provider as CommissionCustomerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CommissionCustomer> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CommissionCustomer> results = null;
			CommissionCustomer item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;
			System.Int32? _salesPersonId_nullable;
			System.String _wholesalerId;

			switch ( SelectMethod )
			{
				case CommissionCustomerSelectMethod.Get:
					CommissionCustomerKey entityKey  = new CommissionCustomerKey();
					entityKey.Load(values);
					item = CommissionCustomerProvider.Get(entityKey);
					results = new TList<CommissionCustomer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommissionCustomerSelectMethod.GetAll:
                    results = CommissionCustomerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommissionCustomerSelectMethod.GetPaged:
					results = CommissionCustomerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommissionCustomerSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommissionCustomerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommissionCustomerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommissionCustomerSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CommissionCustomerProvider.GetById(_id);
					results = new TList<CommissionCustomer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CommissionCustomerSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = CommissionCustomerProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionCustomerSelectMethod.GetBySalesPersonId:
					_salesPersonId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32?));
					results = CommissionCustomerProvider.GetBySalesPersonId(_salesPersonId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionCustomerSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = CommissionCustomerProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CommissionCustomerSelectMethod.Get || SelectMethod == CommissionCustomerSelectMethod.GetById )
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
				CommissionCustomer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommissionCustomerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CommissionCustomer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommissionCustomerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommissionCustomerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommissionCustomerDataSource class.
	/// </summary>
	public class CommissionCustomerDataSourceDesigner : ProviderDataSourceDesigner<CommissionCustomer, CommissionCustomerKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommissionCustomerDataSourceDesigner class.
		/// </summary>
		public CommissionCustomerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionCustomerSelectMethod SelectMethod
		{
			get { return ((CommissionCustomerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommissionCustomerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommissionCustomerDataSourceActionList

	/// <summary>
	/// Supports the CommissionCustomerDataSourceDesigner class.
	/// </summary>
	internal class CommissionCustomerDataSourceActionList : DesignerActionList
	{
		private CommissionCustomerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommissionCustomerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommissionCustomerDataSourceActionList(CommissionCustomerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionCustomerSelectMethod SelectMethod
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

	#endregion CommissionCustomerDataSourceActionList
	
	#endregion CommissionCustomerDataSourceDesigner
	
	#region CommissionCustomerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommissionCustomerDataSource.SelectMethod property.
	/// </summary>
	public enum CommissionCustomerSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion CommissionCustomerSelectMethod

	#region CommissionCustomerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionCustomerFilter : SqlFilter<CommissionCustomerColumn>
	{
	}
	
	#endregion CommissionCustomerFilter

	#region CommissionCustomerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionCustomerExpressionBuilder : SqlExpressionBuilder<CommissionCustomerColumn>
	{
	}
	
	#endregion CommissionCustomerExpressionBuilder	

	#region CommissionCustomerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommissionCustomerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionCustomer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionCustomerProperty : ChildEntityProperty<CommissionCustomerChildEntityTypes>
	{
	}
	
	#endregion CommissionCustomerProperty
}

