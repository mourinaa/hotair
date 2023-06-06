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
	/// This class is the base class for any <see cref="Wholesaler_ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class Wholesaler_ProductProviderBaseCore : EntityProviderBase<CONFDB.Entities.Wholesaler_Product, CONFDB.Entities.Wholesaler_ProductKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.Wholesaler_ProductKey key)
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
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		Product_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		Product_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		Product_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		product_Wholesaler_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		product_Wholesaler_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Wholesaler_Product_FK1 key.
		///		Product_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler_Product> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		Wholesaler_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		Wholesaler_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		Wholesaler_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		wholesaler_Wholesaler_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		wholesaler_Wholesaler_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Wholesaler_Product_FK1 key.
		///		Wholesaler_Wholesaler_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Wholesaler_Product objects.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Wholesaler_Product Get(TransactionManager transactionManager, CONFDB.Entities.Wholesaler_ProductKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public CONFDB.Entities.Wholesaler_Product GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public CONFDB.Entities.Wholesaler_Product GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public CONFDB.Entities.Wholesaler_Product GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public CONFDB.Entities.Wholesaler_Product GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public CONFDB.Entities.Wholesaler_Product GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Wholesaler_Product"/> class.</returns>
		public abstract CONFDB.Entities.Wholesaler_Product GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(System.String _wholesalerId, System.Int32 _productId)
		{
			int count = -1;
			return GetByWholesalerIdProductId(null,_wholesalerId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(System.String _wholesalerId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdProductId(null, _wholesalerId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _productId)
		{
			int count = -1;
			return GetByWholesalerIdProductId(transactionManager, _wholesalerId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdProductId(transactionManager, _wholesalerId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(System.String _wholesalerId, System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdProductId(null, _wholesalerId, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Wholesaler_Product_CusotmerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Wholesaler_Product> GetByWholesalerIdProductId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _productId, int start, int pageLength, out int count);
						
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
		public void InstallDefaults(System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 InstallDefaults(null, 0, int.MaxValue , wholesaler_ProductId, productId, wholesalerId);
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
		public void InstallDefaults(int start, int pageLength, System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 InstallDefaults(null, start, pageLength , wholesaler_ProductId, productId, wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_Wholesaler_Product_InstallDefaults' stored procedure. 
		/// </summary>
		/// <param name="wholesaler_ProductId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void InstallDefaults(TransactionManager transactionManager, System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId)
		{
			 InstallDefaults(transactionManager, 0, int.MaxValue , wholesaler_ProductId, productId, wholesalerId);
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
		public abstract void InstallDefaults(TransactionManager transactionManager, int start, int pageLength , System.Int32? wholesaler_ProductId, System.Int32? productId, System.String wholesalerId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Wholesaler_Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Wholesaler_Product&gt;"/></returns>
		public static CONFDB.Entities.TList<Wholesaler_Product> Fill(IDataReader reader, CONFDB.Entities.TList<Wholesaler_Product> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Wholesaler_Product c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Wholesaler_Product")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.Wholesaler_ProductColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.Wholesaler_ProductColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Wholesaler_Product>(
					key.ToString(), // EntityTrackingKey
					"Wholesaler_Product",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Wholesaler_Product();
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
					c.Id = (System.Int32)reader[((int)Wholesaler_ProductColumn.Id - 1)];
					c.ProductId = (System.Int32)reader[((int)Wholesaler_ProductColumn.ProductId - 1)];
					c.WholesalerId = (System.String)reader[((int)Wholesaler_ProductColumn.WholesalerId - 1)];
					c.Name = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Name - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Description - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.Description - 1)];
					c.DisplayNameAlt = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.DisplayNameAlt - 1)];
					c.DescriptionAlt = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.DescriptionAlt - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)Wholesaler_ProductColumn.DisplayOrder - 1)];
					c.Enabled = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)Wholesaler_ProductColumn.Enabled - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Wholesaler_Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler_Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Wholesaler_Product entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)Wholesaler_ProductColumn.Id - 1)];
			entity.ProductId = (System.Int32)reader[((int)Wholesaler_ProductColumn.ProductId - 1)];
			entity.WholesalerId = (System.String)reader[((int)Wholesaler_ProductColumn.WholesalerId - 1)];
			entity.Name = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Name - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Description - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.Description - 1)];
			entity.DisplayNameAlt = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.DisplayNameAlt - 1)];
			entity.DescriptionAlt = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)Wholesaler_ProductColumn.DescriptionAlt - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)Wholesaler_ProductColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)Wholesaler_ProductColumn.DisplayOrder - 1)];
			entity.Enabled = (reader.IsDBNull(((int)Wholesaler_ProductColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)Wholesaler_ProductColumn.Enabled - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Wholesaler_Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler_Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Wholesaler_Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayNameAlt = Convert.IsDBNull(dataRow["DisplayNameAlt"]) ? null : (System.String)dataRow["DisplayNameAlt"];
			entity.DescriptionAlt = Convert.IsDBNull(dataRow["DescriptionAlt"]) ? null : (System.String)dataRow["DescriptionAlt"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Wholesaler_Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Wholesaler_Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Wholesaler_Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
			
			#region Wholesaler_Product_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Wholesaler_Product_Feature>|Wholesaler_Product_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Wholesaler_Product_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Wholesaler_Product_FeatureCollection = DataRepository.Wholesaler_Product_FeatureProvider.GetByWholesaler_ProductId(transactionManager, entity.Id);

				if (deep && entity.Wholesaler_Product_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Wholesaler_Product_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler_Product_Feature>) DataRepository.Wholesaler_Product_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Wholesaler_Product_FeatureCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerTransactionCollection = DataRepository.CustomerTransactionProvider.GetByWholesaler_ProductId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the CONFDB.Entities.Wholesaler_Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Wholesaler_Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Wholesaler_Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Wholesaler_Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Product|ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.Id;
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
	
			#region List<Wholesaler_Product_Feature>
				if (CanDeepSave(entity.Wholesaler_Product_FeatureCollection, "List<Wholesaler_Product_Feature>|Wholesaler_Product_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler_Product_Feature child in entity.Wholesaler_Product_FeatureCollection)
					{
						if(child.Wholesaler_ProductIdSource != null)
						{
							child.Wholesaler_ProductId = child.Wholesaler_ProductIdSource.Id;
						}
						else
						{
							child.Wholesaler_ProductId = entity.Id;
						}

					}

					if (entity.Wholesaler_Product_FeatureCollection.Count > 0 || entity.Wholesaler_Product_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Wholesaler_Product_FeatureProvider.Save(transactionManager, entity.Wholesaler_Product_FeatureCollection);
						
						deepHandles.Add("Wholesaler_Product_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Wholesaler_Product_Feature >) DataRepository.Wholesaler_Product_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Wholesaler_Product_FeatureCollection, deepSaveType, childTypes, innerList }
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
						if(child.Wholesaler_ProductIdSource != null)
						{
							child.Wholesaler_ProductId = child.Wholesaler_ProductIdSource.Id;
						}
						else
						{
							child.Wholesaler_ProductId = entity.Id;
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
	
	#region Wholesaler_ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Wholesaler_Product</c>
	///</summary>
	public enum Wholesaler_ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
	
		///<summary>
		/// Collection of <c>Wholesaler_Product</c> as OneToMany for Wholesaler_Product_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler_Product_Feature>))]
		Wholesaler_Product_FeatureCollection,

		///<summary>
		/// Collection of <c>Wholesaler_Product</c> as OneToMany for CustomerTransactionCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransaction>))]
		CustomerTransactionCollection,
	}
	
	#endregion Wholesaler_ProductChildEntityTypes
	
	#region Wholesaler_ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;Wholesaler_ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductFilterBuilder : SqlFilterBuilder<Wholesaler_ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilterBuilder class.
		/// </summary>
		public Wholesaler_ProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_ProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_ProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_ProductFilterBuilder
	
	#region Wholesaler_ProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;Wholesaler_ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Wholesaler_Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Wholesaler_ProductParameterBuilder : ParameterizedSqlFilterBuilder<Wholesaler_ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductParameterBuilder class.
		/// </summary>
		public Wholesaler_ProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Wholesaler_ProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Wholesaler_ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Wholesaler_ProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Wholesaler_ProductParameterBuilder
} // end namespace
