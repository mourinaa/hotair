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
	/// Represents the DataRepository.InvoiceChargesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(InvoiceChargesDataSourceDesigner))]
	public class InvoiceChargesDataSource : ProviderDataSource<InvoiceCharges, InvoiceChargesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesDataSource class.
		/// </summary>
		public InvoiceChargesDataSource() : base(new InvoiceChargesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the InvoiceChargesDataSourceView used by the InvoiceChargesDataSource.
		/// </summary>
		protected InvoiceChargesDataSourceView InvoiceChargesView
		{
			get { return ( View as InvoiceChargesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the InvoiceChargesDataSource control invokes to retrieve data.
		/// </summary>
		public InvoiceChargesSelectMethod SelectMethod
		{
			get
			{
				InvoiceChargesSelectMethod selectMethod = InvoiceChargesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (InvoiceChargesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the InvoiceChargesDataSourceView class that is to be
		/// used by the InvoiceChargesDataSource.
		/// </summary>
		/// <returns>An instance of the InvoiceChargesDataSourceView class.</returns>
		protected override BaseDataSourceView<InvoiceCharges, InvoiceChargesKey> GetNewDataSourceView()
		{
			return new InvoiceChargesDataSourceView(this, DefaultViewName);
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
	/// Supports the InvoiceChargesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class InvoiceChargesDataSourceView : ProviderDataSourceView<InvoiceCharges, InvoiceChargesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the InvoiceChargesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public InvoiceChargesDataSourceView(InvoiceChargesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal InvoiceChargesDataSource InvoiceChargesOwner
		{
			get { return Owner as InvoiceChargesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal InvoiceChargesSelectMethod SelectMethod
		{
			get { return InvoiceChargesOwner.SelectMethod; }
			set { InvoiceChargesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal InvoiceChargesService InvoiceChargesProvider
		{
			get { return Provider as InvoiceChargesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<InvoiceCharges> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<InvoiceCharges> results = null;
			InvoiceCharges item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case InvoiceChargesSelectMethod.Get:
					InvoiceChargesKey entityKey  = new InvoiceChargesKey();
					entityKey.Load(values);
					item = InvoiceChargesProvider.Get(entityKey);
					results = new TList<InvoiceCharges>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case InvoiceChargesSelectMethod.GetAll:
                    results = InvoiceChargesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case InvoiceChargesSelectMethod.GetPaged:
					results = InvoiceChargesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case InvoiceChargesSelectMethod.Find:
					if ( FilterParameters != null )
						results = InvoiceChargesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = InvoiceChargesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case InvoiceChargesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = InvoiceChargesProvider.GetById(_id);
					results = new TList<InvoiceCharges>();
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
			if ( SelectMethod == InvoiceChargesSelectMethod.Get || SelectMethod == InvoiceChargesSelectMethod.GetById )
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
				InvoiceCharges entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					InvoiceChargesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<InvoiceCharges> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			InvoiceChargesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region InvoiceChargesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the InvoiceChargesDataSource class.
	/// </summary>
	public class InvoiceChargesDataSourceDesigner : ProviderDataSourceDesigner<InvoiceCharges, InvoiceChargesKey>
	{
		/// <summary>
		/// Initializes a new instance of the InvoiceChargesDataSourceDesigner class.
		/// </summary>
		public InvoiceChargesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceChargesSelectMethod SelectMethod
		{
			get { return ((InvoiceChargesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new InvoiceChargesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region InvoiceChargesDataSourceActionList

	/// <summary>
	/// Supports the InvoiceChargesDataSourceDesigner class.
	/// </summary>
	internal class InvoiceChargesDataSourceActionList : DesignerActionList
	{
		private InvoiceChargesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the InvoiceChargesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public InvoiceChargesDataSourceActionList(InvoiceChargesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceChargesSelectMethod SelectMethod
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

	#endregion InvoiceChargesDataSourceActionList
	
	#endregion InvoiceChargesDataSourceDesigner
	
	#region InvoiceChargesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the InvoiceChargesDataSource.SelectMethod property.
	/// </summary>
	public enum InvoiceChargesSelectMethod
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
	
	#endregion InvoiceChargesSelectMethod

	#region InvoiceChargesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceCharges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceChargesFilter : SqlFilter<InvoiceChargesColumn>
	{
	}
	
	#endregion InvoiceChargesFilter

	#region InvoiceChargesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceCharges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceChargesExpressionBuilder : SqlExpressionBuilder<InvoiceChargesColumn>
	{
	}
	
	#endregion InvoiceChargesExpressionBuilder	

	#region InvoiceChargesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;InvoiceChargesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceCharges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceChargesProperty : ChildEntityProperty<InvoiceChargesChildEntityTypes>
	{
	}
	
	#endregion InvoiceChargesProperty
}

