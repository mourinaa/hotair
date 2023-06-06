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
	/// This class is the base class for any <see cref="ModeratorXtimeUserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ModeratorXtimeUserProviderBaseCore : EntityProviderBase<CONFDB.Entities.ModeratorXtimeUser, CONFDB.Entities.ModeratorXtimeUserKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ModeratorXtimeUserKey key)
		{
			return Delete(transactionManager, key.ModeratorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_moderatorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _moderatorId)
		{
			return Delete(null, _moderatorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _moderatorId);		
		
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
		public override CONFDB.Entities.ModeratorXtimeUser Get(TransactionManager transactionManager, CONFDB.Entities.ModeratorXtimeUserKey key, int start, int pageLength)
		{
			return GetByModeratorId(transactionManager, key.ModeratorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(null,_moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorId(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(System.Int32 _moderatorId, int start, int pageLength, out int count)
		{
			return GetByModeratorId(null, _moderatorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ModeratorXTimeUser_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> class.</returns>
		public abstract CONFDB.Entities.ModeratorXtimeUser GetByModeratorId(TransactionManager transactionManager, System.Int32 _moderatorId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="_firstCallDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(System.DateTime? _firstCallDate)
		{
			int count = -1;
			return GetByFirstCallDate(null,_firstCallDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="_firstCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(System.DateTime? _firstCallDate, int start, int pageLength)
		{
			int count = -1;
			return GetByFirstCallDate(null, _firstCallDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_firstCallDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(TransactionManager transactionManager, System.DateTime? _firstCallDate)
		{
			int count = -1;
			return GetByFirstCallDate(transactionManager, _firstCallDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_firstCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(TransactionManager transactionManager, System.DateTime? _firstCallDate, int start, int pageLength)
		{
			int count = -1;
			return GetByFirstCallDate(transactionManager, _firstCallDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="_firstCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(System.DateTime? _firstCallDate, int start, int pageLength, out int count)
		{
			return GetByFirstCallDate(null, _firstCallDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_FirstCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_firstCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ModeratorXtimeUser> GetByFirstCallDate(TransactionManager transactionManager, System.DateTime? _firstCallDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="_thirdCallDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(System.DateTime? _thirdCallDate)
		{
			int count = -1;
			return GetByThirdCallDate(null,_thirdCallDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="_thirdCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(System.DateTime? _thirdCallDate, int start, int pageLength)
		{
			int count = -1;
			return GetByThirdCallDate(null, _thirdCallDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_thirdCallDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(TransactionManager transactionManager, System.DateTime? _thirdCallDate)
		{
			int count = -1;
			return GetByThirdCallDate(transactionManager, _thirdCallDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_thirdCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(TransactionManager transactionManager, System.DateTime? _thirdCallDate, int start, int pageLength)
		{
			int count = -1;
			return GetByThirdCallDate(transactionManager, _thirdCallDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="_thirdCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(System.DateTime? _thirdCallDate, int start, int pageLength, out int count)
		{
			return GetByThirdCallDate(null, _thirdCallDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ModeratorXTimeUser_ThirdCallDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_thirdCallDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<ModeratorXtimeUser> GetByThirdCallDate(TransactionManager transactionManager, System.DateTime? _thirdCallDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_ModeratorXTimeUser_XTimeReport 
		
		/// <summary>
		///	This method wrap the 'p_ModeratorXTimeUser_XTimeReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reportNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet XTimeReport(System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.Int32? reportNumber, System.Int32? salesPersonId)
		{
			return XTimeReport(null, 0, int.MaxValue , wholesalerId, startDate, endDate, reportNumber, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_ModeratorXTimeUser_XTimeReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reportNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet XTimeReport(int start, int pageLength, System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.Int32? reportNumber, System.Int32? salesPersonId)
		{
			return XTimeReport(null, start, pageLength , wholesalerId, startDate, endDate, reportNumber, salesPersonId);
		}
				
		/// <summary>
		///	This method wrap the 'p_ModeratorXTimeUser_XTimeReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reportNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet XTimeReport(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.Int32? reportNumber, System.Int32? salesPersonId)
		{
			return XTimeReport(transactionManager, 0, int.MaxValue , wholesalerId, startDate, endDate, reportNumber, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_ModeratorXTimeUser_XTimeReport' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reportNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet XTimeReport(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.Int32? reportNumber, System.Int32? salesPersonId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ModeratorXtimeUser&gt;"/></returns>
		public static CONFDB.Entities.TList<ModeratorXtimeUser> Fill(IDataReader reader, CONFDB.Entities.TList<ModeratorXtimeUser> rows, int start, int pageLength)
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
				
				CONFDB.Entities.ModeratorXtimeUser c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ModeratorXtimeUser")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ModeratorXtimeUserColumn.ModeratorId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ModeratorXtimeUserColumn.ModeratorId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ModeratorXtimeUser>(
					key.ToString(), // EntityTrackingKey
					"ModeratorXtimeUser",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ModeratorXtimeUser();
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
					c.ModeratorId = (System.Int32)reader[((int)ModeratorXtimeUserColumn.ModeratorId - 1)];
					c.OriginalModeratorId = c.ModeratorId;
					c.FirstCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.FirstCallDate - 1)];
					c.FirstCallProductId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallProductId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.FirstCallProductId - 1)];
					c.FirstCallNotes = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallNotes - 1)))?null:(System.String)reader[((int)ModeratorXtimeUserColumn.FirstCallNotes - 1)];
					c.ThirdCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.ThirdCallDate - 1)];
					c.ThirdCallProductId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallProductId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.ThirdCallProductId - 1)];
					c.ThirdCallNotes = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallNotes - 1)))?null:(System.String)reader[((int)ModeratorXtimeUserColumn.ThirdCallNotes - 1)];
					c.SecondCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.SecondCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.SecondCallDate - 1)];
					c.UserId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.UserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ModeratorXtimeUser"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ModeratorXtimeUser entity)
		{
			if (!reader.Read()) return;
			
			entity.ModeratorId = (System.Int32)reader[((int)ModeratorXtimeUserColumn.ModeratorId - 1)];
			entity.OriginalModeratorId = (System.Int32)reader["ModeratorID"];
			entity.FirstCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.FirstCallDate - 1)];
			entity.FirstCallProductId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallProductId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.FirstCallProductId - 1)];
			entity.FirstCallNotes = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.FirstCallNotes - 1)))?null:(System.String)reader[((int)ModeratorXtimeUserColumn.FirstCallNotes - 1)];
			entity.ThirdCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.ThirdCallDate - 1)];
			entity.ThirdCallProductId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallProductId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.ThirdCallProductId - 1)];
			entity.ThirdCallNotes = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.ThirdCallNotes - 1)))?null:(System.String)reader[((int)ModeratorXtimeUserColumn.ThirdCallNotes - 1)];
			entity.SecondCallDate = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.SecondCallDate - 1)))?null:(System.DateTime?)reader[((int)ModeratorXtimeUserColumn.SecondCallDate - 1)];
			entity.UserId = (reader.IsDBNull(((int)ModeratorXtimeUserColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ModeratorXtimeUserColumn.UserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ModeratorXtimeUser"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ModeratorXtimeUser"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ModeratorXtimeUser entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.OriginalModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.FirstCallDate = Convert.IsDBNull(dataRow["FirstCallDate"]) ? null : (System.DateTime?)dataRow["FirstCallDate"];
			entity.FirstCallProductId = Convert.IsDBNull(dataRow["FirstCallProductID"]) ? null : (System.Int32?)dataRow["FirstCallProductID"];
			entity.FirstCallNotes = Convert.IsDBNull(dataRow["FirstCallNotes"]) ? null : (System.String)dataRow["FirstCallNotes"];
			entity.ThirdCallDate = Convert.IsDBNull(dataRow["ThirdCallDate"]) ? null : (System.DateTime?)dataRow["ThirdCallDate"];
			entity.ThirdCallProductId = Convert.IsDBNull(dataRow["ThirdCallProductID"]) ? null : (System.Int32?)dataRow["ThirdCallProductID"];
			entity.ThirdCallNotes = Convert.IsDBNull(dataRow["ThirdCallNotes"]) ? null : (System.String)dataRow["ThirdCallNotes"];
			entity.SecondCallDate = Convert.IsDBNull(dataRow["SecondCallDate"]) ? null : (System.DateTime?)dataRow["SecondCallDate"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.ModeratorXtimeUser"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ModeratorXtimeUser Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ModeratorXtimeUser entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.ModeratorXtimeUser object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ModeratorXtimeUser instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ModeratorXtimeUser Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ModeratorXtimeUser entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ModeratorXtimeUserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ModeratorXtimeUser</c>
	///</summary>
	public enum ModeratorXtimeUserChildEntityTypes
	{
	}
	
	#endregion ModeratorXtimeUserChildEntityTypes
	
	#region ModeratorXtimeUserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ModeratorXtimeUserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserFilterBuilder : SqlFilterBuilder<ModeratorXtimeUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilterBuilder class.
		/// </summary>
		public ModeratorXtimeUserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorXtimeUserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorXtimeUserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorXtimeUserFilterBuilder
	
	#region ModeratorXtimeUserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ModeratorXtimeUserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ModeratorXtimeUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ModeratorXtimeUserParameterBuilder : ParameterizedSqlFilterBuilder<ModeratorXtimeUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserParameterBuilder class.
		/// </summary>
		public ModeratorXtimeUserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ModeratorXtimeUserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ModeratorXtimeUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ModeratorXtimeUserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ModeratorXtimeUserParameterBuilder
} // end namespace
