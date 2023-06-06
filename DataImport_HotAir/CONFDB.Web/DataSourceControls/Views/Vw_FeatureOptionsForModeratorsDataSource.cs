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
	/// Represents the DataRepository.Vw_FeatureOptionsForModeratorsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_FeatureOptionsForModeratorsDataSourceDesigner))]
	public class Vw_FeatureOptionsForModeratorsDataSource : ReadOnlyDataSource<Vw_FeatureOptionsForModerators>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsDataSource class.
		/// </summary>
		public Vw_FeatureOptionsForModeratorsDataSource() : base(new Vw_FeatureOptionsForModeratorsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_FeatureOptionsForModeratorsDataSourceView used by the Vw_FeatureOptionsForModeratorsDataSource.
		/// </summary>
		protected Vw_FeatureOptionsForModeratorsDataSourceView Vw_FeatureOptionsForModeratorsView
		{
			get { return ( View as Vw_FeatureOptionsForModeratorsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_FeatureOptionsForModeratorsDataSourceView class that is to be
		/// used by the Vw_FeatureOptionsForModeratorsDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_FeatureOptionsForModeratorsDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_FeatureOptionsForModerators, Object> GetNewDataSourceView()
		{
			return new Vw_FeatureOptionsForModeratorsDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_FeatureOptionsForModeratorsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_FeatureOptionsForModeratorsDataSourceView : ReadOnlyDataSourceView<Vw_FeatureOptionsForModerators>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_FeatureOptionsForModeratorsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_FeatureOptionsForModeratorsDataSourceView(Vw_FeatureOptionsForModeratorsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_FeatureOptionsForModeratorsDataSource Vw_FeatureOptionsForModeratorsOwner
		{
			get { return Owner as Vw_FeatureOptionsForModeratorsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_FeatureOptionsForModeratorsService Vw_FeatureOptionsForModeratorsProvider
		{
			get { return Provider as Vw_FeatureOptionsForModeratorsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_FeatureOptionsForModeratorsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_FeatureOptionsForModeratorsDataSource class.
	/// </summary>
	public class Vw_FeatureOptionsForModeratorsDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_FeatureOptionsForModerators>
	{
	}

	#endregion Vw_FeatureOptionsForModeratorsDataSourceDesigner

	#region Vw_FeatureOptionsForModeratorsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsFilter : SqlFilter<Vw_FeatureOptionsForModeratorsColumn>
	{
	}

	#endregion Vw_FeatureOptionsForModeratorsFilter

	#region Vw_FeatureOptionsForModeratorsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsExpressionBuilder : SqlExpressionBuilder<Vw_FeatureOptionsForModeratorsColumn>
	{
	}
	
	#endregion Vw_FeatureOptionsForModeratorsExpressionBuilder		
}

