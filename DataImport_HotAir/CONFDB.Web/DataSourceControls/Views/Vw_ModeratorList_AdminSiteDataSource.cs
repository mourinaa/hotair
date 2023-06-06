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
	/// Represents the DataRepository.Vw_ModeratorList_AdminSiteProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_ModeratorList_AdminSiteDataSourceDesigner))]
	public class Vw_ModeratorList_AdminSiteDataSource : ReadOnlyDataSource<Vw_ModeratorList_AdminSite>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteDataSource class.
		/// </summary>
		public Vw_ModeratorList_AdminSiteDataSource() : base(new Vw_ModeratorList_AdminSiteService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_ModeratorList_AdminSiteDataSourceView used by the Vw_ModeratorList_AdminSiteDataSource.
		/// </summary>
		protected Vw_ModeratorList_AdminSiteDataSourceView Vw_ModeratorList_AdminSiteView
		{
			get { return ( View as Vw_ModeratorList_AdminSiteDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_ModeratorList_AdminSiteDataSourceView class that is to be
		/// used by the Vw_ModeratorList_AdminSiteDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_ModeratorList_AdminSiteDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_ModeratorList_AdminSite, Object> GetNewDataSourceView()
		{
			return new Vw_ModeratorList_AdminSiteDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_ModeratorList_AdminSiteDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_ModeratorList_AdminSiteDataSourceView : ReadOnlyDataSourceView<Vw_ModeratorList_AdminSite>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_ModeratorList_AdminSiteDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_ModeratorList_AdminSiteDataSourceView(Vw_ModeratorList_AdminSiteDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_ModeratorList_AdminSiteDataSource Vw_ModeratorList_AdminSiteOwner
		{
			get { return Owner as Vw_ModeratorList_AdminSiteDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_ModeratorList_AdminSiteService Vw_ModeratorList_AdminSiteProvider
		{
			get { return Provider as Vw_ModeratorList_AdminSiteService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_ModeratorList_AdminSiteDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_ModeratorList_AdminSiteDataSource class.
	/// </summary>
	public class Vw_ModeratorList_AdminSiteDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_ModeratorList_AdminSite>
	{
	}

	#endregion Vw_ModeratorList_AdminSiteDataSourceDesigner

	#region Vw_ModeratorList_AdminSiteFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteFilter : SqlFilter<Vw_ModeratorList_AdminSiteColumn>
	{
	}

	#endregion Vw_ModeratorList_AdminSiteFilter

	#region Vw_ModeratorList_AdminSiteExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteExpressionBuilder : SqlExpressionBuilder<Vw_ModeratorList_AdminSiteColumn>
	{
	}
	
	#endregion Vw_ModeratorList_AdminSiteExpressionBuilder		
}

