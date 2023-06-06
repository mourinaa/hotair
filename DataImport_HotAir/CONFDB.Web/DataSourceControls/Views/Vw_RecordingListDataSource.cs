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
	/// Represents the DataRepository.Vw_RecordingListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_RecordingListDataSourceDesigner))]
	public class Vw_RecordingListDataSource : ReadOnlyDataSource<Vw_RecordingList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListDataSource class.
		/// </summary>
		public Vw_RecordingListDataSource() : base(new Vw_RecordingListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_RecordingListDataSourceView used by the Vw_RecordingListDataSource.
		/// </summary>
		protected Vw_RecordingListDataSourceView Vw_RecordingListView
		{
			get { return ( View as Vw_RecordingListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_RecordingListDataSourceView class that is to be
		/// used by the Vw_RecordingListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_RecordingListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_RecordingList, Object> GetNewDataSourceView()
		{
			return new Vw_RecordingListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_RecordingListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_RecordingListDataSourceView : ReadOnlyDataSourceView<Vw_RecordingList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_RecordingListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_RecordingListDataSourceView(Vw_RecordingListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_RecordingListDataSource Vw_RecordingListOwner
		{
			get { return Owner as Vw_RecordingListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_RecordingListService Vw_RecordingListProvider
		{
			get { return Provider as Vw_RecordingListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_RecordingListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_RecordingListDataSource class.
	/// </summary>
	public class Vw_RecordingListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_RecordingList>
	{
	}

	#endregion Vw_RecordingListDataSourceDesigner

	#region Vw_RecordingListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListFilter : SqlFilter<Vw_RecordingListColumn>
	{
	}

	#endregion Vw_RecordingListFilter

	#region Vw_RecordingListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListExpressionBuilder : SqlExpressionBuilder<Vw_RecordingListColumn>
	{
	}
	
	#endregion Vw_RecordingListExpressionBuilder		
}

