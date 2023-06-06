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
	/// This class is the base class for any <see cref="AverageRatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AverageRatesProviderBaseCore : EntityProviderBase<CONFDB.Entities.AverageRates, CONFDB.Entities.AverageRatesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AverageRatesKey key)
		{
			return Delete(transactionManager, key.UsageMonth, key.ProductRateId, key.WholesalerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_usageMonth">. Primary Key.</param>
		/// <param name="_productRateId">. Primary Key.</param>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId)
		{
			return Delete(null, _usageMonth, _productRateId, _wholesalerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_usageMonth">. Primary Key.</param>
		/// <param name="_productRateId">. Primary Key.</param>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId);		
		
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
		public override CONFDB.Entities.AverageRates Get(TransactionManager transactionManager, CONFDB.Entities.AverageRatesKey key, int start, int pageLength)
		{
			return GetByUsageMonthProductRateIdWholesalerId(transactionManager, key.UsageMonth, key.ProductRateId, key.WholesalerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AverageRates_PK index.
		/// </summary>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByUsageMonthProductRateIdWholesalerId(null,_usageMonth, _productRateId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AverageRates_PK index.
		/// </summary>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByUsageMonthProductRateIdWholesalerId(null, _usageMonth, _productRateId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AverageRates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(TransactionManager transactionManager, System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId)
		{
			int count = -1;
			return GetByUsageMonthProductRateIdWholesalerId(transactionManager, _usageMonth, _productRateId, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AverageRates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(TransactionManager transactionManager, System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByUsageMonthProductRateIdWholesalerId(transactionManager, _usageMonth, _productRateId, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AverageRates_PK index.
		/// </summary>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByUsageMonthProductRateIdWholesalerId(null, _usageMonth, _productRateId, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AverageRates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_usageMonth"></param>
		/// <param name="_productRateId"></param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AverageRates"/> class.</returns>
		public abstract CONFDB.Entities.AverageRates GetByUsageMonthProductRateIdWholesalerId(TransactionManager transactionManager, System.DateTime _usageMonth, System.Int32 _productRateId, System.String _wholesalerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AverageRates&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AverageRates&gt;"/></returns>
		public static CONFDB.Entities.TList<AverageRates> Fill(IDataReader reader, CONFDB.Entities.TList<AverageRates> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AverageRates c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AverageRates")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AverageRatesColumn.UsageMonth - 1))?DateTime.MinValue:(System.DateTime)reader[((int)CONFDB.Entities.AverageRatesColumn.UsageMonth - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AverageRatesColumn.ProductRateId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AverageRatesColumn.ProductRateId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AverageRatesColumn.WholesalerId - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.AverageRatesColumn.WholesalerId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AverageRates>(
					key.ToString(), // EntityTrackingKey
					"AverageRates",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AverageRates();
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
					c.UsageMonth = (System.DateTime)reader[((int)AverageRatesColumn.UsageMonth - 1)];
					c.OriginalUsageMonth = c.UsageMonth;
					c.ProductRateId = (System.Int32)reader[((int)AverageRatesColumn.ProductRateId - 1)];
					c.OriginalProductRateId = c.ProductRateId;
					c.WholesalerId = (System.String)reader[((int)AverageRatesColumn.WholesalerId - 1)];
					c.OriginalWholesalerId = c.WholesalerId;
					c.MedianRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.MedianRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.MedianRetailRate - 1)];
					c.AverageRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.AverageRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.AverageRetailRate - 1)];
					c.WeightedAverageRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.WeightedAverageRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.WeightedAverageRetailRate - 1)];
					c.MedianWsRate = (reader.IsDBNull(((int)AverageRatesColumn.MedianWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.MedianWsRate - 1)];
					c.AverageWsRate = (reader.IsDBNull(((int)AverageRatesColumn.AverageWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.AverageWsRate - 1)];
					c.WeightedAverageWsRate = (reader.IsDBNull(((int)AverageRatesColumn.WeightedAverageWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.WeightedAverageWsRate - 1)];
					c.UsageSeconds = (System.Int32)reader[((int)AverageRatesColumn.UsageSeconds - 1)];
					c.UsageQuantity = (System.Int32)reader[((int)AverageRatesColumn.UsageQuantity - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AverageRates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AverageRates"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AverageRates entity)
		{
			if (!reader.Read()) return;
			
			entity.UsageMonth = (System.DateTime)reader[((int)AverageRatesColumn.UsageMonth - 1)];
			entity.OriginalUsageMonth = (System.DateTime)reader["UsageMonth"];
			entity.ProductRateId = (System.Int32)reader[((int)AverageRatesColumn.ProductRateId - 1)];
			entity.OriginalProductRateId = (System.Int32)reader["ProductRateID"];
			entity.WholesalerId = (System.String)reader[((int)AverageRatesColumn.WholesalerId - 1)];
			entity.OriginalWholesalerId = (System.String)reader["WholesalerID"];
			entity.MedianRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.MedianRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.MedianRetailRate - 1)];
			entity.AverageRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.AverageRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.AverageRetailRate - 1)];
			entity.WeightedAverageRetailRate = (reader.IsDBNull(((int)AverageRatesColumn.WeightedAverageRetailRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.WeightedAverageRetailRate - 1)];
			entity.MedianWsRate = (reader.IsDBNull(((int)AverageRatesColumn.MedianWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.MedianWsRate - 1)];
			entity.AverageWsRate = (reader.IsDBNull(((int)AverageRatesColumn.AverageWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.AverageWsRate - 1)];
			entity.WeightedAverageWsRate = (reader.IsDBNull(((int)AverageRatesColumn.WeightedAverageWsRate - 1)))?null:(System.Decimal?)reader[((int)AverageRatesColumn.WeightedAverageWsRate - 1)];
			entity.UsageSeconds = (System.Int32)reader[((int)AverageRatesColumn.UsageSeconds - 1)];
			entity.UsageQuantity = (System.Int32)reader[((int)AverageRatesColumn.UsageQuantity - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AverageRates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AverageRates"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AverageRates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UsageMonth = (System.DateTime)dataRow["UsageMonth"];
			entity.OriginalUsageMonth = (System.DateTime)dataRow["UsageMonth"];
			entity.ProductRateId = (System.Int32)dataRow["ProductRateID"];
			entity.OriginalProductRateId = (System.Int32)dataRow["ProductRateID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.OriginalWholesalerId = (System.String)dataRow["WholesalerID"];
			entity.MedianRetailRate = Convert.IsDBNull(dataRow["MedianRetailRate"]) ? null : (System.Decimal?)dataRow["MedianRetailRate"];
			entity.AverageRetailRate = Convert.IsDBNull(dataRow["AverageRetailRate"]) ? null : (System.Decimal?)dataRow["AverageRetailRate"];
			entity.WeightedAverageRetailRate = Convert.IsDBNull(dataRow["WeightedAverageRetailRate"]) ? null : (System.Decimal?)dataRow["WeightedAverageRetailRate"];
			entity.MedianWsRate = Convert.IsDBNull(dataRow["MedianWSRate"]) ? null : (System.Decimal?)dataRow["MedianWSRate"];
			entity.AverageWsRate = Convert.IsDBNull(dataRow["AverageWSRate"]) ? null : (System.Decimal?)dataRow["AverageWSRate"];
			entity.WeightedAverageWsRate = Convert.IsDBNull(dataRow["WeightedAverageWSRate"]) ? null : (System.Decimal?)dataRow["WeightedAverageWSRate"];
			entity.UsageSeconds = (System.Int32)dataRow["UsageSeconds"];
			entity.UsageQuantity = (System.Int32)dataRow["UsageQuantity"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AverageRates"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AverageRates Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AverageRates entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AverageRates object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AverageRates instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AverageRates Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AverageRates entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AverageRatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AverageRates</c>
	///</summary>
	public enum AverageRatesChildEntityTypes
	{
	}
	
	#endregion AverageRatesChildEntityTypes
	
	#region AverageRatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AverageRatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesFilterBuilder : SqlFilterBuilder<AverageRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilterBuilder class.
		/// </summary>
		public AverageRatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AverageRatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AverageRatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AverageRatesFilterBuilder
	
	#region AverageRatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AverageRatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AverageRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AverageRatesParameterBuilder : ParameterizedSqlFilterBuilder<AverageRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AverageRatesParameterBuilder class.
		/// </summary>
		public AverageRatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AverageRatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AverageRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AverageRatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AverageRatesParameterBuilder
} // end namespace
