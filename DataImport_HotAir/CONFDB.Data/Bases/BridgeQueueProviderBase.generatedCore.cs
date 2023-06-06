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
	/// This class is the base class for any <see cref="BridgeQueueProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BridgeQueueProviderBaseCore : EntityProviderBase<CONFDB.Entities.BridgeQueue, CONFDB.Entities.BridgeQueueKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.BridgeQueueKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		Bridge_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="_bridgeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(System.Int32 _bridgeId)
		{
			int count = -1;
			return GetByBridgeId(_bridgeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		Bridge_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId)
		{
			int count = -1;
			return GetByBridgeId(transactionManager, _bridgeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		Bridge_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByBridgeId(transactionManager, _bridgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		bridge_BridgeQueue_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(System.Int32 _bridgeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBridgeId(null, _bridgeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		bridge_BridgeQueue_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(System.Int32 _bridgeId, int start, int pageLength,out int count)
		{
			return GetByBridgeId(null, _bridgeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_BridgeQueue_FK key.
		///		Bridge_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public abstract CONFDB.Entities.TList<BridgeQueue> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		Moderator_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(_moderatorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		Moderator_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		Moderator_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		moderator_BridgeQueue_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		moderator_BridgeQueue_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength,out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeQueue_FK key.
		///		Moderator_BridgeQueue_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeQueue objects.</returns>
		public abstract CONFDB.Entities.TList<BridgeQueue> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.BridgeQueue Get(TransactionManager transactionManager, CONFDB.Entities.BridgeQueueKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key BridgeQueue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public CONFDB.Entities.BridgeQueue GetById(System.Guid _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeQueue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public CONFDB.Entities.BridgeQueue GetById(System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeQueue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public CONFDB.Entities.BridgeQueue GetById(TransactionManager transactionManager, System.Guid _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeQueue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public CONFDB.Entities.BridgeQueue GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeQueue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public CONFDB.Entities.BridgeQueue GetById(System.Guid _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeQueue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeQueue"/> class.</returns>
		public abstract CONFDB.Entities.BridgeQueue GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;BridgeQueue&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;BridgeQueue&gt;"/></returns>
		public static CONFDB.Entities.TList<BridgeQueue> Fill(IDataReader reader, CONFDB.Entities.TList<BridgeQueue> rows, int start, int pageLength)
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
				
				CONFDB.Entities.BridgeQueue c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BridgeQueue")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.BridgeQueueColumn.Id - 1))?Guid.NewGuid():(System.Guid)reader[((int)CONFDB.Entities.BridgeQueueColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<BridgeQueue>(
					key.ToString(), // EntityTrackingKey
					"BridgeQueue",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.BridgeQueue();
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
					c.Id = (System.Guid)reader[((int)BridgeQueueColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.ModeratorId = (System.Int32)reader[((int)BridgeQueueColumn.ModeratorId - 1)];
					c.BridgeId = (System.Int32)reader[((int)BridgeQueueColumn.BridgeId - 1)];
					c.ProcessFlag = (System.String)reader[((int)BridgeQueueColumn.ProcessFlag - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BridgeQueue"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeQueue"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.BridgeQueue entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader[((int)BridgeQueueColumn.Id - 1)];
			entity.OriginalId = (System.Guid)reader["ID"];
			entity.ModeratorId = (System.Int32)reader[((int)BridgeQueueColumn.ModeratorId - 1)];
			entity.BridgeId = (System.Int32)reader[((int)BridgeQueueColumn.BridgeId - 1)];
			entity.ProcessFlag = (System.String)reader[((int)BridgeQueueColumn.ProcessFlag - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BridgeQueue"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeQueue"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.BridgeQueue entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["ID"];
			entity.OriginalId = (System.Guid)dataRow["ID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.BridgeId = (System.Int32)dataRow["BridgeID"];
			entity.ProcessFlag = (System.String)dataRow["ProcessFlag"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeQueue"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.BridgeQueue Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.BridgeQueue entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region BridgeIdSource	
			if (CanDeepLoad(entity, "Bridge|BridgeIdSource", deepLoadType, innerList) 
				&& entity.BridgeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.BridgeId;
				Bridge tmpEntity = EntityManager.LocateEntity<Bridge>(EntityLocator.ConstructKeyFromPkItems(typeof(Bridge), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BridgeIdSource = tmpEntity;
				else
					entity.BridgeIdSource = DataRepository.BridgeProvider.GetById(transactionManager, entity.BridgeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BridgeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BridgeProvider.DeepLoad(transactionManager, entity.BridgeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BridgeIdSource

			#region ModeratorIdSource	
			if (CanDeepLoad(entity, "Moderator|ModeratorIdSource", deepLoadType, innerList) 
				&& entity.ModeratorIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ModeratorId;
				Moderator tmpEntity = EntityManager.LocateEntity<Moderator>(EntityLocator.ConstructKeyFromPkItems(typeof(Moderator), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ModeratorIdSource = tmpEntity;
				else
					entity.ModeratorIdSource = DataRepository.ModeratorProvider.GetById(transactionManager, entity.ModeratorId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ModeratorIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ModeratorIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ModeratorProvider.DeepLoad(transactionManager, entity.ModeratorIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ModeratorIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.BridgeQueue object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.BridgeQueue instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.BridgeQueue Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.BridgeQueue entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region BridgeIdSource
			if (CanDeepSave(entity, "Bridge|BridgeIdSource", deepSaveType, innerList) 
				&& entity.BridgeIdSource != null)
			{
				DataRepository.BridgeProvider.Save(transactionManager, entity.BridgeIdSource);
				entity.BridgeId = entity.BridgeIdSource.Id;
			}
			#endregion 
			
			#region ModeratorIdSource
			if (CanDeepSave(entity, "Moderator|ModeratorIdSource", deepSaveType, innerList) 
				&& entity.ModeratorIdSource != null)
			{
				DataRepository.ModeratorProvider.Save(transactionManager, entity.ModeratorIdSource);
				entity.ModeratorId = entity.ModeratorIdSource.Id;
			}
			#endregion 
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
	
	#region BridgeQueueChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.BridgeQueue</c>
	///</summary>
	public enum BridgeQueueChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Bridge</c> at BridgeIdSource
		///</summary>
		[ChildEntityType(typeof(Bridge))]
		Bridge,
			
		///<summary>
		/// Composite Property for <c>Moderator</c> at ModeratorIdSource
		///</summary>
		[ChildEntityType(typeof(Moderator))]
		Moderator,
		}
	
	#endregion BridgeQueueChildEntityTypes
	
	#region BridgeQueueFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BridgeQueueColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueFilterBuilder : SqlFilterBuilder<BridgeQueueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilterBuilder class.
		/// </summary>
		public BridgeQueueFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeQueueFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeQueueFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeQueueFilterBuilder
	
	#region BridgeQueueParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BridgeQueueColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeQueue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeQueueParameterBuilder : ParameterizedSqlFilterBuilder<BridgeQueueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeQueueParameterBuilder class.
		/// </summary>
		public BridgeQueueParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeQueueParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeQueueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeQueueParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeQueueParameterBuilder
} // end namespace
