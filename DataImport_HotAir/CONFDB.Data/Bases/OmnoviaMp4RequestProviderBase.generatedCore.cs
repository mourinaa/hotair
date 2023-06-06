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
	/// This class is the base class for any <see cref="OmnoviaMp4RequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OmnoviaMp4RequestProviderBaseCore : EntityProviderBase<CONFDB.Entities.OmnoviaMp4Request, CONFDB.Entities.OmnoviaMp4RequestKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.OmnoviaMp4RequestKey key)
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
		public override CONFDB.Entities.OmnoviaMp4Request Get(TransactionManager transactionManager, CONFDB.Entities.OmnoviaMp4RequestKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public CONFDB.Entities.OmnoviaMp4Request GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public CONFDB.Entities.OmnoviaMp4Request GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public CONFDB.Entities.OmnoviaMp4Request GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public CONFDB.Entities.OmnoviaMp4Request GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public CONFDB.Entities.OmnoviaMp4Request GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaMP4Request index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> class.</returns>
		public abstract CONFDB.Entities.OmnoviaMp4Request GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;OmnoviaMp4Request&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;OmnoviaMp4Request&gt;"/></returns>
		public static CONFDB.Entities.TList<OmnoviaMp4Request> Fill(IDataReader reader, CONFDB.Entities.TList<OmnoviaMp4Request> rows, int start, int pageLength)
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
				
				CONFDB.Entities.OmnoviaMp4Request c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OmnoviaMp4Request")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.OmnoviaMp4RequestColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.OmnoviaMp4RequestColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<OmnoviaMp4Request>(
					key.ToString(), // EntityTrackingKey
					"OmnoviaMp4Request",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.OmnoviaMp4Request();
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
					c.Id = (System.Int32)reader[((int)OmnoviaMp4RequestColumn.Id - 1)];
					c.HostedId = (System.Int32)reader[((int)OmnoviaMp4RequestColumn.HostedId - 1)];
					c.RequestedBy = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.RequestedBy - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.RequestedBy - 1)];
					c.EstimatedTime = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.EstimatedTime - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.EstimatedTime - 1)];
					c.ExtraInfo = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.ExtraInfo - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.ExtraInfo - 1)];
					c.OmnoviaHostedUrl = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrl - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrl - 1)];
					c.RedbackHostedUrl = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.RedbackHostedUrl - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.RedbackHostedUrl - 1)];
					c.OmnoviaHostedUrlExpiryDate = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrlExpiryDate - 1)))?null:(System.DateTime?)reader[((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrlExpiryDate - 1)];
					c.Created = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaMp4RequestColumn.Created - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaMp4Request"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.OmnoviaMp4Request entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OmnoviaMp4RequestColumn.Id - 1)];
			entity.HostedId = (System.Int32)reader[((int)OmnoviaMp4RequestColumn.HostedId - 1)];
			entity.RequestedBy = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.RequestedBy - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.RequestedBy - 1)];
			entity.EstimatedTime = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.EstimatedTime - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.EstimatedTime - 1)];
			entity.ExtraInfo = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.ExtraInfo - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.ExtraInfo - 1)];
			entity.OmnoviaHostedUrl = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrl - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrl - 1)];
			entity.RedbackHostedUrl = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.RedbackHostedUrl - 1)))?null:(System.String)reader[((int)OmnoviaMp4RequestColumn.RedbackHostedUrl - 1)];
			entity.OmnoviaHostedUrlExpiryDate = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrlExpiryDate - 1)))?null:(System.DateTime?)reader[((int)OmnoviaMp4RequestColumn.OmnoviaHostedUrlExpiryDate - 1)];
			entity.Created = (reader.IsDBNull(((int)OmnoviaMp4RequestColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaMp4RequestColumn.Created - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaMp4Request"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaMp4Request"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.OmnoviaMp4Request entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.HostedId = (System.Int32)dataRow["HostedID"];
			entity.RequestedBy = Convert.IsDBNull(dataRow["RequestedBy"]) ? null : (System.String)dataRow["RequestedBy"];
			entity.EstimatedTime = Convert.IsDBNull(dataRow["EstimatedTime"]) ? null : (System.String)dataRow["EstimatedTime"];
			entity.ExtraInfo = Convert.IsDBNull(dataRow["ExtraInfo"]) ? null : (System.String)dataRow["ExtraInfo"];
			entity.OmnoviaHostedUrl = Convert.IsDBNull(dataRow["OmnoviaHostedURL"]) ? null : (System.String)dataRow["OmnoviaHostedURL"];
			entity.RedbackHostedUrl = Convert.IsDBNull(dataRow["RedbackHostedURL"]) ? null : (System.String)dataRow["RedbackHostedURL"];
			entity.OmnoviaHostedUrlExpiryDate = Convert.IsDBNull(dataRow["OmnoviaHostedURLExpiryDate"]) ? null : (System.DateTime?)dataRow["OmnoviaHostedURLExpiryDate"];
			entity.Created = Convert.IsDBNull(dataRow["created"]) ? null : (System.DateTime?)dataRow["created"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaMp4Request"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaMp4Request Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.OmnoviaMp4Request entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.OmnoviaMp4Request object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.OmnoviaMp4Request instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaMp4Request Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.OmnoviaMp4Request entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region OmnoviaMp4RequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.OmnoviaMp4Request</c>
	///</summary>
	public enum OmnoviaMp4RequestChildEntityTypes
	{
	}
	
	#endregion OmnoviaMp4RequestChildEntityTypes
	
	#region OmnoviaMp4RequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OmnoviaMp4RequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestFilterBuilder : SqlFilterBuilder<OmnoviaMp4RequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilterBuilder class.
		/// </summary>
		public OmnoviaMp4RequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaMp4RequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaMp4RequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaMp4RequestFilterBuilder
	
	#region OmnoviaMp4RequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OmnoviaMp4RequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaMp4Request"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaMp4RequestParameterBuilder : ParameterizedSqlFilterBuilder<OmnoviaMp4RequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestParameterBuilder class.
		/// </summary>
		public OmnoviaMp4RequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaMp4RequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaMp4RequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaMp4RequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaMp4RequestParameterBuilder
} // end namespace
