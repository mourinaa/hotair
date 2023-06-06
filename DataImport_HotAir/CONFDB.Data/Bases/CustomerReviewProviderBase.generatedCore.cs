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
	/// This class is the base class for any <see cref="CustomerReviewProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerReviewProviderBaseCore : EntityProviderBase<CONFDB.Entities.CustomerReview, CONFDB.Entities.CustomerReviewKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerReviewKey key)
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
		public override CONFDB.Entities.CustomerReview Get(TransactionManager transactionManager, CONFDB.Entities.CustomerReviewKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerReview_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public CONFDB.Entities.CustomerReview GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerReview_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public CONFDB.Entities.CustomerReview GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerReview_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public CONFDB.Entities.CustomerReview GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerReview_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public CONFDB.Entities.CustomerReview GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerReview_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public CONFDB.Entities.CustomerReview GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerReview_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerReview"/> class.</returns>
		public abstract CONFDB.Entities.CustomerReview GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CustomerReview&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CustomerReview&gt;"/></returns>
		public static CONFDB.Entities.TList<CustomerReview> Fill(IDataReader reader, CONFDB.Entities.TList<CustomerReview> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CustomerReview c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerReview")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerReviewColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CustomerReviewColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CustomerReview>(
					key.ToString(), // EntityTrackingKey
					"CustomerReview",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CustomerReview();
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
					c.Id = (System.Int32)reader[((int)CustomerReviewColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.CompanyId = (System.Int32)reader[((int)CustomerReviewColumn.CompanyId - 1)];
					c.GeneralSatisfaction = (reader.IsDBNull(((int)CustomerReviewColumn.GeneralSatisfaction - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.GeneralSatisfaction - 1)];
					c.AreasOfImprovement = (reader.IsDBNull(((int)CustomerReviewColumn.AreasOfImprovement - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.AreasOfImprovement - 1)];
					c.ProductDiscussed = (reader.IsDBNull(((int)CustomerReviewColumn.ProductDiscussed - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.ProductDiscussed - 1)];
					c.Referrals = (reader.IsDBNull(((int)CustomerReviewColumn.Referrals - 1)))?null:(System.Boolean?)reader[((int)CustomerReviewColumn.Referrals - 1)];
					c.Notes = (reader.IsDBNull(((int)CustomerReviewColumn.Notes - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.Notes - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)CustomerReviewColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.ModifiedBy - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CustomerReviewColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerReview"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerReview"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CustomerReview entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomerReviewColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.CompanyId = (System.Int32)reader[((int)CustomerReviewColumn.CompanyId - 1)];
			entity.GeneralSatisfaction = (reader.IsDBNull(((int)CustomerReviewColumn.GeneralSatisfaction - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.GeneralSatisfaction - 1)];
			entity.AreasOfImprovement = (reader.IsDBNull(((int)CustomerReviewColumn.AreasOfImprovement - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.AreasOfImprovement - 1)];
			entity.ProductDiscussed = (reader.IsDBNull(((int)CustomerReviewColumn.ProductDiscussed - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.ProductDiscussed - 1)];
			entity.Referrals = (reader.IsDBNull(((int)CustomerReviewColumn.Referrals - 1)))?null:(System.Boolean?)reader[((int)CustomerReviewColumn.Referrals - 1)];
			entity.Notes = (reader.IsDBNull(((int)CustomerReviewColumn.Notes - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.Notes - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)CustomerReviewColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerReviewColumn.ModifiedBy - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CustomerReviewColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerReview"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerReview"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CustomerReview entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.CompanyId = (System.Int32)dataRow["CompanyID"];
			entity.GeneralSatisfaction = Convert.IsDBNull(dataRow["GeneralSatisfaction"]) ? null : (System.String)dataRow["GeneralSatisfaction"];
			entity.AreasOfImprovement = Convert.IsDBNull(dataRow["AreasOfImprovement"]) ? null : (System.String)dataRow["AreasOfImprovement"];
			entity.ProductDiscussed = Convert.IsDBNull(dataRow["ProductDiscussed"]) ? null : (System.String)dataRow["ProductDiscussed"];
			entity.Referrals = Convert.IsDBNull(dataRow["Referrals"]) ? null : (System.Boolean?)dataRow["Referrals"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerReview"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerReview Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CustomerReview entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CustomerReview object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CustomerReview instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerReview Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CustomerReview entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CustomerReviewChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CustomerReview</c>
	///</summary>
	public enum CustomerReviewChildEntityTypes
	{
	}
	
	#endregion CustomerReviewChildEntityTypes
	
	#region CustomerReviewFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerReviewColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerReviewFilterBuilder : SqlFilterBuilder<CustomerReviewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilterBuilder class.
		/// </summary>
		public CustomerReviewFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerReviewFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerReviewFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerReviewFilterBuilder
	
	#region CustomerReviewParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerReviewColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerReview"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerReviewParameterBuilder : ParameterizedSqlFilterBuilder<CustomerReviewColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerReviewParameterBuilder class.
		/// </summary>
		public CustomerReviewParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerReviewParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerReviewParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerReviewParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerReviewParameterBuilder
} // end namespace
