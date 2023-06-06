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
	/// Represents the DataRepository.Vw_DefaultProductRatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_DefaultProductRatesDataSourceDesigner))]
	public class Vw_DefaultProductRatesDataSource : ReadOnlyDataSource<Vw_DefaultProductRates>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesDataSource class.
		/// </summary>
		public Vw_DefaultProductRatesDataSource() : base(new Vw_DefaultProductRatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_DefaultProductRatesDataSourceView used by the Vw_DefaultProductRatesDataSource.
		/// </summary>
		protected Vw_DefaultProductRatesDataSourceView Vw_DefaultProductRatesView
		{
			get { return ( View as Vw_DefaultProductRatesDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_DefaultProductRatesDataSourceView class that is to be
		/// used by the Vw_DefaultProductRatesDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_DefaultProductRatesDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_DefaultProductRates, Object> GetNewDataSourceView()
		{
			return new Vw_DefaultProductRatesDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_DefaultProductRatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_DefaultProductRatesDataSourceView : ReadOnlyDataSourceView<Vw_DefaultProductRates>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_DefaultProductRatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_DefaultProductRatesDataSourceView(Vw_DefaultProductRatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_DefaultProductRatesDataSource Vw_DefaultProductRatesOwner
		{
			get { return Owner as Vw_DefaultProductRatesDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_DefaultProductRatesService Vw_DefaultProductRatesProvider
		{
			get { return Provider as Vw_DefaultProductRatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_DefaultProductRatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_DefaultProductRatesDataSource class.
	/// </summary>
	public class Vw_DefaultProductRatesDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_DefaultProductRates>
	{
	}

	#endregion Vw_DefaultProductRatesDataSourceDesigner

	#region Vw_DefaultProductRatesFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesFilter : SqlFilter<Vw_DefaultProductRatesColumn>
	{
	}

	#endregion Vw_DefaultProductRatesFilter

	#region Vw_DefaultProductRatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesExpressionBuilder : SqlExpressionBuilder<Vw_DefaultProductRatesColumn>
	{
	}
	
	#endregion Vw_DefaultProductRatesExpressionBuilder		
}

