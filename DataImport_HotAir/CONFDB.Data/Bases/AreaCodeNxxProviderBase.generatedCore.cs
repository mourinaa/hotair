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
	/// This class is the base class for any <see cref="AreaCodeNxxProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AreaCodeNxxProviderBaseCore : EntityProviderBase<CONFDB.Entities.AreaCodeNxx, CONFDB.Entities.AreaCodeNxxKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AreaCodeNxxKey key)
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
		public override CONFDB.Entities.AreaCodeNxx Get(TransactionManager transactionManager, CONFDB.Entities.AreaCodeNxxKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public CONFDB.Entities.AreaCodeNxx GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public CONFDB.Entities.AreaCodeNxx GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public CONFDB.Entities.AreaCodeNxx GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public CONFDB.Entities.AreaCodeNxx GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public CONFDB.Entities.AreaCodeNxx GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AreaCodeNXX_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AreaCodeNxx"/> class.</returns>
		public abstract CONFDB.Entities.AreaCodeNxx GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AreaCodeNxx&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AreaCodeNxx&gt;"/></returns>
		public static CONFDB.Entities.TList<AreaCodeNxx> Fill(IDataReader reader, CONFDB.Entities.TList<AreaCodeNxx> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AreaCodeNxx c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AreaCodeNxx")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AreaCodeNxxColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AreaCodeNxxColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AreaCodeNxx>(
					key.ToString(), // EntityTrackingKey
					"AreaCodeNxx",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AreaCodeNxx();
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
					c.Id = (System.Int32)reader[((int)AreaCodeNxxColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.AreaCode = (System.String)reader[((int)AreaCodeNxxColumn.AreaCode - 1)];
					c.Location1 = (reader.IsDBNull(((int)AreaCodeNxxColumn.Location1 - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.Location1 - 1)];
					c.Location2 = (reader.IsDBNull(((int)AreaCodeNxxColumn.Location2 - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.Location2 - 1)];
					c.IsoCountryCode = (reader.IsDBNull(((int)AreaCodeNxxColumn.IsoCountryCode - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.IsoCountryCode - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AreaCodeNxx"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AreaCodeNxx"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AreaCodeNxx entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)AreaCodeNxxColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.AreaCode = (System.String)reader[((int)AreaCodeNxxColumn.AreaCode - 1)];
			entity.Location1 = (reader.IsDBNull(((int)AreaCodeNxxColumn.Location1 - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.Location1 - 1)];
			entity.Location2 = (reader.IsDBNull(((int)AreaCodeNxxColumn.Location2 - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.Location2 - 1)];
			entity.IsoCountryCode = (reader.IsDBNull(((int)AreaCodeNxxColumn.IsoCountryCode - 1)))?null:(System.String)reader[((int)AreaCodeNxxColumn.IsoCountryCode - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AreaCodeNxx"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AreaCodeNxx"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AreaCodeNxx entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.AreaCode = (System.String)dataRow["AreaCode"];
			entity.Location1 = Convert.IsDBNull(dataRow["Location1"]) ? null : (System.String)dataRow["Location1"];
			entity.Location2 = Convert.IsDBNull(dataRow["Location2"]) ? null : (System.String)dataRow["Location2"];
			entity.IsoCountryCode = Convert.IsDBNull(dataRow["ISOCountryCode"]) ? null : (System.String)dataRow["ISOCountryCode"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AreaCodeNxx"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AreaCodeNxx Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AreaCodeNxx entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AreaCodeNxx object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AreaCodeNxx instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AreaCodeNxx Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AreaCodeNxx entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AreaCodeNxxChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AreaCodeNxx</c>
	///</summary>
	public enum AreaCodeNxxChildEntityTypes
	{
	}
	
	#endregion AreaCodeNxxChildEntityTypes
	
	#region AreaCodeNxxFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AreaCodeNxxColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxFilterBuilder : SqlFilterBuilder<AreaCodeNxxColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilterBuilder class.
		/// </summary>
		public AreaCodeNxxFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaCodeNxxFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaCodeNxxFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaCodeNxxFilterBuilder
	
	#region AreaCodeNxxParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AreaCodeNxxColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AreaCodeNxx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaCodeNxxParameterBuilder : ParameterizedSqlFilterBuilder<AreaCodeNxxColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxParameterBuilder class.
		/// </summary>
		public AreaCodeNxxParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaCodeNxxParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaCodeNxxParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaCodeNxxParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaCodeNxxParameterBuilder
} // end namespace
