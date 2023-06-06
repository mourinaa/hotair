	

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
	/// An component type implementation of the 'TicketCategory' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class TicketCategoryService : CONFDB.Services.TicketCategoryServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the TicketCategoryService class.
		/// </summary>
		public TicketCategoryService() : base()
		{
		}
		
	}//End Class


} // end namespace
