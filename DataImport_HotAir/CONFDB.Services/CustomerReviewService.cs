	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using CONFDB.Entities;
using CONFDB.Entities.Validation;

using CONFDB.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace CONFDB.Services
{		
	
	///<summary>
	/// An component type implementation of the 'CustomerReview' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CustomerReviewService : CONFDB.Services.CustomerReviewServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the CustomerReviewService class.
		/// </summary>
		public CustomerReviewService() : base()
		{
		}
		
	}//End Class


} // end namespace
