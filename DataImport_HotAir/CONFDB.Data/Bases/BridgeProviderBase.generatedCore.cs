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
	/// This class is the base class for any <see cref="BridgeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BridgeProviderBaseCore : EntityProviderBase<CONFDB.Entities.Bridge, CONFDB.Entities.BridgeKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.BridgeKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
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
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		BridgeType_Bridge_FK Description: 
		/// </summary>
		/// <param name="_bridgeTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		public CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(System.Int32 _bridgeTypeId)
		{
			int count = -1;
			return GetByBridgeTypeId(_bridgeTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		BridgeType_Bridge_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(TransactionManager transactionManager, System.Int32 _bridgeTypeId)
		{
			int count = -1;
			return GetByBridgeTypeId(transactionManager, _bridgeTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		BridgeType_Bridge_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		public CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(TransactionManager transactionManager, System.Int32 _bridgeTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByBridgeTypeId(transactionManager, _bridgeTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		bridgeType_Bridge_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		public CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(System.Int32 _bridgeTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBridgeTypeId(null, _bridgeTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		bridgeType_Bridge_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		public CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(System.Int32 _bridgeTypeId, int start, int pageLength,out int count)
		{
			return GetByBridgeTypeId(null, _bridgeTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeType_Bridge_FK key.
		///		BridgeType_Bridge_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Bridge objects.</returns>
		public abstract CONFDB.Entities.TList<Bridge> GetByBridgeTypeId(TransactionManager transactionManager, System.Int32 _bridgeTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Bridge Get(TransactionManager transactionManager, CONFDB.Entities.BridgeKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Bridge_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public CONFDB.Entities.Bridge GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public CONFDB.Entities.Bridge GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public CONFDB.Entities.Bridge GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public CONFDB.Entities.Bridge GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public CONFDB.Entities.Bridge GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Bridge"/> class.</returns>
		public abstract CONFDB.Entities.Bridge GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Bridge&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Bridge&gt;"/></returns>
		public static CONFDB.Entities.TList<Bridge> Fill(IDataReader reader, CONFDB.Entities.TList<Bridge> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Bridge c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Bridge")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.BridgeColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.BridgeColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Bridge>(
					key.ToString(), // EntityTrackingKey
					"Bridge",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Bridge();
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
					c.Id = (System.Int32)reader[((int)BridgeColumn.Id - 1)];
					c.Name = (System.String)reader[((int)BridgeColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)BridgeColumn.Description - 1)))?null:(System.String)reader[((int)BridgeColumn.Description - 1)];
					c.IpAddress = (reader.IsDBNull(((int)BridgeColumn.IpAddress - 1)))?null:(System.String)reader[((int)BridgeColumn.IpAddress - 1)];
					c.WebRequestSecurityToken = (reader.IsDBNull(((int)BridgeColumn.WebRequestSecurityToken - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestSecurityToken - 1)];
					c.WebRequestApiurl = (reader.IsDBNull(((int)BridgeColumn.WebRequestApiurl - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestApiurl - 1)];
					c.WebRequestMethod = (reader.IsDBNull(((int)BridgeColumn.WebRequestMethod - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestMethod - 1)];
					c.WebRequestContentType = (reader.IsDBNull(((int)BridgeColumn.WebRequestContentType - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestContentType - 1)];
					c.UserName = (reader.IsDBNull(((int)BridgeColumn.UserName - 1)))?null:(System.String)reader[((int)BridgeColumn.UserName - 1)];
					c.Password = (reader.IsDBNull(((int)BridgeColumn.Password - 1)))?null:(System.String)reader[((int)BridgeColumn.Password - 1)];
					c.BridgeTypeId = (System.Int32)reader[((int)BridgeColumn.BridgeTypeId - 1)];
					c.DbConnectionString = (reader.IsDBNull(((int)BridgeColumn.DbConnectionString - 1)))?null:(System.String)reader[((int)BridgeColumn.DbConnectionString - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Bridge"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Bridge"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Bridge entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)BridgeColumn.Id - 1)];
			entity.Name = (System.String)reader[((int)BridgeColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)BridgeColumn.Description - 1)))?null:(System.String)reader[((int)BridgeColumn.Description - 1)];
			entity.IpAddress = (reader.IsDBNull(((int)BridgeColumn.IpAddress - 1)))?null:(System.String)reader[((int)BridgeColumn.IpAddress - 1)];
			entity.WebRequestSecurityToken = (reader.IsDBNull(((int)BridgeColumn.WebRequestSecurityToken - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestSecurityToken - 1)];
			entity.WebRequestApiurl = (reader.IsDBNull(((int)BridgeColumn.WebRequestApiurl - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestApiurl - 1)];
			entity.WebRequestMethod = (reader.IsDBNull(((int)BridgeColumn.WebRequestMethod - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestMethod - 1)];
			entity.WebRequestContentType = (reader.IsDBNull(((int)BridgeColumn.WebRequestContentType - 1)))?null:(System.String)reader[((int)BridgeColumn.WebRequestContentType - 1)];
			entity.UserName = (reader.IsDBNull(((int)BridgeColumn.UserName - 1)))?null:(System.String)reader[((int)BridgeColumn.UserName - 1)];
			entity.Password = (reader.IsDBNull(((int)BridgeColumn.Password - 1)))?null:(System.String)reader[((int)BridgeColumn.Password - 1)];
			entity.BridgeTypeId = (System.Int32)reader[((int)BridgeColumn.BridgeTypeId - 1)];
			entity.DbConnectionString = (reader.IsDBNull(((int)BridgeColumn.DbConnectionString - 1)))?null:(System.String)reader[((int)BridgeColumn.DbConnectionString - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Bridge"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Bridge"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Bridge entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.IpAddress = Convert.IsDBNull(dataRow["IPAddress"]) ? null : (System.String)dataRow["IPAddress"];
			entity.WebRequestSecurityToken = Convert.IsDBNull(dataRow["WebRequestSecurityToken"]) ? null : (System.String)dataRow["WebRequestSecurityToken"];
			entity.WebRequestApiurl = Convert.IsDBNull(dataRow["WebRequestAPIURL"]) ? null : (System.String)dataRow["WebRequestAPIURL"];
			entity.WebRequestMethod = Convert.IsDBNull(dataRow["WebRequestMethod"]) ? null : (System.String)dataRow["WebRequestMethod"];
			entity.WebRequestContentType = Convert.IsDBNull(dataRow["WebRequestContentType"]) ? null : (System.String)dataRow["WebRequestContentType"];
			entity.UserName = Convert.IsDBNull(dataRow["UserName"]) ? null : (System.String)dataRow["UserName"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.BridgeTypeId = (System.Int32)dataRow["BridgeTypeID"];
			entity.DbConnectionString = Convert.IsDBNull(dataRow["DBConnectionString"]) ? null : (System.String)dataRow["DBConnectionString"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Bridge"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Bridge Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Bridge entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region BridgeTypeIdSource	
			if (CanDeepLoad(entity, "BridgeType|BridgeTypeIdSource", deepLoadType, innerList) 
				&& entity.BridgeTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.BridgeTypeId;
				BridgeType tmpEntity = EntityManager.LocateEntity<BridgeType>(EntityLocator.ConstructKeyFromPkItems(typeof(BridgeType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BridgeTypeIdSource = tmpEntity;
				else
					entity.BridgeTypeIdSource = DataRepository.BridgeTypeProvider.GetById(transactionManager, entity.BridgeTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BridgeTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BridgeTypeProvider.DeepLoad(transactionManager, entity.BridgeTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BridgeTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region BridgeQueueCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BridgeQueue>|BridgeQueueCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeQueueCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BridgeQueueCollection = DataRepository.BridgeQueueProvider.GetByBridgeId(transactionManager, entity.Id);

				if (deep && entity.BridgeQueueCollection.Count > 0)
				{
					deepHandles.Add("BridgeQueueCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BridgeQueue>) DataRepository.BridgeQueueProvider.DeepLoad,
						new object[] { transactionManager, entity.BridgeQueueCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RatedCdrCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RatedCdr>|RatedCdrCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RatedCdrCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RatedCdrCollection = DataRepository.RatedCdrProvider.GetByBridgeId(transactionManager, entity.Id);

				if (deep && entity.RatedCdrCollection.Count > 0)
				{
					deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RatedCdr>) DataRepository.RatedCdrProvider.DeepLoad,
						new object[] { transactionManager, entity.RatedCdrCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Bridge object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Bridge instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Bridge Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Bridge entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region BridgeTypeIdSource
			if (CanDeepSave(entity, "BridgeType|BridgeTypeIdSource", deepSaveType, innerList) 
				&& entity.BridgeTypeIdSource != null)
			{
				DataRepository.BridgeTypeProvider.Save(transactionManager, entity.BridgeTypeIdSource);
				entity.BridgeTypeId = entity.BridgeTypeIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<BridgeQueue>
				if (CanDeepSave(entity.BridgeQueueCollection, "List<BridgeQueue>|BridgeQueueCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BridgeQueue child in entity.BridgeQueueCollection)
					{
						if(child.BridgeIdSource != null)
						{
							child.BridgeId = child.BridgeIdSource.Id;
						}
						else
						{
							child.BridgeId = entity.Id;
						}

					}

					if (entity.BridgeQueueCollection.Count > 0 || entity.BridgeQueueCollection.DeletedItems.Count > 0)
					{
						//DataRepository.BridgeQueueProvider.Save(transactionManager, entity.BridgeQueueCollection);
						
						deepHandles.Add("BridgeQueueCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BridgeQueue >) DataRepository.BridgeQueueProvider.DeepSave,
							new object[] { transactionManager, entity.BridgeQueueCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<RatedCdr>
				if (CanDeepSave(entity.RatedCdrCollection, "List<RatedCdr>|RatedCdrCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RatedCdr child in entity.RatedCdrCollection)
					{
						if(child.BridgeIdSource != null)
						{
							child.BridgeId = child.BridgeIdSource.Id;
						}
						else
						{
							child.BridgeId = entity.Id;
						}

					}

					if (entity.RatedCdrCollection.Count > 0 || entity.RatedCdrCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RatedCdrProvider.Save(transactionManager, entity.RatedCdrCollection);
						
						deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RatedCdr >) DataRepository.RatedCdrProvider.DeepSave,
							new object[] { transactionManager, entity.RatedCdrCollection, deepSaveType, childTypes, innerList }
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
	
	#region BridgeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Bridge</c>
	///</summary>
	public enum BridgeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>BridgeType</c> at BridgeTypeIdSource
		///</summary>
		[ChildEntityType(typeof(BridgeType))]
		BridgeType,
	
		///<summary>
		/// Collection of <c>Bridge</c> as OneToMany for BridgeQueueCollection
		///</summary>
		[ChildEntityType(typeof(TList<BridgeQueue>))]
		BridgeQueueCollection,

		///<summary>
		/// Collection of <c>Bridge</c> as OneToMany for RatedCdrCollection
		///</summary>
		[ChildEntityType(typeof(TList<RatedCdr>))]
		RatedCdrCollection,
	}
	
	#endregion BridgeChildEntityTypes
	
	#region BridgeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BridgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeFilterBuilder : SqlFilterBuilder<BridgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeFilterBuilder class.
		/// </summary>
		public BridgeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeFilterBuilder
	
	#region BridgeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BridgeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Bridge"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeParameterBuilder : ParameterizedSqlFilterBuilder<BridgeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeParameterBuilder class.
		/// </summary>
		public BridgeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeParameterBuilder
} // end namespace
