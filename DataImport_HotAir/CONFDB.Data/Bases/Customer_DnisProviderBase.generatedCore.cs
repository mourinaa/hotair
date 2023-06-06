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
	/// This class is the base class for any <see cref="Customer_DnisProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class Customer_DnisProviderBaseCore : EntityProviderBase<CONFDB.Entities.Customer_Dnis, CONFDB.Entities.Customer_DnisKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.Customer_DnisKey key)
		{
			return Delete(transactionManager, key.Dnisid, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dnisid">. Primary Key.</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dnisid, System.Int32 _customerId)
		{
			return Delete(null, _dnisid, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid">. Primary Key.</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _customerId);		
		
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
		public override CONFDB.Entities.Customer_Dnis Get(TransactionManager transactionManager, CONFDB.Entities.Customer_DnisKey key, int start, int pageLength)
		{
			return GetByDnisidCustomerId(transactionManager, key.Dnisid, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Customer_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(System.Int32 _dnisid, System.Int32 _customerId)
		{
			int count = -1;
			return GetByDnisidCustomerId(null,_dnisid, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(System.Int32 _dnisid, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidCustomerId(null, _dnisid, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _customerId)
		{
			int count = -1;
			return GetByDnisidCustomerId(transactionManager, _dnisid, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisidCustomerId(transactionManager, _dnisid, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_DNIS_PK index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(System.Int32 _dnisid, System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByDnisidCustomerId(null, _dnisid, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Customer_DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Customer_Dnis"/> class.</returns>
		public abstract CONFDB.Entities.Customer_Dnis GetByDnisidCustomerId(TransactionManager transactionManager, System.Int32 _dnisid, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer_Dnis> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisid(null,_dnisid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(System.Int32 _dnisid, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisid(null, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid)
		{
			int count = -1;
			return GetByDnisid(transactionManager, _dnisid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisid(transactionManager, _dnisid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(System.Int32 _dnisid, int start, int pageLength, out int count)
		{
			return GetByDnisid(null, _dnisid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Customer_DNIS_DNISID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Customer_Dnis> GetByDnisid(TransactionManager transactionManager, System.Int32 _dnisid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Customer_Dnis&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Customer_Dnis&gt;"/></returns>
		public static CONFDB.Entities.TList<Customer_Dnis> Fill(IDataReader reader, CONFDB.Entities.TList<Customer_Dnis> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Customer_Dnis c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Customer_Dnis")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.Customer_DnisColumn.Dnisid - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.Customer_DnisColumn.Dnisid - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.Customer_DnisColumn.CustomerId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.Customer_DnisColumn.CustomerId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Customer_Dnis>(
					key.ToString(), // EntityTrackingKey
					"Customer_Dnis",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Customer_Dnis();
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
					c.Dnisid = (System.Int32)reader[((int)Customer_DnisColumn.Dnisid - 1)];
					c.OriginalDnisid = c.Dnisid;
					c.CustomerId = (System.Int32)reader[((int)Customer_DnisColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Customer_Dnis"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer_Dnis"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Customer_Dnis entity)
		{
			if (!reader.Read()) return;
			
			entity.Dnisid = (System.Int32)reader[((int)Customer_DnisColumn.Dnisid - 1)];
			entity.OriginalDnisid = (System.Int32)reader["DNISID"];
			entity.CustomerId = (System.Int32)reader[((int)Customer_DnisColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Customer_Dnis"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer_Dnis"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Customer_Dnis entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Dnisid = (System.Int32)dataRow["DNISID"];
			entity.OriginalDnisid = (System.Int32)dataRow["DNISID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Customer_Dnis"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Customer_Dnis Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Customer_Dnis entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region DnisidSource	
			if (CanDeepLoad(entity, "Dnis|DnisidSource", deepLoadType, innerList) 
				&& entity.DnisidSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Dnisid;
				Dnis tmpEntity = EntityManager.LocateEntity<Dnis>(EntityLocator.ConstructKeyFromPkItems(typeof(Dnis), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DnisidSource = tmpEntity;
				else
					entity.DnisidSource = DataRepository.DnisProvider.GetById(transactionManager, entity.Dnisid);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisidSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DnisidSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DnisProvider.DeepLoad(transactionManager, entity.DnisidSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DnisidSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Customer_Dnis object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Customer_Dnis instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Customer_Dnis Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Customer_Dnis entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region DnisidSource
			if (CanDeepSave(entity, "Dnis|DnisidSource", deepSaveType, innerList) 
				&& entity.DnisidSource != null)
			{
				DataRepository.DnisProvider.Save(transactionManager, entity.DnisidSource);
				entity.Dnisid = entity.DnisidSource.Id;
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
	
	#region Customer_DnisChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Customer_Dnis</c>
	///</summary>
	public enum Customer_DnisChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
			
		///<summary>
		/// Composite Property for <c>Dnis</c> at DnisidSource
		///</summary>
		[ChildEntityType(typeof(Dnis))]
		Dnis,
		}
	
	#endregion Customer_DnisChildEntityTypes
	
	#region Customer_DnisFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;Customer_DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisFilterBuilder : SqlFilterBuilder<Customer_DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilterBuilder class.
		/// </summary>
		public Customer_DnisFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_DnisFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_DnisFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_DnisFilterBuilder
	
	#region Customer_DnisParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;Customer_DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customer_Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Customer_DnisParameterBuilder : ParameterizedSqlFilterBuilder<Customer_DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Customer_DnisParameterBuilder class.
		/// </summary>
		public Customer_DnisParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Customer_DnisParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Customer_DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Customer_DnisParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Customer_DnisParameterBuilder
} // end namespace
