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
	/// Represents the DataRepository.Vw_CustomerListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_CustomerListDataSourceDesigner))]
	public class Vw_CustomerListDataSource : ReadOnlyDataSource<Vw_CustomerList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListDataSource class.
		/// </summary>
		public Vw_CustomerListDataSource() : base(new Vw_CustomerListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_CustomerListDataSourceView used by the Vw_CustomerListDataSource.
		/// </summary>
		protected Vw_CustomerListDataSourceView Vw_CustomerListView
		{
			get { return ( View as Vw_CustomerListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_CustomerListDataSourceView class that is to be
		/// used by the Vw_CustomerListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_CustomerListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_CustomerList, Object> GetNewDataSourceView()
		{
			return new Vw_CustomerListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_CustomerListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_CustomerListDataSourceView : ReadOnlyDataSourceView<Vw_CustomerList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_CustomerListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_CustomerListDataSourceView(Vw_CustomerListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_CustomerListDataSource Vw_CustomerListOwner
		{
			get { return Owner as Vw_CustomerListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_CustomerListService Vw_CustomerListProvider
		{
			get { return Provider as Vw_CustomerListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_CustomerListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_CustomerListDataSource class.
	/// </summary>
	public class Vw_CustomerListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_CustomerList>
	{
	}

	#endregion Vw_CustomerListDataSourceDesigner

	#region Vw_CustomerListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListFilter : SqlFilter<Vw_CustomerListColumn>
	{
	}

	#endregion Vw_CustomerListFilter

	#region Vw_CustomerListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListExpressionBuilder : SqlExpressionBuilder<Vw_CustomerListColumn>
	{
	}
	
	#endregion Vw_CustomerListExpressionBuilder		
}

