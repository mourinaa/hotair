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
	/// This class is the base class for any <see cref="CustomerTransactionImportProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerTransactionImportProviderBaseCore : EntityProviderBase<CONFDB.Entities.CustomerTransactionImport, CONFDB.Entities.CustomerTransactionImportKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionImportKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _id)
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
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _id);		
		
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
		public override CONFDB.Entities.CustomerTransactionImport Get(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionImportKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionImport GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionImport GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionImport GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionImport GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionImport GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionImport_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionImport"/> class.</returns>
		public abstract CONFDB.Entities.CustomerTransactionImport GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_CustomerTransactionImport_PostCustomerTransactionCharges 
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransactionImport_PostCustomerTransactionCharges' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="customerTransactionImportId"> A <c>System.Int64?</c> instance.</param>
		/// <param name="customerTransactionTypeId2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PostCustomerTransactionCharges(System.String userName, System.Int64? customerTransactionImportId, System.Int32? customerTransactionTypeId2, System.DateTime? startDate, System.DateTime? endDate)
		{
			 PostCustomerTransactionCharges(null, 0, int.MaxValue , userName, customerTransactionImportId, customerTransactionTypeId2, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransactionImport_PostCustomerTransactionCharges' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="customerTransactionImportId"> A <c>System.Int64?</c> instance.</param>
		/// <param name="customerTransactionTypeId2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PostCustomerTransactionCharges(int start, int pageLength, System.String userName, System.Int64? customerTransactionImportId, System.Int32? customerTransactionTypeId2, System.DateTime? startDate, System.DateTime? endDate)
		{
			 PostCustomerTransactionCharges(null, start, pageLength , userName, customerTransactionImportId, customerTransactionTypeId2, startDate, endDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_CustomerTransactionImport_PostCustomerTransactionCharges' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="customerTransactionImportId"> A <c>System.Int64?</c> instance.</param>
		/// <param name="customerTransactionTypeId2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PostCustomerTransactionCharges(TransactionManager transactionManager, System.String userName, System.Int64? customerTransactionImportId, System.Int32? customerTransactionTypeId2, System.DateTime? startDate, System.DateTime? endDate)
		{
			 PostCustomerTransactionCharges(transactionManager, 0, int.MaxValue , userName, customerTransactionImportId, customerTransactionTypeId2, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_CustomerTransactionImport_PostCustomerTransactionCharges' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="customerTransactionImportId"> A <c>System.Int64?</c> instance.</param>
		/// <param name="customerTransactionTypeId2"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void PostCustomerTransactionCharges(TransactionManager transactionManager, int start, int pageLength , System.String userName, System.Int64? customerTransactionImportId, System.Int32? customerTransactionTypeId2, System.DateTime? startDate, System.DateTime? endDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CustomerTransactionImport&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CustomerTransactionImport&gt;"/></returns>
		public static CONFDB.Entities.TList<CustomerTransactionImport> Fill(IDataReader reader, CONFDB.Entities.TList<CustomerTransactionImport> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CustomerTransactionImport c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerTransactionImport")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerTransactionImportColumn.Id - 1))?(long)0:(System.Int64)reader[((int)CONFDB.Entities.CustomerTransactionImportColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CustomerTransactionImport>(
					key.ToString(), // EntityTrackingKey
					"CustomerTransactionImport",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CustomerTransactionImport();
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
					c.Id = (System.Int64)reader[((int)CustomerTransactionImportColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)CustomerTransactionImportColumn.WholesalerId - 1)];
					c.CustomerId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.CustomerId - 1)];
					c.ModeratorId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ModeratorId - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.PriCustomerNumber - 1)];
					c.SecCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.SecCustomerNumber - 1)];
					c.TransactionDate = (System.DateTime)reader[((int)CustomerTransactionImportColumn.TransactionDate - 1)];
					c.TransactionAmount = (System.Decimal)reader[((int)CustomerTransactionImportColumn.TransactionAmount - 1)];
					c.TransactionDescription = (reader.IsDBNull(((int)CustomerTransactionImportColumn.TransactionDescription - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.TransactionDescription - 1)];
					c.CustomerTransactionTypeId = (System.Int32)reader[((int)CustomerTransactionImportColumn.CustomerTransactionTypeId - 1)];
					c.Wholesaler_ProductId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.Wholesaler_ProductId - 1)];
					c.ProductRateId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ProductRateId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ProductRateId - 1)];
					c.Quantity = (reader.IsDBNull(((int)CustomerTransactionImportColumn.Quantity - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.Quantity - 1)];
					c.SellRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.SellRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.SellRate - 1)];
					c.BuyRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.BuyRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.BuyRate - 1)];
					c.WsTransactionAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.WsTransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.WsTransactionAmount - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ModifiedBy - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionImportColumn.CreatedDate - 1)];
					c.PostedToCustTrans = (System.Boolean)reader[((int)CustomerTransactionImportColumn.PostedToCustTrans - 1)];
					c.PostedToCustTransDate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.PostedToCustTransDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionImportColumn.PostedToCustTransDate - 1)];
					c.ImportType = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ImportType - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ImportType - 1)];
					c.ErrorCodesId = (System.Int32)reader[((int)CustomerTransactionImportColumn.ErrorCodesId - 1)];
					c.ReferenceNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ReferenceNumber - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.UniqueConferenceId - 1)];
					c.LocalTaxRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.LocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.LocalTaxRate - 1)];
					c.FederalTaxRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.FederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.FederalTaxRate - 1)];
					c.LocalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.LocalTaxAmount - 1)];
					c.FederalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.FederalTaxAmount - 1)];
					c.ElapsedTimeSeconds = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ElapsedTimeSeconds - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ElapsedTimeSeconds - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransactionImport"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionImport"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CustomerTransactionImport entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)CustomerTransactionImportColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)CustomerTransactionImportColumn.WholesalerId - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.CustomerId - 1)];
			entity.ModeratorId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ModeratorId - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.PriCustomerNumber - 1)];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.SecCustomerNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.SecCustomerNumber - 1)];
			entity.TransactionDate = (System.DateTime)reader[((int)CustomerTransactionImportColumn.TransactionDate - 1)];
			entity.TransactionAmount = (System.Decimal)reader[((int)CustomerTransactionImportColumn.TransactionAmount - 1)];
			entity.TransactionDescription = (reader.IsDBNull(((int)CustomerTransactionImportColumn.TransactionDescription - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.TransactionDescription - 1)];
			entity.CustomerTransactionTypeId = (System.Int32)reader[((int)CustomerTransactionImportColumn.CustomerTransactionTypeId - 1)];
			entity.Wholesaler_ProductId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.Wholesaler_ProductId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.Wholesaler_ProductId - 1)];
			entity.ProductRateId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ProductRateId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ProductRateId - 1)];
			entity.Quantity = (reader.IsDBNull(((int)CustomerTransactionImportColumn.Quantity - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.Quantity - 1)];
			entity.SellRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.SellRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.SellRate - 1)];
			entity.BuyRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.BuyRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.BuyRate - 1)];
			entity.WsTransactionAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.WsTransactionAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.WsTransactionAmount - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ModifiedBy - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionImportColumn.CreatedDate - 1)];
			entity.PostedToCustTrans = (System.Boolean)reader[((int)CustomerTransactionImportColumn.PostedToCustTrans - 1)];
			entity.PostedToCustTransDate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.PostedToCustTransDate - 1)))?null:(System.DateTime?)reader[((int)CustomerTransactionImportColumn.PostedToCustTransDate - 1)];
			entity.ImportType = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ImportType - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ImportType - 1)];
			entity.ErrorCodesId = (System.Int32)reader[((int)CustomerTransactionImportColumn.ErrorCodesId - 1)];
			entity.ReferenceNumber = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ReferenceNumber - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.ReferenceNumber - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)CustomerTransactionImportColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)CustomerTransactionImportColumn.UniqueConferenceId - 1)];
			entity.LocalTaxRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.LocalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.LocalTaxRate - 1)];
			entity.FederalTaxRate = (reader.IsDBNull(((int)CustomerTransactionImportColumn.FederalTaxRate - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.FederalTaxRate - 1)];
			entity.LocalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.LocalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.LocalTaxAmount - 1)];
			entity.FederalTaxAmount = (reader.IsDBNull(((int)CustomerTransactionImportColumn.FederalTaxAmount - 1)))?null:(System.Decimal?)reader[((int)CustomerTransactionImportColumn.FederalTaxAmount - 1)];
			entity.ElapsedTimeSeconds = (reader.IsDBNull(((int)CustomerTransactionImportColumn.ElapsedTimeSeconds - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionImportColumn.ElapsedTimeSeconds - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransactionImport"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionImport"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CustomerTransactionImport entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.ModeratorId = Convert.IsDBNull(dataRow["ModeratorID"]) ? null : (System.Int32?)dataRow["ModeratorID"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = Convert.IsDBNull(dataRow["SecCustomerNumber"]) ? null : (System.String)dataRow["SecCustomerNumber"];
			entity.TransactionDate = (System.DateTime)dataRow["TransactionDate"];
			entity.TransactionAmount = (System.Decimal)dataRow["TransactionAmount"];
			entity.TransactionDescription = Convert.IsDBNull(dataRow["TransactionDescription"]) ? null : (System.String)dataRow["TransactionDescription"];
			entity.CustomerTransactionTypeId = (System.Int32)dataRow["CustomerTransactionTypeID"];
			entity.Wholesaler_ProductId = Convert.IsDBNull(dataRow["Wholesaler_ProductID"]) ? null : (System.Int32?)dataRow["Wholesaler_ProductID"];
			entity.ProductRateId = Convert.IsDBNull(dataRow["ProductRateID"]) ? null : (System.Int32?)dataRow["ProductRateID"];
			entity.Quantity = Convert.IsDBNull(dataRow["Quantity"]) ? null : (System.Int32?)dataRow["Quantity"];
			entity.SellRate = Convert.IsDBNull(dataRow["SellRate"]) ? null : (System.Decimal?)dataRow["SellRate"];
			entity.BuyRate = Convert.IsDBNull(dataRow["BuyRate"]) ? null : (System.Decimal?)dataRow["BuyRate"];
			entity.WsTransactionAmount = Convert.IsDBNull(dataRow["WSTransactionAmount"]) ? null : (System.Decimal?)dataRow["WSTransactionAmount"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.PostedToCustTrans = (System.Boolean)dataRow["PostedToCustTrans"];
			entity.PostedToCustTransDate = Convert.IsDBNull(dataRow["PostedToCustTransDate"]) ? null : (System.DateTime?)dataRow["PostedToCustTransDate"];
			entity.ImportType = Convert.IsDBNull(dataRow["ImportType"]) ? null : (System.String)dataRow["ImportType"];
			entity.ErrorCodesId = (System.Int32)dataRow["ErrorCodesID"];
			entity.ReferenceNumber = Convert.IsDBNull(dataRow["ReferenceNumber"]) ? null : (System.String)dataRow["ReferenceNumber"];
			entity.UniqueConferenceId = Convert.IsDBNull(dataRow["UniqueConferenceID"]) ? null : (System.String)dataRow["UniqueConferenceID"];
			entity.LocalTaxRate = Convert.IsDBNull(dataRow["LocalTaxRate"]) ? null : (System.Decimal?)dataRow["LocalTaxRate"];
			entity.FederalTaxRate = Convert.IsDBNull(dataRow["FederalTaxRate"]) ? null : (System.Decimal?)dataRow["FederalTaxRate"];
			entity.LocalTaxAmount = Convert.IsDBNull(dataRow["LocalTaxAmount"]) ? null : (System.Decimal?)dataRow["LocalTaxAmount"];
			entity.FederalTaxAmount = Convert.IsDBNull(dataRow["FederalTaxAmount"]) ? null : (System.Decimal?)dataRow["FederalTaxAmount"];
			entity.ElapsedTimeSeconds = Convert.IsDBNull(dataRow["ElapsedTimeSeconds"]) ? null : (System.Int32?)dataRow["ElapsedTimeSeconds"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionImport"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransactionImport Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionImport entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CustomerTransactionImport object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CustomerTransactionImport instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransactionImport Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionImport entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CustomerTransactionImportChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CustomerTransactionImport</c>
	///</summary>
	public enum CustomerTransactionImportChildEntityTypes
	{
	}
	
	#endregion CustomerTransactionImportChildEntityTypes
	
	#region CustomerTransactionImportFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerTransactionImportColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportFilterBuilder : SqlFilterBuilder<CustomerTransactionImportColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilterBuilder class.
		/// </summary>
		public CustomerTransactionImportFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionImportFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionImportFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionImportFilterBuilder
	
	#region CustomerTransactionImportParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerTransactionImportColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionImport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionImportParameterBuilder : ParameterizedSqlFilterBuilder<CustomerTransactionImportColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportParameterBuilder class.
		/// </summary>
		public CustomerTransactionImportParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionImportParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionImportParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionImportParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionImportParameterBuilder
} // end namespace
