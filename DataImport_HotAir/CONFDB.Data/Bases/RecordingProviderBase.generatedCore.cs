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
	/// This class is the base class for any <see cref="RecordingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RecordingProviderBaseCore : EntityProviderBase<CONFDB.Entities.Recording, CONFDB.Entities.RecordingKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.RecordingKey key)
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
		public override CONFDB.Entities.Recording Get(TransactionManager transactionManager, CONFDB.Entities.RecordingKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TCRecordings_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public CONFDB.Entities.Recording GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TCRecordings_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public CONFDB.Entities.Recording GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TCRecordings_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public CONFDB.Entities.Recording GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TCRecordings_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public CONFDB.Entities.Recording GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TCRecordings_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public CONFDB.Entities.Recording GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TCRecordings_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Recording"/> class.</returns>
		public abstract CONFDB.Entities.Recording GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByModeratorId(System.Int32? _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(null,_moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByModeratorId(System.Int32? _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByModeratorId(TransactionManager transactionManager, System.Int32? _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByModeratorId(TransactionManager transactionManager, System.Int32? _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByModeratorId(System.Int32? _moderatorId, int start, int pageLength, out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Recording> GetByModeratorId(TransactionManager transactionManager, System.Int32? _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="_replayCode"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByReplayCode(System.String _replayCode)
		{
			int count = -1;
			return GetByReplayCode(null,_replayCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="_replayCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByReplayCode(System.String _replayCode, int start, int pageLength)
		{
			int count = -1;
			return GetByReplayCode(null, _replayCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByReplayCode(TransactionManager transactionManager, System.String _replayCode)
		{
			int count = -1;
			return GetByReplayCode(transactionManager, _replayCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByReplayCode(TransactionManager transactionManager, System.String _replayCode, int start, int pageLength)
		{
			int count = -1;
			return GetByReplayCode(transactionManager, _replayCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="_replayCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByReplayCode(System.String _replayCode, int start, int pageLength, out int count)
		{
			return GetByReplayCode(null, _replayCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecordings_ReplayCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_replayCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Recording> GetByReplayCode(TransactionManager transactionManager, System.String _replayCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="_recordingGuid"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByRecordingGuid(System.String _recordingGuid)
		{
			int count = -1;
			return GetByRecordingGuid(null,_recordingGuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="_recordingGuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByRecordingGuid(System.String _recordingGuid, int start, int pageLength)
		{
			int count = -1;
			return GetByRecordingGuid(null, _recordingGuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingGuid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByRecordingGuid(TransactionManager transactionManager, System.String _recordingGuid)
		{
			int count = -1;
			return GetByRecordingGuid(transactionManager, _recordingGuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingGuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByRecordingGuid(TransactionManager transactionManager, System.String _recordingGuid, int start, int pageLength)
		{
			int count = -1;
			return GetByRecordingGuid(transactionManager, _recordingGuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="_recordingGuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Recording> GetByRecordingGuid(System.String _recordingGuid, int start, int pageLength, out int count)
		{
			return GetByRecordingGuid(null, _recordingGuid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TCRecording_RecordingGuid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingGuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Recording> GetByRecordingGuid(TransactionManager transactionManager, System.String _recordingGuid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_Recording_GetParticipantList 
		
		/// <summary>
		///	This method wrap the 'p_Recording_GetParticipantList' stored procedure. 
		/// </summary>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetParticipantList(System.Int32? recordingId)
		{
			return GetParticipantList(null, 0, int.MaxValue , recordingId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Recording_GetParticipantList' stored procedure. 
		/// </summary>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetParticipantList(int start, int pageLength, System.Int32? recordingId)
		{
			return GetParticipantList(null, start, pageLength , recordingId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Recording_GetParticipantList' stored procedure. 
		/// </summary>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetParticipantList(TransactionManager transactionManager, System.Int32? recordingId)
		{
			return GetParticipantList(transactionManager, 0, int.MaxValue , recordingId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Recording_GetParticipantList' stored procedure. 
		/// </summary>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetParticipantList(TransactionManager transactionManager, int start, int pageLength , System.Int32? recordingId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Recording&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Recording&gt;"/></returns>
		public static CONFDB.Entities.TList<Recording> Fill(IDataReader reader, CONFDB.Entities.TList<Recording> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Recording c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Recording")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.RecordingColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.RecordingColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Recording>(
					key.ToString(), // EntityTrackingKey
					"Recording",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Recording();
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
					c.Id = (System.Int32)reader[((int)RecordingColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)RecordingColumn.WholesalerId - 1)];
					c.BridgeId = (reader.IsDBNull(((int)RecordingColumn.BridgeId - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.BridgeId - 1)];
					c.RecordingStartTime = (reader.IsDBNull(((int)RecordingColumn.RecordingStartTime - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.RecordingStartTime - 1)];
					c.RecordingEndTime = (reader.IsDBNull(((int)RecordingColumn.RecordingEndTime - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.RecordingEndTime - 1)];
					c.ModeratorCode = (reader.IsDBNull(((int)RecordingColumn.ModeratorCode - 1)))?null:(System.String)reader[((int)RecordingColumn.ModeratorCode - 1)];
					c.PassCode = (reader.IsDBNull(((int)RecordingColumn.PassCode - 1)))?null:(System.String)reader[((int)RecordingColumn.PassCode - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)RecordingColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (reader.IsDBNull(((int)RecordingColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.SecCustomerNumber - 1)];
					c.RecordingDirectory = (reader.IsDBNull(((int)RecordingColumn.RecordingDirectory - 1)))?null:(System.String)reader[((int)RecordingColumn.RecordingDirectory - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)RecordingColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)RecordingColumn.UniqueConferenceId - 1)];
					c.ReplayCode = (reader.IsDBNull(((int)RecordingColumn.ReplayCode - 1)))?null:(System.String)reader[((int)RecordingColumn.ReplayCode - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)RecordingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.CreatedDate - 1)];
					c.ProcessFlag = (reader.IsDBNull(((int)RecordingColumn.ProcessFlag - 1)))?null:(System.String)reader[((int)RecordingColumn.ProcessFlag - 1)];
					c.EmailSent = (reader.IsDBNull(((int)RecordingColumn.EmailSent - 1)))?null:(System.Boolean?)reader[((int)RecordingColumn.EmailSent - 1)];
					c.RpFileNumber = (reader.IsDBNull(((int)RecordingColumn.RpFileNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.RpFileNumber - 1)];
					c.ModeratorId = (reader.IsDBNull(((int)RecordingColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.ModeratorId - 1)];
					c.Notes = (reader.IsDBNull(((int)RecordingColumn.Notes - 1)))?null:(System.String)reader[((int)RecordingColumn.Notes - 1)];
					c.Mp3Flag = (reader.IsDBNull(((int)RecordingColumn.Mp3Flag - 1)))?null:(System.String)reader[((int)RecordingColumn.Mp3Flag - 1)];
					c.Mp3SizeInKb = (reader.IsDBNull(((int)RecordingColumn.Mp3SizeInKb - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.Mp3SizeInKb - 1)];
					c.Enabled = (reader.IsDBNull(((int)RecordingColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)RecordingColumn.Enabled - 1)];
					c.StorageDuration = (reader.IsDBNull(((int)RecordingColumn.StorageDuration - 1)))?null:(System.Int16?)reader[((int)RecordingColumn.StorageDuration - 1)];
					c.BillingDuration = (reader.IsDBNull(((int)RecordingColumn.BillingDuration - 1)))?null:(System.Int16?)reader[((int)RecordingColumn.BillingDuration - 1)];
					c.BillingId = (reader.IsDBNull(((int)RecordingColumn.BillingId - 1)))?null:(System.String)reader[((int)RecordingColumn.BillingId - 1)];
					c.DurationSec = (reader.IsDBNull(((int)RecordingColumn.DurationSec - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.DurationSec - 1)];
					c.AuxiliaryConferenceId = (reader.IsDBNull(((int)RecordingColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)RecordingColumn.AuxiliaryConferenceId - 1)];
					c.MediaType = (reader.IsDBNull(((int)RecordingColumn.MediaType - 1)))?null:(System.String)reader[((int)RecordingColumn.MediaType - 1)];
					c.HostedLinkExpiryDate = (reader.IsDBNull(((int)RecordingColumn.HostedLinkExpiryDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.HostedLinkExpiryDate - 1)];
					c.HostedLinkType = (reader.IsDBNull(((int)RecordingColumn.HostedLinkType - 1)))?null:(System.String)reader[((int)RecordingColumn.HostedLinkType - 1)];
					c.HostedLinkUrl = (reader.IsDBNull(((int)RecordingColumn.HostedLinkUrl - 1)))?null:(System.String)reader[((int)RecordingColumn.HostedLinkUrl - 1)];
					c.ExtendRecordingDate = (reader.IsDBNull(((int)RecordingColumn.ExtendRecordingDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.ExtendRecordingDate - 1)];
					c.RecordingGuid = (reader.IsDBNull(((int)RecordingColumn.RecordingGuid - 1)))?null:(System.String)reader[((int)RecordingColumn.RecordingGuid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Recording"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Recording"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Recording entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)RecordingColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)RecordingColumn.WholesalerId - 1)];
			entity.BridgeId = (reader.IsDBNull(((int)RecordingColumn.BridgeId - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.BridgeId - 1)];
			entity.RecordingStartTime = (reader.IsDBNull(((int)RecordingColumn.RecordingStartTime - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.RecordingStartTime - 1)];
			entity.RecordingEndTime = (reader.IsDBNull(((int)RecordingColumn.RecordingEndTime - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.RecordingEndTime - 1)];
			entity.ModeratorCode = (reader.IsDBNull(((int)RecordingColumn.ModeratorCode - 1)))?null:(System.String)reader[((int)RecordingColumn.ModeratorCode - 1)];
			entity.PassCode = (reader.IsDBNull(((int)RecordingColumn.PassCode - 1)))?null:(System.String)reader[((int)RecordingColumn.PassCode - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)RecordingColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)RecordingColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.SecCustomerNumber - 1)];
			entity.RecordingDirectory = (reader.IsDBNull(((int)RecordingColumn.RecordingDirectory - 1)))?null:(System.String)reader[((int)RecordingColumn.RecordingDirectory - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)RecordingColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)RecordingColumn.UniqueConferenceId - 1)];
			entity.ReplayCode = (reader.IsDBNull(((int)RecordingColumn.ReplayCode - 1)))?null:(System.String)reader[((int)RecordingColumn.ReplayCode - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)RecordingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.CreatedDate - 1)];
			entity.ProcessFlag = (reader.IsDBNull(((int)RecordingColumn.ProcessFlag - 1)))?null:(System.String)reader[((int)RecordingColumn.ProcessFlag - 1)];
			entity.EmailSent = (reader.IsDBNull(((int)RecordingColumn.EmailSent - 1)))?null:(System.Boolean?)reader[((int)RecordingColumn.EmailSent - 1)];
			entity.RpFileNumber = (reader.IsDBNull(((int)RecordingColumn.RpFileNumber - 1)))?null:(System.String)reader[((int)RecordingColumn.RpFileNumber - 1)];
			entity.ModeratorId = (reader.IsDBNull(((int)RecordingColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.ModeratorId - 1)];
			entity.Notes = (reader.IsDBNull(((int)RecordingColumn.Notes - 1)))?null:(System.String)reader[((int)RecordingColumn.Notes - 1)];
			entity.Mp3Flag = (reader.IsDBNull(((int)RecordingColumn.Mp3Flag - 1)))?null:(System.String)reader[((int)RecordingColumn.Mp3Flag - 1)];
			entity.Mp3SizeInKb = (reader.IsDBNull(((int)RecordingColumn.Mp3SizeInKb - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.Mp3SizeInKb - 1)];
			entity.Enabled = (reader.IsDBNull(((int)RecordingColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)RecordingColumn.Enabled - 1)];
			entity.StorageDuration = (reader.IsDBNull(((int)RecordingColumn.StorageDuration - 1)))?null:(System.Int16?)reader[((int)RecordingColumn.StorageDuration - 1)];
			entity.BillingDuration = (reader.IsDBNull(((int)RecordingColumn.BillingDuration - 1)))?null:(System.Int16?)reader[((int)RecordingColumn.BillingDuration - 1)];
			entity.BillingId = (reader.IsDBNull(((int)RecordingColumn.BillingId - 1)))?null:(System.String)reader[((int)RecordingColumn.BillingId - 1)];
			entity.DurationSec = (reader.IsDBNull(((int)RecordingColumn.DurationSec - 1)))?null:(System.Int32?)reader[((int)RecordingColumn.DurationSec - 1)];
			entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)RecordingColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)RecordingColumn.AuxiliaryConferenceId - 1)];
			entity.MediaType = (reader.IsDBNull(((int)RecordingColumn.MediaType - 1)))?null:(System.String)reader[((int)RecordingColumn.MediaType - 1)];
			entity.HostedLinkExpiryDate = (reader.IsDBNull(((int)RecordingColumn.HostedLinkExpiryDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.HostedLinkExpiryDate - 1)];
			entity.HostedLinkType = (reader.IsDBNull(((int)RecordingColumn.HostedLinkType - 1)))?null:(System.String)reader[((int)RecordingColumn.HostedLinkType - 1)];
			entity.HostedLinkUrl = (reader.IsDBNull(((int)RecordingColumn.HostedLinkUrl - 1)))?null:(System.String)reader[((int)RecordingColumn.HostedLinkUrl - 1)];
			entity.ExtendRecordingDate = (reader.IsDBNull(((int)RecordingColumn.ExtendRecordingDate - 1)))?null:(System.DateTime?)reader[((int)RecordingColumn.ExtendRecordingDate - 1)];
			entity.RecordingGuid = (reader.IsDBNull(((int)RecordingColumn.RecordingGuid - 1)))?null:(System.String)reader[((int)RecordingColumn.RecordingGuid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Recording"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Recording"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Recording entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.BridgeId = Convert.IsDBNull(dataRow["BridgeID"]) ? null : (System.Int32?)dataRow["BridgeID"];
			entity.RecordingStartTime = Convert.IsDBNull(dataRow["RecordingStartTime"]) ? null : (System.DateTime?)dataRow["RecordingStartTime"];
			entity.RecordingEndTime = Convert.IsDBNull(dataRow["RecordingEndTime"]) ? null : (System.DateTime?)dataRow["RecordingEndTime"];
			entity.ModeratorCode = Convert.IsDBNull(dataRow["ModeratorCode"]) ? null : (System.String)dataRow["ModeratorCode"];
			entity.PassCode = Convert.IsDBNull(dataRow["PassCode"]) ? null : (System.String)dataRow["PassCode"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = Convert.IsDBNull(dataRow["SecCustomerNumber"]) ? null : (System.String)dataRow["SecCustomerNumber"];
			entity.RecordingDirectory = Convert.IsDBNull(dataRow["RecordingDirectory"]) ? null : (System.String)dataRow["RecordingDirectory"];
			entity.UniqueConferenceId = Convert.IsDBNull(dataRow["UniqueConferenceID"]) ? null : (System.String)dataRow["UniqueConferenceID"];
			entity.ReplayCode = Convert.IsDBNull(dataRow["ReplayCode"]) ? null : (System.String)dataRow["ReplayCode"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.ProcessFlag = Convert.IsDBNull(dataRow["ProcessFlag"]) ? null : (System.String)dataRow["ProcessFlag"];
			entity.EmailSent = Convert.IsDBNull(dataRow["EmailSent"]) ? null : (System.Boolean?)dataRow["EmailSent"];
			entity.RpFileNumber = Convert.IsDBNull(dataRow["RPFileNumber"]) ? null : (System.String)dataRow["RPFileNumber"];
			entity.ModeratorId = Convert.IsDBNull(dataRow["ModeratorID"]) ? null : (System.Int32?)dataRow["ModeratorID"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.Mp3Flag = Convert.IsDBNull(dataRow["Mp3Flag"]) ? null : (System.String)dataRow["Mp3Flag"];
			entity.Mp3SizeInKb = Convert.IsDBNull(dataRow["Mp3SizeInKB"]) ? null : (System.Int32?)dataRow["Mp3SizeInKB"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.StorageDuration = Convert.IsDBNull(dataRow["StorageDuration"]) ? null : (System.Int16?)dataRow["StorageDuration"];
			entity.BillingDuration = Convert.IsDBNull(dataRow["BillingDuration"]) ? null : (System.Int16?)dataRow["BillingDuration"];
			entity.BillingId = Convert.IsDBNull(dataRow["BillingID"]) ? null : (System.String)dataRow["BillingID"];
			entity.DurationSec = Convert.IsDBNull(dataRow["DurationSec"]) ? null : (System.Int32?)dataRow["DurationSec"];
			entity.AuxiliaryConferenceId = Convert.IsDBNull(dataRow["AuxiliaryConferenceID"]) ? null : (System.String)dataRow["AuxiliaryConferenceID"];
			entity.MediaType = Convert.IsDBNull(dataRow["MediaType"]) ? null : (System.String)dataRow["MediaType"];
			entity.HostedLinkExpiryDate = Convert.IsDBNull(dataRow["HostedLinkExpiryDate"]) ? null : (System.DateTime?)dataRow["HostedLinkExpiryDate"];
			entity.HostedLinkType = Convert.IsDBNull(dataRow["HostedLinkType"]) ? null : (System.String)dataRow["HostedLinkType"];
			entity.HostedLinkUrl = Convert.IsDBNull(dataRow["HostedLinkURL"]) ? null : (System.String)dataRow["HostedLinkURL"];
			entity.ExtendRecordingDate = Convert.IsDBNull(dataRow["ExtendRecordingDate"]) ? null : (System.DateTime?)dataRow["ExtendRecordingDate"];
			entity.RecordingGuid = Convert.IsDBNull(dataRow["RecordingGuid"]) ? null : (System.String)dataRow["RecordingGuid"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Recording"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Recording Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Recording entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region RecordingParticipantUsageCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RecordingParticipantUsage>|RecordingParticipantUsageCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RecordingParticipantUsageCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RecordingParticipantUsageCollection = DataRepository.RecordingParticipantUsageProvider.GetByRecordingId(transactionManager, entity.Id);

				if (deep && entity.RecordingParticipantUsageCollection.Count > 0)
				{
					deepHandles.Add("RecordingParticipantUsageCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RecordingParticipantUsage>) DataRepository.RecordingParticipantUsageProvider.DeepLoad,
						new object[] { transactionManager, entity.RecordingParticipantUsageCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Recording object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Recording instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Recording Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Recording entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<RecordingParticipantUsage>
				if (CanDeepSave(entity.RecordingParticipantUsageCollection, "List<RecordingParticipantUsage>|RecordingParticipantUsageCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RecordingParticipantUsage child in entity.RecordingParticipantUsageCollection)
					{
						if(child.RecordingIdSource != null)
						{
							child.RecordingId = child.RecordingIdSource.Id;
						}
						else
						{
							child.RecordingId = entity.Id;
						}

					}

					if (entity.RecordingParticipantUsageCollection.Count > 0 || entity.RecordingParticipantUsageCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RecordingParticipantUsageProvider.Save(transactionManager, entity.RecordingParticipantUsageCollection);
						
						deepHandles.Add("RecordingParticipantUsageCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RecordingParticipantUsage >) DataRepository.RecordingParticipantUsageProvider.DeepSave,
							new object[] { transactionManager, entity.RecordingParticipantUsageCollection, deepSaveType, childTypes, innerList }
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
	
	#region RecordingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Recording</c>
	///</summary>
	public enum RecordingChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Recording</c> as OneToMany for RecordingParticipantUsageCollection
		///</summary>
		[ChildEntityType(typeof(TList<RecordingParticipantUsage>))]
		RecordingParticipantUsageCollection,
	}
	
	#endregion RecordingChildEntityTypes
	
	#region RecordingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RecordingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingFilterBuilder : SqlFilterBuilder<RecordingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingFilterBuilder class.
		/// </summary>
		public RecordingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingFilterBuilder
	
	#region RecordingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RecordingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Recording"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParameterBuilder : ParameterizedSqlFilterBuilder<RecordingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParameterBuilder class.
		/// </summary>
		public RecordingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingParameterBuilder
} // end namespace
