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
	/// This class is the base class for any <see cref="UtilProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UtilProviderBaseCore : EntityProviderBase<CONFDB.Entities.Util, CONFDB.Entities.UtilKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.UtilKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.. Primary Key.</param>
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
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.. Primary Key.</param>
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
		public override CONFDB.Entities.Util Get(TransactionManager transactionManager, CONFDB.Entities.UtilKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_UTIL index.
		/// </summary>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public CONFDB.Entities.Util GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UTIL index.
		/// </summary>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public CONFDB.Entities.Util GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UTIL index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public CONFDB.Entities.Util GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UTIL index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public CONFDB.Entities.Util GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UTIL index.
		/// </summary>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public CONFDB.Entities.Util GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UTIL index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">NOT A REAL TABLE. Just Used to Gen. UTIL SP's that can be called from NTier Objects.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Util"/> class.</returns>
		public abstract CONFDB.Entities.Util GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_UTIL_BulkEditProductFeatures 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductFeatures(System.Int32? featureId, System.Int32? featureOptionId, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			 BulkEditProductFeatures(null, 0, int.MaxValue , featureId, featureOptionId, bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductFeatures(int start, int pageLength, System.Int32? featureId, System.Int32? featureOptionId, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			 BulkEditProductFeatures(null, start, pageLength , featureId, featureOptionId, bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductFeatures(TransactionManager transactionManager, System.Int32? featureId, System.Int32? featureOptionId, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			 BulkEditProductFeatures(transactionManager, 0, int.MaxValue , featureId, featureOptionId, bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductFeatures' stored procedure. 
		/// </summary>
		/// <param name="featureId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="featureOptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void BulkEditProductFeatures(TransactionManager transactionManager, int start, int pageLength , System.Int32? featureId, System.Int32? featureOptionId, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId);
		
		#endregion
		
		#region p_UTIL_Accounting_ExportPaymentReversals 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPaymentReversals' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPaymentReversals(System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPaymentReversals(null, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPaymentReversals' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPaymentReversals(int start, int pageLength, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPaymentReversals(null, start, pageLength , wholesalerId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPaymentReversals' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPaymentReversals(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPaymentReversals(transactionManager, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPaymentReversals' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Accounting_ExportPaymentReversals(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? invoiceDate);
		
		#endregion
		
		#region p_UTIL_INV_DoBillingRun 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_DoBillingRun' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_DoBillingRun(System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_DoBillingRun(null, 0, int.MaxValue , startDate, endDate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_DoBillingRun' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_DoBillingRun(int start, int pageLength, System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_DoBillingRun(null, start, pageLength , startDate, endDate, wholesalerId, billingPeriodCutoff);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_DoBillingRun' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_DoBillingRun(TransactionManager transactionManager, System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_DoBillingRun(transactionManager, 0, int.MaxValue , startDate, endDate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_DoBillingRun' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_DoBillingRun(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutoff);
		
		#endregion
		
		#region p_UTIL_GeneratePassword 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GeneratePassword' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GeneratePassword(System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? passwordLength, ref System.String password)
		{
			 GeneratePassword(null, 0, int.MaxValue , wholesalerId, customerId, moderatorId, passwordLength, ref password);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GeneratePassword' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GeneratePassword(int start, int pageLength, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? passwordLength, ref System.String password)
		{
			 GeneratePassword(null, start, pageLength , wholesalerId, customerId, moderatorId, passwordLength, ref password);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_GeneratePassword' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GeneratePassword(TransactionManager transactionManager, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? passwordLength, ref System.String password)
		{
			 GeneratePassword(transactionManager, 0, int.MaxValue , wholesalerId, customerId, moderatorId, passwordLength, ref password);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GeneratePassword' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int32?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GeneratePassword(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? passwordLength, ref System.String password);
		
		#endregion
		
		#region p_UTIL_INV_Mark_BillableCDRSEnd 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSEnd' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSEnd()
		{
			 INV_Mark_BillableCDRSEnd(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSEnd' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSEnd(int start, int pageLength)
		{
			 INV_Mark_BillableCDRSEnd(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSEnd' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSEnd(TransactionManager transactionManager)
		{
			 INV_Mark_BillableCDRSEnd(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSEnd' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_Mark_BillableCDRSEnd(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_UTIL_INV_PostMonthlyCharges 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_PostMonthlyCharges' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="postedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_PostMonthlyCharges(System.String wholesalerId, System.DateTime? postedDate)
		{
			 INV_PostMonthlyCharges(null, 0, int.MaxValue , wholesalerId, postedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_PostMonthlyCharges' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="postedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_PostMonthlyCharges(int start, int pageLength, System.String wholesalerId, System.DateTime? postedDate)
		{
			 INV_PostMonthlyCharges(null, start, pageLength , wholesalerId, postedDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_PostMonthlyCharges' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="postedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_PostMonthlyCharges(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? postedDate)
		{
			 INV_PostMonthlyCharges(transactionManager, 0, int.MaxValue , wholesalerId, postedDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_PostMonthlyCharges' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="postedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_PostMonthlyCharges(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? postedDate);
		
		#endregion
		
		#region p_UTIL_PopulateTrends 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateTrends' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateTrends()
		{
			 PopulateTrends(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateTrends' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateTrends(int start, int pageLength)
		{
			 PopulateTrends(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateTrends' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateTrends(TransactionManager transactionManager)
		{
			 PopulateTrends(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateTrends' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void PopulateTrends(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_UTIL_TestUserCodes 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_TestUserCodes' stored procedure. 
		/// </summary>
		/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
		/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="modCodeValid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="partCodeVaild"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void TestUserCodes(System.String moderatorCode, System.String passCode, System.Int32? moderatorId, ref System.Boolean? modCodeValid, ref System.Boolean? partCodeVaild)
		{
			 TestUserCodes(null, 0, int.MaxValue , moderatorCode, passCode, moderatorId, ref modCodeValid, ref partCodeVaild);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_TestUserCodes' stored procedure. 
		/// </summary>
		/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
		/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="modCodeValid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="partCodeVaild"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void TestUserCodes(int start, int pageLength, System.String moderatorCode, System.String passCode, System.Int32? moderatorId, ref System.Boolean? modCodeValid, ref System.Boolean? partCodeVaild)
		{
			 TestUserCodes(null, start, pageLength , moderatorCode, passCode, moderatorId, ref modCodeValid, ref partCodeVaild);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_TestUserCodes' stored procedure. 
		/// </summary>
		/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
		/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="modCodeValid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="partCodeVaild"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void TestUserCodes(TransactionManager transactionManager, System.String moderatorCode, System.String passCode, System.Int32? moderatorId, ref System.Boolean? modCodeValid, ref System.Boolean? partCodeVaild)
		{
			 TestUserCodes(transactionManager, 0, int.MaxValue , moderatorCode, passCode, moderatorId, ref modCodeValid, ref partCodeVaild);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_TestUserCodes' stored procedure. 
		/// </summary>
		/// <param name="moderatorCode"> A <c>System.String</c> instance.</param>
		/// <param name="passCode"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="modCodeValid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="partCodeVaild"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void TestUserCodes(TransactionManager transactionManager, int start, int pageLength , System.String moderatorCode, System.String passCode, System.Int32? moderatorId, ref System.Boolean? modCodeValid, ref System.Boolean? partCodeVaild);
		
		#endregion
		
		#region p_UTIL_INV_CalculateFreeCredits 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_CalculateFreeCredits' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_CalculateFreeCredits()
		{
			 INV_CalculateFreeCredits(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_CalculateFreeCredits' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_CalculateFreeCredits(int start, int pageLength)
		{
			 INV_CalculateFreeCredits(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_CalculateFreeCredits' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_CalculateFreeCredits(TransactionManager transactionManager)
		{
			 INV_CalculateFreeCredits(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_CalculateFreeCredits' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_CalculateFreeCredits(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_UTIL_MGMTRPT_RevenueByModerator2 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator2' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator2(System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator2(null, 0, int.MaxValue , startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator2' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator2(int start, int pageLength, System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator2(null, start, pageLength , startDate, endDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator2' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator2(TransactionManager transactionManager, System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator2(transactionManager, 0, int.MaxValue , startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator2' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet MGMTRPT_RevenueByModerator2(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.DateTime? endDate);
		
		#endregion
		
		#region p_UTIL_GenerateRandomString 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GenerateRandomString' stored procedure. 
		/// </summary>
		/// <param name="useNumbers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useLowerCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useUpperCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="charactersToUse"> A <c>System.String</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int16?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateRandomString(System.Boolean? useNumbers, System.Boolean? useLowerCase, System.Boolean? useUpperCase, System.String charactersToUse, System.Int16? passwordLength, ref System.String password)
		{
			 GenerateRandomString(null, 0, int.MaxValue , useNumbers, useLowerCase, useUpperCase, charactersToUse, passwordLength, ref password);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GenerateRandomString' stored procedure. 
		/// </summary>
		/// <param name="useNumbers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useLowerCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useUpperCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="charactersToUse"> A <c>System.String</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int16?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateRandomString(int start, int pageLength, System.Boolean? useNumbers, System.Boolean? useLowerCase, System.Boolean? useUpperCase, System.String charactersToUse, System.Int16? passwordLength, ref System.String password)
		{
			 GenerateRandomString(null, start, pageLength , useNumbers, useLowerCase, useUpperCase, charactersToUse, passwordLength, ref password);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_GenerateRandomString' stored procedure. 
		/// </summary>
		/// <param name="useNumbers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useLowerCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useUpperCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="charactersToUse"> A <c>System.String</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int16?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GenerateRandomString(TransactionManager transactionManager, System.Boolean? useNumbers, System.Boolean? useLowerCase, System.Boolean? useUpperCase, System.String charactersToUse, System.Int16? passwordLength, ref System.String password)
		{
			 GenerateRandomString(transactionManager, 0, int.MaxValue , useNumbers, useLowerCase, useUpperCase, charactersToUse, passwordLength, ref password);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GenerateRandomString' stored procedure. 
		/// </summary>
		/// <param name="useNumbers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useLowerCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useUpperCase"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="charactersToUse"> A <c>System.String</c> instance.</param>
		/// <param name="passwordLength"> A <c>System.Int16?</c> instance.</param>
			/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GenerateRandomString(TransactionManager transactionManager, int start, int pageLength , System.Boolean? useNumbers, System.Boolean? useLowerCase, System.Boolean? useUpperCase, System.String charactersToUse, System.Int16? passwordLength, ref System.String password);
		
		#endregion
		
		#region p_UTIL_CalculateTax 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_CalculateTax' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateName"> A <c>System.String</c> instance.</param>
			/// <param name="federalTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="federalTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localOnFederalTax"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="productRateTaxableValue"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customerTaxableValue"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CalculateTax(System.Int32? customerId, System.String priCustomerNumber, System.String wholesalerId, System.Decimal? amount, System.Int32? productRateId, System.String productRateName, ref System.Decimal? federalTaxRate, ref System.Decimal? localTaxRate, ref System.Decimal? federalTaxAmount, ref System.Decimal? localTaxAmount, ref System.Boolean? localOnFederalTax, ref System.Int32? productRateTaxableValue, ref System.Int32? customerTaxableValue)
		{
			 CalculateTax(null, 0, int.MaxValue , customerId, priCustomerNumber, wholesalerId, amount, productRateId, productRateName, ref federalTaxRate, ref localTaxRate, ref federalTaxAmount, ref localTaxAmount, ref localOnFederalTax, ref productRateTaxableValue, ref customerTaxableValue);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_CalculateTax' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateName"> A <c>System.String</c> instance.</param>
			/// <param name="federalTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="federalTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localOnFederalTax"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="productRateTaxableValue"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customerTaxableValue"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CalculateTax(int start, int pageLength, System.Int32? customerId, System.String priCustomerNumber, System.String wholesalerId, System.Decimal? amount, System.Int32? productRateId, System.String productRateName, ref System.Decimal? federalTaxRate, ref System.Decimal? localTaxRate, ref System.Decimal? federalTaxAmount, ref System.Decimal? localTaxAmount, ref System.Boolean? localOnFederalTax, ref System.Int32? productRateTaxableValue, ref System.Int32? customerTaxableValue)
		{
			 CalculateTax(null, start, pageLength , customerId, priCustomerNumber, wholesalerId, amount, productRateId, productRateName, ref federalTaxRate, ref localTaxRate, ref federalTaxAmount, ref localTaxAmount, ref localOnFederalTax, ref productRateTaxableValue, ref customerTaxableValue);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_CalculateTax' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateName"> A <c>System.String</c> instance.</param>
			/// <param name="federalTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="federalTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localOnFederalTax"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="productRateTaxableValue"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customerTaxableValue"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CalculateTax(TransactionManager transactionManager, System.Int32? customerId, System.String priCustomerNumber, System.String wholesalerId, System.Decimal? amount, System.Int32? productRateId, System.String productRateName, ref System.Decimal? federalTaxRate, ref System.Decimal? localTaxRate, ref System.Decimal? federalTaxAmount, ref System.Decimal? localTaxAmount, ref System.Boolean? localOnFederalTax, ref System.Int32? productRateTaxableValue, ref System.Int32? customerTaxableValue)
		{
			 CalculateTax(transactionManager, 0, int.MaxValue , customerId, priCustomerNumber, wholesalerId, amount, productRateId, productRateName, ref federalTaxRate, ref localTaxRate, ref federalTaxAmount, ref localTaxAmount, ref localOnFederalTax, ref productRateTaxableValue, ref customerTaxableValue);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_CalculateTax' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="productRateName"> A <c>System.String</c> instance.</param>
			/// <param name="federalTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxRate"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="federalTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localTaxAmount"> A <c>System.Decimal?</c> instance.</param>
			/// <param name="localOnFederalTax"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="productRateTaxableValue"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customerTaxableValue"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CalculateTax(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId, System.String priCustomerNumber, System.String wholesalerId, System.Decimal? amount, System.Int32? productRateId, System.String productRateName, ref System.Decimal? federalTaxRate, ref System.Decimal? localTaxRate, ref System.Decimal? federalTaxAmount, ref System.Decimal? localTaxAmount, ref System.Boolean? localOnFederalTax, ref System.Int32? productRateTaxableValue, ref System.Int32? customerTaxableValue);
		
		#endregion
		
		#region p_UTIL_INV_GenerateInvoices_Bak 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices_Bak' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices_Bak(System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices_Bak(null, 0, int.MaxValue , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices_Bak' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices_Bak(int start, int pageLength, System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices_Bak(null, start, pageLength , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices_Bak' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices_Bak(TransactionManager transactionManager, System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices_Bak(transactionManager, 0, int.MaxValue , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices_Bak' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_GenerateInvoices_Bak(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff);
		
		#endregion
		
		#region p_UTIL_BulkEditsPreview 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditsPreview' stored procedure. 
		/// </summary>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkEditsPreview(System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			return BulkEditsPreview(null, 0, int.MaxValue , bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditsPreview' stored procedure. 
		/// </summary>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkEditsPreview(int start, int pageLength, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			return BulkEditsPreview(null, start, pageLength , bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditsPreview' stored procedure. 
		/// </summary>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkEditsPreview(TransactionManager transactionManager, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId)
		{
			return BulkEditsPreview(transactionManager, 0, int.MaxValue , bulkEditType, customerId, companyId, salesPersonId, wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditsPreview' stored procedure. 
		/// </summary>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet BulkEditsPreview(TransactionManager transactionManager, int start, int pageLength , System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId);
		
		#endregion
		
		#region p_UTIL_INV_BACKUP_INVOICING_TABLES 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_BACKUP_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_BACKUP_INVOICING_TABLES()
		{
			 INV_BACKUP_INVOICING_TABLES(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_BACKUP_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_BACKUP_INVOICING_TABLES(int start, int pageLength)
		{
			 INV_BACKUP_INVOICING_TABLES(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_BACKUP_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_BACKUP_INVOICING_TABLES(TransactionManager transactionManager)
		{
			 INV_BACKUP_INVOICING_TABLES(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_BACKUP_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_BACKUP_INVOICING_TABLES(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_UTIL_BulkEditProductRates 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sellRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductRates(System.Int32? productRateId, System.Decimal? sellRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditProductRates(null, 0, int.MaxValue , productRateId, sellRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sellRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductRates(int start, int pageLength, System.Int32? productRateId, System.Decimal? sellRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditProductRates(null, start, pageLength , productRateId, sellRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sellRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditProductRates(TransactionManager transactionManager, System.Int32? productRateId, System.Decimal? sellRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditProductRates(transactionManager, 0, int.MaxValue , productRateId, sellRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sellRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void BulkEditProductRates(TransactionManager transactionManager, int start, int pageLength , System.Int32? productRateId, System.Decimal? sellRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId);
		
		#endregion
		
		#region p_UTIL_INV_Mark_BillableCDRSStart 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSStart' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutOff"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSStart(System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutOff)
		{
			 INV_Mark_BillableCDRSStart(null, 0, int.MaxValue , startDate, endDate, wholesalerId, billingPeriodCutOff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSStart' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutOff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSStart(int start, int pageLength, System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutOff)
		{
			 INV_Mark_BillableCDRSStart(null, start, pageLength , startDate, endDate, wholesalerId, billingPeriodCutOff);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSStart' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutOff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_Mark_BillableCDRSStart(TransactionManager transactionManager, System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutOff)
		{
			 INV_Mark_BillableCDRSStart(transactionManager, 0, int.MaxValue , startDate, endDate, wholesalerId, billingPeriodCutOff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_Mark_BillableCDRSStart' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutOff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_Mark_BillableCDRSStart(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.DateTime? endDate, System.String wholesalerId, System.Int32? billingPeriodCutOff);
		
		#endregion
		
		#region p_UTIL_Accounting_ExportInvoicesXERO 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoicesXERO' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoicesXERO(System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoicesXERO(null, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoicesXERO' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoicesXERO(int start, int pageLength, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoicesXERO(null, start, pageLength , wholesalerId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoicesXERO' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoicesXERO(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoicesXERO(transactionManager, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoicesXERO' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Accounting_ExportInvoicesXERO(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? invoiceDate);
		
		#endregion
		
		#region p_UTIL_Accounting_ExportCreditMemos 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportCreditMemos' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportCreditMemos(System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportCreditMemos(null, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportCreditMemos' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportCreditMemos(int start, int pageLength, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportCreditMemos(null, start, pageLength , wholesalerId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportCreditMemos' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportCreditMemos(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportCreditMemos(transactionManager, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportCreditMemos' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Accounting_ExportCreditMemos(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? invoiceDate);
		
		#endregion
		
		#region p_UTIL_INV_GenerateInvoices 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices(System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices(null, 0, int.MaxValue , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices(int start, int pageLength, System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices(null, start, pageLength , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateInvoices(TransactionManager transactionManager, System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateInvoices(transactionManager, 0, int.MaxValue , startdate, enddate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateInvoices' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="enddate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_GenerateInvoices(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startdate, System.DateTime? enddate, System.String wholesalerId, System.Int32? billingPeriodCutoff);
		
		#endregion
		
		#region p_UTIL_PushProductRatesThatDontExistToWholesalerAndAll 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushProductRatesThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushProductRatesThatDontExistToWholesalerAndAll(System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Int32? productId)
		{
			 PushProductRatesThatDontExistToWholesalerAndAll(null, 0, int.MaxValue , wholesalerId, updateWholesaler, updateCustomer, productId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushProductRatesThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushProductRatesThatDontExistToWholesalerAndAll(int start, int pageLength, System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Int32? productId)
		{
			 PushProductRatesThatDontExistToWholesalerAndAll(null, start, pageLength , wholesalerId, updateWholesaler, updateCustomer, productId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_PushProductRatesThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushProductRatesThatDontExistToWholesalerAndAll(TransactionManager transactionManager, System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Int32? productId)
		{
			 PushProductRatesThatDontExistToWholesalerAndAll(transactionManager, 0, int.MaxValue , wholesalerId, updateWholesaler, updateCustomer, productId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushProductRatesThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="productId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void PushProductRatesThatDontExistToWholesalerAndAll(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Int32? productId);
		
		#endregion
		
		#region p_UTIL_PopulateModeratorXTimeUser 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateModeratorXTimeUser' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateModeratorXTimeUser()
		{
			 PopulateModeratorXTimeUser(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateModeratorXTimeUser' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateModeratorXTimeUser(int start, int pageLength)
		{
			 PopulateModeratorXTimeUser(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateModeratorXTimeUser' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PopulateModeratorXTimeUser(TransactionManager transactionManager)
		{
			 PopulateModeratorXTimeUser(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PopulateModeratorXTimeUser' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void PopulateModeratorXTimeUser(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region p_UTIL_GetReportData 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GetReportData' stored procedure. 
		/// </summary>
		/// <param name="reportType"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetReportData(System.String reportType, System.Int32? customerId, System.Int32? moderatorId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetReportData(null, 0, int.MaxValue , reportType, customerId, moderatorId, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GetReportData' stored procedure. 
		/// </summary>
		/// <param name="reportType"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetReportData(int start, int pageLength, System.String reportType, System.Int32? customerId, System.Int32? moderatorId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetReportData(null, start, pageLength , reportType, customerId, moderatorId, startDate, endDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_GetReportData' stored procedure. 
		/// </summary>
		/// <param name="reportType"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetReportData(TransactionManager transactionManager, System.String reportType, System.Int32? customerId, System.Int32? moderatorId, System.DateTime? startDate, System.DateTime? endDate)
		{
			return GetReportData(transactionManager, 0, int.MaxValue , reportType, customerId, moderatorId, startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_GetReportData' stored procedure. 
		/// </summary>
		/// <param name="reportType"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetReportData(TransactionManager transactionManager, int start, int pageLength , System.String reportType, System.Int32? customerId, System.Int32? moderatorId, System.DateTime? startDate, System.DateTime? endDate);
		
		#endregion
		
		#region p_UTIL_BulkEditWSProductRates 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditWSProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="buyRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditWSProductRates(System.Int32? productRateId, System.Decimal? buyRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditWSProductRates(null, 0, int.MaxValue , productRateId, buyRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditWSProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="buyRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditWSProductRates(int start, int pageLength, System.Int32? productRateId, System.Decimal? buyRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditWSProductRates(null, start, pageLength , productRateId, buyRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditWSProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="buyRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void BulkEditWSProductRates(TransactionManager transactionManager, System.Int32? productRateId, System.Decimal? buyRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId)
		{
			 BulkEditWSProductRates(transactionManager, 0, int.MaxValue , productRateId, buyRate, bulkEditType, customerId, companyId, salesPersonId, wholesalerId, currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_BulkEditWSProductRates' stored procedure. 
		/// </summary>
		/// <param name="productRateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="buyRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="bulkEditType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="currencyId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void BulkEditWSProductRates(TransactionManager transactionManager, int start, int pageLength , System.Int32? productRateId, System.Decimal? buyRate, System.Int32? bulkEditType, System.Int32? customerId, System.Int32? companyId, System.Int32? salesPersonId, System.String wholesalerId, System.String currencyId);
		
		#endregion
		
		#region p_UTIL_INV_GenerateCommissions 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateCommissions' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateCommissions(System.DateTime? startdate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateCommissions(null, 0, int.MaxValue , startdate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateCommissions' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateCommissions(int start, int pageLength, System.DateTime? startdate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateCommissions(null, start, pageLength , startdate, wholesalerId, billingPeriodCutoff);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateCommissions' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_GenerateCommissions(TransactionManager transactionManager, System.DateTime? startdate, System.String wholesalerId, System.Int32? billingPeriodCutoff)
		{
			 INV_GenerateCommissions(transactionManager, 0, int.MaxValue , startdate, wholesalerId, billingPeriodCutoff);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_GenerateCommissions' stored procedure. 
		/// </summary>
		/// <param name="startdate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="billingPeriodCutoff"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_GenerateCommissions(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startdate, System.String wholesalerId, System.Int32? billingPeriodCutoff);
		
		#endregion
		
		#region p_UTIL_Accounting_ExportPayments 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPayments' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPayments(System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPayments(null, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPayments' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPayments(int start, int pageLength, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPayments(null, start, pageLength , wholesalerId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPayments' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportPayments(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportPayments(transactionManager, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportPayments' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Accounting_ExportPayments(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? invoiceDate);
		
		#endregion
		
		#region p_UTIL_MGMTRPT_Trends 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_Trends' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_Trends(System.String wholesalerId, System.Int32? salesPersonId)
		{
			return MGMTRPT_Trends(null, 0, int.MaxValue , wholesalerId, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_Trends' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_Trends(int start, int pageLength, System.String wholesalerId, System.Int32? salesPersonId)
		{
			return MGMTRPT_Trends(null, start, pageLength , wholesalerId, salesPersonId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_Trends' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_Trends(TransactionManager transactionManager, System.String wholesalerId, System.Int32? salesPersonId)
		{
			return MGMTRPT_Trends(transactionManager, 0, int.MaxValue , wholesalerId, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_Trends' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet MGMTRPT_Trends(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? salesPersonId);
		
		#endregion
		
		#region p_UTIL_MGMTRPT_RevenueByModerator 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator(System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator(null, 0, int.MaxValue , startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator(int start, int pageLength, System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator(null, start, pageLength , startDate, endDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_RevenueByModerator(TransactionManager transactionManager, System.DateTime? startDate, System.DateTime? endDate)
		{
			return MGMTRPT_RevenueByModerator(transactionManager, 0, int.MaxValue , startDate, endDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_RevenueByModerator' stored procedure. 
		/// </summary>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet MGMTRPT_RevenueByModerator(TransactionManager transactionManager, int start, int pageLength , System.DateTime? startDate, System.DateTime? endDate);
		
		#endregion
		
		#region p_UTIL_INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(System.String wholesalerId)
		{
			 INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(null, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(int start, int pageLength, System.String wholesalerId)
		{
			 INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(null, start, pageLength , wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(TransactionManager transactionManager, System.String wholesalerId)
		{
			 INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(transactionManager, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_REPOST_TRANSACTIONS_AFTER_ROLLBACK(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId);
		
		#endregion
		
		#region p_UTIL_MGMTRPT_GrossProfit 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_GrossProfit' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_GrossProfit(System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.DateTime? invoiceDate, System.Int32? salesPersonId)
		{
			return MGMTRPT_GrossProfit(null, 0, int.MaxValue , wholesalerId, startDate, endDate, invoiceDate, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_GrossProfit' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_GrossProfit(int start, int pageLength, System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.DateTime? invoiceDate, System.Int32? salesPersonId)
		{
			return MGMTRPT_GrossProfit(null, start, pageLength , wholesalerId, startDate, endDate, invoiceDate, salesPersonId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_GrossProfit' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet MGMTRPT_GrossProfit(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.DateTime? invoiceDate, System.Int32? salesPersonId)
		{
			return MGMTRPT_GrossProfit(transactionManager, 0, int.MaxValue , wholesalerId, startDate, endDate, invoiceDate, salesPersonId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_MGMTRPT_GrossProfit' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="endDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="salesPersonId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet MGMTRPT_GrossProfit(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? startDate, System.DateTime? endDate, System.DateTime? invoiceDate, System.Int32? salesPersonId);
		
		#endregion
		
		#region p_UTIL_INV_EnableInvoiceEmailer 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_EnableInvoiceEmailer' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_EnableInvoiceEmailer(System.String wholesalerId, System.DateTime? startDate)
		{
			 INV_EnableInvoiceEmailer(null, 0, int.MaxValue , wholesalerId, startDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_EnableInvoiceEmailer' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_EnableInvoiceEmailer(int start, int pageLength, System.String wholesalerId, System.DateTime? startDate)
		{
			 INV_EnableInvoiceEmailer(null, start, pageLength , wholesalerId, startDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_EnableInvoiceEmailer' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_EnableInvoiceEmailer(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? startDate)
		{
			 INV_EnableInvoiceEmailer(transactionManager, 0, int.MaxValue , wholesalerId, startDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_EnableInvoiceEmailer' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_EnableInvoiceEmailer(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? startDate);
		
		#endregion
		
		#region p_UTIL_PushFeatureThatDontExistToWholesalerAndAll 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushFeatureThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerator"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushFeatureThatDontExistToWholesalerAndAll(System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Boolean? updateModerator)
		{
			 PushFeatureThatDontExistToWholesalerAndAll(null, 0, int.MaxValue , wholesalerId, updateWholesaler, updateCustomer, updateModerator);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushFeatureThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerator"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushFeatureThatDontExistToWholesalerAndAll(int start, int pageLength, System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Boolean? updateModerator)
		{
			 PushFeatureThatDontExistToWholesalerAndAll(null, start, pageLength , wholesalerId, updateWholesaler, updateCustomer, updateModerator);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_PushFeatureThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerator"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void PushFeatureThatDontExistToWholesalerAndAll(TransactionManager transactionManager, System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Boolean? updateModerator)
		{
			 PushFeatureThatDontExistToWholesalerAndAll(transactionManager, 0, int.MaxValue , wholesalerId, updateWholesaler, updateCustomer, updateModerator);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_PushFeatureThatDontExistToWholesalerAndAll' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="updateWholesaler"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateCustomer"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="updateModerator"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void PushFeatureThatDontExistToWholesalerAndAll(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Boolean? updateWholesaler, System.Boolean? updateCustomer, System.Boolean? updateModerator);
		
		#endregion
		
		#region p_UTIL_INV_ROLLBACK_INVOICING_TABLES 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_ROLLBACK_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_ROLLBACK_INVOICING_TABLES(System.String wholesalerId)
		{
			 INV_ROLLBACK_INVOICING_TABLES(null, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_ROLLBACK_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_ROLLBACK_INVOICING_TABLES(int start, int pageLength, System.String wholesalerId)
		{
			 INV_ROLLBACK_INVOICING_TABLES(null, start, pageLength , wholesalerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_ROLLBACK_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void INV_ROLLBACK_INVOICING_TABLES(TransactionManager transactionManager, System.String wholesalerId)
		{
			 INV_ROLLBACK_INVOICING_TABLES(transactionManager, 0, int.MaxValue , wholesalerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_INV_ROLLBACK_INVOICING_TABLES' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void INV_ROLLBACK_INVOICING_TABLES(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId);
		
		#endregion
		
		#region p_UTIL_Accounting_ExportInvoices 
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoices' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoices(System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoices(null, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoices' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoices(int start, int pageLength, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoices(null, start, pageLength , wholesalerId, invoiceDate);
		}
				
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoices' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Accounting_ExportInvoices(TransactionManager transactionManager, System.String wholesalerId, System.DateTime? invoiceDate)
		{
			return Accounting_ExportInvoices(transactionManager, 0, int.MaxValue , wholesalerId, invoiceDate);
		}
		
		/// <summary>
		///	This method wrap the 'p_UTIL_Accounting_ExportInvoices' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Accounting_ExportInvoices(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.DateTime? invoiceDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Util&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Util&gt;"/></returns>
		public static CONFDB.Entities.TList<Util> Fill(IDataReader reader, CONFDB.Entities.TList<Util> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Util c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Util")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.UtilColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.UtilColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Util>(
					key.ToString(), // EntityTrackingKey
					"Util",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Util();
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
					c.Id = (System.Int32)reader[((int)UtilColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Util"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Util"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Util entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)UtilColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Util"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Util"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Util entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Util"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Util Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Util entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Util object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Util instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Util Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Util entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region UtilChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Util</c>
	///</summary>
	public enum UtilChildEntityTypes
	{
	}
	
	#endregion UtilChildEntityTypes
	
	#region UtilFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UtilColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Util"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UtilFilterBuilder : SqlFilterBuilder<UtilColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UtilFilterBuilder class.
		/// </summary>
		public UtilFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UtilFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UtilFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UtilFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UtilFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UtilFilterBuilder
	
	#region UtilParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UtilColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Util"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UtilParameterBuilder : ParameterizedSqlFilterBuilder<UtilColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UtilParameterBuilder class.
		/// </summary>
		public UtilParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UtilParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UtilParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UtilParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UtilParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UtilParameterBuilder
} // end namespace
