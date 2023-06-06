#region Using directives

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
	/// This class is the base class for any <see cref="TicketUserAssociationsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TicketUserAssociationsProviderBaseCore : EntityProviderBase<CONFDB.Entities.TicketUserAssociations, CONFDB.Entities.TicketUserAssociationsKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TicketUserAssociationsKey key)
		{
			return Delete(transactionManager, key.UserId, key.TicketUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userId">. Primary Key.</param>
		/// <param name="_ticketUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _userId, System.Int32 _ticketUserId)
		{
			return Delete(null, _userId, _ticketUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <param name="_ticketUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _userId, System.Int32 _ticketUserId);		
		
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
		public override CONFDB.Entities.TicketUserAssociations Get(TransactionManager transactionManager, CONFDB.Entities.TicketUserAssociationsKey key, int start, int pageLength)
		{
			return GetByUserIdTicketUserId(transactionManager, key.UserId, key.TicketUserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(System.Int32 _userId, System.Int32 _ticketUserId)
		{
			int count = -1;
			return GetByUserIdTicketUserId(null,_userId, _ticketUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(System.Int32 _userId, System.Int32 _ticketUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdTicketUserId(null, _userId, _ticketUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(TransactionManager transactionManager, System.Int32 _userId, System.Int32 _ticketUserId)
		{
			int count = -1;
			return GetByUserIdTicketUserId(transactionManager, _userId, _ticketUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(TransactionManager transactionManager, System.Int32 _userId, System.Int32 _ticketUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdTicketUserId(transactionManager, _userId, _ticketUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(System.Int32 _userId, System.Int32 _ticketUserId, int start, int pageLength, out int count)
		{
			return GetByUserIdTicketUserId(null, _userId, _ticketUserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketUserAssociations_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_ticketUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketUserAssociations"/> class.</returns>
		public abstract CONFDB.Entities.TicketUserAssociations GetByUserIdTicketUserId(TransactionManager transactionManager, System.Int32 _userId, System.Int32 _ticketUserId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TicketUserAssociations&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TicketUserAssociations&gt;"/></returns>
		public static CONFDB.Entities.TList<TicketUserAssociations> Fill(IDataReader reader, CONFDB.Entities.TList<TicketUserAssociations> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TicketUserAssociations c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TicketUserAssociations")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TicketUserAssociationsColumn.UserId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TicketUserAssociationsColumn.UserId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TicketUserAssociationsColumn.TicketUserId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TicketUserAssociationsColumn.TicketUserId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TicketUserAssociations>(
					key.ToString(), // EntityTrackingKey
					"TicketUserAssociations",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TicketUserAssociations();
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
					c.UserId = (System.Int32)reader[((int)TicketUserAssociationsColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.TicketUserId = (System.Int32)reader[((int)TicketUserAssociationsColumn.TicketUserId - 1)];
					c.OriginalTicketUserId = c.TicketUserId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketUserAssociations"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketUserAssociations"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TicketUserAssociations entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Int32)reader[((int)TicketUserAssociationsColumn.UserId - 1)];
			entity.OriginalUserId = (System.Int32)reader["UserID"];
			entity.TicketUserId = (System.Int32)reader[((int)TicketUserAssociationsColumn.TicketUserId - 1)];
			entity.OriginalTicketUserId = (System.Int32)reader["TicketUserID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketUserAssociations"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketUserAssociations"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TicketUserAssociations entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Int32)dataRow["UserID"];
			entity.OriginalUserId = (System.Int32)dataRow["UserID"];
			entity.TicketUserId = (System.Int32)dataRow["TicketUserID"];
			entity.OriginalTicketUserId = (System.Int32)dataRow["TicketUserID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketUserAssociations"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketUserAssociations Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TicketUserAssociations entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TicketUserAssociations object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TicketUserAssociations instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketUserAssociations Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TicketUserAssociations entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TicketUserAssociationsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TicketUserAssociations</c>
	///</summary>
	public enum TicketUserAssociationsChildEntityTypes
	{
	}
	
	#endregion TicketUserAssociationsChildEntityTypes
	
	#region TicketUserAssociationsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TicketUserAssociationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsFilterBuilder : SqlFilterBuilder<TicketUserAssociationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilterBuilder class.
		/// </summary>
		public TicketUserAssociationsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketUserAssociationsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketUserAssociationsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketUserAssociationsFilterBuilder
	
	#region TicketUserAssociationsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TicketUserAssociationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketUserAssociations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketUserAssociationsParameterBuilder : ParameterizedSqlFilterBuilder<TicketUserAssociationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsParameterBuilder class.
		/// </summary>
		public TicketUserAssociationsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketUserAssociationsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketUserAssociationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketUserAssociationsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketUserAssociationsParameterBuilder
} // end namespace
