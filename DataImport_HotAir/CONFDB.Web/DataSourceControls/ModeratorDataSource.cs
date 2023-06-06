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
	/// Represents the DataRepository.ModeratorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ModeratorDataSourceDesigner))]
	public class ModeratorDataSource : ProviderDataSource<Moderator, ModeratorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorDataSource class.
		/// </summary>
		public ModeratorDataSource() : base(new ModeratorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ModeratorDataSourceView used by the ModeratorDataSource.
		/// </summary>
		protected ModeratorDataSourceView ModeratorView
		{
			get { return ( View as ModeratorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ModeratorDataSource control invokes to retrieve data.
		/// </summary>
		public ModeratorSelectMethod SelectMethod
		{
			get
			{
				ModeratorSelectMethod selectMethod = ModeratorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ModeratorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ModeratorDataSourceView class that is to be
		/// used by the ModeratorDataSource.
		/// </summary>
		/// <returns>An instance of the ModeratorDataSourceView class.</returns>
		protected override BaseDataSourceView<Moderator, ModeratorKey> GetNewDataSourceView()
		{
			return new ModeratorDataSourceView(this, DefaultViewName);
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
	/// Supports the ModeratorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ModeratorDataSourceView : ProviderDataSourceView<Moderator, ModeratorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ModeratorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ModeratorDataSourceView(ModeratorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ModeratorDataSource ModeratorOwner
		{
			get { return Owner as ModeratorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ModeratorSelectMethod SelectMethod
		{
			get { return ModeratorOwner.SelectMethod; }
			set { ModeratorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ModeratorService ModeratorProvider
		{
			get { return Provider as ModeratorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Moderator> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Moderator> results = null;
			Moderator item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _customerId;
			System.String _priCustomerNumber;
			System.String _secCustomerNumber;
			System.String _wholesalerId;
			System.String _moderatorCode;
			System.String _passCode;
			System.Int32 _departmentId;
			System.Int32? _userId_nullable;
			System.Int32 _dnisid;

			switch ( SelectMethod )
			{
				case ModeratorSelectMethod.Get:
					ModeratorKey entityKey  = new ModeratorKey();
					entityKey.Load(values);
					item = ModeratorProvider.Get(entityKey);
					results = new TList<Moderator>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ModeratorSelectMethod.GetAll:
                    results = ModeratorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ModeratorSelectMethod.GetPaged:
					results = ModeratorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ModeratorSelectMethod.Find:
					if ( FilterParameters != null )
						results = ModeratorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ModeratorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ModeratorSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ModeratorProvider.GetById(_id);
					results = new TList<Moderator>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ModeratorSelectMethod.GetByCustomerIdPriCustomerNumberSecCustomerNumber:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_priCustomerNumber = ( values["PriCustomerNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["PriCustomerNumber"], typeof(System.String)) : string.Empty;
					_secCustomerNumber = ( values["SecCustomerNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["SecCustomerNumber"], typeof(System.String)) : string.Empty;
					results = ModeratorProvider.GetByCustomerIdPriCustomerNumberSecCustomerNumber(_customerId, _priCustomerNumber, _secCustomerNumber, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorSelectMethod.GetByWholesalerIdPriCustomerNumberSecCustomerNumber:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_priCustomerNumber = ( values["PriCustomerNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["PriCustomerNumber"], typeof(System.String)) : string.Empty;
					_secCustomerNumber = ( values["SecCustomerNumber"] != null ) ? (System.String) EntityUtil.ChangeType(values["SecCustomerNumber"], typeof(System.String)) : string.Empty;
					item = ModeratorProvider.GetByWholesalerIdPriCustomerNumberSecCustomerNumber(_wholesalerId, _priCustomerNumber, _secCustomerNumber);
					results = new TList<Moderator>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ModeratorSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = ModeratorProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorSelectMethod.GetByWholesalerIdId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					results = ModeratorProvider.GetByWholesalerIdId(_wholesalerId, _id, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorSelectMethod.GetByModeratorCode:
					_moderatorCode = ( values["ModeratorCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ModeratorCode"], typeof(System.String)) : string.Empty;
					item = ModeratorProvider.GetByModeratorCode(_moderatorCode);
					results = new TList<Moderator>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ModeratorSelectMethod.GetByModeratorCodePassCode:
					_moderatorCode = ( values["ModeratorCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ModeratorCode"], typeof(System.String)) : string.Empty;
					_passCode = ( values["PassCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["PassCode"], typeof(System.String)) : string.Empty;
					results = ModeratorProvider.GetByModeratorCodePassCode(_moderatorCode, _passCode, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorSelectMethod.GetByPassCode:
					_passCode = ( values["PassCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["PassCode"], typeof(System.String)) : string.Empty;
					item = ModeratorProvider.GetByPassCode(_passCode);
					results = new TList<Moderator>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ModeratorSelectMethod.GetByDepartmentId:
					_departmentId = ( values["DepartmentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DepartmentId"], typeof(System.Int32)) : (int)0;
					results = ModeratorProvider.GetByDepartmentId(_departmentId, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorSelectMethod.GetByUserId:
					_userId_nullable = (System.Int32?) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32?));
					results = ModeratorProvider.GetByUserId(_userId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				case ModeratorSelectMethod.GetByDnisidFromModerator_Dnis:
					_dnisid = ( values["Dnisid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Dnisid"], typeof(System.Int32)) : (int)0;
					results = ModeratorProvider.GetByDnisidFromModerator_Dnis(_dnisid, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ModeratorSelectMethod.Get || SelectMethod == ModeratorSelectMethod.GetById )
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
				Moderator entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ModeratorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Moderator> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ModeratorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ModeratorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ModeratorDataSource class.
	/// </summary>
	public class ModeratorDataSourceDesigner : ProviderDataSourceDesigner<Moderator, ModeratorKey>
	{
		/// <summary>
		/// Initializes a new instance of the ModeratorDataSourceDesigner class.
		/// </summary>
		public ModeratorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ModeratorSelectMethod SelectMethod
		{
			get { return ((ModeratorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ModeratorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ModeratorDataSourceActionList

	/// <summary>
	/// Supports the ModeratorDataSourceDesigner class.
	/// </summary>
	internal class ModeratorDataSourceActionList : DesignerActionList
	{
		private ModeratorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ModeratorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ModeratorDataSourceActionList(ModeratorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ModeratorSelectMethod SelectMethod
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

	#endregion ModeratorDataSourceActionList
	
	#endregion ModeratorDataSourceDesigner
	
	#region ModeratorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ModeratorDataSource.SelectMethod property.
	/// </summary>
	public enum ModeratorSelectMethod
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
		/// Represents the GetByCustomerIdPriCustomerNumberSecCustomerNumber method.
		/// </summary>
		GetByCustomerIdPriCustomerNumberSecCustomerNumber,
		/// <summary>
		/// Represents the GetByWholesalerIdPriCustomerNumberSecCustomerNumber method.
		/// </summary>
		GetByWholesalerIdPriCustomerNumberSecCustomerNumber,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByWholesalerIdId method.
		/// </summary>
		GetByWholesalerIdId,
		/// <summary>
		/// Represents the GetByModeratorCode method.
		/// </summary>
		GetByModeratorCode,
		/// <summary>
		/// Represents the GetByModeratorCodePassCode method.
		/// </summary>
		GetByModeratorCodePassCode,
		/// <summary>
		/// Represents the GetByPassCode method.
		/// </summary>
		GetByPassCode,
		/// <summary>
		/// Represents the GetByDepartmentId method.
		/// </summary>
		GetByDepartmentId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByDnisidFromModerator_Dnis method.
		/// </summary>
		GetByDnisidFromModerator_Dnis
	}
	
	#endregion ModeratorSelectMethod

	#region ModeratorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorFilter : SqlFilter<ModeratorColumn>
	{
	}
	
	#endregion ModeratorFilter

	#region ModeratorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorExpressionBuilder : SqlExpressionBuilder<ModeratorColumn>
	{
	}
	
	#endregion ModeratorExpressionBuilder	

	#region ModeratorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ModeratorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorProperty : ChildEntityProperty<ModeratorChildEntityTypes>
	{
	}
	
	#endregion ModeratorProperty
}

