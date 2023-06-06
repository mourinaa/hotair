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
	/// This class is the base class for any <see cref="MarketingServiceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MarketingServiceProviderBaseCore : EntityProviderBase<CONFDB.Entities.MarketingService, CONFDB.Entities.MarketingServiceKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByUserIdFromUser_MarketingService
		
		/// <summary>
		///		Gets MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of MarketingService objects.</returns>
		public TList<MarketingService> GetByUserIdFromUser_MarketingService(System.Int32 _userId)
		{
			int count = -1;
			return GetByUserIdFromUser_MarketingService(null,_userId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of MarketingService objects.</returns>
		public TList<MarketingService> GetByUserIdFromUser_MarketingService(System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromUser_MarketingService(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of MarketingService objects.</returns>
		public TList<MarketingService> GetByUserIdFromUser_MarketingService(TransactionManager transactionManager, System.Int32 _userId)
		{
			int count = -1;
			return GetByUserIdFromUser_MarketingService(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of MarketingService objects.</returns>
		public TList<MarketingService> GetByUserIdFromUser_MarketingService(TransactionManager transactionManager, System.Int32 _userId,int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromUser_MarketingService(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of MarketingService objects.</returns>
		public TList<MarketingService> GetByUserIdFromUser_MarketingService(System.Int32 _userId,int start, int pageLength, out int count)
		{
			
			return GetByUserIdFromUser_MarketingService(null, _userId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets MarketingService objects from the datasource by UserID in the
		///		User_MarketingService table. Table MarketingService is related to table User
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of MarketingService objects.</returns>
		public abstract TList<MarketingService> GetByUserIdFromUser_MarketingService(TransactionManager transactionManager,System.Int32 _userId, int start, int pageLength, out int count);
		
		#endregion GetByUserIdFromUser_MarketingService
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.MarketingServiceKey key)
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
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		FK_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		public CONFDB.Entities.TList<MarketingService> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		FK_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<MarketingService> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		FK_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		public CONFDB.Entities.TList<MarketingService> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		fk_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		public CONFDB.Entities.TList<MarketingService> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		fk_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		public CONFDB.Entities.TList<MarketingService> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_MarketingService_Wholesaler key.
		///		FK_MarketingService_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.MarketingService objects.</returns>
		public abstract CONFDB.Entities.TList<MarketingService> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.MarketingService Get(TransactionManager transactionManager, CONFDB.Entities.MarketingServiceKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MarketingService index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public CONFDB.Entities.MarketingService GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MarketingService index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public CONFDB.Entities.MarketingService GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public CONFDB.Entities.MarketingService GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public CONFDB.Entities.MarketingService GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MarketingService index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public CONFDB.Entities.MarketingService GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.MarketingService"/> class.</returns>
		public abstract CONFDB.Entities.MarketingService GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;MarketingService&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;MarketingService&gt;"/></returns>
		public static CONFDB.Entities.TList<MarketingService> Fill(IDataReader reader, CONFDB.Entities.TList<MarketingService> rows, int start, int pageLength)
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
				
				CONFDB.Entities.MarketingService c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MarketingService")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.MarketingServiceColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.MarketingServiceColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<MarketingService>(
					key.ToString(), // EntityTrackingKey
					"MarketingService",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.MarketingService();
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
					c.Id = (System.Int32)reader[((int)MarketingServiceColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)MarketingServiceColumn.WholesalerId - 1)];
					c.Name = (System.String)reader[((int)MarketingServiceColumn.Name - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.MarketingService"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.MarketingService"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.MarketingService entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)MarketingServiceColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)MarketingServiceColumn.WholesalerId - 1)];
			entity.Name = (System.String)reader[((int)MarketingServiceColumn.Name - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.MarketingService"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.MarketingService"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.MarketingService entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.Name = (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.MarketingService"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.MarketingService Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.MarketingService entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
			
			#region User_MarketingServiceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<User_MarketingService>|User_MarketingServiceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'User_MarketingServiceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.User_MarketingServiceCollection = DataRepository.User_MarketingServiceProvider.GetByMarketingServiceId(transactionManager, entity.Id);

				if (deep && entity.User_MarketingServiceCollection.Count > 0)
				{
					deepHandles.Add("User_MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<User_MarketingService>) DataRepository.User_MarketingServiceProvider.DeepLoad,
						new object[] { transactionManager, entity.User_MarketingServiceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region UserIdUserCollection_From_User_MarketingService
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<User>|UserIdUserCollection_From_User_MarketingService", deepLoadType, innerList))
			{
				entity.UserIdUserCollection_From_User_MarketingService = DataRepository.UserProvider.GetByMarketingServiceIdFromUser_MarketingService(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdUserCollection_From_User_MarketingService' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdUserCollection_From_User_MarketingService != null)
				{
					deepHandles.Add("UserIdUserCollection_From_User_MarketingService",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< User >) DataRepository.UserProvider.DeepLoad,
						new object[] { transactionManager, entity.UserIdUserCollection_From_User_MarketingService, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.MarketingService object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.MarketingService instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.MarketingService Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.MarketingService entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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

			#region UserIdUserCollection_From_User_MarketingService>
			if (CanDeepSave(entity.UserIdUserCollection_From_User_MarketingService, "List<User>|UserIdUserCollection_From_User_MarketingService", deepSaveType, innerList))
			{
				if (entity.UserIdUserCollection_From_User_MarketingService.Count > 0 || entity.UserIdUserCollection_From_User_MarketingService.DeletedItems.Count > 0)
				{
					DataRepository.UserProvider.Save(transactionManager, entity.UserIdUserCollection_From_User_MarketingService); 
					deepHandles.Add("UserIdUserCollection_From_User_MarketingService",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<User>) DataRepository.UserProvider.DeepSave,
						new object[] { transactionManager, entity.UserIdUserCollection_From_User_MarketingService, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<User_MarketingService>
				if (CanDeepSave(entity.User_MarketingServiceCollection, "List<User_MarketingService>|User_MarketingServiceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(User_MarketingService child in entity.User_MarketingServiceCollection)
					{
						if(child.MarketingServiceIdSource != null)
						{
								child.MarketingServiceId = child.MarketingServiceIdSource.Id;
						}

						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

					}

					if (entity.User_MarketingServiceCollection.Count > 0 || entity.User_MarketingServiceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.User_MarketingServiceProvider.Save(transactionManager, entity.User_MarketingServiceCollection);
						
						deepHandles.Add("User_MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< User_MarketingService >) DataRepository.User_MarketingServiceProvider.DeepSave,
							new object[] { transactionManager, entity.User_MarketingServiceCollection, deepSaveType, childTypes, innerList }
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
	
	#region MarketingServiceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.MarketingService</c>
	///</summary>
	public enum MarketingServiceChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
	
		///<summary>
		/// Collection of <c>MarketingService</c> as OneToMany for User_MarketingServiceCollection
		///</summary>
		[ChildEntityType(typeof(TList<User_MarketingService>))]
		User_MarketingServiceCollection,

		///<summary>
		/// Collection of <c>MarketingService</c> as ManyToMany for UserCollection_From_User_MarketingService
		///</summary>
		[ChildEntityType(typeof(TList<User>))]
		UserIdUserCollection_From_User_MarketingService,
	}
	
	#endregion MarketingServiceChildEntityTypes
	
	#region MarketingServiceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MarketingServiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceFilterBuilder : SqlFilterBuilder<MarketingServiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilterBuilder class.
		/// </summary>
		public MarketingServiceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MarketingServiceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MarketingServiceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MarketingServiceFilterBuilder
	
	#region MarketingServiceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MarketingServiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MarketingServiceParameterBuilder : ParameterizedSqlFilterBuilder<MarketingServiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarketingServiceParameterBuilder class.
		/// </summary>
		public MarketingServiceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MarketingServiceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MarketingServiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MarketingServiceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MarketingServiceParameterBuilder
} // end namespace
