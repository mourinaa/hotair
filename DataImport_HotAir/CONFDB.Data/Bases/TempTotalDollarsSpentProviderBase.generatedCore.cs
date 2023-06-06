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
	/// This class is the base class for any <see cref="TempTotalDollarsSpentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TempTotalDollarsSpentProviderBaseCore : EntityProviderBase<CONFDB.Entities.TempTotalDollarsSpent, CONFDB.Entities.TempTotalDollarsSpentKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.TempTotalDollarsSpentKey key)
		{
			return Delete(transactionManager, key.Id123);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id123">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id123)
		{
			return Delete(null, _id123);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id123">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id123);		
		
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
		public override CONFDB.Entities.TempTotalDollarsSpent Get(TransactionManager transactionManager, CONFDB.Entities.TempTotalDollarsSpentKey key, int start, int pageLength)
		{
			return GetById123(transactionManager, key.Id123, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="_id123"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public CONFDB.Entities.TempTotalDollarsSpent GetById123(System.Int32 _id123)
		{
			int count = -1;
			return GetById123(null,_id123, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="_id123"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public CONFDB.Entities.TempTotalDollarsSpent GetById123(System.Int32 _id123, int start, int pageLength)
		{
			int count = -1;
			return GetById123(null, _id123, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id123"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public CONFDB.Entities.TempTotalDollarsSpent GetById123(TransactionManager transactionManager, System.Int32 _id123)
		{
			int count = -1;
			return GetById123(transactionManager, _id123, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id123"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public CONFDB.Entities.TempTotalDollarsSpent GetById123(TransactionManager transactionManager, System.Int32 _id123, int start, int pageLength)
		{
			int count = -1;
			return GetById123(transactionManager, _id123, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="_id123"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public CONFDB.Entities.TempTotalDollarsSpent GetById123(System.Int32 _id123, int start, int pageLength, out int count)
		{
			return GetById123(null, _id123, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the TempTotalDollarsSpent_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id123"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> class.</returns>
		public abstract CONFDB.Entities.TempTotalDollarsSpent GetById123(TransactionManager transactionManager, System.Int32 _id123, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByPriCustomerNumber(null,_priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumber(null, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(TransactionManager transactionManager, System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByPriCustomerNumber(transactionManager, _priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(TransactionManager transactionManager, System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByPriCustomerNumber(transactionManager, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(System.String _priCustomerNumber, int start, int pageLength, out int count)
		{
			return GetByPriCustomerNumber(null, _priCustomerNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_TempTotalDollarsSpent_PriCustomerNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<TempTotalDollarsSpent> GetByPriCustomerNumber(TransactionManager transactionManager, System.String _priCustomerNumber, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;TempTotalDollarsSpent&gt;"/></returns>
		public static CONFDB.Entities.TList<TempTotalDollarsSpent> Fill(IDataReader reader, CONFDB.Entities.TList<TempTotalDollarsSpent> rows, int start, int pageLength)
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
				
				CONFDB.Entities.TempTotalDollarsSpent c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TempTotalDollarsSpent")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.TempTotalDollarsSpentColumn.Id123 - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.TempTotalDollarsSpentColumn.Id123 - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<TempTotalDollarsSpent>(
					key.ToString(), // EntityTrackingKey
					"TempTotalDollarsSpent",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.TempTotalDollarsSpent();
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
					c.Id123 = (System.Int32)reader[((int)TempTotalDollarsSpentColumn.Id123 - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)TempTotalDollarsSpentColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)TempTotalDollarsSpentColumn.SecCustomerNumber - 1)];
					c.TotalDollarsSpent = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.TotalDollarsSpent - 1)))?null:(System.Decimal?)reader[((int)TempTotalDollarsSpentColumn.TotalDollarsSpent - 1)];
					c.LastTimeUsed = (System.DateTime)reader[((int)TempTotalDollarsSpentColumn.LastTimeUsed - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)TempTotalDollarsSpentColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.TempTotalDollarsSpent entity)
		{
			if (!reader.Read()) return;
			
			entity.Id123 = (System.Int32)reader[((int)TempTotalDollarsSpentColumn.Id123 - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)TempTotalDollarsSpentColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)TempTotalDollarsSpentColumn.SecCustomerNumber - 1)];
			entity.TotalDollarsSpent = (reader.IsDBNull(((int)TempTotalDollarsSpentColumn.TotalDollarsSpent - 1)))?null:(System.Decimal?)reader[((int)TempTotalDollarsSpentColumn.TotalDollarsSpent - 1)];
			entity.LastTimeUsed = (System.DateTime)reader[((int)TempTotalDollarsSpentColumn.LastTimeUsed - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)TempTotalDollarsSpentColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.TempTotalDollarsSpent entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id123 = (System.Int32)dataRow["ID123"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = Convert.IsDBNull(dataRow["SecCustomerNumber"]) ? null : (System.String)dataRow["SecCustomerNumber"];
			entity.TotalDollarsSpent = Convert.IsDBNull(dataRow["TotalDollarsSpent"]) ? null : (System.Decimal?)dataRow["TotalDollarsSpent"];
			entity.LastTimeUsed = (System.DateTime)dataRow["LastTimeUsed"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.TempTotalDollarsSpent"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.TempTotalDollarsSpent Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.TempTotalDollarsSpent entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.TempTotalDollarsSpent object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.TempTotalDollarsSpent instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.TempTotalDollarsSpent Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.TempTotalDollarsSpent entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TempTotalDollarsSpentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.TempTotalDollarsSpent</c>
	///</summary>
	public enum TempTotalDollarsSpentChildEntityTypes
	{
	}
	
	#endregion TempTotalDollarsSpentChildEntityTypes
	
	#region TempTotalDollarsSpentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TempTotalDollarsSpentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentFilterBuilder : SqlFilterBuilder<TempTotalDollarsSpentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilterBuilder class.
		/// </summary>
		public TempTotalDollarsSpentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempTotalDollarsSpentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempTotalDollarsSpentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempTotalDollarsSpentFilterBuilder
	
	#region TempTotalDollarsSpentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TempTotalDollarsSpentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TempTotalDollarsSpent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TempTotalDollarsSpentParameterBuilder : ParameterizedSqlFilterBuilder<TempTotalDollarsSpentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentParameterBuilder class.
		/// </summary>
		public TempTotalDollarsSpentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TempTotalDollarsSpentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TempTotalDollarsSpentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TempTotalDollarsSpentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TempTotalDollarsSpentParameterBuilder
} // end namespace
