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
	/// This class is the base class for any <see cref="TempExistingCodesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TempExistingCodesProviderBaseCore : EntityProviderBase<CONFDB.Entities.TempExistingCodes, CONFDB.Entities.TempExistingCodesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TempExistingCodesKey key)
		{
			return Delete(transactionManager, key.Codes);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_codes">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _codes)
		{
			return Delete(null, _codes);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codes">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _codes);		
		
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
		public override CONFDB.Entities.TempExistingCodes Get(TransactionManager transactionManager, CONFDB.Entities.TempExistingCodesKey key, int start, int pageLength)
		{
			return GetByCodes(transactionManager, key.Codes, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TempExistingCodes_PK index.
		/// </summary>
		/// <param name="_codes"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public CONFDB.Entities.TempExistingCodes GetByCodes(System.String _codes)
		{
			int count = -1;
			return GetByCodes(null,_codes, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempExistingCodes_PK index.
		/// </summary>
		/// <param name="_codes"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public CONFDB.Entities.TempExistingCodes GetByCodes(System.String _codes, int start, int pageLength)
		{
			int count = -1;
			return GetByCodes(null, _codes, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempExistingCodes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codes"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public CONFDB.Entities.TempExistingCodes GetByCodes(TransactionManager transactionManager, System.String _codes)
		{
			int count = -1;
			return GetByCodes(transactionManager, _codes, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempExistingCodes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codes"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public CONFDB.Entities.TempExistingCodes GetByCodes(TransactionManager transactionManager, System.String _codes, int start, int pageLength)
		{
			int count = -1;
			return GetByCodes(transactionManager, _codes, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempExistingCodes_PK index.
		/// </summary>
		/// <param name="_codes"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public CONFDB.Entities.TempExistingCodes GetByCodes(System.String _codes, int start, int pageLength, out int count)
		{
			return GetByCodes(null, _codes, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TempExistingCodes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codes"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempExistingCodes"/> class.</returns>
		public abstract CONFDB.Entities.TempExistingCodes GetByCodes(TransactionManager transactionManager, System.String _codes, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TempExistingCodes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TempExistingCodes&gt;"/></returns>
		public static CONFDB.Entities.TList<TempExistingCodes> Fill(IDataReader reader, CONFDB.Entities.TList<TempExistingCodes> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TempExistingCodes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TempExistingCodes")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TempExistingCodesColumn.Codes - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.TempExistingCodesColumn.Codes - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TempExistingCodes>(
					key.ToString(), // EntityTrackingKey
					"TempExistingCodes",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TempExistingCodes();
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
					c.Codes = (System.String)reader[((int)TempExistingCodesColumn.Codes - 1)];
					c.OriginalCodes = c.Codes;
					c.NewCode = (System.Boolean)reader[((int)TempExistingCodesColumn.NewCode - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)TempExistingCodesColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (reader.IsDBNull(((int)TempExistingCodesColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.SecCustomerNumber - 1)];
					c.Location = (reader.IsDBNull(((int)TempExistingCodesColumn.Location - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.Location - 1)];
					c.WholesalerId = (reader.IsDBNull(((int)TempExistingCodesColumn.WholesalerId - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.WholesalerId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempExistingCodes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempExistingCodes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TempExistingCodes entity)
		{
			if (!reader.Read()) return;
			
			entity.Codes = (System.String)reader[((int)TempExistingCodesColumn.Codes - 1)];
			entity.OriginalCodes = (System.String)reader["Codes"];
			entity.NewCode = (System.Boolean)reader[((int)TempExistingCodesColumn.NewCode - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)TempExistingCodesColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)TempExistingCodesColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.SecCustomerNumber - 1)];
			entity.Location = (reader.IsDBNull(((int)TempExistingCodesColumn.Location - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.Location - 1)];
			entity.WholesalerId = (reader.IsDBNull(((int)TempExistingCodesColumn.WholesalerId - 1)))?null:(System.String)reader[((int)TempExistingCodesColumn.WholesalerId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempExistingCodes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempExistingCodes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TempExistingCodes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Codes = (System.String)dataRow["Codes"];
			entity.OriginalCodes = (System.String)dataRow["Codes"];
			entity.NewCode = (System.Boolean)dataRow["NewCode"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = Convert.IsDBNull(dataRow["SecCustomerNumber"]) ? null : (System.String)dataRow["SecCustomerNumber"];
			entity.Location = Convert.IsDBNull(dataRow["Location"]) ? null : (System.String)dataRow["Location"];
			entity.WholesalerId = Convert.IsDBNull(dataRow["WholesalerID"]) ? null : (System.String)dataRow["WholesalerID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TempExistingCodes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TempExistingCodes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TempExistingCodes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TempExistingCodes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TempExistingCodes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TempExistingCodes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TempExistingCodes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TempExistingCodesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TempExistingCodes</c>
	///</summary>
	public enum TempExistingCodesChildEntityTypes
	{
	}
	
	#endregion TempExistingCodesChildEntityTypes
	
	#region TempExistingCodesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TempExistingCodesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempExistingCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempExistingCodesFilterBuilder : SqlFilterBuilder<TempExistingCodesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilterBuilder class.
		/// </summary>
		public TempExistingCodesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempExistingCodesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempExistingCodesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempExistingCodesFilterBuilder
	
	#region TempExistingCodesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TempExistingCodesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempExistingCodes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempExistingCodesParameterBuilder : ParameterizedSqlFilterBuilder<TempExistingCodesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesParameterBuilder class.
		/// </summary>
		public TempExistingCodesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempExistingCodesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempExistingCodesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempExistingCodesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempExistingCodesParameterBuilder
} // end namespace
