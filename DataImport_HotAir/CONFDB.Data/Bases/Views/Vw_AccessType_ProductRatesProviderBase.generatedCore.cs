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
	/// This class is the base class for any <see cref="Vw_AccessType_ProductRatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_AccessType_ProductRatesProviderBaseCore : EntityViewProviderBase<Vw_AccessType_ProductRates>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_AccessType_ProductRates&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_AccessType_ProductRates&gt;"/></returns>
		protected static VList&lt;Vw_AccessType_ProductRates&gt; Fill(DataSet dataSet, VList<Vw_AccessType_ProductRates> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_AccessType_ProductRates>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_AccessType_ProductRates&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_AccessType_ProductRates>"/></returns>
		protected static VList&lt;Vw_AccessType_ProductRates&gt; Fill(DataTable dataTable, VList<Vw_AccessType_ProductRates> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_AccessType_ProductRates c = new Vw_AccessType_ProductRates();
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
					c.ProductRateDescription = (Convert.IsDBNull(row["ProductRateDescription"]))?string.Empty:(System.String)row["ProductRateDescription"];
					c.RatingTypeId = (Convert.IsDBNull(row["RatingTypeID"]))?(int)0:(System.Int32)row["RatingTypeID"];
					c.RatingTypeDisplayName = (Convert.IsDBNull(row["RatingTypeDisplayName"]))?string.Empty:(System.String)row["RatingTypeDisplayName"];
					c.AccessTypeId = (Convert.IsDBNull(row["AccessTypeID"]))?(int)0:(System.Int32)row["AccessTypeID"];
					c.ProductRateId = (Convert.IsDBNull(row["ProductRateID"]))?(int)0:(System.Int32)row["ProductRateID"];
					c.AccessTypeName = (Convert.IsDBNull(row["AccessTypeName"]))?string.Empty:(System.String)row["AccessTypeName"];
					c.AccessTypeDisplayName = (Convert.IsDBNull(row["AccessTypeDisplayName"]))?string.Empty:(System.String)row["AccessTypeDisplayName"];
					c.AccessTypeValue = (Convert.IsDBNull(row["AccessTypeValue"]))?(int)0:(System.Int32)row["AccessTypeValue"];
					c.AccessTypeBillable = (Convert.IsDBNull(row["AccessTypeBillable"]))?false:(System.Boolean)row["AccessTypeBillable"];
					c.AccessTypeEnabled = (Convert.IsDBNull(row["AccessTypeEnabled"]))?false:(System.Boolean)row["AccessTypeEnabled"];
					c.AccessType_ProductRateId = (Convert.IsDBNull(row["AccessType_ProductRateID"]))?(int)0:(System.Int32)row["AccessType_ProductRateID"];
					c.ProductRateIntervalId = (Convert.IsDBNull(row["ProductRateIntervalID"]))?(int)0:(System.Int32)row["ProductRateIntervalID"];
					c.ProductRateTaxableId = (Convert.IsDBNull(row["ProductRateTaxableID"]))?(int)0:(System.Int32)row["ProductRateTaxableID"];
					c.ProductRateCountryId = (Convert.IsDBNull(row["ProductRateCountryID"]))?string.Empty:(System.String)row["ProductRateCountryID"];
					c.MinimumTimeBeforeChargedSec = (Convert.IsDBNull(row["MinimumTimeBeforeChargedSec"]))?(int)0:(System.Int32?)row["MinimumTimeBeforeChargedSec"];
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
		/// Fill an <see cref="VList&lt;Vw_AccessType_ProductRates&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_AccessType_ProductRates&gt;"/></returns>
		protected VList<Vw_AccessType_ProductRates> Fill(IDataReader reader, VList<Vw_AccessType_ProductRates> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_AccessType_ProductRates entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_AccessType_ProductRates>("Vw_AccessType_ProductRates",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_AccessType_ProductRates();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductRateName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateName)];
					//entity.ProductRateName = (Convert.IsDBNull(reader["ProductRateName"]))?string.Empty:(System.String)reader["ProductRateName"];
					entity.ProductId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductDefaultOption = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductDefaultOption)))?null:(System.Boolean?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductDefaultOption)];
					//entity.ProductDefaultOption = (Convert.IsDBNull(reader["ProductDefaultOption"]))?false:(System.Boolean?)reader["ProductDefaultOption"];
					entity.ProductTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeId)];
					//entity.ProductTypeId = (Convert.IsDBNull(reader["ProductTypeID"]))?(int)0:(System.Int32)reader["ProductTypeID"];
					entity.ProductRateTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeId)];
					//entity.ProductRateTypeId = (Convert.IsDBNull(reader["ProductRateTypeID"]))?(int)0:(System.Int32)reader["ProductRateTypeID"];
					entity.ProductTypeName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeName)];
					//entity.ProductTypeName = (Convert.IsDBNull(reader["ProductTypeName"]))?string.Empty:(System.String)reader["ProductTypeName"];
					entity.ProductRateTypeName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeName)];
					//entity.ProductRateTypeName = (Convert.IsDBNull(reader["ProductRateTypeName"]))?string.Empty:(System.String)reader["ProductRateTypeName"];
					entity.ProductDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductDisplayOrder)];
					//entity.ProductDisplayOrder = (Convert.IsDBNull(reader["ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductDisplayOrder"];
					entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayName)];
					//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
					entity.ProductRateDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayOrder)];
					//entity.ProductRateDisplayOrder = (Convert.IsDBNull(reader["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateDisplayOrder"];
					entity.ProductTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayName)];
					//entity.ProductTypeDisplayName = (Convert.IsDBNull(reader["ProductTypeDisplayName"]))?string.Empty:(System.String)reader["ProductTypeDisplayName"];
					entity.ProductTypeDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayOrder)];
					//entity.ProductTypeDisplayOrder = (Convert.IsDBNull(reader["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductTypeDisplayOrder"];
					entity.ProductRateTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayName)];
					//entity.ProductRateTypeDisplayName = (Convert.IsDBNull(reader["ProductRateTypeDisplayName"]))?string.Empty:(System.String)reader["ProductRateTypeDisplayName"];
					entity.ProductRateTypeDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayOrder)];
					//entity.ProductRateTypeDisplayOrder = (Convert.IsDBNull(reader["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateTypeDisplayOrder"];
					entity.DdlDescription = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.DdlDescription)];
					//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
					entity.ProductRateDescription = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDescription)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDescription)];
					//entity.ProductRateDescription = (Convert.IsDBNull(reader["ProductRateDescription"]))?string.Empty:(System.String)reader["ProductRateDescription"];
					entity.RatingTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.RatingTypeId)];
					//entity.RatingTypeId = (Convert.IsDBNull(reader["RatingTypeID"]))?(int)0:(System.Int32)reader["RatingTypeID"];
					entity.RatingTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.RatingTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.RatingTypeDisplayName)];
					//entity.RatingTypeDisplayName = (Convert.IsDBNull(reader["RatingTypeDisplayName"]))?string.Empty:(System.String)reader["RatingTypeDisplayName"];
					entity.AccessTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeId)];
					//entity.AccessTypeId = (Convert.IsDBNull(reader["AccessTypeID"]))?(int)0:(System.Int32)reader["AccessTypeID"];
					entity.ProductRateId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateId)];
					//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32)reader["ProductRateID"];
					entity.AccessTypeName = (System.String)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeName)];
					//entity.AccessTypeName = (Convert.IsDBNull(reader["AccessTypeName"]))?string.Empty:(System.String)reader["AccessTypeName"];
					entity.AccessTypeDisplayName = (System.String)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeDisplayName)];
					//entity.AccessTypeDisplayName = (Convert.IsDBNull(reader["AccessTypeDisplayName"]))?string.Empty:(System.String)reader["AccessTypeDisplayName"];
					entity.AccessTypeValue = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeValue)];
					//entity.AccessTypeValue = (Convert.IsDBNull(reader["AccessTypeValue"]))?(int)0:(System.Int32)reader["AccessTypeValue"];
					entity.AccessTypeBillable = (System.Boolean)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeBillable)];
					//entity.AccessTypeBillable = (Convert.IsDBNull(reader["AccessTypeBillable"]))?false:(System.Boolean)reader["AccessTypeBillable"];
					entity.AccessTypeEnabled = (System.Boolean)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeEnabled)];
					//entity.AccessTypeEnabled = (Convert.IsDBNull(reader["AccessTypeEnabled"]))?false:(System.Boolean)reader["AccessTypeEnabled"];
					entity.AccessType_ProductRateId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessType_ProductRateId)];
					//entity.AccessType_ProductRateId = (Convert.IsDBNull(reader["AccessType_ProductRateID"]))?(int)0:(System.Int32)reader["AccessType_ProductRateID"];
					entity.ProductRateIntervalId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateIntervalId)];
					//entity.ProductRateIntervalId = (Convert.IsDBNull(reader["ProductRateIntervalID"]))?(int)0:(System.Int32)reader["ProductRateIntervalID"];
					entity.ProductRateTaxableId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTaxableId)];
					//entity.ProductRateTaxableId = (Convert.IsDBNull(reader["ProductRateTaxableID"]))?(int)0:(System.Int32)reader["ProductRateTaxableID"];
					entity.ProductRateCountryId = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateCountryId)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateCountryId)];
					//entity.ProductRateCountryId = (Convert.IsDBNull(reader["ProductRateCountryID"]))?string.Empty:(System.String)reader["ProductRateCountryID"];
					entity.MinimumTimeBeforeChargedSec = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.MinimumTimeBeforeChargedSec)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.MinimumTimeBeforeChargedSec)];
					//entity.MinimumTimeBeforeChargedSec = (Convert.IsDBNull(reader["MinimumTimeBeforeChargedSec"]))?(int)0:(System.Int32?)reader["MinimumTimeBeforeChargedSec"];
					entity.DdlDescription2 = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.DdlDescription2)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.DdlDescription2)];
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
		/// Refreshes the <see cref="Vw_AccessType_ProductRates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_AccessType_ProductRates"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_AccessType_ProductRates entity)
		{
			reader.Read();
			entity.ProductRateName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateName)];
			//entity.ProductRateName = (Convert.IsDBNull(reader["ProductRateName"]))?string.Empty:(System.String)reader["ProductRateName"];
			entity.ProductId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductDefaultOption = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductDefaultOption)))?null:(System.Boolean?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductDefaultOption)];
			//entity.ProductDefaultOption = (Convert.IsDBNull(reader["ProductDefaultOption"]))?false:(System.Boolean?)reader["ProductDefaultOption"];
			entity.ProductTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeId)];
			//entity.ProductTypeId = (Convert.IsDBNull(reader["ProductTypeID"]))?(int)0:(System.Int32)reader["ProductTypeID"];
			entity.ProductRateTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeId)];
			//entity.ProductRateTypeId = (Convert.IsDBNull(reader["ProductRateTypeID"]))?(int)0:(System.Int32)reader["ProductRateTypeID"];
			entity.ProductTypeName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeName)];
			//entity.ProductTypeName = (Convert.IsDBNull(reader["ProductTypeName"]))?string.Empty:(System.String)reader["ProductTypeName"];
			entity.ProductRateTypeName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeName)];
			//entity.ProductRateTypeName = (Convert.IsDBNull(reader["ProductRateTypeName"]))?string.Empty:(System.String)reader["ProductRateTypeName"];
			entity.ProductDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductDisplayOrder)];
			//entity.ProductDisplayOrder = (Convert.IsDBNull(reader["ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductDisplayOrder"];
			entity.ProductRateDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayName)];
			//entity.ProductRateDisplayName = (Convert.IsDBNull(reader["ProductRateDisplayName"]))?string.Empty:(System.String)reader["ProductRateDisplayName"];
			entity.ProductRateDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDisplayOrder)];
			//entity.ProductRateDisplayOrder = (Convert.IsDBNull(reader["ProductRateDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateDisplayOrder"];
			entity.ProductTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayName)];
			//entity.ProductTypeDisplayName = (Convert.IsDBNull(reader["ProductTypeDisplayName"]))?string.Empty:(System.String)reader["ProductTypeDisplayName"];
			entity.ProductTypeDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductTypeDisplayOrder)];
			//entity.ProductTypeDisplayOrder = (Convert.IsDBNull(reader["ProductTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductTypeDisplayOrder"];
			entity.ProductRateTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayName)];
			//entity.ProductRateTypeDisplayName = (Convert.IsDBNull(reader["ProductRateTypeDisplayName"]))?string.Empty:(System.String)reader["ProductRateTypeDisplayName"];
			entity.ProductRateTypeDisplayOrder = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTypeDisplayOrder)];
			//entity.ProductRateTypeDisplayOrder = (Convert.IsDBNull(reader["ProductRateTypeDisplayOrder"]))?(int)0:(System.Int32?)reader["ProductRateTypeDisplayOrder"];
			entity.DdlDescription = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.DdlDescription)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.DdlDescription)];
			//entity.DdlDescription = (Convert.IsDBNull(reader["DDLDescription"]))?string.Empty:(System.String)reader["DDLDescription"];
			entity.ProductRateDescription = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateDescription)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateDescription)];
			//entity.ProductRateDescription = (Convert.IsDBNull(reader["ProductRateDescription"]))?string.Empty:(System.String)reader["ProductRateDescription"];
			entity.RatingTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.RatingTypeId)];
			//entity.RatingTypeId = (Convert.IsDBNull(reader["RatingTypeID"]))?(int)0:(System.Int32)reader["RatingTypeID"];
			entity.RatingTypeDisplayName = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.RatingTypeDisplayName)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.RatingTypeDisplayName)];
			//entity.RatingTypeDisplayName = (Convert.IsDBNull(reader["RatingTypeDisplayName"]))?string.Empty:(System.String)reader["RatingTypeDisplayName"];
			entity.AccessTypeId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeId)];
			//entity.AccessTypeId = (Convert.IsDBNull(reader["AccessTypeID"]))?(int)0:(System.Int32)reader["AccessTypeID"];
			entity.ProductRateId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateId)];
			//entity.ProductRateId = (Convert.IsDBNull(reader["ProductRateID"]))?(int)0:(System.Int32)reader["ProductRateID"];
			entity.AccessTypeName = (System.String)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeName)];
			//entity.AccessTypeName = (Convert.IsDBNull(reader["AccessTypeName"]))?string.Empty:(System.String)reader["AccessTypeName"];
			entity.AccessTypeDisplayName = (System.String)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeDisplayName)];
			//entity.AccessTypeDisplayName = (Convert.IsDBNull(reader["AccessTypeDisplayName"]))?string.Empty:(System.String)reader["AccessTypeDisplayName"];
			entity.AccessTypeValue = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeValue)];
			//entity.AccessTypeValue = (Convert.IsDBNull(reader["AccessTypeValue"]))?(int)0:(System.Int32)reader["AccessTypeValue"];
			entity.AccessTypeBillable = (System.Boolean)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeBillable)];
			//entity.AccessTypeBillable = (Convert.IsDBNull(reader["AccessTypeBillable"]))?false:(System.Boolean)reader["AccessTypeBillable"];
			entity.AccessTypeEnabled = (System.Boolean)reader[((int)Vw_AccessType_ProductRatesColumn.AccessTypeEnabled)];
			//entity.AccessTypeEnabled = (Convert.IsDBNull(reader["AccessTypeEnabled"]))?false:(System.Boolean)reader["AccessTypeEnabled"];
			entity.AccessType_ProductRateId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.AccessType_ProductRateId)];
			//entity.AccessType_ProductRateId = (Convert.IsDBNull(reader["AccessType_ProductRateID"]))?(int)0:(System.Int32)reader["AccessType_ProductRateID"];
			entity.ProductRateIntervalId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateIntervalId)];
			//entity.ProductRateIntervalId = (Convert.IsDBNull(reader["ProductRateIntervalID"]))?(int)0:(System.Int32)reader["ProductRateIntervalID"];
			entity.ProductRateTaxableId = (System.Int32)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateTaxableId)];
			//entity.ProductRateTaxableId = (Convert.IsDBNull(reader["ProductRateTaxableID"]))?(int)0:(System.Int32)reader["ProductRateTaxableID"];
			entity.ProductRateCountryId = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.ProductRateCountryId)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.ProductRateCountryId)];
			//entity.ProductRateCountryId = (Convert.IsDBNull(reader["ProductRateCountryID"]))?string.Empty:(System.String)reader["ProductRateCountryID"];
			entity.MinimumTimeBeforeChargedSec = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.MinimumTimeBeforeChargedSec)))?null:(System.Int32?)reader[((int)Vw_AccessType_ProductRatesColumn.MinimumTimeBeforeChargedSec)];
			//entity.MinimumTimeBeforeChargedSec = (Convert.IsDBNull(reader["MinimumTimeBeforeChargedSec"]))?(int)0:(System.Int32?)reader["MinimumTimeBeforeChargedSec"];
			entity.DdlDescription2 = (reader.IsDBNull(((int)Vw_AccessType_ProductRatesColumn.DdlDescription2)))?null:(System.String)reader[((int)Vw_AccessType_ProductRatesColumn.DdlDescription2)];
			//entity.DdlDescription2 = (Convert.IsDBNull(reader["DDLDescription2"]))?string.Empty:(System.String)reader["DDLDescription2"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_AccessType_ProductRates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_AccessType_ProductRates"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_AccessType_ProductRates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
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
			entity.ProductRateDescription = (Convert.IsDBNull(dataRow["ProductRateDescription"]))?string.Empty:(System.String)dataRow["ProductRateDescription"];
			entity.RatingTypeId = (Convert.IsDBNull(dataRow["RatingTypeID"]))?(int)0:(System.Int32)dataRow["RatingTypeID"];
			entity.RatingTypeDisplayName = (Convert.IsDBNull(dataRow["RatingTypeDisplayName"]))?string.Empty:(System.String)dataRow["RatingTypeDisplayName"];
			entity.AccessTypeId = (Convert.IsDBNull(dataRow["AccessTypeID"]))?(int)0:(System.Int32)dataRow["AccessTypeID"];
			entity.ProductRateId = (Convert.IsDBNull(dataRow["ProductRateID"]))?(int)0:(System.Int32)dataRow["ProductRateID"];
			entity.AccessTypeName = (Convert.IsDBNull(dataRow["AccessTypeName"]))?string.Empty:(System.String)dataRow["AccessTypeName"];
			entity.AccessTypeDisplayName = (Convert.IsDBNull(dataRow["AccessTypeDisplayName"]))?string.Empty:(System.String)dataRow["AccessTypeDisplayName"];
			entity.AccessTypeValue = (Convert.IsDBNull(dataRow["AccessTypeValue"]))?(int)0:(System.Int32)dataRow["AccessTypeValue"];
			entity.AccessTypeBillable = (Convert.IsDBNull(dataRow["AccessTypeBillable"]))?false:(System.Boolean)dataRow["AccessTypeBillable"];
			entity.AccessTypeEnabled = (Convert.IsDBNull(dataRow["AccessTypeEnabled"]))?false:(System.Boolean)dataRow["AccessTypeEnabled"];
			entity.AccessType_ProductRateId = (Convert.IsDBNull(dataRow["AccessType_ProductRateID"]))?(int)0:(System.Int32)dataRow["AccessType_ProductRateID"];
			entity.ProductRateIntervalId = (Convert.IsDBNull(dataRow["ProductRateIntervalID"]))?(int)0:(System.Int32)dataRow["ProductRateIntervalID"];
			entity.ProductRateTaxableId = (Convert.IsDBNull(dataRow["ProductRateTaxableID"]))?(int)0:(System.Int32)dataRow["ProductRateTaxableID"];
			entity.ProductRateCountryId = (Convert.IsDBNull(dataRow["ProductRateCountryID"]))?string.Empty:(System.String)dataRow["ProductRateCountryID"];
			entity.MinimumTimeBeforeChargedSec = (Convert.IsDBNull(dataRow["MinimumTimeBeforeChargedSec"]))?(int)0:(System.Int32?)dataRow["MinimumTimeBeforeChargedSec"];
			entity.DdlDescription2 = (Convert.IsDBNull(dataRow["DDLDescription2"]))?string.Empty:(System.String)dataRow["DDLDescription2"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_AccessType_ProductRatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesFilterBuilder : SqlFilterBuilder<Vw_AccessType_ProductRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilterBuilder class.
		/// </summary>
		public Vw_AccessType_ProductRatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_AccessType_ProductRatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_AccessType_ProductRatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_AccessType_ProductRatesFilterBuilder

	#region Vw_AccessType_ProductRatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_AccessType_ProductRates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_AccessType_ProductRatesParameterBuilder : ParameterizedSqlFilterBuilder<Vw_AccessType_ProductRatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesParameterBuilder class.
		/// </summary>
		public Vw_AccessType_ProductRatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_AccessType_ProductRatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_AccessType_ProductRatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_AccessType_ProductRatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_AccessType_ProductRatesParameterBuilder
} // end namespace
