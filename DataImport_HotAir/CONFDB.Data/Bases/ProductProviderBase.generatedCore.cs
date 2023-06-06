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
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProviderBaseCore : EntityProviderBase<CONFDB.Entities.Product, CONFDB.Entities.ProductKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ProductKey key)
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
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		ProductType_Product_FK1 Description: 
		/// </summary>
		/// <param name="_productTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		public CONFDB.Entities.TList<Product> GetByProductTypeId(System.Int32 _productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(_productTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		ProductType_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Product> GetByProductTypeId(TransactionManager transactionManager, System.Int32 _productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, _productTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		ProductType_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		public CONFDB.Entities.TList<Product> GetByProductTypeId(TransactionManager transactionManager, System.Int32 _productTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, _productTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		productType_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		public CONFDB.Entities.TList<Product> GetByProductTypeId(System.Int32 _productTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductTypeId(null, _productTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		productType_Product_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		public CONFDB.Entities.TList<Product> GetByProductTypeId(System.Int32 _productTypeId, int start, int pageLength,out int count)
		{
			return GetByProductTypeId(null, _productTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductType_Product_FK1 key.
		///		ProductType_Product_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Product objects.</returns>
		public abstract CONFDB.Entities.TList<Product> GetByProductTypeId(TransactionManager transactionManager, System.Int32 _productTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Product Get(TransactionManager transactionManager, CONFDB.Entities.ProductKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public CONFDB.Entities.Product GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public CONFDB.Entities.Product GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public CONFDB.Entities.Product GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public CONFDB.Entities.Product GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public CONFDB.Entities.Product GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Product"/> class.</returns>
		public abstract CONFDB.Entities.Product GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Product_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Product> GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Product_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Product> GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Product> GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Product> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Product_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Product> GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Product_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Product&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Product> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Product&gt;"/></returns>
		public static CONFDB.Entities.TList<Product> Fill(IDataReader reader, CONFDB.Entities.TList<Product> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Product c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Product")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ProductColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ProductColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Product>(
					key.ToString(), // EntityTrackingKey
					"Product",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Product();
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
					c.Id = (System.Int32)reader[((int)ProductColumn.Id - 1)];
					c.ProductTypeId = (System.Int32)reader[((int)ProductColumn.ProductTypeId - 1)];
					c.Name = (reader.IsDBNull(((int)ProductColumn.Name - 1)))?null:(System.String)reader[((int)ProductColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)ProductColumn.Description - 1)))?null:(System.String)reader[((int)ProductColumn.Description - 1)];
					c.DisplayNameAlt = (reader.IsDBNull(((int)ProductColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)ProductColumn.DisplayNameAlt - 1)];
					c.DescriptionAlt = (reader.IsDBNull(((int)ProductColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)ProductColumn.DescriptionAlt - 1)];
					c.DefaultOption = (reader.IsDBNull(((int)ProductColumn.DefaultOption - 1)))?null:(System.Boolean?)reader[((int)ProductColumn.DefaultOption - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)ProductColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)ProductColumn.DisplayOrder - 1)];
					c.SupportsExternalProvisioning = (System.Boolean)reader[((int)ProductColumn.SupportsExternalProvisioning - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProductColumn.Id - 1)];
			entity.ProductTypeId = (System.Int32)reader[((int)ProductColumn.ProductTypeId - 1)];
			entity.Name = (reader.IsDBNull(((int)ProductColumn.Name - 1)))?null:(System.String)reader[((int)ProductColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)ProductColumn.Description - 1)))?null:(System.String)reader[((int)ProductColumn.Description - 1)];
			entity.DisplayNameAlt = (reader.IsDBNull(((int)ProductColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)ProductColumn.DisplayNameAlt - 1)];
			entity.DescriptionAlt = (reader.IsDBNull(((int)ProductColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)ProductColumn.DescriptionAlt - 1)];
			entity.DefaultOption = (reader.IsDBNull(((int)ProductColumn.DefaultOption - 1)))?null:(System.Boolean?)reader[((int)ProductColumn.DefaultOption - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)ProductColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)ProductColumn.DisplayOrder - 1)];
			entity.SupportsExternalProvisioning = (System.Boolean)reader[((int)ProductColumn.SupportsExternalProvisioning - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ProductTypeId = (System.Int32)dataRow["ProductTypeID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayNameAlt = Convert.IsDBNull(dataRow["DisplayNameAlt"]) ? null : (System.String)dataRow["DisplayNameAlt"];
			entity.DescriptionAlt = Convert.IsDBNull(dataRow["DescriptionAlt"]) ? null : (System.String)dataRow["DescriptionAlt"];
			entity.DefaultOption = Convert.IsDBNull(dataRow["DefaultOption"]) ? null : (System.Boolean?)dataRow["DefaultOption"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
			entity.SupportsExternalProvisioning = (System.Boolean)dataRow["SupportsExternalProvisioning"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProductTypeIdSource	
			if (CanDeepLoad(entity, "ProductType|ProductTypeIdSource", deepLoadType, innerList) 
				&& entity.ProductTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductTypeId;
				ProductType tmpEntity = EntityManager.LocateEntity<ProductType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductTypeIdSource = tmpEntity;
				else
					entity.ProductTypeIdSource = DataRepository.ProductTypeProvider.GetById(transactionManager, entity.ProductTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductTypeProvider.DeepLoad(transactionManager, entity.ProductTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region Wholesaler_ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Wholesaler_Product>|Wholesaler_ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Wholesaler_ProductCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Wholesaler_ProductCollection = DataRepository.Wholesaler_ProductProvider.GetByProductId(transactionManager, entity.Id);

				if (deep && entity.Wholesaler_ProductCollection.Count > 0)
				{
					deepHandles.Add("Wholesaler_ProductCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler_Product>) DataRepository.Wholesaler_ProductProvider.DeepLoad,
						new object[] { transactionManager, entity.Wholesaler_ProductCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductRateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductRate>|ProductRateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductRateCollection = DataRepository.ProductRateProvider.GetByProductId(transactionManager, entity.Id);

				if (deep && entity.ProductRateCollection.Count > 0)
				{
					deepHandles.Add("ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRate>) DataRepository.ProductRateProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Feature>|FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FeatureCollection = DataRepository.FeatureProvider.GetByProductId(transactionManager, entity.Id);

				if (deep && entity.FeatureCollection.Count > 0)
				{
					deepHandles.Add("FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Feature>) DataRepository.FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.FeatureCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductTypeIdSource
			if (CanDeepSave(entity, "ProductType|ProductTypeIdSource", deepSaveType, innerList) 
				&& entity.ProductTypeIdSource != null)
			{
				DataRepository.ProductTypeProvider.Save(transactionManager, entity.ProductTypeIdSource);
				entity.ProductTypeId = entity.ProductTypeIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Wholesaler_Product>
				if (CanDeepSave(entity.Wholesaler_ProductCollection, "List<Wholesaler_Product>|Wholesaler_ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler_Product child in entity.Wholesaler_ProductCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.Id;
						}
						else
						{
							child.ProductId = entity.Id;
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
				
	
			#region List<ProductRate>
				if (CanDeepSave(entity.ProductRateCollection, "List<ProductRate>|ProductRateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductRate child in entity.ProductRateCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.Id;
						}
						else
						{
							child.ProductId = entity.Id;
						}

					}

					if (entity.ProductRateCollection.Count > 0 || entity.ProductRateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductRateProvider.Save(transactionManager, entity.ProductRateCollection);
						
						deepHandles.Add("ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductRate >) DataRepository.ProductRateProvider.DeepSave,
							new object[] { transactionManager, entity.ProductRateCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Feature>
				if (CanDeepSave(entity.FeatureCollection, "List<Feature>|FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Feature child in entity.FeatureCollection)
					{
						if(child.ProductIdSource != null)
						{
							child.ProductId = child.ProductIdSource.Id;
						}
						else
						{
							child.ProductId = entity.Id;
						}

					}

					if (entity.FeatureCollection.Count > 0 || entity.FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FeatureProvider.Save(transactionManager, entity.FeatureCollection);
						
						deepHandles.Add("FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Feature >) DataRepository.FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.FeatureCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Product</c>
	///</summary>
	public enum ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProductType</c> at ProductTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ProductType))]
		ProductType,
	
		///<summary>
		/// Collection of <c>Product</c> as OneToMany for Wholesaler_ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler_Product>))]
		Wholesaler_ProductCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRate>))]
		ProductRateCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Feature>))]
		FeatureCollection,
	}
	
	#endregion ProductChildEntityTypes
	
	#region ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilterBuilder : SqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		public ProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilterBuilder
	
	#region ProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductParameterBuilder : ParameterizedSqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		public ProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductParameterBuilder
} // end namespace
