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
	/// Represents the DataRepository.ForExProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ForExDataSourceDesigner))]
	public class ForExDataSource : ProviderDataSource<ForEx, ForExKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExDataSource class.
		/// </summary>
		public ForExDataSource() : base(new ForExService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ForExDataSourceView used by the ForExDataSource.
		/// </summary>
		protected ForExDataSourceView ForExView
		{
			get { return ( View as ForExDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ForExDataSource control invokes to retrieve data.
		/// </summary>
		public ForExSelectMethod SelectMethod
		{
			get
			{
				ForExSelectMethod selectMethod = ForExSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ForExSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ForExDataSourceView class that is to be
		/// used by the ForExDataSource.
		/// </summary>
		/// <returns>An instance of the ForExDataSourceView class.</returns>
		protected override BaseDataSourceView<ForEx, ForExKey> GetNewDataSourceView()
		{
			return new ForExDataSourceView(this, DefaultViewName);
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
	/// Supports the ForExDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ForExDataSourceView : ProviderDataSourceView<ForEx, ForExKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ForExDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ForExDataSourceView(ForExDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ForExDataSource ForExOwner
		{
			get { return Owner as ForExDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ForExSelectMethod SelectMethod
		{
			get { return ForExOwner.SelectMethod; }
			set { ForExOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ForExService ForExProvider
		{
			get { return Provider as ForExService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ForEx> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ForEx> results = null;
			ForEx item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _curveId;

			switch ( SelectMethod )
			{
				case ForExSelectMethod.Get:
					ForExKey entityKey  = new ForExKey();
					entityKey.Load(values);
					item = ForExProvider.Get(entityKey);
					results = new TList<ForEx>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ForExSelectMethod.GetAll:
                    results = ForExProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ForExSelectMethod.GetPaged:
					results = ForExProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ForExSelectMethod.Find:
					if ( FilterParameters != null )
						results = ForExProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ForExProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ForExSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ForExProvider.GetById(_id);
					results = new TList<ForEx>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ForExSelectMethod.GetByCurveId:
					_curveId = ( values["CurveId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurveId"], typeof(System.Int32)) : (int)0;
					results = ForExProvider.GetByCurveId(_curveId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ForExSelectMethod.Get || SelectMethod == ForExSelectMethod.GetById )
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
				ForEx entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ForExProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ForEx> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ForExProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ForExDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ForExDataSource class.
	/// </summary>
	public class ForExDataSourceDesigner : ProviderDataSourceDesigner<ForEx, ForExKey>
	{
		/// <summary>
		/// Initializes a new instance of the ForExDataSourceDesigner class.
		/// </summary>
		public ForExDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ForExSelectMethod SelectMethod
		{
			get { return ((ForExDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ForExDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ForExDataSourceActionList

	/// <summary>
	/// Supports the ForExDataSourceDesigner class.
	/// </summary>
	internal class ForExDataSourceActionList : DesignerActionList
	{
		private ForExDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ForExDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ForExDataSourceActionList(ForExDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ForExSelectMethod SelectMethod
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

	#endregion ForExDataSourceActionList
	
	#endregion ForExDataSourceDesigner
	
	#region ForExSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ForExDataSource.SelectMethod property.
	/// </summary>
	public enum ForExSelectMethod
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
		/// Represents the GetByCurveId method.
		/// </summary>
		GetByCurveId
	}
	
	#endregion ForExSelectMethod

	#region ForExFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExFilter : SqlFilter<ForExColumn>
	{
	}
	
	#endregion ForExFilter

	#region ForExExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExExpressionBuilder : SqlExpressionBuilder<ForExColumn>
	{
	}
	
	#endregion ForExExpressionBuilder	

	#region ForExProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ForExChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExProperty : ChildEntityProperty<ForExChildEntityTypes>
	{
	}
	
	#endregion ForExProperty
}

