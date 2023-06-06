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
	/// Represents the DataRepository.Moderator_FeatureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Moderator_FeatureDataSourceDesigner))]
	public class Moderator_FeatureDataSource : ProviderDataSource<Moderator_Feature, Moderator_FeatureKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureDataSource class.
		/// </summary>
		public Moderator_FeatureDataSource() : base(new Moderator_FeatureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Moderator_FeatureDataSourceView used by the Moderator_FeatureDataSource.
		/// </summary>
		protected Moderator_FeatureDataSourceView Moderator_FeatureView
		{
			get { return ( View as Moderator_FeatureDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Moderator_FeatureDataSource control invokes to retrieve data.
		/// </summary>
		public Moderator_FeatureSelectMethod SelectMethod
		{
			get
			{
				Moderator_FeatureSelectMethod selectMethod = Moderator_FeatureSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Moderator_FeatureSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Moderator_FeatureDataSourceView class that is to be
		/// used by the Moderator_FeatureDataSource.
		/// </summary>
		/// <returns>An instance of the Moderator_FeatureDataSourceView class.</returns>
		protected override BaseDataSourceView<Moderator_Feature, Moderator_FeatureKey> GetNewDataSourceView()
		{
			return new Moderator_FeatureDataSourceView(this, DefaultViewName);
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
	/// Supports the Moderator_FeatureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Moderator_FeatureDataSourceView : ProviderDataSourceView<Moderator_Feature, Moderator_FeatureKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Moderator_FeatureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Moderator_FeatureDataSourceView(Moderator_FeatureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Moderator_FeatureDataSource Moderator_FeatureOwner
		{
			get { return Owner as Moderator_FeatureDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Moderator_FeatureSelectMethod SelectMethod
		{
			get { return Moderator_FeatureOwner.SelectMethod; }
			set { Moderator_FeatureOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Moderator_FeatureService Moderator_FeatureProvider
		{
			get { return Provider as Moderator_FeatureService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Moderator_Feature> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Moderator_Feature> results = null;
			Moderator_Feature item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _featureId;
			System.Int32 _moderatorId;
			System.Int32 _featureOptionId;

			switch ( SelectMethod )
			{
				case Moderator_FeatureSelectMethod.Get:
					Moderator_FeatureKey entityKey  = new Moderator_FeatureKey();
					entityKey.Load(values);
					item = Moderator_FeatureProvider.Get(entityKey);
					results = new TList<Moderator_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Moderator_FeatureSelectMethod.GetAll:
                    results = Moderator_FeatureProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Moderator_FeatureSelectMethod.GetPaged:
					results = Moderator_FeatureProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Moderator_FeatureSelectMethod.Find:
					if ( FilterParameters != null )
						results = Moderator_FeatureProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Moderator_FeatureProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Moderator_FeatureSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = Moderator_FeatureProvider.GetById(_id);
					results = new TList<Moderator_Feature>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case Moderator_FeatureSelectMethod.GetByFeatureIdModeratorIdFeatureOptionId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					_featureOptionId = ( values["FeatureOptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureOptionId"], typeof(System.Int32)) : (int)0;
					results = Moderator_FeatureProvider.GetByFeatureIdModeratorIdFeatureOptionId(_featureId, _moderatorId, _featureOptionId, this.StartIndex, this.PageSize, out count);
					break;
				case Moderator_FeatureSelectMethod.GetByFeatureId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					results = Moderator_FeatureProvider.GetByFeatureId(_featureId, this.StartIndex, this.PageSize, out count);
					break;
				case Moderator_FeatureSelectMethod.GetByFeatureIdModeratorId:
					_featureId = ( values["FeatureId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureId"], typeof(System.Int32)) : (int)0;
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = Moderator_FeatureProvider.GetByFeatureIdModeratorId(_featureId, _moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case Moderator_FeatureSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = Moderator_FeatureProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				case Moderator_FeatureSelectMethod.GetByFeatureOptionId:
					_featureOptionId = ( values["FeatureOptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FeatureOptionId"], typeof(System.Int32)) : (int)0;
					results = Moderator_FeatureProvider.GetByFeatureOptionId(_featureOptionId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == Moderator_FeatureSelectMethod.Get || SelectMethod == Moderator_FeatureSelectMethod.GetById )
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
				Moderator_Feature entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Moderator_FeatureProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Moderator_Feature> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Moderator_FeatureProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Moderator_FeatureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Moderator_FeatureDataSource class.
	/// </summary>
	public class Moderator_FeatureDataSourceDesigner : ProviderDataSourceDesigner<Moderator_Feature, Moderator_FeatureKey>
	{
		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureDataSourceDesigner class.
		/// </summary>
		public Moderator_FeatureDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Moderator_FeatureSelectMethod SelectMethod
		{
			get { return ((Moderator_FeatureDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Moderator_FeatureDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Moderator_FeatureDataSourceActionList

	/// <summary>
	/// Supports the Moderator_FeatureDataSourceDesigner class.
	/// </summary>
	internal class Moderator_FeatureDataSourceActionList : DesignerActionList
	{
		private Moderator_FeatureDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Moderator_FeatureDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Moderator_FeatureDataSourceActionList(Moderator_FeatureDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Moderator_FeatureSelectMethod SelectMethod
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

	#endregion Moderator_FeatureDataSourceActionList
	
	#endregion Moderator_FeatureDataSourceDesigner
	
	#region Moderator_FeatureSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Moderator_FeatureDataSource.SelectMethod property.
	/// </summary>
	public enum Moderator_FeatureSelectMethod
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
		/// Represents the GetByFeatureIdModeratorIdFeatureOptionId method.
		/// </summary>
		GetByFeatureIdModeratorIdFeatureOptionId,
		/// <summary>
		/// Represents the GetByFeatureId method.
		/// </summary>
		GetByFeatureId,
		/// <summary>
		/// Represents the GetByFeatureIdModeratorId method.
		/// </summary>
		GetByFeatureIdModeratorId,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByFeatureOptionId method.
		/// </summary>
		GetByFeatureOptionId
	}
	
	#endregion Moderator_FeatureSelectMethod

	#region Moderator_FeatureFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_FeatureFilter : SqlFilter<Moderator_FeatureColumn>
	{
	}
	
	#endregion Moderator_FeatureFilter

	#region Moderator_FeatureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_FeatureExpressionBuilder : SqlExpressionBuilder<Moderator_FeatureColumn>
	{
	}
	
	#endregion Moderator_FeatureExpressionBuilder	

	#region Moderator_FeatureProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Moderator_FeatureChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_FeatureProperty : ChildEntityProperty<Moderator_FeatureChildEntityTypes>
	{
	}
	
	#endregion Moderator_FeatureProperty
}

