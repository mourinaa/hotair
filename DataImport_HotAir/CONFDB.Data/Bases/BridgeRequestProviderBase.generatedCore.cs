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
	/// This class is the base class for any <see cref="BridgeRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BridgeRequestProviderBaseCore : EntityProviderBase<CONFDB.Entities.BridgeRequest, CONFDB.Entities.BridgeRequestKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.BridgeRequestKey key)
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
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		Moderator_BridgeRequest_FK Description: 
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(_moderatorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		Moderator_BridgeRequest_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		Moderator_BridgeRequest_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		moderator_BridgeRequest_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		moderator_BridgeRequest_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength,out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_BridgeRequest_FK key.
		///		Moderator_BridgeRequest_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public abstract CONFDB.Entities.TList<BridgeRequest> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		FK_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(System.Int32? _bridgeRequestTypeId)
		{
			int count = -1;
			return GetByBridgeRequestTypeId(_bridgeRequestTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		FK_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(TransactionManager transactionManager, System.Int32? _bridgeRequestTypeId)
		{
			int count = -1;
			return GetByBridgeRequestTypeId(transactionManager, _bridgeRequestTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		FK_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(TransactionManager transactionManager, System.Int32? _bridgeRequestTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByBridgeRequestTypeId(transactionManager, _bridgeRequestTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		fk_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(System.Int32? _bridgeRequestTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBridgeRequestTypeId(null, _bridgeRequestTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		fk_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(System.Int32? _bridgeRequestTypeId, int start, int pageLength,out int count)
		{
			return GetByBridgeRequestTypeId(null, _bridgeRequestTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BridgeRequest_BridgeRequestType key.
		///		FK_BridgeRequest_BridgeRequestType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeRequestTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.BridgeRequest objects.</returns>
		public abstract CONFDB.Entities.TList<BridgeRequest> GetByBridgeRequestTypeId(TransactionManager transactionManager, System.Int32? _bridgeRequestTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.BridgeRequest Get(TransactionManager transactionManager, CONFDB.Entities.BridgeRequestKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key BridgeRequest_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public CONFDB.Entities.BridgeRequest GetById(System.Guid _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeRequest_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public CONFDB.Entities.BridgeRequest GetById(System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeRequest_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public CONFDB.Entities.BridgeRequest GetById(TransactionManager transactionManager, System.Guid _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeRequest_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public CONFDB.Entities.BridgeRequest GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeRequest_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public CONFDB.Entities.BridgeRequest GetById(System.Guid _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the BridgeRequest_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BridgeRequest"/> class.</returns>
		public abstract CONFDB.Entities.BridgeRequest GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(System.Int32 _moderatorId, System.String _processFlag)
		{
			int count = -1;
			return GetByModeratorIdProcessFlag(null,_moderatorId, _processFlag, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(System.Int32 _moderatorId, System.String _processFlag, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorIdProcessFlag(null, _moderatorId, _processFlag, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(TransactionManager transactionManager, System.Int32 _moderatorId, System.String _processFlag)
		{
			int count = -1;
			return GetByModeratorIdProcessFlag(transactionManager, _moderatorId, _processFlag, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(TransactionManager transactionManager, System.Int32 _moderatorId, System.String _processFlag, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorIdProcessFlag(transactionManager, _moderatorId, _processFlag, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(System.Int32 _moderatorId, System.String _processFlag, int start, int pageLength, out int count)
		{
			return GetByModeratorIdProcessFlag(null, _moderatorId, _processFlag, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_BridgeRequest_ProcessFlag_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="_processFlag"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BridgeRequest> GetByModeratorIdProcessFlag(TransactionManager transactionManager, System.Int32 _moderatorId, System.String _processFlag, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;BridgeRequest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;BridgeRequest&gt;"/></returns>
		public static CONFDB.Entities.TList<BridgeRequest> Fill(IDataReader reader, CONFDB.Entities.TList<BridgeRequest> rows, int start, int pageLength)
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
				
				CONFDB.Entities.BridgeRequest c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BridgeRequest")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.BridgeRequestColumn.Id - 1))?Guid.NewGuid():(System.Guid)reader[((int)CONFDB.Entities.BridgeRequestColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<BridgeRequest>(
					key.ToString(), // EntityTrackingKey
					"BridgeRequest",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.BridgeRequest();
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
					c.Id = (System.Guid)reader[((int)BridgeRequestColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.ModeratorId = (System.Int32)reader[((int)BridgeRequestColumn.ModeratorId - 1)];
					c.TransTimeStamp = (System.DateTime)reader[((int)BridgeRequestColumn.TransTimeStamp - 1)];
					c.ProcessFlag = (System.String)reader[((int)BridgeRequestColumn.ProcessFlag - 1)];
					c.BridgeRequestTypeId = (reader.IsDBNull(((int)BridgeRequestColumn.BridgeRequestTypeId - 1)))?null:(System.Int32?)reader[((int)BridgeRequestColumn.BridgeRequestTypeId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BridgeRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeRequest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.BridgeRequest entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader[((int)BridgeRequestColumn.Id - 1)];
			entity.OriginalId = (System.Guid)reader["ID"];
			entity.ModeratorId = (System.Int32)reader[((int)BridgeRequestColumn.ModeratorId - 1)];
			entity.TransTimeStamp = (System.DateTime)reader[((int)BridgeRequestColumn.TransTimeStamp - 1)];
			entity.ProcessFlag = (System.String)reader[((int)BridgeRequestColumn.ProcessFlag - 1)];
			entity.BridgeRequestTypeId = (reader.IsDBNull(((int)BridgeRequestColumn.BridgeRequestTypeId - 1)))?null:(System.Int32?)reader[((int)BridgeRequestColumn.BridgeRequestTypeId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BridgeRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeRequest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.BridgeRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["ID"];
			entity.OriginalId = (System.Guid)dataRow["ID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.TransTimeStamp = (System.DateTime)dataRow["TransTimeStamp"];
			entity.ProcessFlag = (System.String)dataRow["ProcessFlag"];
			entity.BridgeRequestTypeId = Convert.IsDBNull(dataRow["BridgeRequestTypeID"]) ? null : (System.Int32?)dataRow["BridgeRequestTypeID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.BridgeRequest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.BridgeRequest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.BridgeRequest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region BridgeRequestTypeIdSource	
			if (CanDeepLoad(entity, "BridgeRequestType|BridgeRequestTypeIdSource", deepLoadType, innerList) 
				&& entity.BridgeRequestTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BridgeRequestTypeId ?? (int)0);
				BridgeRequestType tmpEntity = EntityManager.LocateEntity<BridgeRequestType>(EntityLocator.ConstructKeyFromPkItems(typeof(BridgeRequestType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BridgeRequestTypeIdSource = tmpEntity;
				else
					entity.BridgeRequestTypeIdSource = DataRepository.BridgeRequestTypeProvider.GetById(transactionManager, (entity.BridgeRequestTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeRequestTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BridgeRequestTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BridgeRequestTypeProvider.DeepLoad(transactionManager, entity.BridgeRequestTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BridgeRequestTypeIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.BridgeRequest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.BridgeRequest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.BridgeRequest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.BridgeRequest entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ModeratorIdSource
			if (CanDeepSave(entity, "Moderator|ModeratorIdSource", deepSaveType, innerList) 
				&& entity.ModeratorIdSource != null)
			{
				DataRepository.ModeratorProvider.Save(transactionManager, entity.ModeratorIdSource);
				entity.ModeratorId = entity.ModeratorIdSource.Id;
			}
			#endregion 
			
			#region BridgeRequestTypeIdSource
			if (CanDeepSave(entity, "BridgeRequestType|BridgeRequestTypeIdSource", deepSaveType, innerList) 
				&& entity.BridgeRequestTypeIdSource != null)
			{
				DataRepository.BridgeRequestTypeProvider.Save(transactionManager, entity.BridgeRequestTypeIdSource);
				entity.BridgeRequestTypeId = entity.BridgeRequestTypeIdSource.Id;
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
	
	#region BridgeRequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.BridgeRequest</c>
	///</summary>
	public enum BridgeRequestChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Moderator</c> at ModeratorIdSource
		///</summary>
		[ChildEntityType(typeof(Moderator))]
		Moderator,
			
		///<summary>
		/// Composite Property for <c>BridgeRequestType</c> at BridgeRequestTypeIdSource
		///</summary>
		[ChildEntityType(typeof(BridgeRequestType))]
		BridgeRequestType,
		}
	
	#endregion BridgeRequestChildEntityTypes
	
	#region BridgeRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BridgeRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestFilterBuilder : SqlFilterBuilder<BridgeRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilterBuilder class.
		/// </summary>
		public BridgeRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestFilterBuilder
	
	#region BridgeRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BridgeRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BridgeRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BridgeRequestParameterBuilder : ParameterizedSqlFilterBuilder<BridgeRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BridgeRequestParameterBuilder class.
		/// </summary>
		public BridgeRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BridgeRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BridgeRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BridgeRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BridgeRequestParameterBuilder
} // end namespace
