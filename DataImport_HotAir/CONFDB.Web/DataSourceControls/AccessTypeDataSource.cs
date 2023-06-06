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
	/// Represents the DataRepository.AccessTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AccessTypeDataSourceDesigner))]
	public class AccessTypeDataSource : ProviderDataSource<AccessType, AccessTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeDataSource class.
		/// </summary>
		public AccessTypeDataSource() : base(new AccessTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AccessTypeDataSourceView used by the AccessTypeDataSource.
		/// </summary>
		protected AccessTypeDataSourceView AccessTypeView
		{
			get { return ( View as AccessTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AccessTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AccessTypeSelectMethod SelectMethod
		{
			get
			{
				AccessTypeSelectMethod selectMethod = AccessTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AccessTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AccessTypeDataSourceView class that is to be
		/// used by the AccessTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AccessTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AccessType, AccessTypeKey> GetNewDataSourceView()
		{
			return new AccessTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AccessTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AccessTypeDataSourceView : ProviderDataSourceView<AccessType, AccessTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AccessTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AccessTypeDataSourceView(AccessTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AccessTypeDataSource AccessTypeOwner
		{
			get { return Owner as AccessTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AccessTypeSelectMethod SelectMethod
		{
			get { return AccessTypeOwner.SelectMethod; }
			set { AccessTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AccessTypeService AccessTypeProvider
		{
			get { return Provider as AccessTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AccessType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AccessType> results = null;
			AccessType item;
			count = 0;
			
			System.Int32 _id;
			System.String _name;
			System.Int32 _value;

			switch ( SelectMethod )
			{
				case AccessTypeSelectMethod.Get:
					AccessTypeKey entityKey  = new AccessTypeKey();
					entityKey.Load(values);
					item = AccessTypeProvider.Get(entityKey);
					results = new TList<AccessType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AccessTypeSelectMethod.GetAll:
                    results = AccessTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AccessTypeSelectMethod.GetPaged:
					results = AccessTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AccessTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AccessTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AccessTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AccessTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = AccessTypeProvider.GetById(_id);
					results = new TList<AccessType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AccessTypeSelectMethod.GetByIdNameValue:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					_value = ( values["Value"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Value"], typeof(System.Int32)) : (int)0;
					results = AccessTypeProvider.GetByIdNameValue(_id, _name, _value, this.StartIndex, this.PageSize, out count);
					break;
				case AccessTypeSelectMethod.GetByValueName:
					_value = ( values["Value"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Value"], typeof(System.Int32)) : (int)0;
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					results = AccessTypeProvider.GetByValueName(_value, _name, this.StartIndex, this.PageSize, out count);
					break;
				case AccessTypeSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = AccessTypeProvider.GetByName(_name);
					results = new TList<AccessType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
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
			if ( SelectMethod == AccessTypeSelectMethod.Get || SelectMethod == AccessTypeSelectMethod.GetById )
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
				AccessType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AccessTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AccessType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AccessTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AccessTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AccessTypeDataSource class.
	/// </summary>
	public class AccessTypeDataSourceDesigner : ProviderDataSourceDesigner<AccessType, AccessTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AccessTypeDataSourceDesigner class.
		/// </summary>
		public AccessTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccessTypeSelectMethod SelectMethod
		{
			get { return ((AccessTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AccessTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AccessTypeDataSourceActionList

	/// <summary>
	/// Supports the AccessTypeDataSourceDesigner class.
	/// </summary>
	internal class AccessTypeDataSourceActionList : DesignerActionList
	{
		private AccessTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AccessTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AccessTypeDataSourceActionList(AccessTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AccessTypeSelectMethod SelectMethod
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

	#endregion AccessTypeDataSourceActionList
	
	#endregion AccessTypeDataSourceDesigner
	
	#region AccessTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AccessTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AccessTypeSelectMethod
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
		/// Represents the GetByIdNameValue method.
		/// </summary>
		GetByIdNameValue,
		/// <summary>
		/// Represents the GetByValueName method.
		/// </summary>
		GetByValueName,
		/// <summary>
		/// Represents the GetByName method.
		/// </summary>
		GetByName
	}
	
	#endregion AccessTypeSelectMethod

	#region AccessTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeFilter : SqlFilter<AccessTypeColumn>
	{
	}
	
	#endregion AccessTypeFilter

	#region AccessTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeExpressionBuilder : SqlExpressionBuilder<AccessTypeColumn>
	{
	}
	
	#endregion AccessTypeExpressionBuilder	

	#region AccessTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AccessTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeProperty : ChildEntityProperty<AccessTypeChildEntityTypes>
	{
	}
	
	#endregion AccessTypeProperty
}

