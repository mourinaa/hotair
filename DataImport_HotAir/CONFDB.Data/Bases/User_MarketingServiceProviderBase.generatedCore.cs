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
	/// This class is the base class for any <see cref="User_MarketingServiceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class User_MarketingServiceProviderBaseCore : EntityProviderBase<CONFDB.Entities.User_MarketingService, CONFDB.Entities.User_MarketingServiceKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.User_MarketingServiceKey key)
		{
			return Delete(transactionManager, key.MarketingServiceId, key.UserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_marketingServiceId">. Primary Key.</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _marketingServiceId, System.Int32 _userId)
		{
			return Delete(null, _marketingServiceId, _userId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId">. Primary Key.</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _marketingServiceId, System.Int32 _userId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		FK_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByUserId(System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(_userId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		FK_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User_MarketingService> GetByUserId(TransactionManager transactionManager, System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		FK_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		fk_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByUserId(System.Int32 _userId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserId(null, _userId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		fk_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByUserId(System.Int32 _userId, int start, int pageLength,out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_User key.
		///		FK_User_MarketingService_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public abstract CONFDB.Entities.TList<User_MarketingService> GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		FK_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(System.Int32 _marketingServiceId)
		{
			int count = -1;
			return GetByMarketingServiceId(_marketingServiceId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		FK_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(TransactionManager transactionManager, System.Int32 _marketingServiceId)
		{
			int count = -1;
			return GetByMarketingServiceId(transactionManager, _marketingServiceId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		FK_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(TransactionManager transactionManager, System.Int32 _marketingServiceId, int start, int pageLength)
		{
			int count = -1;
			return GetByMarketingServiceId(transactionManager, _marketingServiceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		fk_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_marketingServiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(System.Int32 _marketingServiceId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMarketingServiceId(null, _marketingServiceId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		fk_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(System.Int32 _marketingServiceId, int start, int pageLength,out int count)
		{
			return GetByMarketingServiceId(null, _marketingServiceId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_MarketingService_MarketingService key.
		///		FK_User_MarketingService_MarketingService Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User_MarketingService objects.</returns>
		public abstract CONFDB.Entities.TList<User_MarketingService> GetByMarketingServiceId(TransactionManager transactionManager, System.Int32 _marketingServiceId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.User_MarketingService Get(TransactionManager transactionManager, CONFDB.Entities.User_MarketingServiceKey key, int start, int pageLength)
		{
			return GetByMarketingServiceIdUserId(transactionManager, key.MarketingServiceId, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_User_MarketingService index.
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(System.Int32 _marketingServiceId, System.Int32 _userId)
		{
			int count = -1;
			return GetByMarketingServiceIdUserId(null,_marketingServiceId, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User_MarketingService index.
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(System.Int32 _marketingServiceId, System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByMarketingServiceIdUserId(null, _marketingServiceId, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(TransactionManager transactionManager, System.Int32 _marketingServiceId, System.Int32 _userId)
		{
			int count = -1;
			return GetByMarketingServiceIdUserId(transactionManager, _marketingServiceId, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(TransactionManager transactionManager, System.Int32 _marketingServiceId, System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByMarketingServiceIdUserId(transactionManager, _marketingServiceId, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User_MarketingService index.
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(System.Int32 _marketingServiceId, System.Int32 _userId, int start, int pageLength, out int count)
		{
			return GetByMarketingServiceIdUserId(null, _marketingServiceId, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User_MarketingService index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User_MarketingService"/> class.</returns>
		public abstract CONFDB.Entities.User_MarketingService GetByMarketingServiceIdUserId(TransactionManager transactionManager, System.Int32 _marketingServiceId, System.Int32 _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;User_MarketingService&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;User_MarketingService&gt;"/></returns>
		public static CONFDB.Entities.TList<User_MarketingService> Fill(IDataReader reader, CONFDB.Entities.TList<User_MarketingService> rows, int start, int pageLength)
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
				
				CONFDB.Entities.User_MarketingService c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("User_MarketingService")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.User_MarketingServiceColumn.UserId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.User_MarketingServiceColumn.UserId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.User_MarketingServiceColumn.MarketingServiceId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.User_MarketingServiceColumn.MarketingServiceId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<User_MarketingService>(
					key.ToString(), // EntityTrackingKey
					"User_MarketingService",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.User_MarketingService();
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
					c.UserId = (System.Int32)reader[((int)User_MarketingServiceColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.MarketingServiceId = (System.Int32)reader[((int)User_MarketingServiceColumn.MarketingServiceId - 1)];
					c.OriginalMarketingServiceId = c.MarketingServiceId;
					c.CreatedDate = (System.DateTime)reader[((int)User_MarketingServiceColumn.CreatedDate - 1)];
					c.LastModified = (System.DateTime)reader[((int)User_MarketingServiceColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)User_MarketingServiceColumn.LastModifiedBy - 1)))?null:(System.String)reader[((int)User_MarketingServiceColumn.LastModifiedBy - 1)];
					c.LastContactDate = (reader.IsDBNull(((int)User_MarketingServiceColumn.LastContactDate - 1)))?null:(System.DateTime?)reader[((int)User_MarketingServiceColumn.LastContactDate - 1)];
					c.NextContactDate = (reader.IsDBNull(((int)User_MarketingServiceColumn.NextContactDate - 1)))?null:(System.DateTime?)reader[((int)User_MarketingServiceColumn.NextContactDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.User_MarketingService"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.User_MarketingService"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.User_MarketingService entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Int32)reader[((int)User_MarketingServiceColumn.UserId - 1)];
			entity.OriginalUserId = (System.Int32)reader["UserID"];
			entity.MarketingServiceId = (System.Int32)reader[((int)User_MarketingServiceColumn.MarketingServiceId - 1)];
			entity.OriginalMarketingServiceId = (System.Int32)reader["MarketingServiceID"];
			entity.CreatedDate = (System.DateTime)reader[((int)User_MarketingServiceColumn.CreatedDate - 1)];
			entity.LastModified = (System.DateTime)reader[((int)User_MarketingServiceColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)User_MarketingServiceColumn.LastModifiedBy - 1)))?null:(System.String)reader[((int)User_MarketingServiceColumn.LastModifiedBy - 1)];
			entity.LastContactDate = (reader.IsDBNull(((int)User_MarketingServiceColumn.LastContactDate - 1)))?null:(System.DateTime?)reader[((int)User_MarketingServiceColumn.LastContactDate - 1)];
			entity.NextContactDate = (reader.IsDBNull(((int)User_MarketingServiceColumn.NextContactDate - 1)))?null:(System.DateTime?)reader[((int)User_MarketingServiceColumn.NextContactDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.User_MarketingService"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.User_MarketingService"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.User_MarketingService entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Int32)dataRow["UserID"];
			entity.OriginalUserId = (System.Int32)dataRow["UserID"];
			entity.MarketingServiceId = (System.Int32)dataRow["MarketingServiceID"];
			entity.OriginalMarketingServiceId = (System.Int32)dataRow["MarketingServiceID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.String)dataRow["LastModifiedBy"];
			entity.LastContactDate = Convert.IsDBNull(dataRow["LastContactDate"]) ? null : (System.DateTime?)dataRow["LastContactDate"];
			entity.NextContactDate = Convert.IsDBNull(dataRow["NextContactDate"]) ? null : (System.DateTime?)dataRow["NextContactDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.User_MarketingService"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.User_MarketingService Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.User_MarketingService entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UserIdSource	
			if (CanDeepLoad(entity, "User|UserIdSource", deepLoadType, innerList) 
				&& entity.UserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UserId;
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserIdSource = tmpEntity;
				else
					entity.UserIdSource = DataRepository.UserProvider.GetByUserId(transactionManager, entity.UserId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.UserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserIdSource

			#region MarketingServiceIdSource	
			if (CanDeepLoad(entity, "MarketingService|MarketingServiceIdSource", deepLoadType, innerList) 
				&& entity.MarketingServiceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MarketingServiceId;
				MarketingService tmpEntity = EntityManager.LocateEntity<MarketingService>(EntityLocator.ConstructKeyFromPkItems(typeof(MarketingService), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MarketingServiceIdSource = tmpEntity;
				else
					entity.MarketingServiceIdSource = DataRepository.MarketingServiceProvider.GetById(transactionManager, entity.MarketingServiceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MarketingServiceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MarketingServiceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MarketingServiceProvider.DeepLoad(transactionManager, entity.MarketingServiceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MarketingServiceIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.User_MarketingService object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.User_MarketingService instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.User_MarketingService Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.User_MarketingService entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UserIdSource
			if (CanDeepSave(entity, "User|UserIdSource", deepSaveType, innerList) 
				&& entity.UserIdSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.UserIdSource);
				entity.UserId = entity.UserIdSource.UserId;
			}
			#endregion 
			
			#region MarketingServiceIdSource
			if (CanDeepSave(entity, "MarketingService|MarketingServiceIdSource", deepSaveType, innerList) 
				&& entity.MarketingServiceIdSource != null)
			{
				DataRepository.MarketingServiceProvider.Save(transactionManager, entity.MarketingServiceIdSource);
				entity.MarketingServiceId = entity.MarketingServiceIdSource.Id;
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
	
	#region User_MarketingServiceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.User_MarketingService</c>
	///</summary>
	public enum User_MarketingServiceChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>User</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(User))]
		User,
			
		///<summary>
		/// Composite Property for <c>MarketingService</c> at MarketingServiceIdSource
		///</summary>
		[ChildEntityType(typeof(MarketingService))]
		MarketingService,
		}
	
	#endregion User_MarketingServiceChildEntityTypes
	
	#region User_MarketingServiceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;User_MarketingServiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceFilterBuilder : SqlFilterBuilder<User_MarketingServiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilterBuilder class.
		/// </summary>
		public User_MarketingServiceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public User_MarketingServiceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public User_MarketingServiceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion User_MarketingServiceFilterBuilder
	
	#region User_MarketingServiceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;User_MarketingServiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User_MarketingService"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class User_MarketingServiceParameterBuilder : ParameterizedSqlFilterBuilder<User_MarketingServiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceParameterBuilder class.
		/// </summary>
		public User_MarketingServiceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public User_MarketingServiceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the User_MarketingServiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public User_MarketingServiceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion User_MarketingServiceParameterBuilder
} // end namespace
