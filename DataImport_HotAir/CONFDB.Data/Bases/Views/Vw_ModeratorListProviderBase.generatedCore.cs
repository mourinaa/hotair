#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CONFDB.Entities;
using CONFDB.Data;

#endregion

namespace CONFDB.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="Vw_ModeratorListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_ModeratorListProviderBaseCore : EntityViewProviderBase<Vw_ModeratorList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_ModeratorList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_ModeratorList&gt;"/></returns>
		protected static VList&lt;Vw_ModeratorList&gt; Fill(DataSet dataSet, VList<Vw_ModeratorList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_ModeratorList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_ModeratorList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_ModeratorList>"/></returns>
		protected static VList&lt;Vw_ModeratorList&gt; Fill(DataTable dataTable, VList<Vw_ModeratorList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_ModeratorList c = new Vw_ModeratorList();
					c.Id = (Convert.IsDBNull(row["ID"]))?(int)0:(System.Int32)row["ID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.PriCustomerNumber = (Convert.IsDBNull(row["PriCustomerNumber"]))?string.Empty:(System.String)row["PriCustomerNumber"];
					c.SecCustomerNumber = (Convert.IsDBNull(row["SecCustomerNumber"]))?string.Empty:(System.String)row["SecCustomerNumber"];
					c.ExternalModeratorNumber = (Convert.IsDBNull(row["ExternalModeratorNumber"]))?string.Empty:(System.String)row["ExternalModeratorNumber"];
					c.ModeratorCode = (Convert.IsDBNull(row["ModeratorCode"]))?string.Empty:(System.String)row["ModeratorCode"];
					c.PassCode = (Convert.IsDBNull(row["PassCode"]))?string.Empty:(System.String)row["PassCode"];
					c.SeeVoghMeetingId = (Convert.IsDBNull(row["SeeVoghMeetingId"]))?string.Empty:(System.String)row["SeeVoghMeetingId"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.DepartmentId = (Convert.IsDBNull(row["DepartmentID"]))?(int)0:(System.Int32)row["DepartmentID"];
					c.ModifiedBy = (Convert.IsDBNull(row["ModifiedBy"]))?string.Empty:(System.String)row["ModifiedBy"];
					c.CreatedDate = (Convert.IsDBNull(row["CreatedDate"]))?DateTime.MinValue:(System.DateTime)row["CreatedDate"];
					c.LastModified = (Convert.IsDBNull(row["LastModified"]))?DateTime.MinValue:(System.DateTime)row["LastModified"];
					c.Enabled = (Convert.IsDBNull(row["Enabled"]))?false:(System.Boolean?)row["Enabled"];
					c.UniqueModeratorId = (Convert.IsDBNull(row["UniqueModeratorID"]))?Guid.Empty:(System.Guid)row["UniqueModeratorID"];
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32?)row["UserID"];
					c.WebMeetingId = (Convert.IsDBNull(row["WebMeetingID"]))?string.Empty:(System.String)row["WebMeetingID"];
					c.DepartmentName = (Convert.IsDBNull(row["DepartmentName"]))?string.Empty:(System.String)row["DepartmentName"];
					c.Username = (Convert.IsDBNull(row["Username"]))?string.Empty:(System.String)row["Username"];
					c.Password = (Convert.IsDBNull(row["Password"]))?string.Empty:(System.String)row["Password"];
					c.DisplayName = (Convert.IsDBNull(row["DisplayName"]))?string.Empty:(System.String)row["DisplayName"];
					c.Email = (Convert.IsDBNull(row["Email"]))?string.Empty:(System.String)row["Email"];
					c.Telephone = (Convert.IsDBNull(row["Telephone"]))?string.Empty:(System.String)row["Telephone"];
					c.UserEnabled = (Convert.IsDBNull(row["UserEnabled"]))?false:(System.Boolean)row["UserEnabled"];
					c.RoleId = (Convert.IsDBNull(row["RoleID"]))?(int)0:(System.Int32?)row["RoleID"];
					c.MustChangePassword = (Convert.IsDBNull(row["MustChangePassword"]))?false:(System.Boolean?)row["MustChangePassword"];
					c.CharityId = (Convert.IsDBNull(row["CharityID"]))?(int)0:(System.Int32?)row["CharityID"];
					c.WebMemberId = (Convert.IsDBNull(row["WebMemberID"]))?string.Empty:(System.String)row["WebMemberID"];
					c.DdlDescription = (Convert.IsDBNull(row["DDLDescription"]))?string.Empty:(System.String)row["DDLDescription"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;Vw_ModeratorList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_ModeratorList&gt;"/></returns>
		protected VList<Vw_ModeratorList> Fill(IDataReader reader, VList<Vw_ModeratorList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_ModeratorList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_ModeratorList>("Vw_ModeratorList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_ModeratorList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int32)reader[((int)Vw_ModeratorListColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_ModeratorListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (System.Int32)reader[((int)Vw_ModeratorListColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.PriCustomerNumber = (System.String)reader[((int)Vw_ModeratorListColumn.PriCustomerNumber)];
					//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
					entity.SecCustomerNumber = (System.String)reader[((int)Vw_ModeratorListColumn.SecCustomerNumber)];
					//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
					entity.ExternalModeratorNumber = (reader.IsDBNull(((int)Vw_ModeratorListColumn.ExternalModeratorNumber)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.ExternalModeratorNumber)];
					//entity.ExternalModeratorNumber = (Convert.IsDBNull(reader["ExternalModeratorNumber"]))?string.Empty:(System.String)reader["ExternalModeratorNumber"];
					entity.ModeratorCode = (System.String)reader[((int)Vw_ModeratorListColumn.ModeratorCode)];
					//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
					entity.PassCode = (System.String)reader[((int)Vw_ModeratorListColumn.PassCode)];
					//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
					entity.SeeVoghMeetingId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.SeeVoghMeetingId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.SeeVoghMeetingId)];
					//entity.SeeVoghMeetingId = (Convert.IsDBNull(reader["SeeVoghMeetingId"]))?string.Empty:(System.String)reader["SeeVoghMeetingId"];
					entity.Description = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Description)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.DepartmentId = (System.Int32)reader[((int)Vw_ModeratorListColumn.DepartmentId)];
					//entity.DepartmentId = (Convert.IsDBNull(reader["DepartmentID"]))?(int)0:(System.Int32)reader["DepartmentID"];
					entity.ModifiedBy = (reader.IsDBNull(((int)Vw_ModeratorListColumn.ModifiedBy)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.ModifiedBy)];
					//entity.ModifiedBy = (Convert.IsDBNull(reader["ModifiedBy"]))?string.Empty:(System.String)reader["ModifiedBy"];
					entity.CreatedDate = (System.DateTime)reader[((int)Vw_ModeratorListColumn.CreatedDate)];
					//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime)reader["CreatedDate"];
					entity.LastModified = (System.DateTime)reader[((int)Vw_ModeratorListColumn.LastModified)];
					//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
					entity.Enabled = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_ModeratorListColumn.Enabled)];
					//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
					entity.UniqueModeratorId = (System.Guid)reader[((int)Vw_ModeratorListColumn.UniqueModeratorId)];
					//entity.UniqueModeratorId = (Convert.IsDBNull(reader["UniqueModeratorID"]))?Guid.Empty:(System.Guid)reader["UniqueModeratorID"];
					entity.UserId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.UserId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32?)reader["UserID"];
					entity.WebMeetingId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.WebMeetingId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.WebMeetingId)];
					//entity.WebMeetingId = (Convert.IsDBNull(reader["WebMeetingID"]))?string.Empty:(System.String)reader["WebMeetingID"];
					entity.DepartmentName = (reader.IsDBNull(((int)Vw_ModeratorListColumn.DepartmentName)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.DepartmentName)];
					//entity.DepartmentName = (Convert.IsDBNull(reader["DepartmentName"]))?string.Empty:(System.String)reader["DepartmentName"];
					entity.Username = (System.String)reader[((int)Vw_ModeratorListColumn.Username)];
					//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
					entity.Password = (System.String)reader[((int)Vw_ModeratorListColumn.Password)];
					//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
					entity.DisplayName = (System.String)reader[((int)Vw_ModeratorListColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.Email = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Email)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.Telephone = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Telephone)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Telephone)];
					//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
					entity.UserEnabled = (System.Boolean)reader[((int)Vw_ModeratorListColumn.UserEnabled)];
					//entity.UserEnabled = (Convert.IsDBNull(reader["UserEnabled"]))?false:(System.Boolean)reader["UserEnabled"];
					entity.RoleId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
					entity.MustChangePassword = (reader.IsDBNull(((int)Vw_ModeratorListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_ModeratorListColumn.MustChangePassword)];
					//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
					entity.CharityId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.CharityId)];
					//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
					entity.WebMemberId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.WebMemberId)];
					//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
					entity.DdlDescription = (System.String)reader[((int)Vw_ModeratorListColumn.DdlDescription)];
					//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="Vw_ModeratorList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ModeratorList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_ModeratorList entity)
		{
			reader.Read();
			entity.Id = (System.Int32)reader[((int)Vw_ModeratorListColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_ModeratorListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)Vw_ModeratorListColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.PriCustomerNumber = (System.String)reader[((int)Vw_ModeratorListColumn.PriCustomerNumber)];
			//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
			entity.SecCustomerNumber = (System.String)reader[((int)Vw_ModeratorListColumn.SecCustomerNumber)];
			//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
			entity.ExternalModeratorNumber = (reader.IsDBNull(((int)Vw_ModeratorListColumn.ExternalModeratorNumber)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.ExternalModeratorNumber)];
			//entity.ExternalModeratorNumber = (Convert.IsDBNull(reader["ExternalModeratorNumber"]))?string.Empty:(System.String)reader["ExternalModeratorNumber"];
			entity.ModeratorCode = (System.String)reader[((int)Vw_ModeratorListColumn.ModeratorCode)];
			//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
			entity.PassCode = (System.String)reader[((int)Vw_ModeratorListColumn.PassCode)];
			//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
			entity.SeeVoghMeetingId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.SeeVoghMeetingId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.SeeVoghMeetingId)];
			//entity.SeeVoghMeetingId = (Convert.IsDBNull(reader["SeeVoghMeetingId"]))?string.Empty:(System.String)reader["SeeVoghMeetingId"];
			entity.Description = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Description)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.DepartmentId = (System.Int32)reader[((int)Vw_ModeratorListColumn.DepartmentId)];
			//entity.DepartmentId = (Convert.IsDBNull(reader["DepartmentID"]))?(int)0:(System.Int32)reader["DepartmentID"];
			entity.ModifiedBy = (reader.IsDBNull(((int)Vw_ModeratorListColumn.ModifiedBy)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.ModifiedBy)];
			//entity.ModifiedBy = (Convert.IsDBNull(reader["ModifiedBy"]))?string.Empty:(System.String)reader["ModifiedBy"];
			entity.CreatedDate = (System.DateTime)reader[((int)Vw_ModeratorListColumn.CreatedDate)];
			//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime)reader["CreatedDate"];
			entity.LastModified = (System.DateTime)reader[((int)Vw_ModeratorListColumn.LastModified)];
			//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
			entity.Enabled = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_ModeratorListColumn.Enabled)];
			//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
			entity.UniqueModeratorId = (System.Guid)reader[((int)Vw_ModeratorListColumn.UniqueModeratorId)];
			//entity.UniqueModeratorId = (Convert.IsDBNull(reader["UniqueModeratorID"]))?Guid.Empty:(System.Guid)reader["UniqueModeratorID"];
			entity.UserId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.UserId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32?)reader["UserID"];
			entity.WebMeetingId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.WebMeetingId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.WebMeetingId)];
			//entity.WebMeetingId = (Convert.IsDBNull(reader["WebMeetingID"]))?string.Empty:(System.String)reader["WebMeetingID"];
			entity.DepartmentName = (reader.IsDBNull(((int)Vw_ModeratorListColumn.DepartmentName)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.DepartmentName)];
			//entity.DepartmentName = (Convert.IsDBNull(reader["DepartmentName"]))?string.Empty:(System.String)reader["DepartmentName"];
			entity.Username = (System.String)reader[((int)Vw_ModeratorListColumn.Username)];
			//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
			entity.Password = (System.String)reader[((int)Vw_ModeratorListColumn.Password)];
			//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
			entity.DisplayName = (System.String)reader[((int)Vw_ModeratorListColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.Email = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Email)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.Telephone = (reader.IsDBNull(((int)Vw_ModeratorListColumn.Telephone)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.Telephone)];
			//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
			entity.UserEnabled = (System.Boolean)reader[((int)Vw_ModeratorListColumn.UserEnabled)];
			//entity.UserEnabled = (Convert.IsDBNull(reader["UserEnabled"]))?false:(System.Boolean)reader["UserEnabled"];
			entity.RoleId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
			entity.MustChangePassword = (reader.IsDBNull(((int)Vw_ModeratorListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_ModeratorListColumn.MustChangePassword)];
			//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
			entity.CharityId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_ModeratorListColumn.CharityId)];
			//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
			entity.WebMemberId = (reader.IsDBNull(((int)Vw_ModeratorListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_ModeratorListColumn.WebMemberId)];
			//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
			entity.DdlDescription = (System.String)reader[((int)Vw_ModeratorListColumn.DdlDescription)];
			//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_ModeratorList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ModeratorList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_ModeratorList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["ID"]))?(int)0:(System.Int32)dataRow["ID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.PriCustomerNumber = (Convert.IsDBNull(dataRow["PriCustomerNumber"]))?string.Empty:(System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (Convert.IsDBNull(dataRow["SecCustomerNumber"]))?string.Empty:(System.String)dataRow["SecCustomerNumber"];
			entity.ExternalModeratorNumber = (Convert.IsDBNull(dataRow["ExternalModeratorNumber"]))?string.Empty:(System.String)dataRow["ExternalModeratorNumber"];
			entity.ModeratorCode = (Convert.IsDBNull(dataRow["ModeratorCode"]))?string.Empty:(System.String)dataRow["ModeratorCode"];
			entity.PassCode = (Convert.IsDBNull(dataRow["PassCode"]))?string.Empty:(System.String)dataRow["PassCode"];
			entity.SeeVoghMeetingId = (Convert.IsDBNull(dataRow["SeeVoghMeetingId"]))?string.Empty:(System.String)dataRow["SeeVoghMeetingId"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.DepartmentId = (Convert.IsDBNull(dataRow["DepartmentID"]))?(int)0:(System.Int32)dataRow["DepartmentID"];
			entity.ModifiedBy = (Convert.IsDBNull(dataRow["ModifiedBy"]))?string.Empty:(System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = (Convert.IsDBNull(dataRow["CreatedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (Convert.IsDBNull(dataRow["LastModified"]))?DateTime.MinValue:(System.DateTime)dataRow["LastModified"];
			entity.Enabled = (Convert.IsDBNull(dataRow["Enabled"]))?false:(System.Boolean?)dataRow["Enabled"];
			entity.UniqueModeratorId = (Convert.IsDBNull(dataRow["UniqueModeratorID"]))?Guid.Empty:(System.Guid)dataRow["UniqueModeratorID"];
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32?)dataRow["UserID"];
			entity.WebMeetingId = (Convert.IsDBNull(dataRow["WebMeetingID"]))?string.Empty:(System.String)dataRow["WebMeetingID"];
			entity.DepartmentName = (Convert.IsDBNull(dataRow["DepartmentName"]))?string.Empty:(System.String)dataRow["DepartmentName"];
			entity.Username = (Convert.IsDBNull(dataRow["Username"]))?string.Empty:(System.String)dataRow["Username"];
			entity.Password = (Convert.IsDBNull(dataRow["Password"]))?string.Empty:(System.String)dataRow["Password"];
			entity.DisplayName = (Convert.IsDBNull(dataRow["DisplayName"]))?string.Empty:(System.String)dataRow["DisplayName"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?string.Empty:(System.String)dataRow["Email"];
			entity.Telephone = (Convert.IsDBNull(dataRow["Telephone"]))?string.Empty:(System.String)dataRow["Telephone"];
			entity.UserEnabled = (Convert.IsDBNull(dataRow["UserEnabled"]))?false:(System.Boolean)dataRow["UserEnabled"];
			entity.RoleId = (Convert.IsDBNull(dataRow["RoleID"]))?(int)0:(System.Int32?)dataRow["RoleID"];
			entity.MustChangePassword = (Convert.IsDBNull(dataRow["MustChangePassword"]))?false:(System.Boolean?)dataRow["MustChangePassword"];
			entity.CharityId = (Convert.IsDBNull(dataRow["CharityID"]))?(int)0:(System.Int32?)dataRow["CharityID"];
			entity.WebMemberId = (Convert.IsDBNull(dataRow["WebMemberID"]))?string.Empty:(System.String)dataRow["WebMemberID"];
			entity.DdlDescription = (Convert.IsDBNull(dataRow["DDLDescription"]))?string.Empty:(System.String)dataRow["DDLDescription"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_ModeratorListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListFilterBuilder : SqlFilterBuilder<Vw_ModeratorListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilterBuilder class.
		/// </summary>
		public Vw_ModeratorListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorListFilterBuilder

	#region Vw_ModeratorListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_ModeratorListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListParameterBuilder class.
		/// </summary>
		public Vw_ModeratorListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorListParameterBuilder
} // end namespace
