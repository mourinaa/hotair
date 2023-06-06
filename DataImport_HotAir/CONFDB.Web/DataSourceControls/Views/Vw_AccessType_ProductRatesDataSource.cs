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
	/// Represents the DataRepository.Vw_AccessType_ProductRatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_AccessType_ProductRatesDataSourceDesigner))]
	public class Vw_AccessType_ProductRatesDataSource : ReadOnlyDataSource<Vw_AccessType_ProductRates>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesDataSource class.
		/// </summary>
		public Vw_AccessType_ProductRatesDataSource() : base(new Vw_AccessType_ProductRatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_AccessType_ProductRatesDataSourceView used by the Vw_AccessType_ProductRatesDataSource.
		/// </summary>
		protected Vw_AccessType_ProductRatesDataSourceView Vw_AccessType_ProductRatesView
		{
			get { return ( View as Vw_AccessType_ProductRatesDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_AccessType_ProductRatesDataSourceView class that is to be
		/// used by the Vw_AccessType_ProductRatesDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_AccessType_ProductRatesDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_AccessType_ProductRates, Object> GetNewDataSourceView()
		{
			return new Vw_AccessType_ProductRatesDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_AccessType_ProductRatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_AccessType_ProductRatesDataSourceView : ReadOnlyDataSourceView<Vw_AccessType_ProductRates>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_AccessType_ProductRatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_AccessType_ProductRatesDataSourceView(Vw_AccessType_ProductRatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_AccessType_ProductRatesDataSource Vw_AccessType_ProductRatesOwner
		{
			get { return Owner as Vw_AccessType_ProductRatesDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_AccessType_ProductRatesService Vw_AccessType_ProductRatesProvider
		{
			get { return Provider as Vw_AccessType_ProductRatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_AccessType_ProductRatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_AccessType_ProductRatesDataSource class.
	/// </summary>
	public class Vw_AccessType_ProductRatesDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_AccessType_ProductRates>
	{
	}

	#endregion Vw_AccessType_ProductRatesDataSourceDesigner

	#region Vw_AccessType_ProductRatesFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesFilter : SqlFilter<Vw_AccessType_ProductRatesColumn>
	{
	}

	#endregion Vw_AccessType_ProductRatesFilter

	#region Vw_AccessType_ProductRatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesExpressionBuilder : SqlExpressionBuilder<Vw_AccessType_ProductRatesColumn>
	{
	}
	
	#endregion Vw_AccessType_ProductRatesExpressionBuilder		
}

