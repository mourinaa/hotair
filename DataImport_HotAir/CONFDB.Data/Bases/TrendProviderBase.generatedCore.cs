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
	/// This class is the base class for any <see cref="TrendProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TrendProviderBaseCore : EntityProviderBase<CONFDB.Entities.Trend, CONFDB.Entities.TrendKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TrendKey key)
		{
			return Delete(transactionManager, key.WholesalerId, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _wholesalerId, System.Int32 _customerId)
		{
			return Delete(null, _wholesalerId, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _customerId);		
		
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
		public override CONFDB.Entities.Trend Get(TransactionManager transactionManager, CONFDB.Entities.TrendKey key, int start, int pageLength)
		{
			return GetByWholesalerIdCustomerId(transactionManager, key.WholesalerId, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Trend index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public CONFDB.Entities.Trend GetByWholesalerIdCustomerId(System.String _wholesalerId, System.Int32 _customerId)
		{
			int count = -1;
			return GetByWholesalerIdCustomerId(null,_wholesalerId, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Trend index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public CONFDB.Entities.Trend GetByWholesalerIdCustomerId(System.String _wholesalerId, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdCustomerId(null, _wholesalerId, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Trend index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public CONFDB.Entities.Trend GetByWholesalerIdCustomerId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _customerId)
		{
			int count = -1;
			return GetByWholesalerIdCustomerId(transactionManager, _wholesalerId, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Trend index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public CONFDB.Entities.Trend GetByWholesalerIdCustomerId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdCustomerId(transactionManager, _wholesalerId, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Trend index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public CONFDB.Entities.Trend GetByWholesalerIdCustomerId(System.String _wholesalerId, System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdCustomerId(null, _wholesalerId, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Trend index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Trend"/> class.</returns>
		public abstract CONFDB.Entities.Trend GetByWholesalerIdCustomerId(TransactionManager transactionManager, System.String _wholesalerId, System.Int32 _customerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Trend&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Trend&gt;"/></returns>
		public static CONFDB.Entities.TList<Trend> Fill(IDataReader reader, CONFDB.Entities.TList<Trend> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Trend c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Trend")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TrendColumn.WholesalerId - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.TrendColumn.WholesalerId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TrendColumn.CustomerId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TrendColumn.CustomerId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Trend>(
					key.ToString(), // EntityTrackingKey
					"Trend",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Trend();
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
					c.CompanyId = (System.Int32)reader[((int)TrendColumn.CompanyId - 1)];
					c.WholesalerId = (System.String)reader[((int)TrendColumn.WholesalerId - 1)];
					c.OriginalWholesalerId = c.WholesalerId;
					c.CustomerId = (System.Int32)reader[((int)TrendColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.SalesPersonId = (System.Int32)reader[((int)TrendColumn.SalesPersonId - 1)];
					c.RetailCurrency = (System.String)reader[((int)TrendColumn.RetailCurrency - 1)];
					c.CompanyName = (System.String)reader[((int)TrendColumn.CompanyName - 1)];
					c.TotalRevenueMonth01 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth01 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth01 - 1)];
					c.TotalRevenueMonth02 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth02 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth02 - 1)];
					c.TotalRevenueMonth03 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth03 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth03 - 1)];
					c.TotalRevenueMonth04 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth04 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth04 - 1)];
					c.TotalRevenueMonth05 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth05 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth05 - 1)];
					c.TotalRevenueMonth06 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth06 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth06 - 1)];
					c.TotalRevenueMonth07 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth07 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth07 - 1)];
					c.TotalRevenueMonth08 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth08 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth08 - 1)];
					c.TotalRevenueMonth09 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth09 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth09 - 1)];
					c.TotalRevenueMonth10 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth10 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth10 - 1)];
					c.TotalRevenueMonth11 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth11 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth11 - 1)];
					c.TotalRevenueMonth12 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth12 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth12 - 1)];
					c.YearCategory = (reader.IsDBNull(((int)TrendColumn.YearCategory - 1)))?null:(System.Int32?)reader[((int)TrendColumn.YearCategory - 1)];
					c.StartDate = (reader.IsDBNull(((int)TrendColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)TrendColumn.StartDate - 1)];
					c.EndDate = (reader.IsDBNull(((int)TrendColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)TrendColumn.EndDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Trend"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Trend"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Trend entity)
		{
			if (!reader.Read()) return;
			
			entity.CompanyId = (System.Int32)reader[((int)TrendColumn.CompanyId - 1)];
			entity.WholesalerId = (System.String)reader[((int)TrendColumn.WholesalerId - 1)];
			entity.OriginalWholesalerId = (System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)TrendColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerID"];
			entity.SalesPersonId = (System.Int32)reader[((int)TrendColumn.SalesPersonId - 1)];
			entity.RetailCurrency = (System.String)reader[((int)TrendColumn.RetailCurrency - 1)];
			entity.CompanyName = (System.String)reader[((int)TrendColumn.CompanyName - 1)];
			entity.TotalRevenueMonth01 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth01 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth01 - 1)];
			entity.TotalRevenueMonth02 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth02 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth02 - 1)];
			entity.TotalRevenueMonth03 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth03 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth03 - 1)];
			entity.TotalRevenueMonth04 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth04 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth04 - 1)];
			entity.TotalRevenueMonth05 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth05 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth05 - 1)];
			entity.TotalRevenueMonth06 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth06 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth06 - 1)];
			entity.TotalRevenueMonth07 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth07 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth07 - 1)];
			entity.TotalRevenueMonth08 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth08 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth08 - 1)];
			entity.TotalRevenueMonth09 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth09 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth09 - 1)];
			entity.TotalRevenueMonth10 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth10 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth10 - 1)];
			entity.TotalRevenueMonth11 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth11 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth11 - 1)];
			entity.TotalRevenueMonth12 = (reader.IsDBNull(((int)TrendColumn.TotalRevenueMonth12 - 1)))?null:(System.Decimal?)reader[((int)TrendColumn.TotalRevenueMonth12 - 1)];
			entity.YearCategory = (reader.IsDBNull(((int)TrendColumn.YearCategory - 1)))?null:(System.Int32?)reader[((int)TrendColumn.YearCategory - 1)];
			entity.StartDate = (reader.IsDBNull(((int)TrendColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)TrendColumn.StartDate - 1)];
			entity.EndDate = (reader.IsDBNull(((int)TrendColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)TrendColumn.EndDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Trend"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Trend"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Trend entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CompanyId = (System.Int32)dataRow["CompanyID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.OriginalWholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerID"];
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.RetailCurrency = (System.String)dataRow["RetailCurrency"];
			entity.CompanyName = (System.String)dataRow["CompanyName"];
			entity.TotalRevenueMonth01 = Convert.IsDBNull(dataRow["TotalRevenueMonth01"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth01"];
			entity.TotalRevenueMonth02 = Convert.IsDBNull(dataRow["TotalRevenueMonth02"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth02"];
			entity.TotalRevenueMonth03 = Convert.IsDBNull(dataRow["TotalRevenueMonth03"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth03"];
			entity.TotalRevenueMonth04 = Convert.IsDBNull(dataRow["TotalRevenueMonth04"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth04"];
			entity.TotalRevenueMonth05 = Convert.IsDBNull(dataRow["TotalRevenueMonth05"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth05"];
			entity.TotalRevenueMonth06 = Convert.IsDBNull(dataRow["TotalRevenueMonth06"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth06"];
			entity.TotalRevenueMonth07 = Convert.IsDBNull(dataRow["TotalRevenueMonth07"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth07"];
			entity.TotalRevenueMonth08 = Convert.IsDBNull(dataRow["TotalRevenueMonth08"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth08"];
			entity.TotalRevenueMonth09 = Convert.IsDBNull(dataRow["TotalRevenueMonth09"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth09"];
			entity.TotalRevenueMonth10 = Convert.IsDBNull(dataRow["TotalRevenueMonth10"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth10"];
			entity.TotalRevenueMonth11 = Convert.IsDBNull(dataRow["TotalRevenueMonth11"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth11"];
			entity.TotalRevenueMonth12 = Convert.IsDBNull(dataRow["TotalRevenueMonth12"]) ? null : (System.Decimal?)dataRow["TotalRevenueMonth12"];
			entity.YearCategory = Convert.IsDBNull(dataRow["YearCategory"]) ? null : (System.Int32?)dataRow["YearCategory"];
			entity.StartDate = Convert.IsDBNull(dataRow["StartDate"]) ? null : (System.DateTime?)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Trend"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Trend Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Trend entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Trend object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Trend instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Trend Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Trend entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TrendChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Trend</c>
	///</summary>
	public enum TrendChildEntityTypes
	{
	}
	
	#endregion TrendChildEntityTypes
	
	#region TrendFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TrendColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendFilterBuilder : SqlFilterBuilder<TrendColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendFilterBuilder class.
		/// </summary>
		public TrendFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrendFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrendFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrendFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrendFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrendFilterBuilder
	
	#region TrendParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TrendColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Trend"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrendParameterBuilder : ParameterizedSqlFilterBuilder<TrendColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrendParameterBuilder class.
		/// </summary>
		public TrendParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrendParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrendParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrendParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrendParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrendParameterBuilder
} // end namespace
