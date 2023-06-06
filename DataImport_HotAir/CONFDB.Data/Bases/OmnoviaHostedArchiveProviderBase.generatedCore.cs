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
	/// This class is the base class for any <see cref="OmnoviaHostedArchiveProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OmnoviaHostedArchiveProviderBaseCore : EntityProviderBase<CONFDB.Entities.OmnoviaHostedArchive, CONFDB.Entities.OmnoviaHostedArchiveKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveKey key)
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
		public override CONFDB.Entities.OmnoviaHostedArchive Get(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchiveKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchive GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchive GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchive GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchive GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public CONFDB.Entities.OmnoviaHostedArchive GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OmnoviaHostedArchive index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> class.</returns>
		public abstract CONFDB.Entities.OmnoviaHostedArchive GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_OmnoviaHostedArchive_RenewHostedLink 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_RenewHostedLink' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="noMonthHostingPeriod"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet RenewHostedLink(System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId, System.Int32? noMonthHostingPeriod)
		{
			return RenewHostedLink(null, 0, int.MaxValue , omnoviaCustomerId, moderatorId, hostedArchiveId, noMonthHostingPeriod);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_RenewHostedLink' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="noMonthHostingPeriod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet RenewHostedLink(int start, int pageLength, System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId, System.Int32? noMonthHostingPeriod)
		{
			return RenewHostedLink(null, start, pageLength , omnoviaCustomerId, moderatorId, hostedArchiveId, noMonthHostingPeriod);
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_RenewHostedLink' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="noMonthHostingPeriod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet RenewHostedLink(TransactionManager transactionManager, System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId, System.Int32? noMonthHostingPeriod)
		{
			return RenewHostedLink(transactionManager, 0, int.MaxValue , omnoviaCustomerId, moderatorId, hostedArchiveId, noMonthHostingPeriod);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_RenewHostedLink' stored procedure. 
		/// </summary>
		/// <param name="omnoviaCustomerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hostedArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="noMonthHostingPeriod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet RenewHostedLink(TransactionManager transactionManager, int start, int pageLength , System.Int32? omnoviaCustomerId, System.Int32? moderatorId, System.Int32? hostedArchiveId, System.Int32? noMonthHostingPeriod);
		
		#endregion
		
		#region p_OmnoviaHostedArchive_checkURL 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_checkURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet checkURL(System.String url)
		{
			return checkURL(null, 0, int.MaxValue , url);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_checkURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet checkURL(int start, int pageLength, System.String url)
		{
			return checkURL(null, start, pageLength , url);
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_checkURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet checkURL(TransactionManager transactionManager, System.String url)
		{
			return checkURL(transactionManager, 0, int.MaxValue , url);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_checkURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet checkURL(TransactionManager transactionManager, int start, int pageLength , System.String url);
		
		#endregion
		
		#region p_OmnoviaHostedArchive_getAllOmnoviaCompanyLogin 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_getAllOmnoviaCompanyLogin' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet getAllOmnoviaCompanyLogin()
		{
			return getAllOmnoviaCompanyLogin(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_getAllOmnoviaCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet getAllOmnoviaCompanyLogin(int start, int pageLength)
		{
			return getAllOmnoviaCompanyLogin(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_getAllOmnoviaCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet getAllOmnoviaCompanyLogin(TransactionManager transactionManager)
		{
			return getAllOmnoviaCompanyLogin(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_getAllOmnoviaCompanyLogin' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet getAllOmnoviaCompanyLogin(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_OmnoviaHostedArchive_addRegistration 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_addRegistration' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="firstname"> A <c>System.String</c> instance.</param>
		/// <param name="lastname"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
			/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void addRegistration(System.String url, System.String firstname, System.String lastname, System.String company, System.String email, ref System.String companyShortLink, ref System.Int32? movieId)
		{
			 addRegistration(null, 0, int.MaxValue , url, firstname, lastname, company, email, ref companyShortLink, ref movieId);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_addRegistration' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="firstname"> A <c>System.String</c> instance.</param>
		/// <param name="lastname"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
			/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void addRegistration(int start, int pageLength, System.String url, System.String firstname, System.String lastname, System.String company, System.String email, ref System.String companyShortLink, ref System.Int32? movieId)
		{
			 addRegistration(null, start, pageLength , url, firstname, lastname, company, email, ref companyShortLink, ref movieId);
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_addRegistration' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="firstname"> A <c>System.String</c> instance.</param>
		/// <param name="lastname"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
			/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void addRegistration(TransactionManager transactionManager, System.String url, System.String firstname, System.String lastname, System.String company, System.String email, ref System.String companyShortLink, ref System.Int32? movieId)
		{
			 addRegistration(transactionManager, 0, int.MaxValue , url, firstname, lastname, company, email, ref companyShortLink, ref movieId);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_addRegistration' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="firstname"> A <c>System.String</c> instance.</param>
		/// <param name="lastname"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="companyShortLink"> A <c>System.String</c> instance.</param>
			/// <param name="movieId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void addRegistration(TransactionManager transactionManager, int start, int pageLength , System.String url, System.String firstname, System.String lastname, System.String company, System.String email, ref System.String companyShortLink, ref System.Int32? movieId);
		
		#endregion
		
		#region p_OmnoviaHostedArchive_GetCompanyLoginByURL 
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_GetCompanyLoginByURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCompanyLoginByURL(System.String url)
		{
			return GetCompanyLoginByURL(null, 0, int.MaxValue , url);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_GetCompanyLoginByURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCompanyLoginByURL(int start, int pageLength, System.String url)
		{
			return GetCompanyLoginByURL(null, start, pageLength , url);
		}
				
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_GetCompanyLoginByURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCompanyLoginByURL(TransactionManager transactionManager, System.String url)
		{
			return GetCompanyLoginByURL(transactionManager, 0, int.MaxValue , url);
		}
		
		/// <summary>
		///	This method wrap the 'p_OmnoviaHostedArchive_GetCompanyLoginByURL' stored procedure. 
		/// </summary>
		/// <param name="url"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCompanyLoginByURL(TransactionManager transactionManager, int start, int pageLength , System.String url);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;OmnoviaHostedArchive&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;OmnoviaHostedArchive&gt;"/></returns>
		public static CONFDB.Entities.TList<OmnoviaHostedArchive> Fill(IDataReader reader, CONFDB.Entities.TList<OmnoviaHostedArchive> rows, int start, int pageLength)
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
				
				CONFDB.Entities.OmnoviaHostedArchive c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OmnoviaHostedArchive")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.OmnoviaHostedArchiveColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.OmnoviaHostedArchiveColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<OmnoviaHostedArchive>(
					key.ToString(), // EntityTrackingKey
					"OmnoviaHostedArchive",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.OmnoviaHostedArchive();
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
					c.Id = (System.Int32)reader[((int)OmnoviaHostedArchiveColumn.Id - 1)];
					c.OmnoviaCustomerId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.OmnoviaCustomerId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.OmnoviaCustomerId - 1)];
					c.ModeratorId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.ModeratorId - 1)];
					c.MovieId = (System.Int32)reader[((int)OmnoviaHostedArchiveColumn.MovieId - 1)];
					c.RoomName = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.RoomName - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.RoomName - 1)];
					c.MovieTitle = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieTitle - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.MovieTitle - 1)];
					c.MovieDateAdded = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieDateAdded - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.MovieDateAdded - 1)];
					c.MovieLength = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieLength - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.MovieLength - 1)];
					c.MovieRoomId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieRoomId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.MovieRoomId - 1)];
					c.MovieDate = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieDate - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.MovieDate - 1)];
					c.CompanyShortLink = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.CompanyShortLink - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.CompanyShortLink - 1)];
					c.Created = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.Created - 1)];
					c.HostedLinkExpiryDate = (System.DateTime)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkExpiryDate - 1)];
					c.HostedLinkShortened = (System.String)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkShortened - 1)];
					c.HostedLinkAlias = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostedLinkAlias - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkAlias - 1)];
					c.RecordingDirectory = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.RecordingDirectory - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.RecordingDirectory - 1)];
					c.UniqueConferenceId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.UniqueConferenceId - 1)];
					c.HostingPeriod = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostingPeriod - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.HostingPeriod - 1)];
					c.HostingAutoRenew = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostingAutoRenew - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.HostingAutoRenew - 1)];
					c.Event_Id = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.Event_Id - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.Event_Id - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.OmnoviaHostedArchive entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OmnoviaHostedArchiveColumn.Id - 1)];
			entity.OmnoviaCustomerId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.OmnoviaCustomerId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.OmnoviaCustomerId - 1)];
			entity.ModeratorId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.ModeratorId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.ModeratorId - 1)];
			entity.MovieId = (System.Int32)reader[((int)OmnoviaHostedArchiveColumn.MovieId - 1)];
			entity.RoomName = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.RoomName - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.RoomName - 1)];
			entity.MovieTitle = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieTitle - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.MovieTitle - 1)];
			entity.MovieDateAdded = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieDateAdded - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.MovieDateAdded - 1)];
			entity.MovieLength = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieLength - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.MovieLength - 1)];
			entity.MovieRoomId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieRoomId - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.MovieRoomId - 1)];
			entity.MovieDate = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.MovieDate - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.MovieDate - 1)];
			entity.CompanyShortLink = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.CompanyShortLink - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.CompanyShortLink - 1)];
			entity.Created = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.Created - 1)))?null:(System.DateTime?)reader[((int)OmnoviaHostedArchiveColumn.Created - 1)];
			entity.HostedLinkExpiryDate = (System.DateTime)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkExpiryDate - 1)];
			entity.HostedLinkShortened = (System.String)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkShortened - 1)];
			entity.HostedLinkAlias = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostedLinkAlias - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.HostedLinkAlias - 1)];
			entity.RecordingDirectory = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.RecordingDirectory - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.RecordingDirectory - 1)];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.UniqueConferenceId - 1)))?null:(System.String)reader[((int)OmnoviaHostedArchiveColumn.UniqueConferenceId - 1)];
			entity.HostingPeriod = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostingPeriod - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.HostingPeriod - 1)];
			entity.HostingAutoRenew = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.HostingAutoRenew - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.HostingAutoRenew - 1)];
			entity.Event_Id = (reader.IsDBNull(((int)OmnoviaHostedArchiveColumn.Event_Id - 1)))?null:(System.Int32?)reader[((int)OmnoviaHostedArchiveColumn.Event_Id - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.OmnoviaHostedArchive entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.OmnoviaCustomerId = Convert.IsDBNull(dataRow["OmnoviaCustomerID"]) ? null : (System.Int32?)dataRow["OmnoviaCustomerID"];
			entity.ModeratorId = Convert.IsDBNull(dataRow["ModeratorID"]) ? null : (System.Int32?)dataRow["ModeratorID"];
			entity.MovieId = (System.Int32)dataRow["MovieID"];
			entity.RoomName = Convert.IsDBNull(dataRow["RoomName"]) ? null : (System.String)dataRow["RoomName"];
			entity.MovieTitle = Convert.IsDBNull(dataRow["MovieTitle"]) ? null : (System.String)dataRow["MovieTitle"];
			entity.MovieDateAdded = Convert.IsDBNull(dataRow["MovieDateAdded"]) ? null : (System.DateTime?)dataRow["MovieDateAdded"];
			entity.MovieLength = Convert.IsDBNull(dataRow["MovieLength"]) ? null : (System.Int32?)dataRow["MovieLength"];
			entity.MovieRoomId = Convert.IsDBNull(dataRow["MovieRoomID"]) ? null : (System.Int32?)dataRow["MovieRoomID"];
			entity.MovieDate = Convert.IsDBNull(dataRow["MovieDate"]) ? null : (System.DateTime?)dataRow["MovieDate"];
			entity.CompanyShortLink = Convert.IsDBNull(dataRow["CompanyShortLink"]) ? null : (System.String)dataRow["CompanyShortLink"];
			entity.Created = Convert.IsDBNull(dataRow["created"]) ? null : (System.DateTime?)dataRow["created"];
			entity.HostedLinkExpiryDate = (System.DateTime)dataRow["HostedLinkExpiryDate"];
			entity.HostedLinkShortened = (System.String)dataRow["HostedLinkShortened"];
			entity.HostedLinkAlias = Convert.IsDBNull(dataRow["HostedLinkAlias"]) ? null : (System.String)dataRow["HostedLinkAlias"];
			entity.RecordingDirectory = Convert.IsDBNull(dataRow["RecordingDirectory"]) ? null : (System.String)dataRow["RecordingDirectory"];
			entity.UniqueConferenceId = Convert.IsDBNull(dataRow["UniqueConferenceID"]) ? null : (System.String)dataRow["UniqueConferenceID"];
			entity.HostingPeriod = Convert.IsDBNull(dataRow["HostingPeriod"]) ? null : (System.Int32?)dataRow["HostingPeriod"];
			entity.HostingAutoRenew = Convert.IsDBNull(dataRow["HostingAutoRenew"]) ? null : (System.Int32?)dataRow["HostingAutoRenew"];
			entity.Event_Id = Convert.IsDBNull(dataRow["Event_ID"]) ? null : (System.Int32?)dataRow["Event_ID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.OmnoviaHostedArchive"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaHostedArchive Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchive entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.OmnoviaHostedArchive object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.OmnoviaHostedArchive instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.OmnoviaHostedArchive Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.OmnoviaHostedArchive entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region OmnoviaHostedArchiveChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.OmnoviaHostedArchive</c>
	///</summary>
	public enum OmnoviaHostedArchiveChildEntityTypes
	{
	}
	
	#endregion OmnoviaHostedArchiveChildEntityTypes
	
	#region OmnoviaHostedArchiveFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OmnoviaHostedArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveFilterBuilder : SqlFilterBuilder<OmnoviaHostedArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilterBuilder class.
		/// </summary>
		public OmnoviaHostedArchiveFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveFilterBuilder
	
	#region OmnoviaHostedArchiveParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OmnoviaHostedArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OmnoviaHostedArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OmnoviaHostedArchiveParameterBuilder : ParameterizedSqlFilterBuilder<OmnoviaHostedArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParameterBuilder class.
		/// </summary>
		public OmnoviaHostedArchiveParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OmnoviaHostedArchiveParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OmnoviaHostedArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OmnoviaHostedArchiveParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OmnoviaHostedArchiveParameterBuilder
} // end namespace
