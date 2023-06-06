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
	/// Represents the DataRepository.RecordingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RecordingDataSourceDesigner))]
	public class RecordingDataSource : ProviderDataSource<Recording, RecordingKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingDataSource class.
		/// </summary>
		public RecordingDataSource() : base(new RecordingService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RecordingDataSourceView used by the RecordingDataSource.
		/// </summary>
		protected RecordingDataSourceView RecordingView
		{
			get { return ( View as RecordingDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RecordingDataSource control invokes to retrieve data.
		/// </summary>
		public RecordingSelectMethod SelectMethod
		{
			get
			{
				RecordingSelectMethod selectMethod = RecordingSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RecordingSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RecordingDataSourceView class that is to be
		/// used by the RecordingDataSource.
		/// </summary>
		/// <returns>An instance of the RecordingDataSourceView class.</returns>
		protected override BaseDataSourceView<Recording, RecordingKey> GetNewDataSourceView()
		{
			return new RecordingDataSourceView(this, DefaultViewName);
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
	/// Supports the RecordingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RecordingDataSourceView : ProviderDataSourceView<Recording, RecordingKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RecordingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RecordingDataSourceView(RecordingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RecordingDataSource RecordingOwner
		{
			get { return Owner as RecordingDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RecordingSelectMethod SelectMethod
		{
			get { return RecordingOwner.SelectMethod; }
			set { RecordingOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RecordingService RecordingProvider
		{
			get { return Provider as RecordingService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Recording> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Recording> results = null;
			Recording item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _moderatorId_nullable;
			System.String _replayCode_nullable;
			System.String _recordingGuid_nullable;

			switch ( SelectMethod )
			{
				case RecordingSelectMethod.Get:
					RecordingKey entityKey  = new RecordingKey();
					entityKey.Load(values);
					item = RecordingProvider.Get(entityKey);
					results = new TList<Recording>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RecordingSelectMethod.GetAll:
                    results = RecordingProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RecordingSelectMethod.GetPaged:
					results = RecordingProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RecordingSelectMethod.Find:
					if ( FilterParameters != null )
						results = RecordingProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RecordingProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RecordingSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = RecordingProvider.GetById(_id);
					results = new TList<Recording>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case RecordingSelectMethod.GetByModeratorId:
					_moderatorId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ModeratorId"], typeof(System.Int32?));
					results = RecordingProvider.GetByModeratorId(_moderatorId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RecordingSelectMethod.GetByReplayCode:
					_replayCode_nullable = (System.String) EntityUtil.ChangeType(values["ReplayCode"], typeof(System.String));
					results = RecordingProvider.GetByReplayCode(_replayCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case RecordingSelectMethod.GetByRecordingGuid:
					_recordingGuid_nullable = (System.String) EntityUtil.ChangeType(values["RecordingGuid"], typeof(System.String));
					results = RecordingProvider.GetByRecordingGuid(_recordingGuid_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RecordingSelectMethod.Get || SelectMethod == RecordingSelectMethod.GetById )
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
				Recording entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RecordingProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Recording> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RecordingProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RecordingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RecordingDataSource class.
	/// </summary>
	public class RecordingDataSourceDesigner : ProviderDataSourceDesigner<Recording, RecordingKey>
	{
		/// <summary>
		/// Initializes a new instance of the RecordingDataSourceDesigner class.
		/// </summary>
		public RecordingDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RecordingSelectMethod SelectMethod
		{
			get { return ((RecordingDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RecordingDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RecordingDataSourceActionList

	/// <summary>
	/// Supports the RecordingDataSourceDesigner class.
	/// </summary>
	internal class RecordingDataSourceActionList : DesignerActionList
	{
		private RecordingDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RecordingDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RecordingDataSourceActionList(RecordingDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RecordingSelectMethod SelectMethod
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

	#endregion RecordingDataSourceActionList
	
	#endregion RecordingDataSourceDesigner
	
	#region RecordingSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RecordingDataSource.SelectMethod property.
	/// </summary>
	public enum RecordingSelectMethod
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
		/// Represents the GetByModeratorId method.
		/// </summary>
		GetByModeratorId,
		/// <summary>
		/// Represents the GetByReplayCode method.
		/// </summary>
		GetByReplayCode,
		/// <summary>
		/// Represents the GetByRecordingGuid method.
		/// </summary>
		GetByRecordingGuid
	}
	
	#endregion RecordingSelectMethod

	#region RecordingFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingFilter : SqlFilter<RecordingColumn>
	{
	}
	
	#endregion RecordingFilter

	#region RecordingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingExpressionBuilder : SqlExpressionBuilder<RecordingColumn>
	{
	}
	
	#endregion RecordingExpressionBuilder	

	#region RecordingProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RecordingChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingProperty : ChildEntityProperty<RecordingChildEntityTypes>
	{
	}
	
	#endregion RecordingProperty
}

