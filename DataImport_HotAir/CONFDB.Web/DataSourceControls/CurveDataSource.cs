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
	/// Represents the DataRepository.CurveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CurveDataSourceDesigner))]
	public class CurveDataSource : ProviderDataSource<Curve, CurveKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurveDataSource class.
		/// </summary>
		public CurveDataSource() : base(new CurveService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CurveDataSourceView used by the CurveDataSource.
		/// </summary>
		protected CurveDataSourceView CurveView
		{
			get { return ( View as CurveDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CurveDataSource control invokes to retrieve data.
		/// </summary>
		public CurveSelectMethod SelectMethod
		{
			get
			{
				CurveSelectMethod selectMethod = CurveSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CurveSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CurveDataSourceView class that is to be
		/// used by the CurveDataSource.
		/// </summary>
		/// <returns>An instance of the CurveDataSourceView class.</returns>
		protected override BaseDataSourceView<Curve, CurveKey> GetNewDataSourceView()
		{
			return new CurveDataSourceView(this, DefaultViewName);
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
	/// Supports the CurveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CurveDataSourceView : ProviderDataSourceView<Curve, CurveKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CurveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CurveDataSourceView(CurveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CurveDataSource CurveOwner
		{
			get { return Owner as CurveDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CurveSelectMethod SelectMethod
		{
			get { return CurveOwner.SelectMethod; }
			set { CurveOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CurveService CurveProvider
		{
			get { return Provider as CurveService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Curve> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Curve> results = null;
			Curve item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case CurveSelectMethod.Get:
					CurveKey entityKey  = new CurveKey();
					entityKey.Load(values);
					item = CurveProvider.Get(entityKey);
					results = new TList<Curve>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CurveSelectMethod.GetAll:
                    results = CurveProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CurveSelectMethod.GetPaged:
					results = CurveProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CurveSelectMethod.Find:
					if ( FilterParameters != null )
						results = CurveProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CurveProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CurveSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CurveProvider.GetById(_id);
					results = new TList<Curve>();
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
			if ( SelectMethod == CurveSelectMethod.Get || SelectMethod == CurveSelectMethod.GetById )
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
				Curve entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CurveProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Curve> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CurveProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CurveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CurveDataSource class.
	/// </summary>
	public class CurveDataSourceDesigner : ProviderDataSourceDesigner<Curve, CurveKey>
	{
		/// <summary>
		/// Initializes a new instance of the CurveDataSourceDesigner class.
		/// </summary>
		public CurveDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurveSelectMethod SelectMethod
		{
			get { return ((CurveDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CurveDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CurveDataSourceActionList

	/// <summary>
	/// Supports the CurveDataSourceDesigner class.
	/// </summary>
	internal class CurveDataSourceActionList : DesignerActionList
	{
		private CurveDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CurveDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CurveDataSourceActionList(CurveDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CurveSelectMethod SelectMethod
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

	#endregion CurveDataSourceActionList
	
	#endregion CurveDataSourceDesigner
	
	#region CurveSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CurveDataSource.SelectMethod property.
	/// </summary>
	public enum CurveSelectMethod
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
	
	#endregion CurveSelectMethod

	#region CurveFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Curve"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurveFilter : SqlFilter<CurveColumn>
	{
	}
	
	#endregion CurveFilter

	#region CurveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Curve"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurveExpressionBuilder : SqlExpressionBuilder<CurveColumn>
	{
	}
	
	#endregion CurveExpressionBuilder	

	#region CurveProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CurveChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Curve"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurveProperty : ChildEntityProperty<CurveChildEntityTypes>
	{
	}
	
	#endregion CurveProperty
}

