	

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
	/// An component type implementation of the 'tempCodeChanges' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class TempCodeChangesService : CONFDB.Services.TempCodeChangesServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the TempCodeChangesService class.
		/// </summary>
		public TempCodeChangesService() : base()
		{
		}
		
	}//End Class


} // end namespace
