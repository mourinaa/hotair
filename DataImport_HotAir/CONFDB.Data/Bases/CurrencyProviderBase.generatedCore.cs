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
	/// This class is the base class for any <see cref="CurrencyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CurrencyProviderBaseCore : EntityProviderBase<CONFDB.Entities.Currency, CONFDB.Entities.CurrencyKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CurrencyKey key)
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
		public override CONFDB.Entities.Currency Get(TransactionManager transactionManager, CONFDB.Entities.CurrencyKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Currency_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public CONFDB.Entities.Currency GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public CONFDB.Entities.Currency GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public CONFDB.Entities.Currency GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public CONFDB.Entities.Currency GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public CONFDB.Entities.Currency GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Currency_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Currency"/> class.</returns>
		public abstract CONFDB.Entities.Currency GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Currency&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Currency&gt;"/></returns>
		public static CONFDB.Entities.TList<Currency> Fill(IDataReader reader, CONFDB.Entities.TList<Currency> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Currency c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Currency")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CurrencyColumn.Id - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.CurrencyColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Currency>(
					key.ToString(), // EntityTrackingKey
					"Currency",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Currency();
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
					c.Id = (System.String)reader[((int)CurrencyColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.LongName = (reader.IsDBNull(((int)CurrencyColumn.LongName - 1)))?null:(System.String)reader[((int)CurrencyColumn.LongName - 1)];
					c.Enabled = (reader.IsDBNull(((int)CurrencyColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)CurrencyColumn.Enabled - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)CurrencyColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)CurrencyColumn.DisplayOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Currency"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Currency"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Currency entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)CurrencyColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["ID"];
			entity.LongName = (reader.IsDBNull(((int)CurrencyColumn.LongName - 1)))?null:(System.String)reader[((int)CurrencyColumn.LongName - 1)];
			entity.Enabled = (reader.IsDBNull(((int)CurrencyColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)CurrencyColumn.Enabled - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)CurrencyColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)CurrencyColumn.DisplayOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Currency"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Currency"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Currency entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["ID"];
			entity.OriginalId = (System.String)dataRow["ID"];
			entity.LongName = Convert.IsDBNull(dataRow["LongName"]) ? null : (System.String)dataRow["LongName"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int16?)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Currency"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Currency Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Currency entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CommissionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Commission>|CommissionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommissionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommissionCollection = DataRepository.CommissionProvider.GetByCurrencyId(transactionManager, entity.Id);

				if (deep && entity.CommissionCollection.Count > 0)
				{
					deepHandles.Add("CommissionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Commission>) DataRepository.CommissionProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.WholesalerCollection = DataRepository.WholesalerProvider.GetByCurrencyId(transactionManager, entity.Id);

				if (deep && entity.WholesalerCollection.Count > 0)
				{
					deepHandles.Add("WholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler>) DataRepository.WholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.WholesalerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductRateValueCollectionGetByBuyRateCurrencyId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductRateValue>|ProductRateValueCollectionGetByBuyRateCurrencyId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateValueCollectionGetByBuyRateCurrencyId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductRateValueCollectionGetByBuyRateCurrencyId = DataRepository.ProductRateValueProvider.GetByBuyRateCurrencyId(transactionManager, entity.Id);

				if (deep && entity.ProductRateValueCollectionGetByBuyRateCurrencyId.Count > 0)
				{
					deepHandles.Add("ProductRateValueCollectionGetByBuyRateCurrencyId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRateValue>) DataRepository.ProductRateValueProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateValueCollectionGetByBuyRateCurrencyId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProductRateValueCollectionGetBySellRateCurrencyId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductRateValue>|ProductRateValueCollectionGetBySellRateCurrencyId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateValueCollectionGetBySellRateCurrencyId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductRateValueCollectionGetBySellRateCurrencyId = DataRepository.ProductRateValueProvider.GetBySellRateCurrencyId(transactionManager, entity.Id);

				if (deep && entity.ProductRateValueCollectionGetBySellRateCurrencyId.Count > 0)
				{
					deepHandles.Add("ProductRateValueCollectionGetBySellRateCurrencyId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProductRateValue>) DataRepository.ProductRateValueProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductRateValueCollectionGetBySellRateCurrencyId, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerCollection = DataRepository.CustomerProvider.GetByCurrencyId(transactionManager, entity.Id);

				if (deep && entity.CustomerCollection.Count > 0)
				{
					deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Currency object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Currency instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Currency Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Currency entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Commission>
				if (CanDeepSave(entity.CommissionCollection, "List<Commission>|CommissionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Commission child in entity.CommissionCollection)
					{
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.Id;
						}
						else
						{
							child.CurrencyId = entity.Id;
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
				
	
			#region List<Wholesaler>
				if (CanDeepSave(entity.WholesalerCollection, "List<Wholesaler>|WholesalerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler child in entity.WholesalerCollection)
					{
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.Id;
						}
						else
						{
							child.CurrencyId = entity.Id;
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
				
	
			#region List<ProductRateValue>
				if (CanDeepSave(entity.ProductRateValueCollectionGetByBuyRateCurrencyId, "List<ProductRateValue>|ProductRateValueCollectionGetByBuyRateCurrencyId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductRateValue child in entity.ProductRateValueCollectionGetByBuyRateCurrencyId)
					{
						if(child.BuyRateCurrencyIdSource != null)
						{
							child.BuyRateCurrencyId = child.BuyRateCurrencyIdSource.Id;
						}
						else
						{
							child.BuyRateCurrencyId = entity.Id;
						}

					}

					if (entity.ProductRateValueCollectionGetByBuyRateCurrencyId.Count > 0 || entity.ProductRateValueCollectionGetByBuyRateCurrencyId.DeletedItems.Count > 0)
					{
						//DataRepository.ProductRateValueProvider.Save(transactionManager, entity.ProductRateValueCollectionGetByBuyRateCurrencyId);
						
						deepHandles.Add("ProductRateValueCollectionGetByBuyRateCurrencyId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductRateValue >) DataRepository.ProductRateValueProvider.DeepSave,
							new object[] { transactionManager, entity.ProductRateValueCollectionGetByBuyRateCurrencyId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProductRateValue>
				if (CanDeepSave(entity.ProductRateValueCollectionGetBySellRateCurrencyId, "List<ProductRateValue>|ProductRateValueCollectionGetBySellRateCurrencyId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductRateValue child in entity.ProductRateValueCollectionGetBySellRateCurrencyId)
					{
						if(child.SellRateCurrencyIdSource != null)
						{
							child.SellRateCurrencyId = child.SellRateCurrencyIdSource.Id;
						}
						else
						{
							child.SellRateCurrencyId = entity.Id;
						}

					}

					if (entity.ProductRateValueCollectionGetBySellRateCurrencyId.Count > 0 || entity.ProductRateValueCollectionGetBySellRateCurrencyId.DeletedItems.Count > 0)
					{
						//DataRepository.ProductRateValueProvider.Save(transactionManager, entity.ProductRateValueCollectionGetBySellRateCurrencyId);
						
						deepHandles.Add("ProductRateValueCollectionGetBySellRateCurrencyId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProductRateValue >) DataRepository.ProductRateValueProvider.DeepSave,
							new object[] { transactionManager, entity.ProductRateValueCollectionGetBySellRateCurrencyId, deepSaveType, childTypes, innerList }
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
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.Id;
						}
						else
						{
							child.CurrencyId = entity.Id;
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
	
	#region CurrencyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Currency</c>
	///</summary>
	public enum CurrencyChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for CommissionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Commission>))]
		CommissionCollection,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for WholesalerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler>))]
		WholesalerCollection,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for ProductRateValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRateValue>))]
		ProductRateValueCollectionGetByBuyRateCurrencyId,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for ProductRateValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductRateValue>))]
		ProductRateValueCollectionGetBySellRateCurrencyId,

		///<summary>
		/// Collection of <c>Currency</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollection,
	}
	
	#endregion CurrencyChildEntityTypes
	
	#region CurrencyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyFilterBuilder : SqlFilterBuilder<CurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		public CurrencyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyFilterBuilder
	
	#region CurrencyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CurrencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrencyParameterBuilder : ParameterizedSqlFilterBuilder<CurrencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		public CurrencyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrencyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrencyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrencyParameterBuilder
} // end namespace
