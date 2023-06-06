﻿/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Vw_ConferenceCallList_Unique.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace CONFDB.Entities
{
	///<summary>
	/// An object representation of the 'vw_ConferenceCallList_Unique' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("Vw_ConferenceCallList_UniqueBase")]
	public abstract partial class Vw_ConferenceCallList_UniqueBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// ModeratorID : 
		/// </summary>
		private System.Int32		  _moderatorId = (int)0;
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		private System.Int32?		  _customerId = (int)0;
		
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		private System.String		  _wholesalerId = null;
		
		/// <summary>
		/// ModeratorName : 
		/// </summary>
		private System.String		  _moderatorName = null;
		
		/// <summary>
		/// ConferenceStartTime : 
		/// </summary>
		private System.DateTime?		  _conferenceStartTime = DateTime.MinValue;
		
		/// <summary>
		/// UniqueConferenceID : 
		/// </summary>
		private System.String		  _uniqueConferenceId = null;
		
		/// <summary>
		/// NumberPeopleOnCall : 
		/// </summary>
		private System.Int32?		  _numberPeopleOnCall = (int)0;
		
		/// <summary>
		/// AuxiliaryConferenceID : 
		/// </summary>
		private System.String		  _auxiliaryConferenceId = null;
		
		/// <summary>
		/// ReferenceNumber : 
		/// </summary>
		private System.String		  _referenceNumber = null;
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;
		
		/// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized] 
		private bool suppressEntityEvents = false;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Vw_ConferenceCallList_UniqueBase"/> instance.
		///</summary>
		public Vw_ConferenceCallList_UniqueBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="Vw_ConferenceCallList_UniqueBase"/> instance.
		///</summary>
		///<param name="_moderatorId"></param>
		///<param name="_customerId"></param>
		///<param name="_wholesalerId"></param>
		///<param name="_moderatorName"></param>
		///<param name="_conferenceStartTime"></param>
		///<param name="_uniqueConferenceId"></param>
		///<param name="_numberPeopleOnCall"></param>
		///<param name="_auxiliaryConferenceId"></param>
		///<param name="_referenceNumber"></param>
		public Vw_ConferenceCallList_UniqueBase(System.Int32 _moderatorId, System.Int32? _customerId, System.String _wholesalerId, System.String _moderatorName, System.DateTime? _conferenceStartTime, System.String _uniqueConferenceId, System.Int32? _numberPeopleOnCall, System.String _auxiliaryConferenceId, System.String _referenceNumber)
		{
			this._moderatorId = _moderatorId;
			this._customerId = _customerId;
			this._wholesalerId = _wholesalerId;
			this._moderatorName = _moderatorName;
			this._conferenceStartTime = _conferenceStartTime;
			this._uniqueConferenceId = _uniqueConferenceId;
			this._numberPeopleOnCall = _numberPeopleOnCall;
			this._auxiliaryConferenceId = _auxiliaryConferenceId;
			this._referenceNumber = _referenceNumber;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Vw_ConferenceCallList_Unique"/> instance.
		///</summary>
		///<param name="_moderatorId"></param>
		///<param name="_customerId"></param>
		///<param name="_wholesalerId"></param>
		///<param name="_moderatorName"></param>
		///<param name="_conferenceStartTime"></param>
		///<param name="_uniqueConferenceId"></param>
		///<param name="_numberPeopleOnCall"></param>
		///<param name="_auxiliaryConferenceId"></param>
		///<param name="_referenceNumber"></param>
		public static Vw_ConferenceCallList_Unique CreateVw_ConferenceCallList_Unique(System.Int32 _moderatorId, System.Int32? _customerId, System.String _wholesalerId, System.String _moderatorName, System.DateTime? _conferenceStartTime, System.String _uniqueConferenceId, System.Int32? _numberPeopleOnCall, System.String _auxiliaryConferenceId, System.String _referenceNumber)
		{
			Vw_ConferenceCallList_Unique newVw_ConferenceCallList_Unique = new Vw_ConferenceCallList_Unique();
			newVw_ConferenceCallList_Unique.ModeratorId = _moderatorId;
			newVw_ConferenceCallList_Unique.CustomerId = _customerId;
			newVw_ConferenceCallList_Unique.WholesalerId = _wholesalerId;
			newVw_ConferenceCallList_Unique.ModeratorName = _moderatorName;
			newVw_ConferenceCallList_Unique.ConferenceStartTime = _conferenceStartTime;
			newVw_ConferenceCallList_Unique.UniqueConferenceId = _uniqueConferenceId;
			newVw_ConferenceCallList_Unique.NumberPeopleOnCall = _numberPeopleOnCall;
			newVw_ConferenceCallList_Unique.AuxiliaryConferenceId = _auxiliaryConferenceId;
			newVw_ConferenceCallList_Unique.ReferenceNumber = _referenceNumber;
			return newVw_ConferenceCallList_Unique;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the ModeratorID property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 ModeratorId
		{
			get
			{
				return this._moderatorId; 
			}
			set
			{
				if (_moderatorId == value)
					return;
					
				this._moderatorId = value;
				this._isDirty = true;
				
				OnPropertyChanged("ModeratorId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CustomerID property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsCustomerIdNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? CustomerId
		{
			get
			{
				return this._customerId; 
			}
			set
			{
				if (_customerId == value && CustomerId != null )
					return;
					
				this._customerId = value;
				this._isDirty = true;
				
				OnPropertyChanged("CustomerId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the WholesalerID property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String WholesalerId
		{
			get
			{
				return this._wholesalerId; 
			}
			set
			{
				if (_wholesalerId == value)
					return;
					
				this._wholesalerId = value;
				this._isDirty = true;
				
				OnPropertyChanged("WholesalerId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ModeratorName property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String ModeratorName
		{
			get
			{
				return this._moderatorName; 
			}
			set
			{
				if (_moderatorName == value)
					return;
					
				this._moderatorName = value;
				this._isDirty = true;
				
				OnPropertyChanged("ModeratorName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ConferenceStartTime property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsConferenceStartTimeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? ConferenceStartTime
		{
			get
			{
				return this._conferenceStartTime; 
			}
			set
			{
				if (_conferenceStartTime == value && ConferenceStartTime != null )
					return;
					
				this._conferenceStartTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("ConferenceStartTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the UniqueConferenceID property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String UniqueConferenceId
		{
			get
			{
				return this._uniqueConferenceId; 
			}
			set
			{
				if (_uniqueConferenceId == value)
					return;
					
				this._uniqueConferenceId = value;
				this._isDirty = true;
				
				OnPropertyChanged("UniqueConferenceId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the NumberPeopleOnCall property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsNumberPeopleOnCallNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32? NumberPeopleOnCall
		{
			get
			{
				return this._numberPeopleOnCall; 
			}
			set
			{
				if (_numberPeopleOnCall == value && NumberPeopleOnCall != null )
					return;
					
				this._numberPeopleOnCall = value;
				this._isDirty = true;
				
				OnPropertyChanged("NumberPeopleOnCall");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the AuxiliaryConferenceID property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String AuxiliaryConferenceId
		{
			get
			{
				return this._auxiliaryConferenceId; 
			}
			set
			{
				if (_auxiliaryConferenceId == value)
					return;
					
				this._auxiliaryConferenceId = value;
				this._isDirty = true;
				
				OnPropertyChanged("AuxiliaryConferenceId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ReferenceNumber property. 
		///		
		/// </summary>
		/// <value>This type is varchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String ReferenceNumber
		{
			get
			{
				return this._referenceNumber; 
			}
			set
			{
				if (_referenceNumber == value)
					return;
					
				this._referenceNumber = value;
				this._isDirty = true;
				
				OnPropertyChanged("ReferenceNumber");
			}
		}
		
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;
		
				this._tag = value;
			}
		}
	
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}
		

		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "vw_ConferenceCallList_Unique"; }
		}

		
		#endregion
		
		#region Methods	
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Vw_ConferenceCallList_UniqueBase Entity 
		///</summary>
		public virtual Vw_ConferenceCallList_UniqueBase Copy()
		{
			//shallow copy entity
			Vw_ConferenceCallList_Unique copy = new Vw_ConferenceCallList_Unique();
				copy.ModeratorId = this.ModeratorId;
				copy.CustomerId = this.CustomerId;
				copy.WholesalerId = this.WholesalerId;
				copy.ModeratorName = this.ModeratorName;
				copy.ConferenceStartTime = this.ConferenceStartTime;
				copy.UniqueConferenceId = this.UniqueConferenceId;
				copy.NumberPeopleOnCall = this.NumberPeopleOnCall;
				copy.AuxiliaryConferenceId = this.AuxiliaryConferenceId;
				copy.ReferenceNumber = this.ReferenceNumber;
			copy.AcceptChanges();
			return (Vw_ConferenceCallList_Unique)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="Vw_ConferenceCallList_UniqueBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(Vw_ConferenceCallList_UniqueBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="Vw_ConferenceCallList_UniqueBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="Vw_ConferenceCallList_UniqueBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="Vw_ConferenceCallList_UniqueBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(Vw_ConferenceCallList_UniqueBase Object1, Vw_ConferenceCallList_UniqueBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.ModeratorId != Object2.ModeratorId)
				equal = false;
			if (Object1.CustomerId != null && Object2.CustomerId != null )
			{
				if (Object1.CustomerId != Object2.CustomerId)
					equal = false;
			}
			else if (Object1.CustomerId == null ^ Object1.CustomerId == null )
			{
				equal = false;
			}
			if (Object1.WholesalerId != null && Object2.WholesalerId != null )
			{
				if (Object1.WholesalerId != Object2.WholesalerId)
					equal = false;
			}
			else if (Object1.WholesalerId == null ^ Object1.WholesalerId == null )
			{
				equal = false;
			}
			if (Object1.ModeratorName != null && Object2.ModeratorName != null )
			{
				if (Object1.ModeratorName != Object2.ModeratorName)
					equal = false;
			}
			else if (Object1.ModeratorName == null ^ Object1.ModeratorName == null )
			{
				equal = false;
			}
			if (Object1.ConferenceStartTime != null && Object2.ConferenceStartTime != null )
			{
				if (Object1.ConferenceStartTime != Object2.ConferenceStartTime)
					equal = false;
			}
			else if (Object1.ConferenceStartTime == null ^ Object1.ConferenceStartTime == null )
			{
				equal = false;
			}
			if (Object1.UniqueConferenceId != null && Object2.UniqueConferenceId != null )
			{
				if (Object1.UniqueConferenceId != Object2.UniqueConferenceId)
					equal = false;
			}
			else if (Object1.UniqueConferenceId == null ^ Object1.UniqueConferenceId == null )
			{
				equal = false;
			}
			if (Object1.NumberPeopleOnCall != null && Object2.NumberPeopleOnCall != null )
			{
				if (Object1.NumberPeopleOnCall != Object2.NumberPeopleOnCall)
					equal = false;
			}
			else if (Object1.NumberPeopleOnCall == null ^ Object1.NumberPeopleOnCall == null )
			{
				equal = false;
			}
			if (Object1.AuxiliaryConferenceId != null && Object2.AuxiliaryConferenceId != null )
			{
				if (Object1.AuxiliaryConferenceId != Object2.AuxiliaryConferenceId)
					equal = false;
			}
			else if (Object1.AuxiliaryConferenceId == null ^ Object1.AuxiliaryConferenceId == null )
			{
				equal = false;
			}
			if (Object1.ReferenceNumber != null && Object2.ReferenceNumber != null )
			{
				if (Object1.ReferenceNumber != Object2.ReferenceNumber)
					equal = false;
			}
			else if (Object1.ReferenceNumber == null ^ Object1.ReferenceNumber == null )
			{
				equal = false;
			}
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	
		#endregion
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}
		
		#endregion
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(Vw_ConferenceCallList_Unique entity, string propertyName)
		{
			switch (propertyName)
			{
				case "ModeratorId":
					return entity.ModeratorId;
				case "CustomerId":
					return entity.CustomerId;
				case "WholesalerId":
					return entity.WholesalerId;
				case "ModeratorName":
					return entity.ModeratorName;
				case "ConferenceStartTime":
					return entity.ConferenceStartTime;
				case "UniqueConferenceId":
					return entity.UniqueConferenceId;
				case "NumberPeopleOnCall":
					return entity.NumberPeopleOnCall;
				case "AuxiliaryConferenceId":
					return entity.AuxiliaryConferenceId;
				case "ReferenceNumber":
					return entity.ReferenceNumber;
			}
			return null;
		}
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{			
			return GetPropertyValueByName(this as Vw_ConferenceCallList_Unique, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{10}{9}- ModeratorId: {0}{9}- CustomerId: {1}{9}- WholesalerId: {2}{9}- ModeratorName: {3}{9}- ConferenceStartTime: {4}{9}- UniqueConferenceId: {5}{9}- NumberPeopleOnCall: {6}{9}- AuxiliaryConferenceId: {7}{9}- ReferenceNumber: {8}{9}", 
				this.ModeratorId,
				(this.CustomerId == null) ? string.Empty : this.CustomerId.ToString(),
			     
				(this.WholesalerId == null) ? string.Empty : this.WholesalerId.ToString(),
			     
				(this.ModeratorName == null) ? string.Empty : this.ModeratorName.ToString(),
			     
				(this.ConferenceStartTime == null) ? string.Empty : this.ConferenceStartTime.ToString(),
			     
				(this.UniqueConferenceId == null) ? string.Empty : this.UniqueConferenceId.ToString(),
			     
				(this.NumberPeopleOnCall == null) ? string.Empty : this.NumberPeopleOnCall.ToString(),
			     
				(this.AuxiliaryConferenceId == null) ? string.Empty : this.AuxiliaryConferenceId.ToString(),
			     
				(this.ReferenceNumber == null) ? string.Empty : this.ReferenceNumber.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the Vw_ConferenceCallList_Unique columns.
	/// </summary>
	[Serializable]
	public enum Vw_ConferenceCallList_UniqueColumn
	{
		/// <summary>
		/// ModeratorID : 
		/// </summary>
		[EnumTextValue("ModeratorID")]
		[ColumnEnum("ModeratorID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ModeratorId,
		/// <summary>
		/// CustomerID : 
		/// </summary>
		[EnumTextValue("CustomerID")]
		[ColumnEnum("CustomerID", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		CustomerId,
		/// <summary>
		/// WholesalerID : 
		/// </summary>
		[EnumTextValue("WholesalerID")]
		[ColumnEnum("WholesalerID", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 10)]
		WholesalerId,
		/// <summary>
		/// ModeratorName : 
		/// </summary>
		[EnumTextValue("ModeratorName")]
		[ColumnEnum("ModeratorName", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		ModeratorName,
		/// <summary>
		/// ConferenceStartTime : 
		/// </summary>
		[EnumTextValue("ConferenceStartTime")]
		[ColumnEnum("ConferenceStartTime", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		ConferenceStartTime,
		/// <summary>
		/// UniqueConferenceID : 
		/// </summary>
		[EnumTextValue("UniqueConferenceID")]
		[ColumnEnum("UniqueConferenceID", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 40)]
		UniqueConferenceId,
		/// <summary>
		/// NumberPeopleOnCall : 
		/// </summary>
		[EnumTextValue("NumberPeopleOnCall")]
		[ColumnEnum("NumberPeopleOnCall", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		NumberPeopleOnCall,
		/// <summary>
		/// AuxiliaryConferenceID : 
		/// </summary>
		[EnumTextValue("AuxiliaryConferenceID")]
		[ColumnEnum("AuxiliaryConferenceID", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 40)]
		AuxiliaryConferenceId,
		/// <summary>
		/// ReferenceNumber : 
		/// </summary>
		[EnumTextValue("ReferenceNumber")]
		[ColumnEnum("ReferenceNumber", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		ReferenceNumber
	}//End enum

} // end namespace