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
	/// This class is the base class for any <see cref="Vw_ModeratorList_AdminSiteProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_ModeratorList_AdminSiteProviderBaseCore : EntityViewProviderBase<Vw_ModeratorList_AdminSite>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_ModeratorList_AdminSite&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_ModeratorList_AdminSite&gt;"/></returns>
		protected static VList&lt;Vw_ModeratorList_AdminSite&gt; Fill(DataSet dataSet, VList<Vw_ModeratorList_AdminSite> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_ModeratorList_AdminSite>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_ModeratorList_AdminSite&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_ModeratorList_AdminSite>"/></returns>
		protected static VList&lt;Vw_ModeratorList_AdminSite&gt; Fill(DataTable dataTable, VList<Vw_ModeratorList_AdminSite> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_ModeratorList_AdminSite c = new Vw_ModeratorList_AdminSite();
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32)row["UserID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.AdminName = (Convert.IsDBNull(row["AdminName"]))?string.Empty:(System.String)row["AdminName"];
					c.WebLoginName = (Convert.IsDBNull(row["WebLoginName"]))?string.Empty:(System.String)row["WebLoginName"];
					c.WebLoginPassword = (Convert.IsDBNull(row["WebLoginPassword"]))?string.Empty:(System.String)row["WebLoginPassword"];
					c.ModeratorName = (Convert.IsDBNull(row["ModeratorName"]))?string.Empty:(System.String)row["ModeratorName"];
					c.Email = (Convert.IsDBNull(row["Email"]))?string.Empty:(System.String)row["Email"];
					c.Address1 = (Convert.IsDBNull(row["Address1"]))?string.Empty:(System.String)row["Address1"];
					c.Address2 = (Convert.IsDBNull(row["Address2"]))?string.Empty:(System.String)row["Address2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.Country = (Convert.IsDBNull(row["Country"]))?string.Empty:(System.String)row["Country"];
					c.Region = (Convert.IsDBNull(row["Region"]))?string.Empty:(System.String)row["Region"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.Telephone = (Convert.IsDBNull(row["Telephone"]))?string.Empty:(System.String)row["Telephone"];
					c.RoleId = (Convert.IsDBNull(row["RoleID"]))?(int)0:(System.Int32?)row["RoleID"];
					c.CharityId = (Convert.IsDBNull(row["CharityID"]))?(int)0:(System.Int32?)row["CharityID"];
					c.CharityName = (Convert.IsDBNull(row["CharityName"]))?string.Empty:(System.String)row["CharityName"];
					c.SalesPerson = (Convert.IsDBNull(row["SalesPerson"]))?string.Empty:(System.String)row["SalesPerson"];
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32)row["SalesPersonID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.AccountManagerId = (Convert.IsDBNull(row["AccountManagerID"]))?(int)0:(System.Int32)row["AccountManagerID"];
					c.AccountManager = (Convert.IsDBNull(row["AccountManager"]))?string.Empty:(System.String)row["AccountManager"];
					c.DateProvisioned = (Convert.IsDBNull(row["DateProvisioned"]))?DateTime.MinValue:(System.DateTime)row["DateProvisioned"];
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
		/// Fill an <see cref="VList&lt;Vw_ModeratorList_AdminSite&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_ModeratorList_AdminSite&gt;"/></returns>
		protected VList<Vw_ModeratorList_AdminSite> Fill(IDataReader reader, VList<Vw_ModeratorList_AdminSite> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_ModeratorList_AdminSite entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_ModeratorList_AdminSite>("Vw_ModeratorList_AdminSite",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_ModeratorList_AdminSite();
					}
					
					entity.SuppressEntityEvents = true;

					entity.UserId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
					entity.CompanyName = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CompanyName)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.AdminName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.AdminName)];
					//entity.AdminName = (Convert.IsDBNull(reader["AdminName"]))?string.Empty:(System.String)reader["AdminName"];
					entity.WebLoginName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WebLoginName)];
					//entity.WebLoginName = (Convert.IsDBNull(reader["WebLoginName"]))?string.Empty:(System.String)reader["WebLoginName"];
					entity.WebLoginPassword = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WebLoginPassword)];
					//entity.WebLoginPassword = (Convert.IsDBNull(reader["WebLoginPassword"]))?string.Empty:(System.String)reader["WebLoginPassword"];
					entity.ModeratorName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.ModeratorName)];
					//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
					entity.Email = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Email)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.Address1 = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Address1)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Address1)];
					//entity.Address1 = (Convert.IsDBNull(reader["Address1"]))?string.Empty:(System.String)reader["Address1"];
					entity.Address2 = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Address2)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Address2)];
					//entity.Address2 = (Convert.IsDBNull(reader["Address2"]))?string.Empty:(System.String)reader["Address2"];
					entity.City = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.City)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.Country = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Country)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Country)];
					//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
					entity.Region = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Region)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Region)];
					//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
					entity.PostalCode = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.PostalCode)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.Telephone = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Telephone)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Telephone)];
					//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
					entity.RoleId = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_ModeratorList_AdminSiteColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
					entity.CharityId = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_ModeratorList_AdminSiteColumn.CharityId)];
					//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
					entity.CharityName = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CharityName)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.CharityName)];
					//entity.CharityName = (Convert.IsDBNull(reader["CharityName"]))?string.Empty:(System.String)reader["CharityName"];
					entity.SalesPerson = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.SalesPerson)];
					//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
					entity.SalesPersonId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.AccountManagerId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.AccountManagerId)];
					//entity.AccountManagerId = (Convert.IsDBNull(reader["AccountManagerID"]))?(int)0:(System.Int32)reader["AccountManagerID"];
					entity.AccountManager = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.AccountManager)];
					//entity.AccountManager = (Convert.IsDBNull(reader["AccountManager"]))?string.Empty:(System.String)reader["AccountManager"];
					entity.DateProvisioned = (System.DateTime)reader[((int)Vw_ModeratorList_AdminSiteColumn.DateProvisioned)];
					//entity.DateProvisioned = (Convert.IsDBNull(reader["DateProvisioned"]))?DateTime.MinValue:(System.DateTime)reader["DateProvisioned"];
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
		/// Refreshes the <see cref="Vw_ModeratorList_AdminSite"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ModeratorList_AdminSite"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_ModeratorList_AdminSite entity)
		{
			reader.Read();
			entity.UserId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
			entity.CompanyName = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CompanyName)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.AdminName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.AdminName)];
			//entity.AdminName = (Convert.IsDBNull(reader["AdminName"]))?string.Empty:(System.String)reader["AdminName"];
			entity.WebLoginName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WebLoginName)];
			//entity.WebLoginName = (Convert.IsDBNull(reader["WebLoginName"]))?string.Empty:(System.String)reader["WebLoginName"];
			entity.WebLoginPassword = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WebLoginPassword)];
			//entity.WebLoginPassword = (Convert.IsDBNull(reader["WebLoginPassword"]))?string.Empty:(System.String)reader["WebLoginPassword"];
			entity.ModeratorName = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.ModeratorName)];
			//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
			entity.Email = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Email)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.Address1 = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Address1)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Address1)];
			//entity.Address1 = (Convert.IsDBNull(reader["Address1"]))?string.Empty:(System.String)reader["Address1"];
			entity.Address2 = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Address2)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Address2)];
			//entity.Address2 = (Convert.IsDBNull(reader["Address2"]))?string.Empty:(System.String)reader["Address2"];
			entity.City = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.City)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.Country = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Country)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Country)];
			//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
			entity.Region = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Region)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Region)];
			//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
			entity.PostalCode = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.PostalCode)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.Telephone = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.Telephone)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.Telephone)];
			//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
			entity.RoleId = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_ModeratorList_AdminSiteColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
			entity.CharityId = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_ModeratorList_AdminSiteColumn.CharityId)];
			//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
			entity.CharityName = (reader.IsDBNull(((int)Vw_ModeratorList_AdminSiteColumn.CharityName)))?null:(System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.CharityName)];
			//entity.CharityName = (Convert.IsDBNull(reader["CharityName"]))?string.Empty:(System.String)reader["CharityName"];
			entity.SalesPerson = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.SalesPerson)];
			//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
			entity.SalesPersonId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.AccountManagerId = (System.Int32)reader[((int)Vw_ModeratorList_AdminSiteColumn.AccountManagerId)];
			//entity.AccountManagerId = (Convert.IsDBNull(reader["AccountManagerID"]))?(int)0:(System.Int32)reader["AccountManagerID"];
			entity.AccountManager = (System.String)reader[((int)Vw_ModeratorList_AdminSiteColumn.AccountManager)];
			//entity.AccountManager = (Convert.IsDBNull(reader["AccountManager"]))?string.Empty:(System.String)reader["AccountManager"];
			entity.DateProvisioned = (System.DateTime)reader[((int)Vw_ModeratorList_AdminSiteColumn.DateProvisioned)];
			//entity.DateProvisioned = (Convert.IsDBNull(reader["DateProvisioned"]))?DateTime.MinValue:(System.DateTime)reader["DateProvisioned"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_ModeratorList_AdminSite"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ModeratorList_AdminSite"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_ModeratorList_AdminSite entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32)dataRow["UserID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.AdminName = (Convert.IsDBNull(dataRow["AdminName"]))?string.Empty:(System.String)dataRow["AdminName"];
			entity.WebLoginName = (Convert.IsDBNull(dataRow["WebLoginName"]))?string.Empty:(System.String)dataRow["WebLoginName"];
			entity.WebLoginPassword = (Convert.IsDBNull(dataRow["WebLoginPassword"]))?string.Empty:(System.String)dataRow["WebLoginPassword"];
			entity.ModeratorName = (Convert.IsDBNull(dataRow["ModeratorName"]))?string.Empty:(System.String)dataRow["ModeratorName"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?string.Empty:(System.String)dataRow["Email"];
			entity.Address1 = (Convert.IsDBNull(dataRow["Address1"]))?string.Empty:(System.String)dataRow["Address1"];
			entity.Address2 = (Convert.IsDBNull(dataRow["Address2"]))?string.Empty:(System.String)dataRow["Address2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?string.Empty:(System.String)dataRow["Country"];
			entity.Region = (Convert.IsDBNull(dataRow["Region"]))?string.Empty:(System.String)dataRow["Region"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.Telephone = (Convert.IsDBNull(dataRow["Telephone"]))?string.Empty:(System.String)dataRow["Telephone"];
			entity.RoleId = (Convert.IsDBNull(dataRow["RoleID"]))?(int)0:(System.Int32?)dataRow["RoleID"];
			entity.CharityId = (Convert.IsDBNull(dataRow["CharityID"]))?(int)0:(System.Int32?)dataRow["CharityID"];
			entity.CharityName = (Convert.IsDBNull(dataRow["CharityName"]))?string.Empty:(System.String)dataRow["CharityName"];
			entity.SalesPerson = (Convert.IsDBNull(dataRow["SalesPerson"]))?string.Empty:(System.String)dataRow["SalesPerson"];
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32)dataRow["SalesPersonID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.AccountManagerId = (Convert.IsDBNull(dataRow["AccountManagerID"]))?(int)0:(System.Int32)dataRow["AccountManagerID"];
			entity.AccountManager = (Convert.IsDBNull(dataRow["AccountManager"]))?string.Empty:(System.String)dataRow["AccountManager"];
			entity.DateProvisioned = (Convert.IsDBNull(dataRow["DateProvisioned"]))?DateTime.MinValue:(System.DateTime)dataRow["DateProvisioned"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_ModeratorList_AdminSiteFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteFilterBuilder : SqlFilterBuilder<Vw_ModeratorList_AdminSiteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilterBuilder class.
		/// </summary>
		public Vw_ModeratorList_AdminSiteFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorList_AdminSiteFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorList_AdminSiteFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorList_AdminSiteFilterBuilder

	#region Vw_ModeratorList_AdminSiteParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ModeratorList_AdminSite"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ModeratorList_AdminSiteParameterBuilder : ParameterizedSqlFilterBuilder<Vw_ModeratorList_AdminSiteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteParameterBuilder class.
		/// </summary>
		public Vw_ModeratorList_AdminSiteParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ModeratorList_AdminSiteParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ModeratorList_AdminSiteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ModeratorList_AdminSiteParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ModeratorList_AdminSiteParameterBuilder
} // end namespace
