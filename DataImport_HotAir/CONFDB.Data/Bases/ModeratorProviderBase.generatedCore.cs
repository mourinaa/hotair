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
	/// This class is the base class for any <see cref="ModeratorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ModeratorProviderBaseCore : EntityProviderBase<CONFDB.Entities.Moderator, CONFDB.Entities.ModeratorKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByDnisidFromModerator_Dnis
		
		/// <summary>
		///		Gets Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <returns>Returns a typed collection of Moderator objects.</returns>
		public TList<Moderator> GetByDnisidFromModerator_Dnis(System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisidFromModerator_Dnis(null,_dnisid, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Moderator objects.</returns>
		public TList<Moderator> GetByDnisidFromModerator_Dnis(System.Int32 _dnisid, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidFromModerator_Dnis(null, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Moderator objects.</returns>
		public TList<Moderator> GetByDnisidFromModerator_Dnis(TransactionManager transactionManager, System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisidFromModerator_Dnis(transactionManager, _dnisid, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Moderator objects.</returns>
		public TList<Moderator> GetByDnisidFromModerator_Dnis(TransactionManager transactionManager, System.Int32 _dnisid,int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidFromModerator_Dnis(transactionManager, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Moderator objects.</returns>
		public TList<Moderator> GetByDnisidFromModerator_Dnis(System.Int32 _dnisid,int start, int pageLength, out int count)
		{
			
			return GetByDnisidFromModerator_Dnis(null, _dnisid, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Moderator objects from the datasource by DNISID in the
		///		Moderator_DNIS table. Table Moderator is related to table DNIS
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Moderator objects.</returns>
		public abstract TList<Moderator> GetByDnisidFromModerator_Dnis(TransactionManager transactionManager,System.Int32 _dnisid, int start, int pageLength, out int count);
		
		#endregion GetByDnisidFromModerator_Dnis
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ModeratorKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.. Primary Key.</param>
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
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.. Primary Key.</param>
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
		public override CONFDB.Entities.Moderator Get(TransactionManager transactionManager, CONFDB.Entities.ModeratorKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Moderator_PK index.
		/// </summary>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_PK index.
		/// </summary>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_PK index.
		/// </summary>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Moderator_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public abstract CONFDB.Entities.Moderator GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber)
		{
			int count = -1;
			return GetByCustomerIdPriCustomerNumberSecCustomerNumber(null,_customerId, _priCustomerNumber, _secCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdPriCustomerNumberSecCustomerNumber(null, _customerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber)
		{
			int count = -1;
			return GetByCustomerIdPriCustomerNumberSecCustomerNumber(transactionManager, _customerId, _priCustomerNumber, _secCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdPriCustomerNumberSecCustomerNumber(transactionManager, _customerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength, out int count)
		{
			return GetByCustomerIdPriCustomerNumberSecCustomerNumber(null, _customerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_Moderator_AcctID_PriAcct_SecAcct index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByCustomerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.Int32 _customerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumberSecCustomerNumber(null,_wholesalerId, _priCustomerNumber, _secCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumberSecCustomerNumber(null, _wholesalerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumberSecCustomerNumber(transactionManager, _wholesalerId, _priCustomerNumber, _secCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumberSecCustomerNumber(transactionManager, _wholesalerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdPriCustomerNumberSecCustomerNumber(null, _wholesalerId, _priCustomerNumber, _secCustomerNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_PriCustomerNumber_SecCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_secCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public abstract CONFDB.Entities.Moderator GetByWholesalerIdPriCustomerNumberSecCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber, System.String _secCustomerNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(System.String _wholesalerId, System.Int32 _id)
		{
			int count = -1;
			return GetByWholesalerIdId(null,_wholesalerId, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(System.String _wholesalerId, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdId(null, _wholesalerId, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _id)
		{
			int count = -1;
			return GetByWholesalerIdId(transactionManager, _wholesalerId, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdId(transactionManager, _wholesalerId, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(System.String _wholesalerId, System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdId(null, _wholesalerId, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_WholesalerID_ModeratorID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_id">This table is changing to be used to house serveral different sets of codes/conferences per User.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByWholesalerIdId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByModeratorCode(System.String _moderatorCode)
		{
			int count = -1;
			return GetByModeratorCode(null,_moderatorCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByModeratorCode(System.String _moderatorCode, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorCode(null, _moderatorCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByModeratorCode(TransactionManager transactionManager, System.String _moderatorCode)
		{
			int count = -1;
			return GetByModeratorCode(transactionManager, _moderatorCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByModeratorCode(TransactionManager transactionManager, System.String _moderatorCode, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorCode(transactionManager, _moderatorCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByModeratorCode(System.String _moderatorCode, int start, int pageLength, out int count)
		{
			return GetByModeratorCode(null, _moderatorCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public abstract CONFDB.Entities.Moderator GetByModeratorCode(TransactionManager transactionManager, System.String _moderatorCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(System.String _moderatorCode, System.String _passCode)
		{
			int count = -1;
			return GetByModeratorCodePassCode(null,_moderatorCode, _passCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(System.String _moderatorCode, System.String _passCode, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorCodePassCode(null, _moderatorCode, _passCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(TransactionManager transactionManager, System.String _moderatorCode, System.String _passCode)
		{
			int count = -1;
			return GetByModeratorCodePassCode(transactionManager, _moderatorCode, _passCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(TransactionManager transactionManager, System.String _moderatorCode, System.String _passCode, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorCodePassCode(transactionManager, _moderatorCode, _passCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(System.String _moderatorCode, System.String _passCode, int start, int pageLength, out int count)
		{
			return GetByModeratorCodePassCode(null, _moderatorCode, _passCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_ModeratorCode_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorCode"></param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByModeratorCodePassCode(TransactionManager transactionManager, System.String _moderatorCode, System.String _passCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="_passCode"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByPassCode(System.String _passCode)
		{
			int count = -1;
			return GetByPassCode(null,_passCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByPassCode(System.String _passCode, int start, int pageLength)
		{
			int count = -1;
			return GetByPassCode(null, _passCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_passCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByPassCode(TransactionManager transactionManager, System.String _passCode)
		{
			int count = -1;
			return GetByPassCode(transactionManager, _passCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByPassCode(TransactionManager transactionManager, System.String _passCode, int start, int pageLength)
		{
			int count = -1;
			return GetByPassCode(transactionManager, _passCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public CONFDB.Entities.Moderator GetByPassCode(System.String _passCode, int start, int pageLength, out int count)
		{
			return GetByPassCode(null, _passCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_PassCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_passCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Moderator"/> class.</returns>
		public abstract CONFDB.Entities.Moderator GetByPassCode(TransactionManager transactionManager, System.String _passCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByDepartmentId(System.Int32 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(null,_departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByDepartmentId(System.Int32 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByDepartmentId(TransactionManager transactionManager, System.Int32 _departmentId)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByDepartmentId(TransactionManager transactionManager, System.Int32 _departmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentId(transactionManager, _departmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="_departmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByDepartmentId(System.Int32 _departmentId, int start, int pageLength, out int count)
		{
			return GetByDepartmentId(null, _departmentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_DepartmentID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByDepartmentId(TransactionManager transactionManager, System.Int32 _departmentId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Moderator_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByUserId(System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByUserId(System.Int32? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByUserId(TransactionManager transactionManager, System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Moderator> GetByUserId(System.Int32? _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Moderator_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Moderator> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_Moderator_CreateUser 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="displayName"> A <c>System.String</c> instance.</param>
		/// <param name="telephone"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="country"> A <c>System.String</c> instance.</param>
		/// <param name="region"> A <c>System.String</c> instance.</param>
		/// <param name="postalCode"> A <c>System.String</c> instance.</param>
		/// <param name="charityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(System.Int32? moderatorId, System.String userName, System.String password, System.String displayName, System.String telephone, System.String address1, System.String address2, System.String city, System.String country, System.String region, System.String postalCode, System.Int32? charityId, System.Boolean? enabled, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(null, 0, int.MaxValue , moderatorId, userName, password, displayName, telephone, address1, address2, city, country, region, postalCode, charityId, enabled, mustChangePassword, ref userId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="displayName"> A <c>System.String</c> instance.</param>
		/// <param name="telephone"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="country"> A <c>System.String</c> instance.</param>
		/// <param name="region"> A <c>System.String</c> instance.</param>
		/// <param name="postalCode"> A <c>System.String</c> instance.</param>
		/// <param name="charityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(int start, int pageLength, System.Int32? moderatorId, System.String userName, System.String password, System.String displayName, System.String telephone, System.String address1, System.String address2, System.String city, System.String country, System.String region, System.String postalCode, System.Int32? charityId, System.Boolean? enabled, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(null, start, pageLength , moderatorId, userName, password, displayName, telephone, address1, address2, city, country, region, postalCode, charityId, enabled, mustChangePassword, ref userId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="displayName"> A <c>System.String</c> instance.</param>
		/// <param name="telephone"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="country"> A <c>System.String</c> instance.</param>
		/// <param name="region"> A <c>System.String</c> instance.</param>
		/// <param name="postalCode"> A <c>System.String</c> instance.</param>
		/// <param name="charityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(TransactionManager transactionManager, System.Int32? moderatorId, System.String userName, System.String password, System.String displayName, System.String telephone, System.String address1, System.String address2, System.String city, System.String country, System.String region, System.String postalCode, System.Int32? charityId, System.Boolean? enabled, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(transactionManager, 0, int.MaxValue , moderatorId, userName, password, displayName, telephone, address1, address2, city, country, region, postalCode, charityId, enabled, mustChangePassword, ref userId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="displayName"> A <c>System.String</c> instance.</param>
		/// <param name="telephone"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="country"> A <c>System.String</c> instance.</param>
		/// <param name="region"> A <c>System.String</c> instance.</param>
		/// <param name="postalCode"> A <c>System.String</c> instance.</param>
		/// <param name="charityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CreateUser(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId, System.String userName, System.String password, System.String displayName, System.String telephone, System.String address1, System.String address2, System.String city, System.String country, System.String region, System.String postalCode, System.Int32? charityId, System.Boolean? enabled, System.Boolean? mustChangePassword, ref System.Int32? userId);
		
		#endregion
		
		#region p_Moderator_InstallDefaults 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(System.Int32? id)
		{
			 InstallDefaults(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(int start, int pageLength, System.Int32? id)
		{
			 InstallDefaults(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(TransactionManager transactionManager, System.Int32? id)
		{
			 InstallDefaults(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void InstallDefaults(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region p_Moderator_GetNextSecCustomerNumber 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetNextSecCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="secCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextSecCustomerNumber(System.Int32? customerId, ref System.String secCustomerNumber)
		{
			 GetNextSecCustomerNumber(null, 0, int.MaxValue , customerId, ref secCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetNextSecCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="secCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextSecCustomerNumber(int start, int pageLength, System.Int32? customerId, ref System.String secCustomerNumber)
		{
			 GetNextSecCustomerNumber(null, start, pageLength , customerId, ref secCustomerNumber);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_GetNextSecCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="secCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextSecCustomerNumber(TransactionManager transactionManager, System.Int32? customerId, ref System.String secCustomerNumber)
		{
			 GetNextSecCustomerNumber(transactionManager, 0, int.MaxValue , customerId, ref secCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetNextSecCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="secCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetNextSecCustomerNumber(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, ref System.String secCustomerNumber);
		
		#endregion
		
		#region p_Moderator_DisableModerator 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DisableModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableModerator(System.Int32? moderatorId)
		{
			 DisableModerator(null, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DisableModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableModerator(int start, int pageLength, System.Int32? moderatorId)
		{
			 DisableModerator(null, start, pageLength , moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_DisableModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableModerator(TransactionManager transactionManager, System.Int32? moderatorId)
		{
			 DisableModerator(transactionManager, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DisableModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DisableModerator(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId);
		
		#endregion
		
		#region p_Moderator_Omnovia_GetRecordings 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(System.Int32? moderatorId)
		{
			return Omnovia_GetRecordings(null, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(int start, int pageLength, System.Int32? moderatorId)
		{
			return Omnovia_GetRecordings(null, start, pageLength , moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(TransactionManager transactionManager, System.Int32? moderatorId)
		{
			return Omnovia_GetRecordings(transactionManager, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Omnovia_GetRecordings(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId);
		
		#endregion
		
		#region p_Moderator_Omnovia_GetCompanyLogin 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(System.Int32? moderatorId)
		{
			return Omnovia_GetCompanyLogin(null, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(int start, int pageLength, System.Int32? moderatorId)
		{
			return Omnovia_GetCompanyLogin(null, start, pageLength , moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(TransactionManager transactionManager, System.Int32? moderatorId)
		{
			return Omnovia_GetCompanyLogin(transactionManager, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Omnovia_GetCompanyLogin(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId);
		
		#endregion
		
		#region p_Moderator_UpdateDNIS 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(System.Int32? moderatorId, System.Int32? dnisid, System.Int32? dnisTypeId)
		{
			 UpdateDNIS(null, 0, int.MaxValue , moderatorId, dnisid, dnisTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(int start, int pageLength, System.Int32? moderatorId, System.Int32? dnisid, System.Int32? dnisTypeId)
		{
			 UpdateDNIS(null, start, pageLength , moderatorId, dnisid, dnisTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(TransactionManager transactionManager, System.Int32? moderatorId, System.Int32? dnisid, System.Int32? dnisTypeId)
		{
			 UpdateDNIS(transactionManager, 0, int.MaxValue , moderatorId, dnisid, dnisTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateDNIS(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId, System.Int32? dnisid, System.Int32? dnisTypeId);
		
		#endregion
		
		#region p_Moderator_DeleteModerator 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DeleteModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteModerator(System.Int32? moderatorId)
		{
			 DeleteModerator(null, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DeleteModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteModerator(int start, int pageLength, System.Int32? moderatorId)
		{
			 DeleteModerator(null, start, pageLength , moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_DeleteModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteModerator(TransactionManager transactionManager, System.Int32? moderatorId)
		{
			 DeleteModerator(transactionManager, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_DeleteModerator' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteModerator(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId);
		
		#endregion
		
		#region p_Moderator_GenerateCodes 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GenerateCodes' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="modCodeLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passCodeLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
			/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateCodes(System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? modCodeLength, System.Int32? passCodeLength, ref System.String moderatorCode, ref System.String passCode)
		{
			 GenerateCodes(null, 0, int.MaxValue , wholesalerId, customerId, moderatorId, modCodeLength, passCodeLength, ref moderatorCode, ref passCode);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GenerateCodes' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="modCodeLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passCodeLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
			/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateCodes(int start, int pageLength, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? modCodeLength, System.Int32? passCodeLength, ref System.String moderatorCode, ref System.String passCode)
		{
			 GenerateCodes(null, start, pageLength , wholesalerId, customerId, moderatorId, modCodeLength, passCodeLength, ref moderatorCode, ref passCode);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_GenerateCodes' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="modCodeLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passCodeLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
			/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateCodes(TransactionManager transactionManager, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? modCodeLength, System.Int32? passCodeLength, ref System.String moderatorCode, ref System.String passCode)
		{
			 GenerateCodes(transactionManager, 0, int.MaxValue , wholesalerId, customerId, moderatorId, modCodeLength, passCodeLength, ref moderatorCode, ref passCode);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GenerateCodes' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="modCodeLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passCodeLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
			/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GenerateCodes(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? modCodeLength, System.Int32? passCodeLength, ref System.String moderatorCode, ref System.String passCode);
		
		#endregion
		
		#region p_Moderator_GetProductFeatures 
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(System.Int32? moderatorId)
		{
			return GetProductFeatures(null, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(int start, int pageLength, System.Int32? moderatorId)
		{
			return GetProductFeatures(null, start, pageLength , moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Moderator_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(TransactionManager transactionManager, System.Int32? moderatorId)
		{
			return GetProductFeatures(transactionManager, 0, int.MaxValue , moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Moderator_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductFeatures(TransactionManager transactionManager, int start, int pageLength , System.Int32? moderatorId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Moderator&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Moderator&gt;"/></returns>
		public static CONFDB.Entities.TList<Moderator> Fill(IDataReader reader, CONFDB.Entities.TList<Moderator> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Moderator c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Moderator")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ModeratorColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ModeratorColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Moderator>(
					key.ToString(), // EntityTrackingKey
					"Moderator",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Moderator();
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
					c.Id = (System.Int32)reader[((int)ModeratorColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)ModeratorColumn.WholesalerId - 1)];
					c.CustomerId = (System.Int32)reader[((int)ModeratorColumn.CustomerId - 1)];
					c.PriCustomerNumber = (System.String)reader[((int)ModeratorColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (System.String)reader[((int)ModeratorColumn.SecCustomerNumber - 1)];
					c.ExternalModeratorNumber = (reader.IsDBNull(((int)ModeratorColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)ModeratorColumn.ExternalModeratorNumber - 1)];
					c.ModeratorCode = (System.String)reader[((int)ModeratorColumn.ModeratorCode - 1)];
					c.PassCode = (System.String)reader[((int)ModeratorColumn.PassCode - 1)];
					c.Description = (reader.IsDBNull(((int)ModeratorColumn.Description - 1)))?null:(System.String)reader[((int)ModeratorColumn.Description - 1)];
					c.DepartmentId = (System.Int32)reader[((int)ModeratorColumn.DepartmentId - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)ModeratorColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)ModeratorColumn.ModifiedBy - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)ModeratorColumn.CreatedDate - 1)];
					c.LastModified = (System.DateTime)reader[((int)ModeratorColumn.LastModified - 1)];
					c.Enabled = (reader.IsDBNull(((int)ModeratorColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)ModeratorColumn.Enabled - 1)];
					c.UniqueModeratorId = (System.Guid)reader[((int)ModeratorColumn.UniqueModeratorId - 1)];
					c.UserId = (reader.IsDBNull(((int)ModeratorColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ModeratorColumn.UserId - 1)];
					c.WebMeetingId = (reader.IsDBNull(((int)ModeratorColumn.WebMeetingId - 1)))?null:(System.String)reader[((int)ModeratorColumn.WebMeetingId - 1)];
					c.Omnovia_Room_Id = (reader.IsDBNull(((int)ModeratorColumn.Omnovia_Room_Id - 1)))?null:(System.Int32?)reader[((int)ModeratorColumn.Omnovia_Room_Id - 1)];
					c.Seevogh_Meeting_Url = (reader.IsDBNull(((int)ModeratorColumn.Seevogh_Meeting_Url - 1)))?null:(System.String)reader[((int)ModeratorColumn.Seevogh_Meeting_Url - 1)];
					c.SeeVoghMeetingId = (reader.IsDBNull(((int)ModeratorColumn.SeeVoghMeetingId - 1)))?null:(System.String)reader[((int)ModeratorColumn.SeeVoghMeetingId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Moderator"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Moderator entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ModeratorColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)ModeratorColumn.WholesalerId - 1)];
			entity.CustomerId = (System.Int32)reader[((int)ModeratorColumn.CustomerId - 1)];
			entity.PriCustomerNumber = (System.String)reader[((int)ModeratorColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (System.String)reader[((int)ModeratorColumn.SecCustomerNumber - 1)];
			entity.ExternalModeratorNumber = (reader.IsDBNull(((int)ModeratorColumn.ExternalModeratorNumber - 1)))?null:(System.String)reader[((int)ModeratorColumn.ExternalModeratorNumber - 1)];
			entity.ModeratorCode = (System.String)reader[((int)ModeratorColumn.ModeratorCode - 1)];
			entity.PassCode = (System.String)reader[((int)ModeratorColumn.PassCode - 1)];
			entity.Description = (reader.IsDBNull(((int)ModeratorColumn.Description - 1)))?null:(System.String)reader[((int)ModeratorColumn.Description - 1)];
			entity.DepartmentId = (System.Int32)reader[((int)ModeratorColumn.DepartmentId - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)ModeratorColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)ModeratorColumn.ModifiedBy - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)ModeratorColumn.CreatedDate - 1)];
			entity.LastModified = (System.DateTime)reader[((int)ModeratorColumn.LastModified - 1)];
			entity.Enabled = (reader.IsDBNull(((int)ModeratorColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)ModeratorColumn.Enabled - 1)];
			entity.UniqueModeratorId = (System.Guid)reader[((int)ModeratorColumn.UniqueModeratorId - 1)];
			entity.UserId = (reader.IsDBNull(((int)ModeratorColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ModeratorColumn.UserId - 1)];
			entity.WebMeetingId = (reader.IsDBNull(((int)ModeratorColumn.WebMeetingId - 1)))?null:(System.String)reader[((int)ModeratorColumn.WebMeetingId - 1)];
			entity.Omnovia_Room_Id = (reader.IsDBNull(((int)ModeratorColumn.Omnovia_Room_Id - 1)))?null:(System.Int32?)reader[((int)ModeratorColumn.Omnovia_Room_Id - 1)];
			entity.Seevogh_Meeting_Url = (reader.IsDBNull(((int)ModeratorColumn.Seevogh_Meeting_Url - 1)))?null:(System.String)reader[((int)ModeratorColumn.Seevogh_Meeting_Url - 1)];
			entity.SeeVoghMeetingId = (reader.IsDBNull(((int)ModeratorColumn.SeeVoghMeetingId - 1)))?null:(System.String)reader[((int)ModeratorColumn.SeeVoghMeetingId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Moderator"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Moderator entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.PriCustomerNumber = (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (System.String)dataRow["SecCustomerNumber"];
			entity.ExternalModeratorNumber = Convert.IsDBNull(dataRow["ExternalModeratorNumber"]) ? null : (System.String)dataRow["ExternalModeratorNumber"];
			entity.ModeratorCode = (System.String)dataRow["ModeratorCode"];
			entity.PassCode = (System.String)dataRow["PassCode"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DepartmentId = (System.Int32)dataRow["DepartmentID"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.UniqueModeratorId = (System.Guid)dataRow["UniqueModeratorID"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
			entity.WebMeetingId = Convert.IsDBNull(dataRow["WebMeetingID"]) ? null : (System.String)dataRow["WebMeetingID"];
			entity.Omnovia_Room_Id = Convert.IsDBNull(dataRow["omnovia_room_id"]) ? null : (System.Int32?)dataRow["omnovia_room_id"];
			entity.Seevogh_Meeting_Url = Convert.IsDBNull(dataRow["seevogh_meeting_url"]) ? null : (System.String)dataRow["seevogh_meeting_url"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Moderator"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Moderator Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Moderator entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UserIdSource	
			if (CanDeepLoad(entity, "User|UserIdSource", deepLoadType, innerList) 
				&& entity.UserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UserId ?? (int)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserIdSource = tmpEntity;
				else
					entity.UserIdSource = DataRepository.UserProvider.GetByUserId(transactionManager, (entity.UserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.UserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserIdSource

			#region DepartmentIdSource	
			if (CanDeepLoad(entity, "Department|DepartmentIdSource", deepLoadType, innerList) 
				&& entity.DepartmentIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DepartmentId;
				Department tmpEntity = EntityManager.LocateEntity<Department>(EntityLocator.ConstructKeyFromPkItems(typeof(Department), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DepartmentIdSource = tmpEntity;
				else
					entity.DepartmentIdSource = DataRepository.DepartmentProvider.GetById(transactionManager, entity.DepartmentId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DepartmentIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DepartmentIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DepartmentProvider.DeepLoad(transactionManager, entity.DepartmentIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DepartmentIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customer|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				Customer tmpEntity = EntityManager.LocateEntity<Customer>(EntityLocator.ConstructKeyFromPkItems(typeof(Customer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerProvider.GetById(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region Moderator_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator_Feature>|Moderator_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Moderator_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Moderator_FeatureCollection = DataRepository.Moderator_FeatureProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.Moderator_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator_Feature>) DataRepository.Moderator_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Moderator_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WelcomeKitRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WelcomeKitRequest>|WelcomeKitRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WelcomeKitRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WelcomeKitRequestCollection = DataRepository.WelcomeKitRequestProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.WelcomeKitRequestCollection.Count > 0)
				{
					deepHandles.Add("WelcomeKitRequestCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WelcomeKitRequest>) DataRepository.WelcomeKitRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.WelcomeKitRequestCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region BridgeRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BridgeRequest>|BridgeRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BridgeRequestCollection = DataRepository.BridgeRequestProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.BridgeRequestCollection.Count > 0)
				{
					deepHandles.Add("BridgeRequestCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BridgeRequest>) DataRepository.BridgeRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.BridgeRequestCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Moderator_DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator_Dnis>|Moderator_DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Moderator_DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Moderator_DnisCollection = DataRepository.Moderator_DnisProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.Moderator_DnisCollection.Count > 0)
				{
					deepHandles.Add("Moderator_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator_Dnis>) DataRepository.Moderator_DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.Moderator_DnisCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region BridgeQueueCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BridgeQueue>|BridgeQueueCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BridgeQueueCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BridgeQueueCollection = DataRepository.BridgeQueueProvider.GetByModeratorId(transactionManager, entity.Id);

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

				entity.RatedCdrCollection = DataRepository.RatedCdrProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.RatedCdrCollection.Count > 0)
				{
					deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RatedCdr>) DataRepository.RatedCdrProvider.DeepLoad,
						new object[] { transactionManager, entity.RatedCdrCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.TicketCollection = DataRepository.TicketProvider.GetByModeratorId(transactionManager, entity.Id);

				if (deep && entity.TicketCollection.Count > 0)
				{
					deepHandles.Add("TicketCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Ticket>) DataRepository.TicketProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DnisidDnisCollection_From_Moderator_Dnis
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Dnis>|DnisidDnisCollection_From_Moderator_Dnis", deepLoadType, innerList))
			{
				entity.DnisidDnisCollection_From_Moderator_Dnis = DataRepository.DnisProvider.GetByModeratorIdFromModerator_Dnis(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisidDnisCollection_From_Moderator_Dnis' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DnisidDnisCollection_From_Moderator_Dnis != null)
				{
					deepHandles.Add("DnisidDnisCollection_From_Moderator_Dnis",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Dnis >) DataRepository.DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.DnisidDnisCollection_From_Moderator_Dnis, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Moderator object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Moderator instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Moderator Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Moderator entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UserIdSource
			if (CanDeepSave(entity, "User|UserIdSource", deepSaveType, innerList) 
				&& entity.UserIdSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.UserIdSource);
				entity.UserId = entity.UserIdSource.UserId;
			}
			#endregion 
			
			#region DepartmentIdSource
			if (CanDeepSave(entity, "Department|DepartmentIdSource", deepSaveType, innerList) 
				&& entity.DepartmentIdSource != null)
			{
				DataRepository.DepartmentProvider.Save(transactionManager, entity.DepartmentIdSource);
				entity.DepartmentId = entity.DepartmentIdSource.Id;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region DnisidDnisCollection_From_Moderator_Dnis>
			if (CanDeepSave(entity.DnisidDnisCollection_From_Moderator_Dnis, "List<Dnis>|DnisidDnisCollection_From_Moderator_Dnis", deepSaveType, innerList))
			{
				if (entity.DnisidDnisCollection_From_Moderator_Dnis.Count > 0 || entity.DnisidDnisCollection_From_Moderator_Dnis.DeletedItems.Count > 0)
				{
					DataRepository.DnisProvider.Save(transactionManager, entity.DnisidDnisCollection_From_Moderator_Dnis); 
					deepHandles.Add("DnisidDnisCollection_From_Moderator_Dnis",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Dnis>) DataRepository.DnisProvider.DeepSave,
						new object[] { transactionManager, entity.DnisidDnisCollection_From_Moderator_Dnis, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Moderator_Feature>
				if (CanDeepSave(entity.Moderator_FeatureCollection, "List<Moderator_Feature>|Moderator_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator_Feature child in entity.Moderator_FeatureCollection)
					{
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
						}

					}

					if (entity.Moderator_FeatureCollection.Count > 0 || entity.Moderator_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Moderator_FeatureProvider.Save(transactionManager, entity.Moderator_FeatureCollection);
						
						deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator_Feature >) DataRepository.Moderator_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Moderator_FeatureCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<WelcomeKitRequest>
				if (CanDeepSave(entity.WelcomeKitRequestCollection, "List<WelcomeKitRequest>|WelcomeKitRequestCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WelcomeKitRequest child in entity.WelcomeKitRequestCollection)
					{
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
						}

					}

					if (entity.WelcomeKitRequestCollection.Count > 0 || entity.WelcomeKitRequestCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WelcomeKitRequestProvider.Save(transactionManager, entity.WelcomeKitRequestCollection);
						
						deepHandles.Add("WelcomeKitRequestCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WelcomeKitRequest >) DataRepository.WelcomeKitRequestProvider.DeepSave,
							new object[] { transactionManager, entity.WelcomeKitRequestCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<BridgeRequest>
				if (CanDeepSave(entity.BridgeRequestCollection, "List<BridgeRequest>|BridgeRequestCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BridgeRequest child in entity.BridgeRequestCollection)
					{
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
						}

					}

					if (entity.BridgeRequestCollection.Count > 0 || entity.BridgeRequestCollection.DeletedItems.Count > 0)
					{
						//DataRepository.BridgeRequestProvider.Save(transactionManager, entity.BridgeRequestCollection);
						
						deepHandles.Add("BridgeRequestCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BridgeRequest >) DataRepository.BridgeRequestProvider.DeepSave,
							new object[] { transactionManager, entity.BridgeRequestCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Moderator_Dnis>
				if (CanDeepSave(entity.Moderator_DnisCollection, "List<Moderator_Dnis>|Moderator_DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator_Dnis child in entity.Moderator_DnisCollection)
					{
						if(child.ModeratorIdSource != null)
						{
								child.ModeratorId = child.ModeratorIdSource.Id;
						}

						if(child.DnisidSource != null)
						{
								child.Dnisid = child.DnisidSource.Id;
						}

					}

					if (entity.Moderator_DnisCollection.Count > 0 || entity.Moderator_DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Moderator_DnisProvider.Save(transactionManager, entity.Moderator_DnisCollection);
						
						deepHandles.Add("Moderator_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator_Dnis >) DataRepository.Moderator_DnisProvider.DeepSave,
							new object[] { transactionManager, entity.Moderator_DnisCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<BridgeQueue>
				if (CanDeepSave(entity.BridgeQueueCollection, "List<BridgeQueue>|BridgeQueueCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BridgeQueue child in entity.BridgeQueueCollection)
					{
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
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
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
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
				
	
			#region List<Ticket>
				if (CanDeepSave(entity.TicketCollection, "List<Ticket>|TicketCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Ticket child in entity.TicketCollection)
					{
						if(child.ModeratorIdSource != null)
						{
							child.ModeratorId = child.ModeratorIdSource.Id;
						}
						else
						{
							child.ModeratorId = entity.Id;
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
	
	#region ModeratorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Moderator</c>
	///</summary>
	public enum ModeratorChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>User</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(User))]
		User,
			
		///<summary>
		/// Composite Property for <c>Department</c> at DepartmentIdSource
		///</summary>
		[ChildEntityType(typeof(Department))]
		Department,
			
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
	
		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for Moderator_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator_Feature>))]
		Moderator_FeatureCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for WelcomeKitRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<WelcomeKitRequest>))]
		WelcomeKitRequestCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for BridgeRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<BridgeRequest>))]
		BridgeRequestCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for Moderator_DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator_Dnis>))]
		Moderator_DnisCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for BridgeQueueCollection
		///</summary>
		[ChildEntityType(typeof(TList<BridgeQueue>))]
		BridgeQueueCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for RatedCdrCollection
		///</summary>
		[ChildEntityType(typeof(TList<RatedCdr>))]
		RatedCdrCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as OneToMany for TicketCollection
		///</summary>
		[ChildEntityType(typeof(TList<Ticket>))]
		TicketCollection,

		///<summary>
		/// Collection of <c>Moderator</c> as ManyToMany for DnisCollection_From_Moderator_Dnis
		///</summary>
		[ChildEntityType(typeof(TList<Dnis>))]
		DnisidDnisCollection_From_Moderator_Dnis,
	}
	
	#endregion ModeratorChildEntityTypes
	
	#region ModeratorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ModeratorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorFilterBuilder : SqlFilterBuilder<ModeratorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorFilterBuilder class.
		/// </summary>
		public ModeratorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorFilterBuilder
	
	#region ModeratorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ModeratorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Moderator"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorParameterBuilder : ParameterizedSqlFilterBuilder<ModeratorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorParameterBuilder class.
		/// </summary>
		public ModeratorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorParameterBuilder
} // end namespace
