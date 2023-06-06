﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'Participant' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IParticipant 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Participant"</remarks>
		System.Int32 Id { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalId { get; set; }
			
		
		
		/// <summary>
		/// ParticipantListID : 
		/// </summary>
		System.Int32  ParticipantListId  { get; set; }
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// CompanyName : 
		/// </summary>
		System.String  CompanyName  { get; set; }
		
		/// <summary>
		/// EmailAddress : 
		/// </summary>
		System.String  EmailAddress  { get; set; }
		
		/// <summary>
		/// PhoneNumber : 
		/// </summary>
		System.String  PhoneNumber  { get; set; }
		
		/// <summary>
		/// PIN : 
		/// </summary>
		System.String  Pin  { get; set; }
		
		/// <summary>
		/// UserName : 
		/// </summary>
		System.String  UserName  { get; set; }
		
		/// <summary>
		/// Password : 
		/// </summary>
		System.String  Password  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


