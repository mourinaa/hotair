﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'IRWholesaler' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IIrWholesaler 
	{
		/// <summary>			
		/// WholesalerID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "IRWholesaler"</remarks>
		System.String WholesalerId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalWholesalerId { get; set; }
			
		/// <summary>			
		/// LanguageID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "IRWholesaler"</remarks>
		System.String LanguageId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalLanguageId { get; set; }
			
		
		
		/// <summary>
		/// IRCustomerID : 
		/// </summary>
		System.String  IrCustomerId  { get; set; }
		
		/// <summary>
		/// LocalDNIS : 
		/// </summary>
		System.String  LocalDnis  { get; set; }
		
		/// <summary>
		/// LocalDialNumber : 
		/// </summary>
		System.String  LocalDialNumber  { get; set; }
		
		/// <summary>
		/// LocalAccessType : 
		/// </summary>
		System.Int32?  LocalAccessType  { get; set; }
		
		/// <summary>
		/// TollFreeDNIS : 
		/// </summary>
		System.String  TollFreeDnis  { get; set; }
		
		/// <summary>
		/// TollFreeDialNumber : 
		/// </summary>
		System.String  TollFreeDialNumber  { get; set; }
		
		/// <summary>
		/// TollFreeAccessType : 
		/// </summary>
		System.Int32?  TollFreeAccessType  { get; set; }
		
		/// <summary>
		/// InstantReplayURL : 
		/// </summary>
		System.String  InstantReplayUrl  { get; set; }
		
		/// <summary>
		/// StorageDuration : 
		/// </summary>
		System.Int16?  StorageDuration  { get; set; }
		
		/// <summary>
		/// InstantReplayLoginURL : 
		/// </summary>
		System.String  InstantReplayLoginUrl  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


