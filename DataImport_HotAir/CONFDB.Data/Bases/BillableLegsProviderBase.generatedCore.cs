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
	/// This class is the base class for any <see cref="BillableLegsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BillableLegsProviderBaseCore : EntityProviderBase<CONFDB.Entities.BillableLegs, CONFDB.Entities.BillableLegsKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.BillableLegsKey key)
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
		public override CONFDB.Entities.BillableLegs Get(TransactionManager transactionManager, CONFDB.Entities.BillableLegsKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key BillableLegs_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public CONFDB.Entities.BillableLegs GetById(System.Guid _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BillableLegs_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public CONFDB.Entities.BillableLegs GetById(System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BillableLegs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public CONFDB.Entities.BillableLegs GetById(TransactionManager transactionManager, System.Guid _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BillableLegs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public CONFDB.Entities.BillableLegs GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the BillableLegs_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public CONFDB.Entities.BillableLegs GetById(System.Guid _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the BillableLegs_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.BillableLegs"/> class.</returns>
		public abstract CONFDB.Entities.BillableLegs GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByConferenceIdBridgeIdWholesalerId(null,_conferenceId, _bridgeId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByConferenceIdBridgeIdWholesalerId(null, _conferenceId, _bridgeId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByConferenceIdBridgeIdWholesalerId(transactionManager, _conferenceId, _bridgeId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByConferenceIdBridgeIdWholesalerId(transactionManager, _conferenceId, _bridgeId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByConferenceIdBridgeIdWholesalerId(null, _conferenceId, _bridgeId, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int16 _bridgeId, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByWholesalerIdModeratorId(null,_wholesalerId, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdModeratorId(null, _wholesalerId, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByWholesalerIdModeratorId(transactionManager, _wholesalerId, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdModeratorId(transactionManager, _wholesalerId, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdModeratorId(null, _wholesalerId, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(null,_moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength, out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(null,_wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_CKSUM index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime)
		{
			int count = -1;
			return GetByWholesalerIdStartTimeEndTime(null,_wholesalerId, _startTime, _endTime, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdStartTimeEndTime(null, _wholesalerId, _startTime, _endTime, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime)
		{
			int count = -1;
			return GetByWholesalerIdStartTimeEndTime(transactionManager, _wholesalerId, _startTime, _endTime, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdStartTimeEndTime(transactionManager, _wholesalerId, _startTime, _endTime, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdStartTimeEndTime(null, _wholesalerId, _startTime, _endTime, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(System.String _referenceNumber)
		{
			int count = -1;
			return GetByReferenceNumber(null,_referenceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(System.String _referenceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceNumber(null, _referenceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber)
		{
			int count = -1;
			return GetByReferenceNumber(transactionManager, _referenceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceNumber(transactionManager, _referenceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(System.String _referenceNumber, int start, int pageLength, out int count)
		{
			return GetByReferenceNumber(null, _referenceNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_ReferenceNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByBilledDate(System.DateTime? _billedDate)
		{
			int count = -1;
			return GetByBilledDate(null,_billedDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByBilledDate(System.DateTime? _billedDate, int start, int pageLength)
		{
			int count = -1;
			return GetByBilledDate(null, _billedDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate)
		{
			int count = -1;
			return GetByBilledDate(transactionManager, _billedDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate, int start, int pageLength)
		{
			int count = -1;
			return GetByBilledDate(transactionManager, _billedDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public CONFDB.Entities.TList<BillableLegs> GetByBilledDate(System.DateTime? _billedDate, int start, int pageLength, out int count)
		{
			return GetByBilledDate(null, _billedDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<BillableLegs> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;BillableLegs&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;BillableLegs&gt;"/></returns>
		public static CONFDB.Entities.TList<BillableLegs> Fill(IDataReader reader, CONFDB.Entities.TList<BillableLegs> rows, int start, int pageLength)
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
				
				CONFDB.Entities.BillableLegs c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BillableLegs")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.BillableLegsColumn.Id - 1))?Guid.Empty:(System.Guid)reader[((int)CONFDB.Entities.BillableLegsColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<BillableLegs>(
					key.ToString(), // EntityTrackingKey
					"BillableLegs",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.BillableLegs();
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
					c.Id = (System.Guid)reader[((int)BillableLegsColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.ConferenceId = (System.String)reader[((int)BillableLegsColumn.ConferenceId - 1)];
					c.ModeratorId = (System.Int32)reader[((int)BillableLegsColumn.ModeratorId - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)BillableLegsColumn.WholesalerId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.WholesalerId - 1)];
					c.ModeratorCode = (System.String)reader[((int)BillableLegsColumn.ModeratorCode - 1)];
					c.PassCode = (System.String)reader[((int)BillableLegsColumn.PassCode - 1)];
					c.ModeratorName = (reader.IsDBNull(((int)BillableLegsColumn.ModeratorName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ModeratorName - 1)];
					c.Moderator = (System.Int32)reader[((int)BillableLegsColumn.Moderator - 1)];
					c.ExternalCustomerNumber = (reader.IsDBNull(((int)BillableLegsColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ExternalCustomerNumber - 1)];
					c.ExternalModeratorNumber = (reader.IsDBNull(((int)BillableLegsColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ExternalModeratorNumber - 1)];
					c.ReferenceNumber = (reader.IsDBNull(((int)BillableLegsColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ReferenceNumber - 1)];
					c.StartTime = (System.DateTime)reader[((int)BillableLegsColumn.StartTime - 1)];
					c.EndTime = (System.DateTime)reader[((int)BillableLegsColumn.EndTime - 1)];
					c.ElapsedTime = (System.Int32)reader[((int)BillableLegsColumn.ElapsedTime - 1)];
					c.BridgeId = (System.Int16)reader[((int)BillableLegsColumn.BridgeId - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)BillableLegsColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.UniqueConferenceId - 1)];
					c.AuxiliaryConferenceId = (reader.IsDBNull(((int)BillableLegsColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.AuxiliaryConferenceId - 1)];
					c.Dnis = (reader.IsDBNull(((int)BillableLegsColumn.Dnis - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Dnis - 1)];
					c.DialNumber = (reader.IsDBNull(((int)BillableLegsColumn.DialNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.DialNumber - 1)];
					c.Ani = (reader.IsDBNull(((int)BillableLegsColumn.Ani - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Ani - 1)];
					c.ParticipantName = (reader.IsDBNull(((int)BillableLegsColumn.ParticipantName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ParticipantName - 1)];
					c.Destination = (reader.IsDBNull(((int)BillableLegsColumn.Destination - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Destination - 1)];
					c.AccessTypeId = (System.Int32)reader[((int)BillableLegsColumn.AccessTypeId - 1)];
					c.ConnectProductRateId = (System.Int32)reader[((int)BillableLegsColumn.ConnectProductRateId - 1)];
					c.BridgeProductRateId = (System.Int32)reader[((int)BillableLegsColumn.BridgeProductRateId - 1)];
					c.LdProductRateId = (System.Int32)reader[((int)BillableLegsColumn.LdProductRateId - 1)];
					c.ProductRateTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.ProductRateTaxableValue - 1)];
					c.CustomerTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.CustomerTaxableValue - 1)];
					c.WsTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.WsTaxableValue - 1)];
					c.RetailConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.RetailConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailConnectCharge - 1)];
					c.RetailBridgeRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailBridgeRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailBridgeRate - 1)];
					c.RetailLdRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailLdRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLdRate - 1)];
					c.RetailCurrency = (reader.IsDBNull(((int)BillableLegsColumn.RetailCurrency - 1)))?null:(System.String)reader[((int)BillableLegsColumn.RetailCurrency - 1)];
					c.RetailBillingInterval = (System.Int32)reader[((int)BillableLegsColumn.RetailBillingInterval - 1)];
					c.RetailTotalConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalConnectCharge - 1)];
					c.RetailTotalBridge = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalBridge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalBridge - 1)];
					c.RetailTotalLd = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalLd - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalLd - 1)];
					c.RetailTotal = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotal - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotal - 1)];
					c.RetailLocalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLocalTaxRate - 1)];
					c.RetailFederalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailFederalTaxRate - 1)];
					c.RetailLocalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailLocalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLocalTax - 1)];
					c.RetailFederalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailFederalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailFederalTax - 1)];
					c.RetailTotalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalTax - 1)];
					c.WsConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.WsConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsConnectCharge - 1)];
					c.WsBridgeRate = (reader.IsDBNull(((int)BillableLegsColumn.WsBridgeRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsBridgeRate - 1)];
					c.WsldRate = (reader.IsDBNull(((int)BillableLegsColumn.WsldRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsldRate - 1)];
					c.WsCurrency = (reader.IsDBNull(((int)BillableLegsColumn.WsCurrency - 1)))?null:(System.String)reader[((int)BillableLegsColumn.WsCurrency - 1)];
					c.WsBillingInterval = (System.Int32)reader[((int)BillableLegsColumn.WsBillingInterval - 1)];
					c.WsTotalConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalConnectCharge - 1)];
					c.WsTotalBridge = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalBridge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalBridge - 1)];
					c.WsTotalLd = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalLd - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalLd - 1)];
					c.WsTotal = (reader.IsDBNull(((int)BillableLegsColumn.WsTotal - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotal - 1)];
					c.WsLocalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.WsLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsLocalTaxRate - 1)];
					c.WsFederalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.WsFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsFederalTaxRate - 1)];
					c.WsLocalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsLocalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsLocalTax - 1)];
					c.WsFederalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsFederalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsFederalTax - 1)];
					c.WsTotalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalTax - 1)];
					c.BillingStatus = (reader.IsDBNull(((int)BillableLegsColumn.BillingStatus - 1)))?null:(System.Int16?)reader[((int)BillableLegsColumn.BillingStatus - 1)];
					c.BilledDate = (reader.IsDBNull(((int)BillableLegsColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)BillableLegsColumn.BilledDate - 1)];
					c.ProcessedDate = (reader.IsDBNull(((int)BillableLegsColumn.ProcessedDate - 1)))?null:(System.DateTime?)reader[((int)BillableLegsColumn.ProcessedDate - 1)];
					c.RatedToZero = (reader.IsDBNull(((int)BillableLegsColumn.RatedToZero - 1)))?null:(System.Boolean?)reader[((int)BillableLegsColumn.RatedToZero - 1)];
					c.ProductName = (reader.IsDBNull(((int)BillableLegsColumn.ProductName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ProductName - 1)];
					c.ProductNameAlt = (reader.IsDBNull(((int)BillableLegsColumn.ProductNameAlt - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ProductNameAlt - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BillableLegs"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BillableLegs"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.BillableLegs entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader[((int)BillableLegsColumn.Id - 1)];
			entity.OriginalId = (System.Guid)reader["ID"];
			entity.ConferenceId = (System.String)reader[((int)BillableLegsColumn.ConferenceId - 1)];
			entity.ModeratorId = (System.Int32)reader[((int)BillableLegsColumn.ModeratorId - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)BillableLegsColumn.WholesalerId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.WholesalerId - 1)];
			entity.ModeratorCode = (System.String)reader[((int)BillableLegsColumn.ModeratorCode - 1)];
			entity.PassCode = (System.String)reader[((int)BillableLegsColumn.PassCode - 1)];
			entity.ModeratorName = (reader.IsDBNull(((int)BillableLegsColumn.ModeratorName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ModeratorName - 1)];
			entity.Moderator = (System.Int32)reader[((int)BillableLegsColumn.Moderator - 1)];
			entity.ExternalCustomerNumber = (reader.IsDBNull(((int)BillableLegsColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ExternalCustomerNumber - 1)];
			entity.ExternalModeratorNumber = (reader.IsDBNull(((int)BillableLegsColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ExternalModeratorNumber - 1)];
			entity.ReferenceNumber = (reader.IsDBNull(((int)BillableLegsColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ReferenceNumber - 1)];
			entity.StartTime = (System.DateTime)reader[((int)BillableLegsColumn.StartTime - 1)];
			entity.EndTime = (System.DateTime)reader[((int)BillableLegsColumn.EndTime - 1)];
			entity.ElapsedTime = (System.Int32)reader[((int)BillableLegsColumn.ElapsedTime - 1)];
			entity.BridgeId = (System.Int16)reader[((int)BillableLegsColumn.BridgeId - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)BillableLegsColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.UniqueConferenceId - 1)];
			entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)BillableLegsColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)BillableLegsColumn.AuxiliaryConferenceId - 1)];
			entity.Dnis = (reader.IsDBNull(((int)BillableLegsColumn.Dnis - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Dnis - 1)];
			entity.DialNumber = (reader.IsDBNull(((int)BillableLegsColumn.DialNumber - 1)))?null:(System.String)reader[((int)BillableLegsColumn.DialNumber - 1)];
			entity.Ani = (reader.IsDBNull(((int)BillableLegsColumn.Ani - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Ani - 1)];
			entity.ParticipantName = (reader.IsDBNull(((int)BillableLegsColumn.ParticipantName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ParticipantName - 1)];
			entity.Destination = (reader.IsDBNull(((int)BillableLegsColumn.Destination - 1)))?null:(System.String)reader[((int)BillableLegsColumn.Destination - 1)];
			entity.AccessTypeId = (System.Int32)reader[((int)BillableLegsColumn.AccessTypeId - 1)];
			entity.ConnectProductRateId = (System.Int32)reader[((int)BillableLegsColumn.ConnectProductRateId - 1)];
			entity.BridgeProductRateId = (System.Int32)reader[((int)BillableLegsColumn.BridgeProductRateId - 1)];
			entity.LdProductRateId = (System.Int32)reader[((int)BillableLegsColumn.LdProductRateId - 1)];
			entity.ProductRateTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.ProductRateTaxableValue - 1)];
			entity.CustomerTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.CustomerTaxableValue - 1)];
			entity.WsTaxableValue = (System.Int32)reader[((int)BillableLegsColumn.WsTaxableValue - 1)];
			entity.RetailConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.RetailConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailConnectCharge - 1)];
			entity.RetailBridgeRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailBridgeRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailBridgeRate - 1)];
			entity.RetailLdRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailLdRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLdRate - 1)];
			entity.RetailCurrency = (reader.IsDBNull(((int)BillableLegsColumn.RetailCurrency - 1)))?null:(System.String)reader[((int)BillableLegsColumn.RetailCurrency - 1)];
			entity.RetailBillingInterval = (System.Int32)reader[((int)BillableLegsColumn.RetailBillingInterval - 1)];
			entity.RetailTotalConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalConnectCharge - 1)];
			entity.RetailTotalBridge = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalBridge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalBridge - 1)];
			entity.RetailTotalLd = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalLd - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalLd - 1)];
			entity.RetailTotal = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotal - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotal - 1)];
			entity.RetailLocalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLocalTaxRate - 1)];
			entity.RetailFederalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.RetailFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailFederalTaxRate - 1)];
			entity.RetailLocalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailLocalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailLocalTax - 1)];
			entity.RetailFederalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailFederalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailFederalTax - 1)];
			entity.RetailTotalTax = (reader.IsDBNull(((int)BillableLegsColumn.RetailTotalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.RetailTotalTax - 1)];
			entity.WsConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.WsConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsConnectCharge - 1)];
			entity.WsBridgeRate = (reader.IsDBNull(((int)BillableLegsColumn.WsBridgeRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsBridgeRate - 1)];
			entity.WsldRate = (reader.IsDBNull(((int)BillableLegsColumn.WsldRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsldRate - 1)];
			entity.WsCurrency = (reader.IsDBNull(((int)BillableLegsColumn.WsCurrency - 1)))?null:(System.String)reader[((int)BillableLegsColumn.WsCurrency - 1)];
			entity.WsBillingInterval = (System.Int32)reader[((int)BillableLegsColumn.WsBillingInterval - 1)];
			entity.WsTotalConnectCharge = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalConnectCharge - 1)];
			entity.WsTotalBridge = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalBridge - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalBridge - 1)];
			entity.WsTotalLd = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalLd - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalLd - 1)];
			entity.WsTotal = (reader.IsDBNull(((int)BillableLegsColumn.WsTotal - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotal - 1)];
			entity.WsLocalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.WsLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsLocalTaxRate - 1)];
			entity.WsFederalTaxRate = (reader.IsDBNull(((int)BillableLegsColumn.WsFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsFederalTaxRate - 1)];
			entity.WsLocalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsLocalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsLocalTax - 1)];
			entity.WsFederalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsFederalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsFederalTax - 1)];
			entity.WsTotalTax = (reader.IsDBNull(((int)BillableLegsColumn.WsTotalTax - 1)))?null:(System.Decimal?)reader[((int)BillableLegsColumn.WsTotalTax - 1)];
			entity.BillingStatus = (reader.IsDBNull(((int)BillableLegsColumn.BillingStatus - 1)))?null:(System.Int16?)reader[((int)BillableLegsColumn.BillingStatus - 1)];
			entity.BilledDate = (reader.IsDBNull(((int)BillableLegsColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)BillableLegsColumn.BilledDate - 1)];
			entity.ProcessedDate = (reader.IsDBNull(((int)BillableLegsColumn.ProcessedDate - 1)))?null:(System.DateTime?)reader[((int)BillableLegsColumn.ProcessedDate - 1)];
			entity.RatedToZero = (reader.IsDBNull(((int)BillableLegsColumn.RatedToZero - 1)))?null:(System.Boolean?)reader[((int)BillableLegsColumn.RatedToZero - 1)];
			entity.ProductName = (reader.IsDBNull(((int)BillableLegsColumn.ProductName - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ProductName - 1)];
			entity.ProductNameAlt = (reader.IsDBNull(((int)BillableLegsColumn.ProductNameAlt - 1)))?null:(System.String)reader[((int)BillableLegsColumn.ProductNameAlt - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.BillableLegs"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.BillableLegs"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.BillableLegs entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["ID"];
			entity.OriginalId = (System.Guid)dataRow["ID"];
			entity.ConferenceId = (System.String)dataRow["ConferenceID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
			entity.ModeratorCode = (System.String)dataRow["ModeratorCode"];
			entity.PassCode = (System.String)dataRow["PassCode"];
			entity.ModeratorName = Convert.IsDBNull(dataRow["ModeratorName"]) ? null : (System.String)dataRow["ModeratorName"];
			entity.Moderator = (System.Int32)dataRow["Moderator"];
			entity.ExternalCustomerNumber = Convert.IsDBNull(dataRow["ExternalCustomerNumber"]) ? null : (System.String)dataRow["ExternalCustomerNumber"];
			entity.ExternalModeratorNumber = Convert.IsDBNull(dataRow["ExternalModeratorNumber"]) ? null : (System.String)dataRow["ExternalModeratorNumber"];
			entity.ReferenceNumber = Convert.IsDBNull(dataRow["ReferenceNumber"]) ? null : (System.String)dataRow["ReferenceNumber"];
			entity.StartTime = (System.DateTime)dataRow["StartTime"];
			entity.EndTime = (System.DateTime)dataRow["EndTime"];
			entity.ElapsedTime = (System.Int32)dataRow["ElapsedTime"];
			entity.BridgeId = (System.Int16)dataRow["BridgeID"];
			entity.UniqueConferenceId = Convert.IsDBNull(dataRow["UniqueConferenceID"]) ? null : (System.String)dataRow["UniqueConferenceID"];
			entity.AuxiliaryConferenceId = Convert.IsDBNull(dataRow["AuxiliaryConferenceID"]) ? null : (System.String)dataRow["AuxiliaryConferenceID"];
			entity.Dnis = Convert.IsDBNull(dataRow["DNIS"]) ? null : (System.String)dataRow["DNIS"];
			entity.DialNumber = Convert.IsDBNull(dataRow["DialNumber"]) ? null : (System.String)dataRow["DialNumber"];
			entity.Ani = Convert.IsDBNull(dataRow["ANI"]) ? null : (System.String)dataRow["ANI"];
			entity.ParticipantName = Convert.IsDBNull(dataRow["ParticipantName"]) ? null : (System.String)dataRow["ParticipantName"];
			entity.Destination = Convert.IsDBNull(dataRow["Destination"]) ? null : (System.String)dataRow["Destination"];
			entity.AccessTypeId = (System.Int32)dataRow["AccessTypeID"];
			entity.ConnectProductRateId = (System.Int32)dataRow["ConnectProductRateID"];
			entity.BridgeProductRateId = (System.Int32)dataRow["BridgeProductRateID"];
			entity.LdProductRateId = (System.Int32)dataRow["LDProductRateID"];
			entity.ProductRateTaxableValue = (System.Int32)dataRow["ProductRateTaxableValue"];
			entity.CustomerTaxableValue = (System.Int32)dataRow["CustomerTaxableValue"];
			entity.WsTaxableValue = (System.Int32)dataRow["WSTaxableValue"];
			entity.RetailConnectCharge = Convert.IsDBNull(dataRow["RetailConnectCharge"]) ? null : (System.Decimal?)dataRow["RetailConnectCharge"];
			entity.RetailBridgeRate = Convert.IsDBNull(dataRow["RetailBridgeRate"]) ? null : (System.Decimal?)dataRow["RetailBridgeRate"];
			entity.RetailLdRate = Convert.IsDBNull(dataRow["RetailLDRate"]) ? null : (System.Decimal?)dataRow["RetailLDRate"];
			entity.RetailCurrency = Convert.IsDBNull(dataRow["RetailCurrency"]) ? null : (System.String)dataRow["RetailCurrency"];
			entity.RetailBillingInterval = (System.Int32)dataRow["RetailBillingInterval"];
			entity.RetailTotalConnectCharge = Convert.IsDBNull(dataRow["RetailTotalConnectCharge"]) ? null : (System.Decimal?)dataRow["RetailTotalConnectCharge"];
			entity.RetailTotalBridge = Convert.IsDBNull(dataRow["RetailTotalBridge"]) ? null : (System.Decimal?)dataRow["RetailTotalBridge"];
			entity.RetailTotalLd = Convert.IsDBNull(dataRow["RetailTotalLD"]) ? null : (System.Decimal?)dataRow["RetailTotalLD"];
			entity.RetailTotal = Convert.IsDBNull(dataRow["RetailTotal"]) ? null : (System.Decimal?)dataRow["RetailTotal"];
			entity.RetailLocalTaxRate = Convert.IsDBNull(dataRow["RetailLocalTaxRate"]) ? null : (System.Decimal?)dataRow["RetailLocalTaxRate"];
			entity.RetailFederalTaxRate = Convert.IsDBNull(dataRow["RetailFederalTaxRate"]) ? null : (System.Decimal?)dataRow["RetailFederalTaxRate"];
			entity.RetailLocalTax = Convert.IsDBNull(dataRow["RetailLocalTax"]) ? null : (System.Decimal?)dataRow["RetailLocalTax"];
			entity.RetailFederalTax = Convert.IsDBNull(dataRow["RetailFederalTax"]) ? null : (System.Decimal?)dataRow["RetailFederalTax"];
			entity.RetailTotalTax = Convert.IsDBNull(dataRow["RetailTotalTax"]) ? null : (System.Decimal?)dataRow["RetailTotalTax"];
			entity.WsConnectCharge = Convert.IsDBNull(dataRow["WSConnectCharge"]) ? null : (System.Decimal?)dataRow["WSConnectCharge"];
			entity.WsBridgeRate = Convert.IsDBNull(dataRow["WSBridgeRate"]) ? null : (System.Decimal?)dataRow["WSBridgeRate"];
			entity.WsldRate = Convert.IsDBNull(dataRow["WSLDRate"]) ? null : (System.Decimal?)dataRow["WSLDRate"];
			entity.WsCurrency = Convert.IsDBNull(dataRow["WSCurrency"]) ? null : (System.String)dataRow["WSCurrency"];
			entity.WsBillingInterval = (System.Int32)dataRow["WSBillingInterval"];
			entity.WsTotalConnectCharge = Convert.IsDBNull(dataRow["WSTotalConnectCharge"]) ? null : (System.Decimal?)dataRow["WSTotalConnectCharge"];
			entity.WsTotalBridge = Convert.IsDBNull(dataRow["WSTotalBridge"]) ? null : (System.Decimal?)dataRow["WSTotalBridge"];
			entity.WsTotalLd = Convert.IsDBNull(dataRow["WSTotalLD"]) ? null : (System.Decimal?)dataRow["WSTotalLD"];
			entity.WsTotal = Convert.IsDBNull(dataRow["WSTotal"]) ? null : (System.Decimal?)dataRow["WSTotal"];
			entity.WsLocalTaxRate = Convert.IsDBNull(dataRow["WSLocalTaxRate"]) ? null : (System.Decimal?)dataRow["WSLocalTaxRate"];
			entity.WsFederalTaxRate = Convert.IsDBNull(dataRow["WSFederalTaxRate"]) ? null : (System.Decimal?)dataRow["WSFederalTaxRate"];
			entity.WsLocalTax = Convert.IsDBNull(dataRow["WSLocalTax"]) ? null : (System.Decimal?)dataRow["WSLocalTax"];
			entity.WsFederalTax = Convert.IsDBNull(dataRow["WSFederalTax"]) ? null : (System.Decimal?)dataRow["WSFederalTax"];
			entity.WsTotalTax = Convert.IsDBNull(dataRow["WSTotalTax"]) ? null : (System.Decimal?)dataRow["WSTotalTax"];
			entity.BillingStatus = Convert.IsDBNull(dataRow["BillingStatus"]) ? null : (System.Int16?)dataRow["BillingStatus"];
			entity.BilledDate = Convert.IsDBNull(dataRow["BilledDate"]) ? null : (System.DateTime?)dataRow["BilledDate"];
			entity.ProcessedDate = Convert.IsDBNull(dataRow["ProcessedDate"]) ? null : (System.DateTime?)dataRow["ProcessedDate"];
			entity.RatedToZero = Convert.IsDBNull(dataRow["RatedToZero"]) ? null : (System.Boolean?)dataRow["RatedToZero"];
			entity.ProductName = Convert.IsDBNull(dataRow["ProductName"]) ? null : (System.String)dataRow["ProductName"];
			entity.ProductNameAlt = Convert.IsDBNull(dataRow["ProductNameAlt"]) ? null : (System.String)dataRow["ProductNameAlt"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.BillableLegs"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.BillableLegs Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.BillableLegs entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.BillableLegs object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.BillableLegs instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.BillableLegs Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.BillableLegs entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region BillableLegsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.BillableLegs</c>
	///</summary>
	public enum BillableLegsChildEntityTypes
	{
	}
	
	#endregion BillableLegsChildEntityTypes
	
	#region BillableLegsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BillableLegsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsFilterBuilder : SqlFilterBuilder<BillableLegsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilterBuilder class.
		/// </summary>
		public BillableLegsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillableLegsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillableLegsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillableLegsFilterBuilder
	
	#region BillableLegsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BillableLegsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BillableLegs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BillableLegsParameterBuilder : ParameterizedSqlFilterBuilder<BillableLegsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BillableLegsParameterBuilder class.
		/// </summary>
		public BillableLegsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BillableLegsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BillableLegsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BillableLegsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BillableLegsParameterBuilder
} // end namespace
