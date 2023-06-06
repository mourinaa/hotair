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
	/// Represents the DataRepository.TicketProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketProductDataSourceDesigner))]
	public class TicketProductDataSource : ProviderDataSource<TicketProduct, TicketProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketProductDataSource class.
		/// </summary>
		public TicketProductDataSource() : base(new TicketProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketProductDataSourceView used by the TicketProductDataSource.
		/// </summary>
		protected TicketProductDataSourceView TicketProductView
		{
			get { return ( View as TicketProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketProductDataSource control invokes to retrieve data.
		/// </summary>
		public TicketProductSelectMethod SelectMethod
		{
			get
			{
				TicketProductSelectMethod selectMethod = TicketProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketProductDataSourceView class that is to be
		/// used by the TicketProductDataSource.
		/// </summary>
		/// <returns>An instance of the TicketProductDataSourceView class.</returns>
		protected override BaseDataSourceView<TicketProduct, TicketProductKey> GetNewDataSourceView()
		{
			return new TicketProductDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketProductDataSourceView : ProviderDataSourceView<TicketProduct, TicketProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketProductDataSourceView(TicketProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketProductDataSource TicketProductOwner
		{
			get { return Owner as TicketProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketProductSelectMethod SelectMethod
		{
			get { return TicketProductOwner.SelectMethod; }
			set { TicketProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketProductService TicketProductProvider
		{
			get { return Provider as TicketProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TicketProduct> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TicketProduct> results = null;
			TicketProduct item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case TicketProductSelectMethod.Get:
					TicketProductKey entityKey  = new TicketProductKey();
					entityKey.Load(values);
					item = TicketProductProvider.Get(entityKey);
					results = new TList<TicketProduct>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketProductSelectMethod.GetAll:
                    results = TicketProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketProductSelectMethod.GetPaged:
					results = TicketProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketProductSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = TicketProductProvider.GetById(_id);
					results = new TList<TicketProduct>();
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
			if ( SelectMethod == TicketProductSelectMethod.Get || SelectMethod == TicketProductSelectMethod.GetById )
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
				TicketProduct entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TicketProduct> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketProductDataSource class.
	/// </summary>
	public class TicketProductDataSourceDesigner : ProviderDataSourceDesigner<TicketProduct, TicketProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketProductDataSourceDesigner class.
		/// </summary>
		public TicketProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketProductSelectMethod SelectMethod
		{
			get { return ((TicketProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketProductDataSourceActionList

	/// <summary>
	/// Supports the TicketProductDataSourceDesigner class.
	/// </summary>
	internal class TicketProductDataSourceActionList : DesignerActionList
	{
		private TicketProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketProductDataSourceActionList(TicketProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketProductSelectMethod SelectMethod
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

	#endregion TicketProductDataSourceActionList
	
	#endregion TicketProductDataSourceDesigner
	
	#region TicketProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketProductDataSource.SelectMethod property.
	/// </summary>
	public enum TicketProductSelectMethod
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
	
	#endregion TicketProductSelectMethod

	#region TicketProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProductFilter : SqlFilter<TicketProductColumn>
	{
	}
	
	#endregion TicketProductFilter

	#region TicketProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProductExpressionBuilder : SqlExpressionBuilder<TicketProductColumn>
	{
	}
	
	#endregion TicketProductExpressionBuilder	

	#region TicketProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TicketProduct"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketProductProperty : ChildEntityProperty<TicketProductChildEntityTypes>
	{
	}
	
	#endregion TicketProductProperty
}

