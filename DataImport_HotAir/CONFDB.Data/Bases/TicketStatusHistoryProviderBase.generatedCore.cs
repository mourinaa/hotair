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
	/// This class is the base class for any <see cref="TicketStatusHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TicketStatusHistoryProviderBaseCore : EntityProviderBase<CONFDB.Entities.TicketStatusHistory, CONFDB.Entities.TicketStatusHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TicketStatusHistoryKey key)
		{
			return Delete(transactionManager, key.TicketId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_ticketId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _ticketId)
		{
			return Delete(null, _ticketId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _ticketId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		FK_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="_statusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		public CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(System.Int32 _statusId)
		{
			int count = -1;
			return GetByStatusId(_statusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		FK_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId)
		{
			int count = -1;
			return GetByStatusId(transactionManager, _statusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		FK_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		public CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId, int start, int pageLength)
		{
			int count = -1;
			return GetByStatusId(transactionManager, _statusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		fk_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_statusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		public CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(System.Int32 _statusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStatusId(null, _statusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		fk_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_statusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		public CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(System.Int32 _statusId, int start, int pageLength,out int count)
		{
			return GetByStatusId(null, _statusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_TicketStatusHistory_TicketStatus key.
		///		FK_TicketStatusHistory_TicketStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.TicketStatusHistory objects.</returns>
		public abstract CONFDB.Entities.TList<TicketStatusHistory> GetByStatusId(TransactionManager transactionManager, System.Int32 _statusId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.TicketStatusHistory Get(TransactionManager transactionManager, CONFDB.Entities.TicketStatusHistoryKey key, int start, int pageLength)
		{
			return GetByTicketId(transactionManager, key.TicketId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="_ticketId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public CONFDB.Entities.TicketStatusHistory GetByTicketId(System.Int32 _ticketId)
		{
			int count = -1;
			return GetByTicketId(null,_ticketId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="_ticketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public CONFDB.Entities.TicketStatusHistory GetByTicketId(System.Int32 _ticketId, int start, int pageLength)
		{
			int count = -1;
			return GetByTicketId(null, _ticketId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public CONFDB.Entities.TicketStatusHistory GetByTicketId(TransactionManager transactionManager, System.Int32 _ticketId)
		{
			int count = -1;
			return GetByTicketId(transactionManager, _ticketId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public CONFDB.Entities.TicketStatusHistory GetByTicketId(TransactionManager transactionManager, System.Int32 _ticketId, int start, int pageLength)
		{
			int count = -1;
			return GetByTicketId(transactionManager, _ticketId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="_ticketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public CONFDB.Entities.TicketStatusHistory GetByTicketId(System.Int32 _ticketId, int start, int pageLength, out int count)
		{
			return GetByTicketId(null, _ticketId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TicketStatusHistory_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_ticketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TicketStatusHistory"/> class.</returns>
		public abstract CONFDB.Entities.TicketStatusHistory GetByTicketId(TransactionManager transactionManager, System.Int32 _ticketId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TicketStatusHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TicketStatusHistory&gt;"/></returns>
		public static CONFDB.Entities.TList<TicketStatusHistory> Fill(IDataReader reader, CONFDB.Entities.TList<TicketStatusHistory> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TicketStatusHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TicketStatusHistory")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TicketStatusHistoryColumn.TicketId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TicketStatusHistoryColumn.TicketId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TicketStatusHistory>(
					key.ToString(), // EntityTrackingKey
					"TicketStatusHistory",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TicketStatusHistory();
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
					c.TicketId = (System.Int32)reader[((int)TicketStatusHistoryColumn.TicketId - 1)];
					c.OriginalTicketId = c.TicketId;
					c.StatusId = (System.Int32)reader[((int)TicketStatusHistoryColumn.StatusId - 1)];
					c.StatusDate = (System.DateTime)reader[((int)TicketStatusHistoryColumn.StatusDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketStatusHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatusHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TicketStatusHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.TicketId = (System.Int32)reader[((int)TicketStatusHistoryColumn.TicketId - 1)];
			entity.OriginalTicketId = (System.Int32)reader["TicketID"];
			entity.StatusId = (System.Int32)reader[((int)TicketStatusHistoryColumn.StatusId - 1)];
			entity.StatusDate = (System.DateTime)reader[((int)TicketStatusHistoryColumn.StatusDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TicketStatusHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatusHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TicketStatusHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TicketId = (System.Int32)dataRow["TicketID"];
			entity.OriginalTicketId = (System.Int32)dataRow["TicketID"];
			entity.StatusId = (System.Int32)dataRow["StatusID"];
			entity.StatusDate = (System.DateTime)dataRow["StatusDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TicketStatusHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketStatusHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TicketStatusHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region StatusIdSource	
			if (CanDeepLoad(entity, "TicketStatus|StatusIdSource", deepLoadType, innerList) 
				&& entity.StatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.StatusId;
				TicketStatus tmpEntity = EntityManager.LocateEntity<TicketStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(TicketStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StatusIdSource = tmpEntity;
				else
					entity.StatusIdSource = DataRepository.TicketStatusProvider.GetById(transactionManager, entity.StatusId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.StatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketStatusProvider.DeepLoad(transactionManager, entity.StatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion StatusIdSource

			#region TicketIdSource	
			if (CanDeepLoad(entity, "Ticket|TicketIdSource", deepLoadType, innerList) 
				&& entity.TicketIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TicketId;
				Ticket tmpEntity = EntityManager.LocateEntity<Ticket>(EntityLocator.ConstructKeyFromPkItems(typeof(Ticket), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TicketIdSource = tmpEntity;
				else
					entity.TicketIdSource = DataRepository.TicketProvider.GetById(transactionManager, entity.TicketId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TicketIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TicketIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TicketProvider.DeepLoad(transactionManager, entity.TicketIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TicketIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TicketStatusHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TicketStatusHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TicketStatusHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TicketStatusHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region StatusIdSource
			if (CanDeepSave(entity, "TicketStatus|StatusIdSource", deepSaveType, innerList) 
				&& entity.StatusIdSource != null)
			{
				DataRepository.TicketStatusProvider.Save(transactionManager, entity.StatusIdSource);
				entity.StatusId = entity.StatusIdSource.Id;
			}
			#endregion 
			
			#region TicketIdSource
			if (CanDeepSave(entity, "Ticket|TicketIdSource", deepSaveType, innerList) 
				&& entity.TicketIdSource != null)
			{
				DataRepository.TicketProvider.Save(transactionManager, entity.TicketIdSource);
				entity.TicketId = entity.TicketIdSource.Id;
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
	
	#region TicketStatusHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TicketStatusHistory</c>
	///</summary>
	public enum TicketStatusHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>TicketStatus</c> at StatusIdSource
		///</summary>
		[ChildEntityType(typeof(TicketStatus))]
		TicketStatus,
			
		///<summary>
		/// Composite Property for <c>Ticket</c> at TicketIdSource
		///</summary>
		[ChildEntityType(typeof(Ticket))]
		Ticket,
		}
	
	#endregion TicketStatusHistoryChildEntityTypes
	
	#region TicketStatusHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TicketStatusHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryFilterBuilder : SqlFilterBuilder<TicketStatusHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilterBuilder class.
		/// </summary>
		public TicketStatusHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusHistoryFilterBuilder
	
	#region TicketStatusHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TicketStatusHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TicketStatusHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TicketStatusHistoryParameterBuilder : ParameterizedSqlFilterBuilder<TicketStatusHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryParameterBuilder class.
		/// </summary>
		public TicketStatusHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TicketStatusHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TicketStatusHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TicketStatusHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TicketStatusHistoryParameterBuilder
} // end namespace
