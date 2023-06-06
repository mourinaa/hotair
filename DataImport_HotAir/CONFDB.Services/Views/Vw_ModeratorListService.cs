
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
	/// An component type implementation of the 'vw_ModeratorList' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class Vw_ModeratorListService : CONFDB.Services.Vw_ModeratorListServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListService class.
		/// </summary>
		public Vw_ModeratorListService() : base()
		{
		}
		
	}//End Class


} // end namespace
