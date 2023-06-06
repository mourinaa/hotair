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
	/// This class is the base class for any <see cref="CountryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountryProviderBaseCore : EntityProviderBase<CONFDB.Entities.Country, CONFDB.Entities.CountryKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CountryKey key)
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
		public override CONFDB.Entities.Country Get(TransactionManager transactionManager, CONFDB.Entities.CountryKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Country_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public CONFDB.Entities.Country GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public CONFDB.Entities.Country GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public CONFDB.Entities.Country GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public CONFDB.Entities.Country GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public CONFDB.Entities.Country GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Country"/> class.</returns>
		public abstract CONFDB.Entities.Country GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Country_AreaCode index.
		/// </summary>
		/// <param name="_countryAreaCode"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Country> GetByCountryAreaCode(System.String _countryAreaCode)
		{
			int count = -1;
			return GetByCountryAreaCode(null,_countryAreaCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Country_AreaCode index.
		/// </summary>
		/// <param name="_countryAreaCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Country> GetByCountryAreaCode(System.String _countryAreaCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryAreaCode(null, _countryAreaCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Country_AreaCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryAreaCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Country> GetByCountryAreaCode(TransactionManager transactionManager, System.String _countryAreaCode)
		{
			int count = -1;
			return GetByCountryAreaCode(transactionManager, _countryAreaCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Country_AreaCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryAreaCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Country> GetByCountryAreaCode(TransactionManager transactionManager, System.String _countryAreaCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryAreaCode(transactionManager, _countryAreaCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Country_AreaCode index.
		/// </summary>
		/// <param name="_countryAreaCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Country> GetByCountryAreaCode(System.String _countryAreaCode, int start, int pageLength, out int count)
		{
			return GetByCountryAreaCode(null, _countryAreaCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Country_AreaCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryAreaCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Country&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Country> GetByCountryAreaCode(TransactionManager transactionManager, System.String _countryAreaCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Country&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Country&gt;"/></returns>
		public static CONFDB.Entities.TList<Country> Fill(IDataReader reader, CONFDB.Entities.TList<Country> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Country c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Country")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CountryColumn.Id - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.CountryColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Country>(
					key.ToString(), // EntityTrackingKey
					"Country",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Country();
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
					c.Id = (System.String)reader[((int)CountryColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Description = (reader.IsDBNull(((int)CountryColumn.Description - 1)))?null:(System.String)reader[((int)CountryColumn.Description - 1)];
					c.CountryDialingCode = (reader.IsDBNull(((int)CountryColumn.CountryDialingCode - 1)))?null:(System.String)reader[((int)CountryColumn.CountryDialingCode - 1)];
					c.CountryAreaCode = (reader.IsDBNull(((int)CountryColumn.CountryAreaCode - 1)))?null:(System.String)reader[((int)CountryColumn.CountryAreaCode - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)CountryColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)CountryColumn.DisplayOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Country"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Country"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Country entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)CountryColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["ID"];
			entity.Description = (reader.IsDBNull(((int)CountryColumn.Description - 1)))?null:(System.String)reader[((int)CountryColumn.Description - 1)];
			entity.CountryDialingCode = (reader.IsDBNull(((int)CountryColumn.CountryDialingCode - 1)))?null:(System.String)reader[((int)CountryColumn.CountryDialingCode - 1)];
			entity.CountryAreaCode = (reader.IsDBNull(((int)CountryColumn.CountryAreaCode - 1)))?null:(System.String)reader[((int)CountryColumn.CountryAreaCode - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)CountryColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)CountryColumn.DisplayOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Country"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Country"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Country entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["ID"];
			entity.OriginalId = (System.String)dataRow["ID"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.CountryDialingCode = Convert.IsDBNull(dataRow["CountryDialingCode"]) ? null : (System.String)dataRow["CountryDialingCode"];
			entity.CountryAreaCode = Convert.IsDBNull(dataRow["CountryAreaCode"]) ? null : (System.String)dataRow["CountryAreaCode"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Country"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Country Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Country entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerCollectionGetByPrimaryContactCountry
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollectionGetByPrimaryContactCountry", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollectionGetByPrimaryContactCountry' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollectionGetByPrimaryContactCountry = DataRepository.CustomerProvider.GetByPrimaryContactCountry(transactionManager, entity.Id);

				if (deep && entity.CustomerCollectionGetByPrimaryContactCountry.Count > 0)
				{
					deepHandles.Add("CustomerCollectionGetByPrimaryContactCountry",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollectionGetByPrimaryContactCountry, deep, deepLoadType, childTypes, innerList }
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

				entity.ProductRateCollection = DataRepository.ProductRateProvider.GetByCountryId(transactionManager, entity.Id);

				if (deep && entity.ProductRateCollection.Count > 0)
				{
					deepHandles.Add("ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRate>) DataRepository.ProductRateProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WholesalerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Wholesaler>|WholesalerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WholesalerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WholesalerCollection = DataRepository.WholesalerProvider.GetByBillingCountry(transactionManager, entity.Id);

				if (deep && entity.WholesalerCollection.Count > 0)
				{
					deepHandles.Add("WholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler>) DataRepository.WholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.WholesalerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region StateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<State>|StateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.StateCollection = DataRepository.StateProvider.GetByCountryId(transactionManager, entity.Id);

				if (deep && entity.StateCollection.Count > 0)
				{
					deepHandles.Add("StateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<State>) DataRepository.StateProvider.DeepLoad,
						new object[] { transactionManager, entity.StateCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CompanyInfoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CompanyInfo>|CompanyInfoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyInfoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CompanyInfoCollection = DataRepository.CompanyInfoProvider.GetByCountryId(transactionManager, entity.Id);

				if (deep && entity.CompanyInfoCollection.Count > 0)
				{
					deepHandles.Add("CompanyInfoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CompanyInfo>) DataRepository.CompanyInfoProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyInfoCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerCollectionGetByBillingContactCountry
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollectionGetByBillingContactCountry", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollectionGetByBillingContactCountry' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollectionGetByBillingContactCountry = DataRepository.CustomerProvider.GetByBillingContactCountry(transactionManager, entity.Id);

				if (deep && entity.CustomerCollectionGetByBillingContactCountry.Count > 0)
				{
					deepHandles.Add("CustomerCollectionGetByBillingContactCountry",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollectionGetByBillingContactCountry, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region UserCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<User>|UserCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.UserCollection = DataRepository.UserProvider.GetByCountry(transactionManager, entity.Id);

				if (deep && entity.UserCollection.Count > 0)
				{
					deepHandles.Add("UserCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<User>) DataRepository.UserProvider.DeepLoad,
						new object[] { transactionManager, entity.UserCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Country object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Country instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Country Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Country entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollectionGetByPrimaryContactCountry, "List<Customer>|CustomerCollectionGetByPrimaryContactCountry", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollectionGetByPrimaryContactCountry)
					{
						if(child.PrimaryContactCountrySource != null)
						{
							child.PrimaryContactCountry = child.PrimaryContactCountrySource.Id;
						}
						else
						{
							child.PrimaryContactCountry = entity.Id;
						}

					}

					if (entity.CustomerCollectionGetByPrimaryContactCountry.Count > 0 || entity.CustomerCollectionGetByPrimaryContactCountry.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollectionGetByPrimaryContactCountry);
						
						deepHandles.Add("CustomerCollectionGetByPrimaryContactCountry",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollectionGetByPrimaryContactCountry, deepSaveType, childTypes, innerList }
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
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.Id;
						}
						else
						{
							child.CountryId = entity.Id;
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
				
	
			#region List<Wholesaler>
				if (CanDeepSave(entity.WholesalerCollection, "List<Wholesaler>|WholesalerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler child in entity.WholesalerCollection)
					{
						if(child.BillingCountrySource != null)
						{
							child.BillingCountry = child.BillingCountrySource.Id;
						}
						else
						{
							child.BillingCountry = entity.Id;
						}

					}

					if (entity.WholesalerCollection.Count > 0 || entity.WholesalerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WholesalerProvider.Save(transactionManager, entity.WholesalerCollection);
						
						deepHandles.Add("WholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Wholesaler >) DataRepository.WholesalerProvider.DeepSave,
							new object[] { transactionManager, entity.WholesalerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<State>
				if (CanDeepSave(entity.StateCollection, "List<State>|StateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(State child in entity.StateCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.Id;
						}
						else
						{
							child.CountryId = entity.Id;
						}

					}

					if (entity.StateCollection.Count > 0 || entity.StateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.StateProvider.Save(transactionManager, entity.StateCollection);
						
						deepHandles.Add("StateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< State >) DataRepository.StateProvider.DeepSave,
							new object[] { transactionManager, entity.StateCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CompanyInfo>
				if (CanDeepSave(entity.CompanyInfoCollection, "List<CompanyInfo>|CompanyInfoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CompanyInfo child in entity.CompanyInfoCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.Id;
						}
						else
						{
							child.CountryId = entity.Id;
						}

					}

					if (entity.CompanyInfoCollection.Count > 0 || entity.CompanyInfoCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CompanyInfoProvider.Save(transactionManager, entity.CompanyInfoCollection);
						
						deepHandles.Add("CompanyInfoCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CompanyInfo >) DataRepository.CompanyInfoProvider.DeepSave,
							new object[] { transactionManager, entity.CompanyInfoCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollectionGetByBillingContactCountry, "List<Customer>|CustomerCollectionGetByBillingContactCountry", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollectionGetByBillingContactCountry)
					{
						if(child.BillingContactCountrySource != null)
						{
							child.BillingContactCountry = child.BillingContactCountrySource.Id;
						}
						else
						{
							child.BillingContactCountry = entity.Id;
						}

					}

					if (entity.CustomerCollectionGetByBillingContactCountry.Count > 0 || entity.CustomerCollectionGetByBillingContactCountry.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollectionGetByBillingContactCountry);
						
						deepHandles.Add("CustomerCollectionGetByBillingContactCountry",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollectionGetByBillingContactCountry, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<User>
				if (CanDeepSave(entity.UserCollection, "List<User>|UserCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(User child in entity.UserCollection)
					{
						if(child.CountrySource != null)
						{
							child.Country = child.CountrySource.Id;
						}
						else
						{
							child.Country = entity.Id;
						}

					}

					if (entity.UserCollection.Count > 0 || entity.UserCollection.DeletedItems.Count > 0)
					{
						//DataRepository.UserProvider.Save(transactionManager, entity.UserCollection);
						
						deepHandles.Add("UserCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< User >) DataRepository.UserProvider.DeepSave,
							new object[] { transactionManager, entity.UserCollection, deepSaveType, childTypes, innerList }
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
	
	#region CountryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Country</c>
	///</summary>
	public enum CountryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollectionGetByPrimaryContactCountry,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for ProductRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRate>))]
		ProductRateCollection,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for WholesalerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler>))]
		WholesalerCollection,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for StateCollection
		///</summary>
		[ChildEntityType(typeof(TList<State>))]
		StateCollection,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for CompanyInfoCollection
		///</summary>
		[ChildEntityType(typeof(TList<CompanyInfo>))]
		CompanyInfoCollection,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollectionGetByBillingContactCountry,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for UserCollection
		///</summary>
		[ChildEntityType(typeof(TList<User>))]
		UserCollection,
	}
	
	#endregion CountryChildEntityTypes
	
	#region CountryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CountryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryFilterBuilder : SqlFilterBuilder<CountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		public CountryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryFilterBuilder
	
	#region CountryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CountryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryParameterBuilder : ParameterizedSqlFilterBuilder<CountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		public CountryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryParameterBuilder
} // end namespace
