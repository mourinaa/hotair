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
	/// This class is the base class for any <see cref="AccessTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccessTypeProviderBaseCore : EntityProviderBase<CONFDB.Entities.AccessType, CONFDB.Entities.AccessTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AccessTypeKey key)
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
		public override CONFDB.Entities.AccessType Get(TransactionManager transactionManager, CONFDB.Entities.AccessTypeKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AccessType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public abstract CONFDB.Entities.AccessType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByIdNameValue(System.Int32 _id, System.String _name, System.Int32 _value)
		{
			int count = -1;
			return GetByIdNameValue(null,_id, _name, _value, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByIdNameValue(System.Int32 _id, System.String _name, System.Int32 _value, int start, int pageLength)
		{
			int count = -1;
			return GetByIdNameValue(null, _id, _name, _value, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByIdNameValue(TransactionManager transactionManager, System.Int32 _id, System.String _name, System.Int32 _value)
		{
			int count = -1;
			return GetByIdNameValue(transactionManager, _id, _name, _value, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByIdNameValue(TransactionManager transactionManager, System.Int32 _id, System.String _name, System.Int32 _value, int start, int pageLength)
		{
			int count = -1;
			return GetByIdNameValue(transactionManager, _id, _name, _value, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByIdNameValue(System.Int32 _id, System.String _name, System.Int32 _value, int start, int pageLength, out int count)
		{
			return GetByIdNameValue(null, _id, _name, _value, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value_ID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="_name"></param>
		/// <param name="_value"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<AccessType> GetByIdNameValue(TransactionManager transactionManager, System.Int32 _id, System.String _name, System.Int32 _value, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_AccessType_Value index.
		/// </summary>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByValueName(System.Int32 _value, System.String _name)
		{
			int count = -1;
			return GetByValueName(null,_value, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value index.
		/// </summary>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByValueName(System.Int32 _value, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByValueName(null, _value, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByValueName(TransactionManager transactionManager, System.Int32 _value, System.String _name)
		{
			int count = -1;
			return GetByValueName(transactionManager, _value, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByValueName(TransactionManager transactionManager, System.Int32 _value, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByValueName(transactionManager, _value, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value index.
		/// </summary>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType> GetByValueName(System.Int32 _value, System.String _name, int start, int pageLength, out int count)
		{
			return GetByValueName(null, _value, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_Value index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_value"></param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<AccessType> GetByValueName(TransactionManager transactionManager, System.Int32 _value, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UX_AccessType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_AccessType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_AccessType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_AccessType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_AccessType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public CONFDB.Entities.AccessType GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_AccessType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType"/> class.</returns>
		public abstract CONFDB.Entities.AccessType GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AccessType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AccessType&gt;"/></returns>
		public static CONFDB.Entities.TList<AccessType> Fill(IDataReader reader, CONFDB.Entities.TList<AccessType> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AccessType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AccessType")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AccessTypeColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AccessTypeColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AccessType>(
					key.ToString(), // EntityTrackingKey
					"AccessType",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AccessType();
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
					c.Id = (System.Int32)reader[((int)AccessTypeColumn.Id - 1)];
					c.Name = (System.String)reader[((int)AccessTypeColumn.Name - 1)];
					c.DisplayName = (System.String)reader[((int)AccessTypeColumn.DisplayName - 1)];
					c.Description = (reader.IsDBNull(((int)AccessTypeColumn.Description - 1)))?null:(System.String)reader[((int)AccessTypeColumn.Description - 1)];
					c.Value = (System.Int32)reader[((int)AccessTypeColumn.Value - 1)];
					c.RetailLdApplicable = (System.Boolean)reader[((int)AccessTypeColumn.RetailLdApplicable - 1)];
					c.WholesaleLdApplicable = (System.Boolean)reader[((int)AccessTypeColumn.WholesaleLdApplicable - 1)];
					c.Billable = (System.Boolean)reader[((int)AccessTypeColumn.Billable - 1)];
					c.Enabled = (System.Boolean)reader[((int)AccessTypeColumn.Enabled - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AccessType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AccessType entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)AccessTypeColumn.Id - 1)];
			entity.Name = (System.String)reader[((int)AccessTypeColumn.Name - 1)];
			entity.DisplayName = (System.String)reader[((int)AccessTypeColumn.DisplayName - 1)];
			entity.Description = (reader.IsDBNull(((int)AccessTypeColumn.Description - 1)))?null:(System.String)reader[((int)AccessTypeColumn.Description - 1)];
			entity.Value = (System.Int32)reader[((int)AccessTypeColumn.Value - 1)];
			entity.RetailLdApplicable = (System.Boolean)reader[((int)AccessTypeColumn.RetailLdApplicable - 1)];
			entity.WholesaleLdApplicable = (System.Boolean)reader[((int)AccessTypeColumn.WholesaleLdApplicable - 1)];
			entity.Billable = (System.Boolean)reader[((int)AccessTypeColumn.Billable - 1)];
			entity.Enabled = (System.Boolean)reader[((int)AccessTypeColumn.Enabled - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AccessType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AccessType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.DisplayName = (System.String)dataRow["DisplayName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.Value = (System.Int32)dataRow["Value"];
			entity.RetailLdApplicable = (System.Boolean)dataRow["RetailLDApplicable"];
			entity.WholesaleLdApplicable = (System.Boolean)dataRow["WholesaleLDApplicable"];
			entity.Billable = (System.Boolean)dataRow["Billable"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AccessType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AccessType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Dnis>|DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DnisCollection = DataRepository.DnisProvider.GetByAccessTypeId(transactionManager, entity.Id);

				if (deep && entity.DnisCollection.Count > 0)
				{
					deepHandles.Add("DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Dnis>) DataRepository.DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.DnisCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AccessType_ProductRateCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AccessType_ProductRate>|AccessType_ProductRateCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccessType_ProductRateCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AccessType_ProductRateCollection = DataRepository.AccessType_ProductRateProvider.GetByAccessTypeId(transactionManager, entity.Id);

				if (deep && entity.AccessType_ProductRateCollection.Count > 0)
				{
					deepHandles.Add("AccessType_ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AccessType_ProductRate>) DataRepository.AccessType_ProductRateProvider.DeepLoad,
						new object[] { transactionManager, entity.AccessType_ProductRateCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RatedCdrCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RatedCdr>|RatedCdrCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RatedCdrCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RatedCdrCollection = DataRepository.RatedCdrProvider.GetByAccessTypeId(transactionManager, entity.Id);

				if (deep && entity.RatedCdrCollection.Count > 0)
				{
					deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RatedCdr>) DataRepository.RatedCdrProvider.DeepLoad,
						new object[] { transactionManager, entity.RatedCdrCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AccessType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AccessType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AccessType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AccessType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Dnis>
				if (CanDeepSave(entity.DnisCollection, "List<Dnis>|DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Dnis child in entity.DnisCollection)
					{
						if(child.AccessTypeIdSource != null)
						{
							child.AccessTypeId = child.AccessTypeIdSource.Id;
						}
						else
						{
							child.AccessTypeId = entity.Id;
						}

					}

					if (entity.DnisCollection.Count > 0 || entity.DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DnisProvider.Save(transactionManager, entity.DnisCollection);
						
						deepHandles.Add("DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Dnis >) DataRepository.DnisProvider.DeepSave,
							new object[] { transactionManager, entity.DnisCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AccessType_ProductRate>
				if (CanDeepSave(entity.AccessType_ProductRateCollection, "List<AccessType_ProductRate>|AccessType_ProductRateCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AccessType_ProductRate child in entity.AccessType_ProductRateCollection)
					{
						if(child.AccessTypeIdSource != null)
						{
							child.AccessTypeId = child.AccessTypeIdSource.Id;
						}
						else
						{
							child.AccessTypeId = entity.Id;
						}

					}

					if (entity.AccessType_ProductRateCollection.Count > 0 || entity.AccessType_ProductRateCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AccessType_ProductRateProvider.Save(transactionManager, entity.AccessType_ProductRateCollection);
						
						deepHandles.Add("AccessType_ProductRateCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AccessType_ProductRate >) DataRepository.AccessType_ProductRateProvider.DeepSave,
							new object[] { transactionManager, entity.AccessType_ProductRateCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<RatedCdr>
				if (CanDeepSave(entity.RatedCdrCollection, "List<RatedCdr>|RatedCdrCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RatedCdr child in entity.RatedCdrCollection)
					{
						if(child.AccessTypeIdSource != null)
						{
							child.AccessTypeId = child.AccessTypeIdSource.Id;
						}
						else
						{
							child.AccessTypeId = entity.Id;
						}

					}

					if (entity.RatedCdrCollection.Count > 0 || entity.RatedCdrCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RatedCdrProvider.Save(transactionManager, entity.RatedCdrCollection);
						
						deepHandles.Add("RatedCdrCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RatedCdr >) DataRepository.RatedCdrProvider.DeepSave,
							new object[] { transactionManager, entity.RatedCdrCollection, deepSaveType, childTypes, innerList }
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
	
	#region AccessTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AccessType</c>
	///</summary>
	public enum AccessTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AccessType</c> as OneToMany for DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Dnis>))]
		DnisCollection,

		///<summary>
		/// Collection of <c>AccessType</c> as OneToMany for AccessType_ProductRateCollection
		///</summary>
		[ChildEntityType(typeof(TList<AccessType_ProductRate>))]
		AccessType_ProductRateCollection,

		///<summary>
		/// Collection of <c>AccessType</c> as OneToMany for RatedCdrCollection
		///</summary>
		[ChildEntityType(typeof(TList<RatedCdr>))]
		RatedCdrCollection,
	}
	
	#endregion AccessTypeChildEntityTypes
	
	#region AccessTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AccessTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeFilterBuilder : SqlFilterBuilder<AccessTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilterBuilder class.
		/// </summary>
		public AccessTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessTypeFilterBuilder
	
	#region AccessTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AccessTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessTypeParameterBuilder : ParameterizedSqlFilterBuilder<AccessTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessTypeParameterBuilder class.
		/// </summary>
		public AccessTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessTypeParameterBuilder
} // end namespace
