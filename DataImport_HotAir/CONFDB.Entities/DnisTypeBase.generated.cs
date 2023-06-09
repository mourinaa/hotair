﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file DnisType.cs instead.
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
	/// An object representation of the 'DNISType' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class DnisTypeBase : EntityBase, CONFDB.Entities.IDnisType, IEntityId<DnisTypeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private DnisTypeEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private DnisTypeEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private DnisTypeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<DnisType> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event DnisTypeEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event DnisTypeEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="DnisTypeBase"/> instance.
		///</summary>
		public DnisTypeBase()
		{
			this.entityData = new DnisTypeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="DnisTypeBase"/> instance.
		///</summary>
		///<param name="_name"></param>
		///<param name="_displayOrder"></param>
		///<param name="_displayName"></param>
		public DnisTypeBase(System.String _name, System.Int16? _displayOrder, System.String _displayName)
		{
			this.entityData = new DnisTypeEntityData();
			this.backupData = null;

			this.Name = _name;
			this.DisplayOrder = _displayOrder;
			this.DisplayName = _displayName;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="DnisType"/> instance.
		///</summary>
		///<param name="_name"></param>
		///<param name="_displayOrder"></param>
		///<param name="_displayName"></param>
		public static DnisType CreateDnisType(System.String _name, System.Int16? _displayOrder, System.String _displayName)
		{
			DnisType newDnisType = new DnisType();
			newDnisType.Name = _name;
			newDnisType.DisplayOrder = _displayOrder;
			newDnisType.DisplayName = _displayName;
			return newDnisType;
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
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
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
					
				OnColumnChanging(DnisTypeColumn.Id, this.entityData.Id);
				this.entityData.Id = value;
				this.EntityId.Id = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DnisTypeColumn.Id, this.entityData.Id);
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 30)]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				if (this.entityData.Name == value)
					return;
					
				OnColumnChanging(DnisTypeColumn.Name, this.entityData.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DnisTypeColumn.Name, this.entityData.Name);
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DisplayOrder property. 
		///		
		/// </summary>
		/// <value>This type is smallint.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (short)0. It is up to the developer
		/// to check the value of IsDisplayOrderNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true)]
		public virtual System.Int16? DisplayOrder
		{
			get
			{
				return this.entityData.DisplayOrder; 
			}
			
			set
			{
				if (this.entityData.DisplayOrder == value)
					return;
					
				OnColumnChanging(DnisTypeColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DnisTypeColumn.DisplayOrder, this.entityData.DisplayOrder);
				OnPropertyChanged("DisplayOrder");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DisplayName property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 30)]
		public virtual System.String DisplayName
		{
			get
			{
				return this.entityData.DisplayName; 
			}
			
			set
			{
				if (this.entityData.DisplayName == value)
					return;
					
				OnColumnChanging(DnisTypeColumn.DisplayName, this.entityData.DisplayName);
				this.entityData.DisplayName = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DnisTypeColumn.DisplayName, this.entityData.DisplayName);
				OnPropertyChanged("DisplayName");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of Dnis objects
		///	which are related to this object through the relation DNISType_DNIS_FK1
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<Dnis> DnisCollection
		{
			get { return entityData.DnisCollection; }
			set { entityData.DnisCollection = value; }	
		}
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
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("Name", "Name", 30));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("DisplayName", "Display Name", 30));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "DNISType"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ID", "Name", "DisplayOrder", "DisplayName"};
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
	            this.backupData = this.entityData.Clone() as DnisTypeEntityData;
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
						this.parentCollection.Remove( (DnisType) this ) ;
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
	            this.parentCollection = value as TList<DnisType>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as DnisType);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed DnisType Entity 
		///</summary>
		public virtual DnisType Copy()
		{
			//shallow copy entity
			DnisType copy = new DnisType();
			copy.SuppressEntityEvents = true;
			copy.Id = this.Id;
			copy.Name = this.Name;
			copy.DisplayOrder = this.DisplayOrder;
			copy.DisplayName = this.DisplayName;
			
		
			//deep copy nested objects
			copy.DnisCollection = (TList<Dnis>) MakeCopyOf(this.DnisCollection); 
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
		///  Returns a Typed DnisType Entity which is a deep copy of the current entity.
		///</summary>
		public virtual DnisType DeepCopy()
		{
			return EntityHelper.Clone<DnisType>(this as DnisType);	
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
				this.entityData = this._originalData.Clone() as DnisTypeEntityData;
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
			this._originalData = this.entityData.Clone() as DnisTypeEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(DnisTypeColumn column)
		{
			switch(column)
			{
					case DnisTypeColumn.Id:
					return entityData.Id != _originalData.Id;
					case DnisTypeColumn.Name:
					return entityData.Name != _originalData.Name;
					case DnisTypeColumn.DisplayOrder:
					return entityData.DisplayOrder != _originalData.DisplayOrder;
					case DnisTypeColumn.DisplayName:
					return entityData.DisplayName != _originalData.DisplayName;
			
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
			result = result || entityData.Name != _originalData.Name;
			result = result || entityData.DisplayOrder != _originalData.DisplayOrder;
			result = result || entityData.DisplayName != _originalData.DisplayName;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="DnisTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is DnisTypeBase)
				return Equals(this, (DnisTypeBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="DnisTypeBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.Id.GetHashCode() ^ 
					((this.Name == null) ? string.Empty : this.Name.ToString()).GetHashCode() ^ 
					((this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString()).GetHashCode() ^ 
					((this.DisplayName == null) ? string.Empty : this.DisplayName.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="DnisTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(DnisTypeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="DnisTypeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="DnisTypeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="DnisTypeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(DnisTypeBase Object1, DnisTypeBase Object2)
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
			if ( Object1.Name != null && Object2.Name != null )
			{
				if (Object1.Name != Object2.Name)
					equal = false;
			}
			else if (Object1.Name == null ^ Object2.Name == null )
			{
				equal = false;
			}
			if ( Object1.DisplayOrder != null && Object2.DisplayOrder != null )
			{
				if (Object1.DisplayOrder != Object2.DisplayOrder)
					equal = false;
			}
			else if (Object1.DisplayOrder == null ^ Object2.DisplayOrder == null )
			{
				equal = false;
			}
			if ( Object1.DisplayName != null && Object2.DisplayName != null )
			{
				if (Object1.DisplayName != Object2.DisplayName)
					equal = false;
			}
			else if (Object1.DisplayName == null ^ Object2.DisplayName == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((DnisTypeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static DnisTypeComparer GetComparer()
        {
            return new DnisTypeComparer();
        }
        */

        // Comparer delegates back to DnisType
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
        public int CompareTo(DnisType rhs, DnisTypeColumn which)
        {
            switch (which)
            {
            	
            	
            	case DnisTypeColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case DnisTypeColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            	
            	case DnisTypeColumn.DisplayOrder:
            		return this.DisplayOrder.Value.CompareTo(rhs.DisplayOrder.Value);
            		
            		                 
            	
            	
            	case DnisTypeColumn.DisplayName:
            		return this.DisplayName.CompareTo(rhs.DisplayName);
            		
            		                 
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
				
		#region IEntityKey<DnisTypeKey> Members
		
		// member variable for the EntityId property
		private DnisTypeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual DnisTypeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new DnisTypeKey(this);
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
					entityTrackingKey = new System.Text.StringBuilder("DnisType")
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
				"{5}{4}- Id: {0}{4}- Name: {1}{4}- DisplayOrder: {2}{4}- DisplayName: {3}{4}", 
				this.Id,
				(this.Name == null) ? string.Empty : this.Name.ToString(),
				(this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString(),
				(this.DisplayName == null) ? string.Empty : this.DisplayName.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'DNISType' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class DnisTypeEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// ID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "DNISType"</remarks>
			public System.Int32 Id;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = null;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int16?		  DisplayOrder = null;
		
		/// <summary>
		/// DisplayName : 
		/// </summary>
		public System.String		  DisplayName = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#region DnisCollection
		
		private TList<Dnis> _dnisDnisTypeId;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _dnisDnisTypeId
		/// </summary>	
		public TList<Dnis> DnisCollection
		{
			get
			{
				if (_dnisDnisTypeId == null)
				{
				_dnisDnisTypeId = new TList<Dnis>();
				}
	
				return _dnisDnisTypeId;
			}
			set { _dnisDnisTypeId = value; }
		}
		
		#endregion

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			DnisTypeEntityData _tmp = new DnisTypeEntityData();
						
			_tmp.Id = this.Id;
			
			_tmp.Name = this.Name;
			_tmp.DisplayOrder = this.DisplayOrder;
			_tmp.DisplayName = this.DisplayName;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this._dnisDnisTypeId != null)
				_tmp.DnisCollection = (TList<Dnis>) MakeCopyOf(this.DnisCollection); 
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
		/// <param name="column">The <see cref="DnisTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(DnisTypeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DnisTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(DnisTypeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DnisTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(DnisTypeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				DnisTypeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new DnisTypeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DnisTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(DnisTypeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				DnisTypeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new DnisTypeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region DnisTypeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="DnisType"/> object.
	/// </remarks>
	public class DnisTypeEventArgs : System.EventArgs
	{
		private DnisTypeColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the DnisTypeEventArgs class.
		///</summary>
		public DnisTypeEventArgs(DnisTypeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the DnisTypeEventArgs class.
		///</summary>
		public DnisTypeEventArgs(DnisTypeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The DnisTypeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="DnisTypeColumn" />
		public DnisTypeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all DnisType related events.
	///</summary>
	public delegate void DnisTypeEventHandler(object sender, DnisTypeEventArgs e);
	
	#region DnisTypeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class DnisTypeComparer : System.Collections.Generic.IComparer<DnisType>
	{
		DnisTypeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:DnisTypeComparer"/> class.
        /// </summary>
		public DnisTypeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnisTypeComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public DnisTypeComparer(DnisTypeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="DnisType"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="DnisType"/> to compare.</param>
        /// <param name="b">The second <c>DnisType</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(DnisType a, DnisType b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(DnisType entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(DnisType a, DnisType b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public DnisTypeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region DnisTypeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="DnisType"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class DnisTypeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the DnisTypeKey class.
		/// </summary>
		public DnisTypeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the DnisTypeKey class.
		/// </summary>
		public DnisTypeKey(DnisTypeBase entity)
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
		/// Initializes a new instance of the DnisTypeKey class.
		/// </summary>
		public DnisTypeKey(System.Int32 _id)
		{
			#region Init Properties

			this.Id = _id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private DnisTypeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public DnisTypeBase Entity
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

	#region DnisTypeColumn Enum
	
	/// <summary>
	/// Enumerate the DnisType columns.
	/// </summary>
	[Serializable]
	public enum DnisTypeColumn : int
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("ID")]
		[ColumnEnum("ID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		Id = 1,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 30)]
		Name = 2,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int16), System.Data.DbType.Int16, false, false, true)]
		DisplayOrder = 3,
		/// <summary>
		/// DisplayName : 
		/// </summary>
		[EnumTextValue("DisplayName")]
		[ColumnEnum("DisplayName", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 30)]
		DisplayName = 4
	}//End enum

	#endregion DnisTypeColumn Enum

} // end namespace
