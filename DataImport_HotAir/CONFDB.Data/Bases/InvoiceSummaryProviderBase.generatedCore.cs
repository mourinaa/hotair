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
	/// This class is the base class for any <see cref="InvoiceSummaryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InvoiceSummaryProviderBaseCore : EntityProviderBase<CONFDB.Entities.InvoiceSummary, CONFDB.Entities.InvoiceSummaryKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.InvoiceSummaryKey key)
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
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		FK_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		FK_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		FK_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		fk_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		fk_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_InvoiceSummary_Customer key.
		///		FK_InvoiceSummary_Customer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.InvoiceSummary objects.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.InvoiceSummary Get(TransactionManager transactionManager, CONFDB.Entities.InvoiceSummaryKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public CONFDB.Entities.InvoiceSummary GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public CONFDB.Entities.InvoiceSummary GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public CONFDB.Entities.InvoiceSummary GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public CONFDB.Entities.InvoiceSummary GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public CONFDB.Entities.InvoiceSummary GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoicesSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceSummary"/> class.</returns>
		public abstract CONFDB.Entities.InvoiceSummary GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(System.DateTime _startDate)
		{
			int count = -1;
			return GetByStartDate(null,_startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByStartDate(null, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate)
		{
			int count = -1;
			return GetByStartDate(transactionManager, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByStartDate(transactionManager, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(System.DateTime _startDate, int start, int pageLength, out int count)
		{
			return GetByStartDate(null, _startDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(System.DateTime _endDate)
		{
			int count = -1;
			return GetByEndDate(null,_endDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(System.DateTime _endDate, int start, int pageLength)
		{
			int count = -1;
			return GetByEndDate(null, _endDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(TransactionManager transactionManager, System.DateTime _endDate)
		{
			int count = -1;
			return GetByEndDate(transactionManager, _endDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(TransactionManager transactionManager, System.DateTime _endDate, int start, int pageLength)
		{
			int count = -1;
			return GetByEndDate(transactionManager, _endDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(System.DateTime _endDate, int start, int pageLength, out int count)
		{
			return GetByEndDate(null, _endDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByEndDate(TransactionManager transactionManager, System.DateTime _endDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(null,_priCustomerNumber, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(null, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(transactionManager, _priCustomerNumber, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(transactionManager, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByPriCustomerNumberWholesalerId(null, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_PriCustomerNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="_invoiceNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(System.String _invoiceNumber)
		{
			int count = -1;
			return GetByInvoiceNumber(null,_invoiceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="_invoiceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(System.String _invoiceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceNumber(null, _invoiceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(TransactionManager transactionManager, System.String _invoiceNumber)
		{
			int count = -1;
			return GetByInvoiceNumber(transactionManager, _invoiceNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(TransactionManager transactionManager, System.String _invoiceNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceNumber(transactionManager, _invoiceNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="_invoiceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(System.String _invoiceNumber, int start, int pageLength, out int count)
		{
			return GetByInvoiceNumber(null, _invoiceNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_InvoiceNum index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByInvoiceNumber(TransactionManager transactionManager, System.String _invoiceNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(null,_wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoicesSummary_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceSummary> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_InvoiceSummary_GetInvoiceSummary 
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummary(System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummary(null, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummary(int start, int pageLength, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummary(null, start, pageLength , startDate, customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummary(TransactionManager transactionManager, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummary(transactionManager, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetInvoiceSummary(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.Int32? customerId);
		
		#endregion
		
		#region p_InvoiceSummary_GetInvoiceSummaryForInvoiceEmail 
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummaryForInvoiceEmail' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummaryForInvoiceEmail(System.String wholesalerId, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummaryForInvoiceEmail(null, 0, int.MaxValue , wholesalerId, startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummaryForInvoiceEmail' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummaryForInvoiceEmail(int start, int pageLength, System.String wholesalerId, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummaryForInvoiceEmail(null, start, pageLength , wholesalerId, startDate, customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummaryForInvoiceEmail' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetInvoiceSummaryForInvoiceEmail(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetInvoiceSummaryForInvoiceEmail(transactionManager, 0, int.MaxValue , wholesalerId, startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetInvoiceSummaryForInvoiceEmail' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetInvoiceSummaryForInvoiceEmail(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? startDate, System.Int32? customerId);
		
		#endregion
		
		#region p_InvoiceSummary_GetServiceSummary 
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummary(System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummary(null, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummary(int start, int pageLength, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummary(null, start, pageLength , startDate, customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummary(TransactionManager transactionManager, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummary(transactionManager, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummary' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetServiceSummary(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.Int32? customerId);
		
		#endregion
		
		#region p_InvoiceSummary_GetServiceDetails 
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceDetails' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceDetails(System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceDetails(null, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceDetails' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceDetails(int start, int pageLength, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceDetails(null, start, pageLength , startDate, customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceDetails' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceDetails(TransactionManager transactionManager, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceDetails(transactionManager, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceDetails' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetServiceDetails(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.Int32? customerId);
		
		#endregion
		
		#region p_InvoiceSummary_GetServiceSummaryTest 
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummaryTest' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummaryTest(System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummaryTest(null, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummaryTest' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummaryTest(int start, int pageLength, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummaryTest(null, start, pageLength , startDate, customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummaryTest' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetServiceSummaryTest(TransactionManager transactionManager, System.DateTime? startDate, System.Int32? customerId)
		{
			return GetServiceSummaryTest(transactionManager, 0, int.MaxValue , startDate, customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_InvoiceSummary_GetServiceSummaryTest' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetServiceSummaryTest(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.Int32? customerId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;InvoiceSummary&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;InvoiceSummary&gt;"/></returns>
		public static CONFDB.Entities.TList<InvoiceSummary> Fill(IDataReader reader, CONFDB.Entities.TList<InvoiceSummary> rows, int start, int pageLength)
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
				
				CONFDB.Entities.InvoiceSummary c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("InvoiceSummary")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.InvoiceSummaryColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.InvoiceSummaryColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<InvoiceSummary>(
					key.ToString(), // EntityTrackingKey
					"InvoiceSummary",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.InvoiceSummary();
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
					c.Id = (System.Int32)reader[((int)InvoiceSummaryColumn.Id - 1)];
					c.StartDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.StartDate - 1)];
					c.EndDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.EndDate - 1)];
					c.CustomerId = (System.Int32)reader[((int)InvoiceSummaryColumn.CustomerId - 1)];
					c.PriCustomerNumber = (System.String)reader[((int)InvoiceSummaryColumn.PriCustomerNumber - 1)];
					c.InvoiceNumber = (System.String)reader[((int)InvoiceSummaryColumn.InvoiceNumber - 1)];
					c.AmountOfLastBill = (reader.IsDBNull(((int)InvoiceSummaryColumn.AmountOfLastBill - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.AmountOfLastBill - 1)];
					c.Payment1 = (reader.IsDBNull(((int)InvoiceSummaryColumn.Payment1 - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.Payment1 - 1)];
					c.TotalCredits = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalCredits - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalCredits - 1)];
					c.TotalLatePaymentCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalLatePaymentCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalLatePaymentCharges - 1)];
					c.BalForward = (reader.IsDBNull(((int)InvoiceSummaryColumn.BalForward - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.BalForward - 1)];
					c.ProductCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.ProductCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.ProductCharges - 1)];
					c.MiscCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.MiscCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.MiscCharges - 1)];
					c.LocalTaxAmount = (reader.IsDBNull(((int)InvoiceSummaryColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.LocalTaxAmount - 1)];
					c.FederalTaxAmount = (reader.IsDBNull(((int)InvoiceSummaryColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.FederalTaxAmount - 1)];
					c.TotalCurrent = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalCurrent - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalCurrent - 1)];
					c.BalanceForward = (reader.IsDBNull(((int)InvoiceSummaryColumn.BalanceForward - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.BalanceForward - 1)];
					c.InvoiceDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.InvoiceDate - 1)];
					c.DueDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.DueDate - 1)];
					c.CurrencyId = (System.String)reader[((int)InvoiceSummaryColumn.CurrencyId - 1)];
					c.WholesalerId = (System.String)reader[((int)InvoiceSummaryColumn.WholesalerId - 1)];
					c.TotalFreeCredits = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalFreeCredits - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalFreeCredits - 1)];
					c.Wholesaler_ProductId = (reader.IsDBNull(((int)InvoiceSummaryColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)InvoiceSummaryColumn.Wholesaler_ProductId - 1)];
					c.BpayCustomerRefNumber = (reader.IsDBNull(((int)InvoiceSummaryColumn.BpayCustomerRefNumber - 1)))?null:(System.String)reader[((int)InvoiceSummaryColumn.BpayCustomerRefNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.InvoiceSummary"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceSummary"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.InvoiceSummary entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)InvoiceSummaryColumn.Id - 1)];
			entity.StartDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.StartDate - 1)];
			entity.EndDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.EndDate - 1)];
			entity.CustomerId = (System.Int32)reader[((int)InvoiceSummaryColumn.CustomerId - 1)];
			entity.PriCustomerNumber = (System.String)reader[((int)InvoiceSummaryColumn.PriCustomerNumber - 1)];
			entity.InvoiceNumber = (System.String)reader[((int)InvoiceSummaryColumn.InvoiceNumber - 1)];
			entity.AmountOfLastBill = (reader.IsDBNull(((int)InvoiceSummaryColumn.AmountOfLastBill - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.AmountOfLastBill - 1)];
			entity.Payment1 = (reader.IsDBNull(((int)InvoiceSummaryColumn.Payment1 - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.Payment1 - 1)];
			entity.TotalCredits = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalCredits - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalCredits - 1)];
			entity.TotalLatePaymentCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalLatePaymentCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalLatePaymentCharges - 1)];
			entity.BalForward = (reader.IsDBNull(((int)InvoiceSummaryColumn.BalForward - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.BalForward - 1)];
			entity.ProductCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.ProductCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.ProductCharges - 1)];
			entity.MiscCharges = (reader.IsDBNull(((int)InvoiceSummaryColumn.MiscCharges - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.MiscCharges - 1)];
			entity.LocalTaxAmount = (reader.IsDBNull(((int)InvoiceSummaryColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.LocalTaxAmount - 1)];
			entity.FederalTaxAmount = (reader.IsDBNull(((int)InvoiceSummaryColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.FederalTaxAmount - 1)];
			entity.TotalCurrent = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalCurrent - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalCurrent - 1)];
			entity.BalanceForward = (reader.IsDBNull(((int)InvoiceSummaryColumn.BalanceForward - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.BalanceForward - 1)];
			entity.InvoiceDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.InvoiceDate - 1)];
			entity.DueDate = (System.DateTime)reader[((int)InvoiceSummaryColumn.DueDate - 1)];
			entity.CurrencyId = (System.String)reader[((int)InvoiceSummaryColumn.CurrencyId - 1)];
			entity.WholesalerId = (System.String)reader[((int)InvoiceSummaryColumn.WholesalerId - 1)];
			entity.TotalFreeCredits = (reader.IsDBNull(((int)InvoiceSummaryColumn.TotalFreeCredits - 1)))?null:(System.Decimal?)reader[((int)InvoiceSummaryColumn.TotalFreeCredits - 1)];
			entity.Wholesaler_ProductId = (reader.IsDBNull(((int)InvoiceSummaryColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)InvoiceSummaryColumn.Wholesaler_ProductId - 1)];
			entity.BpayCustomerRefNumber = (reader.IsDBNull(((int)InvoiceSummaryColumn.BpayCustomerRefNumber - 1)))?null:(System.String)reader[((int)InvoiceSummaryColumn.BpayCustomerRefNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.InvoiceSummary"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceSummary"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.InvoiceSummary entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = (System.DateTime)dataRow["EndDate"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.PriCustomerNumber = (System.String)dataRow["PriCustomerNumber"];
			entity.InvoiceNumber = (System.String)dataRow["InvoiceNumber"];
			entity.AmountOfLastBill = Convert.IsDBNull(dataRow["AmountOfLastBill"]) ? null : (System.Decimal?)dataRow["AmountOfLastBill"];
			entity.Payment1 = Convert.IsDBNull(dataRow["Payment1"]) ? null : (System.Decimal?)dataRow["Payment1"];
			entity.TotalCredits = Convert.IsDBNull(dataRow["TotalCredits"]) ? null : (System.Decimal?)dataRow["TotalCredits"];
			entity.TotalLatePaymentCharges = Convert.IsDBNull(dataRow["TotalLatePaymentCharges"]) ? null : (System.Decimal?)dataRow["TotalLatePaymentCharges"];
			entity.BalForward = Convert.IsDBNull(dataRow["BalForward"]) ? null : (System.Decimal?)dataRow["BalForward"];
			entity.ProductCharges = Convert.IsDBNull(dataRow["ProductCharges"]) ? null : (System.Decimal?)dataRow["ProductCharges"];
			entity.MiscCharges = Convert.IsDBNull(dataRow["MiscCharges"]) ? null : (System.Decimal?)dataRow["MiscCharges"];
			entity.LocalTaxAmount = Convert.IsDBNull(dataRow["LocalTaxAmount"]) ? null : (System.Decimal?)dataRow["LocalTaxAmount"];
			entity.FederalTaxAmount = Convert.IsDBNull(dataRow["FederalTaxAmount"]) ? null : (System.Decimal?)dataRow["FederalTaxAmount"];
			entity.TotalCurrent = Convert.IsDBNull(dataRow["TotalCurrent"]) ? null : (System.Decimal?)dataRow["TotalCurrent"];
			entity.BalanceForward = Convert.IsDBNull(dataRow["BalanceForward"]) ? null : (System.Decimal?)dataRow["BalanceForward"];
			entity.InvoiceDate = (System.DateTime)dataRow["InvoiceDate"];
			entity.DueDate = (System.DateTime)dataRow["DueDate"];
			entity.CurrencyId = (System.String)dataRow["CurrencyID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.TotalFreeCredits = Convert.IsDBNull(dataRow["TotalFreeCredits"]) ? null : (System.Decimal?)dataRow["TotalFreeCredits"];
			entity.Wholesaler_ProductId = Convert.IsDBNull(dataRow["Wholesaler_ProductID"]) ? null : (System.Int32?)dataRow["Wholesaler_ProductID"];
			entity.BpayCustomerRefNumber = Convert.IsDBNull(dataRow["BPayCustomerRefNumber"]) ? null : (System.String)dataRow["BPayCustomerRefNumber"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceSummary"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.InvoiceSummary Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.InvoiceSummary entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.InvoiceSummary object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.InvoiceSummary instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.InvoiceSummary Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.InvoiceSummary entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region InvoiceSummaryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.InvoiceSummary</c>
	///</summary>
	public enum InvoiceSummaryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
		}
	
	#endregion InvoiceSummaryChildEntityTypes
	
	#region InvoiceSummaryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InvoiceSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryFilterBuilder : SqlFilterBuilder<InvoiceSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilterBuilder class.
		/// </summary>
		public InvoiceSummaryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceSummaryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceSummaryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceSummaryFilterBuilder
	
	#region InvoiceSummaryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InvoiceSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceSummaryParameterBuilder : ParameterizedSqlFilterBuilder<InvoiceSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryParameterBuilder class.
		/// </summary>
		public InvoiceSummaryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceSummaryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceSummaryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceSummaryParameterBuilder
} // end namespace
