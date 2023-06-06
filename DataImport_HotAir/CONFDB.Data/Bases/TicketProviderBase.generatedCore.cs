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
	/// This class is the base class for any <see cref="TicketProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TicketProviderBaseCore : EntityProviderBase<CONFDB.Entities.Ticket, CONFDB.Entities.TicketKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TicketKey key)
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
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		FK_Ticket_Customer Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		FK_Ticket_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		FK_Ticket_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		fk_Ticket_Customer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		fk_Ticket_Customer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Customer key.
		///		FK_Ticket_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		FK_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		FK_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		FK_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		fk_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		fk_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Wholesaler key.
		///		FK_Ticket_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		FK_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="_ticketProductId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketProductId(System.Int32 _ticketProductId)
		{
			int count = -1;
			return GetByTicketProductId(_ticketProductId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		FK_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketProductId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByTicketProductId(TransactionManager transactionManager, System.Int32 _ticketProductId)
		{
			int count = -1;
			return GetByTicketProductId(transactionManager, _ticketProductId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		FK_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketProductId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketProductId(TransactionManager transactionManager, System.Int32 _ticketProductId, int start, int pageLength)
		{
			int count = -1;
			return GetByTicketProductId(transactionManager, _ticketProductId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		fk_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketProductId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketProductId(System.Int32 _ticketProductId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTicketProductId(null, _ticketProductId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		fk_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketProductId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketProductId(System.Int32 _ticketProductId, int start, int pageLength,out int count)
		{
			return GetByTicketProductId(null, _ticketProductId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketProduct key.
		///		FK_Ticket_TicketProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketProductId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByTicketProductId(TransactionManager transactionManager, System.Int32 _ticketProductId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		FK_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="_statusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByStatusId(System.Int32 _statusId)
		{
			int count = -1;
			return GetByStatusId(_statusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		FK_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId)
		{
			int count = -1;
			return GetByStatusId(transactionManager, _statusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		FK_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId, int start, int pageLength)
		{
			int count = -1;
			return GetByStatusId(transactionManager, _statusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		fk_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_statusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByStatusId(System.Int32 _statusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStatusId(null, _statusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		fk_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_statusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByStatusId(System.Int32 _statusId, int start, int pageLength,out int count)
		{
			return GetByStatusId(null, _statusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketStatus key.
		///		FK_Ticket_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		FK_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="_ticketPriorityId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(System.Int32 _ticketPriorityId)
		{
			int count = -1;
			return GetByTicketPriorityId(_ticketPriorityId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		FK_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketPriorityId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(TransactionManager transactionManager, System.Int32 _ticketPriorityId)
		{
			int count = -1;
			return GetByTicketPriorityId(transactionManager, _ticketPriorityId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		FK_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketPriorityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(TransactionManager transactionManager, System.Int32 _ticketPriorityId, int start, int pageLength)
		{
			int count = -1;
			return GetByTicketPriorityId(transactionManager, _ticketPriorityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		fk_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketPriorityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(System.Int32 _ticketPriorityId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTicketPriorityId(null, _ticketPriorityId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		fk_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketPriorityId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(System.Int32 _ticketPriorityId, int start, int pageLength,out int count)
		{
			return GetByTicketPriorityId(null, _ticketPriorityId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketPriority key.
		///		FK_Ticket_TicketPriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketPriorityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByTicketPriorityId(TransactionManager transactionManager, System.Int32 _ticketPriorityId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		FK_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="_ticketCategoryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(System.Int32 _ticketCategoryId)
		{
			int count = -1;
			return GetByTicketCategoryId(_ticketCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		FK_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketCategoryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(TransactionManager transactionManager, System.Int32 _ticketCategoryId)
		{
			int count = -1;
			return GetByTicketCategoryId(transactionManager, _ticketCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		FK_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(TransactionManager transactionManager, System.Int32 _ticketCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTicketCategoryId(transactionManager, _ticketCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		fk_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(System.Int32 _ticketCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTicketCategoryId(null, _ticketCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		fk_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ticketCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(System.Int32 _ticketCategoryId, int start, int pageLength,out int count)
		{
			return GetByTicketCategoryId(null, _ticketCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_TicketCategory key.
		///		FK_Ticket_TicketCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByTicketCategoryId(TransactionManager transactionManager, System.Int32 _ticketCategoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		FK_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(_moderatorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		FK_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Ticket> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		FK_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		fk_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		fk_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public CONFDB.Entities.TList<Ticket> GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength,out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Ticket_Moderator key.
		///		FK_Ticket_Moderator Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Ticket objects.</returns>
		public abstract CONFDB.Entities.TList<Ticket> GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Ticket Get(TransactionManager transactionManager, CONFDB.Entities.TicketKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Ticket_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public CONFDB.Entities.Ticket GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Ticket_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public CONFDB.Entities.Ticket GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Ticket_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public CONFDB.Entities.Ticket GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Ticket_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public CONFDB.Entities.Ticket GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Ticket_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public CONFDB.Entities.Ticket GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Ticket_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Ticket"/> class.</returns>
		public abstract CONFDB.Entities.Ticket GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Ticket&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Ticket&gt;"/></returns>
		public static CONFDB.Entities.TList<Ticket> Fill(IDataReader reader, CONFDB.Entities.TList<Ticket> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Ticket c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Ticket")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TicketColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TicketColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Ticket>(
					key.ToString(), // EntityTrackingKey
					"Ticket",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Ticket();
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
					c.Id = (System.Int32)reader[((int)TicketColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Title = (reader.IsDBNull(((int)TicketColumn.Title - 1)))?null:(System.String)reader[((int)TicketColumn.Title - 1)];
					c.IssueDescription = (reader.IsDBNull(((int)TicketColumn.IssueDescription - 1)))?null:(System.String)reader[((int)TicketColumn.IssueDescription - 1)];
					c.ClientContactInfo = (reader.IsDBNull(((int)TicketColumn.ClientContactInfo - 1)))?null:(System.String)reader[((int)TicketColumn.ClientContactInfo - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)TicketColumn.WholesalerId - 1)))?null:(System.String)reader[((int)TicketColumn.WholesalerId - 1)];
					c.CustomerId = (System.Int32)reader[((int)TicketColumn.CustomerId - 1)];
					c.ModeratorId = (System.Int32)reader[((int)TicketColumn.ModeratorId - 1)];
					c.StatusId = (System.Int32)reader[((int)TicketColumn.StatusId - 1)];
					c.ResolutionText = (reader.IsDBNull(((int)TicketColumn.ResolutionText - 1)))?null:(System.String)reader[((int)TicketColumn.ResolutionText - 1)];
					c.TicketPriorityId = (System.Int32)reader[((int)TicketColumn.TicketPriorityId - 1)];
					c.CreatedByUserId = (System.Int32)reader[((int)TicketColumn.CreatedByUserId - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)TicketColumn.CreatedDate - 1)];
					c.AssignedToUserId = (System.Int32)reader[((int)TicketColumn.AssignedToUserId - 1)];
					c.AssignedDate = (System.DateTime)reader[((int)TicketColumn.AssignedDate - 1)];
					c.FixedByUserId = (System.Int32)reader[((int)TicketColumn.FixedByUserId - 1)];
					c.FixedDate = (System.DateTime)reader[((int)TicketColumn.FixedDate - 1)];
					c.ClosedByUserId = (System.Int32)reader[((int)TicketColumn.ClosedByUserId - 1)];
					c.ClosedDate = (System.DateTime)reader[((int)TicketColumn.ClosedDate - 1)];
					c.TicketProductId = (System.Int32)reader[((int)TicketColumn.TicketProductId - 1)];
					c.TicketCategoryId = (System.Int32)reader[((int)TicketColumn.TicketCategoryId - 1)];
					c.DuplicateTicketId = (System.Int32)reader[((int)TicketColumn.DuplicateTicketId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Ticket"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Ticket"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Ticket entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)TicketColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.Title = (reader.IsDBNull(((int)TicketColumn.Title - 1)))?null:(System.String)reader[((int)TicketColumn.Title - 1)];
			entity.IssueDescription = (reader.IsDBNull(((int)TicketColumn.IssueDescription - 1)))?null:(System.String)reader[((int)TicketColumn.IssueDescription - 1)];
			entity.ClientContactInfo = (reader.IsDBNull(((int)TicketColumn.ClientContactInfo - 1)))?null:(System.String)reader[((int)TicketColumn.ClientContactInfo - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)TicketColumn.WholesalerId - 1)))?null:(System.String)reader[((int)TicketColumn.WholesalerId - 1)];
			entity.CustomerId = (System.Int32)reader[((int)TicketColumn.CustomerId - 1)];
			entity.ModeratorId = (System.Int32)reader[((int)TicketColumn.ModeratorId - 1)];
			entity.StatusId = (System.Int32)reader[((int)TicketColumn.StatusId - 1)];
			entity.ResolutionText = (reader.IsDBNull(((int)TicketColumn.ResolutionText - 1)))?null:(System.String)reader[((int)TicketColumn.ResolutionText - 1)];
			entity.TicketPriorityId = (System.Int32)reader[((int)TicketColumn.TicketPriorityId - 1)];
			entity.CreatedByUserId = (System.Int32)reader[((int)TicketColumn.CreatedByUserId - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)TicketColumn.CreatedDate - 1)];
			entity.AssignedToUserId = (System.Int32)reader[((int)TicketColumn.AssignedToUserId - 1)];
			entity.AssignedDate = (System.DateTime)reader[((int)TicketColumn.AssignedDate - 1)];
			entity.FixedByUserId = (System.Int32)reader[((int)TicketColumn.FixedByUserId - 1)];
			entity.FixedDate = (System.DateTime)reader[((int)TicketColumn.FixedDate - 1)];
			entity.ClosedByUserId = (System.Int32)reader[((int)TicketColumn.ClosedByUserId - 1)];
			entity.ClosedDate = (System.DateTime)reader[((int)TicketColumn.ClosedDate - 1)];
			entity.TicketProductId = (System.Int32)reader[((int)TicketColumn.TicketProductId - 1)];
			entity.TicketCategoryId = (System.Int32)reader[((int)TicketColumn.TicketCategoryId - 1)];
			entity.DuplicateTicketId = (System.Int32)reader[((int)TicketColumn.DuplicateTicketId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Ticket"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Ticket"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Ticket entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.IssueDescription = Convert.IsDBNull(dataRow["IssueDescription"]) ? null : (System.String)dataRow["IssueDescription"];
			entity.ClientContactInfo = Convert.IsDBNull(dataRow["ClientContactInfo"]) ? null : (System.String)dataRow["ClientContactInfo"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.StatusId = (System.Int32)dataRow["StatusID"];
			entity.ResolutionText = Convert.IsDBNull(dataRow["ResolutionText"]) ? null : (System.String)dataRow["ResolutionText"];
			entity.TicketPriorityId = (System.Int32)dataRow["TicketPriorityID"];
			entity.CreatedByUserId = (System.Int32)dataRow["CreatedByUserID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.AssignedToUserId = (System.Int32)dataRow["AssignedToUserID"];
			entity.AssignedDate = (System.DateTime)dataRow["AssignedDate"];
			entity.FixedByUserId = (System.Int32)dataRow["FixedByUserID"];
			entity.FixedDate = (System.DateTime)dataRow["FixedDate"];
			entity.ClosedByUserId = (System.Int32)dataRow["ClosedByUserID"];
			entity.ClosedDate = (System.DateTime)dataRow["ClosedDate"];
			entity.TicketProductId = (System.Int32)dataRow["TicketProductID"];
			entity.TicketCategoryId = (System.Int32)dataRow["TicketCategoryID"];
			entity.DuplicateTicketId = (System.Int32)dataRow["DuplicateTicketID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Ticket"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Ticket Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Ticket entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region TicketProductIdSource	
			if (CanDeepLoad(entity, "TicketProduct|TicketProductIdSource", deepLoadType, innerList) 
				&& entity.TicketProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TicketProductId;
				TicketProduct tmpEntity = EntityManager.LocateEntity<TicketProduct>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketProduct), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TicketProductIdSource = tmpEntity;
				else
					entity.TicketProductIdSource = DataRepository.TicketProductProvider.GetById(transactionManager, entity.TicketProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TicketProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketProductProvider.DeepLoad(transactionManager, entity.TicketProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TicketProductIdSource

			#region StatusIdSource	
			if (CanDeepLoad(entity, "TicketStatus|StatusIdSource", deepLoadType, innerList) 
				&& entity.StatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.StatusId;
				TicketStatus tmpEntity = EntityManager.LocateEntity<TicketStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StatusIdSource = tmpEntity;
				else
					entity.StatusIdSource = DataRepository.TicketStatusProvider.GetById(transactionManager, entity.StatusId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.StatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketStatusProvider.DeepLoad(transactionManager, entity.StatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion StatusIdSource

			#region TicketPriorityIdSource	
			if (CanDeepLoad(entity, "TicketPriority|TicketPriorityIdSource", deepLoadType, innerList) 
				&& entity.TicketPriorityIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TicketPriorityId;
				TicketPriority tmpEntity = EntityManager.LocateEntity<TicketPriority>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketPriority), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TicketPriorityIdSource = tmpEntity;
				else
					entity.TicketPriorityIdSource = DataRepository.TicketPriorityProvider.GetById(transactionManager, entity.TicketPriorityId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketPriorityIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TicketPriorityIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketPriorityProvider.DeepLoad(transactionManager, entity.TicketPriorityIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TicketPriorityIdSource

			#region TicketCategoryIdSource	
			if (CanDeepLoad(entity, "TicketCategory|TicketCategoryIdSource", deepLoadType, innerList) 
				&& entity.TicketCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TicketCategoryId;
				TicketCategory tmpEntity = EntityManager.LocateEntity<TicketCategory>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketCategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TicketCategoryIdSource = tmpEntity;
				else
					entity.TicketCategoryIdSource = DataRepository.TicketCategoryProvider.GetById(transactionManager, entity.TicketCategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TicketCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketCategoryProvider.DeepLoad(transactionManager, entity.TicketCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TicketCategoryIdSource

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
			// Deep load child collections  - Call GetById methods when available
			
			#region TicketStatusHistory
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "TicketStatusHistory|TicketStatusHistory", deepLoadType, innerList))
			{
				entity.TicketStatusHistory = DataRepository.TicketStatusHistoryProvider.GetByTicketId(transactionManager, entity.Id);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketStatusHistory' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.TicketStatusHistory != null)
				{
					deepHandles.Add("TicketStatusHistory",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< TicketStatusHistory >) DataRepository.TicketStatusHistoryProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketStatusHistory, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Ticket object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Ticket instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Ticket Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Ticket entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.Id;
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
			
			#region TicketProductIdSource
			if (CanDeepSave(entity, "TicketProduct|TicketProductIdSource", deepSaveType, innerList) 
				&& entity.TicketProductIdSource != null)
			{
				DataRepository.TicketProductProvider.Save(transactionManager, entity.TicketProductIdSource);
				entity.TicketProductId = entity.TicketProductIdSource.Id;
			}
			#endregion 
			
			#region StatusIdSource
			if (CanDeepSave(entity, "TicketStatus|StatusIdSource", deepSaveType, innerList) 
				&& entity.StatusIdSource != null)
			{
				DataRepository.TicketStatusProvider.Save(transactionManager, entity.StatusIdSource);
				entity.StatusId = entity.StatusIdSource.Id;
			}
			#endregion 
			
			#region TicketPriorityIdSource
			if (CanDeepSave(entity, "TicketPriority|TicketPriorityIdSource", deepSaveType, innerList) 
				&& entity.TicketPriorityIdSource != null)
			{
				DataRepository.TicketPriorityProvider.Save(transactionManager, entity.TicketPriorityIdSource);
				entity.TicketPriorityId = entity.TicketPriorityIdSource.Id;
			}
			#endregion 
			
			#region TicketCategoryIdSource
			if (CanDeepSave(entity, "TicketCategory|TicketCategoryIdSource", deepSaveType, innerList) 
				&& entity.TicketCategoryIdSource != null)
			{
				DataRepository.TicketCategoryProvider.Save(transactionManager, entity.TicketCategoryIdSource);
				entity.TicketCategoryId = entity.TicketCategoryIdSource.Id;
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

			#region TicketStatusHistory
			if (CanDeepSave(entity.TicketStatusHistory, "TicketStatusHistory|TicketStatusHistory", deepSaveType, innerList))
			{

				if (entity.TicketStatusHistory != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.TicketStatusHistory.TicketId = entity.Id;
					//DataRepository.TicketStatusHistoryProvider.Save(transactionManager, entity.TicketStatusHistory);
					deepHandles.Add("TicketStatusHistory",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< TicketStatusHistory >) DataRepository.TicketStatusHistoryProvider.DeepSave,
						new object[] { transactionManager, entity.TicketStatusHistory, deepSaveType, childTypes, innerList }
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
	
	#region TicketChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Ticket</c>
	///</summary>
	public enum TicketChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
			
		///<summary>
		/// Composite Property for <c>TicketProduct</c> at TicketProductIdSource
		///</summary>
		[ChildEntityType(typeof(TicketProduct))]
		TicketProduct,
			
		///<summary>
		/// Composite Property for <c>TicketStatus</c> at StatusIdSource
		///</summary>
		[ChildEntityType(typeof(TicketStatus))]
		TicketStatus,
			
		///<summary>
		/// Composite Property for <c>TicketPriority</c> at TicketPriorityIdSource
		///</summary>
		[ChildEntityType(typeof(TicketPriority))]
		TicketPriority,
			
		///<summary>
		/// Composite Property for <c>TicketCategory</c> at TicketCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(TicketCategory))]
		TicketCategory,
			
		///<summary>
		/// Composite Property for <c>Moderator</c> at ModeratorIdSource
		///</summary>
		[ChildEntityType(typeof(Moderator))]
		Moderator,
			///<summary>
		/// Entity <c>TicketStatusHistory</c> as OneToOne for TicketStatusHistory
		///</summary>
		[ChildEntityType(typeof(TicketStatusHistory))]
		TicketStatusHistory,
	}
	
	#endregion TicketChildEntityTypes
	
	#region TicketFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TicketColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketFilterBuilder : SqlFilterBuilder<TicketColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketFilterBuilder class.
		/// </summary>
		public TicketFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketFilterBuilder
	
	#region TicketParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TicketColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Ticket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketParameterBuilder : ParameterizedSqlFilterBuilder<TicketColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketParameterBuilder class.
		/// </summary>
		public TicketParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketParameterBuilder
} // end namespace
