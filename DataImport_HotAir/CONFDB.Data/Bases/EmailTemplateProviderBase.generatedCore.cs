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
	/// This class is the base class for any <see cref="EmailTemplateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailTemplateProviderBaseCore : EntityProviderBase<CONFDB.Entities.EmailTemplate, CONFDB.Entities.EmailTemplateKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.EmailTemplateKey key)
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
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		CallFlow_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="_callFlowId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(System.Int32? _callFlowId)
		{
			int count = -1;
			return GetByCallFlowId(_callFlowId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		CallFlow_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId)
		{
			int count = -1;
			return GetByCallFlowId(transactionManager, _callFlowId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		CallFlow_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId, int start, int pageLength)
		{
			int count = -1;
			return GetByCallFlowId(transactionManager, _callFlowId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		callFlow_EmailTemplates_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_callFlowId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(System.Int32? _callFlowId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCallFlowId(null, _callFlowId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		callFlow_EmailTemplates_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_callFlowId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(System.Int32? _callFlowId, int start, int pageLength,out int count)
		{
			return GetByCallFlowId(null, _callFlowId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the CallFlow_EmailTemplates_FK key.
		///		CallFlow_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callFlowId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public abstract CONFDB.Entities.TList<EmailTemplate> GetByCallFlowId(TransactionManager transactionManager, System.Int32? _callFlowId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		FK_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(_wholesalerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		FK_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		FK_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerId(transactionManager, _wholesalerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		fk_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWholesalerId(null, _wholesalerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		fk_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(System.String _wholesalerId, int start, int pageLength,out int count)
		{
			return GetByWholesalerId(null, _wholesalerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_Wholesaler key.
		///		FK_EmailTemplates_Wholesaler Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public abstract CONFDB.Entities.TList<EmailTemplate> GetByWholesalerId(TransactionManager transactionManager, System.String _wholesalerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		Language_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		Language_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(TransactionManager transactionManager, System.String _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		Language_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		language_EmailTemplates_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(System.String _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		language_EmailTemplates_Fk Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(System.String _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the Language_EmailTemplates_FK key.
		///		Language_EmailTemplates_FK Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.EmailTemplate objects.</returns>
		public abstract CONFDB.Entities.TList<EmailTemplate> GetByLanguageId(TransactionManager transactionManager, System.String _languageId, int start, int pageLength, out int count);
		
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
		public override CONFDB.Entities.EmailTemplate Get(TransactionManager transactionManager, CONFDB.Entities.EmailTemplateKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key EmailTemplates_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public abstract CONFDB.Entities.EmailTemplate GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdTemplateNamePriCustomerNumber(null,_wholesalerId, _templateName, _priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdTemplateNamePriCustomerNumber(null, _wholesalerId, _templateName, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber)
		{
			int count = -1;
			return GetByWholesalerIdTemplateNamePriCustomerNumber(transactionManager, _wholesalerId, _templateName, _priCustomerNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdTemplateNamePriCustomerNumber(transactionManager, _wholesalerId, _templateName, _priCustomerNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdTemplateNamePriCustomerNumber(null, _wholesalerId, _templateName, _priCustomerNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the EmailTemplates_UC1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="_priCustomerNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailTemplate"/> class.</returns>
		public abstract CONFDB.Entities.EmailTemplate GetByWholesalerIdTemplateNamePriCustomerNumber(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName, System.String _priCustomerNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(System.String _wholesalerId, System.String _templateName)
		{
			int count = -1;
			return GetByWholesalerIdTemplateName(null,_wholesalerId, _templateName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(System.String _wholesalerId, System.String _templateName, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdTemplateName(null, _wholesalerId, _templateName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName)
		{
			int count = -1;
			return GetByWholesalerIdTemplateName(transactionManager, _wholesalerId, _templateName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName, int start, int pageLength)
		{
			int count = -1;
			return GetByWholesalerIdTemplateName(transactionManager, _wholesalerId, _templateName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(System.String _wholesalerId, System.String _templateName, int start, int pageLength, out int count)
		{
			return GetByWholesalerIdTemplateName(null, _wholesalerId, _templateName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailTemplate_WholesalerID_TemplateName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_wholesalerId"></param>
		/// <param name="_templateName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<EmailTemplate> GetByWholesalerIdTemplateName(TransactionManager transactionManager, System.String _wholesalerId, System.String _templateName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region p_EmailTemplate_GetEmailTemplates 
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailTemplates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplate&gt;"/> instance.</returns>
		public TList<EmailTemplate> GetEmailTemplates(System.String wholesalerId, System.String templateName, System.String priCustomerNumber, System.Int32? moderatorId)
		{
			return GetEmailTemplates(null, 0, int.MaxValue , wholesalerId, templateName, priCustomerNumber, moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailTemplates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplate&gt;"/> instance.</returns>
		public TList<EmailTemplate> GetEmailTemplates(int start, int pageLength, System.String wholesalerId, System.String templateName, System.String priCustomerNumber, System.Int32? moderatorId)
		{
			return GetEmailTemplates(null, start, pageLength , wholesalerId, templateName, priCustomerNumber, moderatorId);
		}
				
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailTemplates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplate&gt;"/> instance.</returns>
		public TList<EmailTemplate> GetEmailTemplates(TransactionManager transactionManager, System.String wholesalerId, System.String templateName, System.String priCustomerNumber, System.Int32? moderatorId)
		{
			return GetEmailTemplates(transactionManager, 0, int.MaxValue , wholesalerId, templateName, priCustomerNumber, moderatorId);
		}
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailTemplates' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="priCustomerNumber"> A <c>System.String</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplate&gt;"/> instance.</returns>
		public abstract TList<EmailTemplate> GetEmailTemplates(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.String templateName, System.String priCustomerNumber, System.Int32? moderatorId);
		
		#endregion
		
		#region p_EmailTemplate_GetEmailInfo 
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetEmailInfo(System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? recordingId)
		{
			return GetEmailInfo(null, 0, int.MaxValue , wholesalerId, customerId, moderatorId, recordingId);
		}
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetEmailInfo(int start, int pageLength, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? recordingId)
		{
			return GetEmailInfo(null, start, pageLength , wholesalerId, customerId, moderatorId, recordingId);
		}
				
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetEmailInfo(TransactionManager transactionManager, System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? recordingId)
		{
			return GetEmailInfo(transactionManager, 0, int.MaxValue , wholesalerId, customerId, moderatorId, recordingId);
		}
		
		/// <summary>
		///	This method wrap the 'p_EmailTemplate_GetEmailInfo' stored procedure. 
		/// </summary>
		/// <param name="wholesalerId"> A <c>System.String</c> instance.</param>
		/// <param name="customerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="moderatorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="recordingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetEmailInfo(TransactionManager transactionManager, int start, int pageLength , System.String wholesalerId, System.Int32? customerId, System.Int32? moderatorId, System.Int32? recordingId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;EmailTemplate&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;EmailTemplate&gt;"/></returns>
		public static CONFDB.Entities.TList<EmailTemplate> Fill(IDataReader reader, CONFDB.Entities.TList<EmailTemplate> rows, int start, int pageLength)
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
				
				CONFDB.Entities.EmailTemplate c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmailTemplate")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.EmailTemplateColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.EmailTemplateColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<EmailTemplate>(
					key.ToString(), // EntityTrackingKey
					"EmailTemplate",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.EmailTemplate();
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
					c.Id = (System.Int32)reader[((int)EmailTemplateColumn.Id - 1)];
					c.WholesalerId = (System.String)reader[((int)EmailTemplateColumn.WholesalerId - 1)];
					c.SmtpServer = (System.String)reader[((int)EmailTemplateColumn.SmtpServer - 1)];
					c.SmtpUserName = (reader.IsDBNull(((int)EmailTemplateColumn.SmtpUserName - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.SmtpUserName - 1)];
					c.SmtpPassword = (reader.IsDBNull(((int)EmailTemplateColumn.SmtpPassword - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.SmtpPassword - 1)];
					c.BaseFileDirectory = (System.String)reader[((int)EmailTemplateColumn.BaseFileDirectory - 1)];
					c.TemplateName = (System.String)reader[((int)EmailTemplateColumn.TemplateName - 1)];
					c.Description = (reader.IsDBNull(((int)EmailTemplateColumn.Description - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.Description - 1)];
					c.FileName = (System.String)reader[((int)EmailTemplateColumn.FileName - 1)];
					c.Subject = (System.String)reader[((int)EmailTemplateColumn.Subject - 1)];
					c.Sender = (System.String)reader[((int)EmailTemplateColumn.Sender - 1)];
					c.BccList = (reader.IsDBNull(((int)EmailTemplateColumn.BccList - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.BccList - 1)];
					c.CcList = (reader.IsDBNull(((int)EmailTemplateColumn.CcList - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.CcList - 1)];
					c.SendToContact = (System.Boolean)reader[((int)EmailTemplateColumn.SendToContact - 1)];
					c.SendToModerator = (System.Boolean)reader[((int)EmailTemplateColumn.SendToModerator - 1)];
					c.IncludeAttachment = (System.Boolean)reader[((int)EmailTemplateColumn.IncludeAttachment - 1)];
					c.AttachmentFileName = (reader.IsDBNull(((int)EmailTemplateColumn.AttachmentFileName - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.AttachmentFileName - 1)];
					c.PriCustomerNumber = (reader.IsDBNull(((int)EmailTemplateColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.PriCustomerNumber - 1)];
					c.EmailTemplateContentTypeId = (System.Int32)reader[((int)EmailTemplateColumn.EmailTemplateContentTypeId - 1)];
					c.EmailTemplateGroupId = (System.Int32)reader[((int)EmailTemplateColumn.EmailTemplateGroupId - 1)];
					c.CallFlowId = (reader.IsDBNull(((int)EmailTemplateColumn.CallFlowId - 1)))?null:(System.Int32?)reader[((int)EmailTemplateColumn.CallFlowId - 1)];
					c.LanguageId = (System.String)reader[((int)EmailTemplateColumn.LanguageId - 1)];
					c.Enabled = (System.Boolean)reader[((int)EmailTemplateColumn.Enabled - 1)];
					c.DisplayOrder = (System.Int32)reader[((int)EmailTemplateColumn.DisplayOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.EmailTemplate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailTemplate"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.EmailTemplate entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)EmailTemplateColumn.Id - 1)];
			entity.WholesalerId = (System.String)reader[((int)EmailTemplateColumn.WholesalerId - 1)];
			entity.SmtpServer = (System.String)reader[((int)EmailTemplateColumn.SmtpServer - 1)];
			entity.SmtpUserName = (reader.IsDBNull(((int)EmailTemplateColumn.SmtpUserName - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.SmtpUserName - 1)];
			entity.SmtpPassword = (reader.IsDBNull(((int)EmailTemplateColumn.SmtpPassword - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.SmtpPassword - 1)];
			entity.BaseFileDirectory = (System.String)reader[((int)EmailTemplateColumn.BaseFileDirectory - 1)];
			entity.TemplateName = (System.String)reader[((int)EmailTemplateColumn.TemplateName - 1)];
			entity.Description = (reader.IsDBNull(((int)EmailTemplateColumn.Description - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.Description - 1)];
			entity.FileName = (System.String)reader[((int)EmailTemplateColumn.FileName - 1)];
			entity.Subject = (System.String)reader[((int)EmailTemplateColumn.Subject - 1)];
			entity.Sender = (System.String)reader[((int)EmailTemplateColumn.Sender - 1)];
			entity.BccList = (reader.IsDBNull(((int)EmailTemplateColumn.BccList - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.BccList - 1)];
			entity.CcList = (reader.IsDBNull(((int)EmailTemplateColumn.CcList - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.CcList - 1)];
			entity.SendToContact = (System.Boolean)reader[((int)EmailTemplateColumn.SendToContact - 1)];
			entity.SendToModerator = (System.Boolean)reader[((int)EmailTemplateColumn.SendToModerator - 1)];
			entity.IncludeAttachment = (System.Boolean)reader[((int)EmailTemplateColumn.IncludeAttachment - 1)];
			entity.AttachmentFileName = (reader.IsDBNull(((int)EmailTemplateColumn.AttachmentFileName - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.AttachmentFileName - 1)];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)EmailTemplateColumn.PriCustomerNumber - 1)))?null:(System.String)reader[((int)EmailTemplateColumn.PriCustomerNumber - 1)];
			entity.EmailTemplateContentTypeId = (System.Int32)reader[((int)EmailTemplateColumn.EmailTemplateContentTypeId - 1)];
			entity.EmailTemplateGroupId = (System.Int32)reader[((int)EmailTemplateColumn.EmailTemplateGroupId - 1)];
			entity.CallFlowId = (reader.IsDBNull(((int)EmailTemplateColumn.CallFlowId - 1)))?null:(System.Int32?)reader[((int)EmailTemplateColumn.CallFlowId - 1)];
			entity.LanguageId = (System.String)reader[((int)EmailTemplateColumn.LanguageId - 1)];
			entity.Enabled = (System.Boolean)reader[((int)EmailTemplateColumn.Enabled - 1)];
			entity.DisplayOrder = (System.Int32)reader[((int)EmailTemplateColumn.DisplayOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.EmailTemplate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailTemplate"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.EmailTemplate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.WholesalerId = (System.String)dataRow["WholesalerID"];
			entity.SmtpServer = (System.String)dataRow["SMTPServer"];
			entity.SmtpUserName = Convert.IsDBNull(dataRow["SMTPUserName"]) ? null : (System.String)dataRow["SMTPUserName"];
			entity.SmtpPassword = Convert.IsDBNull(dataRow["SMTPPassword"]) ? null : (System.String)dataRow["SMTPPassword"];
			entity.BaseFileDirectory = (System.String)dataRow["BaseFileDirectory"];
			entity.TemplateName = (System.String)dataRow["TemplateName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.FileName = (System.String)dataRow["FileName"];
			entity.Subject = (System.String)dataRow["Subject"];
			entity.Sender = (System.String)dataRow["Sender"];
			entity.BccList = Convert.IsDBNull(dataRow["BCCList"]) ? null : (System.String)dataRow["BCCList"];
			entity.CcList = Convert.IsDBNull(dataRow["CCList"]) ? null : (System.String)dataRow["CCList"];
			entity.SendToContact = (System.Boolean)dataRow["SendToContact"];
			entity.SendToModerator = (System.Boolean)dataRow["SendToModerator"];
			entity.IncludeAttachment = (System.Boolean)dataRow["IncludeAttachment"];
			entity.AttachmentFileName = Convert.IsDBNull(dataRow["AttachmentFileName"]) ? null : (System.String)dataRow["AttachmentFileName"];
			entity.PriCustomerNumber = Convert.IsDBNull(dataRow["PriCustomerNumber"]) ? null : (System.String)dataRow["PriCustomerNumber"];
			entity.EmailTemplateContentTypeId = (System.Int32)dataRow["EmailTemplateContentTypeID"];
			entity.EmailTemplateGroupId = (System.Int32)dataRow["EmailTemplateGroupID"];
			entity.CallFlowId = Convert.IsDBNull(dataRow["CallFlowID"]) ? null : (System.Int32?)dataRow["CallFlowID"];
			entity.LanguageId = (System.String)dataRow["LanguageID"];
			entity.Enabled = (System.Boolean)dataRow["Enabled"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailTemplate"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.EmailTemplate Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.EmailTemplate entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Language|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LanguageId;
				Language tmpEntity = EntityManager.LocateEntity<Language>(EntityLocator.ConstructKeyFromPkItems(typeof(Language), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguageProvider.GetById(transactionManager, entity.LanguageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguageProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource
			
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
		/// Deep Save the entire object graph of the CONFDB.Entities.EmailTemplate object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.EmailTemplate instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.EmailTemplate Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.EmailTemplate entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CallFlowIdSource
			if (CanDeepSave(entity, "CallFlow|CallFlowIdSource", deepSaveType, innerList) 
				&& entity.CallFlowIdSource != null)
			{
				DataRepository.CallFlowProvider.Save(transactionManager, entity.CallFlowIdSource);
				entity.CallFlowId = entity.CallFlowIdSource.Id;
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
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Language|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguageProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.Id;
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
	
	#region EmailTemplateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.EmailTemplate</c>
	///</summary>
	public enum EmailTemplateChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CallFlow</c> at CallFlowIdSource
		///</summary>
		[ChildEntityType(typeof(CallFlow))]
		CallFlow,
			
		///<summary>
		/// Composite Property for <c>Wholesaler</c> at WholesalerIdSource
		///</summary>
		[ChildEntityType(typeof(Wholesaler))]
		Wholesaler,
			
		///<summary>
		/// Composite Property for <c>Language</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Language))]
		Language,
		}
	
	#endregion EmailTemplateChildEntityTypes
	
	#region EmailTemplateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmailTemplateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateFilterBuilder : SqlFilterBuilder<EmailTemplateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilterBuilder class.
		/// </summary>
		public EmailTemplateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplateFilterBuilder
	
	#region EmailTemplateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmailTemplateColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplateParameterBuilder : ParameterizedSqlFilterBuilder<EmailTemplateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplateParameterBuilder class.
		/// </summary>
		public EmailTemplateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplateParameterBuilder
} // end namespace
