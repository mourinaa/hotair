﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'BridgeRequest' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IBridgeRequest 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "BridgeRequest"</remarks>
		System.Guid Id { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Guid OriginalId { get; set; }
			
		
		
		/// <summary>
		/// ModeratorID : 
		/// </summary>
		System.Int32  ModeratorId  { get; set; }
		
		/// <summary>
		/// TransTimeStamp : 
		/// </summary>
		System.DateTime  TransTimeStamp  { get; set; }
		
		/// <summary>
		/// ProcessFlag : 
		/// </summary>
		System.String  ProcessFlag  { get; set; }
		
		/// <summary>
		/// BridgeRequestTypeID : 
		/// </summary>
		System.Int32?  BridgeRequestTypeId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


