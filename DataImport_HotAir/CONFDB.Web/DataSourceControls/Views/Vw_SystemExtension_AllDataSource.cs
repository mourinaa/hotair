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
	/// Represents the DataRepository.Vw_SystemExtension_AllProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_SystemExtension_AllDataSourceDesigner))]
	public class Vw_SystemExtension_AllDataSource : ReadOnlyDataSource<Vw_SystemExtension_All>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllDataSource class.
		/// </summary>
		public Vw_SystemExtension_AllDataSource() : base(new Vw_SystemExtension_AllService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_SystemExtension_AllDataSourceView used by the Vw_SystemExtension_AllDataSource.
		/// </summary>
		protected Vw_SystemExtension_AllDataSourceView Vw_SystemExtension_AllView
		{
			get { return ( View as Vw_SystemExtension_AllDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_SystemExtension_AllDataSourceView class that is to be
		/// used by the Vw_SystemExtension_AllDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_SystemExtension_AllDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_SystemExtension_All, Object> GetNewDataSourceView()
		{
			return new Vw_SystemExtension_AllDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_SystemExtension_AllDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_SystemExtension_AllDataSourceView : ReadOnlyDataSourceView<Vw_SystemExtension_All>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_SystemExtension_AllDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_SystemExtension_AllDataSourceView(Vw_SystemExtension_AllDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_SystemExtension_AllDataSource Vw_SystemExtension_AllOwner
		{
			get { return Owner as Vw_SystemExtension_AllDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_SystemExtension_AllService Vw_SystemExtension_AllProvider
		{
			get { return Provider as Vw_SystemExtension_AllService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_SystemExtension_AllDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_SystemExtension_AllDataSource class.
	/// </summary>
	public class Vw_SystemExtension_AllDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_SystemExtension_All>
	{
	}

	#endregion Vw_SystemExtension_AllDataSourceDesigner

	#region Vw_SystemExtension_AllFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllFilter : SqlFilter<Vw_SystemExtension_AllColumn>
	{
	}

	#endregion Vw_SystemExtension_AllFilter

	#region Vw_SystemExtension_AllExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllExpressionBuilder : SqlExpressionBuilder<Vw_SystemExtension_AllColumn>
	{
	}
	
	#endregion Vw_SystemExtension_AllExpressionBuilder		
}

