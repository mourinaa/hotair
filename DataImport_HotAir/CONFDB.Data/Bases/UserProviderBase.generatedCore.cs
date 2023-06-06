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
	/// This class is the base class for any <see cref="UserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserProviderBaseCore : EntityProviderBase<CONFDB.Entities.User, CONFDB.Entities.UserKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByMarketingServiceIdFromUser_MarketingService
		
		/// <summary>
		///		Gets User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <returns>Returns a typed collection of User objects.</returns>
		public TList<User> GetByMarketingServiceIdFromUser_MarketingService(System.Int32 _marketingServiceId)
		{
			int count = -1;
			return GetByMarketingServiceIdFromUser_MarketingService(null,_marketingServiceId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets CONFDB.Entities.User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_marketingServiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of User objects.</returns>
		public TList<User> GetByMarketingServiceIdFromUser_MarketingService(System.Int32 _marketingServiceId, int start, int pageLength)
		{
			int count = -1;
			return GetByMarketingServiceIdFromUser_MarketingService(null, _marketingServiceId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of User objects.</returns>
		public TList<User> GetByMarketingServiceIdFromUser_MarketingService(TransactionManager transactionManager, System.Int32 _marketingServiceId)
		{
			int count = -1;
			return GetByMarketingServiceIdFromUser_MarketingService(transactionManager, _marketingServiceId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_marketingServiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of User objects.</returns>
		public TList<User> GetByMarketingServiceIdFromUser_MarketingService(TransactionManager transactionManager, System.Int32 _marketingServiceId,int start, int pageLength)
		{
			int count = -1;
			return GetByMarketingServiceIdFromUser_MarketingService(transactionManager, _marketingServiceId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="_marketingServiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of User objects.</returns>
		public TList<User> GetByMarketingServiceIdFromUser_MarketingService(System.Int32 _marketingServiceId,int start, int pageLength, out int count)
		{
			
			return GetByMarketingServiceIdFromUser_MarketingService(null, _marketingServiceId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets User objects from the datasource by MarketingServiceID in the
		///		User_MarketingService table. Table User is related to table MarketingService
		///		through the (M:N) relationship defined in the User_MarketingService table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_marketingServiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of User objects.</returns>
		public abstract TList<User> GetByMarketingServiceIdFromUser_MarketingService(TransactionManager transactionManager,System.Int32 _marketingServiceId, int start, int pageLength, out int count);
		
		#endregion GetByMarketingServiceIdFromUser_MarketingService
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.UserKey key)
		{
			return Delete(transactionManager, key.UserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _userId)
		{
			return Delete(null, _userId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _userId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		FK_User_Charity Description: 
		/// </summary>
		/// <param name="_charityId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCharityId(System.Int32? _charityId)
		{
			int count = -1;
			return GetByCharityId(_charityId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		FK_User_Charity Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_charityId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetByCharityId(TransactionManager transactionManager, System.Int32? _charityId)
		{
			int count = -1;
			return GetByCharityId(transactionManager, _charityId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		FK_User_Charity Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_charityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCharityId(TransactionManager transactionManager, System.Int32? _charityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCharityId(transactionManager, _charityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		fk_User_Charity Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_charityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCharityId(System.Int32? _charityId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCharityId(null, _charityId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		fk_User_Charity Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_charityId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCharityId(System.Int32? _charityId, int start, int pageLength,out int count)
		{
			return GetByCharityId(null, _charityId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Charity key.
		///		FK_User_Charity Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_charityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetByCharityId(TransactionManager transactionManager, System.Int32? _charityId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		FK_User_Country Description: 
		/// </summary>
		/// <param name="_country"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCountry(System.String _country)
		{
			int count = -1;
			return GetByCountry(_country, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		FK_User_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_country"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetByCountry(TransactionManager transactionManager, System.String _country)
		{
			int count = -1;
			return GetByCountry(transactionManager, _country, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		FK_User_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_country"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCountry(TransactionManager transactionManager, System.String _country, int start, int pageLength)
		{
			int count = -1;
			return GetByCountry(transactionManager, _country, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		fk_User_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_country"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCountry(System.String _country, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountry(null, _country, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		fk_User_Country Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_country"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCountry(System.String _country, int start, int pageLength,out int count)
		{
			return GetByCountry(null, _country, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Country key.
		///		FK_User_Country Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_country"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetByCountry(TransactionManager transactionManager, System.String _country, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		FK_User_Role Description: 
		/// </summary>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRoleId(System.Int32? _roleId)
		{
			int count = -1;
			return GetByRoleId(_roleId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		FK_User_Role Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		FK_User_Role Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		fk_User_Role Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRoleId(System.Int32? _roleId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRoleId(null, _roleId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		fk_User_Role Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRoleId(System.Int32? _roleId, int start, int pageLength,out int count)
		{
			return GetByRoleId(null, _roleId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Role key.
		///		FK_User_Role Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId">Used to denote the role of the user.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		FK_User_SalesPerson Description: 
		/// </summary>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetBySalesPersonId(System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(_salesPersonId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		FK_User_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		FK_User_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		fk_User_SalesPerson Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		fk_User_SalesPerson Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength,out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_SalesPerson key.
		///		FK_User_SalesPerson Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Used for the Sales Manger/Sales role(s) and links to the sales person the user is associated with to restrict data access.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		FK_User_State Description: 
		/// </summary>
		/// <param name="_region"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRegion(System.String _region)
		{
			int count = -1;
			return GetByRegion(_region, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		FK_User_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetByRegion(TransactionManager transactionManager, System.String _region)
		{
			int count = -1;
			return GetByRegion(transactionManager, _region, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		FK_User_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRegion(TransactionManager transactionManager, System.String _region, int start, int pageLength)
		{
			int count = -1;
			return GetByRegion(transactionManager, _region, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		fk_User_State Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_region"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRegion(System.String _region, int start, int pageLength)
		{
			int count =  -1;
			return GetByRegion(null, _region, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		fk_User_State Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_region"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByRegion(System.String _region, int start, int pageLength,out int count)
		{
			return GetByRegion(null, _region, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_State key.
		///		FK_User_State Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetByRegion(TransactionManager transactionManager, System.String _region, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		FK_User_Company Description: 
		/// </summary>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCompanyId(System.Int32? _companyId)
		{
			int count = -1;
			return GetByCompanyId(_companyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		FK_User_Company Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<User> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		FK_User_Company Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		fk_User_Company Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCompanyId(System.Int32? _companyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompanyId(null, _companyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		fk_User_Company Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public CONFDB.Entities.TList<User> GetByCompanyId(System.Int32? _companyId, int start, int pageLength,out int count)
		{
			return GetByCompanyId(null, _companyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_User_Company key.
		///		FK_User_Company Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId">Used for the Company Admin role and links to the company the user is associated with to restrict data access.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.User objects.</returns>
		public abstract CONFDB.Entities.TList<User> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.User Get(TransactionManager transactionManager, CONFDB.Entities.UserKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUserId(System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUserId(System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUserId(System.Int32 _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public abstract CONFDB.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_User_UserName index.
		/// </summary>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUsername(System.String _username)
		{
			int count = -1;
			return GetByUsername(null,_username, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_User_UserName index.
		/// </summary>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUsername(System.String _username, int start, int pageLength)
		{
			int count = -1;
			return GetByUsername(null, _username, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_User_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUsername(TransactionManager transactionManager, System.String _username)
		{
			int count = -1;
			return GetByUsername(transactionManager, _username, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_User_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUsername(TransactionManager transactionManager, System.String _username, int start, int pageLength)
		{
			int count = -1;
			return GetByUsername(transactionManager, _username, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_User_UserName index.
		/// </summary>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public CONFDB.Entities.User GetByUsername(System.String _username, int start, int pageLength, out int count)
		{
			return GetByUsername(null, _username, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_User_UserName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_username">Needs to be unique and can be anything e.g. Customer Number, Email Address, etc.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.User"/> class.</returns>
		public abstract CONFDB.Entities.User GetByUsername(TransactionManager transactionManager, System.String _username, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_User_GetAllModeratorsByCustomerID 
		
		/// <summary>
		///	This method wrap the 'p_User_GetAllModeratorsByCustomerID' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;User&gt;"/> instance.</returns>
		public TList<User> GetAllModeratorsByCustomerID(System.Int32? customerId)
		{
			return GetAllModeratorsByCustomerID(null, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_User_GetAllModeratorsByCustomerID' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;User&gt;"/> instance.</returns>
		public TList<User> GetAllModeratorsByCustomerID(int start, int pageLength, System.Int32? customerId)
		{
			return GetAllModeratorsByCustomerID(null, start, pageLength , customerId);
		}
				
		/// <summary>
		///	This method wrap the 'p_User_GetAllModeratorsByCustomerID' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;User&gt;"/> instance.</returns>
		public TList<User> GetAllModeratorsByCustomerID(TransactionManager transactionManager, System.Int32? customerId)
		{
			return GetAllModeratorsByCustomerID(transactionManager, 0, int.MaxValue , customerId);
		}
		
		/// <summary>
		///	This method wrap the 'p_User_GetAllModeratorsByCustomerID' stored procedure. 
		/// </summary>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;User&gt;"/> instance.</returns>
		public abstract TList<User> GetAllModeratorsByCustomerID(TransactionManager transactionManager, int start, int pageLength , System.Int32? customerId);
		
		#endregion
		
		#region p_User_CheckUserName 
		
		/// <summary>
		///	This method wrap the 'p_User_CheckUserName' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="userNameOk"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CheckUserName(System.String userName, System.Int32? userId, ref System.Boolean? userNameOk)
		{
			 CheckUserName(null, 0, int.MaxValue , userName, userId, ref userNameOk);
		}
		
		/// <summary>
		///	This method wrap the 'p_User_CheckUserName' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="userNameOk"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CheckUserName(int start, int pageLength, System.String userName, System.Int32? userId, ref System.Boolean? userNameOk)
		{
			 CheckUserName(null, start, pageLength , userName, userId, ref userNameOk);
		}
				
		/// <summary>
		///	This method wrap the 'p_User_CheckUserName' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="userNameOk"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CheckUserName(TransactionManager transactionManager, System.String userName, System.Int32? userId, ref System.Boolean? userNameOk)
		{
			 CheckUserName(transactionManager, 0, int.MaxValue , userName, userId, ref userNameOk);
		}
		
		/// <summary>
		///	This method wrap the 'p_User_CheckUserName' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="userNameOk"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CheckUserName(TransactionManager transactionManager, int start, int pageLength , System.String userName, System.Int32? userId, ref System.Boolean? userNameOk);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;User&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;User&gt;"/></returns>
		public static CONFDB.Entities.TList<User> Fill(IDataReader reader, CONFDB.Entities.TList<User> rows, int start, int pageLength)
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
				
				CONFDB.Entities.User c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("User")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.UserColumn.UserId - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.UserColumn.UserId - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<User>(
					key.ToString(), // EntityTrackingKey
					"User",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.User();
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
					c.UserId = (System.Int32)reader[((int)UserColumn.UserId - 1)];
					c.Username = (System.String)reader[((int)UserColumn.Username - 1)];
					c.Password = (System.String)reader[((int)UserColumn.Password - 1)];
					c.DisplayName = (System.String)reader[((int)UserColumn.DisplayName - 1)];
					c.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
					c.Telephone = (reader.IsDBNull(((int)UserColumn.Telephone - 1)))?null:(System.String)reader[((int)UserColumn.Telephone - 1)];
					c.Enabled = (System.Boolean)reader[((int)UserColumn.Enabled - 1)];
					c.CompanyId = (reader.IsDBNull(((int)UserColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)UserColumn.CompanyId - 1)];
					c.SalesPersonId = (reader.IsDBNull(((int)UserColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)UserColumn.SalesPersonId - 1)];
					c.RoleId = (reader.IsDBNull(((int)UserColumn.RoleId - 1)))?null:(System.Int32?)reader[((int)UserColumn.RoleId - 1)];
					c.MustChangePassword = (reader.IsDBNull(((int)UserColumn.MustChangePassword - 1)))?null:(System.Boolean?)reader[((int)UserColumn.MustChangePassword - 1)];
					c.Address1 = (reader.IsDBNull(((int)UserColumn.Address1 - 1)))?null:(System.String)reader[((int)UserColumn.Address1 - 1)];
					c.Address2 = (reader.IsDBNull(((int)UserColumn.Address2 - 1)))?null:(System.String)reader[((int)UserColumn.Address2 - 1)];
					c.City = (reader.IsDBNull(((int)UserColumn.City - 1)))?null:(System.String)reader[((int)UserColumn.City - 1)];
					c.Country = (reader.IsDBNull(((int)UserColumn.Country - 1)))?null:(System.String)reader[((int)UserColumn.Country - 1)];
					c.Region = (reader.IsDBNull(((int)UserColumn.Region - 1)))?null:(System.String)reader[((int)UserColumn.Region - 1)];
					c.PostalCode = (reader.IsDBNull(((int)UserColumn.PostalCode - 1)))?null:(System.String)reader[((int)UserColumn.PostalCode - 1)];
					c.CharityId = (reader.IsDBNull(((int)UserColumn.CharityId - 1)))?null:(System.Int32?)reader[((int)UserColumn.CharityId - 1)];
					c.WebMemberId = (reader.IsDBNull(((int)UserColumn.WebMemberId - 1)))?null:(System.String)reader[((int)UserColumn.WebMemberId - 1)];
					c.UserUniqueId = (System.Guid)reader[((int)UserColumn.UserUniqueId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.User"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.User"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.User entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Int32)reader[((int)UserColumn.UserId - 1)];
			entity.Username = (System.String)reader[((int)UserColumn.Username - 1)];
			entity.Password = (System.String)reader[((int)UserColumn.Password - 1)];
			entity.DisplayName = (System.String)reader[((int)UserColumn.DisplayName - 1)];
			entity.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
			entity.Telephone = (reader.IsDBNull(((int)UserColumn.Telephone - 1)))?null:(System.String)reader[((int)UserColumn.Telephone - 1)];
			entity.Enabled = (System.Boolean)reader[((int)UserColumn.Enabled - 1)];
			entity.CompanyId = (reader.IsDBNull(((int)UserColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)UserColumn.CompanyId - 1)];
			entity.SalesPersonId = (reader.IsDBNull(((int)UserColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)UserColumn.SalesPersonId - 1)];
			entity.RoleId = (reader.IsDBNull(((int)UserColumn.RoleId - 1)))?null:(System.Int32?)reader[((int)UserColumn.RoleId - 1)];
			entity.MustChangePassword = (reader.IsDBNull(((int)UserColumn.MustChangePassword - 1)))?null:(System.Boolean?)reader[((int)UserColumn.MustChangePassword - 1)];
			entity.Address1 = (reader.IsDBNull(((int)UserColumn.Address1 - 1)))?null:(System.String)reader[((int)UserColumn.Address1 - 1)];
			entity.Address2 = (reader.IsDBNull(((int)UserColumn.Address2 - 1)))?null:(System.String)reader[((int)UserColumn.Address2 - 1)];
			entity.City = (reader.IsDBNull(((int)UserColumn.City - 1)))?null:(System.String)reader[((int)UserColumn.City - 1)];
			entity.Country = (reader.IsDBNull(((int)UserColumn.Country - 1)))?null:(System.String)reader[((int)UserColumn.Country - 1)];
			entity.Region = (reader.IsDBNull(((int)UserColumn.Region - 1)))?null:(System.String)reader[((int)UserColumn.Region - 1)];
			entity.PostalCode = (reader.IsDBNull(((int)UserColumn.PostalCode - 1)))?null:(System.String)reader[((int)UserColumn.PostalCode - 1)];
			entity.CharityId = (reader.IsDBNull(((int)UserColumn.CharityId - 1)))?null:(System.Int32?)reader[((int)UserColumn.CharityId - 1)];
			entity.WebMemberId = (reader.IsDBNull(((int)UserColumn.WebMemberId - 1)))?null:(System.String)reader[((int)UserColumn.WebMemberId - 1)];
			entity.UserUniqueId = (System.Guid)reader[((int)UserColumn.UserUniqueId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.User"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.User"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.User entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Int32)dataRow["UserID"];
			entity.Username = (System.String)dataRow["Username"];
			entity.Password = (System.String)dataRow["Password"];
			entity.DisplayName = (System.String)dataRow["DisplayName"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Telephone = Convert.IsDBNull(dataRow["Telephone"]) ? null : (System.String)dataRow["Telephone"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.CompanyId = Convert.IsDBNull(dataRow["CompanyID"]) ? null : (System.Int32?)dataRow["CompanyID"];
			entity.SalesPersonId = Convert.IsDBNull(dataRow["SalesPersonID"]) ? null : (System.Int32?)dataRow["SalesPersonID"];
			entity.RoleId = Convert.IsDBNull(dataRow["RoleID"]) ? null : (System.Int32?)dataRow["RoleID"];
			entity.MustChangePassword = Convert.IsDBNull(dataRow["MustChangePassword"]) ? null : (System.Boolean?)dataRow["MustChangePassword"];
			entity.Address1 = Convert.IsDBNull(dataRow["Address1"]) ? null : (System.String)dataRow["Address1"];
			entity.Address2 = Convert.IsDBNull(dataRow["Address2"]) ? null : (System.String)dataRow["Address2"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.Region = Convert.IsDBNull(dataRow["Region"]) ? null : (System.String)dataRow["Region"];
			entity.PostalCode = Convert.IsDBNull(dataRow["PostalCode"]) ? null : (System.String)dataRow["PostalCode"];
			entity.CharityId = Convert.IsDBNull(dataRow["CharityID"]) ? null : (System.Int32?)dataRow["CharityID"];
			entity.WebMemberId = Convert.IsDBNull(dataRow["WebMemberID"]) ? null : (System.String)dataRow["WebMemberID"];
			entity.UserUniqueId = (System.Guid)dataRow["UserUniqueID"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.User"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.User Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.User entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CharityIdSource	
			if (CanDeepLoad(entity, "Charity|CharityIdSource", deepLoadType, innerList) 
				&& entity.CharityIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CharityId ?? (int)0);
				Charity tmpEntity = EntityManager.LocateEntity<Charity>(EntityLocator.ConstructKeyFromPkItems(typeof(Charity), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CharityIdSource = tmpEntity;
				else
					entity.CharityIdSource = DataRepository.CharityProvider.GetById(transactionManager, (entity.CharityId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CharityIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CharityIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CharityProvider.DeepLoad(transactionManager, entity.CharityIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CharityIdSource

			#region CountrySource	
			if (CanDeepLoad(entity, "Country|CountrySource", deepLoadType, innerList) 
				&& entity.CountrySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Country ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountrySource = tmpEntity;
				else
					entity.CountrySource = DataRepository.CountryProvider.GetById(transactionManager, (entity.Country ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountrySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountrySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.CountrySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountrySource

			#region RoleIdSource	
			if (CanDeepLoad(entity, "Role|RoleIdSource", deepLoadType, innerList) 
				&& entity.RoleIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.RoleId ?? (int)0);
				Role tmpEntity = EntityManager.LocateEntity<Role>(EntityLocator.ConstructKeyFromPkItems(typeof(Role), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RoleIdSource = tmpEntity;
				else
					entity.RoleIdSource = DataRepository.RoleProvider.GetById(transactionManager, (entity.RoleId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RoleIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RoleIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RoleProvider.DeepLoad(transactionManager, entity.RoleIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RoleIdSource

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SalesPersonId ?? (int)0);
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetById(transactionManager, (entity.SalesPersonId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource

			#region RegionSource	
			if (CanDeepLoad(entity, "State|RegionSource", deepLoadType, innerList) 
				&& entity.RegionSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Region ?? string.Empty);
				State tmpEntity = EntityManager.LocateEntity<State>(EntityLocator.ConstructKeyFromPkItems(typeof(State), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RegionSource = tmpEntity;
				else
					entity.RegionSource = DataRepository.StateProvider.GetById(transactionManager, (entity.Region ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RegionSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RegionSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StateProvider.DeepLoad(transactionManager, entity.RegionSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RegionSource

			#region CompanyIdSource	
			if (CanDeepLoad(entity, "Company|CompanyIdSource", deepLoadType, innerList) 
				&& entity.CompanyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CompanyId ?? (int)0);
				Company tmpEntity = EntityManager.LocateEntity<Company>(EntityLocator.ConstructKeyFromPkItems(typeof(Company), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompanyIdSource = tmpEntity;
				else
					entity.CompanyIdSource = DataRepository.CompanyProvider.GetById(transactionManager, (entity.CompanyId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompanyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CompanyProvider.DeepLoad(transactionManager, entity.CompanyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompanyIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByUserId methods when available
			
			#region MarketingServiceIdMarketingServiceCollection_From_User_MarketingService
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<MarketingService>|MarketingServiceIdMarketingServiceCollection_From_User_MarketingService", deepLoadType, innerList))
			{
				entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService = DataRepository.MarketingServiceProvider.GetByUserIdFromUser_MarketingService(transactionManager, entity.UserId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MarketingServiceIdMarketingServiceCollection_From_User_MarketingService' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService != null)
				{
					deepHandles.Add("MarketingServiceIdMarketingServiceCollection_From_User_MarketingService",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< MarketingService >) DataRepository.MarketingServiceProvider.DeepLoad,
						new object[] { transactionManager, entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ModeratorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Moderator>|ModeratorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ModeratorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ModeratorCollection = DataRepository.ModeratorProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.ModeratorCollection.Count > 0)
				{
					deepHandles.Add("ModeratorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Moderator>) DataRepository.ModeratorProvider.DeepLoad,
						new object[] { transactionManager, entity.ModeratorCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region User_MarketingServiceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<User_MarketingService>|User_MarketingServiceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'User_MarketingServiceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.User_MarketingServiceCollection = DataRepository.User_MarketingServiceProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.User_MarketingServiceCollection.Count > 0)
				{
					deepHandles.Add("User_MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<User_MarketingService>) DataRepository.User_MarketingServiceProvider.DeepLoad,
						new object[] { transactionManager, entity.User_MarketingServiceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customer>|CustomerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCollection = DataRepository.CustomerProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.CustomerCollection.Count > 0)
				{
					deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customer>) DataRepository.CustomerProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EventManagerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EventManager>|EventManagerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EventManagerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EventManagerCollection = DataRepository.EventManagerProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.EventManagerCollection.Count > 0)
				{
					deepHandles.Add("EventManagerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EventManager>) DataRepository.EventManagerProvider.DeepLoad,
						new object[] { transactionManager, entity.EventManagerCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the CONFDB.Entities.User object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.User instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.User Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.User entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CharityIdSource
			if (CanDeepSave(entity, "Charity|CharityIdSource", deepSaveType, innerList) 
				&& entity.CharityIdSource != null)
			{
				DataRepository.CharityProvider.Save(transactionManager, entity.CharityIdSource);
				entity.CharityId = entity.CharityIdSource.Id;
			}
			#endregion 
			
			#region CountrySource
			if (CanDeepSave(entity, "Country|CountrySource", deepSaveType, innerList) 
				&& entity.CountrySource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.CountrySource);
				entity.Country = entity.CountrySource.Id;
			}
			#endregion 
			
			#region RoleIdSource
			if (CanDeepSave(entity, "Role|RoleIdSource", deepSaveType, innerList) 
				&& entity.RoleIdSource != null)
			{
				DataRepository.RoleProvider.Save(transactionManager, entity.RoleIdSource);
				entity.RoleId = entity.RoleIdSource.Id;
			}
			#endregion 
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.Id;
			}
			#endregion 
			
			#region RegionSource
			if (CanDeepSave(entity, "State|RegionSource", deepSaveType, innerList) 
				&& entity.RegionSource != null)
			{
				DataRepository.StateProvider.Save(transactionManager, entity.RegionSource);
				entity.Region = entity.RegionSource.Id;
			}
			#endregion 
			
			#region CompanyIdSource
			if (CanDeepSave(entity, "Company|CompanyIdSource", deepSaveType, innerList) 
				&& entity.CompanyIdSource != null)
			{
				DataRepository.CompanyProvider.Save(transactionManager, entity.CompanyIdSource);
				entity.CompanyId = entity.CompanyIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region MarketingServiceIdMarketingServiceCollection_From_User_MarketingService>
			if (CanDeepSave(entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService, "List<MarketingService>|MarketingServiceIdMarketingServiceCollection_From_User_MarketingService", deepSaveType, innerList))
			{
				if (entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService.Count > 0 || entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService.DeletedItems.Count > 0)
				{
					DataRepository.MarketingServiceProvider.Save(transactionManager, entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService); 
					deepHandles.Add("MarketingServiceIdMarketingServiceCollection_From_User_MarketingService",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<MarketingService>) DataRepository.MarketingServiceProvider.DeepSave,
						new object[] { transactionManager, entity.MarketingServiceIdMarketingServiceCollection_From_User_MarketingService, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Moderator>
				if (CanDeepSave(entity.ModeratorCollection, "List<Moderator>|ModeratorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Moderator child in entity.ModeratorCollection)
					{
						if(child.UserIdSource != null)
						{
							child.UserId = child.UserIdSource.UserId;
						}
						else
						{
							child.UserId = entity.UserId;
						}

					}

					if (entity.ModeratorCollection.Count > 0 || entity.ModeratorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ModeratorProvider.Save(transactionManager, entity.ModeratorCollection);
						
						deepHandles.Add("ModeratorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Moderator >) DataRepository.ModeratorProvider.DeepSave,
							new object[] { transactionManager, entity.ModeratorCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<User_MarketingService>
				if (CanDeepSave(entity.User_MarketingServiceCollection, "List<User_MarketingService>|User_MarketingServiceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(User_MarketingService child in entity.User_MarketingServiceCollection)
					{
						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

						if(child.MarketingServiceIdSource != null)
						{
								child.MarketingServiceId = child.MarketingServiceIdSource.Id;
						}

					}

					if (entity.User_MarketingServiceCollection.Count > 0 || entity.User_MarketingServiceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.User_MarketingServiceProvider.Save(transactionManager, entity.User_MarketingServiceCollection);
						
						deepHandles.Add("User_MarketingServiceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< User_MarketingService >) DataRepository.User_MarketingServiceProvider.DeepSave,
							new object[] { transactionManager, entity.User_MarketingServiceCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Customer>
				if (CanDeepSave(entity.CustomerCollection, "List<Customer>|CustomerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customer child in entity.CustomerCollection)
					{
						if(child.UserIdSource != null)
						{
							child.UserId = child.UserIdSource.UserId;
						}
						else
						{
							child.UserId = entity.UserId;
						}

					}

					if (entity.CustomerCollection.Count > 0 || entity.CustomerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerCollection);
						
						deepHandles.Add("CustomerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customer >) DataRepository.CustomerProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EventManager>
				if (CanDeepSave(entity.EventManagerCollection, "List<EventManager>|EventManagerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EventManager child in entity.EventManagerCollection)
					{
						if(child.UserIdSource != null)
						{
							child.UserId = child.UserIdSource.UserId;
						}
						else
						{
							child.UserId = entity.UserId;
						}

					}

					if (entity.EventManagerCollection.Count > 0 || entity.EventManagerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EventManagerProvider.Save(transactionManager, entity.EventManagerCollection);
						
						deepHandles.Add("EventManagerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EventManager >) DataRepository.EventManagerProvider.DeepSave,
							new object[] { transactionManager, entity.EventManagerCollection, deepSaveType, childTypes, innerList }
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
	
	#region UserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.User</c>
	///</summary>
	public enum UserChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Charity</c> at CharityIdSource
		///</summary>
		[ChildEntityType(typeof(Charity))]
		Charity,
			
		///<summary>
		/// Composite Property for <c>Country</c> at CountrySource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
			
		///<summary>
		/// Composite Property for <c>Role</c> at RoleIdSource
		///</summary>
		[ChildEntityType(typeof(Role))]
		Role,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>State</c> at RegionSource
		///</summary>
		[ChildEntityType(typeof(State))]
		State,
			
		///<summary>
		/// Composite Property for <c>Company</c> at CompanyIdSource
		///</summary>
		[ChildEntityType(typeof(Company))]
		Company,
	
		///<summary>
		/// Collection of <c>User</c> as ManyToMany for MarketingServiceCollection_From_User_MarketingService
		///</summary>
		[ChildEntityType(typeof(TList<MarketingService>))]
		MarketingServiceIdMarketingServiceCollection_From_User_MarketingService,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for ModeratorCollection
		///</summary>
		[ChildEntityType(typeof(TList<Moderator>))]
		ModeratorCollection,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for User_MarketingServiceCollection
		///</summary>
		[ChildEntityType(typeof(TList<User_MarketingService>))]
		User_MarketingServiceCollection,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for CustomerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customer>))]
		CustomerCollection,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for EventManagerCollection
		///</summary>
		[ChildEntityType(typeof(TList<EventManager>))]
		EventManagerCollection,
	}
	
	#endregion UserChildEntityTypes
	
	#region UserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilterBuilder : SqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		public UserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilterBuilder
	
	#region UserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserParameterBuilder : ParameterizedSqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		public UserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserParameterBuilder
} // end namespace
