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
	/// This class is the base class for any <see cref="Vw_CustomerTransactionListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_CustomerTransactionListProviderBaseCore : EntityViewProviderBase<Vw_CustomerTransactionList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_CustomerTransactionList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_CustomerTransactionList&gt;"/></returns>
		protected static VList&lt;Vw_CustomerTransactionList&gt; Fill(DataSet dataSet, VList<Vw_CustomerTransactionList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_CustomerTransactionList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_CustomerTransactionList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_CustomerTransactionList>"/></returns>
		protected static VList&lt;Vw_CustomerTransactionList&gt; Fill(DataTable dataTable, VList<Vw_CustomerTransactionList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_CustomerTransactionList c = new Vw_CustomerTransactionList();
					c.Id = (Convert.IsDBNull(row["ID"]))?(long)0:(System.Int64)row["ID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32?)row["ModeratorID"];
					c.PriCustomerNumber = (Convert.IsDBNull(row["PriCustomerNumber"]))?string.Empty:(System.String)row["PriCustomerNumber"];
					c.SecCustomerNumber = (Convert.IsDBNull(row["SecCustomerNumber"]))?string.Empty:(System.String)row["SecCustomerNumber"];
					c.CustomerTransactionTypeId = (Convert.IsDBNull(row["CustomerTransactionTypeID"]))?(int)0:(System.Int32)row["CustomerTransactionTypeID"];
					c.CustomerTransactionTypeDisplayName = (Convert.IsDBNull(row["CustomerTransactionTypeDisplayName"]))?string.Empty:(System.String)row["CustomerTransactionTypeDisplayName"];
					c.TransactionDescription = (Convert.IsDBNull(row["TransactionDescription"]))?string.Empty:(System.String)row["TransactionDescription"];
					c.TransactionDate = (Convert.IsDBNull(row["TransactionDate"]))?DateTime.MinValue:(System.DateTime)row["TransactionDate"];
					c.TransactionAmount = (Convert.IsDBNull(row["TransactionAmount"]))?0.0m:(System.Decimal?)row["TransactionAmount"];
					c.LocalTaxRate = (Convert.IsDBNull(row["LocalTaxRate"]))?0.0m:(System.Decimal?)row["LocalTaxRate"];
					c.FederalTaxRate = (Convert.IsDBNull(row["FederalTaxRate"]))?0.0m:(System.Decimal?)row["FederalTaxRate"];
					c.LocalTaxAmount = (Convert.IsDBNull(row["LocalTaxAmount"]))?0.0m:(System.Decimal?)row["LocalTaxAmount"];
					c.FederalTaxAmount = (Convert.IsDBNull(row["FederalTaxAmount"]))?0.0m:(System.Decimal?)row["FederalTaxAmount"];
					c.TransactionTotal = (Convert.IsDBNull(row["TransactionTotal"]))?0.0m:(System.Decimal?)row["TransactionTotal"];
					c.CustomerBalance = (Convert.IsDBNull(row["CustomerBalance"]))?0.0m:(System.Decimal?)row["CustomerBalance"];
					c.Wholesaler_ProductId = (Convert.IsDBNull(row["Wholesaler_ProductID"]))?(int)0:(System.Int32?)row["Wholesaler_ProductID"];
					c.ProductRateId = (Convert.IsDBNull(row["ProductRateID"]))?(int)0:(System.Int32?)row["ProductRateID"];
					c.Quantity = (Convert.IsDBNull(row["Quantity"]))?(int)0:(System.Int32?)row["Quantity"];
					c.SellRate = (Convert.IsDBNull(row["SellRate"]))?0.0m:(System.Decimal?)row["SellRate"];
					c.BuyRate = (Convert.IsDBNull(row["BuyRate"]))?0.0m:(System.Decimal?)row["BuyRate"];
					c.WsTransactionAmount = (Convert.IsDBNull(row["WSTransactionAmount"]))?0.0m:(System.Decimal?)row["WSTransactionAmount"];
					c.ReferenceNumber = (Convert.IsDBNull(row["ReferenceNumber"]))?string.Empty:(System.String)row["ReferenceNumber"];
					c.UniqueConferenceId = (Convert.IsDBNull(row["UniqueConferenceID"]))?string.Empty:(System.String)row["UniqueConferenceID"];
					c.PostedDate = (Convert.IsDBNull(row["PostedDate"]))?DateTime.MinValue:(System.DateTime)row["PostedDate"];
					c.ModifiedBy = (Convert.IsDBNull(row["ModifiedBy"]))?string.Empty:(System.String)row["ModifiedBy"];
					c.CreatedDate = (Convert.IsDBNull(row["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)row["CreatedDate"];
					c.PostedToInvoice = (Convert.IsDBNull(row["PostedToInvoice"]))?false:(System.Boolean?)row["PostedToInvoice"];
					c.PostedToInvoiceDate = (Convert.IsDBNull(row["PostedToInvoiceDate"]))?DateTime.MinValue:(System.DateTime?)row["PostedToInvoiceDate"];
					c.ElapsedTimeSeconds = (Convert.IsDBNull(row["ElapsedTimeSeconds"]))?(int)0:(System.Int32?)row["ElapsedTimeSeconds"];
					c.ProductRateDisplayName = (Convert.IsDBNull(row["ProductRateDisplayName"]))?string.Empty:(System.String)row["ProductRateDisplayName"];
					c.Wholesaler_ProductName = (Convert.IsDBNull(row["Wholesaler_ProductName"]))?string.Empty:(System.String)row["Wholesaler_ProductName"];
					c.ModeratorName = (Convert.IsDBNull(row["ModeratorName"]))?string.Empty:(System.String)row["ModeratorName"];
					c.ConferenceName = (Convert.IsDBNull(row["ConferenceName"]))?string.Empty:(System.String)row["ConferenceName"];
					c.ModeratorConferenceName = (Convert.IsDBNull(row["ModeratorConferenceName"]))?string.Empty:(System.String)row["ModeratorConferenceName"];
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
		/// Fill an <see cref="VList&lt;Vw_CustomerTransactionList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_CustomerTransactionList&gt;"/></returns>
		protected VList<Vw_CustomerTransactionList> Fill(IDataReader reader, VList<Vw_CustomerTransactionList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_CustomerTransactionList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_CustomerTransactionList>("Vw_CustomerTransactionList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_CustomerTransactionList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int64)reader[((int)Vw_CustomerTransactionListColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["ID"]))?(long)0:(System.Int64)reader["ID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_CustomerTransactionListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (System.Int32)reader[((int)Vw_CustomerTransactionListColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.ModeratorId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
					entity.PriCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PriCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.PriCustomerNumber)];
					//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
					entity.SecCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.SecCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.SecCustomerNumber)];
					//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
					entity.CustomerTransactionTypeId = (System.Int32)reader[((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeId)];
					//entity.CustomerTransactionTypeId = (Convert.IsDBNull(reader["CustomerTransactionTypeID"]))?(int)0:(System.Int32)reader["CustomerTransactionTypeID"];
					entity.CustomerTransactionTypeDisplayName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeDisplayName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeDisplayName)];
					//entity.CustomerTransactionTypeDisplayName = (Convert.IsDBNull(reader["CustomerTransactionTypeDisplayName"]))?string.Empty:(System.String)reader["CustomerTransactionTypeDisplayName"];
					entity.TransactionDescription = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionDescription)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.TransactionDescription)];
					//entity.TransactionDescription = (Convert.IsDBNull(reader["TransactionDescription"]))?string.Empty:(System.String)reader["TransactionDescription"];
					entity.TransactionDate = (System.DateTime)reader[((int)Vw_CustomerTransactionListColumn.TransactionDate)];
					//entity.TransactionDate = (Convert.IsDBNull(reader["TransactionDate"]))?DateTime.MinValue:(System.DateTime)reader["TransactionDate"];
					entity.TransactionAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.TransactionAmount)];
					//entity.TransactionAmount = (Convert.IsDBNull(reader["TransactionAmount"]))?0.0m:(System.Decimal?)reader["TransactionAmount"];
					entity.LocalTaxRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.LocalTaxRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.LocalTaxRate)];
					//entity.LocalTaxRate = (Convert.IsDBNull(reader["LocalTaxRate"]))?0.0m:(System.Decimal?)reader["LocalTaxRate"];
					entity.FederalTaxRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.FederalTaxRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.FederalTaxRate)];
					//entity.FederalTaxRate = (Convert.IsDBNull(reader["FederalTaxRate"]))?0.0m:(System.Decimal?)reader["FederalTaxRate"];
					entity.LocalTaxAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.LocalTaxAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.LocalTaxAmount)];
					//entity.LocalTaxAmount = (Convert.IsDBNull(reader["LocalTaxAmount"]))?0.0m:(System.Decimal?)reader["LocalTaxAmount"];
					entity.FederalTaxAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.FederalTaxAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.FederalTaxAmount)];
					//entity.FederalTaxAmount = (Convert.IsDBNull(reader["FederalTaxAmount"]))?0.0m:(System.Decimal?)reader["FederalTaxAmount"];
					entity.TransactionTotal = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionTotal)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.TransactionTotal)];
					//entity.TransactionTotal = (Convert.IsDBNull(reader["TransactionTotal"]))?0.0m:(System.Decimal?)reader["TransactionTotal"];
					entity.CustomerBalance = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CustomerBalance)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.CustomerBalance)];
					//entity.CustomerBalance = (Convert.IsDBNull(reader["CustomerBalance"]))?0.0m:(System.Decimal?)reader["CustomerBalance"];
					entity.Wholesaler_ProductId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductId)];
					//entity.Wholesaler_ProductId = (Convert.IsDBNull(reader["Wholesaler_ProductID"]))?(int)0:(System.Int32?)reader["Wholesaler_ProductID"];
					entity.ProductRateId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ProductRateId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ProductRateId)];
					//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32?)reader["ProductRateID"];
					entity.Quantity = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Quantity)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.Quantity)];
					//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(int)0:(System.Int32?)reader["Quantity"];
					entity.SellRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.SellRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.SellRate)];
					//entity.SellRate = (Convert.IsDBNull(reader["SellRate"]))?0.0m:(System.Decimal?)reader["SellRate"];
					entity.BuyRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.BuyRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.BuyRate)];
					//entity.BuyRate = (Convert.IsDBNull(reader["BuyRate"]))?0.0m:(System.Decimal?)reader["BuyRate"];
					entity.WsTransactionAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.WsTransactionAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.WsTransactionAmount)];
					//entity.WsTransactionAmount = (Convert.IsDBNull(reader["WSTransactionAmount"]))?0.0m:(System.Decimal?)reader["WSTransactionAmount"];
					entity.ReferenceNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ReferenceNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ReferenceNumber)];
					//entity.ReferenceNumber = (Convert.IsDBNull(reader["ReferenceNumber"]))?string.Empty:(System.String)reader["ReferenceNumber"];
					entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.UniqueConferenceId)];
					//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
					entity.PostedDate = (System.DateTime)reader[((int)Vw_CustomerTransactionListColumn.PostedDate)];
					//entity.PostedDate = (Convert.IsDBNull(reader["PostedDate"]))?DateTime.MinValue:(System.DateTime)reader["PostedDate"];
					entity.ModifiedBy = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModifiedBy)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModifiedBy)];
					//entity.ModifiedBy = (Convert.IsDBNull(reader["ModifiedBy"]))?string.Empty:(System.String)reader["ModifiedBy"];
					entity.CreatedDate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CreatedDate)))?null:(System.DateTime?)reader[((int)Vw_CustomerTransactionListColumn.CreatedDate)];
					//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreatedDate"];
					entity.PostedToInvoice = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PostedToInvoice)))?null:(System.Boolean?)reader[((int)Vw_CustomerTransactionListColumn.PostedToInvoice)];
					//entity.PostedToInvoice = (Convert.IsDBNull(reader["PostedToInvoice"]))?false:(System.Boolean?)reader["PostedToInvoice"];
					entity.PostedToInvoiceDate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PostedToInvoiceDate)))?null:(System.DateTime?)reader[((int)Vw_CustomerTransactionListColumn.PostedToInvoiceDate)];
					//entity.PostedToInvoiceDate = (Convert.IsDBNull(reader["PostedToInvoiceDate"]))?DateTime.MinValue:(System.DateTime?)reader["PostedToInvoiceDate"];
					entity.ElapsedTimeSeconds = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ElapsedTimeSeconds)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ElapsedTimeSeconds)];
					//entity.ElapsedTimeSeconds = (Convert.IsDBNull(reader["ElapsedTimeSeconds"]))?(int)0:(System.Int32?)reader["ElapsedTimeSeconds"];
					entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ProductRateDisplayName)];
					//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
					entity.Wholesaler_ProductName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductName)];
					//entity.Wholesaler_ProductName = (Convert.IsDBNull(reader["Wholesaler_ProductName"]))?string.Empty:(System.String)reader["Wholesaler_ProductName"];
					entity.ModeratorName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModeratorName)];
					//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
					entity.ConferenceName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ConferenceName)];
					//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
					entity.ModeratorConferenceName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorConferenceName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModeratorConferenceName)];
					//entity.ModeratorConferenceName = (Convert.IsDBNull(reader["ModeratorConferenceName"]))?string.Empty:(System.String)reader["ModeratorConferenceName"];
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
		/// Refreshes the <see cref="Vw_CustomerTransactionList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_CustomerTransactionList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_CustomerTransactionList entity)
		{
			reader.Read();
			entity.Id = (System.Int64)reader[((int)Vw_CustomerTransactionListColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["ID"]))?(long)0:(System.Int64)reader["ID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_CustomerTransactionListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)Vw_CustomerTransactionListColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.ModeratorId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PriCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.PriCustomerNumber)];
			//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.SecCustomerNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.SecCustomerNumber)];
			//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
			entity.CustomerTransactionTypeId = (System.Int32)reader[((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeId)];
			//entity.CustomerTransactionTypeId = (Convert.IsDBNull(reader["CustomerTransactionTypeID"]))?(int)0:(System.Int32)reader["CustomerTransactionTypeID"];
			entity.CustomerTransactionTypeDisplayName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeDisplayName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.CustomerTransactionTypeDisplayName)];
			//entity.CustomerTransactionTypeDisplayName = (Convert.IsDBNull(reader["CustomerTransactionTypeDisplayName"]))?string.Empty:(System.String)reader["CustomerTransactionTypeDisplayName"];
			entity.TransactionDescription = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionDescription)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.TransactionDescription)];
			//entity.TransactionDescription = (Convert.IsDBNull(reader["TransactionDescription"]))?string.Empty:(System.String)reader["TransactionDescription"];
			entity.TransactionDate = (System.DateTime)reader[((int)Vw_CustomerTransactionListColumn.TransactionDate)];
			//entity.TransactionDate = (Convert.IsDBNull(reader["TransactionDate"]))?DateTime.MinValue:(System.DateTime)reader["TransactionDate"];
			entity.TransactionAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.TransactionAmount)];
			//entity.TransactionAmount = (Convert.IsDBNull(reader["TransactionAmount"]))?0.0m:(System.Decimal?)reader["TransactionAmount"];
			entity.LocalTaxRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.LocalTaxRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.LocalTaxRate)];
			//entity.LocalTaxRate = (Convert.IsDBNull(reader["LocalTaxRate"]))?0.0m:(System.Decimal?)reader["LocalTaxRate"];
			entity.FederalTaxRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.FederalTaxRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.FederalTaxRate)];
			//entity.FederalTaxRate = (Convert.IsDBNull(reader["FederalTaxRate"]))?0.0m:(System.Decimal?)reader["FederalTaxRate"];
			entity.LocalTaxAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.LocalTaxAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.LocalTaxAmount)];
			//entity.LocalTaxAmount = (Convert.IsDBNull(reader["LocalTaxAmount"]))?0.0m:(System.Decimal?)reader["LocalTaxAmount"];
			entity.FederalTaxAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.FederalTaxAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.FederalTaxAmount)];
			//entity.FederalTaxAmount = (Convert.IsDBNull(reader["FederalTaxAmount"]))?0.0m:(System.Decimal?)reader["FederalTaxAmount"];
			entity.TransactionTotal = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.TransactionTotal)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.TransactionTotal)];
			//entity.TransactionTotal = (Convert.IsDBNull(reader["TransactionTotal"]))?0.0m:(System.Decimal?)reader["TransactionTotal"];
			entity.CustomerBalance = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CustomerBalance)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.CustomerBalance)];
			//entity.CustomerBalance = (Convert.IsDBNull(reader["CustomerBalance"]))?0.0m:(System.Decimal?)reader["CustomerBalance"];
			entity.Wholesaler_ProductId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductId)];
			//entity.Wholesaler_ProductId = (Convert.IsDBNull(reader["Wholesaler_ProductID"]))?(int)0:(System.Int32?)reader["Wholesaler_ProductID"];
			entity.ProductRateId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ProductRateId)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ProductRateId)];
			//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32?)reader["ProductRateID"];
			entity.Quantity = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Quantity)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.Quantity)];
			//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(int)0:(System.Int32?)reader["Quantity"];
			entity.SellRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.SellRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.SellRate)];
			//entity.SellRate = (Convert.IsDBNull(reader["SellRate"]))?0.0m:(System.Decimal?)reader["SellRate"];
			entity.BuyRate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.BuyRate)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.BuyRate)];
			//entity.BuyRate = (Convert.IsDBNull(reader["BuyRate"]))?0.0m:(System.Decimal?)reader["BuyRate"];
			entity.WsTransactionAmount = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.WsTransactionAmount)))?null:(System.Decimal?)reader[((int)Vw_CustomerTransactionListColumn.WsTransactionAmount)];
			//entity.WsTransactionAmount = (Convert.IsDBNull(reader["WSTransactionAmount"]))?0.0m:(System.Decimal?)reader["WSTransactionAmount"];
			entity.ReferenceNumber = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ReferenceNumber)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ReferenceNumber)];
			//entity.ReferenceNumber = (Convert.IsDBNull(reader["ReferenceNumber"]))?string.Empty:(System.String)reader["ReferenceNumber"];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.UniqueConferenceId)];
			//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
			entity.PostedDate = (System.DateTime)reader[((int)Vw_CustomerTransactionListColumn.PostedDate)];
			//entity.PostedDate = (Convert.IsDBNull(reader["PostedDate"]))?DateTime.MinValue:(System.DateTime)reader["PostedDate"];
			entity.ModifiedBy = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModifiedBy)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModifiedBy)];
			//entity.ModifiedBy = (Convert.IsDBNull(reader["ModifiedBy"]))?string.Empty:(System.String)reader["ModifiedBy"];
			entity.CreatedDate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.CreatedDate)))?null:(System.DateTime?)reader[((int)Vw_CustomerTransactionListColumn.CreatedDate)];
			//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreatedDate"];
			entity.PostedToInvoice = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PostedToInvoice)))?null:(System.Boolean?)reader[((int)Vw_CustomerTransactionListColumn.PostedToInvoice)];
			//entity.PostedToInvoice = (Convert.IsDBNull(reader["PostedToInvoice"]))?false:(System.Boolean?)reader["PostedToInvoice"];
			entity.PostedToInvoiceDate = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.PostedToInvoiceDate)))?null:(System.DateTime?)reader[((int)Vw_CustomerTransactionListColumn.PostedToInvoiceDate)];
			//entity.PostedToInvoiceDate = (Convert.IsDBNull(reader["PostedToInvoiceDate"]))?DateTime.MinValue:(System.DateTime?)reader["PostedToInvoiceDate"];
			entity.ElapsedTimeSeconds = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ElapsedTimeSeconds)))?null:(System.Int32?)reader[((int)Vw_CustomerTransactionListColumn.ElapsedTimeSeconds)];
			//entity.ElapsedTimeSeconds = (Convert.IsDBNull(reader["ElapsedTimeSeconds"]))?(int)0:(System.Int32?)reader["ElapsedTimeSeconds"];
			entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ProductRateDisplayName)];
			//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
			entity.Wholesaler_ProductName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.Wholesaler_ProductName)];
			//entity.Wholesaler_ProductName = (Convert.IsDBNull(reader["Wholesaler_ProductName"]))?string.Empty:(System.String)reader["Wholesaler_ProductName"];
			entity.ModeratorName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModeratorName)];
			//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
			entity.ConferenceName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ConferenceName)];
			//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
			entity.ModeratorConferenceName = (reader.IsDBNull(((int)Vw_CustomerTransactionListColumn.ModeratorConferenceName)))?null:(System.String)reader[((int)Vw_CustomerTransactionListColumn.ModeratorConferenceName)];
			//entity.ModeratorConferenceName = (Convert.IsDBNull(reader["ModeratorConferenceName"]))?string.Empty:(System.String)reader["ModeratorConferenceName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_CustomerTransactionList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_CustomerTransactionList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_CustomerTransactionList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["ID"]))?(long)0:(System.Int64)dataRow["ID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32?)dataRow["ModeratorID"];
			entity.PriCustomerNumber = (Convert.IsDBNull(dataRow["PriCustomerNumber"]))?string.Empty:(System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (Convert.IsDBNull(dataRow["SecCustomerNumber"]))?string.Empty:(System.String)dataRow["SecCustomerNumber"];
			entity.CustomerTransactionTypeId = (Convert.IsDBNull(dataRow["CustomerTransactionTypeID"]))?(int)0:(System.Int32)dataRow["CustomerTransactionTypeID"];
			entity.CustomerTransactionTypeDisplayName = (Convert.IsDBNull(dataRow["CustomerTransactionTypeDisplayName"]))?string.Empty:(System.String)dataRow["CustomerTransactionTypeDisplayName"];
			entity.TransactionDescription = (Convert.IsDBNull(dataRow["TransactionDescription"]))?string.Empty:(System.String)dataRow["TransactionDescription"];
			entity.TransactionDate = (Convert.IsDBNull(dataRow["TransactionDate"]))?DateTime.MinValue:(System.DateTime)dataRow["TransactionDate"];
			entity.TransactionAmount = (Convert.IsDBNull(dataRow["TransactionAmount"]))?0.0m:(System.Decimal?)dataRow["TransactionAmount"];
			entity.LocalTaxRate = (Convert.IsDBNull(dataRow["LocalTaxRate"]))?0.0m:(System.Decimal?)dataRow["LocalTaxRate"];
			entity.FederalTaxRate = (Convert.IsDBNull(dataRow["FederalTaxRate"]))?0.0m:(System.Decimal?)dataRow["FederalTaxRate"];
			entity.LocalTaxAmount = (Convert.IsDBNull(dataRow["LocalTaxAmount"]))?0.0m:(System.Decimal?)dataRow["LocalTaxAmount"];
			entity.FederalTaxAmount = (Convert.IsDBNull(dataRow["FederalTaxAmount"]))?0.0m:(System.Decimal?)dataRow["FederalTaxAmount"];
			entity.TransactionTotal = (Convert.IsDBNull(dataRow["TransactionTotal"]))?0.0m:(System.Decimal?)dataRow["TransactionTotal"];
			entity.CustomerBalance = (Convert.IsDBNull(dataRow["CustomerBalance"]))?0.0m:(System.Decimal?)dataRow["CustomerBalance"];
			entity.Wholesaler_ProductId = (Convert.IsDBNull(dataRow["Wholesaler_ProductID"]))?(int)0:(System.Int32?)dataRow["Wholesaler_ProductID"];
			entity.ProductRateId = (Convert.IsDBNull(dataRow["ProductRateID"]))?(int)0:(System.Int32?)dataRow["ProductRateID"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?(int)0:(System.Int32?)dataRow["Quantity"];
			entity.SellRate = (Convert.IsDBNull(dataRow["SellRate"]))?0.0m:(System.Decimal?)dataRow["SellRate"];
			entity.BuyRate = (Convert.IsDBNull(dataRow["BuyRate"]))?0.0m:(System.Decimal?)dataRow["BuyRate"];
			entity.WsTransactionAmount = (Convert.IsDBNull(dataRow["WSTransactionAmount"]))?0.0m:(System.Decimal?)dataRow["WSTransactionAmount"];
			entity.ReferenceNumber = (Convert.IsDBNull(dataRow["ReferenceNumber"]))?string.Empty:(System.String)dataRow["ReferenceNumber"];
			entity.UniqueConferenceId = (Convert.IsDBNull(dataRow["UniqueConferenceID"]))?string.Empty:(System.String)dataRow["UniqueConferenceID"];
			entity.PostedDate = (Convert.IsDBNull(dataRow["PostedDate"]))?DateTime.MinValue:(System.DateTime)dataRow["PostedDate"];
			entity.ModifiedBy = (Convert.IsDBNull(dataRow["ModifiedBy"]))?string.Empty:(System.String)dataRow["ModifiedBy"];
			entity.CreatedDate = (Convert.IsDBNull(dataRow["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreatedDate"];
			entity.PostedToInvoice = (Convert.IsDBNull(dataRow["PostedToInvoice"]))?false:(System.Boolean?)dataRow["PostedToInvoice"];
			entity.PostedToInvoiceDate = (Convert.IsDBNull(dataRow["PostedToInvoiceDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["PostedToInvoiceDate"];
			entity.ElapsedTimeSeconds = (Convert.IsDBNull(dataRow["ElapsedTimeSeconds"]))?(int)0:(System.Int32?)dataRow["ElapsedTimeSeconds"];
			entity.ProductRateDisplayName = (Convert.IsDBNull(dataRow["ProductRateDisplayName"]))?string.Empty:(System.String)dataRow["ProductRateDisplayName"];
			entity.Wholesaler_ProductName = (Convert.IsDBNull(dataRow["Wholesaler_ProductName"]))?string.Empty:(System.String)dataRow["Wholesaler_ProductName"];
			entity.ModeratorName = (Convert.IsDBNull(dataRow["ModeratorName"]))?string.Empty:(System.String)dataRow["ModeratorName"];
			entity.ConferenceName = (Convert.IsDBNull(dataRow["ConferenceName"]))?string.Empty:(System.String)dataRow["ConferenceName"];
			entity.ModeratorConferenceName = (Convert.IsDBNull(dataRow["ModeratorConferenceName"]))?string.Empty:(System.String)dataRow["ModeratorConferenceName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_CustomerTransactionListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListFilterBuilder : SqlFilterBuilder<Vw_CustomerTransactionListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilterBuilder class.
		/// </summary>
		public Vw_CustomerTransactionListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerTransactionListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerTransactionListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerTransactionListFilterBuilder

	#region Vw_CustomerTransactionListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_CustomerTransactionList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_CustomerTransactionListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_CustomerTransactionListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListParameterBuilder class.
		/// </summary>
		public Vw_CustomerTransactionListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_CustomerTransactionListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_CustomerTransactionListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_CustomerTransactionListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_CustomerTransactionListParameterBuilder
} // end namespace
