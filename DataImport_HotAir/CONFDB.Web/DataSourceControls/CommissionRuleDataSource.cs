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
	/// Represents the DataRepository.CommissionRuleProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommissionRuleDataSourceDesigner))]
	public class CommissionRuleDataSource : ProviderDataSource<CommissionRule, CommissionRuleKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionRuleDataSource class.
		/// </summary>
		public CommissionRuleDataSource() : base(new CommissionRuleService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommissionRuleDataSourceView used by the CommissionRuleDataSource.
		/// </summary>
		protected CommissionRuleDataSourceView CommissionRuleView
		{
			get { return ( View as CommissionRuleDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommissionRuleDataSource control invokes to retrieve data.
		/// </summary>
		public CommissionRuleSelectMethod SelectMethod
		{
			get
			{
				CommissionRuleSelectMethod selectMethod = CommissionRuleSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommissionRuleSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommissionRuleDataSourceView class that is to be
		/// used by the CommissionRuleDataSource.
		/// </summary>
		/// <returns>An instance of the CommissionRuleDataSourceView class.</returns>
		protected override BaseDataSourceView<CommissionRule, CommissionRuleKey> GetNewDataSourceView()
		{
			return new CommissionRuleDataSourceView(this, DefaultViewName);
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
	/// Supports the CommissionRuleDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommissionRuleDataSourceView : ProviderDataSourceView<CommissionRule, CommissionRuleKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionRuleDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommissionRuleDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommissionRuleDataSourceView(CommissionRuleDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommissionRuleDataSource CommissionRuleOwner
		{
			get { return Owner as CommissionRuleDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommissionRuleSelectMethod SelectMethod
		{
			get { return CommissionRuleOwner.SelectMethod; }
			set { CommissionRuleOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommissionRuleService CommissionRuleProvider
		{
			get { return Provider as CommissionRuleService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CommissionRule> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CommissionRule> results = null;
			CommissionRule item;
			count = 0;
			
			System.Int32 _id;
			System.String _wholesalerId;
			System.Int32? _customerId_nullable;
			System.Int32? _commissionRuleTypeId_nullable;
			System.Int32? _salesPersonId_nullable;

			switch ( SelectMethod )
			{
				case CommissionRuleSelectMethod.Get:
					CommissionRuleKey entityKey  = new CommissionRuleKey();
					entityKey.Load(values);
					item = CommissionRuleProvider.Get(entityKey);
					results = new TList<CommissionRule>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommissionRuleSelectMethod.GetAll:
                    results = CommissionRuleProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommissionRuleSelectMethod.GetPaged:
					results = CommissionRuleProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommissionRuleSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommissionRuleProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommissionRuleProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommissionRuleSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CommissionRuleProvider.GetById(_id);
					results = new TList<CommissionRule>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CommissionRuleSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = CommissionRuleProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionRuleSelectMethod.GetByCustomerId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					results = CommissionRuleProvider.GetByCustomerId(_customerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionRuleSelectMethod.GetByCommissionRuleTypeId:
					_commissionRuleTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CommissionRuleTypeId"], typeof(System.Int32?));
					results = CommissionRuleProvider.GetByCommissionRuleTypeId(_commissionRuleTypeId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CommissionRuleSelectMethod.GetBySalesPersonId:
					_salesPersonId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32?));
					results = CommissionRuleProvider.GetBySalesPersonId(_salesPersonId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CommissionRuleSelectMethod.Get || SelectMethod == CommissionRuleSelectMethod.GetById )
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
				CommissionRule entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommissionRuleProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CommissionRule> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommissionRuleProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommissionRuleDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommissionRuleDataSource class.
	/// </summary>
	public class CommissionRuleDataSourceDesigner : ProviderDataSourceDesigner<CommissionRule, CommissionRuleKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommissionRuleDataSourceDesigner class.
		/// </summary>
		public CommissionRuleDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionRuleSelectMethod SelectMethod
		{
			get { return ((CommissionRuleDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommissionRuleDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommissionRuleDataSourceActionList

	/// <summary>
	/// Supports the CommissionRuleDataSourceDesigner class.
	/// </summary>
	internal class CommissionRuleDataSourceActionList : DesignerActionList
	{
		private CommissionRuleDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommissionRuleDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommissionRuleDataSourceActionList(CommissionRuleDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionRuleSelectMethod SelectMethod
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

	#endregion CommissionRuleDataSourceActionList
	
	#endregion CommissionRuleDataSourceDesigner
	
	#region CommissionRuleSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommissionRuleDataSource.SelectMethod property.
	/// </summary>
	public enum CommissionRuleSelectMethod
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
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByCommissionRuleTypeId method.
		/// </summary>
		GetByCommissionRuleTypeId,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId
	}
	
	#endregion CommissionRuleSelectMethod

	#region CommissionRuleFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionRuleFilter : SqlFilter<CommissionRuleColumn>
	{
	}
	
	#endregion CommissionRuleFilter

	#region CommissionRuleExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionRuleExpressionBuilder : SqlExpressionBuilder<CommissionRuleColumn>
	{
	}
	
	#endregion CommissionRuleExpressionBuilder	

	#region CommissionRuleProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommissionRuleChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionRuleProperty : ChildEntityProperty<CommissionRuleChildEntityTypes>
	{
	}
	
	#endregion CommissionRuleProperty
}

