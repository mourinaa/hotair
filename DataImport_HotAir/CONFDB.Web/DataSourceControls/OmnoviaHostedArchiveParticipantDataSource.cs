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
	/// Represents the DataRepository.OmnoviaHostedArchiveParticipantProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OmnoviaHostedArchiveParticipantDataSourceDesigner))]
	public class OmnoviaHostedArchiveParticipantDataSource : ProviderDataSource<OmnoviaHostedArchiveParticipant, OmnoviaHostedArchiveParticipantKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantDataSource class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantDataSource() : base(new OmnoviaHostedArchiveParticipantService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OmnoviaHostedArchiveParticipantDataSourceView used by the OmnoviaHostedArchiveParticipantDataSource.
		/// </summary>
		protected OmnoviaHostedArchiveParticipantDataSourceView OmnoviaHostedArchiveParticipantView
		{
			get { return ( View as OmnoviaHostedArchiveParticipantDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OmnoviaHostedArchiveParticipantDataSource control invokes to retrieve data.
		/// </summary>
		public OmnoviaHostedArchiveParticipantSelectMethod SelectMethod
		{
			get
			{
				OmnoviaHostedArchiveParticipantSelectMethod selectMethod = OmnoviaHostedArchiveParticipantSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OmnoviaHostedArchiveParticipantSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OmnoviaHostedArchiveParticipantDataSourceView class that is to be
		/// used by the OmnoviaHostedArchiveParticipantDataSource.
		/// </summary>
		/// <returns>An instance of the OmnoviaHostedArchiveParticipantDataSourceView class.</returns>
		protected override BaseDataSourceView<OmnoviaHostedArchiveParticipant, OmnoviaHostedArchiveParticipantKey> GetNewDataSourceView()
		{
			return new OmnoviaHostedArchiveParticipantDataSourceView(this, DefaultViewName);
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
	/// Supports the OmnoviaHostedArchiveParticipantDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OmnoviaHostedArchiveParticipantDataSourceView : ProviderDataSourceView<OmnoviaHostedArchiveParticipant, OmnoviaHostedArchiveParticipantKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OmnoviaHostedArchiveParticipantDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OmnoviaHostedArchiveParticipantDataSourceView(OmnoviaHostedArchiveParticipantDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OmnoviaHostedArchiveParticipantDataSource OmnoviaHostedArchiveParticipantOwner
		{
			get { return Owner as OmnoviaHostedArchiveParticipantDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OmnoviaHostedArchiveParticipantSelectMethod SelectMethod
		{
			get { return OmnoviaHostedArchiveParticipantOwner.SelectMethod; }
			set { OmnoviaHostedArchiveParticipantOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OmnoviaHostedArchiveParticipantService OmnoviaHostedArchiveParticipantProvider
		{
			get { return Provider as OmnoviaHostedArchiveParticipantService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OmnoviaHostedArchiveParticipant> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OmnoviaHostedArchiveParticipant> results = null;
			OmnoviaHostedArchiveParticipant item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case OmnoviaHostedArchiveParticipantSelectMethod.Get:
					OmnoviaHostedArchiveParticipantKey entityKey  = new OmnoviaHostedArchiveParticipantKey();
					entityKey.Load(values);
					item = OmnoviaHostedArchiveParticipantProvider.Get(entityKey);
					results = new TList<OmnoviaHostedArchiveParticipant>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OmnoviaHostedArchiveParticipantSelectMethod.GetAll:
                    results = OmnoviaHostedArchiveParticipantProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OmnoviaHostedArchiveParticipantSelectMethod.GetPaged:
					results = OmnoviaHostedArchiveParticipantProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OmnoviaHostedArchiveParticipantSelectMethod.Find:
					if ( FilterParameters != null )
						results = OmnoviaHostedArchiveParticipantProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OmnoviaHostedArchiveParticipantProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OmnoviaHostedArchiveParticipantSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OmnoviaHostedArchiveParticipantProvider.GetById(_id);
					results = new TList<OmnoviaHostedArchiveParticipant>();
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
			if ( SelectMethod == OmnoviaHostedArchiveParticipantSelectMethod.Get || SelectMethod == OmnoviaHostedArchiveParticipantSelectMethod.GetById )
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
				OmnoviaHostedArchiveParticipant entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OmnoviaHostedArchiveParticipantProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OmnoviaHostedArchiveParticipant> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			OmnoviaHostedArchiveParticipantProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OmnoviaHostedArchiveParticipantDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OmnoviaHostedArchiveParticipantDataSource class.
	/// </summary>
	public class OmnoviaHostedArchiveParticipantDataSourceDesigner : ProviderDataSourceDesigner<OmnoviaHostedArchiveParticipant, OmnoviaHostedArchiveParticipantKey>
	{
		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantDataSourceDesigner class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaHostedArchiveParticipantSelectMethod SelectMethod
		{
			get { return ((OmnoviaHostedArchiveParticipantDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OmnoviaHostedArchiveParticipantDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OmnoviaHostedArchiveParticipantDataSourceActionList

	/// <summary>
	/// Supports the OmnoviaHostedArchiveParticipantDataSourceDesigner class.
	/// </summary>
	internal class OmnoviaHostedArchiveParticipantDataSourceActionList : DesignerActionList
	{
		private OmnoviaHostedArchiveParticipantDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OmnoviaHostedArchiveParticipantDataSourceActionList(OmnoviaHostedArchiveParticipantDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OmnoviaHostedArchiveParticipantSelectMethod SelectMethod
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

	#endregion OmnoviaHostedArchiveParticipantDataSourceActionList
	
	#endregion OmnoviaHostedArchiveParticipantDataSourceDesigner
	
	#region OmnoviaHostedArchiveParticipantSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OmnoviaHostedArchiveParticipantDataSource.SelectMethod property.
	/// </summary>
	public enum OmnoviaHostedArchiveParticipantSelectMethod
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
		GetById
	}
	
	#endregion OmnoviaHostedArchiveParticipantSelectMethod

	#region OmnoviaHostedArchiveParticipantFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantFilter : SqlFilter<OmnoviaHostedArchiveParticipantColumn>
	{
	}
	
	#endregion OmnoviaHostedArchiveParticipantFilter

	#region OmnoviaHostedArchiveParticipantExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantExpressionBuilder : SqlExpressionBuilder<OmnoviaHostedArchiveParticipantColumn>
	{
	}
	
	#endregion OmnoviaHostedArchiveParticipantExpressionBuilder	

	#region OmnoviaHostedArchiveParticipantProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OmnoviaHostedArchiveParticipantChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantProperty : ChildEntityProperty<OmnoviaHostedArchiveParticipantChildEntityTypes>
	{
	}
	
	#endregion OmnoviaHostedArchiveParticipantProperty
}

