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
	/// Represents the DataRepository.ParticipantProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ParticipantDataSourceDesigner))]
	public class ParticipantDataSource : ProviderDataSource<Participant, ParticipantKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantDataSource class.
		/// </summary>
		public ParticipantDataSource() : base(new ParticipantService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ParticipantDataSourceView used by the ParticipantDataSource.
		/// </summary>
		protected ParticipantDataSourceView ParticipantView
		{
			get { return ( View as ParticipantDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ParticipantDataSource control invokes to retrieve data.
		/// </summary>
		public ParticipantSelectMethod SelectMethod
		{
			get
			{
				ParticipantSelectMethod selectMethod = ParticipantSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ParticipantSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ParticipantDataSourceView class that is to be
		/// used by the ParticipantDataSource.
		/// </summary>
		/// <returns>An instance of the ParticipantDataSourceView class.</returns>
		protected override BaseDataSourceView<Participant, ParticipantKey> GetNewDataSourceView()
		{
			return new ParticipantDataSourceView(this, DefaultViewName);
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
	/// Supports the ParticipantDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ParticipantDataSourceView : ProviderDataSourceView<Participant, ParticipantKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ParticipantDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ParticipantDataSourceView(ParticipantDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ParticipantDataSource ParticipantOwner
		{
			get { return Owner as ParticipantDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ParticipantSelectMethod SelectMethod
		{
			get { return ParticipantOwner.SelectMethod; }
			set { ParticipantOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ParticipantService ParticipantProvider
		{
			get { return Provider as ParticipantService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Participant> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Participant> results = null;
			Participant item;
			count = 0;
			
			System.Int32 _id;
			System.Int32 _participantListId;

			switch ( SelectMethod )
			{
				case ParticipantSelectMethod.Get:
					ParticipantKey entityKey  = new ParticipantKey();
					entityKey.Load(values);
					item = ParticipantProvider.Get(entityKey);
					results = new TList<Participant>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ParticipantSelectMethod.GetAll:
                    results = ParticipantProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ParticipantSelectMethod.GetPaged:
					results = ParticipantProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ParticipantSelectMethod.Find:
					if ( FilterParameters != null )
						results = ParticipantProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ParticipantProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ParticipantSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ParticipantProvider.GetById(_id);
					results = new TList<Participant>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ParticipantSelectMethod.GetByParticipantListId:
					_participantListId = ( values["ParticipantListId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ParticipantListId"], typeof(System.Int32)) : (int)0;
					results = ParticipantProvider.GetByParticipantListId(_participantListId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ParticipantSelectMethod.Get || SelectMethod == ParticipantSelectMethod.GetById )
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
				Participant entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ParticipantProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Participant> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ParticipantProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ParticipantDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ParticipantDataSource class.
	/// </summary>
	public class ParticipantDataSourceDesigner : ProviderDataSourceDesigner<Participant, ParticipantKey>
	{
		/// <summary>
		/// Initializes a new instance of the ParticipantDataSourceDesigner class.
		/// </summary>
		public ParticipantDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ParticipantSelectMethod SelectMethod
		{
			get { return ((ParticipantDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ParticipantDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ParticipantDataSourceActionList

	/// <summary>
	/// Supports the ParticipantDataSourceDesigner class.
	/// </summary>
	internal class ParticipantDataSourceActionList : DesignerActionList
	{
		private ParticipantDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ParticipantDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ParticipantDataSourceActionList(ParticipantDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ParticipantSelectMethod SelectMethod
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

	#endregion ParticipantDataSourceActionList
	
	#endregion ParticipantDataSourceDesigner
	
	#region ParticipantSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ParticipantDataSource.SelectMethod property.
	/// </summary>
	public enum ParticipantSelectMethod
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
		/// Represents the GetByParticipantListId method.
		/// </summary>
		GetByParticipantListId
	}
	
	#endregion ParticipantSelectMethod

	#region ParticipantFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantFilter : SqlFilter<ParticipantColumn>
	{
	}
	
	#endregion ParticipantFilter

	#region ParticipantExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantExpressionBuilder : SqlExpressionBuilder<ParticipantColumn>
	{
	}
	
	#endregion ParticipantExpressionBuilder	

	#region ParticipantProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ParticipantChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantProperty : ChildEntityProperty<ParticipantChildEntityTypes>
	{
	}
	
	#endregion ParticipantProperty
}

