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
	/// Represents the DataRepository.AccessType_ProductRateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AccessType_ProductRateDataSourceDesigner))]
	public class AccessType_ProductRateDataSource : ProviderDataSource<AccessType_ProductRate, AccessType_ProductRateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateDataSource class.
		/// </summary>
		public AccessType_ProductRateDataSource() : base(new AccessType_ProductRateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AccessType_ProductRateDataSourceView used by the AccessType_ProductRateDataSource.
		/// </summary>
		protected AccessType_ProductRateDataSourceView AccessType_ProductRateView
		{
			get { return ( View as AccessType_ProductRateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AccessType_ProductRateDataSource control invokes to retrieve data.
		/// </summary>
		public AccessType_ProductRateSelectMethod SelectMethod
		{
			get
			{
				AccessType_ProductRateSelectMethod selectMethod = AccessType_ProductRateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AccessType_ProductRateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AccessType_ProductRateDataSourceView class that is to be
		/// used by the AccessType_ProductRateDataSource.
		/// </summary>
		/// <returns>An instance of the AccessType_ProductRateDataSourceView class.</returns>
		protected override BaseDataSourceView<AccessType_ProductRate, AccessType_ProductRateKey> GetNewDataSourceView()
		{
			return new AccessType_ProductRateDataSourceView(this, DefaultViewName);
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
	/// Supports the AccessType_ProductRateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AccessType_ProductRateDataSourceView : ProviderDataSourceView<AccessType_ProductRate, AccessType_ProductRateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AccessType_ProductRateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AccessType_ProductRateDataSourceView(AccessType_ProductRateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AccessType_ProductRateDataSource AccessType_ProductRateOwner
		{
			get { return Owner as AccessType_ProductRateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AccessType_ProductRateSelectMethod SelectMethod
		{
			get { return AccessType_ProductRateOwner.SelectMethod; }
			set { AccessType_ProductRateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AccessType_ProductRateService AccessType_ProductRateProvider
		{
			get { return Provider as AccessType_ProductRateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AccessType_ProductRate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AccessType_ProductRate> results = null;
			AccessType_ProductRate item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _accessTypeId;
			System.Int32 _productRateId;

			switch ( SelectMethod )
			{
				case AccessType_ProductRateSelectMethod.Get:
					AccessType_ProductRateKey entityKey  = new AccessType_ProductRateKey();
					entityKey.Load(values);
					item = AccessType_ProductRateProvider.Get(entityKey);
					results = new TList<AccessType_ProductRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AccessType_ProductRateSelectMethod.GetAll:
                    results = AccessType_ProductRateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AccessType_ProductRateSelectMethod.GetPaged:
					results = AccessType_ProductRateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AccessType_ProductRateSelectMethod.Find:
					if ( FilterParameters != null )
						results = AccessType_ProductRateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AccessType_ProductRateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AccessType_ProductRateSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = AccessType_ProductRateProvider.GetById(_id);
					results = new TList<AccessType_ProductRate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AccessType_ProductRateSelectMethod.GetByAccessTypeIdProductRateId:
					_accessTypeId = ( values["AccessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AccessTypeId"], typeof(System.Int32)) : (int)0;
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					results = AccessType_ProductRateProvider.GetByAccessTypeIdProductRateId(_accessTypeId, _productRateId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case AccessType_ProductRateSelectMethod.GetByAccessTypeId:
					_accessTypeId = ( values["AccessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AccessTypeId"], typeof(System.Int32)) : (int)0;
					results = AccessType_ProductRateProvider.GetByAccessTypeId(_accessTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case AccessType_ProductRateSelectMethod.GetByProductRateId:
					_productRateId = ( values["ProductRateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductRateId"], typeof(System.Int32)) : (int)0;
					results = AccessType_ProductRateProvider.GetByProductRateId(_productRateId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AccessType_ProductRateSelectMethod.Get || SelectMethod == AccessType_ProductRateSelectMethod.GetById )
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
				AccessType_ProductRate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AccessType_ProductRateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AccessType_ProductRate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AccessType_ProductRateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AccessType_ProductRateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AccessType_ProductRateDataSource class.
	/// </summary>
	public class AccessType_ProductRateDataSourceDesigner : ProviderDataSourceDesigner<AccessType_ProductRate, AccessType_ProductRateKey>
	{
		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateDataSourceDesigner class.
		/// </summary>
		public AccessType_ProductRateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccessType_ProductRateSelectMethod SelectMethod
		{
			get { return ((AccessType_ProductRateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AccessType_ProductRateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AccessType_ProductRateDataSourceActionList

	/// <summary>
	/// Supports the AccessType_ProductRateDataSourceDesigner class.
	/// </summary>
	internal class AccessType_ProductRateDataSourceActionList : DesignerActionList
	{
		private AccessType_ProductRateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AccessType_ProductRateDataSourceActionList(AccessType_ProductRateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccessType_ProductRateSelectMethod SelectMethod
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

	#endregion AccessType_ProductRateDataSourceActionList
	
	#endregion AccessType_ProductRateDataSourceDesigner
	
	#region AccessType_ProductRateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AccessType_ProductRateDataSource.SelectMethod property.
	/// </summary>
	public enum AccessType_ProductRateSelectMethod
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
		/// Represents the GetByAccessTypeIdProductRateId method.
		/// </summary>
		GetByAccessTypeIdProductRateId,
		/// <summary>
		/// Represents the GetByAccessTypeId method.
		/// </summary>
		GetByAccessTypeId,
		/// <summary>
		/// Represents the GetByProductRateId method.
		/// </summary>
		GetByProductRateId
	}
	
	#endregion AccessType_ProductRateSelectMethod

	#region AccessType_ProductRateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateFilter : SqlFilter<AccessType_ProductRateColumn>
	{
	}
	
	#endregion AccessType_ProductRateFilter

	#region AccessType_ProductRateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateExpressionBuilder : SqlExpressionBuilder<AccessType_ProductRateColumn>
	{
	}
	
	#endregion AccessType_ProductRateExpressionBuilder	

	#region AccessType_ProductRateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AccessType_ProductRateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateProperty : ChildEntityProperty<AccessType_ProductRateChildEntityTypes>
	{
	}
	
	#endregion AccessType_ProductRateProperty
}

