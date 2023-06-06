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
	/// This class is the base class for any <see cref="CompanyLeadTrackingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CompanyLeadTrackingProviderBaseCore : EntityProviderBase<CONFDB.Entities.CompanyLeadTracking, CONFDB.Entities.CompanyLeadTrackingKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingKey key)
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
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		FK_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="_leadPeriodId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(System.Int32 _leadPeriodId)
		{
			int count = -1;
			return GetByLeadPeriodId(_leadPeriodId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		FK_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadPeriodId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(TransactionManager transactionManager, System.Int32 _leadPeriodId)
		{
			int count = -1;
			return GetByLeadPeriodId(transactionManager, _leadPeriodId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		FK_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadPeriodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(TransactionManager transactionManager, System.Int32 _leadPeriodId, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadPeriodId(transactionManager, _leadPeriodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		fk_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadPeriodId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(System.Int32 _leadPeriodId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLeadPeriodId(null, _leadPeriodId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		fk_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadPeriodId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(System.Int32 _leadPeriodId, int start, int pageLength,out int count)
		{
			return GetByLeadPeriodId(null, _leadPeriodId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadPeriod key.
		///		FK_CompanyLeadTracking_LeadPeriod Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadPeriodId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadPeriodId(TransactionManager transactionManager, System.Int32 _leadPeriodId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		FK_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="_companyInfoId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(System.Int32 _companyInfoId)
		{
			int count = -1;
			return GetByCompanyInfoId(_companyInfoId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		FK_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyInfoId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(TransactionManager transactionManager, System.Int32 _companyInfoId)
		{
			int count = -1;
			return GetByCompanyInfoId(transactionManager, _companyInfoId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		FK_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyInfoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(TransactionManager transactionManager, System.Int32 _companyInfoId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyInfoId(transactionManager, _companyInfoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		fk_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyInfoId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(System.Int32 _companyInfoId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompanyInfoId(null, _companyInfoId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		fk_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyInfoId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(System.Int32 _companyInfoId, int start, int pageLength,out int count)
		{
			return GetByCompanyInfoId(null, _companyInfoId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_CompanyInfo key.
		///		FK_CompanyLeadTracking_CompanyInfo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyInfoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByCompanyInfoId(TransactionManager transactionManager, System.Int32 _companyInfoId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		FK_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="_leadSourceId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(System.Int32 _leadSourceId)
		{
			int count = -1;
			return GetByLeadSourceId(_leadSourceId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		FK_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadSourceId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(TransactionManager transactionManager, System.Int32 _leadSourceId)
		{
			int count = -1;
			return GetByLeadSourceId(transactionManager, _leadSourceId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		FK_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadSourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(TransactionManager transactionManager, System.Int32 _leadSourceId, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadSourceId(transactionManager, _leadSourceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		fk_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadSourceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(System.Int32 _leadSourceId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLeadSourceId(null, _leadSourceId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		fk_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadSourceId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(System.Int32 _leadSourceId, int start, int pageLength,out int count)
		{
			return GetByLeadSourceId(null, _leadSourceId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadSource key.
		///		FK_CompanyLeadTracking_LeadSource Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadSourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadSourceId(TransactionManager transactionManager, System.Int32 _leadSourceId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		FK_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="_leadChurnReasonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(System.Int32 _leadChurnReasonId)
		{
			int count = -1;
			return GetByLeadChurnReasonId(_leadChurnReasonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		FK_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadChurnReasonId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(TransactionManager transactionManager, System.Int32 _leadChurnReasonId)
		{
			int count = -1;
			return GetByLeadChurnReasonId(transactionManager, _leadChurnReasonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		FK_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadChurnReasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(TransactionManager transactionManager, System.Int32 _leadChurnReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadChurnReasonId(transactionManager, _leadChurnReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		fk_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadChurnReasonId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(System.Int32 _leadChurnReasonId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLeadChurnReasonId(null, _leadChurnReasonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		fk_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadChurnReasonId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(System.Int32 _leadChurnReasonId, int start, int pageLength,out int count)
		{
			return GetByLeadChurnReasonId(null, _leadChurnReasonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadChurnReason key.
		///		FK_CompanyLeadTracking_LeadChurnReason Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadChurnReasonId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadChurnReasonId(TransactionManager transactionManager, System.Int32 _leadChurnReasonId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		FK_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="_leadProductId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(System.Int32 _leadProductId)
		{
			int count = -1;
			return GetByLeadProductId(_leadProductId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		FK_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadProductId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(TransactionManager transactionManager, System.Int32 _leadProductId)
		{
			int count = -1;
			return GetByLeadProductId(transactionManager, _leadProductId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		FK_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadProductId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(TransactionManager transactionManager, System.Int32 _leadProductId, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadProductId(transactionManager, _leadProductId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		fk_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadProductId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(System.Int32 _leadProductId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLeadProductId(null, _leadProductId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		fk_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadProductId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(System.Int32 _leadProductId, int start, int pageLength,out int count)
		{
			return GetByLeadProductId(null, _leadProductId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadProduct key.
		///		FK_CompanyLeadTracking_LeadProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadProductId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadProductId(TransactionManager transactionManager, System.Int32 _leadProductId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		FK_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="_leadStageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(System.Int32 _leadStageId)
		{
			int count = -1;
			return GetByLeadStageId(_leadStageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		FK_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadStageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(TransactionManager transactionManager, System.Int32 _leadStageId)
		{
			int count = -1;
			return GetByLeadStageId(transactionManager, _leadStageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		FK_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadStageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(TransactionManager transactionManager, System.Int32 _leadStageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadStageId(transactionManager, _leadStageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		fk_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadStageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(System.Int32 _leadStageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLeadStageId(null, _leadStageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		fk_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_leadStageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(System.Int32 _leadStageId, int start, int pageLength,out int count)
		{
			return GetByLeadStageId(null, _leadStageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyLeadTracking_LeadStage key.
		///		FK_CompanyLeadTracking_LeadStage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadStageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.CompanyLeadTracking objects.</returns>
		public abstract CONFDB.Entities.TList<CompanyLeadTracking> GetByLeadStageId(TransactionManager transactionManager, System.Int32 _leadStageId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.CompanyLeadTracking Get(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTrackingKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTracking GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTracking GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTracking GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTracking GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public CONFDB.Entities.CompanyLeadTracking GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyLeadTracking_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.CompanyLeadTracking"/> class.</returns>
		public abstract CONFDB.Entities.CompanyLeadTracking GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;CompanyLeadTracking&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;CompanyLeadTracking&gt;"/></returns>
		public static CONFDB.Entities.TList<CompanyLeadTracking> Fill(IDataReader reader, CONFDB.Entities.TList<CompanyLeadTracking> rows, int start, int pageLength)
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
				
				CONFDB.Entities.CompanyLeadTracking c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CompanyLeadTracking")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.CompanyLeadTrackingColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.CompanyLeadTrackingColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<CompanyLeadTracking>(
					key.ToString(), // EntityTrackingKey
					"CompanyLeadTracking",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.CompanyLeadTracking();
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
					c.Id = (System.Int32)reader[((int)CompanyLeadTrackingColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.CompanyInfoId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.CompanyInfoId - 1)];
					c.ProjectedRevenue = (reader.IsDBNull(((int)CompanyLeadTrackingColumn.ProjectedRevenue - 1)))?null:(System.Decimal?)reader[((int)CompanyLeadTrackingColumn.ProjectedRevenue - 1)];
					c.LeadProductId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadProductId - 1)];
					c.LeadSourceId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadSourceId - 1)];
					c.LeadStageId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadStageId - 1)];
					c.ExpectedCloseDate = (System.DateTime)reader[((int)CompanyLeadTrackingColumn.ExpectedCloseDate - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CompanyLeadTrackingColumn.CreatedDate - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)CompanyLeadTrackingColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingColumn.ModifiedBy - 1)];
					c.LeadPeriodId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadPeriodId - 1)];
					c.LeadChurnReasonId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadChurnReasonId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyLeadTracking"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTracking"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.CompanyLeadTracking entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CompanyLeadTrackingColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.CompanyInfoId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.CompanyInfoId - 1)];
			entity.ProjectedRevenue = (reader.IsDBNull(((int)CompanyLeadTrackingColumn.ProjectedRevenue - 1)))?null:(System.Decimal?)reader[((int)CompanyLeadTrackingColumn.ProjectedRevenue - 1)];
			entity.LeadProductId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadProductId - 1)];
			entity.LeadSourceId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadSourceId - 1)];
			entity.LeadStageId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadStageId - 1)];
			entity.ExpectedCloseDate = (System.DateTime)reader[((int)CompanyLeadTrackingColumn.ExpectedCloseDate - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CompanyLeadTrackingColumn.CreatedDate - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)CompanyLeadTrackingColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)CompanyLeadTrackingColumn.ModifiedBy - 1)];
			entity.LeadPeriodId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadPeriodId - 1)];
			entity.LeadChurnReasonId = (System.Int32)reader[((int)CompanyLeadTrackingColumn.LeadChurnReasonId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.CompanyLeadTracking"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTracking"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.CompanyLeadTracking entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.CompanyInfoId = (System.Int32)dataRow["CompanyInfoID"];
			entity.ProjectedRevenue = Convert.IsDBNull(dataRow["ProjectedRevenue"]) ? null : (System.Decimal?)dataRow["ProjectedRevenue"];
			entity.LeadProductId = (System.Int32)dataRow["LeadProductID"];
			entity.LeadSourceId = (System.Int32)dataRow["LeadSourceID"];
			entity.LeadStageId = (System.Int32)dataRow["LeadStageID"];
			entity.ExpectedCloseDate = (System.DateTime)dataRow["ExpectedCloseDate"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.LeadPeriodId = (System.Int32)dataRow["LeadPeriodID"];
			entity.LeadChurnReasonId = (System.Int32)dataRow["LeadChurnReasonID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.CompanyLeadTracking"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyLeadTracking Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTracking entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LeadPeriodIdSource	
			if (CanDeepLoad(entity, "LeadPeriod|LeadPeriodIdSource", deepLoadType, innerList) 
				&& entity.LeadPeriodIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LeadPeriodId;
				LeadPeriod tmpEntity = EntityManager.LocateEntity<LeadPeriod>(EntityLocator.ConstructKeyFromPkItems(typeof(LeadPeriod), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LeadPeriodIdSource = tmpEntity;
				else
					entity.LeadPeriodIdSource = DataRepository.LeadPeriodProvider.GetById(transactionManager, entity.LeadPeriodId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadPeriodIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LeadPeriodIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LeadPeriodProvider.DeepLoad(transactionManager, entity.LeadPeriodIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LeadPeriodIdSource

			#region CompanyInfoIdSource	
			if (CanDeepLoad(entity, "CompanyInfo|CompanyInfoIdSource", deepLoadType, innerList) 
				&& entity.CompanyInfoIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CompanyInfoId;
				CompanyInfo tmpEntity = EntityManager.LocateEntity<CompanyInfo>(EntityLocator.ConstructKeyFromPkItems(typeof(CompanyInfo), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompanyInfoIdSource = tmpEntity;
				else
					entity.CompanyInfoIdSource = DataRepository.CompanyInfoProvider.GetById(transactionManager, entity.CompanyInfoId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyInfoIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompanyInfoIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CompanyInfoProvider.DeepLoad(transactionManager, entity.CompanyInfoIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompanyInfoIdSource

			#region LeadSourceIdSource	
			if (CanDeepLoad(entity, "LeadSource|LeadSourceIdSource", deepLoadType, innerList) 
				&& entity.LeadSourceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LeadSourceId;
				LeadSource tmpEntity = EntityManager.LocateEntity<LeadSource>(EntityLocator.ConstructKeyFromPkItems(typeof(LeadSource), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LeadSourceIdSource = tmpEntity;
				else
					entity.LeadSourceIdSource = DataRepository.LeadSourceProvider.GetById(transactionManager, entity.LeadSourceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadSourceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LeadSourceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LeadSourceProvider.DeepLoad(transactionManager, entity.LeadSourceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LeadSourceIdSource

			#region LeadChurnReasonIdSource	
			if (CanDeepLoad(entity, "LeadChurnReason|LeadChurnReasonIdSource", deepLoadType, innerList) 
				&& entity.LeadChurnReasonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LeadChurnReasonId;
				LeadChurnReason tmpEntity = EntityManager.LocateEntity<LeadChurnReason>(EntityLocator.ConstructKeyFromPkItems(typeof(LeadChurnReason), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LeadChurnReasonIdSource = tmpEntity;
				else
					entity.LeadChurnReasonIdSource = DataRepository.LeadChurnReasonProvider.GetById(transactionManager, entity.LeadChurnReasonId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadChurnReasonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LeadChurnReasonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LeadChurnReasonProvider.DeepLoad(transactionManager, entity.LeadChurnReasonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LeadChurnReasonIdSource

			#region LeadProductIdSource	
			if (CanDeepLoad(entity, "LeadProduct|LeadProductIdSource", deepLoadType, innerList) 
				&& entity.LeadProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LeadProductId;
				LeadProduct tmpEntity = EntityManager.LocateEntity<LeadProduct>(EntityLocator.ConstructKeyFromPkItems(typeof(LeadProduct), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LeadProductIdSource = tmpEntity;
				else
					entity.LeadProductIdSource = DataRepository.LeadProductProvider.GetById(transactionManager, entity.LeadProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LeadProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LeadProductProvider.DeepLoad(transactionManager, entity.LeadProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LeadProductIdSource

			#region LeadStageIdSource	
			if (CanDeepLoad(entity, "LeadStage|LeadStageIdSource", deepLoadType, innerList) 
				&& entity.LeadStageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LeadStageId;
				LeadStage tmpEntity = EntityManager.LocateEntity<LeadStage>(EntityLocator.ConstructKeyFromPkItems(typeof(LeadStage), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LeadStageIdSource = tmpEntity;
				else
					entity.LeadStageIdSource = DataRepository.LeadStageProvider.GetById(transactionManager, entity.LeadStageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LeadStageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LeadStageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LeadStageProvider.DeepLoad(transactionManager, entity.LeadStageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LeadStageIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CompanyLeadTrackingNotesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CompanyLeadTrackingNotes>|CompanyLeadTrackingNotesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyLeadTrackingNotesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CompanyLeadTrackingNotesCollection = DataRepository.CompanyLeadTrackingNotesProvider.GetByCompanyLeadTrackingId(transactionManager, entity.Id);

				if (deep && entity.CompanyLeadTrackingNotesCollection.Count > 0)
				{
					deepHandles.Add("CompanyLeadTrackingNotesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CompanyLeadTrackingNotes>) DataRepository.CompanyLeadTrackingNotesProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyLeadTrackingNotesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.CompanyLeadTracking object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.CompanyLeadTracking instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.CompanyLeadTracking Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.CompanyLeadTracking entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LeadPeriodIdSource
			if (CanDeepSave(entity, "LeadPeriod|LeadPeriodIdSource", deepSaveType, innerList) 
				&& entity.LeadPeriodIdSource != null)
			{
				DataRepository.LeadPeriodProvider.Save(transactionManager, entity.LeadPeriodIdSource);
				entity.LeadPeriodId = entity.LeadPeriodIdSource.Id;
			}
			#endregion 
			
			#region CompanyInfoIdSource
			if (CanDeepSave(entity, "CompanyInfo|CompanyInfoIdSource", deepSaveType, innerList) 
				&& entity.CompanyInfoIdSource != null)
			{
				DataRepository.CompanyInfoProvider.Save(transactionManager, entity.CompanyInfoIdSource);
				entity.CompanyInfoId = entity.CompanyInfoIdSource.Id;
			}
			#endregion 
			
			#region LeadSourceIdSource
			if (CanDeepSave(entity, "LeadSource|LeadSourceIdSource", deepSaveType, innerList) 
				&& entity.LeadSourceIdSource != null)
			{
				DataRepository.LeadSourceProvider.Save(transactionManager, entity.LeadSourceIdSource);
				entity.LeadSourceId = entity.LeadSourceIdSource.Id;
			}
			#endregion 
			
			#region LeadChurnReasonIdSource
			if (CanDeepSave(entity, "LeadChurnReason|LeadChurnReasonIdSource", deepSaveType, innerList) 
				&& entity.LeadChurnReasonIdSource != null)
			{
				DataRepository.LeadChurnReasonProvider.Save(transactionManager, entity.LeadChurnReasonIdSource);
				entity.LeadChurnReasonId = entity.LeadChurnReasonIdSource.Id;
			}
			#endregion 
			
			#region LeadProductIdSource
			if (CanDeepSave(entity, "LeadProduct|LeadProductIdSource", deepSaveType, innerList) 
				&& entity.LeadProductIdSource != null)
			{
				DataRepository.LeadProductProvider.Save(transactionManager, entity.LeadProductIdSource);
				entity.LeadProductId = entity.LeadProductIdSource.Id;
			}
			#endregion 
			
			#region LeadStageIdSource
			if (CanDeepSave(entity, "LeadStage|LeadStageIdSource", deepSaveType, innerList) 
				&& entity.LeadStageIdSource != null)
			{
				DataRepository.LeadStageProvider.Save(transactionManager, entity.LeadStageIdSource);
				entity.LeadStageId = entity.LeadStageIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<CompanyLeadTrackingNotes>
				if (CanDeepSave(entity.CompanyLeadTrackingNotesCollection, "List<CompanyLeadTrackingNotes>|CompanyLeadTrackingNotesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CompanyLeadTrackingNotes child in entity.CompanyLeadTrackingNotesCollection)
					{
						if(child.CompanyLeadTrackingIdSource != null)
						{
							child.CompanyLeadTrackingId = child.CompanyLeadTrackingIdSource.Id;
						}
						else
						{
							child.CompanyLeadTrackingId = entity.Id;
						}

					}

					if (entity.CompanyLeadTrackingNotesCollection.Count > 0 || entity.CompanyLeadTrackingNotesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CompanyLeadTrackingNotesProvider.Save(transactionManager, entity.CompanyLeadTrackingNotesCollection);
						
						deepHandles.Add("CompanyLeadTrackingNotesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CompanyLeadTrackingNotes >) DataRepository.CompanyLeadTrackingNotesProvider.DeepSave,
							new object[] { transactionManager, entity.CompanyLeadTrackingNotesCollection, deepSaveType, childTypes, innerList }
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
	
	#region CompanyLeadTrackingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.CompanyLeadTracking</c>
	///</summary>
	public enum CompanyLeadTrackingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>LeadPeriod</c> at LeadPeriodIdSource
		///</summary>
		[ChildEntityType(typeof(LeadPeriod))]
		LeadPeriod,
			
		///<summary>
		/// Composite Property for <c>CompanyInfo</c> at CompanyInfoIdSource
		///</summary>
		[ChildEntityType(typeof(CompanyInfo))]
		CompanyInfo,
			
		///<summary>
		/// Composite Property for <c>LeadSource</c> at LeadSourceIdSource
		///</summary>
		[ChildEntityType(typeof(LeadSource))]
		LeadSource,
			
		///<summary>
		/// Composite Property for <c>LeadChurnReason</c> at LeadChurnReasonIdSource
		///</summary>
		[ChildEntityType(typeof(LeadChurnReason))]
		LeadChurnReason,
			
		///<summary>
		/// Composite Property for <c>LeadProduct</c> at LeadProductIdSource
		///</summary>
		[ChildEntityType(typeof(LeadProduct))]
		LeadProduct,
			
		///<summary>
		/// Composite Property for <c>LeadStage</c> at LeadStageIdSource
		///</summary>
		[ChildEntityType(typeof(LeadStage))]
		LeadStage,
	
		///<summary>
		/// Collection of <c>CompanyLeadTracking</c> as OneToMany for CompanyLeadTrackingNotesCollection
		///</summary>
		[ChildEntityType(typeof(TList<CompanyLeadTrackingNotes>))]
		CompanyLeadTrackingNotesCollection,
	}
	
	#endregion CompanyLeadTrackingChildEntityTypes
	
	#region CompanyLeadTrackingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CompanyLeadTrackingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingFilterBuilder : SqlFilterBuilder<CompanyLeadTrackingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilterBuilder class.
		/// </summary>
		public CompanyLeadTrackingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingFilterBuilder
	
	#region CompanyLeadTrackingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CompanyLeadTrackingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyLeadTracking"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyLeadTrackingParameterBuilder : ParameterizedSqlFilterBuilder<CompanyLeadTrackingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingParameterBuilder class.
		/// </summary>
		public CompanyLeadTrackingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyLeadTrackingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyLeadTrackingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyLeadTrackingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyLeadTrackingParameterBuilder
} // end namespace
