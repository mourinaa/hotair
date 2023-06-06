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
	/// This class is the base class for any <see cref="Vw_UserListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_UserListProviderBaseCore : EntityViewProviderBase<Vw_UserList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_UserList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_UserList&gt;"/></returns>
		protected static VList&lt;Vw_UserList&gt; Fill(DataSet dataSet, VList<Vw_UserList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_UserList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_UserList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_UserList>"/></returns>
		protected static VList&lt;Vw_UserList&gt; Fill(DataTable dataTable, VList<Vw_UserList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_UserList c = new Vw_UserList();
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32)row["UserID"];
					c.Username = (Convert.IsDBNull(row["Username"]))?string.Empty:(System.String)row["Username"];
					c.Password = (Convert.IsDBNull(row["Password"]))?string.Empty:(System.String)row["Password"];
					c.DisplayName = (Convert.IsDBNull(row["DisplayName"]))?string.Empty:(System.String)row["DisplayName"];
					c.Email = (Convert.IsDBNull(row["Email"]))?string.Empty:(System.String)row["Email"];
					c.Telephone = (Convert.IsDBNull(row["Telephone"]))?string.Empty:(System.String)row["Telephone"];
					c.Enabled = (Convert.IsDBNull(row["Enabled"]))?false:(System.Boolean)row["Enabled"];
					c.CompanyId = (Convert.IsDBNull(row["CompanyID"]))?(int)0:(System.Int32?)row["CompanyID"];
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32?)row["SalesPersonID"];
					c.RoleId = (Convert.IsDBNull(row["RoleID"]))?(int)0:(System.Int32?)row["RoleID"];
					c.MustChangePassword = (Convert.IsDBNull(row["MustChangePassword"]))?false:(System.Boolean?)row["MustChangePassword"];
					c.Address1 = (Convert.IsDBNull(row["Address1"]))?string.Empty:(System.String)row["Address1"];
					c.Address2 = (Convert.IsDBNull(row["Address2"]))?string.Empty:(System.String)row["Address2"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.Country = (Convert.IsDBNull(row["Country"]))?string.Empty:(System.String)row["Country"];
					c.Region = (Convert.IsDBNull(row["Region"]))?string.Empty:(System.String)row["Region"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.CharityId = (Convert.IsDBNull(row["CharityID"]))?(int)0:(System.Int32?)row["CharityID"];
					c.WebMemberId = (Convert.IsDBNull(row["WebMemberID"]))?string.Empty:(System.String)row["WebMemberID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32?)row["CustomerID"];
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32?)row["ModeratorID"];
					c.DdlDescription = (Convert.IsDBNull(row["DDLDescription"]))?string.Empty:(System.String)row["DDLDescription"];
					c.RoleName = (Convert.IsDBNull(row["RoleName"]))?string.Empty:(System.String)row["RoleName"];
					c.CustomerSalesPersonId = (Convert.IsDBNull(row["CustomerSalesPersonID"]))?(int)0:(System.Int32?)row["CustomerSalesPersonID"];
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
		/// Fill an <see cref="VList&lt;Vw_UserList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_UserList&gt;"/></returns>
		protected VList<Vw_UserList> Fill(IDataReader reader, VList<Vw_UserList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_UserList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_UserList>("Vw_UserList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_UserList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.UserId = (System.Int32)reader[((int)Vw_UserListColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
					entity.Username = (System.String)reader[((int)Vw_UserListColumn.Username)];
					//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
					entity.Password = (System.String)reader[((int)Vw_UserListColumn.Password)];
					//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
					entity.DisplayName = (System.String)reader[((int)Vw_UserListColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.Email = (reader.IsDBNull(((int)Vw_UserListColumn.Email)))?null:(System.String)reader[((int)Vw_UserListColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.Telephone = (reader.IsDBNull(((int)Vw_UserListColumn.Telephone)))?null:(System.String)reader[((int)Vw_UserListColumn.Telephone)];
					//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
					entity.Enabled = (System.Boolean)reader[((int)Vw_UserListColumn.Enabled)];
					//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean)reader["Enabled"];
					entity.CompanyId = (reader.IsDBNull(((int)Vw_UserListColumn.CompanyId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CompanyId)];
					//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32?)reader["CompanyID"];
					entity.SalesPersonId = (reader.IsDBNull(((int)Vw_UserListColumn.SalesPersonId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32?)reader["SalesPersonID"];
					entity.RoleId = (reader.IsDBNull(((int)Vw_UserListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
					entity.MustChangePassword = (reader.IsDBNull(((int)Vw_UserListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_UserListColumn.MustChangePassword)];
					//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
					entity.Address1 = (reader.IsDBNull(((int)Vw_UserListColumn.Address1)))?null:(System.String)reader[((int)Vw_UserListColumn.Address1)];
					//entity.Address1 = (Convert.IsDBNull(reader["Address1"]))?string.Empty:(System.String)reader["Address1"];
					entity.Address2 = (reader.IsDBNull(((int)Vw_UserListColumn.Address2)))?null:(System.String)reader[((int)Vw_UserListColumn.Address2)];
					//entity.Address2 = (Convert.IsDBNull(reader["Address2"]))?string.Empty:(System.String)reader["Address2"];
					entity.City = (reader.IsDBNull(((int)Vw_UserListColumn.City)))?null:(System.String)reader[((int)Vw_UserListColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.Country = (reader.IsDBNull(((int)Vw_UserListColumn.Country)))?null:(System.String)reader[((int)Vw_UserListColumn.Country)];
					//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
					entity.Region = (reader.IsDBNull(((int)Vw_UserListColumn.Region)))?null:(System.String)reader[((int)Vw_UserListColumn.Region)];
					//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
					entity.PostalCode = (reader.IsDBNull(((int)Vw_UserListColumn.PostalCode)))?null:(System.String)reader[((int)Vw_UserListColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.CharityId = (reader.IsDBNull(((int)Vw_UserListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CharityId)];
					//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
					entity.WebMemberId = (reader.IsDBNull(((int)Vw_UserListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_UserListColumn.WebMemberId)];
					//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
					entity.WholesalerId = (reader.IsDBNull(((int)Vw_UserListColumn.WholesalerId)))?null:(System.String)reader[((int)Vw_UserListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (reader.IsDBNull(((int)Vw_UserListColumn.CustomerId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32?)reader["CustomerID"];
					entity.ModeratorId = (reader.IsDBNull(((int)Vw_UserListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
					entity.DdlDescription = (System.String)reader[((int)Vw_UserListColumn.DdlDescription)];
					//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
					entity.RoleName = (System.String)reader[((int)Vw_UserListColumn.RoleName)];
					//entity.RoleName = (Convert.IsDBNull(reader["RoleName"]))?string.Empty:(System.String)reader["RoleName"];
					entity.CustomerSalesPersonId = (reader.IsDBNull(((int)Vw_UserListColumn.CustomerSalesPersonId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CustomerSalesPersonId)];
					//entity.CustomerSalesPersonId = (Convert.IsDBNull(reader["CustomerSalesPersonID"]))?(int)0:(System.Int32?)reader["CustomerSalesPersonID"];
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
		/// Refreshes the <see cref="Vw_UserList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_UserList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_UserList entity)
		{
			reader.Read();
			entity.UserId = (System.Int32)reader[((int)Vw_UserListColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
			entity.Username = (System.String)reader[((int)Vw_UserListColumn.Username)];
			//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
			entity.Password = (System.String)reader[((int)Vw_UserListColumn.Password)];
			//entity.Password = (Convert.IsDBNull(reader["Password"]))?string.Empty:(System.String)reader["Password"];
			entity.DisplayName = (System.String)reader[((int)Vw_UserListColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.Email = (reader.IsDBNull(((int)Vw_UserListColumn.Email)))?null:(System.String)reader[((int)Vw_UserListColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.Telephone = (reader.IsDBNull(((int)Vw_UserListColumn.Telephone)))?null:(System.String)reader[((int)Vw_UserListColumn.Telephone)];
			//entity.Telephone = (Convert.IsDBNull(reader["Telephone"]))?string.Empty:(System.String)reader["Telephone"];
			entity.Enabled = (System.Boolean)reader[((int)Vw_UserListColumn.Enabled)];
			//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean)reader["Enabled"];
			entity.CompanyId = (reader.IsDBNull(((int)Vw_UserListColumn.CompanyId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CompanyId)];
			//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32?)reader["CompanyID"];
			entity.SalesPersonId = (reader.IsDBNull(((int)Vw_UserListColumn.SalesPersonId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32?)reader["SalesPersonID"];
			entity.RoleId = (reader.IsDBNull(((int)Vw_UserListColumn.RoleId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32?)reader["RoleID"];
			entity.MustChangePassword = (reader.IsDBNull(((int)Vw_UserListColumn.MustChangePassword)))?null:(System.Boolean?)reader[((int)Vw_UserListColumn.MustChangePassword)];
			//entity.MustChangePassword = (Convert.IsDBNull(reader["MustChangePassword"]))?false:(System.Boolean?)reader["MustChangePassword"];
			entity.Address1 = (reader.IsDBNull(((int)Vw_UserListColumn.Address1)))?null:(System.String)reader[((int)Vw_UserListColumn.Address1)];
			//entity.Address1 = (Convert.IsDBNull(reader["Address1"]))?string.Empty:(System.String)reader["Address1"];
			entity.Address2 = (reader.IsDBNull(((int)Vw_UserListColumn.Address2)))?null:(System.String)reader[((int)Vw_UserListColumn.Address2)];
			//entity.Address2 = (Convert.IsDBNull(reader["Address2"]))?string.Empty:(System.String)reader["Address2"];
			entity.City = (reader.IsDBNull(((int)Vw_UserListColumn.City)))?null:(System.String)reader[((int)Vw_UserListColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.Country = (reader.IsDBNull(((int)Vw_UserListColumn.Country)))?null:(System.String)reader[((int)Vw_UserListColumn.Country)];
			//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
			entity.Region = (reader.IsDBNull(((int)Vw_UserListColumn.Region)))?null:(System.String)reader[((int)Vw_UserListColumn.Region)];
			//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
			entity.PostalCode = (reader.IsDBNull(((int)Vw_UserListColumn.PostalCode)))?null:(System.String)reader[((int)Vw_UserListColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.CharityId = (reader.IsDBNull(((int)Vw_UserListColumn.CharityId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CharityId)];
			//entity.CharityId = (Convert.IsDBNull(reader["CharityID"]))?(int)0:(System.Int32?)reader["CharityID"];
			entity.WebMemberId = (reader.IsDBNull(((int)Vw_UserListColumn.WebMemberId)))?null:(System.String)reader[((int)Vw_UserListColumn.WebMemberId)];
			//entity.WebMemberId = (Convert.IsDBNull(reader["WebMemberID"]))?string.Empty:(System.String)reader["WebMemberID"];
			entity.WholesalerId = (reader.IsDBNull(((int)Vw_UserListColumn.WholesalerId)))?null:(System.String)reader[((int)Vw_UserListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (reader.IsDBNull(((int)Vw_UserListColumn.CustomerId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32?)reader["CustomerID"];
			entity.ModeratorId = (reader.IsDBNull(((int)Vw_UserListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
			entity.DdlDescription = (System.String)reader[((int)Vw_UserListColumn.DdlDescription)];
			//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
			entity.RoleName = (System.String)reader[((int)Vw_UserListColumn.RoleName)];
			//entity.RoleName = (Convert.IsDBNull(reader["RoleName"]))?string.Empty:(System.String)reader["RoleName"];
			entity.CustomerSalesPersonId = (reader.IsDBNull(((int)Vw_UserListColumn.CustomerSalesPersonId)))?null:(System.Int32?)reader[((int)Vw_UserListColumn.CustomerSalesPersonId)];
			//entity.CustomerSalesPersonId = (Convert.IsDBNull(reader["CustomerSalesPersonID"]))?(int)0:(System.Int32?)reader["CustomerSalesPersonID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_UserList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_UserList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_UserList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32)dataRow["UserID"];
			entity.Username = (Convert.IsDBNull(dataRow["Username"]))?string.Empty:(System.String)dataRow["Username"];
			entity.Password = (Convert.IsDBNull(dataRow["Password"]))?string.Empty:(System.String)dataRow["Password"];
			entity.DisplayName = (Convert.IsDBNull(dataRow["DisplayName"]))?string.Empty:(System.String)dataRow["DisplayName"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?string.Empty:(System.String)dataRow["Email"];
			entity.Telephone = (Convert.IsDBNull(dataRow["Telephone"]))?string.Empty:(System.String)dataRow["Telephone"];
			entity.Enabled = (Convert.IsDBNull(dataRow["Enabled"]))?false:(System.Boolean)dataRow["Enabled"];
			entity.CompanyId = (Convert.IsDBNull(dataRow["CompanyID"]))?(int)0:(System.Int32?)dataRow["CompanyID"];
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32?)dataRow["SalesPersonID"];
			entity.RoleId = (Convert.IsDBNull(dataRow["RoleID"]))?(int)0:(System.Int32?)dataRow["RoleID"];
			entity.MustChangePassword = (Convert.IsDBNull(dataRow["MustChangePassword"]))?false:(System.Boolean?)dataRow["MustChangePassword"];
			entity.Address1 = (Convert.IsDBNull(dataRow["Address1"]))?string.Empty:(System.String)dataRow["Address1"];
			entity.Address2 = (Convert.IsDBNull(dataRow["Address2"]))?string.Empty:(System.String)dataRow["Address2"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?string.Empty:(System.String)dataRow["Country"];
			entity.Region = (Convert.IsDBNull(dataRow["Region"]))?string.Empty:(System.String)dataRow["Region"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.CharityId = (Convert.IsDBNull(dataRow["CharityID"]))?(int)0:(System.Int32?)dataRow["CharityID"];
			entity.WebMemberId = (Convert.IsDBNull(dataRow["WebMemberID"]))?string.Empty:(System.String)dataRow["WebMemberID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32?)dataRow["CustomerID"];
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32?)dataRow["ModeratorID"];
			entity.DdlDescription = (Convert.IsDBNull(dataRow["DDLDescription"]))?string.Empty:(System.String)dataRow["DDLDescription"];
			entity.RoleName = (Convert.IsDBNull(dataRow["RoleName"]))?string.Empty:(System.String)dataRow["RoleName"];
			entity.CustomerSalesPersonId = (Convert.IsDBNull(dataRow["CustomerSalesPersonID"]))?(int)0:(System.Int32?)dataRow["CustomerSalesPersonID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_UserListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListFilterBuilder : SqlFilterBuilder<Vw_UserListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilterBuilder class.
		/// </summary>
		public Vw_UserListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_UserListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_UserListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_UserListFilterBuilder

	#region Vw_UserListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_UserList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_UserListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_UserListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_UserListParameterBuilder class.
		/// </summary>
		public Vw_UserListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_UserListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_UserListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_UserListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_UserListParameterBuilder
} // end namespace
