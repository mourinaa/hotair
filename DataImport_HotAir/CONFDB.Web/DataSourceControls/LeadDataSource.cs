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
	/// Represents the DataRepository.LeadProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadDataSourceDesigner))]
	public class LeadDataSource : ProviderDataSource<Lead, LeadKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadDataSource class.
		/// </summary>
		public LeadDataSource() : base(new LeadService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadDataSourceView used by the LeadDataSource.
		/// </summary>
		protected LeadDataSourceView LeadView
		{
			get { return ( View as LeadDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadDataSource control invokes to retrieve data.
		/// </summary>
		public LeadSelectMethod SelectMethod
		{
			get
			{
				LeadSelectMethod selectMethod = LeadSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadDataSourceView class that is to be
		/// used by the LeadDataSource.
		/// </summary>
		/// <returns>An instance of the LeadDataSourceView class.</returns>
		protected override BaseDataSourceView<Lead, LeadKey> GetNewDataSourceView()
		{
			return new LeadDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadDataSourceView : ProviderDataSourceView<Lead, LeadKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadDataSourceView(LeadDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadDataSource LeadOwner
		{
			get { return Owner as LeadDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadSelectMethod SelectMethod
		{
			get { return LeadOwner.SelectMethod; }
			set { LeadOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadService LeadProvider
		{
			get { return Provider as LeadService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Lead> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Lead> results = null;
			Lead item;
			count = 0;
			
			System.Int32 _id;
			System.String _contactEmail_nullable;
			System.String _wholesalerId;
			System.Int32 _salesPersonId;

			switch ( SelectMethod )
			{
				case LeadSelectMethod.Get:
					LeadKey entityKey  = new LeadKey();
					entityKey.Load(values);
					item = LeadProvider.Get(entityKey);
					results = new TList<Lead>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadSelectMethod.GetAll:
                    results = LeadProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadSelectMethod.GetPaged:
					results = LeadProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = LeadProvider.GetById(_id);
					results = new TList<Lead>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case LeadSelectMethod.GetByContactEmail:
					_contactEmail_nullable = (System.String) EntityUtil.ChangeType(values["ContactEmail"], typeof(System.String));
					results = LeadProvider.GetByContactEmail(_contactEmail_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case LeadSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = LeadProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case LeadSelectMethod.GetBySalesPersonId:
					_salesPersonId = ( values["SalesPersonId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalesPersonId"], typeof(System.Int32)) : (int)0;
					results = LeadProvider.GetBySalesPersonId(_salesPersonId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LeadSelectMethod.Get || SelectMethod == LeadSelectMethod.GetById )
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
				Lead entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Lead> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadDataSource class.
	/// </summary>
	public class LeadDataSourceDesigner : ProviderDataSourceDesigner<Lead, LeadKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadDataSourceDesigner class.
		/// </summary>
		public LeadDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadSelectMethod SelectMethod
		{
			get { return ((LeadDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadDataSourceActionList

	/// <summary>
	/// Supports the LeadDataSourceDesigner class.
	/// </summary>
	internal class LeadDataSourceActionList : DesignerActionList
	{
		private LeadDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadDataSourceActionList(LeadDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadSelectMethod SelectMethod
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

	#endregion LeadDataSourceActionList
	
	#endregion LeadDataSourceDesigner
	
	#region LeadSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadDataSource.SelectMethod property.
	/// </summary>
	public enum LeadSelectMethod
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
		/// Represents the GetByContactEmail method.
		/// </summary>
		GetByContactEmail,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetBySalesPersonId method.
		/// </summary>
		GetBySalesPersonId
	}
	
	#endregion LeadSelectMethod

	#region LeadFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadFilter : SqlFilter<LeadColumn>
	{
	}
	
	#endregion LeadFilter

	#region LeadExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadExpressionBuilder : SqlExpressionBuilder<LeadColumn>
	{
	}
	
	#endregion LeadExpressionBuilder	

	#region LeadProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadProperty : ChildEntityProperty<LeadChildEntityTypes>
	{
	}
	
	#endregion LeadProperty
}

