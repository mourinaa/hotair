﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file ForEx.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace CONFDB.Entities
{
	///<summary>
	/// An object representation of the 'ForEx' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class ForExBase : EntityBase, CONFDB.Entities.IForEx, IEntityId<ForExKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private ForExEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private ForExEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private ForExEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<ForEx> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ForExEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ForExEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ForExBase"/> instance.
		///</summary>
		public ForExBase()
		{
			this.entityData = new ForExEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ForExBase"/> instance.
		///</summary>
		///<param name="_id"></param>
		///<param name="_fromCcy"></param>
		///<param name="_toCcy"></param>
		///<param name="_rate"></param>
		///<param name="_curveId"></param>
		///<param name="_effectiveDate"></param>
		public ForExBase(System.Int32 _id, System.String _fromCcy, System.String _toCcy, System.Decimal _rate, 
			System.Int32 _curveId, System.DateTime _effectiveDate)
		{
			this.entityData = new ForExEntityData();
			this.backupData = null;

			this.Id = _id;
			this.FromCcy = _fromCcy;
			this.ToCcy = _toCcy;
			this.Rate = _rate;
			this.CurveId = _curveId;
			this.EffectiveDate = _effectiveDate;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ForEx"/> instance.
		///</summary>
		///<param name="_id"></param>
		///<param name="_fromCcy"></param>
		///<param name="_toCcy"></param>
		///<param name="_rate"></param>
		///<param name="_curveId"></param>
		///<param name="_effectiveDate"></param>
		public static ForEx CreateForEx(System.Int32 _id, System.String _fromCcy, System.String _toCcy, System.Decimal _rate, 
			System.Int32 _curveId, System.DateTime _effectiveDate)
		{
			ForEx newForEx = new ForEx();
			newForEx.Id = _id;
			newForEx.FromCcy = _fromCcy;
			newForEx.ToCcy = _toCcy;
			newForEx.Rate = _rate;
			newForEx.CurveId = _curveId;
			newForEx.EffectiveDate = _effectiveDate;
			return newForEx;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the Id property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false)]
		public virtual System.Int32 Id
		{
			get
			{
				return this.entityData.Id; 
			}
			
			set
			{
				if (this.entityData.Id == value)
					return;
					
				OnColumnChanging(ForExColumn.Id, this.entityData.Id);
				this.entityData.Id = value;
				this.EntityId.Id = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.Id, this.entityData.Id);
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ID property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ID property.</remarks>
		/// <value>This type is int</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int32 OriginalId
		{
			get { return this.entityData.OriginalId; }
			set { this.entityData.OriginalId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the FromCcy property. 
		///		
		/// </summary>
		/// <value>This type is char.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false, 3)]
		public virtual System.String FromCcy
		{
			get
			{
				return this.entityData.FromCcy; 
			}
			
			set
			{
				if (this.entityData.FromCcy == value)
					return;
					
				OnColumnChanging(ForExColumn.FromCcy, this.entityData.FromCcy);
				this.entityData.FromCcy = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.FromCcy, this.entityData.FromCcy);
				OnPropertyChanged("FromCcy");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ToCcy property. 
		///		
		/// </summary>
		/// <value>This type is char.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false, 3)]
		public virtual System.String ToCcy
		{
			get
			{
				return this.entityData.ToCcy; 
			}
			
			set
			{
				if (this.entityData.ToCcy == value)
					return;
					
				OnColumnChanging(ForExColumn.ToCcy, this.entityData.ToCcy);
				this.entityData.ToCcy = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.ToCcy, this.entityData.ToCcy);
				OnPropertyChanged("ToCcy");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Rate property. 
		///		
		/// </summary>
		/// <value>This type is decimal.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false)]
		public virtual System.Decimal Rate
		{
			get
			{
				return this.entityData.Rate; 
			}
			
			set
			{
				if (this.entityData.Rate == value)
					return;
					
				OnColumnChanging(ForExColumn.Rate, this.entityData.Rate);
				this.entityData.Rate = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.Rate, this.entityData.Rate);
				OnPropertyChanged("Rate");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CurveId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 CurveId
		{
			get
			{
				return this.entityData.CurveId; 
			}
			
			set
			{
				if (this.entityData.CurveId == value)
					return;
					
				OnColumnChanging(ForExColumn.CurveId, this.entityData.CurveId);
				this.entityData.CurveId = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.CurveId, this.entityData.CurveId);
				OnPropertyChanged("CurveId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the EffectiveDate property. 
		///		
		/// </summary>
		/// <value>This type is datetime.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false)]
		public virtual System.DateTime EffectiveDate
		{
			get
			{
				return this.entityData.EffectiveDate; 
			}
			
			set
			{
				if (this.entityData.EffectiveDate == value)
					return;
					
				OnColumnChanging(ForExColumn.EffectiveDate, this.entityData.EffectiveDate);
				this.entityData.EffectiveDate = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ForExColumn.EffectiveDate, this.entityData.EffectiveDate);
				OnPropertyChanged("EffectiveDate");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		/// <summary>
		/// Gets or sets the source <see cref="Curve"/>.
		/// </summary>
		/// <value>The source Curve for CurveId.</value>
        [XmlIgnore()]
		[Browsable(false), System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual Curve CurveIdSource
      	{
            get { return entityData.CurveIdSource; }
            set { entityData.CurveIdSource = value; }
      	}
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("FromCcy", "From Ccy"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("FromCcy", "From Ccy", 3));
			ValidationRules.AddRule(
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("ToCcy", "To Ccy"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("ToCcy", "To Ccy", 3));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ForEx"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ID", "FromCcy", "ToCcy", "Rate", "CurveID", "EffectiveDate"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as ForExEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (ForEx) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<ForEx>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ForEx);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed ForEx Entity 
		///</summary>
		public virtual ForEx Copy()
		{
			//shallow copy entity
			ForEx copy = new ForEx();
			copy.SuppressEntityEvents = true;
			copy.Id = this.Id;
			copy.OriginalId = this.OriginalId;
			copy.FromCcy = this.FromCcy;
			copy.ToCcy = this.ToCcy;
			copy.Rate = this.Rate;
			copy.CurveId = this.CurveId;
			copy.EffectiveDate = this.EffectiveDate;
			
			copy.CurveIdSource = MakeCopyOf(this.CurveIdSource) as Curve;
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed ForEx Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ForEx DeepCopy()
		{
			return EntityHelper.Clone<ForEx>(this as ForEx);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as ForExEntityData;
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as ForExEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(ForExColumn column)
		{
			switch(column)
			{
					case ForExColumn.Id:
					return entityData.Id != _originalData.Id;
					case ForExColumn.FromCcy:
					return entityData.FromCcy != _originalData.FromCcy;
					case ForExColumn.ToCcy:
					return entityData.ToCcy != _originalData.ToCcy;
					case ForExColumn.Rate:
					return entityData.Rate != _originalData.Rate;
					case ForExColumn.CurveId:
					return entityData.CurveId != _originalData.CurveId;
					case ForExColumn.EffectiveDate:
					return entityData.EffectiveDate != _originalData.EffectiveDate;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has data changed]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.Id != _originalData.Id;
			result = result || entityData.FromCcy != _originalData.FromCcy;
			result = result || entityData.ToCcy != _originalData.ToCcy;
			result = result || entityData.Rate != _originalData.Rate;
			result = result || entityData.CurveId != _originalData.CurveId;
			result = result || entityData.EffectiveDate != _originalData.EffectiveDate;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="ForExBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is ForExBase)
				return Equals(this, (ForExBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="ForExBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.Id.GetHashCode() ^ 
					this.FromCcy.GetHashCode() ^ 
					this.ToCcy.GetHashCode() ^ 
					this.Rate.GetHashCode() ^ 
					this.CurveId.GetHashCode() ^ 
					this.EffectiveDate.GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ForExBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ForExBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ForExBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ForExBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ForExBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ForExBase Object1, ForExBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.Id != Object2.Id)
				equal = false;
			if (Object1.FromCcy != Object2.FromCcy)
				equal = false;
			if (Object1.ToCcy != Object2.ToCcy)
				equal = false;
			if (Object1.Rate != Object2.Rate)
				equal = false;
			if (Object1.CurveId != Object2.CurveId)
				equal = false;
			if (Object1.EffectiveDate != Object2.EffectiveDate)
				equal = false;
					
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((ForExBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static ForExComparer GetComparer()
        {
            return new ForExComparer();
        }
        */

        // Comparer delegates back to ForEx
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(ForEx rhs, ForExColumn which)
        {
            switch (which)
            {
            	
            	
            	case ForExColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case ForExColumn.FromCcy:
            		return this.FromCcy.CompareTo(rhs.FromCcy);
            		
            		                 
            	
            	
            	case ForExColumn.ToCcy:
            		return this.ToCcy.CompareTo(rhs.ToCcy);
            		
            		                 
            	
            	
            	case ForExColumn.Rate:
            		return this.Rate.CompareTo(rhs.Rate);
            		
            		                 
            	
            	
            	case ForExColumn.CurveId:
            		return this.CurveId.CompareTo(rhs.CurveId);
            		
            		                 
            	
            	
            	case ForExColumn.EffectiveDate:
            		return this.EffectiveDate.CompareTo(rhs.EffectiveDate);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<ForExKey> Members
		
		// member variable for the EntityId property
		private ForExKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual ForExKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ForExKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("ForEx")
					.Append("|").Append( this.Id.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{7}{6}- Id: {0}{6}- FromCcy: {1}{6}- ToCcy: {2}{6}- Rate: {3}{6}- CurveId: {4}{6}- EffectiveDate: {5}{6}", 
				this.Id,
				this.FromCcy,
				this.ToCcy,
				this.Rate,
				this.CurveId,
				this.EffectiveDate,
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ForEx' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class ForExEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// ID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ForEx"</remarks>
			public System.Int32 Id;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int32 OriginalId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// FromCcy : 
		/// </summary>
		public System.String		  FromCcy = string.Empty;
		
		/// <summary>
		/// ToCcy : 
		/// </summary>
		public System.String		  ToCcy = string.Empty;
		
		/// <summary>
		/// Rate : 
		/// </summary>
		public System.Decimal		  Rate = 0.0m;
		
		/// <summary>
		/// CurveID : 
		/// </summary>
		public System.Int32		  CurveId = (int)0;
		
		/// <summary>
		/// EffectiveDate : 
		/// </summary>
		public System.DateTime		  EffectiveDate = DateTime.MinValue;
		#endregion
			
		#region Source Foreign Key Property
				
		private Curve _curveIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Curve"/>.
		/// </summary>
		/// <value>The source Curve for CurveId.</value>
        [XmlIgnore()]
		[Browsable(false)]
		public virtual Curve CurveIdSource
      	{
            get { return this._curveIdSource; }
            set { this._curveIdSource = value; }
      	}
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			ForExEntityData _tmp = new ForExEntityData();
						
			_tmp.Id = this.Id;
			_tmp.OriginalId = this.OriginalId;
			
			_tmp.FromCcy = this.FromCcy;
			_tmp.ToCcy = this.ToCcy;
			_tmp.Rate = this.Rate;
			_tmp.CurveId = this.CurveId;
			_tmp.EffectiveDate = this.EffectiveDate;
			
			#region Source Parent Composite Entities
			if (this.CurveIdSource != null)
				_tmp.CurveIdSource = MakeCopyOf(this.CurveIdSource) as Curve;
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct



		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ForExColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ForExColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ForExColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ForExColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ForExColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ForExColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ForExEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ForExEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ForExColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ForExColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ForExEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ForExEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region ForExEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ForEx"/> object.
	/// </remarks>
	public class ForExEventArgs : System.EventArgs
	{
		private ForExColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the ForExEventArgs class.
		///</summary>
		public ForExEventArgs(ForExColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ForExEventArgs class.
		///</summary>
		public ForExEventArgs(ForExColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The ForExColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ForExColumn" />
		public ForExColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all ForEx related events.
	///</summary>
	public delegate void ForExEventHandler(object sender, ForExEventArgs e);
	
	#region ForExComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ForExComparer : System.Collections.Generic.IComparer<ForEx>
	{
		ForExColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ForExComparer"/> class.
        /// </summary>
		public ForExComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ForExComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ForExComparer(ForExColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ForEx"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ForEx"/> to compare.</param>
        /// <param name="b">The second <c>ForEx</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ForEx a, ForEx b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ForEx entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ForEx a, ForEx b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ForExColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ForExKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ForEx"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ForExKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ForExKey class.
		/// </summary>
		public ForExKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ForExKey class.
		/// </summary>
		public ForExKey(ForExBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.Id = entity.Id;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ForExKey class.
		/// </summary>
		public ForExKey(System.Int32 _id)
		{
			#region Init Properties

			this.Id = _id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ForExBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ForExBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the Id property
		private System.Int32 _id;
		
		/// <summary>
		/// Gets or sets the Id property.
		/// </summary>
		public System.Int32 Id
		{
			get { return _id; }
			set
			{
				if ( this.Entity != null )
					this.Entity.Id = value;
				
				_id = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				Id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("Id", Id);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("Id: {0}{1}",
								Id,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ForExColumn Enum
	
	/// <summary>
	/// Enumerate the ForEx columns.
	/// </summary>
	[Serializable]
	public enum ForExColumn : int
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("ID")]
		[ColumnEnum("ID", typeof(System.Int32), System.Data.DbType.Int32, true, false, false)]
		Id = 1,
		/// <summary>
		/// FromCcy : 
		/// </summary>
		[EnumTextValue("FromCcy")]
		[ColumnEnum("FromCcy", typeof(System.String), System.Data.DbType.AnsiStringFixedLength, false, false, false, 3)]
		FromCcy = 2,
		/// <summary>
		/// ToCcy : 
		/// </summary>
		[EnumTextValue("ToCcy")]
		[ColumnEnum("ToCcy", typeof(System.String), System.Data.DbType.AnsiStringFixedLength, false, false, false, 3)]
		ToCcy = 3,
		/// <summary>
		/// Rate : 
		/// </summary>
		[EnumTextValue("Rate")]
		[ColumnEnum("Rate", typeof(System.Decimal), System.Data.DbType.Decimal, false, false, false)]
		Rate = 4,
		/// <summary>
		/// CurveId : 
		/// </summary>
		[EnumTextValue("CurveID")]
		[ColumnEnum("CurveID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		CurveId = 5,
		/// <summary>
		/// EffectiveDate : 
		/// </summary>
		[EnumTextValue("EffectiveDate")]
		[ColumnEnum("EffectiveDate", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		EffectiveDate = 6
	}//End enum

	#endregion ForExColumn Enum

} // end namespace
