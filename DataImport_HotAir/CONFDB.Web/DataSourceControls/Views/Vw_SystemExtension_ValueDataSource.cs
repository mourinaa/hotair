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
	/// Represents the DataRepository.Vw_SystemExtension_ValueProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_SystemExtension_ValueDataSourceDesigner))]
	public class Vw_SystemExtension_ValueDataSource : ReadOnlyDataSource<Vw_SystemExtension_Value>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueDataSource class.
		/// </summary>
		public Vw_SystemExtension_ValueDataSource() : base(new Vw_SystemExtension_ValueService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_SystemExtension_ValueDataSourceView used by the Vw_SystemExtension_ValueDataSource.
		/// </summary>
		protected Vw_SystemExtension_ValueDataSourceView Vw_SystemExtension_ValueView
		{
			get { return ( View as Vw_SystemExtension_ValueDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_SystemExtension_ValueDataSourceView class that is to be
		/// used by the Vw_SystemExtension_ValueDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_SystemExtension_ValueDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_SystemExtension_Value, Object> GetNewDataSourceView()
		{
			return new Vw_SystemExtension_ValueDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_SystemExtension_ValueDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_SystemExtension_ValueDataSourceView : ReadOnlyDataSourceView<Vw_SystemExtension_Value>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_SystemExtension_ValueDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_SystemExtension_ValueDataSourceView(Vw_SystemExtension_ValueDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_SystemExtension_ValueDataSource Vw_SystemExtension_ValueOwner
		{
			get { return Owner as Vw_SystemExtension_ValueDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_SystemExtension_ValueService Vw_SystemExtension_ValueProvider
		{
			get { return Provider as Vw_SystemExtension_ValueService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_SystemExtension_ValueDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_SystemExtension_ValueDataSource class.
	/// </summary>
	public class Vw_SystemExtension_ValueDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_SystemExtension_Value>
	{
	}

	#endregion Vw_SystemExtension_ValueDataSourceDesigner

	#region Vw_SystemExtension_ValueFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueFilter : SqlFilter<Vw_SystemExtension_ValueColumn>
	{
	}

	#endregion Vw_SystemExtension_ValueFilter

	#region Vw_SystemExtension_ValueExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueExpressionBuilder : SqlExpressionBuilder<Vw_SystemExtension_ValueColumn>
	{
	}
	
	#endregion Vw_SystemExtension_ValueExpressionBuilder		
}

