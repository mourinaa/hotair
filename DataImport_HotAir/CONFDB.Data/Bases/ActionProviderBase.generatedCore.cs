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
	/// This class is the base class for any <see cref="ActionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ActionProviderBaseCore : EntityProviderBase<CONFDB.Entities.Action, CONFDB.Entities.ActionKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ActionKey key)
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
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		FK_Action_ActionType Description: 
		/// </summary>
		/// <param name="_actionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		public CONFDB.Entities.TList<Action> GetByActionTypeId(System.Int32 _actionTypeId)
		{
			int count = -1;
			return GetByActionTypeId(_actionTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		FK_Action_ActionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Action> GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId)
		{
			int count = -1;
			return GetByActionTypeId(transactionManager, _actionTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		FK_Action_ActionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		public CONFDB.Entities.TList<Action> GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByActionTypeId(transactionManager, _actionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		fk_Action_ActionType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_actionTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		public CONFDB.Entities.TList<Action> GetByActionTypeId(System.Int32 _actionTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByActionTypeId(null, _actionTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		fk_Action_ActionType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_actionTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		public CONFDB.Entities.TList<Action> GetByActionTypeId(System.Int32 _actionTypeId, int start, int pageLength,out int count)
		{
			return GetByActionTypeId(null, _actionTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Action_ActionType key.
		///		FK_Action_ActionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Action objects.</returns>
		public abstract CONFDB.Entities.TList<Action> GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Action Get(TransactionManager transactionManager, CONFDB.Entities.ActionKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Action index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public CONFDB.Entities.Action GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Action index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public CONFDB.Entities.Action GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Action index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public CONFDB.Entities.Action GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Action index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public CONFDB.Entities.Action GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Action index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public CONFDB.Entities.Action GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Action index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Action"/> class.</returns>
		public abstract CONFDB.Entities.Action GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Action&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Action&gt;"/></returns>
		public static CONFDB.Entities.TList<Action> Fill(IDataReader reader, CONFDB.Entities.TList<Action> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Action c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Action")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ActionColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ActionColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Action>(
					key.ToString(), // EntityTrackingKey
					"Action",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Action();
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
					c.Id = (System.Int32)reader[((int)ActionColumn.Id - 1)];
					c.DateTimeStamp = (reader.IsDBNull(((int)ActionColumn.DateTimeStamp - 1)))?null:(System.DateTime?)reader[((int)ActionColumn.DateTimeStamp - 1)];
					c.ActionTypeId = (System.Int32)reader[((int)ActionColumn.ActionTypeId - 1)];
					c.ActionFrom = (System.String)reader[((int)ActionColumn.ActionFrom - 1)];
					c.ExtraInfo = (reader.IsDBNull(((int)ActionColumn.ExtraInfo - 1)))?null:(System.String)reader[((int)ActionColumn.ExtraInfo - 1)];
					c.ProcessedFlag = (System.String)reader[((int)ActionColumn.ProcessedFlag - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Action"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Action"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Action entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ActionColumn.Id - 1)];
			entity.DateTimeStamp = (reader.IsDBNull(((int)ActionColumn.DateTimeStamp - 1)))?null:(System.DateTime?)reader[((int)ActionColumn.DateTimeStamp - 1)];
			entity.ActionTypeId = (System.Int32)reader[((int)ActionColumn.ActionTypeId - 1)];
			entity.ActionFrom = (System.String)reader[((int)ActionColumn.ActionFrom - 1)];
			entity.ExtraInfo = (reader.IsDBNull(((int)ActionColumn.ExtraInfo - 1)))?null:(System.String)reader[((int)ActionColumn.ExtraInfo - 1)];
			entity.ProcessedFlag = (System.String)reader[((int)ActionColumn.ProcessedFlag - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Action"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Action"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Action entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.DateTimeStamp = Convert.IsDBNull(dataRow["DateTimeStamp"]) ? null : (System.DateTime?)dataRow["DateTimeStamp"];
			entity.ActionTypeId = (System.Int32)dataRow["ActionTypeID"];
			entity.ActionFrom = (System.String)dataRow["ActionFrom"];
			entity.ExtraInfo = Convert.IsDBNull(dataRow["ExtraInfo"]) ? null : (System.String)dataRow["ExtraInfo"];
			entity.ProcessedFlag = (System.String)dataRow["ProcessedFlag"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Action"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Action Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Action entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ActionTypeIdSource	
			if (CanDeepLoad(entity, "ActionType|ActionTypeIdSource", deepLoadType, innerList) 
				&& entity.ActionTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ActionTypeId;
				ActionType tmpEntity = EntityManager.LocateEntity<ActionType>(EntityLocator.ConstructKeyFromPkItems(typeof(ActionType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ActionTypeIdSource = tmpEntity;
				else
					entity.ActionTypeIdSource = DataRepository.ActionTypeProvider.GetById(transactionManager, entity.ActionTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ActionTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ActionTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ActionTypeProvider.DeepLoad(transactionManager, entity.ActionTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ActionTypeIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Action object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Action instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Action Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Action entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ActionTypeIdSource
			if (CanDeepSave(entity, "ActionType|ActionTypeIdSource", deepSaveType, innerList) 
				&& entity.ActionTypeIdSource != null)
			{
				DataRepository.ActionTypeProvider.Save(transactionManager, entity.ActionTypeIdSource);
				entity.ActionTypeId = entity.ActionTypeIdSource.Id;
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
	
	#region ActionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Action</c>
	///</summary>
	public enum ActionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ActionType</c> at ActionTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ActionType))]
		ActionType,
		}
	
	#endregion ActionChildEntityTypes
	
	#region ActionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ActionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionFilterBuilder : SqlFilterBuilder<ActionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionFilterBuilder class.
		/// </summary>
		public ActionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionFilterBuilder
	
	#region ActionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ActionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Action"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionParameterBuilder : ParameterizedSqlFilterBuilder<ActionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionParameterBuilder class.
		/// </summary>
		public ActionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionParameterBuilder
} // end namespace
