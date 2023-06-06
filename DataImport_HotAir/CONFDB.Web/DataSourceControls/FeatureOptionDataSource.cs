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
	/// Represents the DataRepository.FeatureOptionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FeatureOptionDataSourceDesigner))]
	public class FeatureOptionDataSource : ProviderDataSource<FeatureOption, FeatureOptionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionDataSource class.
		/// </summary>
		public FeatureOptionDataSource() : base(new FeatureOptionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FeatureOptionDataSourceView used by the FeatureOptionDataSource.
		/// </summary>
		protected FeatureOptionDataSourceView FeatureOptionView
		{
			get { return ( View as FeatureOptionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FeatureOptionDataSource control invokes to retrieve data.
		/// </summary>
		public FeatureOptionSelectMethod SelectMethod
		{
			get
			{
				FeatureOptionSelectMethod selectMethod = FeatureOptionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FeatureOptionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FeatureOptionDataSourceView class that is to be
		/// used by the FeatureOptionDataSource.
		/// </summary>
		/// <returns>An instance of the FeatureOptionDataSourceView class.</returns>
		protected override BaseDataSourceView<FeatureOption, FeatureOptionKey> GetNewDataSourceView()
		{
			return new FeatureOptionDataSourceView(this, DefaultViewName);
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
	/// Supports the FeatureOptionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FeatureOptionDataSourceView : ProviderDataSourceView<FeatureOption, FeatureOptionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FeatureOptionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FeatureOptionDataSourceView(FeatureOptionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FeatureOptionDataSource FeatureOptionOwner
		{
			get { return Owner as FeatureOptionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FeatureOptionSelectMethod SelectMethod
		{
			get { return FeatureOptionOwner.SelectMethod; }
			set { FeatureOptionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FeatureOptionService FeatureOptionProvider
		{
			get { return Provider as FeatureOptionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<FeatureOption> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<FeatureOption> results = null;
			FeatureOption item;
			count = 0;
			
			System.Int32 _id;
			System.String _name_nullable;
			System.Int32 _featureId;
			System.Int32? _featureOptionTypeId_nullable;

			switch ( SelectMethod )
			{
				case FeatureOptionSelectMethod.Get:
					FeatureOptionKey entityKey  = new FeatureOptionKey();
					entityKey.Load(values);
					item = FeatureOptionProvider.Get(entityKey);
					results = new TList<FeatureOption>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FeatureOptionSelectMethod.GetAll:
                    results = FeatureOptionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FeatureOptionSelectMethod.GetPaged:
					results = FeatureOptionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FeatureOptionSelectMethod.Find:
					if ( FilterParameters != null )
						results = FeatureOptionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FeatureOptionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FeatureOptionSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = FeatureOptionProvider.GetById(_id);
					results = new TList<FeatureOption>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case FeatureOptionSelectMethod.GetByNameFeatureIdId:
					_name_nullable = (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String));
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					results = FeatureOptionProvider.GetByNameFeatureIdId(_name_nullable, _featureId, _id, this.StartIndex, this.PageSize, out count);
					break;
				case FeatureOptionSelectMethod.GetByFeatureId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					results = FeatureOptionProvider.GetByFeatureId(_featureId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case FeatureOptionSelectMethod.GetByFeatureOptionTypeId:
					_featureOptionTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["FeatureOptionTypeId"], typeof(System.Int32?));
					results = FeatureOptionProvider.GetByFeatureOptionTypeId(_featureOptionTypeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == FeatureOptionSelectMethod.Get || SelectMethod == FeatureOptionSelectMethod.GetById )
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
				FeatureOption entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FeatureOptionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<FeatureOption> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FeatureOptionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FeatureOptionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FeatureOptionDataSource class.
	/// </summary>
	public class FeatureOptionDataSourceDesigner : ProviderDataSourceDesigner<FeatureOption, FeatureOptionKey>
	{
		/// <summary>
		/// Initializes a new instance of the FeatureOptionDataSourceDesigner class.
		/// </summary>
		public FeatureOptionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureOptionSelectMethod SelectMethod
		{
			get { return ((FeatureOptionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FeatureOptionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FeatureOptionDataSourceActionList

	/// <summary>
	/// Supports the FeatureOptionDataSourceDesigner class.
	/// </summary>
	internal class FeatureOptionDataSourceActionList : DesignerActionList
	{
		private FeatureOptionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FeatureOptionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FeatureOptionDataSourceActionList(FeatureOptionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureOptionSelectMethod SelectMethod
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

	#endregion FeatureOptionDataSourceActionList
	
	#endregion FeatureOptionDataSourceDesigner
	
	#region FeatureOptionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FeatureOptionDataSource.SelectMethod property.
	/// </summary>
	public enum FeatureOptionSelectMethod
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
		/// Represents the GetByNameFeatureIdId method.
		/// </summary>
		GetByNameFeatureIdId,
		/// <summary>
		/// Represents the GetByFeatureId method.
		/// </summary>
		GetByFeatureId,
		/// <summary>
		/// Represents the GetByFeatureOptionTypeId method.
		/// </summary>
		GetByFeatureOptionTypeId
	}
	
	#endregion FeatureOptionSelectMethod

	#region FeatureOptionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionFilter : SqlFilter<FeatureOptionColumn>
	{
	}
	
	#endregion FeatureOptionFilter

	#region FeatureOptionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionExpressionBuilder : SqlExpressionBuilder<FeatureOptionColumn>
	{
	}
	
	#endregion FeatureOptionExpressionBuilder	

	#region FeatureOptionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FeatureOptionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionProperty : ChildEntityProperty<FeatureOptionChildEntityTypes>
	{
	}
	
	#endregion FeatureOptionProperty
}

