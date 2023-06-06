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
	/// This class is the base class for any <see cref="DnisProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DnisProviderBaseCore : EntityProviderBase<CONFDB.Entities.Dnis, CONFDB.Entities.DnisKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCustomerIdFromCustomer_Dnis
		
		/// <summary>
		///		Gets DNIS objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of Dnis objects.</returns>
		public TList<Dnis> GetByCustomerIdFromCustomer_Dnis(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomer_Dnis(null,_customerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Dnis objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Dnis objects.</returns>
		public TList<Dnis> GetByCustomerIdFromCustomer_Dnis(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomer_Dnis(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Dnis objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByCustomerIdFromCustomer_Dnis(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomer_Dnis(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Dnis objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByCustomerIdFromCustomer_Dnis(TransactionManager transactionManager, System.Int32 _customerId,int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomer_Dnis(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Dnis objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByCustomerIdFromCustomer_Dnis(System.Int32 _customerId,int start, int pageLength, out int count)
		{
			
			return GetByCustomerIdFromCustomer_Dnis(null, _customerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets DNIS objects from the datasource by CustomerID in the
		///		Customer_DNIS table. Table DNIS is related to table Customer
		///		through the (M:N) relationship defined in the Customer_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Dnis objects.</returns>
		public abstract TList<Dnis> GetByCustomerIdFromCustomer_Dnis(TransactionManager transactionManager,System.Int32 _customerId, int start, int pageLength, out int count);
		
		#endregion GetByCustomerIdFromCustomer_Dnis
		
		#region GetByModeratorIdFromModerator_Dnis
		
		/// <summary>
		///		Gets DNIS objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <returns>Returns a typed collection of Dnis objects.</returns>
		public TList<Dnis> GetByModeratorIdFromModerator_Dnis(System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorIdFromModerator_Dnis(null,_moderatorId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.Dnis objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Dnis objects.</returns>
		public TList<Dnis> GetByModeratorIdFromModerator_Dnis(System.Int32 _moderatorId, int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorIdFromModerator_Dnis(null, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Dnis objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByModeratorIdFromModerator_Dnis(TransactionManager transactionManager, System.Int32 _moderatorId)
		{
			int count = -1;
			return GetByModeratorIdFromModerator_Dnis(transactionManager, _moderatorId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Dnis objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByModeratorIdFromModerator_Dnis(TransactionManager transactionManager, System.Int32 _moderatorId,int start, int pageLength)
		{
			int count = -1;
			return GetByModeratorIdFromModerator_Dnis(transactionManager, _moderatorId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Dnis objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="_moderatorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DNIS objects.</returns>
		public TList<Dnis> GetByModeratorIdFromModerator_Dnis(System.Int32 _moderatorId,int start, int pageLength, out int count)
		{
			
			return GetByModeratorIdFromModerator_Dnis(null, _moderatorId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets DNIS objects from the datasource by ModeratorID in the
		///		Moderator_DNIS table. Table DNIS is related to table Moderator
		///		through the (M:N) relationship defined in the Moderator_DNIS table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_moderatorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Dnis objects.</returns>
		public abstract TList<Dnis> GetByModeratorIdFromModerator_Dnis(TransactionManager transactionManager,System.Int32 _moderatorId, int start, int pageLength, out int count);
		
		#endregion GetByModeratorIdFromModerator_Dnis
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.DnisKey key)
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
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		AccessType_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByAccessTypeId(System.Int32? _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(_accessTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		AccessType_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Dnis> GetByAccessTypeId(TransactionManager transactionManager, System.Int32? _accessTypeId)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		AccessType_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByAccessTypeId(TransactionManager transactionManager, System.Int32? _accessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccessTypeId(transactionManager, _accessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		accessType_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByAccessTypeId(System.Int32? _accessTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		accessType_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByAccessTypeId(System.Int32? _accessTypeId, int start, int pageLength,out int count)
		{
			return GetByAccessTypeId(null, _accessTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the AccessType_DNIS_FK1 key.
		///		AccessType_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_accessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByAccessTypeId(TransactionManager transactionManager, System.Int32? _accessTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		CallFlow_DNIS_FK Description: 
		/// </summary>
		/// <param name="_callFlowId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByCallFlowId(System.Int32? _callFlowId)
		{
			int count = -1;
			return GetByCallFlowId(_callFlowId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		CallFlow_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Dnis> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId)
		{
			int count = -1;
			return GetByCallFlowId(transactionManager, _callFlowId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		CallFlow_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId, int start, int pageLength)
		{
			int count = -1;
			return GetByCallFlowId(transactionManager, _callFlowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		callFlow_Dnis_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_callFlowId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByCallFlowId(System.Int32? _callFlowId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCallFlowId(null, _callFlowId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		callFlow_Dnis_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_callFlowId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByCallFlowId(System.Int32? _callFlowId, int start, int pageLength,out int count)
		{
			return GetByCallFlowId(null, _callFlowId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_DNIS_FK key.
		///		CallFlow_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		PromptSet_DNIS_FK Description: 
		/// </summary>
		/// <param name="_promptSetId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByPromptSetId(System.Int32? _promptSetId)
		{
			int count = -1;
			return GetByPromptSetId(_promptSetId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		PromptSet_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_promptSetId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Dnis> GetByPromptSetId(TransactionManager transactionManager, System.Int32? _promptSetId)
		{
			int count = -1;
			return GetByPromptSetId(transactionManager, _promptSetId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		PromptSet_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_promptSetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByPromptSetId(TransactionManager transactionManager, System.Int32? _promptSetId, int start, int pageLength)
		{
			int count = -1;
			return GetByPromptSetId(transactionManager, _promptSetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		promptSet_Dnis_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_promptSetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByPromptSetId(System.Int32? _promptSetId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPromptSetId(null, _promptSetId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		promptSet_Dnis_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_promptSetId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByPromptSetId(System.Int32? _promptSetId, int start, int pageLength,out int count)
		{
			return GetByPromptSetId(null, _promptSetId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the PromptSet_DNIS_FK key.
		///		PromptSet_DNIS_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_promptSetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByPromptSetId(TransactionManager transactionManager, System.Int32? _promptSetId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		Wholesaler_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		Wholesaler_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<Dnis> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		Wholesaler_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		wholesaler_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		wholesaler_Dnis_Fk1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public CONFDB.Entities.TList<Dnis> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Wholesaler_DNIS_FK1 key.
		///		Wholesaler_DNIS_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.Dnis objects.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.Dnis Get(TransactionManager transactionManager, CONFDB.Entities.DnisKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key DNIS_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public CONFDB.Entities.Dnis GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public CONFDB.Entities.Dnis GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public CONFDB.Entities.Dnis GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public CONFDB.Entities.Dnis GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public CONFDB.Entities.Dnis GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the DNIS_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.Dnis"/> class.</returns>
		public abstract CONFDB.Entities.Dnis GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="_dnisTypeId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisTypeId(System.Int32 _dnisTypeId)
		{
			int count = -1;
			return GetByDnisTypeId(null,_dnisTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="_dnisTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisTypeId(System.Int32 _dnisTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisTypeId(null, _dnisTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisTypeId(TransactionManager transactionManager, System.Int32 _dnisTypeId)
		{
			int count = -1;
			return GetByDnisTypeId(transactionManager, _dnisTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisTypeId(TransactionManager transactionManager, System.Int32 _dnisTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisTypeId(transactionManager, _dnisTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="_dnisTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisTypeId(System.Int32 _dnisTypeId, int start, int pageLength, out int count)
		{
			return GetByDnisTypeId(null, _dnisTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISTypeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByDnisTypeId(TransactionManager transactionManager, System.Int32 _dnisTypeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="_dnisNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisNumber(System.String _dnisNumber)
		{
			int count = -1;
			return GetByDnisNumber(null,_dnisNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="_dnisNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisNumber(System.String _dnisNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisNumber(null, _dnisNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisNumber(TransactionManager transactionManager, System.String _dnisNumber)
		{
			int count = -1;
			return GetByDnisNumber(transactionManager, _dnisNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisNumber(TransactionManager transactionManager, System.String _dnisNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByDnisNumber(transactionManager, _dnisNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="_dnisNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDnisNumber(System.String _dnisNumber, int start, int pageLength, out int count)
		{
			return GetByDnisNumber(null, _dnisNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DNISNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dnisNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByDnisNumber(TransactionManager transactionManager, System.String _dnisNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="_dialNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDialNumber(System.String _dialNumber)
		{
			int count = -1;
			return GetByDialNumber(null,_dialNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="_dialNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDialNumber(System.String _dialNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByDialNumber(null, _dialNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dialNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDialNumber(TransactionManager transactionManager, System.String _dialNumber)
		{
			int count = -1;
			return GetByDialNumber(transactionManager, _dialNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dialNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDialNumber(TransactionManager transactionManager, System.String _dialNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByDialNumber(transactionManager, _dialNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="_dialNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public CONFDB.Entities.TList<Dnis> GetByDialNumber(System.String _dialNumber, int start, int pageLength, out int count)
		{
			return GetByDialNumber(null, _dialNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DNIS_DialNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dialNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<Dnis> GetByDialNumber(TransactionManager transactionManager, System.String _dialNumber, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_DNIS_GetByWholesalerIdDDL 
		
		/// <summary>
		///	This method wrap the 'p_DNIS_GetByWholesalerIdDDL' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWholesalerIdDDL(System.String wholesalerId, System.Int32? dnisTypeId)
		{
			return GetByWholesalerIdDDL(null, 0, int.MaxValue , wholesalerId, dnisTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'p_DNIS_GetByWholesalerIdDDL' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWholesalerIdDDL(int start, int pageLength, System.String wholesalerId, System.Int32? dnisTypeId)
		{
			return GetByWholesalerIdDDL(null, start, pageLength , wholesalerId, dnisTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'p_DNIS_GetByWholesalerIdDDL' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWholesalerIdDDL(TransactionManager transactionManager, System.String wholesalerId, System.Int32? dnisTypeId)
		{
			return GetByWholesalerIdDDL(transactionManager, 0, int.MaxValue , wholesalerId, dnisTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'p_DNIS_GetByWholesalerIdDDL' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="dnisTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByWholesalerIdDDL(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? dnisTypeId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;Dnis&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;Dnis&gt;"/></returns>
		public static CONFDB.Entities.TList<Dnis> Fill(IDataReader reader, CONFDB.Entities.TList<Dnis> rows, int start, int pageLength)
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
				
				CONFDB.Entities.Dnis c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Dnis")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.DnisColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.DnisColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<Dnis>(
					key.ToString(), // EntityTrackingKey
					"Dnis",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.Dnis();
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
					c.Id = (System.Int32)reader[((int)DnisColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)DnisColumn.WholesalerId - 1)];
					c.AccessTypeId = (reader.IsDBNull(((int)DnisColumn.AccessTypeId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.AccessTypeId - 1)];
					c.DnisTypeId = (System.Int32)reader[((int)DnisColumn.DnisTypeId - 1)];
					c.DnisNumber = (reader.IsDBNull(((int)DnisColumn.DnisNumber - 1)))?null:(System.String)reader[((int)DnisColumn.DnisNumber - 1)];
					c.DialNumber = (reader.IsDBNull(((int)DnisColumn.DialNumber - 1)))?null:(System.String)reader[((int)DnisColumn.DialNumber - 1)];
					c.Description = (reader.IsDBNull(((int)DnisColumn.Description - 1)))?null:(System.String)reader[((int)DnisColumn.Description - 1)];
					c.Enabled = (System.Boolean)reader[((int)DnisColumn.Enabled - 1)];
					c.DisplayOrder = (System.Int32)reader[((int)DnisColumn.DisplayOrder - 1)];
					c.DefaultOption = (System.Boolean)reader[((int)DnisColumn.DefaultOption - 1)];
					c.CallFlowId = (reader.IsDBNull(((int)DnisColumn.CallFlowId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.CallFlowId - 1)];
					c.PromptSetId = (reader.IsDBNull(((int)DnisColumn.PromptSetId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.PromptSetId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Dnis"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Dnis"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.Dnis entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)DnisColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)DnisColumn.WholesalerId - 1)];
			entity.AccessTypeId = (reader.IsDBNull(((int)DnisColumn.AccessTypeId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.AccessTypeId - 1)];
			entity.DnisTypeId = (System.Int32)reader[((int)DnisColumn.DnisTypeId - 1)];
			entity.DnisNumber = (reader.IsDBNull(((int)DnisColumn.DnisNumber - 1)))?null:(System.String)reader[((int)DnisColumn.DnisNumber - 1)];
			entity.DialNumber = (reader.IsDBNull(((int)DnisColumn.DialNumber - 1)))?null:(System.String)reader[((int)DnisColumn.DialNumber - 1)];
			entity.Description = (reader.IsDBNull(((int)DnisColumn.Description - 1)))?null:(System.String)reader[((int)DnisColumn.Description - 1)];
			entity.Enabled = (System.Boolean)reader[((int)DnisColumn.Enabled - 1)];
			entity.DisplayOrder = (System.Int32)reader[((int)DnisColumn.DisplayOrder - 1)];
			entity.DefaultOption = (System.Boolean)reader[((int)DnisColumn.DefaultOption - 1)];
			entity.CallFlowId = (reader.IsDBNull(((int)DnisColumn.CallFlowId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.CallFlowId - 1)];
			entity.PromptSetId = (reader.IsDBNull(((int)DnisColumn.PromptSetId - 1)))?null:(System.Int32?)reader[((int)DnisColumn.PromptSetId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.Dnis"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.Dnis"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.Dnis entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.AccessTypeId = Convert.IsDBNull(dataRow["AccessTypeID"]) ? null : (System.Int32?)dataRow["AccessTypeID"];
			entity.DnisTypeId = (System.Int32)dataRow["DNISTypeID"];
			entity.DnisNumber = Convert.IsDBNull(dataRow["DNISNumber"]) ? null : (System.String)dataRow["DNISNumber"];
			entity.DialNumber = Convert.IsDBNull(dataRow["DialNumber"]) ? null : (System.String)dataRow["DialNumber"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.DefaultOption = (System.Boolean)dataRow["DefaultOption"];
			entity.CallFlowId = Convert.IsDBNull(dataRow["CallFlowID"]) ? null : (System.Int32?)dataRow["CallFlowID"];
			entity.PromptSetId = Convert.IsDBNull(dataRow["PromptSetID"]) ? null : (System.Int32?)dataRow["PromptSetID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.Dnis"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.Dnis Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.Dnis entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AccessTypeIdSource	
			if (CanDeepLoad(entity, "AccessType|AccessTypeIdSource", deepLoadType, innerList) 
				&& entity.AccessTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AccessTypeId ?? (int)0);
				AccessType tmpEntity = EntityManager.LocateEntity<AccessType>(EntityLocator.ConstructKeyFromPkItems(typeof(AccessType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccessTypeIdSource = tmpEntity;
				else
					entity.AccessTypeIdSource = DataRepository.AccessTypeProvider.GetById(transactionManager, (entity.AccessTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AccessTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AccessTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AccessTypeProvider.DeepLoad(transactionManager, entity.AccessTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AccessTypeIdSource

			#region CallFlowIdSource	
			if (CanDeepLoad(entity, "CallFlow|CallFlowIdSource", deepLoadType, innerList) 
				&& entity.CallFlowIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CallFlowId ?? (int)0);
				CallFlow tmpEntity = EntityManager.LocateEntity<CallFlow>(EntityLocator.ConstructKeyFromPkItems(typeof(CallFlow), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CallFlowIdSource = tmpEntity;
				else
					entity.CallFlowIdSource = DataRepository.CallFlowProvider.GetById(transactionManager, (entity.CallFlowId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CallFlowIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CallFlowIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CallFlowProvider.DeepLoad(transactionManager, entity.CallFlowIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CallFlowIdSource

			#region DnisTypeIdSource	
			if (CanDeepLoad(entity, "DnisType|DnisTypeIdSource", deepLoadType, innerList) 
				&& entity.DnisTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DnisTypeId;
				DnisType tmpEntity = EntityManager.LocateEntity<DnisType>(EntityLocator.ConstructKeyFromPkItems(typeof(DnisType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DnisTypeIdSource = tmpEntity;
				else
					entity.DnisTypeIdSource = DataRepository.DnisTypeProvider.GetById(transactionManager, entity.DnisTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DnisTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DnisTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DnisTypeProvider.DeepLoad(transactionManager, entity.DnisTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DnisTypeIdSource

			#region PromptSetIdSource	
			if (CanDeepLoad(entity, "PromptSet|PromptSetIdSource", deepLoadType, innerList) 
				&& entity.PromptSetIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PromptSetId ?? (int)0);
				PromptSet tmpEntity = EntityManager.LocateEntity<PromptSet>(EntityLocator.ConstructKeyFromPkItems(typeof(PromptSet), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PromptSetIdSource = tmpEntity;
				else
					entity.PromptSetIdSource = DataRepository.PromptSetProvider.GetById(transactionManager, (entity.PromptSetId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PromptSetIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PromptSetIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PromptSetProvider.DeepLoad(transactionManager, entity.PromptSetIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PromptSetIdSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerIdCustomerCollection_From_Customer_Dnis
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Customer>|CustomerIdCustomerCollection_From_Customer_Dnis", deepLoadType, innerList))
			{
				entity.CustomerIdCustomerCollection_From_Customer_Dnis = DataRepository.CustomerProvider.GetByDnisidFromCustomer_Dnis(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdCustomerCollection_From_Customer_Dnis' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdCustomerCollection_From_Customer_Dnis != null)
				{
					deepHandles.Add("CustomerIdCustomerCollection_From_Customer_Dnis",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Customer >) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerIdCustomerCollection_From_Customer_Dnis, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region Moderator_DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator_Dnis>|Moderator_DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Moderator_DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Moderator_DnisCollection = DataRepository.Moderator_DnisProvider.GetByDnisid(transactionManager, entity.Id);

				if (deep && entity.Moderator_DnisCollection.Count > 0)
				{
					deepHandles.Add("Moderator_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator_Dnis>) DataRepository.Moderator_DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.Moderator_DnisCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ModeratorIdModeratorCollection_From_Moderator_Dnis
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Moderator>|ModeratorIdModeratorCollection_From_Moderator_Dnis", deepLoadType, innerList))
			{
				entity.ModeratorIdModeratorCollection_From_Moderator_Dnis = DataRepository.ModeratorProvider.GetByDnisidFromModerator_Dnis(transactionManager, entity.Id);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ModeratorIdModeratorCollection_From_Moderator_Dnis' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ModeratorIdModeratorCollection_From_Moderator_Dnis != null)
				{
					deepHandles.Add("ModeratorIdModeratorCollection_From_Moderator_Dnis",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Moderator >) DataRepository.ModeratorProvider.DeepLoad,
						new object[] { transactionManager, entity.ModeratorIdModeratorCollection_From_Moderator_Dnis, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region Customer_DnisCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer_Dnis>|Customer_DnisCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Customer_DnisCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Customer_DnisCollection = DataRepository.Customer_DnisProvider.GetByDnisid(transactionManager, entity.Id);

				if (deep && entity.Customer_DnisCollection.Count > 0)
				{
					deepHandles.Add("Customer_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer_Dnis>) DataRepository.Customer_DnisProvider.DeepLoad,
						new object[] { transactionManager, entity.Customer_DnisCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.Dnis object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.Dnis instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.Dnis Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.Dnis entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AccessTypeIdSource
			if (CanDeepSave(entity, "AccessType|AccessTypeIdSource", deepSaveType, innerList) 
				&& entity.AccessTypeIdSource != null)
			{
				DataRepository.AccessTypeProvider.Save(transactionManager, entity.AccessTypeIdSource);
				entity.AccessTypeId = entity.AccessTypeIdSource.Id;
			}
			#endregion 
			
			#region CallFlowIdSource
			if (CanDeepSave(entity, "CallFlow|CallFlowIdSource", deepSaveType, innerList) 
				&& entity.CallFlowIdSource != null)
			{
				DataRepository.CallFlowProvider.Save(transactionManager, entity.CallFlowIdSource);
				entity.CallFlowId = entity.CallFlowIdSource.Id;
			}
			#endregion 
			
			#region DnisTypeIdSource
			if (CanDeepSave(entity, "DnisType|DnisTypeIdSource", deepSaveType, innerList) 
				&& entity.DnisTypeIdSource != null)
			{
				DataRepository.DnisTypeProvider.Save(transactionManager, entity.DnisTypeIdSource);
				entity.DnisTypeId = entity.DnisTypeIdSource.Id;
			}
			#endregion 
			
			#region PromptSetIdSource
			if (CanDeepSave(entity, "PromptSet|PromptSetIdSource", deepSaveType, innerList) 
				&& entity.PromptSetIdSource != null)
			{
				DataRepository.PromptSetProvider.Save(transactionManager, entity.PromptSetIdSource);
				entity.PromptSetId = entity.PromptSetIdSource.Id;
			}
			#endregion 
			
			#region WholesalerIdSource
			if (CanDeepSave(entity, "Wholesaler|WholesalerIdSource", deepSaveType, innerList) 
				&& entity.WholesalerIdSource != null)
			{
				DataRepository.WholesalerProvider.Save(transactionManager, entity.WholesalerIdSource);
				entity.WholesalerId = entity.WholesalerIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region CustomerIdCustomerCollection_From_Customer_Dnis>
			if (CanDeepSave(entity.CustomerIdCustomerCollection_From_Customer_Dnis, "List<Customer>|CustomerIdCustomerCollection_From_Customer_Dnis", deepSaveType, innerList))
			{
				if (entity.CustomerIdCustomerCollection_From_Customer_Dnis.Count > 0 || entity.CustomerIdCustomerCollection_From_Customer_Dnis.DeletedItems.Count > 0)
				{
					DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdCustomerCollection_From_Customer_Dnis); 
					deepHandles.Add("CustomerIdCustomerCollection_From_Customer_Dnis",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Customer>) DataRepository.CustomerProvider.DeepSave,
						new object[] { transactionManager, entity.CustomerIdCustomerCollection_From_Customer_Dnis, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region ModeratorIdModeratorCollection_From_Moderator_Dnis>
			if (CanDeepSave(entity.ModeratorIdModeratorCollection_From_Moderator_Dnis, "List<Moderator>|ModeratorIdModeratorCollection_From_Moderator_Dnis", deepSaveType, innerList))
			{
				if (entity.ModeratorIdModeratorCollection_From_Moderator_Dnis.Count > 0 || entity.ModeratorIdModeratorCollection_From_Moderator_Dnis.DeletedItems.Count > 0)
				{
					DataRepository.ModeratorProvider.Save(transactionManager, entity.ModeratorIdModeratorCollection_From_Moderator_Dnis); 
					deepHandles.Add("ModeratorIdModeratorCollection_From_Moderator_Dnis",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Moderator>) DataRepository.ModeratorProvider.DeepSave,
						new object[] { transactionManager, entity.ModeratorIdModeratorCollection_From_Moderator_Dnis, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Moderator_Dnis>
				if (CanDeepSave(entity.Moderator_DnisCollection, "List<Moderator_Dnis>|Moderator_DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator_Dnis child in entity.Moderator_DnisCollection)
					{
						if(child.DnisidSource != null)
						{
								child.Dnisid = child.DnisidSource.Id;
						}

						if(child.ModeratorIdSource != null)
						{
								child.ModeratorId = child.ModeratorIdSource.Id;
						}

					}

					if (entity.Moderator_DnisCollection.Count > 0 || entity.Moderator_DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Moderator_DnisProvider.Save(transactionManager, entity.Moderator_DnisCollection);
						
						deepHandles.Add("Moderator_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator_Dnis >) DataRepository.Moderator_DnisProvider.DeepSave,
							new object[] { transactionManager, entity.Moderator_DnisCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer_Dnis>
				if (CanDeepSave(entity.Customer_DnisCollection, "List<Customer_Dnis>|Customer_DnisCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer_Dnis child in entity.Customer_DnisCollection)
					{
						if(child.DnisidSource != null)
						{
								child.Dnisid = child.DnisidSource.Id;
						}

						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.Id;
						}

					}

					if (entity.Customer_DnisCollection.Count > 0 || entity.Customer_DnisCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Customer_DnisProvider.Save(transactionManager, entity.Customer_DnisCollection);
						
						deepHandles.Add("Customer_DnisCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer_Dnis >) DataRepository.Customer_DnisProvider.DeepSave,
							new object[] { transactionManager, entity.Customer_DnisCollection, deepSaveType, childTypes, innerList }
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
	
	#region DnisChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.Dnis</c>
	///</summary>
	public enum DnisChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AccessType</c> at AccessTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AccessType))]
		AccessType,
			
		///<summary>
		/// Composite Property for <c>CallFlow</c> at CallFlowIdSource
		///</summary>
		[ChildEntityType(typeof(CallFlow))]
		CallFlow,
			
		///<summary>
		/// Composite Property for <c>DnisType</c> at DnisTypeIdSource
		///</summary>
		[ChildEntityType(typeof(DnisType))]
		DnisType,
			
		///<summary>
		/// Composite Property for <c>PromptSet</c> at PromptSetIdSource
		///</summary>
		[ChildEntityType(typeof(PromptSet))]
		PromptSet,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
	
		///<summary>
		/// Collection of <c>Dnis</c> as ManyToMany for CustomerCollection_From_Customer_Dnis
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerIdCustomerCollection_From_Customer_Dnis,

		///<summary>
		/// Collection of <c>Dnis</c> as OneToMany for Moderator_DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator_Dnis>))]
		Moderator_DnisCollection,

		///<summary>
		/// Collection of <c>Dnis</c> as ManyToMany for ModeratorCollection_From_Moderator_Dnis
		///</summary>
		[ChildEntityType(typeof(TList<Moderator>))]
		ModeratorIdModeratorCollection_From_Moderator_Dnis,

		///<summary>
		/// Collection of <c>Dnis</c> as OneToMany for Customer_DnisCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer_Dnis>))]
		Customer_DnisCollection,
	}
	
	#endregion DnisChildEntityTypes
	
	#region DnisFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisFilterBuilder : SqlFilterBuilder<DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisFilterBuilder class.
		/// </summary>
		public DnisFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisFilterBuilder
	
	#region DnisParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DnisColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Dnis"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DnisParameterBuilder : ParameterizedSqlFilterBuilder<DnisColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DnisParameterBuilder class.
		/// </summary>
		public DnisParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DnisParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DnisParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DnisParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DnisParameterBuilder
} // end namespace
