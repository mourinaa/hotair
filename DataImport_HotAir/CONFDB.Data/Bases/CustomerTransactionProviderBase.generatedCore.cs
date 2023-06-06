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
	/// This class is the base class for any <see cref="CustomerTransactionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerTransactionProviderBaseCore : EntityProviderBase<CONFDB.Entities.CustomerTransaction, CONFDB.Entities.CustomerTransactionKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _id)
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
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		CustomerTransactionType_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="_customerTransactionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(System.Int32 _customerTransactionTypeId)
		{
			int count = -1;
			return GetByCustomerTransactionTypeId(_customerTransactionTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		CustomerTransactionType_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTransactionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(TransactionManager transactionManager, System.Int32 _customerTransactionTypeId)
		{
			int count = -1;
			return GetByCustomerTransactionTypeId(transactionManager, _customerTransactionTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		CustomerTransactionType_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTransactionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(TransactionManager transactionManager, System.Int32 _customerTransactionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTransactionTypeId(transactionManager, _customerTransactionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		customerTransactionType_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerTransactionTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(System.Int32 _customerTransactionTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerTransactionTypeId(null, _customerTransactionTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		customerTransactionType_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerTransactionTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(System.Int32 _customerTransactionTypeId, int start, int pageLength,out int count)
		{
			return GetByCustomerTransactionTypeId(null, _customerTransactionTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_CustomerTransactions_FK1 key.
		///		CustomerTransactionType_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTransactionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByCustomerTransactionTypeId(TransactionManager transactionManager, System.Int32 _customerTransactionTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		FK_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(System.Int32? _productRateId)
		{
			int count = -1;
			return GetByProductRateId(_productRateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		FK_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(TransactionManager transactionManager, System.Int32? _productRateId)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		FK_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(TransactionManager transactionManager, System.Int32? _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		fk_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(System.Int32? _productRateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductRateId(null, _productRateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		fk_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(System.Int32? _productRateId, int start, int pageLength,out int count)
		{
			return GetByProductRateId(null, _productRateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_ProductRate key.
		///		FK_CustomerTransaction_ProductRate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId">Optional: Used to type transactions very specifically to a Product Rate. Gives more gandular reporting.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByProductRateId(TransactionManager transactionManager, System.Int32? _productRateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		FK_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(System.Int32? _wholesaler_ProductId)
		{
			int count = -1;
			return GetByWholesaler_ProductId(_wholesaler_ProductId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		FK_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(TransactionManager transactionManager, System.Int32? _wholesaler_ProductId)
		{
			int count = -1;
			return GetByWholesaler_ProductId(transactionManager, _wholesaler_ProductId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		FK_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(TransactionManager transactionManager, System.Int32? _wholesaler_ProductId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesaler_ProductId(transactionManager, _wholesaler_ProductId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		fk_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(System.Int32? _wholesaler_ProductId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesaler_ProductId(null, _wholesaler_ProductId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		fk_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(System.Int32? _wholesaler_ProductId, int start, int pageLength,out int count)
		{
			return GetByWholesaler_ProductId(null, _wholesaler_ProductId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransaction_Wholesaler_Product key.
		///		FK_CustomerTransaction_Wholesaler_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesaler_ProductId">Optional: But should be specified for Charges. Used to link transactions to a specific Product for reporting purpose, or can be used to select specific ProductRateID's for miscellaneous charges and the quantity.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByWholesaler_ProductId(TransactionManager transactionManager, System.Int32? _wholesaler_ProductId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		Wholesaler_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		Wholesaler_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		Wholesaler_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		wholesaler_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		wholesaler_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerTransactions_FK1 key.
		///		Wholesaler_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		Customer_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		Customer_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		Customer_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		customer_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		customer_CustomerTransactions_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerTransactions_FK1 key.
		///		Customer_CustomerTransactions_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransaction objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CustomerTransaction Get(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerTransaction_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public CONFDB.Entities.CustomerTransaction GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransaction_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public CONFDB.Entities.CustomerTransaction GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransaction_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public CONFDB.Entities.CustomerTransaction GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransaction_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public CONFDB.Entities.CustomerTransaction GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransaction_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public CONFDB.Entities.CustomerTransaction GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransaction_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransaction"/> class.</returns>
		public abstract CONFDB.Entities.CustomerTransaction GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(System.Int32 _customerId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByCustomerIdWholesalerId(null,_customerId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(System.Int32 _customerId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdWholesalerId(null, _customerId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(TransactionManager transactionManager, System.Int32 _customerId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByCustomerIdWholesalerId(transactionManager, _customerId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(TransactionManager transactionManager, System.Int32 _customerId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdWholesalerId(transactionManager, _customerId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(System.Int32 _customerId, System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByCustomerIdWholesalerId(null, _customerId, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByCustomerIdWholesalerId(TransactionManager transactionManager, System.Int32 _customerId, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(null,_priCustomerNumber, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(null, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(transactionManager, _priCustomerNumber, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumberWholesalerId(transactionManager, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByPriCustomerNumberWholesalerId(null, _priCustomerNumber, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByPriCustomerNumberWholesalerId(TransactionManager transactionManager, System.String _priCustomerNumber, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="_transactionDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(System.DateTime _transactionDate)
		{
			int count = -1;
			return GetByTransactionDate(null,_transactionDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="_transactionDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(System.DateTime _transactionDate, int start, int pageLength)
		{
			int count = -1;
			return GetByTransactionDate(null, _transactionDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(TransactionManager transactionManager, System.DateTime _transactionDate)
		{
			int count = -1;
			return GetByTransactionDate(transactionManager, _transactionDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(TransactionManager transactionManager, System.DateTime _transactionDate, int start, int pageLength)
		{
			int count = -1;
			return GetByTransactionDate(transactionManager, _transactionDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="_transactionDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(System.DateTime _transactionDate, int start, int pageLength, out int count)
		{
			return GetByTransactionDate(null, _transactionDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactions_TransactionDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_transactionDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransaction> GetByTransactionDate(TransactionManager transactionManager, System.DateTime _transactionDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_CustomerTransaction_DeleteTransaction 
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_DeleteTransaction' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int64?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteTransaction(System.Int64? id)
		{
			 DeleteTransaction(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_DeleteTransaction' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int64?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteTransaction(int start, int pageLength, System.Int64? id)
		{
			 DeleteTransaction(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_DeleteTransaction' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int64?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteTransaction(TransactionManager transactionManager, System.Int64? id)
		{
			 DeleteTransaction(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_DeleteTransaction' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int64?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteTransaction(TransactionManager transactionManager, int start, int pageLength , System.Int64? id);
		
		#endregion
		
		#region p_CustomerTransaction_GetByCustomer 
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_GetByCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomer(System.Int32? customerId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetByCustomer(null, 0, int.MaxValue , customerId, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_GetByCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomer(int start, int pageLength, System.Int32? customerId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetByCustomer(null, start, pageLength , customerId, startDate, endDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_GetByCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomer(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetByCustomer(transactionManager, 0, int.MaxValue , customerId, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransaction_GetByCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCustomer(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? startDate, System.DateTime? endDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CustomerTransaction&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CustomerTransaction&gt;"/></returns>
		public static CONFDB.Entities.TList<CustomerTransaction> Fill(IDataReader reader, CONFDB.Entities.TList<CustomerTransaction> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CustomerTransaction c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerTransaction")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerTransactionColumn.Id - 1))?(long)0:(System.Int64)reader[((int)CONFDB.Entities.CustomerTransactionColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CustomerTransaction>(
					key.ToString(), // EntityTrackingKey
					"CustomerTransaction",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CustomerTransaction();
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
					c.Id = (System.Int64)reader[((int)CustomerTransactionColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)CustomerTransactionColumn.WholesalerId - 1)];
					c.CustomerId = (System.Int32)reader[((int)CustomerTransactionColumn.CustomerId - 1)];
					c.ModeratorId = (reader.IsDBNull(((int)CustomerTransactionColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ModeratorId - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.SecCustomerNumber - 1)];
					c.CustomerTransactionTypeId = (System.Int32)reader[((int)CustomerTransactionColumn.CustomerTransactionTypeId - 1)];
					c.TransactionDescription = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionDescription - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.TransactionDescription - 1)];
					c.TransactionDate = (System.DateTime)reader[((int)CustomerTransactionColumn.TransactionDate - 1)];
					c.TransactionAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.TransactionAmount - 1)];
					c.LocalTaxRate = (reader.IsDBNull(((int)CustomerTransactionColumn.LocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.LocalTaxRate - 1)];
					c.FederalTaxRate = (reader.IsDBNull(((int)CustomerTransactionColumn.FederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.FederalTaxRate - 1)];
					c.LocalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.LocalTaxAmount - 1)];
					c.FederalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.FederalTaxAmount - 1)];
					c.TransactionTotal = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionTotal - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.TransactionTotal - 1)];
					c.CustomerBalance = (reader.IsDBNull(((int)CustomerTransactionColumn.CustomerBalance - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.CustomerBalance - 1)];
					c.Wholesaler_ProductId = (reader.IsDBNull(((int)CustomerTransactionColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.Wholesaler_ProductId - 1)];
					c.ProductRateId = (reader.IsDBNull(((int)CustomerTransactionColumn.ProductRateId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ProductRateId - 1)];
					c.Quantity = (reader.IsDBNull(((int)CustomerTransactionColumn.Quantity - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.Quantity - 1)];
					c.SellRate = (reader.IsDBNull(((int)CustomerTransactionColumn.SellRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.SellRate - 1)];
					c.BuyRate = (reader.IsDBNull(((int)CustomerTransactionColumn.BuyRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.BuyRate - 1)];
					c.WsTransactionAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.WsTransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.WsTransactionAmount - 1)];
					c.ReferenceNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.ReferenceNumber - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)CustomerTransactionColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.UniqueConferenceId - 1)];
					c.PostedDate = (System.DateTime)reader[((int)CustomerTransactionColumn.PostedDate - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)CustomerTransactionColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.ModifiedBy - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CustomerTransactionColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionColumn.CreatedDate - 1)];
					c.PostedToInvoice = (reader.IsDBNull(((int)CustomerTransactionColumn.PostedToInvoice - 1)))?null:(System.Boolean?)reader[((int)CustomerTransactionColumn.PostedToInvoice - 1)];
					c.PostedToInvoiceDate = (reader.IsDBNull(((int)CustomerTransactionColumn.PostedToInvoiceDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionColumn.PostedToInvoiceDate - 1)];
					c.ElapsedTimeSeconds = (reader.IsDBNull(((int)CustomerTransactionColumn.ElapsedTimeSeconds - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ElapsedTimeSeconds - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransaction"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransaction"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CustomerTransaction entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)CustomerTransactionColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)CustomerTransactionColumn.WholesalerId - 1)];
			entity.CustomerId = (System.Int32)reader[((int)CustomerTransactionColumn.CustomerId - 1)];
			entity.ModeratorId = (reader.IsDBNull(((int)CustomerTransactionColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ModeratorId - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.SecCustomerNumber - 1)];
			entity.CustomerTransactionTypeId = (System.Int32)reader[((int)CustomerTransactionColumn.CustomerTransactionTypeId - 1)];
			entity.TransactionDescription = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionDescription - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.TransactionDescription - 1)];
			entity.TransactionDate = (System.DateTime)reader[((int)CustomerTransactionColumn.TransactionDate - 1)];
			entity.TransactionAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.TransactionAmount - 1)];
			entity.LocalTaxRate = (reader.IsDBNull(((int)CustomerTransactionColumn.LocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.LocalTaxRate - 1)];
			entity.FederalTaxRate = (reader.IsDBNull(((int)CustomerTransactionColumn.FederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.FederalTaxRate - 1)];
			entity.LocalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.LocalTaxAmount - 1)];
			entity.FederalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.FederalTaxAmount - 1)];
			entity.TransactionTotal = (reader.IsDBNull(((int)CustomerTransactionColumn.TransactionTotal - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.TransactionTotal - 1)];
			entity.CustomerBalance = (reader.IsDBNull(((int)CustomerTransactionColumn.CustomerBalance - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.CustomerBalance - 1)];
			entity.Wholesaler_ProductId = (reader.IsDBNull(((int)CustomerTransactionColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.Wholesaler_ProductId - 1)];
			entity.ProductRateId = (reader.IsDBNull(((int)CustomerTransactionColumn.ProductRateId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ProductRateId - 1)];
			entity.Quantity = (reader.IsDBNull(((int)CustomerTransactionColumn.Quantity - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.Quantity - 1)];
			entity.SellRate = (reader.IsDBNull(((int)CustomerTransactionColumn.SellRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.SellRate - 1)];
			entity.BuyRate = (reader.IsDBNull(((int)CustomerTransactionColumn.BuyRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.BuyRate - 1)];
			entity.WsTransactionAmount = (reader.IsDBNull(((int)CustomerTransactionColumn.WsTransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionColumn.WsTransactionAmount - 1)];
			entity.ReferenceNumber = (reader.IsDBNull(((int)CustomerTransactionColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.ReferenceNumber - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)CustomerTransactionColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.UniqueConferenceId - 1)];
			entity.PostedDate = (System.DateTime)reader[((int)CustomerTransactionColumn.PostedDate - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)CustomerTransactionColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerTransactionColumn.ModifiedBy - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CustomerTransactionColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionColumn.CreatedDate - 1)];
			entity.PostedToInvoice = (reader.IsDBNull(((int)CustomerTransactionColumn.PostedToInvoice - 1)))?null:(System.Boolean?)reader[((int)CustomerTransactionColumn.PostedToInvoice - 1)];
			entity.PostedToInvoiceDate = (reader.IsDBNull(((int)CustomerTransactionColumn.PostedToInvoiceDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionColumn.PostedToInvoiceDate - 1)];
			entity.ElapsedTimeSeconds = (reader.IsDBNull(((int)CustomerTransactionColumn.ElapsedTimeSeconds - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionColumn.ElapsedTimeSeconds - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransaction"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransaction"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CustomerTransaction entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.ModeratorId = Convert.IsDBNull(dataRow["ModeratorID"]) ? null : (System.Int32?)dataRow["ModeratorID"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = Convert.IsDBNull(dataRow["SecCustomerNumber"]) ? null : (System.String)dataRow["SecCustomerNumber"];
			entity.CustomerTransactionTypeId = (System.Int32)dataRow["CustomerTransactionTypeID"];
			entity.TransactionDescription = Convert.IsDBNull(dataRow["TransactionDescription"]) ? null : (System.String)dataRow["TransactionDescription"];
			entity.TransactionDate = (System.DateTime)dataRow["TransactionDate"];
			entity.TransactionAmount = Convert.IsDBNull(dataRow["TransactionAmount"]) ? null : (System.Decimal?)dataRow["TransactionAmount"];
			entity.LocalTaxRate = Convert.IsDBNull(dataRow["LocalTaxRate"]) ? null : (System.Decimal?)dataRow["LocalTaxRate"];
			entity.FederalTaxRate = Convert.IsDBNull(dataRow["FederalTaxRate"]) ? null : (System.Decimal?)dataRow["FederalTaxRate"];
			entity.LocalTaxAmount = Convert.IsDBNull(dataRow["LocalTaxAmount"]) ? null : (System.Decimal?)dataRow["LocalTaxAmount"];
			entity.FederalTaxAmount = Convert.IsDBNull(dataRow["FederalTaxAmount"]) ? null : (System.Decimal?)dataRow["FederalTaxAmount"];
			entity.TransactionTotal = Convert.IsDBNull(dataRow["TransactionTotal"]) ? null : (System.Decimal?)dataRow["TransactionTotal"];
			entity.CustomerBalance = Convert.IsDBNull(dataRow["CustomerBalance"]) ? null : (System.Decimal?)dataRow["CustomerBalance"];
			entity.Wholesaler_ProductId = Convert.IsDBNull(dataRow["Wholesaler_ProductID"]) ? null : (System.Int32?)dataRow["Wholesaler_ProductID"];
			entity.ProductRateId = Convert.IsDBNull(dataRow["ProductRateID"]) ? null : (System.Int32?)dataRow["ProductRateID"];
			entity.Quantity = Convert.IsDBNull(dataRow["Quantity"]) ? null : (System.Int32?)dataRow["Quantity"];
			entity.SellRate = Convert.IsDBNull(dataRow["SellRate"]) ? null : (System.Decimal?)dataRow["SellRate"];
			entity.BuyRate = Convert.IsDBNull(dataRow["BuyRate"]) ? null : (System.Decimal?)dataRow["BuyRate"];
			entity.WsTransactionAmount = Convert.IsDBNull(dataRow["WSTransactionAmount"]) ? null : (System.Decimal?)dataRow["WSTransactionAmount"];
			entity.ReferenceNumber = Convert.IsDBNull(dataRow["ReferenceNumber"]) ? null : (System.String)dataRow["ReferenceNumber"];
			entity.UniqueConferenceId = Convert.IsDBNull(dataRow["UniqueConferenceID"]) ? null : (System.String)dataRow["UniqueConferenceID"];
			entity.PostedDate = (System.DateTime)dataRow["PostedDate"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.PostedToInvoice = Convert.IsDBNull(dataRow["PostedToInvoice"]) ? null : (System.Boolean?)dataRow["PostedToInvoice"];
			entity.PostedToInvoiceDate = Convert.IsDBNull(dataRow["PostedToInvoiceDate"]) ? null : (System.DateTime?)dataRow["PostedToInvoiceDate"];
			entity.ElapsedTimeSeconds = Convert.IsDBNull(dataRow["ElapsedTimeSeconds"]) ? null : (System.Int32?)dataRow["ElapsedTimeSeconds"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransaction"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransaction Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CustomerTransaction entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomerTransactionTypeIdSource	
			if (CanDeepLoad(entity, "CustomerTransactionType|CustomerTransactionTypeIdSource", deepLoadType, innerList) 
				&& entity.CustomerTransactionTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerTransactionTypeId;
				CustomerTransactionType tmpEntity = EntityManager.LocateEntity<CustomerTransactionType>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomerTransactionType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerTransactionTypeIdSource = tmpEntity;
				else
					entity.CustomerTransactionTypeIdSource = DataRepository.CustomerTransactionTypeProvider.GetById(transactionManager, entity.CustomerTransactionTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTransactionTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerTransactionTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerTransactionTypeProvider.DeepLoad(transactionManager, entity.CustomerTransactionTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerTransactionTypeIdSource

			#region ProductRateIdSource	
			if (CanDeepLoad(entity, "ProductRate|ProductRateIdSource", deepLoadType, innerList) 
				&& entity.ProductRateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProductRateId ?? (int)0);
				ProductRate tmpEntity = EntityManager.LocateEntity<ProductRate>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductRate), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductRateIdSource = tmpEntity;
				else
					entity.ProductRateIdSource = DataRepository.ProductRateProvider.GetById(transactionManager, (entity.ProductRateId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductRateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductRateProvider.DeepLoad(transactionManager, entity.ProductRateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductRateIdSource

			#region Wholesaler_ProductIdSource	
			if (CanDeepLoad(entity, "Wholesaler_Product|Wholesaler_ProductIdSource", deepLoadType, innerList) 
				&& entity.Wholesaler_ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Wholesaler_ProductId ?? (int)0);
				Wholesaler_Product tmpEntity = EntityManager.LocateEntity<Wholesaler_Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Wholesaler_Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Wholesaler_ProductIdSource = tmpEntity;
				else
					entity.Wholesaler_ProductIdSource = DataRepository.Wholesaler_ProductProvider.GetById(transactionManager, (entity.Wholesaler_ProductId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Wholesaler_ProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Wholesaler_ProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.Wholesaler_ProductProvider.DeepLoad(transactionManager, entity.Wholesaler_ProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Wholesaler_ProductIdSource

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
		/// Deep Save the entire object graph of the CONFDB.Entities.CustomerTransaction object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CustomerTransaction instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransaction Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CustomerTransaction entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerTransactionTypeIdSource
			if (CanDeepSave(entity, "CustomerTransactionType|CustomerTransactionTypeIdSource", deepSaveType, innerList) 
				&& entity.CustomerTransactionTypeIdSource != null)
			{
				DataRepository.CustomerTransactionTypeProvider.Save(transactionManager, entity.CustomerTransactionTypeIdSource);
				entity.CustomerTransactionTypeId = entity.CustomerTransactionTypeIdSource.Id;
			}
			#endregion 
			
			#region ProductRateIdSource
			if (CanDeepSave(entity, "ProductRate|ProductRateIdSource", deepSaveType, innerList) 
				&& entity.ProductRateIdSource != null)
			{
				DataRepository.ProductRateProvider.Save(transactionManager, entity.ProductRateIdSource);
				entity.ProductRateId = entity.ProductRateIdSource.Id;
			}
			#endregion 
			
			#region Wholesaler_ProductIdSource
			if (CanDeepSave(entity, "Wholesaler_Product|Wholesaler_ProductIdSource", deepSaveType, innerList) 
				&& entity.Wholesaler_ProductIdSource != null)
			{
				DataRepository.Wholesaler_ProductProvider.Save(transactionManager, entity.Wholesaler_ProductIdSource);
				entity.Wholesaler_ProductId = entity.Wholesaler_ProductIdSource.Id;
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
	
	#region CustomerTransactionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CustomerTransaction</c>
	///</summary>
	public enum CustomerTransactionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CustomerTransactionType</c> at CustomerTransactionTypeIdSource
		///</summary>
		[ChildEntityType(typeof(CustomerTransactionType))]
		CustomerTransactionType,
			
		///<summary>
		/// Composite Property for <c>ProductRate</c> at ProductRateIdSource
		///</summary>
		[ChildEntityType(typeof(ProductRate))]
		ProductRate,
			
		///<summary>
		/// Composite Property for <c>Wholesaler_Product</c> at Wholesaler_ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler_Product))]
		Wholesaler_Product,
			
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
	
	#endregion CustomerTransactionChildEntityTypes
	
	#region CustomerTransactionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerTransactionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransaction"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionFilterBuilder : SqlFilterBuilder<CustomerTransactionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilterBuilder class.
		/// </summary>
		public CustomerTransactionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionFilterBuilder
	
	#region CustomerTransactionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerTransactionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransaction"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionParameterBuilder : ParameterizedSqlFilterBuilder<CustomerTransactionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionParameterBuilder class.
		/// </summary>
		public CustomerTransactionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionParameterBuilder
} // end namespace
