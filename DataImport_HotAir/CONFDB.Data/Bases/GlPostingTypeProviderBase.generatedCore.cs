﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using CONFDB.Entities;
using CONFDB.Data;

#endregion

namespace CONFDB.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="GlPostingTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GlPostingTypeProviderBaseCore : EntityProviderBase<CONFDB.Entities.GlPostingType, CONFDB.Entities.GlPostingTypeKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.GlPostingTypeKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override CONFDB.Entities.GlPostingType Get(TransactionManager transactionManager, CONFDB.Entities.GlPostingTypeKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_GLPostingType index.
		/// </summary>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public CONFDB.Entities.GlPostingType GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_GLPostingType index.
		/// </summary>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public CONFDB.Entities.GlPostingType GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_GLPostingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public CONFDB.Entities.GlPostingType GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_GLPostingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public CONFDB.Entities.GlPostingType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_GLPostingType index.
		/// </summary>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public CONFDB.Entities.GlPostingType GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_GLPostingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">GLPostingType is used to store the types of different General Ledger posting types and thus used to group together their rules.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.GlPostingType"/> class.</returns>
		public abstract CONFDB.Entities.GlPostingType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<GlPostingType> GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<GlPostingType> GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<GlPostingType> GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<GlPostingType> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<GlPostingType> GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GLPostingType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<GlPostingType> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;GlPostingType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;GlPostingType&gt;"/></returns>
		public static CONFDB.Entities.TList<GlPostingType> Fill(IDataReader reader, CONFDB.Entities.TList<GlPostingType> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				CONFDB.Entities.GlPostingType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("GlPostingType")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.GlPostingTypeColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.GlPostingTypeColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<GlPostingType>(
					key.ToString(), // EntityTrackingKey
					"GlPostingType",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.GlPostingType();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged || c.EntityState == EntityState.Changed))
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Id = (System.Int32)reader[((int)GlPostingTypeColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)GlPostingTypeColumn.Name - 1)))?null:(System.String)reader[((int)GlPostingTypeColumn.Name - 1)];
					c.DisplayName = (reader.IsDBNull(((int)GlPostingTypeColumn.DisplayName - 1)))?null:(System.String)reader[((int)GlPostingTypeColumn.DisplayName - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)GlPostingTypeColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)GlPostingTypeColumn.DisplayOrder - 1)];
					c.Multiplier = (System.Int16)reader[((int)GlPostingTypeColumn.Multiplier - 1)];
					c.CalculateTax = (System.Boolean)reader[((int)GlPostingTypeColumn.CalculateTax - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.GlPostingType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.GlPostingType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.GlPostingType entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)GlPostingTypeColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)GlPostingTypeColumn.Name - 1)))?null:(System.String)reader[((int)GlPostingTypeColumn.Name - 1)];
			entity.DisplayName = (reader.IsDBNull(((int)GlPostingTypeColumn.DisplayName - 1)))?null:(System.String)reader[((int)GlPostingTypeColumn.DisplayName - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)GlPostingTypeColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)GlPostingTypeColumn.DisplayOrder - 1)];
			entity.Multiplier = (System.Int16)reader[((int)GlPostingTypeColumn.Multiplier - 1)];
			entity.CalculateTax = (System.Boolean)reader[((int)GlPostingTypeColumn.CalculateTax - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.GlPostingType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.GlPostingType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.GlPostingType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
			entity.Multiplier = (System.Int16)dataRow["Multiplier"];
			entity.CalculateTax = (System.Boolean)dataRow["CalculateTax"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.GlPostingType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.GlPostingType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.GlPostingType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerTransactionTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerTransactionType>|CustomerTransactionTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTransactionTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerTransactionTypeCollection = DataRepository.CustomerTransactionTypeProvider.GetByGlPostingTypeId(transactionManager, entity.Id);

				if (deep && entity.CustomerTransactionTypeCollection.Count > 0)
				{
					deepHandles.Add("CustomerTransactionTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerTransactionType>) DataRepository.CustomerTransactionTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTransactionTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the CONFDB.Entities.GlPostingType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.GlPostingType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.GlPostingType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.GlPostingType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<CustomerTransactionType>
				if (CanDeepSave(entity.CustomerTransactionTypeCollection, "List<CustomerTransactionType>|CustomerTransactionTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerTransactionType child in entity.CustomerTransactionTypeCollection)
					{
						if(child.GlPostingTypeIdSource != null)
						{
							child.GlPostingTypeId = child.GlPostingTypeIdSource.Id;
						}
						else
						{
							child.GlPostingTypeId = entity.Id;
						}

					}

					if (entity.CustomerTransactionTypeCollection.Count > 0 || entity.CustomerTransactionTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerTransactionTypeProvider.Save(transactionManager, entity.CustomerTransactionTypeCollection);
						
						deepHandles.Add("CustomerTransactionTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerTransactionType >) DataRepository.CustomerTransactionTypeProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerTransactionTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region GlPostingTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.GlPostingType</c>
	///</summary>
	public enum GlPostingTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>GlPostingType</c> as OneToMany for CustomerTransactionTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransactionType>))]
		CustomerTransactionTypeCollection,
	}
	
	#endregion GlPostingTypeChildEntityTypes
	
	#region GlPostingTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GlPostingTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlPostingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlPostingTypeFilterBuilder : SqlFilterBuilder<GlPostingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilterBuilder class.
		/// </summary>
		public GlPostingTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlPostingTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlPostingTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlPostingTypeFilterBuilder
	
	#region GlPostingTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GlPostingTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlPostingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlPostingTypeParameterBuilder : ParameterizedSqlFilterBuilder<GlPostingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeParameterBuilder class.
		/// </summary>
		public GlPostingTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlPostingTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlPostingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlPostingTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlPostingTypeParameterBuilder
} // end namespace