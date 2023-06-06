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
	/// This class is the base class for any <see cref="Vw_DefaultProductRatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_DefaultProductRatesProviderBaseCore : EntityViewProviderBase<Vw_DefaultProductRates>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_DefaultProductRates&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_DefaultProductRates&gt;"/></returns>
		protected static VList&lt;Vw_DefaultProductRates&gt; Fill(DataSet dataSet, VList<Vw_DefaultProductRates> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_DefaultProductRates>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_DefaultProductRates&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_DefaultProductRates>"/></returns>
		protected static VList&lt;Vw_DefaultProductRates&gt; Fill(DataTable dataTable, VList<Vw_DefaultProductRates> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_DefaultProductRates c = new Vw_DefaultProductRates();
					c.ProductRateValueId = (Convert.IsDBNull(row["ProductRateValueID"]))?(int)0:(System.Int32)row["ProductRateValueID"];
					c.ProductRateId = (Convert.IsDBNull(row["ProductRateID"]))?(int)0:(System.Int32)row["ProductRateID"];
					c.SellRate = (Convert.IsDBNull(row["SellRate"]))?0.0m:(System.Decimal)row["SellRate"];
					c.SellRateCurrencyId = (Convert.IsDBNull(row["SellRateCurrencyID"]))?string.Empty:(System.String)row["SellRateCurrencyID"];
					c.BuyRate = (Convert.IsDBNull(row["BuyRate"]))?0.0m:(System.Decimal)row["BuyRate"];
					c.BuyRateCurrencyId = (Convert.IsDBNull(row["BuyRateCurrencyID"]))?string.Empty:(System.String)row["BuyRateCurrencyID"];
					c.StartDate = (Convert.IsDBNull(row["StartDate"]))?DateTime.MinValue:(System.DateTime?)row["StartDate"];
					c.DefaultOption = (Convert.IsDBNull(row["DefaultOption"]))?(byte)0:(System.Byte)row["DefaultOption"];
					c.ProductRateName = (Convert.IsDBNull(row["ProductRateName"]))?string.Empty:(System.String)row["ProductRateName"];
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.ProductDefaultOption = (Convert.IsDBNull(row["ProductDefaultOption"]))?false:(System.Boolean?)row["ProductDefaultOption"];
					c.ProductTypeId = (Convert.IsDBNull(row["ProductTypeID"]))?(int)0:(System.Int32)row["ProductTypeID"];
					c.ProductRateTypeId = (Convert.IsDBNull(row["ProductRateTypeID"]))?(int)0:(System.Int32)row["ProductRateTypeID"];
					c.ProductTypeName = (Convert.IsDBNull(row["ProductTypeName"]))?string.Empty:(System.String)row["ProductTypeName"];
					c.ProductRateTypeName = (Convert.IsDBNull(row["ProductRateTypeName"]))?string.Empty:(System.String)row["ProductRateTypeName"];
					c.ProductDisplayOrder = (Convert.IsDBNull(row["ProductDisplayOrder"]))?(int)0:(System.Int32?)row["ProductDisplayOrder"];
					c.ProductRateDisplayName = (Convert.IsDBNull(row["ProductRateDisplayName"]))?string.Empty:(System.String)row["ProductRateDisplayName"];
					c.ProductRateDisplayOrder = (Convert.IsDBNull(row["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)row["ProductRateDisplayOrder"];
					c.ProductTypeDisplayName = (Convert.IsDBNull(row["ProductTypeDisplayName"]))?string.Empty:(System.String)row["ProductTypeDisplayName"];
					c.ProductTypeDisplayOrder = (Convert.IsDBNull(row["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)row["ProductTypeDisplayOrder"];
					c.ProductRateTypeDisplayName = (Convert.IsDBNull(row["ProductRateTypeDisplayName"]))?string.Empty:(System.String)row["ProductRateTypeDisplayName"];
					c.ProductRateTypeDisplayOrder = (Convert.IsDBNull(row["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)row["ProductRateTypeDisplayOrder"];
					c.DdlDescription = (Convert.IsDBNull(row["DDLDescription"]))?string.Empty:(System.String)row["DDLDescription"];
					c.RatingTypeId = (Convert.IsDBNull(row["RatingTypeID"]))?(int)0:(System.Int32)row["RatingTypeID"];
					c.DisplayName = (Convert.IsDBNull(row["DisplayName"]))?string.Empty:(System.String)row["DisplayName"];
					c.DdlDescription2 = (Convert.IsDBNull(row["DDLDescription2"]))?string.Empty:(System.String)row["DDLDescription2"];
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
		/// Fill an <see cref="VList&lt;Vw_DefaultProductRates&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_DefaultProductRates&gt;"/></returns>
		protected VList<Vw_DefaultProductRates> Fill(IDataReader reader, VList<Vw_DefaultProductRates> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_DefaultProductRates entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_DefaultProductRates>("Vw_DefaultProductRates",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_DefaultProductRates();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductRateValueId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateValueId)];
					//entity.ProductRateValueId = (Convert.IsDBNull(reader["ProductRateValueID"]))?(int)0:(System.Int32)reader["ProductRateValueID"];
					entity.ProductRateId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateId)];
					//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32)reader["ProductRateID"];
					entity.SellRate = (System.Decimal)reader[((int)Vw_DefaultProductRatesColumn.SellRate)];
					//entity.SellRate = (Convert.IsDBNull(reader["SellRate"]))?0.0m:(System.Decimal)reader["SellRate"];
					entity.SellRateCurrencyId = (System.String)reader[((int)Vw_DefaultProductRatesColumn.SellRateCurrencyId)];
					//entity.SellRateCurrencyId = (Convert.IsDBNull(reader["SellRateCurrencyID"]))?string.Empty:(System.String)reader["SellRateCurrencyID"];
					entity.BuyRate = (System.Decimal)reader[((int)Vw_DefaultProductRatesColumn.BuyRate)];
					//entity.BuyRate = (Convert.IsDBNull(reader["BuyRate"]))?0.0m:(System.Decimal)reader["BuyRate"];
					entity.BuyRateCurrencyId = (System.String)reader[((int)Vw_DefaultProductRatesColumn.BuyRateCurrencyId)];
					//entity.BuyRateCurrencyId = (Convert.IsDBNull(reader["BuyRateCurrencyID"]))?string.Empty:(System.String)reader["BuyRateCurrencyID"];
					entity.StartDate = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.StartDate)))?null:(System.DateTime?)reader[((int)Vw_DefaultProductRatesColumn.StartDate)];
					//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["StartDate"];
					entity.DefaultOption = (System.Byte)reader[((int)Vw_DefaultProductRatesColumn.DefaultOption)];
					//entity.DefaultOption = (Convert.IsDBNull(reader["DefaultOption"]))?(byte)0:(System.Byte)reader["DefaultOption"];
					entity.ProductRateName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateName)];
					//entity.ProductRateName = (Convert.IsDBNull(reader["ProductRateName"]))?string.Empty:(System.String)reader["ProductRateName"];
					entity.ProductId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductDefaultOption = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductDefaultOption)))?null:(System.Boolean?)reader[((int)Vw_DefaultProductRatesColumn.ProductDefaultOption)];
					//entity.ProductDefaultOption = (Convert.IsDBNull(reader["ProductDefaultOption"]))?false:(System.Boolean?)reader["ProductDefaultOption"];
					entity.ProductTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeId)];
					//entity.ProductTypeId = (Convert.IsDBNull(reader["ProductTypeID"]))?(int)0:(System.Int32)reader["ProductTypeID"];
					entity.ProductRateTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeId)];
					//entity.ProductRateTypeId = (Convert.IsDBNull(reader["ProductRateTypeID"]))?(int)0:(System.Int32)reader["ProductRateTypeID"];
					entity.ProductTypeName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeName)];
					//entity.ProductTypeName = (Convert.IsDBNull(reader["ProductTypeName"]))?string.Empty:(System.String)reader["ProductTypeName"];
					entity.ProductRateTypeName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeName)];
					//entity.ProductRateTypeName = (Convert.IsDBNull(reader["ProductRateTypeName"]))?string.Empty:(System.String)reader["ProductRateTypeName"];
					entity.ProductDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductDisplayOrder)];
					//entity.ProductDisplayOrder = (Convert.IsDBNull(reader["ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductDisplayOrder"];
					entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateDisplayName)];
					//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
					entity.ProductRateDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductRateDisplayOrder)];
					//entity.ProductRateDisplayOrder = (Convert.IsDBNull(reader["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateDisplayOrder"];
					entity.ProductTypeDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayName)];
					//entity.ProductTypeDisplayName = (Convert.IsDBNull(reader["ProductTypeDisplayName"]))?string.Empty:(System.String)reader["ProductTypeDisplayName"];
					entity.ProductTypeDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayOrder)];
					//entity.ProductTypeDisplayOrder = (Convert.IsDBNull(reader["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductTypeDisplayOrder"];
					entity.ProductRateTypeDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayName)];
					//entity.ProductRateTypeDisplayName = (Convert.IsDBNull(reader["ProductRateTypeDisplayName"]))?string.Empty:(System.String)reader["ProductRateTypeDisplayName"];
					entity.ProductRateTypeDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayOrder)];
					//entity.ProductRateTypeDisplayOrder = (Convert.IsDBNull(reader["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateTypeDisplayOrder"];
					entity.DdlDescription = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DdlDescription)];
					//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
					entity.RatingTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.RatingTypeId)];
					//entity.RatingTypeId = (Convert.IsDBNull(reader["RatingTypeID"]))?(int)0:(System.Int32)reader["RatingTypeID"];
					entity.DisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.DdlDescription2 = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DdlDescription2)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DdlDescription2)];
					//entity.DdlDescription2 = (Convert.IsDBNull(reader["DDLDescription2"]))?string.Empty:(System.String)reader["DDLDescription2"];
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
		/// Refreshes the <see cref="Vw_DefaultProductRates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_DefaultProductRates"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_DefaultProductRates entity)
		{
			reader.Read();
			entity.ProductRateValueId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateValueId)];
			//entity.ProductRateValueId = (Convert.IsDBNull(reader["ProductRateValueID"]))?(int)0:(System.Int32)reader["ProductRateValueID"];
			entity.ProductRateId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateId)];
			//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32)reader["ProductRateID"];
			entity.SellRate = (System.Decimal)reader[((int)Vw_DefaultProductRatesColumn.SellRate)];
			//entity.SellRate = (Convert.IsDBNull(reader["SellRate"]))?0.0m:(System.Decimal)reader["SellRate"];
			entity.SellRateCurrencyId = (System.String)reader[((int)Vw_DefaultProductRatesColumn.SellRateCurrencyId)];
			//entity.SellRateCurrencyId = (Convert.IsDBNull(reader["SellRateCurrencyID"]))?string.Empty:(System.String)reader["SellRateCurrencyID"];
			entity.BuyRate = (System.Decimal)reader[((int)Vw_DefaultProductRatesColumn.BuyRate)];
			//entity.BuyRate = (Convert.IsDBNull(reader["BuyRate"]))?0.0m:(System.Decimal)reader["BuyRate"];
			entity.BuyRateCurrencyId = (System.String)reader[((int)Vw_DefaultProductRatesColumn.BuyRateCurrencyId)];
			//entity.BuyRateCurrencyId = (Convert.IsDBNull(reader["BuyRateCurrencyID"]))?string.Empty:(System.String)reader["BuyRateCurrencyID"];
			entity.StartDate = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.StartDate)))?null:(System.DateTime?)reader[((int)Vw_DefaultProductRatesColumn.StartDate)];
			//entity.StartDate = (Convert.IsDBNull(reader["StartDate"]))?DateTime.MinValue:(System.DateTime?)reader["StartDate"];
			entity.DefaultOption = (System.Byte)reader[((int)Vw_DefaultProductRatesColumn.DefaultOption)];
			//entity.DefaultOption = (Convert.IsDBNull(reader["DefaultOption"]))?(byte)0:(System.Byte)reader["DefaultOption"];
			entity.ProductRateName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateName)];
			//entity.ProductRateName = (Convert.IsDBNull(reader["ProductRateName"]))?string.Empty:(System.String)reader["ProductRateName"];
			entity.ProductId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductDefaultOption = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductDefaultOption)))?null:(System.Boolean?)reader[((int)Vw_DefaultProductRatesColumn.ProductDefaultOption)];
			//entity.ProductDefaultOption = (Convert.IsDBNull(reader["ProductDefaultOption"]))?false:(System.Boolean?)reader["ProductDefaultOption"];
			entity.ProductTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeId)];
			//entity.ProductTypeId = (Convert.IsDBNull(reader["ProductTypeID"]))?(int)0:(System.Int32)reader["ProductTypeID"];
			entity.ProductRateTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeId)];
			//entity.ProductRateTypeId = (Convert.IsDBNull(reader["ProductRateTypeID"]))?(int)0:(System.Int32)reader["ProductRateTypeID"];
			entity.ProductTypeName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeName)];
			//entity.ProductTypeName = (Convert.IsDBNull(reader["ProductTypeName"]))?string.Empty:(System.String)reader["ProductTypeName"];
			entity.ProductRateTypeName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeName)];
			//entity.ProductRateTypeName = (Convert.IsDBNull(reader["ProductRateTypeName"]))?string.Empty:(System.String)reader["ProductRateTypeName"];
			entity.ProductDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductDisplayOrder)];
			//entity.ProductDisplayOrder = (Convert.IsDBNull(reader["ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductDisplayOrder"];
			entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateDisplayName)];
			//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
			entity.ProductRateDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductRateDisplayOrder)];
			//entity.ProductRateDisplayOrder = (Convert.IsDBNull(reader["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateDisplayOrder"];
			entity.ProductTypeDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayName)];
			//entity.ProductTypeDisplayName = (Convert.IsDBNull(reader["ProductTypeDisplayName"]))?string.Empty:(System.String)reader["ProductTypeDisplayName"];
			entity.ProductTypeDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductTypeDisplayOrder)];
			//entity.ProductTypeDisplayOrder = (Convert.IsDBNull(reader["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductTypeDisplayOrder"];
			entity.ProductRateTypeDisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayName)];
			//entity.ProductRateTypeDisplayName = (Convert.IsDBNull(reader["ProductRateTypeDisplayName"]))?string.Empty:(System.String)reader["ProductRateTypeDisplayName"];
			entity.ProductRateTypeDisplayOrder = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_DefaultProductRatesColumn.ProductRateTypeDisplayOrder)];
			//entity.ProductRateTypeDisplayOrder = (Convert.IsDBNull(reader["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateTypeDisplayOrder"];
			entity.DdlDescription = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DdlDescription)];
			//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
			entity.RatingTypeId = (System.Int32)reader[((int)Vw_DefaultProductRatesColumn.RatingTypeId)];
			//entity.RatingTypeId = (Convert.IsDBNull(reader["RatingTypeID"]))?(int)0:(System.Int32)reader["RatingTypeID"];
			entity.DisplayName = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DisplayName)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.DdlDescription2 = (reader.IsDBNull(((int)Vw_DefaultProductRatesColumn.DdlDescription2)))?null:(System.String)reader[((int)Vw_DefaultProductRatesColumn.DdlDescription2)];
			//entity.DdlDescription2 = (Convert.IsDBNull(reader["DDLDescription2"]))?string.Empty:(System.String)reader["DDLDescription2"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_DefaultProductRates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_DefaultProductRates"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_DefaultProductRates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductRateValueId = (Convert.IsDBNull(dataRow["ProductRateValueID"]))?(int)0:(System.Int32)dataRow["ProductRateValueID"];
			entity.ProductRateId = (Convert.IsDBNull(dataRow["ProductRateID"]))?(int)0:(System.Int32)dataRow["ProductRateID"];
			entity.SellRate = (Convert.IsDBNull(dataRow["SellRate"]))?0.0m:(System.Decimal)dataRow["SellRate"];
			entity.SellRateCurrencyId = (Convert.IsDBNull(dataRow["SellRateCurrencyID"]))?string.Empty:(System.String)dataRow["SellRateCurrencyID"];
			entity.BuyRate = (Convert.IsDBNull(dataRow["BuyRate"]))?0.0m:(System.Decimal)dataRow["BuyRate"];
			entity.BuyRateCurrencyId = (Convert.IsDBNull(dataRow["BuyRateCurrencyID"]))?string.Empty:(System.String)dataRow["BuyRateCurrencyID"];
			entity.StartDate = (Convert.IsDBNull(dataRow["StartDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["StartDate"];
			entity.DefaultOption = (Convert.IsDBNull(dataRow["DefaultOption"]))?(byte)0:(System.Byte)dataRow["DefaultOption"];
			entity.ProductRateName = (Convert.IsDBNull(dataRow["ProductRateName"]))?string.Empty:(System.String)dataRow["ProductRateName"];
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.ProductDefaultOption = (Convert.IsDBNull(dataRow["ProductDefaultOption"]))?false:(System.Boolean?)dataRow["ProductDefaultOption"];
			entity.ProductTypeId = (Convert.IsDBNull(dataRow["ProductTypeID"]))?(int)0:(System.Int32)dataRow["ProductTypeID"];
			entity.ProductRateTypeId = (Convert.IsDBNull(dataRow["ProductRateTypeID"]))?(int)0:(System.Int32)dataRow["ProductRateTypeID"];
			entity.ProductTypeName = (Convert.IsDBNull(dataRow["ProductTypeName"]))?string.Empty:(System.String)dataRow["ProductTypeName"];
			entity.ProductRateTypeName = (Convert.IsDBNull(dataRow["ProductRateTypeName"]))?string.Empty:(System.String)dataRow["ProductRateTypeName"];
			entity.ProductDisplayOrder = (Convert.IsDBNull(dataRow["ProductDisplayOrder"]))?(int)0:(System.Int32?)dataRow["ProductDisplayOrder"];
			entity.ProductRateDisplayName = (Convert.IsDBNull(dataRow["ProductRateDisplayName"]))?string.Empty:(System.String)dataRow["ProductRateDisplayName"];
			entity.ProductRateDisplayOrder = (Convert.IsDBNull(dataRow["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)dataRow["ProductRateDisplayOrder"];
			entity.ProductTypeDisplayName = (Convert.IsDBNull(dataRow["ProductTypeDisplayName"]))?string.Empty:(System.String)dataRow["ProductTypeDisplayName"];
			entity.ProductTypeDisplayOrder = (Convert.IsDBNull(dataRow["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)dataRow["ProductTypeDisplayOrder"];
			entity.ProductRateTypeDisplayName = (Convert.IsDBNull(dataRow["ProductRateTypeDisplayName"]))?string.Empty:(System.String)dataRow["ProductRateTypeDisplayName"];
			entity.ProductRateTypeDisplayOrder = (Convert.IsDBNull(dataRow["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)dataRow["ProductRateTypeDisplayOrder"];
			entity.DdlDescription = (Convert.IsDBNull(dataRow["DDLDescription"]))?string.Empty:(System.String)dataRow["DDLDescription"];
			entity.RatingTypeId = (Convert.IsDBNull(dataRow["RatingTypeID"]))?(int)0:(System.Int32)dataRow["RatingTypeID"];
			entity.DisplayName = (Convert.IsDBNull(dataRow["DisplayName"]))?string.Empty:(System.String)dataRow["DisplayName"];
			entity.DdlDescription2 = (Convert.IsDBNull(dataRow["DDLDescription2"]))?string.Empty:(System.String)dataRow["DDLDescription2"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_DefaultProductRatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesFilterBuilder : SqlFilterBuilder<Vw_DefaultProductRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilterBuilder class.
		/// </summary>
		public Vw_DefaultProductRatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_DefaultProductRatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_DefaultProductRatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_DefaultProductRatesFilterBuilder

	#region Vw_DefaultProductRatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_DefaultProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_DefaultProductRatesParameterBuilder : ParameterizedSqlFilterBuilder<Vw_DefaultProductRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesParameterBuilder class.
		/// </summary>
		public Vw_DefaultProductRatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_DefaultProductRatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_DefaultProductRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_DefaultProductRatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_DefaultProductRatesParameterBuilder
} // end namespace
