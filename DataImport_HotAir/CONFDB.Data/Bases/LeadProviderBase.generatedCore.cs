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
	/// This class is the base class for any <see cref="LeadProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LeadProviderBaseCore : EntityProviderBase<CONFDB.Entities.Lead, CONFDB.Entities.LeadKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.LeadKey key)
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
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		FK_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		FK_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Lead> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		FK_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		fk_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		fk_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_Wholesaler key.
		///		FK_Lead_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public abstract CONFDB.Entities.TList<Lead> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		FK_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="_salesPersonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetBySalesPersonId(System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(_salesPersonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		FK_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Lead> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		FK_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		fk_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		fk_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public CONFDB.Entities.TList<Lead> GetBySalesPersonId(System.Int32 _salesPersonId, int start, int pageLength,out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Lead_SalesPerson key.
		///		FK_Lead_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Lead objects.</returns>
		public abstract CONFDB.Entities.TList<Lead> GetBySalesPersonId(TransactionManager transactionManager, System.Int32 _salesPersonId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Lead Get(TransactionManager transactionManager, CONFDB.Entities.LeadKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Lead_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public CONFDB.Entities.Lead GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Lead_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public CONFDB.Entities.Lead GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Lead_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public CONFDB.Entities.Lead GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Lead_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public CONFDB.Entities.Lead GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Lead_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public CONFDB.Entities.Lead GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Lead_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Lead"/> class.</returns>
		public abstract CONFDB.Entities.Lead GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Statistic_ContactEmail index.
		/// </summary>
		/// <param name="_contactEmail"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Lead> GetByContactEmail(System.String _contactEmail)
		{
			int count = -1;
			return GetByContactEmail(null,_contactEmail, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Statistic_ContactEmail index.
		/// </summary>
		/// <param name="_contactEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Lead> GetByContactEmail(System.String _contactEmail, int start, int pageLength)
		{
			int count = -1;
			return GetByContactEmail(null, _contactEmail, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Statistic_ContactEmail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactEmail"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Lead> GetByContactEmail(TransactionManager transactionManager, System.String _contactEmail)
		{
			int count = -1;
			return GetByContactEmail(transactionManager, _contactEmail, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Statistic_ContactEmail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Lead> GetByContactEmail(TransactionManager transactionManager, System.String _contactEmail, int start, int pageLength)
		{
			int count = -1;
			return GetByContactEmail(transactionManager, _contactEmail, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Statistic_ContactEmail index.
		/// </summary>
		/// <param name="_contactEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Lead> GetByContactEmail(System.String _contactEmail, int start, int pageLength, out int count)
		{
			return GetByContactEmail(null, _contactEmail, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Statistic_ContactEmail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Lead> GetByContactEmail(TransactionManager transactionManager, System.String _contactEmail, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Lead&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Lead&gt;"/></returns>
		public static CONFDB.Entities.TList<Lead> Fill(IDataReader reader, CONFDB.Entities.TList<Lead> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Lead c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Lead")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.LeadColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.LeadColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Lead>(
					key.ToString(), // EntityTrackingKey
					"Lead",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Lead();
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
					c.Id = (System.Int32)reader[((int)LeadColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.WholesalerId = (System.String)reader[((int)LeadColumn.WholesalerId - 1)];
					c.CompanyName = (System.String)reader[((int)LeadColumn.CompanyName - 1)];
					c.SalesPersonId = (System.Int32)reader[((int)LeadColumn.SalesPersonId - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)LeadColumn.CreatedDate - 1)];
					c.AssignedDate = (System.DateTime)reader[((int)LeadColumn.AssignedDate - 1)];
					c.ExpiryDate = (System.DateTime)reader[((int)LeadColumn.ExpiryDate - 1)];
					c.ContactName = (reader.IsDBNull(((int)LeadColumn.ContactName - 1)))?null:(System.String)reader[((int)LeadColumn.ContactName - 1)];
					c.ContactNumber = (reader.IsDBNull(((int)LeadColumn.ContactNumber - 1)))?null:(System.String)reader[((int)LeadColumn.ContactNumber - 1)];
					c.ContactEmail = (reader.IsDBNull(((int)LeadColumn.ContactEmail - 1)))?null:(System.String)reader[((int)LeadColumn.ContactEmail - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Lead"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Lead"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Lead entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)LeadColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.WholesalerId = (System.String)reader[((int)LeadColumn.WholesalerId - 1)];
			entity.CompanyName = (System.String)reader[((int)LeadColumn.CompanyName - 1)];
			entity.SalesPersonId = (System.Int32)reader[((int)LeadColumn.SalesPersonId - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)LeadColumn.CreatedDate - 1)];
			entity.AssignedDate = (System.DateTime)reader[((int)LeadColumn.AssignedDate - 1)];
			entity.ExpiryDate = (System.DateTime)reader[((int)LeadColumn.ExpiryDate - 1)];
			entity.ContactName = (reader.IsDBNull(((int)LeadColumn.ContactName - 1)))?null:(System.String)reader[((int)LeadColumn.ContactName - 1)];
			entity.ContactNumber = (reader.IsDBNull(((int)LeadColumn.ContactNumber - 1)))?null:(System.String)reader[((int)LeadColumn.ContactNumber - 1)];
			entity.ContactEmail = (reader.IsDBNull(((int)LeadColumn.ContactEmail - 1)))?null:(System.String)reader[((int)LeadColumn.ContactEmail - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Lead"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Lead"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Lead entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CompanyName = (System.String)dataRow["CompanyName"];
			entity.SalesPersonId = (System.Int32)dataRow["SalesPersonID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.AssignedDate = (System.DateTime)dataRow["AssignedDate"];
			entity.ExpiryDate = (System.DateTime)dataRow["ExpiryDate"];
			entity.ContactName = Convert.IsDBNull(dataRow["ContactName"]) ? null : (System.String)dataRow["ContactName"];
			entity.ContactNumber = Convert.IsDBNull(dataRow["ContactNumber"]) ? null : (System.String)dataRow["ContactNumber"];
			entity.ContactEmail = Convert.IsDBNull(dataRow["ContactEmail"]) ? null : (System.String)dataRow["ContactEmail"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Lead"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Lead Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Lead entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region WholesalerIdSource	
			if (CanDeepLoad(entity, "Wholesaler|WholesalerIdSource", deepLoadType, innerList) 
				&& entity.WholesalerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.WholesalerId;
				Wholesaler tmpEntity = EntityManager.LocateEntity<Wholesaler>(EntityLocator.ConstructKeyFromPkItems(typeof(Wholesaler), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WholesalerIdSource = tmpEntity;
				else
					entity.WholesalerIdSource = DataRepository.WholesalerProvider.GetById(transactionManager, entity.WholesalerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WholesalerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WholesalerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.WholesalerProvider.DeepLoad(transactionManager, entity.WholesalerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WholesalerIdSource

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalesPersonId;
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetById(transactionManager, entity.SalesPersonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Lead object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Lead instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Lead Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Lead entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region WholesalerIdSource
			if (CanDeepSave(entity, "Wholesaler|WholesalerIdSource", deepSaveType, innerList) 
				&& entity.WholesalerIdSource != null)
			{
				DataRepository.WholesalerProvider.Save(transactionManager, entity.WholesalerIdSource);
				entity.WholesalerId = entity.WholesalerIdSource.Id;
			}
			#endregion 
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.Id;
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
	
	#region LeadChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Lead</c>
	///</summary>
	public enum LeadChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
		}
	
	#endregion LeadChildEntityTypes
	
	#region LeadFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LeadColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadFilterBuilder : SqlFilterBuilder<LeadColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadFilterBuilder class.
		/// </summary>
		public LeadFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadFilterBuilder
	
	#region LeadParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LeadColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lead"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadParameterBuilder : ParameterizedSqlFilterBuilder<LeadColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadParameterBuilder class.
		/// </summary>
		public LeadParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadParameterBuilder
} // end namespace
