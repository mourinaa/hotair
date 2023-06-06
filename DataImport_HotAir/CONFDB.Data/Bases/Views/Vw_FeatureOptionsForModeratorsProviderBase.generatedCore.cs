﻿#region Using directives

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
	/// This class is the base class for any <see cref="Vw_FeatureOptionsForModeratorsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_FeatureOptionsForModeratorsProviderBaseCore : EntityViewProviderBase<Vw_FeatureOptionsForModerators>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_FeatureOptionsForModerators&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_FeatureOptionsForModerators&gt;"/></returns>
		protected static VList&lt;Vw_FeatureOptionsForModerators&gt; Fill(DataSet dataSet, VList<Vw_FeatureOptionsForModerators> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_FeatureOptionsForModerators>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_FeatureOptionsForModerators&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_FeatureOptionsForModerators>"/></returns>
		protected static VList&lt;Vw_FeatureOptionsForModerators&gt; Fill(DataTable dataTable, VList<Vw_FeatureOptionsForModerators> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_FeatureOptionsForModerators c = new Vw_FeatureOptionsForModerators();
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32)row["ModeratorID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.PriCustomerNumber = (Convert.IsDBNull(row["PriCustomerNumber"]))?string.Empty:(System.String)row["PriCustomerNumber"];
					c.SecCustomerNumber = (Convert.IsDBNull(row["SecCustomerNumber"]))?string.Empty:(System.String)row["SecCustomerNumber"];
					c.ExternalModeratorNumber = (Convert.IsDBNull(row["ExternalModeratorNumber"]))?string.Empty:(System.String)row["ExternalModeratorNumber"];
					c.Moderator_FeatureId = (Convert.IsDBNull(row["Moderator_FeatureID"]))?(int)0:(System.Int32)row["Moderator_FeatureID"];
					c.Moderator_FeatureFeatureId = (Convert.IsDBNull(row["Moderator_FeatureFeatureID"]))?(int)0:(System.Int32)row["Moderator_FeatureFeatureID"];
					c.Moderator_FeatureFeatureOptionId = (Convert.IsDBNull(row["Moderator_FeatureFeatureOptionID"]))?(int)0:(System.Int32)row["Moderator_FeatureFeatureOptionID"];
					c.Moderator_FeatureEnabled = (Convert.IsDBNull(row["Moderator_FeatureEnabled"]))?false:(System.Boolean)row["Moderator_FeatureEnabled"];
					c.Moderator_FeatureFeatureOptionValue = (Convert.IsDBNull(row["Moderator_FeatureFeatureOptionValue"]))?string.Empty:(System.String)row["Moderator_FeatureFeatureOptionValue"];
					c.FeatureId = (Convert.IsDBNull(row["FeatureID"]))?(int)0:(System.Int32)row["FeatureID"];
					c.FeatureProductId = (Convert.IsDBNull(row["FeatureProductID"]))?(int)0:(System.Int32)row["FeatureProductID"];
					c.FeatureName = (Convert.IsDBNull(row["FeatureName"]))?string.Empty:(System.String)row["FeatureName"];
					c.FeatureDisplayName = (Convert.IsDBNull(row["FeatureDisplayName"]))?string.Empty:(System.String)row["FeatureDisplayName"];
					c.FeatureDescription = (Convert.IsDBNull(row["FeatureDescription"]))?string.Empty:(System.String)row["FeatureDescription"];
					c.FeatureDisplayNameAlt = (Convert.IsDBNull(row["FeatureDisplayNameAlt"]))?string.Empty:(System.String)row["FeatureDisplayNameAlt"];
					c.FeatureDescriptionAlt = (Convert.IsDBNull(row["FeatureDescriptionAlt"]))?string.Empty:(System.String)row["FeatureDescriptionAlt"];
					c.FeatureDefaultOption = (Convert.IsDBNull(row["FeatureDefaultOption"]))?false:(System.Boolean)row["FeatureDefaultOption"];
					c.FeatureEnabled = (Convert.IsDBNull(row["FeatureEnabled"]))?false:(System.Boolean)row["FeatureEnabled"];
					c.FeatureDisplayOrder = (Convert.IsDBNull(row["FeatureDisplayOrder"]))?(int)0:(System.Int32)row["FeatureDisplayOrder"];
					c.FeatureDisplayOnlyToCustomer = (Convert.IsDBNull(row["FeatureDisplayOnlyToCustomer"]))?false:(System.Boolean)row["FeatureDisplayOnlyToCustomer"];
					c.FeatureDisplayInAmpSite = (Convert.IsDBNull(row["FeatureDisplayInAMPSite"]))?false:(System.Boolean)row["FeatureDisplayInAMPSite"];
					c.FeatureDisplayToCustomer = (Convert.IsDBNull(row["FeatureDisplayToCustomer"]))?false:(System.Boolean)row["FeatureDisplayToCustomer"];
					c.FeatureDisplayToModerator = (Convert.IsDBNull(row["FeatureDisplayToModerator"]))?false:(System.Boolean)row["FeatureDisplayToModerator"];
					c.FeatureOptionId = (Convert.IsDBNull(row["FeatureOptionID"]))?(int)0:(System.Int32)row["FeatureOptionID"];
					c.FeatureOptionFeatureId = (Convert.IsDBNull(row["FeatureOptionFeatureID"]))?(int)0:(System.Int32)row["FeatureOptionFeatureID"];
					c.FeatureOptionName = (Convert.IsDBNull(row["FeatureOptionName"]))?string.Empty:(System.String)row["FeatureOptionName"];
					c.FeatureOptionDisplayName = (Convert.IsDBNull(row["FeatureOptionDisplayName"]))?string.Empty:(System.String)row["FeatureOptionDisplayName"];
					c.FeatureOptionDescription = (Convert.IsDBNull(row["FeatureOptionDescription"]))?string.Empty:(System.String)row["FeatureOptionDescription"];
					c.FeatureOptionDisplayNameAlt = (Convert.IsDBNull(row["FeatureOptionDisplayNameAlt"]))?string.Empty:(System.String)row["FeatureOptionDisplayNameAlt"];
					c.FeatureOptionDescriptionAlt = (Convert.IsDBNull(row["FeatureOptionDescriptionAlt"]))?string.Empty:(System.String)row["FeatureOptionDescriptionAlt"];
					c.FeatureOptionValue = (Convert.IsDBNull(row["FeatureOptionValue"]))?string.Empty:(System.String)row["FeatureOptionValue"];
					c.FeatureOptionDisplayOrder = (Convert.IsDBNull(row["FeatureOptionDisplayOrder"]))?(int)0:(System.Int32)row["FeatureOptionDisplayOrder"];
					c.FeatureOptionDefaultOption = (Convert.IsDBNull(row["FeatureOptionDefaultOption"]))?false:(System.Boolean)row["FeatureOptionDefaultOption"];
					c.FeatureOptionEnabled = (Convert.IsDBNull(row["FeatureOptionEnabled"]))?false:(System.Boolean)row["FeatureOptionEnabled"];
					c.FeatureOptionFeatureOptionTypeId = (Convert.IsDBNull(row["FeatureOptionFeatureOptionTypeID"]))?(int)0:(System.Int32?)row["FeatureOptionFeatureOptionTypeID"];
					c.FeatureOptionRegularExpression = (Convert.IsDBNull(row["FeatureOptionRegularExpression"]))?string.Empty:(System.String)row["FeatureOptionRegularExpression"];
					c.FeatureOptionTypeId = (Convert.IsDBNull(row["FeatureOptionTypeID"]))?(int)0:(System.Int32?)row["FeatureOptionTypeID"];
					c.FeatureOptionTypeName = (Convert.IsDBNull(row["FeatureOptionTypeName"]))?string.Empty:(System.String)row["FeatureOptionTypeName"];
					c.FeatureOptionTypeDescription = (Convert.IsDBNull(row["FeatureOptionTypeDescription"]))?string.Empty:(System.String)row["FeatureOptionTypeDescription"];
					c.FeatureOptionTypeDisplayOrder = (Convert.IsDBNull(row["FeatureOptionTypeDisplayOrder"]))?(short)0:(System.Int16?)row["FeatureOptionTypeDisplayOrder"];
					c.Wholesaler_ProductProductId = (Convert.IsDBNull(row["Wholesaler_ProductProductID"]))?(int)0:(System.Int32)row["Wholesaler_ProductProductID"];
					c.Wholesaler_ProductName = (Convert.IsDBNull(row["Wholesaler_ProductName"]))?string.Empty:(System.String)row["Wholesaler_ProductName"];
					c.Wholesaler_ProductDescription = (Convert.IsDBNull(row["Wholesaler_ProductDescription"]))?string.Empty:(System.String)row["Wholesaler_ProductDescription"];
					c.Wholesaler_ProductDisplayNameAlt = (Convert.IsDBNull(row["Wholesaler_ProductDisplayNameAlt"]))?string.Empty:(System.String)row["Wholesaler_ProductDisplayNameAlt"];
					c.Wholesaler_ProductDescriptionAlt = (Convert.IsDBNull(row["Wholesaler_ProductDescriptionAlt"]))?string.Empty:(System.String)row["Wholesaler_ProductDescriptionAlt"];
					c.Wholesaler_ProductDisplayOrder = (Convert.IsDBNull(row["Wholesaler_ProductDisplayOrder"]))?(int)0:(System.Int32?)row["Wholesaler_ProductDisplayOrder"];
					c.Wholesaler_ProductEnabled = (Convert.IsDBNull(row["Wholesaler_ProductEnabled"]))?false:(System.Boolean?)row["Wholesaler_ProductEnabled"];
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
		/// Fill an <see cref="VList&lt;Vw_FeatureOptionsForModerators&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_FeatureOptionsForModerators&gt;"/></returns>
		protected VList<Vw_FeatureOptionsForModerators> Fill(IDataReader reader, VList<Vw_FeatureOptionsForModerators> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_FeatureOptionsForModerators entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_FeatureOptionsForModerators>("Vw_FeatureOptionsForModerators",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_FeatureOptionsForModerators();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ModeratorId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.CustomerId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.PriCustomerNumber = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.PriCustomerNumber)];
					//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
					entity.SecCustomerNumber = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.SecCustomerNumber)];
					//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
					entity.ExternalModeratorNumber = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.ExternalModeratorNumber)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.ExternalModeratorNumber)];
					//entity.ExternalModeratorNumber = (Convert.IsDBNull(reader["ExternalModeratorNumber"]))?string.Empty:(System.String)reader["ExternalModeratorNumber"];
					entity.Moderator_FeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureId)];
					//entity.Moderator_FeatureId = (Convert.IsDBNull(reader["Moderator_FeatureID"]))?(int)0:(System.Int32)reader["Moderator_FeatureID"];
					entity.Moderator_FeatureFeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureId)];
					//entity.Moderator_FeatureFeatureId = (Convert.IsDBNull(reader["Moderator_FeatureFeatureID"]))?(int)0:(System.Int32)reader["Moderator_FeatureFeatureID"];
					entity.Moderator_FeatureFeatureOptionId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionId)];
					//entity.Moderator_FeatureFeatureOptionId = (Convert.IsDBNull(reader["Moderator_FeatureFeatureOptionID"]))?(int)0:(System.Int32)reader["Moderator_FeatureFeatureOptionID"];
					entity.Moderator_FeatureEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureEnabled)];
					//entity.Moderator_FeatureEnabled = (Convert.IsDBNull(reader["Moderator_FeatureEnabled"]))?false:(System.Boolean)reader["Moderator_FeatureEnabled"];
					entity.Moderator_FeatureFeatureOptionValue = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionValue)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionValue)];
					//entity.Moderator_FeatureFeatureOptionValue = (Convert.IsDBNull(reader["Moderator_FeatureFeatureOptionValue"]))?string.Empty:(System.String)reader["Moderator_FeatureFeatureOptionValue"];
					entity.FeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureId)];
					//entity.FeatureId = (Convert.IsDBNull(reader["FeatureID"]))?(int)0:(System.Int32)reader["FeatureID"];
					entity.FeatureProductId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureProductId)];
					//entity.FeatureProductId = (Convert.IsDBNull(reader["FeatureProductID"]))?(int)0:(System.Int32)reader["FeatureProductID"];
					entity.FeatureName = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureName)];
					//entity.FeatureName = (Convert.IsDBNull(reader["FeatureName"]))?string.Empty:(System.String)reader["FeatureName"];
					entity.FeatureDisplayName = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayName)];
					//entity.FeatureDisplayName = (Convert.IsDBNull(reader["FeatureDisplayName"]))?string.Empty:(System.String)reader["FeatureDisplayName"];
					entity.FeatureDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescription)];
					//entity.FeatureDescription = (Convert.IsDBNull(reader["FeatureDescription"]))?string.Empty:(System.String)reader["FeatureDescription"];
					entity.FeatureDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayNameAlt)];
					//entity.FeatureDisplayNameAlt = (Convert.IsDBNull(reader["FeatureDisplayNameAlt"]))?string.Empty:(System.String)reader["FeatureDisplayNameAlt"];
					entity.FeatureDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescriptionAlt)];
					//entity.FeatureDescriptionAlt = (Convert.IsDBNull(reader["FeatureDescriptionAlt"]))?string.Empty:(System.String)reader["FeatureDescriptionAlt"];
					entity.FeatureDefaultOption = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDefaultOption)];
					//entity.FeatureDefaultOption = (Convert.IsDBNull(reader["FeatureDefaultOption"]))?false:(System.Boolean)reader["FeatureDefaultOption"];
					entity.FeatureEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureEnabled)];
					//entity.FeatureEnabled = (Convert.IsDBNull(reader["FeatureEnabled"]))?false:(System.Boolean)reader["FeatureEnabled"];
					entity.FeatureDisplayOrder = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayOrder)];
					//entity.FeatureDisplayOrder = (Convert.IsDBNull(reader["FeatureDisplayOrder"]))?(int)0:(System.Int32)reader["FeatureDisplayOrder"];
					entity.FeatureDisplayOnlyToCustomer = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayOnlyToCustomer)];
					//entity.FeatureDisplayOnlyToCustomer = (Convert.IsDBNull(reader["FeatureDisplayOnlyToCustomer"]))?false:(System.Boolean)reader["FeatureDisplayOnlyToCustomer"];
					entity.FeatureDisplayInAmpSite = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayInAmpSite)];
					//entity.FeatureDisplayInAmpSite = (Convert.IsDBNull(reader["FeatureDisplayInAMPSite"]))?false:(System.Boolean)reader["FeatureDisplayInAMPSite"];
					entity.FeatureDisplayToCustomer = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayToCustomer)];
					//entity.FeatureDisplayToCustomer = (Convert.IsDBNull(reader["FeatureDisplayToCustomer"]))?false:(System.Boolean)reader["FeatureDisplayToCustomer"];
					entity.FeatureDisplayToModerator = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayToModerator)];
					//entity.FeatureDisplayToModerator = (Convert.IsDBNull(reader["FeatureDisplayToModerator"]))?false:(System.Boolean)reader["FeatureDisplayToModerator"];
					entity.FeatureOptionId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionId)];
					//entity.FeatureOptionId = (Convert.IsDBNull(reader["FeatureOptionID"]))?(int)0:(System.Int32)reader["FeatureOptionID"];
					entity.FeatureOptionFeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureId)];
					//entity.FeatureOptionFeatureId = (Convert.IsDBNull(reader["FeatureOptionFeatureID"]))?(int)0:(System.Int32)reader["FeatureOptionFeatureID"];
					entity.FeatureOptionName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionName)];
					//entity.FeatureOptionName = (Convert.IsDBNull(reader["FeatureOptionName"]))?string.Empty:(System.String)reader["FeatureOptionName"];
					entity.FeatureOptionDisplayName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayName)];
					//entity.FeatureOptionDisplayName = (Convert.IsDBNull(reader["FeatureOptionDisplayName"]))?string.Empty:(System.String)reader["FeatureOptionDisplayName"];
					entity.FeatureOptionDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescription)];
					//entity.FeatureOptionDescription = (Convert.IsDBNull(reader["FeatureOptionDescription"]))?string.Empty:(System.String)reader["FeatureOptionDescription"];
					entity.FeatureOptionDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayNameAlt)];
					//entity.FeatureOptionDisplayNameAlt = (Convert.IsDBNull(reader["FeatureOptionDisplayNameAlt"]))?string.Empty:(System.String)reader["FeatureOptionDisplayNameAlt"];
					entity.FeatureOptionDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescriptionAlt)];
					//entity.FeatureOptionDescriptionAlt = (Convert.IsDBNull(reader["FeatureOptionDescriptionAlt"]))?string.Empty:(System.String)reader["FeatureOptionDescriptionAlt"];
					entity.FeatureOptionValue = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionValue)];
					//entity.FeatureOptionValue = (Convert.IsDBNull(reader["FeatureOptionValue"]))?string.Empty:(System.String)reader["FeatureOptionValue"];
					entity.FeatureOptionDisplayOrder = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayOrder)];
					//entity.FeatureOptionDisplayOrder = (Convert.IsDBNull(reader["FeatureOptionDisplayOrder"]))?(int)0:(System.Int32)reader["FeatureOptionDisplayOrder"];
					entity.FeatureOptionDefaultOption = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDefaultOption)];
					//entity.FeatureOptionDefaultOption = (Convert.IsDBNull(reader["FeatureOptionDefaultOption"]))?false:(System.Boolean)reader["FeatureOptionDefaultOption"];
					entity.FeatureOptionEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionEnabled)];
					//entity.FeatureOptionEnabled = (Convert.IsDBNull(reader["FeatureOptionEnabled"]))?false:(System.Boolean)reader["FeatureOptionEnabled"];
					entity.FeatureOptionFeatureOptionTypeId = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureOptionTypeId)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureOptionTypeId)];
					//entity.FeatureOptionFeatureOptionTypeId = (Convert.IsDBNull(reader["FeatureOptionFeatureOptionTypeID"]))?(int)0:(System.Int32?)reader["FeatureOptionFeatureOptionTypeID"];
					entity.FeatureOptionRegularExpression = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionRegularExpression)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionRegularExpression)];
					//entity.FeatureOptionRegularExpression = (Convert.IsDBNull(reader["FeatureOptionRegularExpression"]))?string.Empty:(System.String)reader["FeatureOptionRegularExpression"];
					entity.FeatureOptionTypeId = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeId)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeId)];
					//entity.FeatureOptionTypeId = (Convert.IsDBNull(reader["FeatureOptionTypeID"]))?(int)0:(System.Int32?)reader["FeatureOptionTypeID"];
					entity.FeatureOptionTypeName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeName)];
					//entity.FeatureOptionTypeName = (Convert.IsDBNull(reader["FeatureOptionTypeName"]))?string.Empty:(System.String)reader["FeatureOptionTypeName"];
					entity.FeatureOptionTypeDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDescription)];
					//entity.FeatureOptionTypeDescription = (Convert.IsDBNull(reader["FeatureOptionTypeDescription"]))?string.Empty:(System.String)reader["FeatureOptionTypeDescription"];
					entity.FeatureOptionTypeDisplayOrder = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDisplayOrder)))?null:(System.Int16?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDisplayOrder)];
					//entity.FeatureOptionTypeDisplayOrder = (Convert.IsDBNull(reader["FeatureOptionTypeDisplayOrder"]))?(short)0:(System.Int16?)reader["FeatureOptionTypeDisplayOrder"];
					entity.Wholesaler_ProductProductId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductProductId)];
					//entity.Wholesaler_ProductProductId = (Convert.IsDBNull(reader["Wholesaler_ProductProductID"]))?(int)0:(System.Int32)reader["Wholesaler_ProductProductID"];
					entity.Wholesaler_ProductName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductName)];
					//entity.Wholesaler_ProductName = (Convert.IsDBNull(reader["Wholesaler_ProductName"]))?string.Empty:(System.String)reader["Wholesaler_ProductName"];
					entity.Wholesaler_ProductDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescription)];
					//entity.Wholesaler_ProductDescription = (Convert.IsDBNull(reader["Wholesaler_ProductDescription"]))?string.Empty:(System.String)reader["Wholesaler_ProductDescription"];
					entity.Wholesaler_ProductDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayNameAlt)];
					//entity.Wholesaler_ProductDisplayNameAlt = (Convert.IsDBNull(reader["Wholesaler_ProductDisplayNameAlt"]))?string.Empty:(System.String)reader["Wholesaler_ProductDisplayNameAlt"];
					entity.Wholesaler_ProductDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescriptionAlt)];
					//entity.Wholesaler_ProductDescriptionAlt = (Convert.IsDBNull(reader["Wholesaler_ProductDescriptionAlt"]))?string.Empty:(System.String)reader["Wholesaler_ProductDescriptionAlt"];
					entity.Wholesaler_ProductDisplayOrder = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayOrder)];
					//entity.Wholesaler_ProductDisplayOrder = (Convert.IsDBNull(reader["Wholesaler_ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["Wholesaler_ProductDisplayOrder"];
					entity.Wholesaler_ProductEnabled = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductEnabled)))?null:(System.Boolean?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductEnabled)];
					//entity.Wholesaler_ProductEnabled = (Convert.IsDBNull(reader["Wholesaler_ProductEnabled"]))?false:(System.Boolean?)reader["Wholesaler_ProductEnabled"];
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
		/// Refreshes the <see cref="Vw_FeatureOptionsForModerators"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_FeatureOptionsForModerators"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_FeatureOptionsForModerators entity)
		{
			reader.Read();
			entity.ModeratorId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.CustomerId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.PriCustomerNumber = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.PriCustomerNumber)];
			//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
			entity.SecCustomerNumber = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.SecCustomerNumber)];
			//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
			entity.ExternalModeratorNumber = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.ExternalModeratorNumber)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.ExternalModeratorNumber)];
			//entity.ExternalModeratorNumber = (Convert.IsDBNull(reader["ExternalModeratorNumber"]))?string.Empty:(System.String)reader["ExternalModeratorNumber"];
			entity.Moderator_FeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureId)];
			//entity.Moderator_FeatureId = (Convert.IsDBNull(reader["Moderator_FeatureID"]))?(int)0:(System.Int32)reader["Moderator_FeatureID"];
			entity.Moderator_FeatureFeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureId)];
			//entity.Moderator_FeatureFeatureId = (Convert.IsDBNull(reader["Moderator_FeatureFeatureID"]))?(int)0:(System.Int32)reader["Moderator_FeatureFeatureID"];
			entity.Moderator_FeatureFeatureOptionId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionId)];
			//entity.Moderator_FeatureFeatureOptionId = (Convert.IsDBNull(reader["Moderator_FeatureFeatureOptionID"]))?(int)0:(System.Int32)reader["Moderator_FeatureFeatureOptionID"];
			entity.Moderator_FeatureEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureEnabled)];
			//entity.Moderator_FeatureEnabled = (Convert.IsDBNull(reader["Moderator_FeatureEnabled"]))?false:(System.Boolean)reader["Moderator_FeatureEnabled"];
			entity.Moderator_FeatureFeatureOptionValue = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionValue)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Moderator_FeatureFeatureOptionValue)];
			//entity.Moderator_FeatureFeatureOptionValue = (Convert.IsDBNull(reader["Moderator_FeatureFeatureOptionValue"]))?string.Empty:(System.String)reader["Moderator_FeatureFeatureOptionValue"];
			entity.FeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureId)];
			//entity.FeatureId = (Convert.IsDBNull(reader["FeatureID"]))?(int)0:(System.Int32)reader["FeatureID"];
			entity.FeatureProductId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureProductId)];
			//entity.FeatureProductId = (Convert.IsDBNull(reader["FeatureProductID"]))?(int)0:(System.Int32)reader["FeatureProductID"];
			entity.FeatureName = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureName)];
			//entity.FeatureName = (Convert.IsDBNull(reader["FeatureName"]))?string.Empty:(System.String)reader["FeatureName"];
			entity.FeatureDisplayName = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayName)];
			//entity.FeatureDisplayName = (Convert.IsDBNull(reader["FeatureDisplayName"]))?string.Empty:(System.String)reader["FeatureDisplayName"];
			entity.FeatureDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescription)];
			//entity.FeatureDescription = (Convert.IsDBNull(reader["FeatureDescription"]))?string.Empty:(System.String)reader["FeatureDescription"];
			entity.FeatureDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayNameAlt)];
			//entity.FeatureDisplayNameAlt = (Convert.IsDBNull(reader["FeatureDisplayNameAlt"]))?string.Empty:(System.String)reader["FeatureDisplayNameAlt"];
			entity.FeatureDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDescriptionAlt)];
			//entity.FeatureDescriptionAlt = (Convert.IsDBNull(reader["FeatureDescriptionAlt"]))?string.Empty:(System.String)reader["FeatureDescriptionAlt"];
			entity.FeatureDefaultOption = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDefaultOption)];
			//entity.FeatureDefaultOption = (Convert.IsDBNull(reader["FeatureDefaultOption"]))?false:(System.Boolean)reader["FeatureDefaultOption"];
			entity.FeatureEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureEnabled)];
			//entity.FeatureEnabled = (Convert.IsDBNull(reader["FeatureEnabled"]))?false:(System.Boolean)reader["FeatureEnabled"];
			entity.FeatureDisplayOrder = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayOrder)];
			//entity.FeatureDisplayOrder = (Convert.IsDBNull(reader["FeatureDisplayOrder"]))?(int)0:(System.Int32)reader["FeatureDisplayOrder"];
			entity.FeatureDisplayOnlyToCustomer = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayOnlyToCustomer)];
			//entity.FeatureDisplayOnlyToCustomer = (Convert.IsDBNull(reader["FeatureDisplayOnlyToCustomer"]))?false:(System.Boolean)reader["FeatureDisplayOnlyToCustomer"];
			entity.FeatureDisplayInAmpSite = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayInAmpSite)];
			//entity.FeatureDisplayInAmpSite = (Convert.IsDBNull(reader["FeatureDisplayInAMPSite"]))?false:(System.Boolean)reader["FeatureDisplayInAMPSite"];
			entity.FeatureDisplayToCustomer = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayToCustomer)];
			//entity.FeatureDisplayToCustomer = (Convert.IsDBNull(reader["FeatureDisplayToCustomer"]))?false:(System.Boolean)reader["FeatureDisplayToCustomer"];
			entity.FeatureDisplayToModerator = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureDisplayToModerator)];
			//entity.FeatureDisplayToModerator = (Convert.IsDBNull(reader["FeatureDisplayToModerator"]))?false:(System.Boolean)reader["FeatureDisplayToModerator"];
			entity.FeatureOptionId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionId)];
			//entity.FeatureOptionId = (Convert.IsDBNull(reader["FeatureOptionID"]))?(int)0:(System.Int32)reader["FeatureOptionID"];
			entity.FeatureOptionFeatureId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureId)];
			//entity.FeatureOptionFeatureId = (Convert.IsDBNull(reader["FeatureOptionFeatureID"]))?(int)0:(System.Int32)reader["FeatureOptionFeatureID"];
			entity.FeatureOptionName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionName)];
			//entity.FeatureOptionName = (Convert.IsDBNull(reader["FeatureOptionName"]))?string.Empty:(System.String)reader["FeatureOptionName"];
			entity.FeatureOptionDisplayName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayName)];
			//entity.FeatureOptionDisplayName = (Convert.IsDBNull(reader["FeatureOptionDisplayName"]))?string.Empty:(System.String)reader["FeatureOptionDisplayName"];
			entity.FeatureOptionDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescription)];
			//entity.FeatureOptionDescription = (Convert.IsDBNull(reader["FeatureOptionDescription"]))?string.Empty:(System.String)reader["FeatureOptionDescription"];
			entity.FeatureOptionDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayNameAlt)];
			//entity.FeatureOptionDisplayNameAlt = (Convert.IsDBNull(reader["FeatureOptionDisplayNameAlt"]))?string.Empty:(System.String)reader["FeatureOptionDisplayNameAlt"];
			entity.FeatureOptionDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDescriptionAlt)];
			//entity.FeatureOptionDescriptionAlt = (Convert.IsDBNull(reader["FeatureOptionDescriptionAlt"]))?string.Empty:(System.String)reader["FeatureOptionDescriptionAlt"];
			entity.FeatureOptionValue = (System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionValue)];
			//entity.FeatureOptionValue = (Convert.IsDBNull(reader["FeatureOptionValue"]))?string.Empty:(System.String)reader["FeatureOptionValue"];
			entity.FeatureOptionDisplayOrder = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDisplayOrder)];
			//entity.FeatureOptionDisplayOrder = (Convert.IsDBNull(reader["FeatureOptionDisplayOrder"]))?(int)0:(System.Int32)reader["FeatureOptionDisplayOrder"];
			entity.FeatureOptionDefaultOption = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionDefaultOption)];
			//entity.FeatureOptionDefaultOption = (Convert.IsDBNull(reader["FeatureOptionDefaultOption"]))?false:(System.Boolean)reader["FeatureOptionDefaultOption"];
			entity.FeatureOptionEnabled = (System.Boolean)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionEnabled)];
			//entity.FeatureOptionEnabled = (Convert.IsDBNull(reader["FeatureOptionEnabled"]))?false:(System.Boolean)reader["FeatureOptionEnabled"];
			entity.FeatureOptionFeatureOptionTypeId = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureOptionTypeId)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionFeatureOptionTypeId)];
			//entity.FeatureOptionFeatureOptionTypeId = (Convert.IsDBNull(reader["FeatureOptionFeatureOptionTypeID"]))?(int)0:(System.Int32?)reader["FeatureOptionFeatureOptionTypeID"];
			entity.FeatureOptionRegularExpression = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionRegularExpression)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionRegularExpression)];
			//entity.FeatureOptionRegularExpression = (Convert.IsDBNull(reader["FeatureOptionRegularExpression"]))?string.Empty:(System.String)reader["FeatureOptionRegularExpression"];
			entity.FeatureOptionTypeId = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeId)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeId)];
			//entity.FeatureOptionTypeId = (Convert.IsDBNull(reader["FeatureOptionTypeID"]))?(int)0:(System.Int32?)reader["FeatureOptionTypeID"];
			entity.FeatureOptionTypeName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeName)];
			//entity.FeatureOptionTypeName = (Convert.IsDBNull(reader["FeatureOptionTypeName"]))?string.Empty:(System.String)reader["FeatureOptionTypeName"];
			entity.FeatureOptionTypeDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDescription)];
			//entity.FeatureOptionTypeDescription = (Convert.IsDBNull(reader["FeatureOptionTypeDescription"]))?string.Empty:(System.String)reader["FeatureOptionTypeDescription"];
			entity.FeatureOptionTypeDisplayOrder = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDisplayOrder)))?null:(System.Int16?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.FeatureOptionTypeDisplayOrder)];
			//entity.FeatureOptionTypeDisplayOrder = (Convert.IsDBNull(reader["FeatureOptionTypeDisplayOrder"]))?(short)0:(System.Int16?)reader["FeatureOptionTypeDisplayOrder"];
			entity.Wholesaler_ProductProductId = (System.Int32)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductProductId)];
			//entity.Wholesaler_ProductProductId = (Convert.IsDBNull(reader["Wholesaler_ProductProductID"]))?(int)0:(System.Int32)reader["Wholesaler_ProductProductID"];
			entity.Wholesaler_ProductName = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductName)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductName)];
			//entity.Wholesaler_ProductName = (Convert.IsDBNull(reader["Wholesaler_ProductName"]))?string.Empty:(System.String)reader["Wholesaler_ProductName"];
			entity.Wholesaler_ProductDescription = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescription)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescription)];
			//entity.Wholesaler_ProductDescription = (Convert.IsDBNull(reader["Wholesaler_ProductDescription"]))?string.Empty:(System.String)reader["Wholesaler_ProductDescription"];
			entity.Wholesaler_ProductDisplayNameAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayNameAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayNameAlt)];
			//entity.Wholesaler_ProductDisplayNameAlt = (Convert.IsDBNull(reader["Wholesaler_ProductDisplayNameAlt"]))?string.Empty:(System.String)reader["Wholesaler_ProductDisplayNameAlt"];
			entity.Wholesaler_ProductDescriptionAlt = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescriptionAlt)))?null:(System.String)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDescriptionAlt)];
			//entity.Wholesaler_ProductDescriptionAlt = (Convert.IsDBNull(reader["Wholesaler_ProductDescriptionAlt"]))?string.Empty:(System.String)reader["Wholesaler_ProductDescriptionAlt"];
			entity.Wholesaler_ProductDisplayOrder = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayOrder)))?null:(System.Int32?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductDisplayOrder)];
			//entity.Wholesaler_ProductDisplayOrder = (Convert.IsDBNull(reader["Wholesaler_ProductDisplayOrder"]))?(int)0:(System.Int32?)reader["Wholesaler_ProductDisplayOrder"];
			entity.Wholesaler_ProductEnabled = (reader.IsDBNull(((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductEnabled)))?null:(System.Boolean?)reader[((int)Vw_FeatureOptionsForModeratorsColumn.Wholesaler_ProductEnabled)];
			//entity.Wholesaler_ProductEnabled = (Convert.IsDBNull(reader["Wholesaler_ProductEnabled"]))?false:(System.Boolean?)reader["Wholesaler_ProductEnabled"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_FeatureOptionsForModerators"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_FeatureOptionsForModerators"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_FeatureOptionsForModerators entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32)dataRow["ModeratorID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.PriCustomerNumber = (Convert.IsDBNull(dataRow["PriCustomerNumber"]))?string.Empty:(System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (Convert.IsDBNull(dataRow["SecCustomerNumber"]))?string.Empty:(System.String)dataRow["SecCustomerNumber"];
			entity.ExternalModeratorNumber = (Convert.IsDBNull(dataRow["ExternalModeratorNumber"]))?string.Empty:(System.String)dataRow["ExternalModeratorNumber"];
			entity.Moderator_FeatureId = (Convert.IsDBNull(dataRow["Moderator_FeatureID"]))?(int)0:(System.Int32)dataRow["Moderator_FeatureID"];
			entity.Moderator_FeatureFeatureId = (Convert.IsDBNull(dataRow["Moderator_FeatureFeatureID"]))?(int)0:(System.Int32)dataRow["Moderator_FeatureFeatureID"];
			entity.Moderator_FeatureFeatureOptionId = (Convert.IsDBNull(dataRow["Moderator_FeatureFeatureOptionID"]))?(int)0:(System.Int32)dataRow["Moderator_FeatureFeatureOptionID"];
			entity.Moderator_FeatureEnabled = (Convert.IsDBNull(dataRow["Moderator_FeatureEnabled"]))?false:(System.Boolean)dataRow["Moderator_FeatureEnabled"];
			entity.Moderator_FeatureFeatureOptionValue = (Convert.IsDBNull(dataRow["Moderator_FeatureFeatureOptionValue"]))?string.Empty:(System.String)dataRow["Moderator_FeatureFeatureOptionValue"];
			entity.FeatureId = (Convert.IsDBNull(dataRow["FeatureID"]))?(int)0:(System.Int32)dataRow["FeatureID"];
			entity.FeatureProductId = (Convert.IsDBNull(dataRow["FeatureProductID"]))?(int)0:(System.Int32)dataRow["FeatureProductID"];
			entity.FeatureName = (Convert.IsDBNull(dataRow["FeatureName"]))?string.Empty:(System.String)dataRow["FeatureName"];
			entity.FeatureDisplayName = (Convert.IsDBNull(dataRow["FeatureDisplayName"]))?string.Empty:(System.String)dataRow["FeatureDisplayName"];
			entity.FeatureDescription = (Convert.IsDBNull(dataRow["FeatureDescription"]))?string.Empty:(System.String)dataRow["FeatureDescription"];
			entity.FeatureDisplayNameAlt = (Convert.IsDBNull(dataRow["FeatureDisplayNameAlt"]))?string.Empty:(System.String)dataRow["FeatureDisplayNameAlt"];
			entity.FeatureDescriptionAlt = (Convert.IsDBNull(dataRow["FeatureDescriptionAlt"]))?string.Empty:(System.String)dataRow["FeatureDescriptionAlt"];
			entity.FeatureDefaultOption = (Convert.IsDBNull(dataRow["FeatureDefaultOption"]))?false:(System.Boolean)dataRow["FeatureDefaultOption"];
			entity.FeatureEnabled = (Convert.IsDBNull(dataRow["FeatureEnabled"]))?false:(System.Boolean)dataRow["FeatureEnabled"];
			entity.FeatureDisplayOrder = (Convert.IsDBNull(dataRow["FeatureDisplayOrder"]))?(int)0:(System.Int32)dataRow["FeatureDisplayOrder"];
			entity.FeatureDisplayOnlyToCustomer = (Convert.IsDBNull(dataRow["FeatureDisplayOnlyToCustomer"]))?false:(System.Boolean)dataRow["FeatureDisplayOnlyToCustomer"];
			entity.FeatureDisplayInAmpSite = (Convert.IsDBNull(dataRow["FeatureDisplayInAMPSite"]))?false:(System.Boolean)dataRow["FeatureDisplayInAMPSite"];
			entity.FeatureDisplayToCustomer = (Convert.IsDBNull(dataRow["FeatureDisplayToCustomer"]))?false:(System.Boolean)dataRow["FeatureDisplayToCustomer"];
			entity.FeatureDisplayToModerator = (Convert.IsDBNull(dataRow["FeatureDisplayToModerator"]))?false:(System.Boolean)dataRow["FeatureDisplayToModerator"];
			entity.FeatureOptionId = (Convert.IsDBNull(dataRow["FeatureOptionID"]))?(int)0:(System.Int32)dataRow["FeatureOptionID"];
			entity.FeatureOptionFeatureId = (Convert.IsDBNull(dataRow["FeatureOptionFeatureID"]))?(int)0:(System.Int32)dataRow["FeatureOptionFeatureID"];
			entity.FeatureOptionName = (Convert.IsDBNull(dataRow["FeatureOptionName"]))?string.Empty:(System.String)dataRow["FeatureOptionName"];
			entity.FeatureOptionDisplayName = (Convert.IsDBNull(dataRow["FeatureOptionDisplayName"]))?string.Empty:(System.String)dataRow["FeatureOptionDisplayName"];
			entity.FeatureOptionDescription = (Convert.IsDBNull(dataRow["FeatureOptionDescription"]))?string.Empty:(System.String)dataRow["FeatureOptionDescription"];
			entity.FeatureOptionDisplayNameAlt = (Convert.IsDBNull(dataRow["FeatureOptionDisplayNameAlt"]))?string.Empty:(System.String)dataRow["FeatureOptionDisplayNameAlt"];
			entity.FeatureOptionDescriptionAlt = (Convert.IsDBNull(dataRow["FeatureOptionDescriptionAlt"]))?string.Empty:(System.String)dataRow["FeatureOptionDescriptionAlt"];
			entity.FeatureOptionValue = (Convert.IsDBNull(dataRow["FeatureOptionValue"]))?string.Empty:(System.String)dataRow["FeatureOptionValue"];
			entity.FeatureOptionDisplayOrder = (Convert.IsDBNull(dataRow["FeatureOptionDisplayOrder"]))?(int)0:(System.Int32)dataRow["FeatureOptionDisplayOrder"];
			entity.FeatureOptionDefaultOption = (Convert.IsDBNull(dataRow["FeatureOptionDefaultOption"]))?false:(System.Boolean)dataRow["FeatureOptionDefaultOption"];
			entity.FeatureOptionEnabled = (Convert.IsDBNull(dataRow["FeatureOptionEnabled"]))?false:(System.Boolean)dataRow["FeatureOptionEnabled"];
			entity.FeatureOptionFeatureOptionTypeId = (Convert.IsDBNull(dataRow["FeatureOptionFeatureOptionTypeID"]))?(int)0:(System.Int32?)dataRow["FeatureOptionFeatureOptionTypeID"];
			entity.FeatureOptionRegularExpression = (Convert.IsDBNull(dataRow["FeatureOptionRegularExpression"]))?string.Empty:(System.String)dataRow["FeatureOptionRegularExpression"];
			entity.FeatureOptionTypeId = (Convert.IsDBNull(dataRow["FeatureOptionTypeID"]))?(int)0:(System.Int32?)dataRow["FeatureOptionTypeID"];
			entity.FeatureOptionTypeName = (Convert.IsDBNull(dataRow["FeatureOptionTypeName"]))?string.Empty:(System.String)dataRow["FeatureOptionTypeName"];
			entity.FeatureOptionTypeDescription = (Convert.IsDBNull(dataRow["FeatureOptionTypeDescription"]))?string.Empty:(System.String)dataRow["FeatureOptionTypeDescription"];
			entity.FeatureOptionTypeDisplayOrder = (Convert.IsDBNull(dataRow["FeatureOptionTypeDisplayOrder"]))?(short)0:(System.Int16?)dataRow["FeatureOptionTypeDisplayOrder"];
			entity.Wholesaler_ProductProductId = (Convert.IsDBNull(dataRow["Wholesaler_ProductProductID"]))?(int)0:(System.Int32)dataRow["Wholesaler_ProductProductID"];
			entity.Wholesaler_ProductName = (Convert.IsDBNull(dataRow["Wholesaler_ProductName"]))?string.Empty:(System.String)dataRow["Wholesaler_ProductName"];
			entity.Wholesaler_ProductDescription = (Convert.IsDBNull(dataRow["Wholesaler_ProductDescription"]))?string.Empty:(System.String)dataRow["Wholesaler_ProductDescription"];
			entity.Wholesaler_ProductDisplayNameAlt = (Convert.IsDBNull(dataRow["Wholesaler_ProductDisplayNameAlt"]))?string.Empty:(System.String)dataRow["Wholesaler_ProductDisplayNameAlt"];
			entity.Wholesaler_ProductDescriptionAlt = (Convert.IsDBNull(dataRow["Wholesaler_ProductDescriptionAlt"]))?string.Empty:(System.String)dataRow["Wholesaler_ProductDescriptionAlt"];
			entity.Wholesaler_ProductDisplayOrder = (Convert.IsDBNull(dataRow["Wholesaler_ProductDisplayOrder"]))?(int)0:(System.Int32?)dataRow["Wholesaler_ProductDisplayOrder"];
			entity.Wholesaler_ProductEnabled = (Convert.IsDBNull(dataRow["Wholesaler_ProductEnabled"]))?false:(System.Boolean?)dataRow["Wholesaler_ProductEnabled"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_FeatureOptionsForModeratorsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsFilterBuilder : SqlFilterBuilder<Vw_FeatureOptionsForModeratorsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilterBuilder class.
		/// </summary>
		public Vw_FeatureOptionsForModeratorsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForModeratorsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForModeratorsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForModeratorsFilterBuilder

	#region Vw_FeatureOptionsForModeratorsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_FeatureOptionsForModerators"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_FeatureOptionsForModeratorsParameterBuilder : ParameterizedSqlFilterBuilder<Vw_FeatureOptionsForModeratorsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsParameterBuilder class.
		/// </summary>
		public Vw_FeatureOptionsForModeratorsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_FeatureOptionsForModeratorsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_FeatureOptionsForModeratorsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_FeatureOptionsForModeratorsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_FeatureOptionsForModeratorsParameterBuilder
} // end namespace
