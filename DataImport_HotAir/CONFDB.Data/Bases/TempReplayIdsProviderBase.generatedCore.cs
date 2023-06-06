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
	/// This class is the base class for any <see cref="TempReplayIdsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TempReplayIdsProviderBaseCore : EntityProviderBase<CONFDB.Entities.TempReplayIds, CONFDB.Entities.TempReplayIdsKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TempReplayIdsKey key)
		{
			return Delete(transactionManager, key.ReplayId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_replayId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _replayId)
		{
			return Delete(null, _replayId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _replayId);		
		
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
		public override CONFDB.Entities.TempReplayIds Get(TransactionManager transactionManager, CONFDB.Entities.TempReplayIdsKey key, int start, int pageLength)
		{
			return GetByReplayId(transactionManager, key.ReplayId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TempReplayIDs_PK index.
		/// </summary>
		/// <param name="_replayId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public CONFDB.Entities.TempReplayIds GetByReplayId(System.Int32 _replayId)
		{
			int count = -1;
			return GetByReplayId(null,_replayId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempReplayIDs_PK index.
		/// </summary>
		/// <param name="_replayId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public CONFDB.Entities.TempReplayIds GetByReplayId(System.Int32 _replayId, int start, int pageLength)
		{
			int count = -1;
			return GetByReplayId(null, _replayId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempReplayIDs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public CONFDB.Entities.TempReplayIds GetByReplayId(TransactionManager transactionManager, System.Int32 _replayId)
		{
			int count = -1;
			return GetByReplayId(transactionManager, _replayId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempReplayIDs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public CONFDB.Entities.TempReplayIds GetByReplayId(TransactionManager transactionManager, System.Int32 _replayId, int start, int pageLength)
		{
			int count = -1;
			return GetByReplayId(transactionManager, _replayId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempReplayIDs_PK index.
		/// </summary>
		/// <param name="_replayId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public CONFDB.Entities.TempReplayIds GetByReplayId(System.Int32 _replayId, int start, int pageLength, out int count)
		{
			return GetByReplayId(null, _replayId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TempReplayIDs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempReplayIds"/> class.</returns>
		public abstract CONFDB.Entities.TempReplayIds GetByReplayId(TransactionManager transactionManager, System.Int32 _replayId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TempReplayIds&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TempReplayIds&gt;"/></returns>
		public static CONFDB.Entities.TList<TempReplayIds> Fill(IDataReader reader, CONFDB.Entities.TList<TempReplayIds> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TempReplayIds c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TempReplayIds")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TempReplayIdsColumn.ReplayId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TempReplayIdsColumn.ReplayId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TempReplayIds>(
					key.ToString(), // EntityTrackingKey
					"TempReplayIds",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TempReplayIds();
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
					c.ReplayId = (System.Int32)reader[((int)TempReplayIdsColumn.ReplayId - 1)];
					c.OriginalReplayId = c.ReplayId;
					c.AuxiliaryCid = (reader.IsDBNull(((int)TempReplayIdsColumn.AuxiliaryCid - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.AuxiliaryCid - 1)];
					c.BillingDuration = (reader.IsDBNull(((int)TempReplayIdsColumn.BillingDuration - 1)))?null:(System.Int16?)reader[((int)TempReplayIdsColumn.BillingDuration - 1)];
					c.Notes = (reader.IsDBNull(((int)TempReplayIdsColumn.Notes - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.Notes - 1)];
					c.Enabled = (System.Boolean)reader[((int)TempReplayIdsColumn.Enabled - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)TempReplayIdsColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.ModifiedBy - 1)];
					c.LastModifiedDate = (System.DateTime)reader[((int)TempReplayIdsColumn.LastModifiedDate - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)TempReplayIdsColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempReplayIds"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempReplayIds"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TempReplayIds entity)
		{
			if (!reader.Read()) return;
			
			entity.ReplayId = (System.Int32)reader[((int)TempReplayIdsColumn.ReplayId - 1)];
			entity.OriginalReplayId = (System.Int32)reader["ReplayID"];
			entity.AuxiliaryCid = (reader.IsDBNull(((int)TempReplayIdsColumn.AuxiliaryCid - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.AuxiliaryCid - 1)];
			entity.BillingDuration = (reader.IsDBNull(((int)TempReplayIdsColumn.BillingDuration - 1)))?null:(System.Int16?)reader[((int)TempReplayIdsColumn.BillingDuration - 1)];
			entity.Notes = (reader.IsDBNull(((int)TempReplayIdsColumn.Notes - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.Notes - 1)];
			entity.Enabled = (System.Boolean)reader[((int)TempReplayIdsColumn.Enabled - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)TempReplayIdsColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)TempReplayIdsColumn.ModifiedBy - 1)];
			entity.LastModifiedDate = (System.DateTime)reader[((int)TempReplayIdsColumn.LastModifiedDate - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)TempReplayIdsColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempReplayIds"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempReplayIds"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TempReplayIds entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ReplayId = (System.Int32)dataRow["ReplayID"];
			entity.OriginalReplayId = (System.Int32)dataRow["ReplayID"];
			entity.AuxiliaryCid = Convert.IsDBNull(dataRow["AuxiliaryCID"]) ? null : (System.String)dataRow["AuxiliaryCID"];
			entity.BillingDuration = Convert.IsDBNull(dataRow["BillingDuration"]) ? null : (System.Int16?)dataRow["BillingDuration"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.LastModifiedDate = (System.DateTime)dataRow["LastModifiedDate"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TempReplayIds"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TempReplayIds Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TempReplayIds entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TempReplayIds object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TempReplayIds instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TempReplayIds Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TempReplayIds entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TempReplayIdsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TempReplayIds</c>
	///</summary>
	public enum TempReplayIdsChildEntityTypes
	{
	}
	
	#endregion TempReplayIdsChildEntityTypes
	
	#region TempReplayIdsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TempReplayIdsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsFilterBuilder : SqlFilterBuilder<TempReplayIdsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilterBuilder class.
		/// </summary>
		public TempReplayIdsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempReplayIdsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempReplayIdsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempReplayIdsFilterBuilder
	
	#region TempReplayIdsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TempReplayIdsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempReplayIds"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempReplayIdsParameterBuilder : ParameterizedSqlFilterBuilder<TempReplayIdsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsParameterBuilder class.
		/// </summary>
		public TempReplayIdsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempReplayIdsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempReplayIdsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempReplayIdsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempReplayIdsParameterBuilder
} // end namespace
