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
	/// This class is the base class for any <see cref="CompanyInfoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CompanyInfoProviderBaseCore : EntityProviderBase<CONFDB.Entities.CompanyInfo, CONFDB.Entities.CompanyInfoKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CompanyInfoKey key)
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
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		FK_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		public CONFDB.Entities.TList<CompanyInfo> GetByCountryId(System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		FK_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyInfo> GetByCountryId(TransactionManager transactionManager, System.String _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		FK_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		public CONFDB.Entities.TList<CompanyInfo> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		fk_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		public CONFDB.Entities.TList<CompanyInfo> GetByCountryId(System.String _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		fk_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		public CONFDB.Entities.TList<CompanyInfo> GetByCountryId(System.String _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyInfo_Country key.
		///		FK_CompanyInfo_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyInfo objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyInfo> GetByCountryId(TransactionManager transactionManager, System.String _countryId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CompanyInfo Get(TransactionManager transactionManager, CONFDB.Entities.CompanyInfoKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CompanyInfo_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public CONFDB.Entities.CompanyInfo GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyInfo_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public CONFDB.Entities.CompanyInfo GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyInfo_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public CONFDB.Entities.CompanyInfo GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyInfo_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public CONFDB.Entities.CompanyInfo GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyInfo_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public CONFDB.Entities.CompanyInfo GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyInfo_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyInfo"/> class.</returns>
		public abstract CONFDB.Entities.CompanyInfo GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CompanyInfo&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CompanyInfo&gt;"/></returns>
		public static CONFDB.Entities.TList<CompanyInfo> Fill(IDataReader reader, CONFDB.Entities.TList<CompanyInfo> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CompanyInfo c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CompanyInfo")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CompanyInfoColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CompanyInfoColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CompanyInfo>(
					key.ToString(), // EntityTrackingKey
					"CompanyInfo",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CompanyInfo();
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
					c.Id = (System.Int32)reader[((int)CompanyInfoColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.LeadId = (System.Int32)reader[((int)CompanyInfoColumn.LeadId - 1)];
					c.CompanyId = (System.Int32)reader[((int)CompanyInfoColumn.CompanyId - 1)];
					c.SlaEndDate = (System.DateTime)reader[((int)CompanyInfoColumn.SlaEndDate - 1)];
					c.Address = (reader.IsDBNull(((int)CompanyInfoColumn.Address - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.Address - 1)];
					c.City = (reader.IsDBNull(((int)CompanyInfoColumn.City - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.City - 1)];
					c.CountryId = (System.String)reader[((int)CompanyInfoColumn.CountryId - 1)];
					c.Postal = (reader.IsDBNull(((int)CompanyInfoColumn.Postal - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.Postal - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyInfo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyInfo"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CompanyInfo entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CompanyInfoColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.LeadId = (System.Int32)reader[((int)CompanyInfoColumn.LeadId - 1)];
			entity.CompanyId = (System.Int32)reader[((int)CompanyInfoColumn.CompanyId - 1)];
			entity.SlaEndDate = (System.DateTime)reader[((int)CompanyInfoColumn.SlaEndDate - 1)];
			entity.Address = (reader.IsDBNull(((int)CompanyInfoColumn.Address - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.Address - 1)];
			entity.City = (reader.IsDBNull(((int)CompanyInfoColumn.City - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.City - 1)];
			entity.CountryId = (System.String)reader[((int)CompanyInfoColumn.CountryId - 1)];
			entity.Postal = (reader.IsDBNull(((int)CompanyInfoColumn.Postal - 1)))?null:(System.String)reader[((int)CompanyInfoColumn.Postal - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyInfo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyInfo"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CompanyInfo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.LeadId = (System.Int32)dataRow["LeadID"];
			entity.CompanyId = (System.Int32)dataRow["CompanyID"];
			entity.SlaEndDate = (System.DateTime)dataRow["SLAEndDate"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.CountryId = (System.String)dataRow["CountryID"];
			entity.Postal = Convert.IsDBNull(dataRow["Postal"]) ? null : (System.String)dataRow["Postal"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyInfo"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyInfo Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CompanyInfo entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CompanyLeadTrackingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CompanyLeadTracking>|CompanyLeadTrackingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyLeadTrackingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CompanyLeadTrackingCollection = DataRepository.CompanyLeadTrackingProvider.GetByCompanyInfoId(transactionManager, entity.Id);

				if (deep && entity.CompanyLeadTrackingCollection.Count > 0)
				{
					deepHandles.Add("CompanyLeadTrackingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CompanyLeadTracking>) DataRepository.CompanyLeadTrackingProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyLeadTrackingCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CompanyInfo object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CompanyInfo instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyInfo Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CompanyInfo entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CompanyLeadTracking>
				if (CanDeepSave(entity.CompanyLeadTrackingCollection, "List<CompanyLeadTracking>|CompanyLeadTrackingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CompanyLeadTracking child in entity.CompanyLeadTrackingCollection)
					{
						if(child.CompanyInfoIdSource != null)
						{
							child.CompanyInfoId = child.CompanyInfoIdSource.Id;
						}
						else
						{
							child.CompanyInfoId = entity.Id;
						}

					}

					if (entity.CompanyLeadTrackingCollection.Count > 0 || entity.CompanyLeadTrackingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CompanyLeadTrackingProvider.Save(transactionManager, entity.CompanyLeadTrackingCollection);
						
						deepHandles.Add("CompanyLeadTrackingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CompanyLeadTracking >) DataRepository.CompanyLeadTrackingProvider.DeepSave,
							new object[] { transactionManager, entity.CompanyLeadTrackingCollection, deepSaveType, childTypes, innerList }
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
	
	#region CompanyInfoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CompanyInfo</c>
	///</summary>
	public enum CompanyInfoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Country</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
	
		///<summary>
		/// Collection of <c>CompanyInfo</c> as OneToMany for CompanyLeadTrackingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CompanyLeadTracking>))]
		CompanyLeadTrackingCollection,
	}
	
	#endregion CompanyInfoChildEntityTypes
	
	#region CompanyInfoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CompanyInfoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoFilterBuilder : SqlFilterBuilder<CompanyInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilterBuilder class.
		/// </summary>
		public CompanyInfoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyInfoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyInfoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyInfoFilterBuilder
	
	#region CompanyInfoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CompanyInfoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyInfoParameterBuilder : ParameterizedSqlFilterBuilder<CompanyInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyInfoParameterBuilder class.
		/// </summary>
		public CompanyInfoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyInfoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyInfoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyInfoParameterBuilder
} // end namespace
