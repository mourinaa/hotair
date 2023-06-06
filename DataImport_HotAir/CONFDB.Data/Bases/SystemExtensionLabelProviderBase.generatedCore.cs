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
	/// This class is the base class for any <see cref="SystemExtensionLabelProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SystemExtensionLabelProviderBaseCore : EntityProviderBase<CONFDB.Entities.SystemExtensionLabel, CONFDB.Entities.SystemExtensionLabelKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionLabelKey key)
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
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		FK_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="_extensionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(System.Int32 _extensionTypeId)
		{
			int count = -1;
			return GetByExtensionTypeId(_extensionTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		FK_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(TransactionManager transactionManager, System.Int32 _extensionTypeId)
		{
			int count = -1;
			return GetByExtensionTypeId(transactionManager, _extensionTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		FK_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(TransactionManager transactionManager, System.Int32 _extensionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByExtensionTypeId(transactionManager, _extensionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		fk_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_extensionTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(System.Int32 _extensionTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByExtensionTypeId(null, _extensionTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		fk_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_extensionTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(System.Int32 _extensionTypeId, int start, int pageLength,out int count)
		{
			return GetByExtensionTypeId(null, _extensionTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_ExtensionType key.
		///		FK_SystemExtension_ExtensionType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_extensionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtensionLabel objects.</returns>
		public abstract CONFDB.Entities.TList<SystemExtensionLabel> GetByExtensionTypeId(TransactionManager transactionManager, System.Int32 _extensionTypeId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.SystemExtensionLabel Get(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionLabelKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SystemExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public CONFDB.Entities.SystemExtensionLabel GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SystemExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public CONFDB.Entities.SystemExtensionLabel GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public CONFDB.Entities.SystemExtensionLabel GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public CONFDB.Entities.SystemExtensionLabel GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SystemExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public CONFDB.Entities.SystemExtensionLabel GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtensionLabel"/> class.</returns>
		public abstract CONFDB.Entities.SystemExtensionLabel GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(System.Int32 _customerId, System.Boolean _customerCanView)
		{
			int count = -1;
			return GetByCustomerIdCustomerCanView(null,_customerId, _customerCanView, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(System.Int32 _customerId, System.Boolean _customerCanView, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdCustomerCanView(null, _customerId, _customerCanView, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _customerCanView)
		{
			int count = -1;
			return GetByCustomerIdCustomerCanView(transactionManager, _customerId, _customerCanView, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _customerCanView, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdCustomerCanView(transactionManager, _customerId, _customerCanView, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(System.Int32 _customerId, System.Boolean _customerCanView, int start, int pageLength, out int count)
		{
			return GetByCustomerIdCustomerCanView(null, _customerId, _customerCanView, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_CustomerCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdCustomerCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _customerCanView, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(System.Int32 _customerId, System.Boolean _moderatorCanView)
		{
			int count = -1;
			return GetByCustomerIdModeratorCanView(null,_customerId, _moderatorCanView, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(System.Int32 _customerId, System.Boolean _moderatorCanView, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdModeratorCanView(null, _customerId, _moderatorCanView, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _moderatorCanView)
		{
			int count = -1;
			return GetByCustomerIdModeratorCanView(transactionManager, _customerId, _moderatorCanView, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _moderatorCanView, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdModeratorCanView(transactionManager, _customerId, _moderatorCanView, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(System.Int32 _customerId, System.Boolean _moderatorCanView, int start, int pageLength, out int count)
		{
			return GetByCustomerIdModeratorCanView(null, _customerId, _moderatorCanView, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtensionLabel_ModeratorCanView index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_moderatorCanView"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<SystemExtensionLabel> GetByCustomerIdModeratorCanView(TransactionManager transactionManager, System.Int32 _customerId, System.Boolean _moderatorCanView, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;SystemExtensionLabel&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;SystemExtensionLabel&gt;"/></returns>
		public static CONFDB.Entities.TList<SystemExtensionLabel> Fill(IDataReader reader, CONFDB.Entities.TList<SystemExtensionLabel> rows, int start, int pageLength)
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
				
				CONFDB.Entities.SystemExtensionLabel c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SystemExtensionLabel")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.SystemExtensionLabelColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.SystemExtensionLabelColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<SystemExtensionLabel>(
					key.ToString(), // EntityTrackingKey
					"SystemExtensionLabel",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.SystemExtensionLabel();
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
					c.Id = (System.Int32)reader[((int)SystemExtensionLabelColumn.Id - 1)];
					c.CustomerId = (System.Int32)reader[((int)SystemExtensionLabelColumn.CustomerId - 1)];
					c.ExtensionTypeId = (System.Int32)reader[((int)SystemExtensionLabelColumn.ExtensionTypeId - 1)];
					c.ExtensionTypeLabel = (System.String)reader[((int)SystemExtensionLabelColumn.ExtensionTypeLabel - 1)];
					c.CustomerCanView = (System.Boolean)reader[((int)SystemExtensionLabelColumn.CustomerCanView - 1)];
					c.ModeratorCanView = (System.Boolean)reader[((int)SystemExtensionLabelColumn.ModeratorCanView - 1)];
					c.CustomerCanEdit = (System.Boolean)reader[((int)SystemExtensionLabelColumn.CustomerCanEdit - 1)];
					c.ModeratorCanEdit = (System.Boolean)reader[((int)SystemExtensionLabelColumn.ModeratorCanEdit - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SystemExtensionLabel"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtensionLabel"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.SystemExtensionLabel entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)SystemExtensionLabelColumn.Id - 1)];
			entity.CustomerId = (System.Int32)reader[((int)SystemExtensionLabelColumn.CustomerId - 1)];
			entity.ExtensionTypeId = (System.Int32)reader[((int)SystemExtensionLabelColumn.ExtensionTypeId - 1)];
			entity.ExtensionTypeLabel = (System.String)reader[((int)SystemExtensionLabelColumn.ExtensionTypeLabel - 1)];
			entity.CustomerCanView = (System.Boolean)reader[((int)SystemExtensionLabelColumn.CustomerCanView - 1)];
			entity.ModeratorCanView = (System.Boolean)reader[((int)SystemExtensionLabelColumn.ModeratorCanView - 1)];
			entity.CustomerCanEdit = (System.Boolean)reader[((int)SystemExtensionLabelColumn.CustomerCanEdit - 1)];
			entity.ModeratorCanEdit = (System.Boolean)reader[((int)SystemExtensionLabelColumn.ModeratorCanEdit - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SystemExtensionLabel"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtensionLabel"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.SystemExtensionLabel entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.ExtensionTypeId = (System.Int32)dataRow["ExtensionTypeID"];
			entity.ExtensionTypeLabel = (System.String)dataRow["ExtensionTypeLabel"];
			entity.CustomerCanView = (System.Boolean)dataRow["CustomerCanView"];
			entity.ModeratorCanView = (System.Boolean)dataRow["ModeratorCanView"];
			entity.CustomerCanEdit = (System.Boolean)dataRow["CustomerCanEdit"];
			entity.ModeratorCanEdit = (System.Boolean)dataRow["ModeratorCanEdit"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtensionLabel"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.SystemExtensionLabel Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionLabel entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ExtensionTypeIdSource	
			if (CanDeepLoad(entity, "ExtensionType|ExtensionTypeIdSource", deepLoadType, innerList) 
				&& entity.ExtensionTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ExtensionTypeId;
				ExtensionType tmpEntity = EntityManager.LocateEntity<ExtensionType>(EntityLocator.ConstructKeyFromPkItems(typeof(ExtensionType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ExtensionTypeIdSource = tmpEntity;
				else
					entity.ExtensionTypeIdSource = DataRepository.ExtensionTypeProvider.GetById(transactionManager, entity.ExtensionTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ExtensionTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ExtensionTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ExtensionTypeProvider.DeepLoad(transactionManager, entity.ExtensionTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ExtensionTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region SystemExtensionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SystemExtension>|SystemExtensionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SystemExtensionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SystemExtensionCollection = DataRepository.SystemExtensionProvider.GetBySystemExtensionLabelId(transactionManager, entity.Id);

				if (deep && entity.SystemExtensionCollection.Count > 0)
				{
					deepHandles.Add("SystemExtensionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SystemExtension>) DataRepository.SystemExtensionProvider.DeepLoad,
						new object[] { transactionManager, entity.SystemExtensionCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.SystemExtensionLabel object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.SystemExtensionLabel instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.SystemExtensionLabel Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionLabel entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ExtensionTypeIdSource
			if (CanDeepSave(entity, "ExtensionType|ExtensionTypeIdSource", deepSaveType, innerList) 
				&& entity.ExtensionTypeIdSource != null)
			{
				DataRepository.ExtensionTypeProvider.Save(transactionManager, entity.ExtensionTypeIdSource);
				entity.ExtensionTypeId = entity.ExtensionTypeIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SystemExtension>
				if (CanDeepSave(entity.SystemExtensionCollection, "List<SystemExtension>|SystemExtensionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SystemExtension child in entity.SystemExtensionCollection)
					{
						if(child.SystemExtensionLabelIdSource != null)
						{
							child.SystemExtensionLabelId = child.SystemExtensionLabelIdSource.Id;
						}
						else
						{
							child.SystemExtensionLabelId = entity.Id;
						}

					}

					if (entity.SystemExtensionCollection.Count > 0 || entity.SystemExtensionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SystemExtensionProvider.Save(transactionManager, entity.SystemExtensionCollection);
						
						deepHandles.Add("SystemExtensionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SystemExtension >) DataRepository.SystemExtensionProvider.DeepSave,
							new object[] { transactionManager, entity.SystemExtensionCollection, deepSaveType, childTypes, innerList }
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
	
	#region SystemExtensionLabelChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.SystemExtensionLabel</c>
	///</summary>
	public enum SystemExtensionLabelChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ExtensionType</c> at ExtensionTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ExtensionType))]
		ExtensionType,
	
		///<summary>
		/// Collection of <c>SystemExtensionLabel</c> as OneToMany for SystemExtensionCollection
		///</summary>
		[ChildEntityType(typeof(TList<SystemExtension>))]
		SystemExtensionCollection,
	}
	
	#endregion SystemExtensionLabelChildEntityTypes
	
	#region SystemExtensionLabelFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SystemExtensionLabelColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelFilterBuilder : SqlFilterBuilder<SystemExtensionLabelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilterBuilder class.
		/// </summary>
		public SystemExtensionLabelFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionLabelFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionLabelFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionLabelFilterBuilder
	
	#region SystemExtensionLabelParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SystemExtensionLabelColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtensionLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionLabelParameterBuilder : ParameterizedSqlFilterBuilder<SystemExtensionLabelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelParameterBuilder class.
		/// </summary>
		public SystemExtensionLabelParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionLabelParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionLabelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionLabelParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionLabelParameterBuilder
} // end namespace
