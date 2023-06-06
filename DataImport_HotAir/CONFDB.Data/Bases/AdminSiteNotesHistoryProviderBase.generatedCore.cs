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
	/// This class is the base class for any <see cref="AdminSiteNotesHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminSiteNotesHistoryProviderBaseCore : EntityProviderBase<CONFDB.Entities.AdminSiteNotesHistory, CONFDB.Entities.AdminSiteNotesHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AdminSiteNotesHistoryKey key)
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
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		FK_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="_adminSiteNotesId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		public CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(System.Int32? _adminSiteNotesId)
		{
			int count = -1;
			return GetByAdminSiteNotesId(_adminSiteNotesId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		FK_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminSiteNotesId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(TransactionManager transactionManager, System.Int32? _adminSiteNotesId)
		{
			int count = -1;
			return GetByAdminSiteNotesId(transactionManager, _adminSiteNotesId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		FK_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminSiteNotesId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		public CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(TransactionManager transactionManager, System.Int32? _adminSiteNotesId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminSiteNotesId(transactionManager, _adminSiteNotesId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		fk_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_adminSiteNotesId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		public CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(System.Int32? _adminSiteNotesId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdminSiteNotesId(null, _adminSiteNotesId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		fk_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_adminSiteNotesId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		public CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(System.Int32? _adminSiteNotesId, int start, int pageLength,out int count)
		{
			return GetByAdminSiteNotesId(null, _adminSiteNotesId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminSiteNotesHistory_AdminSiteNotes key.
		///		FK_AdminSiteNotesHistory_AdminSiteNotes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminSiteNotesId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AdminSiteNotesHistory objects.</returns>
		public abstract CONFDB.Entities.TList<AdminSiteNotesHistory> GetByAdminSiteNotesId(TransactionManager transactionManager, System.Int32? _adminSiteNotesId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.AdminSiteNotesHistory Get(TransactionManager transactionManager, CONFDB.Entities.AdminSiteNotesHistoryKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public CONFDB.Entities.AdminSiteNotesHistory GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public CONFDB.Entities.AdminSiteNotesHistory GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public CONFDB.Entities.AdminSiteNotesHistory GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public CONFDB.Entities.AdminSiteNotesHistory GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public CONFDB.Entities.AdminSiteNotesHistory GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdminSiteNotesHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> class.</returns>
		public abstract CONFDB.Entities.AdminSiteNotesHistory GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AdminSiteNotesHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AdminSiteNotesHistory&gt;"/></returns>
		public static CONFDB.Entities.TList<AdminSiteNotesHistory> Fill(IDataReader reader, CONFDB.Entities.TList<AdminSiteNotesHistory> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AdminSiteNotesHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdminSiteNotesHistory")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AdminSiteNotesHistoryColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AdminSiteNotesHistoryColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AdminSiteNotesHistory>(
					key.ToString(), // EntityTrackingKey
					"AdminSiteNotesHistory",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AdminSiteNotesHistory();
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
					c.Id = (System.Int32)reader[((int)AdminSiteNotesHistoryColumn.Id - 1)];
					c.AdminSiteNotesId = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.AdminSiteNotesId - 1)))?null:(System.Int32?)reader[((int)AdminSiteNotesHistoryColumn.AdminSiteNotesId - 1)];
					c.Notes = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.Notes - 1)))?null:(System.String)reader[((int)AdminSiteNotesHistoryColumn.Notes - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)AdminSiteNotesHistoryColumn.ModifiedBy - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)AdminSiteNotesHistoryColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AdminSiteNotesHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)AdminSiteNotesHistoryColumn.Id - 1)];
			entity.AdminSiteNotesId = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.AdminSiteNotesId - 1)))?null:(System.Int32?)reader[((int)AdminSiteNotesHistoryColumn.AdminSiteNotesId - 1)];
			entity.Notes = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.Notes - 1)))?null:(System.String)reader[((int)AdminSiteNotesHistoryColumn.Notes - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)AdminSiteNotesHistoryColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)AdminSiteNotesHistoryColumn.ModifiedBy - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)AdminSiteNotesHistoryColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AdminSiteNotesHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.AdminSiteNotesId = Convert.IsDBNull(dataRow["AdminSiteNotesID"]) ? null : (System.Int32?)dataRow["AdminSiteNotesID"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AdminSiteNotesHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AdminSiteNotesHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AdminSiteNotesHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdminSiteNotesIdSource	
			if (CanDeepLoad(entity, "AdminSiteNotes|AdminSiteNotesIdSource", deepLoadType, innerList) 
				&& entity.AdminSiteNotesIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AdminSiteNotesId ?? (int)0);
				AdminSiteNotes tmpEntity = EntityManager.LocateEntity<AdminSiteNotes>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminSiteNotes), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdminSiteNotesIdSource = tmpEntity;
				else
					entity.AdminSiteNotesIdSource = DataRepository.AdminSiteNotesProvider.GetById(transactionManager, (entity.AdminSiteNotesId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminSiteNotesIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminSiteNotesIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminSiteNotesProvider.DeepLoad(transactionManager, entity.AdminSiteNotesIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdminSiteNotesIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AdminSiteNotesHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AdminSiteNotesHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AdminSiteNotesHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AdminSiteNotesHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdminSiteNotesIdSource
			if (CanDeepSave(entity, "AdminSiteNotes|AdminSiteNotesIdSource", deepSaveType, innerList) 
				&& entity.AdminSiteNotesIdSource != null)
			{
				DataRepository.AdminSiteNotesProvider.Save(transactionManager, entity.AdminSiteNotesIdSource);
				entity.AdminSiteNotesId = entity.AdminSiteNotesIdSource.Id;
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
	
	#region AdminSiteNotesHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AdminSiteNotesHistory</c>
	///</summary>
	public enum AdminSiteNotesHistoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminSiteNotes</c> at AdminSiteNotesIdSource
		///</summary>
		[ChildEntityType(typeof(AdminSiteNotes))]
		AdminSiteNotes,
		}
	
	#endregion AdminSiteNotesHistoryChildEntityTypes
	
	#region AdminSiteNotesHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminSiteNotesHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryFilterBuilder : SqlFilterBuilder<AdminSiteNotesHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilterBuilder class.
		/// </summary>
		public AdminSiteNotesHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesHistoryFilterBuilder
	
	#region AdminSiteNotesHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminSiteNotesHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminSiteNotesHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminSiteNotesHistoryParameterBuilder : ParameterizedSqlFilterBuilder<AdminSiteNotesHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryParameterBuilder class.
		/// </summary>
		public AdminSiteNotesHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminSiteNotesHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminSiteNotesHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminSiteNotesHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminSiteNotesHistoryParameterBuilder
} // end namespace
