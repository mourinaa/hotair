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
	/// This class is the base class for any <see cref="Vw_ConferenceListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_ConferenceListProviderBaseCore : EntityViewProviderBase<Vw_ConferenceList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_ConferenceList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_ConferenceList&gt;"/></returns>
		protected static VList&lt;Vw_ConferenceList&gt; Fill(DataSet dataSet, VList<Vw_ConferenceList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_ConferenceList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_ConferenceList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_ConferenceList>"/></returns>
		protected static VList&lt;Vw_ConferenceList&gt; Fill(DataTable dataTable, VList<Vw_ConferenceList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_ConferenceList c = new Vw_ConferenceList();
					c.Id = (Convert.IsDBNull(row["ID"]))?(int)0:(System.Int32)row["ID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.AdminName = (Convert.IsDBNull(row["AdminName"]))?string.Empty:(System.String)row["AdminName"];
					c.ModeratorName = (Convert.IsDBNull(row["ModeratorName"]))?string.Empty:(System.String)row["ModeratorName"];
					c.ModeratorCode = (Convert.IsDBNull(row["ModeratorCode"]))?string.Empty:(System.String)row["ModeratorCode"];
					c.PassCode = (Convert.IsDBNull(row["PassCode"]))?string.Empty:(System.String)row["PassCode"];
					c.SeeVoghMeetingId = (Convert.IsDBNull(row["SeeVoghMeetingId"]))?string.Empty:(System.String)row["SeeVoghMeetingId"];
					c.Enabled = (Convert.IsDBNull(row["Enabled"]))?false:(System.Boolean?)row["Enabled"];
					c.LastWalletCardSentdate = (Convert.IsDBNull(row["LastWalletCardSentdate"]))?string.Empty:(System.String)row["LastWalletCardSentdate"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.CompanyId = (Convert.IsDBNull(row["CompanyID"]))?(int)0:(System.Int32)row["CompanyID"];
					c.SalesPersonId = (Convert.IsDBNull(row["SalesPersonID"]))?(int)0:(System.Int32)row["SalesPersonID"];
					c.SalesPerson = (Convert.IsDBNull(row["SalesPerson"]))?string.Empty:(System.String)row["SalesPerson"];
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32)row["UserID"];
					c.ConferenceName = (Convert.IsDBNull(row["ConferenceName"]))?string.Empty:(System.String)row["ConferenceName"];
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
		/// Fill an <see cref="VList&lt;Vw_ConferenceList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_ConferenceList&gt;"/></returns>
		protected VList<Vw_ConferenceList> Fill(IDataReader reader, VList<Vw_ConferenceList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_ConferenceList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_ConferenceList>("Vw_ConferenceList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_ConferenceList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int32)reader[((int)Vw_ConferenceListColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
					entity.CompanyName = (reader.IsDBNull(((int)Vw_ConferenceListColumn.CompanyName)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.AdminName = (System.String)reader[((int)Vw_ConferenceListColumn.AdminName)];
					//entity.AdminName = (Convert.IsDBNull(reader["AdminName"]))?string.Empty:(System.String)reader["AdminName"];
					entity.ModeratorName = (System.String)reader[((int)Vw_ConferenceListColumn.ModeratorName)];
					//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
					entity.ModeratorCode = (System.String)reader[((int)Vw_ConferenceListColumn.ModeratorCode)];
					//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
					entity.PassCode = (System.String)reader[((int)Vw_ConferenceListColumn.PassCode)];
					//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
					entity.SeeVoghMeetingId = (reader.IsDBNull(((int)Vw_ConferenceListColumn.SeeVoghMeetingId)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.SeeVoghMeetingId)];
					//entity.SeeVoghMeetingId = (Convert.IsDBNull(reader["SeeVoghMeetingId"]))?string.Empty:(System.String)reader["SeeVoghMeetingId"];
					entity.Enabled = (reader.IsDBNull(((int)Vw_ConferenceListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_ConferenceListColumn.Enabled)];
					//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
					entity.LastWalletCardSentdate = (reader.IsDBNull(((int)Vw_ConferenceListColumn.LastWalletCardSentdate)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.LastWalletCardSentdate)];
					//entity.LastWalletCardSentdate = (Convert.IsDBNull(reader["LastWalletCardSentdate"]))?string.Empty:(System.String)reader["LastWalletCardSentdate"];
					entity.WholesalerId = (System.String)reader[((int)Vw_ConferenceListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (System.Int32)reader[((int)Vw_ConferenceListColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.CompanyId = (System.Int32)reader[((int)Vw_ConferenceListColumn.CompanyId)];
					//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32)reader["CompanyID"];
					entity.SalesPersonId = (System.Int32)reader[((int)Vw_ConferenceListColumn.SalesPersonId)];
					//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
					entity.SalesPerson = (System.String)reader[((int)Vw_ConferenceListColumn.SalesPerson)];
					//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
					entity.UserId = (System.Int32)reader[((int)Vw_ConferenceListColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
					entity.ConferenceName = (reader.IsDBNull(((int)Vw_ConferenceListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.ConferenceName)];
					//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
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
		/// Refreshes the <see cref="Vw_ConferenceList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ConferenceList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_ConferenceList entity)
		{
			reader.Read();
			entity.Id = (System.Int32)reader[((int)Vw_ConferenceListColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
			entity.CompanyName = (reader.IsDBNull(((int)Vw_ConferenceListColumn.CompanyName)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.AdminName = (System.String)reader[((int)Vw_ConferenceListColumn.AdminName)];
			//entity.AdminName = (Convert.IsDBNull(reader["AdminName"]))?string.Empty:(System.String)reader["AdminName"];
			entity.ModeratorName = (System.String)reader[((int)Vw_ConferenceListColumn.ModeratorName)];
			//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
			entity.ModeratorCode = (System.String)reader[((int)Vw_ConferenceListColumn.ModeratorCode)];
			//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
			entity.PassCode = (System.String)reader[((int)Vw_ConferenceListColumn.PassCode)];
			//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
			entity.SeeVoghMeetingId = (reader.IsDBNull(((int)Vw_ConferenceListColumn.SeeVoghMeetingId)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.SeeVoghMeetingId)];
			//entity.SeeVoghMeetingId = (Convert.IsDBNull(reader["SeeVoghMeetingId"]))?string.Empty:(System.String)reader["SeeVoghMeetingId"];
			entity.Enabled = (reader.IsDBNull(((int)Vw_ConferenceListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_ConferenceListColumn.Enabled)];
			//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
			entity.LastWalletCardSentdate = (reader.IsDBNull(((int)Vw_ConferenceListColumn.LastWalletCardSentdate)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.LastWalletCardSentdate)];
			//entity.LastWalletCardSentdate = (Convert.IsDBNull(reader["LastWalletCardSentdate"]))?string.Empty:(System.String)reader["LastWalletCardSentdate"];
			entity.WholesalerId = (System.String)reader[((int)Vw_ConferenceListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)Vw_ConferenceListColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.CompanyId = (System.Int32)reader[((int)Vw_ConferenceListColumn.CompanyId)];
			//entity.CompanyId = (Convert.IsDBNull(reader["CompanyID"]))?(int)0:(System.Int32)reader["CompanyID"];
			entity.SalesPersonId = (System.Int32)reader[((int)Vw_ConferenceListColumn.SalesPersonId)];
			//entity.SalesPersonId = (Convert.IsDBNull(reader["SalesPersonID"]))?(int)0:(System.Int32)reader["SalesPersonID"];
			entity.SalesPerson = (System.String)reader[((int)Vw_ConferenceListColumn.SalesPerson)];
			//entity.SalesPerson = (Convert.IsDBNull(reader["SalesPerson"]))?string.Empty:(System.String)reader["SalesPerson"];
			entity.UserId = (System.Int32)reader[((int)Vw_ConferenceListColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
			entity.ConferenceName = (reader.IsDBNull(((int)Vw_ConferenceListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_ConferenceListColumn.ConferenceName)];
			//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_ConferenceList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ConferenceList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_ConferenceList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["ID"]))?(int)0:(System.Int32)dataRow["ID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.AdminName = (Convert.IsDBNull(dataRow["AdminName"]))?string.Empty:(System.String)dataRow["AdminName"];
			entity.ModeratorName = (Convert.IsDBNull(dataRow["ModeratorName"]))?string.Empty:(System.String)dataRow["ModeratorName"];
			entity.ModeratorCode = (Convert.IsDBNull(dataRow["ModeratorCode"]))?string.Empty:(System.String)dataRow["ModeratorCode"];
			entity.PassCode = (Convert.IsDBNull(dataRow["PassCode"]))?string.Empty:(System.String)dataRow["PassCode"];
			entity.SeeVoghMeetingId = (Convert.IsDBNull(dataRow["SeeVoghMeetingId"]))?string.Empty:(System.String)dataRow["SeeVoghMeetingId"];
			entity.Enabled = (Convert.IsDBNull(dataRow["Enabled"]))?false:(System.Boolean?)dataRow["Enabled"];
			entity.LastWalletCardSentdate = (Convert.IsDBNull(dataRow["LastWalletCardSentdate"]))?string.Empty:(System.String)dataRow["LastWalletCardSentdate"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.CompanyId = (Convert.IsDBNull(dataRow["CompanyID"]))?(int)0:(System.Int32)dataRow["CompanyID"];
			entity.SalesPersonId = (Convert.IsDBNull(dataRow["SalesPersonID"]))?(int)0:(System.Int32)dataRow["SalesPersonID"];
			entity.SalesPerson = (Convert.IsDBNull(dataRow["SalesPerson"]))?string.Empty:(System.String)dataRow["SalesPerson"];
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32)dataRow["UserID"];
			entity.ConferenceName = (Convert.IsDBNull(dataRow["ConferenceName"]))?string.Empty:(System.String)dataRow["ConferenceName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_ConferenceListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListFilterBuilder : SqlFilterBuilder<Vw_ConferenceListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilterBuilder class.
		/// </summary>
		public Vw_ConferenceListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceListFilterBuilder

	#region Vw_ConferenceListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_ConferenceListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListParameterBuilder class.
		/// </summary>
		public Vw_ConferenceListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceListParameterBuilder
} // end namespace
