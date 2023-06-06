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
	/// Represents the DataRepository.ModeratorXtimeUserProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ModeratorXtimeUserDataSourceDesigner))]
	public class ModeratorXtimeUserDataSource : ProviderDataSource<ModeratorXtimeUser, ModeratorXtimeUserKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserDataSource class.
		/// </summary>
		public ModeratorXtimeUserDataSource() : base(new ModeratorXtimeUserService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ModeratorXtimeUserDataSourceView used by the ModeratorXtimeUserDataSource.
		/// </summary>
		protected ModeratorXtimeUserDataSourceView ModeratorXtimeUserView
		{
			get { return ( View as ModeratorXtimeUserDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ModeratorXtimeUserDataSource control invokes to retrieve data.
		/// </summary>
		public ModeratorXtimeUserSelectMethod SelectMethod
		{
			get
			{
				ModeratorXtimeUserSelectMethod selectMethod = ModeratorXtimeUserSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ModeratorXtimeUserSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ModeratorXtimeUserDataSourceView class that is to be
		/// used by the ModeratorXtimeUserDataSource.
		/// </summary>
		/// <returns>An instance of the ModeratorXtimeUserDataSourceView class.</returns>
		protected override BaseDataSourceView<ModeratorXtimeUser, ModeratorXtimeUserKey> GetNewDataSourceView()
		{
			return new ModeratorXtimeUserDataSourceView(this, DefaultViewName);
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
	/// Supports the ModeratorXtimeUserDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ModeratorXtimeUserDataSourceView : ProviderDataSourceView<ModeratorXtimeUser, ModeratorXtimeUserKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ModeratorXtimeUserDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ModeratorXtimeUserDataSourceView(ModeratorXtimeUserDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ModeratorXtimeUserDataSource ModeratorXtimeUserOwner
		{
			get { return Owner as ModeratorXtimeUserDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ModeratorXtimeUserSelectMethod SelectMethod
		{
			get { return ModeratorXtimeUserOwner.SelectMethod; }
			set { ModeratorXtimeUserOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ModeratorXtimeUserService ModeratorXtimeUserProvider
		{
			get { return Provider as ModeratorXtimeUserService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ModeratorXtimeUser> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ModeratorXtimeUser> results = null;
			ModeratorXtimeUser item;
			count = 0;
			
			System.Int32 _moderatorId;
			System.DateTime? _firstCallDate_nullable;
			System.DateTime? _thirdCallDate_nullable;

			switch ( SelectMethod )
			{
				case ModeratorXtimeUserSelectMethod.Get:
					ModeratorXtimeUserKey entityKey  = new ModeratorXtimeUserKey();
					entityKey.Load(values);
					item = ModeratorXtimeUserProvider.Get(entityKey);
					results = new TList<ModeratorXtimeUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ModeratorXtimeUserSelectMethod.GetAll:
                    results = ModeratorXtimeUserProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ModeratorXtimeUserSelectMethod.GetPaged:
					results = ModeratorXtimeUserProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ModeratorXtimeUserSelectMethod.Find:
					if ( FilterParameters != null )
						results = ModeratorXtimeUserProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ModeratorXtimeUserProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ModeratorXtimeUserSelectMethod.GetByModeratorId:
					_moderatorId = ( values["ModeratorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32)) : (int)0;
					item = ModeratorXtimeUserProvider.GetByModeratorId(_moderatorId);
					results = new TList<ModeratorXtimeUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ModeratorXtimeUserSelectMethod.GetByFirstCallDate:
					_firstCallDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["FirstCallDate"], typeof(System.DateTime?));
					results = ModeratorXtimeUserProvider.GetByFirstCallDate(_firstCallDate_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ModeratorXtimeUserSelectMethod.GetByThirdCallDate:
					_thirdCallDate_nullable = (System.DateTime?) EntityUtil.ChangeType(values["ThirdCallDate"], typeof(System.DateTime?));
					results = ModeratorXtimeUserProvider.GetByThirdCallDate(_thirdCallDate_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ModeratorXtimeUserSelectMethod.Get || SelectMethod == ModeratorXtimeUserSelectMethod.GetByModeratorId )
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
				ModeratorXtimeUser entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ModeratorXtimeUserProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ModeratorXtimeUser> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ModeratorXtimeUserProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ModeratorXtimeUserDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ModeratorXtimeUserDataSource class.
	/// </summary>
	public class ModeratorXtimeUserDataSourceDesigner : ProviderDataSourceDesigner<ModeratorXtimeUser, ModeratorXtimeUserKey>
	{
		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserDataSourceDesigner class.
		/// </summary>
		public ModeratorXtimeUserDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ModeratorXtimeUserSelectMethod SelectMethod
		{
			get { return ((ModeratorXtimeUserDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ModeratorXtimeUserDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ModeratorXtimeUserDataSourceActionList

	/// <summary>
	/// Supports the ModeratorXtimeUserDataSourceDesigner class.
	/// </summary>
	internal class ModeratorXtimeUserDataSourceActionList : DesignerActionList
	{
		private ModeratorXtimeUserDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ModeratorXtimeUserDataSourceActionList(ModeratorXtimeUserDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ModeratorXtimeUserSelectMethod SelectMethod
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

	#endregion ModeratorXtimeUserDataSourceActionList
	
	#endregion ModeratorXtimeUserDataSourceDesigner
	
	#region ModeratorXtimeUserSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ModeratorXtimeUserDataSource.SelectMethod property.
	/// </summary>
	public enum ModeratorXtimeUserSelectMethod
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
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByFirstCallDate method.
		/// </summary>
		GetByFirstCallDate,
		/// <summary>
		/// Represents the GetByThirdCallDate method.
		/// </summary>
		GetByThirdCallDate
	}
	
	#endregion ModeratorXtimeUserSelectMethod

	#region ModeratorXtimeUserFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserFilter : SqlFilter<ModeratorXtimeUserColumn>
	{
	}
	
	#endregion ModeratorXtimeUserFilter

	#region ModeratorXtimeUserExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserExpressionBuilder : SqlExpressionBuilder<ModeratorXtimeUserColumn>
	{
	}
	
	#endregion ModeratorXtimeUserExpressionBuilder	

	#region ModeratorXtimeUserProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ModeratorXtimeUserChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserProperty : ChildEntityProperty<ModeratorXtimeUserChildEntityTypes>
	{
	}
	
	#endregion ModeratorXtimeUserProperty
}

