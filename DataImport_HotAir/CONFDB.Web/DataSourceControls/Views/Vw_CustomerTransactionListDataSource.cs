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
	/// Represents the DataRepository.Vw_CustomerTransactionListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_CustomerTransactionListDataSourceDesigner))]
	public class Vw_CustomerTransactionListDataSource : ReadOnlyDataSource<Vw_CustomerTransactionList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListDataSource class.
		/// </summary>
		public Vw_CustomerTransactionListDataSource() : base(new Vw_CustomerTransactionListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_CustomerTransactionListDataSourceView used by the Vw_CustomerTransactionListDataSource.
		/// </summary>
		protected Vw_CustomerTransactionListDataSourceView Vw_CustomerTransactionListView
		{
			get { return ( View as Vw_CustomerTransactionListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_CustomerTransactionListDataSourceView class that is to be
		/// used by the Vw_CustomerTransactionListDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_CustomerTransactionListDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_CustomerTransactionList, Object> GetNewDataSourceView()
		{
			return new Vw_CustomerTransactionListDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_CustomerTransactionListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_CustomerTransactionListDataSourceView : ReadOnlyDataSourceView<Vw_CustomerTransactionList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_CustomerTransactionListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_CustomerTransactionListDataSourceView(Vw_CustomerTransactionListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_CustomerTransactionListDataSource Vw_CustomerTransactionListOwner
		{
			get { return Owner as Vw_CustomerTransactionListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_CustomerTransactionListService Vw_CustomerTransactionListProvider
		{
			get { return Provider as Vw_CustomerTransactionListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_CustomerTransactionListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_CustomerTransactionListDataSource class.
	/// </summary>
	public class Vw_CustomerTransactionListDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_CustomerTransactionList>
	{
	}

	#endregion Vw_CustomerTransactionListDataSourceDesigner

	#region Vw_CustomerTransactionListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListFilter : SqlFilter<Vw_CustomerTransactionListColumn>
	{
	}

	#endregion Vw_CustomerTransactionListFilter

	#region Vw_CustomerTransactionListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListExpressionBuilder : SqlExpressionBuilder<Vw_CustomerTransactionListColumn>
	{
	}
	
	#endregion Vw_CustomerTransactionListExpressionBuilder		
}

