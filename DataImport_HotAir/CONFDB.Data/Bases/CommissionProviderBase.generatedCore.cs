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
	/// This class is the base class for any <see cref="CommissionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CommissionProviderBaseCore : EntityProviderBase<CONFDB.Entities.Commission, CONFDB.Entities.CommissionKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CommissionKey key)
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
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		Currency_Commission_FK Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCurrencyId(System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		Currency_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Commission> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		Currency_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		currency_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCurrencyId(System.String _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		currency_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCurrencyId(System.String _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Commission_FK key.
		///		Currency_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public abstract CONFDB.Entities.TList<Commission> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		SalesPerson_Commission_FK Description: 
		/// </summary>
		/// <param name="_salesPersonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(_salesPersonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		SalesPerson_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Commission> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		SalesPerson_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		salesPerson_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		salesPerson_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength,out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_Commission_FK key.
		///		SalesPerson_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public abstract CONFDB.Entities.TList<Commission> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		Wholesaler_Commission_FK Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		Wholesaler_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Commission> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		Wholesaler_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		wholesaler_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		wholesaler_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Commission_FK key.
		///		Wholesaler_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public abstract CONFDB.Entities.TList<Commission> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		Customer_Commission_FK Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		Customer_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Commission> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		Customer_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		customer_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		customer_Commission_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public CONFDB.Entities.TList<Commission> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_Commission_FK key.
		///		Customer_Commission_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Commission objects.</returns>
		public abstract CONFDB.Entities.TList<Commission> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Commission Get(TransactionManager transactionManager, CONFDB.Entities.CommissionKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Commission_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public CONFDB.Entities.Commission GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Commission_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public CONFDB.Entities.Commission GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Commission_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public CONFDB.Entities.Commission GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Commission_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public CONFDB.Entities.Commission GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Commission_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public CONFDB.Entities.Commission GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Commission_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Commission"/> class.</returns>
		public abstract CONFDB.Entities.Commission GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_Commission_GetCommissionReport 
		
		/// <summary>
		///	This method wrap the 'p_Commission_GetCommissionReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCommissionReport(System.String wholesalerId, System.Int32? salesPersonId, System.DateTime? invoiceDate)
		{
			return GetCommissionReport(null, 0, int.MaxValue , wholesalerId, salesPersonId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Commission_GetCommissionReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCommissionReport(int start, int pageLength, System.String wholesalerId, System.Int32? salesPersonId, System.DateTime? invoiceDate)
		{
			return GetCommissionReport(null, start, pageLength , wholesalerId, salesPersonId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_Commission_GetCommissionReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCommissionReport(TransactionManager transactionManager, System.String wholesalerId, System.Int32? salesPersonId, System.DateTime? invoiceDate)
		{
			return GetCommissionReport(transactionManager, 0, int.MaxValue , wholesalerId, salesPersonId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Commission_GetCommissionReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCommissionReport(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? salesPersonId, System.DateTime? invoiceDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Commission&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Commission&gt;"/></returns>
		public static CONFDB.Entities.TList<Commission> Fill(IDataReader reader, CONFDB.Entities.TList<Commission> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Commission c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Commission")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CommissionColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CommissionColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Commission>(
					key.ToString(), // EntityTrackingKey
					"Commission",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Commission();
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
					c.Id = (System.Int32)reader[((int)CommissionColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)CommissionColumn.WholesalerId - 1)];
					c.CustomerId = (System.Int32)reader[((int)CommissionColumn.CustomerId - 1)];
					c.SalesPersonId = (System.Int32)reader[((int)CommissionColumn.SalesPersonId - 1)];
					c.BilledDate = (reader.IsDBNull(((int)CommissionColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)CommissionColumn.BilledDate - 1)];
					c.TotalCredits = (reader.IsDBNull(((int)CommissionColumn.TotalCredits - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalCredits - 1)];
					c.ProductCharges = (reader.IsDBNull(((int)CommissionColumn.ProductCharges - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.ProductCharges - 1)];
					c.MiscCharges = (reader.IsDBNull(((int)CommissionColumn.MiscCharges - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.MiscCharges - 1)];
					c.TotalAmount = (reader.IsDBNull(((int)CommissionColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalAmount - 1)];
					c.CommissionRate = (reader.IsDBNull(((int)CommissionColumn.CommissionRate - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.CommissionRate - 1)];
					c.TotalCommission = (reader.IsDBNull(((int)CommissionColumn.TotalCommission - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalCommission - 1)];
					c.CurrencyId = (System.String)reader[((int)CommissionColumn.CurrencyId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Commission"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Commission"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Commission entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CommissionColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)CommissionColumn.WholesalerId - 1)];
			entity.CustomerId = (System.Int32)reader[((int)CommissionColumn.CustomerId - 1)];
			entity.SalesPersonId = (System.Int32)reader[((int)CommissionColumn.SalesPersonId - 1)];
			entity.BilledDate = (reader.IsDBNull(((int)CommissionColumn.BilledDate - 1)))?null:(System.DateTime?)reader[((int)CommissionColumn.BilledDate - 1)];
			entity.TotalCredits = (reader.IsDBNull(((int)CommissionColumn.TotalCredits - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalCredits - 1)];
			entity.ProductCharges = (reader.IsDBNull(((int)CommissionColumn.ProductCharges - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.ProductCharges - 1)];
			entity.MiscCharges = (reader.IsDBNull(((int)CommissionColumn.MiscCharges - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.MiscCharges - 1)];
			entity.TotalAmount = (reader.IsDBNull(((int)CommissionColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalAmount - 1)];
			entity.CommissionRate = (reader.IsDBNull(((int)CommissionColumn.CommissionRate - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.CommissionRate - 1)];
			entity.TotalCommission = (reader.IsDBNull(((int)CommissionColumn.TotalCommission - 1)))?null:(System.Decimal?)reader[((int)CommissionColumn.TotalCommission - 1)];
			entity.CurrencyId = (System.String)reader[((int)CommissionColumn.CurrencyId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Commission"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Commission"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Commission entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.BilledDate = Convert.IsDBNull(dataRow["BilledDate"]) ? null : (System.DateTime?)dataRow["BilledDate"];
			entity.TotalCredits = Convert.IsDBNull(dataRow["TotalCredits"]) ? null : (System.Decimal?)dataRow["TotalCredits"];
			entity.ProductCharges = Convert.IsDBNull(dataRow["ProductCharges"]) ? null : (System.Decimal?)dataRow["ProductCharges"];
			entity.MiscCharges = Convert.IsDBNull(dataRow["MiscCharges"]) ? null : (System.Decimal?)dataRow["MiscCharges"];
			entity.TotalAmount = Convert.IsDBNull(dataRow["TotalAmount"]) ? null : (System.Decimal?)dataRow["TotalAmount"];
			entity.CommissionRate = Convert.IsDBNull(dataRow["CommissionRate"]) ? null : (System.Decimal?)dataRow["CommissionRate"];
			entity.TotalCommission = Convert.IsDBNull(dataRow["TotalCommission"]) ? null : (System.Decimal?)dataRow["TotalCommission"];
			entity.CurrencyId = (System.String)dataRow["CurrencyID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Commission"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Commission Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Commission entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CurrencyIdSource	
			if (CanDeepLoad(entity, "Currency|CurrencyIdSource", deepLoadType, innerList) 
				&& entity.CurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CurrencyId;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyIdSource = tmpEntity;
				else
					entity.CurrencyIdSource = DataRepository.CurrencyProvider.GetById(transactionManager, entity.CurrencyId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.CurrencyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurrencyIdSource

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesPersonId;
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetById(transactionManager, entity.SalesPersonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource

			#region WholesalerIdSource	
			if (CanDeepLoad(entity, "Wholesaler|WholesalerIdSource", deepLoadType, innerList) 
				&& entity.WholesalerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.WholesalerId;
				Wholesaler tmpEntity = EntityManager.LocateEntity<Wholesaler>(EntityLocator.ConstructKeyFromPkItems(typeof(Wholesaler), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WholesalerIdSource = tmpEntity;
				else
					entity.WholesalerIdSource = DataRepository.WholesalerProvider.GetById(transactionManager, entity.WholesalerId);		
				
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Commission object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Commission instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Commission Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Commission entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CurrencyIdSource
			if (CanDeepSave(entity, "Currency|CurrencyIdSource", deepSaveType, innerList) 
				&& entity.CurrencyIdSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.CurrencyIdSource);
				entity.CurrencyId = entity.CurrencyIdSource.Id;
			}
			#endregion 
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.Id;
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
	
	#region CommissionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Commission</c>
	///</summary>
	public enum CommissionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currency</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
			
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
		}
	
	#endregion CommissionChildEntityTypes
	
	#region CommissionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CommissionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionFilterBuilder : SqlFilterBuilder<CommissionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionFilterBuilder class.
		/// </summary>
		public CommissionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionFilterBuilder
	
	#region CommissionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CommissionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Commission"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommissionParameterBuilder : ParameterizedSqlFilterBuilder<CommissionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommissionParameterBuilder class.
		/// </summary>
		public CommissionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommissionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommissionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommissionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommissionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommissionParameterBuilder
} // end namespace
