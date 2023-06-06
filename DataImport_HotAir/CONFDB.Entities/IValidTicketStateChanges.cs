﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'ValidTicketStateChanges' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IValidTicketStateChanges 
	{
		/// <summary>			
		/// FromStatusID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ValidTicketStateChanges"</remarks>
		System.Int32 FromStatusId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalFromStatusId { get; set; }
			
		/// <summary>			
		/// ToStatusID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ValidTicketStateChanges"</remarks>
		System.Int32 ToStatusId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalToStatusId { get; set; }
			
		
		
		/// <summary>
		/// Reason : 
		/// </summary>
		System.String  Reason  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

