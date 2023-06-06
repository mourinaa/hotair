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
	/// This class is the base class for any <see cref="OmnoviaHostedArchiveParticipantProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OmnoviaHostedArchiveParticipantProviderBaseCore : EntityProviderBase<CONFDB.Entities.OmnoviaHostedArchiveParticipant, CONFDB.Entities.OmnoviaHostedArchiveParticipantKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveParticipantKey key)
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
		public override CONFDB.Entities.OmnoviaHostedArchiveParticipant Get(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveParticipantKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchiveParticipant_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> class.</returns>
		public abstract CONFDB.Entities.OmnoviaHostedArchiveParticipant GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_OmnoviaHostedArchiveParticipant_GetListByHostedArchiveID 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchiveParticipant_GetListByHostedArchiveID' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetListByHostedArchiveID(System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId)
		{
			return GetListByHostedArchiveID(null, 0, int.MaxValue , omnoviaCustomerId, moderatorId, hostedArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchiveParticipant_GetListByHostedArchiveID' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetListByHostedArchiveID(int start, int pageLength, System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId)
		{
			return GetListByHostedArchiveID(null, start, pageLength , omnoviaCustomerId, moderatorId, hostedArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchiveParticipant_GetListByHostedArchiveID' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetListByHostedArchiveID(TransactionManager transactionManager, System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId)
		{
			return GetListByHostedArchiveID(transactionManager, 0, int.MaxValue , omnoviaCustomerId, moderatorId, hostedArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchiveParticipant_GetListByHostedArchiveID' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetListByHostedArchiveID(TransactionManager transactionManager, int start, int pageLength , System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;OmnoviaHostedArchiveParticipant&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;OmnoviaHostedArchiveParticipant&gt;"/></returns>
		public static CONFDB.Entities.TList<OmnoviaHostedArchiveParticipant> Fill(IDataReader reader, CONFDB.Entities.TList<OmnoviaHostedArchiveParticipant> rows, int start, int pageLength)
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
				
				CONFDB.Entities.OmnoviaHostedArchiveParticipant c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OmnoviaHostedArchiveParticipant")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.OmnoviaHostedArchiveParticipantColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.OmnoviaHostedArchiveParticipantColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<OmnoviaHostedArchiveParticipant>(
					key.ToString(), // EntityTrackingKey
					"OmnoviaHostedArchiveParticipant",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.OmnoviaHostedArchiveParticipant();
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
					c.Id = (System.Int32)reader[((int)OmnoviaHostedArchiveParticipantColumn.Id - 1)];
					c.HostedArchiveId = (System.Int32)reader[((int)OmnoviaHostedArchiveParticipantColumn.HostedArchiveId - 1)];
					c.Firstname = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Firstname - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Firstname - 1)];
					c.Lastname = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Lastname - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Lastname - 1)];
					c.Company = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Company - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Company - 1)];
					c.Email = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Email - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Email - 1)];
					c.Created = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveParticipantColumn.Created - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.OmnoviaHostedArchiveParticipant entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OmnoviaHostedArchiveParticipantColumn.Id - 1)];
			entity.HostedArchiveId = (System.Int32)reader[((int)OmnoviaHostedArchiveParticipantColumn.HostedArchiveId - 1)];
			entity.Firstname = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Firstname - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Firstname - 1)];
			entity.Lastname = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Lastname - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Lastname - 1)];
			entity.Company = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Company - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Company - 1)];
			entity.Email = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Email - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveParticipantColumn.Email - 1)];
			entity.Created = (reader.IsDBNull(((int)OmnoviaHostedArchiveParticipantColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveParticipantColumn.Created - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.OmnoviaHostedArchiveParticipant entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.HostedArchiveId = (System.Int32)dataRow["HostedArchiveID"];
			entity.Firstname = Convert.IsDBNull(dataRow["Firstname"]) ? null : (System.String)dataRow["Firstname"];
			entity.Lastname = Convert.IsDBNull(dataRow["Lastname"]) ? null : (System.String)dataRow["Lastname"];
			entity.Company = Convert.IsDBNull(dataRow["Company"]) ? null : (System.String)dataRow["Company"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Created = Convert.IsDBNull(dataRow["created"]) ? null : (System.DateTime?)dataRow["created"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchiveParticipant"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaHostedArchiveParticipant Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveParticipant entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.OmnoviaHostedArchiveParticipant object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.OmnoviaHostedArchiveParticipant instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaHostedArchiveParticipant Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveParticipant entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region OmnoviaHostedArchiveParticipantChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.OmnoviaHostedArchiveParticipant</c>
	///</summary>
	public enum OmnoviaHostedArchiveParticipantChildEntityTypes
	{
	}
	
	#endregion OmnoviaHostedArchiveParticipantChildEntityTypes
	
	#region OmnoviaHostedArchiveParticipantFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OmnoviaHostedArchiveParticipantColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantFilterBuilder : SqlFilterBuilder<OmnoviaHostedArchiveParticipantColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilterBuilder class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveParticipantFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveParticipantFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveParticipantFilterBuilder
	
	#region OmnoviaHostedArchiveParticipantParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OmnoviaHostedArchiveParticipantColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchiveParticipant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParticipantParameterBuilder : ParameterizedSqlFilterBuilder<OmnoviaHostedArchiveParticipantColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantParameterBuilder class.
		/// </summary>
		public OmnoviaHostedArchiveParticipantParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveParticipantParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParticipantParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveParticipantParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveParticipantParameterBuilder
} // end namespace
