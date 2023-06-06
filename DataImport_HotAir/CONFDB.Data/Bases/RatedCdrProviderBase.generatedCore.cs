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
	/// This class is the base class for any <see cref="RatedCdrProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RatedCdrProviderBaseCore : EntityProviderBase<CONFDB.Entities.RatedCdr, CONFDB.Entities.RatedCdrKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.RatedCdrKey key)
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
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		AccessType_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(System.Int32 _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(_accessTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		AccessType_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		AccessType_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		accessType_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(System.Int32 _accessTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		accessType_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(System.Int32 _accessTypeId, int start, int pageLength,out int count)
		{
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_RatedCDR_FK key.
		///		AccessType_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		Bridge_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="_bridgeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBridgeId(System.Int32 _bridgeId)
		{
			int count = -1;
			return GetByBridgeId(_bridgeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		Bridge_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<RatedCdr> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId)
		{
			int count = -1;
			return GetByBridgeId(transactionManager, _bridgeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		Bridge_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId, int start, int pageLength)
		{
			int count = -1;
			return GetByBridgeId(transactionManager, _bridgeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		bridge_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBridgeId(System.Int32 _bridgeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBridgeId(null, _bridgeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		bridge_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_bridgeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBridgeId(System.Int32 _bridgeId, int start, int pageLength,out int count)
		{
			return GetByBridgeId(null, _bridgeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Bridge_RatedCDR_FK key.
		///		Bridge_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bridgeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByBridgeId(TransactionManager transactionManager, System.Int32 _bridgeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		Wholesaler_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		Wholesaler_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		Wholesaler_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		wholesaler_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		wholesaler_RatedCdr_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_RatedCDR_FK key.
		///		Wholesaler_RatedCDR_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RatedCdr objects.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.RatedCdr Get(TransactionManager transactionManager, CONFDB.Entities.RatedCdrKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key RatedCDR_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public CONFDB.Entities.RatedCdr GetById(System.Guid _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RatedCDR_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public CONFDB.Entities.RatedCdr GetById(System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RatedCDR_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public CONFDB.Entities.RatedCdr GetById(TransactionManager transactionManager, System.Guid _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RatedCDR_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public CONFDB.Entities.RatedCdr GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the RatedCDR_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public CONFDB.Entities.RatedCdr GetById(System.Guid _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the RatedCDR_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RatedCdr"/> class.</returns>
		public abstract CONFDB.Entities.RatedCdr GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_ConfLogID index.
		/// </summary>
		/// <param name="_conferenceId"></param>
		/// <param name="_bridgeId"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByConferenceIdBridgeIdWholesalerId(TransactionManager transactionManager, System.String _conferenceId, System.Int32 _bridgeId, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdModeratorId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_ModeratorID index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByModeratorId(System.Int32 _moderatorId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId)
		{
			int count = -1;
			return GetByAccessTypeIdBridgeProductRateId(null,_accessTypeId, _bridgeProductRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeIdBridgeProductRateId(null, _accessTypeId, _bridgeProductRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId)
		{
			int count = -1;
			return GetByAccessTypeIdBridgeProductRateId(transactionManager, _accessTypeId, _bridgeProductRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeIdBridgeProductRateId(transactionManager, _accessTypeId, _bridgeProductRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId, int start, int pageLength, out int count)
		{
			return GetByAccessTypeIdBridgeProductRateId(null, _accessTypeId, _bridgeProductRateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_AccessTypeID_BridgeProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_bridgeProductRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByAccessTypeIdBridgeProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _bridgeProductRateId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_StartandEndTime index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_startTime"></param>
		/// <param name="_endTime"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByWholesalerIdStartTimeEndTime(TransactionManager transactionManager, System.String _wholesalerId, System.DateTime _startTime, System.DateTime _endTime, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(System.String _referenceNumber)
		{
			int count = -1;
			return GetByReferenceNumber(null,_referenceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(System.String _referenceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceNumber(null, _referenceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber)
		{
			int count = -1;
			return GetByReferenceNumber(transactionManager, _referenceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByReferenceNumber(transactionManager, _referenceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(System.String _referenceNumber, int start, int pageLength, out int count)
		{
			return GetByReferenceNumber(null, _referenceNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_MatterNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referenceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByReferenceNumber(TransactionManager transactionManager, System.String _referenceNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_BilledDate index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBilledDate(System.DateTime? _billedDate)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBilledDate(System.DateTime? _billedDate, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByBilledDate(System.DateTime? _billedDate, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByBilledDate(TransactionManager transactionManager, System.DateTime? _billedDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="_uniqueConferenceId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(System.String _uniqueConferenceId)
		{
			int count = -1;
			return GetByUniqueConferenceId(null,_uniqueConferenceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="_uniqueConferenceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(System.String _uniqueConferenceId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueConferenceId(null, _uniqueConferenceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueConferenceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(TransactionManager transactionManager, System.String _uniqueConferenceId)
		{
			int count = -1;
			return GetByUniqueConferenceId(transactionManager, _uniqueConferenceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueConferenceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(TransactionManager transactionManager, System.String _uniqueConferenceId, int start, int pageLength)
		{
			int count = -1;
			return GetByUniqueConferenceId(transactionManager, _uniqueConferenceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="_uniqueConferenceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(System.String _uniqueConferenceId, int start, int pageLength, out int count)
		{
			return GetByUniqueConferenceId(null, _uniqueConferenceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_RatedCDR_UniqueConferenceID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_uniqueConferenceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<RatedCdr> GetByUniqueConferenceId(TransactionManager transactionManager, System.String _uniqueConferenceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_RatedCDR_GetCallSummaryForCustomer3 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer3' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer3(System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer3(null, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer3' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer3(int start, int pageLength, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer3(null, start, pageLength , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer3' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer3(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer3(transactionManager, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer3' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCallSummaryForCustomer3(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName);
		
		#endregion
		
		#region p_RatedCDR_GetCallSummaryForCustomer 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer(System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer(null, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer(int start, int pageLength, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer(null, start, pageLength , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer(transactionManager, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCallSummaryForCustomer(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName);
		
		#endregion
		
		#region p_RatedCDR_SetBillingCode 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_SetBillingCode' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueConferenceId"> A <c>System.String</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void SetBillingCode(System.Int32? customerId, System.String uniqueConferenceId, System.String referenceNumber)
		{
			 SetBillingCode(null, 0, int.MaxValue , customerId, uniqueConferenceId, referenceNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_SetBillingCode' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueConferenceId"> A <c>System.String</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void SetBillingCode(int start, int pageLength, System.Int32? customerId, System.String uniqueConferenceId, System.String referenceNumber)
		{
			 SetBillingCode(null, start, pageLength , customerId, uniqueConferenceId, referenceNumber);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_SetBillingCode' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueConferenceId"> A <c>System.String</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void SetBillingCode(TransactionManager transactionManager, System.Int32? customerId, System.String uniqueConferenceId, System.String referenceNumber)
		{
			 SetBillingCode(transactionManager, 0, int.MaxValue , customerId, uniqueConferenceId, referenceNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_SetBillingCode' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueConferenceId"> A <c>System.String</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void SetBillingCode(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.String uniqueConferenceId, System.String referenceNumber);
		
		#endregion
		
		#region p_RatedCDR_GetCallDetailsForCustomer 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForCustomer(System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallDetailsForCustomer(null, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForCustomer(int start, int pageLength, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallDetailsForCustomer(null, start, pageLength , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForCustomer(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallDetailsForCustomer(transactionManager, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCallDetailsForCustomer(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName);
		
		#endregion
		
		#region p_RatedCDR_GetCallSummaryForCustomer2 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer2' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer2(System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer2(null, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer2' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer2(int start, int pageLength, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer2(null, start, pageLength , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer2' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallSummaryForCustomer2(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName)
		{
			return GetCallSummaryForCustomer2(transactionManager, 0, int.MaxValue , customerId, startTime, endTime, departmentId, userId, referenceNumber, meetingName);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallSummaryForCustomer2' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="departmentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceNumber"> A <c>System.String</c> instance.</param>
		/// <param name="meetingName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCallSummaryForCustomer2(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? startTime, System.DateTime? endTime, System.Int32? departmentId, System.Int32? userId, System.String referenceNumber, System.String meetingName);
		
		#endregion
		
		#region p_RatedCDR_GetCallDetailsForModerator 
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForModerator' stored procedure. 
		/// </summary>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForModerator(System.Int32? userId, System.DateTime? startTime, System.DateTime? endTime)
		{
			return GetCallDetailsForModerator(null, 0, int.MaxValue , userId, startTime, endTime);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForModerator' stored procedure. 
		/// </summary>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForModerator(int start, int pageLength, System.Int32? userId, System.DateTime? startTime, System.DateTime? endTime)
		{
			return GetCallDetailsForModerator(null, start, pageLength , userId, startTime, endTime);
		}
				
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForModerator' stored procedure. 
		/// </summary>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCallDetailsForModerator(TransactionManager transactionManager, System.Int32? userId, System.DateTime? startTime, System.DateTime? endTime)
		{
			return GetCallDetailsForModerator(transactionManager, 0, int.MaxValue , userId, startTime, endTime);
		}
		
		/// <summary>
		///	This method wrap the 'p_RatedCDR_GetCallDetailsForModerator' stored procedure. 
		/// </summary>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endTime"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCallDetailsForModerator(TransactionManager transactionManager, int start, int pageLength , System.Int32? userId, System.DateTime? startTime, System.DateTime? endTime);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;RatedCdr&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;RatedCdr&gt;"/></returns>
		public static CONFDB.Entities.TList<RatedCdr> Fill(IDataReader reader, CONFDB.Entities.TList<RatedCdr> rows, int start, int pageLength)
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
				
				CONFDB.Entities.RatedCdr c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("RatedCdr")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.RatedCdrColumn.Id - 1))?Guid.Empty:(System.Guid)reader[((int)CONFDB.Entities.RatedCdrColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<RatedCdr>(
					key.ToString(), // EntityTrackingKey
					"RatedCdr",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.RatedCdr();
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
					c.Id = (System.Guid)reader[((int)RatedCdrColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.ConferenceId = (System.String)reader[((int)RatedCdrColumn.ConferenceId - 1)];
					c.ModeratorId = (System.Int32)reader[((int)RatedCdrColumn.ModeratorId - 1)];
					c.CustomerId = (reader.IsDBNull(((int)RatedCdrColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)RatedCdrColumn.CustomerId - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)RatedCdrColumn.WholesalerId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.WholesalerId - 1)];
					c.ModeratorCode = (System.String)reader[((int)RatedCdrColumn.ModeratorCode - 1)];
					c.PassCode = (System.String)reader[((int)RatedCdrColumn.PassCode - 1)];
					c.ModeratorName = (reader.IsDBNull(((int)RatedCdrColumn.ModeratorName - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ModeratorName - 1)];
					c.Moderator = (System.Int32)reader[((int)RatedCdrColumn.Moderator - 1)];
					c.ExternalCustomerNumber = (reader.IsDBNull(((int)RatedCdrColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ExternalCustomerNumber - 1)];
					c.ExternalModeratorNumber = (reader.IsDBNull(((int)RatedCdrColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ExternalModeratorNumber - 1)];
					c.ReferenceNumber = (reader.IsDBNull(((int)RatedCdrColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ReferenceNumber - 1)];
					c.ConferenceStartTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceStartTime - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.ConferenceStartTime - 1)];
					c.ConferenceEndTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceEndTime - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.ConferenceEndTime - 1)];
					c.ConferenceElapsedTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceElapsedTime - 1)))?null:(System.Int32?)reader[((int)RatedCdrColumn.ConferenceElapsedTime - 1)];
					c.StartTime = (System.DateTime)reader[((int)RatedCdrColumn.StartTime - 1)];
					c.EndTime = (System.DateTime)reader[((int)RatedCdrColumn.EndTime - 1)];
					c.ElapsedTime = (System.Int32)reader[((int)RatedCdrColumn.ElapsedTime - 1)];
					c.BridgeId = (System.Int32)reader[((int)RatedCdrColumn.BridgeId - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)RatedCdrColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.UniqueConferenceId - 1)];
					c.AuxiliaryConferenceId = (reader.IsDBNull(((int)RatedCdrColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.AuxiliaryConferenceId - 1)];
					c.Dnis = (reader.IsDBNull(((int)RatedCdrColumn.Dnis - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Dnis - 1)];
					c.DialNumber = (reader.IsDBNull(((int)RatedCdrColumn.DialNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.DialNumber - 1)];
					c.Ani = (reader.IsDBNull(((int)RatedCdrColumn.Ani - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Ani - 1)];
					c.ParticipantName = (reader.IsDBNull(((int)RatedCdrColumn.ParticipantName - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ParticipantName - 1)];
					c.Destination = (reader.IsDBNull(((int)RatedCdrColumn.Destination - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Destination - 1)];
					c.AccessTypeId = (System.Int32)reader[((int)RatedCdrColumn.AccessTypeId - 1)];
					c.ConnectProductRateId = (System.Int32)reader[((int)RatedCdrColumn.ConnectProductRateId - 1)];
					c.BridgeProductRateId = (System.Int32)reader[((int)RatedCdrColumn.BridgeProductRateId - 1)];
					c.LdProductRateId = (System.Int32)reader[((int)RatedCdrColumn.LdProductRateId - 1)];
					c.ProductRateTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.ProductRateTaxableValue - 1)];
					c.CustomerTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.CustomerTaxableValue - 1)];
					c.WsTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.WsTaxableValue - 1)];
					c.RetailConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.RetailConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailConnectCharge - 1)];
					c.RetailBridgeRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailBridgeRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailBridgeRate - 1)];
					c.RetailLdRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailLdRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLdRate - 1)];
					c.RetailCurrency = (reader.IsDBNull(((int)RatedCdrColumn.RetailCurrency - 1)))?null:(System.String)reader[((int)RatedCdrColumn.RetailCurrency - 1)];
					c.RetailBillingInterval = (System.Int32)reader[((int)RatedCdrColumn.RetailBillingInterval - 1)];
					c.RetailTotalConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalConnectCharge - 1)];
					c.RetailTotalBridge = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalBridge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalBridge - 1)];
					c.RetailTotalLd = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalLd - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalLd - 1)];
					c.RetailTotal = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotal - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotal - 1)];
					c.RetailTotalCredit = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalCredit - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalCredit - 1)];
					c.RetailLocalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLocalTaxRate - 1)];
					c.RetailFederalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailFederalTaxRate - 1)];
					c.RetailLocalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailLocalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLocalTax - 1)];
					c.RetailFederalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailFederalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailFederalTax - 1)];
					c.RetailTotalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalTax - 1)];
					c.WsConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.WsConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsConnectCharge - 1)];
					c.WsBridgeRate = (reader.IsDBNull(((int)RatedCdrColumn.WsBridgeRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsBridgeRate - 1)];
					c.WsldRate = (reader.IsDBNull(((int)RatedCdrColumn.WsldRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsldRate - 1)];
					c.WsCurrency = (reader.IsDBNull(((int)RatedCdrColumn.WsCurrency - 1)))?null:(System.String)reader[((int)RatedCdrColumn.WsCurrency - 1)];
					c.WsBillingInterval = (System.Int32)reader[((int)RatedCdrColumn.WsBillingInterval - 1)];
					c.WsTotalConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalConnectCharge - 1)];
					c.WsTotalBridge = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalBridge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalBridge - 1)];
					c.WsTotalLd = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalLd - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalLd - 1)];
					c.WsTotal = (reader.IsDBNull(((int)RatedCdrColumn.WsTotal - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotal - 1)];
					c.WsLocalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.WsLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsLocalTaxRate - 1)];
					c.WsFederalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.WsFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsFederalTaxRate - 1)];
					c.WsLocalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsLocalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsLocalTax - 1)];
					c.WsFederalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsFederalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsFederalTax - 1)];
					c.WsTotalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalTax - 1)];
					c.BillingStatus = (reader.IsDBNull(((int)RatedCdrColumn.BillingStatus - 1)))?null:(System.Int16?)reader[((int)RatedCdrColumn.BillingStatus - 1)];
					c.BilledDate = (reader.IsDBNull(((int)RatedCdrColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.BilledDate - 1)];
					c.ProcessedDate = (System.DateTime)reader[((int)RatedCdrColumn.ProcessedDate - 1)];
					c.SeeVoghMeetingId = (reader.IsDBNull(((int)RatedCdrColumn.SeeVoghMeetingId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.SeeVoghMeetingId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.RatedCdr"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.RatedCdr"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.RatedCdr entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader[((int)RatedCdrColumn.Id - 1)];
			entity.OriginalId = (System.Guid)reader["ID"];
			entity.ConferenceId = (System.String)reader[((int)RatedCdrColumn.ConferenceId - 1)];
			entity.ModeratorId = (System.Int32)reader[((int)RatedCdrColumn.ModeratorId - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)RatedCdrColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)RatedCdrColumn.CustomerId - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)RatedCdrColumn.WholesalerId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.WholesalerId - 1)];
			entity.ModeratorCode = (System.String)reader[((int)RatedCdrColumn.ModeratorCode - 1)];
			entity.PassCode = (System.String)reader[((int)RatedCdrColumn.PassCode - 1)];
			entity.ModeratorName = (reader.IsDBNull(((int)RatedCdrColumn.ModeratorName - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ModeratorName - 1)];
			entity.Moderator = (System.Int32)reader[((int)RatedCdrColumn.Moderator - 1)];
			entity.ExternalCustomerNumber = (reader.IsDBNull(((int)RatedCdrColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ExternalCustomerNumber - 1)];
			entity.ExternalModeratorNumber = (reader.IsDBNull(((int)RatedCdrColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ExternalModeratorNumber - 1)];
			entity.ReferenceNumber = (reader.IsDBNull(((int)RatedCdrColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ReferenceNumber - 1)];
			entity.ConferenceStartTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceStartTime - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.ConferenceStartTime - 1)];
			entity.ConferenceEndTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceEndTime - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.ConferenceEndTime - 1)];
			entity.ConferenceElapsedTime = (reader.IsDBNull(((int)RatedCdrColumn.ConferenceElapsedTime - 1)))?null:(System.Int32?)reader[((int)RatedCdrColumn.ConferenceElapsedTime - 1)];
			entity.StartTime = (System.DateTime)reader[((int)RatedCdrColumn.StartTime - 1)];
			entity.EndTime = (System.DateTime)reader[((int)RatedCdrColumn.EndTime - 1)];
			entity.ElapsedTime = (System.Int32)reader[((int)RatedCdrColumn.ElapsedTime - 1)];
			entity.BridgeId = (System.Int32)reader[((int)RatedCdrColumn.BridgeId - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)RatedCdrColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.UniqueConferenceId - 1)];
			entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)RatedCdrColumn.AuxiliaryConferenceId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.AuxiliaryConferenceId - 1)];
			entity.Dnis = (reader.IsDBNull(((int)RatedCdrColumn.Dnis - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Dnis - 1)];
			entity.DialNumber = (reader.IsDBNull(((int)RatedCdrColumn.DialNumber - 1)))?null:(System.String)reader[((int)RatedCdrColumn.DialNumber - 1)];
			entity.Ani = (reader.IsDBNull(((int)RatedCdrColumn.Ani - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Ani - 1)];
			entity.ParticipantName = (reader.IsDBNull(((int)RatedCdrColumn.ParticipantName - 1)))?null:(System.String)reader[((int)RatedCdrColumn.ParticipantName - 1)];
			entity.Destination = (reader.IsDBNull(((int)RatedCdrColumn.Destination - 1)))?null:(System.String)reader[((int)RatedCdrColumn.Destination - 1)];
			entity.AccessTypeId = (System.Int32)reader[((int)RatedCdrColumn.AccessTypeId - 1)];
			entity.ConnectProductRateId = (System.Int32)reader[((int)RatedCdrColumn.ConnectProductRateId - 1)];
			entity.BridgeProductRateId = (System.Int32)reader[((int)RatedCdrColumn.BridgeProductRateId - 1)];
			entity.LdProductRateId = (System.Int32)reader[((int)RatedCdrColumn.LdProductRateId - 1)];
			entity.ProductRateTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.ProductRateTaxableValue - 1)];
			entity.CustomerTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.CustomerTaxableValue - 1)];
			entity.WsTaxableValue = (System.Int32)reader[((int)RatedCdrColumn.WsTaxableValue - 1)];
			entity.RetailConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.RetailConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailConnectCharge - 1)];
			entity.RetailBridgeRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailBridgeRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailBridgeRate - 1)];
			entity.RetailLdRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailLdRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLdRate - 1)];
			entity.RetailCurrency = (reader.IsDBNull(((int)RatedCdrColumn.RetailCurrency - 1)))?null:(System.String)reader[((int)RatedCdrColumn.RetailCurrency - 1)];
			entity.RetailBillingInterval = (System.Int32)reader[((int)RatedCdrColumn.RetailBillingInterval - 1)];
			entity.RetailTotalConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalConnectCharge - 1)];
			entity.RetailTotalBridge = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalBridge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalBridge - 1)];
			entity.RetailTotalLd = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalLd - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalLd - 1)];
			entity.RetailTotal = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotal - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotal - 1)];
			entity.RetailTotalCredit = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalCredit - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalCredit - 1)];
			entity.RetailLocalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLocalTaxRate - 1)];
			entity.RetailFederalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.RetailFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailFederalTaxRate - 1)];
			entity.RetailLocalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailLocalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailLocalTax - 1)];
			entity.RetailFederalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailFederalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailFederalTax - 1)];
			entity.RetailTotalTax = (reader.IsDBNull(((int)RatedCdrColumn.RetailTotalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.RetailTotalTax - 1)];
			entity.WsConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.WsConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsConnectCharge - 1)];
			entity.WsBridgeRate = (reader.IsDBNull(((int)RatedCdrColumn.WsBridgeRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsBridgeRate - 1)];
			entity.WsldRate = (reader.IsDBNull(((int)RatedCdrColumn.WsldRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsldRate - 1)];
			entity.WsCurrency = (reader.IsDBNull(((int)RatedCdrColumn.WsCurrency - 1)))?null:(System.String)reader[((int)RatedCdrColumn.WsCurrency - 1)];
			entity.WsBillingInterval = (System.Int32)reader[((int)RatedCdrColumn.WsBillingInterval - 1)];
			entity.WsTotalConnectCharge = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalConnectCharge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalConnectCharge - 1)];
			entity.WsTotalBridge = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalBridge - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalBridge - 1)];
			entity.WsTotalLd = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalLd - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalLd - 1)];
			entity.WsTotal = (reader.IsDBNull(((int)RatedCdrColumn.WsTotal - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotal - 1)];
			entity.WsLocalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.WsLocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsLocalTaxRate - 1)];
			entity.WsFederalTaxRate = (reader.IsDBNull(((int)RatedCdrColumn.WsFederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsFederalTaxRate - 1)];
			entity.WsLocalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsLocalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsLocalTax - 1)];
			entity.WsFederalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsFederalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsFederalTax - 1)];
			entity.WsTotalTax = (reader.IsDBNull(((int)RatedCdrColumn.WsTotalTax - 1)))?null:(System.Decimal?)reader[((int)RatedCdrColumn.WsTotalTax - 1)];
			entity.BillingStatus = (reader.IsDBNull(((int)RatedCdrColumn.BillingStatus - 1)))?null:(System.Int16?)reader[((int)RatedCdrColumn.BillingStatus - 1)];
			entity.BilledDate = (reader.IsDBNull(((int)RatedCdrColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)RatedCdrColumn.BilledDate - 1)];
			entity.ProcessedDate = (System.DateTime)reader[((int)RatedCdrColumn.ProcessedDate - 1)];
			entity.SeeVoghMeetingId = (reader.IsDBNull(((int)RatedCdrColumn.SeeVoghMeetingId - 1)))?null:(System.String)reader[((int)RatedCdrColumn.SeeVoghMeetingId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.RatedCdr"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.RatedCdr"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.RatedCdr entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["ID"];
			entity.OriginalId = (System.Guid)dataRow["ID"];
			entity.ConferenceId = (System.String)dataRow["ConferenceID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
			entity.ModeratorCode = (System.String)dataRow["ModeratorCode"];
			entity.PassCode = (System.String)dataRow["PassCode"];
			entity.ModeratorName = Convert.IsDBNull(dataRow["ModeratorName"]) ? null : (System.String)dataRow["ModeratorName"];
			entity.Moderator = (System.Int32)dataRow["Moderator"];
			entity.ExternalCustomerNumber = Convert.IsDBNull(dataRow["ExternalCustomerNumber"]) ? null : (System.String)dataRow["ExternalCustomerNumber"];
			entity.ExternalModeratorNumber = Convert.IsDBNull(dataRow["ExternalModeratorNumber"]) ? null : (System.String)dataRow["ExternalModeratorNumber"];
			entity.ReferenceNumber = Convert.IsDBNull(dataRow["ReferenceNumber"]) ? null : (System.String)dataRow["ReferenceNumber"];
			entity.ConferenceStartTime = Convert.IsDBNull(dataRow["ConferenceStartTime"]) ? null : (System.DateTime?)dataRow["ConferenceStartTime"];
			entity.ConferenceEndTime = Convert.IsDBNull(dataRow["ConferenceEndTime"]) ? null : (System.DateTime?)dataRow["ConferenceEndTime"];
			entity.ConferenceElapsedTime = Convert.IsDBNull(dataRow["ConferenceElapsedTime"]) ? null : (System.Int32?)dataRow["ConferenceElapsedTime"];
			entity.StartTime = (System.DateTime)dataRow["StartTime"];
			entity.EndTime = (System.DateTime)dataRow["EndTime"];
			entity.ElapsedTime = (System.Int32)dataRow["ElapsedTime"];
			entity.BridgeId = (System.Int32)dataRow["BridgeID"];
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
			entity.RetailTotalCredit = Convert.IsDBNull(dataRow["RetailTotalCredit"]) ? null : (System.Decimal?)dataRow["RetailTotalCredit"];
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
			entity.ProcessedDate = (System.DateTime)dataRow["ProcessedDate"];
			entity.SeeVoghMeetingId = Convert.IsDBNull(dataRow["SeeVoghMeetingID"]) ? null : (System.String)dataRow["SeeVoghMeetingID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.RatedCdr"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.RatedCdr Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.RatedCdr entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AccessTypeIdSource	
			if (CanDeepLoad(entity, "AccessType|AccessTypeIdSource", deepLoadType, innerList) 
				&& entity.AccessTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AccessTypeId;
				AccessType tmpEntity = EntityManager.LocateEntity<AccessType>(EntityLocator.ConstructKeyFromPkItems(typeof(AccessType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccessTypeIdSource = tmpEntity;
				else
					entity.AccessTypeIdSource = DataRepository.AccessTypeProvider.GetById(transactionManager, entity.AccessTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccessTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AccessTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AccessTypeProvider.DeepLoad(transactionManager, entity.AccessTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AccessTypeIdSource

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

			#region WholesalerIdSource	
			if (CanDeepLoad(entity, "Wholesaler|WholesalerIdSource", deepLoadType, innerList) 
				&& entity.WholesalerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.WholesalerId ?? string.Empty);
				Wholesaler tmpEntity = EntityManager.LocateEntity<Wholesaler>(EntityLocator.ConstructKeyFromPkItems(typeof(Wholesaler), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WholesalerIdSource = tmpEntity;
				else
					entity.WholesalerIdSource = DataRepository.WholesalerProvider.GetById(transactionManager, (entity.WholesalerId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WholesalerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WholesalerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.WholesalerProvider.DeepLoad(transactionManager, entity.WholesalerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WholesalerIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.RatedCdr object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.RatedCdr instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.RatedCdr Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.RatedCdr entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AccessTypeIdSource
			if (CanDeepSave(entity, "AccessType|AccessTypeIdSource", deepSaveType, innerList) 
				&& entity.AccessTypeIdSource != null)
			{
				DataRepository.AccessTypeProvider.Save(transactionManager, entity.AccessTypeIdSource);
				entity.AccessTypeId = entity.AccessTypeIdSource.Id;
			}
			#endregion 
			
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
			
			#region WholesalerIdSource
			if (CanDeepSave(entity, "Wholesaler|WholesalerIdSource", deepSaveType, innerList) 
				&& entity.WholesalerIdSource != null)
			{
				DataRepository.WholesalerProvider.Save(transactionManager, entity.WholesalerIdSource);
				entity.WholesalerId = entity.WholesalerIdSource.Id;
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
	
	#region RatedCdrChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.RatedCdr</c>
	///</summary>
	public enum RatedCdrChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AccessType</c> at AccessTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AccessType))]
		AccessType,
			
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
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
		}
	
	#endregion RatedCdrChildEntityTypes
	
	#region RatedCdrFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RatedCdrColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrFilterBuilder : SqlFilterBuilder<RatedCdrColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilterBuilder class.
		/// </summary>
		public RatedCdrFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatedCdrFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatedCdrFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatedCdrFilterBuilder
	
	#region RatedCdrParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RatedCdrColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RatedCdr"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RatedCdrParameterBuilder : ParameterizedSqlFilterBuilder<RatedCdrColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RatedCdrParameterBuilder class.
		/// </summary>
		public RatedCdrParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RatedCdrParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RatedCdrParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RatedCdrParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RatedCdrParameterBuilder
} // end namespace
