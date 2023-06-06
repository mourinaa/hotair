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
	/// Represents the DataRepository.OmnoviaMp4RequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OmnoviaMp4RequestDataSourceDesigner))]
	public class OmnoviaMp4RequestDataSource : ProviderDataSource<OmnoviaMp4Request, OmnoviaMp4RequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestDataSource class.
		/// </summary>
		public OmnoviaMp4RequestDataSource() : base(new OmnoviaMp4RequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OmnoviaMp4RequestDataSourceView used by the OmnoviaMp4RequestDataSource.
		/// </summary>
		protected OmnoviaMp4RequestDataSourceView OmnoviaMp4RequestView
		{
			get { return ( View as OmnoviaMp4RequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OmnoviaMp4RequestDataSource control invokes to retrieve data.
		/// </summary>
		public OmnoviaMp4RequestSelectMethod SelectMethod
		{
			get
			{
				OmnoviaMp4RequestSelectMethod selectMethod = OmnoviaMp4RequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OmnoviaMp4RequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OmnoviaMp4RequestDataSourceView class that is to be
		/// used by the OmnoviaMp4RequestDataSource.
		/// </summary>
		/// <returns>An instance of the OmnoviaMp4RequestDataSourceView class.</returns>
		protected override BaseDataSourceView<OmnoviaMp4Request, OmnoviaMp4RequestKey> GetNewDataSourceView()
		{
			return new OmnoviaMp4RequestDataSourceView(this, DefaultViewName);
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
	/// Supports the OmnoviaMp4RequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OmnoviaMp4RequestDataSourceView : ProviderDataSourceView<OmnoviaMp4Request, OmnoviaMp4RequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OmnoviaMp4RequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OmnoviaMp4RequestDataSourceView(OmnoviaMp4RequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OmnoviaMp4RequestDataSource OmnoviaMp4RequestOwner
		{
			get { return Owner as OmnoviaMp4RequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OmnoviaMp4RequestSelectMethod SelectMethod
		{
			get { return OmnoviaMp4RequestOwner.SelectMethod; }
			set { OmnoviaMp4RequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OmnoviaMp4RequestService OmnoviaMp4RequestProvider
		{
			get { return Provider as OmnoviaMp4RequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OmnoviaMp4Request> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OmnoviaMp4Request> results = null;
			OmnoviaMp4Request item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case OmnoviaMp4RequestSelectMethod.Get:
					OmnoviaMp4RequestKey entityKey  = new OmnoviaMp4RequestKey();
					entityKey.Load(values);
					item = OmnoviaMp4RequestProvider.Get(entityKey);
					results = new TList<OmnoviaMp4Request>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OmnoviaMp4RequestSelectMethod.GetAll:
                    results = OmnoviaMp4RequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OmnoviaMp4RequestSelectMethod.GetPaged:
					results = OmnoviaMp4RequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OmnoviaMp4RequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = OmnoviaMp4RequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OmnoviaMp4RequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OmnoviaMp4RequestSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OmnoviaMp4RequestProvider.GetById(_id);
					results = new TList<OmnoviaMp4Request>();
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
			if ( SelectMethod == OmnoviaMp4RequestSelectMethod.Get || SelectMethod == OmnoviaMp4RequestSelectMethod.GetById )
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
				OmnoviaMp4Request entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OmnoviaMp4RequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OmnoviaMp4Request> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			OmnoviaMp4RequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OmnoviaMp4RequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OmnoviaMp4RequestDataSource class.
	/// </summary>
	public class OmnoviaMp4RequestDataSourceDesigner : ProviderDataSourceDesigner<OmnoviaMp4Request, OmnoviaMp4RequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestDataSourceDesigner class.
		/// </summary>
		public OmnoviaMp4RequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaMp4RequestSelectMethod SelectMethod
		{
			get { return ((OmnoviaMp4RequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OmnoviaMp4RequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OmnoviaMp4RequestDataSourceActionList

	/// <summary>
	/// Supports the OmnoviaMp4RequestDataSourceDesigner class.
	/// </summary>
	internal class OmnoviaMp4RequestDataSourceActionList : DesignerActionList
	{
		private OmnoviaMp4RequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OmnoviaMp4RequestDataSourceActionList(OmnoviaMp4RequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaMp4RequestSelectMethod SelectMethod
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

	#endregion OmnoviaMp4RequestDataSourceActionList
	
	#endregion OmnoviaMp4RequestDataSourceDesigner
	
	#region OmnoviaMp4RequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OmnoviaMp4RequestDataSource.SelectMethod property.
	/// </summary>
	public enum OmnoviaMp4RequestSelectMethod
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
	
	#endregion OmnoviaMp4RequestSelectMethod

	#region OmnoviaMp4RequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestFilter : SqlFilter<OmnoviaMp4RequestColumn>
	{
	}
	
	#endregion OmnoviaMp4RequestFilter

	#region OmnoviaMp4RequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestExpressionBuilder : SqlExpressionBuilder<OmnoviaMp4RequestColumn>
	{
	}
	
	#endregion OmnoviaMp4RequestExpressionBuilder	

	#region OmnoviaMp4RequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OmnoviaMp4RequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestProperty : ChildEntityProperty<OmnoviaMp4RequestChildEntityTypes>
	{
	}
	
	#endregion OmnoviaMp4RequestProperty
}

