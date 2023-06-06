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
	/// This class is the base class for any <see cref="InvoiceNotesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InvoiceNotesProviderBaseCore : EntityProviderBase<CONFDB.Entities.InvoiceNotes, CONFDB.Entities.InvoiceNotesKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.InvoiceNotesKey key)
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
		public override CONFDB.Entities.InvoiceNotes Get(TransactionManager transactionManager, CONFDB.Entities.InvoiceNotesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public CONFDB.Entities.InvoiceNotes GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public CONFDB.Entities.InvoiceNotes GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public CONFDB.Entities.InvoiceNotes GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public CONFDB.Entities.InvoiceNotes GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public CONFDB.Entities.InvoiceNotes GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the MonthlyInvoiceNotes_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.InvoiceNotes"/> class.</returns>
		public abstract CONFDB.Entities.InvoiceNotes GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(System.DateTime _startDate)
		{
			int count = -1;
			return GetByStartDate(null,_startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByStartDate(null, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate)
		{
			int count = -1;
			return GetByStartDate(transactionManager, _startDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate, int start, int pageLength)
		{
			int count = -1;
			return GetByStartDate(transactionManager, _startDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(System.DateTime _startDate, int start, int pageLength, out int count)
		{
			return GetByStartDate(null, _startDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodStart index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_startDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceNotes> GetByStartDate(TransactionManager transactionManager, System.DateTime _startDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(System.DateTime? _endDate)
		{
			int count = -1;
			return GetByEndDate(null,_endDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(System.DateTime? _endDate, int start, int pageLength)
		{
			int count = -1;
			return GetByEndDate(null, _endDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(TransactionManager transactionManager, System.DateTime? _endDate)
		{
			int count = -1;
			return GetByEndDate(transactionManager, _endDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(TransactionManager transactionManager, System.DateTime? _endDate, int start, int pageLength)
		{
			int count = -1;
			return GetByEndDate(transactionManager, _endDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(System.DateTime? _endDate, int start, int pageLength, out int count)
		{
			return GetByEndDate(null, _endDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_PeriodEnd index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_endDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceNotes> GetByEndDate(TransactionManager transactionManager, System.DateTime? _endDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(null,_wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength, out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_MonthlyInvoiceNotes_WholesalerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<InvoiceNotes> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;InvoiceNotes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;InvoiceNotes&gt;"/></returns>
		public static CONFDB.Entities.TList<InvoiceNotes> Fill(IDataReader reader, CONFDB.Entities.TList<InvoiceNotes> rows, int start, int pageLength)
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
				
				CONFDB.Entities.InvoiceNotes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("InvoiceNotes")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.InvoiceNotesColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.InvoiceNotesColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<InvoiceNotes>(
					key.ToString(), // EntityTrackingKey
					"InvoiceNotes",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.InvoiceNotes();
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
					c.Id = (System.Int32)reader[((int)InvoiceNotesColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)InvoiceNotesColumn.WholesalerId - 1)];
					c.StartDate = (System.DateTime)reader[((int)InvoiceNotesColumn.StartDate - 1)];
					c.EndDate = (reader.IsDBNull(((int)InvoiceNotesColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)InvoiceNotesColumn.EndDate - 1)];
					c.Note = (reader.IsDBNull(((int)InvoiceNotesColumn.Note - 1)))?null:(System.String)reader[((int)InvoiceNotesColumn.Note - 1)];
					c.Enabled = (reader.IsDBNull(((int)InvoiceNotesColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)InvoiceNotesColumn.Enabled - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)InvoiceNotesColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)InvoiceNotesColumn.ModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.InvoiceNotes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceNotes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.InvoiceNotes entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)InvoiceNotesColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)InvoiceNotesColumn.WholesalerId - 1)];
			entity.StartDate = (System.DateTime)reader[((int)InvoiceNotesColumn.StartDate - 1)];
			entity.EndDate = (reader.IsDBNull(((int)InvoiceNotesColumn.EndDate - 1)))?null:(System.DateTime?)reader[((int)InvoiceNotesColumn.EndDate - 1)];
			entity.Note = (reader.IsDBNull(((int)InvoiceNotesColumn.Note - 1)))?null:(System.String)reader[((int)InvoiceNotesColumn.Note - 1)];
			entity.Enabled = (reader.IsDBNull(((int)InvoiceNotesColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)InvoiceNotesColumn.Enabled - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)InvoiceNotesColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)InvoiceNotesColumn.ModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.InvoiceNotes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceNotes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.InvoiceNotes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.EndDate = Convert.IsDBNull(dataRow["EndDate"]) ? null : (System.DateTime?)dataRow["EndDate"];
			entity.Note = Convert.IsDBNull(dataRow["Note"]) ? null : (System.String)dataRow["Note"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.InvoiceNotes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.InvoiceNotes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.InvoiceNotes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.InvoiceNotes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.InvoiceNotes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.InvoiceNotes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.InvoiceNotes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region InvoiceNotesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.InvoiceNotes</c>
	///</summary>
	public enum InvoiceNotesChildEntityTypes
	{
	}
	
	#endregion InvoiceNotesChildEntityTypes
	
	#region InvoiceNotesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InvoiceNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesFilterBuilder : SqlFilterBuilder<InvoiceNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilterBuilder class.
		/// </summary>
		public InvoiceNotesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceNotesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceNotesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceNotesFilterBuilder
	
	#region InvoiceNotesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InvoiceNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceNotesParameterBuilder : ParameterizedSqlFilterBuilder<InvoiceNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesParameterBuilder class.
		/// </summary>
		public InvoiceNotesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceNotesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceNotesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceNotesParameterBuilder
} // end namespace
