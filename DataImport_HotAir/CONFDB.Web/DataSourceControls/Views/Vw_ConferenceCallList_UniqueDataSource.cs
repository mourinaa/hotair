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
	/// Represents the DataRepository.Vw_ConferenceCallList_UniqueProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_ConferenceCallList_UniqueDataSourceDesigner))]
	public class Vw_ConferenceCallList_UniqueDataSource : ReadOnlyDataSource<Vw_ConferenceCallList_Unique>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueDataSource class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueDataSource() : base(new Vw_ConferenceCallList_UniqueService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_ConferenceCallList_UniqueDataSourceView used by the Vw_ConferenceCallList_UniqueDataSource.
		/// </summary>
		protected Vw_ConferenceCallList_UniqueDataSourceView Vw_ConferenceCallList_UniqueView
		{
			get { return ( View as Vw_ConferenceCallList_UniqueDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_ConferenceCallList_UniqueDataSourceView class that is to be
		/// used by the Vw_ConferenceCallList_UniqueDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_ConferenceCallList_UniqueDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_ConferenceCallList_Unique, Object> GetNewDataSourceView()
		{
			return new Vw_ConferenceCallList_UniqueDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_ConferenceCallList_UniqueDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_ConferenceCallList_UniqueDataSourceView : ReadOnlyDataSourceView<Vw_ConferenceCallList_Unique>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_ConferenceCallList_UniqueDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_ConferenceCallList_UniqueDataSourceView(Vw_ConferenceCallList_UniqueDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_ConferenceCallList_UniqueDataSource Vw_ConferenceCallList_UniqueOwner
		{
			get { return Owner as Vw_ConferenceCallList_UniqueDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_ConferenceCallList_UniqueService Vw_ConferenceCallList_UniqueProvider
		{
			get { return Provider as Vw_ConferenceCallList_UniqueService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_ConferenceCallList_UniqueDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_ConferenceCallList_UniqueDataSource class.
	/// </summary>
	public class Vw_ConferenceCallList_UniqueDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_ConferenceCallList_Unique>
	{
	}

	#endregion Vw_ConferenceCallList_UniqueDataSourceDesigner

	#region Vw_ConferenceCallList_UniqueFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueFilter : SqlFilter<Vw_ConferenceCallList_UniqueColumn>
	{
	}

	#endregion Vw_ConferenceCallList_UniqueFilter

	#region Vw_ConferenceCallList_UniqueExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueExpressionBuilder : SqlExpressionBuilder<Vw_ConferenceCallList_UniqueColumn>
	{
	}
	
	#endregion Vw_ConferenceCallList_UniqueExpressionBuilder		
}

