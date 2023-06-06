
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
	/// An component type implementation of the 'vw_ConferenceCallList_Unique' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class Vw_ConferenceCallList_UniqueService : CONFDB.Services.Vw_ConferenceCallList_UniqueServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueService class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueService() : base()
		{
		}
		
	}//End Class


} // end namespace
