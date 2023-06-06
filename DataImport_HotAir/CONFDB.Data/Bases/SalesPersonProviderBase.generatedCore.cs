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
	/// This class is the base class for any <see cref="SalesPersonProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesPersonProviderBaseCore : EntityProviderBase<CONFDB.Entities.SalesPerson, CONFDB.Entities.SalesPersonKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.SalesPersonKey key)
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
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		FK_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="_salesManagerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(System.Int32? _salesManagerId)
		{
			int count = -1;
			return GetBySalesManagerId(_salesManagerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		FK_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesManagerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(TransactionManager transactionManager, System.Int32? _salesManagerId)
		{
			int count = -1;
			return GetBySalesManagerId(transactionManager, _salesManagerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		FK_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesManagerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(TransactionManager transactionManager, System.Int32? _salesManagerId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesManagerId(transactionManager, _salesManagerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		fk_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesManagerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(System.Int32? _salesManagerId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesManagerId(null, _salesManagerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		fk_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesManagerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(System.Int32? _salesManagerId, int start, int pageLength,out int count)
		{
			return GetBySalesManagerId(null, _salesManagerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesPerson_SalesManager key.
		///		FK_SalesPerson_SalesManager Description: Sales Manager for the Sales Person
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesManagerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public abstract CONFDB.Entities.TList<SalesPerson> GetBySalesManagerId(TransactionManager transactionManager, System.Int32? _salesManagerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		Wholesaler_SalesPerson_FK1 Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		Wholesaler_SalesPerson_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		Wholesaler_SalesPerson_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		wholesaler_SalesPerson_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		wholesaler_SalesPerson_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_SalesPerson_FK1 key.
		///		Wholesaler_SalesPerson_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SalesPerson objects.</returns>
		public abstract CONFDB.Entities.TList<SalesPerson> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.SalesPerson Get(TransactionManager transactionManager, CONFDB.Entities.SalesPersonKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SalesPerson_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public CONFDB.Entities.SalesPerson GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public CONFDB.Entities.SalesPerson GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public CONFDB.Entities.SalesPerson GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public CONFDB.Entities.SalesPerson GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public CONFDB.Entities.SalesPerson GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SalesPerson_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SalesPerson"/> class.</returns>
		public abstract CONFDB.Entities.SalesPerson GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;SalesPerson&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;SalesPerson&gt;"/></returns>
		public static CONFDB.Entities.TList<SalesPerson> Fill(IDataReader reader, CONFDB.Entities.TList<SalesPerson> rows, int start, int pageLength)
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
				
				CONFDB.Entities.SalesPerson c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesPerson")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.SalesPersonColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.SalesPersonColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<SalesPerson>(
					key.ToString(), // EntityTrackingKey
					"SalesPerson",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.SalesPerson();
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
					c.Id = (System.Int32)reader[((int)SalesPersonColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)SalesPersonColumn.WholesalerId - 1)];
					c.FullName = (System.String)reader[((int)SalesPersonColumn.FullName - 1)];
					c.EmailAddress = (System.String)reader[((int)SalesPersonColumn.EmailAddress - 1)];
					c.ExternalAgent = (reader.IsDBNull(((int)SalesPersonColumn.ExternalAgent - 1)))?null:(System.Boolean?)reader[((int)SalesPersonColumn.ExternalAgent - 1)];
					c.Enabled = (System.Boolean)reader[((int)SalesPersonColumn.Enabled - 1)];
					c.SalesManagerId = (reader.IsDBNull(((int)SalesPersonColumn.SalesManagerId - 1)))?null:(System.Int32?)reader[((int)SalesPersonColumn.SalesManagerId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SalesPerson"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SalesPerson"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.SalesPerson entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)SalesPersonColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)SalesPersonColumn.WholesalerId - 1)];
			entity.FullName = (System.String)reader[((int)SalesPersonColumn.FullName - 1)];
			entity.EmailAddress = (System.String)reader[((int)SalesPersonColumn.EmailAddress - 1)];
			entity.ExternalAgent = (reader.IsDBNull(((int)SalesPersonColumn.ExternalAgent - 1)))?null:(System.Boolean?)reader[((int)SalesPersonColumn.ExternalAgent - 1)];
			entity.Enabled = (System.Boolean)reader[((int)SalesPersonColumn.Enabled - 1)];
			entity.SalesManagerId = (reader.IsDBNull(((int)SalesPersonColumn.SalesManagerId - 1)))?null:(System.Int32?)reader[((int)SalesPersonColumn.SalesManagerId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SalesPerson"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SalesPerson"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.SalesPerson entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.EmailAddress = (System.String)dataRow["EmailAddress"];
			entity.ExternalAgent = Convert.IsDBNull(dataRow["ExternalAgent"]) ? null : (System.Boolean?)dataRow["ExternalAgent"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.SalesManagerId = Convert.IsDBNull(dataRow["SalesManagerID"]) ? null : (System.Int32?)dataRow["SalesManagerID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.SalesPerson"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.SalesPerson Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.SalesPerson entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalesManagerIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesManagerIdSource", deepLoadType, innerList) 
				&& entity.SalesManagerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SalesManagerId ?? (int)0);
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesManagerIdSource = tmpEntity;
				else
					entity.SalesManagerIdSource = DataRepository.SalesPersonProvider.GetById(transactionManager, (entity.SalesManagerId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesManagerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesManagerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesManagerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesManagerIdSource

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
			
			#region CommissionCustomerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CommissionCustomer>|CommissionCustomerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommissionCustomerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommissionCustomerCollection = DataRepository.CommissionCustomerProvider.GetBySalesPersonId(transactionManager, entity.Id);

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

				entity.CommissionCollection = DataRepository.CommissionProvider.GetBySalesPersonId(transactionManager, entity.Id);

				if (deep && entity.CommissionCollection.Count > 0)
				{
					deepHandles.Add("CommissionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Commission>) DataRepository.CommissionProvider.DeepLoad,
						new object[] { transactionManager, entity.CommissionCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.SalesPersonCollection = DataRepository.SalesPersonProvider.GetBySalesManagerId(transactionManager, entity.Id);

				if (deep && entity.SalesPersonCollection.Count > 0)
				{
					deepHandles.Add("SalesPersonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesPerson>) DataRepository.SalesPersonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesPersonCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.LeadCollection = DataRepository.LeadProvider.GetBySalesPersonId(transactionManager, entity.Id);

				if (deep && entity.LeadCollection.Count > 0)
				{
					deepHandles.Add("LeadCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lead>) DataRepository.LeadProvider.DeepLoad,
						new object[] { transactionManager, entity.LeadCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerCollection = DataRepository.CustomerProvider.GetBySalesPersonId(transactionManager, entity.Id);

				if (deep && entity.CustomerCollection.Count > 0)
				{
					deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.UserCollection = DataRepository.UserProvider.GetBySalesPersonId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the CONFDB.Entities.SalesPerson object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.SalesPerson instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.SalesPerson Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.SalesPerson entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalesManagerIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesManagerIdSource", deepSaveType, innerList) 
				&& entity.SalesManagerIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesManagerIdSource);
				entity.SalesManagerId = entity.SalesManagerIdSource.Id;
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
	
			#region List<CommissionCustomer>
				if (CanDeepSave(entity.CommissionCustomerCollection, "List<CommissionCustomer>|CommissionCustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CommissionCustomer child in entity.CommissionCustomerCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.Id;
						}
						else
						{
							child.SalesPersonId = entity.Id;
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
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.Id;
						}
						else
						{
							child.SalesPersonId = entity.Id;
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
				
	
			#region List<SalesPerson>
				if (CanDeepSave(entity.SalesPersonCollection, "List<SalesPerson>|SalesPersonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesPerson child in entity.SalesPersonCollection)
					{
						if(child.SalesManagerIdSource != null)
						{
							child.SalesManagerId = child.SalesManagerIdSource.Id;
						}
						else
						{
							child.SalesManagerId = entity.Id;
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
				
	
			#region List<Lead>
				if (CanDeepSave(entity.LeadCollection, "List<Lead>|LeadCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lead child in entity.LeadCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.Id;
						}
						else
						{
							child.SalesPersonId = entity.Id;
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
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollection, "List<Customer>|CustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.Id;
						}
						else
						{
							child.SalesPersonId = entity.Id;
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
				
	
			#region List<User>
				if (CanDeepSave(entity.UserCollection, "List<User>|UserCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(User child in entity.UserCollection)
					{
						if(child.SalesPersonIdSource != null)
						{
							child.SalesPersonId = child.SalesPersonIdSource.Id;
						}
						else
						{
							child.SalesPersonId = entity.Id;
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
	
	#region SalesPersonChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.SalesPerson</c>
	///</summary>
	public enum SalesPersonChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesManagerIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
	
		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for CommissionCustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<CommissionCustomer>))]
		CommissionCustomerCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for CommissionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Commission>))]
		CommissionCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for SalesPersonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesPerson>))]
		SalesPersonCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for LeadCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lead>))]
		LeadCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollection,

		///<summary>
		/// Collection of <c>SalesPerson</c> as OneToMany for UserCollection
		///</summary>
		[ChildEntityType(typeof(TList<User>))]
		UserCollection,
	}
	
	#endregion SalesPersonChildEntityTypes
	
	#region SalesPersonFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesPersonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonFilterBuilder : SqlFilterBuilder<SalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		public SalesPersonFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonFilterBuilder
	
	#region SalesPersonParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesPersonColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesPerson"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesPersonParameterBuilder : ParameterizedSqlFilterBuilder<SalesPersonColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		public SalesPersonParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesPersonParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesPersonParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesPersonParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesPersonParameterBuilder
} // end namespace
