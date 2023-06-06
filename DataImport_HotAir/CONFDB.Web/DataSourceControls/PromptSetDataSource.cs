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
	/// Represents the DataRepository.PromptSetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PromptSetDataSourceDesigner))]
	public class PromptSetDataSource : ProviderDataSource<PromptSet, PromptSetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PromptSetDataSource class.
		/// </summary>
		public PromptSetDataSource() : base(new PromptSetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PromptSetDataSourceView used by the PromptSetDataSource.
		/// </summary>
		protected PromptSetDataSourceView PromptSetView
		{
			get { return ( View as PromptSetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PromptSetDataSource control invokes to retrieve data.
		/// </summary>
		public PromptSetSelectMethod SelectMethod
		{
			get
			{
				PromptSetSelectMethod selectMethod = PromptSetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PromptSetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PromptSetDataSourceView class that is to be
		/// used by the PromptSetDataSource.
		/// </summary>
		/// <returns>An instance of the PromptSetDataSourceView class.</returns>
		protected override BaseDataSourceView<PromptSet, PromptSetKey> GetNewDataSourceView()
		{
			return new PromptSetDataSourceView(this, DefaultViewName);
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
	/// Supports the PromptSetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PromptSetDataSourceView : ProviderDataSourceView<PromptSet, PromptSetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PromptSetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PromptSetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PromptSetDataSourceView(PromptSetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PromptSetDataSource PromptSetOwner
		{
			get { return Owner as PromptSetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PromptSetSelectMethod SelectMethod
		{
			get { return PromptSetOwner.SelectMethod; }
			set { PromptSetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PromptSetService PromptSetProvider
		{
			get { return Provider as PromptSetService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PromptSet> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PromptSet> results = null;
			PromptSet item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case PromptSetSelectMethod.Get:
					PromptSetKey entityKey  = new PromptSetKey();
					entityKey.Load(values);
					item = PromptSetProvider.Get(entityKey);
					results = new TList<PromptSet>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PromptSetSelectMethod.GetAll:
                    results = PromptSetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PromptSetSelectMethod.GetPaged:
					results = PromptSetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PromptSetSelectMethod.Find:
					if ( FilterParameters != null )
						results = PromptSetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PromptSetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PromptSetSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = PromptSetProvider.GetById(_id);
					results = new TList<PromptSet>();
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
			if ( SelectMethod == PromptSetSelectMethod.Get || SelectMethod == PromptSetSelectMethod.GetById )
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
				PromptSet entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PromptSetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PromptSet> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PromptSetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PromptSetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PromptSetDataSource class.
	/// </summary>
	public class PromptSetDataSourceDesigner : ProviderDataSourceDesigner<PromptSet, PromptSetKey>
	{
		/// <summary>
		/// Initializes a new instance of the PromptSetDataSourceDesigner class.
		/// </summary>
		public PromptSetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PromptSetSelectMethod SelectMethod
		{
			get { return ((PromptSetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PromptSetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PromptSetDataSourceActionList

	/// <summary>
	/// Supports the PromptSetDataSourceDesigner class.
	/// </summary>
	internal class PromptSetDataSourceActionList : DesignerActionList
	{
		private PromptSetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PromptSetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PromptSetDataSourceActionList(PromptSetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PromptSetSelectMethod SelectMethod
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

	#endregion PromptSetDataSourceActionList
	
	#endregion PromptSetDataSourceDesigner
	
	#region PromptSetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PromptSetDataSource.SelectMethod property.
	/// </summary>
	public enum PromptSetSelectMethod
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
	
	#endregion PromptSetSelectMethod

	#region PromptSetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PromptSet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PromptSetFilter : SqlFilter<PromptSetColumn>
	{
	}
	
	#endregion PromptSetFilter

	#region PromptSetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PromptSet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PromptSetExpressionBuilder : SqlExpressionBuilder<PromptSetColumn>
	{
	}
	
	#endregion PromptSetExpressionBuilder	

	#region PromptSetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PromptSetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PromptSet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PromptSetProperty : ChildEntityProperty<PromptSetChildEntityTypes>
	{
	}
	
	#endregion PromptSetProperty
}

