	

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
	/// An component type implementation of the 'CustomerTransactionImport' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CustomerTransactionImportService : CONFDB.Services.CustomerTransactionImportServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportService class.
		/// </summary>
		public CustomerTransactionImportService() : base()
		{
		}
		
	}//End Class


} // end namespace
