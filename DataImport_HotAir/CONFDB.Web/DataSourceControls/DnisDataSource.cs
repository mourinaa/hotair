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
	/// Represents the DataRepository.DnisProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DnisDataSourceDesigner))]
	public class DnisDataSource : ProviderDataSource<Dnis, DnisKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisDataSource class.
		/// </summary>
		public DnisDataSource() : base(new DnisService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DnisDataSourceView used by the DnisDataSource.
		/// </summary>
		protected DnisDataSourceView DnisView
		{
			get { return ( View as DnisDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DnisDataSource control invokes to retrieve data.
		/// </summary>
		public DnisSelectMethod SelectMethod
		{
			get
			{
				DnisSelectMethod selectMethod = DnisSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DnisSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DnisDataSourceView class that is to be
		/// used by the DnisDataSource.
		/// </summary>
		/// <returns>An instance of the DnisDataSourceView class.</returns>
		protected override BaseDataSourceView<Dnis, DnisKey> GetNewDataSourceView()
		{
			return new DnisDataSourceView(this, DefaultViewName);
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
	/// Supports the DnisDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DnisDataSourceView : ProviderDataSourceView<Dnis, DnisKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DnisDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DnisDataSourceView(DnisDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DnisDataSource DnisOwner
		{
			get { return Owner as DnisDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DnisSelectMethod SelectMethod
		{
			get { return DnisOwner.SelectMethod; }
			set { DnisOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DnisService DnisProvider
		{
			get { return Provider as DnisService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Dnis> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Dnis> results = null;
			Dnis item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _dnisTypeId;
			System.String _dnisNumber_nullable;
			System.String _dialNumber_nullable;
			System.Int32? _accessTypeId_nullable;
			System.Int32? _callFlowId_nullable;
			System.Int32? _promptSetId_nullable;
			System.String _wholesalerId;
			System.Int32 _customerId;
			System.Int32 _moderatorId;

			switch ( SelectMethod )
			{
				case DnisSelectMethod.Get:
					DnisKey entityKey  = new DnisKey();
					entityKey.Load(values);
					item = DnisProvider.Get(entityKey);
					results = new TList<Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DnisSelectMethod.GetAll:
                    results = DnisProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DnisSelectMethod.GetPaged:
					results = DnisProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DnisSelectMethod.Find:
					if ( FilterParameters != null )
						results = DnisProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DnisProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DnisSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DnisProvider.GetById(_id);
					results = new TList<Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DnisSelectMethod.GetByDnisTypeId:
					_dnisTypeId = ( values["DnisTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DnisTypeId"], typeof(System.Int32)) : (int)0;
					results = DnisProvider.GetByDnisTypeId(_dnisTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByDnisNumber:
					_dnisNumber_nullable = (System.String) EntityUtil.ChangeType(values["DnisNumber"], typeof(System.String));
					results = DnisProvider.GetByDnisNumber(_dnisNumber_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByDialNumber:
					_dialNumber_nullable = (System.String) EntityUtil.ChangeType(values["DialNumber"], typeof(System.String));
					results = DnisProvider.GetByDialNumber(_dialNumber_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case DnisSelectMethod.GetByAccessTypeId:
					_accessTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AccessTypeId"], typeof(System.Int32?));
					results = DnisProvider.GetByAccessTypeId(_accessTypeId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByCallFlowId:
					_callFlowId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CallFlowId"], typeof(System.Int32?));
					results = DnisProvider.GetByCallFlowId(_callFlowId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByPromptSetId:
					_promptSetId_nullable = (System.Int32?) EntityUtil.ChangeType(values["PromptSetId"], typeof(System.Int32?));
					results = DnisProvider.GetByPromptSetId(_promptSetId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = DnisProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case DnisSelectMethod.GetByCustomerIdFromCustomer_Dnis:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = DnisProvider.GetByCustomerIdFromCustomer_Dnis(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case DnisSelectMethod.GetByModeratorIdFromModerator_Dnis:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = DnisProvider.GetByModeratorIdFromModerator_Dnis(_moderatorId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DnisSelectMethod.Get || SelectMethod == DnisSelectMethod.GetById )
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
				Dnis entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DnisProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Dnis> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DnisProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DnisDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DnisDataSource class.
	/// </summary>
	public class DnisDataSourceDesigner : ProviderDataSourceDesigner<Dnis, DnisKey>
	{
		/// <summary>
		/// Initializes a new instance of the DnisDataSourceDesigner class.
		/// </summary>
		public DnisDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DnisSelectMethod SelectMethod
		{
			get { return ((DnisDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DnisDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DnisDataSourceActionList

	/// <summary>
	/// Supports the DnisDataSourceDesigner class.
	/// </summary>
	internal class DnisDataSourceActionList : DesignerActionList
	{
		private DnisDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DnisDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DnisDataSourceActionList(DnisDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DnisSelectMethod SelectMethod
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

	#endregion DnisDataSourceActionList
	
	#endregion DnisDataSourceDesigner
	
	#region DnisSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DnisDataSource.SelectMethod property.
	/// </summary>
	public enum DnisSelectMethod
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
		/// Represents the GetByDnisTypeId method.
		/// </summary>
		GetByDnisTypeId,
		/// <summary>
		/// Represents the GetByDnisNumber method.
		/// </summary>
		GetByDnisNumber,
		/// <summary>
		/// Represents the GetByDialNumber method.
		/// </summary>
		GetByDialNumber,
		/// <summary>
		/// Represents the GetByAccessTypeId method.
		/// </summary>
		GetByAccessTypeId,
		/// <summary>
		/// Represents the GetByCallFlowId method.
		/// </summary>
		GetByCallFlowId,
		/// <summary>
		/// Represents the GetByPromptSetId method.
		/// </summary>
		GetByPromptSetId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByCustomerIdFromCustomer_Dnis method.
		/// </summary>
		GetByCustomerIdFromCustomer_Dnis,
		/// <summary>
		/// Represents the GetByModeratorIdFromModerator_Dnis method.
		/// </summary>
		GetByModeratorIdFromModerator_Dnis
	}
	
	#endregion DnisSelectMethod

	#region DnisFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisFilter : SqlFilter<DnisColumn>
	{
	}
	
	#endregion DnisFilter

	#region DnisExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisExpressionBuilder : SqlExpressionBuilder<DnisColumn>
	{
	}
	
	#endregion DnisExpressionBuilder	

	#region DnisProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DnisChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisProperty : ChildEntityProperty<DnisChildEntityTypes>
	{
	}
	
	#endregion DnisProperty
}

