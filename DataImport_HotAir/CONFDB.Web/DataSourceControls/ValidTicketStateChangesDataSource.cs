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
	/// Represents the DataRepository.ValidTicketStateChangesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ValidTicketStateChangesDataSourceDesigner))]
	public class ValidTicketStateChangesDataSource : ProviderDataSource<ValidTicketStateChanges, ValidTicketStateChangesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesDataSource class.
		/// </summary>
		public ValidTicketStateChangesDataSource() : base(new ValidTicketStateChangesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ValidTicketStateChangesDataSourceView used by the ValidTicketStateChangesDataSource.
		/// </summary>
		protected ValidTicketStateChangesDataSourceView ValidTicketStateChangesView
		{
			get { return ( View as ValidTicketStateChangesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ValidTicketStateChangesDataSource control invokes to retrieve data.
		/// </summary>
		public ValidTicketStateChangesSelectMethod SelectMethod
		{
			get
			{
				ValidTicketStateChangesSelectMethod selectMethod = ValidTicketStateChangesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ValidTicketStateChangesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ValidTicketStateChangesDataSourceView class that is to be
		/// used by the ValidTicketStateChangesDataSource.
		/// </summary>
		/// <returns>An instance of the ValidTicketStateChangesDataSourceView class.</returns>
		protected override BaseDataSourceView<ValidTicketStateChanges, ValidTicketStateChangesKey> GetNewDataSourceView()
		{
			return new ValidTicketStateChangesDataSourceView(this, DefaultViewName);
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
	/// Supports the ValidTicketStateChangesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ValidTicketStateChangesDataSourceView : ProviderDataSourceView<ValidTicketStateChanges, ValidTicketStateChangesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ValidTicketStateChangesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ValidTicketStateChangesDataSourceView(ValidTicketStateChangesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ValidTicketStateChangesDataSource ValidTicketStateChangesOwner
		{
			get { return Owner as ValidTicketStateChangesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ValidTicketStateChangesSelectMethod SelectMethod
		{
			get { return ValidTicketStateChangesOwner.SelectMethod; }
			set { ValidTicketStateChangesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ValidTicketStateChangesService ValidTicketStateChangesProvider
		{
			get { return Provider as ValidTicketStateChangesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ValidTicketStateChanges> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ValidTicketStateChanges> results = null;
			ValidTicketStateChanges item;
			count = 0;
			
			System.Int32 _fromStatusId;
			System.Int32 _toStatusId;

			switch ( SelectMethod )
			{
				case ValidTicketStateChangesSelectMethod.Get:
					ValidTicketStateChangesKey entityKey  = new ValidTicketStateChangesKey();
					entityKey.Load(values);
					item = ValidTicketStateChangesProvider.Get(entityKey);
					results = new TList<ValidTicketStateChanges>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ValidTicketStateChangesSelectMethod.GetAll:
                    results = ValidTicketStateChangesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ValidTicketStateChangesSelectMethod.GetPaged:
					results = ValidTicketStateChangesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ValidTicketStateChangesSelectMethod.Find:
					if ( FilterParameters != null )
						results = ValidTicketStateChangesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ValidTicketStateChangesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ValidTicketStateChangesSelectMethod.GetByFromStatusIdToStatusId:
					_fromStatusId = ( values["FromStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FromStatusId"], typeof(System.Int32)) : (int)0;
					_toStatusId = ( values["ToStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ToStatusId"], typeof(System.Int32)) : (int)0;
					item = ValidTicketStateChangesProvider.GetByFromStatusIdToStatusId(_fromStatusId, _toStatusId);
					results = new TList<ValidTicketStateChanges>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ValidTicketStateChangesSelectMethod.GetByFromStatusId:
					_fromStatusId = ( values["FromStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FromStatusId"], typeof(System.Int32)) : (int)0;
					results = ValidTicketStateChangesProvider.GetByFromStatusId(_fromStatusId, this.StartIndex, this.PageSize, out count);
					break;
				case ValidTicketStateChangesSelectMethod.GetByToStatusId:
					_toStatusId = ( values["ToStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ToStatusId"], typeof(System.Int32)) : (int)0;
					results = ValidTicketStateChangesProvider.GetByToStatusId(_toStatusId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ValidTicketStateChangesSelectMethod.Get || SelectMethod == ValidTicketStateChangesSelectMethod.GetByFromStatusIdToStatusId )
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
				ValidTicketStateChanges entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ValidTicketStateChangesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ValidTicketStateChanges> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ValidTicketStateChangesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ValidTicketStateChangesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ValidTicketStateChangesDataSource class.
	/// </summary>
	public class ValidTicketStateChangesDataSourceDesigner : ProviderDataSourceDesigner<ValidTicketStateChanges, ValidTicketStateChangesKey>
	{
		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesDataSourceDesigner class.
		/// </summary>
		public ValidTicketStateChangesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ValidTicketStateChangesSelectMethod SelectMethod
		{
			get { return ((ValidTicketStateChangesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ValidTicketStateChangesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ValidTicketStateChangesDataSourceActionList

	/// <summary>
	/// Supports the ValidTicketStateChangesDataSourceDesigner class.
	/// </summary>
	internal class ValidTicketStateChangesDataSourceActionList : DesignerActionList
	{
		private ValidTicketStateChangesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ValidTicketStateChangesDataSourceActionList(ValidTicketStateChangesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ValidTicketStateChangesSelectMethod SelectMethod
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

	#endregion ValidTicketStateChangesDataSourceActionList
	
	#endregion ValidTicketStateChangesDataSourceDesigner
	
	#region ValidTicketStateChangesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ValidTicketStateChangesDataSource.SelectMethod property.
	/// </summary>
	public enum ValidTicketStateChangesSelectMethod
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
		/// Represents the GetByFromStatusIdToStatusId method.
		/// </summary>
		GetByFromStatusIdToStatusId,
		/// <summary>
		/// Represents the GetByFromStatusId method.
		/// </summary>
		GetByFromStatusId,
		/// <summary>
		/// Represents the GetByToStatusId method.
		/// </summary>
		GetByToStatusId
	}
	
	#endregion ValidTicketStateChangesSelectMethod

	#region ValidTicketStateChangesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesFilter : SqlFilter<ValidTicketStateChangesColumn>
	{
	}
	
	#endregion ValidTicketStateChangesFilter

	#region ValidTicketStateChangesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesExpressionBuilder : SqlExpressionBuilder<ValidTicketStateChangesColumn>
	{
	}
	
	#endregion ValidTicketStateChangesExpressionBuilder	

	#region ValidTicketStateChangesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ValidTicketStateChangesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesProperty : ChildEntityProperty<ValidTicketStateChangesChildEntityTypes>
	{
	}
	
	#endregion ValidTicketStateChangesProperty
}

