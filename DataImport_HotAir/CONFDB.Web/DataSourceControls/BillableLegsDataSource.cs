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
	/// Represents the DataRepository.BillableLegsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BillableLegsDataSourceDesigner))]
	public class BillableLegsDataSource : ProviderDataSource<BillableLegs, BillableLegsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsDataSource class.
		/// </summary>
		public BillableLegsDataSource() : base(new BillableLegsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BillableLegsDataSourceView used by the BillableLegsDataSource.
		/// </summary>
		protected BillableLegsDataSourceView BillableLegsView
		{
			get { return ( View as BillableLegsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BillableLegsDataSource control invokes to retrieve data.
		/// </summary>
		public BillableLegsSelectMethod SelectMethod
		{
			get
			{
				BillableLegsSelectMethod selectMethod = BillableLegsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BillableLegsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BillableLegsDataSourceView class that is to be
		/// used by the BillableLegsDataSource.
		/// </summary>
		/// <returns>An instance of the BillableLegsDataSourceView class.</returns>
		protected override BaseDataSourceView<BillableLegs, BillableLegsKey> GetNewDataSourceView()
		{
			return new BillableLegsDataSourceView(this, DefaultViewName);
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
	/// Supports the BillableLegsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BillableLegsDataSourceView : ProviderDataSourceView<BillableLegs, BillableLegsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BillableLegsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BillableLegsDataSourceView(BillableLegsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BillableLegsDataSource BillableLegsOwner
		{
			get { return Owner as BillableLegsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BillableLegsSelectMethod SelectMethod
		{
			get { return BillableLegsOwner.SelectMethod; }
			set { BillableLegsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BillableLegsService BillableLegsProvider
		{
			get { return Provider as BillableLegsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BillableLegs> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BillableLegs> results = null;
			BillableLegs item;
			count = 0;
			
			System.Guid _id;
			System.String _conferenceId;
			System.Int16 _bridgeId;
			System.String _wholesalerId_nullable;
			System.Int32 _moderatorId;
			System.DateTime _startTime;
			System.DateTime _endTime;
			System.String _referenceNumber_nullable;
			System.DateTime? _billedDate_nullable;

			switch ( SelectMethod )
			{
				case BillableLegsSelectMethod.Get:
					BillableLegsKey entityKey  = new BillableLegsKey();
					entityKey.Load(values);
					item = BillableLegsProvider.Get(entityKey);
					results = new TList<BillableLegs>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BillableLegsSelectMethod.GetAll:
                    results = BillableLegsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BillableLegsSelectMethod.GetPaged:
					results = BillableLegsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BillableLegsSelectMethod.Find:
					if ( FilterParameters != null )
						results = BillableLegsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BillableLegsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BillableLegsSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.Empty;
					item = BillableLegsProvider.GetById(_id);
					results = new TList<BillableLegs>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case BillableLegsSelectMethod.GetByConferenceIdBridgeIdWholesalerId:
					_conferenceId = ( values["ConferenceId"] != null ) ? (System.String) EntityUtil.ChangeType(values["ConferenceId"], typeof(System.String)) : string.Empty;
					_bridgeId = ( values["BridgeId"] != null ) ? (System.Int16) EntityUtil.ChangeType(values["BridgeId"], typeof(System.Int16)) : (short)0;
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = BillableLegsProvider.GetByConferenceIdBridgeIdWholesalerId(_conferenceId, _bridgeId, _wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByWholesalerIdModeratorId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = BillableLegsProvider.GetByWholesalerIdModeratorId(_wholesalerId_nullable, _moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = BillableLegsProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByWholesalerId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = BillableLegsProvider.GetByWholesalerId(_wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByWholesalerIdStartTimeEndTime:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					_startTime = ( values["StartTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartTime"], typeof(System.DateTime)) : DateTime.MinValue;
					_endTime = ( values["EndTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["EndTime"], typeof(System.DateTime)) : DateTime.MinValue;
					results = BillableLegsProvider.GetByWholesalerIdStartTimeEndTime(_wholesalerId_nullable, _startTime, _endTime, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByReferenceNumber:
					_referenceNumber_nullable = (System.String) EntityUtil.ChangeType(values["ReferenceNumber"], typeof(System.String));
					results = BillableLegsProvider.GetByReferenceNumber(_referenceNumber_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case BillableLegsSelectMethod.GetByBilledDate:
					_billedDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["BilledDate"], typeof(System.DateTime?));
					results = BillableLegsProvider.GetByBilledDate(_billedDate_nullable, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == BillableLegsSelectMethod.Get || SelectMethod == BillableLegsSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(BillableLegs entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.Id == Guid.Empty )
				entity.Id = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				BillableLegs entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BillableLegsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BillableLegs> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BillableLegsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BillableLegsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BillableLegsDataSource class.
	/// </summary>
	public class BillableLegsDataSourceDesigner : ProviderDataSourceDesigner<BillableLegs, BillableLegsKey>
	{
		/// <summary>
		/// Initializes a new instance of the BillableLegsDataSourceDesigner class.
		/// </summary>
		public BillableLegsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BillableLegsSelectMethod SelectMethod
		{
			get { return ((BillableLegsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BillableLegsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BillableLegsDataSourceActionList

	/// <summary>
	/// Supports the BillableLegsDataSourceDesigner class.
	/// </summary>
	internal class BillableLegsDataSourceActionList : DesignerActionList
	{
		private BillableLegsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BillableLegsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BillableLegsDataSourceActionList(BillableLegsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BillableLegsSelectMethod SelectMethod
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

	#endregion BillableLegsDataSourceActionList
	
	#endregion BillableLegsDataSourceDesigner
	
	#region BillableLegsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BillableLegsDataSource.SelectMethod property.
	/// </summary>
	public enum BillableLegsSelectMethod
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
		/// Represents the GetByConferenceIdBridgeIdWholesalerId method.
		/// </summary>
		GetByConferenceIdBridgeIdWholesalerId,
		/// <summary>
		/// Represents the GetByWholesalerIdModeratorId method.
		/// </summary>
		GetByWholesalerIdModeratorId,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByWholesalerIdStartTimeEndTime method.
		/// </summary>
		GetByWholesalerIdStartTimeEndTime,
		/// <summary>
		/// Represents the GetByReferenceNumber method.
		/// </summary>
		GetByReferenceNumber,
		/// <summary>
		/// Represents the GetByBilledDate method.
		/// </summary>
		GetByBilledDate
	}
	
	#endregion BillableLegsSelectMethod

	#region BillableLegsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsFilter : SqlFilter<BillableLegsColumn>
	{
	}
	
	#endregion BillableLegsFilter

	#region BillableLegsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsExpressionBuilder : SqlExpressionBuilder<BillableLegsColumn>
	{
	}
	
	#endregion BillableLegsExpressionBuilder	

	#region BillableLegsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BillableLegsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsProperty : ChildEntityProperty<BillableLegsChildEntityTypes>
	{
	}
	
	#endregion BillableLegsProperty
}

