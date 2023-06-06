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
	/// Represents the DataRepository.IrWholesalerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(IrWholesalerDataSourceDesigner))]
	public class IrWholesalerDataSource : ProviderDataSource<IrWholesaler, IrWholesalerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerDataSource class.
		/// </summary>
		public IrWholesalerDataSource() : base(new IrWholesalerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the IrWholesalerDataSourceView used by the IrWholesalerDataSource.
		/// </summary>
		protected IrWholesalerDataSourceView IrWholesalerView
		{
			get { return ( View as IrWholesalerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the IrWholesalerDataSource control invokes to retrieve data.
		/// </summary>
		public IrWholesalerSelectMethod SelectMethod
		{
			get
			{
				IrWholesalerSelectMethod selectMethod = IrWholesalerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (IrWholesalerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the IrWholesalerDataSourceView class that is to be
		/// used by the IrWholesalerDataSource.
		/// </summary>
		/// <returns>An instance of the IrWholesalerDataSourceView class.</returns>
		protected override BaseDataSourceView<IrWholesaler, IrWholesalerKey> GetNewDataSourceView()
		{
			return new IrWholesalerDataSourceView(this, DefaultViewName);
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
	/// Supports the IrWholesalerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class IrWholesalerDataSourceView : ProviderDataSourceView<IrWholesaler, IrWholesalerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the IrWholesalerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public IrWholesalerDataSourceView(IrWholesalerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal IrWholesalerDataSource IrWholesalerOwner
		{
			get { return Owner as IrWholesalerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal IrWholesalerSelectMethod SelectMethod
		{
			get { return IrWholesalerOwner.SelectMethod; }
			set { IrWholesalerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal IrWholesalerService IrWholesalerProvider
		{
			get { return Provider as IrWholesalerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<IrWholesaler> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<IrWholesaler> results = null;
			IrWholesaler item;
			count = 0;
			
			System.String _wholesalerId;
			System.String _languageId;

			switch ( SelectMethod )
			{
				case IrWholesalerSelectMethod.Get:
					IrWholesalerKey entityKey  = new IrWholesalerKey();
					entityKey.Load(values);
					item = IrWholesalerProvider.Get(entityKey);
					results = new TList<IrWholesaler>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case IrWholesalerSelectMethod.GetAll:
                    results = IrWholesalerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case IrWholesalerSelectMethod.GetPaged:
					results = IrWholesalerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case IrWholesalerSelectMethod.Find:
					if ( FilterParameters != null )
						results = IrWholesalerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = IrWholesalerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case IrWholesalerSelectMethod.GetByWholesalerIdLanguageId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_languageId = ( values["LanguageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["LanguageId"], typeof(System.String)) : string.Empty;
					item = IrWholesalerProvider.GetByWholesalerIdLanguageId(_wholesalerId, _languageId);
					results = new TList<IrWholesaler>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case IrWholesalerSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = IrWholesalerProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
					break;
				case IrWholesalerSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["LanguageId"], typeof(System.String)) : string.Empty;
					results = IrWholesalerProvider.GetByLanguageId(_languageId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == IrWholesalerSelectMethod.Get || SelectMethod == IrWholesalerSelectMethod.GetByWholesalerIdLanguageId )
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
				IrWholesaler entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					IrWholesalerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<IrWholesaler> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			IrWholesalerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region IrWholesalerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the IrWholesalerDataSource class.
	/// </summary>
	public class IrWholesalerDataSourceDesigner : ProviderDataSourceDesigner<IrWholesaler, IrWholesalerKey>
	{
		/// <summary>
		/// Initializes a new instance of the IrWholesalerDataSourceDesigner class.
		/// </summary>
		public IrWholesalerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IrWholesalerSelectMethod SelectMethod
		{
			get { return ((IrWholesalerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new IrWholesalerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region IrWholesalerDataSourceActionList

	/// <summary>
	/// Supports the IrWholesalerDataSourceDesigner class.
	/// </summary>
	internal class IrWholesalerDataSourceActionList : DesignerActionList
	{
		private IrWholesalerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the IrWholesalerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public IrWholesalerDataSourceActionList(IrWholesalerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IrWholesalerSelectMethod SelectMethod
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

	#endregion IrWholesalerDataSourceActionList
	
	#endregion IrWholesalerDataSourceDesigner
	
	#region IrWholesalerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the IrWholesalerDataSource.SelectMethod property.
	/// </summary>
	public enum IrWholesalerSelectMethod
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
		/// Represents the GetByWholesalerIdLanguageId method.
		/// </summary>
		GetByWholesalerIdLanguageId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId
	}
	
	#endregion IrWholesalerSelectMethod

	#region IrWholesalerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerFilter : SqlFilter<IrWholesalerColumn>
	{
	}
	
	#endregion IrWholesalerFilter

	#region IrWholesalerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerExpressionBuilder : SqlExpressionBuilder<IrWholesalerColumn>
	{
	}
	
	#endregion IrWholesalerExpressionBuilder	

	#region IrWholesalerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;IrWholesalerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerProperty : ChildEntityProperty<IrWholesalerChildEntityTypes>
	{
	}
	
	#endregion IrWholesalerProperty
}

