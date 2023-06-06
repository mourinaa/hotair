﻿using System;
using System.ComponentModel;

namespace CONFDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'Moderator_Feature' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IModerator_Feature 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Moderator_Feature"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// ModeratorID : 
		/// </summary>
		System.Int32  ModeratorId  { get; set; }
		
		/// <summary>
		/// FeatureID : 
		/// </summary>
		System.Int32  FeatureId  { get; set; }
		
		/// <summary>
		/// FeatureOptionID : 
		/// </summary>
		System.Int32  FeatureOptionId  { get; set; }
		
		/// <summary>
		/// Enabled : 
		/// </summary>
		System.Boolean  Enabled  { get; set; }
		
		/// <summary>
		/// FeatureOptionValue : 
		/// </summary>
		System.String  FeatureOptionValue  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

