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
	/// This class is the base class for any <see cref="FeatureProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FeatureProviderBaseCore : EntityProviderBase<CONFDB.Entities.Feature, CONFDB.Entities.FeatureKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.FeatureKey key)
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
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		Product_Feature_FK1 Description: 
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		public CONFDB.Entities.TList<Feature> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(_productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		Product_Feature_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Feature> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		Product_Feature_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		public CONFDB.Entities.TList<Feature> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		product_Feature_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		public CONFDB.Entities.TList<Feature> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, _productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		product_Feature_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		public CONFDB.Entities.TList<Feature> GetByProductId(System.Int32 _productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Product_Feature_FK1 key.
		///		Product_Feature_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Feature objects.</returns>
		public abstract CONFDB.Entities.TList<Feature> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Feature Get(TransactionManager transactionManager, CONFDB.Entities.FeatureKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Feature_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public CONFDB.Entities.Feature GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Feature_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public CONFDB.Entities.Feature GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Feature_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public CONFDB.Entities.Feature GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Feature_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public CONFDB.Entities.Feature GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Feature_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public CONFDB.Entities.Feature GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Feature_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Feature"/> class.</returns>
		public abstract CONFDB.Entities.Feature GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Features_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Feature> GetByNameId(System.String _name, System.Int32 _id)
		{
			int count = -1;
			return GetByNameId(null,_name, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Features_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Feature> GetByNameId(System.String _name, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByNameId(null, _name, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Features_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Feature> GetByNameId(TransactionManager transactionManager, System.String _name, System.Int32 _id)
		{
			int count = -1;
			return GetByNameId(transactionManager, _name, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Features_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Feature> GetByNameId(TransactionManager transactionManager, System.String _name, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByNameId(transactionManager, _name, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Features_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Feature> GetByNameId(System.String _name, System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetByNameId(null, _name, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Features_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Feature> GetByNameId(TransactionManager transactionManager, System.String _name, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Feature&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Feature&gt;"/></returns>
		public static CONFDB.Entities.TList<Feature> Fill(IDataReader reader, CONFDB.Entities.TList<Feature> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Feature c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Feature")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.FeatureColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.FeatureColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Feature>(
					key.ToString(), // EntityTrackingKey
					"Feature",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Feature();
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
					c.Id = (System.Int32)reader[((int)FeatureColumn.Id - 1)];
					c.ProductId = (System.Int32)reader[((int)FeatureColumn.ProductId - 1)];
					c.Name = (System.String)reader[((int)FeatureColumn.Name - 1)];
					c.DisplayName = (System.String)reader[((int)FeatureColumn.DisplayName - 1)];
					c.Description = (reader.IsDBNull(((int)FeatureColumn.Description - 1)))?null:(System.String)reader[((int)FeatureColumn.Description - 1)];
					c.DisplayNameAlt = (reader.IsDBNull(((int)FeatureColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)FeatureColumn.DisplayNameAlt - 1)];
					c.DescriptionAlt = (reader.IsDBNull(((int)FeatureColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)FeatureColumn.DescriptionAlt - 1)];
					c.DefaultOption = (System.Boolean)reader[((int)FeatureColumn.DefaultOption - 1)];
					c.Enabled = (System.Boolean)reader[((int)FeatureColumn.Enabled - 1)];
					c.DisplayOrder = (System.Int32)reader[((int)FeatureColumn.DisplayOrder - 1)];
					c.DisplayOnlyToCustomer = (System.Boolean)reader[((int)FeatureColumn.DisplayOnlyToCustomer - 1)];
					c.DisplayInAmpSite = (System.Boolean)reader[((int)FeatureColumn.DisplayInAmpSite - 1)];
					c.DisplayToCustomer = (System.Boolean)reader[((int)FeatureColumn.DisplayToCustomer - 1)];
					c.DisplayToModerator = (System.Boolean)reader[((int)FeatureColumn.DisplayToModerator - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Feature"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Feature"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Feature entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)FeatureColumn.Id - 1)];
			entity.ProductId = (System.Int32)reader[((int)FeatureColumn.ProductId - 1)];
			entity.Name = (System.String)reader[((int)FeatureColumn.Name - 1)];
			entity.DisplayName = (System.String)reader[((int)FeatureColumn.DisplayName - 1)];
			entity.Description = (reader.IsDBNull(((int)FeatureColumn.Description - 1)))?null:(System.String)reader[((int)FeatureColumn.Description - 1)];
			entity.DisplayNameAlt = (reader.IsDBNull(((int)FeatureColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)FeatureColumn.DisplayNameAlt - 1)];
			entity.DescriptionAlt = (reader.IsDBNull(((int)FeatureColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)FeatureColumn.DescriptionAlt - 1)];
			entity.DefaultOption = (System.Boolean)reader[((int)FeatureColumn.DefaultOption - 1)];
			entity.Enabled = (System.Boolean)reader[((int)FeatureColumn.Enabled - 1)];
			entity.DisplayOrder = (System.Int32)reader[((int)FeatureColumn.DisplayOrder - 1)];
			entity.DisplayOnlyToCustomer = (System.Boolean)reader[((int)FeatureColumn.DisplayOnlyToCustomer - 1)];
			entity.DisplayInAmpSite = (System.Boolean)reader[((int)FeatureColumn.DisplayInAmpSite - 1)];
			entity.DisplayToCustomer = (System.Boolean)reader[((int)FeatureColumn.DisplayToCustomer - 1)];
			entity.DisplayToModerator = (System.Boolean)reader[((int)FeatureColumn.DisplayToModerator - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Feature"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Feature"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Feature entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.DisplayName = (System.String)dataRow["DisplayName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayNameAlt = Convert.IsDBNull(dataRow["DisplayNameAlt"]) ? null : (System.String)dataRow["DisplayNameAlt"];
			entity.DescriptionAlt = Convert.IsDBNull(dataRow["DescriptionAlt"]) ? null : (System.String)dataRow["DescriptionAlt"];
			entity.DefaultOption = (System.Boolean)dataRow["DefaultOption"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.DisplayOnlyToCustomer = (System.Boolean)dataRow["DisplayOnlyToCustomer"];
			entity.DisplayInAmpSite = (System.Boolean)dataRow["DisplayInAMPSite"];
			entity.DisplayToCustomer = (System.Boolean)dataRow["DisplayToCustomer"];
			entity.DisplayToModerator = (System.Boolean)dataRow["DisplayToModerator"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Feature"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Feature Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Feature entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

				entity.Wholesaler_Product_FeatureCollection = DataRepository.Wholesaler_Product_FeatureProvider.GetByFeatureId(transactionManager, entity.Id);

				if (deep && entity.Wholesaler_Product_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Wholesaler_Product_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler_Product_Feature>) DataRepository.Wholesaler_Product_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Wholesaler_Product_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Moderator_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator_Feature>|Moderator_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Moderator_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Moderator_FeatureCollection = DataRepository.Moderator_FeatureProvider.GetByFeatureId(transactionManager, entity.Id);

				if (deep && entity.Moderator_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator_Feature>) DataRepository.Moderator_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Moderator_FeatureCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.Customer_FeatureCollection = DataRepository.Customer_FeatureProvider.GetByFeatureId(transactionManager, entity.Id);

				if (deep && entity.Customer_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Customer_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer_Feature>) DataRepository.Customer_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Customer_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FeatureOptionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<FeatureOption>|FeatureOptionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FeatureOptionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FeatureOptionCollection = DataRepository.FeatureOptionProvider.GetByFeatureId(transactionManager, entity.Id);

				if (deep && entity.FeatureOptionCollection.Count > 0)
				{
					deepHandles.Add("FeatureOptionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<FeatureOption>) DataRepository.FeatureOptionProvider.DeepLoad,
						new object[] { transactionManager, entity.FeatureOptionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Feature object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Feature instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Feature Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Feature entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.FeatureIdSource != null)
						{
							child.FeatureId = child.FeatureIdSource.Id;
						}
						else
						{
							child.FeatureId = entity.Id;
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
				
	
			#region List<Moderator_Feature>
				if (CanDeepSave(entity.Moderator_FeatureCollection, "List<Moderator_Feature>|Moderator_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator_Feature child in entity.Moderator_FeatureCollection)
					{
						if(child.FeatureIdSource != null)
						{
							child.FeatureId = child.FeatureIdSource.Id;
						}
						else
						{
							child.FeatureId = entity.Id;
						}

					}

					if (entity.Moderator_FeatureCollection.Count > 0 || entity.Moderator_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Moderator_FeatureProvider.Save(transactionManager, entity.Moderator_FeatureCollection);
						
						deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator_Feature >) DataRepository.Moderator_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Moderator_FeatureCollection, deepSaveType, childTypes, innerList }
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
						if(child.FeatureIdSource != null)
						{
							child.FeatureId = child.FeatureIdSource.Id;
						}
						else
						{
							child.FeatureId = entity.Id;
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
				
	
			#region List<FeatureOption>
				if (CanDeepSave(entity.FeatureOptionCollection, "List<FeatureOption>|FeatureOptionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(FeatureOption child in entity.FeatureOptionCollection)
					{
						if(child.FeatureIdSource != null)
						{
							child.FeatureId = child.FeatureIdSource.Id;
						}
						else
						{
							child.FeatureId = entity.Id;
						}

					}

					if (entity.FeatureOptionCollection.Count > 0 || entity.FeatureOptionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FeatureOptionProvider.Save(transactionManager, entity.FeatureOptionCollection);
						
						deepHandles.Add("FeatureOptionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< FeatureOption >) DataRepository.FeatureOptionProvider.DeepSave,
							new object[] { transactionManager, entity.FeatureOptionCollection, deepSaveType, childTypes, innerList }
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
	
	#region FeatureChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Feature</c>
	///</summary>
	public enum FeatureChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
	
		///<summary>
		/// Collection of <c>Feature</c> as OneToMany for Wholesaler_Product_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler_Product_Feature>))]
		Wholesaler_Product_FeatureCollection,

		///<summary>
		/// Collection of <c>Feature</c> as OneToMany for Moderator_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator_Feature>))]
		Moderator_FeatureCollection,

		///<summary>
		/// Collection of <c>Feature</c> as OneToMany for Customer_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer_Feature>))]
		Customer_FeatureCollection,

		///<summary>
		/// Collection of <c>Feature</c> as OneToMany for FeatureOptionCollection
		///</summary>
		[ChildEntityType(typeof(TList<FeatureOption>))]
		FeatureOptionCollection,
	}
	
	#endregion FeatureChildEntityTypes
	
	#region FeatureFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FeatureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureFilterBuilder : SqlFilterBuilder<FeatureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureFilterBuilder class.
		/// </summary>
		public FeatureFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureFilterBuilder
	
	#region FeatureParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FeatureColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Feature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureParameterBuilder : ParameterizedSqlFilterBuilder<FeatureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureParameterBuilder class.
		/// </summary>
		public FeatureParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureParameterBuilder
} // end namespace
