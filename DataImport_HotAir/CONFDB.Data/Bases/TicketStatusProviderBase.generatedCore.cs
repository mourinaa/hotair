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
	/// This class is the base class for any <see cref="TicketStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TicketStatusProviderBaseCore : EntityProviderBase<CONFDB.Entities.TicketStatus, CONFDB.Entities.TicketStatusKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByToStatusIdFromValidTicketStateChanges
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="_toStatusId"></param>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByToStatusIdFromValidTicketStateChanges(null,_toStatusId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_toStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(System.Int32 _toStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByToStatusIdFromValidTicketStateChanges(null, _toStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(TransactionManager transactionManager, System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByToStatusIdFromValidTicketStateChanges(transactionManager, _toStatusId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(TransactionManager transactionManager, System.Int32 _toStatusId,int start, int pageLength)
		{
			int count = -1;
			return GetByToStatusIdFromValidTicketStateChanges(transactionManager, _toStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(System.Int32 _toStatusId,int start, int pageLength, out int count)
		{
			
			return GetByToStatusIdFromValidTicketStateChanges(null, _toStatusId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets TicketStatus objects from the datasource by ToStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_toStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TicketStatus objects.</returns>
		public abstract TList<TicketStatus> GetByToStatusIdFromValidTicketStateChanges(TransactionManager transactionManager,System.Int32 _toStatusId, int start, int pageLength, out int count);
		
		#endregion GetByToStatusIdFromValidTicketStateChanges
		
		#region GetByFromStatusIdFromValidTicketStateChanges
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(System.Int32 _fromStatusId)
		{
			int count = -1;
			return GetByFromStatusIdFromValidTicketStateChanges(null,_fromStatusId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fromStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(System.Int32 _fromStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromStatusIdFromValidTicketStateChanges(null, _fromStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(TransactionManager transactionManager, System.Int32 _fromStatusId)
		{
			int count = -1;
			return GetByFromStatusIdFromValidTicketStateChanges(transactionManager, _fromStatusId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(TransactionManager transactionManager, System.Int32 _fromStatusId,int start, int pageLength)
		{
			int count = -1;
			return GetByFromStatusIdFromValidTicketStateChanges(transactionManager, _fromStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of TicketStatus objects.</returns>
		public TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(System.Int32 _fromStatusId,int start, int pageLength, out int count)
		{
			
			return GetByFromStatusIdFromValidTicketStateChanges(null, _fromStatusId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets TicketStatus objects from the datasource by FromStatusID in the
		///		ValidTicketStateChanges table. Table TicketStatus is related to table TicketStatus
		///		through the (M:N) relationship defined in the ValidTicketStateChanges table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_fromStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of TicketStatus objects.</returns>
		public abstract TList<TicketStatus> GetByFromStatusIdFromValidTicketStateChanges(TransactionManager transactionManager,System.Int32 _fromStatusId, int start, int pageLength, out int count);
		
		#endregion GetByFromStatusIdFromValidTicketStateChanges
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TicketStatusKey key)
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
		public override CONFDB.Entities.TicketStatus Get(TransactionManager transactionManager, CONFDB.Entities.TicketStatusKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TicketStatus_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public CONFDB.Entities.TicketStatus GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatus_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public CONFDB.Entities.TicketStatus GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatus_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public CONFDB.Entities.TicketStatus GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatus_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public CONFDB.Entities.TicketStatus GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatus_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public CONFDB.Entities.TicketStatus GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatus_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatus"/> class.</returns>
		public abstract CONFDB.Entities.TicketStatus GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TicketStatus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TicketStatus&gt;"/></returns>
		public static CONFDB.Entities.TList<TicketStatus> Fill(IDataReader reader, CONFDB.Entities.TList<TicketStatus> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TicketStatus c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TicketStatus")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TicketStatusColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TicketStatusColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TicketStatus>(
					key.ToString(), // EntityTrackingKey
					"TicketStatus",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TicketStatus();
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
					c.Id = (System.Int32)reader[((int)TicketStatusColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Abbreviation = (reader.IsDBNull(((int)TicketStatusColumn.Abbreviation - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Abbreviation - 1)];
					c.Name = (reader.IsDBNull(((int)TicketStatusColumn.Name - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)TicketStatusColumn.Description - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Description - 1)];
					c.DisplayOrder = (System.Int32)reader[((int)TicketStatusColumn.DisplayOrder - 1)];
					c.Deleted = (reader.IsDBNull(((int)TicketStatusColumn.Deleted - 1)))?null:(System.Boolean?)reader[((int)TicketStatusColumn.Deleted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TicketStatus entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)TicketStatusColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.Abbreviation = (reader.IsDBNull(((int)TicketStatusColumn.Abbreviation - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Abbreviation - 1)];
			entity.Name = (reader.IsDBNull(((int)TicketStatusColumn.Name - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)TicketStatusColumn.Description - 1)))?null:(System.String)reader[((int)TicketStatusColumn.Description - 1)];
			entity.DisplayOrder = (System.Int32)reader[((int)TicketStatusColumn.DisplayOrder - 1)];
			entity.Deleted = (reader.IsDBNull(((int)TicketStatusColumn.Deleted - 1)))?null:(System.Boolean?)reader[((int)TicketStatusColumn.Deleted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TicketStatus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.Abbreviation = Convert.IsDBNull(dataRow["Abbreviation"]) ? null : (System.String)dataRow["Abbreviation"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.Deleted = Convert.IsDBNull(dataRow["Deleted"]) ? null : (System.Boolean?)dataRow["Deleted"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketStatus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TicketStatus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region TicketStatusHistoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TicketStatusHistory>|TicketStatusHistoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketStatusHistoryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TicketStatusHistoryCollection = DataRepository.TicketStatusHistoryProvider.GetByStatusId(transactionManager, entity.Id);

				if (deep && entity.TicketStatusHistoryCollection.Count > 0)
				{
					deepHandles.Add("TicketStatusHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TicketStatusHistory>) DataRepository.TicketStatusHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketStatusHistoryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<TicketStatus>|FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges", deepLoadType, innerList))
			{
				entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges = DataRepository.TicketStatusProvider.GetByToStatusIdFromValidTicketStateChanges(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges != null)
				{
					deepHandles.Add("FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< TicketStatus >) DataRepository.TicketStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ValidTicketStateChangesCollectionGetByToStatusId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ValidTicketStateChanges>|ValidTicketStateChangesCollectionGetByToStatusId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ValidTicketStateChangesCollectionGetByToStatusId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ValidTicketStateChangesCollectionGetByToStatusId = DataRepository.ValidTicketStateChangesProvider.GetByToStatusId(transactionManager, entity.Id);

				if (deep && entity.ValidTicketStateChangesCollectionGetByToStatusId.Count > 0)
				{
					deepHandles.Add("ValidTicketStateChangesCollectionGetByToStatusId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ValidTicketStateChanges>) DataRepository.ValidTicketStateChangesProvider.DeepLoad,
						new object[] { transactionManager, entity.ValidTicketStateChangesCollectionGetByToStatusId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region TicketCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Ticket>|TicketCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TicketCollection = DataRepository.TicketProvider.GetByStatusId(transactionManager, entity.Id);

				if (deep && entity.TicketCollection.Count > 0)
				{
					deepHandles.Add("TicketCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Ticket>) DataRepository.TicketProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ValidTicketStateChangesCollectionGetByFromStatusId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ValidTicketStateChanges>|ValidTicketStateChangesCollectionGetByFromStatusId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ValidTicketStateChangesCollectionGetByFromStatusId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ValidTicketStateChangesCollectionGetByFromStatusId = DataRepository.ValidTicketStateChangesProvider.GetByFromStatusId(transactionManager, entity.Id);

				if (deep && entity.ValidTicketStateChangesCollectionGetByFromStatusId.Count > 0)
				{
					deepHandles.Add("ValidTicketStateChangesCollectionGetByFromStatusId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ValidTicketStateChanges>) DataRepository.ValidTicketStateChangesProvider.DeepLoad,
						new object[] { transactionManager, entity.ValidTicketStateChangesCollectionGetByFromStatusId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<TicketStatus>|ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges", deepLoadType, innerList))
			{
				entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges = DataRepository.TicketStatusProvider.GetByFromStatusIdFromValidTicketStateChanges(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges != null)
				{
					deepHandles.Add("ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< TicketStatus >) DataRepository.TicketStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TicketStatus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TicketStatus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketStatus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TicketStatus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges>
			if (CanDeepSave(entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges, "List<TicketStatus>|FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges", deepSaveType, innerList))
			{
				if (entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges.Count > 0 || entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges.DeletedItems.Count > 0)
				{
					DataRepository.TicketStatusProvider.Save(transactionManager, entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges); 
					deepHandles.Add("FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<TicketStatus>) DataRepository.TicketStatusProvider.DeepSave,
						new object[] { transactionManager, entity.FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges>
			if (CanDeepSave(entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges, "List<TicketStatus>|ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges", deepSaveType, innerList))
			{
				if (entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges.Count > 0 || entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges.DeletedItems.Count > 0)
				{
					DataRepository.TicketStatusProvider.Save(transactionManager, entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges); 
					deepHandles.Add("ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<TicketStatus>) DataRepository.TicketStatusProvider.DeepSave,
						new object[] { transactionManager, entity.ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<TicketStatusHistory>
				if (CanDeepSave(entity.TicketStatusHistoryCollection, "List<TicketStatusHistory>|TicketStatusHistoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TicketStatusHistory child in entity.TicketStatusHistoryCollection)
					{
						if(child.StatusIdSource != null)
						{
							child.StatusId = child.StatusIdSource.Id;
						}
						else
						{
							child.StatusId = entity.Id;
						}

					}

					if (entity.TicketStatusHistoryCollection.Count > 0 || entity.TicketStatusHistoryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TicketStatusHistoryProvider.Save(transactionManager, entity.TicketStatusHistoryCollection);
						
						deepHandles.Add("TicketStatusHistoryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< TicketStatusHistory >) DataRepository.TicketStatusHistoryProvider.DeepSave,
							new object[] { transactionManager, entity.TicketStatusHistoryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ValidTicketStateChanges>
				if (CanDeepSave(entity.ValidTicketStateChangesCollectionGetByToStatusId, "List<ValidTicketStateChanges>|ValidTicketStateChangesCollectionGetByToStatusId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ValidTicketStateChanges child in entity.ValidTicketStateChangesCollectionGetByToStatusId)
					{
						if(child.ToStatusIdSource != null)
						{
								child.ToStatusId = child.ToStatusIdSource.Id;
						}

						if(child.FromStatusIdSource != null)
						{
								child.FromStatusId = child.FromStatusIdSource.Id;
						}

					}

					if (entity.ValidTicketStateChangesCollectionGetByToStatusId.Count > 0 || entity.ValidTicketStateChangesCollectionGetByToStatusId.DeletedItems.Count > 0)
					{
						//DataRepository.ValidTicketStateChangesProvider.Save(transactionManager, entity.ValidTicketStateChangesCollectionGetByToStatusId);
						
						deepHandles.Add("ValidTicketStateChangesCollectionGetByToStatusId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ValidTicketStateChanges >) DataRepository.ValidTicketStateChangesProvider.DeepSave,
							new object[] { transactionManager, entity.ValidTicketStateChangesCollectionGetByToStatusId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Ticket>
				if (CanDeepSave(entity.TicketCollection, "List<Ticket>|TicketCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Ticket child in entity.TicketCollection)
					{
						if(child.StatusIdSource != null)
						{
							child.StatusId = child.StatusIdSource.Id;
						}
						else
						{
							child.StatusId = entity.Id;
						}

					}

					if (entity.TicketCollection.Count > 0 || entity.TicketCollection.DeletedItems.Count > 0)
					{
						//DataRepository.TicketProvider.Save(transactionManager, entity.TicketCollection);
						
						deepHandles.Add("TicketCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Ticket >) DataRepository.TicketProvider.DeepSave,
							new object[] { transactionManager, entity.TicketCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ValidTicketStateChanges>
				if (CanDeepSave(entity.ValidTicketStateChangesCollectionGetByFromStatusId, "List<ValidTicketStateChanges>|ValidTicketStateChangesCollectionGetByFromStatusId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ValidTicketStateChanges child in entity.ValidTicketStateChangesCollectionGetByFromStatusId)
					{
						if(child.ToStatusIdSource != null)
						{
								child.ToStatusId = child.ToStatusIdSource.Id;
						}

						if(child.FromStatusIdSource != null)
						{
								child.FromStatusId = child.FromStatusIdSource.Id;
						}

					}

					if (entity.ValidTicketStateChangesCollectionGetByFromStatusId.Count > 0 || entity.ValidTicketStateChangesCollectionGetByFromStatusId.DeletedItems.Count > 0)
					{
						//DataRepository.ValidTicketStateChangesProvider.Save(transactionManager, entity.ValidTicketStateChangesCollectionGetByFromStatusId);
						
						deepHandles.Add("ValidTicketStateChangesCollectionGetByFromStatusId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ValidTicketStateChanges >) DataRepository.ValidTicketStateChangesProvider.DeepSave,
							new object[] { transactionManager, entity.ValidTicketStateChangesCollectionGetByFromStatusId, deepSaveType, childTypes, innerList }
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
	
	#region TicketStatusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TicketStatus</c>
	///</summary>
	public enum TicketStatusChildEntityTypes
	{

		///<summary>
		/// Collection of <c>TicketStatus</c> as OneToMany for TicketStatusHistoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<TicketStatusHistory>))]
		TicketStatusHistoryCollection,

		///<summary>
		/// Collection of <c>TicketStatus</c> as ManyToMany for TicketStatusCollection_From_ValidTicketStateChanges
		///</summary>
		[ChildEntityType(typeof(TList<TicketStatus>))]
		FromStatusIdTicketStatusCollection_From_ValidTicketStateChanges,

		///<summary>
		/// Collection of <c>TicketStatus</c> as OneToMany for ValidTicketStateChangesCollection
		///</summary>
		[ChildEntityType(typeof(TList<ValidTicketStateChanges>))]
		ValidTicketStateChangesCollectionGetByToStatusId,

		///<summary>
		/// Collection of <c>TicketStatus</c> as OneToMany for TicketCollection
		///</summary>
		[ChildEntityType(typeof(TList<Ticket>))]
		TicketCollection,

		///<summary>
		/// Collection of <c>TicketStatus</c> as OneToMany for ValidTicketStateChangesCollection
		///</summary>
		[ChildEntityType(typeof(TList<ValidTicketStateChanges>))]
		ValidTicketStateChangesCollectionGetByFromStatusId,

		///<summary>
		/// Collection of <c>TicketStatus</c> as ManyToMany for TicketStatusCollection_From_ValidTicketStateChanges
		///</summary>
		[ChildEntityType(typeof(TList<TicketStatus>))]
		ToStatusIdTicketStatusCollection_From_ValidTicketStateChanges,
	}
	
	#endregion TicketStatusChildEntityTypes
	
	#region TicketStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TicketStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusFilterBuilder : SqlFilterBuilder<TicketStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilterBuilder class.
		/// </summary>
		public TicketStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusFilterBuilder
	
	#region TicketStatusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TicketStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusParameterBuilder : ParameterizedSqlFilterBuilder<TicketStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusParameterBuilder class.
		/// </summary>
		public TicketStatusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusParameterBuilder
} // end namespace
