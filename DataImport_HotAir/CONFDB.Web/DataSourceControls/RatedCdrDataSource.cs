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
	/// Represents the DataRepository.RatedCdrProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RatedCdrDataSourceDesigner))]
	public class RatedCdrDataSource : ProviderDataSource<RatedCdr, RatedCdrKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrDataSource class.
		/// </summary>
		public RatedCdrDataSource() : base(new RatedCdrService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RatedCdrDataSourceView used by the RatedCdrDataSource.
		/// </summary>
		protected RatedCdrDataSourceView RatedCdrView
		{
			get { return ( View as RatedCdrDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RatedCdrDataSource control invokes to retrieve data.
		/// </summary>
		public RatedCdrSelectMethod SelectMethod
		{
			get
			{
				RatedCdrSelectMethod selectMethod = RatedCdrSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RatedCdrSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RatedCdrDataSourceView class that is to be
		/// used by the RatedCdrDataSource.
		/// </summary>
		/// <returns>An instance of the RatedCdrDataSourceView class.</returns>
		protected override BaseDataSourceView<RatedCdr, RatedCdrKey> GetNewDataSourceView()
		{
			return new RatedCdrDataSourceView(this, DefaultViewName);
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
	/// Supports the RatedCdrDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RatedCdrDataSourceView : ProviderDataSourceView<RatedCdr, RatedCdrKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RatedCdrDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RatedCdrDataSourceView(RatedCdrDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RatedCdrDataSource RatedCdrOwner
		{
			get { return Owner as RatedCdrDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RatedCdrSelectMethod SelectMethod
		{
			get { return RatedCdrOwner.SelectMethod; }
			set { RatedCdrOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RatedCdrService RatedCdrProvider
		{
			get { return Provider as RatedCdrService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RatedCdr> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RatedCdr> results = null;
			RatedCdr item;
			count = 0;
			
			System.Guid _id;
			System.String _conferenceId;
			System.Int32 _bridgeId;
			System.String _wholesalerId_nullable;
			System.Int32 _moderatorId;
			System.Int32 _accessTypeId;
			System.Int32 _bridgeProductRateId;
			System.DateTime _startTime;
			System.DateTime _endTime;
			System.String _referenceNumber_nullable;
			System.DateTime? _billedDate_nullable;
			System.String _uniqueConferenceId_nullable;

			switch ( SelectMethod )
			{
				case RatedCdrSelectMethod.Get:
					RatedCdrKey entityKey  = new RatedCdrKey();
					entityKey.Load(values);
					item = RatedCdrProvider.Get(entityKey);
					results = new TList<RatedCdr>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RatedCdrSelectMethod.GetAll:
                    results = RatedCdrProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RatedCdrSelectMethod.GetPaged:
					results = RatedCdrProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RatedCdrSelectMethod.Find:
					if ( FilterParameters != null )
						results = RatedCdrProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RatedCdrProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RatedCdrSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.Empty;
					item = RatedCdrProvider.GetById(_id);
					results = new TList<RatedCdr>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case RatedCdrSelectMethod.GetByConferenceIdBridgeIdWholesalerId:
					_conferenceId = ( values["ConferenceId"] != null ) ? (System.String) EntityUtil.ChangeType(values["ConferenceId"], typeof(System.String)) : string.Empty;
					_bridgeId = ( values["BridgeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BridgeId"], typeof(System.Int32)) : (int)0;
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = RatedCdrProvider.GetByConferenceIdBridgeIdWholesalerId(_conferenceId, _bridgeId, _wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByWholesalerIdModeratorId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = RatedCdrProvider.GetByWholesalerIdModeratorId(_wholesalerId_nullable, _moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = RatedCdrProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByAccessTypeIdBridgeProductRateId:
					_accessTypeId = ( values["AccessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AccessTypeId"], typeof(System.Int32)) : (int)0;
					_bridgeProductRateId = ( values["BridgeProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BridgeProductRateId"], typeof(System.Int32)) : (int)0;
					results = RatedCdrProvider.GetByAccessTypeIdBridgeProductRateId(_accessTypeId, _bridgeProductRateId, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByWholesalerIdStartTimeEndTime:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					_startTime = ( values["StartTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartTime"], typeof(System.DateTime)) : DateTime.MinValue;
					_endTime = ( values["EndTime"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["EndTime"], typeof(System.DateTime)) : DateTime.MinValue;
					results = RatedCdrProvider.GetByWholesalerIdStartTimeEndTime(_wholesalerId_nullable, _startTime, _endTime, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByReferenceNumber:
					_referenceNumber_nullable = (System.String) EntityUtil.ChangeType(values["ReferenceNumber"], typeof(System.String));
					results = RatedCdrProvider.GetByReferenceNumber(_referenceNumber_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByBilledDate:
					_billedDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["BilledDate"], typeof(System.DateTime?));
					results = RatedCdrProvider.GetByBilledDate(_billedDate_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByUniqueConferenceId:
					_uniqueConferenceId_nullable = (System.String) EntityUtil.ChangeType(values["UniqueConferenceId"], typeof(System.String));
					results = RatedCdrProvider.GetByUniqueConferenceId(_uniqueConferenceId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case RatedCdrSelectMethod.GetByAccessTypeId:
					_accessTypeId = ( values["AccessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AccessTypeId"], typeof(System.Int32)) : (int)0;
					results = RatedCdrProvider.GetByAccessTypeId(_accessTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByBridgeId:
					_bridgeId = ( values["BridgeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BridgeId"], typeof(System.Int32)) : (int)0;
					results = RatedCdrProvider.GetByBridgeId(_bridgeId, this.StartIndex, this.PageSize, out count);
					break;
				case RatedCdrSelectMethod.GetByWholesalerId:
					_wholesalerId_nullable = (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String));
					results = RatedCdrProvider.GetByWholesalerId(_wholesalerId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RatedCdrSelectMethod.Get || SelectMethod == RatedCdrSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(RatedCdr entity)
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
				RatedCdr entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RatedCdrProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RatedCdr> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RatedCdrProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RatedCdrDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RatedCdrDataSource class.
	/// </summary>
	public class RatedCdrDataSourceDesigner : ProviderDataSourceDesigner<RatedCdr, RatedCdrKey>
	{
		/// <summary>
		/// Initializes a new instance of the RatedCdrDataSourceDesigner class.
		/// </summary>
		public RatedCdrDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RatedCdrSelectMethod SelectMethod
		{
			get { return ((RatedCdrDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RatedCdrDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RatedCdrDataSourceActionList

	/// <summary>
	/// Supports the RatedCdrDataSourceDesigner class.
	/// </summary>
	internal class RatedCdrDataSourceActionList : DesignerActionList
	{
		private RatedCdrDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RatedCdrDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RatedCdrDataSourceActionList(RatedCdrDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RatedCdrSelectMethod SelectMethod
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

	#endregion RatedCdrDataSourceActionList
	
	#endregion RatedCdrDataSourceDesigner
	
	#region RatedCdrSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RatedCdrDataSource.SelectMethod property.
	/// </summary>
	public enum RatedCdrSelectMethod
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
		/// Represents the GetByAccessTypeIdBridgeProductRateId method.
		/// </summary>
		GetByAccessTypeIdBridgeProductRateId,
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
		GetByBilledDate,
		/// <summary>
		/// Represents the GetByUniqueConferenceId method.
		/// </summary>
		GetByUniqueConferenceId,
		/// <summary>
		/// Represents the GetByAccessTypeId method.
		/// </summary>
		GetByAccessTypeId,
		/// <summary>
		/// Represents the GetByBridgeId method.
		/// </summary>
		GetByBridgeId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion RatedCdrSelectMethod

	#region RatedCdrFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrFilter : SqlFilter<RatedCdrColumn>
	{
	}
	
	#endregion RatedCdrFilter

	#region RatedCdrExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrExpressionBuilder : SqlExpressionBuilder<RatedCdrColumn>
	{
	}
	
	#endregion RatedCdrExpressionBuilder	

	#region RatedCdrProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RatedCdrChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrProperty : ChildEntityProperty<RatedCdrChildEntityTypes>
	{
	}
	
	#endregion RatedCdrProperty
}

