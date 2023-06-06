﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'OmnoviaHostedArchiveParticipant' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IOmnoviaHostedArchiveParticipant 
	{
		/// <summary>			
		/// id : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "OmnoviaHostedArchiveParticipant"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// HostedArchiveID : 
		/// </summary>
		System.Int32  HostedArchiveId  { get; set; }
		
		/// <summary>
		/// Firstname : 
		/// </summary>
		System.String  Firstname  { get; set; }
		
		/// <summary>
		/// Lastname : 
		/// </summary>
		System.String  Lastname  { get; set; }
		
		/// <summary>
		/// Company : 
		/// </summary>
		System.String  Company  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
		
		/// <summary>
		/// created : 
		/// </summary>
		System.DateTime?  Created  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

