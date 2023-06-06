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
	/// This class is the base class for any <see cref="CustomerDocumentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerDocumentProviderBaseCore : EntityProviderBase<CONFDB.Entities.CustomerDocument, CONFDB.Entities.CustomerDocumentKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerDocumentKey key)
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
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		Customer_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		Customer_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		Customer_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		customer_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		customer_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_CustomerDocument_FK key.
		///		Customer_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerDocument> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		Wholesaler_CustomerDocument_FK1 Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		Wholesaler_CustomerDocument_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		Wholesaler_CustomerDocument_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		wholesaler_CustomerDocument_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		wholesaler_CustomerDocument_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_CustomerDocument_FK1 key.
		///		Wholesaler_CustomerDocument_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerDocument> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		DocumentType_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="_documentTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(System.Int32 _documentTypeId)
		{
			int count = -1;
			return GetByDocumentTypeId(_documentTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		DocumentType_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(TransactionManager transactionManager, System.Int32 _documentTypeId)
		{
			int count = -1;
			return GetByDocumentTypeId(transactionManager, _documentTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		DocumentType_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(TransactionManager transactionManager, System.Int32 _documentTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDocumentTypeId(transactionManager, _documentTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		documentType_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_documentTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(System.Int32 _documentTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDocumentTypeId(null, _documentTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		documentType_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_documentTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(System.Int32 _documentTypeId, int start, int pageLength,out int count)
		{
			return GetByDocumentTypeId(null, _documentTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the DocumentType_CustomerDocument_FK key.
		///		DocumentType_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_documentTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerDocument> GetByDocumentTypeId(TransactionManager transactionManager, System.Int32 _documentTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		Language_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		Language_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(TransactionManager transactionManager, System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		Language_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		language_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(System.String _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		language_CustomerDocument_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(System.String _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_CustomerDocument_FK key.
		///		Language_CustomerDocument_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerDocument objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerDocument> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CustomerDocument Get(TransactionManager transactionManager, CONFDB.Entities.CustomerDocumentKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerDocument_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public CONFDB.Entities.CustomerDocument GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerDocument_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public CONFDB.Entities.CustomerDocument GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerDocument_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public CONFDB.Entities.CustomerDocument GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerDocument_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public CONFDB.Entities.CustomerDocument GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerDocument_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public CONFDB.Entities.CustomerDocument GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerDocument_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerDocument"/> class.</returns>
		public abstract CONFDB.Entities.CustomerDocument GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CustomerDocument&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CustomerDocument&gt;"/></returns>
		public static CONFDB.Entities.TList<CustomerDocument> Fill(IDataReader reader, CONFDB.Entities.TList<CustomerDocument> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CustomerDocument c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerDocument")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerDocumentColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CustomerDocumentColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CustomerDocument>(
					key.ToString(), // EntityTrackingKey
					"CustomerDocument",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CustomerDocument();
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
					c.Id = (System.Int32)reader[((int)CustomerDocumentColumn.Id - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)CustomerDocumentColumn.WholesalerId - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.WholesalerId - 1)];
					c.CustomerId = (System.Int32)reader[((int)CustomerDocumentColumn.CustomerId - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)CustomerDocumentColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.PriCustomerNumber - 1)];
					c.DocumentDate = (System.DateTime)reader[((int)CustomerDocumentColumn.DocumentDate - 1)];
					c.DocumentTypeId = (System.Int32)reader[((int)CustomerDocumentColumn.DocumentTypeId - 1)];
					c.KbSize = (System.Int32)reader[((int)CustomerDocumentColumn.KbSize - 1)];
					c.DocumentDirectory = (reader.IsDBNull(((int)CustomerDocumentColumn.DocumentDirectory - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.DocumentDirectory - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CustomerDocumentColumn.CreatedDate - 1)];
					c.Notes = (reader.IsDBNull(((int)CustomerDocumentColumn.Notes - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.Notes - 1)];
					c.LanguageId = (reader.IsDBNull(((int)CustomerDocumentColumn.LanguageId - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.LanguageId - 1)];
					c.Enabled = (System.Boolean)reader[((int)CustomerDocumentColumn.Enabled - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerDocument"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerDocument"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CustomerDocument entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomerDocumentColumn.Id - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)CustomerDocumentColumn.WholesalerId - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.WholesalerId - 1)];
			entity.CustomerId = (System.Int32)reader[((int)CustomerDocumentColumn.CustomerId - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)CustomerDocumentColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.PriCustomerNumber - 1)];
			entity.DocumentDate = (System.DateTime)reader[((int)CustomerDocumentColumn.DocumentDate - 1)];
			entity.DocumentTypeId = (System.Int32)reader[((int)CustomerDocumentColumn.DocumentTypeId - 1)];
			entity.KbSize = (System.Int32)reader[((int)CustomerDocumentColumn.KbSize - 1)];
			entity.DocumentDirectory = (reader.IsDBNull(((int)CustomerDocumentColumn.DocumentDirectory - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.DocumentDirectory - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CustomerDocumentColumn.CreatedDate - 1)];
			entity.Notes = (reader.IsDBNull(((int)CustomerDocumentColumn.Notes - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.Notes - 1)];
			entity.LanguageId = (reader.IsDBNull(((int)CustomerDocumentColumn.LanguageId - 1)))?null:(System.String)reader[((int)CustomerDocumentColumn.LanguageId - 1)];
			entity.Enabled = (System.Boolean)reader[((int)CustomerDocumentColumn.Enabled - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerDocument"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerDocument"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CustomerDocument entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.DocumentDate = (System.DateTime)dataRow["DocumentDate"];
			entity.DocumentTypeId = (System.Int32)dataRow["DocumentTypeID"];
			entity.KbSize = (System.Int32)dataRow["KBSize"];
			entity.DocumentDirectory = Convert.IsDBNull(dataRow["DocumentDirectory"]) ? null : (System.String)dataRow["DocumentDirectory"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.LanguageId = Convert.IsDBNull(dataRow["LanguageID"]) ? null : (System.String)dataRow["LanguageID"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerDocument"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerDocument Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CustomerDocument entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region DocumentTypeIdSource	
			if (CanDeepLoad(entity, "DocumentType|DocumentTypeIdSource", deepLoadType, innerList) 
				&& entity.DocumentTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DocumentTypeId;
				DocumentType tmpEntity = EntityManager.LocateEntity<DocumentType>(EntityLocator.ConstructKeyFromPkItems(typeof(DocumentType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DocumentTypeIdSource = tmpEntity;
				else
					entity.DocumentTypeIdSource = DataRepository.DocumentTypeProvider.GetById(transactionManager, entity.DocumentTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DocumentTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DocumentTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DocumentTypeProvider.DeepLoad(transactionManager, entity.DocumentTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DocumentTypeIdSource

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Language|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LanguageId ?? string.Empty);
				Language tmpEntity = EntityManager.LocateEntity<Language>(EntityLocator.ConstructKeyFromPkItems(typeof(Language), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguageProvider.GetById(transactionManager, (entity.LanguageId ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguageProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CustomerDocument object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CustomerDocument instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerDocument Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CustomerDocument entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region DocumentTypeIdSource
			if (CanDeepSave(entity, "DocumentType|DocumentTypeIdSource", deepSaveType, innerList) 
				&& entity.DocumentTypeIdSource != null)
			{
				DataRepository.DocumentTypeProvider.Save(transactionManager, entity.DocumentTypeIdSource);
				entity.DocumentTypeId = entity.DocumentTypeIdSource.Id;
			}
			#endregion 
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Language|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguageProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.Id;
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
	
	#region CustomerDocumentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CustomerDocument</c>
	///</summary>
	public enum CustomerDocumentChildEntityTypes
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
		/// Composite Property for <c>DocumentType</c> at DocumentTypeIdSource
		///</summary>
		[ChildEntityType(typeof(DocumentType))]
		DocumentType,
			
		///<summary>
		/// Composite Property for <c>Language</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Language))]
		Language,
		}
	
	#endregion CustomerDocumentChildEntityTypes
	
	#region CustomerDocumentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerDocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentFilterBuilder : SqlFilterBuilder<CustomerDocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilterBuilder class.
		/// </summary>
		public CustomerDocumentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDocumentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDocumentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDocumentFilterBuilder
	
	#region CustomerDocumentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerDocumentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDocument"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDocumentParameterBuilder : ParameterizedSqlFilterBuilder<CustomerDocumentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentParameterBuilder class.
		/// </summary>
		public CustomerDocumentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDocumentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDocumentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDocumentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDocumentParameterBuilder
} // end namespace
