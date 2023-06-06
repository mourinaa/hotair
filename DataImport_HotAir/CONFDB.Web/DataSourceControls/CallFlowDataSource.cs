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
	/// Represents the DataRepository.CallFlowProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CallFlowDataSourceDesigner))]
	public class CallFlowDataSource : ProviderDataSource<CallFlow, CallFlowKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CallFlowDataSource class.
		/// </summary>
		public CallFlowDataSource() : base(new CallFlowService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CallFlowDataSourceView used by the CallFlowDataSource.
		/// </summary>
		protected CallFlowDataSourceView CallFlowView
		{
			get { return ( View as CallFlowDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CallFlowDataSource control invokes to retrieve data.
		/// </summary>
		public CallFlowSelectMethod SelectMethod
		{
			get
			{
				CallFlowSelectMethod selectMethod = CallFlowSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CallFlowSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CallFlowDataSourceView class that is to be
		/// used by the CallFlowDataSource.
		/// </summary>
		/// <returns>An instance of the CallFlowDataSourceView class.</returns>
		protected override BaseDataSourceView<CallFlow, CallFlowKey> GetNewDataSourceView()
		{
			return new CallFlowDataSourceView(this, DefaultViewName);
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
	/// Supports the CallFlowDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CallFlowDataSourceView : ProviderDataSourceView<CallFlow, CallFlowKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CallFlowDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CallFlowDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CallFlowDataSourceView(CallFlowDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CallFlowDataSource CallFlowOwner
		{
			get { return Owner as CallFlowDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CallFlowSelectMethod SelectMethod
		{
			get { return CallFlowOwner.SelectMethod; }
			set { CallFlowOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CallFlowService CallFlowProvider
		{
			get { return Provider as CallFlowService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CallFlow> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CallFlow> results = null;
			CallFlow item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case CallFlowSelectMethod.Get:
					CallFlowKey entityKey  = new CallFlowKey();
					entityKey.Load(values);
					item = CallFlowProvider.Get(entityKey);
					results = new TList<CallFlow>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CallFlowSelectMethod.GetAll:
                    results = CallFlowProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CallFlowSelectMethod.GetPaged:
					results = CallFlowProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CallFlowSelectMethod.Find:
					if ( FilterParameters != null )
						results = CallFlowProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CallFlowProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CallFlowSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CallFlowProvider.GetById(_id);
					results = new TList<CallFlow>();
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
			if ( SelectMethod == CallFlowSelectMethod.Get || SelectMethod == CallFlowSelectMethod.GetById )
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
				CallFlow entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CallFlowProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CallFlow> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CallFlowProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CallFlowDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CallFlowDataSource class.
	/// </summary>
	public class CallFlowDataSourceDesigner : ProviderDataSourceDesigner<CallFlow, CallFlowKey>
	{
		/// <summary>
		/// Initializes a new instance of the CallFlowDataSourceDesigner class.
		/// </summary>
		public CallFlowDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CallFlowSelectMethod SelectMethod
		{
			get { return ((CallFlowDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CallFlowDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CallFlowDataSourceActionList

	/// <summary>
	/// Supports the CallFlowDataSourceDesigner class.
	/// </summary>
	internal class CallFlowDataSourceActionList : DesignerActionList
	{
		private CallFlowDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CallFlowDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CallFlowDataSourceActionList(CallFlowDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CallFlowSelectMethod SelectMethod
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

	#endregion CallFlowDataSourceActionList
	
	#endregion CallFlowDataSourceDesigner
	
	#region CallFlowSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CallFlowDataSource.SelectMethod property.
	/// </summary>
	public enum CallFlowSelectMethod
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
	
	#endregion CallFlowSelectMethod

	#region CallFlowFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CallFlow"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CallFlowFilter : SqlFilter<CallFlowColumn>
	{
	}
	
	#endregion CallFlowFilter

	#region CallFlowExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CallFlow"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CallFlowExpressionBuilder : SqlExpressionBuilder<CallFlowColumn>
	{
	}
	
	#endregion CallFlowExpressionBuilder	

	#region CallFlowProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CallFlowChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CallFlow"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CallFlowProperty : ChildEntityProperty<CallFlowChildEntityTypes>
	{
	}
	
	#endregion CallFlowProperty
}

