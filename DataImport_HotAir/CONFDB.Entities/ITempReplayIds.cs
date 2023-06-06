﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'TempReplayIDs' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITempReplayIds 
	{
		/// <summary>			
		/// ReplayID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TempReplayIDs"</remarks>
		System.Int32 ReplayId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalReplayId { get; set; }
			
		
		
		/// <summary>
		/// AuxiliaryCID : 
		/// </summary>
		System.String  AuxiliaryCid  { get; set; }
		
		/// <summary>
		/// BillingDuration : 
		/// </summary>
		System.Int16?  BillingDuration  { get; set; }
		
		/// <summary>
		/// Notes : 
		/// </summary>
		System.String  Notes  { get; set; }
		
		/// <summary>
		/// Enabled : 
		/// </summary>
		System.Boolean  Enabled  { get; set; }
		
		/// <summary>
		/// ModifiedBy : 
		/// </summary>
		System.String  ModifiedBy  { get; set; }
		
		/// <summary>
		/// LastModifiedDate : 
		/// </summary>
		System.DateTime  LastModifiedDate  { get; set; }
		
		/// <summary>
		/// CreatedDate : 
		/// </summary>
		System.DateTime  CreatedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

