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
	/// Represents the DataRepository.SystemSettingsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SystemSettingsDataSourceDesigner))]
	public class SystemSettingsDataSource : ProviderDataSource<SystemSettings, SystemSettingsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemSettingsDataSource class.
		/// </summary>
		public SystemSettingsDataSource() : base(new SystemSettingsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SystemSettingsDataSourceView used by the SystemSettingsDataSource.
		/// </summary>
		protected SystemSettingsDataSourceView SystemSettingsView
		{
			get { return ( View as SystemSettingsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SystemSettingsDataSource control invokes to retrieve data.
		/// </summary>
		public SystemSettingsSelectMethod SelectMethod
		{
			get
			{
				SystemSettingsSelectMethod selectMethod = SystemSettingsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SystemSettingsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SystemSettingsDataSourceView class that is to be
		/// used by the SystemSettingsDataSource.
		/// </summary>
		/// <returns>An instance of the SystemSettingsDataSourceView class.</returns>
		protected override BaseDataSourceView<SystemSettings, SystemSettingsKey> GetNewDataSourceView()
		{
			return new SystemSettingsDataSourceView(this, DefaultViewName);
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
	/// Supports the SystemSettingsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SystemSettingsDataSourceView : ProviderDataSourceView<SystemSettings, SystemSettingsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemSettingsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SystemSettingsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SystemSettingsDataSourceView(SystemSettingsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SystemSettingsDataSource SystemSettingsOwner
		{
			get { return Owner as SystemSettingsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SystemSettingsSelectMethod SelectMethod
		{
			get { return SystemSettingsOwner.SelectMethod; }
			set { SystemSettingsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SystemSettingsService SystemSettingsProvider
		{
			get { return Provider as SystemSettingsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SystemSettings> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SystemSettings> results = null;
			SystemSettings item;
			count = 0;
			
			System.String _name;

			switch ( SelectMethod )
			{
				case SystemSettingsSelectMethod.Get:
					SystemSettingsKey entityKey  = new SystemSettingsKey();
					entityKey.Load(values);
					item = SystemSettingsProvider.Get(entityKey);
					results = new TList<SystemSettings>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SystemSettingsSelectMethod.GetAll:
                    results = SystemSettingsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SystemSettingsSelectMethod.GetPaged:
					results = SystemSettingsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SystemSettingsSelectMethod.Find:
					if ( FilterParameters != null )
						results = SystemSettingsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SystemSettingsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SystemSettingsSelectMethod.GetByName:
					_name = ( values["Name"] != null ) ? (System.String) EntityUtil.ChangeType(values["Name"], typeof(System.String)) : string.Empty;
					item = SystemSettingsProvider.GetByName(_name);
					results = new TList<SystemSettings>();
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
			if ( SelectMethod == SystemSettingsSelectMethod.Get || SelectMethod == SystemSettingsSelectMethod.GetByName )
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
				SystemSettings entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SystemSettingsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SystemSettings> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SystemSettingsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SystemSettingsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SystemSettingsDataSource class.
	/// </summary>
	public class SystemSettingsDataSourceDesigner : ProviderDataSourceDesigner<SystemSettings, SystemSettingsKey>
	{
		/// <summary>
		/// Initializes a new instance of the SystemSettingsDataSourceDesigner class.
		/// </summary>
		public SystemSettingsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemSettingsSelectMethod SelectMethod
		{
			get { return ((SystemSettingsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SystemSettingsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SystemSettingsDataSourceActionList

	/// <summary>
	/// Supports the SystemSettingsDataSourceDesigner class.
	/// </summary>
	internal class SystemSettingsDataSourceActionList : DesignerActionList
	{
		private SystemSettingsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SystemSettingsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SystemSettingsDataSourceActionList(SystemSettingsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SystemSettingsSelectMethod SelectMethod
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

	#endregion SystemSettingsDataSourceActionList
	
	#endregion SystemSettingsDataSourceDesigner
	
	#region SystemSettingsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SystemSettingsDataSource.SelectMethod property.
	/// </summary>
	public enum SystemSettingsSelectMethod
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
		/// Represents the GetByName method.
		/// </summary>
		GetByName
	}
	
	#endregion SystemSettingsSelectMethod

	#region SystemSettingsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemSettingsFilter : SqlFilter<SystemSettingsColumn>
	{
	}
	
	#endregion SystemSettingsFilter

	#region SystemSettingsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemSettingsExpressionBuilder : SqlExpressionBuilder<SystemSettingsColumn>
	{
	}
	
	#endregion SystemSettingsExpressionBuilder	

	#region SystemSettingsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SystemSettingsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SystemSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemSettingsProperty : ChildEntityProperty<SystemSettingsChildEntityTypes>
	{
	}
	
	#endregion SystemSettingsProperty
}

