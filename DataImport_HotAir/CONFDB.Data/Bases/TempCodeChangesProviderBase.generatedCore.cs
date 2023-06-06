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
	/// This class is the base class for any <see cref="TempCodeChangesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TempCodeChangesProviderBaseCore : EntityProviderBase<CONFDB.Entities.TempCodeChanges, CONFDB.Entities.TempCodeChangesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TempCodeChangesKey key)
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
		public override CONFDB.Entities.TempCodeChanges Get(TransactionManager transactionManager, CONFDB.Entities.TempCodeChangesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key tempCodeChanges_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public CONFDB.Entities.TempCodeChanges GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the tempCodeChanges_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public CONFDB.Entities.TempCodeChanges GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the tempCodeChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public CONFDB.Entities.TempCodeChanges GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the tempCodeChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public CONFDB.Entities.TempCodeChanges GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the tempCodeChanges_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public CONFDB.Entities.TempCodeChanges GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the tempCodeChanges_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempCodeChanges"/> class.</returns>
		public abstract CONFDB.Entities.TempCodeChanges GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TempCodeChanges&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TempCodeChanges&gt;"/></returns>
		public static CONFDB.Entities.TList<TempCodeChanges> Fill(IDataReader reader, CONFDB.Entities.TList<TempCodeChanges> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TempCodeChanges c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TempCodeChanges")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TempCodeChangesColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TempCodeChangesColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TempCodeChanges>(
					key.ToString(), // EntityTrackingKey
					"TempCodeChanges",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TempCodeChanges();
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
					c.Id = (System.Int32)reader[((int)TempCodeChangesColumn.Id - 1)];
					c.PriCustomerNumber = (System.String)reader[((int)TempCodeChangesColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (System.String)reader[((int)TempCodeChangesColumn.SecCustomerNumber - 1)];
					c.OrigModCode = (System.String)reader[((int)TempCodeChangesColumn.OrigModCode - 1)];
					c.OrigPassCode = (System.String)reader[((int)TempCodeChangesColumn.OrigPassCode - 1)];
					c.ExpectedOrigModCode = (reader.IsDBNull(((int)TempCodeChangesColumn.ExpectedOrigModCode - 1)))?null:(System.String)reader[((int)TempCodeChangesColumn.ExpectedOrigModCode - 1)];
					c.ExpectedOrigPassCode = (reader.IsDBNull(((int)TempCodeChangesColumn.ExpectedOrigPassCode - 1)))?null:(System.String)reader[((int)TempCodeChangesColumn.ExpectedOrigPassCode - 1)];
					c.NewModCode = (System.String)reader[((int)TempCodeChangesColumn.NewModCode - 1)];
					c.NewPassCode = (System.String)reader[((int)TempCodeChangesColumn.NewPassCode - 1)];
					c.AppliedDate = (System.DateTime)reader[((int)TempCodeChangesColumn.AppliedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempCodeChanges"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempCodeChanges"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TempCodeChanges entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)TempCodeChangesColumn.Id - 1)];
			entity.PriCustomerNumber = (System.String)reader[((int)TempCodeChangesColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (System.String)reader[((int)TempCodeChangesColumn.SecCustomerNumber - 1)];
			entity.OrigModCode = (System.String)reader[((int)TempCodeChangesColumn.OrigModCode - 1)];
			entity.OrigPassCode = (System.String)reader[((int)TempCodeChangesColumn.OrigPassCode - 1)];
			entity.ExpectedOrigModCode = (reader.IsDBNull(((int)TempCodeChangesColumn.ExpectedOrigModCode - 1)))?null:(System.String)reader[((int)TempCodeChangesColumn.ExpectedOrigModCode - 1)];
			entity.ExpectedOrigPassCode = (reader.IsDBNull(((int)TempCodeChangesColumn.ExpectedOrigPassCode - 1)))?null:(System.String)reader[((int)TempCodeChangesColumn.ExpectedOrigPassCode - 1)];
			entity.NewModCode = (System.String)reader[((int)TempCodeChangesColumn.NewModCode - 1)];
			entity.NewPassCode = (System.String)reader[((int)TempCodeChangesColumn.NewPassCode - 1)];
			entity.AppliedDate = (System.DateTime)reader[((int)TempCodeChangesColumn.AppliedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempCodeChanges"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempCodeChanges"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TempCodeChanges entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.PriCustomerNumber = (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (System.String)dataRow["SecCustomerNumber"];
			entity.OrigModCode = (System.String)dataRow["OrigModCode"];
			entity.OrigPassCode = (System.String)dataRow["OrigPassCode"];
			entity.ExpectedOrigModCode = Convert.IsDBNull(dataRow["ExpectedOrigModCode"]) ? null : (System.String)dataRow["ExpectedOrigModCode"];
			entity.ExpectedOrigPassCode = Convert.IsDBNull(dataRow["ExpectedOrigPassCode"]) ? null : (System.String)dataRow["ExpectedOrigPassCode"];
			entity.NewModCode = (System.String)dataRow["NewModCode"];
			entity.NewPassCode = (System.String)dataRow["NewPassCode"];
			entity.AppliedDate = (System.DateTime)dataRow["AppliedDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TempCodeChanges"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TempCodeChanges Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TempCodeChanges entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TempCodeChanges object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TempCodeChanges instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TempCodeChanges Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TempCodeChanges entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TempCodeChangesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TempCodeChanges</c>
	///</summary>
	public enum TempCodeChangesChildEntityTypes
	{
	}
	
	#endregion TempCodeChangesChildEntityTypes
	
	#region TempCodeChangesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TempCodeChangesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesFilterBuilder : SqlFilterBuilder<TempCodeChangesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilterBuilder class.
		/// </summary>
		public TempCodeChangesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodeChangesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodeChangesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodeChangesFilterBuilder
	
	#region TempCodeChangesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TempCodeChangesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempCodeChanges"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempCodeChangesParameterBuilder : ParameterizedSqlFilterBuilder<TempCodeChangesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesParameterBuilder class.
		/// </summary>
		public TempCodeChangesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempCodeChangesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempCodeChangesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempCodeChangesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempCodeChangesParameterBuilder
} // end namespace
