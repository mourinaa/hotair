﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Language.cs instead.
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
	/// An object representation of the 'Language' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class LanguageBase : EntityBase, CONFDB.Entities.ILanguage, IEntityId<LanguageKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private LanguageEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private LanguageEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private LanguageEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<Language> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event LanguageEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event LanguageEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="LanguageBase"/> instance.
		///</summary>
		public LanguageBase()
		{
			this.entityData = new LanguageEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="LanguageBase"/> instance.
		///</summary>
		///<param name="_id"></param>
		///<param name="_displayName"></param>
		///<param name="_displayOrder"></param>
		public LanguageBase(System.String _id, System.String _displayName, System.Int16? _displayOrder)
		{
			this.entityData = new LanguageEntityData();
			this.backupData = null;

			this.Id = _id;
			this.DisplayName = _displayName;
			this.DisplayOrder = _displayOrder;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Language"/> instance.
		///</summary>
		///<param name="_id"></param>
		///<param name="_displayName"></param>
		///<param name="_displayOrder"></param>
		public static Language CreateLanguage(System.String _id, System.String _displayName, System.Int16? _displayOrder)
		{
			Language newLanguage = new Language();
			newLanguage.Id = _id;
			newLanguage.DisplayName = _displayName;
			newLanguage.DisplayOrder = _displayOrder;
			return newLanguage;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the Id property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false, 5)]
		public virtual System.String Id
		{
			get
			{
				return this.entityData.Id; 
			}
			
			set
			{
				if (this.entityData.Id == value)
					return;
					
				OnColumnChanging(LanguageColumn.Id, this.entityData.Id);
				this.entityData.Id = value;
				this.EntityId.Id = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.Id, this.entityData.Id);
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ID property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ID property.</remarks>
		/// <value>This type is varchar</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.String OriginalId
		{
			get { return this.entityData.OriginalId; }
			set { this.entityData.OriginalId = value; }
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
		[DataObjectField(false, false, true, 50)]
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
					
				OnColumnChanging(LanguageColumn.DisplayName, this.entityData.DisplayName);
				this.entityData.DisplayName = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.DisplayName, this.entityData.DisplayName);
				OnPropertyChanged("DisplayName");
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
					
				OnColumnChanging(LanguageColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(LanguageColumn.DisplayOrder, this.entityData.DisplayOrder);
				OnPropertyChanged("DisplayOrder");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of CustomerDocument objects
		///	which are related to this object through the relation Language_CustomerDocument_FK
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<CustomerDocument> CustomerDocumentCollection
		{
			get { return entityData.CustomerDocumentCollection; }
			set { entityData.CustomerDocumentCollection = value; }	
		}

		/// <summary>
		///	Holds a collection of WholesalerFromIrWholesaler objects
		///	which are related to this object through the junction table IrWholesaler
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<Wholesaler> WholesalerIdWholesalerCollection_From_IrWholesaler
		{
			get { return entityData.WholesalerIdWholesalerCollection_From_IrWholesaler; }
			set { entityData.WholesalerIdWholesalerCollection_From_IrWholesaler = value; }	
		}
	
		/// <summary>
		///	Holds a collection of IrWholesaler objects
		///	which are related to this object through the relation Language_IRWholesaler_FK
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<IrWholesaler> IrWholesalerCollection
		{
			get { return entityData.IrWholesalerCollection; }
			set { entityData.IrWholesalerCollection = value; }	
		}
	
		/// <summary>
		///	Holds a collection of EmailTemplate objects
		///	which are related to this object through the relation Language_EmailTemplates_FK
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<EmailTemplate> EmailTemplateCollection
		{
			get { return entityData.EmailTemplateCollection; }
			set { entityData.EmailTemplateCollection = value; }	
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
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("Id", "Id"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("Id", "Id", 5));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("DisplayName", "Display Name", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "Language"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ID", "DisplayName", "DisplayOrder"};
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
	            this.backupData = this.entityData.Clone() as LanguageEntityData;
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
						this.parentCollection.Remove( (Language) this ) ;
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
	            this.parentCollection = value as TList<Language>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Language);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Language Entity 
		///</summary>
		public virtual Language Copy()
		{
			//shallow copy entity
			Language copy = new Language();
			copy.SuppressEntityEvents = true;
			copy.Id = this.Id;
			copy.OriginalId = this.OriginalId;
			copy.DisplayName = this.DisplayName;
			copy.DisplayOrder = this.DisplayOrder;
			
		
			//deep copy nested objects
			copy.CustomerDocumentCollection = (TList<CustomerDocument>) MakeCopyOf(this.CustomerDocumentCollection); 
			copy.WholesalerIdWholesalerCollection_From_IrWholesaler = (TList<Wholesaler>) MakeCopyOf(this.WholesalerIdWholesalerCollection_From_IrWholesaler); 
			copy.IrWholesalerCollection = (TList<IrWholesaler>) MakeCopyOf(this.IrWholesalerCollection); 
			copy.EmailTemplateCollection = (TList<EmailTemplate>) MakeCopyOf(this.EmailTemplateCollection); 
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
		///  Returns a Typed Language Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Language DeepCopy()
		{
			return EntityHelper.Clone<Language>(this as Language);	
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
				this.entityData = this._originalData.Clone() as LanguageEntityData;
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
			this._originalData = this.entityData.Clone() as LanguageEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(LanguageColumn column)
		{
			switch(column)
			{
					case LanguageColumn.Id:
					return entityData.Id != _originalData.Id;
					case LanguageColumn.DisplayName:
					return entityData.DisplayName != _originalData.DisplayName;
					case LanguageColumn.DisplayOrder:
					return entityData.DisplayOrder != _originalData.DisplayOrder;
			
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
			result = result || entityData.DisplayName != _originalData.DisplayName;
			result = result || entityData.DisplayOrder != _originalData.DisplayOrder;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="LanguageBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is LanguageBase)
				return Equals(this, (LanguageBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="LanguageBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.Id.GetHashCode() ^ 
					((this.DisplayName == null) ? string.Empty : this.DisplayName.ToString()).GetHashCode() ^ 
					((this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="LanguageBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(LanguageBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="LanguageBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="LanguageBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="LanguageBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(LanguageBase Object1, LanguageBase Object2)
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
			if ( Object1.DisplayName != null && Object2.DisplayName != null )
			{
				if (Object1.DisplayName != Object2.DisplayName)
					equal = false;
			}
			else if (Object1.DisplayName == null ^ Object2.DisplayName == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((LanguageBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static LanguageComparer GetComparer()
        {
            return new LanguageComparer();
        }
        */

        // Comparer delegates back to Language
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
        public int CompareTo(Language rhs, LanguageColumn which)
        {
            switch (which)
            {
            	
            	
            	case LanguageColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case LanguageColumn.DisplayName:
            		return this.DisplayName.CompareTo(rhs.DisplayName);
            		
            		                 
            	
            	
            	case LanguageColumn.DisplayOrder:
            		return this.DisplayOrder.Value.CompareTo(rhs.DisplayOrder.Value);
            		
            		                 
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
				
		#region IEntityKey<LanguageKey> Members
		
		// member variable for the EntityId property
		private LanguageKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual LanguageKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new LanguageKey(this);
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
					entityTrackingKey = new System.Text.StringBuilder("Language")
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
				"{4}{3}- Id: {0}{3}- DisplayName: {1}{3}- DisplayOrder: {2}{3}", 
				this.Id,
				(this.DisplayName == null) ? string.Empty : this.DisplayName.ToString(),
				(this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Language' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class LanguageEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// ID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Language"</remarks>
			public System.String Id;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// DisplayName : 
		/// </summary>
		public System.String		  DisplayName = null;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int16?		  DisplayOrder = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#region CustomerDocumentCollection
		
		private TList<CustomerDocument> _customerDocumentLanguageId;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _customerDocumentLanguageId
		/// </summary>	
		public TList<CustomerDocument> CustomerDocumentCollection
		{
			get
			{
				if (_customerDocumentLanguageId == null)
				{
				_customerDocumentLanguageId = new TList<CustomerDocument>();
				}
	
				return _customerDocumentLanguageId;
			}
			set { _customerDocumentLanguageId = value; }
		}
		
		#endregion

		#region WholesalerIdWholesalerCollection_From_IrWholesaler
		
		private TList<Wholesaler> wholesalerIdWholesalerCollection_From_IrWholesaler;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table wholesalerIdWholesalerCollection_From_IrWholesaler
		/// </summary>	
		public TList<Wholesaler> WholesalerIdWholesalerCollection_From_IrWholesaler
		{
			get
			{
				if (wholesalerIdWholesalerCollection_From_IrWholesaler == null)
				{
				wholesalerIdWholesalerCollection_From_IrWholesaler = new TList<Wholesaler>();
				}
	
				return wholesalerIdWholesalerCollection_From_IrWholesaler;
			}
			set { wholesalerIdWholesalerCollection_From_IrWholesaler = value; }
		}
		
		#endregion 

		#region IrWholesalerCollection
		
		private TList<IrWholesaler> _irWholesalerLanguageId;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _irWholesalerLanguageId
		/// </summary>	
		public TList<IrWholesaler> IrWholesalerCollection
		{
			get
			{
				if (_irWholesalerLanguageId == null)
				{
				_irWholesalerLanguageId = new TList<IrWholesaler>();
				}
	
				return _irWholesalerLanguageId;
			}
			set { _irWholesalerLanguageId = value; }
		}
		
		#endregion

		#region EmailTemplateCollection
		
		private TList<EmailTemplate> _emailTemplateLanguageId;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _emailTemplateLanguageId
		/// </summary>	
		public TList<EmailTemplate> EmailTemplateCollection
		{
			get
			{
				if (_emailTemplateLanguageId == null)
				{
				_emailTemplateLanguageId = new TList<EmailTemplate>();
				}
	
				return _emailTemplateLanguageId;
			}
			set { _emailTemplateLanguageId = value; }
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
			LanguageEntityData _tmp = new LanguageEntityData();
						
			_tmp.Id = this.Id;
			_tmp.OriginalId = this.OriginalId;
			
			_tmp.DisplayName = this.DisplayName;
			_tmp.DisplayOrder = this.DisplayOrder;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this._customerDocumentLanguageId != null)
				_tmp.CustomerDocumentCollection = (TList<CustomerDocument>) MakeCopyOf(this.CustomerDocumentCollection); 
			if (this.wholesalerIdWholesalerCollection_From_IrWholesaler != null)
				_tmp.WholesalerIdWholesalerCollection_From_IrWholesaler = (TList<Wholesaler>) MakeCopyOf(this.WholesalerIdWholesalerCollection_From_IrWholesaler); 
			if (this._irWholesalerLanguageId != null)
				_tmp.IrWholesalerCollection = (TList<IrWholesaler>) MakeCopyOf(this.IrWholesalerCollection); 
			if (this._emailTemplateLanguageId != null)
				_tmp.EmailTemplateCollection = (TList<EmailTemplate>) MakeCopyOf(this.EmailTemplateCollection); 
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
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		public void OnColumnChanging(LanguageColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		public void OnColumnChanged(LanguageColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(LanguageColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				LanguageEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new LanguageEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="LanguageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(LanguageColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				LanguageEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new LanguageEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region LanguageEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Language"/> object.
	/// </remarks>
	public class LanguageEventArgs : System.EventArgs
	{
		private LanguageColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the LanguageEventArgs class.
		///</summary>
		public LanguageEventArgs(LanguageColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the LanguageEventArgs class.
		///</summary>
		public LanguageEventArgs(LanguageColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The LanguageColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="LanguageColumn" />
		public LanguageColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all Language related events.
	///</summary>
	public delegate void LanguageEventHandler(object sender, LanguageEventArgs e);
	
	#region LanguageComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class LanguageComparer : System.Collections.Generic.IComparer<Language>
	{
		LanguageColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:LanguageComparer"/> class.
        /// </summary>
		public LanguageComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LanguageComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public LanguageComparer(LanguageColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Language"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Language"/> to compare.</param>
        /// <param name="b">The second <c>Language</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Language a, Language b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Language entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Language a, Language b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public LanguageColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region LanguageKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Language"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class LanguageKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey(LanguageBase entity)
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
		/// Initializes a new instance of the LanguageKey class.
		/// </summary>
		public LanguageKey(System.String _id)
		{
			#region Init Properties

			this.Id = _id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private LanguageBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public LanguageBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the Id property
		private System.String _id;
		
		/// <summary>
		/// Gets or sets the Id property.
		/// </summary>
		public System.String Id
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
				Id = ( values["Id"] != null ) ? (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String)) : string.Empty;
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

	#region LanguageColumn Enum
	
	/// <summary>
	/// Enumerate the Language columns.
	/// </summary>
	[Serializable]
	public enum LanguageColumn : int
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("ID")]
		[ColumnEnum("ID", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 5)]
		Id = 1,
		/// <summary>
		/// DisplayName : 
		/// </summary>
		[EnumTextValue("DisplayName")]
		[ColumnEnum("DisplayName", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		DisplayName = 2,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int16), System.Data.DbType.Int16, false, false, true)]
		DisplayOrder = 3
	}//End enum

	#endregion LanguageColumn Enum

} // end namespace
