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
	/// Represents the DataRepository.Wholesaler_Product_FeatureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Wholesaler_Product_FeatureDataSourceDesigner))]
	public class Wholesaler_Product_FeatureDataSource : ProviderDataSource<Wholesaler_Product_Feature, Wholesaler_Product_FeatureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureDataSource class.
		/// </summary>
		public Wholesaler_Product_FeatureDataSource() : base(new Wholesaler_Product_FeatureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Wholesaler_Product_FeatureDataSourceView used by the Wholesaler_Product_FeatureDataSource.
		/// </summary>
		protected Wholesaler_Product_FeatureDataSourceView Wholesaler_Product_FeatureView
		{
			get { return ( View as Wholesaler_Product_FeatureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Wholesaler_Product_FeatureDataSource control invokes to retrieve data.
		/// </summary>
		public Wholesaler_Product_FeatureSelectMethod SelectMethod
		{
			get
			{
				Wholesaler_Product_FeatureSelectMethod selectMethod = Wholesaler_Product_FeatureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Wholesaler_Product_FeatureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Wholesaler_Product_FeatureDataSourceView class that is to be
		/// used by the Wholesaler_Product_FeatureDataSource.
		/// </summary>
		/// <returns>An instance of the Wholesaler_Product_FeatureDataSourceView class.</returns>
		protected override BaseDataSourceView<Wholesaler_Product_Feature, Wholesaler_Product_FeatureKey> GetNewDataSourceView()
		{
			return new Wholesaler_Product_FeatureDataSourceView(this, DefaultViewName);
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
	/// Supports the Wholesaler_Product_FeatureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Wholesaler_Product_FeatureDataSourceView : ProviderDataSourceView<Wholesaler_Product_Feature, Wholesaler_Product_FeatureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Wholesaler_Product_FeatureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Wholesaler_Product_FeatureDataSourceView(Wholesaler_Product_FeatureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Wholesaler_Product_FeatureDataSource Wholesaler_Product_FeatureOwner
		{
			get { return Owner as Wholesaler_Product_FeatureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Wholesaler_Product_FeatureSelectMethod SelectMethod
		{
			get { return Wholesaler_Product_FeatureOwner.SelectMethod; }
			set { Wholesaler_Product_FeatureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Wholesaler_Product_FeatureService Wholesaler_Product_FeatureProvider
		{
			get { return Provider as Wholesaler_Product_FeatureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Wholesaler_Product_Feature> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Wholesaler_Product_Feature> results = null;
			Wholesaler_Product_Feature item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _featureId;
			System.Int32 _featureOptionId;
			System.Int32 _wholesaler_ProductId;

			switch ( SelectMethod )
			{
				case Wholesaler_Product_FeatureSelectMethod.Get:
					Wholesaler_Product_FeatureKey entityKey  = new Wholesaler_Product_FeatureKey();
					entityKey.Load(values);
					item = Wholesaler_Product_FeatureProvider.Get(entityKey);
					results = new TList<Wholesaler_Product_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Wholesaler_Product_FeatureSelectMethod.GetAll:
                    results = Wholesaler_Product_FeatureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Wholesaler_Product_FeatureSelectMethod.GetPaged:
					results = Wholesaler_Product_FeatureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Wholesaler_Product_FeatureSelectMethod.Find:
					if ( FilterParameters != null )
						results = Wholesaler_Product_FeatureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Wholesaler_Product_FeatureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Wholesaler_Product_FeatureSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = Wholesaler_Product_FeatureProvider.GetById(_id);
					results = new TList<Wholesaler_Product_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case Wholesaler_Product_FeatureSelectMethod.GetByFeatureId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					results = Wholesaler_Product_FeatureProvider.GetByFeatureId(_featureId, this.StartIndex, this.PageSize, out count);
					break;
				case Wholesaler_Product_FeatureSelectMethod.GetByFeatureOptionId:
					_featureOptionId = ( values["FeatureOptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureOptionId"], typeof(System.Int32)) : (int)0;
					results = Wholesaler_Product_FeatureProvider.GetByFeatureOptionId(_featureOptionId, this.StartIndex, this.PageSize, out count);
					break;
				case Wholesaler_Product_FeatureSelectMethod.GetByWholesaler_ProductId:
					_wholesaler_ProductId = ( values["Wholesaler_ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Wholesaler_ProductId"], typeof(System.Int32)) : (int)0;
					results = Wholesaler_Product_FeatureProvider.GetByWholesaler_ProductId(_wholesaler_ProductId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == Wholesaler_Product_FeatureSelectMethod.Get || SelectMethod == Wholesaler_Product_FeatureSelectMethod.GetById )
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
				Wholesaler_Product_Feature entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Wholesaler_Product_FeatureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Wholesaler_Product_Feature> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Wholesaler_Product_FeatureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Wholesaler_Product_FeatureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Wholesaler_Product_FeatureDataSource class.
	/// </summary>
	public class Wholesaler_Product_FeatureDataSourceDesigner : ProviderDataSourceDesigner<Wholesaler_Product_Feature, Wholesaler_Product_FeatureKey>
	{
		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureDataSourceDesigner class.
		/// </summary>
		public Wholesaler_Product_FeatureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Wholesaler_Product_FeatureSelectMethod SelectMethod
		{
			get { return ((Wholesaler_Product_FeatureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Wholesaler_Product_FeatureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Wholesaler_Product_FeatureDataSourceActionList

	/// <summary>
	/// Supports the Wholesaler_Product_FeatureDataSourceDesigner class.
	/// </summary>
	internal class Wholesaler_Product_FeatureDataSourceActionList : DesignerActionList
	{
		private Wholesaler_Product_FeatureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Wholesaler_Product_FeatureDataSourceActionList(Wholesaler_Product_FeatureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Wholesaler_Product_FeatureSelectMethod SelectMethod
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

	#endregion Wholesaler_Product_FeatureDataSourceActionList
	
	#endregion Wholesaler_Product_FeatureDataSourceDesigner
	
	#region Wholesaler_Product_FeatureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Wholesaler_Product_FeatureDataSource.SelectMethod property.
	/// </summary>
	public enum Wholesaler_Product_FeatureSelectMethod
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
		/// Represents the GetByFeatureId method.
		/// </summary>
		GetByFeatureId,
		/// <summary>
		/// Represents the GetByFeatureOptionId method.
		/// </summary>
		GetByFeatureOptionId,
		/// <summary>
		/// Represents the GetByWholesaler_ProductId method.
		/// </summary>
		GetByWholesaler_ProductId
	}
	
	#endregion Wholesaler_Product_FeatureSelectMethod

	#region Wholesaler_Product_FeatureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_Product_FeatureFilter : SqlFilter<Wholesaler_Product_FeatureColumn>
	{
	}
	
	#endregion Wholesaler_Product_FeatureFilter

	#region Wholesaler_Product_FeatureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_Product_FeatureExpressionBuilder : SqlExpressionBuilder<Wholesaler_Product_FeatureColumn>
	{
	}
	
	#endregion Wholesaler_Product_FeatureExpressionBuilder	

	#region Wholesaler_Product_FeatureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Wholesaler_Product_FeatureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_Product_FeatureProperty : ChildEntityProperty<Wholesaler_Product_FeatureChildEntityTypes>
	{
	}
	
	#endregion Wholesaler_Product_FeatureProperty
}

