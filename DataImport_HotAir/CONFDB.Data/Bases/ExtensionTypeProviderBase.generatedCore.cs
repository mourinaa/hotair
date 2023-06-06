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
	/// This class is the base class for any <see cref="ExtensionTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ExtensionTypeProviderBaseCore : EntityProviderBase<CONFDB.Entities.ExtensionType, CONFDB.Entities.ExtensionTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ExtensionTypeKey key)
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
		public override CONFDB.Entities.ExtensionType Get(TransactionManager transactionManager, CONFDB.Entities.ExtensionTypeKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ExtensionType_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public abstract CONFDB.Entities.ExtensionType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public CONFDB.Entities.ExtensionType GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ExtensionType"/> class.</returns>
		public abstract CONFDB.Entities.ExtensionType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(System.Int32 _extensionTypeCategoryId)
		{
			int count = -1;
			return GetByExtensionTypeCategoryId(null,_extensionTypeCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(System.Int32 _extensionTypeCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByExtensionTypeCategoryId(null, _extensionTypeCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(TransactionManager transactionManager, System.Int32 _extensionTypeCategoryId)
		{
			int count = -1;
			return GetByExtensionTypeCategoryId(transactionManager, _extensionTypeCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(TransactionManager transactionManager, System.Int32 _extensionTypeCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByExtensionTypeCategoryId(transactionManager, _extensionTypeCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(System.Int32 _extensionTypeCategoryId, int start, int pageLength, out int count)
		{
			return GetByExtensionTypeCategoryId(null, _extensionTypeCategoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ExtensionType_CategoryID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ExtensionType> GetByExtensionTypeCategoryId(TransactionManager transactionManager, System.Int32 _extensionTypeCategoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ExtensionType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ExtensionType&gt;"/></returns>
		public static CONFDB.Entities.TList<ExtensionType> Fill(IDataReader reader, CONFDB.Entities.TList<ExtensionType> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ExtensionType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ExtensionType")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ExtensionTypeColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ExtensionTypeColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ExtensionType>(
					key.ToString(), // EntityTrackingKey
					"ExtensionType",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ExtensionType();
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
					c.Id = (System.Int32)reader[((int)ExtensionTypeColumn.Id - 1)];
					c.Name = (System.String)reader[((int)ExtensionTypeColumn.Name - 1)];
					c.DisplayName = (System.String)reader[((int)ExtensionTypeColumn.DisplayName - 1)];
					c.ExtensionTypeCategoryId = (System.Int32)reader[((int)ExtensionTypeColumn.ExtensionTypeCategoryId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ExtensionType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ExtensionType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ExtensionType entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ExtensionTypeColumn.Id - 1)];
			entity.Name = (System.String)reader[((int)ExtensionTypeColumn.Name - 1)];
			entity.DisplayName = (System.String)reader[((int)ExtensionTypeColumn.DisplayName - 1)];
			entity.ExtensionTypeCategoryId = (System.Int32)reader[((int)ExtensionTypeColumn.ExtensionTypeCategoryId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ExtensionType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ExtensionType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ExtensionType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.Name = (System.String)dataRow["Name"];
			entity.DisplayName = (System.String)dataRow["DisplayName"];
			entity.ExtensionTypeCategoryId = (System.Int32)dataRow["ExtensionTypeCategoryID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ExtensionType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ExtensionType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ExtensionType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ExtensionTypeCategoryIdSource	
			if (CanDeepLoad(entity, "ExtensionTypeCategory|ExtensionTypeCategoryIdSource", deepLoadType, innerList) 
				&& entity.ExtensionTypeCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ExtensionTypeCategoryId;
				ExtensionTypeCategory tmpEntity = EntityManager.LocateEntity<ExtensionTypeCategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ExtensionTypeCategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ExtensionTypeCategoryIdSource = tmpEntity;
				else
					entity.ExtensionTypeCategoryIdSource = DataRepository.ExtensionTypeCategoryProvider.GetById(transactionManager, entity.ExtensionTypeCategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ExtensionTypeCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ExtensionTypeCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ExtensionTypeCategoryProvider.DeepLoad(transactionManager, entity.ExtensionTypeCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ExtensionTypeCategoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region SystemExtensionLabelCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SystemExtensionLabel>|SystemExtensionLabelCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SystemExtensionLabelCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SystemExtensionLabelCollection = DataRepository.SystemExtensionLabelProvider.GetByExtensionTypeId(transactionManager, entity.Id);

				if (deep && entity.SystemExtensionLabelCollection.Count > 0)
				{
					deepHandles.Add("SystemExtensionLabelCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SystemExtensionLabel>) DataRepository.SystemExtensionLabelProvider.DeepLoad,
						new object[] { transactionManager, entity.SystemExtensionLabelCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ExtensionType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ExtensionType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ExtensionType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ExtensionType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ExtensionTypeCategoryIdSource
			if (CanDeepSave(entity, "ExtensionTypeCategory|ExtensionTypeCategoryIdSource", deepSaveType, innerList) 
				&& entity.ExtensionTypeCategoryIdSource != null)
			{
				DataRepository.ExtensionTypeCategoryProvider.Save(transactionManager, entity.ExtensionTypeCategoryIdSource);
				entity.ExtensionTypeCategoryId = entity.ExtensionTypeCategoryIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SystemExtensionLabel>
				if (CanDeepSave(entity.SystemExtensionLabelCollection, "List<SystemExtensionLabel>|SystemExtensionLabelCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SystemExtensionLabel child in entity.SystemExtensionLabelCollection)
					{
						if(child.ExtensionTypeIdSource != null)
						{
							child.ExtensionTypeId = child.ExtensionTypeIdSource.Id;
						}
						else
						{
							child.ExtensionTypeId = entity.Id;
						}

					}

					if (entity.SystemExtensionLabelCollection.Count > 0 || entity.SystemExtensionLabelCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SystemExtensionLabelProvider.Save(transactionManager, entity.SystemExtensionLabelCollection);
						
						deepHandles.Add("SystemExtensionLabelCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SystemExtensionLabel >) DataRepository.SystemExtensionLabelProvider.DeepSave,
							new object[] { transactionManager, entity.SystemExtensionLabelCollection, deepSaveType, childTypes, innerList }
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
	
	#region ExtensionTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ExtensionType</c>
	///</summary>
	public enum ExtensionTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ExtensionTypeCategory</c> at ExtensionTypeCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ExtensionTypeCategory))]
		ExtensionTypeCategory,
	
		///<summary>
		/// Collection of <c>ExtensionType</c> as OneToMany for SystemExtensionLabelCollection
		///</summary>
		[ChildEntityType(typeof(TList<SystemExtensionLabel>))]
		SystemExtensionLabelCollection,
	}
	
	#endregion ExtensionTypeChildEntityTypes
	
	#region ExtensionTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ExtensionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeFilterBuilder : SqlFilterBuilder<ExtensionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilterBuilder class.
		/// </summary>
		public ExtensionTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeFilterBuilder
	
	#region ExtensionTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ExtensionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExtensionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExtensionTypeParameterBuilder : ParameterizedSqlFilterBuilder<ExtensionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeParameterBuilder class.
		/// </summary>
		public ExtensionTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExtensionTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExtensionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExtensionTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExtensionTypeParameterBuilder
} // end namespace
