﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'AccountManager' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAccountManager 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "AccountManager"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		System.String  WholesalerId  { get; set; }
		
		/// <summary>
		/// FullName : 
		/// </summary>
		System.String  FullName  { get; set; }
		
		/// <summary>
		/// EmailAddress : 
		/// </summary>
		System.String  EmailAddress  { get; set; }
		
		/// <summary>
		/// Enabled : 
		/// </summary>
		System.Boolean  Enabled  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _customerAccountManagerId
		/// </summary>	
		TList<Customer> CustomerCollection {  get;  set;}	

		#endregion Data Properties

	}
}


