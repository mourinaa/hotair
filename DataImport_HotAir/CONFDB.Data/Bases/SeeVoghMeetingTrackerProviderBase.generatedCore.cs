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
	/// This class is the base class for any <see cref="SeeVoghMeetingTrackerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SeeVoghMeetingTrackerProviderBaseCore : EntityProviderBase<CONFDB.Entities.SeeVoghMeetingTracker, CONFDB.Entities.SeeVoghMeetingTrackerKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.SeeVoghMeetingTrackerKey key)
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
		public override CONFDB.Entities.SeeVoghMeetingTracker Get(TransactionManager transactionManager, CONFDB.Entities.SeeVoghMeetingTrackerKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public CONFDB.Entities.SeeVoghMeetingTracker GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public CONFDB.Entities.SeeVoghMeetingTracker GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public CONFDB.Entities.SeeVoghMeetingTracker GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public CONFDB.Entities.SeeVoghMeetingTracker GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public CONFDB.Entities.SeeVoghMeetingTracker GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SeeVoghMeetingTracker index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> class.</returns>
		public abstract CONFDB.Entities.SeeVoghMeetingTracker GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;SeeVoghMeetingTracker&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;SeeVoghMeetingTracker&gt;"/></returns>
		public static CONFDB.Entities.TList<SeeVoghMeetingTracker> Fill(IDataReader reader, CONFDB.Entities.TList<SeeVoghMeetingTracker> rows, int start, int pageLength)
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
				
				CONFDB.Entities.SeeVoghMeetingTracker c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SeeVoghMeetingTracker")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.SeeVoghMeetingTrackerColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.SeeVoghMeetingTrackerColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<SeeVoghMeetingTracker>(
					key.ToString(), // EntityTrackingKey
					"SeeVoghMeetingTracker",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.SeeVoghMeetingTracker();
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
					c.Id = (System.Int32)reader[((int)SeeVoghMeetingTrackerColumn.Id - 1)];
					c.MeetingId = (System.String)reader[((int)SeeVoghMeetingTrackerColumn.MeetingId - 1)];
					c.Status = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.Status - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.Status - 1)];
					c.ModeratorId = (System.Int32)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorId - 1)];
					c.ModeratorCode = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.ModeratorCode - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorCode - 1)];
					c.ModeratorJoined = (System.Boolean)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorJoined - 1)];
					c.MeetingUrl = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.MeetingUrl - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.MeetingUrl - 1)];
					c.MobileMeetingUrl = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.MobileMeetingUrl - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.MobileMeetingUrl - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)SeeVoghMeetingTrackerColumn.CreatedDate - 1)];
					c.LastModified = (System.DateTime)reader[((int)SeeVoghMeetingTrackerColumn.LastModified - 1)];
					c.Notes = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.Notes - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.Notes - 1)];
					c.CreatedDateUtc = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.CreatedDateUtc - 1)))?null:(System.DateTime?)reader[((int)SeeVoghMeetingTrackerColumn.CreatedDateUtc - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.SeeVoghMeetingTracker entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)SeeVoghMeetingTrackerColumn.Id - 1)];
			entity.MeetingId = (System.String)reader[((int)SeeVoghMeetingTrackerColumn.MeetingId - 1)];
			entity.Status = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.Status - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.Status - 1)];
			entity.ModeratorId = (System.Int32)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorId - 1)];
			entity.ModeratorCode = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.ModeratorCode - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorCode - 1)];
			entity.ModeratorJoined = (System.Boolean)reader[((int)SeeVoghMeetingTrackerColumn.ModeratorJoined - 1)];
			entity.MeetingUrl = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.MeetingUrl - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.MeetingUrl - 1)];
			entity.MobileMeetingUrl = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.MobileMeetingUrl - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.MobileMeetingUrl - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)SeeVoghMeetingTrackerColumn.CreatedDate - 1)];
			entity.LastModified = (System.DateTime)reader[((int)SeeVoghMeetingTrackerColumn.LastModified - 1)];
			entity.Notes = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.Notes - 1)))?null:(System.String)reader[((int)SeeVoghMeetingTrackerColumn.Notes - 1)];
			entity.CreatedDateUtc = (reader.IsDBNull(((int)SeeVoghMeetingTrackerColumn.CreatedDateUtc - 1)))?null:(System.DateTime?)reader[((int)SeeVoghMeetingTrackerColumn.CreatedDateUtc - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.SeeVoghMeetingTracker entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.MeetingId = (System.String)dataRow["MeetingID"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (System.String)dataRow["Status"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.ModeratorCode = Convert.IsDBNull(dataRow["ModeratorCode"]) ? null : (System.String)dataRow["ModeratorCode"];
			entity.ModeratorJoined = (System.Boolean)dataRow["ModeratorJoined"];
			entity.MeetingUrl = Convert.IsDBNull(dataRow["MeetingURL"]) ? null : (System.String)dataRow["MeetingURL"];
			entity.MobileMeetingUrl = Convert.IsDBNull(dataRow["MobileMeetingURL"]) ? null : (System.String)dataRow["MobileMeetingURL"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.CreatedDateUtc = Convert.IsDBNull(dataRow["CreatedDateUTC"]) ? null : (System.DateTime?)dataRow["CreatedDateUTC"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.SeeVoghMeetingTracker"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.SeeVoghMeetingTracker Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.SeeVoghMeetingTracker entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.SeeVoghMeetingTracker object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.SeeVoghMeetingTracker instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.SeeVoghMeetingTracker Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.SeeVoghMeetingTracker entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SeeVoghMeetingTrackerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.SeeVoghMeetingTracker</c>
	///</summary>
	public enum SeeVoghMeetingTrackerChildEntityTypes
	{
	}
	
	#endregion SeeVoghMeetingTrackerChildEntityTypes
	
	#region SeeVoghMeetingTrackerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SeeVoghMeetingTrackerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeeVoghMeetingTracker"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeeVoghMeetingTrackerFilterBuilder : SqlFilterBuilder<SeeVoghMeetingTrackerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilterBuilder class.
		/// </summary>
		public SeeVoghMeetingTrackerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeeVoghMeetingTrackerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeeVoghMeetingTrackerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeeVoghMeetingTrackerFilterBuilder
	
	#region SeeVoghMeetingTrackerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SeeVoghMeetingTrackerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SeeVoghMeetingTracker"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SeeVoghMeetingTrackerParameterBuilder : ParameterizedSqlFilterBuilder<SeeVoghMeetingTrackerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerParameterBuilder class.
		/// </summary>
		public SeeVoghMeetingTrackerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SeeVoghMeetingTrackerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SeeVoghMeetingTrackerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SeeVoghMeetingTrackerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SeeVoghMeetingTrackerParameterBuilder
} // end namespace
