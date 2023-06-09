﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'ProductRateValue' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProductRateValue 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductRateValue"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// ProductRateID : 
		/// </summary>
		System.Int32  ProductRateId  { get; set; }
		
		/// <summary>
		/// SellRate : 
		/// </summary>
		System.Decimal  SellRate  { get; set; }
		
		/// <summary>
		/// SellRateCurrencyID : 
		/// </summary>
		System.String  SellRateCurrencyId  { get; set; }
		
		/// <summary>
		/// BuyRate : 
		/// </summary>
		System.Decimal  BuyRate  { get; set; }
		
		/// <summary>
		/// BuyRateCurrencyID : 
		/// </summary>
		System.String  BuyRateCurrencyId  { get; set; }
		
		/// <summary>
		/// DefaultOption : 
		/// </summary>
		System.Byte  DefaultOption  { get; set; }
		
		/// <summary>
		/// StartDate : 
		/// </summary>
		System.DateTime?  StartDate  { get; set; }
		
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		System.String  WholesalerId  { get; set; }
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		System.Int32?  CustomerId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


