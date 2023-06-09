﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'CustomerDocument' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICustomerDocument 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CustomerDocument"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		System.String  WholesalerId  { get; set; }
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		System.Int32  CustomerId  { get; set; }
		
		/// <summary>
		/// PriCustomerNumber : 
		/// </summary>
		System.String  PriCustomerNumber  { get; set; }
		
		/// <summary>
		/// DocumentDate : 
		/// </summary>
		System.DateTime  DocumentDate  { get; set; }
		
		/// <summary>
		/// DocumentTypeID : 
		/// </summary>
		System.Int32  DocumentTypeId  { get; set; }
		
		/// <summary>
		/// KBSize : 
		/// </summary>
		System.Int32  KbSize  { get; set; }
		
		/// <summary>
		/// DocumentDirectory : 
		/// </summary>
		System.String  DocumentDirectory  { get; set; }
		
		/// <summary>
		/// CreatedDate : 
		/// </summary>
		System.DateTime  CreatedDate  { get; set; }
		
		/// <summary>
		/// Notes : 
		/// </summary>
		System.String  Notes  { get; set; }
		
		/// <summary>
		/// LanguageID : 
		/// </summary>
		System.String  LanguageId  { get; set; }
		
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

		#endregion Data Properties

	}
}


