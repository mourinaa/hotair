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
	/// This class is the base class for any <see cref="ConferencingSummaryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ConferencingSummaryProviderBaseCore : EntityProviderBase<CONFDB.Entities.ConferencingSummary, CONFDB.Entities.ConferencingSummaryKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ConferencingSummaryKey key)
		{
			return Delete(transactionManager, key.BilledDate, key.ProductId, key.Currency);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_billedDate">. Primary Key.</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <param name="_currency">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.DateTime _billedDate, System.Int32 _productId, System.String _currency)
		{
			return Delete(null, _billedDate, _productId, _currency);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate">. Primary Key.</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <param name="_currency">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.DateTime _billedDate, System.Int32 _productId, System.String _currency);		
		
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
		public override CONFDB.Entities.ConferencingSummary Get(TransactionManager transactionManager, CONFDB.Entities.ConferencingSummaryKey key, int start, int pageLength)
		{
			return GetByBilledDateProductIdCurrency(transactionManager, key.BilledDate, key.ProductId, key.Currency, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key EnunciateSummary_PK index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(System.DateTime _billedDate, System.Int32 _productId, System.String _currency)
		{
			int count = -1;
			return GetByBilledDateProductIdCurrency(null,_billedDate, _productId, _currency, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EnunciateSummary_PK index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(System.DateTime _billedDate, System.Int32 _productId, System.String _currency, int start, int pageLength)
		{
			int count = -1;
			return GetByBilledDateProductIdCurrency(null, _billedDate, _productId, _currency, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EnunciateSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(TransactionManager transactionManager, System.DateTime _billedDate, System.Int32 _productId, System.String _currency)
		{
			int count = -1;
			return GetByBilledDateProductIdCurrency(transactionManager, _billedDate, _productId, _currency, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EnunciateSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(TransactionManager transactionManager, System.DateTime _billedDate, System.Int32 _productId, System.String _currency, int start, int pageLength)
		{
			int count = -1;
			return GetByBilledDateProductIdCurrency(transactionManager, _billedDate, _productId, _currency, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EnunciateSummary_PK index.
		/// </summary>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(System.DateTime _billedDate, System.Int32 _productId, System.String _currency, int start, int pageLength, out int count)
		{
			return GetByBilledDateProductIdCurrency(null, _billedDate, _productId, _currency, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the EnunciateSummary_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billedDate"></param>
		/// <param name="_productId"></param>
		/// <param name="_currency"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ConferencingSummary"/> class.</returns>
		public abstract CONFDB.Entities.ConferencingSummary GetByBilledDateProductIdCurrency(TransactionManager transactionManager, System.DateTime _billedDate, System.Int32 _productId, System.String _currency, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ConferencingSummary&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ConferencingSummary&gt;"/></returns>
		public static CONFDB.Entities.TList<ConferencingSummary> Fill(IDataReader reader, CONFDB.Entities.TList<ConferencingSummary> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ConferencingSummary c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ConferencingSummary")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ConferencingSummaryColumn.BilledDate - 1))?DateTime.MinValue:(System.DateTime)reader[((int)CONFDB.Entities.ConferencingSummaryColumn.BilledDate - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ConferencingSummaryColumn.ProductId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ConferencingSummaryColumn.ProductId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ConferencingSummaryColumn.Currency - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.ConferencingSummaryColumn.Currency - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ConferencingSummary>(
					key.ToString(), // EntityTrackingKey
					"ConferencingSummary",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ConferencingSummary();
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
					c.BilledDate = (System.DateTime)reader[((int)ConferencingSummaryColumn.BilledDate - 1)];
					c.OriginalBilledDate = c.BilledDate;
					c.ProductId = (System.Int32)reader[((int)ConferencingSummaryColumn.ProductId - 1)];
					c.OriginalProductId = c.ProductId;
					c.Currency = (System.String)reader[((int)ConferencingSummaryColumn.Currency - 1)];
					c.OriginalCurrency = c.Currency;
					c.LocalSeconds = (System.Int32)reader[((int)ConferencingSummaryColumn.LocalSeconds - 1)];
					c.LdSeconds = (System.Int32)reader[((int)ConferencingSummaryColumn.LdSeconds - 1)];
					c.TotalBridge = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalBridge - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalBridge - 1)];
					c.TotalLd = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalLd - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalLd - 1)];
					c.TotalMiscellaneous = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalMiscellaneous - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalMiscellaneous - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ConferencingSummary"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ConferencingSummary"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ConferencingSummary entity)
		{
			if (!reader.Read()) return;
			
			entity.BilledDate = (System.DateTime)reader[((int)ConferencingSummaryColumn.BilledDate - 1)];
			entity.OriginalBilledDate = (System.DateTime)reader["BilledDate"];
			entity.ProductId = (System.Int32)reader[((int)ConferencingSummaryColumn.ProductId - 1)];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.Currency = (System.String)reader[((int)ConferencingSummaryColumn.Currency - 1)];
			entity.OriginalCurrency = (System.String)reader["Currency"];
			entity.LocalSeconds = (System.Int32)reader[((int)ConferencingSummaryColumn.LocalSeconds - 1)];
			entity.LdSeconds = (System.Int32)reader[((int)ConferencingSummaryColumn.LdSeconds - 1)];
			entity.TotalBridge = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalBridge - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalBridge - 1)];
			entity.TotalLd = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalLd - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalLd - 1)];
			entity.TotalMiscellaneous = (reader.IsDBNull(((int)ConferencingSummaryColumn.TotalMiscellaneous - 1)))?null:(System.Decimal?)reader[((int)ConferencingSummaryColumn.TotalMiscellaneous - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ConferencingSummary"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ConferencingSummary"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ConferencingSummary entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.BilledDate = (System.DateTime)dataRow["BilledDate"];
			entity.OriginalBilledDate = (System.DateTime)dataRow["BilledDate"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.Currency = (System.String)dataRow["Currency"];
			entity.OriginalCurrency = (System.String)dataRow["Currency"];
			entity.LocalSeconds = (System.Int32)dataRow["LocalSeconds"];
			entity.LdSeconds = (System.Int32)dataRow["LDSeconds"];
			entity.TotalBridge = Convert.IsDBNull(dataRow["TotalBridge"]) ? null : (System.Decimal?)dataRow["TotalBridge"];
			entity.TotalLd = Convert.IsDBNull(dataRow["TotalLD"]) ? null : (System.Decimal?)dataRow["TotalLD"];
			entity.TotalMiscellaneous = Convert.IsDBNull(dataRow["TotalMiscellaneous"]) ? null : (System.Decimal?)dataRow["TotalMiscellaneous"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ConferencingSummary"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ConferencingSummary Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ConferencingSummary entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ConferencingSummary object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ConferencingSummary instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ConferencingSummary Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ConferencingSummary entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ConferencingSummaryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ConferencingSummary</c>
	///</summary>
	public enum ConferencingSummaryChildEntityTypes
	{
	}
	
	#endregion ConferencingSummaryChildEntityTypes
	
	#region ConferencingSummaryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ConferencingSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryFilterBuilder : SqlFilterBuilder<ConferencingSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilterBuilder class.
		/// </summary>
		public ConferencingSummaryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConferencingSummaryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConferencingSummaryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConferencingSummaryFilterBuilder
	
	#region ConferencingSummaryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ConferencingSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ConferencingSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConferencingSummaryParameterBuilder : ParameterizedSqlFilterBuilder<ConferencingSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryParameterBuilder class.
		/// </summary>
		public ConferencingSummaryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConferencingSummaryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConferencingSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConferencingSummaryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConferencingSummaryParameterBuilder
} // end namespace
