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
	/// This class is the base class for any <see cref="LanguageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LanguageProviderBaseCore : EntityProviderBase<CONFDB.Entities.Language, CONFDB.Entities.LanguageKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByWholesalerIdFromIrWholesaler
		
		/// <summary>
		///		Gets Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of Language objects.</returns>
		public TList<Language> GetByWholesalerIdFromIrWholesaler(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerIdFromIrWholesaler(null,_wholesalerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Language objects.</returns>
		public TList<Language> GetByWholesalerIdFromIrWholesaler(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdFromIrWholesaler(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Language objects.</returns>
		public TList<Language> GetByWholesalerIdFromIrWholesaler(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerIdFromIrWholesaler(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Language objects.</returns>
		public TList<Language> GetByWholesalerIdFromIrWholesaler(TransactionManager transactionManager, System.String _wholesalerId,int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdFromIrWholesaler(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Language objects.</returns>
		public TList<Language> GetByWholesalerIdFromIrWholesaler(System.String _wholesalerId,int start, int pageLength, out int count)
		{
			
			return GetByWholesalerIdFromIrWholesaler(null, _wholesalerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Language objects from the datasource by WholesalerID in the
		///		IRWholesaler table. Table Language is related to table Wholesaler
		///		through the (M:N) relationship defined in the IRWholesaler table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Language objects.</returns>
		public abstract TList<Language> GetByWholesalerIdFromIrWholesaler(TransactionManager transactionManager,System.String _wholesalerId, int start, int pageLength, out int count);
		
		#endregion GetByWholesalerIdFromIrWholesaler
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.LanguageKey key)
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
		public override CONFDB.Entities.Language Get(TransactionManager transactionManager, CONFDB.Entities.LanguageKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Language_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public CONFDB.Entities.Language GetById(System.String _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public CONFDB.Entities.Language GetById(System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public CONFDB.Entities.Language GetById(TransactionManager transactionManager, System.String _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public CONFDB.Entities.Language GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public CONFDB.Entities.Language GetById(System.String _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Language"/> class.</returns>
		public abstract CONFDB.Entities.Language GetById(TransactionManager transactionManager, System.String _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Language&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Language&gt;"/></returns>
		public static CONFDB.Entities.TList<Language> Fill(IDataReader reader, CONFDB.Entities.TList<Language> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Language c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Language")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.LanguageColumn.Id - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.LanguageColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Language>(
					key.ToString(), // EntityTrackingKey
					"Language",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Language();
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
					c.Id = (System.String)reader[((int)LanguageColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.DisplayName = (reader.IsDBNull(((int)LanguageColumn.DisplayName - 1)))?null:(System.String)reader[((int)LanguageColumn.DisplayName - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)LanguageColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)LanguageColumn.DisplayOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Language"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Language"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Language entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.String)reader[((int)LanguageColumn.Id - 1)];
			entity.OriginalId = (System.String)reader["ID"];
			entity.DisplayName = (reader.IsDBNull(((int)LanguageColumn.DisplayName - 1)))?null:(System.String)reader[((int)LanguageColumn.DisplayName - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)LanguageColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)LanguageColumn.DisplayOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Language"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Language"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Language entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.String)dataRow["ID"];
			entity.OriginalId = (System.String)dataRow["ID"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Language"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Language Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Language entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerDocumentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerDocument>|CustomerDocumentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerDocumentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerDocumentCollection = DataRepository.CustomerDocumentProvider.GetByLanguageId(transactionManager, entity.Id);

				if (deep && entity.CustomerDocumentCollection.Count > 0)
				{
					deepHandles.Add("CustomerDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerDocument>) DataRepository.CustomerDocumentProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerDocumentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WholesalerIdWholesalerCollection_From_IrWholesaler
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Wholesaler>|WholesalerIdWholesalerCollection_From_IrWholesaler", deepLoadType, innerList))
			{
				entity.WholesalerIdWholesalerCollection_From_IrWholesaler = DataRepository.WholesalerProvider.GetByLanguageIdFromIrWholesaler(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WholesalerIdWholesalerCollection_From_IrWholesaler' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WholesalerIdWholesalerCollection_From_IrWholesaler != null)
				{
					deepHandles.Add("WholesalerIdWholesalerCollection_From_IrWholesaler",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Wholesaler >) DataRepository.WholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.WholesalerIdWholesalerCollection_From_IrWholesaler, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region IrWholesalerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<IrWholesaler>|IrWholesalerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IrWholesalerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IrWholesalerCollection = DataRepository.IrWholesalerProvider.GetByLanguageId(transactionManager, entity.Id);

				if (deep && entity.IrWholesalerCollection.Count > 0)
				{
					deepHandles.Add("IrWholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<IrWholesaler>) DataRepository.IrWholesalerProvider.DeepLoad,
						new object[] { transactionManager, entity.IrWholesalerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmailTemplateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmailTemplate>|EmailTemplateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailTemplateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmailTemplateCollection = DataRepository.EmailTemplateProvider.GetByLanguageId(transactionManager, entity.Id);

				if (deep && entity.EmailTemplateCollection.Count > 0)
				{
					deepHandles.Add("EmailTemplateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmailTemplate>) DataRepository.EmailTemplateProvider.DeepLoad,
						new object[] { transactionManager, entity.EmailTemplateCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Language object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Language instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Language Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Language entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region WholesalerIdWholesalerCollection_From_IrWholesaler>
			if (CanDeepSave(entity.WholesalerIdWholesalerCollection_From_IrWholesaler, "List<Wholesaler>|WholesalerIdWholesalerCollection_From_IrWholesaler", deepSaveType, innerList))
			{
				if (entity.WholesalerIdWholesalerCollection_From_IrWholesaler.Count > 0 || entity.WholesalerIdWholesalerCollection_From_IrWholesaler.DeletedItems.Count > 0)
				{
					DataRepository.WholesalerProvider.Save(transactionManager, entity.WholesalerIdWholesalerCollection_From_IrWholesaler); 
					deepHandles.Add("WholesalerIdWholesalerCollection_From_IrWholesaler",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Wholesaler>) DataRepository.WholesalerProvider.DeepSave,
						new object[] { transactionManager, entity.WholesalerIdWholesalerCollection_From_IrWholesaler, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<CustomerDocument>
				if (CanDeepSave(entity.CustomerDocumentCollection, "List<CustomerDocument>|CustomerDocumentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerDocument child in entity.CustomerDocumentCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.Id;
						}
						else
						{
							child.LanguageId = entity.Id;
						}

					}

					if (entity.CustomerDocumentCollection.Count > 0 || entity.CustomerDocumentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerDocumentProvider.Save(transactionManager, entity.CustomerDocumentCollection);
						
						deepHandles.Add("CustomerDocumentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerDocument >) DataRepository.CustomerDocumentProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerDocumentCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<IrWholesaler>
				if (CanDeepSave(entity.IrWholesalerCollection, "List<IrWholesaler>|IrWholesalerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(IrWholesaler child in entity.IrWholesalerCollection)
					{
						if(child.LanguageIdSource != null)
						{
								child.LanguageId = child.LanguageIdSource.Id;
						}

						if(child.WholesalerIdSource != null)
						{
								child.WholesalerId = child.WholesalerIdSource.Id;
						}

					}

					if (entity.IrWholesalerCollection.Count > 0 || entity.IrWholesalerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IrWholesalerProvider.Save(transactionManager, entity.IrWholesalerCollection);
						
						deepHandles.Add("IrWholesalerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< IrWholesaler >) DataRepository.IrWholesalerProvider.DeepSave,
							new object[] { transactionManager, entity.IrWholesalerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmailTemplate>
				if (CanDeepSave(entity.EmailTemplateCollection, "List<EmailTemplate>|EmailTemplateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmailTemplate child in entity.EmailTemplateCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.Id;
						}
						else
						{
							child.LanguageId = entity.Id;
						}

					}

					if (entity.EmailTemplateCollection.Count > 0 || entity.EmailTemplateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmailTemplateProvider.Save(transactionManager, entity.EmailTemplateCollection);
						
						deepHandles.Add("EmailTemplateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmailTemplate >) DataRepository.EmailTemplateProvider.DeepSave,
							new object[] { transactionManager, entity.EmailTemplateCollection, deepSaveType, childTypes, innerList }
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
	
	#region LanguageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Language</c>
	///</summary>
	public enum LanguageChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Language</c> as OneToMany for CustomerDocumentCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerDocument>))]
		CustomerDocumentCollection,

		///<summary>
		/// Collection of <c>Language</c> as ManyToMany for WholesalerCollection_From_IrWholesaler
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler>))]
		WholesalerIdWholesalerCollection_From_IrWholesaler,

		///<summary>
		/// Collection of <c>Language</c> as OneToMany for IrWholesalerCollection
		///</summary>
		[ChildEntityType(typeof(TList<IrWholesaler>))]
		IrWholesalerCollection,

		///<summary>
		/// Collection of <c>Language</c> as OneToMany for EmailTemplateCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmailTemplate>))]
		EmailTemplateCollection,
	}
	
	#endregion LanguageChildEntityTypes
	
	#region LanguageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageFilterBuilder : SqlFilterBuilder<LanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		public LanguageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageFilterBuilder
	
	#region LanguageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageParameterBuilder : ParameterizedSqlFilterBuilder<LanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		public LanguageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageParameterBuilder
} // end namespace
