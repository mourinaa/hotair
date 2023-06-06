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
	/// Represents the DataRepository.FeatureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FeatureDataSourceDesigner))]
	public class FeatureDataSource : ProviderDataSource<Feature, FeatureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureDataSource class.
		/// </summary>
		public FeatureDataSource() : base(new FeatureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FeatureDataSourceView used by the FeatureDataSource.
		/// </summary>
		protected FeatureDataSourceView FeatureView
		{
			get { return ( View as FeatureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FeatureDataSource control invokes to retrieve data.
		/// </summary>
		public FeatureSelectMethod SelectMethod
		{
			get
			{
				FeatureSelectMethod selectMethod = FeatureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FeatureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FeatureDataSourceView class that is to be
		/// used by the FeatureDataSource.
		/// </summary>
		/// <returns>An instance of the FeatureDataSourceView class.</returns>
		protected override BaseDataSourceView<Feature, FeatureKey> GetNewDataSourceView()
		{
			return new FeatureDataSourceView(this, DefaultViewName);
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
	/// Supports the FeatureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FeatureDataSourceView : ProviderDataSourceView<Feature, FeatureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FeatureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FeatureDataSourceView(FeatureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FeatureDataSource FeatureOwner
		{
			get { return Owner as FeatureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FeatureSelectMethod SelectMethod
		{
			get { return FeatureOwner.SelectMethod; }
			set { FeatureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FeatureService FeatureProvider
		{
			get { return Provider as FeatureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Feature> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Feature> results = null;
			Feature item;
			count = 0;
			
			System.Int32 _id;
			System.String _name;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case FeatureSelectMethod.Get:
					FeatureKey entityKey  = new FeatureKey();
					entityKey.Load(values);
					item = FeatureProvider.Get(entityKey);
					results = new TList<Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FeatureSelectMethod.GetAll:
                    results = FeatureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FeatureSelectMethod.GetPaged:
					results = FeatureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FeatureSelectMethod.Find:
					if ( FilterParameters != null )
						results = FeatureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FeatureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FeatureSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = FeatureProvider.GetById(_id);
					results = new TList<Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case FeatureSelectMethod.GetByNameId:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					results = FeatureProvider.GetByNameId(_name, _id, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case FeatureSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = FeatureProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == FeatureSelectMethod.Get || SelectMethod == FeatureSelectMethod.GetById )
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
				Feature entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FeatureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Feature> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FeatureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FeatureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FeatureDataSource class.
	/// </summary>
	public class FeatureDataSourceDesigner : ProviderDataSourceDesigner<Feature, FeatureKey>
	{
		/// <summary>
		/// Initializes a new instance of the FeatureDataSourceDesigner class.
		/// </summary>
		public FeatureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureSelectMethod SelectMethod
		{
			get { return ((FeatureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FeatureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FeatureDataSourceActionList

	/// <summary>
	/// Supports the FeatureDataSourceDesigner class.
	/// </summary>
	internal class FeatureDataSourceActionList : DesignerActionList
	{
		private FeatureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FeatureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FeatureDataSourceActionList(FeatureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FeatureSelectMethod SelectMethod
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

	#endregion FeatureDataSourceActionList
	
	#endregion FeatureDataSourceDesigner
	
	#region FeatureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FeatureDataSource.SelectMethod property.
	/// </summary>
	public enum FeatureSelectMethod
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
		/// Represents the GetByNameId method.
		/// </summary>
		GetByNameId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId
	}
	
	#endregion FeatureSelectMethod

	#region FeatureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureFilter : SqlFilter<FeatureColumn>
	{
	}
	
	#endregion FeatureFilter

	#region FeatureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureExpressionBuilder : SqlExpressionBuilder<FeatureColumn>
	{
	}
	
	#endregion FeatureExpressionBuilder	

	#region FeatureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FeatureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureProperty : ChildEntityProperty<FeatureChildEntityTypes>
	{
	}
	
	#endregion FeatureProperty
}

