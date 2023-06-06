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
	/// This class is the base class for any <see cref="CompanyLeadTrackingNotesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CompanyLeadTrackingNotesProviderBaseCore : EntityProviderBase<CONFDB.Entities.CompanyLeadTrackingNotes, CONFDB.Entities.CompanyLeadTrackingNotesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingNotesKey key)
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
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		FK_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="_companyLeadTrackingId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(System.Int32 _companyLeadTrackingId)
		{
			int count = -1;
			return GetByCompanyLeadTrackingId(_companyLeadTrackingId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		FK_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyLeadTrackingId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(TransactionManager transactionManager, System.Int32 _companyLeadTrackingId)
		{
			int count = -1;
			return GetByCompanyLeadTrackingId(transactionManager, _companyLeadTrackingId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		FK_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyLeadTrackingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(TransactionManager transactionManager, System.Int32 _companyLeadTrackingId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyLeadTrackingId(transactionManager, _companyLeadTrackingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		fk_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyLeadTrackingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(System.Int32 _companyLeadTrackingId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompanyLeadTrackingId(null, _companyLeadTrackingId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		fk_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyLeadTrackingId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(System.Int32 _companyLeadTrackingId, int start, int pageLength,out int count)
		{
			return GetByCompanyLeadTrackingId(null, _companyLeadTrackingId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTrackingNotes_CompanyLeadTracking key.
		///		FK_CompanyLeadTrackingNotes_CompanyLeadTracking Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyLeadTrackingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTrackingNotes objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTrackingNotes> GetByCompanyLeadTrackingId(TransactionManager transactionManager, System.Int32 _companyLeadTrackingId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CompanyLeadTrackingNotes Get(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingNotesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTrackingNotes GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTrackingNotes GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTrackingNotes GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTrackingNotes GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTrackingNotes GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTrackingNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> class.</returns>
		public abstract CONFDB.Entities.CompanyLeadTrackingNotes GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CompanyLeadTrackingNotes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CompanyLeadTrackingNotes&gt;"/></returns>
		public static CONFDB.Entities.TList<CompanyLeadTrackingNotes> Fill(IDataReader reader, CONFDB.Entities.TList<CompanyLeadTrackingNotes> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CompanyLeadTrackingNotes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CompanyLeadTrackingNotes")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CompanyLeadTrackingNotesColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CompanyLeadTrackingNotesColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CompanyLeadTrackingNotes>(
					key.ToString(), // EntityTrackingKey
					"CompanyLeadTrackingNotes",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CompanyLeadTrackingNotes();
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
					c.Id = (System.Int32)reader[((int)CompanyLeadTrackingNotesColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.CompanyLeadTrackingId = (System.Int32)reader[((int)CompanyLeadTrackingNotesColumn.CompanyLeadTrackingId - 1)];
					c.Notes = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.Notes - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.Notes - 1)];
					c.OldValues = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.OldValues - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.OldValues - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CompanyLeadTrackingNotesColumn.CreatedDate - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.ModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CompanyLeadTrackingNotes entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CompanyLeadTrackingNotesColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.CompanyLeadTrackingId = (System.Int32)reader[((int)CompanyLeadTrackingNotesColumn.CompanyLeadTrackingId - 1)];
			entity.Notes = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.Notes - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.Notes - 1)];
			entity.OldValues = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.OldValues - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.OldValues - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CompanyLeadTrackingNotesColumn.CreatedDate - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)CompanyLeadTrackingNotesColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingNotesColumn.ModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CompanyLeadTrackingNotes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.CompanyLeadTrackingId = (System.Int32)dataRow["CompanyLeadTrackingID"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.OldValues = Convert.IsDBNull(dataRow["OldValues"]) ? null : (System.String)dataRow["OldValues"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTrackingNotes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyLeadTrackingNotes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingNotes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CompanyLeadTrackingIdSource	
			if (CanDeepLoad(entity, "CompanyLeadTracking|CompanyLeadTrackingIdSource", deepLoadType, innerList) 
				&& entity.CompanyLeadTrackingIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CompanyLeadTrackingId;
				CompanyLeadTracking tmpEntity = EntityManager.LocateEntity<CompanyLeadTracking>(EntityLocator.ConstructKeyFromPkItems(typeof(CompanyLeadTracking), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompanyLeadTrackingIdSource = tmpEntity;
				else
					entity.CompanyLeadTrackingIdSource = DataRepository.CompanyLeadTrackingProvider.GetById(transactionManager, entity.CompanyLeadTrackingId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyLeadTrackingIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompanyLeadTrackingIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CompanyLeadTrackingProvider.DeepLoad(transactionManager, entity.CompanyLeadTrackingIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompanyLeadTrackingIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CompanyLeadTrackingNotes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CompanyLeadTrackingNotes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyLeadTrackingNotes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingNotes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CompanyLeadTrackingIdSource
			if (CanDeepSave(entity, "CompanyLeadTracking|CompanyLeadTrackingIdSource", deepSaveType, innerList) 
				&& entity.CompanyLeadTrackingIdSource != null)
			{
				DataRepository.CompanyLeadTrackingProvider.Save(transactionManager, entity.CompanyLeadTrackingIdSource);
				entity.CompanyLeadTrackingId = entity.CompanyLeadTrackingIdSource.Id;
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
	
	#region CompanyLeadTrackingNotesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CompanyLeadTrackingNotes</c>
	///</summary>
	public enum CompanyLeadTrackingNotesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CompanyLeadTracking</c> at CompanyLeadTrackingIdSource
		///</summary>
		[ChildEntityType(typeof(CompanyLeadTracking))]
		CompanyLeadTracking,
		}
	
	#endregion CompanyLeadTrackingNotesChildEntityTypes
	
	#region CompanyLeadTrackingNotesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CompanyLeadTrackingNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesFilterBuilder : SqlFilterBuilder<CompanyLeadTrackingNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilterBuilder class.
		/// </summary>
		public CompanyLeadTrackingNotesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingNotesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingNotesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingNotesFilterBuilder
	
	#region CompanyLeadTrackingNotesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CompanyLeadTrackingNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTrackingNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingNotesParameterBuilder : ParameterizedSqlFilterBuilder<CompanyLeadTrackingNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesParameterBuilder class.
		/// </summary>
		public CompanyLeadTrackingNotesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingNotesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingNotesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingNotesParameterBuilder
} // end namespace
