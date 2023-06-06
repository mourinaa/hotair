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
	/// Represents the DataRepository.Vw_SystemExtension_CustomerLabelProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(Vw_SystemExtension_CustomerLabelDataSourceDesigner))]
	public class Vw_SystemExtension_CustomerLabelDataSource : ReadOnlyDataSource<Vw_SystemExtension_CustomerLabel>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelDataSource class.
		/// </summary>
		public Vw_SystemExtension_CustomerLabelDataSource() : base(new Vw_SystemExtension_CustomerLabelService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Vw_SystemExtension_CustomerLabelDataSourceView used by the Vw_SystemExtension_CustomerLabelDataSource.
		/// </summary>
		protected Vw_SystemExtension_CustomerLabelDataSourceView Vw_SystemExtension_CustomerLabelView
		{
			get { return ( View as Vw_SystemExtension_CustomerLabelDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Vw_SystemExtension_CustomerLabelDataSourceView class that is to be
		/// used by the Vw_SystemExtension_CustomerLabelDataSource.
		/// </summary>
		/// <returns>An instance of the Vw_SystemExtension_CustomerLabelDataSourceView class.</returns>
		protected override BaseDataSourceView<Vw_SystemExtension_CustomerLabel, Object> GetNewDataSourceView()
		{
			return new Vw_SystemExtension_CustomerLabelDataSourceView(this, DefaultViewName);
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
	/// Supports the Vw_SystemExtension_CustomerLabelDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Vw_SystemExtension_CustomerLabelDataSourceView : ReadOnlyDataSourceView<Vw_SystemExtension_CustomerLabel>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Vw_SystemExtension_CustomerLabelDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Vw_SystemExtension_CustomerLabelDataSourceView(Vw_SystemExtension_CustomerLabelDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Vw_SystemExtension_CustomerLabelDataSource Vw_SystemExtension_CustomerLabelOwner
		{
			get { return Owner as Vw_SystemExtension_CustomerLabelDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Vw_SystemExtension_CustomerLabelService Vw_SystemExtension_CustomerLabelProvider
		{
			get { return Provider as Vw_SystemExtension_CustomerLabelService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region Vw_SystemExtension_CustomerLabelDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Vw_SystemExtension_CustomerLabelDataSource class.
	/// </summary>
	public class Vw_SystemExtension_CustomerLabelDataSourceDesigner : ReadOnlyDataSourceDesigner<Vw_SystemExtension_CustomerLabel>
	{
	}

	#endregion Vw_SystemExtension_CustomerLabelDataSourceDesigner

	#region Vw_SystemExtension_CustomerLabelFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelFilter : SqlFilter<Vw_SystemExtension_CustomerLabelColumn>
	{
	}

	#endregion Vw_SystemExtension_CustomerLabelFilter

	#region Vw_SystemExtension_CustomerLabelExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelExpressionBuilder : SqlExpressionBuilder<Vw_SystemExtension_CustomerLabelColumn>
	{
	}
	
	#endregion Vw_SystemExtension_CustomerLabelExpressionBuilder		
}

