﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'RecordingParticipantUsage' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IRecordingParticipantUsage 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "RecordingParticipantUsage"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// RecordingID : 
		/// </summary>
		System.Int32  RecordingId  { get; set; }
		
		/// <summary>
		/// ParticipantName : 
		/// </summary>
		System.String  ParticipantName  { get; set; }
		
		/// <summary>
		/// ParticipantCompanyName : 
		/// </summary>
		System.String  ParticipantCompanyName  { get; set; }
		
		/// <summary>
		/// ParticipantEmail : 
		/// </summary>
		System.String  ParticipantEmail  { get; set; }
		
		/// <summary>
		/// DownloadDate : 
		/// </summary>
		System.DateTime  DownloadDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


