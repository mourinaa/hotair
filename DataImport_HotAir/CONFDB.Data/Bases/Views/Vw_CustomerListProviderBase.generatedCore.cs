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
	/// This class is the base class for any <see cref="Vw_CustomerListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_CustomerListProviderBaseCore : EntityViewProviderBase<Vw_CustomerList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_CustomerList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_CustomerList&gt;"/></returns>
		protected static VList&lt;Vw_CustomerList&gt; Fill(DataSet dataSet, VList<Vw_CustomerList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_CustomerList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_CustomerList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_CustomerList>"/></returns>
		protected static VList&lt;Vw_CustomerList&gt; Fill(DataTable dataTable, VList<Vw_CustomerList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_CustomerList c = new Vw_CustomerList();
					c.Id = (Convert.IsDBNull(row["ID"]))?(int)0:(System.Int32)row["ID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.PriCustomerNumber = (Convert.IsDBNull(row["PriCustomerNumber"]))?string.Empty:(System.String)row["PriCustomerNumber"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.ExternalCustomerNumber = (Convert.IsDBNull(row["ExternalCustomerNumber"]))?string.Empty:(System.String)row["ExternalCustomerNumber"];
					c.PrimaryContactName = (Convert.IsDBNull(row["PrimaryContactName"]))?string.Empty:(System.String)row["PrimaryContactName"];
					c.PrimaryContactPhoneNumber = (Convert.IsDBNull(row["PrimaryContactPhoneNumber"]))?string.Empty:(System.String)row["PrimaryContactPhoneNumber"];
					c.PrimaryContactEmailAddress = (Convert.IsDBNull(row["PrimaryContactEmailAddress"]))?string.Empty:(System.String)row["PrimaryContactEmailAddress"];
					c.PrimaryContactAddress1 = (Convert.IsDBNull(row["PrimaryContactAddress1"]))?string.Empty:(System.String)row["PrimaryContactAddress1"];
					c.PrimaryContactAddress2 = (Convert.IsDBNull(row["PrimaryContactAddress2"]))?string.Empty:(System.String)row["PrimaryContactAddress2"];
					c.PrimaryContactCity = (Convert.IsDBNull(row["PrimaryContactCity"]))?string.Empty:(System.String)row["PrimaryContactCity"];
					c.PrimaryContactCountry = (Convert.IsDBNull(row["PrimaryContactCountry"]))?string.Empty:(System.String)row["PrimaryContactCountry"];
					c.PrimaryContactRegion = (Convert.IsDBNull(row["PrimaryContactRegion"]))?string.Empty:(System.String)row["PrimaryContactRegion"];
					c.PrimaryContactPostalCode = (Convert.IsDBNull(row["PrimaryContactPostalCode"]))?string.Empty:(System.String)row["PrimaryContactPostalCode"];
					c.PrimaryContactFaxNumber = (Convert.IsDBNull(row["PrimaryContactFaxNumber"]))?string.Empty:(System.String)row["PrimaryContactFaxNumber"];
					c.BillingContactName = (Convert.IsDBNull(row["BillingContactName"]))?string.Empty:(System.String)row["BillingContactName"];
					c.BillingContactPhoneNumber = (Convert.IsDBNull(row["BillingContactPhoneNumber"]))?string.Empty:(System.String)row["BillingContactPhoneNumber"];
					c.BillingContactEmailAddress = (Convert.IsDBNull(row["BillingContactEmailAddress"]))?string.Empty:(System.String)row["BillingContactEmailAddress"];
					c.BillingContactAddress1 = (Convert.IsDBNull(row["BillingContactAddress1"]))?string.Empty:(System.String)row["BillingContactAddress1"];
					c.BillingContactAddress2 = (Convert.IsDBNull(row["BillingContactAddress2"]))?string.Empty:(System.String)row["BillingContactAddress2"];
					c.BillingContactCity = (Convert.IsDBNull(row["BillingContactCity"]))?string.Empty:(System.String)row["BillingContactCity"];
					c.BillingContactCountry = (Convert.IsDBNull(row["BillingContactCountry"]))?string.Empty:(System.String)row["BillingContactCountry"];
					c.BillingContactRegion = (Convert.IsDBNull(row["BillingContactRegion"]))?string.Empty:(System.String)row["BillingContactRegion"];
					c.BillingContactPostalCode = (Convert.IsDBNull(row["BillingContactPostalCode"]))?string.Empty:(System.String)row["BillingContactPostalCode"];
					c.BillingContactFaxNumber = (Convert.IsDBNull(row["BillingContactFaxNumber"]))?string.Empty:(System.String)row["BillingContactFaxNumber"];
					c.WebsiteUrl = (Convert.IsDBNull(row["WebsiteURL"]))?string.Empty:(System.String)row["WebsiteURL"];
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32)row["SalesPersonID"];
					c.VerticalId = (Convert.IsDBNull(row["VerticalID"]))?(int)0:(System.Int32)row["VerticalID"];
					c.CompanyId = (Convert.IsDBNull(row["CompanyID"]))?(int)0:(System.Int32)row["CompanyID"];
					c.CurrencyId = (Convert.IsDBNull(row["CurrencyID"]))?string.Empty:(System.String)row["CurrencyID"];
					c.BillingPeriodCutoff = (Convert.IsDBNull(row["BillingPeriodCutoff"]))?(int)0:(System.Int32)row["BillingPeriodCutoff"];
					c.TaxableId = (Convert.IsDBNull(row["TaxableID"]))?(int)0:(System.Int32)row["TaxableID"];
					c.CreditCardNameOnCard = (Convert.IsDBNull(row["CreditCardNameOnCard"]))?string.Empty:(System.String)row["CreditCardNameOnCard"];
					c.CreditCardNumber = (Convert.IsDBNull(row["CreditCardNumber"]))?string.Empty:(System.String)row["CreditCardNumber"];
					c.CreditCardExp = (Convert.IsDBNull(row["CreditCardExp"]))?string.Empty:(System.String)row["CreditCardExp"];
					c.CreditCardVerCode = (Convert.IsDBNull(row["CreditCardVerCode"]))?string.Empty:(System.String)row["CreditCardVerCode"];
					c.CreditCardTypeName = (Convert.IsDBNull(row["CreditCardTypeName"]))?string.Empty:(System.String)row["CreditCardTypeName"];
					c.CreatedDate = (Convert.IsDBNull(row["CreatedDate"]))?DateTime.MinValue:(System.DateTime)row["CreatedDate"];
					c.LastModified = (Convert.IsDBNull(row["LastModified"]))?DateTime.MinValue:(System.DateTime)row["LastModified"];
					c.UniqueCustomerId = (Convert.IsDBNull(row["UniqueCustomerID"]))?Guid.Empty:(System.Guid)row["UniqueCustomerID"];
					c.Enabled = (Convert.IsDBNull(row["Enabled"]))?false:(System.Boolean?)row["Enabled"];
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32?)row["UserID"];
					c.WebGroupId = (Convert.IsDBNull(row["WebGroupID"]))?string.Empty:(System.String)row["WebGroupID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
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
					c.SalesPerson = (Convert.IsDBNull(row["SalesPerson"]))?string.Empty:(System.String)row["SalesPerson"];
					c.SalesManagerId = (Convert.IsDBNull(row["SalesManagerID"]))?(int)0:(System.Int32?)row["SalesManagerID"];
					c.VerticalDescription = (Convert.IsDBNull(row["VerticalDescription"]))?string.Empty:(System.String)row["VerticalDescription"];
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
		/// Fill an <see cref="VList&lt;Vw_CustomerList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_CustomerList&gt;"/></returns>
		protected VList<Vw_CustomerList> Fill(IDataReader reader, VList<Vw_CustomerList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_CustomerList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_CustomerList>("Vw_CustomerList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_CustomerList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int32)reader[((int)Vw_CustomerListColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_CustomerListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.PriCustomerNumber = (System.String)reader[((int)Vw_CustomerListColumn.PriCustomerNumber)];
					//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
					entity.Description = (reader.IsDBNull(((int)Vw_CustomerListColumn.Description)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.ExternalCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.ExternalCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.ExternalCustomerNumber)];
					//entity.ExternalCustomerNumber = (Convert.IsDBNull(reader["ExternalCustomerNumber"]))?string.Empty:(System.String)reader["ExternalCustomerNumber"];
					entity.PrimaryContactName = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactName)];
					//entity.PrimaryContactName = (Convert.IsDBNull(reader["PrimaryContactName"]))?string.Empty:(System.String)reader["PrimaryContactName"];
					entity.PrimaryContactPhoneNumber = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactPhoneNumber)];
					//entity.PrimaryContactPhoneNumber = (Convert.IsDBNull(reader["PrimaryContactPhoneNumber"]))?string.Empty:(System.String)reader["PrimaryContactPhoneNumber"];
					entity.PrimaryContactEmailAddress = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactEmailAddress)];
					//entity.PrimaryContactEmailAddress = (Convert.IsDBNull(reader["PrimaryContactEmailAddress"]))?string.Empty:(System.String)reader["PrimaryContactEmailAddress"];
					entity.PrimaryContactAddress1 = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactAddress1)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactAddress1)];
					//entity.PrimaryContactAddress1 = (Convert.IsDBNull(reader["PrimaryContactAddress1"]))?string.Empty:(System.String)reader["PrimaryContactAddress1"];
					entity.PrimaryContactAddress2 = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactAddress2)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactAddress2)];
					//entity.PrimaryContactAddress2 = (Convert.IsDBNull(reader["PrimaryContactAddress2"]))?string.Empty:(System.String)reader["PrimaryContactAddress2"];
					entity.PrimaryContactCity = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactCity)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactCity)];
					//entity.PrimaryContactCity = (Convert.IsDBNull(reader["PrimaryContactCity"]))?string.Empty:(System.String)reader["PrimaryContactCity"];
					entity.PrimaryContactCountry = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactCountry)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactCountry)];
					//entity.PrimaryContactCountry = (Convert.IsDBNull(reader["PrimaryContactCountry"]))?string.Empty:(System.String)reader["PrimaryContactCountry"];
					entity.PrimaryContactRegion = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactRegion)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactRegion)];
					//entity.PrimaryContactRegion = (Convert.IsDBNull(reader["PrimaryContactRegion"]))?string.Empty:(System.String)reader["PrimaryContactRegion"];
					entity.PrimaryContactPostalCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactPostalCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactPostalCode)];
					//entity.PrimaryContactPostalCode = (Convert.IsDBNull(reader["PrimaryContactPostalCode"]))?string.Empty:(System.String)reader["PrimaryContactPostalCode"];
					entity.PrimaryContactFaxNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactFaxNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactFaxNumber)];
					//entity.PrimaryContactFaxNumber = (Convert.IsDBNull(reader["PrimaryContactFaxNumber"]))?string.Empty:(System.String)reader["PrimaryContactFaxNumber"];
					entity.BillingContactName = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactName)];
					//entity.BillingContactName = (Convert.IsDBNull(reader["BillingContactName"]))?string.Empty:(System.String)reader["BillingContactName"];
					entity.BillingContactPhoneNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactPhoneNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactPhoneNumber)];
					//entity.BillingContactPhoneNumber = (Convert.IsDBNull(reader["BillingContactPhoneNumber"]))?string.Empty:(System.String)reader["BillingContactPhoneNumber"];
					entity.BillingContactEmailAddress = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactEmailAddress)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactEmailAddress)];
					//entity.BillingContactEmailAddress = (Convert.IsDBNull(reader["BillingContactEmailAddress"]))?string.Empty:(System.String)reader["BillingContactEmailAddress"];
					entity.BillingContactAddress1 = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactAddress1)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactAddress1)];
					//entity.BillingContactAddress1 = (Convert.IsDBNull(reader["BillingContactAddress1"]))?string.Empty:(System.String)reader["BillingContactAddress1"];
					entity.BillingContactAddress2 = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactAddress2)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactAddress2)];
					//entity.BillingContactAddress2 = (Convert.IsDBNull(reader["BillingContactAddress2"]))?string.Empty:(System.String)reader["BillingContactAddress2"];
					entity.BillingContactCity = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactCity)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactCity)];
					//entity.BillingContactCity = (Convert.IsDBNull(reader["BillingContactCity"]))?string.Empty:(System.String)reader["BillingContactCity"];
					entity.BillingContactCountry = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactCountry)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactCountry)];
					//entity.BillingContactCountry = (Convert.IsDBNull(reader["BillingContactCountry"]))?string.Empty:(System.String)reader["BillingContactCountry"];
					entity.BillingContactRegion = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactRegion)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactRegion)];
					//entity.BillingContactRegion = (Convert.IsDBNull(reader["BillingContactRegion"]))?string.Empty:(System.String)reader["BillingContactRegion"];
					entity.BillingContactPostalCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactPostalCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactPostalCode)];
					//entity.BillingContactPostalCode = (Convert.IsDBNull(reader["BillingContactPostalCode"]))?string.Empty:(System.String)reader["BillingContactPostalCode"];
					entity.BillingContactFaxNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactFaxNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactFaxNumber)];
					//entity.BillingContactFaxNumber = (Convert.IsDBNull(reader["BillingContactFaxNumber"]))?string.Empty:(System.String)reader["BillingContactFaxNumber"];
					entity.WebsiteUrl = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebsiteUrl)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebsiteUrl)];
					//entity.WebsiteUrl = (Convert.IsDBNull(reader["WebsiteURL"]))?string.Empty:(System.String)reader["WebsiteURL"];
					entity.SalesPersonId = (System.Int32)reader[((int)Vw_CustomerListColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
					entity.VerticalId = (System.Int32)reader[((int)Vw_CustomerListColumn.VerticalId)];
					//entity.VerticalId = (Convert.IsDBNull(reader["VerticalID"]))?(int)0:(System.Int32)reader["VerticalID"];
					entity.CompanyId = (System.Int32)reader[((int)Vw_CustomerListColumn.CompanyId)];
					//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32)reader["CompanyID"];
					entity.CurrencyId = (System.String)reader[((int)Vw_CustomerListColumn.CurrencyId)];
					//entity.CurrencyId = (Convert.IsDBNull(reader["CurrencyID"]))?string.Empty:(System.String)reader["CurrencyID"];
					entity.BillingPeriodCutoff = (System.Int32)reader[((int)Vw_CustomerListColumn.BillingPeriodCutoff)];
					//entity.BillingPeriodCutoff = (Convert.IsDBNull(reader["BillingPeriodCutoff"]))?(int)0:(System.Int32)reader["BillingPeriodCutoff"];
					entity.TaxableId = (System.Int32)reader[((int)Vw_CustomerListColumn.TaxableId)];
					//entity.TaxableId = (Convert.IsDBNull(reader["TaxableID"]))?(int)0:(System.Int32)reader["TaxableID"];
					entity.CreditCardNameOnCard = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardNameOnCard)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardNameOnCard)];
					//entity.CreditCardNameOnCard = (Convert.IsDBNull(reader["CreditCardNameOnCard"]))?string.Empty:(System.String)reader["CreditCardNameOnCard"];
					entity.CreditCardNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardNumber)];
					//entity.CreditCardNumber = (Convert.IsDBNull(reader["CreditCardNumber"]))?string.Empty:(System.String)reader["CreditCardNumber"];
					entity.CreditCardExp = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardExp)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardExp)];
					//entity.CreditCardExp = (Convert.IsDBNull(reader["CreditCardExp"]))?string.Empty:(System.String)reader["CreditCardExp"];
					entity.CreditCardVerCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardVerCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardVerCode)];
					//entity.CreditCardVerCode = (Convert.IsDBNull(reader["CreditCardVerCode"]))?string.Empty:(System.String)reader["CreditCardVerCode"];
					entity.CreditCardTypeName = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardTypeName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardTypeName)];
					//entity.CreditCardTypeName = (Convert.IsDBNull(reader["CreditCardTypeName"]))?string.Empty:(System.String)reader["CreditCardTypeName"];
					entity.CreatedDate = (System.DateTime)reader[((int)Vw_CustomerListColumn.CreatedDate)];
					//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime)reader["CreatedDate"];
					entity.LastModified = (System.DateTime)reader[((int)Vw_CustomerListColumn.LastModified)];
					//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
					entity.UniqueCustomerId = (System.Guid)reader[((int)Vw_CustomerListColumn.UniqueCustomerId)];
					//entity.UniqueCustomerId = (Convert.IsDBNull(reader["UniqueCustomerID"]))?Guid.Empty:(System.Guid)reader["UniqueCustomerID"];
					entity.Enabled = (reader.IsDBNull(((int)Vw_CustomerListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_CustomerListColumn.Enabled)];
					//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
					entity.UserId = (reader.IsDBNull(((int)Vw_CustomerListColumn.UserId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32?)reader["UserID"];
					entity.WebGroupId = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebGroupId)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebGroupId)];
					//entity.WebGroupId = (Convert.IsDBNull(reader["WebGroupID"]))?string.Empty:(System.String)reader["WebGroupID"];
					entity.CompanyName = (reader.IsDBNull(((int)Vw_CustomerListColumn.CompanyName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.Username = (System.String)reader[((int)Vw_CustomerListColumn.Username)];
					//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
					entity.Password = (System.String)reader[((int)Vw_CustomerListColumn.Password)];
					//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
					entity.DisplayName = (System.String)reader[((int)Vw_CustomerListColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.Email = (reader.IsDBNull(((int)Vw_CustomerListColumn.Email)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.Telephone = (reader.IsDBNull(((int)Vw_CustomerListColumn.Telephone)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Telephone)];
					//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
					entity.UserEnabled = (System.Boolean)reader[((int)Vw_CustomerListColumn.UserEnabled)];
					//entity.UserEnabled = (Convert.IsDBNull(reader["UserEnabled"]))?false:(System.Boolean)reader["UserEnabled"];
					entity.RoleId = (reader.IsDBNull(((int)Vw_CustomerListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
					entity.MustChangePassword = (reader.IsDBNull(((int)Vw_CustomerListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_CustomerListColumn.MustChangePassword)];
					//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
					entity.CharityId = (reader.IsDBNull(((int)Vw_CustomerListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.CharityId)];
					//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
					entity.WebMemberId = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebMemberId)];
					//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
					entity.DdlDescription = (reader.IsDBNull(((int)Vw_CustomerListColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_CustomerListColumn.DdlDescription)];
					//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
					entity.SalesPerson = (System.String)reader[((int)Vw_CustomerListColumn.SalesPerson)];
					//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
					entity.SalesManagerId = (reader.IsDBNull(((int)Vw_CustomerListColumn.SalesManagerId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.SalesManagerId)];
					//entity.SalesManagerId = (Convert.IsDBNull(reader["SalesManagerID"]))?(int)0:(System.Int32?)reader["SalesManagerID"];
					entity.VerticalDescription = (reader.IsDBNull(((int)Vw_CustomerListColumn.VerticalDescription)))?null:(System.String)reader[((int)Vw_CustomerListColumn.VerticalDescription)];
					//entity.VerticalDescription = (Convert.IsDBNull(reader["VerticalDescription"]))?string.Empty:(System.String)reader["VerticalDescription"];
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
		/// Refreshes the <see cref="Vw_CustomerList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_CustomerList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_CustomerList entity)
		{
			reader.Read();
			entity.Id = (System.Int32)reader[((int)Vw_CustomerListColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_CustomerListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.PriCustomerNumber = (System.String)reader[((int)Vw_CustomerListColumn.PriCustomerNumber)];
			//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
			entity.Description = (reader.IsDBNull(((int)Vw_CustomerListColumn.Description)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.ExternalCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.ExternalCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.ExternalCustomerNumber)];
			//entity.ExternalCustomerNumber = (Convert.IsDBNull(reader["ExternalCustomerNumber"]))?string.Empty:(System.String)reader["ExternalCustomerNumber"];
			entity.PrimaryContactName = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactName)];
			//entity.PrimaryContactName = (Convert.IsDBNull(reader["PrimaryContactName"]))?string.Empty:(System.String)reader["PrimaryContactName"];
			entity.PrimaryContactPhoneNumber = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactPhoneNumber)];
			//entity.PrimaryContactPhoneNumber = (Convert.IsDBNull(reader["PrimaryContactPhoneNumber"]))?string.Empty:(System.String)reader["PrimaryContactPhoneNumber"];
			entity.PrimaryContactEmailAddress = (System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactEmailAddress)];
			//entity.PrimaryContactEmailAddress = (Convert.IsDBNull(reader["PrimaryContactEmailAddress"]))?string.Empty:(System.String)reader["PrimaryContactEmailAddress"];
			entity.PrimaryContactAddress1 = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactAddress1)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactAddress1)];
			//entity.PrimaryContactAddress1 = (Convert.IsDBNull(reader["PrimaryContactAddress1"]))?string.Empty:(System.String)reader["PrimaryContactAddress1"];
			entity.PrimaryContactAddress2 = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactAddress2)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactAddress2)];
			//entity.PrimaryContactAddress2 = (Convert.IsDBNull(reader["PrimaryContactAddress2"]))?string.Empty:(System.String)reader["PrimaryContactAddress2"];
			entity.PrimaryContactCity = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactCity)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactCity)];
			//entity.PrimaryContactCity = (Convert.IsDBNull(reader["PrimaryContactCity"]))?string.Empty:(System.String)reader["PrimaryContactCity"];
			entity.PrimaryContactCountry = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactCountry)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactCountry)];
			//entity.PrimaryContactCountry = (Convert.IsDBNull(reader["PrimaryContactCountry"]))?string.Empty:(System.String)reader["PrimaryContactCountry"];
			entity.PrimaryContactRegion = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactRegion)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactRegion)];
			//entity.PrimaryContactRegion = (Convert.IsDBNull(reader["PrimaryContactRegion"]))?string.Empty:(System.String)reader["PrimaryContactRegion"];
			entity.PrimaryContactPostalCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactPostalCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactPostalCode)];
			//entity.PrimaryContactPostalCode = (Convert.IsDBNull(reader["PrimaryContactPostalCode"]))?string.Empty:(System.String)reader["PrimaryContactPostalCode"];
			entity.PrimaryContactFaxNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.PrimaryContactFaxNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.PrimaryContactFaxNumber)];
			//entity.PrimaryContactFaxNumber = (Convert.IsDBNull(reader["PrimaryContactFaxNumber"]))?string.Empty:(System.String)reader["PrimaryContactFaxNumber"];
			entity.BillingContactName = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactName)];
			//entity.BillingContactName = (Convert.IsDBNull(reader["BillingContactName"]))?string.Empty:(System.String)reader["BillingContactName"];
			entity.BillingContactPhoneNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactPhoneNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactPhoneNumber)];
			//entity.BillingContactPhoneNumber = (Convert.IsDBNull(reader["BillingContactPhoneNumber"]))?string.Empty:(System.String)reader["BillingContactPhoneNumber"];
			entity.BillingContactEmailAddress = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactEmailAddress)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactEmailAddress)];
			//entity.BillingContactEmailAddress = (Convert.IsDBNull(reader["BillingContactEmailAddress"]))?string.Empty:(System.String)reader["BillingContactEmailAddress"];
			entity.BillingContactAddress1 = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactAddress1)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactAddress1)];
			//entity.BillingContactAddress1 = (Convert.IsDBNull(reader["BillingContactAddress1"]))?string.Empty:(System.String)reader["BillingContactAddress1"];
			entity.BillingContactAddress2 = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactAddress2)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactAddress2)];
			//entity.BillingContactAddress2 = (Convert.IsDBNull(reader["BillingContactAddress2"]))?string.Empty:(System.String)reader["BillingContactAddress2"];
			entity.BillingContactCity = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactCity)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactCity)];
			//entity.BillingContactCity = (Convert.IsDBNull(reader["BillingContactCity"]))?string.Empty:(System.String)reader["BillingContactCity"];
			entity.BillingContactCountry = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactCountry)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactCountry)];
			//entity.BillingContactCountry = (Convert.IsDBNull(reader["BillingContactCountry"]))?string.Empty:(System.String)reader["BillingContactCountry"];
			entity.BillingContactRegion = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactRegion)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactRegion)];
			//entity.BillingContactRegion = (Convert.IsDBNull(reader["BillingContactRegion"]))?string.Empty:(System.String)reader["BillingContactRegion"];
			entity.BillingContactPostalCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactPostalCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactPostalCode)];
			//entity.BillingContactPostalCode = (Convert.IsDBNull(reader["BillingContactPostalCode"]))?string.Empty:(System.String)reader["BillingContactPostalCode"];
			entity.BillingContactFaxNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.BillingContactFaxNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.BillingContactFaxNumber)];
			//entity.BillingContactFaxNumber = (Convert.IsDBNull(reader["BillingContactFaxNumber"]))?string.Empty:(System.String)reader["BillingContactFaxNumber"];
			entity.WebsiteUrl = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebsiteUrl)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebsiteUrl)];
			//entity.WebsiteUrl = (Convert.IsDBNull(reader["WebsiteURL"]))?string.Empty:(System.String)reader["WebsiteURL"];
			entity.SalesPersonId = (System.Int32)reader[((int)Vw_CustomerListColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
			entity.VerticalId = (System.Int32)reader[((int)Vw_CustomerListColumn.VerticalId)];
			//entity.VerticalId = (Convert.IsDBNull(reader["VerticalID"]))?(int)0:(System.Int32)reader["VerticalID"];
			entity.CompanyId = (System.Int32)reader[((int)Vw_CustomerListColumn.CompanyId)];
			//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32)reader["CompanyID"];
			entity.CurrencyId = (System.String)reader[((int)Vw_CustomerListColumn.CurrencyId)];
			//entity.CurrencyId = (Convert.IsDBNull(reader["CurrencyID"]))?string.Empty:(System.String)reader["CurrencyID"];
			entity.BillingPeriodCutoff = (System.Int32)reader[((int)Vw_CustomerListColumn.BillingPeriodCutoff)];
			//entity.BillingPeriodCutoff = (Convert.IsDBNull(reader["BillingPeriodCutoff"]))?(int)0:(System.Int32)reader["BillingPeriodCutoff"];
			entity.TaxableId = (System.Int32)reader[((int)Vw_CustomerListColumn.TaxableId)];
			//entity.TaxableId = (Convert.IsDBNull(reader["TaxableID"]))?(int)0:(System.Int32)reader["TaxableID"];
			entity.CreditCardNameOnCard = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardNameOnCard)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardNameOnCard)];
			//entity.CreditCardNameOnCard = (Convert.IsDBNull(reader["CreditCardNameOnCard"]))?string.Empty:(System.String)reader["CreditCardNameOnCard"];
			entity.CreditCardNumber = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardNumber)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardNumber)];
			//entity.CreditCardNumber = (Convert.IsDBNull(reader["CreditCardNumber"]))?string.Empty:(System.String)reader["CreditCardNumber"];
			entity.CreditCardExp = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardExp)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardExp)];
			//entity.CreditCardExp = (Convert.IsDBNull(reader["CreditCardExp"]))?string.Empty:(System.String)reader["CreditCardExp"];
			entity.CreditCardVerCode = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardVerCode)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardVerCode)];
			//entity.CreditCardVerCode = (Convert.IsDBNull(reader["CreditCardVerCode"]))?string.Empty:(System.String)reader["CreditCardVerCode"];
			entity.CreditCardTypeName = (reader.IsDBNull(((int)Vw_CustomerListColumn.CreditCardTypeName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CreditCardTypeName)];
			//entity.CreditCardTypeName = (Convert.IsDBNull(reader["CreditCardTypeName"]))?string.Empty:(System.String)reader["CreditCardTypeName"];
			entity.CreatedDate = (System.DateTime)reader[((int)Vw_CustomerListColumn.CreatedDate)];
			//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime)reader["CreatedDate"];
			entity.LastModified = (System.DateTime)reader[((int)Vw_CustomerListColumn.LastModified)];
			//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
			entity.UniqueCustomerId = (System.Guid)reader[((int)Vw_CustomerListColumn.UniqueCustomerId)];
			//entity.UniqueCustomerId = (Convert.IsDBNull(reader["UniqueCustomerID"]))?Guid.Empty:(System.Guid)reader["UniqueCustomerID"];
			entity.Enabled = (reader.IsDBNull(((int)Vw_CustomerListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_CustomerListColumn.Enabled)];
			//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
			entity.UserId = (reader.IsDBNull(((int)Vw_CustomerListColumn.UserId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32?)reader["UserID"];
			entity.WebGroupId = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebGroupId)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebGroupId)];
			//entity.WebGroupId = (Convert.IsDBNull(reader["WebGroupID"]))?string.Empty:(System.String)reader["WebGroupID"];
			entity.CompanyName = (reader.IsDBNull(((int)Vw_CustomerListColumn.CompanyName)))?null:(System.String)reader[((int)Vw_CustomerListColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.Username = (System.String)reader[((int)Vw_CustomerListColumn.Username)];
			//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
			entity.Password = (System.String)reader[((int)Vw_CustomerListColumn.Password)];
			//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
			entity.DisplayName = (System.String)reader[((int)Vw_CustomerListColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.Email = (reader.IsDBNull(((int)Vw_CustomerListColumn.Email)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.Telephone = (reader.IsDBNull(((int)Vw_CustomerListColumn.Telephone)))?null:(System.String)reader[((int)Vw_CustomerListColumn.Telephone)];
			//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
			entity.UserEnabled = (System.Boolean)reader[((int)Vw_CustomerListColumn.UserEnabled)];
			//entity.UserEnabled = (Convert.IsDBNull(reader["UserEnabled"]))?false:(System.Boolean)reader["UserEnabled"];
			entity.RoleId = (reader.IsDBNull(((int)Vw_CustomerListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
			entity.MustChangePassword = (reader.IsDBNull(((int)Vw_CustomerListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_CustomerListColumn.MustChangePassword)];
			//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
			entity.CharityId = (reader.IsDBNull(((int)Vw_CustomerListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.CharityId)];
			//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
			entity.WebMemberId = (reader.IsDBNull(((int)Vw_CustomerListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_CustomerListColumn.WebMemberId)];
			//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
			entity.DdlDescription = (reader.IsDBNull(((int)Vw_CustomerListColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_CustomerListColumn.DdlDescription)];
			//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
			entity.SalesPerson = (System.String)reader[((int)Vw_CustomerListColumn.SalesPerson)];
			//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
			entity.SalesManagerId = (reader.IsDBNull(((int)Vw_CustomerListColumn.SalesManagerId)))?null:(System.Int32?)reader[((int)Vw_CustomerListColumn.SalesManagerId)];
			//entity.SalesManagerId = (Convert.IsDBNull(reader["SalesManagerID"]))?(int)0:(System.Int32?)reader["SalesManagerID"];
			entity.VerticalDescription = (reader.IsDBNull(((int)Vw_CustomerListColumn.VerticalDescription)))?null:(System.String)reader[((int)Vw_CustomerListColumn.VerticalDescription)];
			//entity.VerticalDescription = (Convert.IsDBNull(reader["VerticalDescription"]))?string.Empty:(System.String)reader["VerticalDescription"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_CustomerList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_CustomerList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_CustomerList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["ID"]))?(int)0:(System.Int32)dataRow["ID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.PriCustomerNumber = (Convert.IsDBNull(dataRow["PriCustomerNumber"]))?string.Empty:(System.String)dataRow["PriCustomerNumber"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.ExternalCustomerNumber = (Convert.IsDBNull(dataRow["ExternalCustomerNumber"]))?string.Empty:(System.String)dataRow["ExternalCustomerNumber"];
			entity.PrimaryContactName = (Convert.IsDBNull(dataRow["PrimaryContactName"]))?string.Empty:(System.String)dataRow["PrimaryContactName"];
			entity.PrimaryContactPhoneNumber = (Convert.IsDBNull(dataRow["PrimaryContactPhoneNumber"]))?string.Empty:(System.String)dataRow["PrimaryContactPhoneNumber"];
			entity.PrimaryContactEmailAddress = (Convert.IsDBNull(dataRow["PrimaryContactEmailAddress"]))?string.Empty:(System.String)dataRow["PrimaryContactEmailAddress"];
			entity.PrimaryContactAddress1 = (Convert.IsDBNull(dataRow["PrimaryContactAddress1"]))?string.Empty:(System.String)dataRow["PrimaryContactAddress1"];
			entity.PrimaryContactAddress2 = (Convert.IsDBNull(dataRow["PrimaryContactAddress2"]))?string.Empty:(System.String)dataRow["PrimaryContactAddress2"];
			entity.PrimaryContactCity = (Convert.IsDBNull(dataRow["PrimaryContactCity"]))?string.Empty:(System.String)dataRow["PrimaryContactCity"];
			entity.PrimaryContactCountry = (Convert.IsDBNull(dataRow["PrimaryContactCountry"]))?string.Empty:(System.String)dataRow["PrimaryContactCountry"];
			entity.PrimaryContactRegion = (Convert.IsDBNull(dataRow["PrimaryContactRegion"]))?string.Empty:(System.String)dataRow["PrimaryContactRegion"];
			entity.PrimaryContactPostalCode = (Convert.IsDBNull(dataRow["PrimaryContactPostalCode"]))?string.Empty:(System.String)dataRow["PrimaryContactPostalCode"];
			entity.PrimaryContactFaxNumber = (Convert.IsDBNull(dataRow["PrimaryContactFaxNumber"]))?string.Empty:(System.String)dataRow["PrimaryContactFaxNumber"];
			entity.BillingContactName = (Convert.IsDBNull(dataRow["BillingContactName"]))?string.Empty:(System.String)dataRow["BillingContactName"];
			entity.BillingContactPhoneNumber = (Convert.IsDBNull(dataRow["BillingContactPhoneNumber"]))?string.Empty:(System.String)dataRow["BillingContactPhoneNumber"];
			entity.BillingContactEmailAddress = (Convert.IsDBNull(dataRow["BillingContactEmailAddress"]))?string.Empty:(System.String)dataRow["BillingContactEmailAddress"];
			entity.BillingContactAddress1 = (Convert.IsDBNull(dataRow["BillingContactAddress1"]))?string.Empty:(System.String)dataRow["BillingContactAddress1"];
			entity.BillingContactAddress2 = (Convert.IsDBNull(dataRow["BillingContactAddress2"]))?string.Empty:(System.String)dataRow["BillingContactAddress2"];
			entity.BillingContactCity = (Convert.IsDBNull(dataRow["BillingContactCity"]))?string.Empty:(System.String)dataRow["BillingContactCity"];
			entity.BillingContactCountry = (Convert.IsDBNull(dataRow["BillingContactCountry"]))?string.Empty:(System.String)dataRow["BillingContactCountry"];
			entity.BillingContactRegion = (Convert.IsDBNull(dataRow["BillingContactRegion"]))?string.Empty:(System.String)dataRow["BillingContactRegion"];
			entity.BillingContactPostalCode = (Convert.IsDBNull(dataRow["BillingContactPostalCode"]))?string.Empty:(System.String)dataRow["BillingContactPostalCode"];
			entity.BillingContactFaxNumber = (Convert.IsDBNull(dataRow["BillingContactFaxNumber"]))?string.Empty:(System.String)dataRow["BillingContactFaxNumber"];
			entity.WebsiteUrl = (Convert.IsDBNull(dataRow["WebsiteURL"]))?string.Empty:(System.String)dataRow["WebsiteURL"];
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32)dataRow["SalesPersonID"];
			entity.VerticalId = (Convert.IsDBNull(dataRow["VerticalID"]))?(int)0:(System.Int32)dataRow["VerticalID"];
			entity.CompanyId = (Convert.IsDBNull(dataRow["CompanyID"]))?(int)0:(System.Int32)dataRow["CompanyID"];
			entity.CurrencyId = (Convert.IsDBNull(dataRow["CurrencyID"]))?string.Empty:(System.String)dataRow["CurrencyID"];
			entity.BillingPeriodCutoff = (Convert.IsDBNull(dataRow["BillingPeriodCutoff"]))?(int)0:(System.Int32)dataRow["BillingPeriodCutoff"];
			entity.TaxableId = (Convert.IsDBNull(dataRow["TaxableID"]))?(int)0:(System.Int32)dataRow["TaxableID"];
			entity.CreditCardNameOnCard = (Convert.IsDBNull(dataRow["CreditCardNameOnCard"]))?string.Empty:(System.String)dataRow["CreditCardNameOnCard"];
			entity.CreditCardNumber = (Convert.IsDBNull(dataRow["CreditCardNumber"]))?string.Empty:(System.String)dataRow["CreditCardNumber"];
			entity.CreditCardExp = (Convert.IsDBNull(dataRow["CreditCardExp"]))?string.Empty:(System.String)dataRow["CreditCardExp"];
			entity.CreditCardVerCode = (Convert.IsDBNull(dataRow["CreditCardVerCode"]))?string.Empty:(System.String)dataRow["CreditCardVerCode"];
			entity.CreditCardTypeName = (Convert.IsDBNull(dataRow["CreditCardTypeName"]))?string.Empty:(System.String)dataRow["CreditCardTypeName"];
			entity.CreatedDate = (Convert.IsDBNull(dataRow["CreatedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["CreatedDate"];
			entity.LastModified = (Convert.IsDBNull(dataRow["LastModified"]))?DateTime.MinValue:(System.DateTime)dataRow["LastModified"];
			entity.UniqueCustomerId = (Convert.IsDBNull(dataRow["UniqueCustomerID"]))?Guid.Empty:(System.Guid)dataRow["UniqueCustomerID"];
			entity.Enabled = (Convert.IsDBNull(dataRow["Enabled"]))?false:(System.Boolean?)dataRow["Enabled"];
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32?)dataRow["UserID"];
			entity.WebGroupId = (Convert.IsDBNull(dataRow["WebGroupID"]))?string.Empty:(System.String)dataRow["WebGroupID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
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
			entity.SalesPerson = (Convert.IsDBNull(dataRow["SalesPerson"]))?string.Empty:(System.String)dataRow["SalesPerson"];
			entity.SalesManagerId = (Convert.IsDBNull(dataRow["SalesManagerID"]))?(int)0:(System.Int32?)dataRow["SalesManagerID"];
			entity.VerticalDescription = (Convert.IsDBNull(dataRow["VerticalDescription"]))?string.Empty:(System.String)dataRow["VerticalDescription"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_CustomerListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListFilterBuilder : SqlFilterBuilder<Vw_CustomerListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilterBuilder class.
		/// </summary>
		public Vw_CustomerListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerListFilterBuilder

	#region Vw_CustomerListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_CustomerListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListParameterBuilder class.
		/// </summary>
		public Vw_CustomerListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerListParameterBuilder
} // end namespace
