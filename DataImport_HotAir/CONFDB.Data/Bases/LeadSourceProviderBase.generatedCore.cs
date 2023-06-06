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
	/// This class is the base class for any <see cref="LeadSourceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LeadSourceProviderBaseCore : EntityProviderBase<CONFDB.Entities.LeadSource, CONFDB.Entities.LeadSourceKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.LeadSourceKey key)
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
		public override CONFDB.Entities.LeadSource Get(TransactionManager transactionManager, CONFDB.Entities.LeadSourceKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LeadSource_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public CONFDB.Entities.LeadSource GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadSource_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public CONFDB.Entities.LeadSource GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadSource_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public CONFDB.Entities.LeadSource GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadSource_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public CONFDB.Entities.LeadSource GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadSource_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public CONFDB.Entities.LeadSource GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadSource_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.LeadSource"/> class.</returns>
		public abstract CONFDB.Entities.LeadSource GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;LeadSource&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;LeadSource&gt;"/></returns>
		public static CONFDB.Entities.TList<LeadSource> Fill(IDataReader reader, CONFDB.Entities.TList<LeadSource> rows, int start, int pageLength)
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
				
				CONFDB.Entities.LeadSource c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LeadSource")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.LeadSourceColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.LeadSourceColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<LeadSource>(
					key.ToString(), // EntityTrackingKey
					"LeadSource",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.LeadSource();
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
					c.Id = (System.Int32)reader[((int)LeadSourceColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.Name = (System.String)reader[((int)LeadSourceColumn.Name - 1)];
					c.Value = (System.Int32)reader[((int)LeadSourceColumn.Value - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)LeadSourceColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)LeadSourceColumn.DisplayOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.LeadSource"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.LeadSource"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.LeadSource entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)LeadSourceColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.Name = (System.String)reader[((int)LeadSourceColumn.Name - 1)];
			entity.Value = (System.Int32)reader[((int)LeadSourceColumn.Value - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)LeadSourceColumn.DisplayOrder - 1)))?null:(System.Int16?)reader[((int)LeadSourceColumn.DisplayOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.LeadSource"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.LeadSource"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.LeadSource entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Value = (System.Int32)dataRow["Value"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int16?)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.LeadSource"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.LeadSource Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.LeadSource entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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

				entity.CompanyLeadTrackingCollection = DataRepository.CompanyLeadTrackingProvider.GetByLeadSourceId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the CONFDB.Entities.LeadSource object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.LeadSource instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.LeadSource Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.LeadSource entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CompanyLeadTracking>
				if (CanDeepSave(entity.CompanyLeadTrackingCollection, "List<CompanyLeadTracking>|CompanyLeadTrackingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CompanyLeadTracking child in entity.CompanyLeadTrackingCollection)
					{
						if(child.LeadSourceIdSource != null)
						{
							child.LeadSourceId = child.LeadSourceIdSource.Id;
						}
						else
						{
							child.LeadSourceId = entity.Id;
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
	
	#region LeadSourceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.LeadSource</c>
	///</summary>
	public enum LeadSourceChildEntityTypes
	{

		///<summary>
		/// Collection of <c>LeadSource</c> as OneToMany for CompanyLeadTrackingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CompanyLeadTracking>))]
		CompanyLeadTrackingCollection,
	}
	
	#endregion LeadSourceChildEntityTypes
	
	#region LeadSourceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LeadSourceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceFilterBuilder : SqlFilterBuilder<LeadSourceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilterBuilder class.
		/// </summary>
		public LeadSourceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadSourceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadSourceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadSourceFilterBuilder
	
	#region LeadSourceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LeadSourceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadSource"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadSourceParameterBuilder : ParameterizedSqlFilterBuilder<LeadSourceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadSourceParameterBuilder class.
		/// </summary>
		public LeadSourceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadSourceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadSourceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadSourceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadSourceParameterBuilder
} // end namespace
