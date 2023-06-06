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
	/// This class is the base class for any <see cref="ParticipantProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ParticipantProviderBaseCore : EntityProviderBase<CONFDB.Entities.Participant, CONFDB.Entities.ParticipantKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ParticipantKey key)
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
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		FK_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="_participantListId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		public CONFDB.Entities.TList<Participant> GetByParticipantListId(System.Int32 _participantListId)
		{
			int count = -1;
			return GetByParticipantListId(_participantListId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		FK_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_participantListId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Participant> GetByParticipantListId(TransactionManager transactionManager, System.Int32 _participantListId)
		{
			int count = -1;
			return GetByParticipantListId(transactionManager, _participantListId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		FK_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_participantListId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		public CONFDB.Entities.TList<Participant> GetByParticipantListId(TransactionManager transactionManager, System.Int32 _participantListId, int start, int pageLength)
		{
			int count = -1;
			return GetByParticipantListId(transactionManager, _participantListId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		fk_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_participantListId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		public CONFDB.Entities.TList<Participant> GetByParticipantListId(System.Int32 _participantListId, int start, int pageLength)
		{
			int count =  -1;
			return GetByParticipantListId(null, _participantListId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		fk_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_participantListId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		public CONFDB.Entities.TList<Participant> GetByParticipantListId(System.Int32 _participantListId, int start, int pageLength,out int count)
		{
			return GetByParticipantListId(null, _participantListId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Participant_ParticipantList key.
		///		FK_Participant_ParticipantList Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_participantListId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Participant objects.</returns>
		public abstract CONFDB.Entities.TList<Participant> GetByParticipantListId(TransactionManager transactionManager, System.Int32 _participantListId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Participant Get(TransactionManager transactionManager, CONFDB.Entities.ParticipantKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Participant_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public CONFDB.Entities.Participant GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Participant_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public CONFDB.Entities.Participant GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Participant_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public CONFDB.Entities.Participant GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Participant_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public CONFDB.Entities.Participant GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Participant_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public CONFDB.Entities.Participant GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Participant_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Participant"/> class.</returns>
		public abstract CONFDB.Entities.Participant GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Participant&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Participant&gt;"/></returns>
		public static CONFDB.Entities.TList<Participant> Fill(IDataReader reader, CONFDB.Entities.TList<Participant> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Participant c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Participant")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ParticipantColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ParticipantColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Participant>(
					key.ToString(), // EntityTrackingKey
					"Participant",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Participant();
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
					c.Id = (System.Int32)reader[((int)ParticipantColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.ParticipantListId = (System.Int32)reader[((int)ParticipantColumn.ParticipantListId - 1)];
					c.Name = (System.String)reader[((int)ParticipantColumn.Name - 1)];
					c.CompanyName = (reader.IsDBNull(((int)ParticipantColumn.CompanyName - 1)))?null:(System.String)reader[((int)ParticipantColumn.CompanyName - 1)];
					c.EmailAddress = (reader.IsDBNull(((int)ParticipantColumn.EmailAddress - 1)))?null:(System.String)reader[((int)ParticipantColumn.EmailAddress - 1)];
					c.PhoneNumber = (reader.IsDBNull(((int)ParticipantColumn.PhoneNumber - 1)))?null:(System.String)reader[((int)ParticipantColumn.PhoneNumber - 1)];
					c.Pin = (reader.IsDBNull(((int)ParticipantColumn.Pin - 1)))?null:(System.String)reader[((int)ParticipantColumn.Pin - 1)];
					c.UserName = (reader.IsDBNull(((int)ParticipantColumn.UserName - 1)))?null:(System.String)reader[((int)ParticipantColumn.UserName - 1)];
					c.Password = (reader.IsDBNull(((int)ParticipantColumn.Password - 1)))?null:(System.String)reader[((int)ParticipantColumn.Password - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Participant"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Participant"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Participant entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ParticipantColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.ParticipantListId = (System.Int32)reader[((int)ParticipantColumn.ParticipantListId - 1)];
			entity.Name = (System.String)reader[((int)ParticipantColumn.Name - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)ParticipantColumn.CompanyName - 1)))?null:(System.String)reader[((int)ParticipantColumn.CompanyName - 1)];
			entity.EmailAddress = (reader.IsDBNull(((int)ParticipantColumn.EmailAddress - 1)))?null:(System.String)reader[((int)ParticipantColumn.EmailAddress - 1)];
			entity.PhoneNumber = (reader.IsDBNull(((int)ParticipantColumn.PhoneNumber - 1)))?null:(System.String)reader[((int)ParticipantColumn.PhoneNumber - 1)];
			entity.Pin = (reader.IsDBNull(((int)ParticipantColumn.Pin - 1)))?null:(System.String)reader[((int)ParticipantColumn.Pin - 1)];
			entity.UserName = (reader.IsDBNull(((int)ParticipantColumn.UserName - 1)))?null:(System.String)reader[((int)ParticipantColumn.UserName - 1)];
			entity.Password = (reader.IsDBNull(((int)ParticipantColumn.Password - 1)))?null:(System.String)reader[((int)ParticipantColumn.Password - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Participant"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Participant"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Participant entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.ParticipantListId = (System.Int32)dataRow["ParticipantListID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.EmailAddress = Convert.IsDBNull(dataRow["EmailAddress"]) ? null : (System.String)dataRow["EmailAddress"];
			entity.PhoneNumber = Convert.IsDBNull(dataRow["PhoneNumber"]) ? null : (System.String)dataRow["PhoneNumber"];
			entity.Pin = Convert.IsDBNull(dataRow["PIN"]) ? null : (System.String)dataRow["PIN"];
			entity.UserName = Convert.IsDBNull(dataRow["UserName"]) ? null : (System.String)dataRow["UserName"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Participant"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Participant Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Participant entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ParticipantListIdSource	
			if (CanDeepLoad(entity, "ParticipantList|ParticipantListIdSource", deepLoadType, innerList) 
				&& entity.ParticipantListIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ParticipantListId;
				ParticipantList tmpEntity = EntityManager.LocateEntity<ParticipantList>(EntityLocator.ConstructKeyFromPkItems(typeof(ParticipantList), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ParticipantListIdSource = tmpEntity;
				else
					entity.ParticipantListIdSource = DataRepository.ParticipantListProvider.GetById(transactionManager, entity.ParticipantListId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ParticipantListIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ParticipantListIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ParticipantListProvider.DeepLoad(transactionManager, entity.ParticipantListIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ParticipantListIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Participant object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Participant instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Participant Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Participant entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ParticipantListIdSource
			if (CanDeepSave(entity, "ParticipantList|ParticipantListIdSource", deepSaveType, innerList) 
				&& entity.ParticipantListIdSource != null)
			{
				DataRepository.ParticipantListProvider.Save(transactionManager, entity.ParticipantListIdSource);
				entity.ParticipantListId = entity.ParticipantListIdSource.Id;
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
	
	#region ParticipantChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Participant</c>
	///</summary>
	public enum ParticipantChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ParticipantList</c> at ParticipantListIdSource
		///</summary>
		[ChildEntityType(typeof(ParticipantList))]
		ParticipantList,
		}
	
	#endregion ParticipantChildEntityTypes
	
	#region ParticipantFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ParticipantColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantFilterBuilder : SqlFilterBuilder<ParticipantColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantFilterBuilder class.
		/// </summary>
		public ParticipantFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantFilterBuilder
	
	#region ParticipantParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ParticipantColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Participant"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ParticipantParameterBuilder : ParameterizedSqlFilterBuilder<ParticipantColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParticipantParameterBuilder class.
		/// </summary>
		public ParticipantParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ParticipantParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParticipantParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParticipantParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParticipantParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ParticipantParameterBuilder
} // end namespace
