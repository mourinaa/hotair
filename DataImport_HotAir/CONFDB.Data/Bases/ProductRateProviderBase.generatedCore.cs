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
	/// This class is the base class for any <see cref="ProductRateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductRateProviderBaseCore : EntityProviderBase<CONFDB.Entities.ProductRate, CONFDB.Entities.ProductRateKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ProductRateKey key)
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
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		Country_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByCountryId(System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		Country_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByCountryId(TransactionManager transactionManager, System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		Country_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		country_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByCountryId(System.String _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		country_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByCountryId(System.String _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_ProductRate_FK1 key.
		///		Country_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		FK_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(System.Int32 _ratingTypeId)
		{
			int count = -1;
			return GetByRatingTypeId(_ratingTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		FK_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(TransactionManager transactionManager, System.Int32 _ratingTypeId)
		{
			int count = -1;
			return GetByRatingTypeId(transactionManager, _ratingTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		FK_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(TransactionManager transactionManager, System.Int32 _ratingTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByRatingTypeId(transactionManager, _ratingTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		fk_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(System.Int32 _ratingTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRatingTypeId(null, _ratingTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		fk_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(System.Int32 _ratingTypeId, int start, int pageLength,out int count)
		{
			return GetByRatingTypeId(null, _ratingTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProductRate_RatingType key.
		///		FK_ProductRate_RatingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ratingTypeId">Used to simplify the rating of rates by provided a grouping mechanism as all CDR based rates are rated with either bridge, LD, Connect(Transport) rates or miscellaneous charges.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByRatingTypeId(TransactionManager transactionManager, System.Int32 _ratingTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		Product_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		Product_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		Product_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		product_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		product_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_ProductRate_FK1 key.
		///		Product_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		ProductRateInterval_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_productRateIntervalId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(System.Int32 _productRateIntervalId)
		{
			int count = -1;
			return GetByProductRateIntervalId(_productRateIntervalId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		ProductRateInterval_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateIntervalId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(TransactionManager transactionManager, System.Int32 _productRateIntervalId)
		{
			int count = -1;
			return GetByProductRateIntervalId(transactionManager, _productRateIntervalId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		ProductRateInterval_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateIntervalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(TransactionManager transactionManager, System.Int32 _productRateIntervalId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateIntervalId(transactionManager, _productRateIntervalId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		productRateInterval_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateIntervalId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(System.Int32 _productRateIntervalId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductRateIntervalId(null, _productRateIntervalId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		productRateInterval_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateIntervalId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(System.Int32 _productRateIntervalId, int start, int pageLength,out int count)
		{
			return GetByProductRateIntervalId(null, _productRateIntervalId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateInterval_ProductRate_FK1 key.
		///		ProductRateInterval_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateIntervalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByProductRateIntervalId(TransactionManager transactionManager, System.Int32 _productRateIntervalId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		ProductRateType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(System.Int32 _productRateTypeId)
		{
			int count = -1;
			return GetByProductRateTypeId(_productRateTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		ProductRateType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(TransactionManager transactionManager, System.Int32 _productRateTypeId)
		{
			int count = -1;
			return GetByProductRateTypeId(transactionManager, _productRateTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		ProductRateType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(TransactionManager transactionManager, System.Int32 _productRateTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateTypeId(transactionManager, _productRateTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		productRateType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(System.Int32 _productRateTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductRateTypeId(null, _productRateTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		productRateType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(System.Int32 _productRateTypeId, int start, int pageLength,out int count)
		{
			return GetByProductRateTypeId(null, _productRateTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRateType_ProductRate_FK1 key.
		///		ProductRateType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByProductRateTypeId(TransactionManager transactionManager, System.Int32 _productRateTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		Taxable_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByTaxableId(System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(_taxableId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		Taxable_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ProductRate> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		Taxable_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaxableId(transactionManager, _taxableId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		taxable_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTaxableId(null, _taxableId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		taxable_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_taxableId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByTaxableId(System.Int32 _taxableId, int start, int pageLength,out int count)
		{
			return GetByTaxableId(null, _taxableId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Taxable_ProductRate_FK1 key.
		///		Taxable_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_taxableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByTaxableId(TransactionManager transactionManager, System.Int32 _taxableId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.ProductRate Get(TransactionManager transactionManager, CONFDB.Entities.ProductRateKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ProductRate_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public abstract CONFDB.Entities.ProductRate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(System.Int32 _productId, System.Int32 _productRateTypeId)
		{
			int count = -1;
			return GetByProductIdProductRateTypeId(null,_productId, _productRateTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(System.Int32 _productId, System.Int32 _productRateTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdProductRateTypeId(null, _productId, _productRateTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productRateTypeId)
		{
			int count = -1;
			return GetByProductIdProductRateTypeId(transactionManager, _productId, _productRateTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productRateTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdProductRateTypeId(transactionManager, _productId, _productRateTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(System.Int32 _productId, System.Int32 _productRateTypeId, int start, int pageLength, out int count)
		{
			return GetByProductIdProductRateTypeId(null, _productId, _productRateTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="_productRateTypeId">The Product Rate Type is used to group together different types of product rates. Example would be Outbound Toll Free and Outbound Mobile rates. The are similar but different rates are required as there are different prices for each.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ProductRate> GetByProductIdProductRateTypeId(TransactionManager transactionManager, System.Int32 _productId, System.Int32 _productRateTypeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductRate_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetByNameProductId(System.String _name, System.Int32 _productId)
		{
			int count = -1;
			return GetByNameProductId(null,_name, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetByNameProductId(System.String _name, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByNameProductId(null, _name, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetByNameProductId(TransactionManager transactionManager, System.String _name, System.Int32 _productId)
		{
			int count = -1;
			return GetByNameProductId(transactionManager, _name, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetByNameProductId(TransactionManager transactionManager, System.String _name, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByNameProductId(transactionManager, _name, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public CONFDB.Entities.ProductRate GetByNameProductId(System.String _name, System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByNameProductId(null, _name, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductRate_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ProductRate"/> class.</returns>
		public abstract CONFDB.Entities.ProductRate GetByNameProductId(TransactionManager transactionManager, System.String _name, System.Int32 _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ProductRate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ProductRate&gt;"/></returns>
		public static CONFDB.Entities.TList<ProductRate> Fill(IDataReader reader, CONFDB.Entities.TList<ProductRate> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ProductRate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProductRate")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ProductRateColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ProductRateColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ProductRate>(
					key.ToString(), // EntityTrackingKey
					"ProductRate",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ProductRate();
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
					c.Id = (System.Int32)reader[((int)ProductRateColumn.Id - 1)];
					c.ProductId = (System.Int32)reader[((int)ProductRateColumn.ProductId - 1)];
					c.ProductRateTypeId = (System.Int32)reader[((int)ProductRateColumn.ProductRateTypeId - 1)];
					c.ProductRateIntervalId = (System.Int32)reader[((int)ProductRateColumn.ProductRateIntervalId - 1)];
					c.TaxableId = (System.Int32)reader[((int)ProductRateColumn.TaxableId - 1)];
					c.CountryId = (reader.IsDBNull(((int)ProductRateColumn.CountryId - 1)))?null:(System.String)reader[((int)ProductRateColumn.CountryId - 1)];
					c.Name = (reader.IsDBNull(((int)ProductRateColumn.Name - 1)))?null:(System.String)reader[((int)ProductRateColumn.Name - 1)];
					c.DisplayName = (reader.IsDBNull(((int)ProductRateColumn.DisplayName - 1)))?null:(System.String)reader[((int)ProductRateColumn.DisplayName - 1)];
					c.Description = (reader.IsDBNull(((int)ProductRateColumn.Description - 1)))?null:(System.String)reader[((int)ProductRateColumn.Description - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)ProductRateColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)ProductRateColumn.DisplayOrder - 1)];
					c.MinimumTimeBeforeChargedSec = (reader.IsDBNull(((int)ProductRateColumn.MinimumTimeBeforeChargedSec - 1)))?null:(System.Int32?)reader[((int)ProductRateColumn.MinimumTimeBeforeChargedSec - 1)];
					c.RatingTypeId = (System.Int32)reader[((int)ProductRateColumn.RatingTypeId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ProductRate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ProductRate entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProductRateColumn.Id - 1)];
			entity.ProductId = (System.Int32)reader[((int)ProductRateColumn.ProductId - 1)];
			entity.ProductRateTypeId = (System.Int32)reader[((int)ProductRateColumn.ProductRateTypeId - 1)];
			entity.ProductRateIntervalId = (System.Int32)reader[((int)ProductRateColumn.ProductRateIntervalId - 1)];
			entity.TaxableId = (System.Int32)reader[((int)ProductRateColumn.TaxableId - 1)];
			entity.CountryId = (reader.IsDBNull(((int)ProductRateColumn.CountryId - 1)))?null:(System.String)reader[((int)ProductRateColumn.CountryId - 1)];
			entity.Name = (reader.IsDBNull(((int)ProductRateColumn.Name - 1)))?null:(System.String)reader[((int)ProductRateColumn.Name - 1)];
			entity.DisplayName = (reader.IsDBNull(((int)ProductRateColumn.DisplayName - 1)))?null:(System.String)reader[((int)ProductRateColumn.DisplayName - 1)];
			entity.Description = (reader.IsDBNull(((int)ProductRateColumn.Description - 1)))?null:(System.String)reader[((int)ProductRateColumn.Description - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)ProductRateColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)ProductRateColumn.DisplayOrder - 1)];
			entity.MinimumTimeBeforeChargedSec = (reader.IsDBNull(((int)ProductRateColumn.MinimumTimeBeforeChargedSec - 1)))?null:(System.Int32?)reader[((int)ProductRateColumn.MinimumTimeBeforeChargedSec - 1)];
			entity.RatingTypeId = (System.Int32)reader[((int)ProductRateColumn.RatingTypeId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ProductRate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ProductRate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.ProductRateTypeId = (System.Int32)dataRow["ProductRateTypeID"];
			entity.ProductRateIntervalId = (System.Int32)dataRow["ProductRateIntervalID"];
			entity.TaxableId = (System.Int32)dataRow["TaxableID"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.String)dataRow["CountryID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
			entity.MinimumTimeBeforeChargedSec = Convert.IsDBNull(dataRow["MinimumTimeBeforeChargedSec"]) ? null : (System.Int32?)dataRow["MinimumTimeBeforeChargedSec"];
			entity.RatingTypeId = (System.Int32)dataRow["RatingTypeID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ProductRate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ProductRate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ProductRate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Country|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CountryId ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountryProvider.GetById(transactionManager, (entity.CountryId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.CountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryIdSource

			#region RatingTypeIdSource	
			if (CanDeepLoad(entity, "RatingType|RatingTypeIdSource", deepLoadType, innerList) 
				&& entity.RatingTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RatingTypeId;
				RatingType tmpEntity = EntityManager.LocateEntity<RatingType>(EntityLocator.ConstructKeyFromPkItems(typeof(RatingType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RatingTypeIdSource = tmpEntity;
				else
					entity.RatingTypeIdSource = DataRepository.RatingTypeProvider.GetById(transactionManager, entity.RatingTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RatingTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RatingTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RatingTypeProvider.DeepLoad(transactionManager, entity.RatingTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RatingTypeIdSource

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Product|ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductProvider.GetById(transactionManager, entity.ProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductIdSource

			#region ProductRateIntervalIdSource	
			if (CanDeepLoad(entity, "ProductRateInterval|ProductRateIntervalIdSource", deepLoadType, innerList) 
				&& entity.ProductRateIntervalIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductRateIntervalId;
				ProductRateInterval tmpEntity = EntityManager.LocateEntity<ProductRateInterval>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductRateInterval), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductRateIntervalIdSource = tmpEntity;
				else
					entity.ProductRateIntervalIdSource = DataRepository.ProductRateIntervalProvider.GetById(transactionManager, entity.ProductRateIntervalId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateIntervalIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductRateIntervalIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductRateIntervalProvider.DeepLoad(transactionManager, entity.ProductRateIntervalIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductRateIntervalIdSource

			#region ProductRateTypeIdSource	
			if (CanDeepLoad(entity, "ProductRateType|ProductRateTypeIdSource", deepLoadType, innerList) 
				&& entity.ProductRateTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductRateTypeId;
				ProductRateType tmpEntity = EntityManager.LocateEntity<ProductRateType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductRateType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductRateTypeIdSource = tmpEntity;
				else
					entity.ProductRateTypeIdSource = DataRepository.ProductRateTypeProvider.GetById(transactionManager, entity.ProductRateTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductRateTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductRateTypeProvider.DeepLoad(transactionManager, entity.ProductRateTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductRateTypeIdSource

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
			
			#region ProductRateValueCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductRateValue>|ProductRateValueCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateValueCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductRateValueCollection = DataRepository.ProductRateValueProvider.GetByProductRateId(transactionManager, entity.Id);

				if (deep && entity.ProductRateValueCollection.Count > 0)
				{
					deepHandles.Add("ProductRateValueCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRateValue>) DataRepository.ProductRateValueProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateValueCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AccessType_ProductRateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AccessType_ProductRate>|AccessType_ProductRateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccessType_ProductRateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AccessType_ProductRateCollection = DataRepository.AccessType_ProductRateProvider.GetByProductRateId(transactionManager, entity.Id);

				if (deep && entity.AccessType_ProductRateCollection.Count > 0)
				{
					deepHandles.Add("AccessType_ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AccessType_ProductRate>) DataRepository.AccessType_ProductRateProvider.DeepLoad,
						new object[] { transactionManager, entity.AccessType_ProductRateCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerTransactionCollection = DataRepository.CustomerTransactionProvider.GetByProductRateId(transactionManager, entity.Id);

				if (deep && entity.CustomerTransactionCollection.Count > 0)
				{
					deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerTransaction>) DataRepository.CustomerTransactionProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTransactionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ProductRate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ProductRate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ProductRate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ProductRate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Country|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.Id;
			}
			#endregion 
			
			#region RatingTypeIdSource
			if (CanDeepSave(entity, "RatingType|RatingTypeIdSource", deepSaveType, innerList) 
				&& entity.RatingTypeIdSource != null)
			{
				DataRepository.RatingTypeProvider.Save(transactionManager, entity.RatingTypeIdSource);
				entity.RatingTypeId = entity.RatingTypeIdSource.Id;
			}
			#endregion 
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Product|ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.Id;
			}
			#endregion 
			
			#region ProductRateIntervalIdSource
			if (CanDeepSave(entity, "ProductRateInterval|ProductRateIntervalIdSource", deepSaveType, innerList) 
				&& entity.ProductRateIntervalIdSource != null)
			{
				DataRepository.ProductRateIntervalProvider.Save(transactionManager, entity.ProductRateIntervalIdSource);
				entity.ProductRateIntervalId = entity.ProductRateIntervalIdSource.Id;
			}
			#endregion 
			
			#region ProductRateTypeIdSource
			if (CanDeepSave(entity, "ProductRateType|ProductRateTypeIdSource", deepSaveType, innerList) 
				&& entity.ProductRateTypeIdSource != null)
			{
				DataRepository.ProductRateTypeProvider.Save(transactionManager, entity.ProductRateTypeIdSource);
				entity.ProductRateTypeId = entity.ProductRateTypeIdSource.Id;
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
	
			#region List<ProductRateValue>
				if (CanDeepSave(entity.ProductRateValueCollection, "List<ProductRateValue>|ProductRateValueCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductRateValue child in entity.ProductRateValueCollection)
					{
						if(child.ProductRateIdSource != null)
						{
							child.ProductRateId = child.ProductRateIdSource.Id;
						}
						else
						{
							child.ProductRateId = entity.Id;
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
				
	
			#region List<AccessType_ProductRate>
				if (CanDeepSave(entity.AccessType_ProductRateCollection, "List<AccessType_ProductRate>|AccessType_ProductRateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AccessType_ProductRate child in entity.AccessType_ProductRateCollection)
					{
						if(child.ProductRateIdSource != null)
						{
							child.ProductRateId = child.ProductRateIdSource.Id;
						}
						else
						{
							child.ProductRateId = entity.Id;
						}

					}

					if (entity.AccessType_ProductRateCollection.Count > 0 || entity.AccessType_ProductRateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AccessType_ProductRateProvider.Save(transactionManager, entity.AccessType_ProductRateCollection);
						
						deepHandles.Add("AccessType_ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AccessType_ProductRate >) DataRepository.AccessType_ProductRateProvider.DeepSave,
							new object[] { transactionManager, entity.AccessType_ProductRateCollection, deepSaveType, childTypes, innerList }
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
						if(child.ProductRateIdSource != null)
						{
							child.ProductRateId = child.ProductRateIdSource.Id;
						}
						else
						{
							child.ProductRateId = entity.Id;
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
	
	#region ProductRateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ProductRate</c>
	///</summary>
	public enum ProductRateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Country</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
			
		///<summary>
		/// Composite Property for <c>RatingType</c> at RatingTypeIdSource
		///</summary>
		[ChildEntityType(typeof(RatingType))]
		RatingType,
			
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>ProductRateInterval</c> at ProductRateIntervalIdSource
		///</summary>
		[ChildEntityType(typeof(ProductRateInterval))]
		ProductRateInterval,
			
		///<summary>
		/// Composite Property for <c>ProductRateType</c> at ProductRateTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ProductRateType))]
		ProductRateType,
			
		///<summary>
		/// Composite Property for <c>Taxable</c> at TaxableIdSource
		///</summary>
		[ChildEntityType(typeof(Taxable))]
		Taxable,
	
		///<summary>
		/// Collection of <c>ProductRate</c> as OneToMany for ProductRateValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRateValue>))]
		ProductRateValueCollection,

		///<summary>
		/// Collection of <c>ProductRate</c> as OneToMany for AccessType_ProductRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<AccessType_ProductRate>))]
		AccessType_ProductRateCollection,

		///<summary>
		/// Collection of <c>ProductRate</c> as OneToMany for CustomerTransactionCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransaction>))]
		CustomerTransactionCollection,
	}
	
	#endregion ProductRateChildEntityTypes
	
	#region ProductRateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateFilterBuilder : SqlFilterBuilder<ProductRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateFilterBuilder class.
		/// </summary>
		public ProductRateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateFilterBuilder
	
	#region ProductRateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductRateParameterBuilder : ParameterizedSqlFilterBuilder<ProductRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductRateParameterBuilder class.
		/// </summary>
		public ProductRateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductRateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductRateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductRateParameterBuilder
} // end namespace
