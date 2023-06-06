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
	/// Represents the DataRepository.Vw_ModeratorListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_ModeratorListDataSourceDesigner))]
	public class Vw_ModeratorListDataSource : ReadOnlyDataSource<Vw_ModeratorList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListDataSource class.
		/// </summary>
		public Vw_ModeratorListDataSource() : base(new Vw_ModeratorListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_ModeratorListDataSourceView used by the Vw_ModeratorListDataSource.
		/// </summary>
		protected Vw_ModeratorListDataSourceView Vw_ModeratorListView
		{
			get { return ( View as Vw_ModeratorListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_ModeratorListDataSourceView class that is to be
		/// used by the Vw_ModeratorListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_ModeratorListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_ModeratorList, Object> GetNewDataSourceView()
		{
			return new Vw_ModeratorListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_ModeratorListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_ModeratorListDataSourceView : ReadOnlyDataSourceView<Vw_ModeratorList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_ModeratorListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_ModeratorListDataSourceView(Vw_ModeratorListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_ModeratorListDataSource Vw_ModeratorListOwner
		{
			get { return Owner as Vw_ModeratorListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_ModeratorListService Vw_ModeratorListProvider
		{
			get { return Provider as Vw_ModeratorListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_ModeratorListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_ModeratorListDataSource class.
	/// </summary>
	public class Vw_ModeratorListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_ModeratorList>
	{
	}

	#endregion Vw_ModeratorListDataSourceDesigner

	#region Vw_ModeratorListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListFilter : SqlFilter<Vw_ModeratorListColumn>
	{
	}

	#endregion Vw_ModeratorListFilter

	#region Vw_ModeratorListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListExpressionBuilder : SqlExpressionBuilder<Vw_ModeratorListColumn>
	{
	}
	
	#endregion Vw_ModeratorListExpressionBuilder		
}

