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
	/// Represents the DataRepository.ClientNotesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ClientNotesDataSourceDesigner))]
	public class ClientNotesDataSource : ProviderDataSource<ClientNotes, ClientNotesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientNotesDataSource class.
		/// </summary>
		public ClientNotesDataSource() : base(new ClientNotesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ClientNotesDataSourceView used by the ClientNotesDataSource.
		/// </summary>
		protected ClientNotesDataSourceView ClientNotesView
		{
			get { return ( View as ClientNotesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ClientNotesDataSource control invokes to retrieve data.
		/// </summary>
		public ClientNotesSelectMethod SelectMethod
		{
			get
			{
				ClientNotesSelectMethod selectMethod = ClientNotesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ClientNotesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ClientNotesDataSourceView class that is to be
		/// used by the ClientNotesDataSource.
		/// </summary>
		/// <returns>An instance of the ClientNotesDataSourceView class.</returns>
		protected override BaseDataSourceView<ClientNotes, ClientNotesKey> GetNewDataSourceView()
		{
			return new ClientNotesDataSourceView(this, DefaultViewName);
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
	/// Supports the ClientNotesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ClientNotesDataSourceView : ProviderDataSourceView<ClientNotes, ClientNotesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClientNotesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ClientNotesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ClientNotesDataSourceView(ClientNotesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ClientNotesDataSource ClientNotesOwner
		{
			get { return Owner as ClientNotesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ClientNotesSelectMethod SelectMethod
		{
			get { return ClientNotesOwner.SelectMethod; }
			set { ClientNotesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ClientNotesService ClientNotesProvider
		{
			get { return Provider as ClientNotesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ClientNotes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ClientNotes> results = null;
			ClientNotes item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ClientNotesSelectMethod.Get:
					ClientNotesKey entityKey  = new ClientNotesKey();
					entityKey.Load(values);
					item = ClientNotesProvider.Get(entityKey);
					results = new TList<ClientNotes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ClientNotesSelectMethod.GetAll:
                    results = ClientNotesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ClientNotesSelectMethod.GetPaged:
					results = ClientNotesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ClientNotesSelectMethod.Find:
					if ( FilterParameters != null )
						results = ClientNotesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ClientNotesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ClientNotesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ClientNotesProvider.GetById(_id);
					results = new TList<ClientNotes>();
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
			if ( SelectMethod == ClientNotesSelectMethod.Get || SelectMethod == ClientNotesSelectMethod.GetById )
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
				ClientNotes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ClientNotesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ClientNotes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ClientNotesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ClientNotesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ClientNotesDataSource class.
	/// </summary>
	public class ClientNotesDataSourceDesigner : ProviderDataSourceDesigner<ClientNotes, ClientNotesKey>
	{
		/// <summary>
		/// Initializes a new instance of the ClientNotesDataSourceDesigner class.
		/// </summary>
		public ClientNotesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClientNotesSelectMethod SelectMethod
		{
			get { return ((ClientNotesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ClientNotesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ClientNotesDataSourceActionList

	/// <summary>
	/// Supports the ClientNotesDataSourceDesigner class.
	/// </summary>
	internal class ClientNotesDataSourceActionList : DesignerActionList
	{
		private ClientNotesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ClientNotesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ClientNotesDataSourceActionList(ClientNotesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClientNotesSelectMethod SelectMethod
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

	#endregion ClientNotesDataSourceActionList
	
	#endregion ClientNotesDataSourceDesigner
	
	#region ClientNotesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ClientNotesDataSource.SelectMethod property.
	/// </summary>
	public enum ClientNotesSelectMethod
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
	
	#endregion ClientNotesSelectMethod

	#region ClientNotesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientNotesFilter : SqlFilter<ClientNotesColumn>
	{
	}
	
	#endregion ClientNotesFilter

	#region ClientNotesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClientNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientNotesExpressionBuilder : SqlExpressionBuilder<ClientNotesColumn>
	{
	}
	
	#endregion ClientNotesExpressionBuilder	

	#region ClientNotesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ClientNotesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ClientNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClientNotesProperty : ChildEntityProperty<ClientNotesChildEntityTypes>
	{
	}
	
	#endregion ClientNotesProperty
}

