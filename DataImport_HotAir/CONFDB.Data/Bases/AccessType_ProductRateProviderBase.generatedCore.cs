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
	/// This class is the base class for any <see cref="AccessType_ProductRateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccessType_ProductRateProviderBaseCore : EntityProviderBase<CONFDB.Entities.AccessType_ProductRate, CONFDB.Entities.AccessType_ProductRateKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.AccessType_ProductRateKey key)
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
	
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		AccessType_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(System.Int32 _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(_accessTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		AccessType_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		AccessType_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		accessType_AccessType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(System.Int32 _accessTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		accessType_AccessType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(System.Int32 _accessTypeId, int start, int pageLength,out int count)
		{
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_AccessType_ProductRate_FK1 key.
		///		AccessType_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeId(TransactionManager transactionManager, System.Int32 _accessTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		ProductRate_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="_productRateId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(System.Int32 _productRateId)
		{
			int count = -1;
			return GetByProductRateId(_productRateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		ProductRate_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		ProductRate_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductRateId(transactionManager, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		productRate_AccessType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(System.Int32 _productRateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductRateId(null, _productRateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		productRate_AccessType_ProductRate_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productRateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(System.Int32 _productRateId, int start, int pageLength,out int count)
		{
			return GetByProductRateId(null, _productRateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductRate_AccessType_ProductRate_FK1 key.
		///		ProductRate_AccessType_ProductRate_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.AccessType_ProductRate objects.</returns>
		public abstract CONFDB.Entities.TList<AccessType_ProductRate> GetByProductRateId(TransactionManager transactionManager, System.Int32 _productRateId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.AccessType_ProductRate Get(TransactionManager transactionManager, CONFDB.Entities.AccessType_ProductRateKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public CONFDB.Entities.AccessType_ProductRate GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public CONFDB.Entities.AccessType_ProductRate GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public CONFDB.Entities.AccessType_ProductRate GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public CONFDB.Entities.AccessType_ProductRate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public CONFDB.Entities.AccessType_ProductRate GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.AccessType_ProductRate"/> class.</returns>
		public abstract CONFDB.Entities.AccessType_ProductRate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(System.Int32 _accessTypeId, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByAccessTypeIdProductRateId(null,_accessTypeId, _productRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(System.Int32 _accessTypeId, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeIdProductRateId(null, _accessTypeId, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _productRateId)
		{
			int count = -1;
			return GetByAccessTypeIdProductRateId(transactionManager, _accessTypeId, _productRateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _productRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeIdProductRateId(transactionManager, _accessTypeId, _productRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(System.Int32 _accessTypeId, System.Int32 _productRateId, int start, int pageLength, out int count)
		{
			return GetByAccessTypeIdProductRateId(null, _accessTypeId, _productRateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_AccessType_ProductRate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="_productRateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<AccessType_ProductRate> GetByAccessTypeIdProductRateId(TransactionManager transactionManager, System.Int32 _accessTypeId, System.Int32 _productRateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;AccessType_ProductRate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;AccessType_ProductRate&gt;"/></returns>
		public static CONFDB.Entities.TList<AccessType_ProductRate> Fill(IDataReader reader, CONFDB.Entities.TList<AccessType_ProductRate> rows, int start, int pageLength)
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
				
				CONFDB.Entities.AccessType_ProductRate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AccessType_ProductRate")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.AccessType_ProductRateColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.AccessType_ProductRateColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<AccessType_ProductRate>(
					key.ToString(), // EntityTrackingKey
					"AccessType_ProductRate",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.AccessType_ProductRate();
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
					c.Id = (System.Int32)reader[((int)AccessType_ProductRateColumn.Id - 1)];
					c.AccessTypeId = (System.Int32)reader[((int)AccessType_ProductRateColumn.AccessTypeId - 1)];
					c.ProductRateId = (System.Int32)reader[((int)AccessType_ProductRateColumn.ProductRateId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AccessType_ProductRate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType_ProductRate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.AccessType_ProductRate entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)AccessType_ProductRateColumn.Id - 1)];
			entity.AccessTypeId = (System.Int32)reader[((int)AccessType_ProductRateColumn.AccessTypeId - 1)];
			entity.ProductRateId = (System.Int32)reader[((int)AccessType_ProductRateColumn.ProductRateId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.AccessType_ProductRate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType_ProductRate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.AccessType_ProductRate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.AccessTypeId = (System.Int32)dataRow["AccessTypeID"];
			entity.ProductRateId = (System.Int32)dataRow["ProductRateID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.AccessType_ProductRate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.AccessType_ProductRate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.AccessType_ProductRate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AccessTypeIdSource	
			if (CanDeepLoad(entity, "AccessType|AccessTypeIdSource", deepLoadType, innerList) 
				&& entity.AccessTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AccessTypeId;
				AccessType tmpEntity = EntityManager.LocateEntity<AccessType>(EntityLocator.ConstructKeyFromPkItems(typeof(AccessType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccessTypeIdSource = tmpEntity;
				else
					entity.AccessTypeIdSource = DataRepository.AccessTypeProvider.GetById(transactionManager, entity.AccessTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccessTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AccessTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AccessTypeProvider.DeepLoad(transactionManager, entity.AccessTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AccessTypeIdSource

			#region ProductRateIdSource	
			if (CanDeepLoad(entity, "ProductRate|ProductRateIdSource", deepLoadType, innerList) 
				&& entity.ProductRateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductRateId;
				ProductRate tmpEntity = EntityManager.LocateEntity<ProductRate>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductRate), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductRateIdSource = tmpEntity;
				else
					entity.ProductRateIdSource = DataRepository.ProductRateProvider.GetById(transactionManager, entity.ProductRateId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductRateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductRateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductRateProvider.DeepLoad(transactionManager, entity.ProductRateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductRateIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.AccessType_ProductRate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.AccessType_ProductRate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.AccessType_ProductRate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.AccessType_ProductRate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AccessTypeIdSource
			if (CanDeepSave(entity, "AccessType|AccessTypeIdSource", deepSaveType, innerList) 
				&& entity.AccessTypeIdSource != null)
			{
				DataRepository.AccessTypeProvider.Save(transactionManager, entity.AccessTypeIdSource);
				entity.AccessTypeId = entity.AccessTypeIdSource.Id;
			}
			#endregion 
			
			#region ProductRateIdSource
			if (CanDeepSave(entity, "ProductRate|ProductRateIdSource", deepSaveType, innerList) 
				&& entity.ProductRateIdSource != null)
			{
				DataRepository.ProductRateProvider.Save(transactionManager, entity.ProductRateIdSource);
				entity.ProductRateId = entity.ProductRateIdSource.Id;
			}
			#endregion 
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
	
	#region AccessType_ProductRateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.AccessType_ProductRate</c>
	///</summary>
	public enum AccessType_ProductRateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AccessType</c> at AccessTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AccessType))]
		AccessType,
			
		///<summary>
		/// Composite Property for <c>ProductRate</c> at ProductRateIdSource
		///</summary>
		[ChildEntityType(typeof(ProductRate))]
		ProductRate,
		}
	
	#endregion AccessType_ProductRateChildEntityTypes
	
	#region AccessType_ProductRateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AccessType_ProductRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateFilterBuilder : SqlFilterBuilder<AccessType_ProductRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilterBuilder class.
		/// </summary>
		public AccessType_ProductRateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessType_ProductRateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessType_ProductRateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessType_ProductRateFilterBuilder
	
	#region AccessType_ProductRateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AccessType_ProductRateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccessType_ProductRate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccessType_ProductRateParameterBuilder : ParameterizedSqlFilterBuilder<AccessType_ProductRateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateParameterBuilder class.
		/// </summary>
		public AccessType_ProductRateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccessType_ProductRateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccessType_ProductRateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccessType_ProductRateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccessType_ProductRateParameterBuilder
} // end namespace
