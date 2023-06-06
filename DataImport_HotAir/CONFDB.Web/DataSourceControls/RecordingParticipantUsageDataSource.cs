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
	/// Represents the DataRepository.RecordingParticipantUsageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RecordingParticipantUsageDataSourceDesigner))]
	public class RecordingParticipantUsageDataSource : ProviderDataSource<RecordingParticipantUsage, RecordingParticipantUsageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageDataSource class.
		/// </summary>
		public RecordingParticipantUsageDataSource() : base(new RecordingParticipantUsageService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RecordingParticipantUsageDataSourceView used by the RecordingParticipantUsageDataSource.
		/// </summary>
		protected RecordingParticipantUsageDataSourceView RecordingParticipantUsageView
		{
			get { return ( View as RecordingParticipantUsageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RecordingParticipantUsageDataSource control invokes to retrieve data.
		/// </summary>
		public RecordingParticipantUsageSelectMethod SelectMethod
		{
			get
			{
				RecordingParticipantUsageSelectMethod selectMethod = RecordingParticipantUsageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RecordingParticipantUsageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RecordingParticipantUsageDataSourceView class that is to be
		/// used by the RecordingParticipantUsageDataSource.
		/// </summary>
		/// <returns>An instance of the RecordingParticipantUsageDataSourceView class.</returns>
		protected override BaseDataSourceView<RecordingParticipantUsage, RecordingParticipantUsageKey> GetNewDataSourceView()
		{
			return new RecordingParticipantUsageDataSourceView(this, DefaultViewName);
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
	/// Supports the RecordingParticipantUsageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RecordingParticipantUsageDataSourceView : ProviderDataSourceView<RecordingParticipantUsage, RecordingParticipantUsageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RecordingParticipantUsageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RecordingParticipantUsageDataSourceView(RecordingParticipantUsageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RecordingParticipantUsageDataSource RecordingParticipantUsageOwner
		{
			get { return Owner as RecordingParticipantUsageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RecordingParticipantUsageSelectMethod SelectMethod
		{
			get { return RecordingParticipantUsageOwner.SelectMethod; }
			set { RecordingParticipantUsageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RecordingParticipantUsageService RecordingParticipantUsageProvider
		{
			get { return Provider as RecordingParticipantUsageService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RecordingParticipantUsage> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RecordingParticipantUsage> results = null;
			RecordingParticipantUsage item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _recordingId;

			switch ( SelectMethod )
			{
				case RecordingParticipantUsageSelectMethod.Get:
					RecordingParticipantUsageKey entityKey  = new RecordingParticipantUsageKey();
					entityKey.Load(values);
					item = RecordingParticipantUsageProvider.Get(entityKey);
					results = new TList<RecordingParticipantUsage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RecordingParticipantUsageSelectMethod.GetAll:
                    results = RecordingParticipantUsageProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RecordingParticipantUsageSelectMethod.GetPaged:
					results = RecordingParticipantUsageProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RecordingParticipantUsageSelectMethod.Find:
					if ( FilterParameters != null )
						results = RecordingParticipantUsageProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RecordingParticipantUsageProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RecordingParticipantUsageSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = RecordingParticipantUsageProvider.GetById(_id);
					results = new TList<RecordingParticipantUsage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case RecordingParticipantUsageSelectMethod.GetByRecordingId:
					_recordingId = ( values["RecordingId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RecordingId"], typeof(System.Int32)) : (int)0;
					results = RecordingParticipantUsageProvider.GetByRecordingId(_recordingId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RecordingParticipantUsageSelectMethod.Get || SelectMethod == RecordingParticipantUsageSelectMethod.GetById )
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
				RecordingParticipantUsage entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RecordingParticipantUsageProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RecordingParticipantUsage> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RecordingParticipantUsageProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RecordingParticipantUsageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RecordingParticipantUsageDataSource class.
	/// </summary>
	public class RecordingParticipantUsageDataSourceDesigner : ProviderDataSourceDesigner<RecordingParticipantUsage, RecordingParticipantUsageKey>
	{
		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageDataSourceDesigner class.
		/// </summary>
		public RecordingParticipantUsageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RecordingParticipantUsageSelectMethod SelectMethod
		{
			get { return ((RecordingParticipantUsageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RecordingParticipantUsageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RecordingParticipantUsageDataSourceActionList

	/// <summary>
	/// Supports the RecordingParticipantUsageDataSourceDesigner class.
	/// </summary>
	internal class RecordingParticipantUsageDataSourceActionList : DesignerActionList
	{
		private RecordingParticipantUsageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RecordingParticipantUsageDataSourceActionList(RecordingParticipantUsageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RecordingParticipantUsageSelectMethod SelectMethod
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

	#endregion RecordingParticipantUsageDataSourceActionList
	
	#endregion RecordingParticipantUsageDataSourceDesigner
	
	#region RecordingParticipantUsageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RecordingParticipantUsageDataSource.SelectMethod property.
	/// </summary>
	public enum RecordingParticipantUsageSelectMethod
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
		/// Represents the GetByRecordingId method.
		/// </summary>
		GetByRecordingId
	}
	
	#endregion RecordingParticipantUsageSelectMethod

	#region RecordingParticipantUsageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageFilter : SqlFilter<RecordingParticipantUsageColumn>
	{
	}
	
	#endregion RecordingParticipantUsageFilter

	#region RecordingParticipantUsageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageExpressionBuilder : SqlExpressionBuilder<RecordingParticipantUsageColumn>
	{
	}
	
	#endregion RecordingParticipantUsageExpressionBuilder	

	#region RecordingParticipantUsageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RecordingParticipantUsageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageProperty : ChildEntityProperty<RecordingParticipantUsageChildEntityTypes>
	{
	}
	
	#endregion RecordingParticipantUsageProperty
}

