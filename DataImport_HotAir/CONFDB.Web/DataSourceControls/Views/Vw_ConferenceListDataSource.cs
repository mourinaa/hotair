#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using CONFDB.Entities;
using CONFDB.Data;
using CONFDB.Data.Bases;
using CONFDB.Services;
#endregion

namespace CONFDB.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.Vw_ConferenceListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_ConferenceListDataSourceDesigner))]
	public class Vw_ConferenceListDataSource : ReadOnlyDataSource<Vw_ConferenceList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListDataSource class.
		/// </summary>
		public Vw_ConferenceListDataSource() : base(new Vw_ConferenceListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_ConferenceListDataSourceView used by the Vw_ConferenceListDataSource.
		/// </summary>
		protected Vw_ConferenceListDataSourceView Vw_ConferenceListView
		{
			get { return ( View as Vw_ConferenceListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_ConferenceListDataSourceView class that is to be
		/// used by the Vw_ConferenceListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_ConferenceListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_ConferenceList, Object> GetNewDataSourceView()
		{
			return new Vw_ConferenceListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_ConferenceListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_ConferenceListDataSourceView : ReadOnlyDataSourceView<Vw_ConferenceList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_ConferenceListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_ConferenceListDataSourceView(Vw_ConferenceListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_ConferenceListDataSource Vw_ConferenceListOwner
		{
			get { return Owner as Vw_ConferenceListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_ConferenceListService Vw_ConferenceListProvider
		{
			get { return Provider as Vw_ConferenceListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_ConferenceListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_ConferenceListDataSource class.
	/// </summary>
	public class Vw_ConferenceListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_ConferenceList>
	{
	}

	#endregion Vw_ConferenceListDataSourceDesigner

	#region Vw_ConferenceListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListFilter : SqlFilter<Vw_ConferenceListColumn>
	{
	}

	#endregion Vw_ConferenceListFilter

	#region Vw_ConferenceListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListExpressionBuilder : SqlExpressionBuilder<Vw_ConferenceListColumn>
	{
	}
	
	#endregion Vw_ConferenceListExpressionBuilder		
}

