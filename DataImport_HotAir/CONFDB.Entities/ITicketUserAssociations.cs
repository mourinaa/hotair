﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'TicketUserAssociations' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITicketUserAssociations 
	{
		/// <summary>			
		/// UserID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TicketUserAssociations"</remarks>
		System.Int32 UserId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalUserId { get; set; }
			
		/// <summary>			
		/// TicketUserID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TicketUserAssociations"</remarks>
		System.Int32 TicketUserId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalTicketUserId { get; set; }
			
		
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

