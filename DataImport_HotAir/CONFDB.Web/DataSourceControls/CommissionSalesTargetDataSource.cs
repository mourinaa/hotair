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
	/// Represents the DataRepository.CommissionSalesTargetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommissionSalesTargetDataSourceDesigner))]
	public class CommissionSalesTargetDataSource : ProviderDataSource<CommissionSalesTarget, CommissionSalesTargetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionSalesTargetDataSource class.
		/// </summary>
		public CommissionSalesTargetDataSource() : base(new CommissionSalesTargetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommissionSalesTargetDataSourceView used by the CommissionSalesTargetDataSource.
		/// </summary>
		protected CommissionSalesTargetDataSourceView CommissionSalesTargetView
		{
			get { return ( View as CommissionSalesTargetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommissionSalesTargetDataSource control invokes to retrieve data.
		/// </summary>
		public CommissionSalesTargetSelectMethod SelectMethod
		{
			get
			{
				CommissionSalesTargetSelectMethod selectMethod = CommissionSalesTargetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommissionSalesTargetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommissionSalesTargetDataSourceView class that is to be
		/// used by the CommissionSalesTargetDataSource.
		/// </summary>
		/// <returns>An instance of the CommissionSalesTargetDataSourceView class.</returns>
		protected override BaseDataSourceView<CommissionSalesTarget, CommissionSalesTargetKey> GetNewDataSourceView()
		{
			return new CommissionSalesTargetDataSourceView(this, DefaultViewName);
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
	/// Supports the CommissionSalesTargetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommissionSalesTargetDataSourceView : ProviderDataSourceView<CommissionSalesTarget, CommissionSalesTargetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionSalesTargetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommissionSalesTargetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommissionSalesTargetDataSourceView(CommissionSalesTargetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommissionSalesTargetDataSource CommissionSalesTargetOwner
		{
			get { return Owner as CommissionSalesTargetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommissionSalesTargetSelectMethod SelectMethod
		{
			get { return CommissionSalesTargetOwner.SelectMethod; }
			set { CommissionSalesTargetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommissionSalesTargetService CommissionSalesTargetProvider
		{
			get { return Provider as CommissionSalesTargetService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CommissionSalesTarget> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CommissionSalesTarget> results = null;
			CommissionSalesTarget item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case CommissionSalesTargetSelectMethod.Get:
					CommissionSalesTargetKey entityKey  = new CommissionSalesTargetKey();
					entityKey.Load(values);
					item = CommissionSalesTargetProvider.Get(entityKey);
					results = new TList<CommissionSalesTarget>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommissionSalesTargetSelectMethod.GetAll:
                    results = CommissionSalesTargetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommissionSalesTargetSelectMethod.GetPaged:
					results = CommissionSalesTargetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommissionSalesTargetSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommissionSalesTargetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommissionSalesTargetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommissionSalesTargetSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CommissionSalesTargetProvider.GetById(_id);
					results = new TList<CommissionSalesTarget>();
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
			if ( SelectMethod == CommissionSalesTargetSelectMethod.Get || SelectMethod == CommissionSalesTargetSelectMethod.GetById )
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
				CommissionSalesTarget entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommissionSalesTargetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CommissionSalesTarget> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommissionSalesTargetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommissionSalesTargetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommissionSalesTargetDataSource class.
	/// </summary>
	public class CommissionSalesTargetDataSourceDesigner : ProviderDataSourceDesigner<CommissionSalesTarget, CommissionSalesTargetKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommissionSalesTargetDataSourceDesigner class.
		/// </summary>
		public CommissionSalesTargetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionSalesTargetSelectMethod SelectMethod
		{
			get { return ((CommissionSalesTargetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommissionSalesTargetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommissionSalesTargetDataSourceActionList

	/// <summary>
	/// Supports the CommissionSalesTargetDataSourceDesigner class.
	/// </summary>
	internal class CommissionSalesTargetDataSourceActionList : DesignerActionList
	{
		private CommissionSalesTargetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommissionSalesTargetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommissionSalesTargetDataSourceActionList(CommissionSalesTargetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommissionSalesTargetSelectMethod SelectMethod
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

	#endregion CommissionSalesTargetDataSourceActionList
	
	#endregion CommissionSalesTargetDataSourceDesigner
	
	#region CommissionSalesTargetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommissionSalesTargetDataSource.SelectMethod property.
	/// </summary>
	public enum CommissionSalesTargetSelectMethod
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
	
	#endregion CommissionSalesTargetSelectMethod

	#region CommissionSalesTargetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionSalesTarget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionSalesTargetFilter : SqlFilter<CommissionSalesTargetColumn>
	{
	}
	
	#endregion CommissionSalesTargetFilter

	#region CommissionSalesTargetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionSalesTarget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionSalesTargetExpressionBuilder : SqlExpressionBuilder<CommissionSalesTargetColumn>
	{
	}
	
	#endregion CommissionSalesTargetExpressionBuilder	

	#region CommissionSalesTargetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommissionSalesTargetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CommissionSalesTarget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionSalesTargetProperty : ChildEntityProperty<CommissionSalesTargetChildEntityTypes>
	{
	}
	
	#endregion CommissionSalesTargetProperty
}

