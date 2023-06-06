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
	/// This class is the base class for any <see cref="CustomerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerProviderBaseCore : EntityProviderBase<CONFDB.Entities.Customer, CONFDB.Entities.CustomerKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByDnisidFromCustomer_Dnis
		
		/// <summary>
		///		Gets Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByDnisidFromCustomer_Dnis(System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisidFromCustomer_Dnis(null,_dnisid, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customer objects.</returns>
		public TList<Customer> GetByDnisidFromCustomer_Dnis(System.Int32 _dnisid, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidFromCustomer_Dnis(null, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByDnisidFromCustomer_Dnis(TransactionManager transactionManager, System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisidFromCustomer_Dnis(transactionManager, _dnisid, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByDnisidFromCustomer_Dnis(TransactionManager transactionManager, System.Int32 _dnisid,int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidFromCustomer_Dnis(transactionManager, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customer objects.</returns>
		public TList<Customer> GetByDnisidFromCustomer_Dnis(System.Int32 _dnisid,int start, int pageLength, out int count)
		{
			
			return GetByDnisidFromCustomer_Dnis(null, _dnisid, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Customer objects from the datasource by DNISID in the
		///		Customer_DNIS table. Table Customer is related to table DNIS
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customer objects.</returns>
		public abstract TList<Customer> GetByDnisidFromCustomer_Dnis(TransactionManager transactionManager,System.Int32 _dnisid, int start, int pageLength, out int count);
		
		#endregion GetByDnisidFromCustomer_Dnis
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerKey key)
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
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		Currency_Customer_FK1 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByCurrencyId(System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		Currency_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		Currency_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		currency_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByCurrencyId(System.String _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		currency_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByCurrencyId(System.String _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Customer_FK1 key.
		///		Currency_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		FK_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="_accountManagerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByAccountManagerId(System.Int32 _accountManagerId)
		{
			int count = -1;
			return GetByAccountManagerId(_accountManagerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		FK_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountManagerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByAccountManagerId(TransactionManager transactionManager, System.Int32 _accountManagerId)
		{
			int count = -1;
			return GetByAccountManagerId(transactionManager, _accountManagerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		FK_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountManagerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByAccountManagerId(TransactionManager transactionManager, System.Int32 _accountManagerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountManagerId(transactionManager, _accountManagerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		fk_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accountManagerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByAccountManagerId(System.Int32 _accountManagerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccountManagerId(null, _accountManagerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		fk_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accountManagerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByAccountManagerId(System.Int32 _accountManagerId, int start, int pageLength,out int count)
		{
			return GetByAccountManagerId(null, _accountManagerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_AccountManager key.
		///		FK_Customer_AccountManager Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accountManagerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByAccountManagerId(TransactionManager transactionManager, System.Int32 _accountManagerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		FK_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="_billingContactCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactCountry(System.String _billingContactCountry)
		{
			int count = -1;
			return GetByBillingContactCountry(_billingContactCountry, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		FK_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByBillingContactCountry(TransactionManager transactionManager, System.String _billingContactCountry)
		{
			int count = -1;
			return GetByBillingContactCountry(transactionManager, _billingContactCountry, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		FK_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactCountry(TransactionManager transactionManager, System.String _billingContactCountry, int start, int pageLength)
		{
			int count = -1;
			return GetByBillingContactCountry(transactionManager, _billingContactCountry, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		fk_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingContactCountry"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactCountry(System.String _billingContactCountry, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillingContactCountry(null, _billingContactCountry, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		fk_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingContactCountry"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactCountry(System.String _billingContactCountry, int start, int pageLength,out int count)
		{
			return GetByBillingContactCountry(null, _billingContactCountry, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactCountry key.
		///		FK_Customer_BillingContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByBillingContactCountry(TransactionManager transactionManager, System.String _billingContactCountry, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		FK_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="_billingContactRegion"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactRegion(System.String _billingContactRegion)
		{
			int count = -1;
			return GetByBillingContactRegion(_billingContactRegion, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		FK_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactRegion"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByBillingContactRegion(TransactionManager transactionManager, System.String _billingContactRegion)
		{
			int count = -1;
			return GetByBillingContactRegion(transactionManager, _billingContactRegion, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		FK_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactRegion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactRegion(TransactionManager transactionManager, System.String _billingContactRegion, int start, int pageLength)
		{
			int count = -1;
			return GetByBillingContactRegion(transactionManager, _billingContactRegion, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		fk_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingContactRegion"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactRegion(System.String _billingContactRegion, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillingContactRegion(null, _billingContactRegion, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		fk_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingContactRegion"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByBillingContactRegion(System.String _billingContactRegion, int start, int pageLength,out int count)
		{
			return GetByBillingContactRegion(null, _billingContactRegion, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_BillingContactRegion key.
		///		FK_Customer_BillingContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingContactRegion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByBillingContactRegion(TransactionManager transactionManager, System.String _billingContactRegion, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		FK_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="_primaryContactCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(System.String _primaryContactCountry)
		{
			int count = -1;
			return GetByPrimaryContactCountry(_primaryContactCountry, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		FK_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(TransactionManager transactionManager, System.String _primaryContactCountry)
		{
			int count = -1;
			return GetByPrimaryContactCountry(transactionManager, _primaryContactCountry, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		FK_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(TransactionManager transactionManager, System.String _primaryContactCountry, int start, int pageLength)
		{
			int count = -1;
			return GetByPrimaryContactCountry(transactionManager, _primaryContactCountry, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		fk_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_primaryContactCountry"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(System.String _primaryContactCountry, int start, int pageLength)
		{
			int count =  -1;
			return GetByPrimaryContactCountry(null, _primaryContactCountry, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		fk_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_primaryContactCountry"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(System.String _primaryContactCountry, int start, int pageLength,out int count)
		{
			return GetByPrimaryContactCountry(null, _primaryContactCountry, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactCountry key.
		///		FK_Customer_PrimaryContactCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByPrimaryContactCountry(TransactionManager transactionManager, System.String _primaryContactCountry, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		FK_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="_primaryContactRegion"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(System.String _primaryContactRegion)
		{
			int count = -1;
			return GetByPrimaryContactRegion(_primaryContactRegion, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		FK_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactRegion"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(TransactionManager transactionManager, System.String _primaryContactRegion)
		{
			int count = -1;
			return GetByPrimaryContactRegion(transactionManager, _primaryContactRegion, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		FK_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactRegion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(TransactionManager transactionManager, System.String _primaryContactRegion, int start, int pageLength)
		{
			int count = -1;
			return GetByPrimaryContactRegion(transactionManager, _primaryContactRegion, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		fk_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_primaryContactRegion"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(System.String _primaryContactRegion, int start, int pageLength)
		{
			int count =  -1;
			return GetByPrimaryContactRegion(null, _primaryContactRegion, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		fk_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_primaryContactRegion"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(System.String _primaryContactRegion, int start, int pageLength,out int count)
		{
			return GetByPrimaryContactRegion(null, _primaryContactRegion, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customer_PrimaryContactRegion key.
		///		FK_Customer_PrimaryContactRegion Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_primaryContactRegion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByPrimaryContactRegion(TransactionManager transactionManager, System.String _primaryContactRegion, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		Taxable_Customer_FK1 Description: 
		/// </summary>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByTaxableId(System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(_taxableId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		Taxable_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		Taxable_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		taxable_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTaxableId(null, _taxableId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		taxable_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength,out int count)
		{
			return GetByTaxableId(null, _taxableId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_Customer_FK1 key.
		///		Taxable_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		Verticals_Customer_FK1 Description: 
		/// </summary>
		/// <param name="_verticalId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByVerticalId(System.Int32 _verticalId)
		{
			int count = -1;
			return GetByVerticalId(_verticalId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		Verticals_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_verticalId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Customer> GetByVerticalId(TransactionManager transactionManager, System.Int32 _verticalId)
		{
			int count = -1;
			return GetByVerticalId(transactionManager, _verticalId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		Verticals_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_verticalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByVerticalId(TransactionManager transactionManager, System.Int32 _verticalId, int start, int pageLength)
		{
			int count = -1;
			return GetByVerticalId(transactionManager, _verticalId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		verticals_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_verticalId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByVerticalId(System.Int32 _verticalId, int start, int pageLength)
		{
			int count =  -1;
			return GetByVerticalId(null, _verticalId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		verticals_Customer_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_verticalId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public CONFDB.Entities.TList<Customer> GetByVerticalId(System.Int32 _verticalId, int start, int pageLength,out int count)
		{
			return GetByVerticalId(null, _verticalId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Verticals_Customer_FK1 key.
		///		Verticals_Customer_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_verticalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Customer objects.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByVerticalId(TransactionManager transactionManager, System.Int32 _verticalId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Customer Get(TransactionManager transactionManager, CONFDB.Entities.CustomerKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Customer_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public abstract CONFDB.Entities.Customer GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumber(null,_wholesalerId, _priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumber(null, _wholesalerId, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumber(transactionManager, _wholesalerId, _priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdPriCustomerNumber(transactionManager, _wholesalerId, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(System.String _wholesalerId, System.String _priCustomerNumber, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdPriCustomerNumber(null, _wholesalerId, _priCustomerNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UI_WholesalerID_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer"/> class.</returns>
		public abstract CONFDB.Entities.Customer GetByWholesalerIdPriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _priCustomerNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(null,_wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(null,_salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength, out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByCompanyId(System.Int32 _companyId)
		{
			int count = -1;
			return GetByCompanyId(null,_companyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByCompanyId(System.Int32 _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(null, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByCompanyId(System.Int32 _companyId, int start, int pageLength, out int count)
		{
			return GetByCompanyId(null, _companyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_CompanyID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="_lastModified"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByLastModified(System.DateTime _lastModified)
		{
			int count = -1;
			return GetByLastModified(null,_lastModified, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="_lastModified"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByLastModified(System.DateTime _lastModified, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModified(null, _lastModified, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModified"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByLastModified(TransactionManager transactionManager, System.DateTime _lastModified)
		{
			int count = -1;
			return GetByLastModified(transactionManager, _lastModified, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModified"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByLastModified(TransactionManager transactionManager, System.DateTime _lastModified, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModified(transactionManager, _lastModified, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="_lastModified"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByLastModified(System.DateTime _lastModified, int start, int pageLength, out int count)
		{
			return GetByLastModified(null, _lastModified, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_LastModifiedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModified"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByLastModified(TransactionManager transactionManager, System.DateTime _lastModified, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByUserId(System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByUserId(System.Int32? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByUserId(TransactionManager transactionManager, System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_UserID index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer> GetByUserId(System.Int32? _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_UserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_Customer_Omnovia_GetCompanyLogin 
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetCompanyLogin(null, 0, int.MaxValue , omnoviaCustomerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(int start, int pageLength, System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetCompanyLogin(null, start, pageLength , omnoviaCustomerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetCompanyLogin(TransactionManager transactionManager, System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetCompanyLogin(transactionManager, 0, int.MaxValue , omnoviaCustomerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Omnovia_GetCompanyLogin(TransactionManager transactionManager, int start, int pageLength , System.Int32? omnoviaCustomerId);
		
		#endregion
		
		#region p_Customer_InstallDefaults 
		
		/// <summary>
		///	This method wrap the 'p_Customer_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(System.Int32? id)
		{
			 InstallDefaults(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_InstallDefaults' stored procedure. 
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
		///	This method wrap the 'p_Customer_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(TransactionManager transactionManager, System.Int32? id)
		{
			 InstallDefaults(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void InstallDefaults(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region p_Customer_GetProductRates 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(System.Int32? customerId)
		{
			return GetProductRates(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(int start, int pageLength, System.Int32? customerId)
		{
			return GetProductRates(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(TransactionManager transactionManager, System.Int32? customerId)
		{
			return GetProductRates(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductRates(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_Customer_GetSeeVoghOverageCharges 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghOverageCharges' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghOverageCharges(System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghOverageCharges(null, 0, int.MaxValue , customerId, billedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghOverageCharges' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghOverageCharges(int start, int pageLength, System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghOverageCharges(null, start, pageLength , customerId, billedDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghOverageCharges' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghOverageCharges(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghOverageCharges(transactionManager, 0, int.MaxValue , customerId, billedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghOverageCharges' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSeeVoghOverageCharges(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? billedDate);
		
		#endregion
		
		#region p_Customer_UpdateDNIS 
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(System.Int32? customerId, System.Int32? dnisid, System.Int32? dnisTypeId, System.Boolean? updateModerators)
		{
			 UpdateDNIS(null, 0, int.MaxValue , customerId, dnisid, dnisTypeId, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(int start, int pageLength, System.Int32? customerId, System.Int32? dnisid, System.Int32? dnisTypeId, System.Boolean? updateModerators)
		{
			 UpdateDNIS(null, start, pageLength , customerId, dnisid, dnisTypeId, updateModerators);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateDNIS(TransactionManager transactionManager, System.Int32? customerId, System.Int32? dnisid, System.Int32? dnisTypeId, System.Boolean? updateModerators)
		{
			 UpdateDNIS(transactionManager, 0, int.MaxValue , customerId, dnisid, dnisTypeId, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateDNIS' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateDNIS(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.Int32? dnisid, System.Int32? dnisTypeId, System.Boolean? updateModerators);
		
		#endregion
		
		#region p_Customer_Omnovia_addArchiveDetails 
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_addArchiveDetails' stored procedure. 
		/// </summary>
		/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieTitle"> A <c>System.String</c> instance.</param>
		/// <param name="roomId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieDateAdded"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roomName"> A <c>System.String</c> instance.</param>
		/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="archiveHostedId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_addArchiveDetails(System.Int32? movieId, System.String movieTitle, System.Int32? roomId, System.DateTime? movieDate, System.DateTime? movieDateAdded, System.Int32? movieLength, System.String roomName, System.String companyShortLink, System.Int32? omnoviaCustomerId, ref System.Int32? archiveHostedId, ref System.Int32? moderatorId)
		{
			 Omnovia_addArchiveDetails(null, 0, int.MaxValue , movieId, movieTitle, roomId, movieDate, movieDateAdded, movieLength, roomName, companyShortLink, omnoviaCustomerId, ref archiveHostedId, ref moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_addArchiveDetails' stored procedure. 
		/// </summary>
		/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieTitle"> A <c>System.String</c> instance.</param>
		/// <param name="roomId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieDateAdded"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roomName"> A <c>System.String</c> instance.</param>
		/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="archiveHostedId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_addArchiveDetails(int start, int pageLength, System.Int32? movieId, System.String movieTitle, System.Int32? roomId, System.DateTime? movieDate, System.DateTime? movieDateAdded, System.Int32? movieLength, System.String roomName, System.String companyShortLink, System.Int32? omnoviaCustomerId, ref System.Int32? archiveHostedId, ref System.Int32? moderatorId)
		{
			 Omnovia_addArchiveDetails(null, start, pageLength , movieId, movieTitle, roomId, movieDate, movieDateAdded, movieLength, roomName, companyShortLink, omnoviaCustomerId, ref archiveHostedId, ref moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_addArchiveDetails' stored procedure. 
		/// </summary>
		/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieTitle"> A <c>System.String</c> instance.</param>
		/// <param name="roomId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieDateAdded"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roomName"> A <c>System.String</c> instance.</param>
		/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="archiveHostedId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_addArchiveDetails(TransactionManager transactionManager, System.Int32? movieId, System.String movieTitle, System.Int32? roomId, System.DateTime? movieDate, System.DateTime? movieDateAdded, System.Int32? movieLength, System.String roomName, System.String companyShortLink, System.Int32? omnoviaCustomerId, ref System.Int32? archiveHostedId, ref System.Int32? moderatorId)
		{
			 Omnovia_addArchiveDetails(transactionManager, 0, int.MaxValue , movieId, movieTitle, roomId, movieDate, movieDateAdded, movieLength, roomName, companyShortLink, omnoviaCustomerId, ref archiveHostedId, ref moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_addArchiveDetails' stored procedure. 
		/// </summary>
		/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieTitle"> A <c>System.String</c> instance.</param>
		/// <param name="roomId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="movieDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieDateAdded"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="movieLength"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roomName"> A <c>System.String</c> instance.</param>
		/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="archiveHostedId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Omnovia_addArchiveDetails(TransactionManager transactionManager, int start, int pageLength , System.Int32? movieId, System.String movieTitle, System.Int32? roomId, System.DateTime? movieDate, System.DateTime? movieDateAdded, System.Int32? movieLength, System.String roomName, System.String companyShortLink, System.Int32? omnoviaCustomerId, ref System.Int32? archiveHostedId, ref System.Int32? moderatorId);
		
		#endregion
		
		#region p_Customer_GetSeeVoghMonthlySummary 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghMonthlySummary' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghMonthlySummary(System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghMonthlySummary(null, 0, int.MaxValue , customerId, billedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghMonthlySummary' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghMonthlySummary(int start, int pageLength, System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghMonthlySummary(null, start, pageLength , customerId, billedDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghMonthlySummary' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSeeVoghMonthlySummary(TransactionManager transactionManager, System.Int32? customerId, System.DateTime? billedDate)
		{
			return GetSeeVoghMonthlySummary(transactionManager, 0, int.MaxValue , customerId, billedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetSeeVoghMonthlySummary' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSeeVoghMonthlySummary(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.DateTime? billedDate);
		
		#endregion
		
		#region p_Customer_Omnovia_GetRecordings 
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetRecordings(null, 0, int.MaxValue , omnoviaCustomerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(int start, int pageLength, System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetRecordings(null, start, pageLength , omnoviaCustomerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Omnovia_GetRecordings(TransactionManager transactionManager, System.Int32? omnoviaCustomerId)
		{
			return Omnovia_GetRecordings(transactionManager, 0, int.MaxValue , omnoviaCustomerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_GetRecordings' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Omnovia_GetRecordings(TransactionManager transactionManager, int start, int pageLength , System.Int32? omnoviaCustomerId);
		
		#endregion
		
		#region p_Customer_DisableCustomer 
		
		/// <summary>
		///	This method wrap the 'p_Customer_DisableCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableCustomer(System.Int32? customerId)
		{
			 DisableCustomer(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_DisableCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableCustomer(int start, int pageLength, System.Int32? customerId)
		{
			 DisableCustomer(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_DisableCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DisableCustomer(TransactionManager transactionManager, System.Int32? customerId)
		{
			 DisableCustomer(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_DisableCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DisableCustomer(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_Customer_GetRecordingRates 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetRecordingRates(System.Int32? customerId)
		{
			return GetRecordingRates(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetRecordingRates(int start, int pageLength, System.Int32? customerId)
		{
			return GetRecordingRates(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetRecordingRates(TransactionManager transactionManager, System.Int32? customerId)
		{
			return GetRecordingRates(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetRecordingRates(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_Customer_GetBalanceInfoDataSet 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfoDataSet' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfoDataSet(System.String wholesalerId, System.Int32? customerId, System.String priCustomerNumber)
		{
			return GetBalanceInfoDataSet(null, 0, int.MaxValue , wholesalerId, customerId, priCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfoDataSet' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfoDataSet(int start, int pageLength, System.String wholesalerId, System.Int32? customerId, System.String priCustomerNumber)
		{
			return GetBalanceInfoDataSet(null, start, pageLength , wholesalerId, customerId, priCustomerNumber);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfoDataSet' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfoDataSet(TransactionManager transactionManager, System.String wholesalerId, System.Int32? customerId, System.String priCustomerNumber)
		{
			return GetBalanceInfoDataSet(transactionManager, 0, int.MaxValue , wholesalerId, customerId, priCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfoDataSet' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBalanceInfoDataSet(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? customerId, System.String priCustomerNumber);
		
		#endregion
		
		#region p_Customer_CreateUser 
		
		/// <summary>
		///	This method wrap the 'p_Customer_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(System.Int32? customerId, System.String userName, System.String password, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(null, 0, int.MaxValue , customerId, userName, password, mustChangePassword, ref userId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(int start, int pageLength, System.Int32? customerId, System.String userName, System.String password, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(null, start, pageLength , customerId, userName, password, mustChangePassword, ref userId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CreateUser(TransactionManager transactionManager, System.Int32? customerId, System.String userName, System.String password, System.Boolean? mustChangePassword, ref System.Int32? userId)
		{
			 CreateUser(transactionManager, 0, int.MaxValue , customerId, userName, password, mustChangePassword, ref userId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_CreateUser' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="mustChangePassword"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CreateUser(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.String userName, System.String password, System.Boolean? mustChangePassword, ref System.Int32? userId);
		
		#endregion
		
		#region p_Customer_GetBalanceInfo 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="returnRowSet"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
			/// <param name="currentBalance"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfo(System.String wholesalerId, System.Boolean? returnRowSet, ref System.Int32? customerId, ref System.String priCustomerNumber, ref System.Decimal? currentBalance, ref System.String currencyId)
		{
			return GetBalanceInfo(null, 0, int.MaxValue , wholesalerId, returnRowSet, ref customerId, ref priCustomerNumber, ref currentBalance, ref currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="returnRowSet"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
			/// <param name="currentBalance"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfo(int start, int pageLength, System.String wholesalerId, System.Boolean? returnRowSet, ref System.Int32? customerId, ref System.String priCustomerNumber, ref System.Decimal? currentBalance, ref System.String currencyId)
		{
			return GetBalanceInfo(null, start, pageLength , wholesalerId, returnRowSet, ref customerId, ref priCustomerNumber, ref currentBalance, ref currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="returnRowSet"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
			/// <param name="currentBalance"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBalanceInfo(TransactionManager transactionManager, System.String wholesalerId, System.Boolean? returnRowSet, ref System.Int32? customerId, ref System.String priCustomerNumber, ref System.Decimal? currentBalance, ref System.String currencyId)
		{
			return GetBalanceInfo(transactionManager, 0, int.MaxValue , wholesalerId, returnRowSet, ref customerId, ref priCustomerNumber, ref currentBalance, ref currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetBalanceInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="returnRowSet"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
			/// <param name="currentBalance"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBalanceInfo(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Boolean? returnRowSet, ref System.Int32? customerId, ref System.String priCustomerNumber, ref System.Decimal? currentBalance, ref System.String currencyId);
		
		#endregion
		
		#region p_Customer_GetProductRatesByProductRateTypeDisplayName 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRatesByProductRateTypeDisplayName' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateTypeDisplayName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRatesByProductRateTypeDisplayName(System.Int32? customerId, System.String productRateTypeDisplayName)
		{
			return GetProductRatesByProductRateTypeDisplayName(null, 0, int.MaxValue , customerId, productRateTypeDisplayName);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRatesByProductRateTypeDisplayName' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateTypeDisplayName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRatesByProductRateTypeDisplayName(int start, int pageLength, System.Int32? customerId, System.String productRateTypeDisplayName)
		{
			return GetProductRatesByProductRateTypeDisplayName(null, start, pageLength , customerId, productRateTypeDisplayName);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRatesByProductRateTypeDisplayName' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateTypeDisplayName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRatesByProductRateTypeDisplayName(TransactionManager transactionManager, System.Int32? customerId, System.String productRateTypeDisplayName)
		{
			return GetProductRatesByProductRateTypeDisplayName(transactionManager, 0, int.MaxValue , customerId, productRateTypeDisplayName);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductRatesByProductRateTypeDisplayName' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateTypeDisplayName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductRatesByProductRateTypeDisplayName(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.String productRateTypeDisplayName);
		
		#endregion
		
		#region p_Customer_GetWebconferenceRecordingRates 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetWebconferenceRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetWebconferenceRecordingRates(System.Int32? customerId)
		{
			return GetWebconferenceRecordingRates(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetWebconferenceRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetWebconferenceRecordingRates(int start, int pageLength, System.Int32? customerId)
		{
			return GetWebconferenceRecordingRates(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetWebconferenceRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetWebconferenceRecordingRates(TransactionManager transactionManager, System.Int32? customerId)
		{
			return GetWebconferenceRecordingRates(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetWebconferenceRecordingRates' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetWebconferenceRecordingRates(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_Customer_Omnovia_RequestMP4 
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_RequestMP4' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="requestedBy"> A <c>System.String</c> instance.</param>
		/// <param name="extraInfo"> A <c>System.String</c> instance.</param>
			/// <param name="mp4RequestId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="message"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_RequestMP4(System.Int32? omnoviaCustomerId, System.Int32? hostedId, System.String requestedBy, System.String extraInfo, ref System.Int32? mp4RequestId, ref System.String message)
		{
			 Omnovia_RequestMP4(null, 0, int.MaxValue , omnoviaCustomerId, hostedId, requestedBy, extraInfo, ref mp4RequestId, ref message);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_RequestMP4' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="requestedBy"> A <c>System.String</c> instance.</param>
		/// <param name="extraInfo"> A <c>System.String</c> instance.</param>
			/// <param name="mp4RequestId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="message"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_RequestMP4(int start, int pageLength, System.Int32? omnoviaCustomerId, System.Int32? hostedId, System.String requestedBy, System.String extraInfo, ref System.Int32? mp4RequestId, ref System.String message)
		{
			 Omnovia_RequestMP4(null, start, pageLength , omnoviaCustomerId, hostedId, requestedBy, extraInfo, ref mp4RequestId, ref message);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_RequestMP4' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="requestedBy"> A <c>System.String</c> instance.</param>
		/// <param name="extraInfo"> A <c>System.String</c> instance.</param>
			/// <param name="mp4RequestId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="message"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Omnovia_RequestMP4(TransactionManager transactionManager, System.Int32? omnoviaCustomerId, System.Int32? hostedId, System.String requestedBy, System.String extraInfo, ref System.Int32? mp4RequestId, ref System.String message)
		{
			 Omnovia_RequestMP4(transactionManager, 0, int.MaxValue , omnoviaCustomerId, hostedId, requestedBy, extraInfo, ref mp4RequestId, ref message);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_Omnovia_RequestMP4' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="requestedBy"> A <c>System.String</c> instance.</param>
		/// <param name="extraInfo"> A <c>System.String</c> instance.</param>
			/// <param name="mp4RequestId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="message"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Omnovia_RequestMP4(TransactionManager transactionManager, int start, int pageLength , System.Int32? omnoviaCustomerId, System.Int32? hostedId, System.String requestedBy, System.String extraInfo, ref System.Int32? mp4RequestId, ref System.String message);
		
		#endregion
		
		#region p_Customer_UpdateFeature 
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateFeature' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateFeature(System.Int32? customerId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateModerators)
		{
			 UpdateFeature(null, 0, int.MaxValue , customerId, featureId, featureOptionId, featureOptionValue, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateFeature' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateFeature(int start, int pageLength, System.Int32? customerId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateModerators)
		{
			 UpdateFeature(null, start, pageLength , customerId, featureId, featureOptionId, featureOptionValue, updateModerators);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateFeature' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateFeature(TransactionManager transactionManager, System.Int32? customerId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateModerators)
		{
			 UpdateFeature(transactionManager, 0, int.MaxValue , customerId, featureId, featureOptionId, featureOptionValue, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_UpdateFeature' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateFeature(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateModerators);
		
		#endregion
		
		#region p_Customer_GetNextCustomerNumber 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetNextCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextCustomerNumber(System.String wholesalerId, ref System.String priCustomerNumber)
		{
			 GetNextCustomerNumber(null, 0, int.MaxValue , wholesalerId, ref priCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetNextCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextCustomerNumber(int start, int pageLength, System.String wholesalerId, ref System.String priCustomerNumber)
		{
			 GetNextCustomerNumber(null, start, pageLength , wholesalerId, ref priCustomerNumber);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetNextCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetNextCustomerNumber(TransactionManager transactionManager, System.String wholesalerId, ref System.String priCustomerNumber)
		{
			 GetNextCustomerNumber(transactionManager, 0, int.MaxValue , wholesalerId, ref priCustomerNumber);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetNextCustomerNumber' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
			/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetNextCustomerNumber(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, ref System.String priCustomerNumber);
		
		#endregion
		
		#region p_Customer_DeleteCustomer 
		
		/// <summary>
		///	This method wrap the 'p_Customer_DeleteCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteCustomer(System.Int32? customerId)
		{
			 DeleteCustomer(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_DeleteCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteCustomer(int start, int pageLength, System.Int32? customerId)
		{
			 DeleteCustomer(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_DeleteCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteCustomer(TransactionManager transactionManager, System.Int32? customerId)
		{
			 DeleteCustomer(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_DeleteCustomer' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteCustomer(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_Customer_GetProductFeatures 
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(System.Int32? customerId)
		{
			return GetProductFeatures(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(int start, int pageLength, System.Int32? customerId)
		{
			return GetProductFeatures(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(TransactionManager transactionManager, System.Int32? customerId)
		{
			return GetProductFeatures(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Customer_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductFeatures(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Customer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Customer&gt;"/></returns>
		public static CONFDB.Entities.TList<Customer> Fill(IDataReader reader, CONFDB.Entities.TList<Customer> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Customer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Customer")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CustomerColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Customer>(
					key.ToString(), // EntityTrackingKey
					"Customer",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Customer();
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
					c.Id = (System.Int32)reader[((int)CustomerColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)CustomerColumn.WholesalerId - 1)];
					c.PriCustomerNumber = (System.String)reader[((int)CustomerColumn.PriCustomerNumber - 1)];
					c.Description = (reader.IsDBNull(((int)CustomerColumn.Description - 1)))?null:(System.String)reader[((int)CustomerColumn.Description - 1)];
					c.ExternalCustomerNumber = (reader.IsDBNull(((int)CustomerColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.ExternalCustomerNumber - 1)];
					c.PrimaryContactName = (System.String)reader[((int)CustomerColumn.PrimaryContactName - 1)];
					c.PrimaryContactPhoneNumber = (System.String)reader[((int)CustomerColumn.PrimaryContactPhoneNumber - 1)];
					c.PrimaryContactEmailAddress = (System.String)reader[((int)CustomerColumn.PrimaryContactEmailAddress - 1)];
					c.PrimaryContactAddress1 = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactAddress1 - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactAddress1 - 1)];
					c.PrimaryContactAddress2 = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactAddress2 - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactAddress2 - 1)];
					c.PrimaryContactCity = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactCity - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactCity - 1)];
					c.PrimaryContactCountry = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactCountry - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactCountry - 1)];
					c.PrimaryContactRegion = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactRegion - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactRegion - 1)];
					c.PrimaryContactPostalCode = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactPostalCode - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactPostalCode - 1)];
					c.PrimaryContactFaxNumber = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactFaxNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactFaxNumber - 1)];
					c.BillingContactName = (reader.IsDBNull(((int)CustomerColumn.BillingContactName - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactName - 1)];
					c.BillingContactPhoneNumber = (reader.IsDBNull(((int)CustomerColumn.BillingContactPhoneNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactPhoneNumber - 1)];
					c.BillingContactEmailAddress = (reader.IsDBNull(((int)CustomerColumn.BillingContactEmailAddress - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactEmailAddress - 1)];
					c.BillingContactAddress1 = (reader.IsDBNull(((int)CustomerColumn.BillingContactAddress1 - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactAddress1 - 1)];
					c.BillingContactAddress2 = (reader.IsDBNull(((int)CustomerColumn.BillingContactAddress2 - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactAddress2 - 1)];
					c.BillingContactCity = (reader.IsDBNull(((int)CustomerColumn.BillingContactCity - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactCity - 1)];
					c.BillingContactCountry = (reader.IsDBNull(((int)CustomerColumn.BillingContactCountry - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactCountry - 1)];
					c.BillingContactRegion = (reader.IsDBNull(((int)CustomerColumn.BillingContactRegion - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactRegion - 1)];
					c.BillingContactPostalCode = (reader.IsDBNull(((int)CustomerColumn.BillingContactPostalCode - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactPostalCode - 1)];
					c.BillingContactFaxNumber = (reader.IsDBNull(((int)CustomerColumn.BillingContactFaxNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactFaxNumber - 1)];
					c.WebsiteUrl = (reader.IsDBNull(((int)CustomerColumn.WebsiteUrl - 1)))?null:(System.String)reader[((int)CustomerColumn.WebsiteUrl - 1)];
					c.SalesPersonId = (System.Int32)reader[((int)CustomerColumn.SalesPersonId - 1)];
					c.VerticalId = (System.Int32)reader[((int)CustomerColumn.VerticalId - 1)];
					c.CompanyId = (System.Int32)reader[((int)CustomerColumn.CompanyId - 1)];
					c.CurrencyId = (System.String)reader[((int)CustomerColumn.CurrencyId - 1)];
					c.BillingPeriodCutoff = (System.Int32)reader[((int)CustomerColumn.BillingPeriodCutoff - 1)];
					c.TaxableId = (System.Int32)reader[((int)CustomerColumn.TaxableId - 1)];
					c.CreditCardNameOnCard = (reader.IsDBNull(((int)CustomerColumn.CreditCardNameOnCard - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardNameOnCard - 1)];
					c.CreditCardNumber = (reader.IsDBNull(((int)CustomerColumn.CreditCardNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardNumber - 1)];
					c.CreditCardExp = (reader.IsDBNull(((int)CustomerColumn.CreditCardExp - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardExp - 1)];
					c.CreditCardVerCode = (reader.IsDBNull(((int)CustomerColumn.CreditCardVerCode - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardVerCode - 1)];
					c.CreditCardTypeName = (reader.IsDBNull(((int)CustomerColumn.CreditCardTypeName - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardTypeName - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CustomerColumn.CreatedDate - 1)];
					c.LastModified = (System.DateTime)reader[((int)CustomerColumn.LastModified - 1)];
					c.UniqueCustomerId = (System.Guid)reader[((int)CustomerColumn.UniqueCustomerId - 1)];
					c.Enabled = (reader.IsDBNull(((int)CustomerColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)CustomerColumn.Enabled - 1)];
					c.UserId = (reader.IsDBNull(((int)CustomerColumn.UserId - 1)))?null:(System.Int32?)reader[((int)CustomerColumn.UserId - 1)];
					c.WebGroupId = (reader.IsDBNull(((int)CustomerColumn.WebGroupId - 1)))?null:(System.String)reader[((int)CustomerColumn.WebGroupId - 1)];
					c.AccountManagerId = (System.Int32)reader[((int)CustomerColumn.AccountManagerId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Customer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Customer entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomerColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)CustomerColumn.WholesalerId - 1)];
			entity.PriCustomerNumber = (System.String)reader[((int)CustomerColumn.PriCustomerNumber - 1)];
			entity.Description = (reader.IsDBNull(((int)CustomerColumn.Description - 1)))?null:(System.String)reader[((int)CustomerColumn.Description - 1)];
			entity.ExternalCustomerNumber = (reader.IsDBNull(((int)CustomerColumn.ExternalCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.ExternalCustomerNumber - 1)];
			entity.PrimaryContactName = (System.String)reader[((int)CustomerColumn.PrimaryContactName - 1)];
			entity.PrimaryContactPhoneNumber = (System.String)reader[((int)CustomerColumn.PrimaryContactPhoneNumber - 1)];
			entity.PrimaryContactEmailAddress = (System.String)reader[((int)CustomerColumn.PrimaryContactEmailAddress - 1)];
			entity.PrimaryContactAddress1 = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactAddress1 - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactAddress1 - 1)];
			entity.PrimaryContactAddress2 = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactAddress2 - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactAddress2 - 1)];
			entity.PrimaryContactCity = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactCity - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactCity - 1)];
			entity.PrimaryContactCountry = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactCountry - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactCountry - 1)];
			entity.PrimaryContactRegion = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactRegion - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactRegion - 1)];
			entity.PrimaryContactPostalCode = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactPostalCode - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactPostalCode - 1)];
			entity.PrimaryContactFaxNumber = (reader.IsDBNull(((int)CustomerColumn.PrimaryContactFaxNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.PrimaryContactFaxNumber - 1)];
			entity.BillingContactName = (reader.IsDBNull(((int)CustomerColumn.BillingContactName - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactName - 1)];
			entity.BillingContactPhoneNumber = (reader.IsDBNull(((int)CustomerColumn.BillingContactPhoneNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactPhoneNumber - 1)];
			entity.BillingContactEmailAddress = (reader.IsDBNull(((int)CustomerColumn.BillingContactEmailAddress - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactEmailAddress - 1)];
			entity.BillingContactAddress1 = (reader.IsDBNull(((int)CustomerColumn.BillingContactAddress1 - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactAddress1 - 1)];
			entity.BillingContactAddress2 = (reader.IsDBNull(((int)CustomerColumn.BillingContactAddress2 - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactAddress2 - 1)];
			entity.BillingContactCity = (reader.IsDBNull(((int)CustomerColumn.BillingContactCity - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactCity - 1)];
			entity.BillingContactCountry = (reader.IsDBNull(((int)CustomerColumn.BillingContactCountry - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactCountry - 1)];
			entity.BillingContactRegion = (reader.IsDBNull(((int)CustomerColumn.BillingContactRegion - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactRegion - 1)];
			entity.BillingContactPostalCode = (reader.IsDBNull(((int)CustomerColumn.BillingContactPostalCode - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactPostalCode - 1)];
			entity.BillingContactFaxNumber = (reader.IsDBNull(((int)CustomerColumn.BillingContactFaxNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.BillingContactFaxNumber - 1)];
			entity.WebsiteUrl = (reader.IsDBNull(((int)CustomerColumn.WebsiteUrl - 1)))?null:(System.String)reader[((int)CustomerColumn.WebsiteUrl - 1)];
			entity.SalesPersonId = (System.Int32)reader[((int)CustomerColumn.SalesPersonId - 1)];
			entity.VerticalId = (System.Int32)reader[((int)CustomerColumn.VerticalId - 1)];
			entity.CompanyId = (System.Int32)reader[((int)CustomerColumn.CompanyId - 1)];
			entity.CurrencyId = (System.String)reader[((int)CustomerColumn.CurrencyId - 1)];
			entity.BillingPeriodCutoff = (System.Int32)reader[((int)CustomerColumn.BillingPeriodCutoff - 1)];
			entity.TaxableId = (System.Int32)reader[((int)CustomerColumn.TaxableId - 1)];
			entity.CreditCardNameOnCard = (reader.IsDBNull(((int)CustomerColumn.CreditCardNameOnCard - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardNameOnCard - 1)];
			entity.CreditCardNumber = (reader.IsDBNull(((int)CustomerColumn.CreditCardNumber - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardNumber - 1)];
			entity.CreditCardExp = (reader.IsDBNull(((int)CustomerColumn.CreditCardExp - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardExp - 1)];
			entity.CreditCardVerCode = (reader.IsDBNull(((int)CustomerColumn.CreditCardVerCode - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardVerCode - 1)];
			entity.CreditCardTypeName = (reader.IsDBNull(((int)CustomerColumn.CreditCardTypeName - 1)))?null:(System.String)reader[((int)CustomerColumn.CreditCardTypeName - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CustomerColumn.CreatedDate - 1)];
			entity.LastModified = (System.DateTime)reader[((int)CustomerColumn.LastModified - 1)];
			entity.UniqueCustomerId = (System.Guid)reader[((int)CustomerColumn.UniqueCustomerId - 1)];
			entity.Enabled = (reader.IsDBNull(((int)CustomerColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)CustomerColumn.Enabled - 1)];
			entity.UserId = (reader.IsDBNull(((int)CustomerColumn.UserId - 1)))?null:(System.Int32?)reader[((int)CustomerColumn.UserId - 1)];
			entity.WebGroupId = (reader.IsDBNull(((int)CustomerColumn.WebGroupId - 1)))?null:(System.String)reader[((int)CustomerColumn.WebGroupId - 1)];
			entity.AccountManagerId = (System.Int32)reader[((int)CustomerColumn.AccountManagerId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Customer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Customer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.PriCustomerNumber = (System.String)dataRow["PriCustomerNumber"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.ExternalCustomerNumber = Convert.IsDBNull(dataRow["ExternalCustomerNumber"]) ? null : (System.String)dataRow["ExternalCustomerNumber"];
			entity.PrimaryContactName = (System.String)dataRow["PrimaryContactName"];
			entity.PrimaryContactPhoneNumber = (System.String)dataRow["PrimaryContactPhoneNumber"];
			entity.PrimaryContactEmailAddress = (System.String)dataRow["PrimaryContactEmailAddress"];
			entity.PrimaryContactAddress1 = Convert.IsDBNull(dataRow["PrimaryContactAddress1"]) ? null : (System.String)dataRow["PrimaryContactAddress1"];
			entity.PrimaryContactAddress2 = Convert.IsDBNull(dataRow["PrimaryContactAddress2"]) ? null : (System.String)dataRow["PrimaryContactAddress2"];
			entity.PrimaryContactCity = Convert.IsDBNull(dataRow["PrimaryContactCity"]) ? null : (System.String)dataRow["PrimaryContactCity"];
			entity.PrimaryContactCountry = Convert.IsDBNull(dataRow["PrimaryContactCountry"]) ? null : (System.String)dataRow["PrimaryContactCountry"];
			entity.PrimaryContactRegion = Convert.IsDBNull(dataRow["PrimaryContactRegion"]) ? null : (System.String)dataRow["PrimaryContactRegion"];
			entity.PrimaryContactPostalCode = Convert.IsDBNull(dataRow["PrimaryContactPostalCode"]) ? null : (System.String)dataRow["PrimaryContactPostalCode"];
			entity.PrimaryContactFaxNumber = Convert.IsDBNull(dataRow["PrimaryContactFaxNumber"]) ? null : (System.String)dataRow["PrimaryContactFaxNumber"];
			entity.BillingContactName = Convert.IsDBNull(dataRow["BillingContactName"]) ? null : (System.String)dataRow["BillingContactName"];
			entity.BillingContactPhoneNumber = Convert.IsDBNull(dataRow["BillingContactPhoneNumber"]) ? null : (System.String)dataRow["BillingContactPhoneNumber"];
			entity.BillingContactEmailAddress = Convert.IsDBNull(dataRow["BillingContactEmailAddress"]) ? null : (System.String)dataRow["BillingContactEmailAddress"];
			entity.BillingContactAddress1 = Convert.IsDBNull(dataRow["BillingContactAddress1"]) ? null : (System.String)dataRow["BillingContactAddress1"];
			entity.BillingContactAddress2 = Convert.IsDBNull(dataRow["BillingContactAddress2"]) ? null : (System.String)dataRow["BillingContactAddress2"];
			entity.BillingContactCity = Convert.IsDBNull(dataRow["BillingContactCity"]) ? null : (System.String)dataRow["BillingContactCity"];
			entity.BillingContactCountry = Convert.IsDBNull(dataRow["BillingContactCountry"]) ? null : (System.String)dataRow["BillingContactCountry"];
			entity.BillingContactRegion = Convert.IsDBNull(dataRow["BillingContactRegion"]) ? null : (System.String)dataRow["BillingContactRegion"];
			entity.BillingContactPostalCode = Convert.IsDBNull(dataRow["BillingContactPostalCode"]) ? null : (System.String)dataRow["BillingContactPostalCode"];
			entity.BillingContactFaxNumber = Convert.IsDBNull(dataRow["BillingContactFaxNumber"]) ? null : (System.String)dataRow["BillingContactFaxNumber"];
			entity.WebsiteUrl = Convert.IsDBNull(dataRow["WebsiteURL"]) ? null : (System.String)dataRow["WebsiteURL"];
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.VerticalId = (System.Int32)dataRow["VerticalID"];
			entity.CompanyId = (System.Int32)dataRow["CompanyID"];
			entity.CurrencyId = (System.String)dataRow["CurrencyID"];
			entity.BillingPeriodCutoff = (System.Int32)dataRow["BillingPeriodCutoff"];
			entity.TaxableId = (System.Int32)dataRow["TaxableID"];
			entity.CreditCardNameOnCard = Convert.IsDBNull(dataRow["CreditCardNameOnCard"]) ? null : (System.String)dataRow["CreditCardNameOnCard"];
			entity.CreditCardNumber = Convert.IsDBNull(dataRow["CreditCardNumber"]) ? null : (System.String)dataRow["CreditCardNumber"];
			entity.CreditCardExp = Convert.IsDBNull(dataRow["CreditCardExp"]) ? null : (System.String)dataRow["CreditCardExp"];
			entity.CreditCardVerCode = Convert.IsDBNull(dataRow["CreditCardVerCode"]) ? null : (System.String)dataRow["CreditCardVerCode"];
			entity.CreditCardTypeName = Convert.IsDBNull(dataRow["CreditCardTypeName"]) ? null : (System.String)dataRow["CreditCardTypeName"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.UniqueCustomerId = (System.Guid)dataRow["UniqueCustomerID"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
			entity.WebGroupId = Convert.IsDBNull(dataRow["WebGroupID"]) ? null : (System.String)dataRow["WebGroupID"];
			entity.AccountManagerId = (System.Int32)dataRow["AccountManagerID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Customer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Customer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region CompanyIdSource	
			if (CanDeepLoad(entity, "Company|CompanyIdSource", deepLoadType, innerList) 
				&& entity.CompanyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CompanyId;
				Company tmpEntity = EntityManager.LocateEntity<Company>(EntityLocator.ConstructKeyFromPkItems(typeof(Company), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompanyIdSource = tmpEntity;
				else
					entity.CompanyIdSource = DataRepository.CompanyProvider.GetById(transactionManager, entity.CompanyId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompanyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CompanyProvider.DeepLoad(transactionManager, entity.CompanyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompanyIdSource

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

			#region AccountManagerIdSource	
			if (CanDeepLoad(entity, "AccountManager|AccountManagerIdSource", deepLoadType, innerList) 
				&& entity.AccountManagerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AccountManagerId;
				AccountManager tmpEntity = EntityManager.LocateEntity<AccountManager>(EntityLocator.ConstructKeyFromPkItems(typeof(AccountManager), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccountManagerIdSource = tmpEntity;
				else
					entity.AccountManagerIdSource = DataRepository.AccountManagerProvider.GetById(transactionManager, entity.AccountManagerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccountManagerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AccountManagerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AccountManagerProvider.DeepLoad(transactionManager, entity.AccountManagerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AccountManagerIdSource

			#region BillingContactCountrySource	
			if (CanDeepLoad(entity, "Country|BillingContactCountrySource", deepLoadType, innerList) 
				&& entity.BillingContactCountrySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BillingContactCountry ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillingContactCountrySource = tmpEntity;
				else
					entity.BillingContactCountrySource = DataRepository.CountryProvider.GetById(transactionManager, (entity.BillingContactCountry ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillingContactCountrySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillingContactCountrySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.BillingContactCountrySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillingContactCountrySource

			#region BillingContactRegionSource	
			if (CanDeepLoad(entity, "State|BillingContactRegionSource", deepLoadType, innerList) 
				&& entity.BillingContactRegionSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BillingContactRegion ?? string.Empty);
				State tmpEntity = EntityManager.LocateEntity<State>(EntityLocator.ConstructKeyFromPkItems(typeof(State), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillingContactRegionSource = tmpEntity;
				else
					entity.BillingContactRegionSource = DataRepository.StateProvider.GetById(transactionManager, (entity.BillingContactRegion ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillingContactRegionSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillingContactRegionSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvider.DeepLoad(transactionManager, entity.BillingContactRegionSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillingContactRegionSource

			#region PrimaryContactCountrySource	
			if (CanDeepLoad(entity, "Country|PrimaryContactCountrySource", deepLoadType, innerList) 
				&& entity.PrimaryContactCountrySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PrimaryContactCountry ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PrimaryContactCountrySource = tmpEntity;
				else
					entity.PrimaryContactCountrySource = DataRepository.CountryProvider.GetById(transactionManager, (entity.PrimaryContactCountry ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PrimaryContactCountrySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PrimaryContactCountrySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.PrimaryContactCountrySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PrimaryContactCountrySource

			#region PrimaryContactRegionSource	
			if (CanDeepLoad(entity, "State|PrimaryContactRegionSource", deepLoadType, innerList) 
				&& entity.PrimaryContactRegionSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PrimaryContactRegion ?? string.Empty);
				State tmpEntity = EntityManager.LocateEntity<State>(EntityLocator.ConstructKeyFromPkItems(typeof(State), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PrimaryContactRegionSource = tmpEntity;
				else
					entity.PrimaryContactRegionSource = DataRepository.StateProvider.GetById(transactionManager, (entity.PrimaryContactRegion ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PrimaryContactRegionSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PrimaryContactRegionSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvider.DeepLoad(transactionManager, entity.PrimaryContactRegionSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PrimaryContactRegionSource

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

			#region TaxableIdSource	
			if (CanDeepLoad(entity, "Taxable|TaxableIdSource", deepLoadType, innerList) 
				&& entity.TaxableIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TaxableId;
				Taxable tmpEntity = EntityManager.LocateEntity<Taxable>(EntityLocator.ConstructKeyFromPkItems(typeof(Taxable), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TaxableIdSource = tmpEntity;
				else
					entity.TaxableIdSource = DataRepository.TaxableProvider.GetById(transactionManager, entity.TaxableId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TaxableIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TaxableIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TaxableProvider.DeepLoad(transactionManager, entity.TaxableIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TaxableIdSource

			#region VerticalIdSource	
			if (CanDeepLoad(entity, "Vertical|VerticalIdSource", deepLoadType, innerList) 
				&& entity.VerticalIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.VerticalId;
				Vertical tmpEntity = EntityManager.LocateEntity<Vertical>(EntityLocator.ConstructKeyFromPkItems(typeof(Vertical), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.VerticalIdSource = tmpEntity;
				else
					entity.VerticalIdSource = DataRepository.VerticalProvider.GetById(transactionManager, entity.VerticalId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VerticalIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.VerticalIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.VerticalProvider.DeepLoad(transactionManager, entity.VerticalIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion VerticalIdSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerDocumentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerDocument>|CustomerDocumentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerDocumentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerDocumentCollection = DataRepository.CustomerDocumentProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.CustomerDocumentCollection.Count > 0)
				{
					deepHandles.Add("CustomerDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerDocument>) DataRepository.CustomerDocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerDocumentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductRateValueCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductRateValue>|ProductRateValueCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateValueCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductRateValueCollection = DataRepository.ProductRateValueProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.ProductRateValueCollection.Count > 0)
				{
					deepHandles.Add("ProductRateValueCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRateValue>) DataRepository.ProductRateValueProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateValueCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Customer_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer_Feature>|Customer_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Customer_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Customer_FeatureCollection = DataRepository.Customer_FeatureProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.Customer_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Customer_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer_Feature>) DataRepository.Customer_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Customer_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CommissionCustomerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CommissionCustomer>|CommissionCustomerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommissionCustomerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommissionCustomerCollection = DataRepository.CommissionCustomerProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.CommissionCustomerCollection.Count > 0)
				{
					deepHandles.Add("CommissionCustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CommissionCustomer>) DataRepository.CommissionCustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCustomerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerTransactionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerTransaction>|CustomerTransactionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTransactionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerTransactionCollection = DataRepository.CustomerTransactionProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.CustomerTransactionCollection.Count > 0)
				{
					deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerTransaction>) DataRepository.CustomerTransactionProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTransactionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ParticipantListCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ParticipantList>|ParticipantListCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ParticipantListCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ParticipantListCollection = DataRepository.ParticipantListProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.ParticipantListCollection.Count > 0)
				{
					deepHandles.Add("ParticipantListCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ParticipantList>) DataRepository.ParticipantListProvider.DeepLoad,
						new object[] { transactionManager, entity.ParticipantListCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DepartmentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Department>|DepartmentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DepartmentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DepartmentCollection = DataRepository.DepartmentProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.DepartmentCollection.Count > 0)
				{
					deepHandles.Add("DepartmentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Department>) DataRepository.DepartmentProvider.DeepLoad,
						new object[] { transactionManager, entity.DepartmentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Customer_DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer_Dnis>|Customer_DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Customer_DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Customer_DnisCollection = DataRepository.Customer_DnisProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.Customer_DnisCollection.Count > 0)
				{
					deepHandles.Add("Customer_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer_Dnis>) DataRepository.Customer_DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.Customer_DnisCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region InvoiceSummaryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<InvoiceSummary>|InvoiceSummaryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceSummaryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceSummaryCollection = DataRepository.InvoiceSummaryProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.InvoiceSummaryCollection.Count > 0)
				{
					deepHandles.Add("InvoiceSummaryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<InvoiceSummary>) DataRepository.InvoiceSummaryProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceSummaryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DnisidDnisCollection_From_Customer_Dnis
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Dnis>|DnisidDnisCollection_From_Customer_Dnis", deepLoadType, innerList))
			{
				entity.DnisidDnisCollection_From_Customer_Dnis = DataRepository.DnisProvider.GetByCustomerIdFromCustomer_Dnis(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisidDnisCollection_From_Customer_Dnis' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DnisidDnisCollection_From_Customer_Dnis != null)
				{
					deepHandles.Add("DnisidDnisCollection_From_Customer_Dnis",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Dnis >) DataRepository.DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.DnisidDnisCollection_From_Customer_Dnis, deep, deepLoadType, childTypes, innerList }
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

				entity.TicketCollection = DataRepository.TicketProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.TicketCollection.Count > 0)
				{
					deepHandles.Add("TicketCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Ticket>) DataRepository.TicketProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CommissionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Commission>|CommissionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommissionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommissionCollection = DataRepository.CommissionProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.CommissionCollection.Count > 0)
				{
					deepHandles.Add("CommissionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Commission>) DataRepository.CommissionProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EventManagerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EventManager>|EventManagerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EventManagerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EventManagerCollection = DataRepository.EventManagerProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.EventManagerCollection.Count > 0)
				{
					deepHandles.Add("EventManagerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EventManager>) DataRepository.EventManagerProvider.DeepLoad,
						new object[] { transactionManager, entity.EventManagerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ModeratorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator>|ModeratorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ModeratorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ModeratorCollection = DataRepository.ModeratorProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.ModeratorCollection.Count > 0)
				{
					deepHandles.Add("ModeratorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator>) DataRepository.ModeratorProvider.DeepLoad,
						new object[] { transactionManager, entity.ModeratorCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Customer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Customer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Customer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Customer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CompanyIdSource
			if (CanDeepSave(entity, "Company|CompanyIdSource", deepSaveType, innerList) 
				&& entity.CompanyIdSource != null)
			{
				DataRepository.CompanyProvider.Save(transactionManager, entity.CompanyIdSource);
				entity.CompanyId = entity.CompanyIdSource.Id;
			}
			#endregion 
			
			#region CurrencyIdSource
			if (CanDeepSave(entity, "Currency|CurrencyIdSource", deepSaveType, innerList) 
				&& entity.CurrencyIdSource != null)
			{
				DataRepository.CurrencyProvider.Save(transactionManager, entity.CurrencyIdSource);
				entity.CurrencyId = entity.CurrencyIdSource.Id;
			}
			#endregion 
			
			#region AccountManagerIdSource
			if (CanDeepSave(entity, "AccountManager|AccountManagerIdSource", deepSaveType, innerList) 
				&& entity.AccountManagerIdSource != null)
			{
				DataRepository.AccountManagerProvider.Save(transactionManager, entity.AccountManagerIdSource);
				entity.AccountManagerId = entity.AccountManagerIdSource.Id;
			}
			#endregion 
			
			#region BillingContactCountrySource
			if (CanDeepSave(entity, "Country|BillingContactCountrySource", deepSaveType, innerList) 
				&& entity.BillingContactCountrySource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.BillingContactCountrySource);
				entity.BillingContactCountry = entity.BillingContactCountrySource.Id;
			}
			#endregion 
			
			#region BillingContactRegionSource
			if (CanDeepSave(entity, "State|BillingContactRegionSource", deepSaveType, innerList) 
				&& entity.BillingContactRegionSource != null)
			{
				DataRepository.StateProvider.Save(transactionManager, entity.BillingContactRegionSource);
				entity.BillingContactRegion = entity.BillingContactRegionSource.Id;
			}
			#endregion 
			
			#region PrimaryContactCountrySource
			if (CanDeepSave(entity, "Country|PrimaryContactCountrySource", deepSaveType, innerList) 
				&& entity.PrimaryContactCountrySource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.PrimaryContactCountrySource);
				entity.PrimaryContactCountry = entity.PrimaryContactCountrySource.Id;
			}
			#endregion 
			
			#region PrimaryContactRegionSource
			if (CanDeepSave(entity, "State|PrimaryContactRegionSource", deepSaveType, innerList) 
				&& entity.PrimaryContactRegionSource != null)
			{
				DataRepository.StateProvider.Save(transactionManager, entity.PrimaryContactRegionSource);
				entity.PrimaryContactRegion = entity.PrimaryContactRegionSource.Id;
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
			
			#region TaxableIdSource
			if (CanDeepSave(entity, "Taxable|TaxableIdSource", deepSaveType, innerList) 
				&& entity.TaxableIdSource != null)
			{
				DataRepository.TaxableProvider.Save(transactionManager, entity.TaxableIdSource);
				entity.TaxableId = entity.TaxableIdSource.Id;
			}
			#endregion 
			
			#region VerticalIdSource
			if (CanDeepSave(entity, "Vertical|VerticalIdSource", deepSaveType, innerList) 
				&& entity.VerticalIdSource != null)
			{
				DataRepository.VerticalProvider.Save(transactionManager, entity.VerticalIdSource);
				entity.VerticalId = entity.VerticalIdSource.Id;
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

			#region DnisidDnisCollection_From_Customer_Dnis>
			if (CanDeepSave(entity.DnisidDnisCollection_From_Customer_Dnis, "List<Dnis>|DnisidDnisCollection_From_Customer_Dnis", deepSaveType, innerList))
			{
				if (entity.DnisidDnisCollection_From_Customer_Dnis.Count > 0 || entity.DnisidDnisCollection_From_Customer_Dnis.DeletedItems.Count > 0)
				{
					DataRepository.DnisProvider.Save(transactionManager, entity.DnisidDnisCollection_From_Customer_Dnis); 
					deepHandles.Add("DnisidDnisCollection_From_Customer_Dnis",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Dnis>) DataRepository.DnisProvider.DeepSave,
						new object[] { transactionManager, entity.DnisidDnisCollection_From_Customer_Dnis, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<CustomerDocument>
				if (CanDeepSave(entity.CustomerDocumentCollection, "List<CustomerDocument>|CustomerDocumentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerDocument child in entity.CustomerDocumentCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.CustomerDocumentCollection.Count > 0 || entity.CustomerDocumentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerDocumentProvider.Save(transactionManager, entity.CustomerDocumentCollection);
						
						deepHandles.Add("CustomerDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerDocument >) DataRepository.CustomerDocumentProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerDocumentCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductRateValue>
				if (CanDeepSave(entity.ProductRateValueCollection, "List<ProductRateValue>|ProductRateValueCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductRateValue child in entity.ProductRateValueCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.ProductRateValueCollection.Count > 0 || entity.ProductRateValueCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductRateValueProvider.Save(transactionManager, entity.ProductRateValueCollection);
						
						deepHandles.Add("ProductRateValueCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductRateValue >) DataRepository.ProductRateValueProvider.DeepSave,
							new object[] { transactionManager, entity.ProductRateValueCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer_Feature>
				if (CanDeepSave(entity.Customer_FeatureCollection, "List<Customer_Feature>|Customer_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer_Feature child in entity.Customer_FeatureCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.Customer_FeatureCollection.Count > 0 || entity.Customer_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Customer_FeatureProvider.Save(transactionManager, entity.Customer_FeatureCollection);
						
						deepHandles.Add("Customer_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer_Feature >) DataRepository.Customer_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Customer_FeatureCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CommissionCustomer>
				if (CanDeepSave(entity.CommissionCustomerCollection, "List<CommissionCustomer>|CommissionCustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CommissionCustomer child in entity.CommissionCustomerCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.CommissionCustomerCollection.Count > 0 || entity.CommissionCustomerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CommissionCustomerProvider.Save(transactionManager, entity.CommissionCustomerCollection);
						
						deepHandles.Add("CommissionCustomerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CommissionCustomer >) DataRepository.CommissionCustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CommissionCustomerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomerTransaction>
				if (CanDeepSave(entity.CustomerTransactionCollection, "List<CustomerTransaction>|CustomerTransactionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerTransaction child in entity.CustomerTransactionCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.CustomerTransactionCollection.Count > 0 || entity.CustomerTransactionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerTransactionProvider.Save(transactionManager, entity.CustomerTransactionCollection);
						
						deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerTransaction >) DataRepository.CustomerTransactionProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerTransactionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ParticipantList>
				if (CanDeepSave(entity.ParticipantListCollection, "List<ParticipantList>|ParticipantListCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ParticipantList child in entity.ParticipantListCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.ParticipantListCollection.Count > 0 || entity.ParticipantListCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ParticipantListProvider.Save(transactionManager, entity.ParticipantListCollection);
						
						deepHandles.Add("ParticipantListCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ParticipantList >) DataRepository.ParticipantListProvider.DeepSave,
							new object[] { transactionManager, entity.ParticipantListCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Department>
				if (CanDeepSave(entity.DepartmentCollection, "List<Department>|DepartmentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Department child in entity.DepartmentCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.DepartmentCollection.Count > 0 || entity.DepartmentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DepartmentProvider.Save(transactionManager, entity.DepartmentCollection);
						
						deepHandles.Add("DepartmentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Department >) DataRepository.DepartmentProvider.DeepSave,
							new object[] { transactionManager, entity.DepartmentCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer_Dnis>
				if (CanDeepSave(entity.Customer_DnisCollection, "List<Customer_Dnis>|Customer_DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer_Dnis child in entity.Customer_DnisCollection)
					{
						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.Id;
						}

						if(child.DnisidSource != null)
						{
								child.Dnisid = child.DnisidSource.Id;
						}

					}

					if (entity.Customer_DnisCollection.Count > 0 || entity.Customer_DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Customer_DnisProvider.Save(transactionManager, entity.Customer_DnisCollection);
						
						deepHandles.Add("Customer_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer_Dnis >) DataRepository.Customer_DnisProvider.DeepSave,
							new object[] { transactionManager, entity.Customer_DnisCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<InvoiceSummary>
				if (CanDeepSave(entity.InvoiceSummaryCollection, "List<InvoiceSummary>|InvoiceSummaryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(InvoiceSummary child in entity.InvoiceSummaryCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.InvoiceSummaryCollection.Count > 0 || entity.InvoiceSummaryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceSummaryProvider.Save(transactionManager, entity.InvoiceSummaryCollection);
						
						deepHandles.Add("InvoiceSummaryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< InvoiceSummary >) DataRepository.InvoiceSummaryProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceSummaryCollection, deepSaveType, childTypes, innerList }
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
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
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
				
	
			#region List<Commission>
				if (CanDeepSave(entity.CommissionCollection, "List<Commission>|CommissionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Commission child in entity.CommissionCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.CommissionCollection.Count > 0 || entity.CommissionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CommissionProvider.Save(transactionManager, entity.CommissionCollection);
						
						deepHandles.Add("CommissionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Commission >) DataRepository.CommissionProvider.DeepSave,
							new object[] { transactionManager, entity.CommissionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EventManager>
				if (CanDeepSave(entity.EventManagerCollection, "List<EventManager>|EventManagerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EventManager child in entity.EventManagerCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.EventManagerCollection.Count > 0 || entity.EventManagerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EventManagerProvider.Save(transactionManager, entity.EventManagerCollection);
						
						deepHandles.Add("EventManagerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EventManager >) DataRepository.EventManagerProvider.DeepSave,
							new object[] { transactionManager, entity.EventManagerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Moderator>
				if (CanDeepSave(entity.ModeratorCollection, "List<Moderator>|ModeratorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator child in entity.ModeratorCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
						}

					}

					if (entity.ModeratorCollection.Count > 0 || entity.ModeratorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ModeratorProvider.Save(transactionManager, entity.ModeratorCollection);
						
						deepHandles.Add("ModeratorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator >) DataRepository.ModeratorProvider.DeepSave,
							new object[] { transactionManager, entity.ModeratorCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Customer</c>
	///</summary>
	public enum CustomerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>User</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(User))]
		User,
			
		///<summary>
		/// Composite Property for <c>Company</c> at CompanyIdSource
		///</summary>
		[ChildEntityType(typeof(Company))]
		Company,
			
		///<summary>
		/// Composite Property for <c>Currency</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
			
		///<summary>
		/// Composite Property for <c>AccountManager</c> at AccountManagerIdSource
		///</summary>
		[ChildEntityType(typeof(AccountManager))]
		AccountManager,
			
		///<summary>
		/// Composite Property for <c>Country</c> at BillingContactCountrySource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
			
		///<summary>
		/// Composite Property for <c>State</c> at BillingContactRegionSource
		///</summary>
		[ChildEntityType(typeof(State))]
		State,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>Taxable</c> at TaxableIdSource
		///</summary>
		[ChildEntityType(typeof(Taxable))]
		Taxable,
			
		///<summary>
		/// Composite Property for <c>Vertical</c> at VerticalIdSource
		///</summary>
		[ChildEntityType(typeof(Vertical))]
		Vertical,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
	
		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for CustomerDocumentCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerDocument>))]
		CustomerDocumentCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for ProductRateValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRateValue>))]
		ProductRateValueCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for Customer_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer_Feature>))]
		Customer_FeatureCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for CommissionCustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<CommissionCustomer>))]
		CommissionCustomerCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for CustomerTransactionCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransaction>))]
		CustomerTransactionCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for ParticipantListCollection
		///</summary>
		[ChildEntityType(typeof(TList<ParticipantList>))]
		ParticipantListCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for DepartmentCollection
		///</summary>
		[ChildEntityType(typeof(TList<Department>))]
		DepartmentCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for Customer_DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer_Dnis>))]
		Customer_DnisCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for InvoiceSummaryCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceSummary>))]
		InvoiceSummaryCollection,

		///<summary>
		/// Collection of <c>Customer</c> as ManyToMany for DnisCollection_From_Customer_Dnis
		///</summary>
		[ChildEntityType(typeof(TList<Dnis>))]
		DnisidDnisCollection_From_Customer_Dnis,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for TicketCollection
		///</summary>
		[ChildEntityType(typeof(TList<Ticket>))]
		TicketCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for CommissionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Commission>))]
		CommissionCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for EventManagerCollection
		///</summary>
		[ChildEntityType(typeof(TList<EventManager>))]
		EventManagerCollection,

		///<summary>
		/// Collection of <c>Customer</c> as OneToMany for ModeratorCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator>))]
		ModeratorCollection,
	}
	
	#endregion CustomerChildEntityTypes
	
	#region CustomerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerFilterBuilder : SqlFilterBuilder<CustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		public CustomerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerFilterBuilder
	
	#region CustomerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerParameterBuilder : ParameterizedSqlFilterBuilder<CustomerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		public CustomerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerParameterBuilder
} // end namespace
