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
	/// Represents the DataRepository.PrevInvoicesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PrevInvoicesDataSourceDesigner))]
	public class PrevInvoicesDataSource : ProviderDataSource<PrevInvoices, PrevInvoicesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesDataSource class.
		/// </summary>
		public PrevInvoicesDataSource() : base(new PrevInvoicesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PrevInvoicesDataSourceView used by the PrevInvoicesDataSource.
		/// </summary>
		protected PrevInvoicesDataSourceView PrevInvoicesView
		{
			get { return ( View as PrevInvoicesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PrevInvoicesDataSource control invokes to retrieve data.
		/// </summary>
		public PrevInvoicesSelectMethod SelectMethod
		{
			get
			{
				PrevInvoicesSelectMethod selectMethod = PrevInvoicesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PrevInvoicesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PrevInvoicesDataSourceView class that is to be
		/// used by the PrevInvoicesDataSource.
		/// </summary>
		/// <returns>An instance of the PrevInvoicesDataSourceView class.</returns>
		protected override BaseDataSourceView<PrevInvoices, PrevInvoicesKey> GetNewDataSourceView()
		{
			return new PrevInvoicesDataSourceView(this, DefaultViewName);
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
	/// Supports the PrevInvoicesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PrevInvoicesDataSourceView : ProviderDataSourceView<PrevInvoices, PrevInvoicesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PrevInvoicesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PrevInvoicesDataSourceView(PrevInvoicesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PrevInvoicesDataSource PrevInvoicesOwner
		{
			get { return Owner as PrevInvoicesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PrevInvoicesSelectMethod SelectMethod
		{
			get { return PrevInvoicesOwner.SelectMethod; }
			set { PrevInvoicesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PrevInvoicesService PrevInvoicesProvider
		{
			get { return Provider as PrevInvoicesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PrevInvoices> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PrevInvoices> results = null;
			PrevInvoices item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case PrevInvoicesSelectMethod.Get:
					PrevInvoicesKey entityKey  = new PrevInvoicesKey();
					entityKey.Load(values);
					item = PrevInvoicesProvider.Get(entityKey);
					results = new TList<PrevInvoices>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PrevInvoicesSelectMethod.GetAll:
                    results = PrevInvoicesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PrevInvoicesSelectMethod.GetPaged:
					results = PrevInvoicesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PrevInvoicesSelectMethod.Find:
					if ( FilterParameters != null )
						results = PrevInvoicesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PrevInvoicesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PrevInvoicesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = PrevInvoicesProvider.GetById(_id);
					results = new TList<PrevInvoices>();
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
			if ( SelectMethod == PrevInvoicesSelectMethod.Get || SelectMethod == PrevInvoicesSelectMethod.GetById )
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
				PrevInvoices entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PrevInvoicesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PrevInvoices> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PrevInvoicesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PrevInvoicesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PrevInvoicesDataSource class.
	/// </summary>
	public class PrevInvoicesDataSourceDesigner : ProviderDataSourceDesigner<PrevInvoices, PrevInvoicesKey>
	{
		/// <summary>
		/// Initializes a new instance of the PrevInvoicesDataSourceDesigner class.
		/// </summary>
		public PrevInvoicesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PrevInvoicesSelectMethod SelectMethod
		{
			get { return ((PrevInvoicesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PrevInvoicesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PrevInvoicesDataSourceActionList

	/// <summary>
	/// Supports the PrevInvoicesDataSourceDesigner class.
	/// </summary>
	internal class PrevInvoicesDataSourceActionList : DesignerActionList
	{
		private PrevInvoicesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PrevInvoicesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PrevInvoicesDataSourceActionList(PrevInvoicesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PrevInvoicesSelectMethod SelectMethod
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

	#endregion PrevInvoicesDataSourceActionList
	
	#endregion PrevInvoicesDataSourceDesigner
	
	#region PrevInvoicesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PrevInvoicesDataSource.SelectMethod property.
	/// </summary>
	public enum PrevInvoicesSelectMethod
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
	
	#endregion PrevInvoicesSelectMethod

	#region PrevInvoicesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PrevInvoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PrevInvoicesFilter : SqlFilter<PrevInvoicesColumn>
	{
	}
	
	#endregion PrevInvoicesFilter

	#region PrevInvoicesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PrevInvoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PrevInvoicesExpressionBuilder : SqlExpressionBuilder<PrevInvoicesColumn>
	{
	}
	
	#endregion PrevInvoicesExpressionBuilder	

	#region PrevInvoicesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PrevInvoicesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PrevInvoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PrevInvoicesProperty : ChildEntityProperty<PrevInvoicesChildEntityTypes>
	{
	}
	
	#endregion PrevInvoicesProperty
}

