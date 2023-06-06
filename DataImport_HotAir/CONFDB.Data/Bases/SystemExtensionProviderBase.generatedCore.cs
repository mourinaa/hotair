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
	/// This class is the base class for any <see cref="SystemExtensionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SystemExtensionProviderBaseCore : EntityProviderBase<CONFDB.Entities.SystemExtension, CONFDB.Entities.SystemExtensionKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionKey key)
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
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		FK_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="_systemExtensionLabelId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		public CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(System.Int32 _systemExtensionLabelId)
		{
			int count = -1;
			return GetBySystemExtensionLabelId(_systemExtensionLabelId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		FK_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId)
		{
			int count = -1;
			return GetBySystemExtensionLabelId(transactionManager, _systemExtensionLabelId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		FK_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		public CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId, int start, int pageLength)
		{
			int count = -1;
			return GetBySystemExtensionLabelId(transactionManager, _systemExtensionLabelId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		fk_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		public CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(System.Int32 _systemExtensionLabelId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySystemExtensionLabelId(null, _systemExtensionLabelId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		fk_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		public CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(System.Int32 _systemExtensionLabelId, int start, int pageLength,out int count)
		{
			return GetBySystemExtensionLabelId(null, _systemExtensionLabelId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SystemExtension_SystemExtensionLabel key.
		///		FK_SystemExtension_SystemExtensionLabel Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.SystemExtension objects.</returns>
		public abstract CONFDB.Entities.TList<SystemExtension> GetBySystemExtensionLabelId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.SystemExtension Get(TransactionManager transactionManager, CONFDB.Entities.SystemExtensionKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ModeratorExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ModeratorExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ModeratorExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ModeratorExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ModeratorExtension index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ModeratorExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public abstract CONFDB.Entities.SystemExtension GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SystemExtension index.
		/// </summary>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(System.Int32 _systemExtensionLabelId, System.Int32 _tableId)
		{
			int count = -1;
			return GetBySystemExtensionLabelIdTableId(null,_systemExtensionLabelId, _tableId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtension index.
		/// </summary>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(System.Int32 _systemExtensionLabelId, System.Int32 _tableId, int start, int pageLength)
		{
			int count = -1;
			return GetBySystemExtensionLabelIdTableId(null, _systemExtensionLabelId, _tableId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId, System.Int32 _tableId)
		{
			int count = -1;
			return GetBySystemExtensionLabelIdTableId(transactionManager, _systemExtensionLabelId, _tableId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId, System.Int32 _tableId, int start, int pageLength)
		{
			int count = -1;
			return GetBySystemExtensionLabelIdTableId(transactionManager, _systemExtensionLabelId, _tableId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtension index.
		/// </summary>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(System.Int32 _systemExtensionLabelId, System.Int32 _tableId, int start, int pageLength, out int count)
		{
			return GetBySystemExtensionLabelIdTableId(null, _systemExtensionLabelId, _tableId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SystemExtension index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_systemExtensionLabelId"></param>
		/// <param name="_tableId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.SystemExtension"/> class.</returns>
		public abstract CONFDB.Entities.SystemExtension GetBySystemExtensionLabelIdTableId(TransactionManager transactionManager, System.Int32 _systemExtensionLabelId, System.Int32 _tableId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_SystemExtension_AddSystemExtension 
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_AddSystemExtension' stored procedure. 
		/// </summary>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tableId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddSystemExtension(System.Int32? extensionTypeCategoryId, System.Int32? customerId, System.Int32? tableId)
		{
			 AddSystemExtension(null, 0, int.MaxValue , extensionTypeCategoryId, customerId, tableId);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_AddSystemExtension' stored procedure. 
		/// </summary>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tableId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddSystemExtension(int start, int pageLength, System.Int32? extensionTypeCategoryId, System.Int32? customerId, System.Int32? tableId)
		{
			 AddSystemExtension(null, start, pageLength , extensionTypeCategoryId, customerId, tableId);
		}
				
		/// <summary>
		///	This method wrap the 'p_SystemExtension_AddSystemExtension' stored procedure. 
		/// </summary>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tableId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddSystemExtension(TransactionManager transactionManager, System.Int32? extensionTypeCategoryId, System.Int32? customerId, System.Int32? tableId)
		{
			 AddSystemExtension(transactionManager, 0, int.MaxValue , extensionTypeCategoryId, customerId, tableId);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_AddSystemExtension' stored procedure. 
		/// </summary>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tableId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void AddSystemExtension(TransactionManager transactionManager, int start, int pageLength , System.Int32? extensionTypeCategoryId, System.Int32? customerId, System.Int32? tableId);
		
		#endregion
		
		#region p_SystemExtension_EditReferenceValueByID 
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_EditReferenceValueByID' stored procedure. 
		/// </summary>
		/// <param name="systemExtensionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceValue"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void EditReferenceValueByID(System.Int32? systemExtensionId, System.String referenceValue)
		{
			 EditReferenceValueByID(null, 0, int.MaxValue , systemExtensionId, referenceValue);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_EditReferenceValueByID' stored procedure. 
		/// </summary>
		/// <param name="systemExtensionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceValue"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void EditReferenceValueByID(int start, int pageLength, System.Int32? systemExtensionId, System.String referenceValue)
		{
			 EditReferenceValueByID(null, start, pageLength , systemExtensionId, referenceValue);
		}
				
		/// <summary>
		///	This method wrap the 'p_SystemExtension_EditReferenceValueByID' stored procedure. 
		/// </summary>
		/// <param name="systemExtensionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceValue"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void EditReferenceValueByID(TransactionManager transactionManager, System.Int32? systemExtensionId, System.String referenceValue)
		{
			 EditReferenceValueByID(transactionManager, 0, int.MaxValue , systemExtensionId, referenceValue);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_EditReferenceValueByID' stored procedure. 
		/// </summary>
		/// <param name="systemExtensionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referenceValue"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void EditReferenceValueByID(TransactionManager transactionManager, int start, int pageLength , System.Int32? systemExtensionId, System.String referenceValue);
		
		#endregion
		
		#region p_SystemExtension_GetSystemExtensionForModerator 
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_GetSystemExtensionForModerator' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemExtensionForModerator(System.Int32? customerId, System.Int32? moderatorId, System.Int32? extensionTypeId, System.Int32? extensionTypeCategoryId)
		{
			return GetSystemExtensionForModerator(null, 0, int.MaxValue , customerId, moderatorId, extensionTypeId, extensionTypeCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_GetSystemExtensionForModerator' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemExtensionForModerator(int start, int pageLength, System.Int32? customerId, System.Int32? moderatorId, System.Int32? extensionTypeId, System.Int32? extensionTypeCategoryId)
		{
			return GetSystemExtensionForModerator(null, start, pageLength , customerId, moderatorId, extensionTypeId, extensionTypeCategoryId);
		}
				
		/// <summary>
		///	This method wrap the 'p_SystemExtension_GetSystemExtensionForModerator' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemExtensionForModerator(TransactionManager transactionManager, System.Int32? customerId, System.Int32? moderatorId, System.Int32? extensionTypeId, System.Int32? extensionTypeCategoryId)
		{
			return GetSystemExtensionForModerator(transactionManager, 0, int.MaxValue , customerId, moderatorId, extensionTypeId, extensionTypeCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'p_SystemExtension_GetSystemExtensionForModerator' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="extensionTypeCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSystemExtensionForModerator(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.Int32? moderatorId, System.Int32? extensionTypeId, System.Int32? extensionTypeCategoryId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;SystemExtension&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;SystemExtension&gt;"/></returns>
		public static CONFDB.Entities.TList<SystemExtension> Fill(IDataReader reader, CONFDB.Entities.TList<SystemExtension> rows, int start, int pageLength)
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
				
				CONFDB.Entities.SystemExtension c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SystemExtension")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.SystemExtensionColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.SystemExtensionColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<SystemExtension>(
					key.ToString(), // EntityTrackingKey
					"SystemExtension",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.SystemExtension();
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
					c.Id = (System.Int32)reader[((int)SystemExtensionColumn.Id - 1)];
					c.TableId = (System.Int32)reader[((int)SystemExtensionColumn.TableId - 1)];
					c.ReferenceValue = (System.String)reader[((int)SystemExtensionColumn.ReferenceValue - 1)];
					c.SystemExtensionLabelId = (System.Int32)reader[((int)SystemExtensionColumn.SystemExtensionLabelId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SystemExtension"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtension"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.SystemExtension entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)SystemExtensionColumn.Id - 1)];
			entity.TableId = (System.Int32)reader[((int)SystemExtensionColumn.TableId - 1)];
			entity.ReferenceValue = (System.String)reader[((int)SystemExtensionColumn.ReferenceValue - 1)];
			entity.SystemExtensionLabelId = (System.Int32)reader[((int)SystemExtensionColumn.SystemExtensionLabelId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.SystemExtension"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtension"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.SystemExtension entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["id"];
			entity.TableId = (System.Int32)dataRow["TableID"];
			entity.ReferenceValue = (System.String)dataRow["ReferenceValue"];
			entity.SystemExtensionLabelId = (System.Int32)dataRow["SystemExtensionLabelID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.SystemExtension"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.SystemExtension Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.SystemExtension entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SystemExtensionLabelIdSource	
			if (CanDeepLoad(entity, "SystemExtensionLabel|SystemExtensionLabelIdSource", deepLoadType, innerList) 
				&& entity.SystemExtensionLabelIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SystemExtensionLabelId;
				SystemExtensionLabel tmpEntity = EntityManager.LocateEntity<SystemExtensionLabel>(EntityLocator.ConstructKeyFromPkItems(typeof(SystemExtensionLabel), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SystemExtensionLabelIdSource = tmpEntity;
				else
					entity.SystemExtensionLabelIdSource = DataRepository.SystemExtensionLabelProvider.GetById(transactionManager, entity.SystemExtensionLabelId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SystemExtensionLabelIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SystemExtensionLabelIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SystemExtensionLabelProvider.DeepLoad(transactionManager, entity.SystemExtensionLabelIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SystemExtensionLabelIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.SystemExtension object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.SystemExtension instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.SystemExtension Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.SystemExtension entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SystemExtensionLabelIdSource
			if (CanDeepSave(entity, "SystemExtensionLabel|SystemExtensionLabelIdSource", deepSaveType, innerList) 
				&& entity.SystemExtensionLabelIdSource != null)
			{
				DataRepository.SystemExtensionLabelProvider.Save(transactionManager, entity.SystemExtensionLabelIdSource);
				entity.SystemExtensionLabelId = entity.SystemExtensionLabelIdSource.Id;
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
	
	#region SystemExtensionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.SystemExtension</c>
	///</summary>
	public enum SystemExtensionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SystemExtensionLabel</c> at SystemExtensionLabelIdSource
		///</summary>
		[ChildEntityType(typeof(SystemExtensionLabel))]
		SystemExtensionLabel,
		}
	
	#endregion SystemExtensionChildEntityTypes
	
	#region SystemExtensionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SystemExtensionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionFilterBuilder : SqlFilterBuilder<SystemExtensionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilterBuilder class.
		/// </summary>
		public SystemExtensionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionFilterBuilder
	
	#region SystemExtensionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SystemExtensionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SystemExtension"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SystemExtensionParameterBuilder : ParameterizedSqlFilterBuilder<SystemExtensionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SystemExtensionParameterBuilder class.
		/// </summary>
		public SystemExtensionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SystemExtensionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SystemExtensionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SystemExtensionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SystemExtensionParameterBuilder
} // end namespace
