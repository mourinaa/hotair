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
	/// Represents the DataRepository.Vw_UserListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_UserListDataSourceDesigner))]
	public class Vw_UserListDataSource : ReadOnlyDataSource<Vw_UserList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListDataSource class.
		/// </summary>
		public Vw_UserListDataSource() : base(new Vw_UserListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_UserListDataSourceView used by the Vw_UserListDataSource.
		/// </summary>
		protected Vw_UserListDataSourceView Vw_UserListView
		{
			get { return ( View as Vw_UserListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_UserListDataSourceView class that is to be
		/// used by the Vw_UserListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_UserListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_UserList, Object> GetNewDataSourceView()
		{
			return new Vw_UserListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_UserListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_UserListDataSourceView : ReadOnlyDataSourceView<Vw_UserList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_UserListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_UserListDataSourceView(Vw_UserListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_UserListDataSource Vw_UserListOwner
		{
			get { return Owner as Vw_UserListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_UserListService Vw_UserListProvider
		{
			get { return Provider as Vw_UserListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_UserListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_UserListDataSource class.
	/// </summary>
	public class Vw_UserListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_UserList>
	{
	}

	#endregion Vw_UserListDataSourceDesigner

	#region Vw_UserListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListFilter : SqlFilter<Vw_UserListColumn>
	{
	}

	#endregion Vw_UserListFilter

	#region Vw_UserListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListExpressionBuilder : SqlExpressionBuilder<Vw_UserListColumn>
	{
	}
	
	#endregion Vw_UserListExpressionBuilder		
}

