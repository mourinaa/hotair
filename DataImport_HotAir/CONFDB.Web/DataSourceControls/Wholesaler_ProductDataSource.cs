﻿#region Using Directives
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
	/// Represents the DataRepository.Wholesaler_ProductProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Wholesaler_ProductDataSourceDesigner))]
	public class Wholesaler_ProductDataSource : ProviderDataSource<Wholesaler_Product, Wholesaler_ProductKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductDataSource class.
		/// </summary>
		public Wholesaler_ProductDataSource() : base(new Wholesaler_ProductService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Wholesaler_ProductDataSourceView used by the Wholesaler_ProductDataSource.
		/// </summary>
		protected Wholesaler_ProductDataSourceView Wholesaler_ProductView
		{
			get { return ( View as Wholesaler_ProductDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Wholesaler_ProductDataSource control invokes to retrieve data.
		/// </summary>
		public Wholesaler_ProductSelectMethod SelectMethod
		{
			get
			{
				Wholesaler_ProductSelectMethod selectMethod = Wholesaler_ProductSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Wholesaler_ProductSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Wholesaler_ProductDataSourceView class that is to be
		/// used by the Wholesaler_ProductDataSource.
		/// </summary>
		/// <returns>An instance of the Wholesaler_ProductDataSourceView class.</returns>
		protected override BaseDataSourceView<Wholesaler_Product, Wholesaler_ProductKey> GetNewDataSourceView()
		{
			return new Wholesaler_ProductDataSourceView(this, DefaultViewName);
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
	/// Supports the Wholesaler_ProductDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Wholesaler_ProductDataSourceView : ProviderDataSourceView<Wholesaler_Product, Wholesaler_ProductKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Wholesaler_ProductDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Wholesaler_ProductDataSourceView(Wholesaler_ProductDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Wholesaler_ProductDataSource Wholesaler_ProductOwner
		{
			get { return Owner as Wholesaler_ProductDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Wholesaler_ProductSelectMethod SelectMethod
		{
			get { return Wholesaler_ProductOwner.SelectMethod; }
			set { Wholesaler_ProductOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Wholesaler_ProductService Wholesaler_ProductProvider
		{
			get { return Provider as Wholesaler_ProductService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Wholesaler_Product> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Wholesaler_Product> results = null;
			Wholesaler_Product item;
			count = 0;
			
			System.Int32 _id;
			System.String _wholesalerId;
			System.Int32 _productId;

			switch ( SelectMethod )
			{
				case Wholesaler_ProductSelectMethod.Get:
					Wholesaler_ProductKey entityKey  = new Wholesaler_ProductKey();
					entityKey.Load(values);
					item = Wholesaler_ProductProvider.Get(entityKey);
					results = new TList<Wholesaler_Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Wholesaler_ProductSelectMethod.GetAll:
                    results = Wholesaler_ProductProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Wholesaler_ProductSelectMethod.GetPaged:
					results = Wholesaler_ProductProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Wholesaler_ProductSelectMethod.Find:
					if ( FilterParameters != null )
						results = Wholesaler_ProductProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Wholesaler_ProductProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Wholesaler_ProductSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = Wholesaler_ProductProvider.GetById(_id);
					results = new TList<Wholesaler_Product>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case Wholesaler_ProductSelectMethod.GetByWholesalerIdProductId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = Wholesaler_ProductProvider.GetByWholesalerIdProductId(_wholesalerId, _productId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case Wholesaler_ProductSelectMethod.GetByProductId:
					_productId = ( values["ProductId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductId"], typeof(System.Int32)) : (int)0;
					results = Wholesaler_ProductProvider.GetByProductId(_productId, this.StartIndex, this.PageSize, out count);
					break;
				case Wholesaler_ProductSelectMethod.GetByWholesalerId:
					_wholesalerId = ( values["WholesalerId"] != null ) ? (System.String) EntityUtil.ChangeType(values["WholesalerId"], typeof(System.String)) : string.Empty;
					results = Wholesaler_ProductProvider.GetByWholesalerId(_wholesalerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == Wholesaler_ProductSelectMethod.Get || SelectMethod == Wholesaler_ProductSelectMethod.GetById )
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
				Wholesaler_Product entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Wholesaler_ProductProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Wholesaler_Product> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Wholesaler_ProductProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Wholesaler_ProductDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Wholesaler_ProductDataSource class.
	/// </summary>
	public class Wholesaler_ProductDataSourceDesigner : ProviderDataSourceDesigner<Wholesaler_Product, Wholesaler_ProductKey>
	{
		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductDataSourceDesigner class.
		/// </summary>
		public Wholesaler_ProductDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Wholesaler_ProductSelectMethod SelectMethod
		{
			get { return ((Wholesaler_ProductDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Wholesaler_ProductDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Wholesaler_ProductDataSourceActionList

	/// <summary>
	/// Supports the Wholesaler_ProductDataSourceDesigner class.
	/// </summary>
	internal class Wholesaler_ProductDataSourceActionList : DesignerActionList
	{
		private Wholesaler_ProductDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Wholesaler_ProductDataSourceActionList(Wholesaler_ProductDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Wholesaler_ProductSelectMethod SelectMethod
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

	#endregion Wholesaler_ProductDataSourceActionList
	
	#endregion Wholesaler_ProductDataSourceDesigner
	
	#region Wholesaler_ProductSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Wholesaler_ProductDataSource.SelectMethod property.
	/// </summary>
	public enum Wholesaler_ProductSelectMethod
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
		/// Represents the GetByWholesalerIdProductId method.
		/// </summary>
		GetByWholesalerIdProductId,
		/// <summary>
		/// Represents the GetByProductId method.
		/// </summary>
		GetByProductId,
		/// <summary>
		/// Represents the GetByWholesalerId method.
		/// </summary>
		GetByWholesalerId
	}
	
	#endregion Wholesaler_ProductSelectMethod

	#region Wholesaler_ProductFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductFilter : SqlFilter<Wholesaler_ProductColumn>
	{
	}
	
	#endregion Wholesaler_ProductFilter

	#region Wholesaler_ProductExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductExpressionBuilder : SqlExpressionBuilder<Wholesaler_ProductColumn>
	{
	}
	
	#endregion Wholesaler_ProductExpressionBuilder	

	#region Wholesaler_ProductProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Wholesaler_ProductChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductProperty : ChildEntityProperty<Wholesaler_ProductChildEntityTypes>
	{
	}
	
	#endregion Wholesaler_ProductProperty
}

