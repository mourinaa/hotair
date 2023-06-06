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
	/// This class is the base class for any <see cref="Moderator_DnisProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class Moderator_DnisProviderBaseCore : EntityProviderBase<CONFDB.Entities.Moderator_Dnis, CONFDB.Entities.Moderator_DnisKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.Moderator_DnisKey key)
		{
			return Delete(transactionManager, key.Dnisid, key.ModeratorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dnisid">. Primary Key.</param>
		/// <param name="_moderatorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dnisid, System.Int32 _moderatorId)
		{
			return Delete(null, _dnisid, _moderatorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid">. Primary Key.</param>
		/// <param name="_moderatorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _moderatorId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		DNIS_Moderator_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisid(_dnisid, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		DNIS_Moderator_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisid(transactionManager, _dnisid, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		DNIS_Moderator_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisid(transactionManager, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		dnis_Moderator_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(System.Int32 _dnisid, int start, int pageLength)
		{
			int count =  -1;
			return GetByDnisid(null, _dnisid, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		dnis_Moderator_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dnisid"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(System.Int32 _dnisid, int start, int pageLength,out int count)
		{
			return GetByDnisid(null, _dnisid, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_Moderator_DNIS_FK1 key.
		///		DNIS_Moderator_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Moderator_Dnis objects.</returns>
		public abstract CONFDB.Entities.TList<Moderator_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Moderator_Dnis Get(TransactionManager transactionManager, CONFDB.Entities.Moderator_DnisKey key, int start, int pageLength)
		{
			return GetByDnisidModeratorId(transactionManager, key.Dnisid, key.ModeratorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(System.Int32 _dnisid, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByDnisidModeratorId(null,_dnisid, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(System.Int32 _dnisid, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidModeratorId(null, _dnisid, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByDnisidModeratorId(transactionManager, _dnisid, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidModeratorId(transactionManager, _dnisid, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(System.Int32 _dnisid, System.Int32 _moderatorId, int start, int pageLength, out int count)
		{
			return GetByDnisidModeratorId(null, _dnisid, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator_Dnis"/> class.</returns>
		public abstract CONFDB.Entities.Moderator_Dnis GetByDnisidModeratorId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(null,_moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength, out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DNIS_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator_Dnis> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Moderator_Dnis&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Moderator_Dnis&gt;"/></returns>
		public static CONFDB.Entities.TList<Moderator_Dnis> Fill(IDataReader reader, CONFDB.Entities.TList<Moderator_Dnis> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Moderator_Dnis c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Moderator_Dnis")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.Moderator_DnisColumn.Dnisid - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.Moderator_DnisColumn.Dnisid - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.Moderator_DnisColumn.ModeratorId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.Moderator_DnisColumn.ModeratorId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Moderator_Dnis>(
					key.ToString(), // EntityTrackingKey
					"Moderator_Dnis",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Moderator_Dnis();
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
					c.Dnisid = (System.Int32)reader[((int)Moderator_DnisColumn.Dnisid - 1)];
					c.OriginalDnisid = c.Dnisid;
					c.ModeratorId = (System.Int32)reader[((int)Moderator_DnisColumn.ModeratorId - 1)];
					c.OriginalModeratorId = c.ModeratorId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Moderator_Dnis"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator_Dnis"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Moderator_Dnis entity)
		{
			if (!reader.Read()) return;
			
			entity.Dnisid = (System.Int32)reader[((int)Moderator_DnisColumn.Dnisid - 1)];
			entity.OriginalDnisid = (System.Int32)reader["DNISID"];
			entity.ModeratorId = (System.Int32)reader[((int)Moderator_DnisColumn.ModeratorId - 1)];
			entity.OriginalModeratorId = (System.Int32)reader["ModeratorID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Moderator_Dnis"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator_Dnis"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Moderator_Dnis entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Dnisid = (System.Int32)dataRow["DNISID"];
			entity.OriginalDnisid = (System.Int32)dataRow["DNISID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.OriginalModeratorId = (System.Int32)dataRow["ModeratorID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator_Dnis"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Moderator_Dnis Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Moderator_Dnis entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DnisidSource	
			if (CanDeepLoad(entity, "Dnis|DnisidSource", deepLoadType, innerList) 
				&& entity.DnisidSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Dnisid;
				Dnis tmpEntity = EntityManager.LocateEntity<Dnis>(EntityLocator.ConstructKeyFromPkItems(typeof(Dnis), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DnisidSource = tmpEntity;
				else
					entity.DnisidSource = DataRepository.DnisProvider.GetById(transactionManager, entity.Dnisid);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisidSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DnisidSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DnisProvider.DeepLoad(transactionManager, entity.DnisidSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DnisidSource

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
		/// Deep Save the entire object graph of the CONFDB.Entities.Moderator_Dnis object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Moderator_Dnis instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Moderator_Dnis Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Moderator_Dnis entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DnisidSource
			if (CanDeepSave(entity, "Dnis|DnisidSource", deepSaveType, innerList) 
				&& entity.DnisidSource != null)
			{
				DataRepository.DnisProvider.Save(transactionManager, entity.DnisidSource);
				entity.Dnisid = entity.DnisidSource.Id;
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
	
	#region Moderator_DnisChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Moderator_Dnis</c>
	///</summary>
	public enum Moderator_DnisChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Dnis</c> at DnisidSource
		///</summary>
		[ChildEntityType(typeof(Dnis))]
		Dnis,
			
		///<summary>
		/// Composite Property for <c>Moderator</c> at ModeratorIdSource
		///</summary>
		[ChildEntityType(typeof(Moderator))]
		Moderator,
		}
	
	#endregion Moderator_DnisChildEntityTypes
	
	#region Moderator_DnisFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;Moderator_DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisFilterBuilder : SqlFilterBuilder<Moderator_DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilterBuilder class.
		/// </summary>
		public Moderator_DnisFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_DnisFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_DnisFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_DnisFilterBuilder
	
	#region Moderator_DnisParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;Moderator_DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Moderator_DnisParameterBuilder : ParameterizedSqlFilterBuilder<Moderator_DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisParameterBuilder class.
		/// </summary>
		public Moderator_DnisParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Moderator_DnisParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Moderator_DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Moderator_DnisParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Moderator_DnisParameterBuilder
} // end namespace
