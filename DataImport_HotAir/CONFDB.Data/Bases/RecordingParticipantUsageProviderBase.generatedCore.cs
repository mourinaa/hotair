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
	/// This class is the base class for any <see cref="RecordingParticipantUsageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RecordingParticipantUsageProviderBaseCore : EntityProviderBase<CONFDB.Entities.RecordingParticipantUsage, CONFDB.Entities.RecordingParticipantUsageKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.RecordingParticipantUsageKey key)
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
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		FK_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="_recordingId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		public CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(System.Int32 _recordingId)
		{
			int count = -1;
			return GetByRecordingId(_recordingId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		FK_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(TransactionManager transactionManager, System.Int32 _recordingId)
		{
			int count = -1;
			return GetByRecordingId(transactionManager, _recordingId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		FK_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		public CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(TransactionManager transactionManager, System.Int32 _recordingId, int start, int pageLength)
		{
			int count = -1;
			return GetByRecordingId(transactionManager, _recordingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		fk_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_recordingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		public CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(System.Int32 _recordingId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRecordingId(null, _recordingId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		fk_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_recordingId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		public CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(System.Int32 _recordingId, int start, int pageLength,out int count)
		{
			return GetByRecordingId(null, _recordingId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RecordingParticipantList_Recording1 key.
		///		FK_RecordingParticipantList_Recording1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_recordingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.RecordingParticipantUsage objects.</returns>
		public abstract CONFDB.Entities.TList<RecordingParticipantUsage> GetByRecordingId(TransactionManager transactionManager, System.Int32 _recordingId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.RecordingParticipantUsage Get(TransactionManager transactionManager, CONFDB.Entities.RecordingParticipantUsageKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public CONFDB.Entities.RecordingParticipantUsage GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public CONFDB.Entities.RecordingParticipantUsage GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public CONFDB.Entities.RecordingParticipantUsage GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public CONFDB.Entities.RecordingParticipantUsage GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public CONFDB.Entities.RecordingParticipantUsage GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RecordingParticipantList index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> class.</returns>
		public abstract CONFDB.Entities.RecordingParticipantUsage GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;RecordingParticipantUsage&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;RecordingParticipantUsage&gt;"/></returns>
		public static CONFDB.Entities.TList<RecordingParticipantUsage> Fill(IDataReader reader, CONFDB.Entities.TList<RecordingParticipantUsage> rows, int start, int pageLength)
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
				
				CONFDB.Entities.RecordingParticipantUsage c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("RecordingParticipantUsage")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.RecordingParticipantUsageColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.RecordingParticipantUsageColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<RecordingParticipantUsage>(
					key.ToString(), // EntityTrackingKey
					"RecordingParticipantUsage",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.RecordingParticipantUsage();
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
					c.Id = (System.Int32)reader[((int)RecordingParticipantUsageColumn.Id - 1)];
					c.RecordingId = (System.Int32)reader[((int)RecordingParticipantUsageColumn.RecordingId - 1)];
					c.ParticipantName = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantName - 1)];
					c.ParticipantCompanyName = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantCompanyName - 1)];
					c.ParticipantEmail = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantEmail - 1)];
					c.DownloadDate = (System.DateTime)reader[((int)RecordingParticipantUsageColumn.DownloadDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.RecordingParticipantUsage"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.RecordingParticipantUsage entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)RecordingParticipantUsageColumn.Id - 1)];
			entity.RecordingId = (System.Int32)reader[((int)RecordingParticipantUsageColumn.RecordingId - 1)];
			entity.ParticipantName = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantName - 1)];
			entity.ParticipantCompanyName = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantCompanyName - 1)];
			entity.ParticipantEmail = (System.String)reader[((int)RecordingParticipantUsageColumn.ParticipantEmail - 1)];
			entity.DownloadDate = (System.DateTime)reader[((int)RecordingParticipantUsageColumn.DownloadDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.RecordingParticipantUsage"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.RecordingParticipantUsage"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.RecordingParticipantUsage entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.RecordingId = (System.Int32)dataRow["RecordingID"];
			entity.ParticipantName = (System.String)dataRow["ParticipantName"];
			entity.ParticipantCompanyName = (System.String)dataRow["ParticipantCompanyName"];
			entity.ParticipantEmail = (System.String)dataRow["ParticipantEmail"];
			entity.DownloadDate = (System.DateTime)dataRow["DownloadDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.RecordingParticipantUsage"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.RecordingParticipantUsage Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.RecordingParticipantUsage entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region RecordingIdSource	
			if (CanDeepLoad(entity, "Recording|RecordingIdSource", deepLoadType, innerList) 
				&& entity.RecordingIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RecordingId;
				Recording tmpEntity = EntityManager.LocateEntity<Recording>(EntityLocator.ConstructKeyFromPkItems(typeof(Recording), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RecordingIdSource = tmpEntity;
				else
					entity.RecordingIdSource = DataRepository.RecordingProvider.GetById(transactionManager, entity.RecordingId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RecordingIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RecordingIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RecordingProvider.DeepLoad(transactionManager, entity.RecordingIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RecordingIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.RecordingParticipantUsage object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.RecordingParticipantUsage instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.RecordingParticipantUsage Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.RecordingParticipantUsage entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region RecordingIdSource
			if (CanDeepSave(entity, "Recording|RecordingIdSource", deepSaveType, innerList) 
				&& entity.RecordingIdSource != null)
			{
				DataRepository.RecordingProvider.Save(transactionManager, entity.RecordingIdSource);
				entity.RecordingId = entity.RecordingIdSource.Id;
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
	
	#region RecordingParticipantUsageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.RecordingParticipantUsage</c>
	///</summary>
	public enum RecordingParticipantUsageChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Recording</c> at RecordingIdSource
		///</summary>
		[ChildEntityType(typeof(Recording))]
		Recording,
		}
	
	#endregion RecordingParticipantUsageChildEntityTypes
	
	#region RecordingParticipantUsageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RecordingParticipantUsageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageFilterBuilder : SqlFilterBuilder<RecordingParticipantUsageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilterBuilder class.
		/// </summary>
		public RecordingParticipantUsageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingParticipantUsageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingParticipantUsageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingParticipantUsageFilterBuilder
	
	#region RecordingParticipantUsageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RecordingParticipantUsageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RecordingParticipantUsage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RecordingParticipantUsageParameterBuilder : ParameterizedSqlFilterBuilder<RecordingParticipantUsageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageParameterBuilder class.
		/// </summary>
		public RecordingParticipantUsageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RecordingParticipantUsageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RecordingParticipantUsageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RecordingParticipantUsageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RecordingParticipantUsageParameterBuilder
} // end namespace
