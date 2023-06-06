	

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
	/// An component type implementation of the 'Wholesaler_Product_Feature' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class Wholesaler_Product_FeatureService : CONFDB.Services.Wholesaler_Product_FeatureServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the Wholesaler_Product_FeatureService class.
		/// </summary>
		public Wholesaler_Product_FeatureService() : base()
		{
		}
		
	}//End Class


} // end namespace
