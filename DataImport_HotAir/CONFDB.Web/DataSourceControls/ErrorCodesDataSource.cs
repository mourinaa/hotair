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
	/// Represents the DataRepository.ErrorCodesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ErrorCodesDataSourceDesigner))]
	public class ErrorCodesDataSource : ProviderDataSource<ErrorCodes, ErrorCodesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorCodesDataSource class.
		/// </summary>
		public ErrorCodesDataSource() : base(new ErrorCodesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ErrorCodesDataSourceView used by the ErrorCodesDataSource.
		/// </summary>
		protected ErrorCodesDataSourceView ErrorCodesView
		{
			get { return ( View as ErrorCodesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ErrorCodesDataSource control invokes to retrieve data.
		/// </summary>
		public ErrorCodesSelectMethod SelectMethod
		{
			get
			{
				ErrorCodesSelectMethod selectMethod = ErrorCodesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ErrorCodesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ErrorCodesDataSourceView class that is to be
		/// used by the ErrorCodesDataSource.
		/// </summary>
		/// <returns>An instance of the ErrorCodesDataSourceView class.</returns>
		protected override BaseDataSourceView<ErrorCodes, ErrorCodesKey> GetNewDataSourceView()
		{
			return new ErrorCodesDataSourceView(this, DefaultViewName);
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
	/// Supports the ErrorCodesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ErrorCodesDataSourceView : ProviderDataSourceView<ErrorCodes, ErrorCodesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ErrorCodesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ErrorCodesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ErrorCodesDataSourceView(ErrorCodesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ErrorCodesDataSource ErrorCodesOwner
		{
			get { return Owner as ErrorCodesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ErrorCodesSelectMethod SelectMethod
		{
			get { return ErrorCodesOwner.SelectMethod; }
			set { ErrorCodesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ErrorCodesService ErrorCodesProvider
		{
			get { return Provider as ErrorCodesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ErrorCodes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ErrorCodes> results = null;
			ErrorCodes item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ErrorCodesSelectMethod.Get:
					ErrorCodesKey entityKey  = new ErrorCodesKey();
					entityKey.Load(values);
					item = ErrorCodesProvider.Get(entityKey);
					results = new TList<ErrorCodes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ErrorCodesSelectMethod.GetAll:
                    results = ErrorCodesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ErrorCodesSelectMethod.GetPaged:
					results = ErrorCodesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ErrorCodesSelectMethod.Find:
					if ( FilterParameters != null )
						results = ErrorCodesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ErrorCodesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ErrorCodesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ErrorCodesProvider.GetById(_id);
					results = new TList<ErrorCodes>();
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
			if ( SelectMethod == ErrorCodesSelectMethod.Get || SelectMethod == ErrorCodesSelectMethod.GetById )
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
				ErrorCodes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ErrorCodesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ErrorCodes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ErrorCodesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ErrorCodesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ErrorCodesDataSource class.
	/// </summary>
	public class ErrorCodesDataSourceDesigner : ProviderDataSourceDesigner<ErrorCodes, ErrorCodesKey>
	{
		/// <summary>
		/// Initializes a new instance of the ErrorCodesDataSourceDesigner class.
		/// </summary>
		public ErrorCodesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ErrorCodesSelectMethod SelectMethod
		{
			get { return ((ErrorCodesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ErrorCodesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ErrorCodesDataSourceActionList

	/// <summary>
	/// Supports the ErrorCodesDataSourceDesigner class.
	/// </summary>
	internal class ErrorCodesDataSourceActionList : DesignerActionList
	{
		private ErrorCodesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ErrorCodesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ErrorCodesDataSourceActionList(ErrorCodesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ErrorCodesSelectMethod SelectMethod
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

	#endregion ErrorCodesDataSourceActionList
	
	#endregion ErrorCodesDataSourceDesigner
	
	#region ErrorCodesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ErrorCodesDataSource.SelectMethod property.
	/// </summary>
	public enum ErrorCodesSelectMethod
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
	
	#endregion ErrorCodesSelectMethod

	#region ErrorCodesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorCodesFilter : SqlFilter<ErrorCodesColumn>
	{
	}
	
	#endregion ErrorCodesFilter

	#region ErrorCodesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorCodesExpressionBuilder : SqlExpressionBuilder<ErrorCodesColumn>
	{
	}
	
	#endregion ErrorCodesExpressionBuilder	

	#region ErrorCodesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ErrorCodesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ErrorCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ErrorCodesProperty : ChildEntityProperty<ErrorCodesChildEntityTypes>
	{
	}
	
	#endregion ErrorCodesProperty
}

