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
	/// This class is the base class for any <see cref="EmailNotificationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailNotificationProviderBaseCore : EntityProviderBase<CONFDB.Entities.EmailNotification, CONFDB.Entities.EmailNotificationKey>
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
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.EmailNotificationKey key)
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
		public override CONFDB.Entities.EmailNotification Get(TransactionManager transactionManager, CONFDB.Entities.EmailNotificationKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmailNotification index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public CONFDB.Entities.EmailNotification GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailNotification index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public CONFDB.Entities.EmailNotification GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailNotification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public CONFDB.Entities.EmailNotification GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailNotification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public CONFDB.Entities.EmailNotification GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailNotification index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public CONFDB.Entities.EmailNotification GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailNotification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.EmailNotification"/> class.</returns>
		public abstract CONFDB.Entities.EmailNotification GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmail(System.String _email)
		{
			int count = -1;
			return GetByEmail(null,_email, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmail(System.String _email, int start, int pageLength)
		{
			int count = -1;
			return GetByEmail(null, _email, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmail(TransactionManager transactionManager, System.String _email)
		{
			int count = -1;
			return GetByEmail(transactionManager, _email, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmail(TransactionManager transactionManager, System.String _email, int start, int pageLength)
		{
			int count = -1;
			return GetByEmail(transactionManager, _email, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmail(System.String _email, int start, int pageLength, out int count)
		{
			return GetByEmail(null, _email, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_email">Email used for scenarios where you need to filter out emails you have already sent to.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<EmailNotification> GetByEmail(TransactionManager transactionManager, System.String _email, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="_emailSent"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmailSent(System.Boolean _emailSent)
		{
			int count = -1;
			return GetByEmailSent(null,_emailSent, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="_emailSent"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmailSent(System.Boolean _emailSent, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailSent(null, _emailSent, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailSent"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmailSent(TransactionManager transactionManager, System.Boolean _emailSent)
		{
			int count = -1;
			return GetByEmailSent(transactionManager, _emailSent, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailSent"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmailSent(TransactionManager transactionManager, System.Boolean _emailSent, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailSent(transactionManager, _emailSent, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="_emailSent"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByEmailSent(System.Boolean _emailSent, int start, int pageLength, out int count)
		{
			return GetByEmailSent(null, _emailSent, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_EmailSent index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailSent"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<EmailNotification> GetByEmailSent(TransactionManager transactionManager, System.Boolean _emailSent, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="_sentDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetBySentDate(System.DateTime? _sentDate)
		{
			int count = -1;
			return GetBySentDate(null,_sentDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="_sentDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetBySentDate(System.DateTime? _sentDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySentDate(null, _sentDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sentDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetBySentDate(TransactionManager transactionManager, System.DateTime? _sentDate)
		{
			int count = -1;
			return GetBySentDate(transactionManager, _sentDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sentDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetBySentDate(TransactionManager transactionManager, System.DateTime? _sentDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySentDate(transactionManager, _sentDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="_sentDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetBySentDate(System.DateTime? _sentDate, int start, int pageLength, out int count)
		{
			return GetBySentDate(null, _sentDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_SentDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sentDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<EmailNotification> GetBySentDate(TransactionManager transactionManager, System.DateTime? _sentDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(System.String _templateName, System.DateTime _createdDate)
		{
			int count = -1;
			return GetByTemplateNameCreatedDate(null,_templateName, _createdDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(System.String _templateName, System.DateTime _createdDate, int start, int pageLength)
		{
			int count = -1;
			return GetByTemplateNameCreatedDate(null, _templateName, _createdDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(TransactionManager transactionManager, System.String _templateName, System.DateTime _createdDate)
		{
			int count = -1;
			return GetByTemplateNameCreatedDate(transactionManager, _templateName, _createdDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(TransactionManager transactionManager, System.String _templateName, System.DateTime _createdDate, int start, int pageLength)
		{
			int count = -1;
			return GetByTemplateNameCreatedDate(transactionManager, _templateName, _createdDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(System.String _templateName, System.DateTime _createdDate, int start, int pageLength, out int count)
		{
			return GetByTemplateNameCreatedDate(null, _templateName, _createdDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_EmailNotification_TemplateName_CreatedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_templateName">Name of the email template to use for sending notifications</param>
		/// <param name="_createdDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/> class.</returns>
		public abstract CONFDB.Entities.TList<EmailNotification> GetByTemplateNameCreatedDate(TransactionManager transactionManager, System.String _templateName, System.DateTime _createdDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;EmailNotification&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;EmailNotification&gt;"/></returns>
		public static CONFDB.Entities.TList<EmailNotification> Fill(IDataReader reader, CONFDB.Entities.TList<EmailNotification> rows, int start, int pageLength)
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
				
				CONFDB.Entities.EmailNotification c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmailNotification")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.EmailNotificationColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.EmailNotificationColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<EmailNotification>(
					key.ToString(), // EntityTrackingKey
					"EmailNotification",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.EmailNotification();
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
					c.Id = (System.Int32)reader[((int)EmailNotificationColumn.Id - 1)];
					c.TemplateName = (System.String)reader[((int)EmailNotificationColumn.TemplateName - 1)];
					c.ModeratorId = (System.Int32)reader[((int)EmailNotificationColumn.ModeratorId - 1)];
					c.Email = (reader.IsDBNull(((int)EmailNotificationColumn.Email - 1)))?null:(System.String)reader[((int)EmailNotificationColumn.Email - 1)];
					c.EmailSent = (System.Boolean)reader[((int)EmailNotificationColumn.EmailSent - 1)];
					c.SentDate = (reader.IsDBNull(((int)EmailNotificationColumn.SentDate - 1)))?null:(System.DateTime?)reader[((int)EmailNotificationColumn.SentDate - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)EmailNotificationColumn.CreatedDate - 1)];
					c.ErrorInfo = (reader.IsDBNull(((int)EmailNotificationColumn.ErrorInfo - 1)))?null:(System.String)reader[((int)EmailNotificationColumn.ErrorInfo - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.EmailNotification"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailNotification"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.EmailNotification entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)EmailNotificationColumn.Id - 1)];
			entity.TemplateName = (System.String)reader[((int)EmailNotificationColumn.TemplateName - 1)];
			entity.ModeratorId = (System.Int32)reader[((int)EmailNotificationColumn.ModeratorId - 1)];
			entity.Email = (reader.IsDBNull(((int)EmailNotificationColumn.Email - 1)))?null:(System.String)reader[((int)EmailNotificationColumn.Email - 1)];
			entity.EmailSent = (System.Boolean)reader[((int)EmailNotificationColumn.EmailSent - 1)];
			entity.SentDate = (reader.IsDBNull(((int)EmailNotificationColumn.SentDate - 1)))?null:(System.DateTime?)reader[((int)EmailNotificationColumn.SentDate - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)EmailNotificationColumn.CreatedDate - 1)];
			entity.ErrorInfo = (reader.IsDBNull(((int)EmailNotificationColumn.ErrorInfo - 1)))?null:(System.String)reader[((int)EmailNotificationColumn.ErrorInfo - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.EmailNotification"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailNotification"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.EmailNotification entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.TemplateName = (System.String)dataRow["TemplateName"];
			entity.ModeratorId = (System.Int32)dataRow["ModeratorID"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.EmailSent = (System.Boolean)dataRow["EmailSent"];
			entity.SentDate = Convert.IsDBNull(dataRow["SentDate"]) ? null : (System.DateTime?)dataRow["SentDate"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.ErrorInfo = Convert.IsDBNull(dataRow["ErrorInfo"]) ? null : (System.String)dataRow["ErrorInfo"];
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
		/// <param name="entity">The <see cref="CONFDB.Entities.EmailNotification"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.EmailNotification Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.EmailNotification entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the CONFDB.Entities.EmailNotification object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.EmailNotification instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.EmailNotification Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.EmailNotification entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region EmailNotificationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.EmailNotification</c>
	///</summary>
	public enum EmailNotificationChildEntityTypes
	{
	}
	
	#endregion EmailNotificationChildEntityTypes
	
	#region EmailNotificationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmailNotificationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationFilterBuilder : SqlFilterBuilder<EmailNotificationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilterBuilder class.
		/// </summary>
		public EmailNotificationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailNotificationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailNotificationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailNotificationFilterBuilder
	
	#region EmailNotificationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmailNotificationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailNotification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailNotificationParameterBuilder : ParameterizedSqlFilterBuilder<EmailNotificationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailNotificationParameterBuilder class.
		/// </summary>
		public EmailNotificationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailNotificationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailNotificationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailNotificationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailNotificationParameterBuilder
} // end namespace
