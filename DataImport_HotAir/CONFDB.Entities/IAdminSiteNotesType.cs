﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'AdminSiteNotesType' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAdminSiteNotesType 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "AdminSiteNotesType"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		System.Int32?  DisplayOrder  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _adminSiteNotesAdminSiteNotesTypeId
		/// </summary>	
		TList<AdminSiteNotes> AdminSiteNotesCollection {  get;  set;}	

		#endregion Data Properties

	}
}


