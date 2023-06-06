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
	/// Represents the DataRepository.OmnoviaHostedArchiveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OmnoviaHostedArchiveDataSourceDesigner))]
	public class OmnoviaHostedArchiveDataSource : ProviderDataSource<OmnoviaHostedArchive, OmnoviaHostedArchiveKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveDataSource class.
		/// </summary>
		public OmnoviaHostedArchiveDataSource() : base(new OmnoviaHostedArchiveService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OmnoviaHostedArchiveDataSourceView used by the OmnoviaHostedArchiveDataSource.
		/// </summary>
		protected OmnoviaHostedArchiveDataSourceView OmnoviaHostedArchiveView
		{
			get { return ( View as OmnoviaHostedArchiveDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OmnoviaHostedArchiveDataSource control invokes to retrieve data.
		/// </summary>
		public OmnoviaHostedArchiveSelectMethod SelectMethod
		{
			get
			{
				OmnoviaHostedArchiveSelectMethod selectMethod = OmnoviaHostedArchiveSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OmnoviaHostedArchiveSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OmnoviaHostedArchiveDataSourceView class that is to be
		/// used by the OmnoviaHostedArchiveDataSource.
		/// </summary>
		/// <returns>An instance of the OmnoviaHostedArchiveDataSourceView class.</returns>
		protected override BaseDataSourceView<OmnoviaHostedArchive, OmnoviaHostedArchiveKey> GetNewDataSourceView()
		{
			return new OmnoviaHostedArchiveDataSourceView(this, DefaultViewName);
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
	/// Supports the OmnoviaHostedArchiveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OmnoviaHostedArchiveDataSourceView : ProviderDataSourceView<OmnoviaHostedArchive, OmnoviaHostedArchiveKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OmnoviaHostedArchiveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OmnoviaHostedArchiveDataSourceView(OmnoviaHostedArchiveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OmnoviaHostedArchiveDataSource OmnoviaHostedArchiveOwner
		{
			get { return Owner as OmnoviaHostedArchiveDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OmnoviaHostedArchiveSelectMethod SelectMethod
		{
			get { return OmnoviaHostedArchiveOwner.SelectMethod; }
			set { OmnoviaHostedArchiveOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OmnoviaHostedArchiveService OmnoviaHostedArchiveProvider
		{
			get { return Provider as OmnoviaHostedArchiveService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OmnoviaHostedArchive> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OmnoviaHostedArchive> results = null;
			OmnoviaHostedArchive item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case OmnoviaHostedArchiveSelectMethod.Get:
					OmnoviaHostedArchiveKey entityKey  = new OmnoviaHostedArchiveKey();
					entityKey.Load(values);
					item = OmnoviaHostedArchiveProvider.Get(entityKey);
					results = new TList<OmnoviaHostedArchive>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OmnoviaHostedArchiveSelectMethod.GetAll:
                    results = OmnoviaHostedArchiveProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OmnoviaHostedArchiveSelectMethod.GetPaged:
					results = OmnoviaHostedArchiveProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OmnoviaHostedArchiveSelectMethod.Find:
					if ( FilterParameters != null )
						results = OmnoviaHostedArchiveProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OmnoviaHostedArchiveProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OmnoviaHostedArchiveSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OmnoviaHostedArchiveProvider.GetById(_id);
					results = new TList<OmnoviaHostedArchive>();
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
			if ( SelectMethod == OmnoviaHostedArchiveSelectMethod.Get || SelectMethod == OmnoviaHostedArchiveSelectMethod.GetById )
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
				OmnoviaHostedArchive entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OmnoviaHostedArchiveProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OmnoviaHostedArchive> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			OmnoviaHostedArchiveProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OmnoviaHostedArchiveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OmnoviaHostedArchiveDataSource class.
	/// </summary>
	public class OmnoviaHostedArchiveDataSourceDesigner : ProviderDataSourceDesigner<OmnoviaHostedArchive, OmnoviaHostedArchiveKey>
	{
		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveDataSourceDesigner class.
		/// </summary>
		public OmnoviaHostedArchiveDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaHostedArchiveSelectMethod SelectMethod
		{
			get { return ((OmnoviaHostedArchiveDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OmnoviaHostedArchiveDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OmnoviaHostedArchiveDataSourceActionList

	/// <summary>
	/// Supports the OmnoviaHostedArchiveDataSourceDesigner class.
	/// </summary>
	internal class OmnoviaHostedArchiveDataSourceActionList : DesignerActionList
	{
		private OmnoviaHostedArchiveDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OmnoviaHostedArchiveDataSourceActionList(OmnoviaHostedArchiveDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaHostedArchiveSelectMethod SelectMethod
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

	#endregion OmnoviaHostedArchiveDataSourceActionList
	
	#endregion OmnoviaHostedArchiveDataSourceDesigner
	
	#region OmnoviaHostedArchiveSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OmnoviaHostedArchiveDataSource.SelectMethod property.
	/// </summary>
	public enum OmnoviaHostedArchiveSelectMethod
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
	
	#endregion OmnoviaHostedArchiveSelectMethod

	#region OmnoviaHostedArchiveFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveFilter : SqlFilter<OmnoviaHostedArchiveColumn>
	{
	}
	
	#endregion OmnoviaHostedArchiveFilter

	#region OmnoviaHostedArchiveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveExpressionBuilder : SqlExpressionBuilder<OmnoviaHostedArchiveColumn>
	{
	}
	
	#endregion OmnoviaHostedArchiveExpressionBuilder	

	#region OmnoviaHostedArchiveProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OmnoviaHostedArchiveChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveProperty : ChildEntityProperty<OmnoviaHostedArchiveChildEntityTypes>
	{
	}
	
	#endregion OmnoviaHostedArchiveProperty
}

