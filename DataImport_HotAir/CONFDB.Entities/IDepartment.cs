﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'Department' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDepartment 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Department"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		System.String  WholesalerId  { get; set; }
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		System.Int32?  CustomerId  { get; set; }
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// ParentID : Used to point to a Parent Department record. This can be used to model Levels such as Regions with sub items or Cost Centers.
		/// </summary>
		System.Int32?  ParentId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _moderatorDepartmentId
		/// </summary>	
		TList<Moderator> ModeratorCollection {  get;  set;}	

		#endregion Data Properties

	}
}


