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
	/// This class is the base class for any <see cref="WholesalerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WholesalerProviderBaseCore : EntityProviderBase<CONFDB.Entities.Wholesaler, CONFDB.Entities.WholesalerKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByLanguageIdFromIrWholesaler
		
		/// <summary>
		///		Gets Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of Wholesaler objects.</returns>
		public TList<Wholesaler> GetByLanguageIdFromIrWholesaler(System.String _languageId)
		{
			int count = -1;
			return GetByLanguageIdFromIrWholesaler(null,_languageId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Wholesaler objects.</returns>
		public TList<Wholesaler> GetByLanguageIdFromIrWholesaler(System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageIdFromIrWholesaler(null, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Wholesaler objects.</returns>
		public TList<Wholesaler> GetByLanguageIdFromIrWholesaler(TransactionManager transactionManager, System.String _languageId)
		{
			int count = -1;
			return GetByLanguageIdFromIrWholesaler(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Wholesaler objects.</returns>
		public TList<Wholesaler> GetByLanguageIdFromIrWholesaler(TransactionManager transactionManager, System.String _languageId,int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageIdFromIrWholesaler(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Wholesaler objects.</returns>
		public TList<Wholesaler> GetByLanguageIdFromIrWholesaler(System.String _languageId,int start, int pageLength, out int count)
		{
			
			return GetByLanguageIdFromIrWholesaler(null, _languageId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Wholesaler objects from the datasource by LanguageID in the
		///		IRWholesaler table. Table Wholesaler is related to table Language
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Wholesaler objects.</returns>
		public abstract TList<Wholesaler> GetByLanguageIdFromIrWholesaler(TransactionManager transactionManager,System.String _languageId, int start, int pageLength, out int count);
		
		#endregion GetByLanguageIdFromIrWholesaler
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.WholesalerKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _id)
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
		public abstract bool Delete(TransactionManager transactionManager, System.String _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		Currency_Wholesaler_FK1 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		Currency_Wholesaler_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		Currency_Wholesaler_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		currency_Wholesaler_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(System.String _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		currency_Wholesaler_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(System.String _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_Wholesaler_FK1 key.
		///		Currency_Wholesaler_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler> GetByCurrencyId(TransactionManager transactionManager, System.String _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		FK_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="_billingCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(System.String _billingCountry)
		{
			int count = -1;
			return GetByBillingCountry(_billingCountry, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		FK_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingCountry"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(TransactionManager transactionManager, System.String _billingCountry)
		{
			int count = -1;
			return GetByBillingCountry(transactionManager, _billingCountry, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		FK_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(TransactionManager transactionManager, System.String _billingCountry, int start, int pageLength)
		{
			int count = -1;
			return GetByBillingCountry(transactionManager, _billingCountry, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		fk_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingCountry"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(System.String _billingCountry, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillingCountry(null, _billingCountry, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		fk_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingCountry"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(System.String _billingCountry, int start, int pageLength,out int count)
		{
			return GetByBillingCountry(null, _billingCountry, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Country key.
		///		FK_Wholesaler_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingCountry"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler> GetByBillingCountry(TransactionManager transactionManager, System.String _billingCountry, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		FK_Wholesaler_State Description: 
		/// </summary>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(System.String _billingRegion)
		{
			int count = -1;
			return GetByBillingRegion(_billingRegion, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		FK_Wholesaler_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(TransactionManager transactionManager, System.String _billingRegion)
		{
			int count = -1;
			return GetByBillingRegion(transactionManager, _billingRegion, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		FK_Wholesaler_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(TransactionManager transactionManager, System.String _billingRegion, int start, int pageLength)
		{
			int count = -1;
			return GetByBillingRegion(transactionManager, _billingRegion, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		fk_Wholesaler_State Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(System.String _billingRegion, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillingRegion(null, _billingRegion, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		fk_Wholesaler_State Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(System.String _billingRegion, int start, int pageLength,out int count)
		{
			return GetByBillingRegion(null, _billingRegion, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_State key.
		///		FK_Wholesaler_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingRegion">State, Province, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler> GetByBillingRegion(TransactionManager transactionManager, System.String _billingRegion, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		FK_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByTaxableId(System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(_taxableId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		FK_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		FK_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		fk_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTaxableId(null, _taxableId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		fk_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public CONFDB.Entities.TList<Wholesaler> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength,out int count)
		{
			return GetByTaxableId(null, _taxableId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Wholesaler_Taxable key.
		///		FK_Wholesaler_Taxable Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Wholesaler Get(TransactionManager transactionManager, CONFDB.Entities.WholesalerKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Wholesaler_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public CONFDB.Entities.Wholesaler GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public CONFDB.Entities.Wholesaler GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public CONFDB.Entities.Wholesaler GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public CONFDB.Entities.Wholesaler GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public CONFDB.Entities.Wholesaler GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler"/> class.</returns>
		public abstract CONFDB.Entities.Wholesaler GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_Wholesaler_Product_InstallDefaults 
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_Product_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="wholesaler_ProductId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Product_InstallDefaults(System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 Product_InstallDefaults(null, 0, int.MaxValue , wholesaler_ProductId, productId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_Product_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="wholesaler_ProductId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Product_InstallDefaults(int start, int pageLength, System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 Product_InstallDefaults(null, start, pageLength , wholesaler_ProductId, productId, wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Wholesaler_Product_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="wholesaler_ProductId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Product_InstallDefaults(TransactionManager transactionManager, System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 Product_InstallDefaults(transactionManager, 0, int.MaxValue , wholesaler_ProductId, productId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_Product_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="wholesaler_ProductId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Product_InstallDefaults(TransactionManager transactionManager, int start, int pageLength , System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId);
		
		#endregion
		
		#region p_Wholesaler_UpdateProductFeature 
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_UpdateProductFeature' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="wholesaler_Product_FeatureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateCustomers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateProductFeature(System.String wholesalerId, System.Int32? wholesaler_Product_FeatureId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateCustomers, System.Boolean? updateModerators)
		{
			 UpdateProductFeature(null, 0, int.MaxValue , wholesalerId, wholesaler_Product_FeatureId, featureId, featureOptionId, featureOptionValue, updateCustomers, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_UpdateProductFeature' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="wholesaler_Product_FeatureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateCustomers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateProductFeature(int start, int pageLength, System.String wholesalerId, System.Int32? wholesaler_Product_FeatureId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateCustomers, System.Boolean? updateModerators)
		{
			 UpdateProductFeature(null, start, pageLength , wholesalerId, wholesaler_Product_FeatureId, featureId, featureOptionId, featureOptionValue, updateCustomers, updateModerators);
		}
				
		/// <summary>
		///	This method wrap the 'p_Wholesaler_UpdateProductFeature' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="wholesaler_Product_FeatureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateCustomers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateProductFeature(TransactionManager transactionManager, System.String wholesalerId, System.Int32? wholesaler_Product_FeatureId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateCustomers, System.Boolean? updateModerators)
		{
			 UpdateProductFeature(transactionManager, 0, int.MaxValue , wholesalerId, wholesaler_Product_FeatureId, featureId, featureOptionId, featureOptionValue, updateCustomers, updateModerators);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_UpdateProductFeature' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="wholesaler_Product_FeatureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionValue"> A <c>System.String</c> instance.</param>
		/// <param name="updateCustomers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerators"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateProductFeature(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? wholesaler_Product_FeatureId, System.Int32? featureId, System.Int32? featureOptionId, System.String featureOptionValue, System.Boolean? updateCustomers, System.Boolean? updateModerators);
		
		#endregion
		
		#region p_Wholesaler_GetProductRates 
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(System.String wholesalerId)
		{
			return GetProductRates(null, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(int start, int pageLength, System.String wholesalerId)
		{
			return GetProductRates(null, start, pageLength , wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductRates(TransactionManager transactionManager, System.String wholesalerId)
		{
			return GetProductRates(transactionManager, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductRates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductRates(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId);
		
		#endregion
		
		#region p_Wholesaler_GetProductFeatures 
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(System.String wholesalerId)
		{
			return GetProductFeatures(null, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(int start, int pageLength, System.String wholesalerId)
		{
			return GetProductFeatures(null, start, pageLength , wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetProductFeatures(TransactionManager transactionManager, System.String wholesalerId)
		{
			return GetProductFeatures(transactionManager, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_Wholesaler_GetProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetProductFeatures(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Wholesaler&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Wholesaler&gt;"/></returns>
		public static CONFDB.Entities.TList<Wholesaler> Fill(IDataReader reader, CONFDB.Entities.TList<Wholesaler> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Wholesaler c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Wholesaler")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.WholesalerColumn.Id - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.WholesalerColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Wholesaler>(
					key.ToString(), // EntityTrackingKey
					"Wholesaler",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Wholesaler();
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
					c.Id = (System.String)reader[((int)WholesalerColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.CompanyName = (reader.IsDBNull(((int)WholesalerColumn.CompanyName - 1)))?null:(System.String)reader[((int)WholesalerColumn.CompanyName - 1)];
					c.CompanyShortName = (reader.IsDBNull(((int)WholesalerColumn.CompanyShortName - 1)))?null:(System.String)reader[((int)WholesalerColumn.CompanyShortName - 1)];
					c.RetailPriCustomerNumber = (reader.IsDBNull(((int)WholesalerColumn.RetailPriCustomerNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.RetailPriCustomerNumber - 1)];
					c.RetailPriCustomerNumberLikeExp = (reader.IsDBNull(((int)WholesalerColumn.RetailPriCustomerNumberLikeExp - 1)))?null:(System.String)reader[((int)WholesalerColumn.RetailPriCustomerNumberLikeExp - 1)];
					c.DefaultModCodeLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultModCodeLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultModCodeLength - 1)];
					c.DefaultPassCodeLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultPassCodeLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultPassCodeLength - 1)];
					c.DefaultPasswordLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultPasswordLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultPasswordLength - 1)];
					c.DefaultCapsOk = (reader.IsDBNull(((int)WholesalerColumn.DefaultCapsOk - 1)))?null:(System.Boolean?)reader[((int)WholesalerColumn.DefaultCapsOk - 1)];
					c.ModeratorTxt = (reader.IsDBNull(((int)WholesalerColumn.ModeratorTxt - 1)))?null:(System.String)reader[((int)WholesalerColumn.ModeratorTxt - 1)];
					c.ParticipantTxt = (reader.IsDBNull(((int)WholesalerColumn.ParticipantTxt - 1)))?null:(System.String)reader[((int)WholesalerColumn.ParticipantTxt - 1)];
					c.Enabled = (reader.IsDBNull(((int)WholesalerColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)WholesalerColumn.Enabled - 1)];
					c.CustomerNumberExceptionList = (reader.IsDBNull(((int)WholesalerColumn.CustomerNumberExceptionList - 1)))?null:(System.String)reader[((int)WholesalerColumn.CustomerNumberExceptionList - 1)];
					c.WebProductProviderName = (reader.IsDBNull(((int)WholesalerColumn.WebProductProviderName - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebProductProviderName - 1)];
					c.WebProductProviderBranding = (reader.IsDBNull(((int)WholesalerColumn.WebProductProviderBranding - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebProductProviderBranding - 1)];
					c.WebSecProductProvider = (reader.IsDBNull(((int)WholesalerColumn.WebSecProductProvider - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebSecProductProvider - 1)];
					c.CurrencyId = (reader.IsDBNull(((int)WholesalerColumn.CurrencyId - 1)))?null:(System.String)reader[((int)WholesalerColumn.CurrencyId - 1)];
					c.BillingWholesalerId = (reader.IsDBNull(((int)WholesalerColumn.BillingWholesalerId - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingWholesalerId - 1)];
					c.BillingCustomerNumber = (reader.IsDBNull(((int)WholesalerColumn.BillingCustomerNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCustomerNumber - 1)];
					c.TaxableId = (System.Int32)reader[((int)WholesalerColumn.TaxableId - 1)];
					c.WebSiteUrl = (reader.IsDBNull(((int)WholesalerColumn.WebSiteUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebSiteUrl - 1)];
					c.AdminSiteUrl = (reader.IsDBNull(((int)WholesalerColumn.AdminSiteUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.AdminSiteUrl - 1)];
					c.AdminSiteIp = (reader.IsDBNull(((int)WholesalerColumn.AdminSiteIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.AdminSiteIp - 1)];
					c.SelfServeUrl = (reader.IsDBNull(((int)WholesalerColumn.SelfServeUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.SelfServeUrl - 1)];
					c.SelfServeIp = (reader.IsDBNull(((int)WholesalerColumn.SelfServeIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.SelfServeIp - 1)];
					c.WebConferencingUrl = (reader.IsDBNull(((int)WholesalerColumn.WebConferencingUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebConferencingUrl - 1)];
					c.WebConferencingIp = (reader.IsDBNull(((int)WholesalerColumn.WebConferencingIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebConferencingIp - 1)];
					c.SupportEmail = (reader.IsDBNull(((int)WholesalerColumn.SupportEmail - 1)))?null:(System.String)reader[((int)WholesalerColumn.SupportEmail - 1)];
					c.SupportPhoneNumber = (reader.IsDBNull(((int)WholesalerColumn.SupportPhoneNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.SupportPhoneNumber - 1)];
					c.DoRetailBilling = (System.Boolean)reader[((int)WholesalerColumn.DoRetailBilling - 1)];
					c.CommissionLockDate = (reader.IsDBNull(((int)WholesalerColumn.CommissionLockDate - 1)))?null:(System.DateTime?)reader[((int)WholesalerColumn.CommissionLockDate - 1)];
					c.PortalId = (reader.IsDBNull(((int)WholesalerColumn.PortalId - 1)))?null:(System.Int32?)reader[((int)WholesalerColumn.PortalId - 1)];
					c.BillingAddress1 = (reader.IsDBNull(((int)WholesalerColumn.BillingAddress1 - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingAddress1 - 1)];
					c.BillingAddress2 = (reader.IsDBNull(((int)WholesalerColumn.BillingAddress2 - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingAddress2 - 1)];
					c.BillingCity = (reader.IsDBNull(((int)WholesalerColumn.BillingCity - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCity - 1)];
					c.BillingCountry = (reader.IsDBNull(((int)WholesalerColumn.BillingCountry - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCountry - 1)];
					c.BillingRegion = (reader.IsDBNull(((int)WholesalerColumn.BillingRegion - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingRegion - 1)];
					c.BillingPostalCode = (reader.IsDBNull(((int)WholesalerColumn.BillingPostalCode - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingPostalCode - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Wholesaler"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Wholesaler entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)WholesalerColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["ID"];
			entity.CompanyName = (reader.IsDBNull(((int)WholesalerColumn.CompanyName - 1)))?null:(System.String)reader[((int)WholesalerColumn.CompanyName - 1)];
			entity.CompanyShortName = (reader.IsDBNull(((int)WholesalerColumn.CompanyShortName - 1)))?null:(System.String)reader[((int)WholesalerColumn.CompanyShortName - 1)];
			entity.RetailPriCustomerNumber = (reader.IsDBNull(((int)WholesalerColumn.RetailPriCustomerNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.RetailPriCustomerNumber - 1)];
			entity.RetailPriCustomerNumberLikeExp = (reader.IsDBNull(((int)WholesalerColumn.RetailPriCustomerNumberLikeExp - 1)))?null:(System.String)reader[((int)WholesalerColumn.RetailPriCustomerNumberLikeExp - 1)];
			entity.DefaultModCodeLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultModCodeLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultModCodeLength - 1)];
			entity.DefaultPassCodeLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultPassCodeLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultPassCodeLength - 1)];
			entity.DefaultPasswordLength = (reader.IsDBNull(((int)WholesalerColumn.DefaultPasswordLength - 1)))?null:(System.Byte?)reader[((int)WholesalerColumn.DefaultPasswordLength - 1)];
			entity.DefaultCapsOk = (reader.IsDBNull(((int)WholesalerColumn.DefaultCapsOk - 1)))?null:(System.Boolean?)reader[((int)WholesalerColumn.DefaultCapsOk - 1)];
			entity.ModeratorTxt = (reader.IsDBNull(((int)WholesalerColumn.ModeratorTxt - 1)))?null:(System.String)reader[((int)WholesalerColumn.ModeratorTxt - 1)];
			entity.ParticipantTxt = (reader.IsDBNull(((int)WholesalerColumn.ParticipantTxt - 1)))?null:(System.String)reader[((int)WholesalerColumn.ParticipantTxt - 1)];
			entity.Enabled = (reader.IsDBNull(((int)WholesalerColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)WholesalerColumn.Enabled - 1)];
			entity.CustomerNumberExceptionList = (reader.IsDBNull(((int)WholesalerColumn.CustomerNumberExceptionList - 1)))?null:(System.String)reader[((int)WholesalerColumn.CustomerNumberExceptionList - 1)];
			entity.WebProductProviderName = (reader.IsDBNull(((int)WholesalerColumn.WebProductProviderName - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebProductProviderName - 1)];
			entity.WebProductProviderBranding = (reader.IsDBNull(((int)WholesalerColumn.WebProductProviderBranding - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebProductProviderBranding - 1)];
			entity.WebSecProductProvider = (reader.IsDBNull(((int)WholesalerColumn.WebSecProductProvider - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebSecProductProvider - 1)];
			entity.CurrencyId = (reader.IsDBNull(((int)WholesalerColumn.CurrencyId - 1)))?null:(System.String)reader[((int)WholesalerColumn.CurrencyId - 1)];
			entity.BillingWholesalerId = (reader.IsDBNull(((int)WholesalerColumn.BillingWholesalerId - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingWholesalerId - 1)];
			entity.BillingCustomerNumber = (reader.IsDBNull(((int)WholesalerColumn.BillingCustomerNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCustomerNumber - 1)];
			entity.TaxableId = (System.Int32)reader[((int)WholesalerColumn.TaxableId - 1)];
			entity.WebSiteUrl = (reader.IsDBNull(((int)WholesalerColumn.WebSiteUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebSiteUrl - 1)];
			entity.AdminSiteUrl = (reader.IsDBNull(((int)WholesalerColumn.AdminSiteUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.AdminSiteUrl - 1)];
			entity.AdminSiteIp = (reader.IsDBNull(((int)WholesalerColumn.AdminSiteIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.AdminSiteIp - 1)];
			entity.SelfServeUrl = (reader.IsDBNull(((int)WholesalerColumn.SelfServeUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.SelfServeUrl - 1)];
			entity.SelfServeIp = (reader.IsDBNull(((int)WholesalerColumn.SelfServeIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.SelfServeIp - 1)];
			entity.WebConferencingUrl = (reader.IsDBNull(((int)WholesalerColumn.WebConferencingUrl - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebConferencingUrl - 1)];
			entity.WebConferencingIp = (reader.IsDBNull(((int)WholesalerColumn.WebConferencingIp - 1)))?null:(System.String)reader[((int)WholesalerColumn.WebConferencingIp - 1)];
			entity.SupportEmail = (reader.IsDBNull(((int)WholesalerColumn.SupportEmail - 1)))?null:(System.String)reader[((int)WholesalerColumn.SupportEmail - 1)];
			entity.SupportPhoneNumber = (reader.IsDBNull(((int)WholesalerColumn.SupportPhoneNumber - 1)))?null:(System.String)reader[((int)WholesalerColumn.SupportPhoneNumber - 1)];
			entity.DoRetailBilling = (System.Boolean)reader[((int)WholesalerColumn.DoRetailBilling - 1)];
			entity.CommissionLockDate = (reader.IsDBNull(((int)WholesalerColumn.CommissionLockDate - 1)))?null:(System.DateTime?)reader[((int)WholesalerColumn.CommissionLockDate - 1)];
			entity.PortalId = (reader.IsDBNull(((int)WholesalerColumn.PortalId - 1)))?null:(System.Int32?)reader[((int)WholesalerColumn.PortalId - 1)];
			entity.BillingAddress1 = (reader.IsDBNull(((int)WholesalerColumn.BillingAddress1 - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingAddress1 - 1)];
			entity.BillingAddress2 = (reader.IsDBNull(((int)WholesalerColumn.BillingAddress2 - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingAddress2 - 1)];
			entity.BillingCity = (reader.IsDBNull(((int)WholesalerColumn.BillingCity - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCity - 1)];
			entity.BillingCountry = (reader.IsDBNull(((int)WholesalerColumn.BillingCountry - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingCountry - 1)];
			entity.BillingRegion = (reader.IsDBNull(((int)WholesalerColumn.BillingRegion - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingRegion - 1)];
			entity.BillingPostalCode = (reader.IsDBNull(((int)WholesalerColumn.BillingPostalCode - 1)))?null:(System.String)reader[((int)WholesalerColumn.BillingPostalCode - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Wholesaler"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Wholesaler entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["ID"];
			entity.OriginalId = (System.String)dataRow["ID"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.CompanyShortName = Convert.IsDBNull(dataRow["CompanyShortName"]) ? null : (System.String)dataRow["CompanyShortName"];
			entity.RetailPriCustomerNumber = Convert.IsDBNull(dataRow["RetailPriCustomerNumber"]) ? null : (System.String)dataRow["RetailPriCustomerNumber"];
			entity.RetailPriCustomerNumberLikeExp = Convert.IsDBNull(dataRow["RetailPriCustomerNumberLIKEExp"]) ? null : (System.String)dataRow["RetailPriCustomerNumberLIKEExp"];
			entity.DefaultModCodeLength = Convert.IsDBNull(dataRow["DefaultModCodeLength"]) ? null : (System.Byte?)dataRow["DefaultModCodeLength"];
			entity.DefaultPassCodeLength = Convert.IsDBNull(dataRow["DefaultPassCodeLength"]) ? null : (System.Byte?)dataRow["DefaultPassCodeLength"];
			entity.DefaultPasswordLength = Convert.IsDBNull(dataRow["DefaultPasswordLength"]) ? null : (System.Byte?)dataRow["DefaultPasswordLength"];
			entity.DefaultCapsOk = Convert.IsDBNull(dataRow["DefaultCapsOK"]) ? null : (System.Boolean?)dataRow["DefaultCapsOK"];
			entity.ModeratorTxt = Convert.IsDBNull(dataRow["ModeratorTxt"]) ? null : (System.String)dataRow["ModeratorTxt"];
			entity.ParticipantTxt = Convert.IsDBNull(dataRow["ParticipantTxt"]) ? null : (System.String)dataRow["ParticipantTxt"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.CustomerNumberExceptionList = Convert.IsDBNull(dataRow["CustomerNumberExceptionList"]) ? null : (System.String)dataRow["CustomerNumberExceptionList"];
			entity.WebProductProviderName = Convert.IsDBNull(dataRow["WebProductProviderName"]) ? null : (System.String)dataRow["WebProductProviderName"];
			entity.WebProductProviderBranding = Convert.IsDBNull(dataRow["WebProductProviderBranding"]) ? null : (System.String)dataRow["WebProductProviderBranding"];
			entity.WebSecProductProvider = Convert.IsDBNull(dataRow["WebSecProductProvider"]) ? null : (System.String)dataRow["WebSecProductProvider"];
			entity.CurrencyId = Convert.IsDBNull(dataRow["CurrencyID"]) ? null : (System.String)dataRow["CurrencyID"];
			entity.BillingWholesalerId = Convert.IsDBNull(dataRow["BillingWholesalerID"]) ? null : (System.String)dataRow["BillingWholesalerID"];
			entity.BillingCustomerNumber = Convert.IsDBNull(dataRow["BillingCustomerNumber"]) ? null : (System.String)dataRow["BillingCustomerNumber"];
			entity.TaxableId = (System.Int32)dataRow["TaxableID"];
			entity.WebSiteUrl = Convert.IsDBNull(dataRow["WebSiteURL"]) ? null : (System.String)dataRow["WebSiteURL"];
			entity.AdminSiteUrl = Convert.IsDBNull(dataRow["AdminSiteURL"]) ? null : (System.String)dataRow["AdminSiteURL"];
			entity.AdminSiteIp = Convert.IsDBNull(dataRow["AdminSiteIP"]) ? null : (System.String)dataRow["AdminSiteIP"];
			entity.SelfServeUrl = Convert.IsDBNull(dataRow["SelfServeURL"]) ? null : (System.String)dataRow["SelfServeURL"];
			entity.SelfServeIp = Convert.IsDBNull(dataRow["SelfServeIP"]) ? null : (System.String)dataRow["SelfServeIP"];
			entity.WebConferencingUrl = Convert.IsDBNull(dataRow["WebConferencingURL"]) ? null : (System.String)dataRow["WebConferencingURL"];
			entity.WebConferencingIp = Convert.IsDBNull(dataRow["WebConferencingIP"]) ? null : (System.String)dataRow["WebConferencingIP"];
			entity.SupportEmail = Convert.IsDBNull(dataRow["SupportEmail"]) ? null : (System.String)dataRow["SupportEmail"];
			entity.SupportPhoneNumber = Convert.IsDBNull(dataRow["SupportPhoneNumber"]) ? null : (System.String)dataRow["SupportPhoneNumber"];
			entity.DoRetailBilling = (System.Boolean)dataRow["DoRetailBilling"];
			entity.CommissionLockDate = Convert.IsDBNull(dataRow["CommissionLockDate"]) ? null : (System.DateTime?)dataRow["CommissionLockDate"];
			entity.PortalId = Convert.IsDBNull(dataRow["PortalID"]) ? null : (System.Int32?)dataRow["PortalID"];
			entity.BillingAddress1 = Convert.IsDBNull(dataRow["BillingAddress1"]) ? null : (System.String)dataRow["BillingAddress1"];
			entity.BillingAddress2 = Convert.IsDBNull(dataRow["BillingAddress2"]) ? null : (System.String)dataRow["BillingAddress2"];
			entity.BillingCity = Convert.IsDBNull(dataRow["BillingCity"]) ? null : (System.String)dataRow["BillingCity"];
			entity.BillingCountry = Convert.IsDBNull(dataRow["BillingCountry"]) ? null : (System.String)dataRow["BillingCountry"];
			entity.BillingRegion = Convert.IsDBNull(dataRow["BillingRegion"]) ? null : (System.String)dataRow["BillingRegion"];
			entity.BillingPostalCode = Convert.IsDBNull(dataRow["BillingPostalCode"]) ? null : (System.String)dataRow["BillingPostalCode"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Wholesaler Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Wholesaler entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CurrencyIdSource	
			if (CanDeepLoad(entity, "Currency|CurrencyIdSource", deepLoadType, innerList) 
				&& entity.CurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CurrencyId ?? string.Empty);
				Currency tmpEntity = EntityManager.LocateEntity<Currency>(EntityLocator.ConstructKeyFromPkItems(typeof(Currency), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyIdSource = tmpEntity;
				else
					entity.CurrencyIdSource = DataRepository.CurrencyProvider.GetById(transactionManager, (entity.CurrencyId ?? string.Empty));		
				
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

			#region BillingCountrySource	
			if (CanDeepLoad(entity, "Country|BillingCountrySource", deepLoadType, innerList) 
				&& entity.BillingCountrySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BillingCountry ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillingCountrySource = tmpEntity;
				else
					entity.BillingCountrySource = DataRepository.CountryProvider.GetById(transactionManager, (entity.BillingCountry ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillingCountrySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillingCountrySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.BillingCountrySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillingCountrySource

			#region BillingRegionSource	
			if (CanDeepLoad(entity, "State|BillingRegionSource", deepLoadType, innerList) 
				&& entity.BillingRegionSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BillingRegion ?? string.Empty);
				State tmpEntity = EntityManager.LocateEntity<State>(EntityLocator.ConstructKeyFromPkItems(typeof(State), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillingRegionSource = tmpEntity;
				else
					entity.BillingRegionSource = DataRepository.StateProvider.GetById(transactionManager, (entity.BillingRegion ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillingRegionSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillingRegionSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvider.DeepLoad(transactionManager, entity.BillingRegionSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillingRegionSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region VerticalCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Vertical>|VerticalCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'VerticalCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.VerticalCollection = DataRepository.VerticalProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.VerticalCollection.Count > 0)
				{
					deepHandles.Add("VerticalCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Vertical>) DataRepository.VerticalProvider.DeepLoad,
						new object[] { transactionManager, entity.VerticalCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LanguageIdLanguageCollection_From_IrWholesaler
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Language>|LanguageIdLanguageCollection_From_IrWholesaler", deepLoadType, innerList))
			{
				entity.LanguageIdLanguageCollection_From_IrWholesaler = DataRepository.LanguageProvider.GetByWholesalerIdFromIrWholesaler(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdLanguageCollection_From_IrWholesaler' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdLanguageCollection_From_IrWholesaler != null)
				{
					deepHandles.Add("LanguageIdLanguageCollection_From_IrWholesaler",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Language >) DataRepository.LanguageProvider.DeepLoad,
						new object[] { transactionManager, entity.LanguageIdLanguageCollection_From_IrWholesaler, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerTransactionCollection = DataRepository.CustomerTransactionProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CustomerTransactionCollection.Count > 0)
				{
					deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerTransaction>) DataRepository.CustomerTransactionProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTransactionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerDocumentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerDocument>|CustomerDocumentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerDocumentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerDocumentCollection = DataRepository.CustomerDocumentProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CustomerDocumentCollection.Count > 0)
				{
					deepHandles.Add("CustomerDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerDocument>) DataRepository.CustomerDocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerDocumentCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CommissionCustomerCollection = DataRepository.CommissionCustomerProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CommissionCustomerCollection.Count > 0)
				{
					deepHandles.Add("CommissionCustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CommissionCustomer>) DataRepository.CommissionCustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCustomerCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CommissionCollection = DataRepository.CommissionProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CommissionCollection.Count > 0)
				{
					deepHandles.Add("CommissionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Commission>) DataRepository.CommissionProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmailTemplateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmailTemplate>|EmailTemplateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailTemplateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmailTemplateCollection = DataRepository.EmailTemplateProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.EmailTemplateCollection.Count > 0)
				{
					deepHandles.Add("EmailTemplateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmailTemplate>) DataRepository.EmailTemplateProvider.DeepLoad,
						new object[] { transactionManager, entity.EmailTemplateCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.RatedCdrCollection = DataRepository.RatedCdrProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.RatedCdrCollection.Count > 0)
				{
					deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RatedCdr>) DataRepository.RatedCdrProvider.DeepLoad,
						new object[] { transactionManager, entity.RatedCdrCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Wholesaler_ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Wholesaler_Product>|Wholesaler_ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Wholesaler_ProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Wholesaler_ProductCollection = DataRepository.Wholesaler_ProductProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.Wholesaler_ProductCollection.Count > 0)
				{
					deepHandles.Add("Wholesaler_ProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler_Product>) DataRepository.Wholesaler_ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.Wholesaler_ProductCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AccountManagerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AccountManager>|AccountManagerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccountManagerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AccountManagerCollection = DataRepository.AccountManagerProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.AccountManagerCollection.Count > 0)
				{
					deepHandles.Add("AccountManagerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AccountManager>) DataRepository.AccountManagerProvider.DeepLoad,
						new object[] { transactionManager, entity.AccountManagerCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.ProductRateValueCollection = DataRepository.ProductRateValueProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.ProductRateValueCollection.Count > 0)
				{
					deepHandles.Add("ProductRateValueCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRateValue>) DataRepository.ProductRateValueProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateValueCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Dnis>|DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DnisCollection = DataRepository.DnisProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.DnisCollection.Count > 0)
				{
					deepHandles.Add("DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Dnis>) DataRepository.DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.DnisCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollection = DataRepository.CustomerProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CustomerCollection.Count > 0)
				{
					deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region IrWholesalerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<IrWholesaler>|IrWholesalerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IrWholesalerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IrWholesalerCollection = DataRepository.IrWholesalerProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.IrWholesalerCollection.Count > 0)
				{
					deepHandles.Add("IrWholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<IrWholesaler>) DataRepository.IrWholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.IrWholesalerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LeadCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lead>|LeadCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LeadCollection = DataRepository.LeadProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.LeadCollection.Count > 0)
				{
					deepHandles.Add("LeadCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lead>) DataRepository.LeadProvider.DeepLoad,
						new object[] { transactionManager, entity.LeadCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesPersonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesPerson>|SalesPersonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesPersonCollection = DataRepository.SalesPersonProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.SalesPersonCollection.Count > 0)
				{
					deepHandles.Add("SalesPersonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesPerson>) DataRepository.SalesPersonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesPersonCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.DepartmentCollection = DataRepository.DepartmentProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.DepartmentCollection.Count > 0)
				{
					deepHandles.Add("DepartmentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Department>) DataRepository.DepartmentProvider.DeepLoad,
						new object[] { transactionManager, entity.DepartmentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CompanyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Company>|CompanyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CompanyCollection = DataRepository.CompanyProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.CompanyCollection.Count > 0)
				{
					deepHandles.Add("CompanyCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Company>) DataRepository.CompanyProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.TicketCollection = DataRepository.TicketProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.TicketCollection.Count > 0)
				{
					deepHandles.Add("TicketCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Ticket>) DataRepository.TicketProvider.DeepLoad,
						new object[] { transactionManager, entity.TicketCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MarketingServiceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MarketingService>|MarketingServiceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MarketingServiceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MarketingServiceCollection = DataRepository.MarketingServiceProvider.GetByWholesalerId(transactionManager, entity.Id);

				if (deep && entity.MarketingServiceCollection.Count > 0)
				{
					deepHandles.Add("MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MarketingService>) DataRepository.MarketingServiceProvider.DeepLoad,
						new object[] { transactionManager, entity.MarketingServiceCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Wholesaler object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Wholesaler instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Wholesaler Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Wholesaler entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region BillingCountrySource
			if (CanDeepSave(entity, "Country|BillingCountrySource", deepSaveType, innerList) 
				&& entity.BillingCountrySource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.BillingCountrySource);
				entity.BillingCountry = entity.BillingCountrySource.Id;
			}
			#endregion 
			
			#region BillingRegionSource
			if (CanDeepSave(entity, "State|BillingRegionSource", deepSaveType, innerList) 
				&& entity.BillingRegionSource != null)
			{
				DataRepository.StateProvider.Save(transactionManager, entity.BillingRegionSource);
				entity.BillingRegion = entity.BillingRegionSource.Id;
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region LanguageIdLanguageCollection_From_IrWholesaler>
			if (CanDeepSave(entity.LanguageIdLanguageCollection_From_IrWholesaler, "List<Language>|LanguageIdLanguageCollection_From_IrWholesaler", deepSaveType, innerList))
			{
				if (entity.LanguageIdLanguageCollection_From_IrWholesaler.Count > 0 || entity.LanguageIdLanguageCollection_From_IrWholesaler.DeletedItems.Count > 0)
				{
					DataRepository.LanguageProvider.Save(transactionManager, entity.LanguageIdLanguageCollection_From_IrWholesaler); 
					deepHandles.Add("LanguageIdLanguageCollection_From_IrWholesaler",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Language>) DataRepository.LanguageProvider.DeepSave,
						new object[] { transactionManager, entity.LanguageIdLanguageCollection_From_IrWholesaler, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Vertical>
				if (CanDeepSave(entity.VerticalCollection, "List<Vertical>|VerticalCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Vertical child in entity.VerticalCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.VerticalCollection.Count > 0 || entity.VerticalCollection.DeletedItems.Count > 0)
					{
						//DataRepository.VerticalProvider.Save(transactionManager, entity.VerticalCollection);
						
						deepHandles.Add("VerticalCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Vertical >) DataRepository.VerticalProvider.DeepSave,
							new object[] { transactionManager, entity.VerticalCollection, deepSaveType, childTypes, innerList }
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
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<CustomerDocument>
				if (CanDeepSave(entity.CustomerDocumentCollection, "List<CustomerDocument>|CustomerDocumentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerDocument child in entity.CustomerDocumentCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<CommissionCustomer>
				if (CanDeepSave(entity.CommissionCustomerCollection, "List<CommissionCustomer>|CommissionCustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CommissionCustomer child in entity.CommissionCustomerCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<Commission>
				if (CanDeepSave(entity.CommissionCollection, "List<Commission>|CommissionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Commission child in entity.CommissionCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<EmailTemplate>
				if (CanDeepSave(entity.EmailTemplateCollection, "List<EmailTemplate>|EmailTemplateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmailTemplate child in entity.EmailTemplateCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.EmailTemplateCollection.Count > 0 || entity.EmailTemplateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmailTemplateProvider.Save(transactionManager, entity.EmailTemplateCollection);
						
						deepHandles.Add("EmailTemplateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmailTemplate >) DataRepository.EmailTemplateProvider.DeepSave,
							new object[] { transactionManager, entity.EmailTemplateCollection, deepSaveType, childTypes, innerList }
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
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<Wholesaler_Product>
				if (CanDeepSave(entity.Wholesaler_ProductCollection, "List<Wholesaler_Product>|Wholesaler_ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler_Product child in entity.Wholesaler_ProductCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.Wholesaler_ProductCollection.Count > 0 || entity.Wholesaler_ProductCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Wholesaler_ProductProvider.Save(transactionManager, entity.Wholesaler_ProductCollection);
						
						deepHandles.Add("Wholesaler_ProductCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Wholesaler_Product >) DataRepository.Wholesaler_ProductProvider.DeepSave,
							new object[] { transactionManager, entity.Wholesaler_ProductCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AccountManager>
				if (CanDeepSave(entity.AccountManagerCollection, "List<AccountManager>|AccountManagerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AccountManager child in entity.AccountManagerCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.AccountManagerCollection.Count > 0 || entity.AccountManagerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AccountManagerProvider.Save(transactionManager, entity.AccountManagerCollection);
						
						deepHandles.Add("AccountManagerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AccountManager >) DataRepository.AccountManagerProvider.DeepSave,
							new object[] { transactionManager, entity.AccountManagerCollection, deepSaveType, childTypes, innerList }
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
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<Dnis>
				if (CanDeepSave(entity.DnisCollection, "List<Dnis>|DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Dnis child in entity.DnisCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.DnisCollection.Count > 0 || entity.DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DnisProvider.Save(transactionManager, entity.DnisCollection);
						
						deepHandles.Add("DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Dnis >) DataRepository.DnisProvider.DeepSave,
							new object[] { transactionManager, entity.DnisCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollection, "List<Customer>|CustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.CustomerCollection.Count > 0 || entity.CustomerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollection);
						
						deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<IrWholesaler>
				if (CanDeepSave(entity.IrWholesalerCollection, "List<IrWholesaler>|IrWholesalerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(IrWholesaler child in entity.IrWholesalerCollection)
					{
						if(child.WholesalerIdSource != null)
						{
								child.WholesalerId = child.WholesalerIdSource.Id;
						}

						if(child.LanguageIdSource != null)
						{
								child.LanguageId = child.LanguageIdSource.Id;
						}

					}

					if (entity.IrWholesalerCollection.Count > 0 || entity.IrWholesalerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IrWholesalerProvider.Save(transactionManager, entity.IrWholesalerCollection);
						
						deepHandles.Add("IrWholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< IrWholesaler >) DataRepository.IrWholesalerProvider.DeepSave,
							new object[] { transactionManager, entity.IrWholesalerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Lead>
				if (CanDeepSave(entity.LeadCollection, "List<Lead>|LeadCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lead child in entity.LeadCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.LeadCollection.Count > 0 || entity.LeadCollection.DeletedItems.Count > 0)
					{
						//DataRepository.LeadProvider.Save(transactionManager, entity.LeadCollection);
						
						deepHandles.Add("LeadCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Lead >) DataRepository.LeadProvider.DeepSave,
							new object[] { transactionManager, entity.LeadCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesPerson>
				if (CanDeepSave(entity.SalesPersonCollection, "List<SalesPerson>|SalesPersonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesPerson child in entity.SalesPersonCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.SalesPersonCollection.Count > 0 || entity.SalesPersonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonCollection);
						
						deepHandles.Add("SalesPersonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesPerson >) DataRepository.SalesPersonProvider.DeepSave,
							new object[] { transactionManager, entity.SalesPersonCollection, deepSaveType, childTypes, innerList }
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
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<Company>
				if (CanDeepSave(entity.CompanyCollection, "List<Company>|CompanyCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Company child in entity.CompanyCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.CompanyCollection.Count > 0 || entity.CompanyCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CompanyProvider.Save(transactionManager, entity.CompanyCollection);
						
						deepHandles.Add("CompanyCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Company >) DataRepository.CompanyProvider.DeepSave,
							new object[] { transactionManager, entity.CompanyCollection, deepSaveType, childTypes, innerList }
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
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
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
				
	
			#region List<MarketingService>
				if (CanDeepSave(entity.MarketingServiceCollection, "List<MarketingService>|MarketingServiceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MarketingService child in entity.MarketingServiceCollection)
					{
						if(child.WholesalerIdSource != null)
						{
							child.WholesalerId = child.WholesalerIdSource.Id;
						}
						else
						{
							child.WholesalerId = entity.Id;
						}

					}

					if (entity.MarketingServiceCollection.Count > 0 || entity.MarketingServiceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MarketingServiceProvider.Save(transactionManager, entity.MarketingServiceCollection);
						
						deepHandles.Add("MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MarketingService >) DataRepository.MarketingServiceProvider.DeepSave,
							new object[] { transactionManager, entity.MarketingServiceCollection, deepSaveType, childTypes, innerList }
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
	
	#region WholesalerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Wholesaler</c>
	///</summary>
	public enum WholesalerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currency</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currency))]
		Currency,
			
		///<summary>
		/// Composite Property for <c>Country</c> at BillingCountrySource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
			
		///<summary>
		/// Composite Property for <c>State</c> at BillingRegionSource
		///</summary>
		[ChildEntityType(typeof(State))]
		State,
			
		///<summary>
		/// Composite Property for <c>Taxable</c> at TaxableIdSource
		///</summary>
		[ChildEntityType(typeof(Taxable))]
		Taxable,
	
		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for VerticalCollection
		///</summary>
		[ChildEntityType(typeof(TList<Vertical>))]
		VerticalCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as ManyToMany for LanguageCollection_From_IrWholesaler
		///</summary>
		[ChildEntityType(typeof(TList<Language>))]
		LanguageIdLanguageCollection_From_IrWholesaler,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CustomerTransactionCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransaction>))]
		CustomerTransactionCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CustomerDocumentCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerDocument>))]
		CustomerDocumentCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CommissionCustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<CommissionCustomer>))]
		CommissionCustomerCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CommissionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Commission>))]
		CommissionCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for EmailTemplateCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmailTemplate>))]
		EmailTemplateCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for RatedCdrCollection
		///</summary>
		[ChildEntityType(typeof(TList<RatedCdr>))]
		RatedCdrCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for Wholesaler_ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler_Product>))]
		Wholesaler_ProductCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for AccountManagerCollection
		///</summary>
		[ChildEntityType(typeof(TList<AccountManager>))]
		AccountManagerCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for ProductRateValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRateValue>))]
		ProductRateValueCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Dnis>))]
		DnisCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for IrWholesalerCollection
		///</summary>
		[ChildEntityType(typeof(TList<IrWholesaler>))]
		IrWholesalerCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for LeadCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lead>))]
		LeadCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for SalesPersonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesPerson>))]
		SalesPersonCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for DepartmentCollection
		///</summary>
		[ChildEntityType(typeof(TList<Department>))]
		DepartmentCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for CompanyCollection
		///</summary>
		[ChildEntityType(typeof(TList<Company>))]
		CompanyCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for TicketCollection
		///</summary>
		[ChildEntityType(typeof(TList<Ticket>))]
		TicketCollection,

		///<summary>
		/// Collection of <c>Wholesaler</c> as OneToMany for MarketingServiceCollection
		///</summary>
		[ChildEntityType(typeof(TList<MarketingService>))]
		MarketingServiceCollection,
	}
	
	#endregion WholesalerChildEntityTypes
	
	#region WholesalerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WholesalerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerFilterBuilder : SqlFilterBuilder<WholesalerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerFilterBuilder class.
		/// </summary>
		public WholesalerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WholesalerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WholesalerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WholesalerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WholesalerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WholesalerFilterBuilder
	
	#region WholesalerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WholesalerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WholesalerParameterBuilder : ParameterizedSqlFilterBuilder<WholesalerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WholesalerParameterBuilder class.
		/// </summary>
		public WholesalerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WholesalerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WholesalerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WholesalerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WholesalerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WholesalerParameterBuilder
} // end namespace
