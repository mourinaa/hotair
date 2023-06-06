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
	/// This class is the base class for any <see cref="ProductRateValueProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductRateValueProviderBaseCore : EntityProviderBase<CONFDB.Entities.ProductRateValue, CONFDB.Entities.ProductRateValueKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ProductRateValueKey key)
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
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		Customer_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		Customer_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		Customer_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		customer_ProductRateValue_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(System.Int32? _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		customer_ProductRateValue_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(System.Int32? _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_ProductRateValue_FK1 key.
		///		Customer_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		FK_ProductRateValue_BuyRateCurrencyID Description: 
		/// </summary>
		/// <param name="_buyRateCurrencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(System.String _buyRateCurrencyId)
		{
			int count = -1;
			return GetByBuyRateCurrencyId(_buyRateCurrencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		FK_ProductRateValue_BuyRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_buyRateCurrencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(TransactionManager transactionManager, System.String _buyRateCurrencyId)
		{
			int count = -1;
			return GetByBuyRateCurrencyId(transactionManager, _buyRateCurrencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		FK_ProductRateValue_BuyRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_buyRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(TransactionManager transactionManager, System.String _buyRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByBuyRateCurrencyId(transactionManager, _buyRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		fk_ProductRateValue_BuyRateCurrencyId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_buyRateCurrencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(System.String _buyRateCurrencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBuyRateCurrencyId(null, _buyRateCurrencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		fk_ProductRateValue_BuyRateCurrencyId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_buyRateCurrencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(System.String _buyRateCurrencyId, int start, int pageLength,out int count)
		{
			return GetByBuyRateCurrencyId(null, _buyRateCurrencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_BuyRateCurrencyID key.
		///		FK_ProductRateValue_BuyRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_buyRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByBuyRateCurrencyId(TransactionManager transactionManager, System.String _buyRateCurrencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		FK_ProductRateValue_SellRateCurrencyID Description: 
		/// </summary>
		/// <param name="_sellRateCurrencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetBySellRateCurrencyId(_sellRateCurrencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		FK_ProductRateValue_SellRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(TransactionManager transactionManager, System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetBySellRateCurrencyId(transactionManager, _sellRateCurrencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		FK_ProductRateValue_SellRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(TransactionManager transactionManager, System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetBySellRateCurrencyId(transactionManager, _sellRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		fk_ProductRateValue_SellRateCurrencyId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySellRateCurrencyId(null, _sellRateCurrencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		fk_ProductRateValue_SellRateCurrencyId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(System.String _sellRateCurrencyId, int start, int pageLength,out int count)
		{
			return GetBySellRateCurrencyId(null, _sellRateCurrencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRateValue_SellRateCurrencyID key.
		///		FK_ProductRateValue_SellRateCurrencyID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetBySellRateCurrencyId(TransactionManager transactionManager, System.String _sellRateCurrencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		ProductRate_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(System.Int32 _productRateId)
		{
			int count = -1;
			return GetByProductRateId(_productRateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		ProductRate_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		ProductRate_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		productRate_ProductRateValue_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(System.Int32 _productRateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductRateId(null, _productRateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		productRate_ProductRateValue_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(System.Int32 _productRateId, int start, int pageLength,out int count)
		{
			return GetByProductRateId(null, _productRateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_ProductRateValue_FK1 key.
		///		ProductRate_ProductRateValue_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRateValue objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.ProductRateValue Get(TransactionManager transactionManager, CONFDB.Entities.ProductRateValueKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ProductRateValue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public abstract CONFDB.Entities.ProductRateValue GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(System.Int32? _customerId, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByCustomerIdProductRateId(null,_customerId, _productRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(System.Int32? _customerId, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdProductRateId(null, _customerId, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(TransactionManager transactionManager, System.Int32? _customerId, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByCustomerIdProductRateId(transactionManager, _customerId, _productRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(TransactionManager transactionManager, System.Int32? _customerId, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdProductRateId(transactionManager, _customerId, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(System.Int32? _customerId, System.Int32 _productRateId, int start, int pageLength, out int count)
		{
			return GetByCustomerIdProductRateId(null, _customerId, _productRateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_CustomerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByCustomerIdProductRateId(TransactionManager transactionManager, System.Int32? _customerId, System.Int32 _productRateId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(System.Int32 _productRateId, System.Byte _defaultOption)
		{
			int count = -1;
			return GetByProductRateIdDefaultOption(null,_productRateId, _defaultOption, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(System.Int32 _productRateId, System.Byte _defaultOption, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateIdDefaultOption(null, _productRateId, _defaultOption, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption)
		{
			int count = -1;
			return GetByProductRateIdDefaultOption(transactionManager, _productRateId, _defaultOption, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateIdDefaultOption(transactionManager, _productRateId, _defaultOption, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(System.Int32 _productRateId, System.Byte _defaultOption, int start, int pageLength, out int count)
		{
			return GetByProductRateIdDefaultOption(null, _productRateId, _defaultOption, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_ProductRateID_DefaultOption index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByProductRateIdDefaultOption(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(null,_wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRateValue_WholesalerID_ProductRateID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetByIdProductRateIdSellRateSellRateCurrencyId(null,_id, _productRateId, _sellRate, _sellRateCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdProductRateIdSellRateSellRateCurrencyId(null, _id, _productRateId, _sellRate, _sellRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetByIdProductRateIdSellRateSellRateCurrencyId(transactionManager, _id, _productRateId, _sellRate, _sellRateCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdProductRateIdSellRateSellRateCurrencyId(transactionManager, _id, _productRateId, _sellRate, _sellRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId, int start, int pageLength, out int count)
		{
			return GetByIdProductRateIdSellRateSellRateCurrencyId(null, _id, _productRateId, _sellRate, _sellRateCurrencyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateValue_SellRateCurrencyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_sellRate"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ProductRateValue> GetByIdProductRateIdSellRateSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _id, System.Int32 _productRateId, System.Decimal _sellRate, System.String _sellRateCurrencyId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(null,_productRateId, _defaultOption, _wholesalerId, _customerId, _sellRateCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(null, _productRateId, _defaultOption, _wholesalerId, _customerId, _sellRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId)
		{
			int count = -1;
			return GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(transactionManager, _productRateId, _defaultOption, _wholesalerId, _customerId, _sellRateCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(transactionManager, _productRateId, _defaultOption, _wholesalerId, _customerId, _sellRateCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId, int start, int pageLength, out int count)
		{
			return GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(null, _productRateId, _defaultOption, _wholesalerId, _customerId, _sellRateCurrencyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_ProductRateValue_Unique_Rates_Rule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="_defaultOption"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="_sellRateCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRateValue"/> class.</returns>
		public abstract CONFDB.Entities.ProductRateValue GetByProductRateIdDefaultOptionWholesalerIdCustomerIdSellRateCurrencyId(TransactionManager transactionManager, System.Int32 _productRateId, System.Byte _defaultOption, System.String _wholesalerId, System.Int32? _customerId, System.String _sellRateCurrencyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ProductRateValue&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ProductRateValue&gt;"/></returns>
		public static CONFDB.Entities.TList<ProductRateValue> Fill(IDataReader reader, CONFDB.Entities.TList<ProductRateValue> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ProductRateValue c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductRateValue")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ProductRateValueColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ProductRateValueColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ProductRateValue>(
					key.ToString(), // EntityTrackingKey
					"ProductRateValue",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ProductRateValue();
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
					c.Id = (System.Int32)reader[((int)ProductRateValueColumn.Id - 1)];
					c.ProductRateId = (System.Int32)reader[((int)ProductRateValueColumn.ProductRateId - 1)];
					c.SellRate = (System.Decimal)reader[((int)ProductRateValueColumn.SellRate - 1)];
					c.SellRateCurrencyId = (System.String)reader[((int)ProductRateValueColumn.SellRateCurrencyId - 1)];
					c.BuyRate = (System.Decimal)reader[((int)ProductRateValueColumn.BuyRate - 1)];
					c.BuyRateCurrencyId = (System.String)reader[((int)ProductRateValueColumn.BuyRateCurrencyId - 1)];
					c.DefaultOption = (System.Byte)reader[((int)ProductRateValueColumn.DefaultOption - 1)];
					c.StartDate = (reader.IsDBNull(((int)ProductRateValueColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)ProductRateValueColumn.StartDate - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)ProductRateValueColumn.WholesalerId - 1)))?null:(System.String)reader[((int)ProductRateValueColumn.WholesalerId - 1)];
					c.CustomerId = (reader.IsDBNull(((int)ProductRateValueColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)ProductRateValueColumn.CustomerId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ProductRateValue"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRateValue"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ProductRateValue entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProductRateValueColumn.Id - 1)];
			entity.ProductRateId = (System.Int32)reader[((int)ProductRateValueColumn.ProductRateId - 1)];
			entity.SellRate = (System.Decimal)reader[((int)ProductRateValueColumn.SellRate - 1)];
			entity.SellRateCurrencyId = (System.String)reader[((int)ProductRateValueColumn.SellRateCurrencyId - 1)];
			entity.BuyRate = (System.Decimal)reader[((int)ProductRateValueColumn.BuyRate - 1)];
			entity.BuyRateCurrencyId = (System.String)reader[((int)ProductRateValueColumn.BuyRateCurrencyId - 1)];
			entity.DefaultOption = (System.Byte)reader[((int)ProductRateValueColumn.DefaultOption - 1)];
			entity.StartDate = (reader.IsDBNull(((int)ProductRateValueColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)ProductRateValueColumn.StartDate - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)ProductRateValueColumn.WholesalerId - 1)))?null:(System.String)reader[((int)ProductRateValueColumn.WholesalerId - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)ProductRateValueColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)ProductRateValueColumn.CustomerId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ProductRateValue"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRateValue"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ProductRateValue entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ProductRateId = (System.Int32)dataRow["ProductRateID"];
			entity.SellRate = (System.Decimal)dataRow["SellRate"];
			entity.SellRateCurrencyId = (System.String)dataRow["SellRateCurrencyID"];
			entity.BuyRate = (System.Decimal)dataRow["BuyRate"];
			entity.BuyRateCurrencyId = (System.String)dataRow["BuyRateCurrencyID"];
			entity.DefaultOption = (System.Byte)dataRow["DefaultOption"];
			entity.StartDate = Convert.IsDBNull(dataRow["StartDate"]) ? null : (System.DateTime?)dataRow["StartDate"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRateValue"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ProductRateValue Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ProductRateValue entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customer|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CustomerId ?? (int)0);
				Customer tmpEntity = EntityManager.LocateEntity<Customer>(EntityLocator.ConstructKeyFromPkItems(typeof(Customer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerProvider.GetById(transactionManager, (entity.CustomerId ?? (int)0));		
				
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

			#region BuyRateCurrencyIdSource	
			if (CanDeepLoad(entity, "Currency|BuyRateCurrencyIdSource", deepLoadType, innerList) 
				&& entity.BuyRateCurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.BuyRateCurrencyId;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BuyRateCurrencyIdSource = tmpEntity;
				else
					entity.BuyRateCurrencyIdSource = DataRepository.CurrencyProvider.GetById(transactionManager, entity.BuyRateCurrencyId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BuyRateCurrencyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BuyRateCurrencyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.BuyRateCurrencyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BuyRateCurrencyIdSource

			#region SellRateCurrencyIdSource	
			if (CanDeepLoad(entity, "Currency|SellRateCurrencyIdSource", deepLoadType, innerList) 
				&& entity.SellRateCurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SellRateCurrencyId;
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SellRateCurrencyIdSource = tmpEntity;
				else
					entity.SellRateCurrencyIdSource = DataRepository.CurrencyProvider.GetById(transactionManager, entity.SellRateCurrencyId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SellRateCurrencyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SellRateCurrencyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyProvider.DeepLoad(transactionManager, entity.SellRateCurrencyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SellRateCurrencyIdSource

			#region ProductRateIdSource	
			if (CanDeepLoad(entity, "ProductRate|ProductRateIdSource", deepLoadType, innerList) 
				&& entity.ProductRateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductRateId;
				ProductRate tmpEntity = EntityManager.LocateEntity<ProductRate>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductRate), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductRateIdSource = tmpEntity;
				else
					entity.ProductRateIdSource = DataRepository.ProductRateProvider.GetById(transactionManager, entity.ProductRateId);		
				
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ProductRateValue object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ProductRateValue instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ProductRateValue Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ProductRateValue entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region BuyRateCurrencyIdSource
			if (CanDeepSave(entity, "Currency|BuyRateCurrencyIdSource", deepSaveType, innerList) 
				&& entity.BuyRateCurrencyIdSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.BuyRateCurrencyIdSource);
				entity.BuyRateCurrencyId = entity.BuyRateCurrencyIdSource.Id;
			}
			#endregion 
			
			#region SellRateCurrencyIdSource
			if (CanDeepSave(entity, "Currency|SellRateCurrencyIdSource", deepSaveType, innerList) 
				&& entity.SellRateCurrencyIdSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.SellRateCurrencyIdSource);
				entity.SellRateCurrencyId = entity.SellRateCurrencyIdSource.Id;
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
	
	#region ProductRateValueChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ProductRateValue</c>
	///</summary>
	public enum ProductRateValueChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
			
		///<summary>
		/// Composite Property for <c>Currency</c> at BuyRateCurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
			
		///<summary>
		/// Composite Property for <c>ProductRate</c> at ProductRateIdSource
		///</summary>
		[ChildEntityType(typeof(ProductRate))]
		ProductRate,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
		}
	
	#endregion ProductRateValueChildEntityTypes
	
	#region ProductRateValueFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductRateValueColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueFilterBuilder : SqlFilterBuilder<ProductRateValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilterBuilder class.
		/// </summary>
		public ProductRateValueFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateValueFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateValueFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateValueFilterBuilder
	
	#region ProductRateValueParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductRateValueColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRateValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateValueParameterBuilder : ParameterizedSqlFilterBuilder<ProductRateValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateValueParameterBuilder class.
		/// </summary>
		public ProductRateValueParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateValueParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateValueParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateValueParameterBuilder
} // end namespace
