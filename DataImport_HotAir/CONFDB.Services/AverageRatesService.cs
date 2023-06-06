	

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
	/// An component type implementation of the 'AverageRates' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AverageRatesService : CONFDB.Services.AverageRatesServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the AverageRatesService class.
		/// </summary>
		public AverageRatesService() : base()
		{
		}
		
	}//End Class


} // end namespace
