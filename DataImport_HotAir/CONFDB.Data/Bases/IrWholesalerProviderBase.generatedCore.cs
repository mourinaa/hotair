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
	/// This class is the base class for any <see cref="IrWholesalerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IrWholesalerProviderBaseCore : EntityProviderBase<CONFDB.Entities.IrWholesaler, CONFDB.Entities.IrWholesalerKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.IrWholesalerKey key)
		{
			return Delete(transactionManager, key.WholesalerId, key.LanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <param name="_languageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _wholesalerId, System.String _languageId)
		{
			return Delete(null, _wholesalerId, _languageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId">. Primary Key.</param>
		/// <param name="_languageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _wholesalerId, System.String _languageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		Wholesaler_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		Wholesaler_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		Wholesaler_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		wholesaler_IrWholesaler_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		wholesaler_IrWholesaler_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_IRWholesaler_FK key.
		///		Wholesaler_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<IrWholesaler> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		Language_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		Language_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(TransactionManager transactionManager, System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		Language_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		language_IrWholesaler_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(System.String _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		language_IrWholesaler_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(System.String _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_IRWholesaler_FK key.
		///		Language_IRWholesaler_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.IrWholesaler objects.</returns>
		public abstract CONFDB.Entities.TList<IrWholesaler> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.IrWholesaler Get(TransactionManager transactionManager, CONFDB.Entities.IrWholesalerKey key, int start, int pageLength)
		{
			return GetByWholesalerIdLanguageId(transactionManager, key.WholesalerId, key.LanguageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IRWholesaler_PK index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(System.String _wholesalerId, System.String _languageId)
		{
			int count = -1;
			return GetByWholesalerIdLanguageId(null,_wholesalerId, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IRWholesaler_PK index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(System.String _wholesalerId, System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdLanguageId(null, _wholesalerId, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IRWholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(TransactionManager transactionManager, System.String _wholesalerId, System.String _languageId)
		{
			int count = -1;
			return GetByWholesalerIdLanguageId(transactionManager, _wholesalerId, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IRWholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(TransactionManager transactionManager, System.String _wholesalerId, System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdLanguageId(transactionManager, _wholesalerId, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IRWholesaler_PK index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(System.String _wholesalerId, System.String _languageId, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdLanguageId(null, _wholesalerId, _languageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IRWholesaler_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.IrWholesaler"/> class.</returns>
		public abstract CONFDB.Entities.IrWholesaler GetByWholesalerIdLanguageId(TransactionManager transactionManager, System.String _wholesalerId, System.String _languageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;IrWholesaler&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;IrWholesaler&gt;"/></returns>
		public static CONFDB.Entities.TList<IrWholesaler> Fill(IDataReader reader, CONFDB.Entities.TList<IrWholesaler> rows, int start, int pageLength)
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
				
				CONFDB.Entities.IrWholesaler c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("IrWholesaler")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.IrWholesalerColumn.WholesalerId - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.IrWholesalerColumn.WholesalerId - 1)]).ToString())
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.IrWholesalerColumn.LanguageId - 1))?string.Empty:(System.String)reader[((int)CONFDB.Entities.IrWholesalerColumn.LanguageId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<IrWholesaler>(
					key.ToString(), // EntityTrackingKey
					"IrWholesaler",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.IrWholesaler();
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
					c.WholesalerId = (System.String)reader[((int)IrWholesalerColumn.WholesalerId - 1)];
					c.OriginalWholesalerId = c.WholesalerId;
					c.LanguageId = (System.String)reader[((int)IrWholesalerColumn.LanguageId - 1)];
					c.OriginalLanguageId = c.LanguageId;
					c.IrCustomerId = (System.String)reader[((int)IrWholesalerColumn.IrCustomerId - 1)];
					c.LocalDnis = (reader.IsDBNull(((int)IrWholesalerColumn.LocalDnis - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.LocalDnis - 1)];
					c.LocalDialNumber = (reader.IsDBNull(((int)IrWholesalerColumn.LocalDialNumber - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.LocalDialNumber - 1)];
					c.LocalAccessType = (reader.IsDBNull(((int)IrWholesalerColumn.LocalAccessType - 1)))?null:(System.Int32?)reader[((int)IrWholesalerColumn.LocalAccessType - 1)];
					c.TollFreeDnis = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeDnis - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.TollFreeDnis - 1)];
					c.TollFreeDialNumber = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeDialNumber - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.TollFreeDialNumber - 1)];
					c.TollFreeAccessType = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeAccessType - 1)))?null:(System.Int32?)reader[((int)IrWholesalerColumn.TollFreeAccessType - 1)];
					c.InstantReplayUrl = (reader.IsDBNull(((int)IrWholesalerColumn.InstantReplayUrl - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.InstantReplayUrl - 1)];
					c.StorageDuration = (reader.IsDBNull(((int)IrWholesalerColumn.StorageDuration - 1)))?null:(System.Int16?)reader[((int)IrWholesalerColumn.StorageDuration - 1)];
					c.InstantReplayLoginUrl = (reader.IsDBNull(((int)IrWholesalerColumn.InstantReplayLoginUrl - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.InstantReplayLoginUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.IrWholesaler"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.IrWholesaler"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.IrWholesaler entity)
		{
			if (!reader.Read()) return;
			
			entity.WholesalerId = (System.String)reader[((int)IrWholesalerColumn.WholesalerId - 1)];
			entity.OriginalWholesalerId = (System.String)reader["WholesalerID"];
			entity.LanguageId = (System.String)reader[((int)IrWholesalerColumn.LanguageId - 1)];
			entity.OriginalLanguageId = (System.String)reader["LanguageID"];
			entity.IrCustomerId = (System.String)reader[((int)IrWholesalerColumn.IrCustomerId - 1)];
			entity.LocalDnis = (reader.IsDBNull(((int)IrWholesalerColumn.LocalDnis - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.LocalDnis - 1)];
			entity.LocalDialNumber = (reader.IsDBNull(((int)IrWholesalerColumn.LocalDialNumber - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.LocalDialNumber - 1)];
			entity.LocalAccessType = (reader.IsDBNull(((int)IrWholesalerColumn.LocalAccessType - 1)))?null:(System.Int32?)reader[((int)IrWholesalerColumn.LocalAccessType - 1)];
			entity.TollFreeDnis = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeDnis - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.TollFreeDnis - 1)];
			entity.TollFreeDialNumber = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeDialNumber - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.TollFreeDialNumber - 1)];
			entity.TollFreeAccessType = (reader.IsDBNull(((int)IrWholesalerColumn.TollFreeAccessType - 1)))?null:(System.Int32?)reader[((int)IrWholesalerColumn.TollFreeAccessType - 1)];
			entity.InstantReplayUrl = (reader.IsDBNull(((int)IrWholesalerColumn.InstantReplayUrl - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.InstantReplayUrl - 1)];
			entity.StorageDuration = (reader.IsDBNull(((int)IrWholesalerColumn.StorageDuration - 1)))?null:(System.Int16?)reader[((int)IrWholesalerColumn.StorageDuration - 1)];
			entity.InstantReplayLoginUrl = (reader.IsDBNull(((int)IrWholesalerColumn.InstantReplayLoginUrl - 1)))?null:(System.String)reader[((int)IrWholesalerColumn.InstantReplayLoginUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.IrWholesaler"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.IrWholesaler"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.IrWholesaler entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.OriginalWholesalerId = (System.String)dataRow["WholesalerID"];
			entity.LanguageId = (System.String)dataRow["LanguageID"];
			entity.OriginalLanguageId = (System.String)dataRow["LanguageID"];
			entity.IrCustomerId = (System.String)dataRow["IRCustomerID"];
			entity.LocalDnis = Convert.IsDBNull(dataRow["LocalDNIS"]) ? null : (System.String)dataRow["LocalDNIS"];
			entity.LocalDialNumber = Convert.IsDBNull(dataRow["LocalDialNumber"]) ? null : (System.String)dataRow["LocalDialNumber"];
			entity.LocalAccessType = Convert.IsDBNull(dataRow["LocalAccessType"]) ? null : (System.Int32?)dataRow["LocalAccessType"];
			entity.TollFreeDnis = Convert.IsDBNull(dataRow["TollFreeDNIS"]) ? null : (System.String)dataRow["TollFreeDNIS"];
			entity.TollFreeDialNumber = Convert.IsDBNull(dataRow["TollFreeDialNumber"]) ? null : (System.String)dataRow["TollFreeDialNumber"];
			entity.TollFreeAccessType = Convert.IsDBNull(dataRow["TollFreeAccessType"]) ? null : (System.Int32?)dataRow["TollFreeAccessType"];
			entity.InstantReplayUrl = Convert.IsDBNull(dataRow["InstantReplayURL"]) ? null : (System.String)dataRow["InstantReplayURL"];
			entity.StorageDuration = Convert.IsDBNull(dataRow["StorageDuration"]) ? null : (System.Int16?)dataRow["StorageDuration"];
			entity.InstantReplayLoginUrl = Convert.IsDBNull(dataRow["InstantReplayLoginURL"]) ? null : (System.String)dataRow["InstantReplayLoginURL"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.IrWholesaler"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.IrWholesaler Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.IrWholesaler entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Language|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LanguageId;
				Language tmpEntity = EntityManager.LocateEntity<Language>(EntityLocator.ConstructKeyFromPkItems(typeof(Language), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguageProvider.GetById(transactionManager, entity.LanguageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguageProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.IrWholesaler object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.IrWholesaler instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.IrWholesaler Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.IrWholesaler entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Language|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguageProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.Id;
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
	
	#region IrWholesalerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.IrWholesaler</c>
	///</summary>
	public enum IrWholesalerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
			
		///<summary>
		/// Composite Property for <c>Language</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Language))]
		Language,
		}
	
	#endregion IrWholesalerChildEntityTypes
	
	#region IrWholesalerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IrWholesalerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerFilterBuilder : SqlFilterBuilder<IrWholesalerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilterBuilder class.
		/// </summary>
		public IrWholesalerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IrWholesalerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IrWholesalerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IrWholesalerFilterBuilder
	
	#region IrWholesalerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IrWholesalerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IrWholesaler"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IrWholesalerParameterBuilder : ParameterizedSqlFilterBuilder<IrWholesalerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IrWholesalerParameterBuilder class.
		/// </summary>
		public IrWholesalerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IrWholesalerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IrWholesalerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IrWholesalerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IrWholesalerParameterBuilder
} // end namespace
