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
	/// This class is the base class for any <see cref="CustomerTransactionTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerTransactionTypeProviderBaseCore : EntityProviderBase<CONFDB.Entities.CustomerTransactionType, CONFDB.Entities.CustomerTransactionTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionTypeKey key)
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
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		FK_CustomerTransactionType_GLPostingType Description: 
		/// </summary>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(System.Int32? _glPostingTypeId)
		{
			int count = -1;
			return GetByGlPostingTypeId(_glPostingTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		FK_CustomerTransactionType_GLPostingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(TransactionManager transactionManager, System.Int32? _glPostingTypeId)
		{
			int count = -1;
			return GetByGlPostingTypeId(transactionManager, _glPostingTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		FK_CustomerTransactionType_GLPostingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(TransactionManager transactionManager, System.Int32? _glPostingTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByGlPostingTypeId(transactionManager, _glPostingTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		fk_CustomerTransactionType_GlPostingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(System.Int32? _glPostingTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGlPostingTypeId(null, _glPostingTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		fk_CustomerTransactionType_GlPostingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(System.Int32? _glPostingTypeId, int start, int pageLength,out int count)
		{
			return GetByGlPostingTypeId(null, _glPostingTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerTransactionType_GLPostingType key.
		///		FK_CustomerTransactionType_GLPostingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_glPostingTypeId">Accounting categories used to group transactions together based on similar posting logic. i.e. all credits, charges, etc</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CustomerTransactionType objects.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransactionType> GetByGlPostingTypeId(TransactionManager transactionManager, System.Int32? _glPostingTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CustomerTransactionType Get(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionTypeKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionType GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionType GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionType GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public CONFDB.Entities.CustomerTransactionType GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerTransactionType_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CustomerTransactionType"/> class.</returns>
		public abstract CONFDB.Entities.CustomerTransactionType GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByName(System.String _name)
		{
			int count = -1;
			return GetByName(null,_name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByName(System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByName(TransactionManager transactionManager, System.String _name)
		{
			int count = -1;
			return GetByName(transactionManager, _name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, _name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByName(System.String _name, int start, int pageLength, out int count)
		{
			return GetByName(null, _name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransactionType> GetByName(TransactionManager transactionManager, System.String _name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(System.Int32? _actionValue)
		{
			int count = -1;
			return GetByActionValue(null,_actionValue, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(System.Int32? _actionValue, int start, int pageLength)
		{
			int count = -1;
			return GetByActionValue(null, _actionValue, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(TransactionManager transactionManager, System.Int32? _actionValue)
		{
			int count = -1;
			return GetByActionValue(transactionManager, _actionValue, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(TransactionManager transactionManager, System.Int32? _actionValue, int start, int pageLength)
		{
			int count = -1;
			return GetByActionValue(transactionManager, _actionValue, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(System.Int32? _actionValue, int start, int pageLength, out int count)
		{
			return GetByActionValue(null, _actionValue, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CustomerTransactionType_ActionValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionValue">Used when importing a batch file. The Action numbers are used by end users to specify the type of transaction they are posting. Easier to standardize.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<CustomerTransactionType> GetByActionValue(TransactionManager transactionManager, System.Int32? _actionValue, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CustomerTransactionType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CustomerTransactionType&gt;"/></returns>
		public static CONFDB.Entities.TList<CustomerTransactionType> Fill(IDataReader reader, CONFDB.Entities.TList<CustomerTransactionType> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CustomerTransactionType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerTransactionType")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CustomerTransactionTypeColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CustomerTransactionTypeColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CustomerTransactionType>(
					key.ToString(), // EntityTrackingKey
					"CustomerTransactionType",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CustomerTransactionType();
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
					c.Id = (System.Int32)reader[((int)CustomerTransactionTypeColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Name - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Description - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.Description - 1)];
					c.DisplayName = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.DisplayName - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.DisplayName - 1)];
					c.GlPostingTypeId = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.GlPostingTypeId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.GlPostingTypeId - 1)];
					c.ActionValue = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.ActionValue - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.ActionValue - 1)];
					c.DisplayOrder = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.DisplayOrder - 1)];
					c.Visible = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Visible - 1)))?null:(System.Boolean?)reader[((int)CustomerTransactionTypeColumn.Visible - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransactionType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CustomerTransactionType entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomerTransactionTypeColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Name - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Description - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.Description - 1)];
			entity.DisplayName = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.DisplayName - 1)))?null:(System.String)reader[((int)CustomerTransactionTypeColumn.DisplayName - 1)];
			entity.GlPostingTypeId = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.GlPostingTypeId - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.GlPostingTypeId - 1)];
			entity.ActionValue = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.ActionValue - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.ActionValue - 1)];
			entity.DisplayOrder = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.DisplayOrder - 1)))?null:(System.Int32?)reader[((int)CustomerTransactionTypeColumn.DisplayOrder - 1)];
			entity.Visible = (reader.IsDBNull(((int)CustomerTransactionTypeColumn.Visible - 1)))?null:(System.Boolean?)reader[((int)CustomerTransactionTypeColumn.Visible - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CustomerTransactionType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CustomerTransactionType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.DisplayName = Convert.IsDBNull(dataRow["DisplayName"]) ? null : (System.String)dataRow["DisplayName"];
			entity.GlPostingTypeId = Convert.IsDBNull(dataRow["GLPostingTypeID"]) ? null : (System.Int32?)dataRow["GLPostingTypeID"];
			entity.ActionValue = Convert.IsDBNull(dataRow["ActionValue"]) ? null : (System.Int32?)dataRow["ActionValue"];
			entity.DisplayOrder = Convert.IsDBNull(dataRow["DisplayOrder"]) ? null : (System.Int32?)dataRow["DisplayOrder"];
			entity.Visible = Convert.IsDBNull(dataRow["Visible"]) ? null : (System.Boolean?)dataRow["Visible"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CustomerTransactionType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransactionType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region GlPostingTypeIdSource	
			if (CanDeepLoad(entity, "GlPostingType|GlPostingTypeIdSource", deepLoadType, innerList) 
				&& entity.GlPostingTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GlPostingTypeId ?? (int)0);
				GlPostingType tmpEntity = EntityManager.LocateEntity<GlPostingType>(EntityLocator.ConstructKeyFromPkItems(typeof(GlPostingType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GlPostingTypeIdSource = tmpEntity;
				else
					entity.GlPostingTypeIdSource = DataRepository.GlPostingTypeProvider.GetById(transactionManager, (entity.GlPostingTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlPostingTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GlPostingTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.GlPostingTypeProvider.DeepLoad(transactionManager, entity.GlPostingTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GlPostingTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerTransactionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerTransaction>|CustomerTransactionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTransactionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerTransactionCollection = DataRepository.CustomerTransactionProvider.GetByCustomerTransactionTypeId(transactionManager, entity.Id);

				if (deep && entity.CustomerTransactionCollection.Count > 0)
				{
					deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerTransaction>) DataRepository.CustomerTransactionProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTransactionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CustomerTransactionType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CustomerTransactionType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CustomerTransactionType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CustomerTransactionType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GlPostingTypeIdSource
			if (CanDeepSave(entity, "GlPostingType|GlPostingTypeIdSource", deepSaveType, innerList) 
				&& entity.GlPostingTypeIdSource != null)
			{
				DataRepository.GlPostingTypeProvider.Save(transactionManager, entity.GlPostingTypeIdSource);
				entity.GlPostingTypeId = entity.GlPostingTypeIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<CustomerTransaction>
				if (CanDeepSave(entity.CustomerTransactionCollection, "List<CustomerTransaction>|CustomerTransactionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerTransaction child in entity.CustomerTransactionCollection)
					{
						if(child.CustomerTransactionTypeIdSource != null)
						{
							child.CustomerTransactionTypeId = child.CustomerTransactionTypeIdSource.Id;
						}
						else
						{
							child.CustomerTransactionTypeId = entity.Id;
						}

					}

					if (entity.CustomerTransactionCollection.Count > 0 || entity.CustomerTransactionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerTransactionProvider.Save(transactionManager, entity.CustomerTransactionCollection);
						
						deepHandles.Add("CustomerTransactionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerTransaction >) DataRepository.CustomerTransactionProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerTransactionCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomerTransactionTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CustomerTransactionType</c>
	///</summary>
	public enum CustomerTransactionTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>GlPostingType</c> at GlPostingTypeIdSource
		///</summary>
		[ChildEntityType(typeof(GlPostingType))]
		GlPostingType,
	
		///<summary>
		/// Collection of <c>CustomerTransactionType</c> as OneToMany for CustomerTransactionCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerTransaction>))]
		CustomerTransactionCollection,
	}
	
	#endregion CustomerTransactionTypeChildEntityTypes
	
	#region CustomerTransactionTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerTransactionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeFilterBuilder : SqlFilterBuilder<CustomerTransactionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilterBuilder class.
		/// </summary>
		public CustomerTransactionTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionTypeFilterBuilder
	
	#region CustomerTransactionTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerTransactionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerTransactionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerTransactionTypeParameterBuilder : ParameterizedSqlFilterBuilder<CustomerTransactionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeParameterBuilder class.
		/// </summary>
		public CustomerTransactionTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerTransactionTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerTransactionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerTransactionTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerTransactionTypeParameterBuilder
} // end namespace
