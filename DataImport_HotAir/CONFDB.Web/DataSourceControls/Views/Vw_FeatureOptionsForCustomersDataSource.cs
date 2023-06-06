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
	/// Represents the DataRepository.Vw_FeatureOptionsForCustomersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_FeatureOptionsForCustomersDataSourceDesigner))]
	public class Vw_FeatureOptionsForCustomersDataSource : ReadOnlyDataSource<Vw_FeatureOptionsForCustomers>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersDataSource class.
		/// </summary>
		public Vw_FeatureOptionsForCustomersDataSource() : base(new Vw_FeatureOptionsForCustomersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_FeatureOptionsForCustomersDataSourceView used by the Vw_FeatureOptionsForCustomersDataSource.
		/// </summary>
		protected Vw_FeatureOptionsForCustomersDataSourceView Vw_FeatureOptionsForCustomersView
		{
			get { return ( View as Vw_FeatureOptionsForCustomersDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_FeatureOptionsForCustomersDataSourceView class that is to be
		/// used by the Vw_FeatureOptionsForCustomersDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_FeatureOptionsForCustomersDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_FeatureOptionsForCustomers, Object> GetNewDataSourceView()
		{
			return new Vw_FeatureOptionsForCustomersDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_FeatureOptionsForCustomersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_FeatureOptionsForCustomersDataSourceView : ReadOnlyDataSourceView<Vw_FeatureOptionsForCustomers>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForCustomersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_FeatureOptionsForCustomersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_FeatureOptionsForCustomersDataSourceView(Vw_FeatureOptionsForCustomersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_FeatureOptionsForCustomersDataSource Vw_FeatureOptionsForCustomersOwner
		{
			get { return Owner as Vw_FeatureOptionsForCustomersDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_FeatureOptionsForCustomersService Vw_FeatureOptionsForCustomersProvider
		{
			get { return Provider as Vw_FeatureOptionsForCustomersService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_FeatureOptionsForCustomersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_FeatureOptionsForCustomersDataSource class.
	/// </summary>
	public class Vw_FeatureOptionsForCustomersDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_FeatureOptionsForCustomers>
	{
	}

	#endregion Vw_FeatureOptionsForCustomersDataSourceDesigner

	#region Vw_FeatureOptionsForCustomersFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForCustomers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForCustomersFilter : SqlFilter<Vw_FeatureOptionsForCustomersColumn>
	{
	}

	#endregion Vw_FeatureOptionsForCustomersFilter

	#region Vw_FeatureOptionsForCustomersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForCustomers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForCustomersExpressionBuilder : SqlExpressionBuilder<Vw_FeatureOptionsForCustomersColumn>
	{
	}
	
	#endregion Vw_FeatureOptionsForCustomersExpressionBuilder		
}

