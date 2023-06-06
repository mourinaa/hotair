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
	/// This class is the base class for any <see cref="FeatureOptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FeatureOptionProviderBaseCore : EntityProviderBase<CONFDB.Entities.FeatureOption, CONFDB.Entities.FeatureOptionKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.FeatureOptionKey key)
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
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		FeatureOptionType_FeatureOption_FK Description: 
		/// </summary>
		/// <param name="_featureOptionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(System.Int32? _featureOptionTypeId)
		{
			int count = -1;
			return GetByFeatureOptionTypeId(_featureOptionTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		FeatureOptionType_FeatureOption_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureOptionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(TransactionManager transactionManager, System.Int32? _featureOptionTypeId)
		{
			int count = -1;
			return GetByFeatureOptionTypeId(transactionManager, _featureOptionTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		FeatureOptionType_FeatureOption_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureOptionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(TransactionManager transactionManager, System.Int32? _featureOptionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByFeatureOptionTypeId(transactionManager, _featureOptionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		featureOptionType_FeatureOption_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_featureOptionTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(System.Int32? _featureOptionTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFeatureOptionTypeId(null, _featureOptionTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		featureOptionType_FeatureOption_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_featureOptionTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(System.Int32? _featureOptionTypeId, int start, int pageLength,out int count)
		{
			return GetByFeatureOptionTypeId(null, _featureOptionTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOptionType_FeatureOption_FK key.
		///		FeatureOptionType_FeatureOption_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureOptionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.FeatureOption objects.</returns>
		public abstract CONFDB.Entities.TList<FeatureOption> GetByFeatureOptionTypeId(TransactionManager transactionManager, System.Int32? _featureOptionTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.FeatureOption Get(TransactionManager transactionManager, CONFDB.Entities.FeatureOptionKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key FeatureOption_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public CONFDB.Entities.FeatureOption GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOption_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public CONFDB.Entities.FeatureOption GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOption_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public CONFDB.Entities.FeatureOption GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOption_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public CONFDB.Entities.FeatureOption GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOption_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public CONFDB.Entities.FeatureOption GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the FeatureOption_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.FeatureOption"/> class.</returns>
		public abstract CONFDB.Entities.FeatureOption GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(System.String _name, System.Int32 _featureId, System.Int32 _id)
		{
			int count = -1;
			return GetByNameFeatureIdId(null,_name, _featureId, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(System.String _name, System.Int32 _featureId, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByNameFeatureIdId(null, _name, _featureId, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(TransactionManager transactionManager, System.String _name, System.Int32 _featureId, System.Int32 _id)
		{
			int count = -1;
			return GetByNameFeatureIdId(transactionManager, _name, _featureId, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(TransactionManager transactionManager, System.String _name, System.Int32 _featureId, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetByNameFeatureIdId(transactionManager, _name, _featureId, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(System.String _name, System.Int32 _featureId, System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetByNameFeatureIdId(null, _name, _featureId, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="_featureId"></param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<FeatureOption> GetByNameFeatureIdId(TransactionManager transactionManager, System.String _name, System.Int32 _featureId, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="_featureId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureId(System.Int32 _featureId)
		{
			int count = -1;
			return GetByFeatureId(null,_featureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="_featureId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureId(System.Int32 _featureId, int start, int pageLength)
		{
			int count = -1;
			return GetByFeatureId(null, _featureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureId(TransactionManager transactionManager, System.Int32 _featureId)
		{
			int count = -1;
			return GetByFeatureId(transactionManager, _featureId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureId(TransactionManager transactionManager, System.Int32 _featureId, int start, int pageLength)
		{
			int count = -1;
			return GetByFeatureId(transactionManager, _featureId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="_featureId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public CONFDB.Entities.TList<FeatureOption> GetByFeatureId(System.Int32 _featureId, int start, int pageLength, out int count)
		{
			return GetByFeatureId(null, _featureId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_FeatureOptions_FeaturesID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_featureId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<FeatureOption> GetByFeatureId(TransactionManager transactionManager, System.Int32 _featureId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;FeatureOption&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;FeatureOption&gt;"/></returns>
		public static CONFDB.Entities.TList<FeatureOption> Fill(IDataReader reader, CONFDB.Entities.TList<FeatureOption> rows, int start, int pageLength)
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
				
				CONFDB.Entities.FeatureOption c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("FeatureOption")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.FeatureOptionColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.FeatureOptionColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<FeatureOption>(
					key.ToString(), // EntityTrackingKey
					"FeatureOption",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.FeatureOption();
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
					c.Id = (System.Int32)reader[((int)FeatureOptionColumn.Id - 1)];
					c.FeatureId = (System.Int32)reader[((int)FeatureOptionColumn.FeatureId - 1)];
					c.Name = (reader.IsDBNull(((int)FeatureOptionColumn.Name - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.Name - 1)];
					c.DisplayName = (reader.IsDBNull(((int)FeatureOptionColumn.DisplayName - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DisplayName - 1)];
					c.Description = (reader.IsDBNull(((int)FeatureOptionColumn.Description - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.Description - 1)];
					c.DisplayNameAlt = (reader.IsDBNull(((int)FeatureOptionColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DisplayNameAlt - 1)];
					c.DescriptionAlt = (reader.IsDBNull(((int)FeatureOptionColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DescriptionAlt - 1)];
					c.Value = (System.String)reader[((int)FeatureOptionColumn.Value - 1)];
					c.DisplayOrder = (System.Int32)reader[((int)FeatureOptionColumn.DisplayOrder - 1)];
					c.DefaultOption = (System.Boolean)reader[((int)FeatureOptionColumn.DefaultOption - 1)];
					c.Enabled = (System.Boolean)reader[((int)FeatureOptionColumn.Enabled - 1)];
					c.FeatureOptionTypeId = (reader.IsDBNull(((int)FeatureOptionColumn.FeatureOptionTypeId - 1)))?null:(System.Int32?)reader[((int)FeatureOptionColumn.FeatureOptionTypeId - 1)];
					c.RegularExpression = (reader.IsDBNull(((int)FeatureOptionColumn.RegularExpression - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.RegularExpression - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.FeatureOption"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.FeatureOption"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.FeatureOption entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)FeatureOptionColumn.Id - 1)];
			entity.FeatureId = (System.Int32)reader[((int)FeatureOptionColumn.FeatureId - 1)];
			entity.Name = (reader.IsDBNull(((int)FeatureOptionColumn.Name - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.Name - 1)];
			entity.DisplayName = (reader.IsDBNull(((int)FeatureOptionColumn.DisplayName - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DisplayName - 1)];
			entity.Description = (reader.IsDBNull(((int)FeatureOptionColumn.Description - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.Description - 1)];
			entity.DisplayNameAlt = (reader.IsDBNull(((int)FeatureOptionColumn.DisplayNameAlt - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DisplayNameAlt - 1)];
			entity.DescriptionAlt = (reader.IsDBNull(((int)FeatureOptionColumn.DescriptionAlt - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.DescriptionAlt - 1)];
			entity.Value = (System.String)reader[((int)FeatureOptionColumn.Value - 1)];
			entity.DisplayOrder = (System.Int32)reader[((int)FeatureOptionColumn.DisplayOrder - 1)];
			entity.DefaultOption = (System.Boolean)reader[((int)FeatureOptionColumn.DefaultOption - 1)];
			entity.Enabled = (System.Boolean)reader[((int)FeatureOptionColumn.Enabled - 1)];
			entity.FeatureOptionTypeId = (reader.IsDBNull(((int)FeatureOptionColumn.FeatureOptionTypeId - 1)))?null:(System.Int32?)reader[((int)FeatureOptionColumn.FeatureOptionTypeId - 1)];
			entity.RegularExpression = (reader.IsDBNull(((int)FeatureOptionColumn.RegularExpression - 1)))?null:(System.String)reader[((int)FeatureOptionColumn.RegularExpression - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.FeatureOption"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.FeatureOption"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.FeatureOption entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.FeatureId = (System.Int32)dataRow["FeatureID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayNameAlt = Convert.IsDBNull(dataRow["DisplayNameAlt"]) ? null : (System.String)dataRow["DisplayNameAlt"];
			entity.DescriptionAlt = Convert.IsDBNull(dataRow["DescriptionAlt"]) ? null : (System.String)dataRow["DescriptionAlt"];
			entity.Value = (System.String)dataRow["Value"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.DefaultOption = (System.Boolean)dataRow["DefaultOption"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.FeatureOptionTypeId = Convert.IsDBNull(dataRow["FeatureOptionTypeID"]) ? null : (System.Int32?)dataRow["FeatureOptionTypeID"];
			entity.RegularExpression = Convert.IsDBNull(dataRow["RegularExpression"]) ? null : (System.String)dataRow["RegularExpression"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.FeatureOption"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.FeatureOption Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.FeatureOption entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FeatureIdSource	
			if (CanDeepLoad(entity, "Feature|FeatureIdSource", deepLoadType, innerList) 
				&& entity.FeatureIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FeatureId;
				Feature tmpEntity = EntityManager.LocateEntity<Feature>(EntityLocator.ConstructKeyFromPkItems(typeof(Feature), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FeatureIdSource = tmpEntity;
				else
					entity.FeatureIdSource = DataRepository.FeatureProvider.GetById(transactionManager, entity.FeatureId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FeatureIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FeatureIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FeatureProvider.DeepLoad(transactionManager, entity.FeatureIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FeatureIdSource

			#region FeatureOptionTypeIdSource	
			if (CanDeepLoad(entity, "FeatureOptionType|FeatureOptionTypeIdSource", deepLoadType, innerList) 
				&& entity.FeatureOptionTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.FeatureOptionTypeId ?? (int)0);
				FeatureOptionType tmpEntity = EntityManager.LocateEntity<FeatureOptionType>(EntityLocator.ConstructKeyFromPkItems(typeof(FeatureOptionType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FeatureOptionTypeIdSource = tmpEntity;
				else
					entity.FeatureOptionTypeIdSource = DataRepository.FeatureOptionTypeProvider.GetById(transactionManager, (entity.FeatureOptionTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FeatureOptionTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FeatureOptionTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FeatureOptionTypeProvider.DeepLoad(transactionManager, entity.FeatureOptionTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FeatureOptionTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region Wholesaler_Product_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Wholesaler_Product_Feature>|Wholesaler_Product_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Wholesaler_Product_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Wholesaler_Product_FeatureCollection = DataRepository.Wholesaler_Product_FeatureProvider.GetByFeatureOptionId(transactionManager, entity.Id);

				if (deep && entity.Wholesaler_Product_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Wholesaler_Product_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Wholesaler_Product_Feature>) DataRepository.Wholesaler_Product_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Wholesaler_Product_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Moderator_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator_Feature>|Moderator_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Moderator_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Moderator_FeatureCollection = DataRepository.Moderator_FeatureProvider.GetByFeatureOptionId(transactionManager, entity.Id);

				if (deep && entity.Moderator_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator_Feature>) DataRepository.Moderator_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Moderator_FeatureCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region Customer_FeatureCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer_Feature>|Customer_FeatureCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Customer_FeatureCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Customer_FeatureCollection = DataRepository.Customer_FeatureProvider.GetByFeatureOptionId(transactionManager, entity.Id);

				if (deep && entity.Customer_FeatureCollection.Count > 0)
				{
					deepHandles.Add("Customer_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer_Feature>) DataRepository.Customer_FeatureProvider.DeepLoad,
						new object[] { transactionManager, entity.Customer_FeatureCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.FeatureOption object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.FeatureOption instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.FeatureOption Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.FeatureOption entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FeatureIdSource
			if (CanDeepSave(entity, "Feature|FeatureIdSource", deepSaveType, innerList) 
				&& entity.FeatureIdSource != null)
			{
				DataRepository.FeatureProvider.Save(transactionManager, entity.FeatureIdSource);
				entity.FeatureId = entity.FeatureIdSource.Id;
			}
			#endregion 
			
			#region FeatureOptionTypeIdSource
			if (CanDeepSave(entity, "FeatureOptionType|FeatureOptionTypeIdSource", deepSaveType, innerList) 
				&& entity.FeatureOptionTypeIdSource != null)
			{
				DataRepository.FeatureOptionTypeProvider.Save(transactionManager, entity.FeatureOptionTypeIdSource);
				entity.FeatureOptionTypeId = entity.FeatureOptionTypeIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Wholesaler_Product_Feature>
				if (CanDeepSave(entity.Wholesaler_Product_FeatureCollection, "List<Wholesaler_Product_Feature>|Wholesaler_Product_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Wholesaler_Product_Feature child in entity.Wholesaler_Product_FeatureCollection)
					{
						if(child.FeatureOptionIdSource != null)
						{
							child.FeatureOptionId = child.FeatureOptionIdSource.Id;
						}
						else
						{
							child.FeatureOptionId = entity.Id;
						}

					}

					if (entity.Wholesaler_Product_FeatureCollection.Count > 0 || entity.Wholesaler_Product_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Wholesaler_Product_FeatureProvider.Save(transactionManager, entity.Wholesaler_Product_FeatureCollection);
						
						deepHandles.Add("Wholesaler_Product_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Wholesaler_Product_Feature >) DataRepository.Wholesaler_Product_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Wholesaler_Product_FeatureCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Moderator_Feature>
				if (CanDeepSave(entity.Moderator_FeatureCollection, "List<Moderator_Feature>|Moderator_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator_Feature child in entity.Moderator_FeatureCollection)
					{
						if(child.FeatureOptionIdSource != null)
						{
							child.FeatureOptionId = child.FeatureOptionIdSource.Id;
						}
						else
						{
							child.FeatureOptionId = entity.Id;
						}

					}

					if (entity.Moderator_FeatureCollection.Count > 0 || entity.Moderator_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Moderator_FeatureProvider.Save(transactionManager, entity.Moderator_FeatureCollection);
						
						deepHandles.Add("Moderator_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator_Feature >) DataRepository.Moderator_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Moderator_FeatureCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer_Feature>
				if (CanDeepSave(entity.Customer_FeatureCollection, "List<Customer_Feature>|Customer_FeatureCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer_Feature child in entity.Customer_FeatureCollection)
					{
						if(child.FeatureOptionIdSource != null)
						{
							child.FeatureOptionId = child.FeatureOptionIdSource.Id;
						}
						else
						{
							child.FeatureOptionId = entity.Id;
						}

					}

					if (entity.Customer_FeatureCollection.Count > 0 || entity.Customer_FeatureCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Customer_FeatureProvider.Save(transactionManager, entity.Customer_FeatureCollection);
						
						deepHandles.Add("Customer_FeatureCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer_Feature >) DataRepository.Customer_FeatureProvider.DeepSave,
							new object[] { transactionManager, entity.Customer_FeatureCollection, deepSaveType, childTypes, innerList }
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
	
	#region FeatureOptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.FeatureOption</c>
	///</summary>
	public enum FeatureOptionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Feature</c> at FeatureIdSource
		///</summary>
		[ChildEntityType(typeof(Feature))]
		Feature,
			
		///<summary>
		/// Composite Property for <c>FeatureOptionType</c> at FeatureOptionTypeIdSource
		///</summary>
		[ChildEntityType(typeof(FeatureOptionType))]
		FeatureOptionType,
	
		///<summary>
		/// Collection of <c>FeatureOption</c> as OneToMany for Wholesaler_Product_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Wholesaler_Product_Feature>))]
		Wholesaler_Product_FeatureCollection,

		///<summary>
		/// Collection of <c>FeatureOption</c> as OneToMany for Moderator_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator_Feature>))]
		Moderator_FeatureCollection,

		///<summary>
		/// Collection of <c>FeatureOption</c> as OneToMany for Customer_FeatureCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer_Feature>))]
		Customer_FeatureCollection,
	}
	
	#endregion FeatureOptionChildEntityTypes
	
	#region FeatureOptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FeatureOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionFilterBuilder : SqlFilterBuilder<FeatureOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilterBuilder class.
		/// </summary>
		public FeatureOptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionFilterBuilder
	
	#region FeatureOptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FeatureOptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FeatureOption"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FeatureOptionParameterBuilder : ParameterizedSqlFilterBuilder<FeatureOptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FeatureOptionParameterBuilder class.
		/// </summary>
		public FeatureOptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FeatureOptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FeatureOptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FeatureOptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FeatureOptionParameterBuilder
} // end namespace
