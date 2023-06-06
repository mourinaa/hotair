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
	/// This class is the base class for any <see cref="StateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StateProviderBaseCore : EntityProviderBase<CONFDB.Entities.State, CONFDB.Entities.StateKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.StateKey key)
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
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		Country_State_FK1 Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		public CONFDB.Entities.TList<State> GetByCountryId(System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		Country_State_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<State> GetByCountryId(TransactionManager transactionManager, System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		Country_State_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		public CONFDB.Entities.TList<State> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		country_State_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		public CONFDB.Entities.TList<State> GetByCountryId(System.String _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		country_State_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		public CONFDB.Entities.TList<State> GetByCountryId(System.String _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Country_State_FK1 key.
		///		Country_State_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.State objects.</returns>
		public abstract CONFDB.Entities.TList<State> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.State Get(TransactionManager transactionManager, CONFDB.Entities.StateKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_State index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_State index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_State index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_State index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_State index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_State index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public abstract CONFDB.Entities.State GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_State_CountryID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetByIdCountryId(System.String _id, System.String _countryId)
		{
			int count = -1;
			return GetByIdCountryId(null,_id, _countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_State_CountryID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetByIdCountryId(System.String _id, System.String _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCountryId(null, _id, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_State_CountryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetByIdCountryId(TransactionManager transactionManager, System.String _id, System.String _countryId)
		{
			int count = -1;
			return GetByIdCountryId(transactionManager, _id, _countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_State_CountryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetByIdCountryId(TransactionManager transactionManager, System.String _id, System.String _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCountryId(transactionManager, _id, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_State_CountryID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public CONFDB.Entities.State GetByIdCountryId(System.String _id, System.String _countryId, int start, int pageLength, out int count)
		{
			return GetByIdCountryId(null, _id, _countryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_State_CountryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.State"/> class.</returns>
		public abstract CONFDB.Entities.State GetByIdCountryId(TransactionManager transactionManager, System.String _id, System.String _countryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;State&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;State&gt;"/></returns>
		public static CONFDB.Entities.TList<State> Fill(IDataReader reader, CONFDB.Entities.TList<State> rows, int start, int pageLength)
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
				
				CONFDB.Entities.State c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("State")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.StateColumn.Id - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.StateColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<State>(
					key.ToString(), // EntityTrackingKey
					"State",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.State();
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
					c.Id = (System.String)reader[((int)StateColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.CountryId = (System.String)reader[((int)StateColumn.CountryId - 1)];
					c.LongName = (reader.IsDBNull(((int)StateColumn.LongName - 1)))?null:(System.String)reader[((int)StateColumn.LongName - 1)];
					c.FederalTax = (reader.IsDBNull(((int)StateColumn.FederalTax - 1)))?null:(System.Decimal?)reader[((int)StateColumn.FederalTax - 1)];
					c.LocalTax = (reader.IsDBNull(((int)StateColumn.LocalTax - 1)))?null:(System.Decimal?)reader[((int)StateColumn.LocalTax - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)StateColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)StateColumn.DisplayOrder - 1)];
					c.LocalOnFederalTax = (System.Boolean)reader[((int)StateColumn.LocalOnFederalTax - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.State"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.State"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.State entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)StateColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["ID"];
			entity.CountryId = (System.String)reader[((int)StateColumn.CountryId - 1)];
			entity.LongName = (reader.IsDBNull(((int)StateColumn.LongName - 1)))?null:(System.String)reader[((int)StateColumn.LongName - 1)];
			entity.FederalTax = (reader.IsDBNull(((int)StateColumn.FederalTax - 1)))?null:(System.Decimal?)reader[((int)StateColumn.FederalTax - 1)];
			entity.LocalTax = (reader.IsDBNull(((int)StateColumn.LocalTax - 1)))?null:(System.Decimal?)reader[((int)StateColumn.LocalTax - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)StateColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)StateColumn.DisplayOrder - 1)];
			entity.LocalOnFederalTax = (System.Boolean)reader[((int)StateColumn.LocalOnFederalTax - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.State"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.State"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.State entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["ID"];
			entity.OriginalId = (System.String)dataRow["ID"];
			entity.CountryId = (System.String)dataRow["CountryID"];
			entity.LongName = Convert.IsDBNull(dataRow["LongName"]) ? null : (System.String)dataRow["LongName"];
			entity.FederalTax = Convert.IsDBNull(dataRow["FederalTax"]) ? null : (System.Decimal?)dataRow["FederalTax"];
			entity.LocalTax = Convert.IsDBNull(dataRow["LocalTax"]) ? null : (System.Decimal?)dataRow["LocalTax"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int16?)dataRow["DisplayOrder"];
			entity.LocalOnFederalTax = (System.Boolean)dataRow["LocalOnFederalTax"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.State"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.State Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.State entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Country|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CountryId;
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountryProvider.GetById(transactionManager, entity.CountryId);		
				
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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerCollectionGetByPrimaryContactRegion
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollectionGetByPrimaryContactRegion", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollectionGetByPrimaryContactRegion' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollectionGetByPrimaryContactRegion = DataRepository.CustomerProvider.GetByPrimaryContactRegion(transactionManager, entity.Id);

				if (deep && entity.CustomerCollectionGetByPrimaryContactRegion.Count > 0)
				{
					deepHandles.Add("CustomerCollectionGetByPrimaryContactRegion",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollectionGetByPrimaryContactRegion, deep, deepLoadType, childTypes, innerList }
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

				entity.WholesalerCollection = DataRepository.WholesalerProvider.GetByBillingRegion(transactionManager, entity.Id);

				if (deep && entity.WholesalerCollection.Count > 0)
				{
					deepHandles.Add("WholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler>) DataRepository.WholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.WholesalerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerCollectionGetByBillingContactRegion
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollectionGetByBillingContactRegion", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollectionGetByBillingContactRegion' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollectionGetByBillingContactRegion = DataRepository.CustomerProvider.GetByBillingContactRegion(transactionManager, entity.Id);

				if (deep && entity.CustomerCollectionGetByBillingContactRegion.Count > 0)
				{
					deepHandles.Add("CustomerCollectionGetByBillingContactRegion",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollectionGetByBillingContactRegion, deep, deepLoadType, childTypes, innerList }
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

				entity.UserCollection = DataRepository.UserProvider.GetByRegion(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the CONFDB.Entities.State object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.State instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.State Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.State entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollectionGetByPrimaryContactRegion, "List<Customer>|CustomerCollectionGetByPrimaryContactRegion", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollectionGetByPrimaryContactRegion)
					{
						if(child.PrimaryContactRegionSource != null)
						{
							child.PrimaryContactRegion = child.PrimaryContactRegionSource.Id;
						}
						else
						{
							child.PrimaryContactRegion = entity.Id;
						}

					}

					if (entity.CustomerCollectionGetByPrimaryContactRegion.Count > 0 || entity.CustomerCollectionGetByPrimaryContactRegion.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollectionGetByPrimaryContactRegion);
						
						deepHandles.Add("CustomerCollectionGetByPrimaryContactRegion",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollectionGetByPrimaryContactRegion, deepSaveType, childTypes, innerList }
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
						if(child.BillingRegionSource != null)
						{
							child.BillingRegion = child.BillingRegionSource.Id;
						}
						else
						{
							child.BillingRegion = entity.Id;
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
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollectionGetByBillingContactRegion, "List<Customer>|CustomerCollectionGetByBillingContactRegion", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollectionGetByBillingContactRegion)
					{
						if(child.BillingContactRegionSource != null)
						{
							child.BillingContactRegion = child.BillingContactRegionSource.Id;
						}
						else
						{
							child.BillingContactRegion = entity.Id;
						}

					}

					if (entity.CustomerCollectionGetByBillingContactRegion.Count > 0 || entity.CustomerCollectionGetByBillingContactRegion.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollectionGetByBillingContactRegion);
						
						deepHandles.Add("CustomerCollectionGetByBillingContactRegion",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollectionGetByBillingContactRegion, deepSaveType, childTypes, innerList }
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
						if(child.RegionSource != null)
						{
							child.Region = child.RegionSource.Id;
						}
						else
						{
							child.Region = entity.Id;
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
	
	#region StateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.State</c>
	///</summary>
	public enum StateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Country</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
	
		///<summary>
		/// Collection of <c>State</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollectionGetByPrimaryContactRegion,

		///<summary>
		/// Collection of <c>State</c> as OneToMany for WholesalerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler>))]
		WholesalerCollection,

		///<summary>
		/// Collection of <c>State</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollectionGetByBillingContactRegion,

		///<summary>
		/// Collection of <c>State</c> as OneToMany for UserCollection
		///</summary>
		[ChildEntityType(typeof(TList<User>))]
		UserCollection,
	}
	
	#endregion StateChildEntityTypes
	
	#region StateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateFilterBuilder : SqlFilterBuilder<StateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateFilterBuilder class.
		/// </summary>
		public StateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateFilterBuilder
	
	#region StateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="State"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StateParameterBuilder : ParameterizedSqlFilterBuilder<StateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StateParameterBuilder class.
		/// </summary>
		public StateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StateParameterBuilder
} // end namespace
