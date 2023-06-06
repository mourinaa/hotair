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
	/// This class is the base class for any <see cref="AuditLogProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AuditLogProviderBaseCore : EntityProviderBase<CONFDB.Entities.AuditLog, CONFDB.Entities.AuditLogKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AuditLogKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">Table used to stored audit log and changes for user items. Primary Key.</param>
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
		/// <param name="_id">Table used to stored audit log and changes for user items. Primary Key.</param>
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
		public override CONFDB.Entities.AuditLog Get(TransactionManager transactionManager, CONFDB.Entities.AuditLogKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AuditLog index.
		/// </summary>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public CONFDB.Entities.AuditLog GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AuditLog index.
		/// </summary>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public CONFDB.Entities.AuditLog GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AuditLog index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public CONFDB.Entities.AuditLog GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AuditLog index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public CONFDB.Entities.AuditLog GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AuditLog index.
		/// </summary>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public CONFDB.Entities.AuditLog GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AuditLog index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">Table used to stored audit log and changes for user items</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AuditLog"/> class.</returns>
		public abstract CONFDB.Entities.AuditLog GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AuditLog&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AuditLog&gt;"/></returns>
		public static CONFDB.Entities.TList<AuditLog> Fill(IDataReader reader, CONFDB.Entities.TList<AuditLog> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AuditLog c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AuditLog")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AuditLogColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AuditLogColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AuditLog>(
					key.ToString(), // EntityTrackingKey
					"AuditLog",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AuditLog();
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
					c.Id = (System.Int32)reader[((int)AuditLogColumn.Id - 1)];
					c.TblName = (reader.IsDBNull(((int)AuditLogColumn.TblName - 1)))?null:(System.String)reader[((int)AuditLogColumn.TblName - 1)];
					c.TablePkid = (reader.IsDBNull(((int)AuditLogColumn.TablePkid - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.TablePkid - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)AuditLogColumn.CreatedDate - 1)];
					c.CustomerId = (reader.IsDBNull(((int)AuditLogColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.CustomerId - 1)];
					c.ModeratorId = (reader.IsDBNull(((int)AuditLogColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.ModeratorId - 1)];
					c.ColumnsUpdated = (reader.IsDBNull(((int)AuditLogColumn.ColumnsUpdated - 1)))?null:(string)reader[((int)AuditLogColumn.ColumnsUpdated - 1)];
					c.Category = (reader.IsDBNull(((int)AuditLogColumn.Category - 1)))?null:(System.String)reader[((int)AuditLogColumn.Category - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AuditLog"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AuditLog"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AuditLog entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)AuditLogColumn.Id - 1)];
			entity.TblName = (reader.IsDBNull(((int)AuditLogColumn.TblName - 1)))?null:(System.String)reader[((int)AuditLogColumn.TblName - 1)];
			entity.TablePkid = (reader.IsDBNull(((int)AuditLogColumn.TablePkid - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.TablePkid - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)AuditLogColumn.CreatedDate - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)AuditLogColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.CustomerId - 1)];
			entity.ModeratorId = (reader.IsDBNull(((int)AuditLogColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)AuditLogColumn.ModeratorId - 1)];
			entity.ColumnsUpdated = (reader.IsDBNull(((int)AuditLogColumn.ColumnsUpdated - 1)))?null:(string)reader[((int)AuditLogColumn.ColumnsUpdated - 1)];
			entity.Category = (reader.IsDBNull(((int)AuditLogColumn.Category - 1)))?null:(System.String)reader[((int)AuditLogColumn.Category - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AuditLog"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AuditLog"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AuditLog entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.TblName = Convert.IsDBNull(dataRow["TblName"]) ? null : (System.String)dataRow["TblName"];
			entity.TablePkid = Convert.IsDBNull(dataRow["TablePKID"]) ? null : (System.Int32?)dataRow["TablePKID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.ModeratorId = Convert.IsDBNull(dataRow["ModeratorID"]) ? null : (System.Int32?)dataRow["ModeratorID"];
			entity.ColumnsUpdated = Convert.IsDBNull(dataRow["ColumnsUpdated"]) ? null : (string)dataRow["ColumnsUpdated"];
			entity.Category = Convert.IsDBNull(dataRow["Category"]) ? null : (System.String)dataRow["Category"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AuditLog"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AuditLog Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AuditLog entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AuditLog object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AuditLog instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AuditLog Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AuditLog entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AuditLogChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AuditLog</c>
	///</summary>
	public enum AuditLogChildEntityTypes
	{
	}
	
	#endregion AuditLogChildEntityTypes
	
	#region AuditLogFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AuditLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AuditLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditLogFilterBuilder : SqlFilterBuilder<AuditLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditLogFilterBuilder class.
		/// </summary>
		public AuditLogFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditLogFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditLogFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditLogFilterBuilder
	
	#region AuditLogParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AuditLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AuditLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuditLogParameterBuilder : ParameterizedSqlFilterBuilder<AuditLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuditLogParameterBuilder class.
		/// </summary>
		public AuditLogParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuditLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuditLogParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuditLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuditLogParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuditLogParameterBuilder
} // end namespace
