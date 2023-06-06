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
	/// This class is the base class for any <see cref="ValidTicketStateChangesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ValidTicketStateChangesProviderBaseCore : EntityProviderBase<CONFDB.Entities.ValidTicketStateChanges, CONFDB.Entities.ValidTicketStateChangesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ValidTicketStateChangesKey key)
		{
			return Delete(transactionManager, key.FromStatusId, key.ToStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_fromStatusId">. Primary Key.</param>
		/// <param name="_toStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _fromStatusId, System.Int32 _toStatusId)
		{
			return Delete(null, _fromStatusId, _toStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId">. Primary Key.</param>
		/// <param name="_toStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _fromStatusId, System.Int32 _toStatusId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		FK_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(System.Int32 _fromStatusId)
		{
			int count = -1;
			return GetByFromStatusId(_fromStatusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		FK_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId)
		{
			int count = -1;
			return GetByFromStatusId(transactionManager, _fromStatusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		FK_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromStatusId(transactionManager, _fromStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		fk_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fromStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(System.Int32 _fromStatusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromStatusId(null, _fromStatusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		fk_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(System.Int32 _fromStatusId, int start, int pageLength,out int count)
		{
			return GetByFromStatusId(null, _fromStatusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus key.
		///		FK_ValidTicketStateChanges_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public abstract CONFDB.Entities.TList<ValidTicketStateChanges> GetByFromStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		FK_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="_toStatusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByToStatusId(_toStatusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		FK_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toStatusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(TransactionManager transactionManager, System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByToStatusId(transactionManager, _toStatusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		FK_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(TransactionManager transactionManager, System.Int32 _toStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByToStatusId(transactionManager, _toStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		fk_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_toStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(System.Int32 _toStatusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByToStatusId(null, _toStatusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		fk_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_toStatusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(System.Int32 _toStatusId, int start, int pageLength,out int count)
		{
			return GetByToStatusId(null, _toStatusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ValidTicketStateChanges_TicketStatus1 key.
		///		FK_ValidTicketStateChanges_TicketStatus1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ValidTicketStateChanges objects.</returns>
		public abstract CONFDB.Entities.TList<ValidTicketStateChanges> GetByToStatusId(TransactionManager transactionManager, System.Int32 _toStatusId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.ValidTicketStateChanges Get(TransactionManager transactionManager, CONFDB.Entities.ValidTicketStateChangesKey key, int start, int pageLength)
		{
			return GetByFromStatusIdToStatusId(transactionManager, key.FromStatusId, key.ToStatusId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(System.Int32 _fromStatusId, System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByFromStatusIdToStatusId(null,_fromStatusId, _toStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(System.Int32 _fromStatusId, System.Int32 _toStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromStatusIdToStatusId(null, _fromStatusId, _toStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId, System.Int32 _toStatusId)
		{
			int count = -1;
			return GetByFromStatusIdToStatusId(transactionManager, _fromStatusId, _toStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId, System.Int32 _toStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromStatusIdToStatusId(transactionManager, _fromStatusId, _toStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(System.Int32 _fromStatusId, System.Int32 _toStatusId, int start, int pageLength, out int count)
		{
			return GetByFromStatusIdToStatusId(null, _fromStatusId, _toStatusId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ValidTicketStateChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fromStatusId"></param>
		/// <param name="_toStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> class.</returns>
		public abstract CONFDB.Entities.ValidTicketStateChanges GetByFromStatusIdToStatusId(TransactionManager transactionManager, System.Int32 _fromStatusId, System.Int32 _toStatusId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ValidTicketStateChanges&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ValidTicketStateChanges&gt;"/></returns>
		public static CONFDB.Entities.TList<ValidTicketStateChanges> Fill(IDataReader reader, CONFDB.Entities.TList<ValidTicketStateChanges> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ValidTicketStateChanges c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ValidTicketStateChanges")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ValidTicketStateChangesColumn.FromStatusId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ValidTicketStateChangesColumn.FromStatusId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ValidTicketStateChangesColumn.ToStatusId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ValidTicketStateChangesColumn.ToStatusId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ValidTicketStateChanges>(
					key.ToString(), // EntityTrackingKey
					"ValidTicketStateChanges",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ValidTicketStateChanges();
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
					c.FromStatusId = (System.Int32)reader[((int)ValidTicketStateChangesColumn.FromStatusId - 1)];
					c.OriginalFromStatusId = c.FromStatusId;
					c.ToStatusId = (System.Int32)reader[((int)ValidTicketStateChangesColumn.ToStatusId - 1)];
					c.OriginalToStatusId = c.ToStatusId;
					c.Reason = (reader.IsDBNull(((int)ValidTicketStateChangesColumn.Reason - 1)))?null:(System.String)reader[((int)ValidTicketStateChangesColumn.Reason - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ValidTicketStateChanges"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ValidTicketStateChanges entity)
		{
			if (!reader.Read()) return;
			
			entity.FromStatusId = (System.Int32)reader[((int)ValidTicketStateChangesColumn.FromStatusId - 1)];
			entity.OriginalFromStatusId = (System.Int32)reader["FromStatusID"];
			entity.ToStatusId = (System.Int32)reader[((int)ValidTicketStateChangesColumn.ToStatusId - 1)];
			entity.OriginalToStatusId = (System.Int32)reader["ToStatusID"];
			entity.Reason = (reader.IsDBNull(((int)ValidTicketStateChangesColumn.Reason - 1)))?null:(System.String)reader[((int)ValidTicketStateChangesColumn.Reason - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ValidTicketStateChanges"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ValidTicketStateChanges"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ValidTicketStateChanges entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FromStatusId = (System.Int32)dataRow["FromStatusID"];
			entity.OriginalFromStatusId = (System.Int32)dataRow["FromStatusID"];
			entity.ToStatusId = (System.Int32)dataRow["ToStatusID"];
			entity.OriginalToStatusId = (System.Int32)dataRow["ToStatusID"];
			entity.Reason = Convert.IsDBNull(dataRow["Reason"]) ? null : (System.String)dataRow["Reason"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ValidTicketStateChanges"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ValidTicketStateChanges Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ValidTicketStateChanges entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FromStatusIdSource	
			if (CanDeepLoad(entity, "TicketStatus|FromStatusIdSource", deepLoadType, innerList) 
				&& entity.FromStatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FromStatusId;
				TicketStatus tmpEntity = EntityManager.LocateEntity<TicketStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromStatusIdSource = tmpEntity;
				else
					entity.FromStatusIdSource = DataRepository.TicketStatusProvider.GetById(transactionManager, entity.FromStatusId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FromStatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FromStatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketStatusProvider.DeepLoad(transactionManager, entity.FromStatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FromStatusIdSource

			#region ToStatusIdSource	
			if (CanDeepLoad(entity, "TicketStatus|ToStatusIdSource", deepLoadType, innerList) 
				&& entity.ToStatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ToStatusId;
				TicketStatus tmpEntity = EntityManager.LocateEntity<TicketStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToStatusIdSource = tmpEntity;
				else
					entity.ToStatusIdSource = DataRepository.TicketStatusProvider.GetById(transactionManager, entity.ToStatusId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ToStatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ToStatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketStatusProvider.DeepLoad(transactionManager, entity.ToStatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ToStatusIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ValidTicketStateChanges object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ValidTicketStateChanges instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ValidTicketStateChanges Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ValidTicketStateChanges entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FromStatusIdSource
			if (CanDeepSave(entity, "TicketStatus|FromStatusIdSource", deepSaveType, innerList) 
				&& entity.FromStatusIdSource != null)
			{
				DataRepository.TicketStatusProvider.Save(transactionManager, entity.FromStatusIdSource);
				entity.FromStatusId = entity.FromStatusIdSource.Id;
			}
			#endregion 
			
			#region ToStatusIdSource
			if (CanDeepSave(entity, "TicketStatus|ToStatusIdSource", deepSaveType, innerList) 
				&& entity.ToStatusIdSource != null)
			{
				DataRepository.TicketStatusProvider.Save(transactionManager, entity.ToStatusIdSource);
				entity.ToStatusId = entity.ToStatusIdSource.Id;
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
	
	#region ValidTicketStateChangesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ValidTicketStateChanges</c>
	///</summary>
	public enum ValidTicketStateChangesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>TicketStatus</c> at FromStatusIdSource
		///</summary>
		[ChildEntityType(typeof(TicketStatus))]
		TicketStatus,
		}
	
	#endregion ValidTicketStateChangesChildEntityTypes
	
	#region ValidTicketStateChangesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ValidTicketStateChangesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesFilterBuilder : SqlFilterBuilder<ValidTicketStateChangesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilterBuilder class.
		/// </summary>
		public ValidTicketStateChangesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ValidTicketStateChangesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ValidTicketStateChangesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ValidTicketStateChangesFilterBuilder
	
	#region ValidTicketStateChangesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ValidTicketStateChangesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ValidTicketStateChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ValidTicketStateChangesParameterBuilder : ParameterizedSqlFilterBuilder<ValidTicketStateChangesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesParameterBuilder class.
		/// </summary>
		public ValidTicketStateChangesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ValidTicketStateChangesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ValidTicketStateChangesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ValidTicketStateChangesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ValidTicketStateChangesParameterBuilder
} // end namespace
