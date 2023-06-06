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
	/// Represents the DataRepository.InvoiceNotesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(InvoiceNotesDataSourceDesigner))]
	public class InvoiceNotesDataSource : ProviderDataSource<InvoiceNotes, InvoiceNotesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesDataSource class.
		/// </summary>
		public InvoiceNotesDataSource() : base(new InvoiceNotesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the InvoiceNotesDataSourceView used by the InvoiceNotesDataSource.
		/// </summary>
		protected InvoiceNotesDataSourceView InvoiceNotesView
		{
			get { return ( View as InvoiceNotesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the InvoiceNotesDataSource control invokes to retrieve data.
		/// </summary>
		public InvoiceNotesSelectMethod SelectMethod
		{
			get
			{
				InvoiceNotesSelectMethod selectMethod = InvoiceNotesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (InvoiceNotesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the InvoiceNotesDataSourceView class that is to be
		/// used by the InvoiceNotesDataSource.
		/// </summary>
		/// <returns>An instance of the InvoiceNotesDataSourceView class.</returns>
		protected override BaseDataSourceView<InvoiceNotes, InvoiceNotesKey> GetNewDataSourceView()
		{
			return new InvoiceNotesDataSourceView(this, DefaultViewName);
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
	/// Supports the InvoiceNotesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class InvoiceNotesDataSourceView : ProviderDataSourceView<InvoiceNotes, InvoiceNotesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the InvoiceNotesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public InvoiceNotesDataSourceView(InvoiceNotesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal InvoiceNotesDataSource InvoiceNotesOwner
		{
			get { return Owner as InvoiceNotesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal InvoiceNotesSelectMethod SelectMethod
		{
			get { return InvoiceNotesOwner.SelectMethod; }
			set { InvoiceNotesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal InvoiceNotesService InvoiceNotesProvider
		{
			get { return Provider as InvoiceNotesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<InvoiceNotes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<InvoiceNotes> results = null;
			InvoiceNotes item;
			count = 0;
			
			System.Int32 _id;
			System.DateTime _startDate;
			System.DateTime? _endDate_nullable;
			System.String _wholesalerId;

			switch ( SelectMethod )
			{
				case InvoiceNotesSelectMethod.Get:
					InvoiceNotesKey entityKey  = new InvoiceNotesKey();
					entityKey.Load(values);
					item = InvoiceNotesProvider.Get(entityKey);
					results = new TList<InvoiceNotes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case InvoiceNotesSelectMethod.GetAll:
                    results = InvoiceNotesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case InvoiceNotesSelectMethod.GetPaged:
					results = InvoiceNotesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case InvoiceNotesSelectMethod.Find:
					if ( FilterParameters != null )
						results = InvoiceNotesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = InvoiceNotesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case InvoiceNotesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = InvoiceNotesProvider.GetById(_id);
					results = new TList<InvoiceNotes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case InvoiceNotesSelectMethod.GetByStartDate:
					_startDate = ( values["StartDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["StartDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = InvoiceNotesProvider.GetByStartDate(_startDate, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceNotesSelectMethod.GetByEndDate:
					_endDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["EndDate"], typeof(System.DateTime?));
					results = InvoiceNotesProvider.GetByEndDate(_endDate_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceNotesSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = InvoiceNotesProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == InvoiceNotesSelectMethod.Get || SelectMethod == InvoiceNotesSelectMethod.GetById )
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
				InvoiceNotes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					InvoiceNotesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<InvoiceNotes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			InvoiceNotesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region InvoiceNotesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the InvoiceNotesDataSource class.
	/// </summary>
	public class InvoiceNotesDataSourceDesigner : ProviderDataSourceDesigner<InvoiceNotes, InvoiceNotesKey>
	{
		/// <summary>
		/// Initializes a new instance of the InvoiceNotesDataSourceDesigner class.
		/// </summary>
		public InvoiceNotesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceNotesSelectMethod SelectMethod
		{
			get { return ((InvoiceNotesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new InvoiceNotesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region InvoiceNotesDataSourceActionList

	/// <summary>
	/// Supports the InvoiceNotesDataSourceDesigner class.
	/// </summary>
	internal class InvoiceNotesDataSourceActionList : DesignerActionList
	{
		private InvoiceNotesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public InvoiceNotesDataSourceActionList(InvoiceNotesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceNotesSelectMethod SelectMethod
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

	#endregion InvoiceNotesDataSourceActionList
	
	#endregion InvoiceNotesDataSourceDesigner
	
	#region InvoiceNotesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the InvoiceNotesDataSource.SelectMethod property.
	/// </summary>
	public enum InvoiceNotesSelectMethod
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
		/// Represents the GetByStartDate method.
		/// </summary>
		GetByStartDate,
		/// <summary>
		/// Represents the GetByEndDate method.
		/// </summary>
		GetByEndDate,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion InvoiceNotesSelectMethod

	#region InvoiceNotesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesFilter : SqlFilter<InvoiceNotesColumn>
	{
	}
	
	#endregion InvoiceNotesFilter

	#region InvoiceNotesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesExpressionBuilder : SqlExpressionBuilder<InvoiceNotesColumn>
	{
	}
	
	#endregion InvoiceNotesExpressionBuilder	

	#region InvoiceNotesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;InvoiceNotesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesProperty : ChildEntityProperty<InvoiceNotesChildEntityTypes>
	{
	}
	
	#endregion InvoiceNotesProperty
}

