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
	/// Represents the DataRepository.Moderator_DnisProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Moderator_DnisDataSourceDesigner))]
	public class Moderator_DnisDataSource : ProviderDataSource<Moderator_Dnis, Moderator_DnisKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisDataSource class.
		/// </summary>
		public Moderator_DnisDataSource() : base(new Moderator_DnisService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Moderator_DnisDataSourceView used by the Moderator_DnisDataSource.
		/// </summary>
		protected Moderator_DnisDataSourceView Moderator_DnisView
		{
			get { return ( View as Moderator_DnisDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Moderator_DnisDataSource control invokes to retrieve data.
		/// </summary>
		public Moderator_DnisSelectMethod SelectMethod
		{
			get
			{
				Moderator_DnisSelectMethod selectMethod = Moderator_DnisSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Moderator_DnisSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Moderator_DnisDataSourceView class that is to be
		/// used by the Moderator_DnisDataSource.
		/// </summary>
		/// <returns>An instance of the Moderator_DnisDataSourceView class.</returns>
		protected override BaseDataSourceView<Moderator_Dnis, Moderator_DnisKey> GetNewDataSourceView()
		{
			return new Moderator_DnisDataSourceView(this, DefaultViewName);
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
	/// Supports the Moderator_DnisDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Moderator_DnisDataSourceView : ProviderDataSourceView<Moderator_Dnis, Moderator_DnisKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Moderator_DnisDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Moderator_DnisDataSourceView(Moderator_DnisDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Moderator_DnisDataSource Moderator_DnisOwner
		{
			get { return Owner as Moderator_DnisDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Moderator_DnisSelectMethod SelectMethod
		{
			get { return Moderator_DnisOwner.SelectMethod; }
			set { Moderator_DnisOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Moderator_DnisService Moderator_DnisProvider
		{
			get { return Provider as Moderator_DnisService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Moderator_Dnis> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Moderator_Dnis> results = null;
			Moderator_Dnis item;
			count = 0;
			
			System.Int32 _dnisid;
			System.Int32 _moderatorId;

			switch ( SelectMethod )
			{
				case Moderator_DnisSelectMethod.Get:
					Moderator_DnisKey entityKey  = new Moderator_DnisKey();
					entityKey.Load(values);
					item = Moderator_DnisProvider.Get(entityKey);
					results = new TList<Moderator_Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Moderator_DnisSelectMethod.GetAll:
                    results = Moderator_DnisProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case Moderator_DnisSelectMethod.GetPaged:
					results = Moderator_DnisProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Moderator_DnisSelectMethod.Find:
					if ( FilterParameters != null )
						results = Moderator_DnisProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Moderator_DnisProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Moderator_DnisSelectMethod.GetByDnisidModeratorId:
					_dnisid = ( values["Dnisid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Dnisid"], typeof(System.Int32)) : (int)0;
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					item = Moderator_DnisProvider.GetByDnisidModeratorId(_dnisid, _moderatorId);
					results = new TList<Moderator_Dnis>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case Moderator_DnisSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					results = Moderator_DnisProvider.GetByModeratorId(_moderatorId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case Moderator_DnisSelectMethod.GetByDnisid:
					_dnisid = ( values["Dnisid"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Dnisid"], typeof(System.Int32)) : (int)0;
					results = Moderator_DnisProvider.GetByDnisid(_dnisid, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == Moderator_DnisSelectMethod.Get || SelectMethod == Moderator_DnisSelectMethod.GetByDnisidModeratorId )
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
				Moderator_Dnis entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					Moderator_DnisProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Moderator_Dnis> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			Moderator_DnisProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Moderator_DnisDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Moderator_DnisDataSource class.
	/// </summary>
	public class Moderator_DnisDataSourceDesigner : ProviderDataSourceDesigner<Moderator_Dnis, Moderator_DnisKey>
	{
		/// <summary>
		/// Initializes a new instance of the Moderator_DnisDataSourceDesigner class.
		/// </summary>
		public Moderator_DnisDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Moderator_DnisSelectMethod SelectMethod
		{
			get { return ((Moderator_DnisDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Moderator_DnisDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Moderator_DnisDataSourceActionList

	/// <summary>
	/// Supports the Moderator_DnisDataSourceDesigner class.
	/// </summary>
	internal class Moderator_DnisDataSourceActionList : DesignerActionList
	{
		private Moderator_DnisDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Moderator_DnisDataSourceActionList(Moderator_DnisDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Moderator_DnisSelectMethod SelectMethod
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

	#endregion Moderator_DnisDataSourceActionList
	
	#endregion Moderator_DnisDataSourceDesigner
	
	#region Moderator_DnisSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Moderator_DnisDataSource.SelectMethod property.
	/// </summary>
	public enum Moderator_DnisSelectMethod
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
		/// Represents the GetByDnisidModeratorId method.
		/// </summary>
		GetByDnisidModeratorId,
		/// <summary>
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByDnisid method.
		/// </summary>
		GetByDnisid
	}
	
	#endregion Moderator_DnisSelectMethod

	#region Moderator_DnisFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisFilter : SqlFilter<Moderator_DnisColumn>
	{
	}
	
	#endregion Moderator_DnisFilter

	#region Moderator_DnisExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisExpressionBuilder : SqlExpressionBuilder<Moderator_DnisColumn>
	{
	}
	
	#endregion Moderator_DnisExpressionBuilder	

	#region Moderator_DnisProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Moderator_DnisChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisProperty : ChildEntityProperty<Moderator_DnisChildEntityTypes>
	{
	}
	
	#endregion Moderator_DnisProperty
}

