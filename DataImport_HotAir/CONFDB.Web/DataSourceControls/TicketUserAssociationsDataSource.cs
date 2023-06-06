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
	/// Represents the DataRepository.TicketUserAssociationsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TicketUserAssociationsDataSourceDesigner))]
	public class TicketUserAssociationsDataSource : ProviderDataSource<TicketUserAssociations, TicketUserAssociationsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsDataSource class.
		/// </summary>
		public TicketUserAssociationsDataSource() : base(new TicketUserAssociationsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TicketUserAssociationsDataSourceView used by the TicketUserAssociationsDataSource.
		/// </summary>
		protected TicketUserAssociationsDataSourceView TicketUserAssociationsView
		{
			get { return ( View as TicketUserAssociationsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TicketUserAssociationsDataSource control invokes to retrieve data.
		/// </summary>
		public TicketUserAssociationsSelectMethod SelectMethod
		{
			get
			{
				TicketUserAssociationsSelectMethod selectMethod = TicketUserAssociationsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TicketUserAssociationsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TicketUserAssociationsDataSourceView class that is to be
		/// used by the TicketUserAssociationsDataSource.
		/// </summary>
		/// <returns>An instance of the TicketUserAssociationsDataSourceView class.</returns>
		protected override BaseDataSourceView<TicketUserAssociations, TicketUserAssociationsKey> GetNewDataSourceView()
		{
			return new TicketUserAssociationsDataSourceView(this, DefaultViewName);
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
	/// Supports the TicketUserAssociationsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TicketUserAssociationsDataSourceView : ProviderDataSourceView<TicketUserAssociations, TicketUserAssociationsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TicketUserAssociationsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TicketUserAssociationsDataSourceView(TicketUserAssociationsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TicketUserAssociationsDataSource TicketUserAssociationsOwner
		{
			get { return Owner as TicketUserAssociationsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TicketUserAssociationsSelectMethod SelectMethod
		{
			get { return TicketUserAssociationsOwner.SelectMethod; }
			set { TicketUserAssociationsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TicketUserAssociationsService TicketUserAssociationsProvider
		{
			get { return Provider as TicketUserAssociationsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TicketUserAssociations> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TicketUserAssociations> results = null;
			TicketUserAssociations item;
			count = 0;
			
			System.Int32 _userId;
			System.Int32 _ticketUserId;

			switch ( SelectMethod )
			{
				case TicketUserAssociationsSelectMethod.Get:
					TicketUserAssociationsKey entityKey  = new TicketUserAssociationsKey();
					entityKey.Load(values);
					item = TicketUserAssociationsProvider.Get(entityKey);
					results = new TList<TicketUserAssociations>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TicketUserAssociationsSelectMethod.GetAll:
                    results = TicketUserAssociationsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TicketUserAssociationsSelectMethod.GetPaged:
					results = TicketUserAssociationsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TicketUserAssociationsSelectMethod.Find:
					if ( FilterParameters != null )
						results = TicketUserAssociationsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TicketUserAssociationsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TicketUserAssociationsSelectMethod.GetByUserIdTicketUserId:
					_userId = ( values["UserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32)) : (int)0;
					_ticketUserId = ( values["TicketUserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TicketUserId"], typeof(System.Int32)) : (int)0;
					item = TicketUserAssociationsProvider.GetByUserIdTicketUserId(_userId, _ticketUserId);
					results = new TList<TicketUserAssociations>();
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
			if ( SelectMethod == TicketUserAssociationsSelectMethod.Get || SelectMethod == TicketUserAssociationsSelectMethod.GetByUserIdTicketUserId )
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
				TicketUserAssociations entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TicketUserAssociationsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TicketUserAssociations> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TicketUserAssociationsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TicketUserAssociationsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TicketUserAssociationsDataSource class.
	/// </summary>
	public class TicketUserAssociationsDataSourceDesigner : ProviderDataSourceDesigner<TicketUserAssociations, TicketUserAssociationsKey>
	{
		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsDataSourceDesigner class.
		/// </summary>
		public TicketUserAssociationsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketUserAssociationsSelectMethod SelectMethod
		{
			get { return ((TicketUserAssociationsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TicketUserAssociationsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TicketUserAssociationsDataSourceActionList

	/// <summary>
	/// Supports the TicketUserAssociationsDataSourceDesigner class.
	/// </summary>
	internal class TicketUserAssociationsDataSourceActionList : DesignerActionList
	{
		private TicketUserAssociationsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TicketUserAssociationsDataSourceActionList(TicketUserAssociationsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TicketUserAssociationsSelectMethod SelectMethod
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

	#endregion TicketUserAssociationsDataSourceActionList
	
	#endregion TicketUserAssociationsDataSourceDesigner
	
	#region TicketUserAssociationsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TicketUserAssociationsDataSource.SelectMethod property.
	/// </summary>
	public enum TicketUserAssociationsSelectMethod
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
		/// Represents the GetByUserIdTicketUserId method.
		/// </summary>
		GetByUserIdTicketUserId
	}
	
	#endregion TicketUserAssociationsSelectMethod

	#region TicketUserAssociationsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsFilter : SqlFilter<TicketUserAssociationsColumn>
	{
	}
	
	#endregion TicketUserAssociationsFilter

	#region TicketUserAssociationsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsExpressionBuilder : SqlExpressionBuilder<TicketUserAssociationsColumn>
	{
	}
	
	#endregion TicketUserAssociationsExpressionBuilder	

	#region TicketUserAssociationsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TicketUserAssociationsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsProperty : ChildEntityProperty<TicketUserAssociationsChildEntityTypes>
	{
	}
	
	#endregion TicketUserAssociationsProperty
}

